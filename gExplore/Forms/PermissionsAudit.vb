Imports System.Windows.Forms
Imports System.IO
Imports Google.GData.Client
Imports Google.GData.Client.ResumableUpload
Imports Google.Documents
Imports Google.GData.Documents
Imports Google.GData.AccessControl

Public Class PermissionsAudit

    Private p_gd As gExplore.GoogleDocs
    Private p_ParentCollections As List(Of Document)

    Public Sub New(gdocs As gExplore.GoogleDocs)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_gd = gdocs

    End Sub

    ''' <summary>
    ''' Audit the permissions of the collection, writing the output to the stream.
    ''' </summary>
    ''' <param name="sw"></param>
    ''' <param name="collection"></param>
    ''' <remarks></remarks>
    Private Sub AuditCollectionContents(sw As StreamWriter, collection As Document)

        Dim FoldersRequest As New DocumentsRequest(p_gd.GetRequestSettings())
        Dim feed As Feed(Of Document) = FoldersRequest.GetFolderContent(collection)

        For Each f As Document In feed.Entries

            Dim DocumentUri As New Uri("https://docs.google.com/feeds/default/private/full/" & f.ResourceId & "/acl")

            Dim acl_feed As AclFeed = p_gd.Service.Query(New AclQuery(DocumentUri.ToString))

            For Each acl As AclEntry In acl_feed.Entries

                ' Format the output.
                Dim ObjectACL As String = collection.Title & " :: " & f.Title & " :: " & acl.Scope.Value & " :: " & acl.Role.Value

                ' Write it to the file.
                sw.WriteLine(ObjectACL)

            Next

            ' Only descend into children if the box is checked.
            If AuditChildrenCheckBox.Checked = True Then

                If f.DocumentEntry.IsFolder = True Then

                    ' Audit the permissions of the sub-collection.
                    AuditCollectionContents(sw, f)

                End If

            End If

        Next

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If IsNothing(p_ParentCollections) = False AndAlso p_ParentCollections.Count > 0 Then

            If Directory.Exists(Path.GetDirectoryName(AuditFileNameTextBox.Text)) = True Then

                ' Get the ACLs for the object and each object under it.

                Me.Cursor = Cursors.WaitCursor

                ' Make a new writer.
                Dim sw As New StreamWriter(AuditFileNameTextBox.Text, False)

                ' Write the header.
                sw.WriteLine("Collection :: Title :: User :: Permission")

                ' Loop through the document colleciton.
                For Each d As Document In p_ParentCollections

                    ' Start the audit on the parent collection.
                    AuditCollectionContents(sw, d)

                Next

                ' Close the writer.
                sw.Close()

                Me.Cursor = Cursors.Default

                If MsgBox("The permission audit is complete. View it now?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    System.Diagnostics.Process.Start(AuditFileNameTextBox.Text)

                End If

            Else

                MsgBox("The directory " & Path.GetDirectoryName(AuditFileNameTextBox.Text) & " does not exist.", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("Select a collection to audit.", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    ''' <summary>
    ''' Update the text shown in the "To Collection" textbox based on the selected collections.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateToCollectionsText()

        ' Clear and show it.
        CollectionTextBox.Clear()

        If IsNothing(p_ParentCollections) = False Then

            If p_ParentCollections.Count > 0 Then

                For Each d As Document In p_ParentCollections
                    CollectionTextBox.Text += d.Title & "; "
                Next

            End If

        End If

    End Sub

    Private Sub Upload_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        UpdateToCollectionsText()

    End Sub

    Private Sub BrowseToFolderButton_Click(sender As System.Object, e As System.EventArgs) Handles BrowseToFolderButton.Click

        Dim bc As New BrowseCollection(p_gd, False, True)

        If bc.ShowDialog = Windows.Forms.DialogResult.OK Then

            p_ParentCollections = bc.GetSelectedCollections()
            UpdateToCollectionsText()

        End If

    End Sub

    Private Sub AuditFileNameButton_Click(sender As System.Object, e As System.EventArgs) Handles AuditFileNameButton.Click

        SaveFileDialog1.Title = "Select Audit Output File"
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        SaveFileDialog1.FilterIndex = 0
        SaveFileDialog1.FileName = String.Empty

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            AuditFileNameTextBox.Text = SaveFileDialog1.FileName

        End If

    End Sub

End Class
