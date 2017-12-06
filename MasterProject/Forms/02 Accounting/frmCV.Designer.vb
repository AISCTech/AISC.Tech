<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCV
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCV))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.lblNonAccrualType = New System.Windows.Forms.Label()
        Me.txtCashInBankWords = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtCashInBank = New System.Windows.Forms.TextBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tpCheckEntry = New System.Windows.Forms.TabPage()
        Me.cmdCashInBank = New System.Windows.Forms.Button()
        Me.dtgCheckEntry = New System.Windows.Forms.DataGridView()
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
        Me.cmdRemoveEntry = New System.Windows.Forms.Button()
        Me.cmdAddEntry = New System.Windows.Forms.Button()
        Me.lblDebit = New System.Windows.Forms.Label()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tpPaymentDetails = New System.Windows.Forms.TabPage()
        Me.cmdAddPaymentDetails = New System.Windows.Forms.Button()
        Me.cmdRemovePaymentDetails = New System.Windows.Forms.Button()
        Me.dtgParticulars = New System.Windows.Forms.DataGridView()
        Me.colReqNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAPVNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFull = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCVAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAmtInWords = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tpStatus = New System.Windows.Forms.TabPage()
        Me.chkPosted = New System.Windows.Forms.CheckBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtStatPostedBy = New System.Windows.Forms.TextBox()
        Me.txtCancelledDate = New System.Windows.Forms.TextBox()
        Me.txtStatPostedDate = New System.Windows.Forms.TextBox()
        Me.txtCancelledBy = New System.Windows.Forms.TextBox()
        Me.chkLiquidate = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.chkRelease = New System.Windows.Forms.CheckBox()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtStatLiquidateDate = New System.Windows.Forms.TextBox()
        Me.txtStatReleaseBy = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtStatLiquidateBy = New System.Windows.Forms.TextBox()
        Me.txtStatReleaseDate = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.gpCVDetails = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.txtCheckNumber = New System.Windows.Forms.TextBox()
        Me.txtReceivedBy = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btLiquidate = New System.Windows.Forms.Button()
        Me.btRelease = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCVNbr = New System.Windows.Forms.Label()
        Me.txtDateNeeded = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPayeeName = New System.Windows.Forms.TextBox()
        Me.txtPayeeCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl2.SuspendLayout()
        Me.tpCheckEntry.SuspendLayout()
        CType(Me.dtgCheckEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPaymentDetails.SuspendLayout()
        CType(Me.dtgParticulars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStatus.SuspendLayout()
        Me.gpCVDetails.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCancel
        '
        Me.lblCancel.AutoSize = True
        Me.lblCancel.BackColor = System.Drawing.Color.Red
        Me.lblCancel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancel.ForeColor = System.Drawing.Color.Black
        Me.lblCancel.Location = New System.Drawing.Point(16, 533)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(98, 18)
        Me.lblCancel.TabIndex = 583
        Me.lblCancel.Text = "CANCELLED"
        Me.lblCancel.Visible = False
        '
        'lblNonAccrualType
        '
        Me.lblNonAccrualType.AutoSize = True
        Me.lblNonAccrualType.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblNonAccrualType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNonAccrualType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNonAccrualType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNonAccrualType.Location = New System.Drawing.Point(16, 512)
        Me.lblNonAccrualType.Name = "lblNonAccrualType"
        Me.lblNonAccrualType.Size = New System.Drawing.Size(2, 18)
        Me.lblNonAccrualType.TabIndex = 582
        '
        'txtCashInBankWords
        '
        Me.txtCashInBankWords.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCashInBankWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashInBankWords.Location = New System.Drawing.Point(783, 512)
        Me.txtCashInBankWords.Multiline = True
        Me.txtCashInBankWords.Name = "txtCashInBankWords"
        Me.txtCashInBankWords.ReadOnly = True
        Me.txtCashInBankWords.Size = New System.Drawing.Size(224, 39)
        Me.txtCashInBankWords.TabIndex = 581
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(684, 516)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 13)
        Me.Label22.TabIndex = 580
        Me.Label22.Text = "Amount in Words:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(354, 516)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 13)
        Me.Label23.TabIndex = 579
        Me.Label23.Text = "Cash in Bank:"
        '
        'txtCashInBank
        '
        Me.txtCashInBank.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCashInBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashInBank.Location = New System.Drawing.Point(441, 511)
        Me.txtCashInBank.Name = "txtCashInBank"
        Me.txtCashInBank.ReadOnly = True
        Me.txtCashInBank.Size = New System.Drawing.Size(224, 20)
        Me.txtCashInBank.TabIndex = 578
        Me.txtCashInBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tpCheckEntry)
        Me.TabControl2.Controls.Add(Me.tpPaymentDetails)
        Me.TabControl2.Controls.Add(Me.tpStatus)
        Me.TabControl2.Location = New System.Drawing.Point(12, 130)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(999, 376)
        Me.TabControl2.TabIndex = 577
        '
        'tpCheckEntry
        '
        Me.tpCheckEntry.Controls.Add(Me.cmdCashInBank)
        Me.tpCheckEntry.Controls.Add(Me.dtgCheckEntry)
        Me.tpCheckEntry.Controls.Add(Me.cmdRemoveEntry)
        Me.tpCheckEntry.Controls.Add(Me.cmdAddEntry)
        Me.tpCheckEntry.Controls.Add(Me.lblDebit)
        Me.tpCheckEntry.Controls.Add(Me.lblCredit)
        Me.tpCheckEntry.Controls.Add(Me.Label38)
        Me.tpCheckEntry.Controls.Add(Me.Label39)
        Me.tpCheckEntry.Location = New System.Drawing.Point(4, 22)
        Me.tpCheckEntry.Name = "tpCheckEntry"
        Me.tpCheckEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCheckEntry.Size = New System.Drawing.Size(991, 350)
        Me.tpCheckEntry.TabIndex = 0
        Me.tpCheckEntry.Text = "Check Entry"
        Me.tpCheckEntry.UseVisualStyleBackColor = True
        '
        'cmdCashInBank
        '
        Me.cmdCashInBank.AccessibleDescription = ""
        Me.cmdCashInBank.AccessibleName = ""
        Me.cmdCashInBank.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCashInBank.Enabled = False
        Me.cmdCashInBank.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdCashInBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCashInBank.Location = New System.Drawing.Point(69, 3)
        Me.cmdCashInBank.Name = "cmdCashInBank"
        Me.cmdCashInBank.Size = New System.Drawing.Size(126, 24)
        Me.cmdCashInBank.TabIndex = 466
        Me.cmdCashInBank.Text = "Cash In Bank"
        Me.cmdCashInBank.UseVisualStyleBackColor = True
        '
        'dtgCheckEntry
        '
        Me.dtgCheckEntry.AllowUserToAddRows = False
        Me.dtgCheckEntry.AllowUserToDeleteRows = False
        Me.dtgCheckEntry.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dtgCheckEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCheckEntry.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectEntry, Me.colAcctCode, Me.colAcctTitle, Me.colDR, Me.colCR, Me.colSubCode, Me.colSubAcctTitle, Me.colchkDept, Me.colDeptName, Me.colchkList, Me.colListItem, Me.colListItemName})
        Me.dtgCheckEntry.Location = New System.Drawing.Point(6, 27)
        Me.dtgCheckEntry.Name = "dtgCheckEntry"
        Me.dtgCheckEntry.Size = New System.Drawing.Size(979, 317)
        Me.dtgCheckEntry.TabIndex = 411
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colDR.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDR.HeaderText = "DR"
        Me.colDR.Name = "colDR"
        Me.colDR.Width = 75
        '
        'colCR
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colCR.DefaultCellStyle = DataGridViewCellStyle6
        Me.colCR.HeaderText = "CR"
        Me.colCR.Name = "colCR"
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
        'cmdRemoveEntry
        '
        Me.cmdRemoveEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRemoveEntry.Enabled = False
        Me.cmdRemoveEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRemoveEntry.Image = CType(resources.GetObject("cmdRemoveEntry.Image"), System.Drawing.Image)
        Me.cmdRemoveEntry.Location = New System.Drawing.Point(38, 3)
        Me.cmdRemoveEntry.Name = "cmdRemoveEntry"
        Me.cmdRemoveEntry.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemoveEntry.TabIndex = 341
        Me.cmdRemoveEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRemoveEntry.UseVisualStyleBackColor = True
        '
        'cmdAddEntry
        '
        Me.cmdAddEntry.AccessibleDescription = ""
        Me.cmdAddEntry.AccessibleName = ""
        Me.cmdAddEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAddEntry.Enabled = False
        Me.cmdAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAddEntry.Image = CType(resources.GetObject("cmdAddEntry.Image"), System.Drawing.Image)
        Me.cmdAddEntry.Location = New System.Drawing.Point(6, 3)
        Me.cmdAddEntry.Name = "cmdAddEntry"
        Me.cmdAddEntry.Size = New System.Drawing.Size(32, 24)
        Me.cmdAddEntry.TabIndex = 340
        Me.cmdAddEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAddEntry.UseVisualStyleBackColor = True
        '
        'lblDebit
        '
        Me.lblDebit.AutoSize = True
        Me.lblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebit.Location = New System.Drawing.Point(616, 8)
        Me.lblDebit.Name = "lblDebit"
        Me.lblDebit.Size = New System.Drawing.Size(36, 16)
        Me.lblDebit.TabIndex = 368
        Me.lblDebit.Text = "0.00"
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredit.Location = New System.Drawing.Point(858, 8)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(36, 16)
        Me.lblCredit.TabIndex = 369
        Me.lblCredit.Text = "0.00"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(539, 8)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(72, 13)
        Me.Label38.TabIndex = 409
        Me.Label38.Text = "Total Debit:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(781, 8)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(76, 13)
        Me.Label39.TabIndex = 410
        Me.Label39.Text = "Total Credit:"
        '
        'tpPaymentDetails
        '
        Me.tpPaymentDetails.Controls.Add(Me.cmdAddPaymentDetails)
        Me.tpPaymentDetails.Controls.Add(Me.cmdRemovePaymentDetails)
        Me.tpPaymentDetails.Controls.Add(Me.dtgParticulars)
        Me.tpPaymentDetails.Controls.Add(Me.txtTotal)
        Me.tpPaymentDetails.Controls.Add(Me.Label13)
        Me.tpPaymentDetails.Controls.Add(Me.txtAmtInWords)
        Me.tpPaymentDetails.Controls.Add(Me.Label14)
        Me.tpPaymentDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpPaymentDetails.Name = "tpPaymentDetails"
        Me.tpPaymentDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPaymentDetails.Size = New System.Drawing.Size(991, 350)
        Me.tpPaymentDetails.TabIndex = 1
        Me.tpPaymentDetails.Text = "Payment Details"
        Me.tpPaymentDetails.UseVisualStyleBackColor = True
        '
        'cmdAddPaymentDetails
        '
        Me.cmdAddPaymentDetails.AccessibleDescription = ""
        Me.cmdAddPaymentDetails.AccessibleName = ""
        Me.cmdAddPaymentDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAddPaymentDetails.Enabled = False
        Me.cmdAddPaymentDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAddPaymentDetails.Image = CType(resources.GetObject("cmdAddPaymentDetails.Image"), System.Drawing.Image)
        Me.cmdAddPaymentDetails.Location = New System.Drawing.Point(15, 6)
        Me.cmdAddPaymentDetails.Name = "cmdAddPaymentDetails"
        Me.cmdAddPaymentDetails.Size = New System.Drawing.Size(32, 24)
        Me.cmdAddPaymentDetails.TabIndex = 343
        Me.cmdAddPaymentDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAddPaymentDetails.UseVisualStyleBackColor = True
        '
        'cmdRemovePaymentDetails
        '
        Me.cmdRemovePaymentDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRemovePaymentDetails.Enabled = False
        Me.cmdRemovePaymentDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRemovePaymentDetails.Image = CType(resources.GetObject("cmdRemovePaymentDetails.Image"), System.Drawing.Image)
        Me.cmdRemovePaymentDetails.Location = New System.Drawing.Point(47, 6)
        Me.cmdRemovePaymentDetails.Name = "cmdRemovePaymentDetails"
        Me.cmdRemovePaymentDetails.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemovePaymentDetails.TabIndex = 342
        Me.cmdRemovePaymentDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRemovePaymentDetails.UseVisualStyleBackColor = True
        Me.cmdRemovePaymentDetails.Visible = False
        '
        'dtgParticulars
        '
        Me.dtgParticulars.AllowUserToAddRows = False
        Me.dtgParticulars.AllowUserToDeleteRows = False
        Me.dtgParticulars.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dtgParticulars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgParticulars.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReqNo, Me.colAPVNo, Me.colPartAmt, Me.colFull, Me.colCVAmt})
        Me.dtgParticulars.Location = New System.Drawing.Point(15, 30)
        Me.dtgParticulars.Name = "dtgParticulars"
        Me.dtgParticulars.ReadOnly = True
        Me.dtgParticulars.Size = New System.Drawing.Size(959, 247)
        Me.dtgParticulars.TabIndex = 309
        '
        'colReqNo
        '
        Me.colReqNo.HeaderText = "Request No."
        Me.colReqNo.Name = "colReqNo"
        Me.colReqNo.ReadOnly = True
        Me.colReqNo.Width = 150
        '
        'colAPVNo
        '
        Me.colAPVNo.HeaderText = "APV No."
        Me.colAPVNo.Name = "colAPVNo"
        Me.colAPVNo.ReadOnly = True
        Me.colAPVNo.Width = 150
        '
        'colPartAmt
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPartAmt.DefaultCellStyle = DataGridViewCellStyle7
        Me.colPartAmt.HeaderText = "Requested Amt"
        Me.colPartAmt.Name = "colPartAmt"
        Me.colPartAmt.ReadOnly = True
        Me.colPartAmt.Width = 125
        '
        'colFull
        '
        Me.colFull.HeaderText = "Full"
        Me.colFull.Name = "colFull"
        Me.colFull.ReadOnly = True
        Me.colFull.Width = 50
        '
        'colCVAmt
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        Me.colCVAmt.DefaultCellStyle = DataGridViewCellStyle8
        Me.colCVAmt.HeaderText = "CV Amt"
        Me.colCVAmt.Name = "colCVAmt"
        Me.colCVAmt.ReadOnly = True
        Me.colCVAmt.Width = 125
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(502, 310)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(213, 20)
        Me.txtTotal.TabIndex = 310
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(499, 294)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 309
        Me.Label13.Text = "Total Amount:"
        '
        'txtAmtInWords
        '
        Me.txtAmtInWords.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAmtInWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmtInWords.Location = New System.Drawing.Point(730, 310)
        Me.txtAmtInWords.Multiline = True
        Me.txtAmtInWords.Name = "txtAmtInWords"
        Me.txtAmtInWords.ReadOnly = True
        Me.txtAmtInWords.Size = New System.Drawing.Size(244, 36)
        Me.txtAmtInWords.TabIndex = 312
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(727, 294)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 13)
        Me.Label14.TabIndex = 311
        Me.Label14.Text = "Amount in Words:"
        '
        'tpStatus
        '
        Me.tpStatus.Controls.Add(Me.chkPosted)
        Me.tpStatus.Controls.Add(Me.Label30)
        Me.tpStatus.Controls.Add(Me.Label36)
        Me.tpStatus.Controls.Add(Me.Label37)
        Me.tpStatus.Controls.Add(Me.txtStatPostedBy)
        Me.tpStatus.Controls.Add(Me.txtCancelledDate)
        Me.tpStatus.Controls.Add(Me.txtStatPostedDate)
        Me.tpStatus.Controls.Add(Me.txtCancelledBy)
        Me.tpStatus.Controls.Add(Me.chkLiquidate)
        Me.tpStatus.Controls.Add(Me.Label31)
        Me.tpStatus.Controls.Add(Me.chkRelease)
        Me.tpStatus.Controls.Add(Me.chkCancel)
        Me.tpStatus.Controls.Add(Me.Label33)
        Me.tpStatus.Controls.Add(Me.txtStatLiquidateDate)
        Me.tpStatus.Controls.Add(Me.txtStatReleaseBy)
        Me.tpStatus.Controls.Add(Me.Label34)
        Me.tpStatus.Controls.Add(Me.Label32)
        Me.tpStatus.Controls.Add(Me.txtStatLiquidateBy)
        Me.tpStatus.Controls.Add(Me.txtStatReleaseDate)
        Me.tpStatus.Controls.Add(Me.Label35)
        Me.tpStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpStatus.Name = "tpStatus"
        Me.tpStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatus.Size = New System.Drawing.Size(991, 350)
        Me.tpStatus.TabIndex = 2
        Me.tpStatus.Text = "Status"
        Me.tpStatus.UseVisualStyleBackColor = True
        '
        'chkPosted
        '
        Me.chkPosted.AutoSize = True
        Me.chkPosted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPosted.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPosted.Location = New System.Drawing.Point(386, 35)
        Me.chkPosted.Name = "chkPosted"
        Me.chkPosted.Size = New System.Drawing.Size(76, 20)
        Me.chkPosted.TabIndex = 403
        Me.chkPosted.Text = "Posted"
        Me.chkPosted.UseVisualStyleBackColor = True
        Me.chkPosted.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(17, 25)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 15)
        Me.Label30.TabIndex = 374
        Me.Label30.Text = "Posted By:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(513, 125)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(81, 15)
        Me.Label36.TabIndex = 402
        Me.Label36.Text = "Date Cancelled"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(513, 106)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(74, 15)
        Me.Label37.TabIndex = 401
        Me.Label37.Text = "Cancelled By:"
        '
        'txtStatPostedBy
        '
        Me.txtStatPostedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatPostedBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtStatPostedBy.Location = New System.Drawing.Point(113, 25)
        Me.txtStatPostedBy.Name = "txtStatPostedBy"
        Me.txtStatPostedBy.ReadOnly = True
        Me.txtStatPostedBy.Size = New System.Drawing.Size(256, 20)
        Me.txtStatPostedBy.TabIndex = 390
        '
        'txtCancelledDate
        '
        Me.txtCancelledDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelledDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCancelledDate.Location = New System.Drawing.Point(609, 122)
        Me.txtCancelledDate.Name = "txtCancelledDate"
        Me.txtCancelledDate.ReadOnly = True
        Me.txtCancelledDate.Size = New System.Drawing.Size(256, 20)
        Me.txtCancelledDate.TabIndex = 400
        '
        'txtStatPostedDate
        '
        Me.txtStatPostedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatPostedDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtStatPostedDate.Location = New System.Drawing.Point(113, 44)
        Me.txtStatPostedDate.Name = "txtStatPostedDate"
        Me.txtStatPostedDate.ReadOnly = True
        Me.txtStatPostedDate.Size = New System.Drawing.Size(256, 20)
        Me.txtStatPostedDate.TabIndex = 393
        '
        'txtCancelledBy
        '
        Me.txtCancelledBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelledBy.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCancelledBy.Location = New System.Drawing.Point(609, 103)
        Me.txtCancelledBy.Name = "txtCancelledBy"
        Me.txtCancelledBy.ReadOnly = True
        Me.txtCancelledBy.Size = New System.Drawing.Size(256, 20)
        Me.txtCancelledBy.TabIndex = 399
        '
        'chkLiquidate
        '
        Me.chkLiquidate.AutoSize = True
        Me.chkLiquidate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLiquidate.Location = New System.Drawing.Point(882, 33)
        Me.chkLiquidate.Name = "chkLiquidate"
        Me.chkLiquidate.Size = New System.Drawing.Size(100, 20)
        Me.chkLiquidate.TabIndex = 397
        Me.chkLiquidate.Text = "Liquidated"
        Me.chkLiquidate.UseVisualStyleBackColor = True
        Me.chkLiquidate.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(17, 44)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 15)
        Me.Label31.TabIndex = 377
        Me.Label31.Text = "Posted Date:"
        '
        'chkRelease
        '
        Me.chkRelease.AutoSize = True
        Me.chkRelease.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRelease.Location = New System.Drawing.Point(386, 111)
        Me.chkRelease.Name = "chkRelease"
        Me.chkRelease.Size = New System.Drawing.Size(95, 20)
        Me.chkRelease.TabIndex = 396
        Me.chkRelease.Text = "Released"
        Me.chkRelease.UseVisualStyleBackColor = True
        Me.chkRelease.Visible = False
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCancel.Location = New System.Drawing.Point(882, 112)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(97, 20)
        Me.chkCancel.TabIndex = 395
        Me.chkCancel.Text = "Cancelled"
        Me.chkCancel.UseVisualStyleBackColor = True
        Me.chkCancel.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(17, 101)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(72, 15)
        Me.Label33.TabIndex = 379
        Me.Label33.Text = "Released By:"
        '
        'txtStatLiquidateDate
        '
        Me.txtStatLiquidateDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatLiquidateDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtStatLiquidateDate.Location = New System.Drawing.Point(609, 43)
        Me.txtStatLiquidateDate.Name = "txtStatLiquidateDate"
        Me.txtStatLiquidateDate.ReadOnly = True
        Me.txtStatLiquidateDate.Size = New System.Drawing.Size(256, 20)
        Me.txtStatLiquidateDate.TabIndex = 388
        '
        'txtStatReleaseBy
        '
        Me.txtStatReleaseBy.BackColor = System.Drawing.SystemColors.Control
        Me.txtStatReleaseBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatReleaseBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtStatReleaseBy.Location = New System.Drawing.Point(113, 101)
        Me.txtStatReleaseBy.Name = "txtStatReleaseBy"
        Me.txtStatReleaseBy.ReadOnly = True
        Me.txtStatReleaseBy.Size = New System.Drawing.Size(256, 20)
        Me.txtStatReleaseBy.TabIndex = 380
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(513, 43)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(88, 15)
        Me.Label34.TabIndex = 387
        Me.Label34.Text = "Date Liquidated:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(17, 120)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(83, 15)
        Me.Label32.TabIndex = 382
        Me.Label32.Text = "Date Released:"
        '
        'txtStatLiquidateBy
        '
        Me.txtStatLiquidateBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatLiquidateBy.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtStatLiquidateBy.Location = New System.Drawing.Point(609, 24)
        Me.txtStatLiquidateBy.Name = "txtStatLiquidateBy"
        Me.txtStatLiquidateBy.ReadOnly = True
        Me.txtStatLiquidateBy.Size = New System.Drawing.Size(256, 20)
        Me.txtStatLiquidateBy.TabIndex = 385
        '
        'txtStatReleaseDate
        '
        Me.txtStatReleaseDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtStatReleaseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatReleaseDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtStatReleaseDate.Location = New System.Drawing.Point(113, 120)
        Me.txtStatReleaseDate.Name = "txtStatReleaseDate"
        Me.txtStatReleaseDate.ReadOnly = True
        Me.txtStatReleaseDate.Size = New System.Drawing.Size(256, 20)
        Me.txtStatReleaseDate.TabIndex = 383
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(513, 24)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(77, 15)
        Me.Label35.TabIndex = 384
        Me.Label35.Text = "Liquidated By:"
        '
        'gpCVDetails
        '
        Me.gpCVDetails.Controls.Add(Me.Label16)
        Me.gpCVDetails.Controls.Add(Me.Label17)
        Me.gpCVDetails.Controls.Add(Me.cboBank)
        Me.gpCVDetails.Controls.Add(Me.txtCheckNumber)
        Me.gpCVDetails.Controls.Add(Me.txtReceivedBy)
        Me.gpCVDetails.Controls.Add(Me.Label26)
        Me.gpCVDetails.Controls.Add(Me.dtCheckDate)
        Me.gpCVDetails.Controls.Add(Me.Label24)
        Me.gpCVDetails.Location = New System.Drawing.Point(593, 12)
        Me.gpCVDetails.Name = "gpCVDetails"
        Me.gpCVDetails.Size = New System.Drawing.Size(418, 112)
        Me.gpCVDetails.TabIndex = 576
        Me.gpCVDetails.TabStop = False
        Me.gpCVDetails.Text = "Voucher Details"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(43, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 15)
        Me.Label16.TabIndex = 414
        Me.Label16.Text = "Bank Name:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Chocolate
        Me.Label17.Location = New System.Drawing.Point(27, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 15)
        Me.Label17.TabIndex = 415
        Me.Label17.Text = "Check Number:"
        '
        'cboBank
        '
        Me.cboBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBank.ForeColor = System.Drawing.Color.RoyalBlue
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Location = New System.Drawing.Point(115, 23)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(288, 21)
        Me.cboBank.TabIndex = 1
        '
        'txtCheckNumber
        '
        Me.txtCheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckNumber.Location = New System.Drawing.Point(115, 43)
        Me.txtCheckNumber.Name = "txtCheckNumber"
        Me.txtCheckNumber.Size = New System.Drawing.Size(288, 20)
        Me.txtCheckNumber.TabIndex = 2
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.BackColor = System.Drawing.SystemColors.Window
        Me.txtReceivedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedBy.Location = New System.Drawing.Point(115, 82)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Size = New System.Drawing.Size(288, 20)
        Me.txtReceivedBy.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Chocolate
        Me.Label26.Location = New System.Drawing.Point(37, 85)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 15)
        Me.Label26.TabIndex = 425
        Me.Label26.Text = "Received by:"
        '
        'dtCheckDate
        '
        Me.dtCheckDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtCheckDate.Location = New System.Drawing.Point(115, 62)
        Me.dtCheckDate.Name = "dtCheckDate"
        Me.dtCheckDate.Size = New System.Drawing.Size(288, 21)
        Me.dtCheckDate.TabIndex = 3
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(41, 66)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 15)
        Me.Label24.TabIndex = 421
        Me.Label24.Text = "Check Date:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btLiquidate)
        Me.GroupBox6.Controls.Add(Me.btRelease)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.lblCVNbr)
        Me.GroupBox6.Controls.Add(Me.txtDateNeeded)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.txtPayeeName)
        Me.GroupBox6.Controls.Add(Me.txtPayeeCode)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(538, 112)
        Me.GroupBox6.TabIndex = 575
        Me.GroupBox6.TabStop = False
        '
        'btLiquidate
        '
        Me.btLiquidate.Location = New System.Drawing.Point(88, 18)
        Me.btLiquidate.Name = "btLiquidate"
        Me.btLiquidate.Size = New System.Drawing.Size(75, 23)
        Me.btLiquidate.TabIndex = 575
        Me.btLiquidate.Text = "Liquidate"
        Me.btLiquidate.UseVisualStyleBackColor = True
        '
        'btRelease
        '
        Me.btRelease.Location = New System.Drawing.Point(11, 18)
        Me.btRelease.Name = "btRelease"
        Me.btRelease.Size = New System.Drawing.Size(75, 23)
        Me.btRelease.TabIndex = 467
        Me.btRelease.Text = "Release"
        Me.btRelease.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(316, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 574
        Me.Label3.Text = "CV No. :"
        '
        'lblCVNbr
        '
        Me.lblCVNbr.AutoSize = True
        Me.lblCVNbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCVNbr.ForeColor = System.Drawing.Color.Red
        Me.lblCVNbr.Location = New System.Drawing.Point(391, 23)
        Me.lblCVNbr.Name = "lblCVNbr"
        Me.lblCVNbr.Size = New System.Drawing.Size(0, 20)
        Me.lblCVNbr.TabIndex = 573
        '
        'txtDateNeeded
        '
        Me.txtDateNeeded.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDateNeeded.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateNeeded.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtDateNeeded.Location = New System.Drawing.Point(90, 84)
        Me.txtDateNeeded.Name = "txtDateNeeded"
        Me.txtDateNeeded.ReadOnly = True
        Me.txtDateNeeded.Size = New System.Drawing.Size(235, 21)
        Me.txtDateNeeded.TabIndex = 459
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(10, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 458
        Me.Label4.Text = "Date Needed:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(90, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 452
        Me.Label1.Text = "Payee Name:"
        '
        'txtPayeeName
        '
        Me.txtPayeeName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPayeeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayeeName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtPayeeName.Location = New System.Drawing.Point(90, 64)
        Me.txtPayeeName.Name = "txtPayeeName"
        Me.txtPayeeName.ReadOnly = True
        Me.txtPayeeName.Size = New System.Drawing.Size(432, 21)
        Me.txtPayeeName.TabIndex = 453
        '
        'txtPayeeCode
        '
        Me.txtPayeeCode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPayeeCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayeeCode.ForeColor = System.Drawing.Color.RoyalBlue
        Me.txtPayeeCode.Location = New System.Drawing.Point(10, 64)
        Me.txtPayeeCode.Name = "txtPayeeCode"
        Me.txtPayeeCode.ReadOnly = True
        Me.txtPayeeCode.Size = New System.Drawing.Size(83, 21)
        Me.txtPayeeCode.TabIndex = 450
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 451
        Me.Label2.Text = "Payee ID:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmCV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 671)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.lblNonAccrualType)
        Me.Controls.Add(Me.txtCashInBankWords)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtCashInBank)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.gpCVDetails)
        Me.Controls.Add(Me.GroupBox6)
        Me.Name = "frmCV"
        Me.Text = "Check/MC VOucher"
        Me.TabControl2.ResumeLayout(False)
        Me.tpCheckEntry.ResumeLayout(False)
        Me.tpCheckEntry.PerformLayout()
        CType(Me.dtgCheckEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPaymentDetails.ResumeLayout(False)
        Me.tpPaymentDetails.PerformLayout()
        CType(Me.dtgParticulars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStatus.ResumeLayout(False)
        Me.tpStatus.PerformLayout()
        Me.gpCVDetails.ResumeLayout(False)
        Me.gpCVDetails.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCancel As Label
    Friend WithEvents lblNonAccrualType As Label
    Friend WithEvents txtCashInBankWords As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtCashInBank As TextBox
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents tpCheckEntry As TabPage
    Friend WithEvents cmdCashInBank As Button
    Friend WithEvents dtgCheckEntry As DataGridView
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
    Friend WithEvents cmdRemoveEntry As Button
    Friend WithEvents cmdAddEntry As Button
    Friend WithEvents lblDebit As Label
    Friend WithEvents lblCredit As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents tpPaymentDetails As TabPage
    Friend WithEvents cmdAddPaymentDetails As Button
    Friend WithEvents cmdRemovePaymentDetails As Button
    Friend WithEvents dtgParticulars As DataGridView
    Friend WithEvents colReqNo As DataGridViewTextBoxColumn
    Friend WithEvents colAPVNo As DataGridViewTextBoxColumn
    Friend WithEvents colPartAmt As DataGridViewTextBoxColumn
    Friend WithEvents colFull As DataGridViewCheckBoxColumn
    Friend WithEvents colCVAmt As DataGridViewTextBoxColumn
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtAmtInWords As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents tpStatus As TabPage
    Friend WithEvents chkPosted As CheckBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtStatPostedBy As TextBox
    Friend WithEvents txtCancelledDate As TextBox
    Friend WithEvents txtStatPostedDate As TextBox
    Friend WithEvents txtCancelledBy As TextBox
    Friend WithEvents chkLiquidate As CheckBox
    Friend WithEvents Label31 As Label
    Friend WithEvents chkRelease As CheckBox
    Friend WithEvents chkCancel As CheckBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtStatLiquidateDate As TextBox
    Friend WithEvents txtStatReleaseBy As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents txtStatLiquidateBy As TextBox
    Friend WithEvents txtStatReleaseDate As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents gpCVDetails As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents txtCheckNumber As TextBox
    Friend WithEvents txtReceivedBy As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents dtCheckDate As DateTimePicker
    Friend WithEvents Label24 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCVNbr As Label
    Friend WithEvents txtDateNeeded As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPayeeName As TextBox
    Friend WithEvents txtPayeeCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents btRelease As Button
    Friend WithEvents btLiquidate As Button
End Class
