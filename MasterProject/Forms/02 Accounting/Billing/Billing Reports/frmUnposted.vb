Public Class frmUnposted
    'Public strMonth As String

    'Private Sub PostSelected()
    '    Dim dtcurrent As Date, dtSLDate As Date, strsql As String

    '    Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand

    '    For ctrRow As Integer = 0 To Me.dtgUnposted.Rows.Count - 1
    '        With Me.dtgUnposted.Rows(ctrRow)
    '            If .Cells("colchkSelect").Value = True Then
    '                'set SL date
    '                dtcurrent = GetServerDate()
    '                dtSLDate = Format$(CDate(.Cells("colPrepDate").Value), "yyyy-MM-dd hh:mm:ss")

    '                If dtcurrent.Day > 15 Then
    '                    While dtSLDate < dtcurrent.AddMonths(-3)
    '                        dtSLDate = Format$(CDate(dtSLDate).AddMonths(1), "yyyy-MM-01 00:00:00")
    '                    End While
    '                Else
    '                    While dtSLDate < dtcurrent.AddMonths(-2)
    '                        dtSLDate = Format$(CDate(dtSLDate).AddMonths(1), "yyyy-MM-01 00:00:00")
    '                    End While
    '                End If

    '                Select Case Me.Tag
    '                    Case "Export Billing"
    '                        strsql = "UPDATE bill_exp_main SET" &
    '                                 " Posted = @Posted, " &
    '                                 " PostedBy = @PostedBy, " &
    '                                 " PostedDate = @PostedDate, " &
    '                                 " SLDate = @SLDate, " &
    '                                 " DateReceived = @DateReceived, " &
    '                                 " Received = True " &
    '                                 " WHERE RefNo = '" & .Cells("colRefNo").Value & "' AND Cancel = FALSE"

    '                        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '                        With cmdSQL.Parameters
    '                            .AddWithValue("@Posted", True)
    '                            .AddWithValue("@PostedBy", CurrentUser)
    '                            .AddWithValue("@PostedDate", dtcurrent)
    '                            .AddWithValue("@SLDate", dtSLDate)
    '                            .AddWithValue("@DateReceived", CDate(dtgUnposted.Rows(ctrRow).Cells("colDateReceived").Value))
    '                        End With

    '                        cmdSQL.ExecuteNonQuery()
    '                    Case "Import Brokerage Billing"
    '                        strsql = "UPDATE bill_impb_main SET" &
    '                                 " Posted = @Posted, " &
    '                                 " PostedBy = @PostedBy, " &
    '                                 " PostedDate = @PostedDate, " &
    '                                 " SLDate = @SLDate, " &
    '                                 " DateReceived = @DateReceived, " &
    '                                 " Received = True " &
    '                                 " WHERE RefNo = '" & .Cells("colRefNo").Value & "' AND Cancel = FALSE"

    '                        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '                        With cmdSQL.Parameters
    '                            .AddWithValue("@Posted", True)
    '                            .AddWithValue("@PostedBy", CurrentUser)
    '                            .AddWithValue("@PostedDate", dtcurrent)
    '                            .AddWithValue("@SLDate", dtSLDate)
    '                            .AddWithValue("@DateReceived", CDate(dtgUnposted.Rows(ctrRow).Cells("colDateReceived").Value))
    '                        End With

    '                        cmdSQL.ExecuteNonQuery()
    '                    Case "Import Forwarding Billing"
    '                        strsql = "UPDATE bill_impf_main SET" &
    '                                 " Posted = @Posted, " &
    '                                 " PostedBy = @PostedBy, " &
    '                                 " DatePosted = @PostedDate, " &
    '                                 " SLDate = @SLDate " &
    '                                 " WHERE RefNo = '" & .Cells("colRefNo").Value & "' AND Cancel = FALSE"

    '                        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '                        With cmdSQL.Parameters
    '                            .AddWithValue("@Posted", True)
    '                            .AddWithValue("@PostedBy", CurrentUser)
    '                            .AddWithValue("@PostedDate", dtcurrent)
    '                            .AddWithValue("@SLDate", dtSLDate)
    '                        End With

    '                        cmdSQL.ExecuteNonQuery()
    '                    Case "Import DC Note Billing"
    '                        strsql = "UPDATE bill_impd_main SET" &
    '                                 " Posted = @Posted, " &
    '                                 " PostedBy = @PostedBy, " &
    '                                 " DatePosted = @PostedDate " &
    '                                 " WHERE RefNo = '" & .Cells("colRefNo").Value & "' AND Cancel = FALSE"

    '                        cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '                        With cmdSQL.Parameters
    '                            .AddWithValue("@Posted", True)
    '                            .AddWithValue("@PostedBy", CurrentUser)
    '                            .AddWithValue("@PostedDate", dtcurrent)
    '                        End With

    '                        cmdSQL.ExecuteNonQuery()
    '                End Select
    '            End If
    '        End With

    '        cmdSQL.Dispose()
    '    Next
    'End Sub

    'Private Sub PopAll()
    '    Select Case Me.Tag
    '        Case "Export Billing"
    '            PopdtgUnpostedBilling("bill_exp_main", "RefNo", "PrepDate", "PrepBy", "Cancel")
    '        Case "Import Brokerage Billing"
    '            PopdtgUnpostedBilling("bill_impb_main", "RefNo", "PrepDate", "PrepBy", "Cancel")
    '        Case "Import Forwarding Billing"
    '            PopdtgUnpostedBilling("bill_impf_main", "RefNo", "DateSaved", "PrepBy", "Cancel")
    '        Case "Import DC Note Billing"
    '            PopdtgUnpostedBilling("bill_impd_main", "RefNo", "PrepDate", "PrepBy", "Cancel")
    '        Case "Container Deposit"
    '            PopdtgUnpostedBilling("bcr_main", "BCR_Nbr", "BCR_PreparedDate", "BCR_PreparedBy", "BCR_Cancel")
    '    End Select
    'End Sub

    'Private Sub LoadImpF(ByVal strCol As String, ByVal strVal As String)

    '    Dim strSQL As String, PstrHBL As String = "", PstrMBL As String = "", PdtMBL As Date

    '    strSQL = "SELECT * FROM bill_impf_main WHERE " & strCol & " = '" & strVal & "' AND Cancel = FALSE"

    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, connAcctg)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    While reader.Read
    '        PstrHBL = reader.Item("HouseBL")
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()

    '    'RETRIEVE HBL
    '    strSQL = "SELECT MasterBL FROM ImpHBL " &
    '         "WHERE HouseBL = '" & PstrHBL & "'"

    '    If connImport.State <> ConnectionState.Open Then connImport.Open()

    '    Dim cmdSQL2 = New OleDb.OleDbCommand(strSQL, connImport)

    '    Dim reader2 As OleDb.OleDbDataReader = cmdSQL2.ExecuteReader

    '    While reader2.Read
    '        PstrMBL = reader2.Item("MasterBL")
    '    End While

    '    reader2.Close()

    '    'RETRIEVE MBL
    '    strSQL = "SELECT ArrivalDate FROM ImpMBL " &
    '         "WHERE MasterBL = '" & PstrMBL & "'"

    '    If connImport.State <> ConnectionState.Open Then connImport.Open()

    '    cmdSQL2 = New OleDb.OleDbCommand(strSQL, connImport)

    '    reader2 = cmdSQL2.ExecuteReader

    '    While reader2.Read
    '        PdtMBL = reader2.Item("ArrivalDate")
    '    End While

    '    reader2.Close()
    '    cmdSQL2.Dispose()


    '    frmImpFBill.dtArrivalDate.Value = PdtMBL
    '    frmImpFBill.cboMBL.Text = PstrMBL
    '    frmImpFBill.cboHBL.Text = PstrHBL
    'End Sub

    'Private Sub PopdtgUnpostedBilling(ByVal strTable As String, ByVal strRefNo As String, ByVal strPrepDate As String, ByVal strPrepBy As String, ByVal strCancel As String)
    '    Dim strsql As String = "SELECT * FROM " & strTable & " WHERE Posted = FALSE AND " & strCancel & " = FALSE"

    '    If Me.chkAllDate.Checked = False Then
    '        strsql += " AND " & strPrepDate & " BETWEEN '" & Format$(Me.dtFrom.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtTo.Value, "yyyy-MM-dd 23:59:59") & "'"
    '    End If

    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    Me.dtgUnposted.Rows.Clear()
    '    While reader.Read
    '        Me.dtgUnposted.Rows.Add(Me.chkSelectAll.Checked, reader.Item(strRefNo), reader.Item(strPrepDate), reader.Item(strPrepBy))
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    'End Sub

    'Private Sub frmUnposted_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    'frmFiscalPeriod.dtgFiscalPeriod.EndEdit()
    '    Me.Dispose()
    'End Sub

    'Private Sub frmUnposted_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Select Case Me.Tag
    '        Case "Export Billing"
    '            Me.optExp.Checked = True
    '        Case "Import Brokerage Billing"
    '            Me.optImpB.Checked = True
    '        Case "Import Forwarding Billing"
    '            Me.optImpF.Checked = True
    '        Case "Import DC Note Billing"
    '            Me.optImpDCAF.Checked = True
    '    End Select

    '    PopAll()
    'End Sub

    'Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If MsgBox("Close month of " & strMonth & " " & frmFiscalPeriod.lblYear.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
    '        frmFiscalPeriod.dtgFiscalPeriod.CurrentCell.Value = True
    '        Me.Close()
    '    End If
    'End Sub

    'Private Sub optExp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optExp.CheckedChanged
    '    If Me.optExp.Checked = True Then
    '        Me.Tag = "Export Billing"
    '        colDateReceived.Visible = True
    '        PopAll()
    '    End If
    'End Sub

    'Private Sub optImpB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optImpB.CheckedChanged
    '    If Me.optImpB.Checked = True Then
    '        Me.Tag = "Import Brokerage Billing"
    '        colDateReceived.Visible = True
    '        PopAll()
    '    End If
    'End Sub

    'Private Sub optImpF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optImpF.CheckedChanged
    '    If Me.optImpF.Checked = True Then
    '        Me.Tag = "Import Forwarding Billing"
    '        colDateReceived.Visible = False
    '        PopAll()
    '    End If
    'End Sub

    'Private Sub dtFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFrom.ValueChanged
    '    PopAll()
    'End Sub

    'Private Sub dtTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTo.ValueChanged
    '    PopAll()
    'End Sub

    'Private Sub chkAllDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllDate.CheckedChanged
    '    Me.dtFrom.Enabled = Not Me.chkAllDate.Checked
    '    Me.dtTo.Enabled = Not Me.chkAllDate.Checked

    '    PopAll()
    'End Sub

    'Private Function CheckReceivedDate(ByVal refno As String, ByVal dtReceived As String, ByVal ft As String) As Boolean
    '    CheckReceivedDate = False
    '    Dim strsql As String = "call sp_getdata ('*', '" & ft & "', '(RefNo like \'" & refno & "\')')"
    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '    Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
    '    While reader.Read
    '        If CDate(dtReceived) < CDate(reader.Item("PrepDate")) Then
    '            CheckReceivedDate = True
    '        End If
    '    End While
    '    cmdsql.Dispose()
    '    reader.Close()
    '    connAcctg.Close()
    'End Function

    'Private Sub cmdPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPost.Click
    '    Dim intSelected As Integer = 0

    '    For ctrrow As Integer = 0 To Me.dtgUnposted.Rows.Count - 1
    '        With Me.dtgUnposted.Rows(ctrrow)
    '            If .Cells("colchkSelect").Value = True Then
    '                intSelected += 1
    '                If optExp.Checked = True Or optImpB.Checked = True Then
    '                    If .Cells("colDateReceived").Value = Nothing Then
    '                        MsgBox("All selected billing for posting should have a received date!", MsgBoxStyle.Exclamation, "System Message")
    '                        Exit Sub
    '                    End If
    '                End If
    '            End If
    '        End With
    '    Next

    '    If intSelected = 0 Then
    '        MsgBox("No reference no. selected!", MsgBoxStyle.Exclamation, "System Message")
    '        Exit Sub
    '    End If

    '    If MsgBox(intSelected & " reference no. selected. Post selected billing?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
    '        PostSelected()
    '        MsgBox(intSelected & " billing reference no. posted!", MsgBoxStyle.Information, "System Message")
    '        PopAll()
    '    End If
    'End Sub

    'Private Sub dtgUnposted_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgUnposted.CellContentClick
    '    Me.dtgUnposted.EndEdit()
    '    For ctrRow As Integer = 0 To Me.dtgUnposted.Rows.Count - 1
    '        With Me.dtgUnposted.Rows(ctrRow)
    '            If .Cells("colchkSelect").Value = False Then
    '                Me.chkSelectAll.Checked = False
    '                Exit Sub
    '            End If
    '        End With
    '    Next

    '    Me.chkSelectAll.Checked = True
    'End Sub

    'Private Sub chkSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelectAll.Click
    '    PopAll()
    'End Sub

    'Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged

    'End Sub

    'Private Sub dtgUnposted_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgUnposted.CellEndEdit
    '    With dtgUnposted.CurrentRow
    '        If .Cells("colChkSelect").Value = True Then
    '            If .Cells("colDateReceived").Value <> Nothing Then
    '                'If CheckReceivedDate(dtgUnposted.CurrentRow.Cells("colRefNo").Value, dtgUnposted.CurrentRow.Cells("colDateReceived").Value, IIf(optExp.Checked = True, "bill_exp_main", "bill_impb_main")) = True Then
    '                'MsgBox("Test")
    '                'End If
    '                'If Format$(.Cells("colPrepDate").Value) > Format$(.Cells("colDateReceived").Value) Then
    '                ' .Cells("colDateReceived").Value = Format$(.Cells("colPrepDate").Value, "Short Date")
    '                'End If

    '                If .Cells("colPrepDate").Value > .Cells("colDateReceived").Value Then
    '                    .Cells("colDateReceived").Value = .Cells("colPrepDate").Value
    '                End If

    '            End If
    '        End If
    '    End With
    'End Sub
End Class