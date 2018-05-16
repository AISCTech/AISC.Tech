<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChequeMCFund
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDateTo = New System.Windows.Forms.DateTimePicker()
        Me.txtDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.checked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.bankname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgVouchers = New System.Windows.Forms.DataGridView()
        Me.prepared_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.voucher = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bank_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.check_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.check_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.payee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.release = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.liquidate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cancel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.cmdFund = New System.Windows.Forms.Button()
        Me.optBank = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgBanks = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkOpen = New System.Windows.Forms.CheckBox()
        Me.chkFunded = New System.Windows.Forms.CheckBox()
        Me.chkCancelled = New System.Windows.Forms.CheckBox()
        Me.chkLiquidated = New System.Windows.Forms.CheckBox()
        Me.chkReleased = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgVouchers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgBanks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(31, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Open"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(31, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Funded"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Location = New System.Drawing.Point(9, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(16, 14)
        Me.Label14.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 115)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtDateTo
        '
        Me.txtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDateTo.Location = New System.Drawing.Point(81, 65)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(179, 20)
        Me.txtDateTo.TabIndex = 4
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDateFrom.Location = New System.Drawing.Point(81, 40)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(179, 20)
        Me.txtDateFrom.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PERIOD"
        '
        'checked
        '
        Me.checked.HeaderText = ""
        Me.checked.Name = "checked"
        Me.checked.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.checked.Width = 20
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Yellow
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(9, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 14)
        Me.Label12.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(31, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Cancelled"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Liquidated"
        '
        'bankname
        '
        Me.bankname.HeaderText = "Bank Name"
        Me.bankname.Name = "bankname"
        Me.bankname.ReadOnly = True
        Me.bankname.Width = 320
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "BANK"
        '
        'dgVouchers
        '
        Me.dgVouchers.AllowUserToAddRows = False
        Me.dgVouchers.AllowUserToDeleteRows = False
        Me.dgVouchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVouchers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.checked, Me.prepared_date, Me.voucher, Me.bank_name, Me.check_no, Me.check_date, Me.payee, Me.amount, Me.release, Me.liquidate, Me.cancel, Me.fund})
        Me.dgVouchers.Location = New System.Drawing.Point(-7, 124)
        Me.dgVouchers.Name = "dgVouchers"
        Me.dgVouchers.Size = New System.Drawing.Size(1056, 416)
        Me.dgVouchers.TabIndex = 8
        '
        'prepared_date
        '
        Me.prepared_date.HeaderText = "Prepared Date"
        Me.prepared_date.Name = "prepared_date"
        Me.prepared_date.ReadOnly = True
        Me.prepared_date.Width = 120
        '
        'voucher
        '
        Me.voucher.HeaderText = "Voucher"
        Me.voucher.Name = "voucher"
        Me.voucher.ReadOnly = True
        Me.voucher.Width = 110
        '
        'bank_name
        '
        Me.bank_name.HeaderText = "Bank Name"
        Me.bank_name.Name = "bank_name"
        Me.bank_name.ReadOnly = True
        Me.bank_name.Width = 220
        '
        'check_no
        '
        Me.check_no.HeaderText = "Check No."
        Me.check_no.Name = "check_no"
        Me.check_no.ReadOnly = True
        Me.check_no.Width = 90
        '
        'check_date
        '
        Me.check_date.HeaderText = "Check Date"
        Me.check_date.Name = "check_date"
        Me.check_date.ReadOnly = True
        Me.check_date.Width = 125
        '
        'payee
        '
        Me.payee.HeaderText = "Payee"
        Me.payee.Name = "payee"
        Me.payee.ReadOnly = True
        Me.payee.Width = 200
        '
        'amount
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.amount.DefaultCellStyle = DataGridViewCellStyle6
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        Me.amount.Width = 110
        '
        'release
        '
        Me.release.HeaderText = "release"
        Me.release.Name = "release"
        Me.release.Visible = False
        '
        'liquidate
        '
        Me.liquidate.HeaderText = "liquidate"
        Me.liquidate.Name = "liquidate"
        Me.liquidate.Visible = False
        '
        'cancel
        '
        Me.cancel.HeaderText = "cancel"
        Me.cancel.Name = "cancel"
        Me.cancel.Visible = False
        '
        'fund
        '
        Me.fund.HeaderText = "funded"
        Me.fund.Name = "fund"
        Me.fund.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(31, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Released"
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(160, 547)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(150, 37)
        Me.cmdReport.TabIndex = 10
        Me.cmdReport.Text = "Funding Report"
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'cmdFund
        '
        Me.cmdFund.Location = New System.Drawing.Point(4, 547)
        Me.cmdFund.Name = "cmdFund"
        Me.cmdFund.Size = New System.Drawing.Size(150, 37)
        Me.cmdFund.TabIndex = 9
        Me.cmdFund.Text = "Fund"
        Me.cmdFund.UseVisualStyleBackColor = True
        '
        'optBank
        '
        Me.optBank.HeaderText = ""
        Me.optBank.Name = "optBank"
        Me.optBank.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.optBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.optBank.Width = 20
        '
        'dgBanks
        '
        Me.dgBanks.AllowUserToAddRows = False
        Me.dgBanks.AllowUserToDeleteRows = False
        Me.dgBanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBanks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.optBank, Me.bankname})
        Me.dgBanks.Location = New System.Drawing.Point(63, 18)
        Me.dgBanks.Name = "dgBanks"
        Me.dgBanks.Size = New System.Drawing.Size(401, 85)
        Me.dgBanks.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.chkOpen)
        Me.Panel2.Controls.Add(Me.chkFunded)
        Me.Panel2.Controls.Add(Me.chkCancelled)
        Me.Panel2.Controls.Add(Me.chkLiquidated)
        Me.Panel2.Controls.Add(Me.chkReleased)
        Me.Panel2.Location = New System.Drawing.Point(470, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(101, 85)
        Me.Panel2.TabIndex = 5
        '
        'chkOpen
        '
        Me.chkOpen.AutoSize = True
        Me.chkOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOpen.Location = New System.Drawing.Point(3, 66)
        Me.chkOpen.Name = "chkOpen"
        Me.chkOpen.Size = New System.Drawing.Size(56, 17)
        Me.chkOpen.TabIndex = 4
        Me.chkOpen.Text = "Open"
        Me.chkOpen.UseVisualStyleBackColor = True
        '
        'chkFunded
        '
        Me.chkFunded.AutoSize = True
        Me.chkFunded.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFunded.Location = New System.Drawing.Point(3, 50)
        Me.chkFunded.Name = "chkFunded"
        Me.chkFunded.Size = New System.Drawing.Size(68, 17)
        Me.chkFunded.TabIndex = 3
        Me.chkFunded.Text = "Funded"
        Me.chkFunded.UseVisualStyleBackColor = True
        '
        'chkCancelled
        '
        Me.chkCancelled.AutoSize = True
        Me.chkCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCancelled.Location = New System.Drawing.Point(3, 34)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.Size = New System.Drawing.Size(82, 17)
        Me.chkCancelled.TabIndex = 2
        Me.chkCancelled.Text = "Cancelled"
        Me.chkCancelled.UseVisualStyleBackColor = True
        '
        'chkLiquidated
        '
        Me.chkLiquidated.AutoSize = True
        Me.chkLiquidated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLiquidated.Location = New System.Drawing.Point(3, 18)
        Me.chkLiquidated.Name = "chkLiquidated"
        Me.chkLiquidated.Size = New System.Drawing.Size(85, 17)
        Me.chkLiquidated.TabIndex = 1
        Me.chkLiquidated.Text = "Liquidated"
        Me.chkLiquidated.UseVisualStyleBackColor = True
        '
        'chkReleased
        '
        Me.chkReleased.AutoSize = True
        Me.chkReleased.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReleased.Location = New System.Drawing.Point(3, 2)
        Me.chkReleased.Name = "chkReleased"
        Me.chkReleased.Size = New System.Drawing.Size(79, 17)
        Me.chkReleased.TabIndex = 0
        Me.chkReleased.Text = "Released"
        Me.chkReleased.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.cmdLoad)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.dgBanks)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(284, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(776, 115)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(577, 18)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(59, 85)
        Me.cmdLoad.TabIndex = 4
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(642, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(127, 85)
        Me.Panel1.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Red
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(9, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 14)
        Me.Label7.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Blue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(9, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 14)
        Me.Label6.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.ForestGreen
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(9, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 14)
        Me.Label5.TabIndex = 0
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(889, 547)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(150, 37)
        Me.cmdPrint.TabIndex = 11
        Me.cmdPrint.Text = "Print Report"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'frmChequeMCFund
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 608)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgVouchers)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdFund)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmChequeMCFund"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheque MC Funding"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgVouchers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgBanks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDateTo As DateTimePicker
    Friend WithEvents txtDateFrom As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents checked As DataGridViewCheckBoxColumn
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents bankname As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents dgVouchers As DataGridView
    Friend WithEvents prepared_date As DataGridViewTextBoxColumn
    Friend WithEvents voucher As DataGridViewTextBoxColumn
    Friend WithEvents bank_name As DataGridViewTextBoxColumn
    Friend WithEvents check_no As DataGridViewTextBoxColumn
    Friend WithEvents check_date As DataGridViewTextBoxColumn
    Friend WithEvents payee As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents release As DataGridViewTextBoxColumn
    Friend WithEvents liquidate As DataGridViewTextBoxColumn
    Friend WithEvents cancel As DataGridViewTextBoxColumn
    Friend WithEvents fund As DataGridViewTextBoxColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents cmdReport As Button
    Friend WithEvents cmdFund As Button
    Friend WithEvents optBank As DataGridViewCheckBoxColumn
    Friend WithEvents dgBanks As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkOpen As CheckBox
    Friend WithEvents chkFunded As CheckBox
    Friend WithEvents chkCancelled As CheckBox
    Friend WithEvents chkLiquidated As CheckBox
    Friend WithEvents chkReleased As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdLoad As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdPrint As Button
End Class
