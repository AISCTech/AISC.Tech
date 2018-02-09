<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOfficialReceipt
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOfficialReceipt))
        Me.chkBank = New System.Windows.Forms.CheckBox()
        Me.cmdCompCheck = New System.Windows.Forms.Button()
        Me.cmdCompCash = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtDRTotal = New System.Windows.Forms.TextBox()
        Me.colAcctCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtCRTotal = New System.Windows.Forms.TextBox()
        Me.dtgAcctgTitle = New System.Windows.Forms.DataGridView()
        Me.colAcctTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubAcctCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubAcctTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDept = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDeptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colList = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colListItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colListItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalBilling = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtOverPayment = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAmtInWords = New System.Windows.Forms.TextBox()
        Me.txtBalanceTotal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtOthChargesTotal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCWTTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPaymentTotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.colORBal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpORPayment = New System.Windows.Forms.GroupBox()
        Me.txtChkNo = New System.Windows.Forms.TextBox()
        Me.txtChkAmt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCashAmt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optImpF = New System.Windows.Forms.RadioButton()
        Me.optImpB = New System.Windows.Forms.RadioButton()
        Me.optExp = New System.Windows.Forms.RadioButton()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.colBookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgBkgNbr = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.colORAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.colOROthChrg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gpLegend = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gpBilling = New System.Windows.Forms.GroupBox()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.dtgBilling = New System.Windows.Forms.DataGridView()
        Me.colBillRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillInv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillVAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.optBillNo = New System.Windows.Forms.RadioButton()
        Me.optInvNo = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboClient = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.colORBillAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colORInv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colORBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgORInv = New System.Windows.Forms.DataGridView()
        Me.colORCWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdRemoveSRow = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.gpOR = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtORNo = New System.Windows.Forms.TextBox()
        Me.tscmdSearchOR = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.tslblPrefix = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmdClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtgAcctgTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.gpORPayment.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dtgBkgNbr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.gpLegend.SuspendLayout()
        Me.gpBilling.SuspendLayout()
        CType(Me.dtgBilling, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dtgORInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.gpOR.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkBank
        '
        Me.chkBank.AutoSize = True
        Me.chkBank.Location = New System.Drawing.Point(123, 38)
        Me.chkBank.Name = "chkBank"
        Me.chkBank.Size = New System.Drawing.Size(134, 17)
        Me.chkBank.TabIndex = 383
        Me.chkBank.Text = "Payment through Bank"
        Me.chkBank.UseVisualStyleBackColor = True
        '
        'cmdCompCheck
        '
        Me.cmdCompCheck.Location = New System.Drawing.Point(492, 14)
        Me.cmdCompCheck.Name = "cmdCompCheck"
        Me.cmdCompCheck.Size = New System.Drawing.Size(23, 20)
        Me.cmdCompCheck.TabIndex = 431
        Me.ToolTip1.SetToolTip(Me.cmdCompCheck, "Compute remaining amount to check")
        Me.cmdCompCheck.UseVisualStyleBackColor = True
        '
        'cmdCompCash
        '
        Me.cmdCompCash.Location = New System.Drawing.Point(244, 14)
        Me.cmdCompCash.Name = "cmdCompCash"
        Me.cmdCompCash.Size = New System.Drawing.Size(23, 20)
        Me.cmdCompCash.TabIndex = 430
        Me.ToolTip1.SetToolTip(Me.cmdCompCash, "Compute remaining amount to cash")
        Me.cmdCompCash.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.Location = New System.Drawing.Point(41, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Bank Name:"
        '
        'cboBank
        '
        Me.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Location = New System.Drawing.Point(123, 59)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(361, 21)
        Me.cboBank.TabIndex = 10
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.Location = New System.Drawing.Point(280, 367)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 13)
        Me.Label25.TabIndex = 251
        Me.Label25.Text = "Total Credit : "
        '
        'txtDRTotal
        '
        Me.txtDRTotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDRTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDRTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtDRTotal.Location = New System.Drawing.Point(322, 335)
        Me.txtDRTotal.Name = "txtDRTotal"
        Me.txtDRTotal.ReadOnly = True
        Me.txtDRTotal.Size = New System.Drawing.Size(159, 22)
        Me.txtDRTotal.TabIndex = 250
        '
        'colAcctCode
        '
        Me.colAcctCode.HeaderText = "Account Code"
        Me.colAcctCode.Name = "colAcctCode"
        Me.colAcctCode.ReadOnly = True
        Me.colAcctCode.Width = 125
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.txtDRTotal)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.txtCRTotal)
        Me.TabPage2.Controls.Add(Me.dtgAcctgTitle)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(533, 391)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Accounting Entry"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.Location = New System.Drawing.Point(234, 339)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 13)
        Me.Label26.TabIndex = 249
        Me.Label26.Text = "Total Debit : "
        '
        'txtCRTotal
        '
        Me.txtCRTotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCRTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCRTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtCRTotal.Location = New System.Drawing.Point(371, 363)
        Me.txtCRTotal.Name = "txtCRTotal"
        Me.txtCRTotal.ReadOnly = True
        Me.txtCRTotal.Size = New System.Drawing.Size(159, 22)
        Me.txtCRTotal.TabIndex = 252
        '
        'dtgAcctgTitle
        '
        Me.dtgAcctgTitle.AllowUserToAddRows = False
        Me.dtgAcctgTitle.AllowUserToDeleteRows = False
        Me.dtgAcctgTitle.AllowUserToResizeRows = False
        Me.dtgAcctgTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAcctgTitle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAcctCode, Me.colAcctTitle, Me.colSubAcctCode, Me.colSubAcctTitle, Me.colDept, Me.colDeptName, Me.colList, Me.colListItem, Me.colListItemName, Me.colDR, Me.colCR})
        Me.dtgAcctgTitle.Location = New System.Drawing.Point(8, 6)
        Me.dtgAcctgTitle.Name = "dtgAcctgTitle"
        Me.dtgAcctgTitle.ReadOnly = True
        Me.dtgAcctgTitle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAcctgTitle.Size = New System.Drawing.Size(522, 323)
        Me.dtgAcctgTitle.TabIndex = 248
        '
        'colAcctTitle
        '
        Me.colAcctTitle.HeaderText = "Account Title"
        Me.colAcctTitle.Name = "colAcctTitle"
        Me.colAcctTitle.ReadOnly = True
        Me.colAcctTitle.Width = 300
        '
        'colSubAcctCode
        '
        Me.colSubAcctCode.HeaderText = "Code"
        Me.colSubAcctCode.Name = "colSubAcctCode"
        Me.colSubAcctCode.ReadOnly = True
        Me.colSubAcctCode.Width = 50
        '
        'colSubAcctTitle
        '
        Me.colSubAcctTitle.HeaderText = "Sub Account Title"
        Me.colSubAcctTitle.Name = "colSubAcctTitle"
        Me.colSubAcctTitle.ReadOnly = True
        Me.colSubAcctTitle.Width = 300
        '
        'colDept
        '
        Me.colDept.HeaderText = "Dept"
        Me.colDept.Name = "colDept"
        Me.colDept.ReadOnly = True
        Me.colDept.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDept.Width = 50
        '
        'colDeptName
        '
        Me.colDeptName.HeaderText = "Department"
        Me.colDeptName.Name = "colDeptName"
        Me.colDeptName.ReadOnly = True
        Me.colDeptName.Width = 125
        '
        'colList
        '
        Me.colList.HeaderText = "List"
        Me.colList.Name = "colList"
        Me.colList.ReadOnly = True
        Me.colList.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colList.Width = 50
        '
        'colListItem
        '
        Me.colListItem.HeaderText = "List Item"
        Me.colListItem.Name = "colListItem"
        Me.colListItem.ReadOnly = True
        Me.colListItem.Width = 200
        '
        'colListItemName
        '
        Me.colListItemName.HeaderText = "List Item Name"
        Me.colListItemName.Name = "colListItemName"
        Me.colListItemName.ReadOnly = True
        Me.colListItemName.Width = 300
        '
        'colDR
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.colDR.DefaultCellStyle = DataGridViewCellStyle1
        Me.colDR.HeaderText = "Debit"
        Me.colDR.Name = "colDR"
        Me.colDR.ReadOnly = True
        '
        'colCR
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.colCR.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCR.HeaderText = "Credit"
        Me.colCR.Name = "colCR"
        Me.colCR.ReadOnly = True
        '
        'txtTotalBilling
        '
        Me.txtTotalBilling.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtTotalBilling.Location = New System.Drawing.Point(123, 12)
        Me.txtTotalBilling.Name = "txtTotalBilling"
        Me.txtTotalBilling.ReadOnly = True
        Me.txtTotalBilling.Size = New System.Drawing.Size(135, 20)
        Me.txtTotalBilling.TabIndex = 22
        Me.txtTotalBilling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(292, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Check No.:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtTotalBilling)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.txtOverPayment)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtAmtInWords)
        Me.GroupBox4.Controls.Add(Me.txtBalanceTotal)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtOthChargesTotal)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtCWTTotal)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtPaymentTotal)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 163)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(521, 143)
        Me.GroupBox4.TabIndex = 429
        Me.GroupBox4.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.Location = New System.Drawing.Point(26, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Billing Amount:"
        '
        'txtOverPayment
        '
        Me.txtOverPayment.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtOverPayment.Location = New System.Drawing.Point(366, 50)
        Me.txtOverPayment.Name = "txtOverPayment"
        Me.txtOverPayment.ReadOnly = True
        Me.txtOverPayment.Size = New System.Drawing.Size(135, 20)
        Me.txtOverPayment.TabIndex = 20
        Me.txtOverPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(266, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Over Payment :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.Location = New System.Drawing.Point(41, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Amount In Words : "
        '
        'txtAmtInWords
        '
        Me.txtAmtInWords.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtAmtInWords.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmtInWords.Location = New System.Drawing.Point(44, 89)
        Me.txtAmtInWords.Multiline = True
        Me.txtAmtInWords.Name = "txtAmtInWords"
        Me.txtAmtInWords.ReadOnly = True
        Me.txtAmtInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAmtInWords.Size = New System.Drawing.Size(457, 50)
        Me.txtAmtInWords.TabIndex = 15
        '
        'txtBalanceTotal
        '
        Me.txtBalanceTotal.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtBalanceTotal.Location = New System.Drawing.Point(366, 31)
        Me.txtBalanceTotal.Name = "txtBalanceTotal"
        Me.txtBalanceTotal.ReadOnly = True
        Me.txtBalanceTotal.Size = New System.Drawing.Size(135, 20)
        Me.txtBalanceTotal.TabIndex = 11
        Me.txtBalanceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Location = New System.Drawing.Point(270, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Total Balance:"
        '
        'txtOthChargesTotal
        '
        Me.txtOthChargesTotal.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtOthChargesTotal.Location = New System.Drawing.Point(366, 12)
        Me.txtOthChargesTotal.Name = "txtOthChargesTotal"
        Me.txtOthChargesTotal.ReadOnly = True
        Me.txtOthChargesTotal.Size = New System.Drawing.Size(135, 20)
        Me.txtOthChargesTotal.TabIndex = 9
        Me.txtOthChargesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(268, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Other Charges:"
        '
        'txtCWTTotal
        '
        Me.txtCWTTotal.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtCWTTotal.Location = New System.Drawing.Point(123, 50)
        Me.txtCWTTotal.Name = "txtCWTTotal"
        Me.txtCWTTotal.ReadOnly = True
        Me.txtCWTTotal.Size = New System.Drawing.Size(135, 20)
        Me.txtCWTTotal.TabIndex = 7
        Me.txtCWTTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(45, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Total CWT:"
        '
        'txtPaymentTotal
        '
        Me.txtPaymentTotal.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtPaymentTotal.ForeColor = System.Drawing.Color.Blue
        Me.txtPaymentTotal.Location = New System.Drawing.Point(123, 31)
        Me.txtPaymentTotal.Name = "txtPaymentTotal"
        Me.txtPaymentTotal.ReadOnly = True
        Me.txtPaymentTotal.Size = New System.Drawing.Size(135, 20)
        Me.txtPaymentTotal.TabIndex = 5
        Me.txtPaymentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(34, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "O.R. Amount:"
        '
        'colORBal
        '
        Me.colORBal.HeaderText = "Balance"
        Me.colORBal.Name = "colORBal"
        Me.colORBal.ReadOnly = True
        '
        'gpORPayment
        '
        Me.gpORPayment.Controls.Add(Me.chkBank)
        Me.gpORPayment.Controls.Add(Me.cmdCompCheck)
        Me.gpORPayment.Controls.Add(Me.cmdCompCash)
        Me.gpORPayment.Controls.Add(Me.Label12)
        Me.gpORPayment.Controls.Add(Me.cboBank)
        Me.gpORPayment.Controls.Add(Me.txtChkNo)
        Me.gpORPayment.Controls.Add(Me.Label7)
        Me.gpORPayment.Controls.Add(Me.txtChkAmt)
        Me.gpORPayment.Controls.Add(Me.Label5)
        Me.gpORPayment.Controls.Add(Me.txtCashAmt)
        Me.gpORPayment.Controls.Add(Me.Label6)
        Me.gpORPayment.Location = New System.Drawing.Point(9, 303)
        Me.gpORPayment.Name = "gpORPayment"
        Me.gpORPayment.Size = New System.Drawing.Size(521, 84)
        Me.gpORPayment.TabIndex = 430
        Me.gpORPayment.TabStop = False
        '
        'txtChkNo
        '
        Me.txtChkNo.Location = New System.Drawing.Point(369, 36)
        Me.txtChkNo.Name = "txtChkNo"
        Me.txtChkNo.Size = New System.Drawing.Size(115, 20)
        Me.txtChkNo.TabIndex = 9
        '
        'txtChkAmt
        '
        Me.txtChkAmt.Location = New System.Drawing.Point(369, 14)
        Me.txtChkAmt.Name = "txtChkAmt"
        Me.txtChkAmt.Size = New System.Drawing.Size(115, 20)
        Me.txtChkAmt.TabIndex = 7
        Me.txtChkAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(270, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Check Amount:"
        '
        'txtCashAmt
        '
        Me.txtCashAmt.Location = New System.Drawing.Point(123, 14)
        Me.txtCashAmt.Name = "txtCashAmt"
        Me.txtCashAmt.Size = New System.Drawing.Size(115, 20)
        Me.txtCashAmt.TabIndex = 5
        Me.txtCashAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(32, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Cash Amount:"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel3.Text = "Status:"
        '
        'tslblPrepDate
        '
        Me.tslblPrepDate.Name = "tslblPrepDate"
        Me.tslblPrepDate.Size = New System.Drawing.Size(26, 17)
        Me.tslblPrepDate.Text = "test"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optImpF)
        Me.GroupBox2.Controls.Add(Me.optImpB)
        Me.GroupBox2.Controls.Add(Me.optExp)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(470, 53)
        Me.GroupBox2.TabIndex = 389
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Service Type"
        '
        'optImpF
        '
        Me.optImpF.AutoSize = True
        Me.optImpF.Location = New System.Drawing.Point(328, 24)
        Me.optImpF.Name = "optImpF"
        Me.optImpF.Size = New System.Drawing.Size(109, 17)
        Me.optImpF.TabIndex = 2
        Me.optImpF.Text = "Import Forwarding"
        Me.optImpF.UseVisualStyleBackColor = True
        '
        'optImpB
        '
        Me.optImpB.AutoSize = True
        Me.optImpB.Location = New System.Drawing.Point(163, 24)
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
        Me.optExp.Location = New System.Drawing.Point(47, 24)
        Me.optExp.Name = "optExp"
        Me.optExp.Size = New System.Drawing.Size(55, 17)
        Me.optExp.TabIndex = 0
        Me.optExp.TabStop = True
        Me.optExp.Text = "Export"
        Me.optExp.UseVisualStyleBackColor = True
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
        'tslblStatus
        '
        Me.tslblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblStatus.Name = "tslblStatus"
        Me.tslblStatus.Size = New System.Drawing.Size(32, 17)
        Me.tslblStatus.Text = "Test"
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
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 469)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(544, 22)
        Me.StatusStrip1.TabIndex = 432
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'colBookingNo
        '
        Me.colBookingNo.HeaderText = "Booking Number"
        Me.colBookingNo.Name = "colBookingNo"
        Me.colBookingNo.ReadOnly = True
        Me.colBookingNo.Width = 200
        '
        'dtgBkgNbr
        '
        Me.dtgBkgNbr.AllowUserToAddRows = False
        Me.dtgBkgNbr.AllowUserToDeleteRows = False
        Me.dtgBkgNbr.AllowUserToResizeRows = False
        Me.dtgBkgNbr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBkgNbr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBookingNo})
        Me.dtgBkgNbr.Location = New System.Drawing.Point(8, 6)
        Me.dtgBkgNbr.Name = "dtgBkgNbr"
        Me.dtgBkgNbr.ReadOnly = True
        Me.dtgBkgNbr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgBkgNbr.Size = New System.Drawing.Size(522, 323)
        Me.dtgBkgNbr.TabIndex = 250
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dtgBkgNbr)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(533, 391)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Booking No."
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'colORAmt
        '
        Me.colORAmt.HeaderText = "Amount Paid"
        Me.colORAmt.Name = "colORAmt"
        Me.colORAmt.ReadOnly = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(339, 25)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(119, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Billing with old O.R."
        '
        'colOROthChrg
        '
        Me.colOROthChrg.HeaderText = "Other Charges"
        Me.colOROthChrg.Name = "colOROthChrg"
        Me.colOROthChrg.ReadOnly = True
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Tomato
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Location = New System.Drawing.Point(319, 25)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(14, 13)
        Me.Label24.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(182, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(125, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Billing with new O.R."
        '
        'gpLegend
        '
        Me.gpLegend.Controls.Add(Me.Label23)
        Me.gpLegend.Controls.Add(Me.Label24)
        Me.gpLegend.Controls.Add(Me.Label21)
        Me.gpLegend.Controls.Add(Me.Label22)
        Me.gpLegend.Controls.Add(Me.Label20)
        Me.gpLegend.Controls.Add(Me.Label19)
        Me.gpLegend.Location = New System.Drawing.Point(9, 127)
        Me.gpLegend.Name = "gpLegend"
        Me.gpLegend.Size = New System.Drawing.Size(458, 50)
        Me.gpLegend.TabIndex = 434
        Me.gpLegend.TabStop = False
        Me.gpLegend.Text = "Legend"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.LightGreen
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Location = New System.Drawing.Point(162, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(14, 13)
        Me.Label22.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(33, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(116, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Billing with no O.R."
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SkyBlue
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Location = New System.Drawing.Point(13, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(14, 13)
        Me.Label19.TabIndex = 0
        '
        'gpBilling
        '
        Me.gpBilling.Controls.Add(Me.gpLegend)
        Me.gpBilling.Controls.Add(Me.cmdLoad)
        Me.gpBilling.Controls.Add(Me.dtgBilling)
        Me.gpBilling.Controls.Add(Me.GroupBox3)
        Me.gpBilling.Controls.Add(Me.Label1)
        Me.gpBilling.Controls.Add(Me.cboClient)
        Me.gpBilling.Controls.Add(Me.Label8)
        Me.gpBilling.Location = New System.Drawing.Point(12, 96)
        Me.gpBilling.Name = "gpBilling"
        Me.gpBilling.Size = New System.Drawing.Size(470, 435)
        Me.gpBilling.TabIndex = 387
        Me.gpBilling.TabStop = False
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(392, 18)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(75, 23)
        Me.cmdLoad.TabIndex = 429
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'dtgBilling
        '
        Me.dtgBilling.AllowUserToAddRows = False
        Me.dtgBilling.AllowUserToDeleteRows = False
        Me.dtgBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBilling.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBillRefNo, Me.colBillInv, Me.colBillAmt, Me.colBillVAT, Me.colBillBalance})
        Me.dtgBilling.Location = New System.Drawing.Point(9, 197)
        Me.dtgBilling.Name = "dtgBilling"
        Me.dtgBilling.ReadOnly = True
        Me.dtgBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgBilling.Size = New System.Drawing.Size(458, 232)
        Me.dtgBilling.TabIndex = 427
        '
        'colBillRefNo
        '
        Me.colBillRefNo.Frozen = True
        Me.colBillRefNo.HeaderText = "Billing No."
        Me.colBillRefNo.Name = "colBillRefNo"
        Me.colBillRefNo.ReadOnly = True
        Me.colBillRefNo.Width = 150
        '
        'colBillInv
        '
        Me.colBillInv.HeaderText = "Invoice No."
        Me.colBillInv.Name = "colBillInv"
        Me.colBillInv.ReadOnly = True
        '
        'colBillAmt
        '
        Me.colBillAmt.HeaderText = "Billing Amount"
        Me.colBillAmt.Name = "colBillAmt"
        Me.colBillAmt.ReadOnly = True
        '
        'colBillVAT
        '
        Me.colBillVAT.HeaderText = "VAT"
        Me.colBillVAT.Name = "colBillVAT"
        Me.colBillVAT.ReadOnly = True
        '
        'colBillBalance
        '
        Me.colBillBalance.HeaderText = "Balance"
        Me.colBillBalance.Name = "colBillBalance"
        Me.colBillBalance.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtRefNo)
        Me.GroupBox3.Controls.Add(Me.lblPrefix)
        Me.GroupBox3.Controls.Add(Me.optBillNo)
        Me.GroupBox3.Controls.Add(Me.optInvNo)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 46)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(458, 75)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search By:"
        '
        'txtRefNo
        '
        Me.txtRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(114, 42)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(341, 22)
        Me.txtRefNo.TabIndex = 426
        '
        'lblPrefix
        '
        Me.lblPrefix.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrefix.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefix.ForeColor = System.Drawing.Color.Black
        Me.lblPrefix.Location = New System.Drawing.Point(9, 42)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(105, 22)
        Me.lblPrefix.TabIndex = 425
        Me.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'optBillNo
        '
        Me.optBillNo.AutoSize = True
        Me.optBillNo.Checked = True
        Me.optBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBillNo.ForeColor = System.Drawing.Color.DarkBlue
        Me.optBillNo.Location = New System.Drawing.Point(125, 19)
        Me.optBillNo.Name = "optBillNo"
        Me.optBillNo.Size = New System.Drawing.Size(111, 17)
        Me.optBillNo.TabIndex = 1
        Me.optBillNo.TabStop = True
        Me.optBillNo.Text = "Billing Ref. No."
        Me.optBillNo.UseVisualStyleBackColor = True
        '
        'optInvNo
        '
        Me.optInvNo.AutoSize = True
        Me.optInvNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optInvNo.ForeColor = System.Drawing.Color.DarkBlue
        Me.optInvNo.Location = New System.Drawing.Point(242, 19)
        Me.optInvNo.Name = "optInvNo"
        Me.optInvNo.Size = New System.Drawing.Size(91, 17)
        Me.optInvNo.TabIndex = 0
        Me.optInvNo.Text = "Invoice No."
        Me.optInvNo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Client Name:"
        '
        'cboClient
        '
        Me.cboClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClient.FormattingEnabled = True
        Me.cboClient.Location = New System.Drawing.Point(94, 19)
        Me.cboClient.Name = "cboClient"
        Me.cboClient.Size = New System.Drawing.Size(292, 21)
        Me.cboClient.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MediumVioletRed
        Me.Label8.Location = New System.Drawing.Point(9, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(243, 15)
        Me.Label8.TabIndex = 428
        Me.Label8.Text = "Note: Unposted billing will not appear in this table."
        '
        'colORBillAmt
        '
        Me.colORBillAmt.HeaderText = "Amount Billed"
        Me.colORBillAmt.Name = "colORBillAmt"
        Me.colORBillAmt.ReadOnly = True
        '
        'colORInv
        '
        Me.colORInv.HeaderText = "Invoice No."
        Me.colORInv.Name = "colORInv"
        Me.colORInv.ReadOnly = True
        '
        'colORBillNo
        '
        Me.colORBillNo.Frozen = True
        Me.colORBillNo.HeaderText = "Billing No."
        Me.colORBillNo.Name = "colORBillNo"
        Me.colORBillNo.ReadOnly = True
        Me.colORBillNo.Width = 150
        '
        'dtgORInv
        '
        Me.dtgORInv.AllowUserToAddRows = False
        Me.dtgORInv.AllowUserToDeleteRows = False
        Me.dtgORInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgORInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colORBillNo, Me.colORInv, Me.colORBillAmt, Me.colORCWT, Me.colOROthChrg, Me.colORAmt, Me.colORBal})
        Me.dtgORInv.Location = New System.Drawing.Point(7, 26)
        Me.dtgORInv.Name = "dtgORInv"
        Me.dtgORInv.ReadOnly = True
        Me.dtgORInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgORInv.Size = New System.Drawing.Size(523, 139)
        Me.dtgORInv.TabIndex = 428
        '
        'colORCWT
        '
        Me.colORCWT.HeaderText = "CWT"
        Me.colORCWT.Name = "colORCWT"
        Me.colORCWT.ReadOnly = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtgORInv)
        Me.TabPage1.Controls.Add(Me.cmdRemoveSRow)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.gpORPayment)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(533, 391)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Invoice"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdRemoveSRow
        '
        Me.cmdRemoveSRow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRemoveSRow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRemoveSRow.Image = CType(resources.GetObject("cmdRemoveSRow.Image"), System.Drawing.Image)
        Me.cmdRemoveSRow.Location = New System.Drawing.Point(498, 3)
        Me.cmdRemoveSRow.Name = "cmdRemoveSRow"
        Me.cmdRemoveSRow.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemoveSRow.TabIndex = 431
        Me.cmdRemoveSRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRemoveSRow.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(9, 49)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(541, 417)
        Me.TabControl1.TabIndex = 433
        '
        'gpOR
        '
        Me.gpOR.Controls.Add(Me.GroupBox1)
        Me.gpOR.Controls.Add(Me.TabControl1)
        Me.gpOR.Controls.Add(Me.StatusStrip1)
        Me.gpOR.Location = New System.Drawing.Point(488, 37)
        Me.gpOR.Name = "gpOR"
        Me.gpOR.Size = New System.Drawing.Size(550, 494)
        Me.gpOR.TabIndex = 388
        Me.gpOR.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtORNo)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 43)
        Me.GroupBox1.TabIndex = 434
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "O.R. Number"
        '
        'txtORNo
        '
        Me.txtORNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNo.Location = New System.Drawing.Point(9, 15)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(485, 20)
        Me.txtORNo.TabIndex = 3
        Me.txtORNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tscmdSearchOR
        '
        Me.tscmdSearchOR.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tscmdSearchOR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdSearchOR.Name = "tscmdSearchOR"
        Me.tscmdSearchOR.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tstxtSearch
        '
        Me.tstxtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tstxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tstxtSearch.Name = "tstxtSearch"
        Me.tstxtSearch.Size = New System.Drawing.Size(100, 25)
        '
        'tslblPrefix
        '
        Me.tslblPrefix.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tslblPrefix.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblPrefix.ForeColor = System.Drawing.Color.DarkRed
        Me.tslblPrefix.Name = "tslblPrefix"
        Me.tslblPrefix.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripLabel1.Text = "Search :"
        '
        'tscmdClose
        '
        Me.tscmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdClose.Name = "tscmdClose"
        Me.tscmdClose.Size = New System.Drawing.Size(40, 22)
        Me.tscmdClose.Text = "Close"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscmdSearchOR, Me.ToolStripSeparator4, Me.tstxtSearch, Me.tslblPrefix, Me.ToolStripLabel1, Me.tscmdClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1050, 25)
        Me.ToolStrip1.TabIndex = 386
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frmOfficialReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 544)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpBilling)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gpOR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmOfficialReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Official Receipt"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dtgAcctgTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gpORPayment.ResumeLayout(False)
        Me.gpORPayment.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dtgBkgNbr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.gpLegend.ResumeLayout(False)
        Me.gpLegend.PerformLayout()
        Me.gpBilling.ResumeLayout(False)
        Me.gpBilling.PerformLayout()
        CType(Me.dtgBilling, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dtgORInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.gpOR.ResumeLayout(False)
        Me.gpOR.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkBank As CheckBox
    Friend WithEvents cmdCompCheck As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmdCompCash As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtDRTotal As TextBox
    Friend WithEvents colAcctCode As DataGridViewTextBoxColumn
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label26 As Label
    Friend WithEvents txtCRTotal As TextBox
    Friend WithEvents dtgAcctgTitle As DataGridView
    Friend WithEvents colAcctTitle As DataGridViewTextBoxColumn
    Friend WithEvents colSubAcctCode As DataGridViewTextBoxColumn
    Friend WithEvents colSubAcctTitle As DataGridViewTextBoxColumn
    Friend WithEvents colDept As DataGridViewCheckBoxColumn
    Friend WithEvents colDeptName As DataGridViewTextBoxColumn
    Friend WithEvents colList As DataGridViewCheckBoxColumn
    Friend WithEvents colListItem As DataGridViewTextBoxColumn
    Friend WithEvents colListItemName As DataGridViewTextBoxColumn
    Friend WithEvents colDR As DataGridViewTextBoxColumn
    Friend WithEvents colCR As DataGridViewTextBoxColumn
    Friend WithEvents txtTotalBilling As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdRemoveSRow As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtOverPayment As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtAmtInWords As TextBox
    Friend WithEvents txtBalanceTotal As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtOthChargesTotal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCWTTotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPaymentTotal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents colORBal As DataGridViewTextBoxColumn
    Friend WithEvents gpORPayment As GroupBox
    Friend WithEvents txtChkNo As TextBox
    Friend WithEvents txtChkAmt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCashAmt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents tslblPrepDate As ToolStripStatusLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents optImpF As RadioButton
    Friend WithEvents optImpB As RadioButton
    Friend WithEvents optExp As RadioButton
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tslblPrepBy As ToolStripStatusLabel
    Friend WithEvents tslblStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents colBookingNo As DataGridViewTextBoxColumn
    Friend WithEvents dtgBkgNbr As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents colORAmt As DataGridViewTextBoxColumn
    Friend WithEvents Label23 As Label
    Friend WithEvents colOROthChrg As DataGridViewTextBoxColumn
    Friend WithEvents Label24 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents gpLegend As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents gpBilling As GroupBox
    Friend WithEvents cmdLoad As Button
    Friend WithEvents dtgBilling As DataGridView
    Friend WithEvents colBillRefNo As DataGridViewTextBoxColumn
    Friend WithEvents colBillInv As DataGridViewTextBoxColumn
    Friend WithEvents colBillAmt As DataGridViewTextBoxColumn
    Friend WithEvents colBillVAT As DataGridViewTextBoxColumn
    Friend WithEvents colBillBalance As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtRefNo As TextBox
    Friend WithEvents lblPrefix As Label
    Friend WithEvents optBillNo As RadioButton
    Friend WithEvents optInvNo As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cboClient As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents colORBillAmt As DataGridViewTextBoxColumn
    Friend WithEvents colORInv As DataGridViewTextBoxColumn
    Friend WithEvents colORBillNo As DataGridViewTextBoxColumn
    Friend WithEvents dtgORInv As DataGridView
    Friend WithEvents colORCWT As DataGridViewTextBoxColumn
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents gpOR As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtORNo As TextBox
    Friend WithEvents tscmdSearchOR As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tstxtSearch As ToolStripTextBox
    Friend WithEvents tslblPrefix As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tscmdClose As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
End Class
