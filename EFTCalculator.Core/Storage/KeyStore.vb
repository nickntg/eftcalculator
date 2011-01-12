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
''' This class implements a persistent key store in a clear text file.
''' </summary>
''' <remarks></remarks>
Public Class KeyStore

    Const KEYSTORAGE As String = "KEYS.TXT"

    Private Shared keys As New SortedList(Of String, StoredKey)

    ''' <summary>
    ''' Reads all keys from the storage file into memory.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ReadKeys()
        Try
            Using SR As IO.StreamReader = New IO.StreamReader(KEYSTORAGE, System.Text.Encoding.Default)
                While Not SR.EndOfStream
                    Dim s As String = SR.ReadLine
                    If s <> "" AndAlso Not s.StartsWith("'") Then
                        Dim SK As New StoredKey(s)
                        keys.Add(SK.KeyName, SK)
                    End If
                End While
            End Using
        Catch ex As Exception
            'Let this slide.
        End Try
    End Sub

    ''' <summary>
    ''' Writes all keys from memory to the storage file.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub WriteKeys()
        Using SW As IO.StreamWriter = New IO.StreamWriter(KEYSTORAGE, False, System.Text.Encoding.Default)
            For Each key As String In keys.Keys
                SW.WriteLine(keys(key).ToString)
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Returns True if a key exists, false otherwise.
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function KeyExists(ByVal keyName As String) As Boolean
        Return keys.ContainsKey(keyName)
    End Function

    ''' <summary>
    ''' Adds a new key to the key store.
    ''' </summary>
    ''' <param name="SK"></param>
    ''' <remarks></remarks>
    Public Shared Sub AddKey(ByVal SK As StoredKey)
        keys.Add(SK.KeyName, SK)
    End Sub

    ''' <summary>
    ''' Removes a key from the key store.
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <remarks></remarks>
    Public Shared Sub RemoveKey(ByVal keyName As String)
        keys.Remove(keyName)
    End Sub

    ''' <summary>
    ''' Updates a key in the key store.
    ''' </summary>
    ''' <param name="SK"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateKey(ByVal SK As StoredKey)
        keys(SK.KeyName) = SK
    End Sub

    ''' <summary>
    ''' Returns a key from the key store.
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetKey(ByVal keyName As String) As StoredKey
        Return keys(keyName)
    End Function

    ''' <summary>
    ''' Return all keys.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetKeys() As SortedList(Of String, StoredKey)
        Return keys
    End Function

    ''' <summary>
    ''' Clears the key store.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Clear()
        keys.Clear()
    End Sub

End Class
