Imports System.IO

Namespace gExplore

    Public Class Logging

        ''' <summary>
        ''' Return the location of the application's data directory. (Makes the directory if it does not exist.)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetUserDataPath() As String

            Dim ApplicationDataDirectory As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "gExplore")

            If Directory.Exists(ApplicationDataDirectory) = False Then
                Directory.CreateDirectory(ApplicationDataDirectory)
            End If

            Return ApplicationDataDirectory

        End Function

        ''' <summary>
        ''' Return the location of the application's log file.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetLogFileName() As String

            Dim LogFileName As String = Path.Combine(GetUserDataPath, "gexplorelog.txt")

            If File.Exists(LogFileName) = False Then
                My.Computer.FileSystem.WriteAllText(LogFileName, Now.ToString & " - " & "Log created." & vbNewLine, True)
            End If

            Return LogFileName

        End Function

        ''' <summary>
        '''  Write text to the application log.
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <remarks></remarks>
        Public Shared Sub WriteToApplicationLog(Text As String)

            My.Computer.FileSystem.WriteAllText(GetLogFileName(), Now.ToString & " - " & Text & vbNewLine, True)

        End Sub

        ''' <summary>
        ''' Write an error to the application log.
        ''' </summary>
        ''' <param name="Ex">The thrown exception.</param>
        ''' <remarks></remarks>
        Public Shared Sub WriteErrorToApplicationLog(Ex As Exception)

            Dim Text As String = Now.ToString & " - " & Ex.ToString & vbNewLine

            My.Computer.FileSystem.WriteAllText(GetLogFileName, Text, True)

        End Sub

    End Class

End Namespace