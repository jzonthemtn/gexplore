Imports Google.GData.Documents
Imports Google.GData.Client
Imports System.ComponentModel
Imports Google.Documents
Imports System.IO
Imports Google.GData.Client.ResumableUpload
Imports System.Windows.Forms.ListView
Imports gExplore.gExplore
Imports Google.GData.AccessControl
Imports System.Net
Imports System.Net.Mail
Imports System.Threading.Tasks

Public Class MainForm

    ' Private member variables.
    Private gd As gExplore.GoogleDocs

    ' The currently selected tab (first is documents, the rest are of search results).
    Private p_SelectedTab As TabPage

    Public Sub New(gdocs As gExplore.GoogleDocs)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gd = gdocs

        ' Set the listview column sorter.
        Dim lvwColumnSorter As New ListViewColumnSorter
        DocumentsListListView.ListViewItemSorter = lvwColumnSorter
        DocumentsListListView.Tag = lvwColumnSorter

        ' Add a handler for the listview's columnclick to sort so we don't duplicate the code. Just use the handler for the search result listviews.
        AddHandler DocumentsListListView.ColumnClick, AddressOf ListViewColumnClick

    End Sub

    ''' <summary>
    ''' Refresh the list of folders shown in the treeview.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshFolders()

        Me.Cursor = Cursors.WaitCursor

        ' Clear all the nodes.
        FoldersTreeView.Nodes.Clear()

        ' Create a top-level node for Collections.
        Dim CollectionsNode As New TreeNode("Collections")
        CollectionsNode.SelectedImageIndex = 7
        CollectionsNode.ImageIndex = 7
        FoldersTreeView.Nodes.Add(CollectionsNode)

        ' Select this top level node.
        FoldersTreeView.SelectedNode = CollectionsNode

        ' Get a list of the folders.

        'If IsNothing(gd.Request) = True Then
        gd.Request = New DocumentsRequest(gd.GetRequestSettings())
        gd.Request.Proxy = gd.ProxyServer
        'End If

        Dim feed As Feed(Of Document) = gd.Request.GetFolders()

        Dim all As New List(Of Document)

        ' this takes care of paging the results in

        'For Each entry As Document In feed.Entries
        '    all.Add(entry)
        'Next

        all.AddRange(feed.Entries)

        ' TODO: Sort by name?

        For Each entry As Document In all

            ' let's add those with no parents for the toplevel
            If entry.ParentFolders.Count = 0 Then

                If entry.Type <> Document.DocumentType.Folder Then

                    ' These are "Items with no folder"
                    AddToTreeView(CollectionsNode.Nodes, entry)

                Else

                    Dim n As TreeNode = AddToTreeView(CollectionsNode.Nodes, entry)
                    AddAllChildren(n.Nodes, entry, all)

                End If

            End If

        Next

        CollectionsNode.Expand()

        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' Refresh the list of documents shown in the listview.
    ''' </summary>
    ''' <param name="ParentDocument"></param>
    ''' <remarks></remarks>
    Private Sub UpdateDocList(Optional ParentDocument As Document = Nothing)

        Me.Cursor = Cursors.WaitCursor

        DocumentsListListView.Items.Clear()

        Try

            If IsNothing(gd.Request) = True Then
                gd.Request = New DocumentsRequest(gd.GetRequestSettings())
                gd.Request.Proxy = gd.ProxyServer
            End If

            Dim documentFeed As Feed(Of Document) = Nothing

            If IsNothing(ParentDocument) = False Then

                documentFeed = gd.Request.GetFolderContent(ParentDocument)

            Else

                'documentFeed = gd.Request.GetEverything()


                ''Dim query As New DocumentsListQuery
                'Dim query As New FolderQuery()
                'query.ShowFolders = False
                'query.ShowRoot = False
                'query.ShowDeleted = False

                'Dim feed As DocumentsFeed = gd.Service.Query(query)

            End If

            'If Not documentFeed Is Nothing Then

            '    Console.WriteLine("Beginning loop of documents: Count = " & documentFeed.Entries.Count.ToString)

            '    Parallel.For(0, documentFeed.Entries.Count - 1, Sub(i)

            '                                                        Dim doc As Document = documentFeed.Entries(i)

            '                                                        Console.WriteLine("In UpdateDocList : " & doc.Title)

            '                                                        ' Is it a folder?
            '                                                        If doc.DocumentEntry.IsFolder = False Then

            '                                                            ' In a specific folder?
            '                                                            If IsNothing(ParentDocument) = False Then

            '                                                                AddDocumentToListView(doc)

            '                                                            Else

            '                                                                ' Not in a folder.
            '                                                                If doc.DocumentEntry.ParentFolders.Count = 0 Then
            '                                                                    AddDocumentToListView(doc)
            '                                                                End If

            '                                                            End If

            '                                                        End If

            '                                                    End Sub)

            'End If

            If Not documentFeed Is Nothing Then

                For Each doc As Document In documentFeed.Entries

                    ' Is it a folder?
                    If doc.DocumentEntry.IsFolder = False Then

                        ' In a specific folder?
                        If IsNothing(ParentDocument) = False Then

                            AddDocumentToListView(doc)

                        Else

                            ' Not in a folder.
                            If doc.DocumentEntry.ParentFolders.Count = 0 Then
                                AddDocumentToListView(doc)
                            End If

                        End If

                    End If

                Next

            End If

            If DocumentsListListView.Items.Count > 0 Then

                For Each column As ColumnHeader In DocumentsListListView.Columns
                    column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Next

            End If

            ToolStripStatusLabel1.Text = DocumentsListListView.Items.Count.ToString & " file(s)."

        Catch ex As Exception

            Me.Cursor = Cursors.Default

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            MessageBox.Show("Error retrieving documents: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' Remove the selected file from its collection.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveFromCollection()

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim DeleteMessage As String = "Are you sure you want to remove the " & DocumentsListListView.SelectedItems.Count.ToString & " file(s) from the '" & FoldersTreeView.SelectedNode.Text & "' collection?"

            If MessageBox.Show(DeleteMessage, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

                For Each lvi As ListViewItem In DocumentsListListView.SelectedItems

                    Try

                        Dim doc As Document = CType(lvi.Tag, Document)

                        Me.Cursor = Cursors.WaitCursor

                        gd.Service.Delete(doc.AtomEntry, False)

                        ' Remove it from the listview.
                        lvi.Remove()

                    Catch ex As Exception

                        Me.Cursor = Cursors.Default

                        gExplore.Logging.WriteErrorToApplicationLog(ex)

                        If DocumentsListListView.SelectedItems.Count > 1 Then

                            ' If they were trying to remove multiple files from a collection...
                            If MsgBox("Unable to remove " & lvi.Text & " from the collection. Make sure you have edit permissions to this file and collection. Continue with the other selected files?", MsgBoxStyle.Critical, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                                Exit For
                            End If

                        Else

                            ' If they were only trying to remove 1 file from a collection...
                            MsgBox("Unable to remove " & lvi.Text & " from the collection. Make sure you have edit permissions to this file and collection.", MsgBoxStyle.Critical)

                        End If

                    Finally

                        Me.Cursor = Cursors.Default

                    End Try

                Next

            End If

        End If

    End Sub

    Private Sub OpenSelectedDocument(DocEntry As DocumentEntry)

        Me.Cursor = Cursors.WaitCursor

        Try

            Process.Start(DocEntry.AlternateUri.ToString())

        Catch ex As Win32Exception

            gExplore.Logging.WriteErrorToApplicationLog(ex)

            ' nothing is registered to handle URLs, so let's use IE!
            Process.Start("IExplore.exe", DocEntry.AlternateUri.ToString())

        Finally

            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub AddAllChildren(col As TreeNodeCollection, entry As Document, all As List(Of Document))

        For Each d As Document In all

            If d.ParentFolders.Contains(entry.Self) Then

                Dim n As TreeNode = AddToTreeView(col, d)
                AddAllChildren(n.Nodes, d, all)

            End If

        Next

    End Sub

    Private Function FindEntry(coll As TreeNodeCollection, entry As Document) As TreeNode

        For Each n As TreeNode In coll

            ' title is not specific enough
            Dim d As Document = TryCast(n.Tag, Document)

            If d.Id = entry.Id Then
                Return n
            End If

            Dim x As TreeNode = FindEntry(n.Nodes, entry)

            If x IsNot Nothing Then
                Return x
            End If

        Next

        Return Nothing

    End Function

    Private Function AddToTreeView(parent As TreeNodeCollection, doc As Document) As TreeNode

        Dim node As New TreeNode(doc.Title)
        node.Tag = doc

        Dim menuitem As New ToolStripMenuItem
        menuitem.Text = doc.Title

        If doc.Type = Document.DocumentType.Folder Then

            node.ImageIndex = 7
            node.SelectedImageIndex = 7

        ElseIf doc.Type = Document.DocumentType.Document Then

            node.ImageIndex = 2
            node.SelectedImageIndex = 2

            menuitem.ImageIndex = 2

        ElseIf doc.Type = Document.DocumentType.Spreadsheet Then

            node.ImageIndex = 3
            node.SelectedImageIndex = 3

            menuitem.ImageIndex = 3

        ElseIf doc.Type = Document.DocumentType.Presentation Then

            node.ImageIndex = 4
            node.SelectedImageIndex = 4

            menuitem.ImageIndex = 4

        ElseIf doc.Type = Document.DocumentType.PDF Then

            node.ImageIndex = 5
            node.SelectedImageIndex = 5

            menuitem.ImageIndex = 5

        Else

            node.ImageIndex = 2
            node.SelectedImageIndex = 2

        End If

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

    Private Sub documentsView_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles FoldersTreeView.AfterCollapse

        Dim node As TreeNode = e.Node

        Dim d As Document = TryCast(node.Tag, Document)
        Dim type As Document.DocumentType = If(d Is Nothing, Document.DocumentType.Folder, d.Type)

        If node.Nodes.Count > 0 AndAlso type = Document.DocumentType.Folder Then

            node.SelectedImageIndex = 7
            node.ImageIndex = 7

        End If

    End Sub

    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Set the image list for the tray menu.
        TrayContextMenuStrip.ImageList = imageList

        ' Load the user's folders.
        RefreshFolders()

        ' First run? Show welcome?
        If gExplore.SettingsHandler.FirstRun = True Then

            Dim welcome As New Welcome
            welcome.TopMost = True
            welcome.Show()

        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Application.Exit()

    End Sub

    ''' <summary>
    ''' Upload a file to Google Docs.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UploadFile()

        Dim ParentCollection As Document = Nothing

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            ParentCollection = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

        End If

        Dim up As New Upload(gd, ParentCollection)

        If up.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If IsNothing(ParentCollection) = False Then

                ' Is this the folder we are looking at?

                If up.GetParentCollections(0).ResourceId = ParentCollection.ResourceId Then

                    ' Yes, so let's update the document list.

                    UpdateDocList(ParentCollection)

                End If

            End If

        End If

        ' Clean up.
        up.Dispose()

    End Sub

    Private Sub UploadFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadFileToolStripMenuItem.Click

        UploadFile()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click

        About.ShowDialog()

    End Sub

    Private Sub OpenInBrowserToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenInBrowserToolStripMenuItem.Click

        If (DocumentsListListView.SelectedItems.Count > 0) Then

            Try

                Dim doc As Document = CType(DocumentsListListView.SelectedItems(0).Tag, Document)
                OpenSelectedDocument(doc.DocumentEntry)

            Catch ex As Exception

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("Unable to open this document.", MsgBoxStyle.Critical)

            End Try

        End If

    End Sub

    Private Sub DocumentListContextMenuStrip_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles DocumentListContextMenuStrip.Opening

        ' Enable/disable the context menu depending on what's selected.

        If DocumentsListListView.SelectedItems.Count = 0 Then

            OpenInBrowserToolStripMenuItem.Enabled = False
            RemoveFromCollectionToolStripMenuItem.Enabled = False
            ExportToolStripMenuItem.Enabled = False
            RenameToolStripMenuItem.Enabled = False
            StarredToolStripMenuItem.Enabled = False
            DocumentTitleToolStripMenuItem.Enabled = False
            ViewFileCollectionsToolStripMenuItem.Enabled = False
            AdvancedPropertiesToolStripMenuItem.Enabled = False
            DeleteFileToolStripMenuItem.Enabled = False
            ShareToolStripMenuItem.Enabled = False
            ViewSharingToolStripMenuItem.Enabled = False
            SelectToolStripMenuItem.Enabled = False
            SendToMyKindleToolStripMenuItem.Enabled = False
            UploadNewVersionToolStripMenuItem.Enabled = False
            EmailFileToolStripMenuItem.Enabled = False
            EditLocallyToolStripMenuItem.Enabled = False

        Else

            OpenInBrowserToolStripMenuItem.Enabled = True
            ExportToolStripMenuItem.Enabled = True
            RenameToolStripMenuItem.Enabled = True
            StarredToolStripMenuItem.Enabled = True
            DocumentTitleToolStripMenuItem.Enabled = True
            ViewFileCollectionsToolStripMenuItem.Enabled = True
            AdvancedPropertiesToolStripMenuItem.Enabled = True
            ShareToolStripMenuItem.Enabled = True
            ViewSharingToolStripMenuItem.Enabled = True
            DeleteFileToolStripMenuItem.Enabled = True
            SelectToolStripMenuItem.Enabled = True
            EmailFileToolStripMenuItem.Enabled = True

            Dim doc As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            ' Only enable the remove from collection menu if it belongs to a collection.
            If doc.DocumentEntry.ParentFolders.Count > 0 Then
                RemoveFromCollectionToolStripMenuItem.Enabled = True
            Else
                RemoveFromCollectionToolStripMenuItem.Enabled = False
            End If

            ' Change text of menu depending upon selection.
            If doc.DocumentEntry.IsStarred = True Then
                StarredToolStripMenuItem.Text = "Unstar File"
            Else
                StarredToolStripMenuItem.Text = "Star File"
            End If

            ' Update is only for docs.
            If doc.DocumentEntry.IsDocument = True Then
                UploadNewVersionToolStripMenuItem.Enabled = True
                EditLocallyToolStripMenuItem.Enabled = False
            Else
                UploadNewVersionToolStripMenuItem.Enabled = False
                EditLocallyToolStripMenuItem.Enabled = True
            End If

            ' Only enable kindle if all are documents or PDFs.
            Dim EnableSendToKindle As Boolean = True
            For Each lvi As ListViewItem In DocumentsListListView.SelectedItems
                If doc.DocumentEntry.IsDocument Or doc.DocumentEntry.IsPDF = False Then
                    EnableSendToKindle = False
                    Exit For
                End If
            Next
            SendToMyKindleToolStripMenuItem.Enabled = EnableSendToKindle

        End If

        ' Downloading directory listings is not available for the root collection because it's not easily queried.
        Dim f As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)
        If IsNothing(f) = True Then
            DownloadDirectoryListingToolStripMenuItem.Enabled = False
        Else
            DownloadDirectoryListingToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim d As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            ExportFile(d)

        End If

    End Sub


    ''' <summary>
    ''' Download the selected file from Google Docs.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExportFile(d As Document)

        'Dim ExportUri As String = String.Empty
        Dim ExportFormat As String = String.Empty

        ' Fill the filter based on the document type.

        If d.DocumentEntry.IsPresentation = True Then

            ExportDialog.Filter = "PDF|*.pdf|Microsoft Powerpoint|*.ppt|PNG|*.png"
            'ExportUri = "https://docs.google.com/feeds/download/presentations/Export"

        ElseIf d.DocumentEntry.IsSpreadsheet = True Then

            ExportDialog.Filter = "PDF|*.pdf|HTML|*.html|Microsoft Excel|*.xls|Comma seperated|*.csv|Open Document Spreadsheet|*.ods|Tab seperated|*.tsv"
            'ExportUri = "https://spreadsheets.google.com/feeds/download/spreadsheets/Export"

        ElseIf d.DocumentEntry.IsDocument = True Then

            ExportDialog.Filter = "PDF|*.pdf|ODT|*.odt|Microsoft Word|*.doc|HTML|*.html|RTF|*.rtf|TXT|*.txt|PNG|*.png|ZIP|*.zip"
            'ExportUri = "https://docs.google.com/feeds/download/documents/Export"

        Else

            ExportDialog.Filter = "All Files (*.*)|*.*"

        End If

        ExportDialog.FileName = d.Title
        ExportDialog.Title = "Download File"
        ExportDialog.CheckFileExists = False
        ExportDialog.CheckPathExists = True
        ExportDialog.OverwritePrompt = True
        ExportDialog.ShowHelp = False

        If ExportDialog.ShowDialog() = DialogResult.OK Then

            If DownloadFile(d, ExportDialog.FileName) <> String.Empty Then

                ' Is the file encrypted? 
                If d.Title.EndsWith(".genc") = True Then

                    If MsgBox("The downloaded file may have been encrypted using gExplore prior to uploading. Do you want to decrypt it now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        ' Decrypt the file.
                        Dim df As New DecryptFile(ExportDialog.FileName)
                        df.ShowDialog()

                    End If

                End If

                MsgBox("The file has been downloaded to " & ExportDialog.FileName & ".", MsgBoxStyle.Information)

            End If

        End If

    End Sub

    ''' <summary>
    ''' Write a stream to a local file.
    ''' </summary>
    ''' <param name="InStream"></param>
    ''' <param name="LocalFileName"></param>
    ''' <remarks></remarks>
    Private Sub WriteDownloadStreamToFile(InStream As Stream, LocalFileName As String, d As Document)

        Me.Cursor = Cursors.WaitCursor

        Dim pw As ProgressWindow = Nothing

        If d.QuotaBytesUsed > 0 Then

            ' Only show the progress window if the file is using > 0 quota. 
            ' Not a real good solution because Google Docs formatted files always use 0 quota and they 
            ' could potentially be large.

            pw = New ProgressWindow("Downloading " & d.Title & "...", Convert.ToInt32(d.QuotaBytesUsed))
            pw.Show()

        End If

        ToolStripStatusLabel1.Text = "Downloading " & d.Title & " ..."

        Dim OutStream As New FileStream(LocalFileName, FileMode.Create)

        Dim nBytes As Integer = 2048
        Dim count As Integer = 0
        Dim arr As Byte() = New Byte(nBytes - 1) {}

        ' Running total of the number of bytes downloaded.
        Dim Progress As Long = 0

        ' Set up the progress bar.
        'ToolStripProgressBar1.Minimum = 0
        'ToolStripProgressBar1.Maximum = d.QuotaBytesUsed

        Do

            count = InStream.Read(arr, 0, nBytes)
            OutStream.Write(arr, 0, count)

            Application.DoEvents()

            If IsNothing(pw) = False Then

                ' Only update the progress if there is a progress window.

                pw.IncreaseProgress(count)
                pw.Refresh()

            End If

            Progress = Progress + count

            If d.QuotaBytesUsed > 0 Then

                Dim CurrentValue As Integer = Convert.ToInt32(Math.Round((Progress / d.QuotaBytesUsed) * 100, 0))

                'ToolStripProgressBar1.Value = CurrentValue
                ToolStripStatusLabel1.Text = "Downloading " & d.Title & " ... " & CurrentValue.ToString & "%"

            End If

        Loop While count > 0

        OutStream.Flush()
        OutStream.Close()

        Me.Cursor = Cursors.Default

        InStream.Close()

        If IsNothing(pw) = False Then

            pw.Close()
            pw.Dispose()

        End If

        ToolStripStatusLabel1.Text = Application.ProductName
        'ToolStripProgressBar1.Value = 0

    End Sub

    ''' <summary>
    ''' Download a document to a local file.
    ''' </summary>
    ''' <param name="d"></param>
    ''' <remarks></remarks>
    ''' TODO: Move this to the GoogleDocs class to remove the duplicate code.
    Public Function DownloadFile(d As Document, Optional DownloadFileName As String = "") As String

        Try

            'Get the export format from the document's title.
            Dim ExportFormat As String = Path.GetExtension(d.Title).Replace(".", String.Empty)

            ' Set the local file in the Windows' temp directory.
            Dim LocalFileName As String = Path.Combine(Path.GetTempPath, gExplore.Miscellaneous.SanitizeFileName(d.Title))

            ' For files with no extension, use PDF.
            If ExportFormat = String.Empty Then
                ExportFormat = "pdf"
                LocalFileName = LocalFileName & ".pdf"
            End If

            ' If they've provided a download file name then they've overridden the temp file.
            If DownloadFileName <> String.Empty Then
                LocalFileName = DownloadFileName
            End If

            'If IsNothing(gd.Request) = True Then
            gd.Request = New DocumentsRequest(gd.GetRequestSettings())
            gd.Request.Proxy = gd.ProxyServer
            'End If

            Dim DownloadStream As Stream = gd.Request.Download(d, ExportFormat)

            ' Download the file to the file stream.
            WriteDownloadStreamToFile(DownloadStream, LocalFileName, d)

            ' Success.
            Return LocalFileName

        Catch ex As Exception

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            MsgBox("An error occurred while downloading the file.", MsgBoxStyle.Critical)

            Return String.Empty

        End Try

    End Function

    Private Sub FoldersTreeView_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles FoldersTreeView.AfterSelect

        Dim node As TreeNode = e.Node

        Dim d As Document = TryCast(node.Tag, Document)

        ' Get the files.
        UpdateDocList(d)

        ' Update the location.
        UpdateLocationText(node)

    End Sub

    ''' <summary>
    ''' Find a node somewhere in the treeview.
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindCollectionInTreeNode(doc As Document) As TreeNode

        Dim FoundNode As TreeNode = Nothing

        If IsNothing(doc) = False Then

            Dim nodes As New List(Of TreeNode)

            GetAllChildren(FoldersTreeView.Nodes(0), nodes)

            Parallel.ForEach(nodes, Sub(node As TreeNode, loopstate As ParallelLoopState)

                                        'For Each node As TreeNode In nodes

                                        If IsNothing(node.Tag) = False Then

                                            If TryCast(node.Tag, Document).ResourceId = doc.ResourceId Then

                                                ' We found it.
                                                FoundNode = node
                                                loopstate.Break()
                                                ' Exit For

                                            End If

                                        End If

                                        'Next

                                    End Sub)

        End If

        ' Doesn't exist.
        Return FoundNode

    End Function

    Private Sub GetAllChildren(parentNode As TreeNode, nodes As List(Of TreeNode))

        For Each childNode As TreeNode In parentNode.Nodes
            nodes.Add(childNode)
            GetAllChildren(childNode, nodes)
        Next

    End Sub

    Private Sub UpdateLocationText(node As TreeNode)

        Dim Breadcrumb As New ArrayList

        ' Update the folder text.
        While IsNothing(node) = False

            Breadcrumb.Add(node.Text)
            node = node.Parent

        End While

        ' Clear the current location.
        CurrentDirectoryLabel.Text = String.Empty

        ' Go through the list backwards.
        For x As Integer = 1 To Breadcrumb.Count

            CurrentDirectoryLabel.Text = CurrentDirectoryLabel.Text & " / " & Breadcrumb(Breadcrumb.Count - x)

        Next

    End Sub

    Private Sub AdvancedPropertiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AdvancedPropertiesToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Try

                Dim doc As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

                Dim prop As New FileProperties(doc)
                prop.Show()

            Catch ex As Exception

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("An error occurred while loading the properties of the file.", MsgBoxStyle.Critical)

            End Try

        End If

    End Sub

    Private Sub DownloadToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles DownloadToolStripButton.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim d As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            ExportFile(d)

        End If

    End Sub

    Private Sub DocumentsListListView_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DocumentsListListView.DragDrop

        ' Can only drop files, so check.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            ShowOrHideLog(True)

            Dim files As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())

            Dim ParentCollection As Document = Nothing

            If IsNothing(FoldersTreeView.SelectedNode) = False Then

                ParentCollection = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            End If

            For Each FileName As String In files

                ' Upload the file.
                gd.UploadFile(FileName, ParentCollection, FileName, AddressOf OnDone, AddressOf OnProgress, True)

                ' Log it.
                AppendToLog("Uploading " & FileName)

            Next

        End If

    End Sub

    Private Sub OnDone(sender As Object, args As AsyncOperationCompletedEventArgs)

        Me.Cursor = Cursors.Default

        If IsNothing(args.Error) = False Then

            MsgBox("The file could not be uploaded: " & args.Error.Message)

        Else

            AppendToLog("File uploaded (" & args.UserState.ToString & ")")

            ' Notify that a download has completed.
            gd.DecreaseCurrentDownloads()

        End If

    End Sub

    Private Sub AppendToLog(Log As String)

        LogTextBox.Text = LogTextBox.Text & Now.ToString & ": " & Log & vbNewLine

    End Sub

    Private Sub OnProgress(sender As Object, args As AsyncOperationProgressEventArgs)

        'UploadProgressBar.Value = args.ProgressPercentage
        'UploadProgressLabel.Text = args.ProgressPercentage.ToString & "%"

    End Sub

    Private Sub DocumentsListListView_DragLeave(sender As Object, e As System.EventArgs) Handles DocumentsListListView.DragLeave

        ToolStripStatusLabel1.Text = Application.ProductName

    End Sub

    Private Sub DocumentsListListView_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DocumentsListListView.DragOver

        ' Determine whether file data exists in the drop data. If not, then
        ' the drop effect reflects that the drop cannot occur.
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then

            e.Effect = DragDropEffects.None

        Else

            e.Effect = DragDropEffects.Copy

            Dim files As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
            ToolStripStatusLabel1.Text = "Upload the " & files.Count.ToString & " file(s) to this collection."

        End If

    End Sub

    Private Sub DocumentsListListView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DocumentsListListView.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then

            ' Is it a double-click?
            If e.Clicks = 2 Then

                ' Get the item clicked.
                Dim lvi As ListViewItem = DocumentsListListView.GetItemAt(e.Location.X, e.Location.Y)

                ' If it was an item and not white space...
                If IsNothing(lvi) = False Then

                    ' Get the item's Document.
                    Dim doc As Document = TryCast(lvi.Tag, Document)

                    Try

                        ' If there was a valid Document open it.
                        If IsNothing(doc) = False Then
                            OpenSelectedDocument(doc.DocumentEntry)
                        End If

                    Catch ex As Exception

                        gExplore.Logging.WriteErrorToApplicationLog(ex)
                        MsgBox("Unable to open this document.", MsgBoxStyle.Critical)

                    End Try

                End If

            Else

                If DocumentsListListView.SelectedItems.Count > 0 Then
                    DocumentsListListView.DoDragDrop(DocumentsListListView.SelectedItems, DragDropEffects.Move)
                End If

            End If

        End If

    End Sub

    Private Sub DocumentsListListView_ParentChanged(sender As Object, e As System.EventArgs) Handles DocumentsListListView.ParentChanged

    End Sub

    Private Sub DocumentsListListView_SearchForVirtualItem(sender As Object, e As System.Windows.Forms.SearchForVirtualItemEventArgs) Handles DocumentsListListView.SearchForVirtualItem

    End Sub

    Private Sub DocumentsListListView_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles DocumentsListListView.SelectedIndexChanged

        If DocumentsListListView.SelectedItems.Count > 0 Then
            DownloadToolStripButton.Enabled = True
        Else
            DownloadToolStripButton.Enabled = False
        End If

    End Sub

    Private Sub UploadFileToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles UploadFileToolStripMenuItem1.Click

        UploadFile()

    End Sub

    Private Sub UploadFolderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadFolderToolStripMenuItem.Click

        UploadFolder()

    End Sub

    ''' <summary>
    ''' Upload a folder to Google docs.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UploadFolder()

        Dim ParentCollection As Document = Nothing

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            ParentCollection = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

        End If

        Dim up As New UploadFolder(gd, ParentCollection, Me)

        If up.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If IsNothing(ParentCollection) = False Then

                ' Is this the folder we're looking at?

                If up.GetParentCollections(0).ResourceId = ParentCollection.ResourceId Then

                    ' Yes, so refresh the document list.

                    UpdateDocList(ParentCollection)

                End If

            End If

        End If

        ' Clean up.
        up.Dispose()

    End Sub

    Private Sub UploadFolderToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles UploadFolderToolStripMenuItem1.Click

        UploadFolder()

    End Sub

    Private Sub RefreshToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles RefreshToolStripButton.Click

        Dim ParentDocument As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)
        UpdateDocList(ParentDocument)

    End Sub

    Private Sub FoldersTreeView_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles FoldersTreeView.DragEnter

        Dim data As SelectedListViewItemCollection = e.Data.GetData(GetType(SelectedListViewItemCollection))

        If IsNothing(data) = False Then

            e.Effect = DragDropEffects.Move

        End If

    End Sub

    Private Sub FoldersTreeView_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles FoldersTreeView.DragDrop

        Dim NodeToDropIn As TreeNode = FoldersTreeView.GetNodeAt(FoldersTreeView.PointToClient(New Point(e.X, e.Y)))

        If IsNothing(NodeToDropIn) = False Then

            Dim ParentDocument As Document = TryCast(NodeToDropIn.Tag, Document)

            ' The docs being moved.
            Dim data As SelectedListViewItemCollection = e.Data.GetData(GetType(SelectedListViewItemCollection))

            If MsgBox("Are you sure you want to add the " & data.Count.ToString & " file(s) to the '" & NodeToDropIn.Text & "' collection?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Me.Cursor = Cursors.WaitCursor

                'If IsNothing(gd.Request) = True Then
                gd.Request = New DocumentsRequest(gd.GetRequestSettings())
                gd.Request.Proxy = gd.ProxyServer
                'End If

                For Each lv As ListViewItem In data

                    Dim doc As Document = CType(lv.Tag, Document)

                    ' Move the document to the other folder.
                    gd.Request.MoveDocumentTo(ParentDocument, doc)

                    ' Only remove it from the listview if we are moving a file that does not belong to any collection.
                    If IsNothing(ParentDocument) = True Then

                        ' Remove the item from the listview.
                        DocumentsListListView.Items.Remove(lv)

                    End If

                Next

                Me.Cursor = Cursors.Default

            End If

        End If

    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FindToolStripMenuItem.Click

        SearchPanel.Visible = True
        SearchForTextBox.Select()

    End Sub

    Private Sub SearchButton_Click(sender As System.Object, e As System.EventArgs) Handles SearchButton.Click

        SearchFiles()

    End Sub

    Private Sub ListViewColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs)

        Dim lv As ListView = CType(sender, ListView)
        Dim lvSorter As ListViewColumnSorter = CType(lv.Tag, ListViewColumnSorter)

        ' Determine if the clicked column is already the column that is being sorted.
        If (e.Column = lvSorter.SortColumn) Then

            ' Reverse the current sort direction for this column.
            If (lvSorter.Order = SortOrder.Ascending) Then
                lvSorter.Order = SortOrder.Descending
            Else
                lvSorter.Order = SortOrder.Ascending
            End If

        Else

            ' Set the column number that is to be sorted; default to ascending.
            lvSorter.SortColumn = e.Column
            lvSorter.Order = SortOrder.Ascending

        End If

        ' Update the tag with the updated sorter.
        lv.Tag = lvSorter

        ' Perform the sort with these new sort options.
        CType(sender, ListView).Sort()

    End Sub

    ''' <summary>
    ''' Perform a search for files.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SearchFiles()

        Me.Cursor = Cursors.WaitCursor

        ' Make the new controls.
        Dim SearchResultsListView As New ListView
        SearchResultsListView.View = Windows.Forms.View.Details
        SearchResultsListView.Dock = DockStyle.Fill
        SearchResultsListView.Columns.Add("Title").Width = 500
        SearchResultsListView.SmallImageList = imageList
        SearchResultsListView.LargeImageList = imageList
        SearchResultsListView.FullRowSelect = True
        SearchResultsListView.ContextMenuStrip = SearchResultsContextMenuStrip

        ' The listview groups.
        Dim DocumentsListViewGroup As New ListViewGroup("Documents", "Documents")
        Dim PresentationsListViewGroup As New ListViewGroup("Presentations", "Presentations")
        Dim SpreadsheetsListViewGroup As New ListViewGroup("Spreadsheets", "Spreadsheets")
        Dim OtherListViewGroup As New ListViewGroup("Other", "Other")

        SearchResultsListView.Groups.Add(DocumentsListViewGroup)
        SearchResultsListView.Groups.Add(PresentationsListViewGroup)
        SearchResultsListView.Groups.Add(SpreadsheetsListViewGroup)
        SearchResultsListView.Groups.Add(OtherListViewGroup)

        ' Set the listview column sorter.
        Dim lvSorter As New ListViewColumnSorter()
        SearchResultsListView.ListViewItemSorter = lvSorter
        SearchResultsListView.Tag = lvSorter
        AddHandler SearchResultsListView.ColumnClick, AddressOf ListViewColumnClick

        Dim tp As New TabPage(SearchForTextBox.Text)
        tp.Controls.Add(SearchResultsListView)
        TabControl1.TabPages.Add(tp)

        ' Do the search.

        Dim query As New DocumentsListQuery

        If SearchFileContentsCheckBox.Checked = False Then
            query.Title = SearchForTextBox.Text
            'query.TitleExact = True
        Else
            query.Query = SearchForTextBox.Text
        End If

        Dim feed As DocumentsFeed = gd.Service.Query(query)

        For Each doc As DocumentEntry In feed.Entries

            Dim lvi As New ListViewItem()
            lvi.Text = doc.Title.Text
            lvi.Tag = doc

            ' Get the right image.            
            lvi.ImageIndex = GetImageIndex(doc)

            SearchResultsListView.Items.Add(lvi)

        Next

        ' Open the newest tab.
        TabControl1.SelectedTab = tp

        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' Add the document to the listview.
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <remarks></remarks>
    Private Sub AddDocumentToListView(doc As Document)

        Dim item As New ListViewItem(doc.DocumentEntry.Title.Text)

        item.ImageIndex = GetImageIndex(doc.DocumentEntry)

        item.SubItems.Add(doc.DocumentEntry.Updated.ToString())
        item.SubItems.Add(gExplore.Conversions.ConvertIntelligently(doc.QuotaBytesUsed))
        item.Tag = doc

        If doc.DocumentEntry.IsDocument = True Then

            item.Group = DocumentsListListView.Groups(0)

        ElseIf doc.DocumentEntry.IsSpreadsheet = True Then

            item.Group = DocumentsListListView.Groups(1)

        ElseIf doc.DocumentEntry.IsPresentation = True Then

            item.Group = DocumentsListListView.Groups(2)

        Else

            item.Group = DocumentsListListView.Groups(3)

        End If

        DocumentsListListView.Items.Add(item)

    End Sub

    ''' <summary>
    ''' Determine what icon to show based on the document type.
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetImageIndex(entry As DocumentEntry) As Integer

        Dim ImageIndex As Integer = 0

        If entry.IsDocument = True Then 'Or entry.Title.Text.ToLower.EndsWith(".txt") = True Or entry.Title.Text.ToLower.EndsWith(".docx") = True Then

            ImageIndex = 2

        ElseIf entry.IsSpreadsheet = True Then 'Or entry.Title.Text.ToLower.EndsWith(".xlsx") = True Then

            ImageIndex = 3

        ElseIf entry.IsPresentation = True Then

            ImageIndex = 4

        ElseIf entry.IsPDF = True Then

            ImageIndex = 5

        ElseIf entry.Title.Text.EndsWith(".mp3") Or entry.Title.Text.EndsWith(".wav") Then

            ImageIndex = 10

        ElseIf entry.Title.Text.ToLower.EndsWith(".png") = True Or entry.Title.Text.ToLower.EndsWith(".jpg") Or entry.Title.Text.ToLower.EndsWith(".gif") Or entry.Title.Text.ToLower.EndsWith(".jpeg") Then

            ImageIndex = 11

        Else

            ImageIndex = 9

        End If

        ' If it is starred it overrides all other conditions.
        If entry.IsStarred = True Then
            ImageIndex = 6
        End If

        Return ImageIndex

    End Function

    Private Sub CloseSearchPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CloseSearchPictureBox.Click

        SearchPanel.Visible = False

    End Sub

    Private Sub FoldersContextMenuStrip_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles FoldersContextMenuStrip.Opening

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            If IsNothing(FoldersTreeView.SelectedNode.Tag) = False Then

                RenameCollectionToolStripMenuItem.Enabled = True
                DeleteCollectionToolStripMenuItem.Enabled = True
                ExportCollectionToolStripMenuItem.Enabled = True
                ShareCollectionToolStripMenuItem.Enabled = True
                ViewCollectionSharingToolStripMenuItem.Enabled = True
                ViewParentCollectionsToolStripMenuItem.Enabled = True

            Else

                RenameCollectionToolStripMenuItem.Enabled = False
                DeleteCollectionToolStripMenuItem.Enabled = False
                ExportCollectionToolStripMenuItem.Enabled = False
                ShareCollectionToolStripMenuItem.Enabled = False
                ViewCollectionSharingToolStripMenuItem.Enabled = False
                ViewParentCollectionsToolStripMenuItem.Enabled = False

            End If

        Else

            ' This is to handle when the top-level item is selected.
            DeleteCollectionToolStripMenuItem.Enabled = False
            ExportCollectionToolStripMenuItem.Enabled = False

        End If

    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim SelectedListViewItem As ListViewItem = DocumentsListListView.SelectedItems(0)

            Dim doc As Document = TryCast(SelectedListViewItem.Tag, Document)

            Dim rn As New Rename(gd, doc, True)

            If rn.ShowDialog() = DialogResult.OK Then

                Me.Cursor = Cursors.WaitCursor

                UpdateDocumentInListView(doc, SelectedListViewItem)

                Me.Cursor = Cursors.Default

            End If

            ' Clean up.
            rn.Dispose()

        End If

    End Sub

    ''' <summary>
    ''' Update a document by ResourceID in the listview.
    ''' </summary>
    ''' <param name="DocumentToUpdate"></param>
    ''' <param name="lvi"></param>
    ''' <remarks></remarks>
    Private Sub UpdateDocumentInListView(DocumentToUpdate As Document, lvi As ListViewItem)

        Me.Cursor = Cursors.WaitCursor

        ' Find the object on Google Docs.
        Dim doc As Document = gd.FindObject(DocumentToUpdate.ResourceId)

        ' If it was found, update it in the listview.
        If IsNothing(doc) = False Then

            lvi.Text = doc.Title
            lvi.SubItems(1).Text = doc.Updated.ToString
            lvi.Tag = doc

            ' Set the icon.
            lvi.ImageIndex = GetImageIndex(doc.DocumentEntry)

        End If

        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' Update a document (folder) by ResourceID in the treeview.
    ''' </summary>
    ''' <param name="DocumentToUpdate"></param>
    ''' <param name="tn"></param>
    ''' <remarks></remarks>
    Private Sub UpdateDocumentInTreeView(DocumentToUpdate As Document, tn As TreeNode)

        Me.Cursor = Cursors.WaitCursor

        ' Find the object on Google Docs.
        Dim doc As Document = gd.FindObject(DocumentToUpdate.ResourceId)

        ' If it was found, update it in the listview.
        If IsNothing(doc) = False Then

            tn.Text = doc.Title
            tn.Tag = doc

            ' Set the icon.
            tn.ImageIndex = GetImageIndex(doc.DocumentEntry)

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SettingsToolStripMenuItem.Click

        Dim s As New Settings(gd)
        s.ShowDialog()
        s.Dispose()

    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestoreToolStripMenuItem.Click

        RestoreFromTray()

    End Sub

    ''' <summary>
    ''' Restore gExplore when accessed from the system tray.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RestoreFromTray()

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem1.Click

        Application.Exit()

    End Sub

    Private Sub Main_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then

            If gExplore.SettingsHandler.MinimizeToTray = True Then

                Me.Visible = False
                Me.ShowInTaskbar = False
                Me.WindowState = FormWindowState.Minimized

                SystemTrayNotifyIcon.Visible = True
                SystemTrayNotifyIcon.BalloonTipTitle = "gExplore"
                SystemTrayNotifyIcon.BalloonTipIcon = ToolTipIcon.Info
                SystemTrayNotifyIcon.BalloonTipText = "gExplore is still running."
                SystemTrayNotifyIcon.ShowBalloonTip(5000)

            End If

        End If

    End Sub

    Private Sub SystemTrayNotifyIcon_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles SystemTrayNotifyIcon.MouseDoubleClick

        RestoreFromTray()

    End Sub

    Private Sub DeleteCollectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteCollectionToolStripMenuItem.Click

        If IsNothing(FoldersTreeView.SelectedNode.Tag) = False Then

            Dim doc As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            If MsgBox("Are you sure you want to delete the '" & doc.Title & "' collection? The collection and all files in it will be moved to the trash if they do not belong to any other collections.", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Me.Cursor = Cursors.WaitCursor

                ' Have to enumerate the collections under this one and delete them all.
                DeleteCollectionRecursively(doc)

                ' Now delete this top-level collection.
                gd.Request.Delete(New Uri("https://docs.google.com/feeds/default/private/full/" & doc.ResourceId), doc.ETag)

                FoldersTreeView.SelectedNode.Remove()

                Me.Cursor = Cursors.Default

            End If

        End If

    End Sub

    ''' <summary>
    ''' Recursively delete the contents of a collection.
    ''' </summary>
    ''' <param name="Parent"></param>
    ''' <remarks></remarks>
    Private Sub DeleteCollectionRecursively(Parent As Document)

        'If IsNothing(gd.Request) = True Then
        gd.Request = New DocumentsRequest(gd.GetRequestSettings())
        gd.Request.Proxy = gd.ProxyServer
        'End If

        Dim contents As Feed(Of Document) = gd.Request.GetFolderContent(Parent)

        For Each d As Document In contents.Entries

            If d.DocumentEntry.IsFolder = True Then

                DeleteCollectionRecursively(d)

                Application.DoEvents()

            End If

            gd.Request.Delete(New Uri("https://docs.google.com/feeds/default/private/full/" & d.ResourceId), d.ETag)

        Next

    End Sub

    Private Sub RemoveFromCollectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveFromCollectionToolStripMenuItem.Click

        RemoveFromCollection()

    End Sub

    Private Sub ExportCollectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportCollectionToolStripMenuItem.Click

        Dim doc As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

        Dim ExportDialog As New ExportCollection(gd, doc)
        ExportDialog.ShowDialog()
        ExportDialog.Dispose()

    End Sub

    Private Sub NewCollectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewCollectionToolStripMenuItem.Click

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            Dim ParentCollection As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            Dim nc As New NewCollection(gd, ParentCollection)

            If nc.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Dim doc As Document = gd.FindObject(nc.GetNewCollectionResourceID)

                ' Make a new child node and set it's tag.
                Dim NewCollectionNode As New TreeNode(nc.GetNewCollectionName)
                NewCollectionNode.Tag = doc
                NewCollectionNode.SelectedImageIndex = 7
                NewCollectionNode.ImageIndex = 7

                ' Add the node.
                FoldersTreeView.SelectedNode.Nodes.Add(NewCollectionNode)

                ' Expand the parent to show the new child.
                FoldersTreeView.SelectedNode.Expand()

            End If

        Else

            Dim nc As New NewCollection(gd, Nothing)
            nc.ShowDialog()

        End If

    End Sub

    Private Sub RefreshCollectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshCollectionsToolStripMenuItem.Click

        RefreshFolders()

    End Sub

    Private Sub StarredToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StarredToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            For Each lvi As ListViewItem In DocumentsListListView.SelectedItems

                ' Get the document from the listview.
                Dim doc As Document = TryCast(lvi.Tag, Document)

                Try

                    ' Star/unstar it and update it in Google Docs.
                    doc.DocumentEntry.IsStarred = Not doc.DocumentEntry.IsStarred
                    gd.Service.Update(doc.AtomEntry)

                    ' Update the document in the listview to reflect the change.
                    UpdateDocumentInListView(doc, lvi)

                Catch ex As Exception

                    gExplore.Logging.WriteErrorToApplicationLog(ex)
                    MsgBox("An error occurred while starring/unstarring " & doc.Title & ".", MsgBoxStyle.Critical)

                End Try

            Next

        End If

    End Sub

    Private Sub RefreshDocumentsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshDocumentsToolStripMenuItem.Click

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            Dim ParentDocument As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)
            UpdateDocList(ParentDocument)

        Else

            UpdateDocList()

        End If

    End Sub

    Private Sub ViewFileCollectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewFileCollectionsToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim doc As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            ShowParentCollections(doc, True)

        End If

    End Sub

    ''' <summary>
    ''' Show the window of collections for this document.
    ''' </summary>
    ''' <param name="doc"></param>
    ''' <remarks></remarks>
    Private Sub ShowParentCollections(doc As Document, IsDocument As Boolean)

        Dim Collections As New List(Of String)

        ' Get the parent collections for this document.
        For Each s As AtomLink In doc.DocumentEntry.ParentFolders
            Collections.Add(s.AbsoluteUri)
        Next

        Dim CurrentFolder As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

        Dim bc As New ItemCollections(gd, Collections, doc, CurrentFolder)

        If bc.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If bc.GetRequireRefresh = True Then

                If IsDocument = True Then

                    UpdateDocList(CurrentFolder)

                Else

                    RefreshFolders()

                End If

            End If

        End If

        bc.Dispose()

    End Sub

    Private Sub RenameCollectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameCollectionToolStripMenuItem.Click

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            Dim doc As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            Dim rc As New Rename(gd, doc, False)

            If rc.ShowDialog = Windows.Forms.DialogResult.OK Then

                ' FoldersTreeView.SelectedNode.Text = rc.NewName

                ' Get the new collection as a Document object and set it to the node's Tag.
                UpdateTreeViewNode(doc, FoldersTreeView.SelectedNode)

                ' Update the location.
                UpdateLocationText(FoldersTreeView.SelectedNode)

            End If

            rc.Dispose()

        End If

    End Sub

    ''' <summary>
    ''' Update the text and tag of a node in the treeview.
    ''' </summary>
    ''' <param name="DocumentToUpload"></param>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Private Sub UpdateTreeViewNode(DocumentToUpload As Document, node As TreeNode)

        Me.Cursor = Cursors.WaitCursor

        Dim doc As Document = gd.FindObject(DocumentToUpload.ResourceId)

        If IsNothing(doc) = False Then

            node.Text = doc.Title
            node.Tag = doc

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FoldersTreeView_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles FoldersTreeView.DragOver

        Dim data As SelectedListViewItemCollection = e.Data.GetData(GetType(SelectedListViewItemCollection))

        If IsNothing(data) = False Then

            Dim NodeToDropIn As TreeNode = FoldersTreeView.GetNodeAt(FoldersTreeView.PointToClient(New Point(e.X, e.Y)))

            ToolStripStatusLabel1.Text = "Add the " & data.Count.ToString & " file(s) to the '" & NodeToDropIn.Text & "' collection."

        End If

    End Sub

    Private Sub DocumentTitleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DocumentTitleToolStripMenuItem.Click

        Try

            If DocumentsListListView.SelectedItems.Count > 1 Then

                Dim ClipboardText As String = String.Empty

                For Each lvi As ListViewItem In DocumentsListListView.SelectedItems

                    ClipboardText += lvi.Text & vbNewLine

                Next

                Clipboard.SetDataObject(ClipboardText, True, 5, 200)

            ElseIf DocumentsListListView.SelectedItems.Count = 1 Then

                Clipboard.SetDataObject(DocumentsListListView.SelectedItems(0).Text, True, 5, 200)

            End If

        Catch ex As Exception

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            MsgBox("Unable to access the clipbard. Please try again.", MsgBoxStyle.Critical)

        End Try

    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteFileToolStripMenuItem.Click

        DeleteFiles()

    End Sub

    Private Sub DeleteFiles()

        If DocumentsListListView.SelectedItems.Count > 0 Then

            If MsgBox("Are you sure you want to move the " & DocumentsListListView.SelectedItems.Count.ToString & " selected file(s) to the trash?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For Each lvi As ListViewItem In DocumentsListListView.SelectedItems

                    Dim doc As Document = TryCast(lvi.Tag, Document)

                    If MoveFileToTrash(doc.DocumentEntry) = True Then

                        ' Remove it from the listview.
                        lvi.Remove()

                    Else

                        If MsgBox("An error occurred while trying to delete " & doc.Title & ". Continue deleting any remaining files?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit For
                        End If

                    End If

                Next

            End If

        End If

    End Sub

    Private Sub SearchForTextBox_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles SearchForTextBox.KeyDown

        If e.KeyCode = Keys.Enter Then

            SearchFiles()

            e.Handled = False
            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub TabControl1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TabControl1.MouseUp

        ' check if the right mouse button was pressed 
        If e.Button = MouseButtons.Right Then

            ' iterate through all the tab pages 
            For i As Integer = 0 To TabControl1.TabCount - 1

                ' get their rectangle area and check if it contains the mouse cursor 
                Dim r As Rectangle = TabControl1.GetTabRect(i)

                If r.Contains(e.Location) Then

                    ' Don't show the menu for the first tab.
                    If i > 0 Then

                        p_SelectedTab = TabControl1.TabPages(i)

                        ' Show a context menu to close the search tab.
                        SearchTabContextMenuStrip.Show(TabControl1.TabPages(i), e.Location, ToolStripDropDownDirection.Default)

                    End If

                End If

            Next

        End If

    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseTabToolStripMenuItem.Click

        p_SelectedTab.Dispose()

    End Sub

    Private Sub CloseAllTabsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseAllTabsToolStripMenuItem.Click

        For x As Integer = 1 To TabControl1.TabPages.Count - 1

            ' It removes them left to right. So the next tab is always index = 1.
            TabControl1.TabPages(1).Dispose()

        Next

    End Sub

    Private Sub SearchResultOpenInBrowserToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchResultOpenInBrowserToolStripMenuItem.Click

        Dim lv As ListView = DirectCast(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            Try

                Dim lvi As ListViewItem = lv.SelectedItems(0)

                Dim entry As DocumentEntry = CType(lvi.Tag, DocumentEntry)
                OpenSelectedDocument(entry)

            Catch ex As Exception

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("Unable to open this document.", MsgBoxStyle.Critical)

            End Try

        End If

    End Sub

    Private Sub ShareToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShareToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim doc As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            If ShareObject(doc, True) = True Then

                UpdateDocumentInListView(doc, DocumentsListListView.SelectedItems(0))

            End If

        End If

    End Sub

    Private Function ShareObject(doc As Document, SharingFile As Boolean) As Boolean

        Dim result As Boolean = False

        Dim sf As New Share(gd, doc)

        ' Show it.
        If sf.ShowDialog() = Windows.Forms.DialogResult.OK Then
            result = True
        End If

        ' Clean up.
        sf.Dispose()

        Return result

    End Function

    Private Sub ShareCollectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShareCollectionToolStripMenuItem.Click

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            Dim doc As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            If ShareObject(doc, False) = True Then

                UpdateDocumentInTreeView(doc, FoldersTreeView.SelectedNode)

            End If

        End If

    End Sub

    Private Sub ViewSharingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewSharingToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim doc As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            Dim vs As New ViewShares(gd, doc)
            vs.ShowDialog()

            ' Clean up.
            vs.Dispose()

        End If

    End Sub

    Private Sub ViewCollectionSharingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewCollectionSharingToolStripMenuItem.Click

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            Dim doc As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            Dim vs As New ViewShares(gd, doc, False)
            vs.ShowDialog()

            ' Clean up.
            vs.Dispose()

        End If

    End Sub

    Private Sub PermissionsAuditToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PermissionsAuditToolStripMenuItem.Click

        ShowPermissionsAudit()

    End Sub

    ''' <summary>
    ''' Show the Permissions Audit window.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowFileSizeAudit()

        Dim pa As New FileSizeAudit(gd)
        pa.ShowDialog()

        ' Clean up.
        pa.Dispose()

    End Sub

    ''' <summary>
    ''' Show the Permissions Audit window.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowPermissionsAudit()

        Dim pa As New PermissionsAudit(gd)
        pa.ShowDialog()

        ' Clean up.
        pa.Dispose()

    End Sub

    Private Sub DecryptFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DecryptFileToolStripMenuItem.Click

        Dim d As New DecryptFile()
        d.ShowDialog()

        ' Clean up.
        d.Dispose()

    End Sub

    Private Sub ViewLogToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewLogToolStripMenuItem.Click

        LogPanel.Visible = Not ViewLogToolStripMenuItem.Checked
        ViewLogToolStripMenuItem.Checked = Not ViewLogToolStripMenuItem.Checked

    End Sub

    ''' <summary>
    ''' Show the log.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowOrHideLog(Visible As Boolean)

        LogPanel.Visible = Visible
        ViewLogToolStripMenuItem.Checked = Visible

    End Sub

    Private Sub ViewByFileTypeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewByFileTypeToolStripMenuItem.Click

        DocumentsListListView.ShowGroups = Not ViewByFileTypeToolStripMenuItem.Checked
        ViewByFileTypeToolStripMenuItem.Checked = Not ViewByFileTypeToolStripMenuItem.Checked

    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AllToolStripMenuItem.Click

        For Each lvi As ListViewItem In DocumentsListListView.Items

            lvi.Selected = True

        Next

    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NoneToolStripMenuItem.Click

        For Each lvi As ListViewItem In DocumentsListListView.Items

            lvi.Selected = False

        Next

    End Sub

    Private Sub CloseLogPanelPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CloseLogPanelPictureBox.Click

        ShowOrHideLog(False)

    End Sub

    Private Sub FoldersTreeView_DragLeave(sender As Object, e As System.EventArgs) Handles FoldersTreeView.DragLeave

        ToolStripStatusLabel1.Text = Application.ProductName

    End Sub

    Private Sub SearchResultsContextMenuStrip_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles SearchResultsContextMenuStrip.Opening

        Dim lv As ListView = DirectCast(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            SearchResultOpenInBrowserToolStripMenuItem.Enabled = True
            DownloadToolStripMenuItem.Enabled = True
            SearchShareToolStripMenuItem.Enabled = True
            SearchViewSharingToolStripMenuItem.Enabled = True
            ViewCollectionsToolStripMenuItem.Enabled = True
            SearchDeleteFileToolStripMenuItem.Enabled = True

        Else

            SearchResultOpenInBrowserToolStripMenuItem.Enabled = False
            DownloadToolStripMenuItem.Enabled = False
            SearchShareToolStripMenuItem.Enabled = False
            SearchViewSharingToolStripMenuItem.Enabled = False
            ViewCollectionsToolStripMenuItem.Enabled = False
            SearchDeleteFileToolStripMenuItem.Enabled = False

        End If

    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadToolStripMenuItem.Click

        Dim lv As ListView = DirectCast(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            Dim lvi As ListViewItem = lv.SelectedItems(0)

            Dim entry As DocumentEntry = CType(lvi.Tag, DocumentEntry)

            Dim d As Document = gd.FindObject(entry.ResourceId)
            ExportFile(d)

        End If

    End Sub

    Private Sub SearchShareToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchShareToolStripMenuItem.Click

        Dim lv As ListView = DirectCast(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            Dim lvi As ListViewItem = lv.SelectedItems(0)

            Dim entry As DocumentEntry = CType(lvi.Tag, DocumentEntry)

            Dim d As Document = gd.FindObject(entry.ResourceId)

            If ShareObject(d, True) = True Then

                UpdateDocumentInListView(d, lvi)

            End If

        End If

    End Sub

    Private Sub SearchViewSharingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchViewSharingToolStripMenuItem.Click

        Dim lv As ListView = DirectCast(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            Dim lvi As ListViewItem = lv.SelectedItems(0)

            Dim entry As DocumentEntry = CType(lvi.Tag, DocumentEntry)

            Dim d As Document = gd.FindObject(entry.ResourceId)

            Dim vs As New ViewShares(gd, d)
            vs.ShowDialog()

            ' Clean up.
            vs.Dispose()

        End If

    End Sub

    Private Sub ViewCollectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewCollectionsToolStripMenuItem.Click

        Dim lv As ListView = DirectCast(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            Dim lvi As ListViewItem = lv.SelectedItems(0)

            Dim entry As DocumentEntry = CType(lvi.Tag, DocumentEntry)

            Dim doc As Document = gd.FindObject(entry.ResourceId)

            ShowParentCollections(doc, True)

        End If

    End Sub

    ''' <summary>
    ''' Move a file to the Trash collection.
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <remarks></remarks>
    Private Function MoveFileToTrash(entry As DocumentEntry) As Boolean

        Try

            Dim doc As Document = gd.FindObject(entry.ResourceId)

            'If IsNothing(gd.Request) = True Then
            gd.Request = New DocumentsRequest(gd.GetRequestSettings())
            gd.Request.Proxy = gd.ProxyServer
            'End If

            gd.Request.Service.Delete(New Uri(String.Format("http://docs.google.com/feeds/default/private/full/{0}?delete=false", doc.ResourceId)), doc.ETag)

            Return True

        Catch ex As Exception

            gExplore.Logging.WriteErrorToApplicationLog(ex)

            Return False

        End Try

    End Function

    Private Sub SearchDeleteFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem.Click

        Dim lv As ListView = DirectCast(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            If MsgBox("Are you sure you want to move the " & lv.SelectedItems.Count.ToString & " selected file(s) to the trash?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For Each lvi As ListViewItem In lv.SelectedItems

                    Dim entry As DocumentEntry = CType(lvi.Tag, DocumentEntry)

                    If MoveFileToTrash(entry) = True Then

                        ' Remove it from the listview.
                        lvi.Remove()

                    Else

                        If MsgBox("An error occurred while trying to delete " & entry.Title.Text & ". Continue deleting any remaining files?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit For
                        End If

                    End If

                Next

            End If

        End If

    End Sub

    Private Sub SendToMyKindleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SendToMyKindleToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim FilesToSend As New List(Of Document)

            For Each lvi As ListViewItem In DocumentsListListView.SelectedItems

                ' Get which document.
                Dim doc As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

                FilesToSend.Add(doc)

            Next

            ' Send the files to the user's @kindle.com email address.
            SendDocumentToKindleEMail(FilesToSend)

        End If

    End Sub

    ''' <summary>
    ''' Download and email a document to the user's Kindle email address.
    ''' </summary>
    ''' <param name="docs"></param>
    ''' <remarks></remarks>
    Private Sub SendDocumentToKindleEMail(docs As List(Of Document))

        If gExplore.SettingsHandler.KindleEmail <> String.Empty Then

            Dim FilesToAttch As New List(Of String)

            ' Download each document to a temp file.
            For Each d As Document In docs

                Dim LocalFile As String = DownloadFile(d)

                ' Will be empty string if the download failed.
                If LocalFile <> String.Empty Then

                    FilesToAttch.Add(LocalFile)

                Else

                    ' The file could not be downloaded.
                    If MsgBox("Unable to attach " & d.Title & " to the email. Continue with remaining files?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If

                End If

            Next

            Try

                gExplore.SendEmail.SendToKindle(gd, FilesToAttch)

                MsgBox("The email has been sent to " & gExplore.SettingsHandler.KindleEmail & "@kindle.com.", MsgBoxStyle.Information)

            Catch ex As Exception

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("An error occurred while sending the mail.", MsgBoxStyle.Critical)

            End Try

        Else

            If MsgBox("You have not provided your Kindle email address or you have provided an invalid email address. Do you want to do enter your Kindle email address now?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim s As New Settings(gd)

                s.TabControl1.SelectedIndex = 1

                If s.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    ' Try sending the email again.
                    SendDocumentToKindleEMail(docs)

                End If

                s.Dispose()

            End If

        End If

    End Sub

    Private Sub UploadNewVersionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadNewVersionToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim doc As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            OpenFileDialog1.FileName = doc.DocumentEntry.Title.Text
            OpenFileDialog1.CheckFileExists = True
            OpenFileDialog1.CheckPathExists = True
            OpenFileDialog1.ShowReadOnly = False
            OpenFileDialog1.Title = "Select File"
            OpenFileDialog1.Filter = "All Files (*.*)|*.*"

            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                UpdateDocContents(doc.DocumentEntry, OpenFileDialog1.FileName)

                MsgBox("The file's contents have been updated.", MsgBoxStyle.Information)

            End If

        End If

    End Sub

    ''' <summary>
    ''' Update the contents of a document without uploading a new file.
    ''' </summary>
    ''' <param name="entryToUpdate"></param>
    ''' <param name="replacementFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateDocContents(entryToUpdate As DocumentEntry, replacementFileName As String) As DocumentEntry

        Dim fileInfo As New FileInfo(replacementFileName)
        Dim stream As FileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

        Dim entry As DocumentEntry = Nothing

        Try

            ' Convert the extension to caps and strip the "." off the front
            Dim ext As String = fileInfo.Extension.ToUpper().Substring(1)

            Dim contentType As String = DirectCast(DocumentsService.DocumentTypes(ext), String)
            ' "application/octet-stream" '
            If contentType Is Nothing Then
                Throw New ArgumentException("File extension '" & ext & "' is not recognized as valid.")
            End If

            ' Set ETag because we're making an update
            Dim factory As GDataRequestFactory = DirectCast(gd.Service.RequestFactory, GDataRequestFactory)
            factory.CustomHeaders.Clear()
            factory.CustomHeaders.Add("If-Match: " & entryToUpdate.Etag)
            factory.CustomHeaders.Add("X-Content-Length:" & stream.Length)
            'factory.CustomHeaders.Add("Content-Length:" & stream.Length)

            Dim mediaUri As New Uri(entryToUpdate.MediaUri.ToString())
            entry = TryCast(gd.Service.Update(mediaUri, stream, contentType, entryToUpdate.Title.Text), DocumentEntry)

            'Dim cla As New ClientLoginAuthenticator(Application.ProductName, ServiceNames.Documents, gd.UserName, gd.Password)
            ' Dim ru As New ResumableUploader(1)
            'ru.Update(cla, mediaUri, stream, contentType)

            ' Important to clear our headers so they aren't there for the next request.
            factory.CustomHeaders.Clear()

        Finally

            stream.Close()

        End Try

        Return entry

    End Function


    Private Sub ViewParentCollectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewParentCollectionsToolStripMenuItem.Click

        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            Dim doc As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            ShowParentCollections(doc, False)

        End If

    End Sub

    Private Sub EmailFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmailFileToolStripMenuItem.Click

        If DocumentsListListView.SelectedItems.Count > 0 Then

            Dim l As New List(Of Document)

            For Each lvi As ListViewItem In DocumentsListListView.SelectedItems

                Dim doc As Document = TryCast(lvi.Tag, Document)

                If IsNothing(doc) = False Then
                    l.Add(doc)
                End If

            Next

            Dim ef As New EmailFile(gd, l, Me)
            ef.ShowDialog()
            ef.Dispose()

        End If

    End Sub

    Private Sub DownloadDirectoryListingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadDirectoryListingToolStripMenuItem.Click

        Dim CollectionName As String = "RootDirectoryListing.csv"
        If IsNothing(FoldersTreeView.SelectedNode) = False Then

            Dim doc As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

            If IsNothing(doc) = False Then

                CollectionName = doc.Title

                SaveFileDialog1.Title = "Download Directory Listing As"
                SaveFileDialog1.OverwritePrompt = True
                SaveFileDialog1.FileName = CollectionName & " Listing.csv"
                SaveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.txt)|*.txt"
                SaveFileDialog1.FilterIndex = 1
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                    ' Download a directory listing to the selected text file.
                    Dim feed As Feed(Of Document) = gd.Request.GetFolderContent(doc)

                    ' Open a writer.
                    Dim sw As New StreamWriter(SaveFileDialog1.FileName)

                    'sw.WriteLine("Name")

                    For Each d As Document In feed.Entries

                        sw.WriteLine(d.Title)

                    Next

                    ' Close up.
                    sw.Dispose()
                    sw.Close()

                    ' Done!
                    MsgBox("The directory listing has been saved to " & SaveFileDialog1.FileName & ".", MsgBoxStyle.Information)

                End If

            End If

        End If

    End Sub

    Private Sub FileSizeAuditToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileSizeAuditToolStripMenuItem.Click

        ShowFileSizeAudit()

    End Sub

    Private Sub EditLocallyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditLocallyToolStripMenuItem.Click

        Dim lv As ListView = CType(TabControl1.SelectedTab.Controls(0), ListView)

        If lv.SelectedItems.Count > 0 Then

            Dim lvi As ListViewItem = lv.SelectedItems(0)

            Dim d As Document = TryCast(DocumentsListListView.SelectedItems(0).Tag, Document)

            ' Download the file to a temp directory.
            Dim TempFileName As String = gd.DownloadFile(d)

            ' Hash the downloaded file.
            Dim OriginalMD5 As String = gExplore.StringEncryption.GetFileMD5Hash(TempFileName)

            ' Run the document editor to open it.
            Dim psi As New ProcessStartInfo()
            psi.FileName = TempFileName ' LocalEditor
            psi.Arguments = TempFileName

            Dim p As New Process
            p.StartInfo = psi

            ' Run it.
            p.Start()

            ' Wait until the user exits.
            p.WaitForExit()

            ' Ok, done. Get the new hash.
            Dim NewMD5 As String = gExplore.StringEncryption.GetFileMD5Hash(TempFileName)

            ' Are the hashes different? Need to re-upload?
            If OriginalMD5 = NewMD5 Then

                ' No changes.

            Else

                ' It was changed.
                If MsgBox("The file has changed. Upload the new version? The old version will be moved to the Trash.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "gExplore") = MsgBoxResult.Yes Then

                    ' Get the parent collection.
                    Dim ParentCollection As Document = TryCast(FoldersTreeView.SelectedNode.Tag, Document)

                    ' Upload the file.
                    gd.UploadFile(TempFileName, ParentCollection, TempFileName, AddressOf OnDone, AddressOf OnProgress, True)

                    ' Move the old one to the trash.
                    MoveFileToTrash(d.DocumentEntry)

                    ' Refresh the listview.
                    UpdateDocList(ParentCollection)

                End If

            End If

        End If

    End Sub

End Class
