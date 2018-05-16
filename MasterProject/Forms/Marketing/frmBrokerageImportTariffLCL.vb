Imports MySql.Data.MySqlClient
Public Class frmBrokerageImportTariffLCL

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

            Me.btClose.Enabled = Not blUserInput
            Me.cboChargeName.Enabled = blUserInput
            Me.cboType.Enabled = blUserInput
            Me.txtPrice.ReadOnly = Not blUserInput

            .UpdateEnabledButtons()
        End With
    End Sub

    Public Sub ClearEntries()
        Me.txtCtrlNbr.Text = ""
        Me.cboChargeName.SelectedIndex = -1
        Me.cboType.SelectedIndex = -1
        Me.txtType.Text = ""
        Me.txtPrice.Text = 0
        Me.lblEncodedBy.Text = ""
        Me.lblDateEncoded.Text = ""
        Me.lblModifiedBy.Text = ""
        Me.lblDateModified.Text = ""
    End Sub

    Public Function CheckForRequiredEntries() As Boolean
        Me.ErrorProvider1.Clear()

        If Me.cboChargeName.SelectedIndex = -1 Then
            MsgBox("Please select Charge Description!", vbCritical, "Missing Information")
            ErrorProvider1.SetError(Me.cboChargeName, "Missing Informattion")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboType.SelectedIndex = -1 Then
            MsgBox("Please select Type of Processing!", vbCritical, "Missing Information")
            ErrorProvider1.SetError(Me.cboType, "Missing Informattion")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtPrice.Text) = 0 Then
            MsgBox("Please type on Price!", vbCritical, "Missing Information")
            ErrorProvider1.SetError(Me.txtPrice, "Missing Informattion")
            CheckForRequiredEntries = False
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

        If Len(Me.txtCtrlNbr.Text) = 0 Then

            Try
                cmdSQL.CommandText = ("INSERT INTO tbl_brokerageimporttarifflcl (`CtrlNbr`, `ChargeCode`, `ChargeName`, `TypeID`, `TypeDesc`, `Price`, `EncodedBy`, `EncodedDate`, `ModifiedBy`, `ModifiedDate`) VALUES " &
                                                        "               (@CtrlNbr, @ChargeCode, @ChargeName, @TypeID, @TypeDesc, @Price, @EncodedBy, @EncodedDate, @ModifiedBy, @ModifiedDate)")


                With cmdSQL.Parameters
                    Dim ctrlnbr As String = "IBLCL" & GetCtrlNbr(strCompanyCode, strSiteCode, "BrokerageImportTariffLCL")

                    If Len(ctrlnbr) = 0 Then
                        MsgBox("Error getting control number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@CtrlNbr", ctrlnbr)
                    .AddWithValue("@ChargeCode", Me.txtChargeCode.Text)
                    .AddWithValue("@ChargeName", Me.cboChargeName.Text)
                    .AddWithValue("@TypeID", CInt(Me.txtType.Text))
                    .AddWithValue("@TypeDesc", Me.cboType.Text)
                    .AddWithValue("@Price", CDbl(Me.txtPrice.Text))
                    .AddWithValue("@EncodedBy", strCurrentUser)
                    .AddWithValue("@EncodedDate", dtCurrent)
                    .AddWithValue("@ModifiedBy", strCurrentUser)
                    .AddWithValue("@ModifiedDate", dtCurrent)

                    'MsgBox(cmdSQL.CommandText)

                    Me.txtCtrlNbr.Text = ctrlnbr
                    Me.lblEncodedBy.Text = strCurrentUser
                    Me.lblDateEncoded.Text = Format(dtCurrent, "yyyy-MM-dd hhmm : ss")
                    Me.lblModifiedBy.Text = strCurrentUser
                    Me.lblDateModified.Text = Format(dtCurrent, "yyyy-MM-dd hh: mm : ss")
                End With

                cmdSQL.Connection = cnnDBMaster
                cmdSQL.ExecuteNonQuery()
                cmdSQL.Dispose()

            Catch ex As Exception
                MsgBox("There was an Error trying To save the record - " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "BrokerageImportTariffLCL")

            MsgBox("Record Successfully Saved!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            'save transaction log
            SaveTransLogs("Create New", Me.Name, "Brokerage Import Tariff LCL", Me.txtCtrlNbr.Text, strCurrentUser)

        Else
            'update record

            Dim sSQL As String = "UPDATE  tbl_brokerageimporttarifflcl Set "
            sSQL += " Price=@Price, "
            sSQL += " ModifiedBy=@ModifiedBy, "
            sSQL += " ModifiedDate=@ModifiedDate "
            sSQL += " WHERE CtrlNbr= '" & Me.txtCtrlNbr.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@Price", CDbl(Me.txtPrice.Text))
                .AddWithValue("@ModifiedBy", strCurrentUser)
                .AddWithValue("@ModifiedDate", dtCurrent)
            End With

            cmdSQL.Connection = cnnDBMaster
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()

            MsgBox("Record " & Me.txtCtrlNbr.Text & " Successfully Updated!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            Me.lblModifiedBy.Text = strCurrentUser
            Me.lblDateModified.Text = Format(dtCurrent, "yyyy-MM-dd hh:mm:ss")
            SaveTransLogs("Edit Record", Me.Name, "Brokerage Import Tariff LCL", Me.txtCtrlNbr.Text, strCurrentUser)
        End If

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()

        PopTariff(Me.dgBrkgTariff)
    End Sub

    Public Sub PopTariff(ByVal dg As DataGridView)
        dg.Rows.Clear()

        Dim strSQL As String


        strSQL = "Select * " &
                 "FROM tbl_brokerageimporttarifflcl"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            dg.Rows.Add(reader.Item("CtrlNbr"), reader.Item("ChargeCode"), reader.Item("ChargeName"), reader.Item("TypeID"), reader.Item("TypeDesc"), Format(reader.Item("Price"), "n2"), reader.Item("EncodedBy"), reader.Item("EncodedDate"), reader.Item("ModifiedBy"), reader.Item("ModifiedDate"))

        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Public Sub SearchTariff(ByVal str As String)
        ClearEntries()

        Dim strSQL As String


        strSQL = "Select * " &
                 "FROM tbl_brokerageimporttarifflcl " &
                 "WHERE tbl_brokerageimporttarifflcl.CtrlNbr = '" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.HasRows = False Then
            MsgBox("No record found!", vbInformation, "System Message")
            cmd.Dispose()
            reader.Close()
            cnnDBMaster.Close()
            Exit Sub
        End If

        While reader.Read()

            Me.txtCtrlNbr.Text = reader.Item("CtrlNbr")
            Me.txtChargeCode.Text = reader.Item("ChargeCode")
            Me.cboChargeName.Text = reader.Item("ChargeName")
            Me.txtType.Text = reader.Item("TypeID")
            Me.cboType.Text = reader.Item("TypeDesc")
            Me.txtPrice.Text = Format(reader.Item("Price"), "n2")
            Me.lblEncodedBy.Text = reader.Item("EncodedBy")
            Me.lblDateEncoded.Text = reader.Item("EncodedDate")
            Me.lblModifiedBy.Text = reader.Item("ModifiedBy")
            Me.lblDateModified.Text = reader.Item("ModifiedDate")

        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        ClearEntries()
        ChangeEnabledButtons(False, False, True, True, False, False, False, False, False, True)
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        ClearEntries()
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckForRequiredEntries() = False Then Exit Sub

        If MsgBox("Are you sure you want to save this transaction?", vbYesNo, "Confirm Save") = vbNo Then Exit Sub

        SaveTariff()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub

    Private Sub frmBrokerageImportTariffLCL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBox(Me.cboChargeName, "Select ChargeName from lib_charges where B = 1  ORDER BY ChargeName", "ChargeName")
        FillComboBox(Me.cboType, "Select Description from lib_brokerageimporttarifflcl where Description is not null", "Description")
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        PopTariff(Me.dgBrkgTariff)
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub frmBrokerageImportTariffLCL_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub cboChargeName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChargeName.SelectedIndexChanged
        If Me.cboChargeName.SelectedIndex = -1 Then Exit Sub

        Me.txtChargeCode.Text = GetStringValue("Select ChargeCode from lib_charges where ChargeName = '" & Me.cboChargeName.Text & "'", "ChargeCode")
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        If Me.cboType.SelectedIndex = -1 Then Exit Sub

        Me.txtType.Text = GetIntegerValue("Select PK from lib_brokerageimporttarifflcl where Description = '" & Me.cboType.Text & "'", "PK")
    End Sub

    Private Sub dgBrkgTariff_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBrkgTariff.CellContentClick

    End Sub

    Private Sub dgBrkgTariff_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBrkgTariff.CellClick
        SearchTariff(Me.dgBrkgTariff.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged

    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub
End Class