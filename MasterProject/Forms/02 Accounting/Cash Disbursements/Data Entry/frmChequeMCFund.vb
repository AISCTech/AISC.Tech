Imports MySql.Data.MySqlClient
Public Class frmChequeMCFund

    Dim FundKey As String
    Dim FundCode As Integer

    Private Sub frmChequeMCFund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBank()
    End Sub

    Public Sub loadBank()
        Dim strsql As String
        dgBanks.Rows.Clear()

        strsql = "SELECT Name from lib_bank WHERE Active like '" & 1 & "' ORDER by Name"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            dgBanks.Rows.Add(0, reader.Item("Name"))
        End While
        cmdsql.Dispose()
        reader.Close()
    End Sub

    Public Sub loadPrintReport()
        Dim strsql As String
        'dgVouchers.Rows.Clear()
        strsql = "UPDATE tbl_cv SET selected = '" & 0 & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql1.ExecuteNonQuery()
        cmdsql1.Dispose()
        cnnDBMaster.Close()

        For j As Integer = 0 To dgBanks.Rows.Count - 1
            With dgBanks.Rows(j)
                If .Cells(0).Value = True Then
                    strsql = "SELECT * FROM tbl_cv INNER JOIN lib_vendor ON tbl_cv.PayeeID = tbl_vendor.Code WHERE BankName like '" & .Cells(1).Value & "'"

                    Dim cnn As New MySqlConnection(strDBMaster)

                    If cnn.State <> ConnectionState.Open Then cnn.Open()
                    Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
                    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
                    While reader.Read
                        If Format$(txtDateFrom.Value, "yyMMdd") <= Format$(reader.Item("PrepDate"), "yyMMdd") And Format$(txtDateTo.Value, "yyMMdd") >= Format$(reader.Item("PrepDate"), "yyMMdd") Then
                            If chkReleased.Checked = True Then
                                If reader.Item("Released") = True Then
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkLiquidated.Checked = True Then
                                If reader.Item("Liquidated") = True Then
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkCancelled.Checked = True Then
                                If reader.Item("Cancelled") = True Then
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkFunded.Checked = True Then
                                If reader.Item("Fund") = True Then
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkOpen.Checked = True Then
                                If reader.Item("Released") = False And reader.Item("Cancelled") = False And reader.Item("Liquidated") = False And reader.Item("Released") = False And reader.Item("Fund") = False Then
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                        End If
                    End While
                    cmdsql.Dispose()
                    reader.Close()
                End If
            End With
        Next
    End Sub

    Public Sub loadVouchers()
        Dim strsql As String
        dgVouchers.Rows.Clear()
        strsql = "UPDATE tbl_cv SET selected = '" & 0 & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql1.ExecuteNonQuery()
        cmdsql1.Dispose()
        cnnDBMaster.Close()

        For j As Integer = 0 To dgBanks.Rows.Count - 1
            With dgBanks.Rows(j)
                If .Cells(0).Value = True Then
                    strsql = "SELECT * FROM tbl_cv INNER JOIN tbl_vendor ON tbl_cv.PayeeID = tbl_vendor.Code WHERE BankName like '" & .Cells(1).Value & "'"

                    Dim cnn As New MySqlConnection(strDBMaster)

                    If cnn.State <> ConnectionState.Open Then cnn.Open()
                    Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnn)
                    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
                    While reader.Read
                        If Format$(txtDateFrom.Value, "yyMMdd") <= Format$(reader.Item("PrepDate"), "yyMMdd") And Format$(txtDateTo.Value, "yyMMdd") >= Format$(reader.Item("PrepDate"), "yyMMdd") Then
                            If chkReleased.Checked = True Then
                                If reader.Item("Released") = True Then
                                    dgVouchers.Rows.Add(0, reader.Item("PrepDate"), reader.Item("CVNo"), reader.Item("BankName"), reader.Item("CheckNo"), reader.Item("CheckDate"), reader.Item("Description"), Format$(reader.Item("CashInBank"), "N2"), reader.Item("Released"), reader.Item("Liquidated"), reader.Item("Cancelled"), reader.Item("Fund"))
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkLiquidated.Checked = True Then
                                If reader.Item("Liquidated") = True Then
                                    dgVouchers.Rows.Add(0, reader.Item("PrepDate"), reader.Item("CVNo"), reader.Item("BankName"), reader.Item("CheckNo"), reader.Item("CheckDate"), reader.Item("Description"), Format$(reader.Item("CashInBank"), "N2"), reader.Item("Released"), reader.Item("Liquidated"), reader.Item("Cancelled"), reader.Item("Fund"))
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkCancelled.Checked = True Then
                                If reader.Item("Cancelled") = True Then
                                    dgVouchers.Rows.Add(0, reader.Item("PrepDate"), reader.Item("CVNo"), reader.Item("BankName"), reader.Item("CheckNo"), reader.Item("CheckDate"), reader.Item("Description"), Format$(reader.Item("CashInBank"), "N2"), reader.Item("Released"), reader.Item("Liquidated"), reader.Item("Cancelled"), reader.Item("Fund"))
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkFunded.Checked = True Then
                                If reader.Item("Fund") = True Then
                                    dgVouchers.Rows.Add(0, reader.Item("PrepDate"), reader.Item("CVNo"), reader.Item("BankName"), reader.Item("CheckNo"), reader.Item("CheckDate"), reader.Item("Description"), Format$(reader.Item("CashInBank"), "N2"), reader.Item("Released"), reader.Item("Liquidated"), reader.Item("Cancelled"), reader.Item("Fund"))
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                            If chkOpen.Checked = True Then
                                If reader.Item("Released") = False And reader.Item("Cancelled") = False And reader.Item("Liquidated") = False And reader.Item("Released") = False And reader.Item("Fund") = False Then
                                    dgVouchers.Rows.Add(0, reader.Item("PrepDate"), reader.Item("CVNo"), reader.Item("BankName"), reader.Item("CheckNo"), reader.Item("CheckDate"), reader.Item("Description"), Format$(reader.Item("CashInBank"), "N2"), reader.Item("Released"), reader.Item("Liquidated"), reader.Item("Cancelled"), reader.Item("Fund"))
                                    strsql = "UPDATE tbl_cv SET selected = '" & 1 & "' WHERE CVNo like '" & reader.Item("CVNo") & "'"
                                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
                                    Dim cmdsql2 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
                                    cmdsql2.ExecuteNonQuery()
                                    cmdsql2.Dispose()
                                    cnnDBMaster.Close()
                                End If
                            End If
                        End If
                    End While
                    cmdsql.Dispose()
                    reader.Close()
                End If
            End With
        Next

        For i As Integer = 0 To dgVouchers.Rows.Count - 1
            With dgVouchers.Rows(i)
                If .Cells(11).Value = True Then                     'Funded
                    .DefaultCellStyle.BackColor = Color.Yellow
                    .DefaultCellStyle.ForeColor = Color.Black
                    .Cells(0).ReadOnly = True
                End If
                If .Cells(8).Value = True Then                      'Released
                    .DefaultCellStyle.BackColor = Color.Green
                    .DefaultCellStyle.ForeColor = Color.White
                    .Cells(0).ReadOnly = True
                End If
                If .Cells(9).Value = True Then                      'Liquidated
                    .DefaultCellStyle.BackColor = Color.Blue
                    .DefaultCellStyle.ForeColor = Color.White
                    .Cells(0).ReadOnly = True
                End If
                If .Cells(10).Value = True Then                     'Cancelled
                    .DefaultCellStyle.BackColor = Color.Red
                    .DefaultCellStyle.ForeColor = Color.White
                    .Cells(0).ReadOnly = True
                End If
            End With
        Next
    End Sub

    Public Sub funded()
        Dim strsql As String

        strsql = "SELECT `Counter` from tbl_counter WHERE Description ='CheckMC_Fund' AND CompanyCode ='" & strCompanyCode & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdsql.ExecuteReader
        While reader.Read
            FundCode = reader.Item("Counter")
            FundKey = "AISFUND" & Format$(FundCode, "000000").ToString & Format$(GetServerDate, "yy").ToString
        End While
        cmdsql.Dispose()
        reader.Close()

        strsql = "UPDATE tbl_counter SET Counter = '" & (Val(FundCode) + 1) & "' WHERE Description ='CheckMC_Fund' AND CompanyCode ='" & strCompanyCode & "'"
        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()
        Dim cmdsql1 = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)
        cmdsql1.ExecuteNonQuery()
        cmdsql1.Dispose()

        For i As Integer = 0 To dgVouchers.Rows.Count - 1
            With dgVouchers.Rows(i)
                If .Cells(0).Value = True Then
                    If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

                    Dim cmdsql2 As New MySqlCommand

                    strsql = "UPDATE tbl_cv SET Fund = @Fund, FundBy = @User, FundName = @FundName, FundDate = @FundDate WHERE CVNo like '" & .Cells(2).Value & "'"

                    cmdsql2 = New MySqlCommand(strsql, cnnDBMaster)

                    With cmdsql2.Parameters
                        .AddWithValue("@Fund", 1)
                        .AddWithValue("@User", CurrentUser)
                        .AddWithValue("@FundName", FundKey)
                        .AddWithValue("@FundDate", GetServerDate)
                    End With

                    cmdsql2.ExecuteNonQuery()
                    cmdsql2.Dispose()
                End If
            End With
        Next
    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        loadVouchers()
    End Sub

    Private Sub cmdFund_Click(sender As Object, e As EventArgs) Handles cmdFund.Click
        'If GetUserAccess(CurrentUsername, CurrentPassword, "Allow_SavingFund") = False Then
        '    MsgBox("You are not allowed to fund vouchers.", MsgBoxStyle.Information, "System Message")
        '    Exit Sub
        'End If
        If dgVouchers.Rows.Count = 0 Then
            MsgBox("Empty List!", MsgBoxStyle.Exclamation, "Empty...")
            Exit Sub
        End If
        For i As Integer = 0 To dgVouchers.Rows.Count - 1
            With dgVouchers.Rows(i)
                If .Cells(0).Value = True Then
                    If MsgBox("Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Continue...") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    funded()
                    MsgBox("Selected Voucher(s) Funded!", MsgBoxStyle.Information, "Done...")
                    loadVouchers()
                    Exit Sub
                End If
            End With
        Next
        MsgBox("No selected Check Voucher!", MsgBoxStyle.Exclamation, "Select...")
    End Sub

    Private Sub cmdReport_Click(sender As Object, e As EventArgs) Handles cmdReport.Click
        frmFundSearch.ShowDialog()
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        loadPrintReport()
        frmPrintPreview.loadCheckMCFundPrintReport()
        frmPrintPreview.ShowDialog()
    End Sub
End Class