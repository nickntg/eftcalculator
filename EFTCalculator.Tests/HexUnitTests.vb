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
Public Class HexUnitTests

    <TestMethod()> _
    Public Sub TestIsHex()
        Assert.IsTrue(Utility.IsHex("0123456789ABCDEF"))
        Assert.IsFalse(Utility.IsHex("ABCD01O"))
    End Sub

    <TestMethod()> _
    Public Sub TestHexOperations()
        Assert.AreEqual("0001", Utility.XORHex("0001", "0000"))
    End Sub

End Class
