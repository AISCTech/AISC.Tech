Imports MasterProject
Imports MySql.Data.MySqlClient
Public Class frmImportSeaTariffForwLCL
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
            Me.txtPrice.ReadOnly = Not blUserInput
            Me.cboUOM.Enabled = blUserInput
            Me.cboCurrency.Enabled = blUserInput
            Me.txtPriceS.ReadOnly = Not blUserInput
            Me.cboUOMS.Enabled = blUserInput
            Me.cboCurrencyS.Enabled = blUserInput
            Me.txtRemarks.ReadOnly = Not blUserInput
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
        Throw New NotImplementedException()
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckForRequiredEntries() = False Then Exit Sub

        If MsgBox("Are you sure you want to save this record?", vbYesNo, "Confirm Save?") = vbNo Then Exit Sub

        SaveTariff()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub
    Private Sub frmImportSeaTariffForwLCL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBox(Me.cboChargeName, "Select ChargeName from lib_charges where F = 1", "ChargeName")
        FillComboBox(Me.cboCurrency, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillComboBox(Me.cboUOM, "Select Unit from lib_uom where Unit is not null", "Unit")
        FillComboBox(Me.cboCurrencyS, "Select Acronym from lib_currency where Acronym is not null", "Acronym")
        FillComboBox(Me.cboUOMS, "Select Unit from lib_uom where Unit is not null", "Unit")
        FillComboBox(Me.cboDirectPort, "Select Description from lib_port where Description is not null", "Description")
        FillComboBox(Me.cboTranshipmentPort, "Select Description from lib_port where Description is not null", "Description")
        FillComboBox(Me.cboTranshipmentFinalDest, "Select Description from lib_port where Description is not null", "Description")
        ClearEntries()
        FillComboBox(Me.cboType, "Select Description from tbl_salesquotationchargestype where Description is not null", "Description")
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        PopTariff(Me.dgTariff)
    End Sub

    Public Sub SearchTariff(ByVal str As String)
        ClearEntries()
        Dim cnn As New MySqlConnection(strDBMaster)
        Dim strSQL As String

        strSQL = "SELECT * " &
                     "FROM tbl_impsea_tariff_lcl_forw where PK = '" & str & "'"


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
            Me.txtPrice.Text = Format(reader.Item("Price"), "n2")
            Me.cboUOM.Text = reader.Item("UOM")
            Me.cboCurrency.Text = reader.Item("Currency")
            Me.txtPriceS.Text = Format(reader.Item("SellingPrice"), "n2")
            Me.cboUOMS.Text = reader.Item("SellingUOM")
            Me.cboCurrencyS.Text = reader.Item("SellingCurrency")
            Me.txtRemarks.Text = reader.Item("Remarks")
            Me.cboType.Text = reader.Item("Type")
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
        Me.txtPrice.Text = 0
        Me.cboUOM.SelectedIndex = -1
        Me.cboCurrency.SelectedIndex = -1
        Me.txtPriceS.Text = 0
        Me.cboUOMS.SelectedIndex = -1
        Me.cboCurrencyS.SelectedIndex = -1
        Me.txtRemarks.Text = ""
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

        If Len(Me.txtPrice.Text) = 0 Then
            MsgBox("Please input Buying Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice, "Missing Information")
            Exit Function
        End If

        If CDbl(Me.txtPrice.Text) = 0 Then
            MsgBox("Please input Buying Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPrice, "Missing Information")
            Exit Function
        End If

        If Me.cboUOM.SelectedIndex = -1 Then
            MsgBox("Please select Buying Unit Of Measurement!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboUOM, "Missing Information")
            Exit Function
        End If

        If Me.cboCurrency.SelectedIndex = -1 Then
            MsgBox("Please select Buying Currency!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboCurrency, "Missing Information")
            Exit Function
        End If

        If Len(Me.txtPriceS.Text) = 0 Then
            MsgBox("Please input Selling Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPriceS, "Missing Information")
            Exit Function
        End If

        If CDbl(Me.txtPriceS.Text) = 0 Then
            MsgBox("Please input Selling Price!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtPriceS, "Missing Information")
            Exit Function
        End If

        If Me.cboUOMS.SelectedIndex = -1 Then
            MsgBox("Please select Selling Unit Of Measurement!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboUOMS, "Missing Information")
            Exit Function
        End If

        If Me.cboCurrencyS.SelectedIndex = -1 Then
            MsgBox("Please select Selling Currency!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.cboCurrencyS, "Missing Information")
            Exit Function
        End If

        If Len(Me.txtRemarks.Text) = 0 Then
            MsgBox("Please input Remarks!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            ErrorProvider1.SetError(Me.txtRemarks, "Missing Information")
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
                cmdSQL.CommandText = ("INSERT INTO tbl_impsea_tariff_lcl_forw (`PK`, `ChargeCode`, `ChargeDesc`, `DirectTranshipment`, `TranshipmentPort`, `TranshipmentFinalDest`, `DirectPort`, `Price`, `UOM`, `Currency`, `SellingPrice`, `SellingUOM`, `SellingCurrency`, `Type`, `Remarks`, `EncodedBy`, `EncodedDate`, `ModifiedBy`, `ModifiedDate`)  VALUES " &
                                     "               (@PK, @ChargeCode, @ChargeDesc, @DirectTranshipment, @TranshipmentPort, @TranshipmentFinalDest, @DirectPort, @Price, @UOM, @Currency, @SellingPrice, @SellingUOM, @SellingCurrency, @Type, @Remarks, @EncodedBy, @EncodedDate, @ModifiedBy, @ModifiedDate)")


                With cmdSQL.Parameters
                    Dim strPK As String = "104" & GetCtrlNbr(strCompanyCode, strSiteCode, "Charges_ImpSea_LCL")

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
                    .AddWithValue("@Price", CDbl(Me.txtPrice.Text))
                    .AddWithValue("@UOM", Me.cboUOM.Text)
                    .AddWithValue("@Currency", Me.cboCurrency.Text)
                    .AddWithValue("@SellingPrice", CDbl(Me.txtPriceS.Text))
                    .AddWithValue("@SellingUOM", Me.cboUOMS.Text)
                    .AddWithValue("@SellingCurrency", Me.cboCurrencyS.Text)
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

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "Charges_ImpSea_LCL")

            MsgBox("Record Successfully Saved!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            'save transaction log
            SaveTransLogs("Create New", Me.Name, "Tariff Rate ImpSeaLCL Forw", Me.txtPK.Text, strCurrentUser)

        Else
            'update record

            Dim sSQL As String = "UPDATE tbl_impsea_tariff_lcl_forw Set "
            sSQL += " ChargeCode=@ChargeCode, "
            sSQL += " ChargeDesc=@ChargeDesc, "
            sSQL += " DirectTranshipment=@DirectTranshipment, "
            sSQL += " TranshipmentPort=@TranshipmentPort, "
            sSQL += " TranshipmentFinalDest=@TranshipmentFinalDest, "
            sSQL += " DirectPort=@DirectPort, "
            sSQL += " Price=@Price, "
            sSQL += " UOM=@UOM, "
            sSQL += " Currency=@Currency, "
            sSQL += " SellingPrice=@SellingPrice, "
            sSQL += " SellingUOM=@SellingUOM, "
            sSQL += " SellingCurrency=@SellingCurrency, "
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
                .AddWithValue("@Price", CDbl(Me.txtPrice.Text))
                .AddWithValue("@UOM", Me.cboUOM.Text)
                .AddWithValue("@Currency", Me.cboCurrency.Text)
                .AddWithValue("@SellingPrice", CDbl(Me.txtPriceS.Text))
                .AddWithValue("@SellingUOM", Me.cboUOMS.Text)
                .AddWithValue("@SellingCurrency", Me.cboCurrencyS.Text)
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
            SaveTransLogs("Edit Record", Me.Name, "Tariff Rate ImpSeaLCL Forw", Me.txtPK.Text, strCurrentUser)
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
                     "FROM tbl_impsea_tariff_lcl_forw"


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

            dg.Rows.Add(reader.Item("PK"), reader.Item("ChargeCode"), reader.Item("ChargeDesc"), strDirectTranshipment, reader.Item("TranshipmentPort"), reader.Item("TranshipmentFinalDest"), reader.Item("DirectPort"), Format(reader.Item("Price"), "n2"), reader.Item("UOM"), reader.Item("Currency"), Format(reader.Item("SellingPrice"), "n2"), reader.Item("SellingUOM"), reader.Item("SellingCurrency"), reader.Item("Remarks"))

        End While
        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Sub

    Private Sub frmImportSeaTariffForwLCL_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub optDirect_CheckedChanged(sender As Object, e As EventArgs) Handles optDirect.CheckedChanged

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

    Private Sub dgTariff_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTariff.CellClick

    End Sub

    Private Sub dgTariff_Click(sender As Object, e As EventArgs) Handles dgTariff.Click
        If Me.dgTariff.Rows.Count = 0 Then Exit Sub

        SearchTariff(Me.dgTariff.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged

    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txtPriceS_TextChanged(sender As Object, e As EventArgs) Handles txtPriceS.TextChanged

    End Sub

    Private Sub txtPriceS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPriceS.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub
End Class