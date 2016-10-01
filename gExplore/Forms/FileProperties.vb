Imports System.Windows.Forms
Imports Google.Documents

Public Class FileProperties

    Private p_Doc As Document

    Public Sub New(Doc As Document)

        InitializeComponent()

        p_Doc = Doc

    End Sub

    Private Sub OkButton_Click(sender As System.Object, e As System.EventArgs) Handles OkButton.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub FileProperties_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        propertyGrid1.SelectedObject = p_Doc

    End Sub

End Class
