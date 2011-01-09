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
Public Class ParityUnitTests

    <TestMethod()>
    Public Sub TestParityChecking()
        Assert.IsFalse(Utility.IsOddParity("AF7202ED1A3EF20F"))
        Assert.IsTrue(Utility.IsOddParity("AE7302EC1A3EF20E"))
        Assert.IsTrue(Utility.IsEvenParity("AF7203ED1B3FF30F"))
    End Sub

    <TestMethod()> _
    Public Sub TestParityEnforcing()
        Assert.AreEqual("AE7302EC1A3EF20E", Utility.MakeOddParity("AF7202ED1A3EF20F"))
        Assert.AreEqual("AF7203ED1B3FF30F", Utility.MakeEvenParity("AF7202ED1A3EF20F"))
    End Sub

End Class
