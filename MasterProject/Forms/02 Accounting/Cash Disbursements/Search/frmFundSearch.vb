Imports MySql.Data.MySqlClient
Public Class frmFundSearch
    Private Sub frmFundSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadVouchers()
        Dim strsql As String
        Dim strCV As String
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql2 As New MySqlCommand

        strsql = "UPDATE tbl_cv SET selected = @selected"

        cmdsql2 = New MySqlCommand(strsql, cnn)

        With cmdsql2.Parameters
            .AddWithValue("@selected", 0)
        End With

        cmdsql2.ExecuteNonQuery()
        cmdsql2.Dispose()

        strsql = "SELECT * FROM tbl_cv"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            strCV = reader.Item("CVNo")
            If Not reader.Item("Fund") = False Then
                If CDate(Format$(txtDateFrom.Value, "Short Date")) <= CDate(Format$(reader.Item("FundDate"), "Short Date")) And CDate(Format$(txtDateTo.Value, "Short Date")) >= CDate(Format$(reader.Item("FundDate"), "Short Date")) Then
                    If cnn.State <> ConnectionState.Open Then cnn.Open()

                    Dim cmdsql1 As New MySqlCommand

                    strsql = "UPDATE tbl_cv SET selected = @selected WHERE CVNo like '" & strCV & "'"

                    cmdsql1 = New MySqlCommand(strsql, cnn)

                    With cmdsql1.Parameters
                        .AddWithValue("@selected", 1)
                    End With

                    cmdsql1.ExecuteNonQuery()
                    cmdsql1.Dispose()
                End If
            End If
        End While
        cmdsql.Dispose()
        reader.Close()
    End Sub

    Private Sub cmdPreview_Click(sender As Object, e As EventArgs) Handles cmdPreview.Click
        loadVouchers()

        frmPrintPreview.loadCheckMCFundReport()
        frmPrintPreview.ShowDialog()
    End Sub
End Class