<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Documents", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Spreadsheets", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Presentations", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Other", System.Windows.Forms.HorizontalAlignment.Left)
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ExportDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SystemTrayNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FoldersTreeView = New System.Windows.Forms.TreeView()
        Me.FoldersContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewParentCollectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShareCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewCollectionSharingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshCollectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentsListListView = New System.Windows.Forms.ListView()
        Me.TitleColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LastModifiedColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SpaceUsedColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DocumentListContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFolderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenInBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditLocallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StarredToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadNewVersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSharingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.EmailFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendToMyKindleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewFileCollectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DownloadDirectoryListingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancedPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentTitleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshDocumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.MainToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PermissionsAuditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSizeAuditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.DecryptFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewByFileTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.RefreshToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.UploadToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.UploadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CurrentDirectoryLabel = New System.Windows.Forms.Label()
        Me.SearchPanel = New System.Windows.Forms.Panel()
        Me.CloseSearchPictureBox = New System.Windows.Forms.PictureBox()
        Me.SearchFileContentsCheckBox = New System.Windows.Forms.CheckBox()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SearchForTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CloseLogPanelPictureBox = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SearchTabContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CloseTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllTabsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchResultsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SearchResultOpenInBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.SearchShareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchViewSharingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewCollectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloudFileNotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.SearchDeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogPanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LogTextBox = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TrayContextMenuStrip.SuspendLayout()
        Me.FoldersContextMenuStrip.SuspendLayout()
        Me.DocumentListContextMenuStrip.SuspendLayout()
        Me.MainMenuStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SearchPanel.SuspendLayout()
        CType(Me.CloseSearchPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseLogPanelPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SearchTabContextMenuStrip.SuspendLayout()
        Me.SearchResultsContextMenuStrip.SuspendLayout()
        Me.LogPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList
        '
        Me.imageList.ImageStream = CType(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList.Images.SetKeyName(0, "CLSDFOLD.BMP")
        Me.imageList.Images.SetKeyName(1, "OPENFOLD.BMP")
        Me.imageList.Images.SetKeyName(2, "gdoc.png")
        Me.imageList.Images.SetKeyName(3, "Spreadsheet.gif")
        Me.imageList.Images.SetKeyName(4, "Presentation.gif")
        Me.imageList.Images.SetKeyName(5, "pdf.png")
        Me.imageList.Images.SetKeyName(6, "starred.png")
        Me.imageList.Images.SetKeyName(7, "folder.png")
        Me.imageList.Images.SetKeyName(8, "open.ico")
        Me.imageList.Images.SetKeyName(9, "other.png")
        Me.imageList.Images.SetKeyName(10, "audio.png")
        Me.imageList.Images.SetKeyName(11, "picture.png")
        '
        'SystemTrayNotifyIcon
        '
        Me.SystemTrayNotifyIcon.ContextMenuStrip = Me.TrayContextMenuStrip
        Me.SystemTrayNotifyIcon.Icon = CType(resources.GetObject("SystemTrayNotifyIcon.Icon"), System.Drawing.Icon)
        Me.SystemTrayNotifyIcon.Text = "gExplore"
        '
        'TrayContextMenuStrip
        '
        Me.TrayContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestoreToolStripMenuItem, Me.ToolStripSeparator8, Me.ExitToolStripMenuItem1})
        Me.TrayContextMenuStrip.Name = "TrayContextMenuStrip"
        Me.TrayContextMenuStrip.Size = New System.Drawing.Size(114, 54)
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(110, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(113, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'FoldersTreeView
        '
        Me.FoldersTreeView.AllowDrop = True
        Me.FoldersTreeView.ContextMenuStrip = Me.FoldersContextMenuStrip
        Me.FoldersTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FoldersTreeView.ImageIndex = 0
        Me.FoldersTreeView.ImageList = Me.imageList
        Me.FoldersTreeView.Location = New System.Drawing.Point(0, 0)
        Me.FoldersTreeView.Margin = New System.Windows.Forms.Padding(2)
        Me.FoldersTreeView.Name = "FoldersTreeView"
        Me.FoldersTreeView.SelectedImageIndex = 0
        Me.FoldersTreeView.Size = New System.Drawing.Size(212, 249)
        Me.FoldersTreeView.TabIndex = 25
        '
        'FoldersContextMenuStrip
        '
        Me.FoldersContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewCollectionToolStripMenuItem, Me.ExportCollectionToolStripMenuItem, Me.RenameCollectionToolStripMenuItem, Me.ViewParentCollectionsToolStripMenuItem, Me.ToolStripSeparator4, Me.ShareCollectionToolStripMenuItem, Me.ViewCollectionSharingToolStripMenuItem, Me.ToolStripSeparator10, Me.DeleteCollectionToolStripMenuItem, Me.ToolStripSeparator11, Me.RefreshCollectionsToolStripMenuItem})
        Me.FoldersContextMenuStrip.Name = "FoldersContextMenuStrip"
        Me.FoldersContextMenuStrip.Size = New System.Drawing.Size(208, 198)
        '
        'NewCollectionToolStripMenuItem
        '
        Me.NewCollectionToolStripMenuItem.Image = CType(resources.GetObject("NewCollectionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewCollectionToolStripMenuItem.Name = "NewCollectionToolStripMenuItem"
        Me.NewCollectionToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.NewCollectionToolStripMenuItem.Text = "New Collection..."
        '
        'ExportCollectionToolStripMenuItem
        '
        Me.ExportCollectionToolStripMenuItem.Name = "ExportCollectionToolStripMenuItem"
        Me.ExportCollectionToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ExportCollectionToolStripMenuItem.Text = "Export Collection..."
        '
        'RenameCollectionToolStripMenuItem
        '
        Me.RenameCollectionToolStripMenuItem.Name = "RenameCollectionToolStripMenuItem"
        Me.RenameCollectionToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RenameCollectionToolStripMenuItem.Text = "Rename Collection..."
        '
        'ViewParentCollectionsToolStripMenuItem
        '
        Me.ViewParentCollectionsToolStripMenuItem.Name = "ViewParentCollectionsToolStripMenuItem"
        Me.ViewParentCollectionsToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ViewParentCollectionsToolStripMenuItem.Text = "View Parent Collections..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(204, 6)
        '
        'ShareCollectionToolStripMenuItem
        '
        Me.ShareCollectionToolStripMenuItem.Name = "ShareCollectionToolStripMenuItem"
        Me.ShareCollectionToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ShareCollectionToolStripMenuItem.Text = "Share Collection..."
        '
        'ViewCollectionSharingToolStripMenuItem
        '
        Me.ViewCollectionSharingToolStripMenuItem.Name = "ViewCollectionSharingToolStripMenuItem"
        Me.ViewCollectionSharingToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ViewCollectionSharingToolStripMenuItem.Text = "View Sharing..."
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(204, 6)
        '
        'DeleteCollectionToolStripMenuItem
        '
        Me.DeleteCollectionToolStripMenuItem.Image = CType(resources.GetObject("DeleteCollectionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteCollectionToolStripMenuItem.Name = "DeleteCollectionToolStripMenuItem"
        Me.DeleteCollectionToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.DeleteCollectionToolStripMenuItem.Text = "Delete Collection..."
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(204, 6)
        '
        'RefreshCollectionsToolStripMenuItem
        '
        Me.RefreshCollectionsToolStripMenuItem.Name = "RefreshCollectionsToolStripMenuItem"
        Me.RefreshCollectionsToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RefreshCollectionsToolStripMenuItem.Text = "Refresh"
        '
        'DocumentsListListView
        '
        Me.DocumentsListListView.AllowDrop = True
        Me.DocumentsListListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TitleColumnHeader, Me.LastModifiedColumnHeader, Me.SpaceUsedColumnHeader})
        Me.DocumentsListListView.ContextMenuStrip = Me.DocumentListContextMenuStrip
        Me.DocumentsListListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentsListListView.FullRowSelect = True
        ListViewGroup1.Header = "Documents"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "Spreadsheets"
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "Presentations"
        ListViewGroup3.Name = "ListViewGroup3"
        ListViewGroup4.Header = "Other"
        ListViewGroup4.Name = "ListViewGroup4"
        Me.DocumentsListListView.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4})
        Me.DocumentsListListView.Location = New System.Drawing.Point(3, 41)
        Me.DocumentsListListView.Name = "DocumentsListListView"
        Me.DocumentsListListView.Size = New System.Drawing.Size(532, 186)
        Me.DocumentsListListView.SmallImageList = Me.imageList
        Me.DocumentsListListView.TabIndex = 21
        Me.DocumentsListListView.UseCompatibleStateImageBehavior = False
        Me.DocumentsListListView.View = System.Windows.Forms.View.Details
        '
        'TitleColumnHeader
        '
        Me.TitleColumnHeader.Text = "Title"
        Me.TitleColumnHeader.Width = 223
        '
        'LastModifiedColumnHeader
        '
        Me.LastModifiedColumnHeader.Text = "Last Modified"
        Me.LastModifiedColumnHeader.Width = 172
        '
        'SpaceUsedColumnHeader
        '
        Me.SpaceUsedColumnHeader.Text = "Quota Used"
        Me.SpaceUsedColumnHeader.Width = 120
        '
        'DocumentListContextMenuStrip
        '
        Me.DocumentListContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator7, Me.OpenInBrowserToolStripMenuItem, Me.EditLocallyToolStripMenuItem, Me.StarredToolStripMenuItem, Me.ExportToolStripMenuItem, Me.UploadNewVersionToolStripMenuItem, Me.RenameToolStripMenuItem, Me.ToolStripSeparator13, Me.ShareToolStripMenuItem, Me.ViewSharingToolStripMenuItem, Me.ToolStripSeparator19, Me.EmailFileToolStripMenuItem, Me.SendToMyKindleToolStripMenuItem, Me.ToolStripSeparator5, Me.ViewFileCollectionsToolStripMenuItem, Me.RemoveFromCollectionToolStripMenuItem, Me.DeleteFileToolStripMenuItem, Me.ToolStripSeparator1, Me.DownloadDirectoryListingToolStripMenuItem, Me.AdvancedPropertiesToolStripMenuItem, Me.ToolStripSeparator6, Me.SelectToolStripMenuItem, Me.CopyToolStripMenuItem, Me.ToolStripSeparator12, Me.RefreshDocumentsToolStripMenuItem})
        Me.DocumentListContextMenuStrip.Name = "ContextMenuStrip1"
        Me.DocumentListContextMenuStrip.Size = New System.Drawing.Size(233, 464)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadFileToolStripMenuItem1, Me.UploadFolderToolStripMenuItem1})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuItem1.Text = "Upload"
        '
        'UploadFileToolStripMenuItem1
        '
        Me.UploadFileToolStripMenuItem1.Name = "UploadFileToolStripMenuItem1"
        Me.UploadFileToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.UploadFileToolStripMenuItem1.Text = "Upload File..."
        '
        'UploadFolderToolStripMenuItem1
        '
        Me.UploadFolderToolStripMenuItem1.Name = "UploadFolderToolStripMenuItem1"
        Me.UploadFolderToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.UploadFolderToolStripMenuItem1.Text = "Upload Folder..."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(229, 6)
        '
        'OpenInBrowserToolStripMenuItem
        '
        Me.OpenInBrowserToolStripMenuItem.Image = CType(resources.GetObject("OpenInBrowserToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenInBrowserToolStripMenuItem.Name = "OpenInBrowserToolStripMenuItem"
        Me.OpenInBrowserToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.OpenInBrowserToolStripMenuItem.Text = "Open in Browser"
        '
        'EditLocallyToolStripMenuItem
        '
        Me.EditLocallyToolStripMenuItem.Name = "EditLocallyToolStripMenuItem"
        Me.EditLocallyToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.EditLocallyToolStripMenuItem.Text = "Edit Locally..."
        '
        'StarredToolStripMenuItem
        '
        Me.StarredToolStripMenuItem.Name = "StarredToolStripMenuItem"
        Me.StarredToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.StarredToolStripMenuItem.Text = "Star File"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Image = CType(resources.GetObject("ExportToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ExportToolStripMenuItem.Text = "Download..."
        '
        'UploadNewVersionToolStripMenuItem
        '
        Me.UploadNewVersionToolStripMenuItem.Name = "UploadNewVersionToolStripMenuItem"
        Me.UploadNewVersionToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.UploadNewVersionToolStripMenuItem.Text = "Upload New Version..."
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.RenameToolStripMenuItem.Text = "Rename..."
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(229, 6)
        '
        'ShareToolStripMenuItem
        '
        Me.ShareToolStripMenuItem.Name = "ShareToolStripMenuItem"
        Me.ShareToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ShareToolStripMenuItem.Text = "Share..."
        '
        'ViewSharingToolStripMenuItem
        '
        Me.ViewSharingToolStripMenuItem.Name = "ViewSharingToolStripMenuItem"
        Me.ViewSharingToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ViewSharingToolStripMenuItem.Text = "View Sharing..."
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(229, 6)
        '
        'EmailFileToolStripMenuItem
        '
        Me.EmailFileToolStripMenuItem.Image = CType(resources.GetObject("EmailFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EmailFileToolStripMenuItem.Name = "EmailFileToolStripMenuItem"
        Me.EmailFileToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.EmailFileToolStripMenuItem.Text = "Email Selected Files..."
        '
        'SendToMyKindleToolStripMenuItem
        '
        Me.SendToMyKindleToolStripMenuItem.Name = "SendToMyKindleToolStripMenuItem"
        Me.SendToMyKindleToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SendToMyKindleToolStripMenuItem.Text = "Send to My Kindle..."
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(229, 6)
        '
        'ViewFileCollectionsToolStripMenuItem
        '
        Me.ViewFileCollectionsToolStripMenuItem.Name = "ViewFileCollectionsToolStripMenuItem"
        Me.ViewFileCollectionsToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ViewFileCollectionsToolStripMenuItem.Text = "Parent Collections..."
        '
        'RemoveFromCollectionToolStripMenuItem
        '
        Me.RemoveFromCollectionToolStripMenuItem.Name = "RemoveFromCollectionToolStripMenuItem"
        Me.RemoveFromCollectionToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.RemoveFromCollectionToolStripMenuItem.Text = "Remove from Collection..."
        '
        'DeleteFileToolStripMenuItem
        '
        Me.DeleteFileToolStripMenuItem.Image = CType(resources.GetObject("DeleteFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
        Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.DeleteFileToolStripMenuItem.Text = "Delete File..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(229, 6)
        '
        'DownloadDirectoryListingToolStripMenuItem
        '
        Me.DownloadDirectoryListingToolStripMenuItem.Name = "DownloadDirectoryListingToolStripMenuItem"
        Me.DownloadDirectoryListingToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.DownloadDirectoryListingToolStripMenuItem.Text = "Download Collection Listing..."
        '
        'AdvancedPropertiesToolStripMenuItem
        '
        Me.AdvancedPropertiesToolStripMenuItem.Name = "AdvancedPropertiesToolStripMenuItem"
        Me.AdvancedPropertiesToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.AdvancedPropertiesToolStripMenuItem.Text = "Advanced File Properties..."
        Me.AdvancedPropertiesToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(229, 6)
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllToolStripMenuItem, Me.NoneToolStripMenuItem})
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'NoneToolStripMenuItem
        '
        Me.NoneToolStripMenuItem.Name = "NoneToolStripMenuItem"
        Me.NoneToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.NoneToolStripMenuItem.Text = "None"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentTitleToolStripMenuItem})
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'DocumentTitleToolStripMenuItem
        '
        Me.DocumentTitleToolStripMenuItem.Name = "DocumentTitleToolStripMenuItem"
        Me.DocumentTitleToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.DocumentTitleToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DocumentTitleToolStripMenuItem.Text = "Document Title"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(229, 6)
        '
        'RefreshDocumentsToolStripMenuItem
        '
        Me.RefreshDocumentsToolStripMenuItem.Image = CType(resources.GetObject("RefreshDocumentsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RefreshDocumentsToolStripMenuItem.Name = "RefreshDocumentsToolStripMenuItem"
        Me.RefreshDocumentsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RefreshDocumentsToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.RefreshDocumentsToolStripMenuItem.Text = "Refresh"
        '
        'MainMenuStrip
        '
        Me.MainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MainMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainMenuStrip.Name = "MainMenuStrip"
        Me.MainMenuStrip.Size = New System.Drawing.Size(762, 24)
        Me.MainMenuStrip.TabIndex = 29
        Me.MainMenuStrip.Text = "MenuStrip1"
        '
        'MainToolStripMenuItem
        '
        Me.MainToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.MainToolStripMenuItem.Name = "MainToolStripMenuItem"
        Me.MainToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.MainToolStripMenuItem.Text = "gExplore"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = CType(resources.GetObject("SettingsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(122, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindToolStripMenuItem})
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PermissionsAuditToolStripMenuItem, Me.FileSizeAuditToolStripMenuItem, Me.ToolStripSeparator21, Me.DecryptFileToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'PermissionsAuditToolStripMenuItem
        '
        Me.PermissionsAuditToolStripMenuItem.Name = "PermissionsAuditToolStripMenuItem"
        Me.PermissionsAuditToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.PermissionsAuditToolStripMenuItem.Text = "Permissions Audit..."
        '
        'FileSizeAuditToolStripMenuItem
        '
        Me.FileSizeAuditToolStripMenuItem.Name = "FileSizeAuditToolStripMenuItem"
        Me.FileSizeAuditToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.FileSizeAuditToolStripMenuItem.Text = "File Size Audit..."
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(175, 6)
        '
        'DecryptFileToolStripMenuItem
        '
        Me.DecryptFileToolStripMenuItem.Name = "DecryptFileToolStripMenuItem"
        Me.DecryptFileToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.DecryptFileToolStripMenuItem.Text = "Decrypt File..."
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewByFileTypeToolStripMenuItem, Me.ToolStripSeparator15, Me.ViewLogToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ViewByFileTypeToolStripMenuItem
        '
        Me.ViewByFileTypeToolStripMenuItem.Checked = True
        Me.ViewByFileTypeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ViewByFileTypeToolStripMenuItem.Name = "ViewByFileTypeToolStripMenuItem"
        Me.ViewByFileTypeToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ViewByFileTypeToolStripMenuItem.Text = "Group by File Type"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(169, 6)
        '
        'ViewLogToolStripMenuItem
        '
        Me.ViewLogToolStripMenuItem.Name = "ViewLogToolStripMenuItem"
        Me.ViewLogToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.ViewLogToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ViewLogToolStripMenuItem.Text = "Log"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripButton, Me.ToolStripSeparator3, Me.UploadToolStripDropDownButton, Me.DownloadToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 227)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(532, 25)
        Me.ToolStrip1.TabIndex = 31
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'RefreshToolStripButton
        '
        Me.RefreshToolStripButton.Image = CType(resources.GetObject("RefreshToolStripButton.Image"), System.Drawing.Image)
        Me.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshToolStripButton.Name = "RefreshToolStripButton"
        Me.RefreshToolStripButton.Size = New System.Drawing.Size(104, 22)
        Me.RefreshToolStripButton.Text = "Refresh Listing"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'UploadToolStripDropDownButton
        '
        Me.UploadToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadFileToolStripMenuItem, Me.UploadFolderToolStripMenuItem})
        Me.UploadToolStripDropDownButton.Image = CType(resources.GetObject("UploadToolStripDropDownButton.Image"), System.Drawing.Image)
        Me.UploadToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UploadToolStripDropDownButton.Name = "UploadToolStripDropDownButton"
        Me.UploadToolStripDropDownButton.Size = New System.Drawing.Size(74, 22)
        Me.UploadToolStripDropDownButton.Text = "Upload"
        '
        'UploadFileToolStripMenuItem
        '
        Me.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem"
        Me.UploadFileToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.UploadFileToolStripMenuItem.Text = "Upload File..."
        Me.UploadFileToolStripMenuItem.ToolTipText = "Upload a single file to Google Docs."
        '
        'UploadFolderToolStripMenuItem
        '
        Me.UploadFolderToolStripMenuItem.Name = "UploadFolderToolStripMenuItem"
        Me.UploadFolderToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.UploadFolderToolStripMenuItem.Text = "Upload Folder..."
        Me.UploadFolderToolStripMenuItem.ToolTipText = "Upload the contents of a folder to Google Docs."
        '
        'DownloadToolStripButton
        '
        Me.DownloadToolStripButton.Enabled = False
        Me.DownloadToolStripButton.Image = CType(resources.GetObject("DownloadToolStripButton.Image"), System.Drawing.Image)
        Me.DownloadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DownloadToolStripButton.Name = "DownloadToolStripButton"
        Me.DownloadToolStripButton.Size = New System.Drawing.Size(81, 22)
        Me.DownloadToolStripButton.Text = "Download"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FoldersTreeView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(762, 281)
        Me.SplitContainer1.SplitterDistance = 212
        Me.SplitContainer1.TabIndex = 32
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 249)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(212, 32)
        Me.Panel4.TabIndex = 26
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(546, 281)
        Me.TabControl1.TabIndex = 34
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DocumentsListListView)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.ToolStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(538, 255)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Documents"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CurrentDirectoryLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 38)
        Me.Panel1.TabIndex = 22
        '
        'CurrentDirectoryLabel
        '
        Me.CurrentDirectoryLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentDirectoryLabel.AutoEllipsis = True
        Me.CurrentDirectoryLabel.Location = New System.Drawing.Point(6, 12)
        Me.CurrentDirectoryLabel.Name = "CurrentDirectoryLabel"
        Me.CurrentDirectoryLabel.Size = New System.Drawing.Size(416, 13)
        Me.CurrentDirectoryLabel.TabIndex = 0
        Me.CurrentDirectoryLabel.Text = "/"
        '
        'SearchPanel
        '
        Me.SearchPanel.Controls.Add(Me.CloseSearchPictureBox)
        Me.SearchPanel.Controls.Add(Me.SearchFileContentsCheckBox)
        Me.SearchPanel.Controls.Add(Me.SearchButton)
        Me.SearchPanel.Controls.Add(Me.SearchForTextBox)
        Me.SearchPanel.Controls.Add(Me.Label1)
        Me.SearchPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SearchPanel.Location = New System.Drawing.Point(0, 305)
        Me.SearchPanel.Name = "SearchPanel"
        Me.SearchPanel.Size = New System.Drawing.Size(762, 45)
        Me.SearchPanel.TabIndex = 33
        Me.SearchPanel.Visible = False
        '
        'CloseSearchPictureBox
        '
        Me.CloseSearchPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.CloseSearchPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseSearchPictureBox.Image = CType(resources.GetObject("CloseSearchPictureBox.Image"), System.Drawing.Image)
        Me.CloseSearchPictureBox.Location = New System.Drawing.Point(737, 12)
        Me.CloseSearchPictureBox.Name = "CloseSearchPictureBox"
        Me.CloseSearchPictureBox.Size = New System.Drawing.Size(22, 19)
        Me.CloseSearchPictureBox.TabIndex = 34
        Me.CloseSearchPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.CloseSearchPictureBox, "Close search panel.")
        '
        'SearchFileContentsCheckBox
        '
        Me.SearchFileContentsCheckBox.AutoSize = True
        Me.SearchFileContentsCheckBox.Location = New System.Drawing.Point(416, 14)
        Me.SearchFileContentsCheckBox.Name = "SearchFileContentsCheckBox"
        Me.SearchFileContentsCheckBox.Size = New System.Drawing.Size(125, 17)
        Me.SearchFileContentsCheckBox.TabIndex = 34
        Me.SearchFileContentsCheckBox.Text = "Search file contents."
        Me.SearchFileContentsCheckBox.UseVisualStyleBackColor = True
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(335, 10)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 34
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'SearchForTextBox
        '
        Me.SearchForTextBox.Location = New System.Drawing.Point(79, 12)
        Me.SearchForTextBox.Name = "SearchForTextBox"
        Me.SearchForTextBox.Size = New System.Drawing.Size(250, 21)
        Me.SearchForTextBox.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search for:"
        '
        'CloseLogPanelPictureBox
        '
        Me.CloseLogPanelPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.CloseLogPanelPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseLogPanelPictureBox.Image = CType(resources.GetObject("CloseLogPanelPictureBox.Image"), System.Drawing.Image)
        Me.CloseLogPanelPictureBox.Location = New System.Drawing.Point(12, 6)
        Me.CloseLogPanelPictureBox.Name = "CloseLogPanelPictureBox"
        Me.CloseLogPanelPictureBox.Size = New System.Drawing.Size(22, 19)
        Me.CloseLogPanelPictureBox.TabIndex = 35
        Me.CloseLogPanelPictureBox.TabStop = False
        Me.ToolTip1.SetToolTip(Me.CloseLogPanelPictureBox, "Close log panel.")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 450)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(762, 22)
        Me.StatusStrip1.TabIndex = 34
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(747, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "gExplore"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SearchTabContextMenuStrip
        '
        Me.SearchTabContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseTabToolStripMenuItem, Me.CloseAllTabsToolStripMenuItem})
        Me.SearchTabContextMenuStrip.Name = "SearchTabContextMenuStrip"
        Me.SearchTabContextMenuStrip.Size = New System.Drawing.Size(148, 48)
        '
        'CloseTabToolStripMenuItem
        '
        Me.CloseTabToolStripMenuItem.Name = "CloseTabToolStripMenuItem"
        Me.CloseTabToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.CloseTabToolStripMenuItem.Text = "Close Tab"
        '
        'CloseAllTabsToolStripMenuItem
        '
        Me.CloseAllTabsToolStripMenuItem.Name = "CloseAllTabsToolStripMenuItem"
        Me.CloseAllTabsToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.CloseAllTabsToolStripMenuItem.Text = "Close All Tabs"
        '
        'SearchResultsContextMenuStrip
        '
        Me.SearchResultsContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchResultOpenInBrowserToolStripMenuItem, Me.DownloadToolStripMenuItem, Me.ToolStripSeparator16, Me.SearchShareToolStripMenuItem, Me.SearchViewSharingToolStripMenuItem, Me.ToolStripSeparator17, Me.ViewCollectionsToolStripMenuItem, Me.ToolStripSeparator20, Me.CloudFileNotesToolStripMenuItem, Me.ToolStripSeparator18, Me.SearchDeleteFileToolStripMenuItem})
        Me.SearchResultsContextMenuStrip.Name = "SearchResultsContextMenuStrip"
        Me.SearchResultsContextMenuStrip.Size = New System.Drawing.Size(180, 182)
        '
        'SearchResultOpenInBrowserToolStripMenuItem
        '
        Me.SearchResultOpenInBrowserToolStripMenuItem.Image = CType(resources.GetObject("SearchResultOpenInBrowserToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchResultOpenInBrowserToolStripMenuItem.Name = "SearchResultOpenInBrowserToolStripMenuItem"
        Me.SearchResultOpenInBrowserToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SearchResultOpenInBrowserToolStripMenuItem.Text = "Open in Browser..."
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Image = CType(resources.GetObject("DownloadToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.DownloadToolStripMenuItem.Text = "Download..."
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(176, 6)
        '
        'SearchShareToolStripMenuItem
        '
        Me.SearchShareToolStripMenuItem.Name = "SearchShareToolStripMenuItem"
        Me.SearchShareToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SearchShareToolStripMenuItem.Text = "Share..."
        '
        'SearchViewSharingToolStripMenuItem
        '
        Me.SearchViewSharingToolStripMenuItem.Name = "SearchViewSharingToolStripMenuItem"
        Me.SearchViewSharingToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SearchViewSharingToolStripMenuItem.Text = "View Sharing..."
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(176, 6)
        '
        'ViewCollectionsToolStripMenuItem
        '
        Me.ViewCollectionsToolStripMenuItem.Name = "ViewCollectionsToolStripMenuItem"
        Me.ViewCollectionsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ViewCollectionsToolStripMenuItem.Text = "Parent Collections..."
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(176, 6)
        '
        'CloudFileNotesToolStripMenuItem
        '
        Me.CloudFileNotesToolStripMenuItem.Image = CType(resources.GetObject("CloudFileNotesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloudFileNotesToolStripMenuItem.Name = "CloudFileNotesToolStripMenuItem"
        Me.CloudFileNotesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CloudFileNotesToolStripMenuItem.Text = "Cloud File Notes..."
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(176, 6)
        '
        'SearchDeleteFileToolStripMenuItem
        '
        Me.SearchDeleteFileToolStripMenuItem.Image = CType(resources.GetObject("SearchDeleteFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchDeleteFileToolStripMenuItem.Name = "SearchDeleteFileToolStripMenuItem"
        Me.SearchDeleteFileToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SearchDeleteFileToolStripMenuItem.Text = "Delete File..."
        '
        'LogPanel
        '
        Me.LogPanel.Controls.Add(Me.Panel2)
        Me.LogPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LogPanel.Location = New System.Drawing.Point(0, 350)
        Me.LogPanel.Name = "LogPanel"
        Me.LogPanel.Size = New System.Drawing.Size(762, 100)
        Me.LogPanel.TabIndex = 35
        Me.LogPanel.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LogTextBox)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(762, 100)
        Me.Panel2.TabIndex = 1
        '
        'LogTextBox
        '
        Me.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogTextBox.Location = New System.Drawing.Point(0, 0)
        Me.LogTextBox.Multiline = True
        Me.LogTextBox.Name = "LogTextBox"
        Me.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LogTextBox.Size = New System.Drawing.Size(725, 100)
        Me.LogTextBox.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CloseLogPanelPictureBox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(725, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(37, 100)
        Me.Panel3.TabIndex = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 472)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.SearchPanel)
        Me.Controls.Add(Me.MainMenuStrip)
        Me.Controls.Add(Me.LogPanel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(451, 268)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gExplore"
        Me.TrayContextMenuStrip.ResumeLayout(False)
        Me.FoldersContextMenuStrip.ResumeLayout(False)
        Me.DocumentListContextMenuStrip.ResumeLayout(False)
        Me.MainMenuStrip.ResumeLayout(False)
        Me.MainMenuStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.SearchPanel.ResumeLayout(False)
        Me.SearchPanel.PerformLayout()
        CType(Me.CloseSearchPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseLogPanelPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SearchTabContextMenuStrip.ResumeLayout(False)
        Me.SearchResultsContextMenuStrip.ResumeLayout(False)
        Me.LogPanel.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ExportDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Friend WithEvents SystemTrayNotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents TrayContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Private WithEvents FoldersTreeView As System.Windows.Forms.TreeView
    Private WithEvents DocumentsListListView As System.Windows.Forms.ListView
    Private WithEvents TitleColumnHeader As System.Windows.Forms.ColumnHeader
    Private WithEvents LastModifiedColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents MainMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MainToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents RefreshToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloadToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CurrentDirectoryLabel As System.Windows.Forms.Label
    Friend WithEvents UploadToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents UploadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentListContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenInBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AdvancedPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SpaceUsedColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFolderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchPanel As System.Windows.Forms.Panel
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents SearchForTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SearchFileContentsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CloseSearchPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ViewFileCollectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FoldersContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveFromCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshCollectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshDocumentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StarredToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentTitleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SearchTabContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CloseTabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllTabsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchResultsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SearchResultOpenInBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShareCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSharingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewCollectionSharingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PermissionsAuditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DecryptFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogPanel As System.Windows.Forms.Panel
    Friend WithEvents LogTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewByFileTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CloseLogPanelPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchShareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchViewSharingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewCollectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SearchDeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SendToMyKindleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadNewVersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ViewParentCollectionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloudFileNotesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents EmailFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadDirectoryListingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FileSizeAuditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditLocallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
