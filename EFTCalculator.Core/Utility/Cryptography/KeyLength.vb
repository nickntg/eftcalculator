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

Namespace Cryptography

    ''' <summary>
    ''' Key length enumeration.
    ''' </summary>
    ''' <remarks>
    ''' This is an enumeration that defines the length of a hexadecimal key.
    ''' </remarks>
    Public Enum KeyLength
        ''' <summary>
        ''' Single length keys.
        ''' </summary>
        ''' <remarks>
        ''' Defines a single length hexadecimal key (16 digits).
        ''' </remarks>
        SingleLength = 0

        ''' <summary>
        ''' Double length keys.
        ''' </summary>
        ''' <remarks>
        ''' Defines a double length hexadecimal key (32 digits).
        ''' </remarks>
        DoubleLength

        ''' <summary>
        ''' Triple length keys.
        ''' </summary>
        ''' <remarks>
        ''' Defines a triple length hexadecimal key (48 digits).
        ''' </remarks>
        TripleLength
    End Enum

End Namespace