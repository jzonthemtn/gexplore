Imports Google.Documents
Imports Google.GData.Documents
Imports Google.GData.Client

Public Class NewCollection

    Private p_ParentCollection As Document
    Private p_gd As gExplore.GoogleDocs
    Private p_NewCollectionResourceID As String
    Private p_NewCollectionName As String

    Public Sub New(gd As gExplore.GoogleDocs, ParentCollection As Document)

        InitializeComponent()

        p_gd = gd
        p_ParentCollection = ParentCollection

    End Sub

    Public ReadOnly Property GetNewCollectionResourceID As String
        Get
            Return p_NewCollectionResourceID
        End Get
    End Property

    Public ReadOnly Property GetDocument As Document
        Get
            Return p_ParentCollection
        End Get
    End Property

    Public ReadOnly Property GetNewCollectionName As String
        Get
            Return p_NewCollectionName
        End Get
    End Property

    Private Sub FileMetaData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        NewCollectionNameTextBox.Select()

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click

        If NewCollectionNameTextBox.TextLength > 0 Then

            Me.Cursor = Cursors.WaitCursor

            Try

                p_NewCollectionName = NewCollectionNameTextBox.Text

                p_NewCollectionResourceID = p_gd.CreateCollection(p_ParentCollection, NewCollectionNameTextBox.Text)

                Me.Cursor = Cursors.Default

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception

                Me.Cursor = Cursors.Default

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("An error occurred while creating the new collection. If this is a shared collection make sure you have write permissions to it.", MsgBoxStyle.Critical)

            End Try

        Else

            MsgBox("A name for the collection is required.", MsgBoxStyle.Critical)

        End If

    End Sub

End Class