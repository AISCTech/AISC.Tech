Public Class frmBrkgMonitoring

    Dim dvDataView As DataView

    Private Sub PopGrid()
        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            Dim strSQl As String
            If optDate.Checked = True Then
                Dim dtFrom As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day, 0, 0, 0)
                Dim dtTo As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day, 0, 0, 0).AddDays(1)

                strSQl = "SELECT ID, " & '0
                                    "FreightTypeName AS `Type`, " & '1
                                    "BookNo AS `Booking No.`, " & '2
                                    "ConsignorName AS `Client`, " & '3
                                    "IF(StatusID > 0, StatTypeName, '-No Status-') AS `Status Type`, " & '4
                                    "IF(StatusID > 0, StatusName, '-No Status-') AS `Status`, " & '5
                                    "ModeOfTransportName AS `Mode Of Transport`, " & '6
                                    "LoadTypeName AS `Load Type`, " & '7
                                    "HBLNo AS `House BL`, " & '8
                                    "OriginName AS `Origin`, " & '9
                                    "FinalDestinationName AS `Destination`, " & '10
                                    "Commodity AS `Commodity`, " & '11
                                    "Volume AS `Volume`, " & '12
                                    "GrossWeight AS `Gross Weight`, " & '13
                                    "ActualVolume AS `Actual Volume`, " & '14
                                    "ActualGrossWeight AS `Actual Gross Weight`, " & '15
                                    "StatusID, " & '16
                                    "`Completed`, " & '17
                                    "`Cancelled` " & '18
                                "FROM " &
                                    "v_brkg_jo " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode AND " &
                                    "PrepDate BETWEEN @From AND @To " &
                                "ORDER BY " &
                                    "PrepDate"

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.CommandText = strSQl

                With cmdSQL.Parameters
                    .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                    .AddWithValue("@From", dtFrom)
                    .AddWithValue("@To", dtTo)
                End With
            Else
                strSQl = "SELECT ID, " & '0
                                    "FreightTypeName AS `Type`, " & '1
                                    "BookNo AS `Booking No.`, " & '2
                                    "ConsignorName AS `Client`, " & '3
                                    "IF(StatusID > 0, StatTypeName, '-No Status-') AS `Status Type`, " & '4
                                    "IF(StatusID > 0, StatusName, '-No Status-') AS `Status`, " & '5
                                    "ModeOfTransportName AS `Mode Of Transport`, " & '6
                                    "LoadTypeName AS `Load Type`, " & '7
                                    "HBLNo AS `House BL`, " & '8
                                    "OriginName AS `Origin`, " & '9
                                    "FinalDestinationName AS `Destination`, " & '10
                                    "Commodity AS `Commodity`, " & '11
                                    "Volume AS `Volume`, " & '12
                                    "GrossWeight AS `Gross Weight`, " & '13
                                    "ActualVolume AS `Actual Volume`, " & '14
                                    "ActualGrossWeight AS `Actual Gross Weight`, " & '15
                                    "StatusID " & '16
                                "FROM " &
                                    "v_brkg_jo " &
                                "WHERE " &
                                    "CompanyCode = @CompanyCode " &
                                "ORDER BY " &
                                    "PrepDate"

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.CommandText = strSQl

                With cmdSQL.Parameters
                    .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                End With
            End If



            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView

            With dtgBrkgMonitoring
                .DataSource = dvDataView

                If .ColumnCount > 0 Then
                    .Columns(0).Frozen = True
                    .Columns(1).Frozen = True
                    .Columns(2).Frozen = True

                    .Columns(0).Visible = False
                    .Columns(1).Width = 100
                    .Columns(2).Width = 125
                    .Columns(3).Width = 375
                    .Columns(4).Width = 200
                    .Columns(5).Width = 200
                    .Columns(6).Width = 125
                    .Columns(7).Width = 125
                    .Columns(8).Width = 175
                    .Columns(9).Width = 175
                    .Columns(10).Width = 175
                    .Columns(11).Width = 250
                    .Columns(12).Width = 100
                    .Columns(13).Width = 100
                    .Columns(14).Width = 100
                    .Columns(15).Width = 100
                    .Columns(16).Visible = False
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        SetStatusColor()
    End Sub

    Private Sub FilterGrid()
        If dtgBrkgMonitoring.ColumnCount > 0 Then
            Dim strTemp As String = "`StatusID` = -1"

            If chkNoStatus.Checked = True Then
                strTemp = strTemp & " OR `StatusID` = 0"
            End If
            If chkWithStatus.Checked = True Then
                strTemp = strTemp & " OR `StatusID` > 0"
            End If

            dvDataView.RowFilter = strTemp

            SetStatusColor()
        End If
    End Sub

    Private Sub SetStatusColor()
        For Each dtgRow As DataGridViewRow In dtgBrkgMonitoring.Rows
            If dtgRow.Cells(16).Value = 0 Then
                SetRowColor(dtgRow.Index, lblNoStatus.BackColor)
            Else
                SetRowColor(dtgRow.Index, lblWithStatus.BackColor)
            End If
        Next
    End Sub

    Private Sub SetRowColor(ByVal RowIndex As Integer, ByVal RowColor As Color)
        For Each dtgCol As DataGridViewColumn In dtgBrkgMonitoring.Columns
            dtgBrkgMonitoring.Rows(RowIndex).Cells(dtgCol.Index).Style.BackColor = RowColor
        Next
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

    Private Sub frmBrkgMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtServerDate As Date = GetServerDate()
        Dim dtToday As Date = New Date(dtServerDate.Year, dtServerDate.Month, dtServerDate.Day, 0, 0, 0)

        dtpFrom.Value = GetFirstDayOfWeek(dtToday)
        dtpTo.Value = GetLastDayOfWeek(dtToday)

        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub frmBrkgMonitoring_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        SetStatusColor()
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmBrkgMonitoring_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub optDate_CheckedChanged(sender As Object, e As EventArgs) Handles optDate.CheckedChanged
        If optDate.Checked = True Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
            PopGrid()
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
    End Sub

    Private Sub optShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles optShowAll.CheckedChanged
        If optShowAll.Checked = True Then
            PopGrid()
        End If
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        If optDate.Checked = True Then PopGrid()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        If optDate.Checked = True Then PopGrid()
    End Sub

    Private Sub chkNoStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoStatus.CheckedChanged
        FilterGrid()
    End Sub

    Private Sub chkCompleted_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompleted.CheckedChanged
        FilterGrid()
    End Sub

    Private Sub chkWithStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkWithStatus.CheckedChanged
        FilterGrid()
    End Sub
End Class