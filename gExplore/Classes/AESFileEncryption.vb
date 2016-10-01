Imports System.IO
Imports System.Security.Cryptography

Namespace gExplore

    Public Class AESFileEncryption

        Private Shared p_Progress As Integer

        Public Shared ReadOnly Property Progress As Integer
            Get
                Return p_Progress
            End Get
        End Property

        Public Enum CryptoAction
            ActionEncrypt = 1
            ActionDecrypt = 2
        End Enum

        Private Shared Function CreateKey(ByVal strPassword As String) As Byte()

            'Convert strPassword to an array and store in chrData.
            Dim chrData() As Char = strPassword.ToCharArray

            'Use intLength to get strPassword size.
            Dim intLength As Integer = chrData.GetUpperBound(0)

            'Declare bytDataToHash and make it the same size as chrData.
            Dim bytDataToHash(intLength) As Byte

            'Use For Next to convert and store chrData into bytDataToHash.
            For i As Integer = 0 To chrData.GetUpperBound(0)
                bytDataToHash(i) = CByte(Asc(chrData(i)))
            Next

            'Declare what hash to use.
            Dim SHA512 As New System.Security.Cryptography.SHA512Managed

            'Declare bytResult, Hash bytDataToHash and store it in bytResult.
            Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)

            'Declare bytKey(31).  It will hold 256 bits.
            Dim bytKey(31) As Byte

            'Use For Next to put a specific size (256 bits) of 
            'bytResult into bytKey. The 0 To 31 will put the first 256 bits
            'of 512 bits into bytKey.
            For i As Integer = 0 To 31
                bytKey(i) = bytResult(i)
            Next

            Return bytKey 'Return the key.

        End Function

        Private Shared Function CreateIV(ByVal strPassword As String) As Byte()

            'Convert strPassword to an array and store in chrData.
            Dim chrData() As Char = strPassword.ToCharArray

            'Use intLength to get strPassword size.
            Dim intLength As Integer = chrData.GetUpperBound(0)

            'Declare bytDataToHash and make it the same size as chrData.
            Dim bytDataToHash(intLength) As Byte

            'Use For Next to convert and store chrData into bytDataToHash.
            For i As Integer = 0 To chrData.GetUpperBound(0)
                bytDataToHash(i) = CByte(Asc(chrData(i)))
            Next

            'Declare what hash to use.
            Dim SHA512 As New System.Security.Cryptography.SHA512Managed

            'Declare bytResult, Hash bytDataToHash and store it in bytResult.
            Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)

            'Declare bytIV(15).  It will hold 128 bits.
            Dim bytIV(15) As Byte

            'Use For Next to put a specific size (128 bits) of bytResult into bytIV.
            'The 0 To 30 for bytKey used the first 256 bits of the hashed password.
            'The 32 To 47 will put the next 128 bits into bytIV.

            For i As Integer = 32 To 47
                bytIV(i - 32) = bytResult(i)
            Next

            Return bytIV 'Return the IV.

        End Function

        ''' <summary>
        ''' Encrypt or decrypt a file using AES 256-bit.
        ''' </summary>
        ''' <param name="strInputFile"></param>
        ''' <param name="strOutputFile"></param>
        ''' <param name="Password"></param>
        ''' <param name="Direction"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function EncryptOrDecryptFile(ByVal strInputFile As String, ByVal strOutputFile As String, ByVal Password As String, ByVal Direction As CryptoAction) As Boolean

            Dim Result As Boolean = False

            p_Progress = 0

            Dim bytKey() As Byte = CreateKey(Password)
            Dim bytIV() As Byte = CreateIV(Password)

            Dim csCryptoStream As CryptoStream

            'Setup file streams to handle input and output.
            Dim fsInput As New FileStream(strInputFile, FileMode.Open, FileAccess.Read)
            Dim fsOutput As New System.IO.FileStream(strOutputFile, FileMode.OpenOrCreate, FileAccess.Write)

            Try 'In case of errors.

                fsOutput.SetLength(0) 'make sure fsOutput is empty

                'Declare variables for encrypt/decrypt process.
                Dim bytBuffer(4096) As Byte 'holds a block of bytes for processing
                Dim lngBytesProcessed As Long = 0 'running count of bytes processed
                Dim lngFileLength As Long = fsInput.Length 'the input file's length
                Dim intBytesInCurrentBlock As Integer 'current bytes being processed

                'Declare your CryptoServiceProvider.
                Dim cspRijndael As New System.Security.Cryptography.AesManaged

                'Setup Progress Bar
                'pbStatus.Value = 0
                'pbStatus.Maximum = 100

                'Determine if ecryption or decryption and setup CryptoStream.
                Select Case Direction

                    Case CryptoAction.ActionEncrypt
                        csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)

                    Case CryptoAction.ActionDecrypt
                        csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write)

                End Select

                'Use While to loop until all of the file is processed.
                While lngBytesProcessed < lngFileLength

                    'Read file with the input filestream.
                    intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)

                    'Write output file with the cryptostream.
                    csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)

                    'Update lngBytesProcessed
                    lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)

                    'Update Progress Bar
                    'pbStatus.Value = CInt((lngBytesProcessed / lngFileLength) * 100)
                    p_Progress = CInt((lngBytesProcessed / lngFileLength) * 100)

                End While

                csCryptoStream.Close()

                Result = True

            Catch ex As Exception

                Result = False

            Finally

                'Close FileStreams
                fsInput.Close()
                fsOutput.Close()

            End Try

            Return Result

        End Function

    End Class

End Namespace