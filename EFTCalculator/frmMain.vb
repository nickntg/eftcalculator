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

    'Read keys and add to list view.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyStore.ReadKeys()

        For Each key As String In KeyStore.GetKeys.Keys
            Dim SK As StoredKey = KeyStore.GetKey(key)
            AddKeyToLV(SK)
        Next
    End Sub

    Private Sub AddKeyToLV(ByVal SK As StoredKey)
        Dim itmX As New ListViewItem(SK.KeyName)
        itmX.SubItems.Add(SK.KeyValue)
        itmX.SubItems.Add(SK.KeyComment)
        itmX.Tag = SK
        LVKeys.Items.Add(itmX)
    End Sub

    Private Sub RemoveKeyFromLV(ByVal SK As StoredKey)
        For Each itmX As ListViewItem In LVKeys.Items
            If itmX.SubItems(0).Text = SK.KeyName Then
                LVKeys.Items.Remove(itmX)
                Exit Sub
            End If
        Next
    End Sub

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

#Region "Key management"

    'Show keys as they are selected.
    Private Sub LVKeys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVKeys.SelectedIndexChanged
        If LVKeys.SelectedItems.Count = 0 Then
            txtKeyName.Text = ""
            txtKeyValue.Clear()
            txtKeyDescription.Text = ""
        Else
            txtKeyName.Text = LVKeys.SelectedItems(0).SubItems(0).Text
            txtKeyValue.Text = LVKeys.SelectedItems(0).SubItems(1).Text
            txtKeyDescription.Text = LVKeys.SelectedItems(0).SubItems(2).Text
        End If
    End Sub

    'Add/update a key.
    Private Sub cmdAddUpdateKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUpdateKey.Click
        If txtKeyName.Text = "" Then
            MessageBox.Show(Me, "Enter a unique key name.", "No key name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtKeyName.Focus()
            Exit Sub
        End If

        If Not txtKeyValue.IsValid Then
            Exit Sub
        End If

        Dim SK As New StoredKey(txtKeyName.Text, txtKeyValue.Text, txtKeyDescription.Text)
        Dim alreadyExists As Boolean = False

        If KeyStore.KeyExists(SK.KeyName) Then
            alreadyExists = True
            KeyStore.UpdateKey(SK)
        Else
            KeyStore.AddKey(SK)
        End If

        Try
            KeyStore.WriteKeys()
        Catch ex As Exception
            MessageBox.Show(Me, "There was an error writing the keys to the disk." + vbCrLf + ex.ToString(), "I/O error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If alreadyExists Then
            RemoveKeyFromLV(SK)
        End If

        AddKeyToLV(SK)
    End Sub

    Private Sub cmdDeleteKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteKey.Click
        If txtKeyName.Text = "" Then
            MessageBox.Show(Me, "Click on a key, then click on the DELETE button.", "No key selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LVKeys.Focus()
            Exit Sub
        End If

        If KeyStore.KeyExists(txtKeyName.Text) Then
            Dim SK As StoredKey = KeyStore.GetKey(txtKeyName.Text)

            KeyStore.RemoveKey(txtKeyName.Text)

            Try
                KeyStore.WriteKeys()
            Catch ex As Exception
                MessageBox.Show(Me, "There was an error writing the keys to the disk." + vbCrLf + ex.ToString(), "I/O error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            RemoveKeyFromLV(SK)
        End If
    End Sub

    Private Sub cmdClearAllKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAllKeys.Click
        If MessageBox.Show(Me, "Remove all keys?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub

        KeyStore.Clear()

        Try
            KeyStore.WriteKeys()
        Catch ex As Exception
            MessageBox.Show(Me, "There was an error writing the keys to the disk." + vbCrLf + ex.ToString(), "I/O error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LVKeys.Items.Clear()
    End Sub

#End Region

End Class