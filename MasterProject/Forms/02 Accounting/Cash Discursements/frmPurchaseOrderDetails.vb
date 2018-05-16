Imports MySql.Data.MySqlClient
Public Class frmPurchaseOrderDetails
    Private Sub btPrintPreview_Click(sender As Object, e As EventArgs) Handles btPrintPreview.Click
        If CheckForRequiredEntries() = False Then Exit Sub

        SavePODetails(frmRequest.lblReqNbr.Text)

        frmPrintPreview.LoadRequestADMPO(frmRequest.lblReqNbr.Text)
        frmPrintPreview.ShowDialog()
    End Sub
    Public Sub SavePODetails(ByVal str As String)
        Dim dtCurrent As Date = GetServerDate()
        Dim cmdSQL As New MySqlCommand
        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)
        If cnn.State <> ConnectionState.Open Then cnn.Open()
        Try

            cmdSQL.CommandText = ("INSERT INTO tbl_requestpodetails (`ReqNbr`, `VendorAddr`,`DeliverTo`, `DeliverOn`, `RequestedBy`, `Terms`, `Remarks`, `EncodedBy`, `EncodedDate`)  VALUES " &
                                 "               (@ReqNbr, @VendorAddr,@DeliverTo, @DeliverOn, @RequestedBy, @Terms, @Remarks, @EncodedBy, @EncodedDate)")

            With cmdSQL.Parameters

                .AddWithValue("@ReqNbr", str)
                .AddWithValue("@VendorAddr", Me.txtSupplierAdd.Text)
                .AddWithValue("@DeliverTo", Me.txtDeliverTo.Text)
                .AddWithValue("@DeliverOn", Me.dtDeliver.Value)
                .AddWithValue("@RequestedBy", Me.txtRequestedBy.Text)
                .AddWithValue("@Terms", Me.cboTerms.Text)
                .AddWithValue("@Remarks", Me.txtRemarks.Text)
                .AddWithValue("@EncodedBy", strCurrentUser)
                .AddWithValue("@EncodedDate", dtCurrent)
            End With

            cmdSQL.Connection = cnn
            cmdSQL.ExecuteNonQuery()
            cmdSQL.Dispose()
            cnn.Close()
        Catch ex As Exception
            MsgBox("There was an error trying to save transaction log - " & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Private Sub frmPurchaseOrderDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function CheckForRequiredEntries() As Boolean
        If Len(Me.txtSupplierAdd.Text) = 0 Then
            MsgBox("Please input Vendor/Supplier Address!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtDeliverTo.Text) = 0 Then
            MsgBox("Please input Delivery To Address!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtDeliverOn.Text) = 0 Then
            MsgBox("Please select Delivery Date!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtRequestedBy.Text) = 0 Then
            MsgBox("Please type in Requested By!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Me.cboTerms.SelectedIndex = -1 Then
            MsgBox("Please select Terms of Payment!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        If Len(Me.txtRemarks.Text) = 0 Then
            MsgBox("Please type in Remarks!", vbInformation, "Missing Information")
            CheckForRequiredEntries = False
            Exit Function
        End If

        CheckForRequiredEntries = True
    End Function

    Private Sub dtDeliver_ValueChanged(sender As Object, e As EventArgs) Handles dtDeliver.ValueChanged
        Me.txtDeliverOn.Text = Format(Me.dtDeliver.Value, "yyyy-MM-dd")
    End Sub

    Public Sub SearchPODetails(ByVal str As String)

        Dim cnn As New MySql.Data.MySqlClient.MySqlConnection(strDBMaster)

        If cnn.State <> ConnectionState.Open Then cnn.Open()

        Dim strSQL As String = "Select * from tbl_requestpodetails where ReqNbr = '" & str & "' ORDER BY EncodedDate asc"

        Dim cmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, cnn)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()

        If reader.HasRows = False Then
            Me.txtSupplierAdd.Text = GetStringValue("Select Addr1 from tbl_vendor where Code = '" & frmRequest.txtPayeeCode.Text & "'", "Addr1") & vbNewLine & GetStringValue("Select lib_city.Description AS `CityDesc` from tbl_vendor INNER JOIN lib_city on tbl_vendor.AddrCity = lib_city.PK where tbl_vendor.Code = '" & frmRequest.txtPayeeCode.Text & "'", "CityDesc") & vbNewLine & GetStringValue("Select AddrZipCode from tbl_vendor where Code = '" & frmRequest.txtPayeeCode.Text & "'", "AddrZipCode")
        Else
            While reader.Read
                Me.txtSupplierAdd.Text = reader.Item("VendorAddr")
                Me.txtDeliverTo.Text = reader.Item("DeliverTo")
                Me.dtDeliver.Value = reader.Item("DeliverOn")
                Me.txtRequestedBy.Text = reader.Item("RequestedBy")
                Me.cboTerms.Text = reader.Item("Terms")
                Me.txtRemarks.Text = reader.Item("Remarks")
            End While
        End If


        cmd.Dispose()
        reader.Close()
        cnn.Close()
    End Sub
End Class