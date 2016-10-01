<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proxy
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProxyAddressTextBox = New System.Windows.Forms.TextBox()
        Me.AuthGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UseProxyCheckBox = New System.Windows.Forms.CheckBox()
        Me.ProxyAuthCheckBox = New System.Windows.Forms.CheckBox()
        Me.ProxyPortTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.AuthGroupBox.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(228, 291)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Proxy Address:"
        '
        'ProxyAddressTextBox
        '
        Me.ProxyAddressTextBox.Enabled = False
        Me.ProxyAddressTextBox.Location = New System.Drawing.Point(109, 60)
        Me.ProxyAddressTextBox.Name = "ProxyAddressTextBox"
        Me.ProxyAddressTextBox.Size = New System.Drawing.Size(260, 21)
        Me.ProxyAddressTextBox.TabIndex = 2
        '
        'AuthGroupBox
        '
        Me.AuthGroupBox.Controls.Add(Me.ProxyAuthCheckBox)
        Me.AuthGroupBox.Controls.Add(Me.PasswordTextBox)
        Me.AuthGroupBox.Controls.Add(Me.Label3)
        Me.AuthGroupBox.Controls.Add(Me.UserNameTextBox)
        Me.AuthGroupBox.Controls.Add(Me.Label2)
        Me.AuthGroupBox.Enabled = False
        Me.AuthGroupBox.Location = New System.Drawing.Point(25, 132)
        Me.AuthGroupBox.Name = "AuthGroupBox"
        Me.AuthGroupBox.Size = New System.Drawing.Size(344, 138)
        Me.AuthGroupBox.TabIndex = 3
        Me.AuthGroupBox.TabStop = False
        Me.AuthGroupBox.Text = "Authentication"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "User Name:"
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Enabled = False
        Me.UserNameTextBox.Location = New System.Drawing.Point(94, 55)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(228, 21)
        Me.UserNameTextBox.TabIndex = 5
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Enabled = False
        Me.PasswordTextBox.Location = New System.Drawing.Point(94, 82)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(228, 21)
        Me.PasswordTextBox.TabIndex = 7
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Password:"
        '
        'UseProxyCheckBox
        '
        Me.UseProxyCheckBox.AutoSize = True
        Me.UseProxyCheckBox.Location = New System.Drawing.Point(24, 31)
        Me.UseProxyCheckBox.Name = "UseProxyCheckBox"
        Me.UseProxyCheckBox.Size = New System.Drawing.Size(251, 17)
        Me.UseProxyCheckBox.TabIndex = 4
        Me.UseProxyCheckBox.Text = "Use a proxy server to connect to Google Docs."
        Me.UseProxyCheckBox.UseVisualStyleBackColor = True
        '
        'ProxyAuthCheckBox
        '
        Me.ProxyAuthCheckBox.AutoSize = True
        Me.ProxyAuthCheckBox.Location = New System.Drawing.Point(28, 32)
        Me.ProxyAuthCheckBox.Name = "ProxyAuthCheckBox"
        Me.ProxyAuthCheckBox.Size = New System.Drawing.Size(206, 17)
        Me.ProxyAuthCheckBox.TabIndex = 5
        Me.ProxyAuthCheckBox.Text = "Proxy server requires authentication."
        Me.ProxyAuthCheckBox.UseVisualStyleBackColor = True
        '
        'ProxyPortTextBox
        '
        Me.ProxyPortTextBox.Enabled = False
        Me.ProxyPortTextBox.Location = New System.Drawing.Point(109, 87)
        Me.ProxyPortTextBox.MaxLength = 5
        Me.ProxyPortTextBox.Name = "ProxyPortTextBox"
        Me.ProxyPortTextBox.Size = New System.Drawing.Size(109, 21)
        Me.ProxyPortTextBox.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Proxy Port:"
        '
        'Proxy
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(386, 332)
        Me.Controls.Add(Me.ProxyPortTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.UseProxyCheckBox)
        Me.Controls.Add(Me.AuthGroupBox)
        Me.Controls.Add(Me.ProxyAddressTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Proxy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proxy for gExplore"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.AuthGroupBox.ResumeLayout(False)
        Me.AuthGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProxyAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AuthGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UseProxyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ProxyAuthCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ProxyPortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
