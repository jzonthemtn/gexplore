<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSizeAudit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileSizeAudit))
        Me.AuditChildrenCheckBox = New System.Windows.Forms.CheckBox()
        Me.AuditFileNameButton = New System.Windows.Forms.Button()
        Me.AuditFileNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.InstructionsLabel = New System.Windows.Forms.Label()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BrowseToFolderButton = New System.Windows.Forms.Button()
        Me.CollectionTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ExcludeZeroCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AuditChildrenCheckBox
        '
        Me.AuditChildrenCheckBox.AutoSize = True
        Me.AuditChildrenCheckBox.Location = New System.Drawing.Point(132, 152)
        Me.AuditChildrenCheckBox.Name = "AuditChildrenCheckBox"
        Me.AuditChildrenCheckBox.Size = New System.Drawing.Size(141, 17)
        Me.AuditChildrenCheckBox.TabIndex = 55
        Me.AuditChildrenCheckBox.Text = "Include child collections."
        Me.AuditChildrenCheckBox.UseVisualStyleBackColor = True
        '
        'AuditFileNameButton
        '
        Me.AuditFileNameButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AuditFileNameButton.Location = New System.Drawing.Point(332, 96)
        Me.AuditFileNameButton.Name = "AuditFileNameButton"
        Me.AuditFileNameButton.Size = New System.Drawing.Size(75, 23)
        Me.AuditFileNameButton.TabIndex = 54
        Me.AuditFileNameButton.Text = "Browse..."
        Me.AuditFileNameButton.UseVisualStyleBackColor = True
        '
        'AuditFileNameTextBox
        '
        Me.AuditFileNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AuditFileNameTextBox.Location = New System.Drawing.Point(132, 98)
        Me.AuditFileNameTextBox.Name = "AuditFileNameTextBox"
        Me.AuditFileNameTextBox.ReadOnly = True
        Me.AuditFileNameTextBox.Size = New System.Drawing.Size(194, 21)
        Me.AuditFileNameTextBox.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Save Audit To:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(359, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 51
        Me.PictureBox1.TabStop = False
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstructionsLabel.AutoEllipsis = True
        Me.InstructionsLabel.AutoSize = True
        Me.InstructionsLabel.BackColor = System.Drawing.Color.White
        Me.InstructionsLabel.Location = New System.Drawing.Point(12, 34)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Size = New System.Drawing.Size(188, 13)
        Me.InstructionsLabel.TabIndex = 50
        Me.InstructionsLabel.Text = "Find files using the most quota space."
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
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Audit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "File Size Audit"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(429, 63)
        Me.PictureBox2.TabIndex = 48
        Me.PictureBox2.TabStop = False
        '
        'BrowseToFolderButton
        '
        Me.BrowseToFolderButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowseToFolderButton.Location = New System.Drawing.Point(332, 123)
        Me.BrowseToFolderButton.Name = "BrowseToFolderButton"
        Me.BrowseToFolderButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseToFolderButton.TabIndex = 47
        Me.BrowseToFolderButton.Text = "Browse..."
        Me.BrowseToFolderButton.UseVisualStyleBackColor = True
        '
        'CollectionTextBox
        '
        Me.CollectionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CollectionTextBox.Location = New System.Drawing.Point(132, 125)
        Me.CollectionTextBox.Name = "CollectionTextBox"
        Me.CollectionTextBox.ReadOnly = True
        Me.CollectionTextBox.Size = New System.Drawing.Size(194, 21)
        Me.CollectionTextBox.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Collection to Audit:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(261, 227)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 44
        '
        'ExcludeZeroCheckBox
        '
        Me.ExcludeZeroCheckBox.AutoSize = True
        Me.ExcludeZeroCheckBox.Location = New System.Drawing.Point(132, 175)
        Me.ExcludeZeroCheckBox.Name = "ExcludeZeroCheckBox"
        Me.ExcludeZeroCheckBox.Size = New System.Drawing.Size(203, 17)
        Me.ExcludeZeroCheckBox.TabIndex = 56
        Me.ExcludeZeroCheckBox.Text = "Exclude files that use 0 quota space."
        Me.ExcludeZeroCheckBox.UseVisualStyleBackColor = True
        '
        'FileSizeAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 267)
        Me.Controls.Add(Me.ExcludeZeroCheckBox)
        Me.Controls.Add(Me.AuditChildrenCheckBox)
        Me.Controls.Add(Me.AuditFileNameButton)
        Me.Controls.Add(Me.AuditFileNameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.BrowseToFolderButton)
        Me.Controls.Add(Me.CollectionTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FileSizeAudit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "File Size Audit"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AuditChildrenCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AuditFileNameButton As System.Windows.Forms.Button
    Friend WithEvents AuditFileNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents InstructionsLabel As System.Windows.Forms.Label
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BrowseToFolderButton As System.Windows.Forms.Button
    Friend WithEvents CollectionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ExcludeZeroCheckBox As System.Windows.Forms.CheckBox

End Class
