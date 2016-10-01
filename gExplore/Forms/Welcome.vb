Public Class Welcome

    Private Sub OkButton_Click(sender As System.Object, e As System.EventArgs) Handles OkButton.Click

        gExplore.SettingsHandler.FirstRun = False

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

End Class