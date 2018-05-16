<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFundTransfer
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFundTransfer))
        Me.txtTotalAmt = New System.Windows.Forms.TextBox()
        Me.txtExRate = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbFT = New System.Windows.Forms.TabPage()
        Me.dtgBankEntry = New System.Windows.Forms.DataGridView()
        Me.colSelectEntry = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colAcctCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcctTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubAcctTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colchkDept = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDeptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colchkList = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colListItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colListItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbStatus = New System.Windows.Forms.TabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtFundedDate = New System.Windows.Forms.TextBox()
        Me.txtFundedBy = New System.Windows.Forms.TextBox()
        Me.chkFunded = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPrepBy = New System.Windows.Forms.TextBox()
        Me.txtPrepDate = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkPosted = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPostedBy = New System.Windows.Forms.TextBox()
        Me.txtCancelledDate = New System.Windows.Forms.TextBox()
        Me.txtPostedDate = New System.Windows.Forms.TextBox()
        Me.txtCancelledBy = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.chkCancelled = New System.Windows.Forms.CheckBox()
        Me.tbOthers = New System.Windows.Forms.TabPage()
        Me.dtFT = New System.Windows.Forms.DateTimePicker()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtToAcct = New System.Windows.Forms.TextBox()
        Me.txtFromAcct = New System.Windows.Forms.TextBox()
        Me.ToCCode = New System.Windows.Forms.TextBox()
        Me.fromCCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAmtInWords = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAmt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtToBankAcct = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtToBankCode = New System.Windows.Forms.TextBox()
        Me.txtFromBankAcct = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFromBankCode = New System.Windows.Forms.TextBox()
        Me.gpType = New System.Windows.Forms.GroupBox()
        Me.rdDollar = New System.Windows.Forms.RadioButton()
        Me.rdAffiliates = New System.Windows.Forms.RadioButton()
        Me.rdSavings = New System.Windows.Forms.RadioButton()
        Me.cmdFund = New System.Windows.Forms.Button()
        Me.btAdvanceSearch = New System.Windows.Forms.Button()
        Me.lblCVNbr = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnTo = New System.Windows.Forms.Button()
        Me.btnFrom = New System.Windows.Forms.Button()
        Me.cboReport = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.tbFT.SuspendLayout()
        CType(Me.dtgBankEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbStatus.SuspendLayout()
        Me.tbOthers.SuspendLayout()
        Me.gpType.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTotalAmt
        '
        Me.txtTotalAmt.BackColor = System.Drawing.Color.White
        Me.txtTotalAmt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmt.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtTotalAmt.Location = New System.Drawing.Point(155, 249)
        Me.txtTotalAmt.Name = "txtTotalAmt"
        Me.txtTotalAmt.Size = New System.Drawing.Size(189, 21)
        Me.txtTotalAmt.TabIndex = 605
        Me.txtTotalAmt.Text = "0.00"
        Me.txtTotalAmt.Visible = False
        '
        'txtExRate
        '
        Me.txtExRate.BackColor = System.Drawing.Color.White
        Me.txtExRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExRate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtExRate.Location = New System.Drawing.Point(214, 148)
        Me.txtExRate.Name = "txtExRate"
        Me.txtExRate.Size = New System.Drawing.Size(51, 21)
        Me.txtExRate.TabIndex = 604
        Me.txtExRate.Text = "1"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(214, 133)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 15)
        Me.Label27.TabIndex = 603
        Me.Label27.Text = "Ex Rate:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbFT)
        Me.TabControl1.Controls.Add(Me.tbStatus)
        Me.TabControl1.Controls.Add(Me.tbOthers)
        Me.TabControl1.Location = New System.Drawing.Point(7, 254)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(821, 271)
        Me.TabControl1.TabIndex = 598
        '
        'tbFT
        '
        Me.tbFT.Controls.Add(Me.dtgBankEntry)
        Me.tbFT.Location = New System.Drawing.Point(4, 22)
        Me.tbFT.Name = "tbFT"
        Me.tbFT.Padding = New System.Windows.Forms.Padding(3)
        Me.tbFT.Size = New System.Drawing.Size(813, 245)
        Me.tbFT.TabIndex = 0
        Me.tbFT.Text = "FT Entry"
        Me.tbFT.UseVisualStyleBackColor = True
        '
        'dtgBankEntry
        '
        Me.dtgBankEntry.AllowUserToAddRows = False
        Me.dtgBankEntry.AllowUserToDeleteRows = False
        Me.dtgBankEntry.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dtgBankEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBankEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectEntry, Me.colAcctCode, Me.colAcctTitle, Me.colDR, Me.colCR, Me.colSubCode, Me.colSubAcctTitle, Me.colchkDept, Me.colDeptName, Me.colchkList, Me.colListItem, Me.colListItemName})
        Me.dtgBankEntry.Location = New System.Drawing.Point(3, 3)
        Me.dtgBankEntry.Name = "dtgBankEntry"
        Me.dtgBankEntry.Size = New System.Drawing.Size(807, 239)
        Me.dtgBankEntry.TabIndex = 572
        '
        'colSelectEntry
        '
        Me.colSelectEntry.Frozen = True
        Me.colSelectEntry.HeaderText = ""
        Me.colSelectEntry.Name = "colSelectEntry"
        Me.colSelectEntry.ReadOnly = True
        Me.colSelectEntry.Width = 25
        '
        'colAcctCode
        '
        Me.colAcctCode.Frozen = True
        Me.colAcctCode.HeaderText = "Account Code"
        Me.colAcctCode.Name = "colAcctCode"
        Me.colAcctCode.ReadOnly = True
        '
        'colAcctTitle
        '
        Me.colAcctTitle.Frozen = True
        Me.colAcctTitle.HeaderText = "Account Title"
        Me.colAcctTitle.Name = "colAcctTitle"
        Me.colAcctTitle.ReadOnly = True
        Me.colAcctTitle.Width = 150
        '
        'colDR
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colDR.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDR.HeaderText = "DR"
        Me.colDR.Name = "colDR"
        Me.colDR.ReadOnly = True
        Me.colDR.Width = 75
        '
        'colCR
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colCR.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCR.HeaderText = "CR"
        Me.colCR.Name = "colCR"
        Me.colCR.ReadOnly = True
        Me.colCR.Width = 75
        '
        'colSubCode
        '
        Me.colSubCode.HeaderText = "Sub"
        Me.colSubCode.Name = "colSubCode"
        Me.colSubCode.ReadOnly = True
        Me.colSubCode.Width = 25
        '
        'colSubAcctTitle
        '
        Me.colSubAcctTitle.HeaderText = "Sub Account Title"
        Me.colSubAcctTitle.Name = "colSubAcctTitle"
        Me.colSubAcctTitle.ReadOnly = True
        Me.colSubAcctTitle.Width = 150
        '
        'colchkDept
        '
        Me.colchkDept.HeaderText = ""
        Me.colchkDept.Name = "colchkDept"
        Me.colchkDept.ReadOnly = True
        Me.colchkDept.Width = 25
        '
        'colDeptName
        '
        Me.colDeptName.HeaderText = "Dept Name"
        Me.colDeptName.Name = "colDeptName"
        Me.colDeptName.ReadOnly = True
        Me.colDeptName.Width = 50
        '
        'colchkList
        '
        Me.colchkList.HeaderText = ""
        Me.colchkList.Name = "colchkList"
        Me.colchkList.ReadOnly = True
        Me.colchkList.Width = 25
        '
        'colListItem
        '
        Me.colListItem.HeaderText = "List Item"
        Me.colListItem.Name = "colListItem"
        Me.colListItem.ReadOnly = True
        Me.colListItem.Width = 75
        '
        'colListItemName
        '
        Me.colListItemName.HeaderText = "List Item Name"
        Me.colListItemName.Name = "colListItemName"
        Me.colListItemName.ReadOnly = True
        Me.colListItemName.Width = 150
        '
        'tbStatus
        '
        Me.tbStatus.Controls.Add(Me.Label29)
        Me.tbStatus.Controls.Add(Me.Label38)
        Me.tbStatus.Controls.Add(Me.txtFundedDate)
        Me.tbStatus.Controls.Add(Me.txtFundedBy)
        Me.tbStatus.Controls.Add(Me.chkFunded)
        Me.tbStatus.Controls.Add(Me.Label21)
        Me.tbStatus.Controls.Add(Me.txtPrepBy)
        Me.tbStatus.Controls.Add(Me.txtPrepDate)
        Me.tbStatus.Controls.Add(Me.Label22)
        Me.tbStatus.Controls.Add(Me.chkPosted)
        Me.tbStatus.Controls.Add(Me.Label23)
        Me.tbStatus.Controls.Add(Me.Label24)
        Me.tbStatus.Controls.Add(Me.Label25)
        Me.tbStatus.Controls.Add(Me.txtPostedBy)
        Me.tbStatus.Controls.Add(Me.txtCancelledDate)
        Me.tbStatus.Controls.Add(Me.txtPostedDate)
        Me.tbStatus.Controls.Add(Me.txtCancelledBy)
        Me.tbStatus.Controls.Add(Me.Label26)
        Me.tbStatus.Controls.Add(Me.chkCancelled)
        Me.tbStatus.Location = New System.Drawing.Point(4, 22)
        Me.tbStatus.Name = "tbStatus"
        Me.tbStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tbStatus.Size = New System.Drawing.Size(813, 245)
        Me.tbStatus.TabIndex = 1
        Me.tbStatus.Text = "Status"
        Me.tbStatus.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(21, 79)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(75, 15)
        Me.Label29.TabIndex = 431
        Me.Label29.Text = "Date Funded:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(21, 60)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(64, 15)
        Me.Label38.TabIndex = 430
        Me.Label38.Text = "Funded By:"
        '
        'txtFundedDate
        '
        Me.txtFundedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFundedDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtFundedDate.Location = New System.Drawing.Point(117, 79)
        Me.txtFundedDate.Name = "txtFundedDate"
        Me.txtFundedDate.ReadOnly = True
        Me.txtFundedDate.Size = New System.Drawing.Size(256, 20)
        Me.txtFundedDate.TabIndex = 429
        '
        'txtFundedBy
        '
        Me.txtFundedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFundedBy.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtFundedBy.Location = New System.Drawing.Point(117, 60)
        Me.txtFundedBy.Name = "txtFundedBy"
        Me.txtFundedBy.ReadOnly = True
        Me.txtFundedBy.Size = New System.Drawing.Size(256, 20)
        Me.txtFundedBy.TabIndex = 428
        '
        'chkFunded
        '
        Me.chkFunded.AutoCheck = False
        Me.chkFunded.AutoSize = True
        Me.chkFunded.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFunded.Location = New System.Drawing.Point(390, 69)
        Me.chkFunded.Name = "chkFunded"
        Me.chkFunded.Size = New System.Drawing.Size(79, 20)
        Me.chkFunded.TabIndex = 427
        Me.chkFunded.Text = "Funded"
        Me.chkFunded.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(21, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 15)
        Me.Label21.TabIndex = 423
        Me.Label21.Text = "Prepared By:"
        '
        'txtPrepBy
        '
        Me.txtPrepBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPrepBy.Location = New System.Drawing.Point(117, 15)
        Me.txtPrepBy.Name = "txtPrepBy"
        Me.txtPrepBy.ReadOnly = True
        Me.txtPrepBy.Size = New System.Drawing.Size(256, 20)
        Me.txtPrepBy.TabIndex = 425
        '
        'txtPrepDate
        '
        Me.txtPrepDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrepDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPrepDate.Location = New System.Drawing.Point(117, 34)
        Me.txtPrepDate.Name = "txtPrepDate"
        Me.txtPrepDate.ReadOnly = True
        Me.txtPrepDate.Size = New System.Drawing.Size(256, 20)
        Me.txtPrepDate.TabIndex = 426
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(21, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 15)
        Me.Label22.TabIndex = 424
        Me.Label22.Text = "Prepared Date:"
        '
        'chkPosted
        '
        Me.chkPosted.AutoCheck = False
        Me.chkPosted.AutoSize = True
        Me.chkPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPosted.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPosted.Location = New System.Drawing.Point(390, 115)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.Size = New System.Drawing.Size(76, 20)
        Me.chkPosted.TabIndex = 422
        Me.chkPosted.Text = "Posted"
        Me.chkPosted.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(21, 105)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 15)
        Me.Label23.TabIndex = 408
        Me.Label23.Text = "Posted By:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(21, 169)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(81, 15)
        Me.Label24.TabIndex = 421
        Me.Label24.Text = "Date Cancelled"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(21, 150)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 15)
        Me.Label25.TabIndex = 420
        Me.Label25.Text = "Cancelled By:"
        '
        'txtPostedBy
        '
        Me.txtPostedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostedBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPostedBy.Location = New System.Drawing.Point(117, 105)
        Me.txtPostedBy.Name = "txtPostedBy"
        Me.txtPostedBy.ReadOnly = True
        Me.txtPostedBy.Size = New System.Drawing.Size(256, 20)
        Me.txtPostedBy.TabIndex = 414
        '
        'txtCancelledDate
        '
        Me.txtCancelledDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelledDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCancelledDate.Location = New System.Drawing.Point(117, 169)
        Me.txtCancelledDate.Name = "txtCancelledDate"
        Me.txtCancelledDate.ReadOnly = True
        Me.txtCancelledDate.Size = New System.Drawing.Size(256, 20)
        Me.txtCancelledDate.TabIndex = 419
        '
        'txtPostedDate
        '
        Me.txtPostedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostedDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPostedDate.Location = New System.Drawing.Point(117, 124)
        Me.txtPostedDate.Name = "txtPostedDate"
        Me.txtPostedDate.ReadOnly = True
        Me.txtPostedDate.Size = New System.Drawing.Size(256, 20)
        Me.txtPostedDate.TabIndex = 415
        '
        'txtCancelledBy
        '
        Me.txtCancelledBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelledBy.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCancelledBy.Location = New System.Drawing.Point(117, 150)
        Me.txtCancelledBy.Name = "txtCancelledBy"
        Me.txtCancelledBy.ReadOnly = True
        Me.txtCancelledBy.Size = New System.Drawing.Size(256, 20)
        Me.txtCancelledBy.TabIndex = 418
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(21, 124)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 15)
        Me.Label26.TabIndex = 409
        Me.Label26.Text = "Posted Date:"
        '
        'chkCancelled
        '
        Me.chkCancelled.AutoCheck = False
        Me.chkCancelled.AutoSize = True
        Me.chkCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCancelled.Location = New System.Drawing.Point(390, 159)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.Size = New System.Drawing.Size(97, 20)
        Me.chkCancelled.TabIndex = 416
        Me.chkCancelled.Text = "Cancelled"
        Me.chkCancelled.UseVisualStyleBackColor = True
        '
        'tbOthers
        '
        Me.tbOthers.Controls.Add(Me.dtFT)
        Me.tbOthers.Controls.Add(Me.txtDate)
        Me.tbOthers.Controls.Add(Me.Label41)
        Me.tbOthers.Controls.Add(Me.txtRefNo)
        Me.tbOthers.Controls.Add(Me.Label40)
        Me.tbOthers.Controls.Add(Me.Label39)
        Me.tbOthers.Controls.Add(Me.txtRemarks)
        Me.tbOthers.Location = New System.Drawing.Point(4, 22)
        Me.tbOthers.Name = "tbOthers"
        Me.tbOthers.Padding = New System.Windows.Forms.Padding(3)
        Me.tbOthers.Size = New System.Drawing.Size(813, 245)
        Me.tbOthers.TabIndex = 2
        Me.tbOthers.Text = "Others"
        Me.tbOthers.UseVisualStyleBackColor = True
        '
        'dtFT
        '
        Me.dtFT.Enabled = False
        Me.dtFT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFT.Location = New System.Drawing.Point(154, 198)
        Me.dtFT.Name = "dtFT"
        Me.dtFT.Size = New System.Drawing.Size(16, 20)
        Me.dtFT.TabIndex = 564
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(14, 198)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(141, 20)
        Me.txtDate.TabIndex = 563
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label41.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(14, 180)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(104, 15)
        Me.Label41.TabIndex = 562
        Me.Label41.Text = "Date of Transaction"
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(14, 146)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.ReadOnly = True
        Me.txtRefNo.Size = New System.Drawing.Size(521, 20)
        Me.txtRefNo.TabIndex = 561
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(14, 128)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(154, 15)
        Me.Label40.TabIndex = 560
        Me.Label40.Text = "BANK TRANSACTION NUMBER"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label39.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(14, 15)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(226, 15)
        Me.Label39.TabIndex = 559
        Me.Label39.Text = "PURPOSE OF TRANSFER (Please give details)"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(14, 33)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(521, 76)
        Me.txtRemarks.TabIndex = 0
        '
        'txtToAcct
        '
        Me.txtToAcct.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtToAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToAcct.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtToAcct.Location = New System.Drawing.Point(367, 219)
        Me.txtToAcct.Name = "txtToAcct"
        Me.txtToAcct.ReadOnly = True
        Me.txtToAcct.Size = New System.Drawing.Size(448, 21)
        Me.txtToAcct.TabIndex = 602
        '
        'txtFromAcct
        '
        Me.txtFromAcct.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFromAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromAcct.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtFromAcct.Location = New System.Drawing.Point(367, 116)
        Me.txtFromAcct.Name = "txtFromAcct"
        Me.txtFromAcct.ReadOnly = True
        Me.txtFromAcct.Size = New System.Drawing.Size(448, 21)
        Me.txtFromAcct.TabIndex = 601
        '
        'ToCCode
        '
        Me.ToCCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToCCode.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ToCCode.Location = New System.Drawing.Point(303, 219)
        Me.ToCCode.Name = "ToCCode"
        Me.ToCCode.ReadOnly = True
        Me.ToCCode.Size = New System.Drawing.Size(62, 21)
        Me.ToCCode.TabIndex = 600
        '
        'fromCCode
        '
        Me.fromCCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.fromCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fromCCode.ForeColor = System.Drawing.Color.RoyalBlue
        Me.fromCCode.Location = New System.Drawing.Point(302, 116)
        Me.fromCCode.Name = "fromCCode"
        Me.fromCCode.ReadOnly = True
        Me.fromCCode.Size = New System.Drawing.Size(63, 21)
        Me.fromCCode.TabIndex = 599
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 15)
        Me.Label8.TabIndex = 597
        Me.Label8.Text = "Amount in Words:"
        '
        'txtAmtInWords
        '
        Me.txtAmtInWords.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAmtInWords.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmtInWords.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtAmtInWords.Location = New System.Drawing.Point(19, 186)
        Me.txtAmtInWords.Multiline = True
        Me.txtAmtInWords.Name = "txtAmtInWords"
        Me.txtAmtInWords.ReadOnly = True
        Me.txtAmtInWords.Size = New System.Drawing.Size(246, 47)
        Me.txtAmtInWords.TabIndex = 596
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 595
        Me.Label7.Text = "Amount:"
        '
        'txtAmt
        '
        Me.txtAmt.BackColor = System.Drawing.Color.White
        Me.txtAmt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmt.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtAmt.Location = New System.Drawing.Point(19, 148)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(189, 21)
        Me.txtAmt.TabIndex = 594
        Me.txtAmt.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(288, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 15)
        Me.Label6.TabIndex = 591
        Me.Label6.Text = "To:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(288, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 590
        Me.Label5.Text = "From:"
        '
        'txtToBankAcct
        '
        Me.txtToBankAcct.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtToBankAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToBankAcct.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtToBankAcct.Location = New System.Drawing.Point(367, 192)
        Me.txtToBankAcct.Name = "txtToBankAcct"
        Me.txtToBankAcct.ReadOnly = True
        Me.txtToBankAcct.Size = New System.Drawing.Size(448, 21)
        Me.txtToBankAcct.TabIndex = 589
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(366, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 588
        Me.Label3.Text = "Bank Account:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(302, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 15)
        Me.Label4.TabIndex = 587
        Me.Label4.Text = "Bank Code:"
        '
        'txtToBankCode
        '
        Me.txtToBankCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtToBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToBankCode.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtToBankCode.Location = New System.Drawing.Point(303, 192)
        Me.txtToBankCode.Name = "txtToBankCode"
        Me.txtToBankCode.ReadOnly = True
        Me.txtToBankCode.Size = New System.Drawing.Size(62, 21)
        Me.txtToBankCode.TabIndex = 586
        '
        'txtFromBankAcct
        '
        Me.txtFromBankAcct.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFromBankAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromBankAcct.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtFromBankAcct.Location = New System.Drawing.Point(367, 89)
        Me.txtFromBankAcct.Name = "txtFromBankAcct"
        Me.txtFromBankAcct.ReadOnly = True
        Me.txtFromBankAcct.Size = New System.Drawing.Size(448, 21)
        Me.txtFromBankAcct.TabIndex = 585
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(366, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 584
        Me.Label1.Text = "Bank Account:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(302, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 583
        Me.Label2.Text = "Bank Code:"
        '
        'txtFromBankCode
        '
        Me.txtFromBankCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFromBankCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFromBankCode.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtFromBankCode.Location = New System.Drawing.Point(303, 89)
        Me.txtFromBankCode.Name = "txtFromBankCode"
        Me.txtFromBankCode.ReadOnly = True
        Me.txtFromBankCode.Size = New System.Drawing.Size(62, 21)
        Me.txtFromBankCode.TabIndex = 582
        '
        'gpType
        '
        Me.gpType.Controls.Add(Me.rdDollar)
        Me.gpType.Controls.Add(Me.rdAffiliates)
        Me.gpType.Controls.Add(Me.rdSavings)
        Me.gpType.Location = New System.Drawing.Point(9, 57)
        Me.gpType.Name = "gpType"
        Me.gpType.Size = New System.Drawing.Size(266, 72)
        Me.gpType.TabIndex = 581
        Me.gpType.TabStop = False
        Me.gpType.Text = "Type of Transaction"
        '
        'rdDollar
        '
        Me.rdDollar.AutoSize = True
        Me.rdDollar.Enabled = False
        Me.rdDollar.Location = New System.Drawing.Point(16, 49)
        Me.rdDollar.Name = "rdDollar"
        Me.rdDollar.Size = New System.Drawing.Size(176, 17)
        Me.rdDollar.TabIndex = 2
        Me.rdDollar.TabStop = True
        Me.rdDollar.Text = "Fund Transfer to Dollar Account"
        Me.rdDollar.UseVisualStyleBackColor = True
        Me.rdDollar.Visible = False
        '
        'rdAffiliates
        '
        Me.rdAffiliates.AutoSize = True
        Me.rdAffiliates.Location = New System.Drawing.Point(16, 31)
        Me.rdAffiliates.Name = "rdAffiliates"
        Me.rdAffiliates.Size = New System.Drawing.Size(156, 17)
        Me.rdAffiliates.TabIndex = 1
        Me.rdAffiliates.TabStop = True
        Me.rdAffiliates.Text = "Fund Transfer from Affiliates"
        Me.rdAffiliates.UseVisualStyleBackColor = True
        '
        'rdSavings
        '
        Me.rdSavings.AutoSize = True
        Me.rdSavings.Location = New System.Drawing.Point(16, 13)
        Me.rdSavings.Name = "rdSavings"
        Me.rdSavings.Size = New System.Drawing.Size(198, 17)
        Me.rdSavings.TabIndex = 0
        Me.rdSavings.TabStop = True
        Me.rdSavings.Text = "Fund Transfer from Savings Account"
        Me.rdSavings.UseVisualStyleBackColor = True
        '
        'cmdFund
        '
        Me.cmdFund.Location = New System.Drawing.Point(193, 12)
        Me.cmdFund.Name = "cmdFund"
        Me.cmdFund.Size = New System.Drawing.Size(75, 23)
        Me.cmdFund.TabIndex = 606
        Me.cmdFund.Text = "Fund"
        Me.cmdFund.UseVisualStyleBackColor = True
        '
        'btAdvanceSearch
        '
        Me.btAdvanceSearch.Location = New System.Drawing.Point(7, 12)
        Me.btAdvanceSearch.Name = "btAdvanceSearch"
        Me.btAdvanceSearch.Size = New System.Drawing.Size(168, 23)
        Me.btAdvanceSearch.TabIndex = 3
        Me.btAdvanceSearch.Text = "Advance Search"
        Me.btAdvanceSearch.UseVisualStyleBackColor = True
        '
        'lblCVNbr
        '
        Me.lblCVNbr.BackColor = System.Drawing.Color.Transparent
        Me.lblCVNbr.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCVNbr.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCVNbr.Location = New System.Drawing.Point(660, 3)
        Me.lblCVNbr.Name = "lblCVNbr"
        Me.lblCVNbr.Size = New System.Drawing.Size(157, 23)
        Me.lblCVNbr.TabIndex = 607
        Me.lblCVNbr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnTo
        '
        Me.btnTo.BackColor = System.Drawing.Color.Transparent
        Me.btnTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTo.Image = CType(resources.GetObject("btnTo.Image"), System.Drawing.Image)
        Me.btnTo.Location = New System.Drawing.Point(783, 170)
        Me.btnTo.Name = "btnTo"
        Me.btnTo.Size = New System.Drawing.Size(32, 24)
        Me.btnTo.TabIndex = 593
        Me.btnTo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTo.UseVisualStyleBackColor = False
        '
        'btnFrom
        '
        Me.btnFrom.BackColor = System.Drawing.Color.Transparent
        Me.btnFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFrom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFrom.Image = CType(resources.GetObject("btnFrom.Image"), System.Drawing.Image)
        Me.btnFrom.Location = New System.Drawing.Point(783, 67)
        Me.btnFrom.Name = "btnFrom"
        Me.btnFrom.Size = New System.Drawing.Size(32, 24)
        Me.btnFrom.TabIndex = 592
        Me.btnFrom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFrom.UseVisualStyleBackColor = False
        '
        'cboReport
        '
        Me.cboReport.FormattingEnabled = True
        Me.cboReport.Location = New System.Drawing.Point(288, 14)
        Me.cboReport.Name = "cboReport"
        Me.cboReport.Size = New System.Drawing.Size(121, 21)
        Me.cboReport.TabIndex = 608
        '
        'frmFundTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 536)
        Me.Controls.Add(Me.cboReport)
        Me.Controls.Add(Me.lblCVNbr)
        Me.Controls.Add(Me.btAdvanceSearch)
        Me.Controls.Add(Me.cmdFund)
        Me.Controls.Add(Me.txtTotalAmt)
        Me.Controls.Add(Me.txtExRate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtToAcct)
        Me.Controls.Add(Me.txtFromAcct)
        Me.Controls.Add(Me.ToCCode)
        Me.Controls.Add(Me.fromCCode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAmtInWords)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAmt)
        Me.Controls.Add(Me.btnTo)
        Me.Controls.Add(Me.btnFrom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtToBankAcct)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtToBankCode)
        Me.Controls.Add(Me.txtFromBankAcct)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFromBankCode)
        Me.Controls.Add(Me.gpType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmFundTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fund Transfer Menu"
        Me.TabControl1.ResumeLayout(False)
        Me.tbFT.ResumeLayout(False)
        CType(Me.dtgBankEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbStatus.ResumeLayout(False)
        Me.tbStatus.PerformLayout()
        Me.tbOthers.ResumeLayout(False)
        Me.tbOthers.PerformLayout()
        Me.gpType.ResumeLayout(False)
        Me.gpType.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTotalAmt As TextBox
    Friend WithEvents txtExRate As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbFT As TabPage
    Friend WithEvents dtgBankEntry As DataGridView
    Friend WithEvents colSelectEntry As DataGridViewButtonColumn
    Friend WithEvents colAcctCode As DataGridViewTextBoxColumn
    Friend WithEvents colAcctTitle As DataGridViewTextBoxColumn
    Friend WithEvents colDR As DataGridViewTextBoxColumn
    Friend WithEvents colCR As DataGridViewTextBoxColumn
    Friend WithEvents colSubCode As DataGridViewTextBoxColumn
    Friend WithEvents colSubAcctTitle As DataGridViewTextBoxColumn
    Friend WithEvents colchkDept As DataGridViewCheckBoxColumn
    Friend WithEvents colDeptName As DataGridViewTextBoxColumn
    Friend WithEvents colchkList As DataGridViewCheckBoxColumn
    Friend WithEvents colListItem As DataGridViewTextBoxColumn
    Friend WithEvents colListItemName As DataGridViewTextBoxColumn
    Friend WithEvents tbStatus As TabPage
    Friend WithEvents Label29 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents txtFundedDate As TextBox
    Friend WithEvents txtFundedBy As TextBox
    Friend WithEvents chkFunded As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtPrepBy As TextBox
    Friend WithEvents txtPrepDate As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents chkPosted As CheckBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtPostedBy As TextBox
    Friend WithEvents txtCancelledDate As TextBox
    Friend WithEvents txtPostedDate As TextBox
    Friend WithEvents txtCancelledBy As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents chkCancelled As CheckBox
    Friend WithEvents tbOthers As TabPage
    Friend WithEvents dtFT As DateTimePicker
    Friend WithEvents txtDate As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents txtRefNo As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents txtToAcct As TextBox
    Friend WithEvents txtFromAcct As TextBox
    Friend WithEvents ToCCode As TextBox
    Friend WithEvents fromCCode As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAmtInWords As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAmt As TextBox
    Friend WithEvents btnTo As Button
    Friend WithEvents btnFrom As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtToBankAcct As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtToBankCode As TextBox
    Friend WithEvents txtFromBankAcct As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFromBankCode As TextBox
    Friend WithEvents gpType As GroupBox
    Friend WithEvents rdDollar As RadioButton
    Friend WithEvents rdAffiliates As RadioButton
    Friend WithEvents rdSavings As RadioButton
    Friend WithEvents cmdFund As Button
    Friend WithEvents btAdvanceSearch As Button
    Public WithEvents lblCVNbr As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents cboReport As ComboBox
End Class
