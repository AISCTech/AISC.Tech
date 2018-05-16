Imports MySql.Data.MySqlClient
Public Class frmAISCSalesQuotation
    Implements ICommonFunction
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

            Me.cboCompany.Enabled = blUserInput
            Me.cboTransType.Enabled = blUserInput
            Me.cboTransMode.Enabled = blUserInput
            Me.cboLoadType.Enabled = blUserInput
            Me.cboClient.Enabled = blUserInput
            Me.txtCommodity.ReadOnly = Not blUserInput
            Me.txtCBM.ReadOnly = Not blUserInput
            Me.txtWeight.ReadOnly = Not blUserInput
            'Me.txtContainer.ReadOnly = Not blUserInput
            Me.dgServices.ReadOnly = Not blUserInput
            Me.dgContainer.ReadOnly = Not blUserInput
            Me.cboOriginCountry.Enabled = blUserInput
            Me.cboOriginPort.Enabled = blUserInput
            'Me.cboDESCountry.Enabled = blUserInput
            'Me.cboDESPort.Enabled = blUserInput
            Me.cboDESPort2.Enabled = blUserInput
            Me.cboShippingLine.Enabled = blUserInput

            Me.dgRouting.ReadOnly = Not blUserInput

            Me.cboCurrency.Enabled = blUserInput

            Me.dgOceanFreight.ReadOnly = Not blUserInput
            Me.dgLocalCharges.ReadOnly = Not blUserInput
            Me.dgCustomsProcessing.ReadOnly = Not blUserInput
            Me.dgPickupLoading.ReadOnly = Not blUserInput

            Me.btAddDES.Enabled = blUserInput
            Me.btRemoveDES.Enabled = blUserInput

            Me.btPrevScanFile.Enabled = Not blUserInput

            .UpdateEnabledButtons()
        End With
    End Sub
    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        If Len(Me.txtControlNum.Text) = 0 Then
            MsgBox("Nothing to Cancel!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.tstripStatus.Text <> "Open" Then
            MsgBox("Record already " & Me.tstripStatus.Text & "!", vbInformation, "Cannot Cancel Record")
            Exit Sub
        End If
        'user restrictions

        'cancel record
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        If Len(Me.txtControlNum.Text) = 0 Then
            MsgBox("Nothing to Edit!", vbInformation, "System Message")
            Exit Sub
        End If

        'user restrictions

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)

    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        'user restrictions

        If MsgBox("Are you sure you want to create new Sales Quotation?", vbYesNo, "Create New?") = vbNo Then Exit Sub

        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
        ClearEntries()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        If Len(Me.txtControlNum.Text) = 0 Then
            MsgBox("Nothing to Post!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.tstripStatus.Text <> "Open" Then
            MsgBox("Record already " & Me.tstripStatus.Text & "!", vbInformation, "Cannot Post Record")
            Exit Sub
        End If
        'user restrictions

        'post record
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        If Len(Me.txtControlNum.Text) = 0 Then
            MsgBox("Nothing to Post!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.tstripStatus.Text <> "Open" Then
            MsgBox("Record already " & Me.tstripStatus.Text & "!", vbInformation, "Cannot Post Record")
            Exit Sub
        End If
        'user restrictions
        'print record
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        If Len(Me.txtControlNum.Text) = 0 Then
            MsgBox("Nothing to Re-Open!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.tstripStatus.Text = "Open" Then
            MsgBox("Record already " & Me.tstripStatus.Text & "!", vbInformation, "Cannot Re-Open Record")
            Exit Sub
        End If
        'user restrictions

        're-open record
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        ClearEntries()
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckForRequiredEntries() = False Then Exit Sub

        If MsgBox("Are you sure you want to save this record?", vbYesNo, "Confirm Save?") = vbNo Then Exit Sub

        SaveQuotation()

    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        SearchQuotation(Me.txtControlNum.Text)
    End Sub

    Private Sub frmSalesQuotation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        FillComboBox(Me.cboCompany, "Select Company_Name from tbl_company where Company_Name is not null", "Company_Name")
        FillComboBox(Me.cboTransType, "Select Description from tbl_transactiontype where Description is not null", "Description")
        FillComboBox(Me.cboTransMode, "Select Description from tbl_transportmode where Description is not null", "Description")
        FillComboBox(Me.cboLoadType, "Select Description from tbl_loadtype where Description is not null", "Description")
        FillComboBox(Me.cboClient, "Select Description from tbl_client where Description is not null", "Description")
        FillComboBox(Me.cboCurrency, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillComboBox(Me.cboOriginCountry, "Select Description from lib_country where Description is not null", "Description")
        FillComboBox(Me.cboDESCountry, "Select Description from lib_country where Description is not null", "Description")
        FillComboBox(Me.cboDESPort2, "Select Description from lib_port where Description is not null", "Description")
        FillComboBox(Me.cboShippingLine, "Select Description from tbl_client where Description is not null", "Description")

        FillGridComboBox(Me.colOFChargeName, "Select ChargeName from lib_charges where ChargeName is not null", "ChargeName")
        FillGridComboBox(Me.colLCChargeName, "Select ChargeName from lib_charges where ChargeName is not null", "ChargeName")
        FillGridComboBox(Me.colCPChargeName, "Select ChargeName from lib_charges where ChargeName is not null", "ChargeName")
        FillGridComboBox(Me.colPLChargeName, "Select ChargeName from lib_charges where ChargeName is not null", "ChargeName")

        FillGridComboBox(Me.colOFCurrencyBuying, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colOFCurrencySelling, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colLCCurrencyBuying, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colLCCurrencySelling, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colCPCurrencyBuying, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colCPCurrencySelling, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colPLCurrencyBuying, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillGridComboBox(Me.colPLCurrencySelling, "Select Acronym from lib_currency where Acronym is not null", "Acronym")

        PopServices(Me.dgServices)
        ClearEntries()
        Me.dgContainer.Rows.Add("", "20FT")
        Me.dgContainer.Rows.Add("", "40FT")
        Me.dgContainer.Rows.Add("", "40HC")
    End Sub

    Public Sub PopServices(ByVal dg As DataGridView)
        dg.Rows.Clear()

        Dim cnn As New MySqlConnection(strDBMaster)
        Dim strSQL As String

        strSQL = "SELECT * " &
                     "FROM tbl_services Where Description is not null"

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        While reader.Read

            dg.Rows.Add(False, reader.Item("Description"), reader.Item("Remarks"))

        End While
        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Sub

    Private Sub frmAISCSalesQuotation_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Public Sub ClearEntries()
        ErrorProvider1.Clear()
        Me.cboCompany.SelectedIndex = -1
        Me.txtCompany.Text = ""
        Me.cboTransType.SelectedIndex = -1
        Me.cboTransMode.SelectedIndex = -1
        Me.cboLoadType.SelectedIndex = -1
        Me.cboClient.SelectedIndex = -1
        Me.txtClientCode.Text = ""
        Me.txtCommodity.Text = ""
        Me.txtScanFile.Text = ""
        Me.lblFromOrigin.Text = ""
        Me.txtCBM.Text = ""
        Me.txtWeight.Text = ""
        Me.txtContainer.Text = ""
        'Me.dgContainer.Rows.Clear()
        Dim i As Integer = 0
        Dim h As DataGridViewRow
        For i = 0 To Me.dgServices.Rows.Count - 1
            h = Me.dgServices.Rows(i)
            h.Cells(0).Value = False
        Next

        Me.cboOriginCountry.SelectedIndex = -1
        Me.cboOriginPort.SelectedIndex = -1
        Me.cboDESCountry.SelectedIndex = -1
        Me.cboDESPort.SelectedIndex = -1
        Me.cboDESPort2.SelectedIndex = -1
        Me.cboShippingLine.SelectedIndex = -1
        Me.lblTranshipment.Text = ""

        Me.dgRouting.Rows.Clear()
        Me.lblFromOrigin.Text = ""

        Me.txtCurrency.Text = ""
        Me.cboCurrency.SelectedIndex = -1
        Me.txtExRate.Text = 0
        Me.txtTotalAmount.Text = 0
        Me.txtTotalAmountInPeso.Text = 0

        Me.txtBuyingOF.Text = 0
        Me.txtSellingOF.Text = 0
        Me.txtBuyingLC.Text = 0
        Me.txtSellingLC.Text = 0
        Me.txtBuyingCP.Text = 0
        Me.txtSellingCP.Text = 0
        Me.txtBuyingPL.Text = 0
        Me.txtSellingPL.Text = 0

        Me.dgOceanFreight.Rows.Clear()
        Me.dgLocalCharges.Rows.Clear()
        Me.dgCustomsProcessing.Rows.Clear()
        Me.dgPickupLoading.Rows.Clear()

        Me.tstripEncodedBy.Text = ""
        Me.tstripEncodedDate.Text = ""
        Me.tstripModifiedBy.Text = ""
        Me.tstripModifiedDate.Text = ""
        Me.tstripStatus.Text = ""
    End Sub

    Public Function CheckForRequiredEntries() As Boolean
        ErrorProvider1.Clear()

        If Me.cboCompany.SelectedIndex = -1 Then
            MsgBox("Please select Company", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboCompany, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboTransType.SelectedIndex = -1 Then
            MsgBox("Please select Transaction Type", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboTransType, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboTransMode.SelectedIndex = -1 Then
            MsgBox("Please select Transport Mode", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboTransMode, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboLoadType.SelectedIndex = -1 Then
            MsgBox("Please select Load Type", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboLoadType, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboClient.SelectedIndex = -1 Then
            MsgBox("Please select Client Name", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboClient, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtCommodity.Text) = 0 Then
            MsgBox("Please type Commodity", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.txtCommodity, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtCBM.Text) = 0 Then
            MsgBox("Please type CBM", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.txtCBM, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtWeight.Text) = 0 Then
            MsgBox("Please type Weight", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.txtWeight, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If


        If Me.cboLoadType.Text = "FCL" Then
            Dim i As Integer = 0
            Dim h As DataGridViewRow
            Dim iCont As Integer = 0
            For i = 0 To Me.dgContainer.Rows.Count - 1
                h = Me.dgContainer.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    If Len(h.Cells(0).Value) <> 0 Then
                        iCont = iCont + 1
                    End If
                End If
            Next

            If iCont = 0 Then
                MsgBox("Number of container(s) cannot be blank", vbYesNo, "Missing Information")
                ErrorProvider1.SetError(Me.dgContainer, "Missing Information")
                CheckForRequiredEntries = False
                Exit Function
            End If

        End If

        If Me.cboOriginCountry.SelectedIndex = -1 Then
            MsgBox("Please select Country of Origin", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboOriginCountry, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboOriginPort.SelectedIndex = -1 Then
            MsgBox("Please select Port of Origin", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboOriginPort, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        'If Me.cboDESCountry.SelectedIndex = -1 Then
        '    MsgBox("Please select Country of Destination", vbYesNo, "Missing Information")
        '    ErrorProvider1.SetError(Me.cboDESCountry, "Missing Information")
        '    CheckForRequiredEntries = False
        '    Exit Function
        'End If

        'If Me.cboDESPort.SelectedIndex = -1 Then
        '    MsgBox("Please select Port of Destination", vbYesNo, "Missing Information")
        '    ErrorProvider1.SetError(Me.cboDESPort, "Missing Information")
        '    CheckForRequiredEntries = False
        '    Exit Function
        'End If

        If Me.cboShippingLine.SelectedIndex = -1 Then
            MsgBox("Please select Shipping Line", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboShippingLine, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboCurrency.SelectedIndex = -1 Then
            MsgBox("Please select Currency", vbYesNo, "Missing Information")
            ErrorProvider1.SetError(Me.cboCurrency, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If



        'If CDbl(Me.txtTotalAmount.Text) = 0 Then
        '    MsgBox("Please select Currency", vbYesNo, "Missing Information")
        '    ErrorProvider1.SetError(Me.cboCurrency, "Missing Information")
        '    CheckForRequiredEntries = False
        '    Exit Function
        'End If

        CheckForRequiredEntries = True
    End Function

    Public Sub SaveQuotation()
        Dim cmdSQL As New MySqlCommand
        Dim dtCurrent As Date
        'script to get the current date of MYSQL Server
        dtCurrent = GetServerDate()

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        If Len(Me.txtControlNum.Text) = 0 Then

            Try
                cmdSQL.CommandText = ("INSERT INTO tbl_salesquotation (`CtrlNbr`, `CompanyCode`, `CompanyName`, `TransactionType`, `TransportMode`,  `CBM`, `Weight`, `Container`, `LoadType`, `ClientCode`, `ClientName`, `Commodity`, `Services`, `UploadFile`, `Currency`, `TotalAmt`, `TotalAmtPhp`, `ExRate`, `OriginCountry`, `OriginPort`, `DestinationCountry`, `DestinationPort`, `TranshipmentRoute`, `ShippingLine`, `Status`, `EncodedBy`, `EncodedDate`, `ModifiedBy`, `ModifiedDate`)  VALUES " &
                                     "               (@CtrlNbr, @CompanyCode, @CompanyName, @TransactionType, @TransportMode, @CBM, @Weight, @Container, @LoadType, @ClientCode, @ClientName, @Commodity, @Services, @UploadFile, @Currency, @TotalAmt, @TotalAmtPhp, @ExRate, @OriginCountry, @OriginPort, @DestinationCountry, @DestinationPort, @TranshipmentRoute, @ShippingLine, @Status, @EncodedBy, @EncodedDate, @ModifiedBy, @ModifiedDate)")


                With cmdSQL.Parameters
                    Dim strPK As String = GetCtrlNbr(strCompanyCode, strSiteCode, "Acestar_Sales_Quotation")

                    If Len(strPK) = 0 Then
                        MsgBox("Error getting control number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@CtrlNbr", strPK)
                    .AddWithValue("@CompanyCode", Me.txtCompany.Text)
                    .AddWithValue("@CompanyName", Me.cboCompany.Text)
                    .AddWithValue("@TransactionType", Me.cboTransType.Text)
                    .AddWithValue("@TransportMode", Me.cboTransMode.Text)
                    .AddWithValue("@CBM", CDbl(Me.txtCBM.Text))
                    .AddWithValue("@Weight", CDbl(Me.txtWeight.Text))
                    .AddWithValue("@Container", Me.txtContainer.Text)
                    .AddWithValue("@LoadType", Me.cboLoadType.Text)
                    If Me.cboLoadType.Text = "FCL" Then
                        SaveContainer(Me.dgContainer)
                    End If
                    .AddWithValue("@ClientCode", Me.txtClientCode.Text)
                    .AddWithValue("@ClientName", Me.cboClient.Text)
                    .AddWithValue("@Commodity", Me.txtCommodity.Text)

                    Dim i As Integer = 0
                    Dim h As DataGridViewRow
                    Dim strServices As String = ""
                    For i = 0 To Me.dgServices.Rows.Count - 1
                        h = Me.dgServices.Rows(i)

                        If h.Cells(0).Value = True Then
                            strServices = strServices & h.Cells(1).Value
                        End If

                    Next

                    .AddWithValue("@Services", strServices)
                    .AddWithValue("@UploadFile", Me.txtScanFile.Text)
                    .AddWithValue("@Currency", Me.cboCurrency.Text)
                    .AddWithValue("@TotalAmt", CDbl(Me.txtTotalAmount.Text))
                    .AddWithValue("@TotalAmtPhp", CDbl(Me.txtTotalAmountInPeso.Text))
                    .AddWithValue("@ExRate", CDbl(Me.txtExRate.Text))
                    .AddWithValue("@OriginCountry", Me.cboOriginCountry.Text)
                    .AddWithValue("@OriginPort", Me.cboOriginPort.Text)
                    .AddWithValue("@DestinationCountry", Me.cboDESCountry.Text)
                    .AddWithValue("@DestinationPort", Me.cboDESPort.Text)
                    .AddWithValue("@TranshipmentRoute", Me.lblTranshipment.Text)
                    .AddWithValue("@ShippingLine", Me.cboShippingLine.Text)
                    .AddWithValue("@Status", 1)
                    .AddWithValue("@EncodedDate", dtCurrent)
                    .AddWithValue("@EncodedBy", strCurrentUser)
                    .AddWithValue("@ModifiedDate", dtCurrent)
                    .AddWithValue("@ModifiedBy", strCurrentUser)
                    Me.txtControlNum.Text = strPK
                    Me.tstripEncodedBy.Text = strCurrentUser
                    Me.tstripEncodedDate.Text = Format(dtCurrent, "yyyy-MM-dd hhmm : ss")
                    Me.tstripModifiedBy.Text = strCurrentUser
                    Me.tstripModifiedDate.Text = Format(dtCurrent, "yyyy-MM-dd hh: mm : ss")
                    Me.tstripStatus.Text = "Open"
                End With

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()

            Catch ex As Exception
                MsgBox("There was an Error trying To save the record - " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Acestar_Sales_Quotation")

            SaveCharges(Me.dgOceanFreight, 1)
            SaveCharges(Me.dgLocalCharges, 2)
            SaveCharges(Me.dgCustomsProcessing, 3)
            SaveCharges(Me.dgPickupLoading, 4)

            MsgBox("Record Successfully Saved!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            'save transaction log
            SaveTransLogs("Create New", Me.Name, "Acestar Sales Quotation", Me.txtControlNum.Text, strCurrentUser)

        Else
            'update record

            Dim sSQL As String = "UPDATE tbl_salesquotation Set "
            sSQL += " CompanyCode=@CompanyCode, "
            sSQL += " CompanyName=@CompanyName, "
            sSQL += " TransactionType=@TransactionType, "
            sSQL += " TransportMode=@TransportMode, "
            sSQL += " CBM=@CBM, "
            sSQL += " Weight=@Weight, "
            sSQL += " Container=@Container, "
            sSQL += " LoadType=@LoadType, "
            sSQL += " ClientCode=@ClientCode, "
            sSQL += " ClientName=@ClientName, "
            sSQL += " Commodity=@Commodity, "
            sSQL += " Services=@Services, "
            sSQL += " UploadFile=@UploadFile, "
            sSQL += " Currency=@Currency, "
            sSQL += " TotalAmt=@TotalAmt, "
            sSQL += " TotalAmtPhp=@TotalAmtPhp, "
            sSQL += " ExRate=@ExRate, "
            sSQL += " OriginCountry=@OriginCountry, "
            sSQL += " OriginPort=@OriginPort, "
            sSQL += " DestinationCountry=@DestinationCountry, "
            sSQL += " DestinationPort=@DestinationPort, "
            sSQL += " TranshipmentRoute=@TranshipmentRoute, "
            sSQL += " ShippingLine=@ShippingLine, "
            sSQL += " Status=@Status, "
            sSQL += " ModifiedDate=@ModifiedDate, "
            sSQL += " ModifiedBy=@ModifiedBy "
            sSQL += " WHERE CtrlNbr = '" & Me.txtControlNum.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@CompanyCode", Me.txtCompany.Text)
                .AddWithValue("@CompanyName", Me.cboCompany.Text)
                .AddWithValue("@TransactionType", Me.cboTransType.Text)
                .AddWithValue("@TransportMode", Me.cboTransMode.Text)
                .AddWithValue("@CBM", CDbl(Me.txtCBM.Text))
                .AddWithValue("@Weight", CDbl(Me.txtWeight.Text))
                .AddWithValue("@Container", Me.txtContainer.Text)
                .AddWithValue("@LoadType", Me.cboLoadType.Text)
                .AddWithValue("@ClientCode", Me.txtClientCode.Text)
                .AddWithValue("@ClientName", Me.cboClient.Text)
                .AddWithValue("@Commodity", Me.txtCommodity.Text)
                Dim i As Integer = 0
                Dim h As DataGridViewRow
                Dim strServices As String = ""
                For i = 0 To Me.dgServices.Rows.Count - 1
                    h = Me.dgServices.Rows(i)

                    If h.Cells(0).Value = True Then
                        strServices = strServices & h.Cells(1).Value
                    End If

                Next

                .AddWithValue("@Services", strServices)
                .AddWithValue("@UploadFile", Me.txtScanFile.Text)
                .AddWithValue("@Currency", Me.cboCurrency.Text)
                .AddWithValue("@TotalAmt", CDbl(Me.txtTotalAmount.Text))
                .AddWithValue("@TotalAmtPhp", CDbl(Me.txtTotalAmountInPeso.Text))
                .AddWithValue("@ExRate", CDbl(Me.txtExRate.Text))
                .AddWithValue("@OriginCountry", Me.cboOriginCountry.Text)
                .AddWithValue("@OriginPort", Me.cboOriginPort.Text)
                .AddWithValue("@DestinationCountry", Me.cboDESCountry.Text)
                .AddWithValue("@DestinationPort", Me.cboDESPort.Text)
                .AddWithValue("@TranshipmentRoute", Me.lblTranshipment.Text)
                .AddWithValue("@ShippingLine", Me.cboShippingLine.Text)
                .AddWithValue("@Status", 1)
                .AddWithValue("@ModifiedDate", dtCurrent)
                .AddWithValue("@ModifiedBy", strCurrentUser)
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            'Delete record in tbl_salesquotationcharges
            Dim cmdSysParam As MySqlCommand
            Dim sqlString2 As String = "DELETE FROM tbl_salesquotationcharges WHERE CtrlNbr = '" & Me.txtControlNum.Text & "'"

            cmdSysParam = New MySqlCommand(sqlString2, cnnDBMaster)
            cmdSysParam.ExecuteNonQuery()

            cmdSysParam.Dispose()


            SaveCharges(Me.dgOceanFreight, 1)
            SaveCharges(Me.dgLocalCharges, 2)
            SaveCharges(Me.dgCustomsProcessing, 3)
            SaveCharges(Me.dgPickupLoading, 4)


            If Me.cboLoadType.Text = "FCL" Then
                Dim cmdSysParam3 As MySqlCommand
                Dim sqlString3 As String = "DELETE FROM tbl_salesquotationcontainer WHERE CtrlNbr = '" & Me.txtControlNum.Text & "'"

                cmdSysParam3 = New MySqlCommand(sqlString3, cnnDBMaster)
                cmdSysParam3.ExecuteNonQuery()

                cmdSysParam3.Dispose()

                SaveContainer(Me.dgContainer)

            End If

            MsgBox("Record " & Me.txtControlNum.Text & " Successfully Updated!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            Me.tstripStatus.Text = "Open"
            Me.tstripModifiedBy.Text = strCurrentUser
            Me.tstripModifiedDate.Text = Format(dtCurrent, "yyyy-MM-dd hh:mm:ss")
            SaveTransLogs("Edit Record", Me.Name, "Acestar Sales Quotation", Me.txtControlNum.Text, strCurrentUser)
        End If

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()

        PopCharges(Me.dgOceanFreight, Me.txtControlNum.Text, 1)
        PopCharges(Me.dgLocalCharges, Me.txtControlNum.Text, 2)
        PopCharges(Me.dgCustomsProcessing, Me.txtControlNum.Text, 3)
        PopCharges(Me.dgPickupLoading, Me.txtControlNum.Text, 4)
    End Sub

    Public Sub PopCharges(ByVal dg As DataGridView, ByVal str As String, ByVal intType As Integer)
        dg.Rows.Clear()
        Dim cnn As New MySqlConnection(strDBMaster)
        Dim strSQL As String

        strSQL = "SELECT * " &
                     "FROM tbl_salesquotationcharges Where CtrlNbr = '" & str & "' and Type  = " & intType & ""

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        While reader.Read

            dg.Rows.Add(reader.Item("ChargeCode"), reader.Item("ChargeName"), reader.Item("BuyingCurrency"), Format(reader.Item("BuyingExRate"), "n2"), Format(reader.Item("BuyingPrice"), "n2"), Format(reader.Item("BuyingAmtPhp"), "n2"), reader.Item("SellingCurrency"), Format(reader.Item("SellingExRate"), "n2"), Format(reader.Item("SellingPrice"), "n2"), Format(reader.Item("SellingAmtPhp"), "n2"), reader.Item("Remarks"))

        End While
        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Sub

    Public Sub SaveCharges(ByVal dg As DataGridView, ByVal intType As Integer)
        Dim i As Integer = 0
        Dim h As DataGridViewRow

        For i = 0 To dg.Rows.Count - 1
            h = dg.Rows(i)
            Dim cmdSQLPart1 As New MySqlCommand
            cmdSQLPart1.Connection = cnnDBMaster

            If Not Len(h.Cells(0).Value) = 0 Then
                cmdSQLPart1.CommandText = ("INSERT INTO tbl_salesquotationcharges (CtrlNbr, ChargeCode, ChargeName, Type, BuyingCurrency, BuyingExRate, BuyingPrice, BuyingAmtPhp, SellingCurrency, SellingExRate, SellingPrice, SellingAmtPhp, Remarks)  VALUES " &
                                      "                   (@CtrlNbr, @ChargeCode, @ChargeName, @Type, @BuyingCurrency, @BuyingExRate, @BuyingPrice, @BuyingAmtPhp, @SellingCurrency, @SellingExRate, @SellingPrice, @SellingAmtPhp, @Remarks)")

                With cmdSQLPart1.Parameters
                    .AddWithValue("@CtrlNbr", Me.txtControlNum.Text)
                    .AddWithValue("@ChargeCode", h.Cells(0).Value)
                    .AddWithValue("@ChargeName", h.Cells(1).Value)
                    .AddWithValue("@Type", intType)
                    .AddWithValue("@BuyingCurrency", h.Cells(2).Value)
                    .AddWithValue("@BuyingExRate", CDbl(h.Cells(3).Value))
                    .AddWithValue("@BuyingPrice", CDbl(h.Cells(4).Value))
                    .AddWithValue("@BuyingAmtPhp", CDbl(h.Cells(5).Value))
                    .AddWithValue("@SellingCurrency", h.Cells(6).Value)
                    .AddWithValue("@SellingExRate", CDbl(h.Cells(7).Value))
                    .AddWithValue("@SellingPrice", CDbl(h.Cells(8).Value))
                    .AddWithValue("@SellingAmtPhp", CDbl(h.Cells(9).Value))
                    .AddWithValue("@Remarks", h.Cells(10).Value)
                End With

                cmdSQLPart1.ExecuteNonQuery()

            End If
            cmdSQLPart1.Dispose()

        Next
    End Sub

    Public Sub SaveContainer(ByVal dg As DataGridView)
        Dim i As Integer = 0
        Dim h As DataGridViewRow

        For i = 0 To dg.Rows.Count - 1
            h = dg.Rows(i)
            Dim cmdSQLPart1 As New MySqlCommand
            cmdSQLPart1.Connection = cnnDBMaster

            If Not Len(h.Cells(0).Value) = 0 Then
                cmdSQLPart1.CommandText = ("INSERT INTO tbl_salesquotationcontainer (CtrlNbr, ContQty, ContSize)  VALUES " &
                                      "                   (@CtrlNbr, @ContQty, @ContSize)")

                With cmdSQLPart1.Parameters
                    .AddWithValue("@CtrlNbr", Me.txtControlNum.Text)
                    .AddWithValue("@ContQty", h.Cells(0).Value)
                    .AddWithValue("@ContSize", h.Cells(1).Value)
                End With

                cmdSQLPart1.ExecuteNonQuery()

            End If
            cmdSQLPart1.Dispose()

        Next
    End Sub

    Public Sub SearchQuotation(ByVal str As String)
        ClearEntries()
        Dim cnn As New MySqlConnection(strDBMaster)
        Dim strSQL As String

        strSQL = "SELECT * " &
                     "FROM tbl_salesquotation where CtrlNbr = '" & str & "'"

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        If reader.HasRows = False Then
            MsgBox("No Record Found!", vbInformation, "System Message")
            cmd.Dispose()
            reader.Close()
            cnn.Close()
            Exit Sub
        End If

        While reader.Read
            Me.txtControlNum.Text = reader.Item("CtrlNbr")
            Me.txtCompany.Text = reader.Item("CompanyCode")
            Me.cboCompany.Text = reader.Item("CompanyName")
            Me.cboTransType.Text = reader.Item("TransactionType")
            Me.cboTransMode.Text = reader.Item("TransportMode")
            Me.txtCBM.Text = Format(reader.Item("CBM"), "n2")
            Me.txtWeight.Text = Format(reader.Item("Weight"), "n2")
            Me.txtContainer.Text = reader.Item("Container")
            Me.cboLoadType.Text = reader.Item("LoadType")
            Me.txtClientCode.Text = reader.Item("ClientCode")
            Me.cboCompany.Text = reader.Item("ClientName")
            Me.txtCommodity.Text = reader.Item("Commodity")

            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To Me.dgServices.Rows.Count - 1
                h = Me.dgServices.Rows(i)

                If reader.Item("Services").ToString.Contains(h.Cells(1).Value) Then
                    h.Cells(0).Value = True
                Else
                    h.Cells(0).Value = False
                End If

            Next

            Me.txtScanFile.Text = reader.Item("UploadFile")
            Me.cboCurrency.Text = reader.Item("Currency")
            Me.txtTotalAmount.Text = Format(reader.Item("TotalAmt"), "n2")
            Me.txtTotalAmountInPeso.Text = Format(reader.Item("TotalAmtPhp"), "n2")
            Me.txtExRate.Text = Format(reader.Item("ExRate"), "n2")
            Me.cboOriginCountry.Text = reader.Item("OriginCountry")
            Me.cboOriginPort.Text = reader.Item("OriginPort")
            Me.cboDESCountry.Text = reader.Item("DestinationCountry")
            Me.cboDESPort.Text = reader.Item("DestinationPort")
            Me.lblTranshipment.Text = reader.Item("TranshipmentRoute")

            Select Case reader.Item("Status")
                Case 1
                    Me.tstripStatus.Text = "Open"
                Case 2
                    Me.tstripStatus.Text = "Posted"
                Case 3
                    Me.tstripStatus.Text = "Cancelled"
            End Select

            Me.tstripEncodedBy.Text = reader.Item("EncodedBy")
            Me.tstripEncodedDate.Text = Format(reader.Item("EncodedDate"), "yyyy-MM-dd hh:mm:ss")
            Me.tstripModifiedBy.Text = reader.Item("ModifiedBy")
            Me.tstripModifiedDate.Text = Format(reader.Item("ModifiedDate"), "yyyy-MM-dd hh:mm:ss")

        End While
        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCompany.SelectedIndexChanged
        If Me.cboCompany.SelectedIndex = -1 Then Exit Sub

        Me.txtCompany.Text = GetStringValue("Select Company_Code from tbl_company where Company_Name = '" & Me.cboCompany.Text & "'", "Company_Code")
    End Sub

    Private Sub cboClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClient.SelectedIndexChanged
        If Me.cboClient.SelectedIndex = -1 Then Exit Sub

        Me.txtClientCode.Text = GetStringValue("Select Code from tbl_client where Description = '" & Me.cboClient.Text & "'", "Code")
    End Sub

    Private Sub dgPickupLoading_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickupLoading.CellContentClick

    End Sub

    Public Sub ComputeTotal(ByVal dg As DataGridView, ByVal str As String)
        Dim i As Integer = 0
        Dim h As DataGridViewRow
        Dim dblBuying As Double = 0
        Dim dblSelling As Double = 0
        For i = 0 To dg.Rows.Count - 1
            h = dg.Rows(i)

            If Len(h.Cells(1).Value) <> 0 Then
                h.Cells(0).Value = GetStringValue("Select ChargeCode from lib_charges where ChargeName = '" & h.Cells(1).Value & "'", "ChargeCode")
            Else
                h.Cells(0).Value = ""
            End If

            If Len(h.Cells(2).Value) <> 0 Then
                h.Cells(3).Value = GetDoubleValue("Select Rate from lib_currency where Acronym = '" & h.Cells(2).Value & "'", "Rate")
            Else
                h.Cells(3).Value = 0
            End If

            If Len(h.Cells(6).Value) <> 0 Then
                h.Cells(7).Value = GetDoubleValue("Select Rate from lib_currency where Acronym = '" & h.Cells(6).Value & "'", "Rate")
            Else
                h.Cells(7).Value = 0
            End If

            If IsNumeric(h.Cells(3).Value) And IsNumeric(h.Cells(4).Value) Then
                h.Cells(5).Value = CDbl(h.Cells(3).Value) * CDbl(h.Cells(4).Value)
                dblBuying = dblBuying + CDbl(h.Cells(5).Value)
            Else
                h.Cells(5).Value = 0
            End If

            If IsNumeric(h.Cells(7).Value) And IsNumeric(h.Cells(8).Value) Then
                h.Cells(9).Value = CDbl(h.Cells(7).Value) * CDbl(h.Cells(8).Value)
                dblSelling = dblSelling + CDbl(h.Cells(9).Value)
            Else
                h.Cells(9).Value = 0
            End If
        Next

        Select Case str
            Case "OF"
                Me.txtBuyingOF.Text = Format(dblBuying, "n2")
                Me.txtSellingOF.Text = Format(dblSelling, "n2")
            Case "LC"
                Me.txtBuyingLC.Text = Format(dblBuying, "n2")
                Me.txtSellingLC.Text = Format(dblSelling, "n2")
            Case "CP"
                Me.txtBuyingCP.Text = Format(dblBuying, "n2")
                Me.txtSellingCP.Text = Format(dblSelling, "n2")
            Case "PL"
                Me.txtBuyingPL.Text = Format(dblBuying, "n2")
                Me.txtSellingPL.Text = Format(dblSelling, "n2")
        End Select



    End Sub

    Private Sub dgPickupLoading_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgPickupLoading.EditingControlShowing
        Dim tb As TextBox
        If dgPickupLoading.CurrentCell.ColumnIndex = 3 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgPickupLoading.CurrentCell.ColumnIndex = 4 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgPickupLoading.CurrentCell.ColumnIndex = 7 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgPickupLoading.CurrentCell.ColumnIndex = 8 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub

    Private Sub dgOceanFreight_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOceanFreight.CellContentClick

    End Sub

    Private Sub dgOceanFreight_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgOceanFreight.EditingControlShowing
        Dim tb As TextBox
        If dgOceanFreight.CurrentCell.ColumnIndex = 3 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgOceanFreight.CurrentCell.ColumnIndex = 4 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgOceanFreight.CurrentCell.ColumnIndex = 7 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgOceanFreight.CurrentCell.ColumnIndex = 8 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        SetCharacter(MyOption.Numeric, e)

    End Sub

    Private Sub dgLocalCharges_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgLocalCharges.CellContentClick

    End Sub

    Private Sub dgLocalCharges_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgLocalCharges.EditingControlShowing
        Dim tb As TextBox
        If dgLocalCharges.CurrentCell.ColumnIndex = 3 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgLocalCharges.CurrentCell.ColumnIndex = 4 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgLocalCharges.CurrentCell.ColumnIndex = 7 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgLocalCharges.CurrentCell.ColumnIndex = 8 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub

    Private Sub dgCustomsProcessing_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomsProcessing.CellContentClick

    End Sub

    Private Sub dgCustomsProcessing_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgCustomsProcessing.EditingControlShowing
        Dim tb As TextBox
        If dgCustomsProcessing.CurrentCell.ColumnIndex = 3 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgCustomsProcessing.CurrentCell.ColumnIndex = 4 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgCustomsProcessing.CurrentCell.ColumnIndex = 7 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If

        If dgCustomsProcessing.CurrentCell.ColumnIndex = 8 Then
            tb = CType(e.Control, TextBox)
            '---add an event handler to the TextBox control---
            AddHandler tb.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub

    Private Sub dgOceanFreight_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgOceanFreight.CellEndEdit
        ComputeTotal(Me.dgOceanFreight, "OF")
    End Sub

    Private Sub dgLocalCharges_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgLocalCharges.CellEndEdit
        ComputeTotal(Me.dgLocalCharges, "LC")
    End Sub

    Private Sub dgCustomsProcessing_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomsProcessing.CellEndEdit
        ComputeTotal(Me.dgCustomsProcessing, "CP")
    End Sub

    Private Sub dgPickupLoading_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickupLoading.CellEndEdit
        ComputeTotal(Me.dgPickupLoading, "PL")
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurrency.SelectedIndexChanged
        If Me.cboCurrency.SelectedIndex = -1 Then Exit Sub

        Me.txtExRate.Text = Format(GetDoubleValue("Select Rate from lib_currency where Acronym = '" & Me.cboCurrency.Text & "'", "Rate"), "n2")
        'Me.txtTotalAmountInPeso.Text = Format(CDbl(Me.txtExRate.Text) * CDbl(Me.txtTotalAmount.Text), "n2")

        Me.txtTotalAmountInPeso.Text = Format(CDbl(Me.txtSellingOF.Text) + CDbl(Me.txtSellingLC.Text) + CDbl(Me.txtSellingCP.Text) + CDbl(Me.txtSellingPL.Text), "n2")

        Me.txtTotalAmount.Text = CDbl(Me.txtTotalAmountInPeso.Text) / CDbl(Me.txtExRate.Text)
    End Sub

    Private Sub btAddDES_Click(sender As Object, e As EventArgs) Handles btAddDES.Click
        If Len(Me.cboDESPort2.Text) = 0 Then
            MsgBox("Please select Destination!", vbInformation, "System Message")
            Exit Sub
        End If

        If Me.dgRouting.Rows.Count = 0 Then
            Me.dgRouting.Rows.Add("", Me.cboOriginCountry.Text, "", Me.cboOriginPort.Text, "", "", "", Me.cboDESPort2.Text)
        Else
            Me.dgRouting.Rows.Add(Me.dgRouting.Rows(Me.dgRouting.Rows.Count - 1).Cells(4).Value, Me.dgRouting.Rows(Me.dgRouting.Rows.Count - 1).Cells(5).Value, Me.dgRouting.Rows(Me.dgRouting.Rows.Count - 1).Cells(6).Value, Me.dgRouting.Rows(Me.dgRouting.Rows.Count - 1).Cells(7).Value, "", "", "", Me.cboDESPort2.Text)
        End If
        Me.lblFromOrigin.Text = "From " & Me.cboDESPort2.Text & " To "
        Me.cboDESPort2.SelectedIndex = -1

        SetRouting(Me.dgRouting)
    End Sub

    Public Sub SetRouting(ByVal dg As DataGridView)
        'Me.txtDESCountry.Text = dg.Rows(dg.Rows.Count - 1).Cells(4).Value
        Me.cboDESCountry.Text = dg.Rows(dg.Rows.Count - 1).Cells(5).Value
        Me.txtDESPort.Text = dg.Rows(dg.Rows.Count - 1).Cells(6).Value
        Me.cboDESPort.Text = dg.Rows(dg.Rows.Count - 1).Cells(7).Value
        Me.cboDESCountry.Text = GetStringValue("Select Description from lib_country where PK = " & GetIntegerValue("Select Country_PK from lib_port where Description = '" & Me.cboDESPort.Text & "'", "Country_PK") & "", "Description")

        Dim i As Integer = 0
        Dim h As DataGridViewRow
        Dim Routing As String = ""

        For i = 0 To dg.Rows.Count - 1
            h = dg.Rows(i)

            Routing = Routing & " - " & h.Cells(7).Value

            If i = dg.Rows.Count - 1 Then
                h.DefaultCellStyle.BackColor = Color.Gray
            Else
                h.DefaultCellStyle.BackColor = Color.White
            End If

        Next
        Me.lblTranshipment.Text = Me.cboOriginPort.Text & Routing
        'GetComboBoxFields(Me.cboDESPort2, "DESTPortDesc", "v_ratelibrary", "ORG_Port = " & Me.dgRouting.Rows(Me.dgRouting.Rows.Count - 1).Cells(6).Value & "")

    End Sub

    Private Sub cboOriginCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOriginCountry.SelectedIndexChanged
        If Me.cboOriginCountry.SelectedIndex = -1 Then Exit Sub
        Dim intCountryPK As Integer = GetIntegerValue("Select PK from lib_country where Description = '" & Me.cboOriginCountry.Text & "'", "PK")

        FillComboBox(Me.cboOriginPort, "Select Description from lib_port where Country_PK = " & intCountryPK & "", "Description")
    End Sub

    Private Sub cboOriginPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOriginPort.SelectedIndexChanged
        If Me.cboOriginPort.SelectedIndex = -1 Then Exit Sub

        If Me.dgRouting.Rows.Count = 0 Then
            Me.lblFromOrigin.Text = "From " & Me.cboOriginPort.Text & " To "
        End If
    End Sub

    Private Sub cboDESCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDESCountry.SelectedIndexChanged
        If Me.cboDESCountry.SelectedIndex = -1 Then Exit Sub
        Dim intCountryPK As Integer = GetIntegerValue("Select PK from lib_country where Description = '" & Me.cboDESCountry.Text & "'", "PK")

        FillComboBox(Me.cboDESPort, "Select Description from lib_port where Country_PK = " & intCountryPK & "", "Description")
    End Sub

    Private Sub cboDESPort2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDESPort2.SelectedIndexChanged

    End Sub

    Private Sub txtCBM_TextChanged(sender As Object, e As EventArgs) Handles txtCBM.TextChanged

    End Sub

    Private Sub txtCBM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCBM.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txtWeight_TextChanged(sender As Object, e As EventArgs) Handles txtWeight.TextChanged

    End Sub

    Private Sub txtWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWeight.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub dgContainer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgContainer.CellContentClick

    End Sub

    Public Function SetContainerGrid() As String
        SetContainerGrid = ""
        Dim i As Integer = 0
        Dim h As DataGridViewRow
        Dim str20FT As String = ""
        Dim str40FT As String = ""
        Dim str40HC As String = ""

        For i = 0 To Me.dgContainer.Rows.Count - 1
            h = Me.dgContainer.Rows(i)

            If Len(h.Cells(1).Value) <> 0 Then
                If Len(h.Cells(0).Value) <> 0 Then
                    Select Case h.Cells(1).Value
                        Case "20FT"
                            str20FT = h.Cells(0).Value & "x" & h.Cells(1).Value
                        Case "40FT"
                            str40FT = h.Cells(0).Value & "x" & h.Cells(1).Value
                        Case "40HC"
                            str40HC = h.Cells(0).Value & "x" & h.Cells(1).Value
                    End Select
                End If
            End If

        Next

        SetContainerGrid = str20FT & " " & str40FT & " " & str40HC
    End Function

    Private Sub dgContainer_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgContainer.CellEndEdit
        Me.txtContainer.Text = SetContainerGrid()
    End Sub
End Class