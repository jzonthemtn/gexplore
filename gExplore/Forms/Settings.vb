Imports System.Windows.Forms

Public Class Settings

    Private p_gd As gExplore.GoogleDocs

    Public Sub New(gd As gExplore.GoogleDocs)

        InitializeComponent()

        p_gd = gd

    End Sub

    ''' <summary>
    ''' Saves the settings.
    ''' </summary>
    ''' <returns>True if successful; otherwise false.</returns>
    ''' <remarks></remarks>
    Private Function SaveSettings() As Boolean

        If KindleEmailTextBox.Text.Contains("@") = True Then

            MsgBox("Your Kindle email address contains an invalid character. You just need to enter your Kindle user name (the part of the email address before the @ symbol.", MsgBoxStyle.Critical)

            TabControl1.TabIndex = 1
            KindleEmailTextBox.SelectAll()

        Else

            If IsNumeric(PortTextBox.Text) = False Then

                MsgBox("The SMTP port must be a number.", MsgBoxStyle.Critical)

                TabControl1.TabIndex = 2
                PortTextBox.SelectAll()

            Else

                ' General tab.
                gExplore.SettingsHandler.MinimizeToTray = SendToTrayCheckBox.Checked
                gExplore.SettingsHandler.EnableWeeklyUpdateCheck = EnableWeeklyUpdateChecksCheckBox.Checked

                ' Kindle tab.
                gExplore.SettingsHandler.KindleEmail = KindleEmailTextBox.Text

                ' Email tab.
                gExplore.SettingsHandler.UseCustomSMTP = UseSMTPRadioButton.Checked
                gExplore.SettingsHandler.SMTPHost = SMTPServerTextBox.Text
                gExplore.SettingsHandler.SMTPPort = PortTextBox.Text
                gExplore.SettingsHandler.SMTPRequiresSSL = MailUseSSLCheckBox.Checked
                gExplore.SettingsHandler.SMTPRequiresAuth = MailRequiresAuthCheckBox.Checked
                gExplore.SettingsHandler.SMTPUserName = UserNameTextBox.Text
                gExplore.SettingsHandler.SMTPPassword = PasswordTextBox.Text

                ' Editors tab.
                'gExplore.SettingsHandler.DocumentsEditor = DocumentsEditorTextBox.Text

                Return True

            End If

        End If

        Return False

    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If SaveSettings() = True Then

            ' Settings were saved ok. Close the form.

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ClearSavedCredentialsButton_Click(sender As System.Object, e As System.EventArgs) Handles ClearSavedCredentialsButton.Click

        gExplore.SettingsHandler.GoogleLogin = String.Empty
        gExplore.SettingsHandler.GooglePassword = String.Empty

        MsgBox("Your saved Google credentials have been cleared. You will be asked for your Google email address and password the next time " & Application.ProductName & " is launched.", MsgBoxStyle.Information)

    End Sub

    Private Sub Settings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' General tab.
        SendToTrayCheckBox.Checked = gExplore.SettingsHandler.MinimizeToTray
        EnableWeeklyUpdateChecksCheckBox.Checked = gExplore.SettingsHandler.EnableWeeklyUpdateCheck

        ' Kindle tab.
        KindleEmailTextBox.Text = gExplore.SettingsHandler.KindleEmail

        ' Email tab.
        UseSMTPRadioButton.Checked = gExplore.SettingsHandler.UseCustomSMTP
        SMTPServerTextBox.Text = gExplore.SettingsHandler.SMTPHost
        PortTextBox.Text = gExplore.SettingsHandler.SMTPPort
        MailUseSSLCheckBox.Checked = gExplore.SettingsHandler.SMTPRequiresSSL
        MailRequiresAuthCheckBox.Checked = gExplore.SettingsHandler.SMTPRequiresAuth
        UserNameTextBox.Text = gExplore.SettingsHandler.SMTPUserName
        PasswordTextBox.Text = gExplore.SettingsHandler.SMTPPassword

        ' Editors tab.
        'DocumentsEditorTextBox.Text = gExplore.SettingsHandler.DocumentsEditor

    End Sub

    Private Sub ViewLogButton_Click(sender As System.Object, e As System.EventArgs) Handles ViewLogButton.Click

        System.Diagnostics.Process.Start(gExplore.Logging.GetLogFileName)

    End Sub

    Private Sub ProxyButton_Click(sender As System.Object, e As System.EventArgs) Handles ProxyButton.Click

        If Proxy.ShowDialog() = Windows.Forms.DialogResult.OK Then

            MsgBox("Proxy settings will take affect the next time gExplore is started.", MsgBoxStyle.Information)

        End If

    End Sub

    Private Sub UseSMTPRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles UseSMTPRadioButton.CheckedChanged

        CustomMailSettingsGroupBox.Enabled = UseSMTPRadioButton.Checked

    End Sub

    Private Sub TestMailSettingsButton_Click(sender As System.Object, e As System.EventArgs) Handles TestMailSettingsButton.Click

        If MsgBox("Your current settings will be saved and a test email will be sent to " & p_gd.UserName & ". Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            If SaveSettings() = True Then

                gExplore.SendEmail.SendEmailWithOptionalAttachments(p_gd, p_gd.UserName, p_gd.UserName, "Test from gExplore", "If you receive this message then gExplore is correctly configured to send email!")

                MsgBox("The mail has been sent to " & p_gd.UserName & ". Please check your email to confirm delivery.", MsgBoxStyle.Information)

            End If

        End If

    End Sub

    'Private Sub BrowseDocumentsButton_Click(sender As System.Object, e As System.EventArgs)

    '    OpenFileDialog1.FileName = String.Empty
    '    OpenFileDialog1.Title = "Select Document Editor"
    '    OpenFileDialog1.Filter = "Applications (*.exe)|*.exe|All Files (*.*|*.*"
    '    OpenFileDialog1.CheckFileExists = True
    '    OpenFileDialog1.CheckPathExists = True
    '    If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        DocumentsEditorTextBox.Text = OpenFileDialog1.FileName
    '    End If

    'End Sub

End Class
