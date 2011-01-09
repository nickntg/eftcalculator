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

Public Class frmMain

#Region "DES/3DES"

    'DES encrypt.
    Private Sub cmdEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEncrypt.Click
        If Not IsDESValid() Then Exit Sub

        Dim hk As HexKey = DESHexKey.GetKey

        If Utility.IsOddParity(hk.ToString) Then
            lblDESParity.Text = "Parity: ODD"
        ElseIf Utility.IsEvenParity(hk.ToString) Then
            lblDESParity.Text = "Parity: EVEN"
        End If

        lblDESKCV.Text = "Check Value: " + TripleDES.GetCheckValue(hk)

        DESResult.Text = TripleDES.TripleDESEncrypt(hk, DESHexData.Text)
    End Sub

    'DES decrypt.
    Private Sub cmdDecrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDecrypt.Click
        If Not IsDESValid() Then Exit Sub

        Dim hk As HexKey = DESHexKey.GetKey

        If Utility.IsOddParity(hk.ToString) Then
            lblDESParity.Text = "Parity: ODD"
        ElseIf Utility.IsEvenParity(hk.ToString) Then
            lblDESParity.Text = "Parity: EVEN"
        End If

        lblDESKCV.Text = "Check Value: " + TripleDES.GetCheckValue(hk)

        DESResult.Text = TripleDES.TripleDESDecrypt(hk, DESHexData.Text)
    End Sub

    'XOR
    Private Sub cmdXOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXOR.Click
        If Not IsDESValid() Then Exit Sub

        If DESHexData.Text.Length <> DESHexKey.Text.Length Then
            DESHexData.SetError("Length must be identical for XOR operation")
            DESHexKey.SetError("Length must be identical for XOR operation")
            Exit Sub
        End If

        DESResult.Text = Utility.XORHex(DESHexData.Text, DESHexKey.Text)
    End Sub

    'OR
    Private Sub cmdOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOR.Click
        If Not IsDESValid() Then Exit Sub

        If DESHexData.Text.Length <> DESHexKey.Text.Length Then
            DESHexData.SetError("Length must be identical for OR operation")
            DESHexKey.SetError("Length must be identical for OR operation")
            Exit Sub
        End If

        DESResult.Text = Utility.ORHex(DESHexData.Text, DESHexKey.Text)
    End Sub

    'AND
    Private Sub cmdAND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAND.Click
        If Not IsDESValid() Then Exit Sub

        If DESHexData.Text.Length <> DESHexKey.Text.Length Then
            DESHexData.SetError("Length must be identical for AND operation")
            DESHexKey.SetError("Length must be identical for AND operation")
            Exit Sub
        End If

        DESResult.Text = Utility.ANDHex(DESHexData.Text, DESHexKey.Text)
    End Sub

    'Odd parity
    Private Sub cmdOddParity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOddParity.Click
        DESResult.Text = Utility.MakeOddParity(DESResult.Text)
    End Sub

    'Even parity
    Private Sub cmdEvenParity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEvenParity.Click
        DESResult.Text = Utility.MakeEvenParity(DESResult.Text)
    End Sub

    Private Function IsDESValid() As Boolean
        If DESHexData.IsValid And DESHexKey.IsValid Then
            If Not TripleDES.IsWeakKey(DESHexKey.GetKey) Then
                Return True
            Else
                DESHexKey.SetError("DES weak or semi-weak key")
            End If
        End If
        Return False
    End Function

#End Region

End Class