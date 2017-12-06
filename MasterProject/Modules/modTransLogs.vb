Imports MySql.Data.MySqlClient
Module modTransLogs
    Public Sub SaveTransLogs(ByVal strTransaction As String, ByVal strFormName As String, ByVal strRef As String, ByVal strRefNbr As String, ByVal strModBy As String)
        Dim dtCurrent As Date = GetServerDate()
        Dim cmdSQL As New MySqlCommand
        Dim myIPaddress As String = GetHostIP(Net.Sockets.AddressFamily.InterNetwork)
        'Dim SiteCode As String = ""
        'SiteCode = GetStringValue("v_201.User_ID = " & strCurrentUser & "", "Site_Name")
        Dim SitePK As String = ""
        'SitePK = GetID("Trans_Logs", SiteCode)
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Try

            cmdSQL.CommandText = ("INSERT INTO tbl_translogs (`Date`, `Site_Code`, `Site_PK`, `Transaction`,`Form_Name`, `Ref`, `Ref_Nbr`, `Modified_By`, `Workstation`, `IPAddress`)  VALUES " &
                                 "               (@Date, @Site_Code, @Site_PK , @Transaction,@Form_Name, @Ref, @Ref_Nbr, @Modified_By, @Workstation, @IPAddress)")

            With cmdSQL.Parameters

                .AddWithValue("@Date", dtCurrent)
                .AddWithValue("@Site_Code", strSiteCode)
                .AddWithValue("@Site_PK", SitePK)
                .AddWithValue("@Transaction", strTransaction)
                .AddWithValue("@Form_Name", strFormName)
                .AddWithValue("@Ref", strRef)
                .AddWithValue("@Ref_Nbr", strRefNbr)
                .AddWithValue("@Modified_By", strModBy)
                .AddWithValue("Workstation", My.Computer.Name)
                .AddWithValue("IPAddress", myIPaddress)
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
End Module
