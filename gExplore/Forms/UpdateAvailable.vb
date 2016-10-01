Imports System.Windows.Forms

Public Class UpdateAvailable

    Private p_gd As gExplore.GoogleDocs

    Public Sub New(CurrentVersion As String, gd As gExplore.GoogleDocs)

        InitializeComponent()

        p_gd = gd

        YourVersionLabel.Text = Application.ProductVersion
        CurrentVersionLabel.Text = CurrentVersion

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UpdateAvailable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class
