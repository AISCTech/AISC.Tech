Imports MasterProject

Public Class frmBrkgItinerary
    Implements ICommonFunction

    Public clsRecord As New clsBrkgItineraryHeader

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        If MsgBox("Create new record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "System Message") = MsgBoxResult.Yes Then
            ClearUserInput()
            clsRecord = New clsBrkgItineraryHeader
            ChangeEnabledButtons(True, False, True, True, False, True, False, False, False, True)
        End If
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        Dim clsCombo As New clsPopulateComboBox(cboPersonel, "SELECT ID, CONCAT(First_Name, ' ', Last_Name) AS `PersonelName` FROM `v_brkg_personel_list` ORDER BY First_Name",
                                                "PersonelName", "ID")
        clsCombo.PopComboBox()

        If Len(txtID.Text) = 0 Then
            ClearUserInput()
            ChangeEnabledButtons(True, False, False, True, False, True, False, False, False, False)
        Else
            Dim clsDB As New clsDBTrans
            clsRecord = clsDB.BrokerageItinerarySearch(txtID.Text)
            LoadRecord(clsRecord)
            ChangeEnabledButtons(True, True, False, True, False, True, False, False, False, False)
        End If
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        If MsgBox("Save record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.Yes Then
            Dim objSelectedValue As IConvertible = TryCast(cboPersonel.SelectedValue, IConvertible)
            Dim clsDetails As New clsBrkgItineraryDetails
            With clsRecord
                If Len(txtID.Text) > 0 Then ._ID = txtID.Text
                ._PersonelDetails._ID = cboPersonel.SelectedValue
                ._Location = txtLocation.Text
                ._Remarks = txtRemarks.Text
                ._PrepByDetails._User_ID = CurrentUser._User_ID
                ._ModByDetails._User_ID = CurrentUser._User_ID
                ._StatusDetails._ID = 0

                ._ListOfItineraryDetails.Clear()
                For Each dtgRow As DataGridViewRow In dtgDetails.Rows
                    clsDetails = New clsBrkgItineraryDetails
                    With clsDetails
                        ._JODetails._ID = dtgRow.Cells(colJOID.Name).Value
                        ._Remarks = dtgRow.Cells(colRemarks.Name).Value
                        With ._JODetails
                            ._StatusDetails._ID = dtgRow.Cells(colStatusID.Name).Value
                            ._StatusByDetails._User_ID = CurrentUser._User_ID
                        End With
                    End With
                    ._ListOfItineraryDetails.Add(clsDetails)
                Next
            End With

            Dim clsDB As New clsDBTrans
            If clsRecord._ID = 0 Then
                clsRecord = clsDB.BrokerageItinerarySave(clsRecord, 1)
            Else
                clsRecord = clsDB.BrokerageItinerarySave(clsRecord, 2)
            End If
            clsRecord = clsDB.BrokerageItinerarySearch(clsRecord._ID)
            LoadRecord(clsRecord)

            MsgBox("Record Saved.")
        End If
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        frmBrkgItinerarySearch.ShowDialog()
    End Sub

    Public Sub LoadRecord(ByVal clsItinerary As clsBrkgItineraryHeader)
        ClearUserInput()

        With clsItinerary
            txtID.Text = ._ID
            cboPersonel.SelectedValue = ._PersonelDetails._ID
            txtDesignation.Text = ._PersonelDetails._TypeDetails._Description
            txtLocation.Text = ._Location
            txtRemarks.Text = ._Remarks

            dtgDetails.Rows.Clear()
            Dim dtgRow As DataGridViewRow
            For Each clsDetails As clsBrkgItineraryDetails In ._ListOfItineraryDetails
                With clsDetails
                    dtgDetails.Rows.Add()
                    dtgRow = dtgDetails.Rows(dtgDetails.Rows.Count - 1)
                    dtgRow.Cells(colID.Name).Value = ._ID
                    dtgRow.Cells(colJOID.Name).Value = ._JODetails._ID
                    dtgRow.Cells(colType.Name).Value = ._JODetails._FreightTypeDetails._Param_Desc
                    dtgRow.Cells(colBookNo.Name).Value = ._JODetails._BookNo
                    dtgRow.Cells(colStatusTypeID.Name).Value = ._JODetails._StatusDetails._StatusTypeDetails._ID
                    dtgRow.Cells(colStatusType.Name).Value = ._JODetails._StatusDetails._StatusTypeDetails._Description
                    dtgRow.Cells(colStatusID.Name).Value = ._JODetails._StatusDetails._ID
                    dtgRow.Cells(colStatusName.Name).Value = ._JODetails._StatusDetails._StatName
                    dtgRow.Cells(colRemarks.Name).Value = ._Remarks
                End With
            Next

            tslblPrepBy.Text = ._PrepByDetails._First_Name & " " & ._PrepByDetails._First_Name
            tslblPrepDate.Text = ._PrepDate
            tslblModBy.Text = ._ModByDetails._First_Name & " " & ._ModByDetails._Last_Name
            tslblModDate.Text = ._ModDate
        End With

        ChangeEnabledButtons(True, True, False, True, False, True, False, False, False, False)
    End Sub

    Private Sub ClearUserInput()
        txtID.Text = ""
        cboPersonel.SelectedIndex = -1
        txtDesignation.Text = ""
        txtLocation.Text = ""
        txtRemarks.Text = ""
        dtgDetails.Rows.Clear()
        tslblPrepBy.Text = ""
        tslblPrepDate.Text = ""
        tslblModBy.Text = ""
        tslblModDate.Text = ""
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

            cboPersonel.Enabled = blUserInput
            txtLocation.ReadOnly = Not blUserInput
            txtRemarks.ReadOnly = Not blUserInput
            tscmdAdd.Enabled = blUserInput
            tscmdRemove.Enabled = blUserInput

            If Len(txtID.Text) > 0 Then
                tscmdAddRequest.Enabled = Not blUserInput
            Else
                tscmdAddRequest.Enabled = False
            End If

            .UpdateEnabledButtons()
        End With
    End Sub

    Private Sub frmBrkgItinerary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeEnabledButtons(True, True, True, True, True, True, True, True, True, True)
        ResetRecord()
    End Sub

    Private Sub frmBrkgItinerary_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmBrkgItinerary_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub cboPersonel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPersonel.SelectedIndexChanged
        Dim objSelectedValue As IConvertible = TryCast(cboPersonel.SelectedValue, IConvertible)

        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT PersonelTypeName FROM v_brkg_personel_list WHERE ID = @ID"
            cmdSQL.Parameters.AddWithValue("@ID", objSelectedValue)

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

            txtDesignation.Text = ""
            While reader.Read
                txtDesignation.Text = reader.Item("PersonelTypeName")
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tscmdAdd_Click(sender As Object, e As EventArgs) Handles tscmdAdd.Click
        frmBrkgItineraryAddBooking.ShowDialog()
    End Sub

    Private Sub tscmdRemove_Click(sender As Object, e As EventArgs) Handles tscmdRemove.Click
        If Me.dtgDetails.Rows.Count > 0 Then
            dtgDetails.Rows.Remove(dtgDetails.CurrentRow)
        End If
    End Sub

    Private Sub tscmdAddRequest_Click(sender As Object, e As EventArgs) Handles tscmdAddRequest.Click
        frmOprReq.ShowDialog()
    End Sub
End Class