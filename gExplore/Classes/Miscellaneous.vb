Imports System.Text.RegularExpressions

Namespace gExplore

    Public Class Miscellaneous

        ''' <summary>
        ''' Sanitize a file name by removing illegal characters.
        ''' </summary>
        ''' <param name="FileName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function SanitizeFileName(FileName As String) As String

            ' Remove illegal characters.
            Dim rgPattern = "[\\\/:\*\?""'<>|\""]"

            Dim objRegEx As New Regex(rgPattern)

            Dim output As String = objRegEx.Replace(FileName, String.Empty)

            ' Remove non-printable (i.e. control) characters.
            Dim reg2 As New Regex("[\x00-\x1f]")
            output = reg2.Replace(output, String.Empty)

            Return output

        End Function

        ''' <summary>
        ''' Check if an email address is syncatically correct.
        ''' </summary>
        ''' <param name="Email"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ValidateEmail(ByVal Email As String) As Boolean

            Dim strRegex As String = "^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            Dim re As New Regex(strRegex)
            If re.IsMatch(Email) Then
                Return (True)
            Else
                Return (False)
            End If

        End Function

    End Class

End Namespace
