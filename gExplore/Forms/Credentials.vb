Imports System.Windows.Forms
Imports System.Net
Imports Google.Documents

Public Class Credentials

    Dim gd As gExplore.GoogleDocs

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If EmailAddressTextBox.TextLength = 0 Then

            MessageBox.Show("Please specify a username", "No user name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        If PasswordTextBox.TextLength = 0 Then

            MessageBox.Show("Please specify a password", "No password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        Try

            ' See if we are to use a proxy server.
            If gExplore.SettingsHandler.UseProxy = True Then

                ' Set the proxy settings.
                Dim myproxy As New WebProxy(gExplore.SettingsHandler.ProxyServer, gExplore.SettingsHandler.ProxyPort)

                If gExplore.SettingsHandler.ProxyServerAuth = True Then

                    Dim ProxyUserName As String = gExplore.SettingsHandler.ProxyServerUserName
                    Dim ProxyPassword As String = gExplore.SettingsHandler.ProxyServerPassword
                    myproxy.Credentials = New NetworkCredential(ProxyUserName, ProxyPassword)

                End If

                ' Set the proxy with the service.
                gd = New gExplore.GoogleDocs(EmailAddressTextBox.Text, PasswordTextBox.Text, myproxy)

            Else

                ' No proxy. Just make the service.
                gd = New gExplore.GoogleDocs(EmailAddressTextBox.Text, PasswordTextBox.Text)

            End If

            EmailAddressTextBox.Enabled = False
            PasswordTextBox.Enabled = False
            OK_Button.Enabled = False
            ProxyButton.Enabled = False

            If gd.Login(EmailAddressTextBox.Text, PasswordTextBox.Text) = True Then

                ' Save the credentials.
                gExplore.SettingsHandler.GoogleLogin = EmailAddressTextBox.Text

                If RememberPasswordCheckBox.Checked = True Then
                    gExplore.SettingsHandler.GooglePassword = PasswordTextBox.Text
                Else
                    gExplore.SettingsHandler.GooglePassword = String.Empty
                End If

                Dim m As New MainForm(gd)
                m.Show()

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                MsgBox("Unable to log in to Google Drive. Please check your email and password are correct. If you are using a proxy server verify your proxy server settings.", MsgBoxStyle.Critical)

                EmailAddressTextBox.Enabled = True
                PasswordTextBox.Enabled = True
                OK_Button.Enabled = True
                ProxyButton.Enabled = True

            End If

        Catch ex As Exception

            EmailAddressTextBox.Enabled = True
            PasswordTextBox.Enabled = True
            OK_Button.Enabled = True
            ProxyButton.Enabled = True

            gExplore.Logging.WriteErrorToApplicationLog(ex)
            MsgBox("Error connecting to Google Drive: " & ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub SecurityLinkLabel_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles SecurityLinkLabel.LinkClicked

        CredentialsSecurityToolTip.Show(My.Resources.CredentialsSecurity, SecurityLinkLabel)

    End Sub

    Private Sub Credentials_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Load the credentials.
        EmailAddressTextBox.Text = gExplore.SettingsHandler.GoogleLogin
        PasswordTextBox.Text = gExplore.SettingsHandler.GooglePassword

        If EmailAddressTextBox.TextLength = 0 Then

            ' Put focus on the email box.
            EmailAddressTextBox.Select()

        Else

            If PasswordTextBox.TextLength > 0 Then
                RememberPasswordCheckBox.Checked = True
            Else
                RememberPasswordCheckBox.Checked = False
            End If

            ' Put focus on the password box.
            PasswordTextBox.Select()

        End If

    End Sub

    Private Sub ProxyButton_Click(sender As System.Object, e As System.EventArgs) Handles ProxyButton.Click

        Proxy.ShowDialog()

    End Sub

End Class