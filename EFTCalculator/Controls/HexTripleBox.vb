Imports EFTCalculator.Core.Cryptography

Public Class HexTripleBox

    Public Overrides Property Text() As String
        Get
            Return txt1.Text + txt2.Text + txt3.Text
        End Get
        Set(ByVal value As String)
            Select Case value.Length
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

    Public Function GetKey() As HexKey
        Return New HexKey(Me.Text)
    End Function

    Public Sub Clear()
        Me.Text = ""
    End Sub

    Public Function IsValid() As Boolean
        If (Me.Text.Length Mod 16 = 0) AndAlso (Me.Text <> "") AndAlso ((txt1.Text <> "") AndAlso ((txt2.Text <> "") OrElse (txt3.Text = ""))) Then
            erProv.Clear()
            Return True
        Else
            SetError("Invalid hex value")
            Return False
        End If
    End Function

    Public Sub SetError(ByVal erStr As String)
        erProv.Clear()
        erProv.SetError(txt3, erStr)
    End Sub

    Private Sub Completed(ByVal sender As Object) Handles txt1.Completed, txt2.Completed, txt3.Completed
        If CType(sender, HexTextBox) Is txt1 Then
            txt2.Focus()
        ElseIf CType(sender, HexTextBox) Is txt2 Then
            txt3.Focus()
        Else
            txt1.Focus()
        End If
    End Sub

End Class
