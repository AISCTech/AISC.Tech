Public Class frmSelection

    Dim dvDataView As DataView
    Dim strFilterField As String
    Dim txtCaller As TextBox

    Public Sub PopulateGrid(ByVal _strSQL As String, ByVal _strFilterField As String, ByVal _txtCaller As TextBox)
        strFilterField = _strFilterField
        txtCaller = _txtCaller

        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster

            cmdSQL.CommandText = _strSQL

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            dtgSelection.DataSource = dvDataView

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmSelection_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        dvDataView.RowFilter = strFilterField & " LIKE '%" & Replace(txtFilter.Text, "'", "''") & "%'"
    End Sub

    Private Sub dtgSelection_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSelection.CellContentClick

    End Sub

    Private Sub dtgSelection_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSelection.CellDoubleClick
        'Select Case Me.Tag
        'Case "ImpBookShipper"
        'FillImpBookShipper(sender, e)
        'Case "ImpBookConsignee"
        'FillImpBookConsignee(sender, e)
        'Case "ImpBookConsignor"

        'Case "ImpBookForwarder"

        'End Select

        txtCaller.Tag = dtgSelection.Rows(e.RowIndex).Cells(0).Value
        txtCaller.Text = dtgSelection.Rows(e.RowIndex).Cells(1).Value
        Me.Close()
    End Sub
End Class