Public Class frmAddBookingContainer
    Public strCaller As String

    Private Sub PopulateContainer()
        Try
            Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand

            If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
            cmdSQL.Connection = cnnDBMaster
            cmdSQL.CommandText = "SELECT * FROM v_containersize WHERE ContainerNo LIKE @ContainerNo ORDER BY ContainerNo"
            cmdSQL.Parameters.AddWithValue("@ContainerNo", "%" & txtFilter.Text & "%")

            dtgContainer.Rows.Clear()

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader
            While reader.Read
                dtgContainer.Rows.Add()
                With dtgContainer.Rows(dtgContainer.Rows.Count - 1)
                    .Cells(colPK.Name).Value = reader.Item("ID")
                    .Cells(colContainerNo.Name).Value = reader.Item("ContainerNo")
                    .Cells(colContainerSizeID.Name).Value = reader.Item("ContainerSizeID")
                    .Cells(colContainerSize.Name).Value = reader.Item("Param_Desc")
                End With
            End While

            reader.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PopulateImportBookingContainer(ByVal intRow As Integer)
        Dim dtgRow As DataGridViewRow = dtgContainer.Rows(intRow)

        frmImportBookingMenu.dtgContainer.Rows.Add()
        With frmImportBookingMenu.dtgContainer.Rows(frmImportBookingMenu.dtgContainer.Rows.Count - 1)
            .Cells(frmImportBookingMenu.colCContainerID.Name).Value = dtgRow.Cells(colPK.Name).Value
            .Cells(frmImportBookingMenu.colCContainerNo.Name).Value = dtgRow.Cells(colContainerNo.Name).Value
            .Cells(frmImportBookingMenu.colCContainerSizeID.Name).Value = dtgRow.Cells(colContainerSizeID.Name).Value
            .Cells(frmImportBookingMenu.colCContainerSizeName.Name).Value = dtgRow.Cells(colContainerSize.Name).Value
        End With
    End Sub

    Private Sub frmAddBookingContainer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtPickup.Value = New DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0)
        dtDelivery.Value = New DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0)
        txtPickup.Text = dtPickup.Value.ToLongDateString
        txtDelivery.Text = dtDelivery.Value.ToLongDateString

        PopulateContainer()
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        PopulateContainer()
    End Sub

    Private Sub dtgContainer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgContainer.CellContentClick

    End Sub

    Private Sub dtgContainer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgContainer.CellDoubleClick
        Select Case strCaller
            Case "ImpBook"
                PopulateImportBookingContainer(e.RowIndex)
        End Select

        Me.Close()
    End Sub

    Private Sub dtPickup_ValueChanged(sender As Object, e As EventArgs) Handles dtPickup.ValueChanged
        txtPickup.Text = dtPickup.Value.ToLongDateString
    End Sub

    Private Sub dtDelivery_ValueChanged(sender As Object, e As EventArgs) Handles dtDelivery.ValueChanged
        txtDelivery.Text = dtDelivery.Value.ToLongDateString
    End Sub

    Private Sub frmAddBookingContainer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub chkPickupTBA_CheckedChanged(sender As Object, e As EventArgs) Handles chkPickupTBA.CheckedChanged
        dtPickup.Enabled = Not chkPickupTBA.Checked
    End Sub

    Private Sub chkDeliveryTBA_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeliveryTBA.CheckedChanged
        dtDelivery.Enabled = Not chkDeliveryTBA.Checked
    End Sub
End Class