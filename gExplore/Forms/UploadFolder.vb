Imports System.Windows.Forms
Imports System.IO
Imports Google.GData.Client
Imports Google.GData.Client.ResumableUpload
Imports Google.Documents

Public Class UploadFolder

    Private p_gd As gExplore.GoogleDocs

    ' Keep track of where we're at in the uploading.
    Private p_DirectoriesToBeUploadedCount As Integer = 0
    Private p_DirectoryBeingUploaded As Integer = 0
    Private p_UploadInProgress As Boolean = False

    ' THe collection to upload to.
    Private p_ParentCollections As New List(Of Document)

    ' The calling form.
    Private p_CallingForm As MainForm

    Public ReadOnly Property GetParentCollections As List(Of Document)
        Get
            Return p_ParentCollections
        End Get
    End Property

    Public Sub New(gdocs As gExplore.GoogleDocs, ParentCollection As Document, CallingForm As MainForm)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_gd = gdocs
        p_CallingForm = CallingForm

        p_ParentCollections.Add(ParentCollection)

    End Sub

    Private Function UploadParamatersValidated() As Boolean

        ' Check stuff first.
        If EncryptFileCheckBox.Checked = True Then

            If PasswordTextBox.TextLength > 0 Then

                If PasswordTextBox.Text <> ConfirmTextBox.Text Then

                    MsgBox("The passwords entered do not match.", MsgBoxStyle.Critical)
                    Return False

                End If

            Else

                MsgBox("A password is required to encrypt the files.", MsgBoxStyle.Critical)
                Return False

            End If

        End If

        If FolderTextBox.TextLength > 0 Then

            If Directory.Exists(FolderTextBox.Text) = False Then

                MsgBox("The folder selected does not exist.", MsgBoxStyle.Critical)
                Return False

            End If

        Else

            MsgBox("Please select a folder to upload.", MsgBoxStyle.Critical)
            Return False

        End If

        Return True

    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If UploadParamatersValidated() = True Then

            Dim FolderToUpload As String = FolderTextBox.Text

            ' List should only have one item and it is the destination collection.
            Dim DestinationCollection As Document = p_ParentCollections(0)

            ' Make this directory a folder in Google Docs.
            Dim NewCollectionResourceID As String = p_gd.CreateCollection(DestinationCollection, Path.GetFileName(FolderToUpload))

            ' The new collection.
            Dim NewCollection As Document = p_gd.FindObject(NewCollectionResourceID)

            Me.Cursor = Cursors.WaitCursor

            ' Upload the top-level directory.
            UploadFiles(FolderToUpload, NewCollection)

            If UploadSubFoldersCheckBox.Checked = True Then

                ' Set the number of directories to upload for progress.
                Dim alldirectories As IEnumerable(Of String) = Directory.EnumerateDirectories(FolderToUpload, "*", SearchOption.AllDirectories)
                p_DirectoriesToBeUploadedCount = alldirectories.Count

                ' Set up the progress bar.
                UploadProgressBar.Minimum = 0
                UploadProgressBar.Maximum = p_DirectoriesToBeUploadedCount
                UploadProgressBar.Visible = True

                ' Upload all sub-directories.
                UploadDirectories(FolderToUpload, NewCollection)

            End If

            Me.Cursor = Cursors.Default

            MsgBox("The folder " & FolderToUpload & " has been uploaded.", MsgBoxStyle.Information)

            ' Refresh the destination folder in the main window.            
            p_CallingForm.RefreshFolders()
            Dim ParentTreeNode As TreeNode = p_CallingForm.FindCollectionInTreeNode(p_ParentCollections(0))

            ' If it was found (and it should be), expand its children.
            If IsNothing(ParentTreeNode) = False Then
                ParentTreeNode.Expand()
            End If

            ' Close the window.
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
            Me.Dispose()

        End If

    End Sub

    ''' <summary>
    ''' Upload the directories (and files) recursively into the collection.
    ''' </summary>
    ''' <param name="FolderToUpload"></param>
    ''' <param name="ParentCollection"></param>
    ''' <remarks></remarks>
    Private Sub UploadDirectories(FolderToUpload As String, ParentCollection As Document)

        ' Get the sub-folders.
        Dim directories As IEnumerable(Of String) = Directory.EnumerateDirectories(FolderToUpload, "*", SearchOption.TopDirectoryOnly)

        For Each d As String In directories

            ' Get the name of the directory (strip off the full path).
            Dim DirectoryName As String = d.Replace(FolderToUpload & "\", String.Empty)

            ' Make this directory a folder in Google Docs.
            Dim NewCollectionResourceID As String = p_gd.CreateCollection(ParentCollection, DirectoryName)

            Dim NewParentCollection As Document = p_gd.FindObject(NewCollectionResourceID)

            ' Upload the files in this directory to the new collection.
            UploadFiles(d, NewParentCollection)

            ' Increment the count and the progress bar.
            p_DirectoryBeingUploaded = p_DirectoryBeingUploaded + 1
            UploadProgressBar.Value = p_DirectoryBeingUploaded

            ' Go inside this directory.
            UploadDirectories(d, NewParentCollection)

        Next

    End Sub

    ''' <summary>
    ''' Upload the files inside this folder to the collection.
    ''' </summary>
    ''' <param name="FolderToUpload"></param>
    ''' <param name="ToCollection"></param>
    ''' <remarks></remarks>
    Private Sub UploadFiles(FolderToUpload As String, ToCollection As Document)

        Dim files As IEnumerable(Of String) = Directory.EnumerateFiles(FolderToUpload, FileFilterTextBox.Text, SearchOption.TopDirectoryOnly)

        For Each f As String In files

            ' Don't continue is a file upload is currently in progress.
            While p_UploadInProgress = True
                Application.DoEvents()
            End While

            If EncryptFileCheckBox.Checked = True Then

                ' Encrypt the file.                    
                Dim OutputFile As String = Path.Combine(Path.GetTempPath, Path.GetFileName(f & ".genc"))

                StatusLabel.Text = "Encrypting..."

                If gExplore.AESFileEncryption.EncryptOrDecryptFile(f, OutputFile, PasswordTextBox.Text, gExplore.AESFileEncryption.CryptoAction.ActionEncrypt) = True Then

                    ' Upload the file.
                    UploadFile(OutputFile, ToCollection)

                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("The file could not be encrypted.", MsgBoxStyle.Critical)

                End If

            Else

                ' Upload the file.
                UploadFile(f, ToCollection)

            End If

        Next

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub EncryptFileCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs)

        PasswordTextBox.Enabled = EncryptFileCheckBox.Checked
        ConfirmTextBox.Enabled = EncryptFileCheckBox.Checked

    End Sub

    Private Sub Upload_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        UpdateToCollectionsText()

    End Sub

    ''' <summary>
    ''' Upload the local file to the collection.
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="ToCollection"></param>
    ''' <remarks></remarks>
    Private Sub UploadFile(FileName As String, ToCollection As Document)

        Try

            StatusLabel.Visible = True
            StatusLabel.Text = "Uploading " & FileName

            Dim info As New FileInfo(FileName)

            ' Chunk size in MB
            ' Important: Always choose a chunk size that is a multiple of 512 kilobytes. The last chunk may be smaller than 512 kilobytes.
            Dim CHUNK_SIZE As Integer = 1

            Dim cla As New ClientLoginAuthenticator(Application.ProductName, ServiceNames.Documents, p_gd.UserName, p_gd.Password)

            ' Set up resumable uploader and notifications
            Dim ru As New ResumableUploader(CHUNK_SIZE)

            ' Add handlers for progress.
            AddHandler ru.AsyncOperationCompleted, AddressOf OnDone
            AddHandler ru.AsyncOperationProgress, AddressOf OnProgress

            ' Set metadata for our upload.
            Dim entry As New Document
            entry.Title = Path.GetFileName(FileName)
            entry.MediaSource = New MediaFileSource(FileName, "application/octet-stream")

            Dim createUploadUrl As Uri

            If IsNothing(p_ParentCollections) = True And p_ParentCollections.Count > 0 Then
                createUploadUrl = New Uri("https://docs.google.com/feeds/upload/create-session/default/private/full?convert=false")
            Else
                createUploadUrl = New Uri("https://docs.google.com/feeds/upload/create-session/default/private/full/" & ToCollection.ResourceId & "/contents?convert=false")
            End If

            Dim link As New AtomLink(createUploadUrl.AbsoluteUri)
            link.Rel = ResumableUploader.CreateMediaRelation

            entry.DocumentEntry.Links.Add(link)

            ' Upload the file.
            ru.InsertAsync(cla, entry.DocumentEntry, New Object())

            ' Set that an upload is in progress.
            p_UploadInProgress = True

        Catch ex As ArgumentException

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            Dim result As DialogResult = MessageBox.Show("Error, unable to upload the file: '" & FileName & "'. It is not one of the valid types.", "Upload Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

        Catch ex As Exception

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            Dim result As DialogResult = MessageBox.Show("Error, unable to upload the file: '" & FileName & "'. " & ex.Message, "Upload Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub OnDone(sender As Object, args As AsyncOperationCompletedEventArgs)

        ' Upload was complete. Notify that it is done.
        p_UploadInProgress = False

    End Sub

    Private Sub OnProgress(sender As Object, args As AsyncOperationProgressEventArgs)

        ' Nothing to do in this instance.

    End Sub

    Private Sub BrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseButton.Click

        FolderBrowserDialog1.Description = "Select Folder to Upload"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.ShowNewFolderButton = False

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            FolderTextBox.Text = FolderBrowserDialog1.SelectedPath

        End If

    End Sub

    Private Sub BrowseToFolderButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseToFolderButton.Click

        Dim bc As New BrowseCollection(p_gd, False, False)

        If bc.ShowDialog = Windows.Forms.DialogResult.OK Then

            p_ParentCollections = bc.GetSelectedCollections()
            UpdateToCollectionsText()

        End If

    End Sub

    ''' <summary>
    ''' Update the text shown in the "To Collection" textbox based on the selected collections.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateToCollectionsText()

        ' Clear and show it.
        ToFolderTextBox.Clear()

        If IsNothing(p_ParentCollections) = False And p_ParentCollections.Count > 0 Then
            ToFolderTextBox.Text = p_ParentCollections(0).Title
        End If

    End Sub

End Class
