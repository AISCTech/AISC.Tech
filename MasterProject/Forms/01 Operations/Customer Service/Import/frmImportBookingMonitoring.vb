Imports MasterProject

Public Class frmImportBookingMonitoring
    Implements ICommonFunction

    Dim dvDataView As DataView

    Public Sub NewRecord() Implements ICommonFunction.NewRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord

    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        Dim dtServerDate As Date = GetServerDate()
        Dim dtToday As Date = New Date(dtServerDate.Year, dtServerDate.Month, dtServerDate.Day, 0, 0, 0)

        dtFrom.Value = GetFirstDayOfWeek(dtToday)
        dtTo.Value = GetLastDayOfWeek(dtToday)

        ChangeEnabledButtons(False, False, False, True, False, False, False, False, False)
        PopGrid()
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

    Private Sub PopGrid()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID, " &
                                    "BookingNo AS `Book`, " &
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " &
                                    "PrepDate AS `Prepared Date`, " &
                                    "HouseBL AS `House BL`, " &
                                    "ConsignorName AS `Consignor/Debtor`, " &
                                    "ShipperName AS `Shipper`, " &
                                    "ConsigneeName AS `Consignee`, " &
                                    "ForwarderName AS `Forwarder`, " &
                                    "OriginPortName AS `Origin`, " &
                                    "DestinationPortName AS `Destination`, " &
                                    "Status_Name AS `Status` " &
                                "FROM " &
                                    "v_importbookingheader " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "PrepDate BETWEEN @DateFrom AND @DateTo " &
                                "ORDER BY " &
                                    "PrepDate"
            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                .AddWithValue("@DateFrom", dtFrom.Value)
                .AddWithValue("@DateTo", dtTo.Value)
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView
            dtgImportBooking.DataSource = dvDataView

            dtgImportBooking.Columns(0).Frozen = True
            dtgImportBooking.Columns(1).Frozen = True
            dtgImportBooking.Columns(2).Frozen = True

            dtgImportBooking.Columns(0).Visible = False
            dtgImportBooking.Columns(1).Visible = False
            dtgImportBooking.Columns(2).Width = 125
            dtgImportBooking.Columns(3).Width = 125
            dtgImportBooking.Columns(4).Width = 150
            dtgImportBooking.Columns(5).Width = 200
            dtgImportBooking.Columns(6).Width = 200
            dtgImportBooking.Columns(7).Width = 200
            dtgImportBooking.Columns(8).Width = 200
            dtgImportBooking.Columns(9).Width = 125
            dtgImportBooking.Columns(10).Width = 125
            dtgImportBooking.Columns(11).Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blPost As Boolean, ByVal blCancel As Boolean,
                                     ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .PostEnabled = blPost
            .CancelEnabled = blCancel

            .UpdateEnabledButtons()
        End With
    End Sub

    Private Sub frmImportBookingMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmImportBookingMonitoring_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmImportBookingMonitoring_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        dtgImportBooking.DataSource = Nothing
    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs) Handles dtTo.ValueChanged
        dtgImportBooking.DataSource = Nothing
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        PopGrid()
    End Sub

    Private Sub dtgImportBooking_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgImportBooking.CellContentClick

    End Sub

    Private Sub dtgImportBooking_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgImportBooking.CellDoubleClick
        Dim clsImpTemp As New clsImportBookingHeader
        Dim clsDBTemp As New clsDBTrans
        clsImpTemp = clsDBTemp.SearchImportBookingRecord(dtgImportBooking.Rows(e.RowIndex).Cells(1).Value, CurrentUser._Company_Code)

        If Not IsNothing(clsImpTemp) Then
            frmImportBookingMenu.PopulateBooking(clsImpTemp)
            ShowChildForm(frmImportBookingMenu)
        End If
    End Sub
End Class