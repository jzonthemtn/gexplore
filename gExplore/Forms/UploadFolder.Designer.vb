<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadFolder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UploadFolder))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderTextBox = New System.Windows.Forms.TextBox()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.UploadProgressBar = New System.Windows.Forms.ProgressBar()
        Me.UploadProgressLabel = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.EncryptFileCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConfirmTextBox = New System.Windows.Forms.TextBox()
        Me.BrowseToFolderButton = New System.Windows.Forms.Button()
        Me.ToFolderTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UploadSubFoldersCheckBox = New System.Windows.Forms.CheckBox()
        Me.FileFilterTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(255, 295)
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
        Me.OK_Button.Text = "Upload"
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
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Folder to Upload:"
        '
        'FolderTextBox
        '
        Me.FolderTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FolderTextBox.Location = New System.Drawing.Point(117, 18)
        Me.FolderTextBox.Name = "FolderTextBox"
        Me.FolderTextBox.Size = New System.Drawing.Size(196, 21)
        Me.FolderTextBox.TabIndex = 2
        '
        'BrowseButton
        '
        Me.BrowseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowseButton.Location = New System.Drawing.Point(319, 16)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton.TabIndex = 3
        Me.BrowseButton.Text = "Browse..."
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'UploadProgressBar
        '
        Me.UploadProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UploadProgressBar.Location = New System.Drawing.Point(24, 295)
        Me.UploadProgressBar.Name = "UploadProgressBar"
        Me.UploadProgressBar.Size = New System.Drawing.Size(144, 23)
        Me.UploadProgressBar.TabIndex = 9
        Me.UploadProgressBar.Visible = False
        '
        'UploadProgressLabel
        '
        Me.UploadProgressLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UploadProgressLabel.AutoSize = True
        Me.UploadProgressLabel.BackColor = System.Drawing.Color.Transparent
        Me.UploadProgressLabel.Location = New System.Drawing.Point(174, 298)
        Me.UploadProgressLabel.Name = "UploadProgressLabel"
        Me.UploadProgressLabel.Size = New System.Drawing.Size(24, 13)
        Me.UploadProgressLabel.TabIndex = 10
        Me.UploadProgressLabel.Text = "0%"
        Me.UploadProgressLabel.Visible = False
        '
        'StatusLabel
        '
        Me.StatusLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StatusLabel.AutoEllipsis = True
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(21, 275)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(66, 13)
        Me.StatusLabel.TabIndex = 11
        Me.StatusLabel.Text = "Uploading..."
        Me.StatusLabel.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EncryptFileCheckBox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PasswordTextBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ConfirmTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(374, 117)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'EncryptFileCheckBox
        '
        Me.EncryptFileCheckBox.AutoSize = True
        Me.EncryptFileCheckBox.Location = New System.Drawing.Point(22, 24)
        Me.EncryptFileCheckBox.Name = "EncryptFileCheckBox"
        Me.EncryptFileCheckBox.Size = New System.Drawing.Size(245, 17)
        Me.EncryptFileCheckBox.TabIndex = 4
        Me.EncryptFileCheckBox.Text = "Encrypt files before uploading to Google Docs."
        Me.EncryptFileCheckBox.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password:"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Enabled = False
        Me.PasswordTextBox.Location = New System.Drawing.Point(82, 52)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(272, 21)
        Me.PasswordTextBox.TabIndex = 6
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Confirm:"
        '
        'ConfirmTextBox
        '
        Me.ConfirmTextBox.Enabled = False
        Me.ConfirmTextBox.Location = New System.Drawing.Point(82, 79)
        Me.ConfirmTextBox.Name = "ConfirmTextBox"
        Me.ConfirmTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ConfirmTextBox.Size = New System.Drawing.Size(272, 21)
        Me.ConfirmTextBox.TabIndex = 8
        Me.ConfirmTextBox.UseSystemPasswordChar = True
        '
        'BrowseToFolderButton
        '
        Me.BrowseToFolderButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowseToFolderButton.Location = New System.Drawing.Point(319, 70)
        Me.BrowseToFolderButton.Name = "BrowseToFolderButton"
        Me.BrowseToFolderButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseToFolderButton.TabIndex = 19
        Me.BrowseToFolderButton.Text = "Browse..."
        Me.BrowseToFolderButton.UseVisualStyleBackColor = True
        '
        'ToFolderTextBox
        '
        Me.ToFolderTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToFolderTextBox.Location = New System.Drawing.Point(117, 72)
        Me.ToFolderTextBox.Name = "ToFolderTextBox"
        Me.ToFolderTextBox.ReadOnly = True
        Me.ToFolderTextBox.Size = New System.Drawing.Size(196, 21)
        Me.ToFolderTextBox.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "To Collection:"
        '
        'UploadSubFoldersCheckBox
        '
        Me.UploadSubFoldersCheckBox.AutoSize = True
        Me.UploadSubFoldersCheckBox.Checked = True
        Me.UploadSubFoldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UploadSubFoldersCheckBox.Location = New System.Drawing.Point(117, 99)
        Me.UploadSubFoldersCheckBox.Name = "UploadSubFoldersCheckBox"
        Me.UploadSubFoldersCheckBox.Size = New System.Drawing.Size(116, 17)
        Me.UploadSubFoldersCheckBox.TabIndex = 9
        Me.UploadSubFoldersCheckBox.Text = "Upload subfolders."
        Me.UploadSubFoldersCheckBox.UseVisualStyleBackColor = True
        '
        'FileFilterTextBox
        '
        Me.FileFilterTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileFilterTextBox.Location = New System.Drawing.Point(117, 45)
        Me.FileFilterTextBox.Name = "FileFilterTextBox"
        Me.FileFilterTextBox.Size = New System.Drawing.Size(196, 21)
        Me.FileFilterTextBox.TabIndex = 21
        Me.FileFilterTextBox.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "File Filter:"
        '
        'UploadFolder
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(413, 336)
        Me.Controls.Add(Me.FileFilterTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.UploadSubFoldersCheckBox)
        Me.Controls.Add(Me.BrowseToFolderButton)
        Me.Controls.Add(Me.ToFolderTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.UploadProgressLabel)
        Me.Controls.Add(Me.UploadProgressBar)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.FolderTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(419, 247)
        Me.Name = "UploadFolder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upload Folder"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BrowseButton As System.Windows.Forms.Button
    Friend WithEvents UploadProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents UploadProgressLabel As System.Windows.Forms.Label
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents EncryptFileCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ConfirmTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BrowseToFolderButton As System.Windows.Forms.Button
    Friend WithEvents ToFolderTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UploadSubFoldersCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FileFilterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
