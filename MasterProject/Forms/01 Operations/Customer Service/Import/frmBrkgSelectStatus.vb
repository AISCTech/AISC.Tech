Public Class frmBrkgSelectStatus
    Public lngJOID As Long

    Private Sub frmBrkgSelectStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clsCombo As New clsPopulateComboBox(cboStatusType, "SELECT * FROM `lib_brkg_status_type` ORDER BY `Description`", "Description", "ID")
        clsCombo.PopComboBox()

        With cboStatusList
            .DataSource = Nothing
            .DisplayMember = Nothing
            .ValueMember = Nothing
            .Text = ""
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub cboStatusType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusType.SelectedIndexChanged

    End Sub

    Private Sub cboStatusType_Validated(sender As Object, e As EventArgs) Handles cboStatusType.Validated
        With cboStatusList
            .DataSource = Nothing
            .DisplayMember = Nothing
            .ValueMember = Nothing
            .Text = ""
            .SelectedIndex = -1
        End With

        If cboStatusType.SelectedIndex >= 0 Then
            Dim clsCombo As New clsPopulateComboBox(cboStatusList, "SELECT `ID`, `StatName` FROM `lib_brkg_status_list` WHERE `StatTypeID` = " & cboStatusType.SelectedValue & " ORDER BY `StatOrder`", "StatName", "ID")
            clsCombo.PopComboBox()
        Else
            cboStatusType.Text = ""
        End If
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        With frmBrkgItinerary
            .dtgDetails.Rows.Add()
            Dim dtgRow As DataGridViewRow = .dtgDetails.Rows(.dtgDetails.Rows.Count - 1)
            dtgRow.Cells(.colJOID.Name).Value = lngJOID
            dtgRow.Cells(.colType.Name).Value = txtType.Text
            dtgRow.Cells(.colBookNo.Name).Value = txtBookingNo.Text
            dtgRow.Cells(.colStatusTypeID.Name).Value = cboStatusType.SelectedValue
            dtgRow.Cells(.colStatusType.Name).Value = cboStatusType.Text
            dtgRow.Cells(.colStatusID.Name).Value = cboStatusList.SelectedValue
            dtgRow.Cells(.colStatusName.Name).Value = cboStatusList.Text
            dtgRow.Cells(.colRemarks.Name).Value = txtRemarks.Text
        End With

        frmBrkgItineraryAddBooking.Close()
        Me.Close()
        Me.Dispose()
    End Sub
End Class