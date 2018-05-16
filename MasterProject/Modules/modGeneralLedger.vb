Module modGeneralLedger
    Public Function GetAccountTitle(ByVal acctcode As String) As String
        GetAccountTitle = ""
        Dim strsql As String = "SELECT * from lib_acctcode WHERE Account_Code like '" & acctcode & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            GetAccountTitle = reader.Item("Account_Title")
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()
    End Function
End Module
