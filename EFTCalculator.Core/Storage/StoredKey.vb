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
''' This class represents a stored key.
''' </summary>
''' <remarks></remarks>
Public Class StoredKey

    ''' <summary>
    ''' Name of key.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property KeyName As String

    ''' <summary>
    ''' Value of key.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property KeyValue As String

    ''' <summary>
    ''' Key comment.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property KeyComment As String

    ''' <summary>
    ''' Creates a new instance from values.
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <param name="keyValue"></param>
    ''' <param name="keyComment"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal keyName As String, ByVal keyValue As String, ByVal keyComment As String)
        Me.KeyName = keyName
        Me.KeyValue = keyValue
        Me.KeyComment = keyComment
    End Sub

    ''' <summary>
    ''' Creates a new instance from a file line.
    ''' </summary>
    ''' <param name="fileLine"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal fileLine As String)
        Dim sSplit() As String = fileLine.Split(";"c)
        Me.KeyName = sSplit(0)
        Me.KeyValue = sSplit(1)
        Me.KeyComment = sSplit(2)
    End Sub

    ''' <summary>
    ''' Returns a string representing the key as it must be written to the key file.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return KeyName + ";" + KeyValue + ";" + KeyComment
    End Function

End Class
