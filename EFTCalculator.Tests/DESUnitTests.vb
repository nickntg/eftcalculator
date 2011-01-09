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

Imports EFTCalculator.Core.Cryptography

<TestClass()>
Public Class DESUnitTests

    <TestMethod()>
    Public Sub TestDESOperations()
        Assert.AreEqual("D5D44FF720683D0D", DES.DESEncrypt("0123456789ABCDEF", "0000000000000000"))
        Assert.AreEqual("0000000000000000", DES.DESDecrypt("0123456789ABCDEF", "D5D44FF720683D0D"))
    End Sub

End Class
