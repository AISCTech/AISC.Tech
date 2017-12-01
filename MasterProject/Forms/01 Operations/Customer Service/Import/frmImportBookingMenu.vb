Public Class frmImportBookingMenu

    Implements ICommonFunction

    Private EnableButtons As New clsEnableToolstripObjects()
    Public lngBookingID As Long

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Create new record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            ClearUserInput()
            txtSite.Tag = CurrentUser._Site_Code
            txtSite.Text = CurrentUser._Site_Name
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
        End If
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckRequiredEntries() = True Then
            Dim clsTempBookHead As New clsImportBookingHeader
            Dim clsTempService As New clsImportBookingServices
            Dim clsTempContainer As New clsImportBookingContainers
            Dim clsSaveImpBook = New clsDBImportBooking
            Dim dtNow As Date = GetServerDate()

            With clsTempBookHead
                ._ID = lngBookingID
                ._BookingNo = txtBookingNo.Text
                ._BookingPrefix = GenerateBookingPrefix()
                ._HouseBL = txtHouseBL.Text
                ._CompanyCode = CurrentUser._Company_Code
                ._SiteCode = txtSite.Tag
                ._ShipperCode = txtShipper.Tag
                ._ConsigneeCode = txtConsignee.Tag
                ._ConsignorCode = txtConsignor.Tag
                ._ForwarderCode = txtForwarder.Tag
                ._ShippingLineCode = cboShippingLine.SelectedValue
                ._DescriptionOfGoods = txtDescriptionOfGoods.Text
                ._Weight = txtWeight.Text
                ._Volume = txtVolume.Text
                ._NoOfPackage = txtNoOfPackage.Text
                ._PackageUnitID = cboUnitOfMeasure.SelectedValue
                ._OriginPortID = cboOrigin.SelectedValue
                ._DestinationPortID = cboDestination.SelectedValue
                If IsDate(txtETA.Text) Then
                    ._ETA = CDate(txtETA.Text)
                Else
                    ._ETA = Nothing
                End If
                If IsDate(txtATA.Text) Then
                    ._ATA = CDate(txtATA.Text)
                Else
                    ._ATA = Nothing
                End If
                ._VesselID = cboVessel.SelectedValue
                ._Voyage = txtVoyage.Text
                ._DocsCompleted = True
                ._DocsCompletedDate = dtNow
                ._ImportPermitNo = txtImportPermitNo.Text
                ._InvoiceNo = txtInvoiceNo.Text
                ._RegistryNo = txtRegistryNo.Text
                ._Remarks = txtRemarks.Text
                ._ModeOfTrasnsportID = cboModeOfTransport.SelectedValue
                ._LoadTypeID = cboLoadType.SelectedValue
                ._EntryTypeID = cboEntryType.SelectedValue
                ._FreightTermsID = cboFreightType.SelectedValue
                ._AccountHolderID = 1
                ._PrepByID = CurrentUser._User_ID
                ._PrepDate = dtNow
                ._ModByID = CurrentUser._User_ID
                ._ModDate = dtNow
            End With

            For Each dtgRow As DataGridViewRow In dtgServices.Rows
                If dtgRow.Cells(colSSelected.Name).Value = True Then
                    clsTempService = New clsImportBookingServices
                    With clsTempService
                        ._ServiceID = dtgRow.Cells(colSPK.Name).Value
                    End With

                    clsTempBookHead._ServiceDetails.Add(clsTempService)
                End If
            Next

            For Each dtgRow As DataGridViewRow In dtgContainer.Rows
                clsTempContainer = New clsImportBookingContainers
                With clsTempContainer
                    ._ContainerID = dtgRow.Cells(colCContainerID.Name).Value
                    If IsDate(dtgRow.Cells(colCPickUpDate.Name).Value) Then
                        ._PickupDate = dtgRow.Cells(colCPickUpDate.Name).Value
                    Else
                        ._PickupDate = Nothing
                    End If
                    If IsDate(dtgRow.Cells(colCDeliveryDate.Name).Value) Then
                        ._DeliveryDate = dtgRow.Cells(colCDeliveryDate.Name).Value
                    Else
                        ._DeliveryDate = Nothing
                    End If
                End With
                clsTempBookHead._ContainerDetails.Add(clsTempContainer)
            Next

            clsSaveImpBook.SaveRecord(clsTempBookHead)
            PopulateBooking(clsSaveImpBook._ImportBookingRecord)
        End If
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord


        Dim clsComboBox As New clsPopulateComboBox(cboShippingLine, "SELECT * FROM v_vendortype WHERE Params_Code = 2 ORDER BY `Description`", "Description", "Code")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboModeOfTransport, "SELECT * FROM lib_params WHERE Param_Type = 4 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboLoadType, "SELECT * FROM lib_params WHERE Param_Type = 2 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboUnitOfMeasure, "SELECT * FROM lib_params WHERE Param_Type = 5 ORDER BY `Param_Desc`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboOrigin, "SELECT * FROM lib_port ORDER BY `Description`", "Description", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboDestination, "SELECT * FROM lib_port ORDER BY `Description`", "Description", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboVessel, "SELECT * FROM lib_vessel ORDER BY `VesselName`", "VesselName", "ID")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboEntryType, "SELECT * FROM lib_params WHERE Param_Type = 13 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        clsComboBox = New clsPopulateComboBox(cboFreightType, "SELECT * FROM lib_params WHERE Param_Type = 3 ORDER BY `PK`", "Param_Desc", "PK")
        clsComboBox.PopComboBox()

        PopulateServices()

        If lngBookingID < 1 Then
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        Else
            Dim clsTemp As New clsImportBookingHeader
            clsTemp.SearchRecord(txtBookingNo.Text, CurrentUser._Company_Code)
            PopulateBooking(clsTemp)
        End If
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        frmSearchImportBooking.ShowDialog()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Private Function CheckRequiredEntries() As Boolean
        CheckRequiredEntries = True

        dtgServices.EndEdit()
        dtgContainer.EndEdit()
        dtgDocuments.EndEdit()
    End Function

    Public Sub PopulateBooking(ByVal clsImpBook As clsImportBookingHeader)
        ClearUserInput()
        lngBookingID = clsImpBook._ID
        txtBookingPrefix.Text = clsImpBook._BookingPrefix
        txtBookingNo.Text = clsImpBook._BookingNo
        txtHouseBL.Text = clsImpBook._HouseBL
        txtSite.Tag = clsImpBook._SiteCode
        txtSite.Text = clsImpBook._SiteName
        txtShipper.Tag = clsImpBook._ShipperCode
        txtShipper.Text = clsImpBook._ShipperName
        txtShipperAddress.Text = clsImpBook._ShipperAddress
        txtConsignee.Tag = clsImpBook._ConsigneeCode
        txtConsignee.Text = clsImpBook._ConsigneeName
        txtConsigneeAddress.Text = clsImpBook._ConsigneeAddress
        txtConsignor.Tag = clsImpBook._ConsignorCode
        txtConsignor.Text = clsImpBook._ConsignorName
        txtConsignorAddress.Text = clsImpBook._ConsignorAddress
        txtForwarder.Tag = clsImpBook._ForwarderCode
        txtForwarder.Text = clsImpBook._ForwarderName
        txtForwarderAddress.Text = clsImpBook._ForwarderAddress
        cboShippingLine.SelectedValue = clsImpBook._ShippingLineCode
        txtDescriptionOfGoods.Text = clsImpBook._DescriptionOfGoods
        txtWeight.Text = clsImpBook._Weight
        txtVolume.Text = clsImpBook._Volume
        txtNoOfPackage.Text = clsImpBook._NoOfPackage
        cboUnitOfMeasure.SelectedValue = clsImpBook._PackageUnitID
        cboOrigin.SelectedValue = clsImpBook._OriginPortID
        txtOriginCountry.Text = clsImpBook._OriginCountryName
        cboDestination.SelectedValue = clsImpBook._DestinationPortID
        txtDestinationCountry.Text = clsImpBook._DestinationCountryName
        If clsImpBook._ETA = Nothing Then
            txtETA.Text = ""
        Else
            txtETA.Text = clsImpBook._ETA
        End If
        If clsImpBook._ATA = Nothing Then
            txtATA.Text = ""
        Else
            txtATA.Text = clsImpBook._ATA
        End If
        cboVessel.SelectedValue = clsImpBook._VesselID
        txtVoyage.Text = clsImpBook._Voyage
        'DocsCompleted
        'DocsCompletedDate
        txtImportPermitNo.Text = clsImpBook._ImportPermitNo
        txtInvoiceNo.Text = clsImpBook._InvoiceNo
        txtRegistryNo.Text = clsImpBook._RegistryNo
        txtRemarks.Text = clsImpBook._Remarks
        cboModeOfTransport.SelectedValue = clsImpBook._ModeOfTrasnsportID
        cboLoadType.SelectedValue = clsImpBook._LoadTypeID
        cboEntryType.SelectedValue = clsImpBook._EntryTypeID
        cboFreightType.SelectedValue = clsImpBook._FreightTermsID
        tslblPrepBy.Text = clsImpBook._PrepByFullName
        tslblPrepDate.Text = clsImpBook._PrepDate
        tslblModBy.Text = clsImpBook._ModByFullName
        tslblModDate.Text = clsImpBook._ModDate

        For Each clsTemp As clsImportBookingServices In clsImpBook._ServiceDetails
            For Each dtgTemp As DataGridViewRow In dtgServices.Rows
                If clsTemp._ServiceID = dtgTemp.Cells(colSPK.Name).Value Then
                    dtgTemp.Cells(colSSelected.Name).Value = True
                    Exit For
                End If
            Next
        Next

        For Each clsTemp As clsImportBookingContainers In clsImpBook._ContainerDetails
            dtgContainer.Rows.Add()
            With dtgContainer.Rows(dtgContainer.Rows.Count - 1)
                .Cells(colCPK.Name).Value = clsTemp._ID
                .Cells(colCContainerID.Name).Value = clsTemp._ContainerID
                .Cells(colCContainerNo.Name).Value = clsTemp._ContainerNo
                .Cells(colCContainerSizeID.Name).Value = clsTemp._ContainerSizeID
                .Cells(colCContainerSizeName.Name).Value = clsTemp._ContainerSizeName
                If clsTemp._PickupDate = Nothing Then
                    .Cells(colCPickUpDate.Name).Value = "TBA"
                Else
                    .Cells(colCPickUpDate.Name).Value = clsTemp._PickupDate
                End If
                If clsTemp._DeliveryDate = Nothing Then
                    .Cells(colCDeliveryDate.Name).Value = "TBA"
                Else
                    .Cells(colCDeliveryDate.Name).Value = clsTemp._DeliveryDate
                End If
            End With
        Next

        ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False)
    End Sub

    Private Function GenerateBookingPrefix() As String
        Dim strTemp As String = ""
        GenerateBookingPrefix = ""
        Try
            'Site/Location
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT BookPrefix From tbl_dbsitename WHERE Site_Code = @Site_Code"
            cmdSQL.Parameters.AddWithValue("@Site_Code", txtSite.Tag)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            While reader.Read
                strTemp = reader.Item("BookPrefix")
            End While

            reader.Close()
            cmdSQL.Dispose()

            'Service Type
            For Each dtgRow As DataGridViewRow In dtgServices.Rows
                If dtgRow.Cells(colSPK.Name).Value = 27 And dtgRow.Cells(colSSelected.Name).Value = True Then
                    Select Case cboModeOfTransport.Text
                        Case "Air"
                            strTemp = strTemp & "A" & dtgRow.Cells(colSPrefix.Name).Value
                        Case "Sea"
                            strTemp = strTemp & "S" & dtgRow.Cells(colSPrefix.Name).Value
                    End Select
                    GoTo lnAccountType
                ElseIf dtgRow.Cells(colSSelected.Name).Value = True Then
                    strTemp = strTemp & dtgRow.Cells(colSPrefix.Name).Value
                    GoTo lnAccountType
                End If
            Next

lnAccountType:
            'Account Type

            GenerateBookingPrefix = strTemp
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function GetContainerSizes() As String
        GetContainerSizes = ""
        Dim strTemp As String = ""


    End Function

    Public Sub ClearUserInput()
        lngBookingID = -1
        txtBookingNo.Text = ""
        txtHouseBL.Text = ""
        txtShipper.Tag = ""
        txtShipper.Text = ""
        txtShipperAddress.Text = ""
        txtConsignee.Tag = ""
        txtConsignee.Text = ""
        txtConsigneeAddress.Text = ""
        txtConsignor.Tag = ""
        txtConsignor.Text = ""
        txtConsignorAddress.Text = ""
        txtForwarder.Tag = ""
        txtForwarder.Text = ""
        txtForwarderAddress.Text = ""
        cboShippingLine.SelectedIndex = -1
        cboModeOfTransport.SelectedIndex = -1
        cboLoadType.SelectedIndex = -1
        txtDescriptionOfGoods.Text = ""
        txtWeight.Text = ""
        txtVolume.Text = ""
        txtAccountHolder.Text = ""
        For Each dtgRow As DataGridViewRow In dtgServices.Rows
            dtgRow.Cells(colSSelected.Name).Value = False
        Next
        txtSite.Tag = ""
        txtSite.Text = ""

        txtNoOfPackage.Text = ""
        cboUnitOfMeasure.SelectedIndex = -1
        cboOrigin.SelectedIndex = -1
        txtOriginCountry.Text = ""
        cboDestination.SelectedIndex = -1
        txtDestinationCountry.Text = ""
        dtETA.Value = Now
        txtETA.Text = ""
        dtATA.Value = Now
        txtATA.Text = ""
        cboVessel.SelectedIndex = -1
        txtVoyage.Text = ""
        txtImportPermitNo.Text = ""
        txtInvoiceNo.Text = ""
        txtRegistryNo.Text = ""
        cboEntryType.SelectedIndex = -1
        cboFreightType.SelectedIndex = -1
        txtRemarks.Text = ""
        txtStatus.Text = ""
        dtgContainer.Rows.Clear()
        tslblContainerSizes.Text = ""
        dtgDocuments.Rows.Clear()
    End Sub

    Public Sub PopulateServices()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT PK, Param_Type, Param_Code, Param_Value, Param_Desc " &
                        "FROM lib_params " &
                        "WHERE Param_Type = 10 " &
                            "AND Param_Code LIKE 'SIMP%' " &
                        "ORDER BY PK"

            dtgServices.Rows.Clear()

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                dtgServices.Rows.Add()
                With dtgServices.Rows(dtgServices.Rows.Count - 1)
                    .Cells(colSPK.Name).Value = reader.Item("PK")
                    .Cells(colSParam_Type.Name).Value = reader.Item("Param_Type")
                    .Cells(colSParam_Code.Name).Value = reader.Item("Param_Code")
                    .Cells(colSPrefix.Name).Value = reader.Item("Param_Value")
                    .Cells(colSParam_Desc.Name).Value = reader.Item("Param_Desc")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetClientAddress(ByVal strClientCode As String) As String
        GetClientAddress = ""

        Try
            Dim strTemp As String
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT Addr1, CityDesc, CountryDesc FROM v_client WHERE Code = @Code"
            cmdSQL.Parameters.AddWithValue("@Code", strClientCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                strTemp = Trim(CStr(reader.Item("Addr1") & " " & reader.Item("CityDesc") & " " & reader.Item("CountryDesc")).ToUpper)
                GetClientAddress = System.Text.RegularExpressions.Regex.Replace(strTemp, "\s{2,}", " ")
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function GetPortCountry(ByVal lngPortCode As Long) As String
        GetPortCountry = ""

        Try
            Dim strTemp As String
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT CountryDesc FROM v_origdestport WHERE PK = @PK"
            cmdSQL.Parameters.AddWithValue("@PK", lngPortCode)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                strTemp = Trim(CStr(reader.Item("CountryDesc")).ToUpper)
                GetPortCountry = System.Text.RegularExpressions.Regex.Replace(strTemp, "\s{2,}", " ")
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

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

        txtHouseBL.ReadOnly = Not blUserInput
        cmdSelectShipper.Enabled = blUserInput
        cmdSelectConsignee.Enabled = blUserInput
        cmdSelectConsignor.Enabled = blUserInput
        cmdSelectForwader.Enabled = blUserInput
        dtgServices.ReadOnly = Not blUserInput
        txtDescriptionOfGoods.ReadOnly = Not blUserInput
        txtRemarks.ReadOnly = Not blUserInput
        cboShippingLine.Enabled = blUserInput
        cboModeOfTransport.Enabled = blUserInput
        cboLoadType.Enabled = blUserInput
        cboLoadType.Enabled = blUserInput
        txtWeight.ReadOnly = Not blUserInput
        txtVolume.ReadOnly = Not blUserInput
        txtNoOfPackage.ReadOnly = Not blUserInput
        cboUnitOfMeasure.Enabled = blUserInput
        cboOrigin.Enabled = blUserInput
        cboDestination.Enabled = blUserInput
        txtETA.ReadOnly = Not blUserInput
        dtETA.Enabled = blUserInput
        txtATA.ReadOnly = Not blUserInput
        dtATA.Enabled = blUserInput
        cboVessel.Enabled = blUserInput
        txtVoyage.ReadOnly = Not blUserInput
        txtImportPermitNo.ReadOnly = Not blUserInput
        txtInvoiceNo.ReadOnly = Not blUserInput
        txtRegistryNo.ReadOnly = Not blUserInput
        cboEntryType.Enabled = blUserInput
        cboFreightType.Enabled = blUserInput
        tscmdContainerAdd.Enabled = blUserInput
        tscmdContainerRemove.Enabled = blUserInput
    End Sub

    Private Sub frmImportBookingMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmImportBookingMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub frmImportBookingMenu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub dtETA_ValueChanged(sender As Object, e As EventArgs) Handles dtETA.ValueChanged
        txtETA.Text = dtETA.Value.ToShortDateString
    End Sub

    Private Sub dtATA_ValueChanged(sender As Object, e As EventArgs) Handles dtATA.ValueChanged
        txtATA.Text = dtATA.Value.ToShortDateString
    End Sub

    Private Sub tscmdContainerAdd_Click(sender As Object, e As EventArgs) Handles tscmdContainerAdd.Click
        frmAddBookingContainer.strCaller = "ImpBook"
        frmAddBookingContainer.ShowDialog()
        tslblContainerSizes.Text = GetContainerSizes()
    End Sub

    Private Sub tscmdContainerRemove_Click(sender As Object, e As EventArgs) Handles tscmdContainerRemove.Click
        If Me.dtgContainer.Rows.Count > 0 Then
            dtgContainer.Rows.Remove(dtgContainer.CurrentRow)
        End If

        tslblContainerSizes.Text = GetContainerSizes()
    End Sub

    Private Sub cboOrigin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrigin.SelectedIndexChanged

    End Sub

    Private Sub cboDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDestination.SelectedIndexChanged

    End Sub

    Private Sub cboOrigin_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboOrigin.SelectionChangeCommitted
        txtOriginCountry.Text = GetPortCountry(cboOrigin.SelectedValue)
    End Sub

    Private Sub cboDestination_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDestination.SelectionChangeCommitted
        txtDestinationCountry.Text = GetPortCountry(Me.cboDestination.SelectedValue)
    End Sub

    Private Sub cmdSelectShipper_Click(sender As Object, e As EventArgs) Handles cmdSelectShipper.Click
        With frmSelection
            .Text = "Select Shipper"
            .PopulateGrid("SELECT Code, Description as `Shipper Name` FROM v_shipper ORDER BY `Shipper Name`", "`Shipper Name`", txtShipper)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtShipperAddress.Text = GetClientAddress(txtShipper.Tag)
    End Sub

    Private Sub cmdSelectConsignee_Click(sender As Object, e As EventArgs) Handles cmdSelectConsignee.Click
        With frmSelection
            .Text = "Select Consignee"
            .PopulateGrid("SELECT Code, Description as `Consignee Name` FROM v_consignee ORDER BY `Consignee Name`", "`Consignee Name`", txtConsignee)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtConsigneeAddress.Text = GetClientAddress(txtConsignee.Tag)
    End Sub

    Private Sub cmdSelectConsignor_Click(sender As Object, e As EventArgs) Handles cmdSelectConsignor.Click
        With frmSelection
            .Text = "Select Consignor/Debtor"
            .PopulateGrid("SELECT Code, Description as `Consignor Name` FROM tbl_client ORDER BY `Consignor Name`", "`Consignor Name`", txtConsignor)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtConsignorAddress.Text = GetClientAddress(txtConsignor.Tag)
    End Sub

    Private Sub cmdSelectForwader_Click(sender As Object, e As EventArgs) Handles cmdSelectForwader.Click
        With frmSelection
            .Text = "Select Forwarder"
            .PopulateGrid("SELECT Code, Description as `Forwarder Name` FROM v_forwarder ORDER BY `Forwarder Name`", "`Forwarder Name`", txtForwarder)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        txtForwarderAddress.Text = GetClientAddress(txtForwarder.Tag)
    End Sub

    Private Sub txtShipper_TextChanged(sender As Object, e As EventArgs) Handles txtShipper.TextChanged
        ToolTip1.SetToolTip(txtShipper, txtShipper.Text)
    End Sub

    Private Sub txtConsignee_TextChanged(sender As Object, e As EventArgs) Handles txtConsignee.TextChanged
        ToolTip1.SetToolTip(txtConsignee, txtConsignee.Text)
    End Sub

    Private Sub txtConsignor_TextChanged(sender As Object, e As EventArgs) Handles txtConsignor.TextChanged
        ToolTip1.SetToolTip(txtConsignor, txtConsignor.Text)
    End Sub

    Private Sub txtForwarder_TextChanged(sender As Object, e As EventArgs) Handles txtForwarder.TextChanged
        ToolTip1.SetToolTip(txtForwarder, txtForwarder.Text)
    End Sub
End Class