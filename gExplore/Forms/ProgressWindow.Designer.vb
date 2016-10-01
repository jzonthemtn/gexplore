<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressWindow))
        Me.StatusProgressBar = New System.Windows.Forms.ProgressBar()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.PercentageCompleteLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'StatusProgressBar
        '
        Me.StatusProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusProgressBar.Location = New System.Drawing.Point(23, 47)
        Me.StatusProgressBar.Name = "StatusProgressBar"
        Me.StatusProgressBar.Size = New System.Drawing.Size(284, 23)
        Me.StatusProgressBar.TabIndex = 0
        '
        'StatusLabel
        '
        Me.StatusLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusLabel.AutoEllipsis = True
        Me.StatusLabel.Location = New System.Drawing.Point(20, 22)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(287, 13)
        Me.StatusLabel.TabIndex = 1
        Me.StatusLabel.Text = "Starting..."
        '
        'PercentageCompleteLabel
        '
        Me.PercentageCompleteLabel.AutoSize = True
        Me.PercentageCompleteLabel.Location = New System.Drawing.Point(20, 83)
        Me.PercentageCompleteLabel.Name = "PercentageCompleteLabel"
        Me.PercentageCompleteLabel.Size = New System.Drawing.Size(24, 13)
        Me.PercentageCompleteLabel.TabIndex = 2
        Me.PercentageCompleteLabel.Text = "0%"
        '
        'ProgressWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 114)
        Me.Controls.Add(Me.PercentageCompleteLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.StatusProgressBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(350, 152)
        Me.Name = "ProgressWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents PercentageCompleteLabel As System.Windows.Forms.Label
End Class
