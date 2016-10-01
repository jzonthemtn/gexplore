<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Credentials
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Credentials))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.EmailAddressTextBox = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.RememberPasswordCheckBox = New System.Windows.Forms.CheckBox()
        Me.InstructionsLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SecurityLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.CredentialsSecurityToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GeneralToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ProxyButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(179, 207)
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
        Me.OK_Button.TabIndex = 13
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 14
        Me.Cancel_Button.Text = "Cancel"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(108, 114)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(214, 21)
        Me.PasswordTextBox.TabIndex = 10
        Me.GeneralToolTip.SetToolTip(Me.PasswordTextBox, "The password for your Google Docs account.")
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'EmailAddressTextBox
        '
        Me.EmailAddressTextBox.Location = New System.Drawing.Point(108, 83)
        Me.EmailAddressTextBox.Name = "EmailAddressTextBox"
        Me.EmailAddressTextBox.Size = New System.Drawing.Size(214, 21)
        Me.EmailAddressTextBox.TabIndex = 9
        Me.GeneralToolTip.SetToolTip(Me.EmailAddressTextBox, "The email address of your Google Docs account.")
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(18, 114)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(57, 13)
        Me.label2.TabIndex = 19
        Me.label2.Text = "Password:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(18, 86)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(39, 13)
        Me.label1.TabIndex = 18
        Me.label1.Text = "E-mail:"
        '
        'RememberPasswordCheckBox
        '
        Me.RememberPasswordCheckBox.AutoSize = True
        Me.RememberPasswordCheckBox.Location = New System.Drawing.Point(108, 141)
        Me.RememberPasswordCheckBox.Name = "RememberPasswordCheckBox"
        Me.RememberPasswordCheckBox.Size = New System.Drawing.Size(147, 17)
        Me.RememberPasswordCheckBox.TabIndex = 11
        Me.RememberPasswordCheckBox.Text = "Remember my password."
        Me.GeneralToolTip.SetToolTip(Me.RememberPasswordCheckBox, "Remember your password to skip login next time.")
        Me.RememberPasswordCheckBox.UseVisualStyleBackColor = True
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.AutoSize = True
        Me.InstructionsLabel.BackColor = System.Drawing.Color.White
        Me.InstructionsLabel.Location = New System.Drawing.Point(12, 34)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Size = New System.Drawing.Size(237, 13)
        Me.InstructionsLabel.TabIndex = 25
        Me.InstructionsLabel.Text = "Enter your login for Google Docs / Google Drive."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Welcome to gExplore"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(337, 63)
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'SecurityLinkLabel
        '
        Me.SecurityLinkLabel.AutoSize = True
        Me.SecurityLinkLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.SecurityLinkLabel.Location = New System.Drawing.Point(252, 142)
        Me.SecurityLinkLabel.Name = "SecurityLinkLabel"
        Me.SecurityLinkLabel.Size = New System.Drawing.Size(65, 13)
        Me.SecurityLinkLabel.TabIndex = 12
        Me.SecurityLinkLabel.TabStop = True
        Me.SecurityLinkLabel.Text = "Is this safe?"
        '
        'CredentialsSecurityToolTip
        '
        Me.CredentialsSecurityToolTip.AutomaticDelay = 0
        Me.CredentialsSecurityToolTip.AutoPopDelay = 0
        Me.CredentialsSecurityToolTip.InitialDelay = 0
        Me.CredentialsSecurityToolTip.ReshowDelay = 0
        Me.CredentialsSecurityToolTip.ShowAlways = True
        Me.CredentialsSecurityToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.CredentialsSecurityToolTip.ToolTipTitle = "Security of Credentials"
        '
        'GeneralToolTip
        '
        Me.GeneralToolTip.IsBalloon = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(277, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'ProxyButton
        '
        Me.ProxyButton.Location = New System.Drawing.Point(12, 210)
        Me.ProxyButton.Name = "ProxyButton"
        Me.ProxyButton.Size = New System.Drawing.Size(75, 23)
        Me.ProxyButton.TabIndex = 32
        Me.ProxyButton.Text = "Proxy..."
        Me.ProxyButton.UseVisualStyleBackColor = True
        '
        'Credentials
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(337, 248)
        Me.Controls.Add(Me.ProxyButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SecurityLinkLabel)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.RememberPasswordCheckBox)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.EmailAddressTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Credentials"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gExplore"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Private WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Private WithEvents EmailAddressTextBox As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents RememberPasswordCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents InstructionsLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents SecurityLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents CredentialsSecurityToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents GeneralToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ProxyButton As System.Windows.Forms.Button

End Class
