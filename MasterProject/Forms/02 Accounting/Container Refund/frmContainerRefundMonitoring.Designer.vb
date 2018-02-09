<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContainerRefundMonitoring
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdPrintPrev = New System.Windows.Forms.Button()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBKNbr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCnee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShpLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReqNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCtrlNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCollectionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReqDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgContRefMonitoring = New System.Windows.Forms.DataGridView()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optAll = New System.Windows.Forms.RadioButton()
        Me.optPaid = New System.Windows.Forms.RadioButton()
        Me.optBalance = New System.Windows.Forms.RadioButton()
        Me.optOutstanding = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dtgContRefMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPrintPrev
        '
        Me.cmdPrintPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintPrev.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPrintPrev.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPrintPrev.Location = New System.Drawing.Point(276, 35)
        Me.cmdPrintPrev.Name = "cmdPrintPrev"
        Me.cmdPrintPrev.Size = New System.Drawing.Size(90, 29)
        Me.cmdPrintPrev.TabIndex = 1218
        Me.cmdPrintPrev.Text = "Print Preview"
        Me.cmdPrintPrev.UseVisualStyleBackColor = True
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        '
        'colAmt
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAmt.DefaultCellStyle = DataGridViewCellStyle1
        Me.colAmt.HeaderText = "Amount"
        Me.colAmt.Name = "colAmt"
        Me.colAmt.ReadOnly = True
        '
        'colBKNbr
        '
        Me.colBKNbr.HeaderText = "Booking No."
        Me.colBKNbr.Name = "colBKNbr"
        Me.colBKNbr.ReadOnly = True
        Me.colBKNbr.Width = 150
        '
        'colCnee
        '
        Me.colCnee.HeaderText = "Consignee"
        Me.colCnee.Name = "colCnee"
        Me.colCnee.ReadOnly = True
        Me.colCnee.Width = 250
        '
        'colShpLine
        '
        Me.colShpLine.HeaderText = "Shipping Line"
        Me.colShpLine.Name = "colShpLine"
        Me.colShpLine.ReadOnly = True
        Me.colShpLine.Width = 250
        '
        'colReqNo
        '
        Me.colReqNo.HeaderText = "Request No."
        Me.colReqNo.Name = "colReqNo"
        Me.colReqNo.ReadOnly = True
        '
        'colCtrlNum
        '
        Me.colCtrlNum.HeaderText = "Control No."
        Me.colCtrlNum.Name = "colCtrlNum"
        Me.colCtrlNum.ReadOnly = True
        Me.colCtrlNum.Width = 120
        '
        'colCollectionDate
        '
        Me.colCollectionDate.HeaderText = "Collection Date"
        Me.colCollectionDate.Name = "colCollectionDate"
        Me.colCollectionDate.ReadOnly = True
        '
        'colBillDate
        '
        Me.colBillDate.HeaderText = "Bill Date"
        Me.colBillDate.Name = "colBillDate"
        Me.colBillDate.ReadOnly = True
        '
        'colReqDate
        '
        Me.colReqDate.HeaderText = "Request Date"
        Me.colReqDate.Name = "colReqDate"
        Me.colReqDate.ReadOnly = True
        '
        'dtgContRefMonitoring
        '
        Me.dtgContRefMonitoring.AllowUserToAddRows = False
        Me.dtgContRefMonitoring.AllowUserToDeleteRows = False
        Me.dtgContRefMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgContRefMonitoring.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReqDate, Me.colBillDate, Me.colCollectionDate, Me.colCtrlNum, Me.colReqNo, Me.colShpLine, Me.colCnee, Me.colBKNbr, Me.colAmt, Me.colStatus, Me.colRemarks})
        Me.dtgContRefMonitoring.Location = New System.Drawing.Point(12, 70)
        Me.dtgContRefMonitoring.Name = "dtgContRefMonitoring"
        Me.dtgContRefMonitoring.ReadOnly = True
        Me.dtgContRefMonitoring.Size = New System.Drawing.Size(946, 399)
        Me.dtgContRefMonitoring.TabIndex = 1216
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        Me.colRemarks.Width = 300
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Checked = True
        Me.optAll.Location = New System.Drawing.Point(6, 19)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(36, 17)
        Me.optAll.TabIndex = 3
        Me.optAll.TabStop = True
        Me.optAll.Text = "All"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'optPaid
        '
        Me.optPaid.AutoSize = True
        Me.optPaid.Location = New System.Drawing.Point(206, 19)
        Me.optPaid.Name = "optPaid"
        Me.optPaid.Size = New System.Drawing.Size(46, 17)
        Me.optPaid.TabIndex = 2
        Me.optPaid.Text = "Paid"
        Me.optPaid.UseVisualStyleBackColor = True
        '
        'optBalance
        '
        Me.optBalance.AutoSize = True
        Me.optBalance.Location = New System.Drawing.Point(136, 19)
        Me.optBalance.Name = "optBalance"
        Me.optBalance.Size = New System.Drawing.Size(64, 17)
        Me.optBalance.TabIndex = 1
        Me.optBalance.Text = "Balance"
        Me.optBalance.UseVisualStyleBackColor = True
        '
        'optOutstanding
        '
        Me.optOutstanding.AutoSize = True
        Me.optOutstanding.Location = New System.Drawing.Point(48, 19)
        Me.optOutstanding.Name = "optOutstanding"
        Me.optOutstanding.Size = New System.Drawing.Size(82, 17)
        Me.optOutstanding.TabIndex = 0
        Me.optOutstanding.Text = "Outstanding"
        Me.optOutstanding.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optAll)
        Me.GroupBox1.Controls.Add(Me.optPaid)
        Me.GroupBox1.Controls.Add(Me.optBalance)
        Me.GroupBox1.Controls.Add(Me.optOutstanding)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 48)
        Me.GroupBox1.TabIndex = 1217
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'frmContainerRefundMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 480)
        Me.Controls.Add(Me.cmdPrintPrev)
        Me.Controls.Add(Me.dtgContRefMonitoring)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmContainerRefundMonitoring"
        Me.Text = "frmContainerRefundMonitoring"
        CType(Me.dtgContRefMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdPrintPrev As Button
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colAmt As DataGridViewTextBoxColumn
    Friend WithEvents colBKNbr As DataGridViewTextBoxColumn
    Friend WithEvents colCnee As DataGridViewTextBoxColumn
    Friend WithEvents colShpLine As DataGridViewTextBoxColumn
    Friend WithEvents colReqNo As DataGridViewTextBoxColumn
    Friend WithEvents colCtrlNum As DataGridViewTextBoxColumn
    Friend WithEvents colCollectionDate As DataGridViewTextBoxColumn
    Friend WithEvents colBillDate As DataGridViewTextBoxColumn
    Friend WithEvents colReqDate As DataGridViewTextBoxColumn
    Friend WithEvents dtgContRefMonitoring As DataGridView
    Friend WithEvents colRemarks As DataGridViewTextBoxColumn
    Friend WithEvents optAll As RadioButton
    Friend WithEvents optPaid As RadioButton
    Friend WithEvents optBalance As RadioButton
    Friend WithEvents optOutstanding As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
End Class
