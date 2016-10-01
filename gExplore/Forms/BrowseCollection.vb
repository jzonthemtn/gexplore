Imports System.Windows.Forms
Imports Google.Documents
Imports Google.GData.Client

Public Class BrowseCollection

    Private gd As gExplore.GoogleDocs
    Private p_SelectedCollections As New List(Of Document)
    Private p_ShowCheckBoxes As Boolean
    Private p_ShowRootCollection As Boolean

    Public Sub New(gdocs As gExplore.GoogleDocs, ShowCheckBoxes As Boolean, ShowRootCollection As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gd = gdocs
        p_ShowCheckBoxes = ShowCheckBoxes
        p_ShowRootCollection = ShowRootCollection

        ' Show/hide checkboxes.
        FoldersTreeView.CheckBoxes = ShowCheckBoxes

    End Sub

    Public ReadOnly Property GetSelectedCollections As List(Of Document)
        Get
            Return p_SelectedCollections
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If p_ShowCheckBoxes = True Then

            For Each n As TreeNode In FoldersTreeView.Nodes

                If n.Checked = True Then

                    p_SelectedCollections.Add(TryCast(n.Tag, Document))

                End If

            Next

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Else

            If IsNothing(FoldersTreeView.SelectedNode) = False Then

                If FoldersTreeView.SelectedNode.Text = "Collections" Then

                    ' They picked the top-level root node. So add all of it's children to the list but don't add it.

                    For Each node As TreeNode In FoldersTreeView.SelectedNode.Nodes

                        Dim ChildNodeCollection As Document = TryCast(node.Tag, Document)
                        p_SelectedCollections.Add(ChildNodeCollection)

                    Next

                Else

                    Dim SelectedCollection As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)
                    p_SelectedCollections.Add(SelectedCollection)

                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                MsgBox("No collection is selected.", MsgBoxStyle.Critical)

            End If

        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        p_SelectedCollections = Nothing

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

        Dim RootNode As TreeNode

        If p_ShowRootCollection = True Then

            ' Add a folder for the root collection.
            RootNode = New TreeNode
            RootNode.Text = "Collections"
            FoldersTreeView.Nodes.Add(RootNode)

        End If

        ' Get a list of the folders.

        'If IsNothing(gd.Request) = True Then
        gd.Request = New DocumentsRequest(gd.GetRequestSettings())
        gd.Request.Proxy = gd.ProxyServer
        'End If

        Dim feed As Google.GData.Client.Feed(Of Document) = gd.Request.GetFolders()

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

                    If p_ShowRootCollection = True Then

                        AddToTreeView(RootNode.Nodes, entry)

                    Else

                        AddToTreeView(FoldersTreeView.Nodes, entry)

                    End If

                Else

                    Dim n As TreeNode

                    If p_ShowRootCollection = True Then
                        n = AddToTreeView(RootNode.Nodes, entry)
                    Else
                        n = AddToTreeView(FoldersTreeView.Nodes, entry)
                    End If

                    AddAllChildren(n.Nodes, entry, all)

                End If

            End If

        Next

        ' Expand the root node.
        RootNode.Expand()

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
