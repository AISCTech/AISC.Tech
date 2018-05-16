Imports MasterProject

Public Class frmExportBookingMonitoring

    Implements ICommonFunction

    Dim dvDataView As DataView

    Public Sub NewRecord() Implements ICommonFunction.NewRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord

    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ChangeEnabledButtons(False, False, False, True, False, False, False, False, False, False)

        PopulateTreeView()
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Private Sub SetGridColor()
        For Each row As DataGridViewRow In dtgBooking.Rows
            For Each col As DataGridViewColumn In dtgBooking.Columns
                'row.Cells(col.Index).Style.BackColor = Color.FromArgb(row.Cells(colColorR.Name).Value, row.Cells(colColorG.Name).Value, row.Cells(colColorB.Name).Value)
            Next
        Next
    End Sub

    Private Sub SetTreeViewParentNodes()
        Dim GrandfatherNode As TreeNode = trvSelection.Nodes.Add("Grandfather")
        Dim fatherNode As TreeNode = GrandfatherNOde.Nodes.Add("Father")
        Dim sonNode As TreeNode = fatherNode.Nodes.Add("Son")

        trvSelection.Nodes.Clear()
        trvSelection.Nodes.Add("ndeLCL", "LCL", 0)
        trvSelection.Nodes.Add("ndeFCL", "FCL", 0)
        trvSelection.Nodes.Add("ndeDestination", "Destination", 0)
        trvSelection.Nodes.Add("ndeCoload", "Coload", 0)
        'trvSelection.Nodes.Add("ndeClient", "Client", 0)
        trvSelection.Nodes.Add("ndeAll", "All Bookings", 0)

        Dim tempNode() As TreeNode
        tempNode = trvSelection.Nodes.Find("ndeLCL", True)
        tempNode(0).Nodes.Add("ndeLCLAll", "All", 0)
        tempNode(0).Nodes.Add("ndeLCLAir", "Air", 0)
        tempNode(0).Nodes.Add("ndeLCLSea", "Sea", 0)

        tempNode = trvSelection.Nodes.Find("ndeFCL", True)
        tempNode(0).Nodes.Add("ndeFCLAll", "All", 0)
        tempNode(0).Nodes.Add("ndeFCLAir", "Air", 0)
        tempNode(0).Nodes.Add("ndeFCLSea", "Sea", 0)
    End Sub

    Private Sub SetTreeViewDestinations(ByVal lstMaster As List(Of clsExportMasterBooking))
        Dim ndeDest() As TreeNode = trvSelection.Nodes.Find("ndeDestination", True)
        Dim tempNode() As TreeNode
        Dim strKey As String

        For Each clsMaster As clsExportMasterBooking In lstMaster
            strKey = "ndeDestID" & clsMaster._DestinationDetails._PK
            tempNode = trvSelection.Nodes.Find(strKey, True)
            If tempNode.Length = 0 Then
                ndeDest(0).Nodes.Add(strKey, clsMaster._DestinationDetails._Description)
            End If
        Next
    End Sub

    Private Sub PopulateDataGridMasterBooking(ByVal strMasterBookingID As String)
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster


            cmdSQL.CommandText = "SELECT ID, " & '0
                                    "CompanyCode, " & '1
                                    "BookingNo, " & '2
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " & '3
                                    "PrepDate AS `Prepared Date`, " & '4
                                    "ConsignorCode, " & '5
                                    "ConsignorName AS `Consignor / Debtor`, " & '6
                                    "ShipperCode, " & '7
                                    "ShipperName AS `Shipper`, " & '8
                                    "ConsigneeCode, " & '9
                                    "ConsigneeName AS `Consignee`, " & '10
                                    "FinalDestinationID, " & '11
                                    "FinalDestinationName AS `Final Destination` " & '12
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "MasterBookingID = @MasterBookingID " &
                                "ORDER BY " &
                                    "PrepDate"
            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                .AddWithValue("@MasterBookingID", strMasterBookingID)
            End With


            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgBooking
                .DataSource = dvDataView

                .Columns(0).Frozen = True
                .Columns(1).Frozen = True
                .Columns(2).Frozen = True
                .Columns(3).Frozen = True

                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Width = 125
                .Columns(4).Width = 125
                .Columns(5).Visible = False
                .Columns(6).Width = 275
                .Columns(7).Visible = False
                .Columns(8).Width = 275
                .Columns(9).Visible = False
                .Columns(10).Width = 275
                .Columns(11).Visible = False
                .Columns(12).Width = 125
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopulateDataGridBooking()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster

            If optStatusOpen.Checked = True Then
                cmdSQL.CommandText = "SELECT ID, " & '0
                                    "CompanyCode, " & '1
                                    "BookingNo, " & '2
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " & '3
                                    "PrepDate AS `Prepared Date`, " & '4
                                    "ConsignorCode, " & '5
                                    "ConsignorName AS `Consignor / Debtor`, " & '6
                                    "ShipperCode, " & '7
                                    "ShipperName AS `Shipper`, " & '8
                                    "ConsigneeCode, " & '9
                                    "ConsigneeName AS `Consignee`, " & '10
                                    "FinalDestinationID, " & '11
                                    "FinalDestinationName AS `Final Destination` " & '12
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "StatusID = 1 " &
                                "ORDER BY " &
                                    "PrepDate"
                With cmdSQL.Parameters
                    .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                End With
            Else
                Dim dtFrom As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0)
                Dim dtTo As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 0, 0, 0).AddDays(1)

                cmdSQL.CommandText = "SELECT ID, " & '0
                                    "CompanyCode, " & '1
                                    "BookingNo, " & '2
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " & '3
                                    "PrepDate AS `Prepared Date`, " & '4
                                    "ConsignorCode, " & '5
                                    "ConsignorName AS `Consignor / Debtor`, " & '6
                                    "ShipperCode, " & '7
                                    "ShipperName AS `Shipper`, " & '8
                                    "ConsigneeCode, " & '9
                                    "ConsigneeName AS `Consignee`, " & '10
                                    "FinalDestinationID, " & '11
                                    "FinalDestinationName AS `Final Destination` " & '12
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "PrepDate BETWEEN @From AND @To " &
                                "ORDER BY " &
                                    "PrepDate"
                With cmdSQL.Parameters
                    .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                    .AddWithValue("@From", dtFrom)
                    .AddWithValue("@To", dtTo)
                End With
            End If



            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgBooking
                .DataSource = dvDataView

                .Columns(0).Frozen = True
                .Columns(1).Frozen = True
                .Columns(2).Frozen = True
                .Columns(3).Frozen = True

                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Width = 125
                .Columns(4).Width = 125
                .Columns(5).Visible = False
                .Columns(6).Width = 275
                .Columns(7).Visible = False
                .Columns(8).Width = 275
                .Columns(9).Visible = False
                .Columns(10).Width = 275
                .Columns(11).Visible = False
                .Columns(12).Width = 125
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopulateDataGridColoadBooking()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster

            If optStatusOpen.Checked = True Then
                cmdSQL.CommandText = "SELECT ID, " & '0
                                    "CompanyCode, " & '1
                                    "BookingNo, " & '2
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " & '3
                                    "PrepDate AS `Prepared Date`, " & '4
                                    "ConsignorCode, " & '5
                                    "ConsignorName AS `Consignor / Debtor`, " & '6
                                    "ShipperCode, " & '7
                                    "ShipperName AS `Shipper`, " & '8
                                    "ConsigneeCode, " & '9
                                    "ConsigneeName AS `Consignee`, " & '10
                                    "FinalDestinationID, " & '11
                                    "FinalDestinationName AS `Final Destination` " & '12
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "LENGTH(ColoadToID) > 0 AND " &
                                    "StatusID = 1 " &
                                "ORDER BY " &
                                    "PrepDate"
                With cmdSQL.Parameters
                    .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                End With
            Else
                Dim dtFrom As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0)
                Dim dtTo As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 0, 0, 0).AddDays(1)

                cmdSQL.CommandText = "SELECT ID, " & '0
                                    "CompanyCode, " & '1
                                    "BookingNo, " & '2
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " & '3
                                    "PrepDate AS `Prepared Date`, " & '4
                                    "ConsignorCode, " & '5
                                    "ConsignorName AS `Consignor / Debtor`, " & '6
                                    "ShipperCode, " & '7
                                    "ShipperName AS `Shipper`, " & '8
                                    "ConsigneeCode, " & '9
                                    "ConsigneeName AS `Consignee`, " & '10
                                    "FinalDestinationID, " & '11
                                    "FinalDestinationName AS `Final Destination` " & '12
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "LENGTH(ColoadToID) > 0 AND " &
                                    "PrepDate BETWEEN @From AND @To " &
                                "ORDER BY " &
                                    "PrepDate"
                With cmdSQL.Parameters
                    .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                    .AddWithValue("@From", dtFrom)
                    .AddWithValue("@To", dtTo)
                End With
            End If


            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgBooking
                .DataSource = dvDataView

                .Columns(0).Frozen = True
                .Columns(1).Frozen = True
                .Columns(2).Frozen = True
                .Columns(3).Frozen = True

                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Width = 125
                .Columns(4).Width = 125
                .Columns(5).Visible = False
                .Columns(6).Width = 275
                .Columns(7).Visible = False
                .Columns(8).Width = 275
                .Columns(9).Visible = False
                .Columns(10).Width = 275
                .Columns(11).Visible = False
                .Columns(12).Width = 125
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopulateTreeView()
        SetTreeViewParentNodes()

        Dim clsDB As New clsDBTrans
        Dim lstMaster As New List(Of clsExportMasterBooking)
        If optStatusOpen.Checked = True Then
            lstMaster = clsDB.PopulateListOfExportMasterBookingOpenRecords(CurrentUser._Company_Code)
        Else
            lstMaster = clsDB.PopulateListOfExportMasterBookingDateFromTo(CurrentUser._Company_Code, dtpFrom.Value, dtpTo.Value)
        End If

        SetTreeViewDestinations(lstMaster)

        Dim tempNode() As TreeNode
        Dim strKey As String
        Dim strText As String
        For Each clsMaster As clsExportMasterBooking In lstMaster
            strKey = "ndeMst" & clsMaster._ID
            strText = clsMaster._RefNo & ", " & clsMaster._DestinationDetails._Description & ", " & clsMaster._ModeOfTransportDetails._Param_Desc

            'LCL
            If clsMaster._LoadTypeDetails._PK = 4 Then
                tempNode = trvSelection.Nodes.Find("ndeLCLALL", True)
                tempNode(0).Nodes.Add(strKey, strText)

                'SEA
                If clsMaster._ModeOfTransportDetails._PK = 8 Then
                    tempNode = trvSelection.Nodes.Find("ndeLCLSea", True)
                    tempNode(0).Nodes.Add(strKey, strText)
                End If

                'AIR
                If clsMaster._ModeOfTransportDetails._PK = 9 Then
                    tempNode = trvSelection.Nodes.Find("ndeLCLAir", True)
                    tempNode(0).Nodes.Add(strKey, strText)
                End If
            End If

            'FCL
            If clsMaster._LoadTypeDetails._PK = 5 Then
                tempNode = trvSelection.Nodes.Find("ndeFCLALL", True)
                tempNode(0).Nodes.Add(strKey, strText)

                'SEA
                If clsMaster._ModeOfTransportDetails._PK = 8 Then
                    tempNode = trvSelection.Nodes.Find("ndeFCLSea", True)
                    tempNode(0).Nodes.Add(strKey, strText)
                End If

                'AIR
                If clsMaster._ModeOfTransportDetails._PK = 8 Then
                    tempNode = trvSelection.Nodes.Find("ndeFCLAir", True)
                    tempNode(0).Nodes.Add(strKey, strText)
                End If
            End If

            'DESTINATION
            tempNode = trvSelection.Nodes.Find("ndeDestID" & clsMaster._DestinationDetails._PK, True)
            tempNode(0).Nodes.Add(strKey, strText)
        Next

        dtgBooking.DataSource = Nothing
    End Sub

    Private Sub frmExportBookingMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtServerDate As Date = GetServerDate()
        Dim dtToday As Date = New Date(dtServerDate.Year, dtServerDate.Month, dtServerDate.Day, 0, 0, 0)

        dtpFrom.Value = GetFirstDayOfWeek(dtToday)
        dtpTo.Value = GetLastDayOfWeek(dtToday)

        optStatusOpen.Checked = True
        ResetRecord()
    End Sub

    Private Sub trvSelection_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvSelection.AfterSelect
        dtgBooking.DataSource = Nothing

        If Mid(e.Node.Name, 1, 6) = "ndeMst" Then
            PopulateDataGridMasterBooking(Replace(e.Node.Name, "ndeMst", ""))
        End If

        If e.Node.Name = "ndeAll" Then
            PopulateDataGridBooking()
        End If

        If e.Node.Name = "ndeCoload" Then
            PopulateDataGridColoadBooking()
        End If
    End Sub

    Private Sub MakeSelected(ByVal node As TreeNode, ByVal selected As Boolean)
        Try
            node.ImageIndex = IIf(selected, 1, 0)
            node.SelectedImageIndex = IIf(selected, 1, 0)

            If Not node.IsExpanded Then
                node.Expand()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub trvSelection_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles trvSelection.BeforeSelect
        Try
            If trvSelection.SelectedNode IsNot Nothing Then
                MakeSelected(trvSelection.SelectedNode, False)
            End If

            MakeSelected(e.Node, True)
        Catch ex As Exception

        End Try
    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .SearchEnabled = blSearch
            .PostEnabled = blPost
            .CancelEnabled = blCancel
            .ReOpen = blReOpen

            .UpdateEnabledButtons()
        End With
    End Sub

    Private Sub frmExportBookingMonitoring_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub frmExportBookingMonitoring_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub dtgBooking_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBooking.CellContentClick

    End Sub

    Private Sub dtgBooking_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBooking.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim clsExpTemp As New clsExportBookingHeader
            Dim clsDBTemp As New clsDBTrans
            clsExpTemp = clsDBTemp.CustomerServiceExportBookingSearch(dtgBooking.Rows(e.RowIndex).Cells(2).Value, dtgBooking.Rows(e.RowIndex).Cells(1).Value)

            If Not IsNothing(clsExpTemp) Then
                With frmExportBookingMenu
                    .clsExportRecord = clsExpTemp
                    .PopulateUserInput(.clsExportRecord)
                End With
                ShowChildForm(frmExportBookingMenu)
            End If
        End If
    End Sub

    Private Sub FilterOptions_CheckedChanged(sender As Object, e As EventArgs) Handles optStatusOpen.CheckedChanged, optDate.CheckedChanged
        dtpFrom.Enabled = optDate.Checked
        dtpTo.Enabled = optDate.Checked

        PopulateTreeView()
    End Sub

    Private Sub LabelDate_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label2.Click, Label3.Click, Label4.Click
        optDate.Checked = True
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        PopulateTreeView()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        PopulateTreeView()
    End Sub

    Private Sub trvSelection_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles trvSelection.NodeMouseDoubleClick
        If Mid(e.Node.Name, 1, 6) = "ndeMst" Then
            Dim clsDB As New clsDBTrans

            With frmExportMasterBooking
                .clsExportMasterRecord = clsDB.CustomerServiceExportMasterSearch(Mid(e.Node.Text, 1, 7), CurrentUser._Company_Code)
                .PopulateUserInput(.clsExportMasterRecord)
            End With

            ShowChildForm(frmExportMasterBooking)
        End If
    End Sub
End Class