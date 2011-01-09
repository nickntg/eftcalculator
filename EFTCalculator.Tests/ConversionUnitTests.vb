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

Imports EFTCalculator.Core

<TestClass()>
Public Class ConversionUnitTests

    <TestMethod()> _
    Public Sub TestConversionToBinary()
        Assert.AreEqual("1111", Utility.HexToBinary("F"))
        Assert.AreEqual("0000000100100011", Utility.HexToBinary("0123"))
    End Sub

    <TestMethod()> _
    Public Sub TestConversionFromBinary()
        Assert.AreEqual("F", Utility.BinaryToHex("1111"))
        Assert.AreEqual("0123", Utility.BinaryToHex("0000000100100011"))
    End Sub

    <TestMethod()> _
    Public Sub TestConversionFromHexToByteArray()
        Dim b() As Byte = {0, 10, 20, 30}
        Dim bConverted() As Byte = Utility.HexToByteArray("000A141E")

        If b.GetLength(0) <> bConverted.GetLength(0) Then
            Assert.Fail("HexStringToByteArray() failed (length)")
        End If

        For i As Integer = 0 To b.GetUpperBound(0)
            If b(i) <> bConverted(i) Then
                Assert.Fail("HexStringToByteArray() failed (contents)")
            End If
        Next
    End Sub

    <TestMethod()> _
    Public Sub TestConversionFromByteArrayToHex()
        Dim b() As Byte = {0, 10, 20, 30}
        Assert.AreEqual("000A141E", Utility.ByteArrayToHex(b))
    End Sub
End Class
