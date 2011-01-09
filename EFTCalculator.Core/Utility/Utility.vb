﻿''
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


''' <summary>
''' Utility class that implements common operations.
''' </summary>
''' <remarks></remarks>
Public Class Utility

    ''' <summary>
    ''' Converts a string from hexadecimal to binary form.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function HexToBinary(ByVal hexString As String) As String
        Dim r As String = ""
        For i As Integer = 0 To hexString.Length - 1
            r = r + Convert.ToString(Convert.ToInt32(hexString.Substring(i, 1), 16), 2).PadLeft(4, "0"c)
        Next
        Return r
    End Function

    ''' <summary>
    ''' Converts a string from binary to hexadecimal form.
    ''' </summary>
    ''' <param name="binaryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BinaryToHex(ByVal binaryString As String) As String
        Dim r As String = ""
        For i As Integer = 0 To binaryString.Length - 1 Step 4
            r = r + Convert.ToByte(binaryString.Substring(i, 4), 2).ToString("X1")
        Next
        Return r
    End Function

    ''' <summary>
    ''' Converts a hexadecimal string to a byte array.
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function HexToByteArray(ByVal s As String) As Byte()
        Dim i As Integer = 0, j As Integer = 0
        Dim bData() As Byte
        ReDim bData(s.Length \ 2 - 1)

        While i <= s.Length - 1
            bData(j) = Convert.ToByte(s.Substring(i, 2), 16)
            i += 2
            j += 1
        End While

        Return bData
    End Function

    ''' <summary>
    ''' Converts a byte array to a hexadecimal string.
    ''' </summary>
    ''' <param name="bData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ByteArrayToHex(ByVal bData() As Byte) As String
        Dim sb As New System.Text.StringBuilder

        For i As Integer = 0 To bData.GetUpperBound(0)
            sb.AppendFormat("{0:X2}", bData(i))
        Next
        Return sb.ToString
    End Function

    ''' <summary>
    ''' Determines whether a string is hexadecimal.
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsHex(ByVal s As String) As Boolean
        If String.IsNullOrEmpty(s) Then Return False

        For i As Integer = 0 To s.Length - 1
            If Not Char.IsDigit(s.Chars(i)) Then
                If (s.Chars(i) < "A"c) Or (s.Chars(i) > "F"c) Then
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    ''' <summary>
    ''' Performs a XOR operation on two hexadecimal strings.
    ''' </summary>
    ''' <param name="sourceHexString"></param>
    ''' <param name="xorHexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function XORHex(ByVal sourceHexString As String, ByVal xorHexString As String) As String
        Dim s As String = ""

        For i As Integer = 0 To sourceHexString.Length - 1
            s = s + (Convert.ToInt32(sourceHexString.Substring(i, 1), 16) Xor Convert.ToInt32(xorHexString.Substring(i, 1), 16)).ToString("X")
        Next

        Return s
    End Function

    ''' <summary>
    ''' Performs an AND operation on two hexadecimal strings.
    ''' </summary>
    ''' <param name="sourceHexString"></param>
    ''' <param name="xorHexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ANDHex(ByVal sourceHexString As String, ByVal xorHexString As String) As String
        Dim s As String = ""

        For i As Integer = 0 To sourceHexString.Length - 1
            s = s + (Convert.ToInt32(sourceHexString.Substring(i, 1), 16) And Convert.ToInt32(xorHexString.Substring(i, 1), 16)).ToString("X")
        Next

        Return s
    End Function

    ''' <summary>
    ''' Performs an OR operation on two hexadecimal strings.
    ''' </summary>
    ''' <param name="sourceHexString"></param>
    ''' <param name="xorHexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ORHex(ByVal sourceHexString As String, ByVal xorHexString As String) As String
        Dim s As String = ""

        For i As Integer = 0 To sourceHexString.Length - 1
            s = s + (Convert.ToInt32(sourceHexString.Substring(i, 1), 16) Or Convert.ToInt32(xorHexString.Substring(i, 1), 16)).ToString("X")
        Next

        Return s
    End Function

    ''' <summary>
    ''' Determines if a hexadecimal string has a specified parity.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <param name="parity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsParityOK(ByVal hexString As String, ByVal parity As Parity) As Boolean
        If parity = Core.Parity.NoParity Then Return True

        Dim i As Integer = 0
        While i < hexString.Length
            Dim b As String = HexToBinary(hexString.Substring(i, 2))
            i += 2
            Dim l As Integer = 0
            For j As Integer = 0 To b.Length - 1
                If b.Substring(j, 1) = "1" Then l += 1
            Next
            If ((l Mod 2 = 0) AndAlso (parity = Core.Parity.OddParity)) OrElse _
               ((l Mod 2 = 1) AndAlso (parity = Core.Parity.EvenParity)) Then
                Return False
            End If

        End While
        Return True
    End Function

    ''' <summary>
    ''' Determines if a hexadecimal string has odd bit parity.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsOddParity(ByVal hexString As String) As Boolean
        Return IsParityOK(hexString, Parity.OddParity)
    End Function

    ''' <summary>
    ''' Determines if a hexadecimal string has even bit parity.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsEvenParity(ByVal hexString As String) As Boolean
        Return IsParityOK(hexString, Parity.EvenParity)
    End Function

    ''' <summary>
    ''' Changes a hexadecimal key to force the specified bit parity.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <param name="parity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeParity(ByVal hexString As String, ByVal parity As Parity) As String
        If parity = Core.Parity.NoParity Then Return hexString

        Dim i As Integer = 0, r As String = ""
        While i < hexString.Length
            Dim b As String = HexToBinary(hexString.Substring(i, 2))
            i += 2
            Dim l As Integer = b.Replace("0", "").Length

            If ((l Mod 2 = 0) AndAlso (parity = Core.Parity.OddParity)) OrElse _
               ((l Mod 2 = 1) AndAlso (parity = Core.Parity.EvenParity)) Then
                If b.Substring(7, 1) = "1" Then
                    r = r + b.Substring(0, 7) + "0"
                Else
                    r = r + b.Substring(0, 7) + "1"
                End If
            Else
                r = r + b
            End If
        End While

        Return BinaryToHex(r)
    End Function

    ''' <summary>
    ''' Changes a hexadecimal string to force odd bit parity.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeOddParity(ByVal hexString As String) As String
        Return MakeParity(hexString, Parity.OddParity)
    End Function

    ''' <summary>
    ''' Changes a hexadecimal string to force even bit parity.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeEvenParity(ByVal hexString As String) As String
        Return MakeParity(hexString, Parity.EvenParity)
    End Function

    ''' <summary>
    ''' Creates a random DES/3DS key of specified length.
    ''' </summary>
    ''' <param name="KeyLength"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateRandomKey(ByVal KeyLength As Cryptography.KeyLength) As String
        Select Case KeyLength
            Case Cryptography.KeyLength.SingleLength
                Return SingleLengthRandomKey(Parity.OddParity)
            Case Cryptography.KeyLength.DoubleLength
                Return MakeOddParity(SingleLengthRandomKey(Parity.NoParity) + SingleLengthRandomKey(Parity.NoParity))
            Case Else
                Return MakeOddParity(SingleLengthRandomKey(Parity.NoParity) + SingleLengthRandomKey(Parity.NoParity) + SingleLengthRandomKey(Parity.NoParity))
        End Select
    End Function

    Private Shared rndMachine As Random = New Random

    Private Shared Function SingleLengthRandomKey(ByVal Parity As Parity) As String
        Dim s As String, sb As New System.Text.StringBuilder
        Do
            For i As Integer = 1 To 16
                sb.AppendFormat("{0:X1}", rndMachine.Next(0, 16))
            Next
            s = sb.ToString
            sb = Nothing

            If Parity <> Core.Parity.NoParity Then
                s = MakeParity(s, Parity)
            End If
        Loop Until Not Cryptography.DES.IsWeakKey(s)

        Return s
    End Function

End Class