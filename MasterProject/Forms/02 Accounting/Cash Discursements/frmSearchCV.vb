Public Class frmSearchCV
    Private Sub frmSearchCV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SetRowColor(ByVal grid As DataGridView)
        Dim x As Integer, y As Integer, pcr As String, newcolor As Color

        If grid.RowCount >= 1 Then
            pcr = grid.Rows(0).Cells(0).Value
            newcolor = Color.LightBlue
        Else
            Exit Sub
        End If

        For x = 0 To grid.RowCount - 1
            If grid.Rows(x).Cells(0).Value = pcr Then
                For y = 0 To grid.ColumnCount - 1
                    grid.Rows(x).Cells(y).Style.BackColor = newcolor
                Next
            Else
                If newcolor = Color.LightBlue Then
                    newcolor = Color.White
                Else
                    newcolor = Color.LightBlue
                End If
                For y = 0 To grid.ColumnCount - 1
                    grid.Rows(x).Cells(y).Style.BackColor = newcolor
                Next
                pcr = grid.Rows(x).Cells(0).Value
            End If
        Next
    End Sub

    Private Sub PopCVs()
        Dim strCVType As String

        Select Case Me.Tag
            Case "CV"
                strCVType = "Check"
            Case "MCV"
                strCVType = "MC"
            Case Else
                strCVType = ""
        End Select

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim strsql As String = "SELECT tbl_cv.CVNo, tbl_cv.PrepDate, tbl_cvp.APVNo, tbl_cvp.ReqNo, tbl_cv.CheckDate " &
                                "FROM tbl_cv INNER JOIN tbl_cvp ON tbl_cv.CVNo = tbl_cvp.CVNo " &
                                "WHERE tbl_cv.PrepDate " &
                                "BETWEEN '" & Format$(Me.dtFrom.Value, "yyyy-MM-dd 00:00:00") & "' " &
                                "AND '" & Format$(Me.dtTo.Value, "yyyy-MM-dd 23:59:59") & "' " &
                                "AND tbl_cv.VoucherType = '" & strCVType & "'"

        Dim cmdSQL = New MySql.Data.MySqlClient.MySqlCommand(strsql, cnnDBMaster)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmdSQL.ExecuteReader

        Me.dtgSearchCV.Rows.Clear()

        While reader.Read
            Me.dtgSearchCV.Rows.Add(reader.Item("CVNo"), reader.Item("ReqNo"), reader.Item("APVNo"), reader.Item("PrepDate"), Format(reader.Item("CheckDate"), "MM/dd/yyyy"))
        End While

        reader.Close()
        cmdSQL.Dispose()

        SetRowColor(Me.dtgSearchCV)
    End Sub

    Private Sub dtgSearchCV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSearchCV.CellContentClick

    End Sub

    Private Sub dtgSearchCV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgSearchCV.CellDoubleClick
        If Me.dtgSearchCV.Rows.Count > 0 Then
            With frmCV
                .PopCV(Me.dtgSearchCV.CurrentRow.Cells("colCVNo").Value)
                .ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)
            End With
        End If
        Me.Close()
    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        PopCVs()
    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs) Handles dtTo.ValueChanged
        PopCVs()
    End Sub

    Private Sub dtgSearchCV_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dtgSearchCV.CellPainting
        Dim i As Integer
        'Dim i2 As Integer
        ' Dim i2 As Integer
        For i = 0 To Me.dtgSearchCV.Columns.Count - 1
            If e.ColumnIndex = i AndAlso e.RowIndex <> -1 Then
                Using gridBrush As Brush = New SolidBrush(Me.dtgSearchCV.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)
                        ' Clear cell  
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        'If next row cell has different content, only draw bottom border line of current cell
                        If e.ColumnIndex = 0 Then
                            If e.RowIndex < dtgSearchCV.Rows.Count - 2 AndAlso dtgSearchCV.Rows(e.RowIndex + 1).Cells(0).Value.ToString() <> dtgSearchCV.Rows(e.RowIndex).Cells(0).Value.ToString() Then
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                            End If
                        Else
                            If e.RowIndex < dtgSearchCV.Rows.Count - 1 AndAlso dtgSearchCV.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                            End If
                        End If

                        ' Draw right border line of current cell  
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        ' draw/fill content in current cell, and fill only one cell of multiple same cells  
                        If Not e.Value Is Nothing Then

                            If e.ColumnIndex = 0 Then
                                If e.RowIndex > 0 AndAlso dtgSearchCV.Rows(e.RowIndex - 1).Cells(0).Value.ToString() = dtgSearchCV.Rows(e.RowIndex).Cells(0).Value.ToString() Then
                                Else
                                    e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                                End If
                            Else
                                If e.RowIndex > 0 AndAlso dtgSearchCV.Rows(e.RowIndex - 1).Cells(i).Value.ToString() = e.Value.ToString() Then
                                Else
                                    e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                                End If
                            End If
                        End If
                        e.Handled = True
                    End Using
                End Using
            End If
        Next
    End Sub

    Private Sub txtRefNo_TextChanged(sender As Object, e As EventArgs) Handles txtRefNo.TextChanged

    End Sub

    Private Sub dtgSearchCV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgSearchCV.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            cmdSearch_Click(sender, e)
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        With frmCV
            .PopCV(Me.lblPrefix.Text & Me.txtRefNo.Text)
            .ChangeEnabledButtons(True, True, False, False, True, True, True, True, True, False)

        End With
        Me.Close()
    End Sub
End Class