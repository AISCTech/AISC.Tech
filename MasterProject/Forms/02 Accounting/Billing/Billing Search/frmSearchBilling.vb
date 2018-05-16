Imports MySql.Data.MySqlClient
Public Class frmSearchBilling
    Dim PstrHBL As String = ""
    Dim PstrMBL As String = ""
    Dim PdtMBL As Date
    Private Sub frmSearchBilling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopMBL()
        If Me.dtgMBL.Rows.Count > 0 Then
            PopHBL(Me.dtgMBL.CurrentCell.Value)
        End If

        Me.dtFrom.Value = GetServerDate()
        Me.dtTo.Value = Me.dtFrom.Value
        Me.txtSearch.Focus()
    End Sub
    Public Function SearchBy(ByVal strCol As String, ByVal strVal As String) As Boolean
        SearchBy = False
        Dim strSQL As String
        If optRefNo.Checked = True Then
            strSQL = "SELECT * FROM bill_impfinv_main WHERE " & strCol & " = '" & strVal & "' AND Cancel = FALSE"

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

            Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                PstrHBL = reader.Item("HouseBL")
            End While

            reader.Close()
            cmdSQL.Dispose()
        ElseIf Me.optHBL.Checked = True Then
            PstrHBL = strVal
        Else
            PstrMBL = strVal
        End If

        'RETRIEVE HBL
        strSQL = "SELECT MBLNo FROM v_frwdg_docs_hbl " &
             "WHERE HBLNo = '" & PstrHBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL2 = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL2.ExecuteReader

        While reader2.Read
            PstrMBL = reader2.Item("MBLNo")
        End While

        reader2.Close()

        'RETRIEVE MBL
        strSQL = "SELECT ArrivalDate FROM v_frwdg_docs_mbl " &
             "WHERE MBLNo = '" & PstrMBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        cmdSQL2 = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        reader2 = cmdSQL2.ExecuteReader

        While reader2.Read
            PdtMBL = reader2.Item("ArrivalDate")
            SearchBy = True
        End While

        reader2.Close()
        cmdSQL2.Dispose()

        If SearchBy = True Then

            Select Case Me.Tag

                Case "IMPFCI"
                    frmInvoiceImpF.dtArrivalDate.Value = PdtMBL
                    frmInvoiceImpF.cboMBL.Text = PstrMBL
                    frmInvoiceImpF.cboHBL.Text = PstrHBL
                    If Me.optRefNo.Checked = True Then
                        frmInvoiceImpF.RetrieveBillingMain("RefNo", Me.txtSearch.Text)
                    End If

                    frmInvoiceImpF.PopulateOR(frmInvoiceImpF.tslblRefNo.Text)
                    frmInvoiceImpF.PopulateAR(frmInvoiceImpF.tslblRefNo.Text)
                Case "IMPFSOA"
                    frmSOAImpF.dtArrivalDate.Value = PdtMBL
                    frmSOAImpF.cboMBL.Text = PstrMBL
                    frmSOAImpF.cboHBL.Text = PstrHBL
                    If Me.optRefNo.Checked = True Then
                        frmSOAImpF.RetrieveBillingMain("RefNo", Me.txtSearch.Text)
                    End If

                    frmSOAImpF.PopulateOR(frmSOAImpF.tslblRefNo.Text)
                    frmSOAImpF.PopulateAR(frmSOAImpF.tslblRefNo.Text)
                Case "IMPD"
                    frmAgencyFeeBillingImpF.dtArrivalDate.Value = PdtMBL
                    frmAgencyFeeBillingImpF.cboMBL.Text = PstrMBL
                    frmAgencyFeeBillingImpF.cboHBL.Text = PstrHBL
                    'frmIMPDCBill.PopulateOR(frmImpFBill.tslblRefNo.Text)
                    'frmIMPDCBill.PopulateAR(frmImpFBill.tslblRefNo.Text)
            End Select


            'MsgBox(PstrMBL)
        Else
            MsgBox("Record not found!", MsgBoxStyle.Exclamation, "System Message")
        End If
    End Function

    Private Sub PopMBL()
        Dim strSQL As String = "SELECT MBLNo FROM v_frwdg_docs_mbl WHERE ArrivalDate between '" & Format$(dtFrom.Value, "yyyy-MM-dd") & "' AND '" & Format$(dtTo.Value, "yyyy-MM-dd") & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgMBL.Rows.Clear()
        Me.dtgHBL.Rows.Clear()
        'Me.txtSearch.Text = ""
        While reader.Read
            Me.dtgMBL.Rows.Add(reader.Item("MBLNo"))
            If CheckIfMBLBilled(Me.dtgMBL.Rows(Me.dtgMBL.RowCount - 1).Cells(0).Value) = True Then
                With Me.dtgMBL.Rows(Me.dtgMBL.RowCount - 1).Cells(0).Style
                    .Font = New Font(Me.dtgMBL.Font, FontStyle.Bold)
                    .ForeColor = Color.DarkBlue
                    .SelectionForeColor = Color.DarkBlue
                End With
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub PopHBL(ByVal pMBL As String)
        pMBL = pMBL.Replace("'", "''")
        Dim strSQL As String = "SELECT HBLNo, ConsigneeName1 FROM v_frwdg_docs_hbl WHERE MBLNo = '" & pMBL & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgHBL.Rows.Clear()
        'Me.txtSearch.Text = ""
        While reader.Read
            If CheckIfHBLBilled(reader.Item("HBLNo")) = True Then
                PopHBLDetails(reader.Item("HBLNo"))
            Else
                Me.dtgHBL.Rows.Add(reader.Item("HBLNo"), "", "", "", dtgMBL.CurrentRow.Cells(colMBLBook.Name).Value, reader.Item("ConsigneeName1"), "", "")
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub PopHBLDetails(ByVal pHBL As String)
        Dim strSQL As String = "SELECT * FROM bill_impfinv_main WHERE HouseBL = '" & pHBL & "' AND Cancel = FALSE"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySqlCommand(strSQL, cnn)

        Dim rdrBill As MySqlDataReader = cmdSQL.ExecuteReader

        While rdrBill.Read
            Me.dtgHBL.Rows.Add(rdrBill.Item("HouseBL"), rdrBill.Item("RefNo"), rdrBill.Item("InvoiceNum"), "", dtgMBL.CurrentRow.Cells(colMBLBook.Name).Value, rdrBill.Item("Client"), rdrBill.Item("PrepDate"), rdrBill.Item("PrepBy"))
            With Me.dtgHBL.Rows(Me.dtgHBL.RowCount - 1).Cells(colHBL.Name).Style
                .Font = New Font(Me.dtgHBL.Font, FontStyle.Bold)
                .ForeColor = Color.DarkBlue
                .SelectionForeColor = Color.DarkBlue
            End With
        End While

        rdrBill.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub PopRefNo(ByVal pHBL As String)
        If Me.optRefNo.Checked = True Then
            Dim strSQL As String = "SELECT RefNo FROM bill_impfinv_main WHERE HouseBL = '" & pHBL & "' AND Cancel = FALSE"

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

            Dim cmdSQL = New MySqlCommand(strSQL, cnnDBMaster)

            Dim reader As MySqlDataReader = cmdSQL.ExecuteReader

            Me.txtSearch.Text = ""
            While reader.Read
                Me.txtSearch.Text = Mid$(reader.Item("RefNo"), 7, Len(reader.Item("RefNo")))
            End While

            reader.Close()
            cmdSQL.Dispose()
        End If
    End Sub

    Private Function CheckIfMBLBilled(ByVal strVal As String) As Boolean
        CheckIfMBLBilled = False
        strVal = strVal.Replace("'", "''")
        Dim strsql As String = "SELECT HBLNo FROM v_frwdg_docs_hbl WHERE MBLNo = '" & strVal & "'"
        Dim strHBL As String = ""
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            If CheckIfHBLBilled(reader.Item("HBLNo")) = True Then
                CheckIfMBLBilled = True
                Exit While
            Else
                CheckIfMBLBilled = False
            End If
        End While

        reader.Close()
        cmdSQL.Dispose()
    End Function

    Private Function CheckIfHBLBilled(ByVal strVal As String) As Boolean
        CheckIfHBLBilled = False
        Dim strsql As String = "SELECT RefNo FROM bill_impfinv_main WHERE HouseBL = '" & strVal & "' AND Cancel = FALSE"
        Dim cnn As New MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql2.ExecuteReader

        While reader2.Read
            CheckIfHBLBilled = True
        End While

        reader2.Close()
        cmdsql2.Dispose()
    End Function

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            If SearchBy("RefNo", Me.txtSearch.Text) = False Then Exit Sub
            Me.Close()
        End If
    End Sub

    Private Sub frmSearchBilling_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        PopMBL()
        If Me.dtgMBL.Rows.Count > 0 Then
            PopHBL(Me.dtgMBL.CurrentCell.Value)
        End If
    End Sub

    Private Sub dtgMBL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgMBL.CellContentClick

    End Sub

    Private Sub dtgMBL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgMBL.CellClick
        PopHBL(Me.dtgMBL.CurrentCell.Value)
    End Sub

    Private Sub dtgHBL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgHBL.CellContentClick

    End Sub

    Private Sub dtgHBL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgHBL.CellClick
        PopRefNo(Me.dtgHBL.CurrentCell.Value)
    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs) Handles dtTo.ValueChanged
        PopMBL()
        If Me.dtgMBL.Rows.Count > 0 Then
            PopHBL(Me.dtgMBL.CurrentCell.Value)
        End If
    End Sub

    Private Sub dtgMBL_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgMBL.CellDoubleClick
        Select Case Me.Tag

            Case "IMPFCI"

                frmInvoiceImpF.RetrieveMBL(Me.dtgMBL.CurrentCell.Value)
            Case "IMPB"

                'frmIMPDCBill.RetrieveMBL(Me.dtgMBL.CurrentCell.Value)
        End Select

        Me.Close()
    End Sub

    Private Sub dtgHBL_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgHBL.CellDoubleClick
        Select Case Me.Tag

            Case "IMPFCI"

                frmInvoiceImpF.RetrieveMBL(dtgMBL.CurrentRow.Cells(colMBL.Name).Value)
                frmInvoiceImpF.cboHBL.Text = dtgHBL.CurrentRow.Cells(colHBL.Name).Value

            Case "IMPD"
                'frmIMPDCBill.RetrieveMBL(dtgMBL.CurrentRow.Cells(colMBL.Name).Value)
                'frmIMPDCBill.cboHBL.Text = dtgHBL.CurrentRow.Cells(colHBL.Name).Value
        End Select
        Me.Close()
    End Sub

    Private Sub optRefNo_CheckedChanged(sender As Object, e As EventArgs) Handles optRefNo.CheckedChanged
        Me.lblPrefix.Text = ""
        Me.txtSearch.Text = ""
        Me.txtSearch.Focus()
    End Sub

    Private Sub optMBL_CheckedChanged(sender As Object, e As EventArgs) Handles optMBL.CheckedChanged
        Me.lblPrefix.Text = ""
        Me.txtSearch.Text = ""
        Me.txtSearch.Focus()
    End Sub

    Private Sub optHBL_CheckedChanged(sender As Object, e As EventArgs) Handles optHBL.CheckedChanged
        Me.lblPrefix.Text = ""
        Me.txtSearch.Text = ""
        Me.txtSearch.Focus()
    End Sub

    Private Sub btnAdvanceSearch_Click(sender As Object, e As EventArgs) Handles btnAdvanceSearch.Click
        'frmExpImpBBillSearch.Text = "Search Import Forwarding Billing"
        'frmExpImpBBillSearch.ShowDialog()
        If Me.txtSearch.Text <> "" Then
            If SearchBy("RefNo", Me.txtSearch.Text) = False Then Exit Sub
            Me.Close()
        End If
    End Sub
End Class