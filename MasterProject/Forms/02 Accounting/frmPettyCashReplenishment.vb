Imports MySql.Data.MySqlClient
Public Class frmPettyCashReplenishment
    Private Sub frmPettyCashReplenishment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'newload = True
        'FillBranch()
        SetColumnProp()
        FillComboBox(Me.cboFund, "SELECT FundName FROM lib_pcv_fund", "FundName")
        'FillTheCombos()
        txtFundKey.Text = ""
        dgReplenishment.Rows.Clear()
        txtForReplenishment.Text = ""
        btSave.Enabled = False
        btReport.Enabled = False
        txtBranchCode.Text = ""
        txtForEncashment.Text = ""
        txtUnliquidated.Text = ""
        'newload = False
    End Sub

    Private Sub SetColumnProp()
        With Me.dgReplenishment
            With Me.dgReplenishment

                .Columns.Add("", "PCR #")
                .Columns.Add("", "PCR Date")
                .Columns.Add("", "Payee")
                .Columns.Add("", "Department")
                .Columns.Add("", "Decription/Particulars")
                .Columns.Add("", "Amount")

                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = True
                .MultiSelect = False

            End With
            .Columns(0).Width = 100
            .Columns(1).Width = 200
            .Columns(2).Width = 250
            .Columns(3).Width = 150
            .Columns(4).Width = 300
            .Columns(5).Width = 100

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        Me.Refresh()
    End Sub

    Private Sub cboFund_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFund.SelectedIndexChanged
        If Me.cboFund.SelectedIndex = -1 Then Exit Sub
        Dim cmd2 As MySql.Data.MySqlClient.MySqlCommand
        Dim strSQL2 As String


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        strSQL2 = "SELECT lib_pcv_fund.FundCode, lib_pcv_fund.FundName, lib_pcv_fund.BranchCode, lib_pcv_fund.FundRevFund " &
                "FROM lib_pcv_fund " &
               "WHERE FundName = '" & Me.cboFund.Text & "'"

        cmd2 = New MySql.Data.MySqlClient.MySqlCommand(strSQL2, cnnDBMaster)

        Dim reader2 As MySql.Data.MySqlClient.MySqlDataReader = cmd2.ExecuteReader()

        While reader2.Read()

            If reader2.Item("BranchCode") <> strSiteCode Then
                'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_All_Branch") = "False" Then
                '    MsgBox("You have no permission to view this record", vbInformation, "System Message")
                '    cmd2.Dispose()
                '    reader2.Close()
                '    Exit Sub

                'End If
            End If

            Me.txtFundKey.Text = reader2.Item("FundCode")
            Me.txtBranchCode.Text = reader2.Item("BranchCode")
            Me.txtRevFund.Text = reader2.Item("FundRevFund")

        End While

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()

        PopulatePosted()
        ComputeForReplenishment()
        SetRowColor()
        btSave.Enabled = True
        btReport.Enabled = False
        ComputeUnliquidated(Me.txtFundKey.Text)
        ComputeForEncashment(Me.txtFundKey.Text)
        Me.txtName.Text = ""
        Me.txtDateSave.Text = ""
        Me.txtCreatedBy.Text = ""
        Me.txtTotalAmount.Text = ""
        Me.txtFundCode.Text = ""
        Me.txtReplenish.Text = ""
        Me.txtFundName.Text = ""
        btReport.Enabled = False
        If Me.dgReplenishment.RowCount = 0 Then
            btSave.Enabled = False
        Else
            btSave.Enabled = True
        End If
        txtBalance.Text = Val(txtRevFund.Text) - (Val(txtForReplenishment.Text) + Val(txtUnliquidated.Text) + Val(txtForEncashment.Text))
    End Sub

    Public Sub ComputeForEncashment(ByVal str As String)
        Dim cmdSQL As New MySqlCommand
        Dim strSQL As String

        strSQL = "SELECT tbl_pcv_replenish.FundCode, SUM(tbl_pcv_replenish.Amount), tbl_pcv_replenish.Replenish " &
                 "FROM tbl_pcv_replenish " &
                 "WHERE tbl_pcv_replenish.Replenish = 0 and tbl_pcv_replenish.FundCode ='" & str & "' " &
                 "GROUP BY tbl_pcv_replenish.FundCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        While reader2.Read

            Me.txtForEncashment.Text = reader2.Item("SUM(tbl_pcv_replenish.Amount)")

        End While

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()
    End Sub

    Public Sub ComputeUnliquidated(ByVal str As String)
        Dim cmdSQL As New MySqlCommand
        Dim strSQL As String

        strSQL = "SELECT tbl_request.REQ_Release, tbl_request.REQ_Liquidated, tbl_request.REQ_Cancel, SUM(tbl_request.REQ_TotalAmt), tbl_request.REQ_Nbr, tbl_request.REQ_PCVRepFund " &
                 "FROM tbl_request " &
                 "WHERE tbl_request.REQ_Release = 1 and tbl_request.REQ_Liquidated = '0' and tbl_request.REQ_Cancel ='0' and tbl_request.REQ_PCVRepFund = '" & str & "' " &
        "GROUP BY tbl_request.REQ_PCVRepFund"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        While reader2.Read

            Me.txtUnliquidated.Text = reader2.Item("SUM(tbl_request.REQ_TotalAmt)")

        End While

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()
    End Sub
    Public Sub ComputeForReplenishment()
        Me.txtForReplenishment.Text = Format(SumAmount)
    End Sub
    Public Function SumAmount() As Double
        Dim i As Integer
        Dim h As DataGridViewRow

        For i = 0 To Me.dgReplenishment.Rows.Count - 1
            h = Me.dgReplenishment.Rows(i)
            If Not Len(h.Cells(5).Value) = 0 Then
                SumAmount = SumAmount + h.Cells(5).Value
            End If
        Next

        Return SumAmount
    End Function
    Private Sub SetRowColor()
        Dim grid As DataGridView, x As Integer, y As Integer, pcr As String, newcolor As Color
        grid = Me.dgReplenishment
        If grid.RowCount >= 1 Then
            pcr = grid.Rows(0).Cells(0).Value
            newcolor = Color.LightBlue
        Else
            Exit Sub
        End If

        For x = 0 To grid.RowCount - 1
            If grid.Rows(x).Cells(0).Value = pcr Then
                For y = 0 To grid.ColumnCount - 1
                    grid.Rows(x).Cells(y).Style.BackColor = newcolor
                Next
            Else
                If newcolor = Color.LightBlue Then
                    newcolor = Color.White
                Else
                    newcolor = Color.LightBlue
                End If
                For y = 0 To grid.ColumnCount - 1
                    grid.Rows(x).Cells(y).Style.BackColor = newcolor
                Next
                pcr = grid.Rows(x).Cells(0).Value
            End If
        Next
    End Sub

    Private Sub PopulatePosted()
        Dim strSQL As String

        strSQL = "SELECT tbl_requestd.REQD_REQNbr, tbl_requestd.REQD_Particulars, tbl_requestd.REQD_Amount, tbl_requestd.REQD_Index, tbl_request.REQ_Nbr, tbl_request.REQ_Liquidated, tbl_request.REQ_TotalAmt, tbl_request.REQ_LiquidationDate,  tbl_request.REQ_PrepDate, tbl_request.REQ_PayeeID, tbl_vendor.Code, tbl_vendor.Description, tbl_requestd.REQD_CostCenter, tbl_request.REQ_PCVRepSave, tbl_request.REQ_BranchCode, tbl_dept.Dept_Name " &
                 "FROM ((tbl_request INNER JOIN tbl_requestd ON tbl_request.REQ_Nbr = tbl_requestd.REQD_REQNbr) INNER JOIN tbl_vendor ON tbl_request.REQ_PayeeID = tbl_vendor.Code) INNER JOIN tbl_dept ON tbl_requestd.REQD_Costcenter = tbl_dept.Dept_Code " &
        "WHERE tbl_request.REQ_Liquidated = '1' and tbl_request.REQ_PCVRepFund = '" & txtFundKey.Text & "' and tbl_request.REQ_PCVRepSave = '0' and tbl_request.REQ_BranchCode = '" & Me.txtBranchCode.Text & "' and REQ_ReqType = 1 " &
          "ORDER BY tbl_request.REQ_Nbr"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView
        dgReplenishment.Rows.Clear()
        While reader2.Read
            gridBook = Me.dgReplenishment
            gridBook.Rows.Add(reader2.Item("REQ_Nbr"), reader2.Item("REQ_PrepDate"), reader2.Item("Description"), reader2.Item("Dept_Name"), reader2.Item("REQD_Particulars"), reader2.Item("REQD_Amount"))
            i = i + 1

        End While

        cmd2.Dispose()
        reader2.Close()

    End Sub

    Private Sub dgReplenishment_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReplenishment.CellContentClick

    End Sub

    Private Sub dgReplenishment_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgReplenishment.CellPainting
        ' merge same pcr #
        Dim i As Integer
        Dim i2 As Integer
        For i = 0 To Me.dgReplenishment.Columns.Count - 2
            If e.ColumnIndex = i AndAlso e.RowIndex <> -1 Then

                Using gridBrush As Brush = New SolidBrush(Me.dgReplenishment.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)
                        ' Clear cell  
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                        ' DataGridView3.RowsDefaultCellStyle.BackColor = Color.LightBlue
                        ' Draw line (bottom border and right border of current cell)  
                        'If next row cell has different content, only draw bottom border line of current cell  

                        If e.ColumnIndex = 2 Then
                            If e.RowIndex < dgReplenishment.Rows.Count - 2 AndAlso dgReplenishment.Rows(e.RowIndex + 1).Cells(0).Value.ToString() <> dgReplenishment.Rows(e.RowIndex).Cells(0).Value.ToString() Then
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                                i2 = i2 + 1
                                '   

                            End If
                        ElseIf e.ColumnIndex = 3 Then
                            If e.RowIndex < dgReplenishment.Rows.Count - 2 AndAlso dgReplenishment.Rows(e.RowIndex + 1).Cells(0).Value.ToString() <> dgReplenishment.Rows(e.RowIndex).Cells(0).Value.ToString() Then
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                            End If
                        Else
                            If e.RowIndex < dgReplenishment.Rows.Count - 1 AndAlso dgReplenishment.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                            End If

                        End If

                        ' Draw right border line of current cell  
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        ' draw/fill content in current cell, and fill only one cell of multiple same cells  
                        If Not e.Value Is Nothing Then

                            If e.ColumnIndex = 2 Then
                                If e.RowIndex > 0 AndAlso dgReplenishment.Rows(e.RowIndex - 1).Cells(0).Value.ToString() = dgReplenishment.Rows(e.RowIndex).Cells(0).Value.ToString() Then
                                Else


                                    e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                                    'e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                End If
                            ElseIf e.ColumnIndex = 3 Then
                                If e.RowIndex > 0 AndAlso dgReplenishment.Rows(e.RowIndex - 1).Cells(0).Value.ToString() = dgReplenishment.Rows(e.RowIndex).Cells(0).Value.ToString() Then
                                Else


                                    e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                                    'e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                End If
                            Else
                                If e.RowIndex > 0 AndAlso dgReplenishment.Rows(e.RowIndex - 1).Cells(i).Value.ToString() = e.Value.ToString() Then
                                Else


                                    e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                                    'e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                End If
                            End If
                        End If

                        e.Handled = True

                    End Using

                End Using

            End If
        Next
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub SearchFundKey(ByVal str As String)
        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM tbl_pcv_replenish " &
                 "WHERE tbl_pcv_replenish.RepNumber = '" & str & " '"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            Me.txtName.Text = reader.Item("RepNumber")
            Me.txtDateSave.Text = reader.Item("PrepDate")
            Me.txtCreatedBy.Text = reader.Item("PrepBy")
            Me.txtTotalAmount.Text = reader.Item("Amount")
            Me.txtFundCode.Text = reader.Item("FundCode")
            Me.txtFundName.Text = GetStringValue("Select FundName from lib_pcv_fund where FundCode = '" & Me.txtFundCode.Text & "'", "FundName")
            Me.txtRevolvingFund.Text = GetDoubleValue("Select FundRevFund from lib_pcv_fund where FundCode = '" & Me.txtFundCode.Text & "'", "FundRevFund")
            Me.txtReplenish.Text = reader.Item("Replenish")

            'check if replenished

            If Not IsDBNull(reader.Item("CRNbr")) Then
                Me.txtCRNbr.Text = reader.Item("CRNbr")

            Else
                Me.txtCRNbr.Text = ""
            End If

            If Not IsDBNull(reader.Item("RepDate")) Then
                Me.txtReplenishDate.Text = reader.Item("RepDate")
            Else
                Me.txtReplenishDate.Text = ""
            End If

            If Not IsDBNull(reader.Item("RepBy")) Then
                Me.txtReplenishBy.Text = reader.Item("RepBy")
            Else
                Me.txtReplenishBy.Text = ""
            End If

        End While


        cmd.Dispose()
        reader.Close()


        cnnDBMaster.Close()

        PopulateDetails(str)

        ComputeUnliquidated(Me.txtFundCode.Text)
        ComputeForEncashment(Me.txtFundCode.Text)

        Me.btSave.Enabled = False
        RetrieveVoucher()

    End Sub
    Public Sub RetrieveVoucher()
        Dim strSQL As String


        strSQL = "SELECT * " &
                  "FROM tbl_cvp " &
                  "WHERE tbl_cvp.ReqNo = '" & Me.txtCRNbr.Text & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            If Not IsDBNull(reader.Item("CVNo")) Then
                Me.txtCVNbr.Text = reader.Item("CVNo")
            Else
                Me.txtCVNbr.Text = "n/a"
            End If

        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Public Sub Save()
        Dim cmdSQL As New MySqlCommand
        Dim dtCurrent As Date = GetServerDate()

        'FundKey = Me.txtFundKey.Text


        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim strFundKey As String = "" & GetPCVFundKeyAIS(Me.txtFundKey.Text) & ""

        Try


            cmdSQL.CommandText = ("INSERT INTO tbl_pcv_replenish (`RepNumber`, `PrepDate`, Amount, PrepBy, FundCode, Replenish)  VALUES " &
                                 "               (@RepNumber, @PrepDate, @Amount, @PrepBy, @FundCode,  @Replenish)")


            With cmdSQL.Parameters

                .AddWithValue("@RepNumber", strFundKey)
                .AddWithValue("@PrepDate", dtCurrent)
                .AddWithValue("@Amount", CDbl(txtForReplenishment.Text))
                .AddWithValue("@PrepBy", strCurrentUser)
                .AddWithValue("@FundCode", Me.txtFundKey.Text)
                .AddWithValue("@Replenish", 0)
                Me.txtName.Text = strFundKey

            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            'update tbl_request
            Dim i As Integer
            Dim h As DataGridViewRow
            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            For i = 0 To Me.dgReplenishment.Rows.Count - 1
                h = Me.dgReplenishment.Rows(i)
                Dim cmdSQL2 As New MySqlCommand

                Dim sSQL2 As String = "UPDATE  tbl_request SET "

                sSQL2 += " REQ_PCVRepSave=@REQ_PCVRepSave, "

                sSQL2 += " REQ_PCVRepFundKey=@REQ_PCVRepFundKey "

                sSQL2 += " WHERE REQ_Nbr = '" & h.Cells(0).Value & "'"

                cmdSQL2.CommandText = sSQL2
                cmdSQL2.Connection = cnnDBMaster

                With cmdSQL2.Parameters

                    .AddWithValue("@REQ_PCVRepFundKey", strFundKey)
                    .AddWithValue("@REQ_PCVRepSave", 1)

                End With

                cmdSQL2.ExecuteNonQuery()
                cmdSQL2.Dispose()
            Next

            For i = 0 To dgReplenishment.Rows.Count - 1
                h = Me.dgReplenishment.Rows(i)
                Dim cmdSQL3 As New MySqlCommand

                Dim sSQL3 As String = "Update tbl_pca SET "
                sSQL3 += " PCA_RepNumber=@PCA_RepNumber "
                sSQL3 += " WHERE PCA_Nbr= '" & h.Cells(0).Value & "'"

                cmdSQL3.CommandText = sSQL3
                cmdSQL3.Connection = cnnDBMaster


                With cmdSQL3.Parameters
                    .AddWithValue("@PCA_RepNumber", strFundKey)
                End With

                cmdSQL3.ExecuteNonQuery()
                cmdSQL3.Dispose()
            Next

            cnnDBMaster.Close()
            cnnDBMaster.Dispose()
            MsgBox("Done Saving.", MsgBoxStyle.Information, "System Message")


        Catch ex As Exception
            MsgBox("There was an error trying to save the record - " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        SearchFundKey(strFundKey)
        RetrieveVoucher()
        Me.txtFundName.Text = GetStringValue("Select lib_pcv_fund.FundName FROM lib_pcv_fund where lib_pcv_fund.FundCode ='" & Me.txtFundCode.Text & "'", "FundName")
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        If MsgBox("Save this record?", vbYesNo, "Confirm Save") = vbNo Then
            Exit Sub
        Else
            Save()
            btSave.Enabled = False
            btReport.Enabled = True
        End If
    End Sub

    Private Sub btReport_Click(sender As Object, e As EventArgs) Handles btReport.Click
        Dim strSQL As String

        strSQL = "SELECT * " &
                 "FROM tbl_request " &
                 "WHERE tbl_request.REQ_Invoice ='" & Me.txtName.Text & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        With reader.Read

            If reader.HasRows = True Then
                MsgBox("Already Requested", MsgBoxStyle.Critical, "Invalid Transaction")

                reader.Close()
                'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_Reprint_PCVRep") = True Then
                '    If MsgBox("Are you sure you want to print another copy of Replenishment " & Me.txtFundName.Text & "?", vbYesNo, "Confirm Re-Print") = vbNo Then
                '        Exit Sub
                '    Else
                '        frmReportReplenish.ShowDialog()
                '        Exit Sub
                '    End If
                'Else

                '    'check if account entry is revised
                '    If AllowReprintRevisedAcctgEntry(Me.txtName.Text) = True Then
                '        UpdatePCFReprint(Me.txtName.Text)
                '        frmReportReplenish.ShowDialog()
                '        Exit Sub
                '    End If

                '    MsgBox("You are not allowed to re-print this replenishment report. Please contact System Administrator.", vbInformation, "System Message")
                '    cmd.Dispose()
                '    reader.Close()
                '    cnnDBMaster.Close()
                '    Exit Sub
                'End If

            End If
        End With
        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        frmPCVCheckRequest.txtInvoice.Text = txtName.Text

        frmPCVCheckRequest.txtGrandTotal.Text = txtTotalAmount.Text
        frmPCVCheckRequest.ShowDialog()
    End Sub
    Public Sub UpdatePCFReprint(ByVal strRepNumber As String)
        Dim strsql As String
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()

        strsql = "UPDATE tbl_pcv_replenish SET " &
                    "Allow_Reprint = @Allow_Reprint " &
                "WHERE RepNumber = '" & strRepNumber & "'"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        With cmdSQL.Parameters
            .AddWithValue("@Allow_Reprint", 0)
        End With

        cmdSQL.ExecuteNonQuery()
        cmdSQL.Dispose()
        cnn.Close()
    End Sub
    Public Function AllowReprintRevisedAcctgEntry(ByVal strRepNumber As String) As Boolean
        AllowReprintRevisedAcctgEntry = False
        Dim strSQL As String

        strSQL = "SELECT Allow_Reprint " &
                 "FROM tbl_pcv_replenish " &
                 "WHERE tbl_pcv_replenish.RepNumber = '" & strRepNumber & "'"
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmd2 = New MySqlCommand(strSQL, cnn)

        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        If reader2.HasRows = False Then
            AllowReprintRevisedAcctgEntry = False
            cmd2.Dispose()
            reader2.Close()
            cnn.Close()
            Exit Function
        End If

        While reader2.Read
            AllowReprintRevisedAcctgEntry = reader2.Item("Allow_Reprint")
        End While

        cmd2.Dispose()
        reader2.Close()
        cnn.Close()

    End Function

    Private Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        frmSearchFundKey.ShowDialog()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        SetRowColor()
    End Sub

    Public Sub PopulateDetails(ByVal str As String)
        Dim strSQL As String

        strSQL = "SELECT tbl_request.REQ_Nbr, tbl_requestd.REQD_Particulars, tbl_requestd.REQD_Amount, tbl_request.REQ_PrepDate, tbl_vendor.Description, tbl_dept.Dept_Name " &
                 "FROM ((tbl_request INNER JOIN tbl_requestd ON tbl_request.REQ_Nbr = tbl_requestd.REQD_REQNbr) INNER JOIN tbl_vendor ON tbl_request.REQ_PayeeID = tbl_vendor.Code) INNER JOIN tbl_dept ON tbl_requestd.REQD_CostCenter = tbl_dept.Dept_Code " &
        "WHERE tbl_request.REQ_PCVRepFundKey = '" & str & "'" &
          " ORDER BY tbl_requestd.REQD_REQNbr"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)

        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView
        dgReplenishment.Rows.Clear()
        While reader2.Read
            gridBook = Me.dgReplenishment
            gridBook.Rows.Add(reader2.Item("REQ_Nbr"), reader2.Item("REQ_PrepDate"), reader2.Item("Description"), reader2.Item("Dept_Name"), reader2.Item("REQD_Particulars"), reader2.Item("REQD_Amount"))
            i = i + 1
        End While

        cmd2.Dispose()
        reader2.Close()

    End Sub
End Class