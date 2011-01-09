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

Namespace Cryptography

    ''' <summary>
    ''' This class represents a DES/3DES key.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HexKey

        ''' <summary>
        ''' First 16-hex characters of key.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PartA As String

        ''' <summary>
        ''' Second 16-hex characters of key.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PartB As String

        ''' <summary>
        ''' Last 16-hex characters of key.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PartC As String
        Property KeyLength As KeyLength

        ''' <summary>
        ''' Initializes a key using a hexadecimal string.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal key As String)

            If key.Length = 16 Then
                PartA = key
                PartB = key
                PartC = key
                KeyLength = KeyLength.SingleLength
            ElseIf key.Length = 32 Then
                _PartA = key.Substring(0, 16)
                _PartB = key.Substring(16)
                _PartC = _PartA
                _KeyLength = KeyLength.DoubleLength
            Else
                _PartA = key.Substring(0, 16)
                _PartB = key.Substring(16, 16)
                _PartC = key.Substring(32)
                _KeyLength = KeyLength.TripleLength
            End If
        End Sub

        ''' <summary>
        ''' Returns key as hexadecimal characters.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Select Case KeyLength
                Case Cryptography.KeyLength.SingleLength
                    Return PartA
                Case Cryptography.KeyLength.DoubleLength
                    Return PartA + PartB
                Case Else
                    Return PartA + PartB + PartC
            End Select
        End Function

    End Class


End Namespace