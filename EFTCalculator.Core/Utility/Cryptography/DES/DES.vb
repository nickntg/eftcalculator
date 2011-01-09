''
'' This program is free software; you can redistribute it and/or modify
'' it under the terms of the GNU General Public License as published by
'' the Free Software Foundation; either version 2 of the License, or
'' (at your option) any later version.
''
'' This program is distributed in the hope that it will be useful,
'' but WITHOUT ANY WARRANTY; without even the implied warranty of
'' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'' GNU General Public License for more details.
''
'' You should have received a copy of the GNU General Public License
'' along with this program; if not, write to the Free Software
'' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'' 

Imports System.IO
Imports System.Security.Cryptography

Namespace Cryptography

    ''' <summary>
    ''' Generic byte-oriented and hex-oriented DES operations.
    ''' </summary>
    ''' <remarks>
    ''' The DES class uses the .Net DESCryptoServiceProvider to implement DES encryption/decryption
    ''' using the ECB mode.
    ''' </remarks>
    Public Class DES

        ''' <summary>
        ''' Encrypts a byte array.
        ''' </summary>
        ''' <remarks>
        ''' The method encrypts a byte array of 16 bytes.
        ''' </remarks>
        Public Shared Sub byteDESEncrypt(ByVal bKey() As Byte, ByVal bData() As Byte, ByRef bResult() As Byte)
            ReDim bResult(7)

            Using outStream As MemoryStream = New MemoryStream(bResult)
                Using desProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider
                    Dim bNullVector() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}

                    desProvider.Mode = CipherMode.ECB
                    desProvider.Key = bKey
                    desProvider.IV = bNullVector
                    desProvider.Padding = PaddingMode.None

                    Using cStream As CryptoStream = New CryptoStream(outStream, desProvider.CreateEncryptor(bKey, bNullVector), CryptoStreamMode.Write)
                        cStream.Write(bData, 0, 8)
                        cStream.Close()
                    End Using
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Decrypts a byte array.
        ''' </summary>
        ''' <remarks>
        ''' This method decrypts a byte array of 16 bytes.
        ''' </remarks>
        Public Shared Sub byteDESDecrypt(ByVal bKey() As Byte, ByVal bData() As Byte, ByRef bResult() As Byte)
            Using desProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider
                Dim bNullVector() As Byte = {0, 0, 0, 0, 0, 0, 0, 0}

                desProvider.Mode = CipherMode.ECB
                desProvider.Key = bKey
                desProvider.IV = bNullVector
                desProvider.Padding = PaddingMode.None

                ReDim bResult(7)

                Using outStream As MemoryStream = New MemoryStream(bResult)
                    Using cStream As CryptoStream = New CryptoStream(outStream, desProvider.CreateDecryptor(bKey, bNullVector), CryptoStreamMode.Write)
                        cStream.Write(bData, 0, 8)
                        cStream.Close()
                    End Using
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Encrypts a hex string.
        ''' </summary>
        ''' <remarks>
        ''' This method encrypts hex data under a hex key and returns the result.
        ''' </remarks>
        Public Shared Function DESEncrypt(ByVal sKey As String, ByVal sData As String) As String
            Dim bOutput() As Byte = {}, sResult As String = ""

            byteDESEncrypt(Core.Utility.HexToByteArray(sKey), Core.Utility.HexToByteArray(sData), bOutput)
            Return Core.Utility.ByteArrayToHex(bOutput)
        End Function

        'DES-decrypt a 16-hex block using a 16-hex key
        ''' <summary>
        ''' Decrypts a hex string.
        ''' </summary>
        ''' <remarks>
        ''' This method decrypts hex data using a hex key and returns the result.
        ''' </remarks>
        Public Shared Function DESDecrypt(ByVal sKey As String, ByVal sData As String) As String
            Dim bOutput() As Byte = {}, sResult As String = ""

            byteDESDecrypt(Core.Utility.HexToByteArray(sKey), Core.Utility.HexToByteArray(sData), bOutput)
            Return Core.Utility.ByteArrayToHex(bOutput)
        End Function

        ''' <summary>
        ''' Determines whether a key is weak or semi-weak.
        ''' </summary>
        ''' <param name="hexKey"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsWeakKey(ByVal hexKey As String) As Boolean
            Dim bKey() As Byte = Utility.HexToByteArray(hexKey)
            Return (DESCryptoServiceProvider.IsWeakKey(bKey)) Or (DESCryptoServiceProvider.IsSemiWeakKey(bKey))
        End Function

    End Class

End Namespace
