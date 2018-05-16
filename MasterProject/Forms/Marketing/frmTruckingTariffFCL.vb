Imports MySql.Data.MySqlClient
Public Class frmTruckingTariffFCL

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
            Me.cboLocation.Enabled = blUserInput
            Me.txt20ft.ReadOnly = Not blUserInput
            Me.txt40ft.ReadOnly = Not blUserInput

            Me.dgTruckingTariffLCL.Enabled = Not blUserInput

            .UpdateEnabledButtons()
        End With
    End Sub

    Public Sub ClearEntries()
        Me.txtCtrlNbr.Text = ""
        Me.cboLocation.SelectedIndex = -1
        Me.txtLocation.Text = ""
        Me.txtCountry.Text = ""
        Me.txt20ft.Text = 0
        Me.txt40ft.Text = 0
        Me.lblEncodedBy.Text = ""
        Me.lblDateEncoded.Text = ""
        Me.lblModifiedBy.Text = ""
        Me.lblDateModified.Text = ""
    End Sub

    Public Function CheckForRequiredEntries() As Boolean
        Me.ErrorProvider1.Clear()

        If Me.cboLocation.SelectedIndex = -1 Then
            MsgBox("Please select location!", vbCritical, "Missing Information")
            ErrorProvider1.SetError(Me.cboLocation, "Missing Informattion")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txt20ft.Text) = 0 Then
            MsgBox("Please type on x20 FT Amount!", vbCritical, "Missing Information")
            ErrorProvider1.SetError(Me.txt20ft, "Missing Informattion")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txt40ft.Text) = 0 Then
            MsgBox("Please type on x40 FT Amount!", vbCritical, "Missing Information")
            ErrorProvider1.SetError(Me.txt40ft, "Missing Informattion")
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
            If CheckIfLocationExists(Me.cboLocation.Text) = True Then Exit Sub
            Try
                cmdSQL.CommandText = ("INSERT INTO tbl_truckingtarifffcl (`CtrlNbr`, `LocationDesc`, `LocationCityCode`, `LocationCountryCode`, `x20FT`, `x40FT`, `EncodedBy`, `EncodedDate`, `ModifiedBy`, `ModifiedDate`) VALUES " &
                                                        "               (@CtrlNbr, @LocationDesc, @LocationCityCode, @LocationCountryCode, @x20FT, @x40FT, @EncodedBy, @EncodedDate, @ModifiedBy, @ModifiedDate)")





                With cmdSQL.Parameters
                    Dim ctrlnbr As String = "TFCL" & GetCtrlNbr(strCompanyCode, strSiteCode, "TruckingTariffFCL")

                    If Len(ctrlnbr) = 0 Then
                        MsgBox("Error getting control number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    .AddWithValue("@CtrlNbr", ctrlnbr)
                    .AddWithValue("@LocationDesc", Me.cboLocation.Text)
                    .AddWithValue("@LocationCityCode", CInt(Me.txtLocation.Text))
                    .AddWithValue("@LocationCountryCode", CInt(Me.txtCountry.Text))
                    .AddWithValue("@x20FT", CDbl(Me.txt20ft.Text))
                    .AddWithValue("@x40FT", CDbl(Me.txt40ft.Text))
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

            UpdateCtrlNbrCounter(strCompanyCode, strSiteCode, "TruckingTariffFCL")

            MsgBox("Record Successfully Saved!", vbInformation, "System Message")
            ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

            'save transaction log
            SaveTransLogs("Create New", Me.Name, "Trucking Tariff FCL", Me.txtCtrlNbr.Text, strCurrentUser)

        Else
            'update record

            Dim sSQL As String = "UPDATE  tbl_truckingtarifffcl Set "
            sSQL += " x20FT=@x20FT, "
            sSQL += " x40FT=@x40FT, "
            sSQL += " ModifiedBy=@ModifiedBy, "
            sSQL += " ModifiedDate=@ModifiedDate "
            sSQL += " WHERE CtrlNbr= '" & Me.txtCtrlNbr.Text & "'"
            cmdSQL.CommandText = sSQL

            With cmdSQL.Parameters
                .AddWithValue("@x20FT", CDbl(Me.txt20ft.Text))
                .AddWithValue("@x40FT", CDbl(Me.txt40ft.Text))
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
            SaveTransLogs("Edit Record", Me.Name, "Trucking Tariff FCL", Me.txtCtrlNbr.Text, strCurrentUser)
        End If

        cnnDBMaster.Close()
        cnnDBMaster.Dispose()

        PopTariff(Me.dgTruckingTariffLCL)
    End Sub

    Public Sub PopTariff(ByVal dg As DataGridView)
        dg.Rows.Clear()

        Dim strSQL As String


        strSQL = "Select * " &
                 "FROM tbl_truckingtarifffcl"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()

            dg.Rows.Add(reader.Item("CtrlNbr"), reader.Item("LocationDesc"), reader.Item("LocationCityCode"), reader.Item("LocationCountryCode"), Format(reader.Item("x20FT"), "n2"), Format(reader.Item("x40FT"), "n2"), reader.Item("EncodedBy"), reader.Item("EncodedDate"), reader.Item("ModifiedBy"), reader.Item("ModifiedDate"))

        End While

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()
    End Sub

    Public Sub SearchTariff(ByVal str As String)
        ClearEntries()

        Dim strSQL As String


        strSQL = "Select * " &
                 "FROM tbl_truckingtarifffcl " &
                 "WHERE tbl_truckingtarifffcl.CtrlNbr = '" & str & "'"

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
            Me.cboLocation.Text = reader.Item("LocationDesc")
            Me.txtLocation.Text = reader.Item("LocationCityCode")
            Me.txtCountry.Text = reader.Item("LocationCountryCode")
            Me.txt20ft.Text = Format(reader.Item("x20FT"), "n2")
            Me.txt40ft.Text = Format(reader.Item("x40FT"), "n2")

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

    Public Function CheckIfLocationExists(ByVal str As String) As Boolean


        Dim strSQL As String


        strSQL = "Select * " &
                 "FROM tbl_truckingtarifffcl " &
                 "WHERE tbl_truckingtarifffcl.LocationDesc = '" & str & "'"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.HasRows = True Then
            MsgBox("Location already exists!", vbInformation, "System Message")
            cmd.Dispose()
            reader.Close()
            cnnDBMaster.Close()
            CheckIfLocationExists = True
            Exit Function
        End If

        cmd.Dispose()
        reader.Close()
        cnnDBMaster.Close()

        CheckIfLocationExists = False

    End Function

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If CheckForRequiredEntries() = False Then Exit Sub



        If MsgBox("Are you sure you want to save this transaction?", vbYesNo, "Confirm Save") = vbNo Then Exit Sub

        SaveTariff()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub
    Private Sub frmTruckingTariffFCL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBox(Me.cboLocation, "Select Description from lib_city where Description is not null", "Description")
        ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
        PopTariff(Me.dgTruckingTariffLCL)
    End Sub

    Private Sub frmTruckingTariffFCL_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub txt20ft_TextChanged(sender As Object, e As EventArgs) Handles txt20ft.TextChanged

    End Sub

    Private Sub txt20ft_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt20ft.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub txt40ft_TextChanged(sender As Object, e As EventArgs) Handles txt40ft.TextChanged

    End Sub

    Private Sub txt40ft_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt40ft.KeyPress
        SetCharacter(MyOption.Numeric, e)
    End Sub

    Private Sub dgTruckingTariffLCL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTruckingTariffLCL.CellContentClick

    End Sub

    Private Sub dgTruckingTariffLCL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTruckingTariffLCL.CellClick
        SearchTariff(Me.dgTruckingTariffLCL.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocation.SelectedIndexChanged
        If Me.cboLocation.SelectedIndex = -1 Then Exit Sub

        Me.txtLocation.Text = GetIntegerValue("Select PK from lib_city where Description = '" & Me.cboLocation.Text & "'", "PK")
        Me.txtCountry.Text = GetIntegerValue("Select Country from lib_city where Description = '" & Me.cboLocation.Text & "'", "Country")
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class