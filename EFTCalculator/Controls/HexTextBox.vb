Public Class HexTextBox

    Public Event Completed(ByVal sender As Object)

    Public Overrides Property Text() As String
        Get
            Return txt.Text
        End Get
        Set(ByVal value As String)
            txt.Text = value
        End Set
    End Property

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt.GotFocus
        txt.SelectAll()
    End Sub

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt.KeyPress
        If Char.IsControl(e.KeyChar) Then Exit Sub

        If Char.IsLetterOrDigit(e.KeyChar) OrElse Char.IsPunctuation(e.KeyChar) OrElse Char.IsSymbol(e.KeyChar) OrElse Char.IsWhiteSpace(e.KeyChar) OrElse Char.IsSeparator(e.KeyChar) Then
            Dim ch As Char = Char.ToUpper(e.KeyChar)
            If EFTCalculator.Core.Utility.IsHex(ch) Then
                If txt.Text.Length < txt.MaxLength Then
                    txt.AppendText(ch)
                    If txt.Text.Length = 16 Then
                        RaiseEvent Completed(Me)
                    End If
                End If
            End If
            e.Handled = True
        End If
    End Sub

End Class
