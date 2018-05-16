Public Class frmSearchFT
    Private Sub frmSearchFT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dtFrom.Value = Now
        Me.dtTo.Value = Now
        LoadFT()
    End Sub
    Private Sub LoadFT()
        Me.dtgSearchCV.Rows.Clear()
        Dim strsql As String = "SELECT * from ft_main WHERE PrepDate BETWEEN '" & Format$(Me.dtFrom.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo.Value, "yyyy-MM-dd 23:59:59") & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            Me.dtgSearchCV.Rows.Add(reader.Item("RefNo"), reader.Item("PrepBy"), Format$(reader.Item("PrepDate"), "Short Date"))
        End While
        cmdsql.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Private Sub dtFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFrom.ValueChanged
        LoadFT()
    End Sub

    Private Sub dtTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTo.ValueChanged
        LoadFT()
    End Sub

    Private Sub dtgSearchCV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSearchCV.CellContentClick

    End Sub

    Private Sub dtgSearchCV_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSearchCV.CellDoubleClick
        If dtgSearchCV.Rows.Count > 0 Then
            With frmFundTransfer
                If .LoadFT(dtgSearchCV.CurrentRow.Cells("colFTNo").Value) = False Then
                    MsgBox("Fund Transfer not found!", MsgBoxStyle.Exclamation, "System Message")
                    Exit Sub
                End If
                Me.Dispose()
            End With
        End If
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        With frmFundTransfer
            If .LoadFT(Me.lblPrefix.Text & Me.txtRefNo.Text) = False Then
                MsgBox("Fund Transfer not found!", MsgBoxStyle.Exclamation, "System Message")
                Exit Sub
            End If
            Me.Dispose()
        End With
    End Sub

    Private Sub txtRefNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            cmdSearch_Click(sender, e)
        End If
    End Sub
End Class