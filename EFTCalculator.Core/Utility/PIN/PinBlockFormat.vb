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
    ''' This enumerates the PIN block formats we know about.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum PinBlockFormat

        ''' <summary>
        ''' Ansi X9.8 format.
        ''' </summary>
        ''' <remarks></remarks>
        AnsiX98 = 0

        ''' <summary>
        ''' ISO1 format.
        ''' </summary>
        ''' <remarks></remarks>
        ISO_1

        ''' <summary>
        ''' ISO3 format.
        ''' </summary>
        ''' <remarks></remarks>
        ISO_3

        ''' <summary>
        ''' Docutel format.
        ''' </summary>
        ''' <remarks></remarks>
        Docutel

        ''' <summary>
        ''' Diebold format.
        ''' </summary>
        ''' <remarks></remarks>
        Diebold

        ''' <summary>
        ''' Plus network format.
        ''' </summary>
        ''' <remarks></remarks>
        Plus

        ''' <summary>
        ''' IBM 4704 format.
        ''' </summary>
        ''' <remarks></remarks>
        IBM_4704

        ''' <summary>
        ''' IBM 3621 format.
        ''' </summary>
        ''' <remarks></remarks>
        IBM_3621

        ''' <summary>
        ''' IBM 3624 format.
        ''' </summary>
        ''' <remarks></remarks>
        IBM_3624

    End Enum

End Namespace