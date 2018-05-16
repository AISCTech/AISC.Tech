Public Class frmNewFrwdgDocs
    Public clsMBL As New clsFrwdgDocsMBL
    Public clsHBL As New clsFrwdgDocsHBL
    Public strToDo As String
    Public blCancel As Boolean

    Dim dvDataView As DataView

    Private Sub PopGrid()
        Dim objSelectedValue As IConvertible = TryCast(cboPreviewType.SelectedValue, IConvertible)
        Dim intStatus As New Integer
        Select Case CInt(objSelectedValue)
            Case 1
                intStatus = 1
            Case 2
                intStatus = 1
            Case 3
                intStatus = 1
            Case 4
                intStatus = 4
            Case Else
                Exit Sub
        End Select

        Dim cmdSQL As New MySql.Data.MySqlClient.MySqlCommand
        Dim adapterCV As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsConn As New DataSet

        Try
            With cnnDBMaster
                If .State <> ConnectionState.Open Then .Open()
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT ID, " & '0
                                    "BookingNo AS `Book`, " & '1
                                    "CONCAT(BookingPrefix, '-', BookingNo) AS `Booking No.`, " & '2
                                    "PrepDate AS `Prepared Date`, " & '3
                                    "ConsignorName AS `Consignor/Debtor`, " & '4
                                    "ShipperName AS `Shipper`, " & '5
                                    "ConsigneeName AS `Consignee`, " & '6
                                    "Status_Name AS `Status` " & '7
                                "FROM " &
                                    "v_exportbookingheader " &
                                "WHERE " &
                                    "StatusID = @StatusID AND " &
                                    "CompanyCode = @CompanyCode " &
                                "ORDER BY " &
                                    "PrepDate"

            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", CurrentUser._Company_Code)
                .AddWithValue("@StatusID", intStatus)
            End With

            adapterCV.SelectCommand = cmdSQL
            adapterCV.Fill(dsConn)

            adapterCV.Dispose()
            cmdSQL.Dispose()
            cnnDBMaster.Close()

            dvDataView = dsConn.Tables(0).DefaultView
            dtgBookings.DataSource = dvDataView

            dtgBookings.Columns(0).Frozen = True
            dtgBookings.Columns(1).Frozen = True
            dtgBookings.Columns(2).Frozen = True

            dtgBookings.Columns(0).Visible = False
            dtgBookings.Columns(1).Visible = False
            dtgBookings.Columns(2).Width = 125
            dtgBookings.Columns(3).Width = 125
            dtgBookings.Columns(4).Width = 200
            dtgBookings.Columns(5).Width = 200
            dtgBookings.Columns(6).Width = 200
            dtgBookings.Columns(7).Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmNewFrwdgDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clsCombo As New clsPopulateComboBox(cboPreviewType, "SELECT ID, PreviewTypeName FROM lib_frwdg_docs_preview_type ORDER BY ID", "PreviewTypeName", "ID")
        clsCombo.PopComboBox()

        blCancel = True
    End Sub

    Private Sub cboPreviewType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPreviewType.SelectedIndexChanged
        PopGrid()
    End Sub

    Private Sub dtgBookings_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBookings.CellContentClick

    End Sub

    Private Sub dtgBookings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgBookings.CellDoubleClick
        If strToDo = "New" Then
            Dim clsBooking As New clsExportBookingHeader
            Dim clsMaster As New clsExportMasterBooking
            Dim clsClient As New clsClientHeader
            Dim clsDB As New clsDBTrans
            Dim lstString As List(Of String)

            clsBooking = clsDB.CustomerServiceExportBookingSearch(dtgBookings.Rows(e.RowIndex).Cells(1).Value, CurrentUser._Company_Code)
            clsMaster = clsDB.CustomerServiceExportMasterSearch(clsBooking._MasterBookingDetails._RefNo, CurrentUser._Company_Code)
            '.clsExportMasterRecord = clsDB.CustomerServiceExportMasterSearch(dtgMasterBooking.Rows(e.RowIndex).Cells(2).Value, dtgMasterBooking.Rows(e.RowIndex).Cells(1).Value)
            With frmExportFrwdgDocs
                .ClearUserInput()
                .clsCurrentMBL = New clsFrwdgDocsMBL
                .clsCurrentHBL = New clsFrwdgDocsHBL
                .clsCurrentMBL._FreightTypeDetails._PK = 2 'Export
                .clsCurrentMBL._PreviewTypeDetails._ID = cboPreviewType.SelectedValue
                clsClient = clsDB.SearchClientRecord(clsBooking._ShipperDetails._Code)
                lstString = DivideString((clsClient._Description & " " & clsClient._Addr1 & " " & clsClient._CityDesc & "  " & clsClient._CountryDesc).ToUpper, 35)
                .txtModeOfTransport.Tag = clsBooking._ModeOfTransportDetails._PK
                .txtModeOfTransport.Text = clsBooking._ModeOfTransportDetails._Param_Desc
                Try
                    .txtShipper01.Text = lstString(0)
                    .txtShipper02.Text = lstString(1)
                    .txtShipper03.Text = lstString(2)
                    .txtShipper04.Text = lstString(3)
                    .txtShipper05.Text = lstString(4)
                    .txtShipper06.Text = lstString(5)
                Catch ex As Exception
                End Try
                clsClient = clsDB.SearchClientRecord(clsBooking._ConsigneeDetails._Code)
                lstString = DivideString((clsClient._Description & " " & clsClient._Addr1 & " " & clsClient._CityDesc & "  " & clsClient._CountryDesc).ToUpper, 35)
                Try
                    .txtConsignee01.Text = lstString(0)
                    .txtConsignee02.Text = lstString(1)
                    .txtConsignee03.Text = lstString(2)
                    .txtConsignee04.Text = lstString(3)
                    .txtConsignee05.Text = lstString(4)
                    .txtConsignee06.Text = lstString(5)
                Catch ex As Exception
                End Try

                .dtgContainer.Rows.Clear()
                For Each clsCont As clsExportMasterContainers In clsMaster._ListOfContainers
                    .dtgContainer.Rows.Add()
                    .dtgContainer.Rows(.dtgContainer.Rows.Count - 1).Cells(.colContNo.Name).Value = clsCont._ContainerNo
                    .dtgContainer.Rows(.dtgContainer.Rows.Count - 1).Cells(.colContSizeCode.Name).Value = ""
                    .dtgContainer.Rows(.dtgContainer.Rows.Count - 1).Cells(.colContSizeName.Name).Value = clsCont._ContainerSizeName
                Next

                clsBooking._OriginDetails = clsDB.SearchPort(clsBooking._OriginDetails._PK)
                .txtPlaceOfReceiptCode.Text = clsBooking._OriginDetails._UNLOCODE
                .txtPlaceOfReceiptName.Text = clsBooking._OriginDetails._Description
                .txtPortOfLoadingCode.Text = clsBooking._OriginDetails._UNLOCODE
                .txtPortOfLoadingName.Text = clsBooking._OriginDetails._Description

                clsMaster._DestinationDetails = clsDB.SearchPort(clsMaster._DestinationDetails._PK)
                .txtPlaceOfDeliveryCode.Text = clsMaster._DestinationDetails._UNLOCODE
                .txtPlaceOfDeliveryName.Text = clsMaster._DestinationDetails._Description
                .txtPortOfDischargeCode.Text = clsMaster._DestinationDetails._UNLOCODE
                .txtPortOfDischargeName.Text = clsMaster._DestinationDetails._Description

                .txtGrossWeight.Text = clsBooking._ActualGrossWeight
                .txtMeasurement.Text = clsBooking._ActualVolume

                If clsBooking._LoadTypeDetails._PK = 4 Then 'LCL
                    .txtQty.Text = clsBooking._NoOfPackage & " " & clsBooking._PackageUnitDetails._Param_Desc
                Else 'FCL
                    .txtQty.Text = ""

                    Dim strTempContDesc1 As String
                    Dim strTempContDesc2 As String
                    Select Case .txtQty.Text
                        Case "1 X 20 FT"
                            strTempContDesc1 = "ONE (20') CONTAINER"
                            strTempContDesc2 = "ONE TWENTY FOOTER CONTAINER ONLY."
                        Case "1 X 40 FT"
                            strTempContDesc1 = "ONE (40') CONTAINER"
                            strTempContDesc2 = "ONE FORTY FOOTER CONTAINER ONLY."
                        Case "1 X 20 FT HC"
                            strTempContDesc1 = "ONE (20') HC CONTAINER"
                            strTempContDesc2 = "ONE TWENTY FOOTER HC CONTAINER ONLY."
                        Case "1 X 40 FT HC"
                            strTempContDesc1 = "ONE (40') HC CONTAINER"
                            strTempContDesc2 = "ONE FORTY FOOTER HC CONTAINER ONLY."
                        Case Else
                            strTempContDesc1 = ""
                            strTempContDesc2 = ""
                    End Select

                    .txtDescription.Text = "SHIPPER'S LOAD, COUNT & SEALED" & vbNewLine &
                                            strTempContDesc1 & vbNewLine &
                                            "SAID TO CONTAIN:" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            "" & vbNewLine &
                                            strTempContDesc2 & vbNewLine &
                                            "CY/CY"
                End If

                If clsBooking._LoadTypeDetails._PK = 4 Then
                    .optLCL.Checked = True
                ElseIf clsBooking._LoadTypeDetails._PK = 5 Then
                    .optFCL.Checked = True
                Else
                    .optLCL.Checked = False
                    .optFCL.Checked = False
                End If
            End With
        End If

        Dim lvItem As New ListViewItem
        lvItem.Text = dtgBookings.Rows(e.RowIndex).Cells(2).Value
        lvItem.ToolTipText = lvItem.Text
        lvItem.SubItems.Add(dtgBookings.Rows(e.RowIndex).Cells(0).Value)
        frmExportFrwdgDocs.lstBookings.Items.Add(lvItem)

        Me.Close()
    End Sub
End Class