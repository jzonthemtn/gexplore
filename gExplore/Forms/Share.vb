Imports Google.Documents
Imports Google.GData.AccessControl
Imports Google.GData.Client

Public Class Share

    Private p_Document As Document
    Private p_gd As gExplore.GoogleDocs
    Private p_SharingFile As Boolean

    Public Sub New(gd As gExplore.GoogleDocs, doc As Document, Optional SharingFile As Boolean = True)

        InitializeComponent()

        p_gd = gd
        p_Document = doc
        p_SharingFile = SharingFile

        If p_SharingFile = True Then

            Me.Text = "Share File"
            InstructionsLabel.Text = "Share a file with another user."
            ViewRadioButton.Text = "User can only view the file."
            EditRadioButton.Text = "User can view and edit the file."

        Else

            Me.Text = "Share Collection"
            InstructionsLabel.Text = "Share a collection with another user."
            ViewRadioButton.Text = "User can only view the collection."
            EditRadioButton.Text = "User can view and edit the collection."

        End If

    End Sub

    Private Sub FileMetaData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CurrentNameTextBox.Text = p_Document.DocumentEntry.Title.Text
        UsersEmailTextBox.Select()

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click

        ' Check for valid email.
        If gExplore.Miscellaneous.ValidateEmail(UsersEmailTextBox.Text) = True Then

            Me.Cursor = Cursors.WaitCursor

            Try

                Dim aclentry As New Google.GData.AccessControl.AclEntry
                aclentry.Scope = New AclScope
                aclentry.Scope.Type = AclScope.SCOPE_USER
                aclentry.Scope.Value = UsersEmailTextBox.Text

                Dim role As AclRole

                If ViewRadioButton.Checked = True Then
                    role = New AclRole("reader")
                Else
                    role = New AclRole("writer")
                End If

                aclentry.Role = role

                Dim newAcl As AtomEntry = p_gd.Service.Insert(p_Document.AccessControlList, aclentry)

                Me.Cursor = Cursors.Default

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception

                Me.Cursor = Cursors.Default

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("Error while sharing: " & ex.Message, MsgBoxStyle.Critical)

            End Try

        Else

            MsgBox("A valid email address is required.", MsgBoxStyle.Critical)

        End If

    End Sub

End Class