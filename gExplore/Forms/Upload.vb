Imports System.Windows.Forms
Imports System.IO
Imports Google.GData.Client
Imports Google.GData.Client.ResumableUpload
Imports Google.Documents
Imports Google.GData.Documents

Public Class Upload

    Private gd As gExplore.GoogleDocs
    Private p_ParentCollections As New List(Of Document)

    Public ReadOnly Property GetParentCollections As List(Of Document)
        Get
            Return p_ParentCollections
        End Get
    End Property

    Public Sub New(gdocs As gExplore.GoogleDocs, ParentDocument As Document)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gd = gdocs

        p_ParentCollections.Add(ParentDocument)

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If FileNameTextBox.TextLength > 0 Then

            If File.Exists(FileNameTextBox.Text) = True Then

                Dim InputFile As String = FileNameTextBox.Text

                If EncryptFileCheckBox.Checked = True Then

                    If PasswordTextBox.Text = ConfirmTextBox.Text Then

                        ' Encrypt the file.                    
                        Dim OutputFile As String = Path.Combine(Path.GetTempPath, Path.GetFileName(FileNameTextBox.Text & ".genc"))

                        StatusLabel.Text = "Encrypting..."

                        If gExplore.AESFileEncryption.EncryptOrDecryptFile(InputFile, OutputFile, PasswordTextBox.Text, gExplore.AESFileEncryption.CryptoAction.ActionEncrypt) = True Then

                            ' Upload the file.
                            UploadFile(OutputFile)

                        Else

                            MsgBox("The file " & FileNameTextBox.Text & " could not be encrypted.", MsgBoxStyle.Critical)

                        End If

                    Else

                        MsgBox("The passwords entered do not match.", MsgBoxStyle.Critical)

                    End If

                Else

                    ' Upload the file.
                    UploadFile(InputFile)

                End If

            Else

                MsgBox("The file selected does not exist.", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("Please select a file to upload.", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub EncryptFileCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles EncryptFileCheckBox.CheckedChanged

        PasswordTextBox.Enabled = EncryptFileCheckBox.Checked
        ConfirmTextBox.Enabled = EncryptFileCheckBox.Checked

    End Sub

    ''' <summary>
    ''' Update the text shown in the "To Collection" textbox based on the selected collections.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateToCollectionsText()

        ' Clear and show it.
        ToFolderTextBox.Clear()

        If IsNothing(p_ParentCollections) = False And p_ParentCollections.Count > 0 Then

            ' Only need the first collection. The collection should only have 1 item.
            ToFolderTextBox.Text = p_ParentCollections(0).Title

        End If

    End Sub

    Private Sub Upload_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        UpdateToCollectionsText()

    End Sub

    Private Sub UploadFile(FileName As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            UploadProgressBar.Visible = True
            UploadProgressLabel.Visible = True
            UploadProgressLabel.Text = "0%"
            StatusLabel.Visible = True
            StatusLabel.Text = "Uploading..."

            ' The collection should only have one item and it is the destination.
            Dim DestinationCollection As Document = p_ParentCollections(0)

            ' Upload the file.
            gd.UploadFile(FileName, DestinationCollection, FileName, AddressOf OnDone, AddressOf OnProgress, True)

        Catch ex As ArgumentException

            Me.Cursor = Cursors.Default

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            Dim result As DialogResult = MessageBox.Show("Error, unable to upload the file: '" & FileName & "'. It is not one of the valid types.", "Upload Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

        Catch ex As Exception

            Me.Cursor = Cursors.Default

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            Dim result As DialogResult = MessageBox.Show("Error, unable to upload the file: '" & FileName & "'. " & ex.Message & vbNewLine & vbNewLine & "If this is a shared collection make sure you have been given edit permissions to it.", "Upload Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub OnDone(sender As Object, args As AsyncOperationCompletedEventArgs)

        Me.Cursor = Cursors.Default

        If IsNothing(args.Error) = False Then

            MsgBox("The file could not be uploaded: " & args.Error.Message)

        Else

            MsgBox("The file '" & FileNameTextBox.Text & "' has been uploaded to Google Docs.", MsgBoxStyle.Information)

        End If

        UploadProgressBar.Visible = False
        UploadProgressLabel.Visible = False
        StatusLabel.Visible = False

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub OnProgress(sender As Object, args As AsyncOperationProgressEventArgs)

        UploadProgressBar.Value = args.ProgressPercentage
        UploadProgressLabel.Text = args.ProgressPercentage.ToString & "%"

    End Sub

    Private Sub BrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseButton.Click

        OpenFileDialog1.Title = "Select Files to Upload"
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.ShowReadOnly = False
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 0
        OpenFileDialog1.FileName = String.Empty

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            FileNameTextBox.Text = OpenFileDialog1.FileName

        End If

    End Sub

    Private Sub BrowseToFolderButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseToFolderButton.Click

        Dim bc As New BrowseCollection(gd, False, False)

        If bc.ShowDialog = Windows.Forms.DialogResult.OK Then

            p_ParentCollections = bc.GetSelectedCollections()
            UpdateToCollectionsText()

        End If

    End Sub

End Class
