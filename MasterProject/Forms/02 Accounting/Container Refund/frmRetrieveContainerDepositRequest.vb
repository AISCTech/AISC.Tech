Imports MySql.Data.MySqlClient
Public Class frmRetrieveContainerDepositRequest
    Dim BookNbrStatus As String
    Dim BookNbr As String
    Dim strORNbr As String

    Private Sub frmRetrieveContainerDepositRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetColumnProp()

        Me.optCheck.Checked = True
    End Sub
    Private Function CheckIfLiquidatedCV(ByVal strVal As String, ByVal strAPAmt As String, ByVal strCVAmt As String) As Boolean
        Dim dblAPAmt As Double, dblCVAmt As Double
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        Dim strsql As String = "SELECT tbl_apvgl.APVGL_CR, SUM(tbl_cvp.CVAmt), tbl_cv.ORNo " &
                                "FROM (((tbl_cv INNER JOIN tbl_cvp ON tbl_cv.CVNo = tbl_cvp.CVNo) " &
                                "INNER JOIN tbl_apv ON tbl_cvp.ReqNo  = tbl_apv.APV_ReqNo) " &
                                "INNER JOIN tbl_apvgl ON tbl_apv.APV_Nbr = tbl_apvgl.APVGL_APVNbr) " &
                                "WHERE tbl_cvp.ReqNo = '" & strVal & "' " &
                                "AND tbl_cv.Liquidated = TRUE AND tbl_cv.Cancelled = FALSE " &
                                "AND tbl_apv.APV_Cancel = FALSE AND tbl_apvgl.APVGL_Account_Code = '2010'"

        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        While reader.Read
            If IsDBNull(reader.Item(strAPAmt)) = False Then
                dblAPAmt = reader.Item(strAPAmt)
            Else
                dblAPAmt = 0
            End If

            If IsDBNull(reader.Item(strCVAmt)) = False Then
                dblCVAmt = reader.Item(strCVAmt)
            Else
                dblCVAmt = 0
            End If
        End While

        If (dblAPAmt > dblCVAmt) Or dblAPAmt = 0 Or dblCVAmt = 0 Then
            CheckIfLiquidatedCV = False
            strORNbr = ""
        Else
            CheckIfLiquidatedCV = True
            strORNbr = reader.Item("ORNo")
        End If

        reader.Close()
        cmdSQL.Dispose()
        cnn.Close()
    End Function

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        frmContainerRefund.ResetForm()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PopulateDetails(ByVal searchkey As String, ByVal dtfrom As String, ByVal dtto As String)
        Dim strSQL As String

        Me.DataGridView1.Rows.Clear()

        Dim cmdMDB As MySql.Data.MySqlClient.MySqlCommand

        strSQL = "SELECT tbl_requestd.REQD_REQNbr, tbl_requestd.REQD_BookNbr, tbl_requestd.REQD_BookNbr, tbl_requestd.REQD_Consignee, tbl_requestd.REQD_ContainerNo, SUM(tbl_requestd.REQD_Amount), tbl_requestd.REQD_Key, tbl_requestd.REQD_Index, tbl_requestd.REQD_Particulars, tbl_request.REQ_Cancel, tbl_request.REQ_Liquidated, tbl_vendor.VendorID, tbl_vendor.VendorName, tbl_request.REQ_PayeeID " &
                 "FROM (tbl_requestd INNER JOIN tbl_request ON tbl_requestd.REQD_REQNbr = tbl_request.REQ_Nbr) INNER JOIN tbl_vendor ON tbl_request.REQ_PayeeID = tbl_vendor.VendorID " &
                 "WHERE (((tbl_requestd.REQD_Particulars) like '%Container Deposit%' and tbl_request.REQ_Cancel = 0)) " &
                 "and (tbl_requestd.REQD_BookNbr like '%" & searchkey & "%' or tbl_vendor.VendorName like '%" & searchkey & "%' " &
                 "or tbl_requestd.REQD_Consignee like '%" & searchkey & "%' or tbl_requestd.REQD_ContainerNo like '%" & searchkey & "%') " &
                 "and (tbl_request.REQ_PrepDate BETWEEN '" & dtfrom & "' and '" & dtto & "') " &
                 "GROUP BY tbl_requestd.REQD_REQNbr"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        Dim i As Integer
        Dim gridBook As DataGridView
        'Me.DataGridView1.Rows.Clear()
        While reader2.Read
            gridBook = Me.DataGridView1
            If IsDBNull(reader2.Item("REQD_BookNbr")) = False Then
                BookNbr = reader2.Item("REQD_BookNbr")


                If reader2.Item("REQD_Key") = "IMPB" Then

                    Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

                    Dim strSQLFORW As String = "SELECT CtrlNbr, Status FROM tbl_importbook WHERE CtrlNbr = '" & BookNbr & "'"

                    cmdMDB = New MySql.Data.MySqlClient.MySqlCommand(strSQLFORW, cnn)

                    If cnn.State <> ConnectionState.Open Then cnn.Open()

                    Dim dbReader As MySql.Data.MySqlClient.MySqlDataReader = cmdMDB.ExecuteReader()
                    While dbReader.Read
                        If dbReader.Item("Status") = 3 Then
                            BookNbrStatus = "Cancelled"
                        ElseIf dbReader.Item("Status") = 1 Then
                            BookNbrStatus = "Open"
                        ElseIf dbReader.Item("Status") = 2 Then
                            BookNbrStatus = "Posted"
                            'ElseIf dbReader.Item("Status") = 4 Then
                            '    BookNbrStatus = "Posted"
                            'ElseIf dbReader.Item("Status") = 5 Then
                            '    BookNbrStatus = "Re-book"
                            'ElseIf dbReader.Item("Status") = 6 Then
                            'BookNbrStatus = "Foul"
                        End If

                    End While
                    dbReader.Close()
                    cmdMDB.Dispose()
                ElseIf reader2.Item("REQD_Key") = "EXP" Then
                    'Dim strSQLEXP As String = "SELECT BKS.BKS_Nbr, BKS.BKS_Status " & _
                    '        "FROM BKS " & _
                    '        "WHERE (((BKS.BKS_Nbr)='" & BookNbr & "'))"

                    'cmdMDB = New OleDb.OleDbCommand(strSQLEXP, connExport)

                    'If connExport.State <> ConnectionState.Open Then connExport.Open()

                    'Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
                    'While dbReader.Read
                    '    If dbReader.Item("BKS_Status") = 3 Then
                    '        BookNbrStatus = "Cancelled"
                    '    ElseIf dbReader.Item("BKS_Status") = 1 Then
                    '        BookNbrStatus = "Open"
                    '    ElseIf dbReader.Item("BKS_Status") = 2 Then
                    '        BookNbrStatus = "Loaded"
                    '    ElseIf dbReader.Item("BKS_Status") = 4 Then
                    '        BookNbrStatus = "Posted"
                    '    ElseIf dbReader.Item("BKS_Status") = 5 Then
                    '        BookNbrStatus = "Re-book"
                    '    ElseIf dbReader.Item("BKS_Status") = 6 Then
                    '        BookNbrStatus = "Foul"
                    '    End If
                    '    'BookNbrStatus = dbReader.Item("BKS_Status")
                    'End While

                    'dbReader.Close()
                    'cmdMDB.Dispose()
                End If


                gridBook.Rows.Add(BookNbr, reader2.Item("REQD_REQNbr"), reader2.Item("VendorName"), reader2.Item("REQD_BookNbr"), BookNbrStatus, reader2.Item("REQD_Consignee"), reader2.Item("REQD_ContainerNo"), reader2.Item("SUM(tbl_requestd.REQD_Amount)"), reader2.Item("REQD_Key"), reader2.Item("REQD_Index"), reader2.Item("REQD_Particulars"), "", reader2.Item("REQ_Liquidated"))
                i = i + 1
            End If

        End While

        cmd2.Dispose()
        reader2.Close()
    End Sub
    Private Sub StatusColor()
        For x = 0 To Me.DataGridView1.Rows.Count - 1
            With Me.DataGridView1.Rows(x)
                'If Liquidatedin new CV
                If CheckIfLiquidatedCV(.Cells(1).Value, "APVGL_CR", "SUM(tbl_cvp.CVAmt)") = True Then
                    .Cells(11).Value = strORNbr
                    .Cells(12).Value = True
                End If

                If CBool(.Cells(12).Value) = True Then
                    For y = 0 To Me.DataGridView1.Columns.Count - 1
                        .Cells(y).Style.BackColor = Color.LightBlue
                        .Cells(y).Style.SelectionBackColor = Color.Empty
                    Next
                Else
                    For y = 0 To Me.DataGridView1.Columns.Count - 1
                        .Cells(y).Style.BackColor = Color.LightCoral
                        .Cells(y).Style.SelectionBackColor = Color.DarkRed
                    Next
                End If
                If frmContainerRefund.CheckIfRequestExistOnContRef(.Cells(1).Value) = True Then
                    For y = 0 To Me.DataGridView1.Columns.Count - 1
                        .Cells(y).Style.BackColor = Color.LightGreen
                        .Cells(y).Style.SelectionBackColor = Color.DarkGreen
                    Next
                End If
            End With
        Next
    End Sub

    'Private Sub PopulateCRDDetails(ByVal searchkey As String, ByVal dtfrom As String, ByVal dtto As String)
    '    Dim strSQL As String

    '    Me.DataGridView1.Rows.Clear()

    '    Dim cmdMDB As OleDb.OleDbCommand

    '    strSQL = "SELECT ap_crd.CRD_CPRNbr, ap_crd.CRD_BookNbr, ap_crd.CRD_BookComp, ap_crd.CRD_ShipCons, ap_crd.CRD_ContHBL, SUM(ap_crd.CRD_Amount), ap_crd.CRD_Key, ap_crd.CRD_Index, ap_crd.CRD_Particulars, ap_crp.CRP_Cancel, ap_crp.CRP_Liquidated, lib_vendor.VendorID, lib_vendor.VendorName, ap_crp.CRP_PayeeID, ap_crp.CRP_ORNbr " & _
    '             "FROM (ap_crd INNER JOIN ap_crp ON ap_crd.CRD_CPRNbr = ap_crp.CRP_Nbr) INNER JOIN lib_vendor ON ap_crp.CRP_PayeeID = lib_vendor.VendorID " & _
    '             "WHERE (((ap_crd.CRD_Particulars) like '%Container Deposit%' and ap_crp.CRP_Cancel = 0)) " & _
    '             "and (ap_crd.CRD_BookComp like '%" & searchkey & "%' or lib_vendor.VendorName like '%" & searchkey & "%' " & _
    '             "or ap_crd.CRD_ShipCons like '%" & searchkey & "%' or ap_crd.CRD_ContHBL like '%" & searchkey & "%') " & _
    '             "and (ap_crp.CRP_PrepDate BETWEEN '" & dtfrom & "' and '" & dtto & "') " & _
    '             "GROUP BY ap_crd.CRD_CPRNbr"

    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmd2 = New MySqlCommand(strSQL, connAcctg)
    '    Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

    '    Dim i As Integer
    '    Dim gridBook As DataGridView
    '    'Me.DataGridView1.Rows.Clear()
    '    While reader2.Read
    '        gridBook = Me.DataGridView1
    '        If IsDBNull(reader2.Item("CRD_BookNbr")) = False Then
    '            BookNbr = reader2.Item("CRD_BookNbr")


    '            If reader2.Item("CRD_Key") = "FORW" Or reader2.Item("CRD_Key") = "Forw" Then
    '                Dim strSQLFORW As String = "SELECT BookNum, Status FROM ImpMBL WHERE Booknum = '" & BookNbr & "'"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLFORW, connImport)

    '                If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                While dbReader.Read
    '                    If dbReader.Item("Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If

    '                End While
    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            ElseIf reader2.Item("CRD_Key") = "EXP" Then
    '                Dim strSQLEXP As String = "SELECT BKS.BKS_Nbr, BKS.BKS_Status " & _
    '                        "FROM BKS " & _
    '                        "WHERE (((BKS.BKS_Nbr)='" & BookNbr & "'))"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLEXP, connExport)

    '                If connExport.State <> ConnectionState.Open Then connExport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                While dbReader.Read
    '                    If dbReader.Item("BKS_Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("BKS_Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("BKS_Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("BKS_Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("BKS_Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("BKS_Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If
    '                    'BookNbrStatus = dbReader.Item("BKS_Status")
    '                End While

    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            ElseIf reader2.Item("CRD_Key") = "BRKG" Then

    '                Dim strSQLBRKG As String = "SELECT ImpBrokerage.CargoLoad, Consignee, Services, ControlNum, Status " & _
    '                        "From ImpBrokerage " & _
    '                        "WHERE (((ImpBrokerage.ControlNum)= '" & BookNbr & "'))"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLBRKG, connImport)

    '                If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()

    '                While dbReader.Read
    '                    If dbReader.Item("Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If
    '                End While
    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            End If


    '            gridBook.Rows.Add(BookNbr, reader2.Item("CRD_CPRNbr"), reader2.Item("VendorName"), reader2.Item("CRD_BookComp"), BookNbrStatus, reader2.Item("CRD_ShipCons"), reader2.Item("CRD_ContHBL"), reader2.Item("SUM(ap_crd.CRD_Amount)"), reader2.Item("CRD_Key"), reader2.Item("CRD_Index"), reader2.Item("CRD_Particulars"), reader2.Item("CRP_ORNbr"), reader2.Item("CRP_Liquidated"))
    '            i = i + 1
    '        End If

    '    End While

    '    If connExport.State = ConnectionState.Open Then connExport.Close()
    '    If connImport.State = ConnectionState.Open Then connImport.Close()

    '    cmd2.Dispose()
    '    reader2.Close()
    'End Sub

    '    Private Sub PopulateCheckDetails()
    '        Dim strSQL As String

    '        Dim cmdMDB As OleDb.OleDbCommand

    '        strSQL = "SELECT ap_crd.CRD_CPRNbr, ap_crd.CRD_BookNbr, ap_crd.CRD_BookComp, ap_crd.CRD_ShipCons, ap_crd.CRD_ContHBL, SUM(ap_crd.CRD_Amount), ap_crd.CRD_Key, ap_crd.CRD_Index, ap_crd.CRD_Particulars, ap_crp.CRP_Cancel, ap_crp.CRP_Liquidated, lib_vendor.VendorID, lib_vendor.VendorName, ap_crp.CRP_PayeeID, ap_crp.CRP_ORNbr " & _
    '                 "FROM (ap_crd INNER JOIN ap_crp ON ap_crd.CRD_CPRNbr = ap_crp.CRP_Nbr) INNER JOIN lib_vendor ON ap_crp.CRP_PayeeID = lib_vendor.VendorID " & _
    '                 "WHERE (((ap_crd.CRD_Particulars)='Container Deposit' and ap_crp.CRP_Cancel = 0)) " & _
    '                 "GROUP BY ap_crd.CRD_CPRNbr ORDER BY ap_crp.CRP_PrepDate"

    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '        Dim cmd2 = New MySqlCommand(strSQL, connAcctg)
    '        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

    '        Dim i As Integer
    '        Dim gridBook As DataGridView
    '        Me.DataGridView1.Rows.Clear()
    '        While reader2.Read
    '            gridBook = Me.DataGridView1
    '            If IsDBNull(reader2.Item("CRD_BookNbr")) = True Then
    '                GoTo Skip1
    '            End If
    '            BookNbr = reader2.Item("CRD_BookNbr")
    '            If reader2.Item("CRD_Key") = "FORW" Or reader2.Item("CRD_Key") = "Forw" Then
    '                Dim strSQLFORW As String = "SELECT BookNum, Status FROM ImpMBL WHERE Booknum = '" & BookNbr & "'"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLFORW, connImport)

    '                If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                While dbReader.Read
    '                    If dbReader.Item("Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If

    '                End While
    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            ElseIf reader2.Item("CRD_Key") = "EXP" Then
    '                Dim strSQLEXP As String = "SELECT BKS.BKS_Nbr, BKS.BKS_Status " & _
    '                        "FROM BKS " & _
    '                        "WHERE (((BKS.BKS_Nbr)='" & BookNbr & "'))"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLEXP, connExport)

    '                If connExport.State <> ConnectionState.Open Then connExport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                While dbReader.Read
    '                    If dbReader.Item("BKS_Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("BKS_Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("BKS_Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("BKS_Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("BKS_Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("BKS_Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If
    '                    'BookNbrStatus = dbReader.Item("BKS_Status")
    '                End While

    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            ElseIf reader2.Item("CRD_Key") = "BRKG" Then

    '                Dim strSQLBRKG As String = "SELECT ImpBrokerage.CargoLoad, Consignee, Services, ControlNum, Status " & _
    '                    "From ImpBrokerage " & _
    '                    "WHERE (((ImpBrokerage.ControlNum)= '" & BookNbr & "'))"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLBRKG, connImport)

    '                If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()

    '                While dbReader.Read
    '                    If dbReader.Item("Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If
    '                End While
    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            End If


    '            gridBook.Rows.Add(BookNbr, reader2.Item("CRD_CPRNbr"), reader2.Item("VendorName"), reader2.Item("CRD_BookComp"), BookNbrStatus, reader2.Item("CRD_ShipCons"), reader2.Item("CRD_ContHBL"), reader2.Item("SUM(ap_crd.CRD_Amount)"), reader2.Item("CRD_Key"), reader2.Item("CRD_Index"), reader2.Item("CRD_Particulars"), reader2.Item("CRP_ORNbr"), reader2.Item("CRP_Liquidated"))
    '            i = i + 1
    'Skip1:
    '        End While

    '        If connExport.State = ConnectionState.Open Then connExport.Close()
    '        If connImport.State = ConnectionState.Open Then connImport.Close()

    '        cmd2.Dispose()
    '        reader2.Close()
    '    End Sub

    '    Private Sub PopulateMCDDetails(ByVal searchkey As String, ByVal dtFrom As String, ByVal dtTo As String)
    '        Dim strSQL As String

    '        Me.DataGridView1.Rows.Clear()

    '        Dim cmdMDB As OleDb.OleDbCommand

    '        strSQL = "SELECT ap_mcd.MCD_MCRNbr, ap_mcd.MCD_BookNbr, ap_mcd.MCD_BookComp, ap_mcd.MCD_ShipCons, ap_mcd.MCD_ContHBL, SUM(ap_mcd.MCD_Amount), ap_mcd.MCD_Key, ap_mcd.MCD_Index, ap_mcd.MCD_Particulars, ap_mcp.MCP_Cancel, ap_mcp.MCP_Liquidated, lib_vendor.VendorID, lib_vendor.VendorName, ap_mcp.MCP_PayeeID, ap_mcp.MCP_ORNbr " & _
    '                 "FROM (ap_mcd INNER JOIN ap_mcp ON ap_mcd.MCD_MCRNbr = ap_mcp.MCP_Nbr) INNER JOIN lib_vendor ON ap_mcp.MCP_PayeeID = lib_vendor.VendorID " & _
    '                 "WHERE (((ap_mcd.MCD_Particulars) like '%Container Deposit%' and ap_mcp.MCP_Cancel = 0)) " & _
    '                 "and (ap_mcd.MCD_BookComp like '%" & searchkey & "%' or lib_vendor.VendorName like '%" & searchkey & "%' " & _
    '                 "or ap_mcd.MCD_ShipCons like '%" & searchkey & "%' or ap_mcd.MCD_ContHBL like '%" & searchkey & "%') " & _
    '                 "and (ap_mcp.MCP_PrepDate BETWEEN '" & dtFrom & "' and '" & dtTo & "') " & _
    '                 "GROUP BY ap_mcd.MCD_MCRNbr"

    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '        Dim cmd2 = New MySqlCommand(strSQL, connAcctg)
    '        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

    '        Dim i As Integer
    '        Dim gridBook As DataGridView
    '        'Me.DataGridView1.Rows.Clear()
    '        While reader2.Read
    '            gridBook = Me.DataGridView1

    '            If IsDBNull(reader2.Item("MCD_BookNbr")) = False Then
    '                BookNbr = reader2.Item("MCD_BookNbr")


    '                If reader2.Item("MCD_Key") = "FORW" Or reader2.Item("MCD_Key") = "Forw" Then
    '                    Dim strSQLFORW As String = "SELECT BookNum, Status FROM ImpMBL WHERE Booknum = '" & BookNbr & "'"

    '                    cmdMDB = New OleDb.OleDbCommand(strSQLFORW, connImport)

    '                    If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                    Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                    While dbReader.Read
    '                        If dbReader.Item("Status") = 3 Then
    '                            BookNbrStatus = "Cancelled"
    '                        ElseIf dbReader.Item("Status") = 1 Then
    '                            BookNbrStatus = "Open"
    '                        ElseIf dbReader.Item("Status") = 2 Then
    '                            BookNbrStatus = "Loaded"
    '                        ElseIf dbReader.Item("Status") = 4 Then
    '                            BookNbrStatus = "Posted"
    '                        ElseIf dbReader.Item("Status") = 5 Then
    '                            BookNbrStatus = "Re-book"
    '                        ElseIf dbReader.Item("Status") = 6 Then
    '                            BookNbrStatus = "Foul"
    '                        End If

    '                    End While
    '                    dbReader.Close()
    '                    cmdMDB.Dispose()
    '                ElseIf reader2.Item("MCD_Key") = "EXP" Then
    '                    Dim strSQLEXP As String = "SELECT BKS.BKS_Nbr, BKS.BKS_Status " & _
    '                            "FROM BKS " & _
    '                            "WHERE (((BKS.BKS_Nbr)='" & BookNbr & "'))"

    '                    cmdMDB = New OleDb.OleDbCommand(strSQLEXP, connExport)

    '                    If connExport.State <> ConnectionState.Open Then connExport.Open()

    '                    Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                    While dbReader.Read
    '                        If dbReader.Item("BKS_Status") = 3 Then
    '                            BookNbrStatus = "Cancelled"
    '                        ElseIf dbReader.Item("BKS_Status") = 1 Then
    '                            BookNbrStatus = "Open"
    '                        ElseIf dbReader.Item("BKS_Status") = 2 Then
    '                            BookNbrStatus = "Loaded"
    '                        ElseIf dbReader.Item("BKS_Status") = 4 Then
    '                            BookNbrStatus = "Posted"
    '                        ElseIf dbReader.Item("BKS_Status") = 5 Then
    '                            BookNbrStatus = "Re-book"
    '                        ElseIf dbReader.Item("BKS_Status") = 6 Then
    '                            BookNbrStatus = "Foul"
    '                        End If
    '                        'BookNbrStatus = dbReader.Item("BKS_Status")
    '                    End While

    '                    dbReader.Close()
    '                    cmdMDB.Dispose()
    '                ElseIf reader2.Item("MCD_Key") = "BRKG" Then

    '                    Dim strSQLBRKG As String = "SELECT ImpBrokerage.CargoLoad, Consignee, Services, ControlNum, Status " & _
    '                            "From ImpBrokerage " & _
    '                            "WHERE (((ImpBrokerage.ControlNum)= '" & BookNbr & "'))"

    '                    cmdMDB = New OleDb.OleDbCommand(strSQLBRKG, connImport)

    '                    If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                    Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()

    '                    While dbReader.Read
    '                        If dbReader.Item("Status") = 3 Then
    '                            BookNbrStatus = "Cancelled"
    '                        ElseIf dbReader.Item("Status") = 1 Then
    '                            BookNbrStatus = "Open"
    '                        ElseIf dbReader.Item("Status") = 2 Then
    '                            BookNbrStatus = "Loaded"
    '                        ElseIf dbReader.Item("Status") = 4 Then
    '                            BookNbrStatus = "Posted"
    '                        ElseIf dbReader.Item("Status") = 5 Then
    '                            BookNbrStatus = "Re-book"
    '                        ElseIf dbReader.Item("Status") = 6 Then
    '                            BookNbrStatus = "Foul"
    '                        End If
    '                    End While
    '                    dbReader.Close()
    '                    cmdMDB.Dispose()
    '                End If


    '                gridBook.Rows.Add(BookNbr, reader2.Item("MCD_MCRNbr"), reader2.Item("VendorName"), reader2.Item("MCD_BookComp"), BookNbrStatus, reader2.Item("MCD_ShipCons"), reader2.Item("MCD_ContHBL"), reader2.Item("SUM(ap_mcd.MCD_Amount)"), reader2.Item("MCD_Key"), reader2.Item("MCD_Index"), reader2.Item("MCD_Particulars"), reader2.Item("MCP_ORNbr"), reader2.Item("MCP_Liquidated"))
    '                i = i + 1
    '            End If

    '        End While

    '        If connExport.State = ConnectionState.Open Then connExport.Close()
    '        If connImport.State = ConnectionState.Open Then connImport.Close()

    '        cmd2.Dispose()
    '        reader2.Close()
    '    End Sub


    '    Private Sub PopulatePCDetails(ByVal searchkey As String, ByVal dtFrom As String, ByVal dtTo As String)
    '        Dim strSQL As String

    '        Me.DataGridView1.Rows.Clear()

    '        Dim cmdMDB As OleDb.OleDbCommand

    '        strSQL = "SELECT ap_pcd.PCD_PCRNbr, ap_pcd.PCD_BookNbr, ap_pcd.PCD_BookComp, ap_pcd.PCD_ShipCons, ap_pcd.PCD_ContHBL, SUM(ap_pcd.PCD_Amount), ap_pcd.PCD_Key, ap_pcd.PCD_Index, ap_pcd.PCD_Particulars, ap_pcr.PCR_Cancel, ap_pcr.PCR_Posted, lib_vendor.VendorID, lib_vendor.VendorName, ap_pcr.PCR_PayeeID " & _
    '                 "FROM (ap_pcd INNER JOIN ap_pcr ON ap_pcd.PCD_PCRNbr = ap_pcr.PCR_Nbr) INNER JOIN lib_vendor ON ap_pcr.PCR_PayeeID = lib_vendor.VendorID " & _
    '                 "WHERE (((ap_pcd.PCD_Particulars) like '%Container Deposit%' and ap_pcr.PCR_Cancel = 0)) " & _
    '                 "and (ap_pcd.PCD_BookComp like '%" & searchkey & "%' or lib_vendor.VendorName like '%" & searchkey & "%' " & _
    '                 "or ap_pcd.PCD_ShipCons like '%" & searchkey & "%' or ap_pcd.PCD_ContHBL like '%" & searchkey & "%') " & _
    '                 "and (ap_pcr.PCR_PrepDate BETWEEN '" & dtFrom & "' and '" & dtTo & "') " & _
    '                 "GROUP BY ap_pcd.PCD_PCRNbr"

    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '        Dim cmd2 = New MySqlCommand(strSQL, connAcctg)
    '        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

    '        Dim i As Integer
    '        Dim gridBook As DataGridView
    '        Me.DataGridView1.Rows.Clear()
    '        While reader2.Read
    '            gridBook = Me.DataGridView1
    '            BookNbr = reader2.Item("PCD_BookNbr")


    '            If reader2.Item("PCD_Key") = "FORW" Or reader2.Item("PCD_Key") = "Forw" Then
    '                Dim strSQLFORW As String = "SELECT BookNum, Status FROM ImpMBL WHERE Booknum = '" & BookNbr & "'"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLFORW, connImport)

    '                If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                While dbReader.Read
    '                    If dbReader.Item("Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If

    '                End While
    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            ElseIf reader2.Item("PCD_Key") = "EXP" Then
    '                Dim strSQLEXP As String = "SELECT BKS.BKS_Nbr, BKS.BKS_Status " & _
    '                        "FROM BKS " & _
    '                        "WHERE (((BKS.BKS_Nbr)='" & BookNbr & "'))"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLEXP, connExport)

    '                If connExport.State <> ConnectionState.Open Then connExport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()
    '                While dbReader.Read
    '                    If dbReader.Item("BKS_Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("BKS_Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("BKS_Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("BKS_Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("BKS_Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("BKS_Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If
    '                    'BookNbrStatus = dbReader.Item("BKS_Status")
    '                End While

    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            ElseIf reader2.Item("PCD_Key") = "BRKG" Then

    '                Dim strSQLBRKG As String = "SELECT ImpBrokerage.CargoLoad, Consignee, Services, ControlNum, Status " & _
    '                        "From ImpBrokerage " & _
    '                        "WHERE (((ImpBrokerage.ControlNum)= '" & BookNbr & "'))"

    '                cmdMDB = New OleDb.OleDbCommand(strSQLBRKG, connImport)

    '                If connImport.State <> ConnectionState.Open Then connImport.Open()

    '                Dim dbReader As OleDb.OleDbDataReader = cmdMDB.ExecuteReader()

    '                While dbReader.Read
    '                    If dbReader.Item("Status") = 3 Then
    '                        BookNbrStatus = "Cancelled"
    '                    ElseIf dbReader.Item("Status") = 1 Then
    '                        BookNbrStatus = "Open"
    '                    ElseIf dbReader.Item("Status") = 2 Then
    '                        BookNbrStatus = "Loaded"
    '                    ElseIf dbReader.Item("Status") = 4 Then
    '                        BookNbrStatus = "Posted"
    '                    ElseIf dbReader.Item("Status") = 5 Then
    '                        BookNbrStatus = "Re-book"
    '                    ElseIf dbReader.Item("Status") = 6 Then
    '                        BookNbrStatus = "Foul"
    '                    End If
    '                End While
    '                dbReader.Close()
    '                cmdMDB.Dispose()
    '            End If


    '            gridBook.Rows.Add(BookNbr, reader2.Item("PCD_PCRNbr"), reader2.Item("VendorName"), reader2.Item("PCD_BookComp"), BookNbrStatus, reader2.Item("PCD_ShipCons"), reader2.Item("PCD_ContHBL"), reader2.Item("SUM(ap_pcd.PCD_Amount)"), reader2.Item("PCD_Key"), reader2.Item("PCD_Index"), reader2.Item("PCD_Particulars"), "", reader2.Item("PCR_Posted"))
    '            i = i + 1
    '        End While

    '        If connExport.State = ConnectionState.Open Then connExport.Close()
    '        If connImport.State = ConnectionState.Open Then connImport.Close()

    '        cmd2.Dispose()
    '        reader2.Close()
    '    End Sub

    Private Sub SetColumnProp()
        With Me.DataGridView1
            .Columns.Clear()
            .Columns.Add("", "Booking")
            .Columns.Add("", "Request #")
            .Columns.Add("", "Shipping Line")

            .Columns.Add("", "Booking #")
            .Columns.Add("", "Booking Status")

            .Columns.Add("", "Shipper/Consignee")
            .Columns.Add("", "Container/BL #")
            .Columns.Add("", "Amount")
            .Columns.Add("", "Key")
            .Columns.Add("", "Index")
            .Columns.Add("", "Particulars")
            .Columns.Add("", "O.R #")

            .Columns.Add("", "Liquidated")

            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .MultiSelect = True

            .Columns(0).Width = 0
            .Columns(1).Width = 120
            .Columns(2).Width = 200


            .Columns(3).Width = 120

            .Columns(4).Width = 220
            .Columns(6).Width = 150
            .Columns(7).Width = 100
            .Columns(8).Width = 50
            .Columns(9).Width = 50
            .Columns(10).Width = 150
            .Columns(11).Width = 75
            .Columns(12).Width = 100

            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(7).ReadOnly = True
            .Columns(8).ReadOnly = True
            .Columns(9).ReadOnly = True
            .Columns(10).ReadOnly = True
            .Columns(11).ReadOnly = True
            .Columns(12).ReadOnly = True

            .Columns(11).Visible = False
            .Columns(12).Visible = False

            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).DefaultCellStyle.Format = "n2"

            .MultiSelect = False
        End With

        Me.Refresh()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If CBool(Me.DataGridView1.CurrentRow.Cells(12).Value) = False Then
            MsgBox("Request Number " & Me.DataGridView1.CurrentRow.Cells(1).Value & " not yet liquidated.", MsgBoxStyle.Critical, "System Message")
            Exit Sub
        End If

        If frmContainerRefund.CheckIfRequestExistOnContRef(Me.DataGridView1.CurrentRow.Cells(1).Value) = True Then
            MsgBox("Request Number " & Me.DataGridView1.CurrentRow.Cells(1).Value & " Already Exist To Container Refund Billing!", MsgBoxStyle.Exclamation, "System Message")
            Exit Sub
        End If

        frmContainerRefund.DataGridView1.Rows.Clear()

        frmContainerRefund.PopulateItems(Me.DataGridView1.CurrentRow.Cells(1).Value)
        frmContainerRefund.PopulateBooking(Me.DataGridView1.CurrentRow.Cells(1).Value)

        frmContainerRefund.txtPayeeName.Text = Me.DataGridView1.CurrentRow.Cells(2).Value

        frmContainerRefund.ComputeGrandTotal()
        frmContainerRefund.txtRequestNbr.Text = Me.DataGridView1.CurrentRow.Cells(1).Value

        If IsDBNull(Me.DataGridView1.CurrentRow.Cells(11).Value) = False Then
            frmContainerRefund.txtORNbr.Text = Me.DataGridView1.CurrentRow.Cells(11).Value
        End If
        frmContainerRefund.txtShipAddress.Text = GetStringValue("Select Addr1 from tbl_client where Description ='" & frmContainerRefund.txtPayeeName.Text & "'", "Addr1") & vbNewLine & GetStringValue("Select AddrCityDesc from tbl_client where Description ='" & frmContainerRefund.txtPayeeName.Text & "'", "AddrCityDesc") & vbNewLine & GetStringValue("Select AddrCountryDesc from tbl_client where Description ='" & frmContainerRefund.txtPayeeName.Text & "'", "AddrCountryDesc")
        Me.Close()
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        PopulateDetails(Me.txtSearch.Text, Format$(dtFromDate.Value, "yyyy/MM/dd 00:00:00"), Format$(dtToDate.Value, "yyyy/MM/dd 23:59:59"))

        StatusColor()
    End Sub

    Private Sub dtFromDate_ValueChanged(sender As Object, e As EventArgs) Handles dtFromDate.ValueChanged
        If dtFromDate.Value > dtToDate.Value Then
            dtFromDate.Value = dtToDate.Value
        End If
    End Sub

    Private Sub dtToDate_ValueChanged(sender As Object, e As EventArgs) Handles dtToDate.ValueChanged
        If dtToDate.Value < dtFromDate.Value Then
            dtToDate.Value = dtFromDate.Value
        End If
    End Sub
End Class