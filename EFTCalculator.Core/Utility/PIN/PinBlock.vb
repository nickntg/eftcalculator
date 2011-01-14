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
    ''' This class is used to construct PIN blocks and find PINs of PIN blocks.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PinBlock

        ''' <summary>
        ''' Returns the PIN block info requirements based on PIN block format.
        ''' </summary>
        ''' <param name="PBFormat"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetPINBlockRequirements(ByVal PBFormat As PinBlockFormat) As PinBlockRequirements
            Select Case PBFormat
                Case PinBlockFormat.AnsiX98
                    Return New PinBlockRequirements(False, True)
                Case PinBlockFormat.Diebold
                    Return New PinBlockRequirements(False, False)
                Case PinBlockFormat.Docutel
                    Return New PinBlockRequirements(True, False)
                Case PinBlockFormat.IBM_3621
                    Return New PinBlockRequirements(True, False)
                Case PinBlockFormat.IBM_3624
                    Return New PinBlockRequirements(False, False)
                Case PinBlockFormat.IBM_4704
                    Return New PinBlockRequirements(False, False)
                Case PinBlockFormat.ISO_1
                    Return New PinBlockRequirements(False, False)
                Case PinBlockFormat.ISO_3
                    Return New PinBlockRequirements(False, True)
                Case PinBlockFormat.Plus
                    Return New PinBlockRequirements(False, True)
                Case Else
                    Throw New InvalidOperationException("Invalid PIN Block Format code")
            End Select
        End Function

        ''' <summary>
        ''' Construct a PIN block.
        ''' </summary>
        ''' <param name="PBFormat"></param>
        ''' <param name="PIN"></param>
        ''' <param name="Padding"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ToPINBlock(ByVal PBFormat As PinBlockFormat, ByVal PIN As String, ByVal Padding As String, ByVal Account As String) As String
            Select Case PBFormat
                Case PinBlockFormat.AnsiX98
                    Return FormatPINBlock_AnsiX98(PIN, Account)
                Case PinBlockFormat.Diebold
                    Return FormatPINBlock_Diebold(PIN)
                Case PinBlockFormat.Docutel
                    Return FormatPINBlock_Docutel(PIN, Padding)
                Case PinBlockFormat.IBM_3621
                    Return FormatPINBlock_IBM3621(PIN, Padding)
                Case PinBlockFormat.IBM_3624
                    Return FormatPINBlock_Diebold(PIN)
                Case PinBlockFormat.IBM_4704
                    Return FormatPINBlock_IBM4704(PIN)
                Case PinBlockFormat.ISO_1
                    Return FormatPINBlock_ISO1(PIN)
                Case PinBlockFormat.ISO_3
                    Return FormatPINBlock_ISO3(PIN, Account)
                Case PinBlockFormat.Plus
                    Return FormatPINBlock_Plus(PIN, Account)
                Case Else
                    Throw New InvalidOperationException("Invalid PIN Block Format code")
            End Select
        End Function

        ''' <summary>
        ''' Find a PIN from a PIN block.
        ''' </summary>
        ''' <param name="PBFormat"></param>
        ''' <param name="PINBlock"></param>
        ''' <param name="Padding"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ToPIN(ByVal PBFormat As PinBlockFormat, ByVal PINBlock As String, ByVal Padding As String, ByVal Account As String) As String
            Select Case PBFormat
                Case PinBlockFormat.AnsiX98
                    Return GetPIN_AnsiX98(PINBlock, Account)
                Case PinBlockFormat.Diebold
                    Return GetPIN_Diebold(PINBlock)
                Case PinBlockFormat.Docutel
                    Return GetPIN_Docutel(PINBlock, Padding)
                Case PinBlockFormat.IBM_3621
                    Return GetPIN_IBM3621(PINBlock, Padding)
                Case PinBlockFormat.IBM_3624
                    Return GetPIN_Diebold(PINBlock)
                Case PinBlockFormat.IBM_4704
                    Return GetPIN_IBM4704(PINBlock)
                Case PinBlockFormat.ISO_1
                    Return GetPIN_ISO1(PINBlock)
                Case PinBlockFormat.ISO_3
                    Return GetPIN_ISO3(PINBlock, Account)
                Case PinBlockFormat.Plus
                    Return GetPIN_Plus(PINBlock, Account)
                Case Else
                    Throw New InvalidOperationException("Invalid PIN Block Format code")
            End Select
        End Function

        ''' <summary>
        ''' Construct PIN block for Ansi X9.8.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_AnsiX98(ByVal PIN As String, ByVal Account As String) As String
            Return Utility.XORHex((PIN.Length.ToString.PadLeft(2, "0"c) + PIN).PadRight(16, "F"c), GetProperAccountDigits(Account).PadLeft(16, "0"c))
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for Ansi X9.8.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_AnsiX98(ByVal PINBlock As String, ByVal Account As String) As String
            Dim unXor As String = Utility.XORHex(PINBlock, GetProperAccountDigits(Account).PadLeft(16, "0"c))
            Return unXor.Substring(2, Convert.ToInt32(unXor.Substring(0, 2)))
        End Function

        ''' <summary>
        ''' Construct PIN block for Diebold.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_Diebold(ByVal PIN As String) As String
            Return PIN.PadRight(16, "F"c)
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for Diebold.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_Diebold(ByVal PINBlock As String) As String
            Return PINBlock.Replace("F", "")
        End Function

        ''' <summary>
        ''' Construct PIN block for Docutel.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <param name="Padding"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_Docutel(ByVal PIN As String, ByVal Padding As String) As String
            If PIN.Length > 6 Then
                Throw New InvalidOperationException("Docutel PIN length must not be greater than 6")
            End If

            Dim PINChars As String = PIN.Length.ToString + PIN.PadRight(6, "0"c)
            Return PINChars + Padding.Substring(0, 16 - PINChars.Length)
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for Docutel.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <param name="Padding"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_Docutel(ByVal PINBlock As String, ByVal Padding As String) As String
            Return PINBlock.Substring(1, Convert.ToInt32(PINBlock.Substring(0, 1)))
        End Function

        ''' <summary>
        ''' Construct PIN block for IBM 3621.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <param name="Padding"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_IBM3621(ByVal PIN As String, ByVal Padding As String) As String
            If PIN.Length <= 12 Then
                Return ("1234" + PIN).PadRight(16, Padding.Chars(0))
            Else
                Return "1234" + PIN.Substring(0, 12)
            End If
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for IBM 3621.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <param name="Padding"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_IBM3621(ByVal PINBlock As String, ByVal Padding As String) As String
            Return PINBlock.Substring(4).Replace(Padding.Chars(0), "")
        End Function

        ''' <summary>
        ''' Construct PIN block for IBM 4704.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_IBM4704(ByVal PIN As String) As String
            Dim PINChars As String = PIN.Length.ToString + PIN
            Return PINChars.PadRight(14, "F"c) + "12"
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for IBM 4704.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_IBM4704(ByVal PINBlock As String) As String
            Return PINBlock.Substring(1, Convert.ToInt32(PINBlock.Substring(0, 1)))
        End Function

        ''' <summary>
        ''' Construct PIN block for ISO1.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_ISO1(ByVal PIN As String) As String
            Dim PINChars As String = "1" + PIN.Length.ToString + PIN
            Dim RandomChars As String = Utility.CreateRandomKey(Cryptography.KeyLength.SingleLength)
            Return PINChars + RandomChars.Substring(0, 16 - PINChars.Length)
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for ISO1.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_ISO1(ByVal PINBlock As String) As String
            Return PINBlock.Substring(2, Convert.ToInt32(PINBlock.Substring(1, 1)))
        End Function

        ''' <summary>
        ''' Construct PIN block for ISO3.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_ISO3(ByVal PIN As String, ByVal Account As String) As String
            Dim PINChars As String = "3" + PIN.Length.ToString + PIN
            Dim RandomChars As String = Utility.CreateRandomKey(Cryptography.KeyLength.SingleLength)
            Return Utility.XORHex(PINChars + RandomChars.Substring(0, 16 - PINChars.Length), GetProperAccountDigits(Account).PadLeft(16, "0"c))
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for ISO3.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_ISO3(ByVal PINBlock As String, ByVal Account As String) As String
            Dim unXor As String = Utility.XORHex(PINBlock, GetProperAccountDigits(Account).PadLeft(16, "0"c))
            Return unXor.Substring(2, Convert.ToInt32(unXor.Substring(1, 1)))
        End Function

        ''' <summary>
        ''' Construct PIN block for Plus.
        ''' </summary>
        ''' <param name="PIN"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function FormatPINBlock_Plus(ByVal PIN As String, ByVal Account As String) As String
            Dim PINChars As String = "0" + PIN.Length.ToString + PIN
            Return Utility.XORHex(PINChars.PadRight(16, "F"c), "0000" + Account.Substring(0, 12))
        End Function

        ''' <summary>
        ''' Get PIN from PIN block for Plus.
        ''' </summary>
        ''' <param name="PINBlock"></param>
        ''' <param name="Account"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetPIN_Plus(ByVal PINBlock As String, ByVal Account As String) As String
            Dim unXor As String = Utility.XORHex(PINBlock, "0000" + Account.Substring(0, 12))
            Return unXor.Substring(2, Convert.ToInt32(unXor.Substring(1, 1)))
        End Function

        Private Shared Function GetProperAccountDigits(ByVal account As String) As String
            Return account.Substring(account.Length - 12 - 1, 12)
        End Function

    End Class

End Namespace