Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBillingSummaryReports
    Private Sub frmBillingSummaryReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '    Private Sub CheckForBillMonitoringIfExpOrImpB()
    '        If Me.Text = "Export Billing Summary" Then
    '            PrevExpBillMonitoring()
    '            'PrevExpBook()
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PrevImpBBillMonitoring()
    '            'PrevImpBBook()
    '        Else
    '            PrevImpFBillMonitoring()
    '            'PrevImpFBook()
    '        End If
    '    End Sub

    '    Private Sub PrevExpBook()
    '        Dim strsql As String = "SELECT BKS.BKS_Nbr, SHP.SHP_ClientName, BKSBL.BKSBL_BLNum, DES.DES_DestName, BKS.BKS_TSETD " &
    '                               "from ((BKS INNER JOIN SHP ON BKS.BKS_ShippertCode = SHP.SHP_ClientCode) " &
    '                               "INNER JOIN BKSBL ON BKS.BKS_Nbr = BKSBL.BKSBL_BKSNum) " &
    '                               "INNER JOIN DES ON BKS.BKS_DestCode = DES.DES_DestCode " &
    '                               "WHERE SHP.SHP_ExcludeBilling = false AND (BKS_Status = 1 OR BKS_Status = 4) AND BKS.BKS_Date " &
    '                               "BETWEEN @from " &
    '                               "AND @to " &
    '                               "ORDER by BKS_Nbr"
    '        If connExport.State <> ConnectionState.Open Then connExport.Open()
    '        Dim cmdsql = New OleDb.OleDbCommand(strsql, connExport)
    '        With cmdsql.Parameters
    '            .AddWithValue("@from", Format$(Me.dtFromMon.Value, "MM/dd/yyyy 00:00:00"))
    '            .AddWithValue("@to", Format$(Me.dtToMon.Value, "MM/dd/yyyy 23:59:59"))
    '        End With
    '        Dim reader As OleDb.OleDbDataReader = cmdsql.ExecuteReader
    '        While reader.Read
    '            strsql = "SELECT * from bill_exp_main WHERE BookingNo like '" & reader.Item("BKS_Nbr") & "'"
    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '            Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            Dim reader1 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql1.ExecuteReader
    '            While reader1.Read
    '                cmdsql1.Dispose()
    '                reader1.Close()
    '                connAcctg.Close()
    '                GoTo DontRecord
    '            End While
    '            cmdsql1.Dispose()
    '            reader1.Close()
    '            connAcctg.Close()
    '            dtgBillingMonitoring.Rows.Add(reader.Item("BKS_Nbr"), "", "", "", "", reader.Item("SHP_ClientName"), reader.Item("BKSBL_BLNum"), reader.Item("DES_DestName"), "", "", "", "", "", "")
    'DontRecord:
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connExport.Close()
    '    End Sub

    '    Private Sub PrevImpBBook()
    '        Dim strsql As String = "SELECT ImpBrokerage.ControlNum, ImpBrokerage.Shipper, ImpBrokerage.HouseBL, BrokerageContainers.ContainerNum " &
    '                               "from ImpBrokerage INNER JOIN BrokerageContainers ON ImpBrokerage.ControlNum = BrokerageContainers.ControlNum " &
    '                               "WHERE (Status = 1 Or Status = 4) AND ImpBrokerage.EncodedDate BETWEEN " &
    '                               "@from AND @to " &
    '                               "ORDER by ImpBrokerage.ControlNum"
    '        If connImport.State <> ConnectionState.Open Then connImport.Open()
    '        Dim cmdsql = New OleDb.OleDbCommand(strsql, connImport)
    '        With cmdsql.Parameters
    '            .AddWithValue("@from", Format$(Me.dtFromMon.Value, "MM/dd/yyyy 00:00:00"))
    '            .AddWithValue("@to", Format$(Me.dtToMon.Value, "MM/dd/yyyy 23:59:59"))
    '        End With
    '        Dim reader As OleDb.OleDbDataReader = cmdsql.ExecuteReader
    '        While reader.Read
    '            strsql = "SELECT * from bill_impb_main WHERE BookingNos like '" & reader.Item("ControlNum") & "'"
    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '            Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            Dim reader1 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql1.ExecuteReader
    '            While reader1.Read
    '                cmdsql1.Dispose()
    '                reader1.Close()
    '                connAcctg.Close()
    '                GoTo DontRecord
    '            End While
    '            cmdsql1.Dispose()
    '            reader1.Close()
    '            connAcctg.Close()
    '            dtgBillingMonitoring.Rows.Add(reader.Item("ControlNum"), "", "", "", "", reader.Item("Shipper"), reader.Item("HouseBL"), reader.Item("ContainerNum"), "", "", "", "", "", "")
    'DontRecord:
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connExport.Close()
    '    End Sub

    '    Private Sub PrevImpFBook()
    '        Dim strsql As String = "SELECT ImpMBL.MasterBL, ImpMBL.Shipper, ImpHBL.HouseBL " &
    '                               "from ImpMBL INNER JOIN ImpHBL ON ImpMBL.MasterBL = ImpHBL.MasterBL " &
    '                               "WHERE ImpHBL.DODate BETWEEN " &
    '                               "@from AND @to "
    '        If connImport.State <> ConnectionState.Open Then connImport.Open()
    '        Dim cmdsql = New OleDb.OleDbCommand(strsql, connImport)
    '        With cmdsql.Parameters
    '            .AddWithValue("@from", Format$(Me.dtFromMon.Value, "MM/dd/yyyy 00:00:00"))
    '            .AddWithValue("@to", Format$(Me.dtToMon.Value, "MM/dd/yyyy 23:59:59"))
    '        End With
    '        Dim reader As OleDb.OleDbDataReader = cmdsql.ExecuteReader
    '        While reader.Read
    '            strsql = "SELECT * from bill_impf_main WHERE HouseBL like '" & reader.Item("HouseBL") & "'"
    '            If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()
    '            Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            Dim reader1 As MySql.Data.MySqlClient.MySqlDataReader = cmdsql1.ExecuteReader
    '            While reader1.Read
    '                cmdsql1.Dispose()
    '                reader1.Close()
    '                connAcctg.Close()
    '                GoTo DontRecord
    '            End While
    '            cmdsql1.Dispose()
    '            reader1.Close()
    '            connAcctg.Close()
    '            dtgBillingMonitoring.Rows.Add(reader.Item("MasterBL"), "", "", "", "", reader.Item("Shipper"), reader.Item("HouseBL"), "", "", "", "", "", "", "")
    'DontRecord:
    '        End While
    '        cmdsql.Dispose()
    '        reader.Close()
    '        connExport.Close()
    '    End Sub

    '    Private Sub SetGridStatusColor()
    '        For ctrRow As Integer = 0 To Me.dtgBillingMonitoring.Rows.Count - 1
    '            With Me.dtgBillingMonitoring.Rows(ctrRow)
    '                If .Cells("colStatus").Value = "Cancelled" Then
    '                    For ctrCol = 0 To Me.dtgBillingMonitoring.Columns.Count - 1
    '                        .Cells(ctrCol).Style.BackColor = Color.IndianRed
    '                        .Cells(ctrCol).Style.SelectionBackColor = Color.DarkRed
    '                    Next
    '                ElseIf .Cells("colStatus").Value = "Posted" Then
    '                    For ctrCol = 0 To Me.dtgBillingMonitoring.Columns.Count - 1
    '                        .Cells(ctrCol).Style.BackColor = Color.LightSkyBlue
    '                        .Cells(ctrCol).Style.SelectionBackColor = Color.DarkBlue
    '                    Next
    '                ElseIf .Cells("colStatus").Value = "Open" Then
    '                    For ctrCol = 0 To Me.dtgBillingMonitoring.Columns.Count - 1
    '                        .Cells(ctrCol).Style.BackColor = Color.LightGreen
    '                        .Cells(ctrCol).Style.SelectionBackColor = Color.DarkGreen
    '                    Next
    '                Else
    '                    For ctrCol = 0 To Me.dtgBillingMonitoring.Columns.Count - 1
    '                        .Cells(ctrCol).Style.BackColor = Color.Yellow
    '                        .Cells(ctrCol).Style.SelectionBackColor = Color.YellowGreen
    '                    Next
    '                End If
    '            End With
    '        Next
    '    End Sub

    '    Private Sub PrevImpFBillMonitoring()
    '        If Me.chkAll.Checked = False And Me.chkCancelled.Checked = False And Me.chkPosted.Checked = False And Me.chkOpen.Checked = False Then
    '            Me.dtgBillingMonitoring.Rows.Clear()
    '            Exit Sub
    '        End If

    '        Dim strsql As String = "SELECT * FROM bill_ImpF_main " &
    '                                "WHERE DateSaved " &
    '                                "BETWEEN '" & Format$(Me.dtFromMon.Value, "yyyy-MM-dd 00:00:00") & "' " &
    '                                "AND '" & Format$(Me.dtToMon.Value, "yyyy-MM-dd 23:59:59") & "'"

    '        If Me.chkAll.Checked = False And (Me.chkCancelled.Checked = True Or Me.chkPosted.Checked = True Or Me.chkOpen.Checked = True) Then
    '            strsql += "AND ("
    '            If Me.chkCancelled.Checked = True Then
    '                strsql += "Cancel = TRUE"

    '                If Me.chkPosted.Checked = True Then
    '                    strsql += " OR (Posted = TRUE AND Cancel = FALSE)"
    '                End If

    '                If Me.chkOpen.Checked = True Then
    '                    strsql += " OR (Posted = FALSE AND Cancel = FALSE)"
    '                End If
    '            Else
    '                If Me.chkPosted.Checked = True Then
    '                    strsql += "(Posted = TRUE AND Cancel = FALSE)"

    '                    If Me.chkOpen.Checked = True Then
    '                        strsql += " OR (Posted = FALSE AND Cancel = FALSE)"
    '                    End If
    '                Else
    '                    If Me.chkOpen.Checked = True Then
    '                        strsql += "(Posted = FALSE AND Cancel = FALSE)"
    '                    End If
    '                End If
    '            End If
    '            strsql += ")"
    '        End If

    '        strsql += " ORDER BY DateSaved DESC"

    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
    '        Dim strStatus As String

    '        Me.dtgBillingMonitoring.Rows.Clear()
    '        While reader.Read
    '            If reader.Item("Cancel") = True Then
    '                strStatus = "Cancelled"
    '            ElseIf reader.Item("Posted") = True Then
    '                strStatus = "Posted"
    '            Else
    '                strStatus = "Open"
    '            End If

    '            Me.dtgBillingMonitoring.Rows.Add("", reader.Item("RefNo"), reader.Item("InvoiceNum"), reader.Item("SOANo"),
    '                                             reader.Item("DateSaved"), reader.Item("Client"),
    '                                             reader.Item("HouseBL"), "", "",
    '                                             Format(reader.Item("InvAmt"), "n2"), Format(reader.Item("SOAAmt"), "n2"),
    '                                             Format(reader.Item("VAT"), "n2"), Format(reader.Item("GrandTotal"), "n2"), strStatus)
    '        End While

    '        reader.Close()
    '        cmdSQL.Dispose()

    '        'Get Access DB
    '        If connImport.State <> ConnectionState.Open Then connImport.Open()

    '        Dim cmdAccess = New OleDb.OleDbCommand
    '        Dim rdrAccess As OleDb.OleDbDataReader

    '        For ctrRow As Integer = 0 To Me.dtgBillingMonitoring.Rows.Count - 1
    '            With Me.dtgBillingMonitoring.Rows(ctrRow)
    '                strsql = "SELECT ImpMBL.MasterBL FROM ImpHBL INNER JOIN ImpMBL ON ImpHBL.MasterBL = ImpMBL.MasterBL " &
    '                            "WHERE ImpHBL.HouseBL = '" & .Cells("colHBL").Value & "'"

    '                cmdAccess = New OleDb.OleDbCommand(strsql, connImport)

    '                rdrAccess = cmdAccess.ExecuteReader

    '                While rdrAccess.Read
    '                    .Cells("colBookNo").Value = rdrAccess.Item("MasterBL")
    '                End While

    '                rdrAccess.Close()
    '            End With
    '        Next

    '        cmdSQL.Dispose()
    '    End Sub

    '    Private Sub PrevImpBBillMonitoring()
    '        If Me.chkAll.Checked = False And Me.chkCancelled.Checked = False And Me.chkPosted.Checked = False And Me.chkOpen.Checked = False Then
    '            Me.dtgBillingMonitoring.Rows.Clear()
    '            Exit Sub
    '        End If

    '        Dim strsql As String = "SELECT * FROM bill_impb_main " &
    '                                "INNER JOIN bill_impb_booking ON bill_impb_main.RefNo = bill_impb_booking.RefNo " &
    '                                "WHERE PrepDate " &
    '                                "BETWEEN '" & Format$(Me.dtFromMon.Value, "yyyy-MM-dd 00:00:00") & "' " &
    '                                "AND '" & Format$(Me.dtToMon.Value, "yyyy-MM-dd 23:59:59") & "'"

    '        If Me.chkAll.Checked = False And (Me.chkCancelled.Checked = True Or Me.chkPosted.Checked = True Or Me.chkOpen.Checked = True) Then
    '            strsql += "AND ("
    '            If Me.chkCancelled.Checked = True Then
    '                strsql += "Cancel = TRUE"

    '                If Me.chkPosted.Checked = True Then
    '                    strsql += " OR (Posted = TRUE AND Cancel = FALSE)"
    '                End If

    '                If Me.chkOpen.Checked = True Then
    '                    strsql += " OR (Posted = FALSE AND Cancel = FALSE)"
    '                End If
    '            Else
    '                If Me.chkPosted.Checked = True Then
    '                    strsql += "(Posted = TRUE AND Cancel = FALSE)"

    '                    If Me.chkOpen.Checked = True Then
    '                        strsql += " OR (Posted = FALSE AND Cancel = FALSE)"
    '                    End If
    '                Else
    '                    If Me.chkOpen.Checked = True Then
    '                        strsql += "(Posted = FALSE AND Cancel = FALSE)"
    '                    End If
    '                End If
    '            End If
    '            strsql += ")"
    '        End If

    '        strsql += " ORDER BY BookingNos DESC"

    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
    '        Dim strStatus As String

    '        Me.dtgBillingMonitoring.Rows.Clear()
    '        While reader.Read
    '            If reader.Item("Cancel") = True Then
    '                strStatus = "Cancelled"
    '            ElseIf reader.Item("Posted") = True Then
    '                strStatus = "Posted"
    '            Else
    '                strStatus = "Open"
    '            End If

    '            Me.dtgBillingMonitoring.Rows.Add(reader.Item("BookingNos"), reader.Item("RefNo"), reader.Item("CINo"),
    '                                             reader.Item("SOANo"), reader.Item("PrepDate"), reader.Item("BilledTo"),
    '                                             reader.Item("HouseBL"), reader.Item("ContNo"), reader.Item("TermsOfPayment") & " Day/s",
    '                                             Format(reader.Item("TotalInv"), "n2"), Format(reader.Item("TotalSOA"), "n2"),
    '                                             Format(reader.Item("TotalVAT"), "n2"), Format(reader.Item("TotalAmtPHP"), "n2"), strStatus)
    '        End While

    '        reader.Close()
    '        cmdSQL.Dispose()
    '    End Sub

    '    Private Sub PrevExpBillMonitoring()
    '        If Me.chkAll.Checked = False And Me.chkCancelled.Checked = False And Me.chkPosted.Checked = False And Me.chkOpen.Checked = False Then
    '            Me.dtgBillingMonitoring.Rows.Clear()
    '            Exit Sub
    '        End If

    '        Dim strsql As String

    '        strsql = "SELECT * FROM bill_exp_main " &
    '                                "WHERE PrepDate " &
    '                                "BETWEEN '" & Format$(Me.dtFromMon.Value, "yyyy-MM-dd 00:00:00") & "' " &
    '                                "AND '" & Format$(Me.dtToMon.Value, "yyyy-MM-dd 23:59:59") & "'"

    '        If Me.chkAll.Checked = False And (Me.chkCancelled.Checked = True Or Me.chkPosted.Checked = True Or Me.chkOpen.Checked = True) Then
    '            strsql += "AND ("
    '            If Me.chkCancelled.Checked = True Then
    '                strsql += "Cancel = TRUE"

    '                If Me.chkPosted.Checked = True Then
    '                    strsql += " OR (Posted = TRUE AND Cancel = FALSE)"
    '                End If

    '                If Me.chkOpen.Checked = True Then
    '                    strsql += " OR (Posted = FALSE AND Cancel = FALSE)"
    '                End If
    '            Else
    '                If Me.chkPosted.Checked = True Then
    '                    strsql += "(Posted = TRUE AND Cancel = FALSE)"

    '                    If Me.chkOpen.Checked = True Then
    '                        strsql += " OR (Posted = FALSE AND Cancel = FALSE)"
    '                    End If
    '                Else
    '                    If Me.chkOpen.Checked = True Then
    '                        strsql += "(Posted = FALSE AND Cancel = FALSE)"
    '                    End If
    '                End If
    '            End If
    '            strsql += ")"
    '        End If

    '        strsql += " ORDER BY BookingNo DESC"

    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
    '        Dim strStatus As String

    '        Me.dtgBillingMonitoring.Rows.Clear()
    '        While reader.Read
    '            If reader.Item("Cancel") = True Then
    '                strStatus = "Cancelled"
    '            ElseIf reader.Item("Posted") = True Then
    '                strStatus = "Posted"
    '            Else
    '                strStatus = "Open"
    '            End If

    '            Me.dtgBillingMonitoring.Rows.Add(reader.Item("BookingNo"), reader.Item("RefNo"), reader.Item("CINo"),
    '                                             reader.Item("SOANo"), reader.Item("PrepDate"), reader.Item("BilledTo"),
    '                                             reader.Item("HBL"), reader.Item("Destination"), reader.Item("TermsOfPayment") & " Day/s",
    '                                             Format(reader.Item("TotalInv"), "n2"), Format(reader.Item("TotalSOA"), "n2"),
    '                                             Format(reader.Item("TotalVAT"), "n2"), Format(reader.Item("TotalPaymentPHP"), "n2"), strStatus)
    '        End While

    '        reader.Close()
    '        cmdSQL.Dispose()
    '    End Sub

    '    Private Sub PrevAllImpF()
    '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '        Dim crParameterFieldDefinition As ParameterFieldDefinition
    '        Dim crParameterValues As New ParameterValues
    '        Dim crParameterDiscreteValue As New ParameterDiscreteValue
    '        Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '        Dim myTable As Table

    '        Dim CR As New ReportDocument

    '        'ais
    '        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptImpFBillSummary2013.rpt"))
    '        CR.Load(GetReportPath("Acctg System Reports\Billing\rptImpFBillSummary.rpt"))
    '        'port
    '        'CrystalReportViewer1.ReportSource = GetReportPath("rptCrpAdminPort.rpt")

    '        'Set login info
    '        For Each myTable In CR.Database.Tables
    '            If myTable.Name <> "bill_impf_main" Then
    '                myLogin = myTable.LogOnInfo
    '                'myLogin.ConnectionInfo.ServerName = "server name"
    '                myLogin.ConnectionInfo.DatabaseName = ""
    '                myLogin.ConnectionInfo.UserID = ""
    '                myLogin.ConnectionInfo.Password = "arnoldtheripper"
    '                myTable.ApplyLogOnInfo(myLogin)
    '                myTable.Location = myTable.Location
    '            End If
    '        Next

    '        crParameterDiscreteValue.Value = Format(Me.dtFromSummary.Value, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateFrom")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = Format(Me.dtToSummary.Value, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateTo")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = GetServerDate()
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("PrintDate")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


    '        crSummary.SelectionFormula() = "{bill_impf_main.DateSaved} in #" & Format(Me.dtFromSummary.Value, "yyyy-MM-dd 00:00:00") & "# to #" & Format(Me.dtToSummary.Value.Date, "yyyy-MM-dd 23:59:59") & "# AND {bill_impf_main.Cancel} = 0"
    '        crSummary.ReportSource = CR
    '    End Sub

    '    Private Sub PrevAllImpB()
    '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '        Dim crParameterFieldDefinition As ParameterFieldDefinition
    '        Dim crParameterValues As New ParameterValues
    '        Dim crParameterDiscreteValue As New ParameterDiscreteValue
    '        Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '        Dim myTable As Table
    '        Dim CRSub As New ReportDocument

    '        Dim CR As New ReportDocument

    '        'ais
    '        CR.Load(GetReportPath("Acctg System Reports\Billing\rptImpBBillSummary.rpt"))
    '        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptImpBBillSummary2013.rpt"))
    '        'port
    '        'CrystalReportViewer1.ReportSource = GetReportPath("rptCrpAdminPort.rpt")

    '        'Set login info
    '        For Each myTable In CR.Database.Tables
    '            If myTable.Name <> "bill_impb_main" Then
    '                myLogin = myTable.LogOnInfo
    '                'myLogin.ConnectionInfo.ServerName = "server name"
    '                myLogin.ConnectionInfo.DatabaseName = ""
    '                myLogin.ConnectionInfo.UserID = ""
    '                myLogin.ConnectionInfo.Password = "arnoldtheripper"
    '                myTable.ApplyLogOnInfo(myLogin)
    '                myTable.Location = myTable.Location
    '            End If
    '        Next

    '        For Each CRSub In CR.Subreports
    '            If CRSub.Name = "rptHBL" Then
    '                For Each myTable In CRSub.Database.Tables
    '                    If myTable.Name = "Country" Or myTable.Name = "ImpBrokerage" Then
    '                        myLogin = myTable.LogOnInfo
    '                        'myLogin.ConnectionInfo.ServerName = ""
    '                        myLogin.ConnectionInfo.DatabaseName = ""
    '                        myLogin.ConnectionInfo.UserID = ""
    '                        myLogin.ConnectionInfo.Password = "arnoldtheripper"
    '                        myTable.ApplyLogOnInfo(myLogin)
    '                        myTable.Location = myTable.Location
    '                    End If

    '                Next
    '            End If
    '        Next

    '        crParameterDiscreteValue.Value = Format(Me.dtFromSummary.Value, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateFrom")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = Format(Me.dtToSummary.Value, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateTo")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = GetServerDate()
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("PrintDate")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


    '        crSummary.SelectionFormula() = "{bill_impb_main.PrepDate} in #" & Format(Me.dtFromSummary.Value, "yyyy-MM-dd 00:00:00") & "# to #" & Format(Me.dtToSummary.Value.Date, "yyyy-MM-dd 23:59:59") & "# AND {bill_impb_main.Cancel} = 0"
    '        crSummary.ReportSource = CR
    '    End Sub

    '    Private Sub PrevReportImf(ByVal crpt As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal dtFrom As DateTime, ByVal dtTo As DateTime, ByVal blCondition As Boolean, ByVal strField As String, ByVal strValue As String)
    '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '        Dim crParameterFieldDefinition As ParameterFieldDefinition
    '        Dim crParameterValues As New ParameterValues
    '        Dim crParameterDiscreteValue As New ParameterDiscreteValue
    '        Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '        Dim myTable As Table

    '        Dim CR As New ReportDocument

    '        'ais
    '        CR.Load(GetReportPath("Acctg System Reports\Billing\rptImpFBillSummary.rpt"))

    '        'port
    '        'CrystalReportViewer1.ReportSource = GetReportPath("rptCrpAdminPort.rpt")

    '        'Set login info
    '        For Each myTable In CR.Database.Tables
    '            If myTable.Name <> "bill_impf_main" Then
    '                myLogin = myTable.LogOnInfo
    '                'myLogin.ConnectionInfo.ServerName = "server name"
    '                myLogin.ConnectionInfo.DatabaseName = ""
    '                myLogin.ConnectionInfo.UserID = ""
    '                myLogin.ConnectionInfo.Password = "arnoldtheripper"
    '                myTable.ApplyLogOnInfo(myLogin)
    '                myTable.Location = myTable.Location
    '            End If
    '        Next

    '        'port
    '        'CrystalReportViewer1.ReportSource = GetReportPath("rptCrpAdminPort.rpt")

    '        crParameterDiscreteValue.Value = Format(dtFrom, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateFrom")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = Format(dtTo, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateTo")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = GetServerDate()
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("PrintDate")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        If blCondition = False Then
    '            If strField = "SLS_SAName" Then
    '                crpt.SelectionFormula() = "{bill_impf_main.DateSaved} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo, "yyyy-MM-dd 23:59:59") & "# AND {SLS." & strField & "} = '" & strValue & "' AND {bill_impf_main.Cancel} = 0"
    '            Else
    '                crpt.SelectionFormula() = "{bill_impf_main.DateSaved} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo.Date, "yyyy-MM-dd 23:59:59") & "# AND {bill_impf_main." & strField & "} = '" & strValue & "' AND {bill_impf_main.Cancel} = 0"
    '            End If
    '        Else
    '            crpt.SelectionFormula() = "{bill_impf_main.DateSaved} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo.Date, "yyyy-MM-dd 23:59:59") & "# AND {bill_impf_main.Cancel} = 0"
    '        End If
    '        crpt.ReportSource = CR
    '    End Sub

    '    Private Sub PrevreportImpB(ByVal crpt As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal dtFrom As DateTime, ByVal dtTo As DateTime, ByVal blCondition As Boolean, ByVal strField As String, ByVal strValue As String)
    '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '        Dim crParameterFieldDefinition As ParameterFieldDefinition
    '        Dim crParameterValues As New ParameterValues
    '        Dim crParameterDiscreteValue As New ParameterDiscreteValue
    '        Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '        Dim myTable As Table

    '        Dim CR As New ReportDocument

    '        'ais
    '        CR.Load(GetReportPath("Acctg System Reports\Billing\rptImpBBillSummary.rpt"))

    '        'port
    '        'CrystalReportViewer1.ReportSource = GetReportPath("rptCrpAdminPort.rpt")

    '        'Set login info
    '        For Each myTable In CR.Database.Tables
    '            If myTable.Name <> "bill_impb_main" Then
    '                myLogin = myTable.LogOnInfo
    '                'myLogin.ConnectionInfo.ServerName = "server name"
    '                myLogin.ConnectionInfo.DatabaseName = ""
    '                myLogin.ConnectionInfo.UserID = ""
    '                myLogin.ConnectionInfo.Password = "arnoldtheripper"
    '                myTable.ApplyLogOnInfo(myLogin)
    '                myTable.Location = myTable.Location
    '            End If
    '        Next

    '        crParameterDiscreteValue.Value = Format(dtFrom, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateFrom")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = Format(dtTo, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateTo")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = GetServerDate()
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("PrintDate")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        If blCondition = False Then
    '            If strField = "SLS_SAName" Then
    '                crpt.SelectionFormula() = "{bill_impb_main.PrepDate} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo, "yyyy-MM-dd 23:59:59") & "# AND {SLS." & strField & "} = '" & strValue & "' AND {bill_impb_main.Cancel} = 0"
    '            Else
    '                crpt.SelectionFormula() = "{bill_impb_main.PrepDate} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo, "yyyy-MM-dd 23:59:59") & "# AND {bill_impb_main." & strField & "} = '" & strValue & "' AND {bill_impb_main.Cancel} = 0"
    '            End If
    '        Else
    '            crpt.SelectionFormula() = "{bill_impb_main.PrepDate} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo, "yyyy-MM-dd 23:59:59") & "# AND {bill_impb_main.Cancel} = 0"
    '        End If

    '        crpt.ReportSource = CR
    '    End Sub

    '    Private Sub PrevReport(ByVal crpt As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal dtFrom As DateTime, ByVal dtTo As DateTime, ByVal blCondition As Boolean, ByVal strField As String, ByVal strValue As String)
    '        If Me.Text = "Export Billing Summary" Then
    '            PrevReportExp(crpt, dtFrom, dtTo, blCondition, strField, strValue)
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PrevreportImpB(crpt, dtFrom, dtTo, blCondition, strField, strValue)
    '        Else
    '            PrevReportImf(crpt, dtFrom, dtTo, blCondition, strField, strValue)
    '        End If
    '    End Sub

    '    Private Sub PrevReportExp(ByVal crpt As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal dtFrom As DateTime, ByVal dtTo As DateTime, ByVal blCondition As Boolean, ByVal strField As String, ByVal strValue As String)
    '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '        Dim crParameterFieldDefinition As ParameterFieldDefinition
    '        Dim crParameterValues As New ParameterValues
    '        Dim crParameterDiscreteValue As New ParameterDiscreteValue
    '        Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '        Dim myTable As Table

    '        Dim CR As New ReportDocument

    '        'ais
    '        CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpBillSummary.rpt"))

    '        'port
    '        'CrystalReportViewer1.ReportSource = GetReportPath("rptCrpAdminPort.rpt")

    '        'Set login info
    '        For Each myTable In CR.Database.Tables
    '            If myTable.Name <> "bill_exp_main" And myTable.Name <> "bill_exp_booking" Then
    '                myLogin = myTable.LogOnInfo
    '                'myLogin.ConnectionInfo.ServerName = "server name"
    '                myLogin.ConnectionInfo.DatabaseName = ""
    '                myLogin.ConnectionInfo.UserID = ""
    '                myLogin.ConnectionInfo.Password = "arnoldtheripper"
    '                myTable.ApplyLogOnInfo(myLogin)
    '                myTable.Location = myTable.Location
    '            End If
    '        Next

    '        crParameterDiscreteValue.Value = Format(dtFrom, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateFrom")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = Format(dtTo, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateTo")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = GetServerDate()
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("PrintDate")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        If blCondition = False Then
    '            crpt.SelectionFormula() = "{bill_exp_main.PrepDate} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo.Date, "yyyy-MM-dd 23:59:59") & "# AND {bill_exp_main." & strField & "} = '" & strValue & "' AND {bill_exp_main.Cancel} = 0"
    '        Else
    '            crpt.SelectionFormula() = "{bill_exp_main.PrepDate} in #" & Format(dtFrom, "yyyy-MM-dd 00:00:00") & "# to #" & Format(dtTo.Date, "yyyy-MM-dd 23:59:59") & "# AND {bill_exp_main.Cancel} = 0"
    '        End If
    '        crpt.ReportSource = CR
    '    End Sub

    '    Private Sub PrevAllExp()
    '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '        Dim crParameterFieldDefinition As ParameterFieldDefinition
    '        Dim crParameterValues As New ParameterValues
    '        Dim crParameterDiscreteValue As New ParameterDiscreteValue
    '        Dim myLogin As CrystalDecisions.Shared.TableLogOnInfo
    '        Dim myTable As Table

    '        Dim CR As New ReportDocument

    '        'ais
    '        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpBillSummary2013.rpt"))
    '        CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpBillSummary.rpt"))

    '        'port
    '        'CrystalReportViewer1.ReportSource = GetReportPath("rptCrpAdminPort.rpt")

    '        'Set login info
    '        For Each myTable In CR.Database.Tables
    '            If myTable.Name <> "bill_exp_main" And myTable.Name <> "bill_exp_booking" Then
    '                myLogin = myTable.LogOnInfo
    '                'myLogin.ConnectionInfo.ServerName = "server name"
    '                myLogin.ConnectionInfo.DatabaseName = ""
    '                myLogin.ConnectionInfo.UserID = ""
    '                myLogin.ConnectionInfo.Password = "arnoldtheripper"
    '                myTable.ApplyLogOnInfo(myLogin)
    '                myTable.Location = myTable.Location
    '            End If
    '        Next

    '        crParameterDiscreteValue.Value = Format(Me.dtFromSummary.Value, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateFrom")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = Format(Me.dtToSummary.Value, "MM/dd/yyyy")
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("DateTo")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

    '        crParameterDiscreteValue.Value = GetServerDate()
    '        crParameterFieldDefinitions =
    '            CR.DataDefinition.ParameterFields
    '        crParameterFieldDefinition =
    '    crParameterFieldDefinitions.Item("PrintDate")
    '        crParameterValues = crParameterFieldDefinition.CurrentValues
    '        crParameterValues.Clear()
    '        crParameterValues.Add(crParameterDiscreteValue)
    '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


    '        crSummary.SelectionFormula() = "{bill_exp_main.PrepDate} in #" & Format(Me.dtFromSummary.Value, "yyyy-MM-dd 00:00:00") & "# to #" & Format(Me.dtToSummary.Value.Date, "yyyy-MM-dd 23:59:59") & "# AND {bill_exp_main.Cancel} = 0"
    '        crSummary.ReportSource = CR
    '    End Sub

    '    Private Sub PopComboSQL(ByVal cbo As ComboBox, ByVal strsql As String, ByVal strField As String)

    '        If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)

    '        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

    '        cbo.Items.Clear()

    '        While reader.Read
    '            cbo.Items.Add(reader.Item(strField))
    '        End While

    '        reader.Close()
    '        cmdSQL.Dispose()
    '    End Sub

    '    Private Sub PopComboAccess(ByVal cbo As ComboBox, ByVal strsql As String, ByVal strField As String)
    '        If connExport.State <> ConnectionState.Open Then connExport.Open()

    '        Dim cmdSQL = New OleDb.OleDbCommand(strsql, connExport)

    '        Dim reader As OleDb.OleDbDataReader = cmdSQL.ExecuteReader

    '        cbo.Items.Clear()

    '        While reader.Read
    '            cbo.Items.Add(reader.Item(strField))
    '        End While

    '        reader.Close()
    '        cmdSQL.Dispose()
    '    End Sub

    '    Private Sub PopComboAccessImpF(ByVal cbo As ComboBox, ByVal strsql As String, ByVal strField As String)
    '        If connImport.State <> ConnectionState.Open Then connImport.Open()

    '        Dim cmdSQL = New OleDb.OleDbCommand(strsql, connImport)

    '        Dim reader As OleDb.OleDbDataReader = cmdSQL.ExecuteReader

    '        cbo.Items.Clear()

    '        While reader.Read
    '            cbo.Items.Add(reader.Item(strField))
    '        End While

    '        reader.Close()
    '        cmdSQL.Dispose()
    '    End Sub

    '    Private Sub frmBillingSummaryReports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '        Me.Dispose()
    '    End Sub

    '    Private Sub frmBillingSummaryReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Me.tbpBillingSummary.Text = Me.Text
    '        Me.lblFormTitle.Text = Me.Text
    '        Me.cmdClose.Left = Me.Width - 93
    '        'Me.gpLegend.Left = Panel2.Width - 223

    '        PopComboAccess(Me.cboAcctHolderName, "SELECT SLS_SAName FROM SLS ORDER BY SLS_SAName", "SLS_SAName")

    '        If Me.Text = "Export Billing Summary" Then
    '            PopComboSQL(Me.cboShipperName, "SELECT DISTINCT BilledTo FROM bill_exp_main ORDER BY BilledTo", "BilledTo")

    '            PopComboSQL(Me.cboCINo, "SELECT CINo FROM bill_exp_main WHERE CINo IS NOT NULL AND Length(CINo) > 0  AND PrepDate BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "CINo")
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_exp_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "SOANo")
    '            'Me.PanelAcctHolder.Enabled = True
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PopComboSQL(Me.cboShipperName, "SELECT DISTINCT BilledTo FROM bill_impb_main ORDER BY BilledTo", "BilledTo")

    '            PopComboSQL(Me.cboCINo, "SELECT CINo FROM bill_impb_main WHERE CINo IS NOT NULL AND Length(CINo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "CINo")
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_impb_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "SOANo")

    '            'Change Column Destination to Cont. No. if Import Brokerage
    '            Me.colDestination.HeaderText = "Cont. No."
    '        ElseIf Me.Text = "Import DC Note Billing Summary" Then


    '        Else
    '            PopComboSQL(Me.cboShipperName, "SELECT DISTINCT Client FROM bill_impf_main ORDER BY Client", "Client")

    '            PopComboSQL(Me.cboCINo, "SELECT InvoiceNum FROM bill_impf_main WHERE InvoiceNum IS NOT NULL AND Length(InvoiceNum) > 0 AND DateSaved BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY DateSaved DESC", "InvoiceNum")
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_impf_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND DateSaved BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY DateSaved", "SOANo")
    '            'Me.PanelAcctHolder.Enabled = False
    '            Me.colBookNo.HeaderText = "MBL"
    '            Me.colDestination.Visible = False
    '            Me.colTerms.Visible = False
    '        End If
    '    End Sub

    '    Private Sub cmdPrevSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevSummary.Click
    '        If Me.Text = "Export Billing Summary" Then
    '            PrevAllExp()
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PrevAllImpB()
    '        Else
    '            PrevAllImpF()
    '        End If
    '    End Sub

    '    Private Sub cmdPrevShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevShipper.Click
    '        If Me.Text = "Export Billing Summary" Then
    '            PrevReport(Me.crShipper, Me.dtFromShipper.Value, Me.dtToShipper.Value, Me.chkShipperNameAll.Checked, "BilledTo", Me.cboShipperName.Text)
    '        ElseIf Me.Text = "Import Forwarding Billing Summary" Then
    '            PrevReport(Me.crShipper, Me.dtFromShipper.Value, Me.dtToShipper.Value, Me.chkShipperNameAll.Checked, "Client", Me.cboShipperName.Text)
    '        Else
    '            PrevReport(Me.crShipper, Me.dtFromShipper.Value, Me.dtToShipper.Value, Me.chkShipperNameAll.Checked, "BilledTo", Me.cboShipperName.Text)
    '        End If
    '    End Sub

    '    Private Sub cmdPrevAcctHolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevAcctHolder.Click
    '        If Me.Text = "Export Billing Summary" Then
    '            PrevReport(Me.crAcctHolder, Me.dtFromAcctHolder.Value, Me.dtToAcctHolder.Value, Me.chkAcctHolderNameAll.Checked, "AcctHolder", Me.cboAcctHolderName.Text)
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PrevReport(Me.crAcctHolder, Me.dtFromAcctHolder.Value, Me.dtToAcctHolder.Value, Me.chkAcctHolderNameAll.Checked, "SLS_SAName", Me.cboAcctHolderName.Text)
    '        Else
    '            PrevReport(Me.crAcctHolder, Me.dtFromAcctHolder.Value, Me.dtToAcctHolder.Value, Me.chkAcctHolderNameAll.Checked, "SLS_SAName", Me.cboAcctHolderName.Text)
    '        End If
    '    End Sub

    '    Private Sub cmdPrevCI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevCI.Click
    '        If Me.Text = "Export Billing Summary" Or Me.Text = "Import Brokerage Billing Summary" Then
    '            PrevReport(Me.crCI, Me.dtFromCI.Value, Me.dtToCI.Value, Me.chkCINoAll.Checked, "CINo", Me.cboCINo.Text)
    '        ElseIf Me.Text = "Import Forwarding Billing Summary" Then
    '            PrevReport(Me.crCI, Me.dtFromCI.Value, Me.dtToCI.Value, Me.chkCINoAll.Checked, "InvoiceNum", Me.cboCINo.Text)
    '        End If
    '    End Sub

    '    Private Sub cmdPrevSOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevSOA.Click
    '        PrevReport(Me.crSOA, dtFromSOA.Value, Me.dtToSOA.Value, Me.chkSOANoAll.Checked, "SOANo", Me.cboSOANo.Text)
    '    End Sub

    '    Private Sub chkShipperNameAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShipperNameAll.CheckedChanged
    '        If Me.chkShipperNameAll.Checked = True Then
    '            Me.cboShipperName.SelectedIndex = -1
    '            Me.cboShipperName.Enabled = False
    '        Else
    '            Me.cboShipperName.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub chkAcctHolderNameAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAcctHolderNameAll.CheckedChanged
    '        If Me.chkAcctHolderNameAll.Checked = True Then
    '            Me.cboAcctHolderName.SelectedIndex = -1
    '            Me.cboAcctHolderName.Enabled = False
    '        Else
    '            Me.cboAcctHolderName.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub chkCINoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCINoAll.CheckedChanged
    '        If Me.chkCINoAll.Checked = True Then
    '            Me.cboCINo.SelectedIndex = -1
    '            Me.cboCINo.Enabled = False
    '        Else
    '            Me.cboCINo.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub chkSOANoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSOANoAll.CheckedChanged
    '        If Me.chkSOANoAll.Checked = True Then
    '            Me.cboSOANo.SelectedIndex = -1
    '            Me.cboSOANo.Enabled = False
    '        Else
    '            Me.cboSOANo.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub dtFromCI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromCI.ValueChanged
    '        If Me.Text = "Export Billing Summary" Then
    '            PopComboSQL(Me.cboCINo, "SELECT CINo FROM bill_exp_main WHERE CINo IS NOT NULL AND Length(CINo) > 0  AND PrepDate BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "CINo")
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PopComboSQL(Me.cboCINo, "SELECT CINo FROM bill_impb_main WHERE CINo IS NOT NULL AND Length(CINo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "CINo")
    '        Else
    '            PopComboSQL(Me.cboCINo, "SELECT InvoiceNum FROM bill_impf_main WHERE InvoiceNum IS NOT NULL AND Length(InvoiceNum) > 0 AND DateSaved BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY DateSaved DESC", "InvoiceNum")
    '        End If
    '    End Sub

    '    Private Sub dtToCI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtToCI.ValueChanged
    '        If Me.Text = "Export Billing Summary" Then
    '            PopComboSQL(Me.cboCINo, "SELECT CINo FROM bill_exp_main WHERE CINo IS NOT NULL AND Length(CINo) > 0  AND PrepDate BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "CINo")
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PopComboSQL(Me.cboCINo, "SELECT CINo FROM bill_impb_main WHERE CINo IS NOT NULL AND Length(CINo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "CINo")
    '        Else
    '            PopComboSQL(Me.cboCINo, "SELECT InvoiceNum FROM bill_impf_main WHERE InvoiceNum IS NOT NULL AND Length(InvoiceNum) > 0 AND DateSaved BETWEEN '" & Format$(Me.dtFromCI.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToCI.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY DateSaved DESC", "InvoiceNum")
    '        End If
    '    End Sub

    '    Private Sub dtFromSOA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromSOA.ValueChanged
    '        If Me.Text = "Export Billing Summary" Then
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_exp_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "SOANo")
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_impb_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "SOANo")
    '        Else
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_impf_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND DateSaved BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY DateSaved", "SOANo")
    '        End If
    '    End Sub

    '    Private Sub dtToSOA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtToSOA.ValueChanged
    '        If Me.Text = "Export Billing Summary" Then
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_exp_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "SOANo")
    '        ElseIf Me.Text = "Import Brokerage Billing Summary" Then
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_impb_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND PrepDate BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY PrepDate DESC", "SOANo")
    '        Else
    '            PopComboSQL(Me.cboSOANo, "SELECT SOANo FROM bill_impf_main WHERE SOANo IS NOT NULL AND Length(SOANo) > 0 AND DateSaved BETWEEN '" & Format$(Me.dtFromSOA.Value, "yyyy-MM-dd 00:00:00") & "' AND '" & Format$(Me.dtToSOA.Value, "yyyy-MM-dd 23:59:59") & "' ORDER BY DateSaved", "SOANo")
    '        End If
    '    End Sub

    '    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    '        Me.Close()
    '    End Sub

    '    Private Sub chkAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAll.Click
    '        If Me.chkAll.Checked = True Then
    '            Me.chkPosted.Checked = False
    '            Me.chkOpen.Checked = False
    '            Me.chkCancelled.Checked = False
    '        End If

    '        CheckForBillMonitoringIfExpOrImpB()
    '        SetGridStatusColor()
    '    End Sub

    '    Private Sub chkCancelled_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCancelled.Click
    '        If Me.chkCancelled.Checked = True Then
    '            Me.chkAll.Checked = False
    '        End If

    '        CheckForBillMonitoringIfExpOrImpB()
    '        SetGridStatusColor()
    '    End Sub

    '    Private Sub chkPosted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPosted.Click
    '        If Me.chkPosted.Checked = True Then
    '            Me.chkAll.Checked = False
    '        End If

    '        CheckForBillMonitoringIfExpOrImpB()
    '        SetGridStatusColor()
    '    End Sub

    '    Private Sub chkOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOpen.Click
    '        If Me.chkOpen.Checked = True Then
    '            Me.chkAll.Checked = False
    '        End If

    '        CheckForBillMonitoringIfExpOrImpB()
    '        SetGridStatusColor()
    '    End Sub

    '    Private Sub dtFromMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFromMon.ValueChanged
    '        CheckForBillMonitoringIfExpOrImpB()
    '        SetGridStatusColor()
    '    End Sub

    '    Private Sub dtToMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtToMon.ValueChanged
    '        CheckForBillMonitoringIfExpOrImpB()
    '        SetGridStatusColor()
    '    End Sub

    '    Private Sub dtgBillingMonitoring_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dtgBillingMonitoring.CellPainting
    '        Dim i As Integer
    '        'Dim i2 As Integer
    '        'Dim i2 As Integer
    '        For i = 0 To Me.dtgBillingMonitoring.Columns.Count - 1
    '            If e.ColumnIndex = i AndAlso e.RowIndex <> -1 Then
    '                Using gridBrush As Brush = New SolidBrush(Me.dtgBillingMonitoring.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

    '                    Using gridLinePen As Pen = New Pen(gridBrush)
    '                        ' Clear cell  
    '                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

    '                        'If next row cell has different content, only draw bottom border line of current cell
    '                        If e.RowIndex < dtgBillingMonitoring.Rows.Count - 1 AndAlso dtgBillingMonitoring.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
    '                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
    '                        End If

    '                        If e.RowIndex < dtgBillingMonitoring.Rows.Count - 1 AndAlso dtgBillingMonitoring.Rows(e.RowIndex + 1).Cells(0).Value.ToString() <> dtgBillingMonitoring.Rows(e.RowIndex).Cells(0).Value.ToString() Then
    '                            e.Graphics.DrawLine(Pens.Black, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
    '                        End If

    '                        ' Draw right border line of current cell  
    '                        e.Graphics.DrawLine(Pens.Black, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

    '                        ' draw/fill content in current cell, and fill only one cell of multiple same cells  
    '                        If Not e.Value Is Nothing Then
    '                            'If e.ColumnIndex = 0 Then
    '                            If e.RowIndex > 0 AndAlso dtgBillingMonitoring.Rows(e.RowIndex - 1).Cells(0).Value.ToString() = dtgBillingMonitoring.Rows(e.RowIndex).Cells(0).Value.ToString() Then
    '                            Else
    '                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
    '                            End If
    '                            'Else
    '                            If e.RowIndex > 0 AndAlso (dtgBillingMonitoring.Rows(e.RowIndex - 1).Cells(i).Value.ToString() = e.Value.ToString()) Then
    '                            Else
    '                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
    '                            End If
    '                            'End If
    '                        End If
    '                        e.Handled = True
    '                    End Using
    '                End Using
    '            End If
    '        Next
    '    End Sub
End Class