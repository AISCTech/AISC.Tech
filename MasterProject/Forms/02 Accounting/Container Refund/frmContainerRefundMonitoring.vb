Imports MySql.Data.MySqlClient
Public Class frmContainerRefundMonitoring
    Private Sub frmContainerRefundMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub PopContRefMonitoring()
        Dim strsql As String, dtReqDate As Date, strStatus As String = "", strPaidDate As String
        Dim reader As MySqlDataReader
        Dim cmd As MySqlCommand

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Me.dtgContRefMonitoring.Rows.Clear()
        strsql = "SELECT tbl_contrefmain.*, tbl_contrefdetails.*, tbl_request.REQ_PrepDate " &
                        " FROM (tbl_contrefmain LEFT JOIN tbl_contrefdetails ON tbl_contrefmain.BCR_Nbr = tbl_contrefdetails.BCD_BCRNbr)" &
                        " LEFT JOIN tbl_request ON tbl_contrefmain.BCR_RequestNbr = tbl_request.REQ_Nbr"

        If Me.optAll.Checked = True Then
            strsql += ""
        ElseIf Me.optOutstanding.Checked = True Then
            strsql += " WHERE tbl_contrefmain.BCR_Outstanding = TRUE"
        ElseIf Me.optBalance.Checked = True Then
            strsql += " WHERE tbl_contrefmain.BCR_Balance = TRUE"
        ElseIf Me.optPaid.Checked = True Then
            strsql += " WHERE tbl_contrefmain.BCR_Paid = TRUE"
        End If

        cmd = New MySqlCommand(strsql, cnnDBMaster)
        reader = cmd.ExecuteReader()

        While reader.Read()

            dtReqDate = Format$(reader.Item("REQ_PrepDate"), "MM/dd/yyyy")

            If reader.Item("BCR_Cancel") Then
                strStatus = "CANCEL"
            ElseIf reader.Item("BCR_Outstanding") Then
                strStatus = "OUTSTANDING"
            ElseIf reader.Item("BCR_Balance") Then
                strStatus = "BALANCE"
            ElseIf reader.Item("BCR_Paid") Then
                strStatus = "PAID"
            End If

            If IsDBNull(reader.Item("BCR_PaidDate")) = False Then
                strPaidDate = Format$(reader.Item("BCR_PaidDate"), "MM/dd/yyyy")
            Else
                strPaidDate = ""
            End If

            Me.dtgContRefMonitoring.Rows.Add(Format$(dtReqDate, "MM/dd/yyyy"), Format$(reader.Item("BCR_PreparedDate"), "MM/dd/yyyy"), strPaidDate, reader.Item("BCR_Nbr"), reader.Item("BCR_RequestNbr"), reader.Item("BCR_ShippingName"), reader.Item("BCD_Consignee"), reader.Item("BCD_BookNbr"), Format$(CDbl(reader.Item("BCD_Amount")), "n2"), strStatus, reader.Item("BCR_Remarks"))
        End While

        reader.Close()
        cmd.Dispose()
    End Sub

    Private Sub optAll_CheckedChanged(sender As Object, e As EventArgs) Handles optAll.CheckedChanged

    End Sub

    Private Sub optAll_Click(sender As Object, e As EventArgs) Handles optAll.Click
        PopContRefMonitoring()
    End Sub

    Private Sub optOutstanding_CheckedChanged(sender As Object, e As EventArgs) Handles optOutstanding.CheckedChanged

    End Sub

    Private Sub optOutstanding_Click(sender As Object, e As EventArgs) Handles optOutstanding.Click
        PopContRefMonitoring()
    End Sub

    Private Sub optBalance_CheckedChanged(sender As Object, e As EventArgs) Handles optBalance.CheckedChanged

    End Sub

    Private Sub optBalance_Click(sender As Object, e As EventArgs) Handles optBalance.Click
        PopContRefMonitoring()
    End Sub

    Private Sub optPaid_CheckedChanged(sender As Object, e As EventArgs) Handles optPaid.CheckedChanged

    End Sub

    Private Sub optPaid_Click(sender As Object, e As EventArgs) Handles optPaid.Click
        PopContRefMonitoring()
    End Sub
End Class