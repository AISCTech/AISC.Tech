Imports System.Configuration
Imports MySql.Data.MySqlClient

Module modDBConn
    Public strDBMaster As String = ConfigurationManager.ConnectionStrings("DBMaster").ConnectionString
    Public cnnDBMaster As New MySqlConnection(strDBMaster)
End Module
