Imports System.Net.Mail
Imports System.Net
Imports Google.Documents

Namespace gExplore

    Public Class SendEmail

        ''' <summary>
        ''' Send a document to the user's Kindle email address.
        ''' </summary>
        ''' <param name="gd"></param>
        ''' <param name="AttachmentFileNames">List of files to send. Will only be 1 for Kindle.</param>
        ''' <remarks></remarks>
        Public Shared Sub SendToKindle(gd As GoogleDocs, AttachmentFileNames As List(Of String))

            Dim UsersKindleAddress As String = gExplore.SettingsHandler.KindleEmail & "@kindle.com"
            SendEmailWithOptionalAttachments(gd, gd.UserName, UsersKindleAddress, "Documents sent from gExplore", "Documents sent to my Kindle via " & Application.ProductName & ".", AttachmentFileNames)

        End Sub

        ''' <summary>
        ''' Send an email with an attachment.
        ''' </summary>
        ''' <param name="gd"></param>
        ''' <param name="FromAddress"></param>
        ''' <param name="ToAddress"></param>
        ''' <param name="Subject"></param>
        ''' <param name="Body"></param>
        ''' <param name="AttachmentFileNames">List of files to attach to the email message.</param>
        ''' <remarks></remarks>
        Public Shared Sub SendEmailWithOptionalAttachments(gd As GoogleDocs, FromAddress As String, ToAddress As String, Subject As String, Body As String, Optional AttachmentFileNames As List(Of String) = Nothing)

            Dim message As New MailMessage()

            message.From = New MailAddress(FromAddress)
            message.To.Add(New MailAddress(ToAddress))

            message.Subject = Subject
            message.Body = Body
            message.IsBodyHtml = False

            If IsNothing(AttachmentFileNames) = False Then

                For Each FileToattach As String In AttachmentFileNames

                    ' Add attachment.
                    Dim attachment As New Mail.Attachment(FileToattach)
                    message.Attachments.Add(attachment)

                Next

            End If

            Dim client As SmtpClient

            If gExplore.SettingsHandler.UseCustomSMTP = True Then

                ' Send the email using their custom email settings.

                client = New SmtpClient(gExplore.SettingsHandler.SMTPHost, Convert.ToInt32(gExplore.SettingsHandler.SMTPPort))
                client.EnableSsl = gExplore.SettingsHandler.SMTPRequiresSSL

                ' Server require authentication?
                If gExplore.SettingsHandler.SMTPRequiresAuth = True Then
                    client.UseDefaultCredentials = False
                    client.Credentials = New NetworkCredential(gExplore.SettingsHandler.SMTPUserName, gExplore.SettingsHandler.SMTPPassword)
                End If

            Else

                ' Send the email using their Gmail account.

                client = New SmtpClient("smtp.gmail.com", 587)
                client.EnableSsl = True

                ' Set the credentials.
                client.UseDefaultCredentials = False
                client.Credentials = New NetworkCredential(gd.UserName, gd.Password)

            End If

            ' Sent the message.
            client.Send(message)

        End Sub

    End Class

End Namespace