Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Module modGlobalFunction
    Public strCurrentUser As String = ""
    Public strSiteCode As String = "MNL"
    Public strCompanyCode = ""


    Public Function GetHostIP(ByVal af As System.Net.Sockets.AddressFamily) As String

        Dim host As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim strRet As String = ""

        For Each ip As System.Net.IPAddress In host.AddressList
            If ip.AddressFamily = af Then
                strRet = ip.ToString
                Exit For
            End If
        Next

        Return strRet

    End Function

    Public Function GetClientAddress(ByVal strClientCode As String) As String
        GetClientAddress = ""

        Try
            Dim strTemp As String
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT Addr1, CityDesc, CountryDesc FROM v_client WHERE Code = @Code"
            cmdSQL.Parameters.AddWithValue("@Code", strClientCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                strTemp = Trim(CStr(reader.Item("Addr1") & " " & reader.Item("CityDesc") & " " & reader.Item("CountryDesc")).ToUpper)
                GetClientAddress = System.Text.RegularExpressions.Regex.Replace(strTemp, "\s{2,}", " ")
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function _NotNull(Of T)(ByVal Value As T, ByVal DefaultValue As T) As T
        If Value Is Nothing OrElse IsDBNull(Value) Then
            Return DefaultValue
        Else
            Return Value
        End If
    End Function

    Public Function GetServerDate() As Date
        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim dtTemp As New Date
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        cmdSQL.Connection = cnn
        cmdSQL.CommandText = "SELECT NOW()as CurrentDateTime"

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            dtTemp = reader.Item("CurrentDateTime")
        End While

        reader.Close()
        cmdSQL.Dispose()

        Return dtTemp
    End Function

    'Public Sub FillComboBox(ByVal cbo As ComboBox, ByVal strSQL As String, ByVal strFieldName As String)

    '    cbo.Items.Clear()

    '    Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

    '    If cnn.State <> ConnectionState.Open Then cnn.Open()

    '    Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


    '    While reader.Read
    '        cbo.Items.Add(reader.Item(strFieldName))
    '    End While

    '    cmd.Dispose()
    '    reader.Close()
    '    cnn.Close()

    'End Sub
    'Public Function GetStringValue(ByVal strSQL As String, ByVal strFieldName As String) As String

    '    GetStringValue = ""

    '    Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

    '    If cnn.State <> ConnectionState.Open Then cnn.Open()

    '    Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


    '    While reader.Read
    '        GetStringValue = reader.Item(strFieldName)
    '    End While

    '    cmd.Dispose()
    '    reader.Close()
    '    cnn.Close()

    'End Function

    'Public Function GetIntegerValue(ByVal strSQL As String, ByVal strFieldName As String) As Integer

    '    GetIntegerValue = 0

    '    Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

    '    If cnn.State <> ConnectionState.Open Then cnn.Open()

    '    Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


    '    While reader.Read
    '        GetIntegerValue = reader.Item(strFieldName)
    '    End While

    '    cmd.Dispose()
    '    reader.Close()
    '    cnn.Close()

    'End Function

    Public Function EncryptString(ByVal InString As String, ByVal EncryptKey As String) As String

        Dim TempKey As String = "", OutString As String = ""
        Dim OldChar As Integer, NewChar As Integer, CryptChar As Integer
        Dim i As Integer

        'Initilize i and make sure the EncryptKey is long enough
        i = 0

        Do
            TempKey = TempKey + EncryptKey
        Loop While Len(TempKey) < Len(InString)

        'Loop through the string to encrypt each character.
        Do
            i = i + 1
            OldChar = Asc(Mid$(InString, i, 1))
            CryptChar = Asc(Mid$(TempKey, i, 1))

            Select Case i Mod 2
                Case 0
                    NewChar = OldChar + CryptChar
                    If NewChar > 127 Then
                        NewChar = NewChar - 127
                    End If
                Case Else
                    NewChar = OldChar - CryptChar
                    If NewChar < 0 Then
                        NewChar = NewChar + 127
                    End If
            End Select

            If NewChar < 35 Then
                OutString = OutString + "!" + Chr(NewChar + 40)
            Else
                OutString = OutString + Chr(NewChar)
            End If

        Loop Until i = Len(InString)
        'pass encrypted value to string
        EncryptString = OutString
    End Function

    Public Function DecryptString(ByVal InString As String, ByVal EncryptKey As String) As String
        Dim TempKey As String = "", OutString As String = ""
        Dim OldChar As Integer, NewChar As Integer, CryptChar As Integer
        Dim i, c As Integer

        'Initialize c and i (loop variables)
        c = 0
        i = 0

        Do
            TempKey = TempKey + EncryptKey
        Loop While Len(TempKey) < Len(InString)

        Do
            i = i + 1
            c = c + 1
            OldChar = Asc(Mid$(InString, c, 1))

            If OldChar = 33 Then
                c = c + 1
                OldChar = Asc(Mid$(InString, c, 1))
                OldChar = OldChar - 40
            End If

            CryptChar = Asc(Mid$(TempKey, i, 1))

            Select Case i Mod 2
                Case 0      'Even Character
                    NewChar = OldChar - CryptChar
                    If NewChar < 0 Then
                        NewChar = NewChar + 127
                    End If
                Case Else
                    NewChar = OldChar + CryptChar
                    If NewChar > 127 Then
                        NewChar = NewChar - 127
                    End If
            End Select

            OutString = OutString + Chr(NewChar)

        Loop Until c = Len(InString)

        'pass decryted value to string
        DecryptString = OutString
    End Function

    Public Sub FillComboBox(ByVal cbo As ComboBox, ByVal strSQL As String, ByVal strFieldName As String)

        cbo.Items.Clear()

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


        While reader.Read
            cbo.Items.Add(reader.Item(strFieldName))
        End While

        cmd.Dispose()
        reader.Close()
        cnn.Close()

    End Sub
    Public Function GetStringValue(ByVal strSQL As String, ByVal strFieldName As String) As String

        GetStringValue = ""

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


        While reader.Read
            GetStringValue = reader.Item(strFieldName)
        End While

        cmd.Dispose()
        reader.Close()
        cnn.Close()

    End Function
    Public Function GetDoubleValue(ByVal strSQL As String, ByVal strFieldName As String) As Double

        GetDoubleValue = 0

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


        While reader.Read
            GetDoubleValue = reader.Item(strFieldName)
        End While

        cmd.Dispose()
        reader.Close()
        cnn.Close()

    End Function
    Public Function GetIntegerValue(ByVal strSQL As String, ByVal strFieldName As String) As Integer

        GetIntegerValue = 0

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


        While reader.Read
            GetIntegerValue = reader.Item(strFieldName)
        End While

        cmd.Dispose()
        reader.Close()
        cnn.Close()

    End Function

    Function English(ByVal n As Decimal, Optional ByVal CurrencyName As String = "") As String
        Const Thousand = 1000@
        Const Million = Thousand * Thousand
        Const Billion = Thousand * Million
        Const Trillion = Thousand * Billion

        If (n = 0) Then English = "zero" : Exit Function

        Dim Buf As String
        Dim Frac As Decimal
        Dim AtLeastOne As Integer

        AtLeastOne = n >= 1
        If (n < 0) Then Buf = "negative " Else Buf = ""
        Frac = Math.Abs(n - Fix(n))
        If (n < 0 Or Frac <> 0) Then n = Math.Abs(Fix(n))

        If (n >= Trillion) Then
            'Debug.Print n
            Buf = Buf & EnglishDigitGroup(Int(n / Trillion)) & " trillion"
            n = n - Int(n / Trillion) * Trillion ' Mod overflows
            If (n >= 1) Then Buf = Buf & " "
        End If

        If (n >= Billion) Then
            'Debug.Print n
            Buf = Buf & EnglishDigitGroup(Int(n / Billion)) & " billion"
            n = n - Int(n / Billion) * Billion ' Mod still overflows
            If (n >= 1) Then Buf = Buf & " "
        End If

        If (n >= Million) Then
            'Debug.Print n
            Buf = Buf & EnglishDigitGroup(n \ Million) & " million"
            n = n Mod Million
            If (n >= 1) Then Buf = Buf & " "
        End If

        If (n >= Thousand) Then
            'Debug.Print n
            Buf = Buf & EnglishDigitGroup(n \ Thousand) & " thousand"
            n = n Mod Thousand
            If (n >= 1) Then Buf = Buf & " "
        End If

        If (n >= 1) Then
            'Debug.Print n
            Buf = Buf & EnglishDigitGroup(n)
        End If

        If (Frac = 0) Then
            'Buf = Buf & " exactly"
            Buf = Buf
        ElseIf (Int(Frac * 100) = Frac * 100) Then
            If AtLeastOne Then Buf = Buf & " and "
            Buf = Buf & Format$(Frac * 100, "00") & "/100"
        Else
            If AtLeastOne Then Buf = Buf & " and "
            Buf = Buf & Format$(Frac * 10000, "0000") & "/10000"
        End If

        Buf = StrConv(Buf, vbProperCase)

        If Not CurrencyName = "" Then
            English = Buf & " " & CurrencyName & " Only"
        Else
            English = Buf & " Pesos Only"
        End If

    End Function

    Private Function EnglishDigitGroup(ByVal n As Integer) As String
        Const Hundred = " hundred"
        Const One = "one"
        Const Two = "two"
        Const Three = "three"
        Const Four = "four"
        Const Five = "five"
        Const Six = "six"
        Const Seven = "seven"
        Const Eight = "eight"
        Const Nine = "nine"
        Dim Buf As String : Buf = ""
        Dim Flag As Integer : Flag = False

        'Do hundreds
        Select Case (n \ 100)
            Case 0 : Buf = "" : Flag = False
            Case 1 : Buf = One & Hundred : Flag = True
            Case 2 : Buf = Two & Hundred : Flag = True
            Case 3 : Buf = Three & Hundred : Flag = True
            Case 4 : Buf = Four & Hundred : Flag = True
            Case 5 : Buf = Five & Hundred : Flag = True
            Case 6 : Buf = Six & Hundred : Flag = True
            Case 7 : Buf = Seven & Hundred : Flag = True
            Case 8 : Buf = Eight & Hundred : Flag = True
            Case 9 : Buf = Nine & Hundred : Flag = True
        End Select

        If (Flag <> False) Then n = n Mod 100
        If (n > 0) Then
            If (Flag <> False) Then Buf = Buf & " "
        Else
            EnglishDigitGroup = Buf
            Exit Function
        End If

        Select Case (n \ 10)
            Case 0, 1 : Flag = False
            Case 2 : Buf = Buf & "twenty" : Flag = True
            Case 3 : Buf = Buf & "thirty" : Flag = True
            Case 4 : Buf = Buf & "forty" : Flag = True
            Case 5 : Buf = Buf & "fifty" : Flag = True
            Case 6 : Buf = Buf & "sixty" : Flag = True
            Case 7 : Buf = Buf & "seventy" : Flag = True
            Case 8 : Buf = Buf & "eighty" : Flag = True
            Case 9 : Buf = Buf & "ninety" : Flag = True
        End Select

        If (Flag <> False) Then n = n Mod 10
        If (n > 0) Then
            If (Flag <> False) Then Buf = Buf & "-"
        Else
            EnglishDigitGroup = Buf
            Exit Function
        End If

        Select Case (n)
            Case 0 ' do nothing
            Case 1 : Buf = Buf & One
            Case 2 : Buf = Buf & Two
            Case 3 : Buf = Buf & Three
            Case 4 : Buf = Buf & Four
            Case 5 : Buf = Buf & Five
            Case 6 : Buf = Buf & Six
            Case 7 : Buf = Buf & Seven
            Case 8 : Buf = Buf & Eight
            Case 9 : Buf = Buf & Nine
            Case 10 : Buf = Buf & "ten"
            Case 11 : Buf = Buf & "eleven"
            Case 12 : Buf = Buf & "twelve"
            Case 13 : Buf = Buf & "thirteen"
            Case 14 : Buf = Buf & "fourteen"
            Case 15 : Buf = Buf & "fifteen"
            Case 16 : Buf = Buf & "sixteen"
            Case 17 : Buf = Buf & "seventeen"
            Case 18 : Buf = Buf & "eighteen"
            Case 19 : Buf = Buf & "nineteen"
        End Select

        EnglishDigitGroup = Buf
    End Function
    Public Sub FillGridComboBox(ByVal cbo As DataGridViewComboBoxColumn, ByVal strSQL As String, ByVal strFieldName As String)

        cbo.Items.Clear()

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()


        While reader.Read
            cbo.Items.Add(reader.Item(strFieldName))
        End While

        cmd.Dispose()
        reader.Close()
        cnn.Close()

    End Sub

    Public Enum MyOption
        Alpha = 1
        AlphaNumeric = 2
        Numeric = 3
    End Enum

    Public Sub SetCharacter(ByVal CharacterOption As MyOption, ByVal kp As KeyPressEventArgs)
        Select Case CharacterOption
            Case MyOption.Alpha
                If Not (
                    kp.KeyChar Like "[A-Z]" Or
                    kp.KeyChar Like "[a-z]" Or
                    kp.KeyChar = vbBack Or
                    Asc(kp.KeyChar) = 32) Then
                    kp.KeyChar = vbNullChar
                End If
            Case MyOption.AlphaNumeric
                If Not (
                        kp.KeyChar Like "[A-Z]" Or
                        kp.KeyChar Like "[a-z]" Or
                        kp.KeyChar Like "[ñÑ]" Or
                        kp.KeyChar Like "[0-9]" Or
                        kp.KeyChar Like "." Or
                        kp.KeyChar = vbBack Or
                        Asc(kp.KeyChar) = 32) Then
                    kp.KeyChar = vbNullChar
                End If
            Case MyOption.Numeric
                If Not (
                     kp.KeyChar Like "[0-9]" Or
                     kp.KeyChar = vbBack Or
                     kp.KeyChar Like "." Or
                     kp.KeyChar Like "[-]" Or
                     Asc(kp.KeyChar) = 32) Then
                    kp.KeyChar = vbNullChar
                End If
        End Select

    End Sub

    Public Class WatermarkTextBox
        Inherits TextBox

        Private NotInheritable Class NativeMethods
            Private Sub New()
            End Sub

            Private Const ECM_FIRST As UInteger = &H1500
            Friend Const EM_SETCUEBANNER As UInteger = ECM_FIRST + 1

            <DllImport("user32.dll", EntryPoint:="SendMessageW")>
            Public Shared Function SendMessageW(hWnd As IntPtr, Msg As UInt32, wParam As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> lParam As String) As IntPtr
            End Function
        End Class

        Private _watermark As String
        Public Property Watermark() As String
            Get
                Return _watermark
            End Get
            Set(value As String)
                _watermark = value
                UpdateWatermark()
            End Set
        End Property

        Private Sub UpdateWatermark()
            If IsHandleCreated AndAlso _watermark IsNot Nothing Then
                NativeMethods.SendMessageW(Handle, NativeMethods.EM_SETCUEBANNER, CType(1, IntPtr), _watermark)
            End If
        End Sub

        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            MyBase.OnHandleCreated(e)
            UpdateWatermark()
        End Sub

    End Class


    Private Const ECM_FIRST As UInteger = &H1500
    Private Const EM_SETCUEBANNER As UInteger = ECM_FIRST + 1

    <DllImport("user32.dll", EntryPoint:="SendMessageW")>
    Private Function SendMessageW(hWnd As IntPtr, Msg As UInt32, wParam As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> lParam As String) As IntPtr
    End Function

    <Extension()>
    Public Sub SetWaterMark(tb As TextBox, watermark As String)
        SendMessageW(tb.Handle, EM_SETCUEBANNER, 0, watermark)
    End Sub

    Public Function GetPCVFundKeyAIS(ByVal str As String) As String
        Dim mySelectQuery As String
        Dim ds As DataSet = New DataSet
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        Try
            mySelectQuery = "SELECT * " &
                            "FROM lib_pcv_fund " &
                            "WHERE lib_pcv_fund.FundCode ='" & str & "'"

            If cnn.State <> ConnectionState.Open Then cnn.Open()

            Dim myDataAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
            myDataAdapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(mySelectQuery, cnn)

            'Dim cb As MySql.Data.MySqlClient.MySqlCommandBuilder = New MySql.Data.MySqlClient.MySqlCommandBuilder(myDataAdapter)

            myDataAdapter.Fill(ds, "lib_pcv_fund")

            GetPCVFundKeyAIS = ds.Tables("lib_pcv_fund").Rows(0).Item("FundCode") & ds.Tables("lib_pcv_fund").Rows(0).Item("FundKey")
            ds.Tables("lib_pcv_fund").Rows(0).BeginEdit()
            ds.Tables("lib_pcv_fund").Rows(0).Item("FundKey") = ds.Tables("lib_pcv_fund").Rows(0).Item("FundKey") + 1
            ds.Tables("lib_pcv_fund").Rows(0).EndEdit()
            'ds.Tables("ap_sysparams").Rows(0).AcceptChanges()

            ' Code to modify data in DataSet here 
            ' Without the MySqlCommandBuilder this line would fail.
            'myDataAdapter.Update(ds, "ap_sysparams")

            'update using dataset does not function as expected so temporary use the command function
            Dim cmd As MySql.Data.MySqlClient.MySqlCommand
            mySelectQuery = "UPDATE lib_pcv_fund SET lib_pcv_fund.FundKey =  " & ds.Tables("lib_pcv_fund").Rows(0).Item("FundKey") & " WHERE lib_pcv_fund.FundCode = '" & str & "'"


            cmd = New MySql.Data.MySqlClient.MySqlCommand(mySelectQuery, cnn)
            cmd.ExecuteNonQuery()

            cmd.Dispose()

        Catch ex As Exception
            ' Reject DataSet changes
            Return ""
            'GetCheckRequestNbr = 0
            ds.RejectChanges()

            ' An error occurred. Show the error message
            MsgBox(ex.Message)
        End Try


    End Function
    Public Function GetBooleanField(ByVal strSQL As String, ByVal strField As String) As Boolean
        GetBooleanField = False
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader
        While reader.Read()
            If IsDBNull(reader.Item("" & strField & "")) Then
                GetBooleanField = False
            End If
            GetBooleanField = reader.Item("" & strField & "")
        End While
        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Function

    Public Function GetFirstDayOfWeek(ByVal dtToday As Date) 'MONDAY OF CURRENT WEEK
        Dim intDiff As Integer = dtToday.DayOfWeek - DayOfWeek.Monday
        GetFirstDayOfWeek = dtToday.AddDays(-intDiff)
    End Function

    Public Function GetLastDayOfWeek(ByVal dtToday As Date) 'SUNDAY OF NEXT WEEK
        Dim intDiff As Integer = dtToday.DayOfWeek - DayOfWeek.Saturday
        GetLastDayOfWeek = dtToday.AddDays((-intDiff) + 1)
    End Function

    Public Sub ShowChildForm(ByVal frmTemp As System.Windows.Forms.Form)
        frmTemp.MdiParent = mdiMain
        frmTemp.Show()
        frmTemp.WindowState = FormWindowState.Maximized
        frmTemp.Focus()
    End Sub

    Public Function CompareFiles(ByVal file1FullPath As String, ByVal file2FullPath As String) As Boolean

        If Not System.IO.File.Exists(file1FullPath) Or Not System.IO.File.Exists(file2FullPath) Then
            'One or both of the files does not exist.
            Return False
        End If

        If file1FullPath = file2FullPath Then
            ' fileFullPath1 and fileFullPath2 points to the same file...
            Return True
        End If

        Try
            Dim file1Hash As String = hashFile(file1FullPath)
            Dim file2Hash As String = hashFile(file2FullPath)

            If file1Hash = file2Hash Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function hashFile(ByVal filepath As String) As String
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim hash() As Byte = md5.ComputeHash(reader)
                Return System.Text.Encoding.Unicode.GetString(hash)
            End Using
        End Using
    End Function

    Public Function GetGreeting() As String
        Dim dtCurrent As Date = GetServerDate()

        If dtCurrent.Hour < 12 Then
            Return "Good Morning."
        ElseIf dtCurrent.Hour <= 17 Then
            Return "Good Afternoon"
        Else
            Return "Good Evening"
        End If
    End Function

    Public Function UpperFirstLetter(ByVal strVal As String) As String
        Dim strSentence As String() = Split(strVal, " ")
        Dim strTemp As String = ""

        For Each strWord As String In strSentence
            strTemp = strTemp & Mid(strWord, 1, 1).ToUpper & Mid(strWord, 2, Len(strWord) - 1).ToLower & " "
        Next

        Return Trim(strTemp)
    End Function

    Public Function FormalText(ByVal strVal As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(Trim(strVal), "\s{2,}", " ")
    End Function

    Public Function GetRegisteredFormNo(ByVal intGroupID As Integer, ByVal intModuleID As Integer) As Integer
        GetRegisteredFormNo = 0
        Try
            Dim intTemp As Integer = 0
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
            Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
            If cnn.State <> ConnectionState.Open Then cnn.Open()
            cmdSQL.Connection = cnnDBMaster

            cmdSQL.CommandText = "SELECT MIN(reg_no) AS FormNo FROM reg_trn_main " &
                                "WHERE reg_group = @reg_group AND reg_module = @reg_module " &
                                    "AND reg_status = 2"

            cmdSQL.Parameters.AddWithValue("@reg_group", intGroupID)
            cmdSQL.Parameters.AddWithValue("@reg_module", intModuleID)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                If Not IsDBNull(reader.Item("FormNo")) Then
                    intTemp = reader.Item("FormNo")
                Else
                    intTemp = -1
                End If
            End While

            reader.Close()
            cmdSQL.Dispose()

            GetRegisteredFormNo = intTemp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Module
