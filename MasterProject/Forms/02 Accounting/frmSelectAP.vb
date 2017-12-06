Imports MySql.Data.MySqlClient
Public Class frmSelectAP

    Dim ListName As String
    Public j As Double
    Private Sub optAP_CheckedChanged(sender As Object, e As EventArgs) Handles optAP.CheckedChanged

    End Sub

    Private Sub optAP_Click(sender As Object, e As EventArgs) Handles optAP.Click
        If Me.optAP.Checked = True Then
            Me.txtAcctCode.Text = "2010"
        End If
        PopGLSub(Me.dgGLSub, Me.txtAcctCode.Text)
    End Sub

    Private Sub optSalary_CheckedChanged(sender As Object, e As EventArgs) Handles optSalary.CheckedChanged

    End Sub

    Private Sub optSalary_Click(sender As Object, e As EventArgs) Handles optSalary.Click
        If Me.optSalary.Checked = True Then
            Me.txtAcctCode.Text = "6250"
        End If
        PopGLSub(Me.dgGLSub, Me.txtAcctCode.Text)
    End Sub

    Private Sub PopGLSub(ByVal dg As DataGridView, ByVal str As String)
        dg.Rows.Clear()

        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM lib_subacctcode " &
                 "WHERE Account_Code = '" & str & "' " &
                 "ORDER BY SubAccount_Title"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            dg.Rows.Add(reader.Item("Account_Code"), reader.Item("SubAccount_Code"), reader.Item("SubAccount_Title"), reader.Item("SubAccount_Dept"), reader.Item("SubAccount_List"), reader.Item("SubAccount_ListItem"))
        End While

        cmd.Dispose()
        reader.Close()
    End Sub

    Private Sub txtAcctCode_TextChanged(sender As Object, e As EventArgs) Handles txtAcctCode.TextChanged
        Dim strsql As String = "SELECT Account_Title FROM lib_acctcode WHERE Account_Code = '" & Me.txtAcctCode.Text & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            Me.txtAcctName.Text = reader.Item("Account_Title")
        End While

        reader.Close()
        cmdSQL.Dispose()
        cnnDBMaster.Close()
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btSelect_Click(sender As Object, e As EventArgs) Handles btSelect.Click
        Dim h As DataGridViewRow

        If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
            If cboClient.Text = "" Then
                MsgBox("Please select Client Name.", MsgBoxStyle.Critical, "Missing Information")

                Exit Sub
            End If
        ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
            If cboAgents.Text = "" Then
                MsgBox("Please select Agent Name.", MsgBoxStyle.Critical, "Missing Information")

                Exit Sub
            End If
        End If

        Select Case Me.Tag

            Case "APV"
                h = frmAPV.dgGLEntry.Rows(Val(Me.txtLineNbr.Text))

                h.Cells(1).Value = Me.txtAcctCode.Text
                h.Cells(2).Value = Me.txtAcctName.Text
                h.Cells(3).Value = Me.dgGLSub.SelectedCells(1).Value
                h.Cells(4).Value = Me.dgGLSub.SelectedCells(2).Value
                h.Cells(5).Value = Me.dgGLSub.SelectedCells(3).Value
                h.Cells(6).Value = ""
                h.Cells(7).Value = Me.dgGLSub.SelectedCells(4).Value
                h.Cells(8).Value = Me.dgGLSub.SelectedCells(5).Value
                h.Cells(11).Value = ComputeAP(frmAPV.dgGLEntry)

                If Me.dgGLSub.SelectedCells(5).Value = "Client" Then
                    ListName = cboClient.Text
                ElseIf Me.dgGLSub.SelectedCells(5).Value = "Agent" Then
                    ListName = cboAgents.Text
                End If

                h.Cells(9).Value = ListName
                frmAPV.lblDebit.Text = frmAPV.SumAmount(10)
                frmAPV.lblCredit.Text = frmAPV.SumAmount(11)

                frmAPV.btAddGLEntry.Enabled = False
                frmAPV.btRemoveGLEntry.Enabled = False
                Me.Dispose()
                Me.Close()
        End Select
    End Sub

    Private Function ComputeAP(ByVal dtgEntry As DataGridView) As Double
        Dim x As Integer
        Dim y As Double = 0
        Dim z As Double = 0
        Dim h As DataGridViewRow

        For x = 0 To dtgEntry.Rows.Count - 1
            h = dtgEntry.Rows(x)
            y = y + Val(h.Cells(10).Value)
            z = z + Val(h.Cells(11).Value)
        Next
        ComputeAP = y - z
        j = y - z
    End Function

    Private Sub dgGLSub_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgGLSub.CellContentClick

    End Sub

    Private Sub dgGLSub_Click(sender As Object, e As EventArgs) Handles dgGLSub.Click
        If Me.dgGLSub.CurrentRow.Cells(4).Value = True Then
            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Agent" Then
                cboAgents.Enabled = True
            Else
                cboAgents.Enabled = False
            End If

            If Me.dgGLSub.CurrentRow.Cells(5).Value = "Client" Then
                cboClient.Enabled = True
            Else
                cboClient.Enabled = False
            End If
        Else
            cboClient.Enabled = False
            Me.cboClient.Text = ""
        End If
    End Sub

    Private Sub frmSelectAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.optAP.Checked = True Then
            Me.txtAcctCode.Text = "2010"
        End If
        If Me.optSalary.Checked = True Then
            Me.txtAcctCode.Text = "6250"
        End If
        PopGLSub(Me.dgGLSub, Me.txtAcctCode.Text)
    End Sub
End Class