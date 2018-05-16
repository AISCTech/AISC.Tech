Imports MySql.Data.MySqlClient
Public Class frmBillingUnpost

    'Private Sub cmdUnpost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnpost.Click
    '    If Len(Me.txtRemarks.Text) = 0 Then
    '        MsgBox("Cannot save with blank remarks!", vbCritical, "Cannot Continue")
    '        Exit Sub
    '    End If
    '    If Len(Me.cboEmployee.Text) = 0 Then
    '        MsgBox("Please select requested by!", vbCritical, "Cannot Continue")
    '        Exit Sub
    '    End If
    '    Select Case Me.Tag

    '        Case "EXP"
    '            Dim strsql As String

    '            If MsgBox("Are you sure you want unpost billing : " & frmExpBill.lblRefNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
    '                Exit Sub
    '            End If

    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '            strsql = "UPDATE bill_exp_main SET Posted=FALSE, SL = FALSE WHERE RefNo = '" & frmExpBill.lblRefNo.Text & "' AND Cancel = FALSE"

    '            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
    '            Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

    '            trnSQL = connAcctg.BeginTransaction

    '            Try
    '                cmdSQL.Connection = connAcctg
    '                cmdSQL.Transaction = trnSQL

    '                cmdSQL.CommandText = strsql
    '                cmdSQL.ExecuteNonQuery()

    '                'cmdSQL.CommandText = "UPDATE reg_trn_main SET " & _
    '                '                        "related_ref = '' " & _
    '                '                    "WHERE reg_group = 1 " & _
    '                '                        "AND reg_no = @reg_no " & _
    '                '                        "AND related_ref = @related_ref"

    '                'cmdSQL.Parameters.Clear()
    '                'With cmdSQL.Parameters
    '                '    .AddWithValue("@reg_no", frmExpBill.txtCISOANo.Text)
    '                '    .AddWithValue("@related_ref", frmExpBill.lblRefNo.Text)
    '                'End With

    '                'cmdSQL.ExecuteNonQuery()

    '                'cmdSQL.CommandText = "UPDATE reg_trn_main SET " & _
    '                '                        "related_ref = '' " & _
    '                '                    "WHERE reg_group = 2 " & _
    '                '                        "AND reg_no = @reg_no " & _
    '                '                        "AND related_ref = @related_ref"

    '                'cmdSQL.Parameters.Clear()
    '                'With cmdSQL.Parameters
    '                '    .AddWithValue("@reg_no", frmExpBill.txtSOANo.Text)
    '                '    .AddWithValue("@related_ref", frmExpBill.lblRefNo.Text)
    '                'End With

    '                'cmdSQL.ExecuteNonQuery()

    '                trnSQL.Commit()
    '                cmdSQL.Dispose()
    '            Catch ex As Exception
    '                Try
    '                    trnSQL.Rollback()
    '                    MsgBox(ex.Message)
    '                Catch ex1 As Exception
    '                    If Not trnSQL.Connection Is Nothing Then
    '                        MsgBox("An exception of type " & ex1.GetType().ToString() &
    '                          " was encountered while attempting to roll back the transaction.")
    '                    End If
    '                End Try
    '            End Try

    '            connAcctg.Close()
    '            frmExpBill.SearchExpBilling(frmExpBill.lblRefNo.Text)
    '        Case "IMPB"
    '            Dim strsql As String

    '            If MsgBox("Are you sure you want unpost billing : " & frmImpBBill.lblRefNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
    '                Exit Sub
    '            End If

    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '            strsql = "UPDATE bill_impb_main SET Posted=FALSE, SL = FALSE WHERE RefNo = '" & frmImpBBill.lblRefNo.Text & "' AND Cancel = FALSE"

    '            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
    '            Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

    '            trnSQL = connAcctg.BeginTransaction

    '            Try
    '                cmdSQL.Connection = connAcctg
    '                cmdSQL.Transaction = trnSQL

    '                cmdSQL.CommandText = strsql
    '                cmdSQL.ExecuteNonQuery()

    '                trnSQL.Commit()
    '                cmdSQL.Dispose()
    '            Catch ex As Exception
    '                Try
    '                    trnSQL.Rollback()
    '                    MsgBox(ex.Message)
    '                Catch ex1 As Exception
    '                    If Not trnSQL.Connection Is Nothing Then
    '                        MsgBox("An exception of type " & ex1.GetType().ToString() &
    '                          " was encountered while attempting to roll back the transaction.")
    '                    End If
    '                End Try
    '            End Try

    '            connAcctg.Close()
    '            frmImpBBill.SearchBilling(frmImpBBill.lblRefNo.Text, "RefNo")
    '        Case "IMPF"
    '            Dim strsql As String

    '            If MsgBox("Are you sure you want unpost billing : " & frmImpFBill.tslblRefNo.Text, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.No Then
    '                Exit Sub
    '            End If

    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '            strsql = "UPDATE bill_impf_main SET Posted=FALSE, SL = FALSE WHERE RefNo = '" & frmImpFBill.tslblRefNo.Text & "' AND Cancel = FALSE"

    '            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand
    '            Dim trnSQL As MySql.Data.MySqlClient.MySqlTransaction

    '            trnSQL = connAcctg.BeginTransaction

    '            Try
    '                cmdSQL.Connection = connAcctg
    '                cmdSQL.Transaction = trnSQL

    '                cmdSQL.CommandText = strsql
    '                cmdSQL.ExecuteNonQuery()

    '                trnSQL.Commit()
    '                cmdSQL.Dispose()
    '            Catch ex As Exception
    '                Try
    '                    trnSQL.Rollback()
    '                    MsgBox(ex.Message)
    '                Catch ex1 As Exception
    '                    If Not trnSQL.Connection Is Nothing Then
    '                        MsgBox("An exception of type " & ex1.GetType().ToString() &
    '                          " was encountered while attempting to roll back the transaction.")
    '                    End If
    '                End Try
    '            End Try

    '            connAcctg.Close()
    '            frmImpFBill.RetrieveBillingMain("RefNo", frmImpFBill.tslblRefNo.Text)
    '    End Select

    '    SaveUnpostHistory(Me.Tag, Me.txtRefNo.Text)

    '    MsgBox("Successfully Unposted Billing : " & Me.txtRefNo.Text, vbInformation, "System Message")
    '    Me.Dispose()
    '    Me.Close()
    'End Sub
    'Public Sub SaveUnpostHistory(ByVal str As String, ByVal strRefNo As String)
    '    Dim strsql As String = "INSERT INTO bill_unpost_history " &
    '                            "(RefNo, Tag, RequestedBy, Remarks, UnpostDate, UnpostBy) " &
    '                            "VALUES " &
    '                            "(@RefNo, @Tag, @RequestedBy, @Remarks, @UnpostDate, @UnpostBy)"

    '    Dim dtCurrent As Date = GetServerDate()

    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '    With cmdSQL.Parameters
    '        .AddWithValue("@RefNo", Me.txtRefNo.Text)
    '        .AddWithValue("@Tag", Me.Tag)
    '        .AddWithValue("@RequestedBy", Me.cboEmployee.Text)
    '        .AddWithValue("@Remarks", Me.txtRemarks.Text)
    '        .AddWithValue("@UnpostDate", dtCurrent)
    '        .AddWithValue("@UnpostBy", CurrentUser)
    '    End With

    '    cmdSQL.ExecuteNonQuery()
    '    cmdSQL.Dispose()
    '    connAcctg.Close()
    'End Sub

    'Private Sub frmBillingUnpost_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    PopComboSQL(Me.cboEmployee, "Select Name FROM lib_employee ORDER BY Name", "Name")
    'End Sub
    'Private Sub PopComboSQL(ByVal cbo As ComboBox, ByVal strsql As String, ByVal strField As String)

    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '    cbo.SelectedIndex = -1
    '    cbo.Items.Clear()

    '    While reader.Read
    '        cbo.Items.Add(reader.Item(strField))
    '    End While

    '    reader.Close()
    '    cmdSQL.Dispose()
    '    connAcctg.Close()
    'End Sub

    'Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
    '    Me.Dispose()
    '    Me.Close()
    'End Sub
End Class