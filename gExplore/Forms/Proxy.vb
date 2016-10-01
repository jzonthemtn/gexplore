Imports System.Windows.Forms

Public Class Proxy

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        ' Validate the data.

        If UseProxyCheckBox.Checked = True Then

            If ProxyAddressTextBox.TextLength = 0 Then
                MsgBox("A proxy server address is required.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If IsNumeric(ProxyPortTextBox.Text) = False Then
                MsgBox("The proxy port must be a number.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If ProxyAuthCheckBox.Checked = True Then

                If UserNameTextBox.TextLength = 0 Or PasswordTextBox.TextLength = 0 Then
                    MsgBox("You have selected the proxy server requires authentication but have not entered a user name and a password.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

            End If

        End If

        ' Save the settings.
        gExplore.SettingsHandler.UseProxy = UseProxyCheckBox.Checked
        gExplore.SettingsHandler.ProxyServer = ProxyAddressTextBox.Text
        gExplore.SettingsHandler.ProxyPort = Convert.ToInt32(ProxyPortTextBox.Text)
        gExplore.SettingsHandler.ProxyServerAuth = ProxyAuthCheckBox.Checked
        gExplore.SettingsHandler.ProxyServerUserName = UserNameTextBox.Text
        gExplore.SettingsHandler.ProxyServerPassword = PasswordTextBox.Text

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UseProxyCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles UseProxyCheckBox.CheckedChanged

        ProxyAddressTextBox.Enabled = UseProxyCheckBox.Checked
        AuthGroupBox.Enabled = UseProxyCheckBox.Checked

    End Sub

    Private Sub Proxy_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Load the settings.
        UseProxyCheckBox.Checked = gExplore.SettingsHandler.UseProxy
        ProxyAddressTextBox.Text = gExplore.SettingsHandler.ProxyServer
        ProxyPortTextBox.Text = gExplore.SettingsHandler.ProxyPort.ToString
        ProxyAuthCheckBox.Checked = gExplore.SettingsHandler.ProxyServerAuth
        UserNameTextBox.Text = gExplore.SettingsHandler.ProxyServerUserName
        PasswordTextBox.Text = gExplore.SettingsHandler.ProxyServerPassword

    End Sub

    Private Sub ProxyAuthCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ProxyAuthCheckBox.CheckedChanged

        UserNameTextBox.Enabled = ProxyAuthCheckBox.Checked
        PasswordTextBox.Enabled = ProxyAuthCheckBox.Checked

    End Sub

End Class
