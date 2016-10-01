Imports Google.Documents

Public Class Rename

    Private p_Document As Document
    Private p_gd As gExplore.GoogleDocs
    Private p_NewName As String
    Private p_RenamingFile As Boolean

    Public ReadOnly Property NewName As String
        Get
            Return p_NewName
        End Get
    End Property

    Public Sub New(gd As gExplore.GoogleDocs, doc As Document, RenamingFile As Boolean)

        InitializeComponent()

        p_gd = gd
        p_Document = doc
        p_RenamingFile = RenamingFile

    End Sub

    Public ReadOnly Property GetDocument As Document
        Get
            Return p_Document
        End Get
    End Property

    Private Sub FileMetaData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If p_RenamingFile = False Then

            Me.Text = "Rename Collection"
            TitleLabel.Text = "Rename Collection"
            InstructionsLabel.Text = "Enter new name for this collection."

        Else

            Me.Text = "Rename File"
            TitleLabel.Text = "Rename File"
            InstructionsLabel.Text = "Enter new name for this file."

        End If

        CurrentNameTextBox.Text = p_Document.DocumentEntry.Title.Text
        NewNameTextBox.Select()

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click

        If NewNameTextBox.TextLength > 0 Then

            If CurrentNameTextBox.Text <> NewNameTextBox.Text Then

                Me.Cursor = Cursors.WaitCursor

                Try

                    Try

                        p_Document.Title = NewNameTextBox.Text
                        p_Document.DocumentEntry.Update()

                        p_NewName = NewNameTextBox.Text

                        Me.Cursor = Cursors.Default

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    Catch ex As Exception

                        Me.Cursor = Cursors.Default

                        gExplore.Logging.WriteErrorToApplicationLog(ex)
                        MsgBox("An error occurred while renaming the file. Please ensure that the file still exists and your internet connection is active.", MsgBoxStyle.Critical)

                    End Try

                Catch ex As Exception

                    Me.Cursor = Cursors.Default

                    gExplore.Logging.WriteErrorToApplicationLog(ex)
                    MsgBox("Error while renaming: " & ex.Message, MsgBoxStyle.Critical)

                End Try

            Else

                    MsgBox("The names are the same.", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("A name is required.", MsgBoxStyle.Critical)

        End If

    End Sub

End Class