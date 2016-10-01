Imports NConsoler
Imports System.Net
Imports Google.GData.Client
Imports Google.Documents
Imports System.IO

Namespace gExplore

    Public Class CommandLineActions

        Private Shared p_gd As gExplore.GoogleDocs

        <Action()>
        Public Shared Sub Upload(<Required(Description:="The full path to the local file to upload. (Paths with spaces must be enclosed with quotes).")> LocalFile As String, <Required(Description:="The name of the level collection to store the file.")> Collection As String)

            ' Upload the file.
            UploadFile(LocalFile, Collection, False, String.Empty)

        End Sub

        <Action()>
        Public Shared Sub EncryptAndUpload(<Required(Description:="The full path to the local file to upload. (Paths with spaces must be enclosed with quotes).")> LocalFile As String, <Required(Description:="The password to use to encrypt the file.")> EncryptionPassword As String, <Required(Description:="The full name of the collection to store the file.")> Collection As String)

            ' Encrypt and then upload the file.
            UploadFile(LocalFile, Collection, True, EncryptionPassword)

        End Sub

        <Action()>
        Public Shared Sub Decrypt(<Required(Description:="The full path to the local file to decrypt. (Paths with spaces must be enclosed with quotes).")> EncryptedFile As String, <Required(Description:="The password to use to decrypt the file.")> EncryptionPassword As String)

            ' Make sure the input file exists.
            If File.Exists(EncryptedFile) = True Then

                Dim DecryptedFileName As String = EncryptedFile.Replace(".enc", String.Empty)

                ' Decrypt the file to the same directory.
                If gExplore.AESFileEncryption.EncryptOrDecryptFile(EncryptedFile, DecryptedFileName, EncryptionPassword, AESFileEncryption.CryptoAction.ActionDecrypt) = True Then

                    Console.WriteLine("The file has been decrypted to " & DecryptedFileName & ".")

                Else

                    Console.WriteLine("The file could not be decrypted. Make sure the file was encrypted by gExplore and the password is correct.")

                End If

            Else

                Console.WriteLine("The file " & EncryptedFile & " does not exist.")

            End If

        End Sub

        <Action()>
        Public Shared Sub Download(<Required(Description:="The name of the file to download.")> FileName As String, <Required(Description:="The full path of where to save the downloaded file (ex. c:\file.doc).")> LocalFile As String, <Required(Description:="The name of the containing collection on Google Drive.")> SourceCollection As String)

            Try

                ' See if we are to use a proxy server.
                If gExplore.SettingsHandler.UseProxy = True Then

                    ' Set the proxy settings.
                    Dim myproxy As New WebProxy(gExplore.SettingsHandler.ProxyServer, gExplore.SettingsHandler.ProxyPort)

                    If gExplore.SettingsHandler.ProxyServerAuth = True Then

                        Dim ProxyUserName As String = gExplore.SettingsHandler.ProxyServerUserName
                        Dim ProxyPassword As String = gExplore.SettingsHandler.ProxyServerPassword
                        myproxy.Credentials = New NetworkCredential(ProxyUserName, ProxyPassword)

                    End If

                    ' Set the proxy with the service.
                    p_gd = New gExplore.GoogleDocs(gExplore.SettingsHandler.GoogleLogin, gExplore.SettingsHandler.GooglePassword, myproxy)

                Else

                    ' No proxy. Just make the service.
                    p_gd = New gExplore.GoogleDocs(gExplore.SettingsHandler.GoogleLogin, gExplore.SettingsHandler.GooglePassword)

                End If

                ' Set up the request object.
                If IsNothing(p_gd.Request) = True Then
                    p_gd.Request = New DocumentsRequest(p_gd.GetRequestSettings())
                    p_gd.Request.Proxy = p_gd.ProxyServer
                End If

                ' Get the collection.
                Dim Collection As Document = GetCollection(SourceCollection)

                If Collection Is Nothing Then

                    Console.WriteLine("The collection " & SourceCollection & " was not found in Google Drive.")

                Else

                    ' Get the file to download.
                    Dim DocToDownload As Document = GetDocument(FileName, Collection)

                    If IsNothing(DocToDownload) = False Then

                        Console.WriteLine("Beginning download of " & FileName & "...")

                        ' Do the download.
                        p_gd.DownloadFile(DocToDownload, LocalFile)

                        If File.Exists(LocalFile) = True Then

                            Console.WriteLine("The file " & FileName & " has been download to " & LocalFile & ".")

                        End If

                    Else

                        Console.WriteLine("The file " & FileName & " was not found on Google Drive.")

                    End If

                    End If

            Catch ex As Exception

                ' Something went wrong.
                Console.WriteLine("The file could not be downloaded: " & ex.Message)

            End Try

        End Sub

        ''' <summary>
        ''' Upload a file, and optionally encrypt prior to uploading.
        ''' </summary>
        ''' <param name="LocalFile"></param>
        ''' <param name="Encrypt"></param>
        ''' <param name="EncryptionPassword"></param>
        ''' <remarks></remarks>
        Private Shared Sub UploadFile(LocalFile As String, DestinationCollection As String, Encrypt As Boolean, EncryptionPassword As String)

            ' Make sure file1 exists locally.
            If File.Exists(LocalFile) = True Then

                Try

                    ' See if we are to use a proxy server.
                    If gExplore.SettingsHandler.UseProxy = True Then

                        ' Set the proxy settings.
                        Dim myproxy As New WebProxy(gExplore.SettingsHandler.ProxyServer, gExplore.SettingsHandler.ProxyPort)

                        If gExplore.SettingsHandler.ProxyServerAuth = True Then

                            Dim ProxyUserName As String = gExplore.SettingsHandler.ProxyServerUserName
                            Dim ProxyPassword As String = gExplore.SettingsHandler.ProxyServerPassword
                            myproxy.Credentials = New NetworkCredential(ProxyUserName, ProxyPassword)

                        End If

                        ' Set the proxy with the service.
                        p_gd = New gExplore.GoogleDocs(gExplore.SettingsHandler.GoogleLogin, gExplore.SettingsHandler.GooglePassword, myproxy)

                    Else

                        ' No proxy. Just make the service.
                        p_gd = New gExplore.GoogleDocs(gExplore.SettingsHandler.GoogleLogin, gExplore.SettingsHandler.GooglePassword)

                    End If

                    ' Set up the request object.
                    If IsNothing(p_gd.Request) = True Then
                        p_gd.Request = New DocumentsRequest(p_gd.GetRequestSettings())
                        p_gd.Request.Proxy = p_gd.ProxyServer
                    End If

                    ' Get the root collection.
                    Dim Collection As Document = GetCollection(DestinationCollection)

                    If Collection Is Nothing Then

                        Console.WriteLine("The collection " & DestinationCollection & " was not found in Google Drive.")

                    Else

                        ' Encrypt the file?
                        If Encrypt = True Then

                            Dim TempFileName As String = Path.Combine(Path.GetTempPath, Path.GetFileName(LocalFile) & ".enc")

                            Console.WriteLine("Encrypting " & LocalFile & "...")

                            If gExplore.AESFileEncryption.EncryptOrDecryptFile(LocalFile, TempFileName, EncryptionPassword, AESFileEncryption.CryptoAction.ActionEncrypt) = False Then

                                ' Unable to encrypt.
                                Console.WriteLine("Unable to encrypt " & LocalFile & ".")

                            Else

                                Console.WriteLine("Beginning upload of " & LocalFile & "...")

                                ' Do the upload.
                                p_gd.UploadFile(LocalFile, Collection, New Object, AddressOf OnDone, AddressOf OnProgress, False)

                                Console.WriteLine("The file " & LocalFile & " has been encrypted and uploaded to Google Docs.")

                            End If

                        Else

                            Console.WriteLine("Beginning upload of " & LocalFile & "...")

                            ' Do the upload.
                            p_gd.UploadFile(LocalFile, Collection, New Object, AddressOf OnDone, AddressOf OnProgress, False)

                            Console.WriteLine("The file " & LocalFile & " has been uploaded to Google Docs.")

                        End If

                    End If

                Catch ex As Exception

                    ' Something went wrong.
                    Console.WriteLine("The file could not be uploaded: " & ex.Message)

                End Try

            Else

                Console.WriteLine("The file " & LocalFile & " does not exist.")

            End If

        End Sub

        ''' <summary>
        ''' Find the file in the root that we want to download (first occurrence).
        ''' </summary>
        ''' <param name="FileName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetDocument(FileName As String, Collection As Document) As Document

            Dim d As Document = Nothing

            Dim feed As Feed(Of Document) = p_gd.Request.GetFolderContent(Collection)

            For Each doc As Document In feed.Entries

                If doc.Title.ToLower = FileName.ToLower Then

                    Return doc

                End If

            Next

            Return Nothing

        End Function

        ''' <summary>
        ''' Get the root collection for the account.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetCollection(CollectionName As String) As Document

            Dim f As Feed(Of Document) = p_gd.Request.GetFolders()

            For Each d As Document In f.Entries

                If d.Title.ToLower = CollectionName.ToLower Then

                    Return d

                End If

            Next

            Return Nothing

        End Function

        ''' <summary>
        ''' Get the destination collection given the string path from the command line.
        ''' </summary>
        ''' <param name="CollectionTextPath"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Private Shared Function GetCollection(CollectionTextPath As String) As Document

        '    ' Need a trailing slash.
        '    If CollectionTextPath.EndsWith("\") = False Then
        '        CollectionTextPath = CollectionTextPath & "\"
        '    End If

        '    ' Split up the collections by the slash.
        '    Dim CollectionPath As String() = CollectionTextPath.Split("\")

        '    ' What we'll be returning. Nothing if not found.
        '    Dim Collection As Document = Nothing

        '    ' For each string in CollectionPath, find the collection we're looking for.
        '    Dim feed As Feed(Of Document) = p_gd.Request.GetFolders()

        '    For Each d As Document In feed.Entries

        '        For Each s As String In d.ParentFolders
        '            Console.Write(s & "\")
        '        Next
        '        Console.WriteLine()

        '        d.

        '        'If d.Title = CollectionPath(0) Then

        '        '    ' We found the first one! Do we need to continue? (Is there more to their path?)
        '        '    If CountSlashes(CollectionTextPath) > 1 Then

        '        '        ' Yes, we need to continue.

        '        '    Else

        '        '        ' Nope, we are done. Return it.
        '        '        Collection = d
        '        '        Exit For

        '        '    End If

        '        'End If

        '    Next

        '    Return Collection

        'End Function

        ''' <summary>
        ''' Count the number of backslashes in a string.
        ''' </summary>
        ''' <param name="Input"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Private Shared Function CountSlashes(ByVal Input As String) As Integer

        '    Dim Count As Integer = 0

        '    For i As Integer = 0 To Input.Length - 1
        '        If Input.Substring(i, 1) = "\" Then
        '            Count = Count + 1
        '        End If
        '    Next

        '    Return Count

        'End Function

        Private Shared Sub OnDone(sender As Object, args As AsyncOperationCompletedEventArgs)

            If IsNothing(args.Error) = False Then

                Console.WriteLine("The file could not be uploaded: " & args.Error.Message)

            Else

                Console.WriteLine("The file has been uploaded to Google Docs.")

            End If

        End Sub

        Private Shared Sub OnProgress(sender As Object, args As AsyncOperationProgressEventArgs)

            Console.WriteLine(args.ProgressPercentage.ToString & "%")

        End Sub

    End Class

End Namespace
