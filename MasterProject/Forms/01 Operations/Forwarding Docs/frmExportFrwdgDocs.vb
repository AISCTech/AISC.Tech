Imports MasterProject

Public Class frmExportFrwdgDocs
    Implements ICommonFunction

    Public clsCurrentMBL As New clsFrwdgDocsMBL
    Public clsCurrentHBL As New clsFrwdgDocsHBL

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        With frmNewFrwdgDocs
            .strToDo = "New"
            .ShowDialog()
        End With
        ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        'Dim clsCombo As New clsPopulateComboBox(cboShipper, "SELECT Code, Description FROM v_shipper ORDER BY Description", "Description", "Code")
        'clsCombo.PopComboBox()

        'clsCombo = New clsPopulateComboBox(cboConsignee, "SELECT Code, Description FROM v_consignee ORDER BY Description", "Description", "Code")
        'clsCombo.PopComboBox()

        'clsCombo = New clsPopulateComboBox(cboNotifyParty, "SELECT Code, Description FROM tbl_client ORDER BY Description", "Description", "Code")
        'clsCombo.PopComboBox()

        'clsCombo = New clsPopulateComboBox(cboAgent, "SELECT Code, Description FROM v_agent ORDER BY Description", "Description", "Code")
        'clsCombo.PopComboBox()

        'clsCombo = New clsPopulateComboBox(cboAgent, "SELECT Code, Description FROM v_agent ORDER BY Description", "Description", "Code")
        'clsCombo.PopComboBox()        

        If clsCurrentHBL._ID <= 0 Then
            clsCurrentMBL = New clsFrwdgDocsMBL
            clsCurrentHBL = New clsFrwdgDocsHBL
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        Else

        End If
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckRequiredEntries() = False Then
            Exit Sub
        End If

        Dim clsBookingTemp As New clsFrwdgDocsBooking
        Dim clsContTemp As New clsFrwdgDocsContainer
        Dim clsMarksTemp As New clsFrwdgDocsMarksAndNumbers
        Dim clsDescTemp As New clsFrwdgDocsDescription
        Dim clsCharges As New clsFrwdgDocsFreightAndCharge
        Dim clsBody As New clsFrwdgDocsBody

        If MsgBox("Save record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            Try
                With clsCurrentMBL
                    ._MBLNo = txtMBL.Text
                    ._CompanyCode = CurrentUser._Company_Code
                    If optLCL.Checked = True Then
                        ._CargoType = "L"
                    End If
                    If optFCL.Checked = True Then
                        ._CargoType = "F"
                    End If
                    ._PlaceOfReceiptCode = txtPlaceOfReceiptCode.Text
                    ._PlaceOfReceiptName = txtPlaceOfReceiptName.Text
                    ._VesselCode = ""
                    ._VesselName = txtVessel.Text
                    ._VOY = txtVoyage.Text
                    ._PortOfLoadingCode = txtPortOfLoadingCode.Text
                    ._PortOfLoadingName = txtPortOfLoadingName.Text
                    ._PortOfDischargeCode = txtPortOfDischargeCode.Text
                    ._PortOfDischargeName = txtPortOfDischargeName.Text
                    ._DevanDate = Format(dtpDevanning.Value, "yyyyMMdd")
                    ._ModeOfTransport._PK = txtModeOfTransport.Tag
                    ._RegistryNo = txtRegistryNo.Text
                    ._RegYear = txtRegistryYear.Text
                End With

                Dim clsDB As New clsDBTrans
                clsCurrentMBL = clsDB.ForwardingDocsMBLSave(clsCurrentMBL)

                With clsCurrentHBL
                    ._MBL._ID = clsCurrentMBL._ID
                    ._HBLNo = txtHBL.Text
                    ._DataDiv = "1"
                    ._ShipperName1 = txtShipper01.Text
                    ._ShipperName2 = txtShipper02.Text
                    ._ShipperName3 = txtShipper03.Text
                    ._ShipperName4 = txtShipper04.Text
                    ._ShipperName5 = txtShipper05.Text
                    ._ShipperName6 = txtShipper06.Text
                    ._ConsigneeName1 = txtConsignee01.Text
                    ._ConsigneeName2 = txtConsignee02.Text
                    ._ConsigneeName3 = txtConsignee03.Text
                    ._ConsigneeName4 = txtConsignee04.Text
                    ._ConsigneeName5 = txtConsignee05.Text
                    ._ConsigneeName6 = txtConsignee06.Text
                    ._NotifyPartyName1 = txtNotifyParty01.Text
                    ._NotifyPartyName2 = txtNotifyParty02.Text
                    ._NotifyPartyName3 = txtNotifyParty03.Text
                    ._NotifyPartyName4 = txtNotifyParty04.Text
                    ._NotifyPartyName5 = txtNotifyParty05.Text
                    ._NotifyPartyName6 = txtNotifyParty06.Text
                    ._NotifyPartyName1 = txtAgent01.Text
                    ._NotifyPartyName2 = txtAgent02.Text
                    ._NotifyPartyName3 = txtAgent03.Text
                    ._NotifyPartyName4 = txtAgent04.Text
                    ._NotifyPartyName5 = txtAgent05.Text
                    ._NotifyPartyName6 = txtAgent06.Text
                    If optSendDIV01.Checked = True Then
                        ._SendDiv = "1"
                    End If
                    If optSendDIV02.Checked = True Then
                        ._SendDiv = "2"
                    End If
                    ._PlaceOfDeliveryCode = txtPlaceOfDeliveryCode.Text
                    ._PlaceOfDeliveryName = txtPlaceOfDeliveryName.Text
                    ._FinalDestinationCode = txtFinalDestinationCode.Text
                    ._FinalDestinationName = txtFinalDestinationName.Text
                    If optPrepaid.Checked = True Then
                        ._Freight = "P"
                    End If
                    If optCollect.Checked = True Then
                        ._Freight = "C"
                    End If
                End With

                clsCurrentHBL._BookingDetails.Clear()
                For Each item As ListViewItem In lstBookings.Items
                    clsBookingTemp = New clsFrwdgDocsBooking
                    clsBookingTemp._BookingID = item.SubItems.Item(1).Text
                    clsCurrentHBL._BookingDetails.Add(clsBookingTemp)
                Next

                clsCurrentHBL._ContainerDetails.Clear()
                For Each dtgRows As DataGridViewRow In dtgContainer.Rows
                    clsContTemp = New clsFrwdgDocsContainer
                    With clsContTemp
                        ._DataDiv = "2"  'default value for ntl edi
                        ._ItemLines = dtgRows.Index
                        If InStr(dtgRows.Cells(colContSizeName.Name).Value, "10") > 0 Then
                            ._ContainerSize = "1"
                        ElseIf InStr(dtgRows.Cells(colContSizeName.Name).Value, "20") > 0 Then
                            ._ContainerSize = "2"
                        ElseIf InStr(dtgRows.Cells(colContSizeName.Name).Value, "30") > 0 Then
                            ._ContainerSize = "3"
                        ElseIf InStr(dtgRows.Cells(colContSizeName.Name).Value, "40") > 0 Then
                            ._ContainerSize = "4"
                        Else
                            ._ContainerSize = "9"
                        End If
                        ._ContainerType = ""
                        ._ContainerNumber = dtgRows.Cells(colContNo.Name).Value
                    End With
                    clsCurrentHBL._ContainerDetails.Add(clsContTemp)
                Next

                Dim tempArray1() As String
                Dim tempArray2() As String
                tempArray1 = txtMarksAndNos.Lines
                clsCurrentHBL._MarksAndNumbersDetails.Clear()
                For intCtr As Integer = 0 To tempArray1.Length - 1
                    clsMarksTemp = New clsFrwdgDocsMarksAndNumbers
                    With clsMarksTemp
                        ._DataDiv = "3"  'default value for ntl edi
                        ._ItemLines = intCtr + 1
                        ._MarksAndNumbers = tempArray1(intCtr)
                    End With
                    clsCurrentHBL._MarksAndNumbersDetails.Add(clsMarksTemp)
                Next

                tempArray1 = txtDescription.Lines
                clsCurrentHBL._DescriptionDetails.Clear()
                For intCtr As Integer = 0 To tempArray1.Length - 1
                    clsDescTemp = New clsFrwdgDocsDescription
                    With clsDescTemp
                        ._DataDiv = "4"  'default value for ntl edi
                        ._ItemLines = intCtr + 1
                        ._DescriptionOfGoods = tempArray1(intCtr)
                    End With
                    clsCurrentHBL._DescriptionDetails.Add(clsDescTemp)
                Next

                tempArray1 = txtFreightCharges.Lines
                clsCurrentHBL._FreightChargeDetails.Clear()
                For intCtr As Integer = 0 To tempArray1.Length - 1
                    clsCharges = New clsFrwdgDocsFreightAndCharge
                    With clsCharges
                        ._DataDiv = "5"  'default value for ntl edi
                        ._ItemLines = intCtr + 1
                        ._ChargeName = tempArray1(intCtr)
                    End With
                    clsCurrentHBL._FreightChargeDetails.Add(clsCharges)
                Next

                Dim intTemp As Integer
                tempArray1 = txtMarksAndNos.Lines
                tempArray2 = txtDescription.Lines

                If tempArray1.Length > tempArray2.Length Then
                    intTemp = tempArray1.Length
                Else
                    intTemp = tempArray2.Length
                End If

                clsCurrentHBL._BodyDetails.Clear()
                For intCtr As Integer = 0 To intTemp - 1
                    clsBody = New clsFrwdgDocsBody
                    With clsBody
                        ._DataDiv = "6"  'default value for ntl edi
                        ._ItemLines = intCtr + 1
                        If intCtr <= tempArray1.Length - 1 Then
                            ._MarksAndNumbers = tempArray1(intCtr)
                        End If
                        If intCtr <= tempArray2.Length - 1 Then
                            ._DescriptionOfGoods = tempArray2(intCtr)
                        End If
                    End With
                    clsCurrentHBL._BodyDetails.Add(clsBody)
                Next

                clsCurrentHBL = clsDB.ForwardingDocsHBLSave(clsCurrentHBL)

                ChangeEnabledButtons(True, True, False, True, False, True, True, True, True, False)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "System Message")
            End Try
        End If
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        With frmSearchBL
            .ShowDialog()
        End With
    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
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

        txtMBL.ReadOnly = Not blUserInput
        optLCL.Enabled = blUserInput
        optFCL.Enabled = blUserInput
        lblPlaceOfReceipt.Enabled = blUserInput
        txtVessel.ReadOnly = Not blUserInput
        txtVoyage.ReadOnly = Not blUserInput
        lblPortOfLoading.Enabled = blUserInput
        lblPortOfDischarge.Enabled = blUserInput
        txtDevaning.ReadOnly = Not blUserInput
        dtpDevanning.Enabled = blUserInput
        txtRegistryNo.ReadOnly = Not blUserInput
        txtRegistryYear.ReadOnly = Not blUserInput

        txtHBL.ReadOnly = Not blUserInput
        lblHBL.Enabled = Not blUserInput
        lblShipper.Enabled = blUserInput
        txtShipper01.ReadOnly = Not blUserInput
        txtShipper02.ReadOnly = Not blUserInput
        txtShipper03.ReadOnly = Not blUserInput
        txtShipper04.ReadOnly = Not blUserInput
        txtShipper05.ReadOnly = Not blUserInput
        txtShipper06.ReadOnly = Not blUserInput
        lblConsignee.Enabled = blUserInput
        txtConsignee01.ReadOnly = Not blUserInput
        txtConsignee02.ReadOnly = Not blUserInput
        txtConsignee03.ReadOnly = Not blUserInput
        txtConsignee04.ReadOnly = Not blUserInput
        txtConsignee05.ReadOnly = Not blUserInput
        txtConsignee06.ReadOnly = Not blUserInput
        lblNotifyParty.Enabled = blUserInput
        txtNotifyParty01.ReadOnly = Not blUserInput
        txtNotifyParty02.ReadOnly = Not blUserInput
        txtNotifyParty03.ReadOnly = Not blUserInput
        txtNotifyParty04.ReadOnly = Not blUserInput
        txtNotifyParty05.ReadOnly = Not blUserInput
        txtNotifyParty06.ReadOnly = Not blUserInput
        lblAgent.Enabled = blUserInput
        txtAgent01.ReadOnly = Not blUserInput
        txtAgent02.ReadOnly = Not blUserInput
        txtAgent03.ReadOnly = Not blUserInput
        txtAgent04.ReadOnly = Not blUserInput
        txtAgent05.ReadOnly = Not blUserInput
        txtAgent06.ReadOnly = Not blUserInput
        txtMarksAndNos.ReadOnly = Not blUserInput
        txtDescription.ReadOnly = Not blUserInput
        txtFreightCharges.ReadOnly = Not blUserInput
        lblPlaceOfDelivery.Enabled = blUserInput
        lblFinalDestination.Enabled = blUserInput
        optCollect.Enabled = blUserInput
        optPrepaid.Enabled = blUserInput
        optSendDIV01.Enabled = blUserInput
        optSendDIV02.Enabled = blUserInput
        tscmdContainerAdd.Enabled = blUserInput
        tscmdContainerRemove.Enabled = blUserInput
        tscmdBookAdd.Enabled = blUserInput
        tscmdBookRemove.Enabled = blUserInput
        txtQty.ReadOnly = Not blUserInput
        txtExRate.Enabled = blUserInput
    End Sub

    Private Function CheckRequiredEntries() As Boolean
        If Len(Trim(txtMBL.Text)) = 0 Then
            MsgBox("Please enter MBL!", MsgBoxStyle.Exclamation, "System Message")
            Return False
        End If

        If optLCL.Checked = False And optFCL.Checked = False Then
            MsgBox("Please select Cargo Type!", MsgBoxStyle.Exclamation, "System Message")
            Return False
        End If

        If Len(Trim(txtHBL.Text)) = 0 Then
            MsgBox("Please enter HBL!", MsgBoxStyle.Exclamation, "System Message")
            Return False
        End If

        If optSendDIV01.Checked = False And optSendDIV02.Checked = False Then
            MsgBox("Please select Send DIV!", MsgBoxStyle.Exclamation, "System Message")
            Return False
        End If
        Return True
    End Function

    Public Sub ClearUserInput()
        Try
            txtMBL.Text = ""
            optFCL.Checked = False
            optLCL.Checked = False
            txtPlaceOfReceiptCode.Text = ""
            txtPlaceOfReceiptName.Text = ""
            txtVessel.Text = ""
            txtVoyage.Text = ""
            txtPortOfLoadingCode.Text = ""
            txtPortOfLoadingName.Text = ""
            txtPortOfDischargeCode.Text = ""
            txtPortOfDischargeName.Text = ""
            txtModeOfTransport.Tag = ""
            txtModeOfTransport.Text = ""
            txtDevaning.Text = ""
            txtRegistryNo.Text = ""
            txtRegistryYear.Text = ""
            txtHBL.Text = ""
            txtShipper01.Text = ""
            txtShipper01.Tag = ""
            txtShipper02.Text = ""
            txtShipper03.Text = ""
            txtShipper04.Text = ""
            txtShipper05.Text = ""
            txtShipper06.Text = ""
            txtConsignee01.Text = ""
            txtConsignee01.Tag = ""
            txtConsignee02.Text = ""
            txtConsignee03.Text = ""
            txtConsignee04.Text = ""
            txtConsignee05.Text = ""
            txtConsignee06.Text = ""
            txtNotifyParty01.Text = ""
            txtNotifyParty01.Tag = ""
            txtNotifyParty02.Text = ""
            txtNotifyParty03.Text = ""
            txtNotifyParty04.Text = ""
            txtNotifyParty05.Text = ""
            txtNotifyParty06.Text = ""
            txtAgent01.Text = ""
            txtAgent01.Tag = ""
            txtAgent02.Text = ""
            txtAgent03.Text = ""
            txtAgent04.Text = ""
            txtAgent05.Text = ""
            txtAgent06.Text = ""
            txtPlaceOfDeliveryCode.Text = ""
            txtPlaceOfDeliveryName.Text = ""
            txtFinalDestinationCode.Text = ""
            txtFinalDestinationName.Text = ""
            optCollect.Checked = False
            optPrepaid.Checked = False
            optSendDIV01.Checked = False
            optSendDIV02.Checked = False
            txtGrossWeight.Text = ""
            txtMeasurement.Text = ""
            txtQty.Text = ""
            txtExRate.Text = ""
            txtMarksAndNos.Text = ""
            txtDescription.Text = ""
            txtFreightCharges.Text = ""
            lstBookings.Items.Clear()
            dtgContainer.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub

    Public Sub LoadCurrentRecord()
        Try
            With clsCurrentMBL
                txtMBL.Text = ._MBLNo
                Select Case ._CargoType
                    Case "L"
                        optLCL.Checked = True
                    Case "F"
                        optFCL.Checked = True
                    Case Else
                        optFCL.Checked = False
                        optLCL.Checked = False
                End Select
                txtPlaceOfReceiptCode.Text = ._PlaceOfReceiptCode
                txtPlaceOfReceiptName.Text = ._PlaceOfReceiptName
                txtVessel.Text = ._VesselName
                txtVoyage.Text = ._VOY
                txtPortOfLoadingCode.Text = ._PortOfLoadingCode
                txtPortOfLoadingName.Text = ._PortOfLoadingName
                txtPortOfDischargeCode.Text = ._PortOfDischargeCode
                txtPortOfDischargeName.Text = ._PortOfDischargeName
                txtDevaning.Text = ._DevanDate
                txtExRate.Text = ._ExchangeRate
                txtModeOfTransport.Tag = ._ModeOfTransport._PK
                txtModeOfTransport.Text = ._ModeOfTransport._Param_Desc
            End With

            With clsCurrentHBL
                txtHBL.Text = ._HBLNo
                txtShipper01.Text = ._ShipperName1
                txtShipper02.Text = ._ShipperName2
                txtShipper03.Text = ._ShipperName3
                txtShipper04.Text = ._ShipperName4
                txtShipper05.Text = ._ShipperName5
                txtShipper06.Text = ._ShipperName6
                txtConsignee01.Text = ._ConsigneeName1
                txtConsignee02.Text = ._ConsigneeName2
                txtConsignee03.Text = ._ConsigneeName3
                txtConsignee04.Text = ._ConsigneeName4
                txtConsignee05.Text = ._ConsigneeName5
                txtConsignee06.Text = ._ConsigneeName6
                txtNotifyParty01.Text = ._NotifyPartyName1
                txtNotifyParty02.Text = ._NotifyPartyName2
                txtNotifyParty03.Text = ._NotifyPartyName3
                txtNotifyParty04.Text = ._NotifyPartyName4
                txtNotifyParty05.Text = ._NotifyPartyName5
                txtNotifyParty06.Text = ._NotifyPartyName6
                txtAgent01.Text = ._PartyToContactName1
                txtAgent02.Text = ._PartyToContactName2
                txtAgent03.Text = ._PartyToContactName3
                txtAgent04.Text = ._PartyToContactName4
                txtAgent05.Text = ._PartyToContactName5
                txtAgent06.Text = ._PartyToContactName6
                txtPlaceOfDeliveryCode.Text = ._PlaceOfDeliveryCode
                txtPlaceOfDeliveryName.Text = ._PlaceOfDeliveryName
                txtFinalDestinationCode.Text = ._FinalDestinationCode
                txtFinalDestinationName.Text = ._FinalDestinationName
                Select Case ._Freight
                    Case "P"
                        optPrepaid.Checked = True
                    Case "C"
                        optCollect.Checked = True
                    Case Else
                        optCollect.Checked = False
                        optPrepaid.Checked = False
                End Select
                Select Case ._SendDiv
                    Case "1"
                        optSendDIV01.Checked = True
                    Case "2"
                        optSendDIV02.Checked = True
                    Case Else
                        optSendDIV01.Checked = False
                        optSendDIV02.Checked = False
                End Select
                txtGrossWeight.Text = ._GrossWeightKGMInteger & "." & ._GrossWeightKGMFraction
                txtMeasurement.Text = ._MeasurementInteger & "." & ._MeasurementFraction
                txtQty.Text = ._TotalQuantity

                lstBookings.Items.Clear()
                For Each clsTemp As clsFrwdgDocsBooking In ._BookingDetails
                    With clsTemp
                        Dim lvItem As New ListViewItem
                        lvItem.Text = ._BookingPrefix & "-" & ._BookingNo
                        lvItem.ToolTipText = lvItem.Text
                        lvItem.SubItems.Add(._BookingID)
                        lstBookings.Items.Add(lvItem)
                    End With
                Next

                txtMarksAndNos.Text = ""
                For ctr As Integer = 1 To 15
                    For Each clsTemp As clsFrwdgDocsMarksAndNumbers In ._MarksAndNumbersDetails
                        With clsTemp
                            If CInt(._ItemLines) = ctr Then txtMarksAndNos.Text = txtMarksAndNos.Text & ._MarksAndNumbers & vbNewLine
                        End With
                    Next
                Next

                txtDescription.Text = ""
                For ctr As Integer = 1 To 15
                    For Each clsTemp As clsFrwdgDocsDescription In ._DescriptionDetails
                        With clsTemp
                            If CInt(._ItemLines) = ctr Then txtDescription.Text = txtDescription.Text & ._DescriptionOfGoods & vbNewLine
                        End With
                    Next
                Next

                txtFreightCharges.Text = ""
                For ctr As Integer = 1 To 5
                    For Each clsTemp As clsFrwdgDocsFreightAndCharge In ._FreightChargeDetails
                        With clsTemp
                            If CInt(._ItemLines) = ctr Then txtFreightCharges.Text = txtFreightCharges.Text & ._ChargeName & vbNewLine
                        End With
                    Next
                Next

                dtgContainer.Rows.Clear()
                For Each clsTemp As clsFrwdgDocsContainer In ._ContainerDetails
                    dtgContainer.Rows.Add()
                    With dtgContainer.Rows(dtgContainer.Rows.Count - 1)
                        .Cells(colContNo.Name).Value = clsTemp._ContainerNumber
                        .Cells(colContSizeName.Name).Value = clsTemp._ContainerSize
                    End With
                Next

                ChangeEnabledButtons(True, True, False, True, True, True, True, True, True, False)
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "System Message")
        End Try
    End Sub

    Private Sub frmFrwdgDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetRecord()
    End Sub

    Private Sub frmFrwdgDocs_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmFrwdgDocs_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub SelectNextTab()

    End Sub

    Private Sub lblPlaceOfReceipt_Click(sender As Object, e As EventArgs) Handles lblPlaceOfReceipt.Click
        txtPlaceOfReceiptCode.Text = ""
        txtPlaceOfReceiptName.Tag = ""
        txtPlaceOfReceiptName.Text = ""

        With frmSelection
            .Text = "Select Place Of Receipt"
            .PopulateGrid("SELECT PK, Description as `Port Name` FROM lib_port ORDER BY `Port Name`", "`Port Name`", txtPlaceOfReceiptName)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        If Len(txtPlaceOfReceiptName.Tag) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsPort = clsDB.SearchPort(txtPlaceOfReceiptName.Tag)
            txtPlaceOfReceiptCode.Text = clsTemp._UNLOCODE
        End If
    End Sub



    Private Sub lblPortOfLoading_Click(sender As Object, e As EventArgs) Handles lblPortOfLoading.Click
        txtPortOfLoadingCode.Text = ""
        txtPortOfLoadingName.Tag = ""
        txtPortOfLoadingName.Text = ""

        With frmSelection
            .Text = "Select Port Of Loading"
            .PopulateGrid("SELECT PK, Description as `Port Name` FROM lib_port ORDER BY `Port Name`", "`Port Name`", txtPortOfLoadingName)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        If Len(txtPortOfLoadingName.Tag) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsPort = clsDB.SearchPort(txtPortOfLoadingName.Tag)
            txtPortOfLoadingCode.Text = clsTemp._UNLOCODE
        End If
    End Sub

    Private Sub lblPortOfDischarge_Click(sender As Object, e As EventArgs) Handles lblPortOfDischarge.Click
        txtPortOfDischargeCode.Text = ""
        txtPortOfDischargeName.Tag = ""
        txtPortOfDischargeName.Text = ""

        With frmSelection
            .Text = "Select Port Of Discharge"
            .PopulateGrid("SELECT PK, Description as `Port Name` FROM lib_port ORDER BY `Port Name`", "`Port Name`", txtPortOfDischargeName)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        If Len(txtPortOfDischargeName.Tag) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsPort = clsDB.SearchPort(txtPortOfDischargeName.Tag)
            txtPortOfLoadingCode.Text = clsTemp._UNLOCODE
        End If

    End Sub

    Private Sub lblPlaceOfDelivery_Click(sender As Object, e As EventArgs) Handles lblPlaceOfDelivery.Click
        txtPlaceOfDeliveryCode.Text = ""
        txtPlaceOfDeliveryName.Tag = ""
        txtPlaceOfDeliveryName.Text = ""

        With frmSelection
            .Text = "Select Place Of Receipt"
            .PopulateGrid("SELECT PK, Description as `Port Name` FROM lib_port ORDER BY `Port Name`", "`Port Name`", txtPlaceOfDeliveryName)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        If Len(txtPortOfDischargeName.Tag) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsPort = clsDB.SearchPort(txtPortOfDischargeName.Tag)
            txtPlaceOfDeliveryCode.Text = clsTemp._UNLOCODE
        End If

    End Sub

    Private Sub lblFinalDestination_Click(sender As Object, e As EventArgs) Handles lblFinalDestination.Click
        txtFinalDestinationCode.Text = ""
        txtFinalDestinationName.Tag = ""
        txtFinalDestinationName.Text = ""

        With frmSelection
            .Text = "Select Place Of Receipt"
            .PopulateGrid("SELECT PK, Description as `Port Name` FROM lib_port ORDER BY `Port Name`", "`Port Name`", txtFinalDestinationName)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        If Len(txtFinalDestinationName.Tag) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsPort = clsDB.SearchPort(txtFinalDestinationName.Tag)
            txtFinalDestinationCode.Text = clsTemp._UNLOCODE
        End If
    End Sub

    Private Sub cmdContAdd_Click(sender As Object, e As EventArgs)
        frmAddBookingContainer.strCaller = "FwrdngDocs"
        frmAddBookingContainer.ShowDialog()
    End Sub

    Private Sub lblShipper_Click(sender As Object, e As EventArgs) Handles lblShipper.Click
        With frmSelection
            .Text = "Select Shipper"
            .PopulateGrid("SELECT Code, Description AS `Shipper Name` FROM v_shipper ORDER BY Description", "`Shipper Name`", txtShipper01)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        Dim strClientCode As String = txtShipper01.Tag
        If Len(strClientCode) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsClientHeader = clsDB.SearchClientRecord(strClientCode)
            Dim strTemp As String = Trim(clsTemp._Description & " " & clsTemp._Addr1 & " " & clsTemp._CityDesc & " " & clsTemp._CountryDesc).ToUpper

            Dim lstString As List(Of String) = DivideString(strTemp, 35)

            Try
                txtShipper01.Text = lstString(0)
                txtShipper02.Text = lstString(1)
                txtShipper03.Text = lstString(2)
                txtShipper04.Text = lstString(3)
                txtShipper05.Text = lstString(4)
                txtShipper06.Text = lstString(5)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub lblConsignee_Click(sender As Object, e As EventArgs) Handles lblConsignee.Click
        With frmSelection
            .Text = "Select Consignee"
            .PopulateGrid("SELECT Code, Description AS `Consignee Name` FROM v_consignee ORDER BY Description", "`Consignee Name`", txtConsignee01)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        Dim strClientCode As String = txtConsignee01.Tag
        If Len(strClientCode) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsClientHeader = clsDB.SearchClientRecord(strClientCode)
            Dim strTemp As String = Trim(clsTemp._Description & " " & clsTemp._Addr1 & " " & clsTemp._CityDesc & " " & clsTemp._CountryDesc).ToUpper

            Dim lstString As List(Of String) = DivideString(strTemp, 35)

            Try
                txtConsignee01.Text = lstString(0)
                txtConsignee02.Text = lstString(1)
                txtConsignee03.Text = lstString(2)
                txtConsignee04.Text = lstString(3)
                txtConsignee05.Text = lstString(4)
                txtConsignee06.Text = lstString(5)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub lblNotifyParty_Click(sender As Object, e As EventArgs) Handles lblNotifyParty.Click
        With frmSelection
            .Text = "Select Notify Party"
            .PopulateGrid("SELECT Code, Description AS `Notify Party Name` FROM tbl_client ORDER BY Description", "`Notify Party Name`", txtNotifyParty01)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        Dim strClientCode As String = txtNotifyParty01.Tag
        If Len(strClientCode) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsClientHeader = clsDB.SearchClientRecord(strClientCode)
            Dim strTemp As String = Trim(clsTemp._Description & " " & clsTemp._Addr1 & " " & clsTemp._CityDesc & " " & clsTemp._CountryDesc).ToUpper

            Dim lstString As List(Of String) = DivideString(strTemp, 35)

            Try
                txtNotifyParty01.Text = lstString(0)
                txtNotifyParty02.Text = lstString(1)
                txtNotifyParty03.Text = lstString(2)
                txtNotifyParty04.Text = lstString(3)
                txtNotifyParty05.Text = lstString(4)
                txtNotifyParty06.Text = lstString(5)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub lblAgent_Click(sender As Object, e As EventArgs) Handles lblAgent.Click
        With frmSelection
            .Text = "Select Agent"
            .PopulateGrid("SELECT Code, Description AS `Agent Name` FROM v_agent ORDER BY Description", "`Agent Name`", txtAgent01)

            .dtgSelection.Columns(0).Visible = False
            .dtgSelection.Columns(1).Width = 375

            .ShowDialog()
        End With

        Dim strClientCode As String = txtAgent01.Tag
        If Len(strClientCode) > 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsTemp As clsClientHeader = clsDB.SearchClientRecord(strClientCode)
            Dim strTemp As String = Trim(clsTemp._Description & " " & clsTemp._Addr1 & " " & clsTemp._CityDesc & " " & clsTemp._CountryDesc).ToUpper

            Dim lstString As List(Of String) = DivideString(strTemp, 35)

            Try
                txtAgent01.Text = lstString(0)
                txtAgent02.Text = lstString(1)
                txtAgent03.Text = lstString(2)
                txtAgent04.Text = lstString(3)
                txtAgent05.Text = lstString(4)
                txtAgent06.Text = lstString(5)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub optPrepaid_CheckedChanged(sender As Object, e As EventArgs) Handles optPrepaid.CheckedChanged
        If optPrepaid.Checked = True Then
            txtFreightCharges.Text = "FREIGHT PREPAID" & vbNewLine & "AS ARRANGED"
        End If
    End Sub

    Private Sub dtpDevanning_ValueChanged(sender As Object, e As EventArgs) Handles dtpDevanning.ValueChanged
        txtDevaning.Text = Format(dtpDevanning.Value, "MM/dd/yyyy")
    End Sub

    Private Sub optCollect_CheckedChanged(sender As Object, e As EventArgs) Handles optCollect.CheckedChanged
        If optCollect.Checked = True Then
            txtFreightCharges.Text = "FREIGHT COLLECT" & vbNewLine & "AS ARRANGED"
        End If
    End Sub
End Class