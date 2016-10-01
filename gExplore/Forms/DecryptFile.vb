Imports System.IO

Public Class DecryptFile

    Private p_InputFile As String
    Private p_OutputFile As String

    Public Sub New(InputFile As String)

        InitializeComponent()

        p_InputFile = InputFile

    End Sub

    Public Sub New()

        InitializeComponent()

    End Sub

    Private Sub FileMetaData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        EncryptedFileTextBox.Text = p_InputFile
        OutputFileTextBox.Text = Path.GetDirectoryName(p_InputFile)

        PasswordTextBox.Select()        

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click

        p_InputFile = EncryptedFileTextBox.Text
        p_OutputFile = Path.Combine(OutputFileTextBox.Text, Path.GetFileName(p_InputFile)).Replace(".genc", String.Empty)

        If File.Exists(p_InputFile) = True Then

            If Directory.Exists(Path.GetDirectoryName(p_OutputFile)) = True Then

                If PasswordTextBox.TextLength > 0 Then

                    Me.Cursor = Cursors.WaitCursor

                    ' Decrypt the file.
                    If gExplore.AESFileEncryption.EncryptOrDecryptFile(p_InputFile, p_OutputFile, PasswordTextBox.Text, gExplore.AESFileEncryption.CryptoAction.ActionDecrypt) = True Then

                        Me.Cursor = Cursors.Default

                        MsgBox("The file has been decrypted.", MsgBoxStyle.Information)

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        Me.Cursor = Cursors.Default

                        MsgBox("The encryption password is incorrect or this file was not encrypted by gExplore.", MsgBoxStyle.Critical)
                        PasswordTextBox.SelectAll()

                    End If

                Else

                    MsgBox("The file's encryption password is required.", MsgBoxStyle.Critical)

                End If

            Else

                MsgBox("The output directory does not exist.", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("The input file does not exist.", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub BrowseFileButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseFileButton.Click

        FolderBrowserDialog1.Description = "Save Decrypted File As"
        FolderBrowserDialog1.ShowNewFolderButton = True

        If EncryptedFileTextBox.TextLength > 0 Then

            FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.Desktop

        End If

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            OutputFileTextBox.Text = FolderBrowserDialog1.SelectedPath

        End If

    End Sub

    Private Sub BrowseEncryptedFileButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseEncryptedFileButton.Click

        OpenFileDialog1.Title = "Select File to Decrypt"
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.Filter = "gEncrypted Files (*.genc)|*.genc|All Files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 0
        OpenFileDialog1.FileName = String.Empty

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            EncryptedFileTextBox.Text = OpenFileDialog1.FileName
            OutputFileTextBox.Text = Path.GetDirectoryName(OpenFileDialog1.FileName)

        End If

    End Sub

End Class