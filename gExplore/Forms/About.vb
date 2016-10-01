Imports System.Windows.Forms

Public Class About

    Private Sub OkButton_Click(sender As System.Object, e As System.EventArgs) Handles OkButton.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub About_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        VersionLabel.Text = Application.ProductName & " " & Application.ProductVersion

    End Sub

    Private Sub WebsiteLinkLabel_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles WebsiteLinkLabel.LinkClicked

        System.Diagnostics.Process.Start("https://www.github.com/jzonthemtn/gexplore")

    End Sub

End Class
