Module modGlobalFunction

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

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        cmdSQL.Connection = cnnDBMaster
        cmdSQL.CommandText = "SELECT NOW()as CurrentDateTime"

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            dtTemp = reader.Item("CurrentDateTime")
        End While

        reader.Close()
        cmdSQL.Dispose()

        Return dtTemp
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
End Module
