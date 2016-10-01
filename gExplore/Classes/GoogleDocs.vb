Imports Google.GData.Documents
Imports Google.GData.Client
Imports Google.Documents
Imports Google.GData.Client.ResumableUpload
Imports System.IO
Imports System.Net

Namespace gExplore

    Public Class GoogleDocs

        ' A connection with the DocList API.
        Private p_Service As DocumentsService

        ' Request for querying.
        Private p_Request As DocumentsRequest = Nothing

        ' The user's Google credentials.
        Private p_UserName As String
        Private p_Password As String

        ' Keep track of the number of files currently being uploaded.
        Private p_CurrentUploads As Integer = 0
        Private p_MaxCurrentUploads As Integer = 2

        ' The proxy.
        Private p_Proxy As IWebProxy

        ''' <summary>
        ''' Get the proxy server to use.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ProxyServer As IWebProxy
            Get
                Return p_Proxy
            End Get
        End Property

        ''' <summary>
        ''' Get the document service.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Service As DocumentsService
            Get
                Return p_Service
            End Get
        End Property

        ''' <summary>
        ''' Get or set the documents request.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Request As DocumentsRequest
            Get
                Return p_Request
            End Get
            Set(value As DocumentsRequest)
                p_Request = value
            End Set
        End Property

        ''' <summary>
        ''' The user's Google username.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UserName As String
            Get
                Return p_UserName
            End Get
            Set(value As String)
                p_Password = value
            End Set
        End Property

        ''' <summary>
        ''' The user's Google password.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Password As String
            Get
                Return p_Password
            End Get
            Set(value As String)
                p_Password = value
            End Set
        End Property

        Public Sub New(UserName As String, Password As String, ProxyServer As IWebProxy)

            ' NOTE: This is using version 3 of the Google Docs API.

            p_Service = New DocumentsService(Application.ProductName)
            p_Proxy = ProxyServer

            CType(Service.RequestFactory, GDataRequestFactory).KeepAlive = False
            CType(Service.RequestFactory, GDataRequestFactory).UseSSL = True
            CType(Service.RequestFactory, GDataRequestFactory).Proxy = ProxyServer

            Service.RequestFactory.UseSSL = True
            Service.setUserCredentials(UserName, Password)

            p_UserName = UserName
            p_Password = Password

        End Sub

        Public Sub New(UserName As String, Password As String)

            ' NOTE: This is using version 3 of the Google Docs API.

            p_Service = New DocumentsService(Application.ProductName)

            CType(Service.RequestFactory, GDataRequestFactory).KeepAlive = False
            CType(Service.RequestFactory, GDataRequestFactory).UseSSL = True

            Service.RequestFactory.UseSSL = True
            Service.setUserCredentials(UserName, Password)

            p_UserName = UserName
            p_Password = Password

        End Sub

        Public Sub LogOut()

            p_Service = Nothing

        End Sub

        Public Function Login(UserName As String, Password As String) As Boolean

            Try

                ' force the service to authenticate
                Dim query As New DocumentsListQuery
                query.NumberToRetrieve = 1
                Service.Query(query)

                Return True

            Catch e As Exception

                LogOut()

                Return False

            End Try

        End Function

        ''' <summary>
        ''' Get the RequestSettings.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRequestSettings() As RequestSettings

            Dim credentials As New GDataCredentials(p_UserName, p_Password)

            Dim settings As New RequestSettings(Application.ProductName, credentials)

            settings.UseSSL = True
            settings.AutoPaging = True

            Return settings

        End Function

        ''' <summary>
        ''' Function to find an object given its ResourceID.
        ''' </summary>
        ''' <param name="ResourceID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FindObject(ResourceID As String) As Document

            Try

                Dim DocumentUri As New Uri("https://docs.google.com/feeds/default/private/full/" & ResourceID)

                Dim Result As Document = Nothing

                Dim documentsRequest As New DocumentsRequest(GetRequestSettings())
                Dim documentFeed As Feed(Of Document) = documentsRequest.Get(Of Google.Documents.Document)(DocumentUri)

                For Each d As Document In documentFeed.Entries

                    If d.ResourceId = ResourceID Then

                        Result = d

                        Exit For

                    End If

                Next

                Return Result

            Catch ex As GDataRequestException

                'Dim resp As HttpWebResponse = TryCast(ex.Response, HttpWebResponse)
                'resp.StatusCode = HttpStatusCode.NotFound

                Return Nothing

            End Try

        End Function

        ''' <summary>
        ''' Upload a file.
        ''' </summary>
        ''' <param name="FileName"></param>
        ''' <param name="ParentCollection"></param>
        ''' <param name="done"></param>
        ''' <param name="progress"></param>
        ''' <remarks></remarks>
        Public Sub UploadFile(FileName As String, ParentCollection As Document, ObjectTag As Object, done As AsyncOperationCompletedEventHandler, progress As AsyncOperationProgressEventHandler, UploadAsync As Boolean)

            p_CurrentUploads = p_CurrentUploads + 1

            While p_CurrentUploads > p_MaxCurrentUploads

                ' We're at our max for uploads. Do nothing until p_CurrentUploads has been decreased.
                Application.DoEvents()

            End While

            ' Chunk size in MB
            ' Important: Always choose a chunk size that is a multiple of 512 KB. The last chunk may be smaller than 512 KB.
            Dim CHUNK_SIZE As Integer = 1

            Dim cla As New ClientLoginAuthenticator(Application.ProductName, ServiceNames.Documents, UserName, Password)

            ' Set up resumable uploader and notifications
            Dim ru As New ResumableUploader(CHUNK_SIZE)

            ' Add handlers for progress.
            AddHandler ru.AsyncOperationCompleted, done
            AddHandler ru.AsyncOperationProgress, progress

            ' Get the content-type.
            'Dim ContentType As String = DocumentsService.DocumentTypes(".txt")

            ' Set metadata for our upload.
            Dim entry As New Document
            entry.Title = Path.GetFileName(FileName)
            entry.MediaSource = New MediaFileSource(FileName, "application/octet-stream")

            Dim createUploadUrl As Uri

            If IsNothing(ParentCollection) = True Then
                createUploadUrl = New Uri("https://docs.google.com/feeds/upload/create-session/default/private/full?convert=false")
            Else
                createUploadUrl = New Uri("https://docs.google.com/feeds/upload/create-session/default/private/full/" & ParentCollection.ResourceId & "/contents?convert=false")
            End If

            Dim link As New AtomLink(createUploadUrl.ToString)
            link.Rel = ResumableUploader.CreateMediaRelation

            entry.DocumentEntry.Links.Add(link)

            ' Upload the file.

            If UploadAsync = True Then
                ru.InsertAsync(cla, entry.DocumentEntry, ObjectTag)
            Else
                ru.Insert(cla, entry.DocumentEntry)
            End If

        End Sub

        ''' <summary>
        ''' Signal that a download has completed.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DecreaseCurrentDownloads()

            p_CurrentUploads = p_CurrentUploads - 1

        End Sub

        ''' <summary>
        ''' Make a new collection.
        ''' </summary>
        ''' <param name="p_ParentCollection"></param>
        ''' <param name="NewCollectionName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateCollection(p_ParentCollection As Document, NewCollectionName As String) As String

            Dim feedUri As Uri

            If IsNothing(p_ParentCollection) = False Then

                ' This will be a sub-collection.

                feedUri = New Uri(p_ParentCollection.DocumentEntry.SelfUri.ToString & "/contents")

            Else

                feedUri = New Uri("https://docs.google.com/feeds/default/private/full/?convert=false")

            End If

            ' Make the collection.
            Dim d As New DocumentEntry
            d.Title = New AtomTextConstruct(AtomTextConstructElementType.Title, NewCollectionName)
            d.Categories.Add(DocumentEntry.FOLDER_CATEGORY)

            ' Insert it and get the resource id.
            Return Service.Insert(feedUri, d).ResourceId

        End Function

        ''' <summary>
        ''' Download a document to a local file.
        ''' </summary>
        ''' <param name="d"></param>
        ''' <remarks></remarks>
        Public Function DownloadFile(d As Document, Optional DownloadFileName As String = "") As String

            Try

                'Get the export format from the document's title.
                Dim ExportFormat As String = Path.GetExtension(d.Title).Replace(".", String.Empty)

                ' Set the local file in the Windows' temp directory.
                Dim LocalFileName As String = Path.Combine(Path.GetTempPath, gExplore.Miscellaneous.SanitizeFileName(d.Title))

                ' For files with no extension, use PDF.
                If ExportFormat = String.Empty Then
                    ExportFormat = "pdf"
                    LocalFileName = LocalFileName & ".pdf"
                End If

                ' If they've provided a download file name then they've overridden the temp file.
                If DownloadFileName <> String.Empty Then
                    LocalFileName = DownloadFileName
                End If

                If IsNothing(Request) = True Then
                    Request = New DocumentsRequest(GetRequestSettings())
                    Request.Proxy = ProxyServer
                End If

                Dim DownloadStream As Stream = Request.Download(d, ExportFormat)

                ' Download the file to the file stream.
                WriteDownloadStreamToFile(DownloadStream, LocalFileName, d)

                ' Success.
                Return LocalFileName

            Catch ex As Exception

                gExplore.Logging.WriteErrorToApplicationLog(ex)
                MsgBox("An error occurred while downloading the file: " & ex.Message, MsgBoxStyle.Critical)

                Console.WriteLine("An error occurred while downloading the file: " & ex.Message)

                Return String.Empty

            End Try

        End Function

        ''' <summary>
        ''' Write a stream to a local file.
        ''' </summary>
        ''' <param name="InStream"></param>
        ''' <param name="LocalFileName"></param>
        ''' <remarks></remarks>
        Private Sub WriteDownloadStreamToFile(InStream As Stream, LocalFileName As String, d As Document)

            Dim OutStream As New FileStream(LocalFileName, FileMode.Create)

            Dim nBytes As Integer = 2048
            Dim count As Integer = 0
            Dim arr As Byte() = New Byte(nBytes - 1) {}

            ' Running total of the number of bytes downloaded.
            Dim Progress As Long = 0

            ' Set up the progress bar.
            'ToolStripProgressBar1.Minimum = 0
            'ToolStripProgressBar1.Maximum = d.QuotaBytesUsed

            Do

                count = InStream.Read(arr, 0, nBytes)
                OutStream.Write(arr, 0, count)

                Application.DoEvents()

                Progress = Progress + count

            Loop While count > 0

            OutStream.Flush()
            OutStream.Close()

            InStream.Close()

        End Sub

    End Class

End Namespace