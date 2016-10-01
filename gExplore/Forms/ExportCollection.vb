Imports Google.Documents
Imports Google.GData.Client
Imports System.IO
Imports Google.GData.AccessControl

Public Class ExportCollection

    Private p_gd As gExplore.GoogleDocs
    Private p_Document As Document

    Public Sub New(gd As gExplore.GoogleDocs, doc As Document)

        InitializeComponent()

        p_gd = gd
        p_Document = doc

    End Sub

    Private Sub ExportCollectionData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CollectionTextBox.Text = p_Document.Title

        DocumentsFormatComboBox.SelectedIndex = 0
        PresentationsFormatComboBox.SelectedIndex = 0
        SpreadsheetsFormatComboBox.SelectedIndex = 0

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub BrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseButton.Click

        FolderBrowserDialog1.ShowNewFolderButton = True
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.Description = "Select folder to export to."

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            LocalFolderTextBox.Text = FolderBrowserDialog1.SelectedPath

        End If

    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click

        If Directory.Exists(LocalFolderTextBox.Text) = True Then

            Me.Cursor = Cursors.WaitCursor

            ' Export the collection.
            ExploreCollectionContents(p_Document, LocalFolderTextBox.Text)

            Me.Cursor = Cursors.Default

            MsgBox("The collection has been exported.", MsgBoxStyle.Information)

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Else

            MsgBox("The local path " & LocalFolderTextBox.Text & " does not exist.", MsgBoxStyle.Critical)

        End If

    End Sub

    ''' <summary>
    ''' Export the contents of the collection to the local file system.
    ''' </summary>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Private Sub ExploreCollectionContents(collection As Document, LocalPath As String)

        Dim FoldersRequest As New DocumentsRequest(p_gd.GetRequestSettings())
        Dim feed As Feed(Of Document) = FoldersRequest.GetFolderContent(collection)

        For Each f As Document In feed.Entries

            Dim DownloadFileName As String = gExplore.Miscellaneous.SanitizeFileName(f.Title)

            If f.DocumentEntry.IsFolder = False Then

                DownloadFile(f, Path.Combine(LocalPath, DownloadFileName))

            Else

                ' Only descend into children if the box is checked.
                If ExportSubCollectionsCheckBox.Checked = True Then

                    ' Make a directory for this collection.
                    Dim dir As String = Path.Combine(LocalPath, DownloadFileName)
                    Directory.CreateDirectory(dir)

                    ' Export the contents of the child collections.
                    ExploreCollectionContents(f, dir)

                End If

            End If

        Next

    End Sub

    Private Sub DownloadFile(d As Document, LocalFileName As String)

        Dim ExportFormat As String = String.Empty
        'Dim type As Document.DocumentType

        If d.DocumentEntry.IsDocument = True Then

            ExportFormat = DocumentsFormatComboBox.Text.Substring(DocumentsFormatComboBox.Text.IndexOf("(") + 1, 3)
            'type = Document.DocumentType.PDF

        ElseIf d.DocumentEntry.IsPresentation = True Then

            ExportFormat = PresentationsFormatComboBox.Text.Substring(PresentationsFormatComboBox.Text.IndexOf("(") + 1, 3)
            'type = Document.DocumentType.PDF

        ElseIf d.DocumentEntry.IsSpreadsheet = True Then

            ExportFormat = SpreadsheetsFormatComboBox.Text.Substring(SpreadsheetsFormatComboBox.Text.IndexOf("(") + 1, 3)
            'type = Document.DocumentType.PDF

        Else

            ExportFormat = "pdf"
            'type = Document.DocumentType.PDF

        End If

        ' Add the extension to the file name if it isn't already there.
        If Path.GetExtension(LocalFileName) <> "." & ExportFormat Then
            LocalFileName = LocalFileName & "." & ExportFormat
        End If

        ' Create the request if we need one.
        If IsNothing(p_gd.Request) = True Then
            p_gd.Request = New DocumentsRequest(p_gd.GetRequestSettings())
            p_gd.Request.Proxy = p_gd.ProxyServer
        End If

        ' Download the file.
        Dim stream As Stream = p_gd.Request.Download(d, ExportFormat)

        Dim file As New FileStream(LocalFileName, FileMode.Create, FileAccess.Write)

        If file IsNot Nothing Then

            Dim nBytes As Integer = 2048
            Dim count As Integer = 0
            Dim arr As Byte() = New Byte(nBytes - 1) {}

            Do

                count = stream.Read(arr, 0, nBytes)
                file.Write(arr, 0, count)

            Loop While count > 0

            file.Flush()
            file.Close()

        End If

        stream.Close()

    End Sub

End Class