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
Imports EFTCalculator.Core.Cryptography

<TestClass()>
Public Class TripleDESUnitTests

    <TestMethod()>
    Public Sub TestTripleDESOperations()
        Const ZEROES As String = "0000000000000000"

        Assert.AreEqual("D5D44FF720683D0D", TripleDES.TripleDESEncrypt(New HexKey("0123456789ABCDEF"), ZEROES))
        Assert.AreEqual("D5D44FF720683D0D", TripleDES.TripleDESEncrypt(New HexKey("0123456789ABCDEF0123456789ABCDEF"), ZEROES))
        Assert.AreEqual("D5D44FF720683D0D", TripleDES.TripleDESEncrypt(New HexKey("0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"), ZEROES))
        Assert.AreEqual("08D7B4FB629D0885", TripleDES.TripleDESEncrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210"), ZEROES))
        Assert.AreEqual("1D81356B5DDE5F2A", TripleDES.TripleDESEncrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210ABCDEF0123456789"), ZEROES))

        Assert.AreEqual(ZEROES, TripleDES.TripleDESDecrypt(New HexKey("0123456789ABCDEF"), "D5D44FF720683D0D"))
        Assert.AreEqual(ZEROES, TripleDES.TripleDESDecrypt(New HexKey("0123456789ABCDEF0123456789ABCDEF"), "D5D44FF720683D0D"))
        Assert.AreEqual(ZEROES, TripleDES.TripleDESDecrypt(New HexKey("0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"), "D5D44FF720683D0D"))
        Assert.AreEqual(ZEROES, TripleDES.TripleDESDecrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210"), "08D7B4FB629D0885"))
        Assert.AreEqual(ZEROES, TripleDES.TripleDESDecrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210ABCDEF0123456789"), "1D81356B5DDE5F2A"))

        Assert.AreEqual("1D81356B5DDE5F2A1D81356B5DDE5F2A", TripleDES.TripleDESEncrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210ABCDEF0123456789"), ZEROES + ZEROES))
        Assert.AreEqual("1D81356B5DDE5F2A1D81356B5DDE5F2A1D81356B5DDE5F2A", TripleDES.TripleDESEncrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210ABCDEF0123456789"), ZEROES + ZEROES + ZEROES))

        Assert.AreEqual(ZEROES + ZEROES, TripleDES.TripleDESDecrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210ABCDEF0123456789"), "1D81356B5DDE5F2A1D81356B5DDE5F2A"))
        Assert.AreEqual(ZEROES + ZEROES + ZEROES, TripleDES.TripleDESDecrypt(New HexKey("0123456789ABCDEFFEDCBA9876543210ABCDEF0123456789"), "1D81356B5DDE5F2A1D81356B5DDE5F2A1D81356B5DDE5F2A"))

        For kl As KeyLength = KeyLength.SingleLength To KeyLength.TripleLength
            For i As Integer = 1 To 100
                Dim key As New HexKey(Utility.CreateRandomKey(kl))
                Dim crypt As String = TripleDES.TripleDESEncrypt(key, ZEROES)
                Assert.AreEqual(ZEROES, TripleDES.TripleDESDecrypt(key, crypt))
            Next
        Next
    End Sub

End Class
