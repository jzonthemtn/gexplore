<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ClearSavedCredentialsButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SendToTrayCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.EnableWeeklyUpdateChecksCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckForUpdatesButton = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ProxyButton = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ViewLogButton = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.KindleHelpLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.KindleEmailTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TestMailSettingsButton = New System.Windows.Forms.Button()
        Me.CustomMailSettingsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MailRequiresAuthCheckBox = New System.Windows.Forms.CheckBox()
        Me.MailUseSSLCheckBox = New System.Windows.Forms.CheckBox()
        Me.PortTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SMTPServerTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UseSMTPRadioButton = New System.Windows.Forms.RadioButton()
        Me.UseGmailRadioButton = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.CustomMailSettingsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(309, 325)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ClearSavedCredentialsButton)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Security"
        '
        'ClearSavedCredentialsButton
        '
        Me.ClearSavedCredentialsButton.Location = New System.Drawing.Point(21, 29)
        Me.ClearSavedCredentialsButton.Name = "ClearSavedCredentialsButton"
        Me.ClearSavedCredentialsButton.Size = New System.Drawing.Size(156, 23)
        Me.ClearSavedCredentialsButton.TabIndex = 0
        Me.ClearSavedCredentialsButton.Text = "Clear Saved Credentials"
        Me.ClearSavedCredentialsButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SendToTrayCheckBox)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 72)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "General"
        '
        'SendToTrayCheckBox
        '
        Me.SendToTrayCheckBox.AutoSize = True
        Me.SendToTrayCheckBox.Location = New System.Drawing.Point(18, 31)
        Me.SendToTrayCheckBox.Name = "SendToTrayCheckBox"
        Me.SendToTrayCheckBox.Size = New System.Drawing.Size(273, 17)
        Me.SendToTrayCheckBox.TabIndex = 0
        Me.SendToTrayCheckBox.Text = "When minimized, send gExplore to the system tray."
        Me.SendToTrayCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.EnableWeeklyUpdateChecksCheckBox)
        Me.GroupBox3.Controls.Add(Me.CheckForUpdatesButton)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 173)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(207, 84)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Updates"
        '
        'EnableWeeklyUpdateChecksCheckBox
        '
        Me.EnableWeeklyUpdateChecksCheckBox.Location = New System.Drawing.Point(21, 55)
        Me.EnableWeeklyUpdateChecksCheckBox.Name = "EnableWeeklyUpdateChecksCheckBox"
        Me.EnableWeeklyUpdateChecksCheckBox.Size = New System.Drawing.Size(154, 17)
        Me.EnableWeeklyUpdateChecksCheckBox.TabIndex = 4
        Me.EnableWeeklyUpdateChecksCheckBox.Text = "Check for updates weekly."
        Me.EnableWeeklyUpdateChecksCheckBox.UseVisualStyleBackColor = True
        '
        'CheckForUpdatesButton
        '
        Me.CheckForUpdatesButton.Location = New System.Drawing.Point(21, 29)
        Me.CheckForUpdatesButton.Name = "CheckForUpdatesButton"
        Me.CheckForUpdatesButton.Size = New System.Drawing.Size(156, 23)
        Me.CheckForUpdatesButton.TabIndex = 0
        Me.CheckForUpdatesButton.Text = "Check for Updates"
        Me.CheckForUpdatesButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(444, 303)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(436, 277)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ProxyButton)
        Me.GroupBox6.Location = New System.Drawing.Point(227, 95)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(192, 72)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Proxy"
        '
        'ProxyButton
        '
        Me.ProxyButton.Location = New System.Drawing.Point(38, 29)
        Me.ProxyButton.Name = "ProxyButton"
        Me.ProxyButton.Size = New System.Drawing.Size(118, 23)
        Me.ProxyButton.TabIndex = 0
        Me.ProxyButton.Text = "Set Proxy..."
        Me.ProxyButton.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ViewLogButton)
        Me.GroupBox5.Location = New System.Drawing.Point(227, 173)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(192, 84)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Diagnostic Logging"
        '
        'ViewLogButton
        '
        Me.ViewLogButton.Location = New System.Drawing.Point(38, 29)
        Me.ViewLogButton.Name = "ViewLogButton"
        Me.ViewLogButton.Size = New System.Drawing.Size(118, 23)
        Me.ViewLogButton.TabIndex = 0
        Me.ViewLogButton.Text = "View Log"
        Me.ViewLogButton.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(436, 277)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Send to Kindle"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.KindleHelpLinkLabel)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.KindleEmailTextBox)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 17)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(408, 108)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Email Addresses"
        '
        'KindleHelpLinkLabel
        '
        Me.KindleHelpLinkLabel.AutoSize = True
        Me.KindleHelpLinkLabel.Location = New System.Drawing.Point(147, 68)
        Me.KindleHelpLinkLabel.Name = "KindleHelpLinkLabel"
        Me.KindleHelpLinkLabel.Size = New System.Drawing.Size(68, 13)
        Me.KindleHelpLinkLabel.TabIndex = 3
        Me.KindleHelpLinkLabel.TabStop = True
        Me.KindleHelpLinkLabel.Text = "What is this?"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(324, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "@kindle.com"
        '
        'KindleEmailTextBox
        '
        Me.KindleEmailTextBox.Location = New System.Drawing.Point(150, 31)
        Me.KindleEmailTextBox.Name = "KindleEmailTextBox"
        Me.KindleEmailTextBox.Size = New System.Drawing.Size(168, 21)
        Me.KindleEmailTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "My Kindle Email Address:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TestMailSettingsButton)
        Me.TabPage3.Controls.Add(Me.CustomMailSettingsGroupBox)
        Me.TabPage3.Controls.Add(Me.UseSMTPRadioButton)
        Me.TabPage3.Controls.Add(Me.UseGmailRadioButton)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(436, 277)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Sending Mail"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TestMailSettingsButton
        '
        Me.TestMailSettingsButton.Location = New System.Drawing.Point(345, 15)
        Me.TestMailSettingsButton.Name = "TestMailSettingsButton"
        Me.TestMailSettingsButton.Size = New System.Drawing.Size(75, 23)
        Me.TestMailSettingsButton.TabIndex = 4
        Me.TestMailSettingsButton.Text = "Test..."
        Me.TestMailSettingsButton.UseVisualStyleBackColor = True
        '
        'CustomMailSettingsGroupBox
        '
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.PasswordTextBox)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.Label5)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.UserNameTextBox)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.Label6)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.MailRequiresAuthCheckBox)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.MailUseSSLCheckBox)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.PortTextBox)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.Label4)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.SMTPServerTextBox)
        Me.CustomMailSettingsGroupBox.Controls.Add(Me.Label3)
        Me.CustomMailSettingsGroupBox.Enabled = False
        Me.CustomMailSettingsGroupBox.Location = New System.Drawing.Point(22, 76)
        Me.CustomMailSettingsGroupBox.Name = "CustomMailSettingsGroupBox"
        Me.CustomMailSettingsGroupBox.Size = New System.Drawing.Size(387, 175)
        Me.CustomMailSettingsGroupBox.TabIndex = 4
        Me.CustomMailSettingsGroupBox.TabStop = False
        Me.CustomMailSettingsGroupBox.Text = "Custom Mail Settings"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(257, 128)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(107, 21)
        Me.PasswordTextBox.TabIndex = 14
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(199, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Password:"
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Location = New System.Drawing.Point(86, 128)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(107, 21)
        Me.UserNameTextBox.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "User Name:"
        '
        'MailRequiresAuthCheckBox
        '
        Me.MailRequiresAuthCheckBox.AutoSize = True
        Me.MailRequiresAuthCheckBox.Location = New System.Drawing.Point(23, 106)
        Me.MailRequiresAuthCheckBox.Name = "MailRequiresAuthCheckBox"
        Me.MailRequiresAuthCheckBox.Size = New System.Drawing.Size(176, 17)
        Me.MailRequiresAuthCheckBox.TabIndex = 10
        Me.MailRequiresAuthCheckBox.Text = "Server requires authentication:"
        Me.MailRequiresAuthCheckBox.UseVisualStyleBackColor = True
        '
        'MailUseSSLCheckBox
        '
        Me.MailUseSSLCheckBox.AutoSize = True
        Me.MailUseSSLCheckBox.Location = New System.Drawing.Point(23, 83)
        Me.MailUseSSLCheckBox.Name = "MailUseSSLCheckBox"
        Me.MailUseSSLCheckBox.Size = New System.Drawing.Size(124, 17)
        Me.MailUseSSLCheckBox.TabIndex = 9
        Me.MailUseSSLCheckBox.Text = "Server requires SSL."
        Me.MailUseSSLCheckBox.UseVisualStyleBackColor = True
        '
        'PortTextBox
        '
        Me.PortTextBox.Location = New System.Drawing.Point(127, 51)
        Me.PortTextBox.MaxLength = 5
        Me.PortTextBox.Name = "PortTextBox"
        Me.PortTextBox.Size = New System.Drawing.Size(107, 21)
        Me.PortTextBox.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Port:"
        '
        'SMTPServerTextBox
        '
        Me.SMTPServerTextBox.Location = New System.Drawing.Point(127, 24)
        Me.SMTPServerTextBox.Name = "SMTPServerTextBox"
        Me.SMTPServerTextBox.Size = New System.Drawing.Size(237, 21)
        Me.SMTPServerTextBox.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Mail (SMTP) Server:"
        '
        'UseSMTPRadioButton
        '
        Me.UseSMTPRadioButton.AutoSize = True
        Me.UseSMTPRadioButton.Location = New System.Drawing.Point(22, 44)
        Me.UseSMTPRadioButton.Name = "UseSMTPRadioButton"
        Me.UseSMTPRadioButton.Size = New System.Drawing.Size(193, 17)
        Me.UseSMTPRadioButton.TabIndex = 1
        Me.UseSMTPRadioButton.TabStop = True
        Me.UseSMTPRadioButton.Text = "Send mail using the settings below:"
        Me.UseSMTPRadioButton.UseVisualStyleBackColor = True
        '
        'UseGmailRadioButton
        '
        Me.UseGmailRadioButton.AutoSize = True
        Me.UseGmailRadioButton.Checked = True
        Me.UseGmailRadioButton.Location = New System.Drawing.Point(22, 21)
        Me.UseGmailRadioButton.Name = "UseGmailRadioButton"
        Me.UseGmailRadioButton.Size = New System.Drawing.Size(188, 17)
        Me.UseGmailRadioButton.TabIndex = 0
        Me.UseGmailRadioButton.TabStop = True
        Me.UseGmailRadioButton.Text = "Send mail using my Gmail account."
        Me.UseGmailRadioButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Settings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(467, 366)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "gExplore Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.CustomMailSettingsGroupBox.ResumeLayout(False)
        Me.CustomMailSettingsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ClearSavedCredentialsButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SendToTrayCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckForUpdatesButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents KindleEmailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents KindleHelpLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ViewLogButton As System.Windows.Forms.Button
    Friend WithEvents EnableWeeklyUpdateChecksCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ProxyButton As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents UseSMTPRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents UseGmailRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents CustomMailSettingsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents TestMailSettingsButton As System.Windows.Forms.Button
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MailRequiresAuthCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MailUseSSLCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SMTPServerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
