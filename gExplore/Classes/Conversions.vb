Namespace gExplore

    Public Class Conversions

        ''' <summary>
        ''' Convert bytes to KB.
        ''' </summary>
        ''' <param name="bytes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertBytesToKiloBytes(bytes As Long) As Decimal
            Return Convert.ToDecimal(Math.Round(bytes / 1024, 2))
        End Function

        ''' <summary>
        ''' Convert bytes to MB.
        ''' </summary>
        ''' <param name="bytes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertBytesToMegabytes(bytes As Long) As Decimal
            Return Convert.ToDecimal(Math.Round(bytes / 1024 / 1024, 2))
        End Function

        ''' <summary>
        ''' Convert bytes to GB.
        ''' </summary>
        ''' <param name="bytes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertBytesToGigabytes(bytes As Long) As Decimal
            Return Convert.ToDecimal(Math.Round(bytes / 1024 / 1024 / 1024, 2))
        End Function

        ''' <summary>
        ''' Convert bytes to one format based on the number of bytes (KB, MB, GB)
        ''' </summary>
        ''' <param name="bytes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertIntelligently(bytes As Long) As String

            If bytes < 1024 * 1024 Then
                Return ConvertBytesToKiloBytes(bytes).ToString & " KB"
            ElseIf bytes > (1024 ^ 2) And bytes < (1024 ^ 3) Then
                Return ConvertBytesToMegabytes(bytes).ToString & " MB"
            Else 'If bytes > (1024 ^ 3) And bytes < (1024 ^ 4) Then
                Return ConvertBytesToGigabytes(bytes).ToString & " GB"
            End If

        End Function

    End Class

End Namespace