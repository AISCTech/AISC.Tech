Module modSampleCodes

    Private Sub SampleDataReader()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = ""

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read

            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function SampleSave() As Boolean
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
        Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

        trnSQL = cnnDBMaster.BeginTransaction

        Try
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.Transaction = trnSQL
            cmdSQL.CommandText = "sp_importbookingheadersave"
            cmdSQL.CommandType = CommandType.StoredProcedure

            'cmdSQL.Parameters.AddWithValue("@p_ID", ._ID)
            'cmdSQL.Parameters("@p_ID").Direction = ParameterDirection.Input

            'cmdSQL.Parameters.AddWithValue("@p_PK", _lngPK)
            'cmdSQL.Parameters("@p_PK").Direction = ParameterDirection.Output

            cmdSQL.ExecuteNonQuery()

            trnSQL.Commit()
            cmdSQL.Dispose()
            SampleSave = True
        Catch ex As Exception
            SampleSave = False
            Try
                trnSQL.Rollback()
                MsgBox(ex.Message)
            Catch ex1 As Exception
                If Not trnSQL.Connection Is Nothing Then
                    MsgBox("An exception of type " & ex1.GetType().ToString() &
                      " was encountered while attempting to roll back the transaction.")
                End If
            End Try
        End Try
    End Function
End Module
