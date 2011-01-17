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

Imports EFTCalculator.Core
Imports EFTCalculator.Core.Cryptography

Public Class frmMain

    Private PVVCalculation As String = ""

    Delegate Sub UpdateProgress(ByVal percent As Integer)
    Delegate Sub UpdateLabel(ByVal status As String)

    'Read keys and add to list view.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lnkHome.Links.Add(0, lnkHome.Text.Length, "http://eftcalculator.codeplex.com/")

        txtPINKey.ShowLoadKey = True
        txtPINKey.ShowGenerateKey = True
        DESHexData.ShowLoadKey = True
        DESHexData.ShowGenerateKey = True
        DESHexKey.ShowLoadKey = True
        DESHexKey.ShowGenerateKey = True
        DESResult.ShowLoadKey = False
        DESResult.ShowGenerateKey = False
        txtPVVPVK.ShowLoadKey = True
        txtPVVPVK.ShowGenerateKey = True
        txtCVKPair.ShowLoadKey = True
        txtCVKPair.ShowGenerateKey = True

        cboPVKI.SelectedIndex = 0

        KeyStore.ReadKeys()

        For Each key As String In KeyStore.GetKeys.Keys
            Dim SK As StoredKey = KeyStore.GetKey(key)
            AddKeyToLV(SK)
        Next
    End Sub

    'Add a key to the list view.
    Private Sub AddKeyToLV(ByVal SK As StoredKey)
        Dim itmX As New ListViewItem(SK.KeyName)
        itmX.SubItems.Add(SK.KeyValue)
        itmX.SubItems.Add(SK.KeyComment)
        itmX.Tag = SK
        LVKeys.Items.Add(itmX)
    End Sub

    'Remove a key from the list view.
    Private Sub RemoveKeyFromLV(ByVal SK As StoredKey)
        For Each itmX As ListViewItem In LVKeys.Items
            If itmX.SubItems(0).Text = SK.KeyName Then
                LVKeys.Items.Remove(itmX)
                Exit Sub
            End If
        Next
    End Sub

    'Go to home site.
    Private Sub lnkHome_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkHome.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString)
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

#Region "Check digit"

    'Check digit calculation/verification.
    Private Sub cmdCheckDigit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckDigit.Click
        If txtPANtoCheck.Text.Length < 2 Then
            MessageBox.Show(Me, "Enter a PAN", "No PAN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPANtoCheck.Focus()
            Exit Sub
        End If

        If optPANWithCheckDigit.Checked Then
            Dim result As String = Utility.LuhnCheck(txtPANtoCheck.Text)
            If result = txtPANtoCheck.Text.Substring(txtPANtoCheck.Text.Length - 1, 1) Then
                lblCheckDigitResult.Text = "Check digit is correct"
                lblCheckDigitResult.ForeColor = Color.Green
            Else
                lblCheckDigitResult.Text = "Check digit is incorrect, should be " + result
                lblCheckDigitResult.ForeColor = Color.Red
            End If
        Else
            Dim result As String = Utility.LuhnCheck(txtPANtoCheck.Text + "0")
            lblCheckDigitResult.Text = "Calculated check digit: " + result
            lblCheckDigitResult.ForeColor = Color.Black
        End If
    End Sub

#End Region

#Region "PIN block"

    'Find PIN block requirements on format selection change.
    Private Sub cboPBFormat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPBFormat.SelectedIndexChanged
        If cboPBFormat.SelectedIndex = -1 Then
            txtAccount.Enabled = False
            txtPadding.Enabled = False
        Else
            Dim PBF As PIN.PinBlockFormat = GetPBFormat()
            Dim reqs As PIN.PinBlockRequirements = PIN.PinBlock.GetPINBlockRequirements(PBF)
            txtAccount.Enabled = reqs.RequiresAccount
            txtPadding.Enabled = reqs.RequiresPadding
        End If
    End Sub

    'Calculate clear and encrypted PIN blocks.
    Private Sub cmdGetPINBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetPINBlock.Click
        If txtPIN.Text = "" Then
            MessageBox.Show(Me, "Enter a PIN number", "No PIN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPIN.Focus()
            Exit Sub
        End If

        If Not IsOtherPINBlockDataValid() Then Exit Sub

        Dim clearPB As String = ""

        Try
            clearPB = PIN.PinBlock.ToPINBlock(GetPBFormat, txtPIN.Text, txtPadding.Text, txtAccount.Text)
        Catch ex As Exception
            MessageBox.Show(Me, "Error calculating clear PIN block." + vbCrLf + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim cryptPB As String = TripleDES.TripleDESEncrypt(txtPINKey.GetKey, clearPB)
        txtPINBlock.Text = cryptPB

        lblPINBlockResult.Text = "Clear PIN Block: " + clearPB + vbCrLf + "Encrypted PIN Block: " + cryptPB
    End Sub

    'Find clear PIN from PIN block.
    Private Sub cmdGetPIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetPIN.Click
        If txtPINBlock.Text.Length <> 16 Then
            MessageBox.Show(Me, "Enter a valid PIN block", "No PIN block", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPINBlock.Focus()
            Exit Sub
        End If

        If Not IsOtherPINBlockDataValid() Then Exit Sub

        Dim clearPB As String = TripleDES.TripleDESDecrypt(txtPINKey.GetKey, txtPINBlock.Text)
        Dim clearPIN As String = ""

        Try
            clearPIN = PIN.PinBlock.ToPIN(GetPBFormat, clearPB, txtPadding.Text, txtAccount.Text)
        Catch ex As Exception
            MessageBox.Show(Me, "Error finding PIN. This may indicate an incorrect PIN block or PIN key." + vbCrLf + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        txtPIN.Text = clearPIN
        lblPINBlockResult.Text = "Clear PIN: " + clearPIN
    End Sub

    'Get the PIN block format from the combo.
    Private Function GetPBFormat() As PIN.PinBlockFormat
        Return CType(cboPBFormat.SelectedIndex, PIN.PinBlockFormat)
    End Function

    'Validate PIN block data.
    Private Function IsOtherPINBlockDataValid() As Boolean
        If txtAccount.Enabled AndAlso txtAccount.Text = "" Then
            MessageBox.Show(Me, "Enter an account number", "No account", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAccount.Focus()
            Return False
        End If

        If txtPadding.Enabled AndAlso txtPadding.Text = "" Then
            MessageBox.Show(Me, "Enter a padding string", "No padding", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPadding.Focus()
            Return False
        End If

        If cboPBFormat.SelectedIndex = -1 Then
            MessageBox.Show(Me, "Select a PIN block format", "No PIN block format", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboPBFormat.Focus()
            Return False
        End If

        Return txtPINKey.IsValid
    End Function

#End Region

#Region "PVV"

    'Generate Visa PVV
    Private Sub cmdGeneratePVV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneratePVV.Click
        If Not IsPVVInfoValid() Then Exit Sub

        Try
            Dim PVV As String = Utility.GeneratePVV(txtPVVAccount.Text, cboPVKI.Text, txtPVVPIN.Text, txtPVVPVK.GetKey)
            lblPVV.Text = "Calculated PVV: " + PVV
        Catch ex As Exception
            MessageBox.Show(Me, "Error calculating Visa PVV" + vbCrLf + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'PVV clashing
    Private Sub cmdFindOtherPINs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindOtherPINs.Click
        If BW.IsBusy Then
            MessageBox.Show(Me, "Please wait until the current calculation completes.", "Still calculating...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not IsPVVInfoValid() Then Exit Sub

        barPVVClashing.Visible = True

        BW.RunWorkerAsync(txtPVVPIN.Text + ";" + txtPVVAccount.Text + ";" + cboPVKI.Text + ";" + txtPVVPVK.Text)
        lblPVV.Text = "Please wait...calculating all PINs..."
    End Sub

    'Determines whether PVV text info is valid.
    Private Function IsPVVInfoValid() As Boolean
        If txtPVVAccount.Text.Length < 12 Then
            MessageBox.Show(Me, "Enter an account number", "No account", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPVVAccount.Focus()
            Return False
        End If

        If txtPVVPIN.Text.Length <> 4 Then
            MessageBox.Show(Me, "Enter a 4-digit PIN", "Incorrect PIN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPVVPIN.Focus()
            Return False
        End If

        If cboPVKI.SelectedIndex = -1 Then
            MessageBox.Show(Me, "Select a PVKI", "No PVKI", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboPVKI.Focus()
            Return False
        End If

        If Not txtPVVPVK.IsValid Then
            Return False
        End If

        Dim HK As HexKey = txtPVVPVK.GetKey
        If HK.KeyLength <> KeyLength.DoubleLength Then
            MessageBox.Show(Me, "PVK should be a double-length key", "Incorrect PVK", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    'Async - PVV clashing worker.
    Private Sub BW_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW.DoWork
        Dim PIN As String, Account As String, PVKI As String, PVK As HexKey
        Dim sSplit() As String = Convert.ToString(e.Argument).Split(";"c)

        PIN = sSplit(0)
        Account = sSplit(1)
        PVKI = sSplit(2)
        PVK = New HexKey(sSplit(3))

        Try
            Dim PVVMap As New SortedList(Of String, Integer)
            Dim PVV As String = Utility.GeneratePVV(Account, PVKI, PIN, PVK)
            PVVCalculation = "Calculated PVV: " + PVV + vbCrLf + vbCrLf

            For i As Integer = 0 To 9999
                Dim otherPVV As String = Utility.GeneratePVV(Account, PVKI, i.ToString.PadLeft(4, "0"c), PVK)

                If PVVMap.ContainsKey(otherPVV) Then
                    PVVMap(otherPVV) += 1
                Else
                    PVVMap.Add(otherPVV, 1)
                End If

                If PVV = otherPVV Then
                    PVVCalculation += "Verified for PIN " + i.ToString.PadLeft(4, "0"c) + vbCrLf
                End If

                If i Mod 100 = 0 Then
                    BW.ReportProgress(i \ 100)
                End If
            Next

            Dim counts(10) As Integer
            For Each PVV In PVVMap.Keys
                If PVVMap(PVV) <= 10 Then
                    counts(PVVMap(PVV)) += 1
                Else
                    counts(10) += 1
                End If
            Next

            'This will show the PIN distribution for this PAN/PVK/PVKI.
            PVVCalculation += vbCrLf
            Dim sum As Double = 0
            For i As Integer = 0 To 9
                If counts(i) > 0 Then
                    PVVCalculation += i.ToString + " PIN matches: " + (i * counts(i) / 100).ToString("N2") + "%" + vbCrLf
                    sum += i * counts(i) / 100
                End If
            Next

            If counts(10) > 0 Then
                PVVCalculation += "More than 10 PIN matches: " + (100 - sum).ToString("N2") + "%"
            End If
        Catch ex As Exception
            PVVCalculation = "Error during calculation" + vbCrLf + ex.Message
        End Try

        BW.ReportProgress(100)
    End Sub

    'Update progress indicator.
    Private Sub BW_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW.ProgressChanged
        Me.Invoke(New UpdateProgress(AddressOf UpdateProgressIndicator), New Object() {e.ProgressPercentage})
    End Sub

    'Hide progress indicator and show results.
    Private Sub BW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW.RunWorkerCompleted
        Me.Invoke(New UpdateLabel(AddressOf UpdatePVVLabel), New Object() {PVVCalculation})
        Me.Invoke(New UpdateProgress(AddressOf UpdateProgressIndicator), New Object() {Int32.MaxValue})
    End Sub

    'Delegate implementation for progress indicator update.
    Private Sub UpdateProgressIndicator(ByVal progress As Integer)
        If progress = Int32.MaxValue Then
            barPVVClashing.Visible = False
            Exit Sub
        End If
        barPVVClashing.Value = progress
    End Sub

    'Delegate implementation for label update.
    Private Sub UpdatePVVLabel(ByVal status As String)
        lblPVV.Text = status
    End Sub

#End Region

#Region "CVV"

    'Generate CVV.
    Private Sub cmdGenerateCVV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateCVV.Click
        If txtCVVSVC.Text.Length <> 3 Then
            MessageBox.Show(Me, "Enter a correct service code", "Incorrect SVC", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCVVSVC.Focus()
            Exit Sub
        End If

        If txtCVVAccount.Text = "" Then
            MessageBox.Show(Me, "Enter an account number", "No account", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCVVAccount.Focus()
            Exit Sub
        End If

        If txtCVVExpDate.Text.Length <> 4 Then
            MessageBox.Show(Me, "Enter an expiration date", "Incorrect expiration date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCVVExpDate.Focus()
            Exit Sub
        End If

        If Not txtCVKPair.IsValid Then Exit Sub

        Dim CVKPair As HexKey = txtCVKPair.GetKey
        If CVKPair.KeyLength <> KeyLength.DoubleLength Then
            MessageBox.Show(Me, "CVK should be a double-length key", "Incorrect PVK", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            lblCVV.Text = "CVV: " + Utility.GenerateCVV(CVKPair, txtCVVAccount.Text, txtCVVExpDate.Text, txtCVVSVC.Text)
        Catch ex As Exception
            MessageBox.Show(Me, "Error generating CVV." + vbCrLf + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class