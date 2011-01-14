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

''' <summary>
''' This control is used to hold hexadecimal or numeric values.
''' </summary>
''' <remarks></remarks>
Public Class HexTextBox

    ''' <summary>
    ''' Fired when the text box is full.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Public Event Completed(ByVal sender As Object)

    ''' <summary>
    ''' Get/set the max length of the text box.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxLength As Integer
        Get
            Return txt.MaxLength
        End Get
        Set(ByVal value As Integer)
            txt.MaxLength = value
        End Set
    End Property

    ''' <summary>
    ''' Get/set the text horizontal alignment.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TextAlignment As HorizontalAlignment
        Get
            Return txt.TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            txt.TextAlign = value
        End Set
    End Property

    ''' <summary>
    ''' Get/set whether we accept hex characters.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AcceptHex As Boolean = True

    ''' <summary>
    ''' Get/set the text value of the control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Text() As String
        Get
            Return txt.Text
        End Get
        Set(ByVal value As String)
            txt.Text = value
        End Set
    End Property

    'When we get the focus anew, we select everything.
    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt.GotFocus
        txt.SelectAll()
    End Sub

    'Depending on the key pressed, ignore some, accept valid characters and capitalize them.
    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt.KeyPress
        If Char.IsControl(e.KeyChar) Then Exit Sub

        If Char.IsLetterOrDigit(e.KeyChar) OrElse Char.IsPunctuation(e.KeyChar) OrElse Char.IsSymbol(e.KeyChar) OrElse Char.IsWhiteSpace(e.KeyChar) OrElse Char.IsSeparator(e.KeyChar) Then
            Dim ch As Char = Char.ToUpper(e.KeyChar)

            If (Not AcceptHex AndAlso Char.IsNumber(ch)) OrElse (AcceptHex AndAlso EFTCalculator.Core.Utility.IsHex(ch)) Then
                If txt.Text.Length < txt.MaxLength Then
                    txt.AppendText(ch)
                    If txt.Text.Length = txt.MaxLength Then
                        RaiseEvent Completed(Me)
                    End If
                End If
            End If
            e.Handled = True
        End If
    End Sub

End Class
