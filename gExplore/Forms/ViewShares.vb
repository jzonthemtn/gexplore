Imports Google.Documents
Imports Google.GData.AccessControl
Imports Google.GData.Client

Public Class ViewShares

    Private p_Document As Document
    Private p_gd As gExplore.GoogleDocs
    Private p_IsFile As Boolean

    Public Sub New(gd As gExplore.GoogleDocs, doc As Document, Optional IsFile As Boolean = True)

        InitializeComponent()

        p_gd = gd
        p_Document = doc
        p_IsFile = IsFile

    End Sub

    Private Sub ViewShares_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CurrentNameTextBox.Text = p_Document.DocumentEntry.Title.Text

        If p_IsFile = True Then

            InstructionsLabel.Text = "View how this file is shared."
            WhatLabel.Text = "File:"

        Else

            InstructionsLabel.Text = "View how this collection is shared."
            WhatLabel.Text = "Collection:"

        End If

        LoadShares()

    End Sub

    ''' <summary>
    ''' Get the ACL for the document.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadShares()

        SharesListView.Items.Clear()

        Me.Cursor = Cursors.WaitCursor

        Dim DocumentUri As New Uri("https://docs.google.com/feeds/default/private/full/" & p_Document.ResourceId & "/acl")

        Dim feed As AclFeed = p_gd.Service.Query(New AclQuery(DocumentUri.ToString))

        For Each acl As AclEntry In feed.Entries

            Dim lvi As New ListViewItem(acl.Scope.Value)
            lvi.SubItems.Add(acl.Role.Value)
            lvi.Tag = acl

            SharesListView.Items.Add(lvi)

        Next

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub RefreshButton_Click_1(sender As System.Object, e As System.EventArgs) Handles RefreshButton.Click

        LoadShares()

    End Sub

    Private Sub RemovePermissionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemovePermissionToolStripMenuItem.Click

        If SharesListView.SelectedItems.Count > 0 Then

            If MsgBox("Are you sure you want to delete the selected permissions?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For Each lvi As ListViewItem In SharesListView.SelectedItems

                    Try

                        ' Delete the entry.
                        Dim acl As AclEntry = TryCast(lvi.Tag, AclEntry)
                        acl.Delete()

                        ' Remove it from the listview.
                        lvi.Remove()

                    Catch ex As GDataRequestException

                        gExplore.Logging.WriteErrorToApplicationLog(ex)
                        MsgBox("An error occurred while removing the permission: " & ex.ResponseString, MsgBoxStyle.Critical)

                    End Try

                Next

            End If

        End If

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        If SharesListView.SelectedItems.Count > 0 Then

            RemovePermissionToolStripMenuItem.Enabled = True

        Else

            RemovePermissionToolStripMenuItem.Enabled = False

        End If

    End Sub

    Private Sub AddPermissionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddPermissionToolStripMenuItem.Click

        Dim s As New Share(p_gd, p_Document, p_IsFile)

        If s.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' If they clicked Ok refresh the list.
            LoadShares()

        End If

        ' Clean up.
        s.Dispose()

    End Sub

End Class