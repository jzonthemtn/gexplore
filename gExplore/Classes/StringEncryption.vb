Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Namespace gExplore

    Class StringEncryption

        Private Shared EncryptionKey As String = "E1fd658dfz4@(*)&^@asf6A-6CBD-4655-AF19-49-dkdhfij-5B83%kqa58F63B-4D7__34E6D9F-0943-4C6C-8F5A-DA7972360C58"

        Public Shared Function EncryptString256Bit(ByVal vstrTextToBeEncrypted As String) As String

            Dim bytEncoded() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}

            Dim intRemaining As Integer
            Dim objMemoryStream As New MemoryStream()
            Dim objCryptoStream As CryptoStream



            '   **********************************************************************
            '   ******  Strip any null character from string to be encrypted    ******
            '   **********************************************************************

            vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted)

            '   **********************************************************************
            '   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
            '   **********************************************************************

            Dim bytValue() As Byte = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

            Dim intLength As Integer = EncryptionKey.Length

            '   ********************************************************************
            '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
            '   ******   If it is longer than 32 bytes it will be truncated.  ******
            '   ******   If it is shorter than 32 bytes it will be padded     ******
            '   ******   with upper-case Xs.                                  ****** 
            '   ********************************************************************

            If intLength >= 32 Then

                EncryptionKey = Strings.Left(EncryptionKey, 32)

            Else

                intLength = EncryptionKey.Length
                intRemaining = 32 - intLength
                EncryptionKey = EncryptionKey & Strings.StrDup(intRemaining, "X")

            End If

            Dim bytKey() As Byte = Encoding.ASCII.GetBytes(EncryptionKey.ToCharArray)

            Dim objAesManaged As AesManaged = New AesManaged()

            '   ***********************************************************************
            '   ******  Create the encryptor and write value to it after it is   ******
            '   ******  converted into a byte array                              ******
            '   ***********************************************************************

            Try


                objCryptoStream = New CryptoStream(objMemoryStream, objAesManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)
                objCryptoStream.Write(bytValue, 0, bytValue.Length)

                objCryptoStream.FlushFinalBlock()

                bytEncoded = objMemoryStream.ToArray
                objMemoryStream.Close()
                objCryptoStream.Close()

            Catch

            End Try

            '   ***********************************************************************
            '   ******   Return encryptes value (converted from  byte Array to   ******
            '   ******   a base64 string).  Base64 is MIME encoding)             ******
            '   ***********************************************************************

            Return Convert.ToBase64String(bytEncoded)

        End Function

        Public Shared Function IsEncrypted(ByVal vstrString As String) As Boolean

            Dim bytDataToBeDecrypted() As Byte

            Try
                bytDataToBeDecrypted = Convert.FromBase64String(vstrString)
                Return True
            Catch
                Return False
            End Try

        End Function

        Public Shared Function DecryptString256Bit(ByVal vstrStringToBeDecrypted As String) As String

            Dim bytDataToBeDecrypted() As Byte
            Dim bytTemp() As Byte
            Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
            Dim objAesManaged As New AesManaged()
            Dim objMemoryStream As MemoryStream
            Dim objCryptoStream As CryptoStream
            Dim bytDecryptionKey() As Byte

            Dim intLength As Integer
            Dim intRemaining As Integer
            Dim strReturnString As String = String.Empty

            '   *****************************************************************
            '   ******   Convert base64 encrypted value to byte array      ******
            '   *****************************************************************

            Try
                bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)
            Catch
                Return vstrStringToBeDecrypted
            End Try

            '   ********************************************************************
            '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
            '   ******   If it is longer than 32 bytes it will be truncated.  ******
            '   ******   If it is shorter than 32 bytes it will be padded     ******
            '   ******   with upper-case Xs.                                  ****** 
            '   ********************************************************************

            intLength = Len(EncryptionKey)

            If intLength >= 32 Then
                EncryptionKey = Strings.Left(EncryptionKey, 32)
            Else
                intLength = Len(EncryptionKey)
                intRemaining = 32 - intLength
                EncryptionKey = EncryptionKey & Strings.StrDup(intRemaining, "X")
            End If

            bytDecryptionKey = Encoding.ASCII.GetBytes(EncryptionKey.ToCharArray)

            ReDim bytTemp(bytDataToBeDecrypted.Length)

            objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

            '   ***********************************************************************
            '   ******  Create the decryptor and write value to it after it is   ******
            '   ******  converted into a byte array                              ******
            '   ***********************************************************************

            Try

                objCryptoStream = New CryptoStream(objMemoryStream, _
                   objAesManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
                   CryptoStreamMode.Read)

                objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

                objCryptoStream.FlushFinalBlock()
                objMemoryStream.Close()
                objCryptoStream.Close()

            Catch

            End Try

            '   *****************************************
            '   ******   Return decypted value     ******
            '   *****************************************

            Return StripNullCharacters(Encoding.ASCII.GetString(bytTemp))

        End Function

        Public Shared Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String

            Dim intPosition As Integer
            Dim strStringWithOutNulls As String

            intPosition = 1
            strStringWithOutNulls = vstrStringWithNulls

            Do While intPosition > 0
                intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

                If intPosition > 0 Then
                    strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                      Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
                End If

                If intPosition > strStringWithOutNulls.Length Then
                    Exit Do
                End If
            Loop

            Return strStringWithOutNulls

        End Function

        Public Shared Function ByteArrayToString(ByVal arrInput() As Byte) As String

            Dim i As Integer
            Dim sOutput As New StringBuilder(arrInput.Length)
            For i = 0 To arrInput.Length - 1
                sOutput.Append(arrInput(i).ToString("X2"))
            Next
            Return sOutput.ToString()

        End Function

        ''' <summary>
        ''' Get the SHA1 hash of a string.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSHA1Hash(ByVal value As String) As String

            ' NOTE: Can't use SHA512 here because it isn't supported on Windows XP.

            Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(value)

            bytesToHash = sha1Obj.ComputeHash(bytesToHash)

            Return ByteToString(bytesToHash)

        End Function

        Private Shared Function ByteToString(ByVal buff As Byte()) As String

            Dim sbinary As String = String.Empty

            For i As Integer = 0 To buff.Length - 1
                ' hex format
                sbinary += buff(i).ToString("X2")
            Next

            Return (sbinary)

        End Function

        ''' <summary>
        ''' Get the MD5 hash of a file.
        ''' </summary>
        ''' <param name="filePath"></param>
        ''' <returns></returns>
        Public Shared Function GetFileMD5Hash(ByVal FilePath As String) As String

            ' get all the file contents
            Dim File() As Byte = System.IO.File.ReadAllBytes(FilePath)

            ' create a new md5 object
            Dim Md5 As New MD5CryptoServiceProvider()

            ' compute the hash
            Dim byteHash() As Byte = Md5.ComputeHash(File)

            ' return the value in base 64 
            Return Convert.ToBase64String(byteHash)

        End Function

    End Class

End Namespace