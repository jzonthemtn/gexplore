Imports Google.Documents
Imports Google.GData.Documents
Imports Google.GData.Client
Imports System.Net.Mail
Imports System.Net
Imports System.IO

Public Class EmailFile

    Private p_Documents As List(Of Document)
    Private p_gd As gExplore.GoogleDocs
    Private p_Caller As MainForm

    Public Sub New(gd As gExplore.GoogleDocs, documents As List(Of Document), Caller As MainForm)

        InitializeComponent()

        p_gd = gd
        p_Documents = documents
        p_Caller = Caller

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click

        If gExplore.Miscellaneous.ValidateEmail(SendToTextBox.Text) = True Then

            Me.Cursor = Cursors.WaitCursor

            Dim FilesToAttach As New List(Of String)

            For Each d As Document In p_Documents

                ' Download it.
                Dim LocalFileName As String = p_Caller.DownloadFile(d)

                ' Will be empty if the download failed.
                If LocalFileName <> String.Empty Then

                    FilesToAttach.Add(LocalFileName)

                Else

                    ' The file could not be downloaded.
                    If MsgBox("Unable to attach " & d.Title & " to the email. Continue with remaining files?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If

                End If

            Next

            Try

                gExplore.SendEmail.SendEmailWithOptionalAttachments(p_gd, p_gd.UserName, SendToTextBox.Text, SubjectTextBox.Text, MessageTextBox.Text, FilesToAttach)

                Dim message As New MailMessage()

                Me.Cursor = Cursors.Default

                MsgBox("The email has been sent.", MsgBoxStyle.Information)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception

                Me.Cursor = Cursors.Default

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("An error occurred while sending the mail.", MsgBoxStyle.Critical)

            End Try


        Else

            MsgBox("The email address entered is not a valid email address.", MsgBoxStyle.Critical)
            SendToTextBox.Focus()

        End If

    End Sub

    Private Sub EmailFile_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        SubjectTextBox.Text = "Files from gExplore"

        For Each d As Document In p_Documents

            AttachmentsListBox.Items.Add(d.Title)

        Next

    End Sub

End Class