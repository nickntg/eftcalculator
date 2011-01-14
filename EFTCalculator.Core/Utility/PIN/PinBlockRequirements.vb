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

Namespace PIN

    ''' <summary>
    ''' This class is used to describe the information required
    ''' to construct a PIN block.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PinBlockRequirements

        Property RequiresPadding As Boolean

        Property RequiresAccount As Boolean

        Public Sub New(ByVal RequiresPadding As Boolean, ByVal RequiresAccount As Boolean)
            Me.RequiresAccount = RequiresAccount
            Me.RequiresPadding = RequiresPadding
        End Sub

    End Class

End Namespace