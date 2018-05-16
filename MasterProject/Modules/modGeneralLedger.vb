Module modGeneralLedger
    Public Function GetAccountTitle(ByVal acctcode As String) As String
        GetAccountTitle = ""
        Dim strsql As String = "SELECT * from lib_acctcode WHERE Account_Code = '" & acctcode & "'"
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
    Public Function GetSubAccountTitle(ByVal acctcode As String, ByVal subacctcode As String) As String
        GetSubAccountTitle = ""
        Dim strsql As String = "SELECT * from lib_subacctcode WHERE Account_Code = '" & acctcode & "' and SubAccount_Code = '" & subacctcode & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            GetSubAccountTitle = reader.Item("SubAccount_Title")
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()
    End Function
    Public Sub DeleteToGLTable(ByVal strRefNbr As String, ByVal intModule As Integer)
        'delete record in tbl_generalledger
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdSysParamGL As MySql.Data.MySqlClient.MySqlCommand
        Dim sqlStringGL As String = "DELETE FROM tbl_generalledger WHERE RefNbr = '" & strRefNbr & "' and ModuleCode = " & intModule & ""

        cmdSysParamGL = New MySql.Data.MySqlClient.MySqlCommand(sqlStringGL, cnn)
        cmdSysParamGL.ExecuteNonQuery()
        cmdSysParamGL.Dispose()
    End Sub

    Public Sub InsertToGLTable(ByVal intModule As Integer, ByVal strModule As String, ByVal strRefNbr As String, ByVal strAcctCode As String, ByVal strAcctName As String, ByVal strSubAcctCode As String, ByVal strSubAcctName As String, ByVal dblDR As Double, ByVal dblCR As Double, ByVal boolSubAcctDept As Boolean, ByVal strSubAcctDeptName As String, ByVal boolSubAcctList As Boolean, ByVal strSubAcctListItem As String, ByVal strSubAcctListItemName As String)
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Try

            cmdSQL.CommandText = ("INSERT INTO tbl_generalledger (`ModuleCode`, `ModuleName`, `RefNbr`, `AcctCode`, `AcctName`, `SubAcctCode`, `SubAcctName`, `DR`, `CR`, `SubAcctDept`, `SubAcctDeptName`, `SubAcctList`, `SubAcctListItem`, `SubAcctListItemName` )  VALUES " &
                                 "               (@ModuleCode, @ModuleName, @RefNbr, @AcctCode , @AcctName, @SubAcctCode, @SubAcctName, @DR, @CR, @SubAcctDept, @SubAcctDeptName, @SubAcctList, @SubAcctListItem, @SubAcctListItemName )")

            With cmdSQL.Parameters

                .AddWithValue("@ModuleCode", intModule)
                .AddWithValue("@ModuleName", strModule)
                .AddWithValue("@RefNbr", strRefNbr)
                .AddWithValue("@AcctCode", strAcctCode)
                .AddWithValue("@AcctName", strAcctName)
                .AddWithValue("@SubAcctCode", strSubAcctCode)
                .AddWithValue("@SubAcctName", strSubAcctName)
                .AddWithValue("@DR", dblDR)
                .AddWithValue("@CR", dblCR)
                .AddWithValue("SubAcctDept", boolSubAcctDept)
                .AddWithValue("SubAcctDeptName", strSubAcctDeptName)
                .AddWithValue("@SubAcctList", boolSubAcctList)
                .AddWithValue("SubAcctListItem", strSubAcctListItem)
                .AddWithValue("SubAcctListItemName", strSubAcctListItemName)
            End With

            cmdSQL.Connection = cnn
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox("There was an error trying to save transaction log - " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Public Function GetGeneralLedgerModuleName(ByVal intModule As Integer) As String
        GetGeneralLedgerModuleName = ""
        Dim strsql As String = "SELECT * from lib_generalledgermodule WHERE PK = " & intModule & ""
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            GetGeneralLedgerModuleName = reader.Item("Description")
        End While
        cmdsql.Dispose()
        reader.Close()
        cnn.Close()
    End Function

    Public Sub InsertToGLSummaryTable(ByVal strRefNo As String, ByVal dtPostCheckDate As Date, ByVal strPayee As String, ByVal strRemarks As String, ByVal strAcctTitle As String, ByVal strSubAcctTitle As String, ByVal dblDR As Double, ByVal dblCR As Double, ByVal intModule As Integer, ByVal strModule As String)
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Try

            cmdSQL.CommandText = ("INSERT INTO tbl_generalledgersummary (`RefNo`, `PostCheckDate`, `Payee`, `RemarksDescription`, `AcctTitle`, `SubAcctTitle`, `DR`, `CR`, `ModuleCode`, `ModuleName` )  VALUES " &
                                 "               (@RefNo, @PostCheckDate, @Payee, @RemarksDescription , @AcctTitle, @SubAcctTitle, @DR, @CR, @ModuleCode, @ModuleName )")

            With cmdSQL.Parameters

                .AddWithValue("@RefNo", strRefNo)
                .AddWithValue("@PostCheckDate", Format(dtPostCheckDate, "yyyy-MM-dd"))
                .AddWithValue("@Payee", strPayee)
                .AddWithValue("@RemarksDescription", strRemarks)
                .AddWithValue("@AcctTitle", strAcctTitle)
                .AddWithValue("@SubAcctTitle", strSubAcctTitle)
                .AddWithValue("@DR", dblDR)
                .AddWithValue("@CR", dblCR)
                .AddWithValue("SubAcctDept", intModule)
                .AddWithValue("SubAcctDeptName", strModule)
            End With

            cmdSQL.Connection = cnn
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox("There was an error trying to save transaction log - " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

    End Sub

    Public Sub DeleteToGLSummaryTable(ByVal strRefNbr As String, ByVal intModule As Integer)
        'delete record in tbl_generalledger
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdSysParamGL As MySql.Data.MySqlClient.MySqlCommand
        Dim sqlStringGL As String = "DELETE FROM tbl_generalledgersummary WHERE RefNo = '" & strRefNbr & "' and ModuleCode = " & intModule & ""

        cmdSysParamGL = New MySql.Data.MySqlClient.MySqlCommand(sqlStringGL, cnn)
        cmdSysParamGL.ExecuteNonQuery()
        cmdSysParamGL.Dispose()
    End Sub
End Module
