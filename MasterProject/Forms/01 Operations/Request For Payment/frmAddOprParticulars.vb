Public Class frmAddOprParticulars
    Public blBrkg As Boolean = False
    Public blTrkg As Boolean = False
    Public blFrwdg As Boolean = False
    Public blWrhs As Boolean = False

    Private Sub AddOprParticulars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clsCombo As New clsPopulateComboBox(cboParticulars, "SELECT `ChargeCode`, `ChargeName` FROM `lib_charges` WHERE `Active` = TRUE AND " &
                                                "`F` = " & blFrwdg & " AND `B` = " & blBrkg & " AND `T` = " & blTrkg & " AND `W` = " & blWrhs & " " &
                                                "ORDER BY `ChargeName`", "ChargeName", "ChargeCode")
        clsCombo.PopComboBox()

        cboBooking.Items.Clear()
        With frmBrkgItinerary
            For Each dtgRow As DataGridViewRow In .dtgDetails.Rows
                cboBooking.Items.Add(dtgRow.Cells(.colBookNo.Name).Value)
            Next
        End With
    End Sub

    Private Sub cboBooking_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBooking.SelectedIndexChanged
        If cboBooking.SelectedIndex >= 0 Then
            Dim clsDB As New clsDBTrans
            Dim clsJO As clsBrkgJO = clsDB.BrokerageJOSearchByBookingNo(cboBooking.Text)

            txtShipper.Text = clsJO._ShipperDetails._Description
            txtConsignee.Text = clsJO._ConsigneeDetails._Description

            Select Case clsJO._FreightTypeDetails._PK
                Case 1
                    Dim clsImp As clsImportBookingHeader = clsDB.CustomerServiceImportSearch(Mid(clsJO._BookNo, 5, 7), CurrentUser._Company_Code)
                    Dim clsCont As New clsImportBookingContainers
                    cboContainer.Items.Clear()
                    For Each clsCont In clsImp._ContainerDetails
                        cboContainer.Items.Add(clsCont._ContainerNo)
                    Next
                Case 2
                    Dim clsExp As clsExportBookingHeader = clsDB.CustomerServiceExportBookingSearch(Mid(clsJO._BookNo, 5, 7), CurrentUser._Company_Code)
                    Dim clsCont As New clsExportMasterContainers
                    cboContainer.Items.Clear()
                    For Each clsCont In clsExp._MasterBookingDetails._ListOfContainers
                        cboContainer.Items.Add(clsCont._ContainerNo)
                    Next
            End Select
        End If
    End Sub

    Private Sub frmAddOprParticulars_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        With frmOprReq
            .dtgDetails.Rows.Add()
            Dim dtgRow As DataGridViewRow = .dtgDetails.Rows(.dtgDetails.Rows.Count - 1)
            dtgRow.Cells(.colCHCode.Name).Value = cboParticulars.SelectedValue
            dtgRow.Cells(.colParticulars.Name).Value = cboParticulars.Text
            dtgRow.Cells(.colAmount.Name).Value = Format(CDbl(txtAmount.Text), "N2")
        End With
    End Sub
End Class