<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateAvailable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateAvailable))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.YourVersionLabel = New System.Windows.Forms.Label()
        Me.CurrentVersionLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DownloadNewVersionLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.ReadReleaseNotesLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(245, 177)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "An update for gExplore is available:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Your Version:"
        '
        'YourVersionLabel
        '
        Me.YourVersionLabel.AutoSize = True
        Me.YourVersionLabel.Location = New System.Drawing.Point(151, 59)
        Me.YourVersionLabel.Name = "YourVersionLabel"
        Me.YourVersionLabel.Size = New System.Drawing.Size(23, 13)
        Me.YourVersionLabel.TabIndex = 3
        Me.YourVersionLabel.Text = "1.0"
        '
        'CurrentVersionLabel
        '
        Me.CurrentVersionLabel.AutoSize = True
        Me.CurrentVersionLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentVersionLabel.Location = New System.Drawing.Point(151, 84)
        Me.CurrentVersionLabel.Name = "CurrentVersionLabel"
        Me.CurrentVersionLabel.Size = New System.Drawing.Size(24, 13)
        Me.CurrentVersionLabel.TabIndex = 5
        Me.CurrentVersionLabel.Text = "1.0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Current Version:"
        '
        'DownloadNewVersionLinkLabel
        '
        Me.DownloadNewVersionLinkLabel.AutoSize = True
        Me.DownloadNewVersionLinkLabel.Location = New System.Drawing.Point(22, 113)
        Me.DownloadNewVersionLinkLabel.Name = "DownloadNewVersionLinkLabel"
        Me.DownloadNewVersionLinkLabel.Size = New System.Drawing.Size(262, 13)
        Me.DownloadNewVersionLinkLabel.TabIndex = 6
        Me.DownloadNewVersionLinkLabel.TabStop = True
        Me.DownloadNewVersionLinkLabel.Text = "Download and install the newest version of gExplore."
        '
        'ReadReleaseNotesLinkLabel
        '
        Me.ReadReleaseNotesLinkLabel.AutoSize = True
        Me.ReadReleaseNotesLinkLabel.Location = New System.Drawing.Point(22, 138)
        Me.ReadReleaseNotesLinkLabel.Name = "ReadReleaseNotesLinkLabel"
        Me.ReadReleaseNotesLinkLabel.Size = New System.Drawing.Size(123, 13)
        Me.ReadReleaseNotesLinkLabel.TabIndex = 7
        Me.ReadReleaseNotesLinkLabel.TabStop = True
        Me.ReadReleaseNotesLinkLabel.Text = "Read the release notes."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(25, 81)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'UpdateAvailable
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 212)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReadReleaseNotesLinkLabel)
        Me.Controls.Add(Me.DownloadNewVersionLinkLabel)
        Me.Controls.Add(Me.CurrentVersionLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.YourVersionLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OK_Button)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateAvailable"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gExplore Update Available"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents YourVersionLabel As System.Windows.Forms.Label
    Friend WithEvents CurrentVersionLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DownloadNewVersionLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents ReadReleaseNotesLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
