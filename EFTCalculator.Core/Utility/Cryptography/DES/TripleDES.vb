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

Imports System.Security.Cryptography

Namespace Cryptography

    ''' <summary>
    ''' Utility class to perform Triple DES operations.
    ''' </summary>
    ''' <remarks>
    ''' This class can be used to perform 3D operations using <see cref="HexKey"/> hexadecimal keys.
    ''' </remarks>
    Public Class TripleDES

        ''' <summary>
        ''' Performs an encryption operation.
        ''' </summary>
        ''' <remarks>
        ''' Performs an encryption operation.
        ''' </remarks>
        Public Shared Function TripleDESEncrypt(ByVal key As HexKey, ByVal data As String) As String

            If (data Is Nothing) OrElse (data.Length <> 16 AndAlso data.Length <> 32 AndAlso data.Length <> 48) Then Throw New InvalidOperationException("Invalid data for 3DEncrypt")

            Dim result As String
            If data.Length = 16 Then
                result = Encrypt(key, data)
            ElseIf data.Length = 32 Then
                result = Encrypt(key, data.Substring(0, 16)) + _
                         Encrypt(key, data.Substring(16, 16))
            Else
                result = Encrypt(key, data.Substring(0, 16)) + _
                         Encrypt(key, data.Substring(16, 16)) + _
                         Encrypt(key, data.Substring(32, 16))
            End If
            Return result
        End Function

        ''' <summary>
        ''' Performs a decrypt operation.
        ''' </summary>
        ''' <remarks>
        ''' Performs a decryption operation.
        ''' </remarks>
        Public Shared Function TripleDESDecrypt(ByVal key As HexKey, ByVal data As String) As String
            If (data Is Nothing) OrElse (data.Length <> 16 AndAlso data.Length <> 32 AndAlso data.Length <> 48) Then Throw New InvalidOperationException("Invalid data for 3DEncrypt")

            Dim result As String
            If data.Length = 16 Then
                result = Decrypt(key, data)
            ElseIf data.Length = 32 Then
                result = Decrypt(key, data.Substring(0, 16)) + _
                         Decrypt(key, data.Substring(16, 16))
            Else
                result = Decrypt(key, data.Substring(0, 16)) + _
                         Decrypt(key, data.Substring(16, 16)) + _
                         Decrypt(key, data.Substring(32, 16))
            End If
            Return result
        End Function

        ''' <summary>
        ''' Determines whether a key is weak or semi-weak.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsWeakKey(ByVal key As HexKey) As Boolean
            Dim bKey() As Byte = Utility.HexToByteArray(key.ToString)
            If key.KeyLength = KeyLength.SingleLength Then
                Return (DESCryptoServiceProvider.IsWeakKey(bKey)) Or (DESCryptoServiceProvider.IsSemiWeakKey(bKey))
            Else
                Return TripleDESCryptoServiceProvider.IsWeakKey(bKey)
            End If
        End Function

        ''' <summary>
        ''' Returns a key check value.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetCheckValue(ByVal key As HexKey) As String
            Return TripleDESEncrypt(key, "0000000000000000")
        End Function

        ''' <summary>
        ''' Encrypts 16-hex data.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function Encrypt(ByVal key As HexKey, ByVal data As String) As String
            Dim result As String = ""
            result = DES.DESEncrypt(key.PartA, data)
            result = DES.DESDecrypt(key.PartB, result)
            result = DES.DESEncrypt(key.PartC, result)
            Return result
        End Function

        ''' <summary>
        ''' Decrypts 16-hex data.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="data"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function Decrypt(ByVal key As HexKey, ByVal data As String) As String
            Dim result As String
            result = DES.DESDecrypt(key.PartC, data)
            result = DES.DESEncrypt(key.PartB, result)
            result = DES.DESDecrypt(key.PartA, result)
            Return result
        End Function

    End Class

End Namespace
