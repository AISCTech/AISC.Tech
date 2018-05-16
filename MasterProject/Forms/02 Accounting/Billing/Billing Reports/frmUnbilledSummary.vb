Imports MySql.Data.MySqlClient
Public Class frmUnbilledSummary
    Private Sub frmUnbilledSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub SetStatusColor()
    '    For ctrrow As Integer = 0 To Me.dtgUnbilledSummary.Rows.Count - 1
    '        For ctrcol As Integer = 0 To Me.dtgUnbilledSummary.Columns.Count - 1
    '            With Me.dtgUnbilledSummary.Rows(ctrrow).Cells(ctrcol)
    '                Select Case Me.dtgUnbilledSummary.Rows(ctrrow).Cells("colStatus").Value
    '                    Case "Open"
    '                        .Style.BackColor = Color.LightGreen
    '                    Case "Posted"
    '                        .Style.BackColor = Color.LightSkyBlue
    '                    Case "Cancelled"
    '                        .Style.BackColor = Color.IndianRed
    '                    Case Else
    '                        .Style.BackColor = Color.White
    '                End Select
    '            End With
    '        Next
    '    Next
    'End Sub

    'Private Sub LoadUnbilled()
    '    Select Case Me.Tag
    '        Case "Exp"
    '            RetrieveExpUnbilled()
    '        Case "ImpB"
    '            RetrieveImpBUnbilled()
    '        Case "ImpF"
    '            RetrieveImpFUnbilled()
    '    End Select

    '    Me.lblCount.Text = Me.dtgUnbilledSummary.Rows.Count & " unbilled booking nos."

    '    SetStatusColor()
    'End Sub

    'Private Sub RetrieveImpFUnbilled()
    '    Dim strStatus As String = ""
    '    Dim dtCurrent As Date = GetServerDate()

    '    Dim strsql As String = "SELECT ImpMBL.ArrivalDate, ImpHBL.* FROM ImpMBL INNER JOIN ImpHBL ON ImpMBL.MasterBL = ImpHBL.MasterBL " &
    '                           "WHERE ImpMBL.ArrivalDate BETWEEN #" & Me.dtFrom.Value & "# AND #" & Me.dtTo.Value & "#"

    '    If connImport.State <> ConnectionState.Open Then connImport.Open()

    '    Dim cmdAccess = New OleDb.OleDbCommand(strsql, connImport)

    '    Dim rdrAccess As OleDb.OleDbDataReader = cmdAccess.ExecuteReader
    '    Dim i2 As Integer = 0
    '    Me.dtgUnbilledSummary.Rows.Clear()
    '    Dim dtETA As Date
    '    If rdrAccess.HasRows = False Then
    '        rdrAccess.Close()
    '        cmdAccess.Dispose()
    '        Exit Sub
    '    End If

    '    While rdrAccess.Read
    '        If rdrAccess.Item("Posted") = True Then
    '            strStatus = "Posted"
    '        Else
    '            strStatus = "Open"
    '        End If

    '        dtETA = rdrAccess.Item("ArrivalDate")



    '        Me.dtgUnbilledSummary.Rows.Add(rdrAccess.Item("MasterBL"), rdrAccess.Item("HouseBL"), rdrAccess.Item("Shipper"), rdrAccess.Item("Consignee"), rdrAccess.Item("CargoLoad"), Format$(rdrAccess.Item("ArrivalDate"), "MM/dd/yyyy"), "")

    '        If dtETA.AddDays(1) < dtCurrent Then
    '            Me.dtgUnbilledSummary.Rows(i2).DefaultCellStyle.ForeColor = Color.Red
    '        Else
    '            Me.dtgUnbilledSummary.Rows(i2).DefaultCellStyle.ForeColor = Color.Black
    '        End If

    '        i2 = i2 + 1
    '    End While

    '    rdrAccess.Close()
    '    cmdAccess.Dispose()


    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand

    '    Dim rdrSQL As MySql.Data.MySqlClient.MySqlDataReader

    '    Dim ctrrow As Integer = 0

    '    While ctrrow <= Me.dtgUnbilledSummary.Rows.Count - 1
    '        With Me.dtgUnbilledSummary.Rows(ctrrow)
    '            strsql = "SELECT * FROM bill_impf_main WHERE HouseBL = '" & .Cells("colHBL").Value & "'"

    '            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            rdrSQL = cmdSQL.ExecuteReader

    '            If rdrSQL.HasRows = True Then
    '                Me.dtgUnbilledSummary.Rows.Remove(Me.dtgUnbilledSummary.Rows(ctrrow))
    '            Else
    '                ctrrow += 1
    '            End If

    '            rdrSQL.Close()
    '        End With
    '    End While

    '    cmdSQL.Dispose()
    'End Sub

    'Private Sub RetrieveImpBUnbilled()
    '    Dim strStatus As String = "", strSeaAir As String = ""

    '    Dim strsql As String = "SELECT * FROM ImpBrokerage " &
    '                           "WHERE (Status = 1 Or Status = 4) AND EncodedDate BETWEEN " &
    '                           "@from AND @to " &
    '                           "ORDER by ControlNum"
    '    '                       "@from AND @to " & _
    '    '                       "ORDER by ImpBrokerage.ControlNum"
    '    '                       "WHERE ImpBrokerage.ReleasedDate BETWEEN #" & Me.dtFrom.Value & "# AND #" & Me.dtTo.Value & "#"
    '    'Dim strsql As String = "SELECT ImpBrokerage.ControlNum, ImpBrokerage.Shipper, ImpBrokerage.HouseBL, BrokerageContainers.ContainerNum " & _
    '    '                       "from ImpBrokerage INNER JOIN BrokerageContainers ON ImpBrokerage.ControlNum = BrokerageContainers.ControlNum " & _
    '    '                       "WHERE (Status = 1 Or Status = 4) AND ImpBrokerage.EncodedDate BETWEEN " & _
    '    '                       "@from AND @to " & _
    '    '                       "ORDER by ImpBrokerage.ControlNum"

    '    If connImport.State <> ConnectionState.Open Then connImport.Open()

    '    Dim cmdAccess = New OleDb.OleDbCommand(strsql, connImport)

    '    With cmdAccess.Parameters
    '        .AddWithValue("@from", Format$(Me.dtFrom.Value, "MM/dd/yyyy 00:00:00"))
    '        .AddWithValue("@to", Format$(Me.dtTo.Value, "MM/dd/yyyy 23:59:59"))
    '    End With

    '    Dim rdrAccess As OleDb.OleDbDataReader = cmdAccess.ExecuteReader

    '    Me.dtgUnbilledSummary.Rows.Clear()
    '    If rdrAccess.HasRows = False Then
    '        rdrAccess.Close()
    '        cmdAccess.Dispose()
    '        Exit Sub
    '    End If
    '    Dim DelDate As Date
    '    Dim dtCurrent As Date = GetServerDate()
    '    Dim i2 As Integer = 0
    '    While rdrAccess.Read
    '        If rdrAccess.Item("Status") = 3 Then
    '            strStatus = "Cancelled"
    '        ElseIf rdrAccess.Item("Status") = 1 Then
    '            strStatus = "Open"
    '        ElseIf rdrAccess.Item("Status") = 2 Then
    '            strStatus = "Loaded"
    '        ElseIf rdrAccess.Item("Status") = 4 Then
    '            strStatus = "Posted"
    '        ElseIf rdrAccess.Item("Status") = 5 Then
    '            strStatus = "Re-book"
    '        ElseIf rdrAccess.Item("Status") = 6 Then
    '            strStatus = "Foul"
    '        End If

    '        Select Case rdrAccess.Item("ShipmentMode")
    '            Case "S"
    '                strSeaAir = "Sea"
    '            Case "A"
    '                strSeaAir = "Air"
    '            Case Else
    '                strSeaAir = ""
    '        End Select



    '        Me.dtgUnbilledSummary.Rows.Add(rdrAccess.Item("ControlNum"), rdrAccess.Item("Consignee"), rdrAccess.Item("HouseBL"), rdrAccess.Item("CargoLoad"), "", strSeaAir, Format(rdrAccess.Item("EncodedDate"), "MM/dd/yyyy"), strStatus, rdrAccess.Item("ReleasedDelDate"))
    '        If IsDBNull(rdrAccess.Item("ReleasedDelDate")) = True Then
    '            DelDate = Nothing
    '        Else
    '            DelDate = rdrAccess.Item("ReleasedDelDate")

    '            If DelDate.AddDays(1) < dtCurrent Then
    '                Me.dtgUnbilledSummary.Rows(i2).DefaultCellStyle.ForeColor = Color.Red
    '            Else
    '                Me.dtgUnbilledSummary.Rows(i2).DefaultCellStyle.ForeColor = Color.Black
    '            End If

    '        End If
    '        i2 = i2 + 1
    '    End While

    '    rdrAccess.Close()
    '    cmdAccess.Dispose()


    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand

    '    Dim rdrSQL As MySql.Data.MySqlClient.MySqlDataReader

    '    Dim ctrrow As Integer = 0

    '    While ctrrow <= Me.dtgUnbilledSummary.Rows.Count - 1
    '        With Me.dtgUnbilledSummary.Rows(ctrrow)
    '            strsql = "SELECT * FROM bill_impb_booking WHERE BookingNo = '" & .Cells("colBooking").Value & "'"

    '            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            rdrSQL = cmdSQL.ExecuteReader

    '            If rdrSQL.HasRows = True Then
    '                Me.dtgUnbilledSummary.Rows.Remove(Me.dtgUnbilledSummary.Rows(ctrrow))
    '            Else
    '                ctrrow += 1
    '            End If

    '            rdrSQL.Close()
    '        End With
    '    End While

    '    cmdSQL.Dispose()
    'End Sub

    'Public Function GetETAETD(ByVal str As String, ByVal strBook As String) As String
    '    GetETAETD = ""

    '    Select Case str

    '        Case "IMPB"
    '            Dim strsql As String = "SELECT crp_Counter, BranchCode FROM ap_sysparams WHERE CompanyID = 'AIS_BIB' AND BranchCode = '" & BranchCode & "'"

    '            If connImport2.State <> ConnectionState.Open Then connImport2.Open()

    '            Dim cmdsql = New OleDb.OleDbCommand(strsql, connImport2)

    '            Dim reader As OleDb.OleDbDataReader = cmdsql.ExecuteReader

    '            If reader.HasRows = False Then
    '                GetETAETD = ""
    '            Else
    '                While reader.Read
    '                    GetETAETD = Format(reader.Item("ReleasedDelDate"), "yyyy-MM-dd hh:mm:ss")
    '                End While
    '            End If

    '            reader.Close()
    '            cmdsql.Dispose()
    '        Case "EXP"

    '    End Select

    'End Function

    'Private Sub RetrieveExpUnbilled()
    '    Dim strStatus As String = ""

    '    Dim strsql As String = "SELECT * FROM (((BKS LEFT JOIN BKSBL ON BKS.BKS_Nbr = BKSBL.BKSBL_BKSNum) " &
    '                           "INNER JOIN SHP ON BKS.BKS_ShippertCode = SHP.SHP_ClientCode)" &
    '                           "INNER JOIN DES ON BKS.BKS_DestCode = DES.DES_DestCode) LEFT JOIN HBL ON BKSBL.BKSBL_BLNum = HBL.HBL_BLNumber " &
    '                           "WHERE SHP.SHP_ExcludeBilling = false AND BKS.BKS_Master = false and BKS.BKS_Date BETWEEN #" & Format$(Me.dtFrom.Value, "MM/dd/yyyy 00:00:00") & "# AND #" & Format$(Me.dtTo.Value, "MM/dd/yyyy 00:00:00") & "#"

    '    If connExport.State <> ConnectionState.Open Then connExport.Open()

    '    Dim cmdAccess = New OleDb.OleDbCommand(strsql, connExport)

    '    Dim rdrAccess As OleDb.OleDbDataReader = cmdAccess.ExecuteReader
    '    Dim ATD As Date
    '    Dim dtCurrent As Date = GetServerDate()
    '    Me.dtgUnbilledSummary.Rows.Clear()
    '    Dim i2 As Integer = 0
    '    If rdrAccess.HasRows = False Then
    '        rdrAccess.Close()
    '        cmdAccess.Dispose()
    '        Exit Sub
    '    End If

    '    While rdrAccess.Read
    '        If rdrAccess.Item("BKS_Status") = 3 Then
    '            strStatus = "Cancelled"
    '        ElseIf rdrAccess.Item("BKS_Status") = 1 Then
    '            strStatus = "Open"
    '        ElseIf rdrAccess.Item("BKS_Status") = 2 Then
    '            strStatus = "Loaded"
    '        ElseIf rdrAccess.Item("BKS_Status") = 4 Then
    '            strStatus = "Posted"
    '        ElseIf rdrAccess.Item("BKS_Status") = 5 Then
    '            strStatus = "Re-book"
    '        ElseIf rdrAccess.Item("BKS_Status") = 6 Then
    '            strStatus = "Foul"
    '        End If



    '        Me.dtgUnbilledSummary.Rows.Add(rdrAccess.Item("BKS_Nbr"), rdrAccess.Item("SHP_ClientName"), IIf(IsDBNull(rdrAccess.Item("BKSBL_BLNum")), "", rdrAccess.Item("BKSBL_BLNum")), rdrAccess.Item("DES_DestName"), rdrAccess.Item("BKS_FreightType"), Format(rdrAccess.Item("BKS_Date"), "MM/dd/yyyy"), strStatus, "")

    '        If IsDBNull(rdrAccess.Item("HBL_BoardVesselLaden")) = True Then
    '            ATD = Nothing
    '        Else
    '            ATD = rdrAccess.Item("HBL_BoardVesselLaden")

    '            If ATD.AddDays(1) < dtCurrent Then
    '                Me.dtgUnbilledSummary.Rows(i2).DefaultCellStyle.ForeColor = Color.Red
    '            Else
    '                Me.dtgUnbilledSummary.Rows(i2).DefaultCellStyle.ForeColor = Color.Black
    '            End If
    '        End If
    '        i2 = i2 + 1
    '    End While

    '    rdrAccess.Close()
    '    cmdAccess.Dispose()


    '    If connAcctg.State <> ConnectionState.Open Then connAcctg.Open()

    '    Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand

    '    Dim rdrSQL As MySql.Data.MySqlClient.MySqlDataReader

    '    Dim ctrrow As Integer = 0

    '    While ctrrow <= Me.dtgUnbilledSummary.Rows.Count - 1
    '        With Me.dtgUnbilledSummary.Rows(ctrrow)
    '            strsql = "SELECT * FROM bill_exp_booking WHERE BookingNo = '" & .Cells("colBooking").Value & "'"

    '            cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, connAcctg)
    '            rdrSQL = cmdSQL.ExecuteReader

    '            If rdrSQL.HasRows = True Then
    '                Me.dtgUnbilledSummary.Rows.Remove(Me.dtgUnbilledSummary.Rows(ctrrow))
    '            Else
    '                ctrrow += 1
    '            End If

    '            rdrSQL.Close()
    '        End With
    '    End While

    '    cmdSQL.Dispose()
    'End Sub

    'Private Sub SetGridColumns()
    '    Select Case Me.Tag
    '        Case "Exp"
    '            With dtgUnbilledSummary
    '                .Columns.Clear()

    '                .Columns.Add("colBooking", "Booking No.")
    '                .Columns.Add("colShipName", "Shipper Name")
    '                .Columns.Add("colBL", "B/L")
    '                .Columns.Add("colDest", "Destination")
    '                .Columns.Add("colSeaAir", "Sea/Air")
    '                .Columns.Add("colDate", "Date")
    '                .Columns.Add("colStatus", "Status")
    '                .Columns.Add("colATD", "ATD")

    '                .Columns("colBooking").Width = 100
    '                .Columns("colBooking").Frozen = True

    '                .Columns("colShipName").Width = 375
    '                .Columns("colBL").Width = 150
    '                .Columns("colDest").Width = 125
    '                .Columns("colSeaAir").Width = 75
    '                .Columns("colDate").Width = 125
    '                .Columns("colStatus").Width = 100
    '                .Columns("colATD").Width = 275
    '            End With
    '        Case "ImpB"
    '            Dim colcmdLCLFCL As New DataGridViewButtonColumn
    '            colcmdLCLFCL.Name = "colcmdLCLFCL"
    '            colcmdLCLFCL.HeaderText = ""

    '            With dtgUnbilledSummary
    '                .Columns.Clear()

    '                .Columns.Add("colBooking", "Booking No.")
    '                .Columns.Add("colCneeName", "Consignee Name")
    '                .Columns.Add("colBL", "B/L")
    '                .Columns.Add("colFCLLCL", "FCL/LCL")
    '                .Columns.Add(colcmdLCLFCL)
    '                .Columns.Add("colSeaAir", "Sea/Air")
    '                .Columns.Add("colDate", "Date Encoded")
    '                .Columns.Add("colStatus", "Status")
    '                .Columns.Add("colDelDate", "Delivery Date")

    '                .Columns("colBooking").Width = 100
    '                .Columns("colBooking").Frozen = True

    '                .Columns("colCneeName").Width = 375
    '                .Columns("colBL").Width = 150
    '                .Columns("colFCLLCL").Width = 60
    '                .Columns("colcmdLCLFCL").Width = 25
    '                .Columns("colcmdLCLFCL").Visible = False

    '                .Columns("colSeaAir").Width = 60
    '                .Columns("colDate").Width = 125
    '                .Columns("colStatus").Width = 100
    '                .Columns("colDelDate").Width = 275
    '            End With
    '        Case "ImpF"
    '            With dtgUnbilledSummary
    '                .Columns.Clear()

    '                .Columns.Add("colMBL", "MBL")
    '                .Columns.Add("colHBL", "HBL")
    '                .Columns.Add("colShipper", "Shipper")
    '                .Columns.Add("colCnee", "Consignee")
    '                .Columns.Add("colLCLFCL", "LCL/FCL")
    '                .Columns.Add("colDate", "Arrival Date")
    '                '.Columns.Add("colStatus", "Status")
    '                '.Columns.Add("colRemarks", "Remarks")

    '                .Columns("colMBL").Width = 125
    '                .Columns("colHBL").Width = 125
    '                .Columns("colHBL").Frozen = True

    '                .Columns("colShipper").Width = 375
    '                .Columns("colCnee").Width = 375
    '                .Columns("colLCLFCL").Width = 60
    '                .Columns("colDate").Width = 100
    '                '.Columns("colStatus").Width = 100
    '                '.Columns("colRemarks").Width = 275
    '            End With
    '    End Select
    'End Sub

    'Private Sub frmUnbilledSummary_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    Me.Dispose()
    'End Sub

    'Private Sub frmUnbilledSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    SetGridColumns()
    '    LoadUnbilled()
    'End Sub

    'Private Sub dtFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFrom.ValueChanged
    '    LoadUnbilled()
    'End Sub

    'Private Sub dtTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtTo.ValueChanged
    '    LoadUnbilled()
    'End Sub

    'Private Sub dtgUnbilledSummary_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgUnbilledSummary.CellContentClick
    '    If Me.dtgUnbilledSummary.Columns(e.ColumnIndex).Name = "colcmdLCLFCL" Then
    '        If Me.dtgUnbilledSummary.Rows(e.RowIndex).Cells("colFCLLCL").Value = "FCL" Then

    '        End If
    '    End If
    'End Sub
End Class