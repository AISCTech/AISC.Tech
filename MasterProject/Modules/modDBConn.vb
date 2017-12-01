Imports MySql.Data.MySqlClient

Module modDBConn

    Public DBServer As String = "localhost"
    'Public DBServer As String = "192.168.8.2"
    Public DBUID As String = "root"
    Public DBPwd As String = "ripper"
    Public DBName As String = "aces_master"

    Public strDBMaster As String = "server=" & DBServer & ";" &
                                    "uid=" & DBUID & ";" &
                                    "pwd=" & DBPwd & ";" &
                                    "database=" & DBName & ";"

    Public cnnDBMaster As New MySqlConnection(strDBMaster)
End Module
