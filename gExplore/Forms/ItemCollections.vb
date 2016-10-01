Imports System.Windows.Forms
Imports Google.Documents
Imports Google.GData.Client

Public Class ItemCollections

    Private p_gd As gExplore.GoogleDocs
    Private p_Collections As List(Of String)
    Private p_Doc As Document
    Private p_RequireRefresh As Boolean = False
    Private p_CurrentFolderInListView As Document

    ''' <summary>
    ''' Get a value indicating if the listview should be refreshed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetRequireRefresh As Boolean
        Get
            Return p_RequireRefresh
        End Get
    End Property

    Public Sub New(gdocs As gExplore.GoogleDocs, Collections As List(Of String), Doc As Document, CurrentFolderInListView As Document)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_gd = gdocs
        p_Collections = Collections
        p_Doc = Doc
        p_CurrentFolderInListView = CurrentFolderInListView

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If IsNothing(p_gd.Request) = True Then
            p_gd.Request = New DocumentsRequest(p_gd.GetRequestSettings())
            p_gd.Request.Proxy = p_gd.ProxyServer
        End If

        Me.Cursor = Cursors.WaitCursor

        DescendTreeView(FoldersTreeView.Nodes)

        Me.Cursor = Cursors.Default

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    ''' <summary>
    ''' Recursively go through the TreeNodes seeing what's checked and what's not.
    ''' </summary>
    ''' <param name="nodes"></param>
    ''' <remarks></remarks>
    Private Sub DescendTreeView(nodes As TreeNodeCollection)

        For Each n As TreeNode In nodes

            Dim ParentCollection As Document = TryCast(n.Tag, Document)

            If n.Checked = True Then

                ' Don't add it to the collection if it is already in that collection.

                If p_Collections.Contains(ParentCollection.Self) = False Then

                    Try

                        If IsNothing(p_gd.Request) = True Then
                            p_gd.Request = New DocumentsRequest(p_gd.GetRequestSettings())
                            p_gd.Request.Proxy = p_gd.ProxyServer
                        End If

                        ' Add the document to the collection.             
                        p_gd.Request.MoveDocumentTo(ParentCollection, p_Doc)

                        ' If this is the collection being viewed in the listview then we need to refresh.
                        If IsNothing(p_CurrentFolderInListView) = False Then
                            If ParentCollection.ResourceId = p_CurrentFolderInListView.ResourceId Then
                                p_RequireRefresh = True
                            End If
                        Else
                            p_RequireRefresh = True
                        End If

                    Catch ex As Exception

                        gExplore.Logging.WriteErrorToApplicationLog(ex)
                        MsgBox("Unable to add to the '" & ParentCollection.Title & "' collection. Make sure you have permissions to write to this collection.", MsgBoxStyle.Critical)

                    End Try

                End If

            Else

                ' Was it removed from this collection?

                If p_Collections.Contains(ParentCollection.Self) = True Then

                    ' Outside the Try so the headers can be cleared in the Finally.
                    Dim factory As GDataRequestFactory = DirectCast(p_gd.Service.RequestFactory, GDataRequestFactory)

                    Try

                        ' Set ETag because we're making an update
                        factory.CustomHeaders.Clear()
                        factory.CustomHeaders.Add("If-Match: " & p_Doc.DocumentEntry.Etag)

                        Dim uri As New Uri(ParentCollection.Self & "/contents/" & p_Doc.ResourceId)

                        p_gd.Service.Delete(uri)

                        ' If this is the collection being viewed in the listview then we need to refresh.
                        If IsNothing(p_CurrentFolderInListView) = False Then
                            If ParentCollection.ResourceId = p_CurrentFolderInListView.ResourceId Then
                                p_RequireRefresh = True
                            End If
                        End If

                    Catch ex As Exception

                        gExplore.Logging.WriteErrorToApplicationLog(ex)
                        MsgBox("Unable to remove from the '" & ParentCollection.Title & "' collection. Make sure you have write permissions to this collection.", MsgBoxStyle.Critical)

                    Finally

                        ' Important to clear our headers so they aren't there for the next request.
                        factory.CustomHeaders.Clear()

                    End Try

                End If

            End If

            DescendTreeView(n.Nodes)

        Next

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub BrowseCollection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Load the user's folders.
        RefreshFolders()

    End Sub

    ''' <summary>
    ''' Refresh the list of folders shown in the treeview.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshFolders()

        Me.Cursor = Cursors.WaitCursor

        ' Clear all the nodes.
        FoldersTreeView.Nodes.Clear()

        ' Get a list of the folders.
        Dim FoldersRequest As New DocumentsRequest(p_gd.GetRequestSettings())
        Dim feed As Google.GData.Client.Feed(Of Document) = FoldersRequest.GetFolders()

        Dim all As New List(Of Document)

        ' this takes care of paging the results in
        For Each entry As Document In feed.Entries
            all.Add(entry)
        Next

        For Each entry As Document In all

            ' let's add those with no parents for the toplevel
            If entry.ParentFolders.Count = 0 Then

                If entry.Type <> Document.DocumentType.Folder Then

                    ' These are "Items with no folder"
                    AddToTreeView(FoldersTreeView.Nodes, entry)

                Else

                    Dim n As TreeNode = AddToTreeView(FoldersTreeView.Nodes, entry)
                    AddAllChildren(n.Nodes, entry, all)

                End If

            End If

        Next

        Me.Cursor = Cursors.Default

    End Sub

    Private Function AddToTreeView(parent As TreeNodeCollection, doc As Document) As TreeNode

        Dim node As New TreeNode(doc.Title)
        node.Tag = doc

        Dim menuitem As New ToolStripMenuItem
        menuitem.Text = doc.Title

        node.ImageIndex = 0
        node.SelectedImageIndex = 0

        parent.Add(node)

        If p_Collections.Contains(doc.Self) = True Then

            node.Checked = True

            ' Expand all the nodes down to this one.

            Dim n As TreeNode = node.Parent

            While IsNothing(n) = False
                n.Expand()
                n = n.Parent
            End While

        End If

        Return node

    End Function

    Private Function FindParentTreeNode(coll As TreeNodeCollection, doc As Document) As TreeNodeCollection

        For Each n As TreeNode In coll

            Dim d As Document = TryCast(n.Tag, Document)

            If doc.ParentFolders.Contains(d.Self) Then
                ' found it.
                Return n.Nodes
            End If

            Dim x As TreeNodeCollection = FindParentTreeNode(n.Nodes, doc)

            If x IsNot Nothing Then
                Return x
            End If

        Next

        Return Nothing

    End Function

    Private Function CreateParentTreeNode(doc As Document, all As List(Of Document)) As TreeNodeCollection

        Dim ret As TreeNode = Nothing

        For Each d As Document In all

            If doc.ParentFolders.Contains(d.Self) Then

                Dim parent As TreeNodeCollection = Nothing

                If d.ParentFolders.Count <> 0 Then
                    parent = FindParentTreeNode(FoldersTreeView.Nodes, d)
                End If

                ret = AddToTreeView(If(parent Is Nothing, FoldersTreeView.Nodes, parent), d)

                Return ret.Nodes

            End If

        Next

        Return FoldersTreeView.Nodes

    End Function

    Private Sub AddAllChildren(col As TreeNodeCollection, entry As Document, all As List(Of Document))

        For Each d As Document In all

            If d.ParentFolders.Contains(entry.Self) Then

                Dim n As TreeNode = AddToTreeView(col, d)
                AddAllChildren(n.Nodes, d, all)

            End If

        Next

    End Sub

End Class
