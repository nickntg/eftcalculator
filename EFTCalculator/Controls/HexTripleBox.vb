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

''' <summary>
''' This control displays three hex text boxes together.
''' Used to display a single, double or triple length key or data.
''' </summary>
''' <remarks></remarks>
Public Class HexTripleBox

    ''' <summary>
    ''' Determines whether the load key command is available.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowLoadKey As Boolean
        Get
            Return cmdLoadKey.Visible
        End Get
        Set(ByVal value As Boolean)
            cmdLoadKey.Visible = value
        End Set
    End Property

    ''' <summary>
    ''' Determines whether the random key command is available.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowGenerateKey As Boolean
        Get
            Return cmdRandomKey.Visible
        End Get
        Set(ByVal value As Boolean)
            cmdRandomKey.Visible = value
        End Set
    End Property

    ''' <summary>
    ''' Get/set the text value of this control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Text() As String
        Get
            Return txt1.Text + txt2.Text + txt3.Text
        End Get
        Set(ByVal value As String)
            Select Case value.Length
                Case 0
                    txt1.Text = ""
                    txt2.Text = ""
                    txt3.Text = ""
                Case 16
                    txt1.Text = value
                    txt2.Text = ""
                    txt3.Text = ""
                Case 32
                    txt1.Text = value.Substring(0, 16)
                    txt2.Text = value.Substring(16)
                    txt3.Text = ""
                Case Else
                    txt1.Text = value.Substring(0, 16)
                    txt2.Text = value.Substring(16, 16)
                    txt3.Text = value.Substring(32)
            End Select
        End Set
    End Property

    ''' <summary>
    ''' Return the hexadecimal key corresponding to the text of this instance.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetKey() As HexKey
        Return New HexKey(Me.Text)
    End Function

    ''' <summary>
    ''' Clear the key/data text.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        Me.Text = ""
    End Sub

    ''' <summary>
    ''' Returns True if the key/data is valid, False otherwise.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValid() As Boolean
        If (Me.Text.Length Mod 16 = 0) AndAlso (Me.Text <> "") AndAlso ((txt1.Text <> "") AndAlso ((txt2.Text <> "") OrElse (txt3.Text = ""))) Then
            erProv.Clear()
            Return True
        Else
            SetError("Invalid hex value")
            Return False
        End If
    End Function

    ''' <summary>
    ''' Display a specific error.
    ''' </summary>
    ''' <param name="erStr"></param>
    ''' <remarks></remarks>
    Public Sub SetError(ByVal erStr As String)
        erProv.Clear()
        erProv.SetError(txt3, erStr)
    End Sub

    'Hand the completion event of the hex text boxes and advance the focus accordingly.
    Private Sub Completed(ByVal sender As Object) Handles txt1.Completed, txt2.Completed, txt3.Completed
        If CType(sender, HexTextBox) Is txt1 Then
            txt2.Focus()
        ElseIf CType(sender, HexTextBox) Is txt2 Then
            txt3.Focus()
        Else
            txt1.Focus()
        End If
    End Sub

    'Show the context menu.
    Private Sub cmdRandomKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRandomKey.Click
        btnMenu.Show(cmdRandomKey, 10, 20)
    End Sub

    'Random 16-hex.
    Private Sub SinglelengthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SinglelengthToolStripMenuItem.Click
        Me.Text = Utility.CreateRandomKey(KeyLength.SingleLength)
    End Sub

    'Random 32-hex.
    Private Sub DoublelengthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoublelengthToolStripMenuItem.Click
        Me.Text = Utility.CreateRandomKey(KeyLength.DoubleLength)
    End Sub

    'Random 48-hex.
    Private Sub TriplelengthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriplelengthToolStripMenuItem.Click
        Me.Text = Utility.CreateRandomKey(KeyLength.TripleLength)
    End Sub

    'Load a key in menu strip.
    Private Sub cmdLoadKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadKey.Click
        keysMenuStrip.Items.Clear()
        For Each key As String In KeyStore.GetKeys.Keys
            Dim SK As StoredKey = KeyStore.GetKey(key)
            keysMenuStrip.Items.Add(SK.KeyName + " --> " + SK.KeyValue, Nothing, AddressOf KeyClicked)
        Next

        keysMenuStrip.Show(cmdLoadKey, 10, 20)
    End Sub

    'Load key from menu strip item to text boxes.
    Private Sub KeyClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim txt As String = CType(sender, ToolStripMenuItem).Text
        Me.Text = txt.Substring(txt.IndexOf(" --> ") + 5)
    End Sub

End Class
