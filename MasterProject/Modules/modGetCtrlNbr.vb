Imports MySql.Data.MySqlClient
Module modGetCtrlNbr
    Public Function GetCtrlNbr(ByVal strCompanyCode As String, ByVal strSiteCode As String, ByVal strDesc As String) As String
        GetCtrlNbr = ""
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        Dim mySelectQuery As String
        Dim ds As DataSet = New DataSet
        Dim dtCurrent As Date = GetServerDate()

        Try
            mySelectQuery = "SELECT Company_Code, Site_Code, Counter " &
                            "FROM tbl_counter " &
                            "WHERE Company_Code = '" & strCompanyCode & "' and Site_Code = '" & strSiteCode & "' and Description = '" & strDesc & "'"

            If cnn.State <> ConnectionState.Open Then cnn.Open()

            Dim myDataAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
            myDataAdapter.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(mySelectQuery, cnn)

            myDataAdapter.Fill(ds, "tbl_counter")

            GetCtrlNbr = ds.Tables("tbl_counter").Rows(0).Item("Company_Code") & Format(dtCurrent, "yy") & Right$(Mid$("00000000" & ds.Tables("tbl_counter").Rows(0).Item("Counter"), 1), 8)
            ds.Tables("tbl_counter").Rows(0).BeginEdit()
            ds.Tables("tbl_counter").Rows(0).Item("Counter") = ds.Tables("tbl_counter").Rows(0).Item("Counter") + 1
            ds.Tables("tbl_counter").Rows(0).EndEdit()


        Catch ex As Exception
            ' Reject DataSet changes
            Return ""

            ds.RejectChanges()

            ' An error occurred. Show the error message
            MsgBox(ex.Message)
        End Try

    End Function

    Public Sub UpdateCtrlNbrCounter(ByVal strCompanyCode As String, ByVal strSiteCode As String, ByVal strDesc As String)
        Dim cmdSQL As New MySqlCommand
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        Dim UpdCtr As Integer = 0
        'get current counter value
        Dim strsql As String

        strsql = "SELECT Counter FROM tbl_counter WHERE Company_Code = '" & strCompanyCode & "' and Site_Code = '" & strSiteCode & "' and Description = '" & strDesc & "'"
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader()

        While reader.Read

            UpdCtr = reader.Item("Counter") + 1

        End While

        reader.Close()
        cmdSQL.Dispose()

        'update new counter value
        Dim sSQL As String = "UPDATE  tbl_counter SET "

        sSQL += " Counter=@Counter "

        sSQL += " WHERE Company_Code = '" & strCompanyCode & "' and Site_Code = '" & strSiteCode & "' and Description = '" & strDesc & "'"
        cmdSQL.CommandText = sSQL

        With cmdSQL.Parameters

            .AddWithValue("@Counter", UpdCtr)

        End With

        cmdSQL.Connection = cnn
        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        cnn.Close()

    End Sub
End Module
