Imports MySql.Data.MySqlClient
Module modGPA
    Public Sub UpdateToGPATable(ByVal strPKField As String, ByVal strPKFieldValue As String, ByVal strField As String, ByVal strFieldType As Integer, ByVal strFieldValueString As String, ByVal strFieldValueDouble As Double)
        Dim dtCurrent As Date = GetServerDate()
        Dim cmdSQL As New MySqlCommand


        Dim cnn As New MySqlConnection(strDBMaster)
        dtCurrent = GetServerDate()
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim sSQL As String = "UPDATE tbl_gpa SET "
        sSQL += " " & strField & "=@" & strField & " "

        sSQL += " WHERE " & strPKField & " = '" & strPKFieldValue & "'"
        cmdSQL.CommandText = sSQL

        With cmdSQL.Parameters

            'strFieldType
            '1 for string
            '2 for double

            Select Case strFieldType
                Case 1
                    .AddWithValue("@" & strField & "", strFieldValueString)
                Case 2
                    .AddWithValue("@" & strField & "", strFieldValueDouble)
            End Select

        End With

        cmdSQL.Connection = cnn
        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()

        'save to trans logs
        SaveTransLogs("Update GPA Table", "modGPA", strPKField, strPKFieldValue, strCurrentUser)
    End Sub

    Public Sub InsertToGPATable(ByVal strRef As String)
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim dtCurrent As Date = GetServerDate()
        Dim cmdSQL As New MySqlCommand
        Dim sSQL As String

        sSQL = "INSERT INTO tbl_gpa () " &
                " VALUES (@)"

        cmdSQL.CommandText = sSQL

        With cmdSQL.Parameters

            .AddWithValue("@", "")

        End With

        cmdSQL.Connection = cnnDBMaster
        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()

        cnnDBMaster.Dispose()
        cnnDBMaster.Close()

        'save to trans logs
        SaveTransLogs("Insert GPA Table", "modGPA", "", "", strCurrentUser)
    End Sub
End Module
