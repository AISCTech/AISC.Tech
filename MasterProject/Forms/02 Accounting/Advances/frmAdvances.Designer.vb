<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdvances
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.subacctlistitemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbPayment = New System.Windows.Forms.GroupBox()
        Me.chkBank = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.txtChkNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtChkAmt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCashAmt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.subacctlistitem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subacctlist = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.subacctdeptname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subaccttitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDRTotal = New System.Windows.Forms.TextBox()
        Me.subacctdept = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCRTotal = New System.Windows.Forms.TextBox()
        Me.tslblPrepDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cboBooking = New System.Windows.Forms.ComboBox()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.subacctcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.accttitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acctcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtARNo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.gbAcctEntry = New System.Windows.Forms.GroupBox()
        Me.dtgAcctgTitle = New System.Windows.Forms.DataGridView()
        Me.gbAR = New System.Windows.Forms.GroupBox()
        Me.cboClient = New System.Windows.Forms.ComboBox()
        Me.gbServiceType = New System.Windows.Forms.GroupBox()
        Me.optImpF = New System.Windows.Forms.RadioButton()
        Me.optImpB = New System.Windows.Forms.RadioButton()
        Me.optExp = New System.Windows.Forms.RadioButton()
        Me.gbPayment.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.gbAcctEntry.SuspendLayout()
        CType(Me.dtgAcctgTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAR.SuspendLayout()
        Me.gbServiceType.SuspendLayout()
        Me.SuspendLayout()
        '
        'subacctlistitemname
        '
        Me.subacctlistitemname.HeaderText = "List Item Name"
        Me.subacctlistitemname.Name = "subacctlistitemname"
        Me.subacctlistitemname.ReadOnly = True
        Me.subacctlistitemname.Width = 300
        '
        'dr
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.dr.DefaultCellStyle = DataGridViewCellStyle5
        Me.dr.HeaderText = "Debit"
        Me.dr.Name = "dr"
        Me.dr.ReadOnly = True
        '
        'cr
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.cr.DefaultCellStyle = DataGridViewCellStyle6
        Me.cr.HeaderText = "Credit"
        Me.cr.Name = "cr"
        Me.cr.ReadOnly = True
        '
        'gbPayment
        '
        Me.gbPayment.Controls.Add(Me.chkBank)
        Me.gbPayment.Controls.Add(Me.Label12)
        Me.gbPayment.Controls.Add(Me.cboBank)
        Me.gbPayment.Controls.Add(Me.txtChkNo)
        Me.gbPayment.Controls.Add(Me.Label7)
        Me.gbPayment.Controls.Add(Me.txtChkAmt)
        Me.gbPayment.Controls.Add(Me.Label5)
        Me.gbPayment.Controls.Add(Me.txtCashAmt)
        Me.gbPayment.Controls.Add(Me.Label6)
        Me.gbPayment.Location = New System.Drawing.Point(12, 395)
        Me.gbPayment.Name = "gbPayment"
        Me.gbPayment.Size = New System.Drawing.Size(536, 87)
        Me.gbPayment.TabIndex = 453
        Me.gbPayment.TabStop = False
        Me.gbPayment.Text = "Payment"
        '
        'chkBank
        '
        Me.chkBank.AutoSize = True
        Me.chkBank.Location = New System.Drawing.Point(132, 34)
        Me.chkBank.Name = "chkBank"
        Me.chkBank.Size = New System.Drawing.Size(134, 17)
        Me.chkBank.TabIndex = 20
        Me.chkBank.Text = "Payment through Bank"
        Me.chkBank.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.Location = New System.Drawing.Point(50, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Bank Name:"
        '
        'cboBank
        '
        Me.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Location = New System.Drawing.Point(132, 58)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(378, 21)
        Me.cboBank.TabIndex = 18
        '
        'txtChkNo
        '
        Me.txtChkNo.Location = New System.Drawing.Point(375, 32)
        Me.txtChkNo.Name = "txtChkNo"
        Me.txtChkNo.Size = New System.Drawing.Size(135, 20)
        Me.txtChkNo.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(298, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Check No.:"
        '
        'txtChkAmt
        '
        Me.txtChkAmt.Location = New System.Drawing.Point(375, 13)
        Me.txtChkAmt.Name = "txtChkAmt"
        Me.txtChkAmt.Size = New System.Drawing.Size(135, 20)
        Me.txtChkAmt.TabIndex = 15
        Me.txtChkAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(276, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Check Amount:"
        '
        'txtCashAmt
        '
        Me.txtCashAmt.Location = New System.Drawing.Point(132, 13)
        Me.txtCashAmt.Name = "txtCashAmt"
        Me.txtCashAmt.Size = New System.Drawing.Size(135, 20)
        Me.txtCashAmt.TabIndex = 13
        Me.txtCashAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(41, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cash Amount:"
        '
        'subacctlistitem
        '
        Me.subacctlistitem.HeaderText = "List Item"
        Me.subacctlistitem.Name = "subacctlistitem"
        Me.subacctlistitem.ReadOnly = True
        Me.subacctlistitem.Width = 200
        '
        'subacctlist
        '
        Me.subacctlist.HeaderText = "List"
        Me.subacctlist.Name = "subacctlist"
        Me.subacctlist.ReadOnly = True
        Me.subacctlist.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.subacctlist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.subacctlist.Width = 50
        '
        'subacctdeptname
        '
        Me.subacctdeptname.HeaderText = "Department"
        Me.subacctdeptname.Name = "subacctdeptname"
        Me.subacctdeptname.ReadOnly = True
        Me.subacctdeptname.Width = 125
        '
        'subaccttitle
        '
        Me.subaccttitle.HeaderText = "Sub Account Title"
        Me.subaccttitle.Name = "subaccttitle"
        Me.subaccttitle.ReadOnly = True
        Me.subaccttitle.Width = 300
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(278, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 256
        Me.Label2.Text = "Total Credit : "
        '
        'txtDRTotal
        '
        Me.txtDRTotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDRTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDRTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDRTotal.Location = New System.Drawing.Point(96, 186)
        Me.txtDRTotal.Name = "txtDRTotal"
        Me.txtDRTotal.ReadOnly = True
        Me.txtDRTotal.Size = New System.Drawing.Size(159, 22)
        Me.txtDRTotal.TabIndex = 255
        '
        'subacctdept
        '
        Me.subacctdept.HeaderText = "Dept"
        Me.subacctdept.Name = "subacctdept"
        Me.subacctdept.ReadOnly = True
        Me.subacctdept.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.subacctdept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.subacctdept.Width = 50
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(8, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 254
        Me.Label3.Text = "Total Debit : "
        '
        'txtCRTotal
        '
        Me.txtCRTotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCRTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCRTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCRTotal.Location = New System.Drawing.Point(369, 186)
        Me.txtCRTotal.Name = "txtCRTotal"
        Me.txtCRTotal.ReadOnly = True
        Me.txtCRTotal.Size = New System.Drawing.Size(159, 22)
        Me.txtCRTotal.TabIndex = 257
        '
        'tslblPrepDate
        '
        Me.tslblPrepDate.Name = "tslblPrepDate"
        Me.tslblPrepDate.Size = New System.Drawing.Size(26, 17)
        Me.tslblPrepDate.Text = "test"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel3.Text = "Status:"
        '
        'cboBooking
        '
        Me.cboBooking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBooking.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBooking.FormattingEnabled = True
        Me.cboBooking.Location = New System.Drawing.Point(122, 151)
        Me.cboBooking.Name = "cboBooking"
        Me.cboBooking.Size = New System.Drawing.Size(426, 21)
        Me.cboBooking.TabIndex = 455
        '
        'tslblStatus
        '
        Me.tslblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(32, 17)
        Me.tslblStatus.Text = "Test"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(84, 17)
        Me.ToolStripStatusLabel2.Text = "Prepared Date:"
        '
        'tslblPrepBy
        '
        Me.tslblPrepBy.Name = "tslblPrepBy"
        Me.tslblPrepBy.Size = New System.Drawing.Size(26, 17)
        Me.tslblPrepBy.Text = "test"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(76, 17)
        Me.ToolStripStatusLabel1.Text = "Prepared By :"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslblPrepBy, Me.ToolStripStatusLabel2, Me.tslblPrepDate, Me.ToolStripStatusLabel3, Me.tslblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 504)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(564, 22)
        Me.StatusStrip1.TabIndex = 454
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'subacctcode
        '
        Me.subacctcode.HeaderText = "Sub Acct Code"
        Me.subacctcode.Name = "subacctcode"
        Me.subacctcode.ReadOnly = True
        Me.subacctcode.Width = 80
        '
        'accttitle
        '
        Me.accttitle.HeaderText = "Account Title"
        Me.accttitle.Name = "accttitle"
        Me.accttitle.ReadOnly = True
        Me.accttitle.Width = 300
        '
        'acctcode
        '
        Me.acctcode.HeaderText = "Account Code"
        Me.acctcode.Name = "acctcode"
        Me.acctcode.ReadOnly = True
        Me.acctcode.Width = 125
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 456
        Me.Label4.Text = "Booking/House BL :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(9, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "Client Name:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.Location = New System.Drawing.Point(257, 279)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 13)
        Me.Label25.TabIndex = 443
        Me.Label25.Text = "Total Credit : "
        '
        'txtARNo
        '
        Me.txtARNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtARNo.Location = New System.Drawing.Point(6, 15)
        Me.txtARNo.Name = "txtARNo"
        Me.txtARNo.Size = New System.Drawing.Size(523, 20)
        Me.txtARNo.TabIndex = 3
        Me.txtARNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.Location = New System.Drawing.Point(211, 251)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 13)
        Me.Label26.TabIndex = 442
        Me.Label26.Text = "Total Debit : "
        '
        'gbAcctEntry
        '
        Me.gbAcctEntry.Controls.Add(Me.dtgAcctgTitle)
        Me.gbAcctEntry.Controls.Add(Me.Label2)
        Me.gbAcctEntry.Controls.Add(Me.txtDRTotal)
        Me.gbAcctEntry.Controls.Add(Me.Label3)
        Me.gbAcctEntry.Controls.Add(Me.txtCRTotal)
        Me.gbAcctEntry.Location = New System.Drawing.Point(12, 174)
        Me.gbAcctEntry.Name = "gbAcctEntry"
        Me.gbAcctEntry.Size = New System.Drawing.Size(536, 214)
        Me.gbAcctEntry.TabIndex = 452
        Me.gbAcctEntry.TabStop = False
        Me.gbAcctEntry.Text = "Accounting Entry"
        '
        'dtgAcctgTitle
        '
        Me.dtgAcctgTitle.AllowUserToAddRows = False
        Me.dtgAcctgTitle.AllowUserToDeleteRows = False
        Me.dtgAcctgTitle.AllowUserToResizeRows = False
        Me.dtgAcctgTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAcctgTitle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acctcode, Me.accttitle, Me.subacctcode, Me.subaccttitle, Me.subacctdept, Me.subacctdeptname, Me.subacctlist, Me.subacctlistitem, Me.subacctlistitemname, Me.dr, Me.cr})
        Me.dtgAcctgTitle.Location = New System.Drawing.Point(6, 19)
        Me.dtgAcctgTitle.Name = "dtgAcctgTitle"
        Me.dtgAcctgTitle.ReadOnly = True
        Me.dtgAcctgTitle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAcctgTitle.Size = New System.Drawing.Size(522, 161)
        Me.dtgAcctgTitle.TabIndex = 253
        '
        'gbAR
        '
        Me.gbAR.Controls.Add(Me.txtARNo)
        Me.gbAR.Location = New System.Drawing.Point(12, 102)
        Me.gbAR.Name = "gbAR"
        Me.gbAR.Size = New System.Drawing.Size(536, 43)
        Me.gbAR.TabIndex = 451
        Me.gbAR.TabStop = False
        Me.gbAR.Text = "A.R. Number"
        '
        'cboClient
        '
        Me.cboClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClient.FormattingEnabled = True
        Me.cboClient.Location = New System.Drawing.Point(94, 75)
        Me.cboClient.Name = "cboClient"
        Me.cboClient.Size = New System.Drawing.Size(454, 21)
        Me.cboClient.TabIndex = 449
        '
        'gbServiceType
        '
        Me.gbServiceType.Controls.Add(Me.optImpF)
        Me.gbServiceType.Controls.Add(Me.optImpB)
        Me.gbServiceType.Controls.Add(Me.optExp)
        Me.gbServiceType.Location = New System.Drawing.Point(12, 12)
        Me.gbServiceType.Name = "gbServiceType"
        Me.gbServiceType.Size = New System.Drawing.Size(536, 53)
        Me.gbServiceType.TabIndex = 448
        Me.gbServiceType.TabStop = False
        Me.gbServiceType.Text = "Service Type"
        '
        'optImpF
        '
        Me.optImpF.AutoSize = True
        Me.optImpF.Location = New System.Drawing.Point(374, 24)
        Me.optImpF.Name = "optImpF"
        Me.optImpF.Size = New System.Drawing.Size(109, 17)
        Me.optImpF.TabIndex = 2
        Me.optImpF.Text = "Import Forwarding"
        Me.optImpF.UseVisualStyleBackColor = True
        '
        'optImpB
        '
        Me.optImpB.AutoSize = True
        Me.optImpB.Location = New System.Drawing.Point(191, 24)
        Me.optImpB.Name = "optImpB"
        Me.optImpB.Size = New System.Drawing.Size(106, 17)
        Me.optImpB.TabIndex = 1
        Me.optImpB.Text = "Import Brokerage"
        Me.optImpB.UseVisualStyleBackColor = True
        '
        'optExp
        '
        Me.optExp.AutoSize = True
        Me.optExp.Checked = True
        Me.optExp.Location = New System.Drawing.Point(44, 24)
        Me.optExp.Name = "optExp"
        Me.optExp.Size = New System.Drawing.Size(55, 17)
        Me.optExp.TabIndex = 0
        Me.optExp.TabStop = True
        Me.optExp.Text = "Export"
        Me.optExp.UseVisualStyleBackColor = True
        '
        'frmAdvances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 526)
        Me.Controls.Add(Me.gbAcctEntry)
        Me.Controls.Add(Me.gbPayment)
        Me.Controls.Add(Me.cboBooking)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.gbAR)
        Me.Controls.Add(Me.cboClient)
        Me.Controls.Add(Me.gbServiceType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAdvances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advances"
        Me.gbPayment.ResumeLayout(False)
        Me.gbPayment.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gbAcctEntry.ResumeLayout(False)
        Me.gbAcctEntry.PerformLayout()
        CType(Me.dtgAcctgTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAR.ResumeLayout(False)
        Me.gbAR.PerformLayout()
        Me.gbServiceType.ResumeLayout(False)
        Me.gbServiceType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents subacctlistitemname As DataGridViewTextBoxColumn
    Friend WithEvents dr As DataGridViewTextBoxColumn
    Friend WithEvents cr As DataGridViewTextBoxColumn
    Friend WithEvents gbPayment As GroupBox
    Friend WithEvents chkBank As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents txtChkNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtChkAmt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCashAmt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents subacctlistitem As DataGridViewTextBoxColumn
    Friend WithEvents subacctlist As DataGridViewCheckBoxColumn
    Friend WithEvents subacctdeptname As DataGridViewTextBoxColumn
    Friend WithEvents subaccttitle As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDRTotal As TextBox
    Friend WithEvents subacctdept As DataGridViewCheckBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCRTotal As TextBox
    Friend WithEvents tslblPrepDate As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents cboBooking As ComboBox
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tslblPrepBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents subacctcode As DataGridViewTextBoxColumn
    Friend WithEvents accttitle As DataGridViewTextBoxColumn
    Friend WithEvents acctcode As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtARNo As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents gbAcctEntry As GroupBox
    Friend WithEvents dtgAcctgTitle As DataGridView
    Friend WithEvents gbAR As GroupBox
    Friend WithEvents cboClient As ComboBox
    Friend WithEvents gbServiceType As GroupBox
    Friend WithEvents optImpF As RadioButton
    Friend WithEvents optImpB As RadioButton
    Friend WithEvents optExp As RadioButton
End Class
