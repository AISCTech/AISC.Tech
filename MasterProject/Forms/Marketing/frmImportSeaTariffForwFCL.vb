Imports MySql.Data.MySqlClient
Public Class frmImportSeaTariffForwFCL
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

            Me.cboChargeName.Enabled = blUserInput
            Me.txtPrice20FT.ReadOnly = Not blUserInput
            Me.cboUOM20FT.Enabled = blUserInput
            Me.cboCurrency20FT.Enabled = blUserInput
            Me.txtPrice40FT.ReadOnly = Not blUserInput
            Me.cboUOM40FT.Enabled = blUserInput
            Me.cboCurrency40FT.Enabled = blUserInput
            Me.txtPrice20FTS.ReadOnly = Not blUserInput
            Me.cboUOM20FTS.Enabled = blUserInput
            Me.cboCurrency20FTS.Enabled = blUserInput
            Me.txtPrice40FTS.ReadOnly = Not blUserInput
            Me.cboUOM40FTS.Enabled = blUserInput
            Me.cboCurrency40FTS.Enabled = blUserInput
            Me.txtRemarks.ReadOnly = Not blUserInput
            Me.cboShippingLine.Enabled = blUserInput
            Me.cboType.Enabled = blUserInput
            .UpdateEnabledButtons()
        End With
    End Sub
    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Are you sure you want to create new record?", vbYesNo, "Create New?") = vbNo Then Exit Sub

        ClearEntries()
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        'Throw New NotImplementedException()
        ClearEntries()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckForRequiredEntries() = False Then Exit Sub

        If MsgBox("Are you sure you want to save this record?", vbYesNo, "Confirm Save?") = vbNo Then Exit Sub

        SaveTariff()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub

    Private Sub frmImportSeaTariffForwFCL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBox(Me.cboChargeName, "Select ChargeName from lib_charges where F = 1", "ChargeName")
        FillComboBox(Me.cboCurrency20FT, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillComboBox(Me.cboUOM20FT, "Select Unit from lib_uom where Unit is not null", "Unit")
        FillComboBox(Me.cboCurrency40FT, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillComboBox(Me.cboUOM40FT, "Select Unit from lib_uom where Unit is not null", "Unit")
        FillComboBox(Me.cboCurrency20FTS, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillComboBox(Me.cboUOM20FTS, "Select Unit from lib_uom where Unit is not null", "Unit")
        FillComboBox(Me.cboCurrency40FTS, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillComboBox(Me.cboUOM40FTS, "Select Unit from lib_uom where Unit is not null", "Unit")
        FillComboBox(Me.cboDirectPort, "Select Description from lib_port where Description is not null", "Description")
        FillComboBox(Me.cboTranshipmentPort, "Select Description from lib_port where Description is not null", "Description")
        FillComboBox(Me.cboTranshipmentFinalDest, "Select Description from lib_port where Description is not null", "Description")
        FillComboBox(Me.cboType, "Select Description from tbl_salesquotationchargestype where Description is not null", "Description")
        'shipping line combobox
        FillComboBox(Me.cboShippingLine, "Select Description from tbl_vendor INNER JOIN tbl_vendortype ON tbl_vendor.Code = tbl_vendortype.Vendor_Code WHERE tbl_vendortype.Params_Code = 2", "Description")
        ClearEntries()
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        PopTariff(Me.dgTariff)
    End Sub

    Public Sub SearchTariff(ByVal str As String)
        ClearEntries()
        Dim cnn As New MySqlConnection(strDBMaster)
        Dim strSQL As String

        strSQL = "SELECT * " &
                     "FROM tbl_impsea_tariff_fcl_forw where PK = '" & str & "'"


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
            Dim strDirectTranshipment As String = ""

            Select Case reader.Item("DirectTranshipment")
                Case "D"
                    Me.optDirect.Checked = True
                    Me.cboTranshipmentPort.SelectedIndex = -1
                    Me.cboTranshipmentFinalDest.SelectedIndex = -1
                    Me.cboDirectPort.Text = reader.Item("DirectPort")
                Case "T"
                    Me.optTranshipment.Checked = True
                    Me.cboDirectPort.SelectedIndex = -1
                    Me.cboTranshipmentPort.Text = reader.Item("TranshipmentPort")
                    Me.cboTranshipmentFinalDest.Text = reader.Item("TranshipmentFinalDest")
            End Select

            Me.txtPK.Text = reader.Item("PK")
            Me.txtChargeCode.Text = reader.Item("ChargeCode")
            Me.cboChargeName.Text = reader.Item("ChargeDesc")
            Me.txtShippingLineCode.Text = reader.Item("ShippingLineCode")
            Me.cboShippingLine.Text = reader.Item("ShippingLineName")
            Me.txtPrice20FT.Text = Format(reader.Item("Price20FT"), "n2")
            Me.cboUOM20FT.Text = reader.Item("UOM20FT")
            Me.cboCurrency20FT.Text = reader.Item("Currency20FT")
            Me.txtPrice40FT.Text = Format(reader.Item("Price40FT"), "n2")
            Me.cboUOM40FT.Text = reader.Item("UOM40FT")
            Me.cboCurrency40FT.Text = reader.Item("Currency40FT")

            Me.txtPrice20FTS.Text = Format(reader.Item("SellingPrice20FT"), "n2")
            Me.cboUOM20FTS.Text = reader.Item("SellingUOM20FT")
            Me.cboCurrency20FTS.Text = reader.Item("SellingCurrency20FT")
            Me.txtPrice40FTS.Text = Format(reader.Item("SellingPrice40FT"), "n2")
            Me.cboUOM40FTS.Text = reader.Item("SellingUOM40FT")
            Me.cboCurrency40FTS.Text = reader.Item("SellingCurrency40FT")

            Me.cboType.Text = reader.Item("Type")
            Me.txtRemarks.Text = reader.Item("Remarks")

            Me.tstripEncodedBy.Text = reader.Item("EncodedBy")
            Me.tstripEncodedDate.Text = Format(reader.Item("EncodedDate"), "yyyy-MM-dd hh:mm:ss")
            Me.tstripModifiedBy.Text = reader.Item("ModifiedBy")
            Me.tstripModifiedDate.Text = Format(reader.Item("ModifiedDate"), "yyyy-MM-dd hh:mm:ss")


        End While
        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Sub

    Public Sub ClearEntries()
        Me.txtPK.Text = ""
        Me.txtChargeCode.Text = ""
        Me.cboChargeName.SelectedIndex = -1
        Me.optDirect.Checked = True
        Me.cboDirectPort.Enabled = True
        Me.cboTranshipmentPort.Enabled = False
        Me.cboTranshipmentFinalDest.Enabled = False
        Me.optTranshipment.Checked = False
        Me.cboDirectPort.SelectedIndex = -1
        Me.cboTranshipmentPort.SelectedIndex = -1
        Me.cboTranshipmentFinalDest.SelectedIndex = -1
        Me.txtPrice20FT.Text = 0
        Me.cboUOM20FT.SelectedIndex = -1
        Me.cboCurrency20FT.SelectedIndex = -1
        Me.txtPrice40FT.Text = 0
        Me.cboUOM40FT.SelectedIndex = -1
        Me.cboCurrency40FT.SelectedIndex = -1
        Me.txtPrice20FTS.Text = 0
        Me.cboUOM20FTS.SelectedIndex = -1
        Me.cboCurrency20FTS.SelectedIndex = -1
        Me.txtPrice40FTS.Text = 0
        Me.cboUOM40FTS.SelectedIndex = -1
        Me.cboCurrency40FTS.SelectedIndex = -1
        Me.txtRemarks.Text = ""
        Me.txtShippingLineCode.Text = ""
        Me.cboShippingLine.SelectedIndex = -1
        Me.cboType.SelectedIndex = -1
    End Sub

    Public Function CheckForRequiredEntries() As Boolean
        ErrorProvider1.Clear()

        If Me.cboChargeName.SelectedIndex = -1 Then
            MsgBox("Please select Charge Name!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboChargeName, "Missing Information")
            Exit Function
        End If

        If Me.optDirect.Checked = True Then
            If Me.cboDirectPort.SelectedIndex = -1 Then
                MsgBox("Please select Direct Port!", vbInformation, "Missing Information")
                CheckForRequiredEntries = False
                ErrorProvider1.SetError(Me.cboDirectPort, "Missing Information")
                Exit Function
            End If
        End If

        If Me.optTranshipment.Checked = True Then
            If Me.cboTranshipmentPort.SelectedIndex = -1 Then
                MsgBox("Please select Transhipment Port!", vbInformation, "Missing Information")
                CheckForRequiredEntries = False
                ErrorProvider1.SetError(Me.cboTranshipmentPort, "Missing Information")
                Exit Function
            End If

            If Me.cboTranshipmentFinalDest.SelectedIndex = -1 Then
                MsgBox("Please select Transhipment Final Destination!", vbInformation, "Missing Information")
                CheckForRequiredEntries = False
                ErrorProvider1.SetError(Me.cboTranshipmentFinalDest, "Missing Information")
                Exit Function
            End If
        End If

        If Me.cboType.SelectedIndex = -1 Then
            MsgBox("Please select Type!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboType, "Missing Information")
            Exit Function
        End If

        If Len(Me.txtPrice20FT.Text) = 0 Then
            MsgBox("Please input Buying Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice20FT, "Missing Information")
            Exit Function
        End If

        If CDbl(Me.txtPrice20FT.Text) = 0 Then
            MsgBox("Please input Buying Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice20FT, "Missing Information")
            Exit Function
        End If

        If Me.cboUOM20FT.SelectedIndex = -1 Then
            MsgBox("Please select Buying Unit Of Measurement!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboUOM20FT, "Missing Information")
            Exit Function
        End If

        If Me.cboCurrency20FT.SelectedIndex = -1 Then
            MsgBox("Please select Buying Currency!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboCurrency20FT, "Missing Information")
            Exit Function
        End If

        If Len(Me.txtPrice40FT.Text) = 0 Then
            MsgBox("Please input Buying Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice40FT, "Missing Information")
            Exit Function
        End If

        If CDbl(Me.txtPrice40FT.Text) = 0 Then
            MsgBox("Please input Buying Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice40FT, "Missing Information")
            Exit Function
        End If

        If Me.cboUOM40FT.SelectedIndex = -1 Then
            MsgBox("Please select Buying Unit Of Measurement!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboUOM40FT, "Missing Information")
            Exit Function
        End If

        If Me.cboCurrency40FT.SelectedIndex = -1 Then
            MsgBox("Please select Buying Currency!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboCurrency40FT, "Missing Information")
            Exit Function
        End If

        If Len(Me.txtPrice20FTS.Text) = 0 Then
            MsgBox("Please input Selling Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice20FTS, "Missing Information")
            Exit Function
        End If

        If CDbl(Me.txtPrice20FTS.Text) = 0 Then
            MsgBox("Please input Selling Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice20FTS, "Missing Information")
            Exit Function
        End If

        If Me.cboUOM20FTS.SelectedIndex = -1 Then
            MsgBox("Please select Selling Unit Of Measurement!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboUOM20FTS, "Missing Information")
            Exit Function
        End If

        If Me.cboCurrency20FTS.SelectedIndex = -1 Then
            MsgBox("Please select Selling Currency!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboCurrency20FTS, "Missing Information")
            Exit Function
        End If

        If Len(Me.txtPrice40FTS.Text) = 0 Then
            MsgBox("Please input Selling Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice40FTS, "Missing Information")
            Exit Function
        End If

        If CDbl(Me.txtPrice40FTS.Text) = 0 Then
            MsgBox("Please input Selling Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice40FTS, "Missing Information")
            Exit Function
        End If

        If Me.cboUOM40FTS.SelectedIndex = -1 Then
            MsgBox("Please select Selling Unit Of Measurement!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboUOM40FTS, "Missing Information")
            Exit Function
        End If

        If Me.cboCurrency40FTS.SelectedIndex = -1 Then
            MsgBox("Please select Selling Currency!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboCurrency40FTS, "Missing Information")
            Exit Function
        End If


        If Len(Me.txtRemarks.Text) = 0 Then
            MsgBox("Please input Remarks!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtRemarks, "Missing Information")
            Exit Function
        End If

        If Me.cboShippingLine.SelectedIndex = -1 Then
            MsgBox("Please select Shipping Line!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboShippingLine, "Missing Information")
            Exit Function
        End If

        CheckForRequiredEntries = True
    End Function

    Public Sub SaveTariff()
        Dim cmdSQL As New MySqlCommand
        Dim dtCurrent As Date
        'script to get the current date of MYSQL Server
        dtCurrent = GetServerDate()

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        If Len(Me.txtPK.Text) = 0 Then

            Try
                cmdSQL.CommandText = ("INSERT INTO tbl_impsea_tariff_fcl_forw (`PK`, `ChargeCode`, `ChargeDesc`, `DirectTranshipment`, `TranshipmentPort`, `TranshipmentFinalDest`, `DirectPort`, `ShippingLineCode`, `ShippingLineName`, `Price20FT`, `UOM20FT`, `Currency20FT`, `Price40FT`, `UOM40FT`, `Currency40FT`, `SellingPrice20FT`, `SellingUOM20FT`, `SellingCurrency20FT`, `SellingPrice40FT`, `SellingUOM40FT`, `SellingCurrency40FT`, `Type`, `Remarks`, `EncodedBy`, `EncodedDate`, `ModifiedBy`, `ModifiedDate`)  VALUES " &
                                     "               (@PK, @ChargeCode, @ChargeDesc, @DirectTranshipment, @TranshipmentPort, @TranshipmentFinalDest, @DirectPort, @ShippingLineCode, @ShippingLineName, @Price20FT, @UOM20FT, @Currency20FT, @Price40FT, @UOM40FT, @Currency40FT, @SellingPrice20FT, @SellingUOM20FT, @SellingCurrency20FT, @SellingPrice40FT, @SellingUOM40FT, @SellingCurrency40FT, @Type,  @Remarks, @EncodedBy, @EncodedDate, @ModifiedBy, @ModifiedDate)")


                With cmdSQL.Parameters
                    Dim strPK As String = "108" & GetCtrlNbr(strCompanyCode, strSiteCode, "Charges_ImpSea_FCL")

                    If Len(strPK) = 0 Then
                        MsgBox("Error getting control number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@PK", strPK)
                    .AddWithValue("@ChargeCode", Me.txtChargeCode.Text)
                    .AddWithValue("@ChargeDesc", Me.cboChargeName.Text)
                    If Me.optDirect.Checked = True Then
                        .AddWithValue("@DirectTranshipment", "D")
                    End If
                    If Me.optTranshipment.Checked = True Then
                        .AddWithValue("@DirectTranshipment", "T")
                    End If
                    .AddWithValue("@TranshipmentPort", Me.cboTranshipmentPort.Text)
                    .AddWithValue("@TranshipmentFinalDest", Me.cboTranshipmentFinalDest.Text)
                    .AddWithValue("@DirectPort", Me.cboDirectPort.Text)
                    .AddWithValue("@ShippingLineCode", Me.txtShippingLineCode.Text)
                    .AddWithValue("@ShippingLineName", Me.cboShippingLine.Text)
                    .AddWithValue("@Price20FT", CDbl(Me.txtPrice20FT.Text))
                    .AddWithValue("@UOM20FT", Me.cboUOM20FT.Text)
                    .AddWithValue("@Currency20FT", Me.cboCurrency20FT.Text)
                    .AddWithValue("@Price40FT", CDbl(Me.txtPrice40FT.Text))
                    .AddWithValue("@UOM40FT", Me.cboUOM40FT.Text)
                    .AddWithValue("@Currency40FT", Me.cboCurrency40FT.Text)
                    .AddWithValue("@SellingPrice20FT", CDbl(Me.txtPrice20FTS.Text))
                    .AddWithValue("@SellingUOM20FT", Me.cboUOM20FTS.Text)
                    .AddWithValue("@SellingCurrency20FT", Me.cboCurrency20FTS.Text)
                    .AddWithValue("@SellingPrice40FT", CDbl(Me.txtPrice40FTS.Text))
                    .AddWithValue("@SellingUOM40FT", Me.cboUOM40FTS.Text)
                    .AddWithValue("@SellingCurrency40FT", Me.cboCurrency40FTS.Text)
                    .AddWithValue("@Type", Me.cboType.Text)
                    .AddWithValue("@Remarks", Me.txtRemarks.Text)
                    .AddWithValue("@EncodedDate", dtCurrent)
                    .AddWithValue("@EncodedBy", strCurrentUser)
                    .AddWithValue("@ModifiedDate", dtCurrent)
                    .AddWithValue("@ModifiedBy", strCurrentUser)
                    Me.txtPK.Text = strPK
                    Me.tstripEncodedBy.Text = strCurrentUser
                    Me.tstripEncodedDate.Text = Format(dtCurrent, "yyyy-MM-dd hhmm : ss")
                    Me.tstripModifiedBy.Text = strCurrentUser
                    Me.tstripModifiedDate.Text = Format(dtCurrent, "yyyy-MM-dd hh: mm : ss")
                End With

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()

            Catch ex As Exception
                MsgBox("There was an Error trying To save the record - " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Charges_ImpSea_FCL")

            MsgBox("Record Successfully Saved!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            'save transaction log
            SaveTransLogs("Create New", Me.Name, "Tariff Rate ImpSeaFCL Forw", Me.txtPK.Text, strCurrentUser)

        Else
            'update record

            Dim sSQL As String = "UPDATE tbl_impsea_tariff_lcl_forw Set "
            sSQL += " ChargeCode=@ChargeCode, "
            sSQL += " ChargeDesc=@ChargeDesc, "
            sSQL += " DirectTranshipment=@DirectTranshipment, "
            sSQL += " TranshipmentPort=@TranshipmentPort, "
            sSQL += " TranshipmentFinalDest=@TranshipmentFinalDest, "
            sSQL += " DirectPort=@DirectPort, "
            sSQL += " ShippingLineCode=@ShippingLineCode, "
            sSQL += " ShippingLineName=@ShippingLineName, "
            sSQL += " Price20FT=@Price20FT, "
            sSQL += " UOM20FT=@UOM20FT, "
            sSQL += " Currency20FT=@Currency20FT, "
            sSQL += " Price40FT=@Price40FT, "
            sSQL += " UOM40FT=@UOM40FT, "
            sSQL += " Currency40FT=@Currency40FT, "
            sSQL += " SellingPrice20FT=@SellingPrice20FT, "
            sSQL += " SellingUOM20FT=@SellingUOM20FT, "
            sSQL += " SellingCurrency20FT=@SellingCurrency20FT, "
            sSQL += " SellingPrice40FT=@SellingPrice40FT, "
            sSQL += " SellingUOM40FT=@SellingUOM40FT, "
            sSQL += " SellingCurrency40FT=@SellingCurrency40FT, "
            sSQL += " Type=@Type, "
            sSQL += " Remarks=@Remarks, "
            sSQL += " ModifiedDate=@ModifiedDate, "
            sSQL += " ModifiedBy=@ModifiedBy "
            sSQL += " WHERE PK= '" & Me.txtPK.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@ChargeCode", Me.txtChargeCode.Text)
                .AddWithValue("@ChargeDesc", Me.cboChargeName.Text)
                If Me.optDirect.Checked = True Then
                    .AddWithValue("@DirectTranshipment", "D")
                End If
                If Me.optTranshipment.Checked = True Then
                    .AddWithValue("@DirectTranshipment", "T")
                End If
                .AddWithValue("@TranshipmentPort", Me.cboTranshipmentPort.Text)
                .AddWithValue("@TranshipmentFinalDest", Me.cboTranshipmentFinalDest.Text)
                .AddWithValue("@DirectPort", Me.cboDirectPort.Text)
                .AddWithValue("@ShippingLineCode", Me.txtShippingLineCode.Text)
                .AddWithValue("@ShippingLineName", Me.cboShippingLine.Text)
                .AddWithValue("@Price20FT", CDbl(Me.txtPrice20FT.Text))
                .AddWithValue("@UOM20FT", Me.cboUOM20FT.Text)
                .AddWithValue("@Currency20FT", Me.cboCurrency20FT.Text)
                .AddWithValue("@Price40FT", CDbl(Me.txtPrice40FT.Text))
                .AddWithValue("@UOM40FT", Me.cboUOM40FT.Text)
                .AddWithValue("@Currency40FT", Me.cboCurrency40FT.Text)
                .AddWithValue("@SellingPrice20FT", CDbl(Me.txtPrice20FTS.Text))
                .AddWithValue("@SellingUOM20FT", Me.cboUOM20FTS.Text)
                .AddWithValue("@SellingCurrency20FT", Me.cboCurrency20FTS.Text)
                .AddWithValue("@SellingPrice40FT", CDbl(Me.txtPrice40FTS.Text))
                .AddWithValue("@SellingUOM40FT", Me.cboUOM40FTS.Text)
                .AddWithValue("@SellingCurrency40FT", Me.cboCurrency40FTS.Text)
                .AddWithValue("@Type", Me.cboType.Text)
                .AddWithValue("@Remarks", Me.txtRemarks.Text)
                .AddWithValue("@ModifiedDate", dtCurrent)
                .AddWithValue("@ModifiedBy", strCurrentUser)
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            MsgBox("Record " & Me.txtPK.Text & " Successfully Updated!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            Me.tstripModifiedBy.Text = strCurrentUser
            Me.tstripModifiedDate.Text = Format(dtCurrent, "yyyy-MM-dd hh:mm:ss")
            SaveTransLogs("Edit Record", Me.Name, "Tariff Rate ImpSeaFCL Forw", Me.txtPK.Text, strCurrentUser)
        End If

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()

        PopTariff(Me.dgTariff)
    End Sub

    Public Sub PopTariff(ByVal dg As DataGridView)
        dg.Rows.Clear()
        Dim cnn As New MySqlConnection(strDBMaster)
        Dim strSQL As String

        strSQL = "SELECT * " &
                     "FROM tbl_impsea_tariff_fcl_forw"


        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        While reader.Read
            Dim strDirectTranshipment As String = ""

            Select Case reader.Item("DirectTranshipment")
                Case "D"
                    strDirectTranshipment = "Direct"
                Case "T"
                    strDirectTranshipment = "Transhipment"
            End Select

            dg.Rows.Add(reader.Item("PK"), reader.Item("ChargeCode"), reader.Item("ChargeDesc"), strDirectTranshipment, reader.Item("TranshipmentPort"), reader.Item("TranshipmentFinalDest"), reader.Item("DirectPort"), reader.Item("ShippingLineCode"), reader.Item("ShippingLineName"), Format(reader.Item("Price20FT"), "n2"), reader.Item("UOM20FT"), reader.Item("Currency20FT"), Format(reader.Item("Price40FT"), "n2"), reader.Item("UOM40FT"), reader.Item("Currency40FT"), Format(reader.Item("SellingPrice20FT"), "n2"), reader.Item("SellingUOM20FT"), reader.Item("SellingCurrency20FT"), Format(reader.Item("SellingPrice40FT"), "n2"), reader.Item("SellingUOM40FT"), reader.Item("SellingCurrency40FT"), reader.Item("Remarks"))

        End While
        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Sub

    Private Sub frmImportSeaTariffForwFCL_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub optDirect_Click(sender As Object, e As EventArgs) Handles optDirect.Click
        If Me.optDirect.Checked = True Then
            Me.cboTranshipmentPort.SelectedIndex = -1
            Me.cboTranshipmentPort.Enabled = False
            Me.cboTranshipmentFinalDest.SelectedIndex = -1
            Me.cboTranshipmentFinalDest.Enabled = False
            Me.cboDirectPort.Enabled = True
        End If
    End Sub

    Private Sub optTranshipment_CheckedChanged(sender As Object, e As EventArgs) Handles optTranshipment.CheckedChanged

    End Sub

    Private Sub optTranshipment_Click(sender As Object, e As EventArgs) Handles optTranshipment.Click
        If Me.optTranshipment.Checked = True Then
            Me.cboDirectPort.SelectedIndex = -1
            Me.cboDirectPort.Enabled = False
            Me.cboTranshipmentPort.Enabled = True
            Me.cboTranshipmentFinalDest.Enabled = True
        End If
    End Sub

    Private Sub cboChargeName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChargeName.SelectedIndexChanged
        If Me.cboChargeName.SelectedIndex = -1 Then Exit Sub

        Me.txtChargeCode.Text = GetStringValue("Select ChargeCode from lib_charges where ChargeName = '" & Me.cboChargeName.Text & "'", "ChargeCode")

    End Sub

    Private Sub dgTariff_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTariff.CellContentClick

    End Sub

    Private Sub dgTariff_Click(sender As Object, e As EventArgs) Handles dgTariff.Click
        If Me.dgTariff.Rows.Count = 0 Then Exit Sub

        SearchTariff(Me.dgTariff.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub cboShippingLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShippingLine.SelectedIndexChanged
        If Me.cboShippingLine.SelectedIndex = -1 Then Exit Sub

        Me.txtShippingLineCode.Text = GetStringValue("Select Code from tbl_vendor where Description = '" & Me.cboShippingLine.Text & "'", "Code")
    End Sub

    Private Sub txtPrice20FT_TextChanged(sender As Object, e As EventArgs) Handles txtPrice20FT.TextChanged

    End Sub

    Private Sub txtPrice20FT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice20FT.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txtPrice40FT_TextChanged(sender As Object, e As EventArgs) Handles txtPrice40FT.TextChanged

    End Sub

    Private Sub txtPrice40FT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice40FT.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txtPrice20FTS_TextChanged(sender As Object, e As EventArgs) Handles txtPrice20FTS.TextChanged

    End Sub

    Private Sub txtPrice20FTS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice20FTS.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txtPrice40FTS_TextChanged(sender As Object, e As EventArgs) Handles txtPrice40FTS.TextChanged

    End Sub

    Private Sub txtPrice40FTS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice40FTS.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub
End Class