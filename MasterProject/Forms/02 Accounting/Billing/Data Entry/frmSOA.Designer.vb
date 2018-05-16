<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSOA
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSOA))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpMain = New System.Windows.Forms.GroupBox()
        Me.txtBilledTo = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.dtPrepDate = New System.Windows.Forms.DateTimePicker()
        Me.dtReceived = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtRegNo = New System.Windows.Forms.TextBox()
        Me.txtForwarder = New System.Windows.Forms.TextBox()
        Me.txtWarehouse = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFreightTerms = New System.Windows.Forms.TextBox()
        Me.txtBookingNo = New System.Windows.Forms.TextBox()
        Me.txtCargoLoad = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtPier = New System.Windows.Forms.TextBox()
        Me.txtShprAddr = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtETA = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cboTermsofPayment = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVessel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOriginDest = New System.Windows.Forms.TextBox()
        Me.txtTransMode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtExrateDollar = New System.Windows.Forms.TextBox()
        Me.txtConsignee = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtWgtMeas = New System.Windows.Forms.TextBox()
        Me.txtDescOfGoods = New System.Windows.Forms.TextBox()
        Me.txtShipper = New System.Windows.Forms.TextBox()
        Me.lblTransType = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCISOANo = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslblCurrentUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStatus1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStatus2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblStatus3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtTotalSOA = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtAmtInWords = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTotalAmtPHP = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboCurrency = New System.Windows.Forms.ComboBox()
        Me.lblRefNo = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtgServiceCharge = New System.Windows.Forms.DataGridView()
        Me.colSSelectCharge = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colSCharges = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colSTerms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colORNbr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSBillAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSBillCurrency = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colSBillPHP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSBillingVAT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSBillingVATAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSDRAcctCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSDRSub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSCRAcctCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSCRSub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contCharges = New System.Windows.Forms.Panel()
        Me.cmdClearSRows = New System.Windows.Forms.Button()
        Me.cmdRemoveSRow = New System.Windows.Forms.Button()
        Me.cmdAddSRow = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtCRTotal = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtDRTotal = New System.Windows.Forms.TextBox()
        Me.dtgAcctgTitle = New System.Windows.Forms.DataGridView()
        Me.colAcctCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtgOR = New System.Windows.Forms.DataGridView()
        Me.colBillingRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCheckAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCheckNbr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.dgUnpostHistory = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tscmdSearch = New System.Windows.Forms.ToolStripButton()
        Me.tstxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SOANoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CINoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tslblSearch = New System.Windows.Forms.ToolStripLabel()
        Me.tscmdPrint = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SOAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DraftSOAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoftCopySOAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tscmdClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PostBatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BillingSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnbilledBookingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BiilingVsReceivablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnreceivedBillingSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.gpMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtgServiceCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contCharges.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dtgAcctgTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dtgOR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        CType(Me.dgUnpostHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpMain
        '
        Me.gpMain.BackColor = System.Drawing.Color.PaleGreen
        Me.gpMain.Controls.Add(Me.txtBilledTo)
        Me.gpMain.Controls.Add(Me.txtDate)
        Me.gpMain.Controls.Add(Me.Label46)
        Me.gpMain.Controls.Add(Me.dtPrepDate)
        Me.gpMain.Controls.Add(Me.dtReceived)
        Me.gpMain.Controls.Add(Me.Label18)
        Me.gpMain.Controls.Add(Me.Label19)
        Me.gpMain.Controls.Add(Me.txtRegNo)
        Me.gpMain.Controls.Add(Me.txtForwarder)
        Me.gpMain.Controls.Add(Me.txtWarehouse)
        Me.gpMain.Controls.Add(Me.Label13)
        Me.gpMain.Controls.Add(Me.Label11)
        Me.gpMain.Controls.Add(Me.txtFreightTerms)
        Me.gpMain.Controls.Add(Me.txtBookingNo)
        Me.gpMain.Controls.Add(Me.txtCargoLoad)
        Me.gpMain.Controls.Add(Me.Label8)
        Me.gpMain.Controls.Add(Me.Label17)
        Me.gpMain.Controls.Add(Me.Label31)
        Me.gpMain.Controls.Add(Me.txtPier)
        Me.gpMain.Controls.Add(Me.txtShprAddr)
        Me.gpMain.Controls.Add(Me.Label14)
        Me.gpMain.Controls.Add(Me.txtETA)
        Me.gpMain.Controls.Add(Me.Label15)
        Me.gpMain.Controls.Add(Me.lbl)
        Me.gpMain.Controls.Add(Me.cboTermsofPayment)
        Me.gpMain.Controls.Add(Me.Label6)
        Me.gpMain.Controls.Add(Me.Label7)
        Me.gpMain.Controls.Add(Me.txtVessel)
        Me.gpMain.Controls.Add(Me.Label4)
        Me.gpMain.Controls.Add(Me.txtOriginDest)
        Me.gpMain.Controls.Add(Me.txtTransMode)
        Me.gpMain.Controls.Add(Me.Label10)
        Me.gpMain.Controls.Add(Me.Label9)
        Me.gpMain.Controls.Add(Me.txtExrateDollar)
        Me.gpMain.Controls.Add(Me.txtConsignee)
        Me.gpMain.Controls.Add(Me.Label28)
        Me.gpMain.Controls.Add(Me.txtWgtMeas)
        Me.gpMain.Controls.Add(Me.txtDescOfGoods)
        Me.gpMain.Controls.Add(Me.txtShipper)
        Me.gpMain.Controls.Add(Me.lblTransType)
        Me.gpMain.Controls.Add(Me.Label5)
        Me.gpMain.Controls.Add(Me.Label3)
        Me.gpMain.Controls.Add(Me.Label2)
        Me.gpMain.Controls.Add(Me.txtCISOANo)
        Me.gpMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpMain.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpMain.Location = New System.Drawing.Point(12, 28)
        Me.gpMain.Name = "gpMain"
        Me.gpMain.Size = New System.Drawing.Size(978, 199)
        Me.gpMain.TabIndex = 1185
        Me.gpMain.TabStop = False
        '
        'txtBilledTo
        '
        Me.txtBilledTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBilledTo.Location = New System.Drawing.Point(89, 35)
        Me.txtBilledTo.Name = "txtBilledTo"
        Me.txtBilledTo.ReadOnly = True
        Me.txtBilledTo.Size = New System.Drawing.Size(279, 21)
        Me.txtBilledTo.TabIndex = 1197
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDate.Location = New System.Drawing.Point(851, 152)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(93, 21)
        Me.txtDate.TabIndex = 1193
        Me.txtDate.Visible = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label46.Location = New System.Drawing.Point(848, 137)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(96, 13)
        Me.Label46.TabIndex = 1195
        Me.Label46.Text = "Date Received:"
        Me.Label46.Visible = False
        '
        'dtPrepDate
        '
        Me.dtPrepDate.Location = New System.Drawing.Point(941, 152)
        Me.dtPrepDate.Name = "dtPrepDate"
        Me.dtPrepDate.Size = New System.Drawing.Size(26, 21)
        Me.dtPrepDate.TabIndex = 1196
        Me.dtPrepDate.Visible = False
        '
        'dtReceived
        '
        Me.dtReceived.Enabled = False
        Me.dtReceived.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtReceived.Location = New System.Drawing.Point(950, 152)
        Me.dtReceived.Name = "dtReceived"
        Me.dtReceived.Size = New System.Drawing.Size(16, 21)
        Me.dtReceived.TabIndex = 1194
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Location = New System.Drawing.Point(419, 140)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 1146
        Me.Label18.Text = "Reg. No. :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.Location = New System.Drawing.Point(402, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 13)
        Me.Label19.TabIndex = 1191
        Me.Label19.Text = "Booking No :"
        '
        'txtRegNo
        '
        Me.txtRegNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRegNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegNo.Location = New System.Drawing.Point(483, 137)
        Me.txtRegNo.Name = "txtRegNo"
        Me.txtRegNo.ReadOnly = True
        Me.txtRegNo.Size = New System.Drawing.Size(208, 21)
        Me.txtRegNo.TabIndex = 1145
        '
        'txtForwarder
        '
        Me.txtForwarder.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtForwarder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForwarder.Location = New System.Drawing.Point(483, 77)
        Me.txtForwarder.Name = "txtForwarder"
        Me.txtForwarder.ReadOnly = True
        Me.txtForwarder.Size = New System.Drawing.Size(208, 21)
        Me.txtForwarder.TabIndex = 1178
        '
        'txtWarehouse
        '
        Me.txtWarehouse.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtWarehouse.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarehouse.Location = New System.Drawing.Point(483, 157)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(208, 21)
        Me.txtWarehouse.TabIndex = 1180
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(400, 160)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 1181
        Me.Label13.Text = "Warehouse :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.Location = New System.Drawing.Point(406, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 1179
        Me.Label11.Text = "Forwarder :"
        '
        'txtFreightTerms
        '
        Me.txtFreightTerms.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFreightTerms.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreightTerms.Location = New System.Drawing.Point(851, 32)
        Me.txtFreightTerms.Name = "txtFreightTerms"
        Me.txtFreightTerms.ReadOnly = True
        Me.txtFreightTerms.Size = New System.Drawing.Size(116, 21)
        Me.txtFreightTerms.TabIndex = 1189
        Me.txtFreightTerms.TabStop = False
        '
        'txtBookingNo
        '
        Me.txtBookingNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtBookingNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBookingNo.Location = New System.Drawing.Point(483, 37)
        Me.txtBookingNo.Name = "txtBookingNo"
        Me.txtBookingNo.ReadOnly = True
        Me.txtBookingNo.Size = New System.Drawing.Size(208, 21)
        Me.txtBookingNo.TabIndex = 1190
        '
        'txtCargoLoad
        '
        Me.txtCargoLoad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCargoLoad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargoLoad.Location = New System.Drawing.Point(733, 115)
        Me.txtCargoLoad.Name = "txtCargoLoad"
        Me.txtCargoLoad.ReadOnly = True
        Me.txtCargoLoad.Size = New System.Drawing.Size(109, 21)
        Me.txtCargoLoad.TabIndex = 1187
        Me.txtCargoLoad.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(730, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 1186
        Me.Label8.Text = "Cargo Load :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(730, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 1185
        Me.Label17.Text = "Pier :"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.Location = New System.Drawing.Point(21, 57)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 26)
        Me.Label31.TabIndex = 51
        Me.Label31.Text = "Billed To" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Address :"
        '
        'txtPier
        '
        Me.txtPier.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPier.Location = New System.Drawing.Point(731, 32)
        Me.txtPier.Name = "txtPier"
        Me.txtPier.ReadOnly = True
        Me.txtPier.Size = New System.Drawing.Size(98, 21)
        Me.txtPier.TabIndex = 1184
        '
        'txtShprAddr
        '
        Me.txtShprAddr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtShprAddr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShprAddr.Location = New System.Drawing.Point(89, 55)
        Me.txtShprAddr.Multiline = True
        Me.txtShprAddr.Name = "txtShprAddr"
        Me.txtShprAddr.ReadOnly = True
        Me.txtShprAddr.Size = New System.Drawing.Size(279, 47)
        Me.txtShprAddr.TabIndex = 50
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.Location = New System.Drawing.Point(23, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 1148
        Me.Label14.Text = "Billed To :"
        '
        'txtETA
        '
        Me.txtETA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtETA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtETA.Location = New System.Drawing.Point(733, 152)
        Me.txtETA.Name = "txtETA"
        Me.txtETA.ReadOnly = True
        Me.txtETA.Size = New System.Drawing.Size(102, 21)
        Me.txtETA.TabIndex = 1188
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.Location = New System.Drawing.Point(731, 139)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 1147
        Me.Label15.Text = "ETA :"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbl.Location = New System.Drawing.Point(728, 62)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(117, 13)
        Me.lbl.TabIndex = 1150
        Me.lbl.Text = "Terms of Payment :"
        '
        'cboTermsofPayment
        '
        Me.cboTermsofPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTermsofPayment.FormattingEnabled = True
        Me.cboTermsofPayment.Location = New System.Drawing.Point(731, 76)
        Me.cboTermsofPayment.Name = "cboTermsofPayment"
        Me.cboTermsofPayment.Size = New System.Drawing.Size(109, 21)
        Me.cboTermsofPayment.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(848, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 1139
        Me.Label6.Text = "Frt. Terms :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(428, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 1177
        Me.Label7.Text = "Vessel :"
        '
        'txtVessel
        '
        Me.txtVessel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtVessel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVessel.Location = New System.Drawing.Point(483, 117)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.ReadOnly = True
        Me.txtVessel.Size = New System.Drawing.Size(208, 21)
        Me.txtVessel.TabIndex = 1176
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(396, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 1175
        Me.Label4.Text = "Origin/Dest. :"
        '
        'txtOriginDest
        '
        Me.txtOriginDest.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtOriginDest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginDest.Location = New System.Drawing.Point(483, 97)
        Me.txtOriginDest.Name = "txtOriginDest"
        Me.txtOriginDest.ReadOnly = True
        Me.txtOriginDest.Size = New System.Drawing.Size(208, 21)
        Me.txtOriginDest.TabIndex = 1174
        '
        'txtTransMode
        '
        Me.txtTransMode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTransMode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransMode.Location = New System.Drawing.Point(851, 115)
        Me.txtTransMode.Name = "txtTransMode"
        Me.txtTransMode.ReadOnly = True
        Me.txtTransMode.Size = New System.Drawing.Size(116, 21)
        Me.txtTransMode.TabIndex = 1171
        Me.txtTransMode.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Location = New System.Drawing.Point(848, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 1170
        Me.Label10.Text = "Transport Mode :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(848, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 1169
        Me.Label9.Text = "Dollar ExRate :"
        '
        'txtExrateDollar
        '
        Me.txtExrateDollar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtExrateDollar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExrateDollar.Location = New System.Drawing.Point(851, 76)
        Me.txtExrateDollar.Name = "txtExrateDollar"
        Me.txtExrateDollar.ReadOnly = True
        Me.txtExrateDollar.Size = New System.Drawing.Size(116, 21)
        Me.txtExrateDollar.TabIndex = 148
        Me.txtExrateDollar.TabStop = False
        Me.txtExrateDollar.Text = "0.00"
        Me.txtExrateDollar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConsignee
        '
        Me.txtConsignee.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtConsignee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsignee.Location = New System.Drawing.Point(89, 121)
        Me.txtConsignee.Name = "txtConsignee"
        Me.txtConsignee.ReadOnly = True
        Me.txtConsignee.Size = New System.Drawing.Size(279, 21)
        Me.txtConsignee.TabIndex = 3
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.Location = New System.Drawing.Point(405, 60)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(72, 13)
        Me.Label28.TabIndex = 1159
        Me.Label28.Text = "Wgt/Meas :"
        '
        'txtWgtMeas
        '
        Me.txtWgtMeas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtWgtMeas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWgtMeas.Location = New System.Drawing.Point(483, 57)
        Me.txtWgtMeas.Name = "txtWgtMeas"
        Me.txtWgtMeas.ReadOnly = True
        Me.txtWgtMeas.Size = New System.Drawing.Size(208, 21)
        Me.txtWgtMeas.TabIndex = 1158
        '
        'txtDescOfGoods
        '
        Me.txtDescOfGoods.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDescOfGoods.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescOfGoods.Location = New System.Drawing.Point(89, 141)
        Me.txtDescOfGoods.Multiline = True
        Me.txtDescOfGoods.Name = "txtDescOfGoods"
        Me.txtDescOfGoods.ReadOnly = True
        Me.txtDescOfGoods.Size = New System.Drawing.Size(279, 43)
        Me.txtDescOfGoods.TabIndex = 1140
        '
        'txtShipper
        '
        Me.txtShipper.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtShipper.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipper.Location = New System.Drawing.Point(89, 101)
        Me.txtShipper.Name = "txtShipper"
        Me.txtShipper.ReadOnly = True
        Me.txtShipper.Size = New System.Drawing.Size(279, 21)
        Me.txtShipper.TabIndex = 2
        '
        'lblTransType
        '
        Me.lblTransType.AutoSize = True
        Me.lblTransType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTransType.Location = New System.Drawing.Point(21, 19)
        Me.lblTransType.Name = "lblTransType"
        Me.lblTransType.Size = New System.Drawing.Size(62, 13)
        Me.lblTransType.TabIndex = 1142
        Me.lblTransType.Text = "S.O.A No. :"
        Me.lblTransType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(11, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 35)
        Me.Label5.TabIndex = 1138
        Me.Label5.Text = "Description Of Goods :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(12, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 1136
        Me.Label3.Text = "Consignee :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(27, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1134
        Me.Label2.Text = "Shipper :"
        '
        'txtCISOANo
        '
        Me.txtCISOANo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCISOANo.Location = New System.Drawing.Point(89, 15)
        Me.txtCISOANo.Name = "txtCISOANo"
        Me.txtCISOANo.ReadOnly = True
        Me.txtCISOANo.Size = New System.Drawing.Size(108, 21)
        Me.txtCISOANo.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblCurrentUser, Me.tslblPrepBy, Me.tslblPrepDate, Me.tslblStatus1, Me.tslblStatus2, Me.tslblStatus3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 593)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1006, 22)
        Me.StatusStrip1.TabIndex = 1196
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslblCurrentUser
        '
        Me.tslblCurrentUser.Name = "tslblCurrentUser"
        Me.tslblCurrentUser.Size = New System.Drawing.Size(0, 17)
        '
        'tslblPrepBy
        '
        Me.tslblPrepBy.Name = "tslblPrepBy"
        Me.tslblPrepBy.Size = New System.Drawing.Size(0, 17)
        '
        'tslblPrepDate
        '
        Me.tslblPrepDate.Name = "tslblPrepDate"
        Me.tslblPrepDate.Size = New System.Drawing.Size(0, 17)
        '
        'tslblStatus1
        '
        Me.tslblStatus1.Name = "tslblStatus1"
        Me.tslblStatus1.Size = New System.Drawing.Size(0, 17)
        '
        'tslblStatus2
        '
        Me.tslblStatus2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tslblStatus2.Name = "tslblStatus2"
        Me.tslblStatus2.Size = New System.Drawing.Size(0, 17)
        '
        'tslblStatus3
        '
        Me.tslblStatus3.Name = "tslblStatus3"
        Me.tslblStatus3.Size = New System.Drawing.Size(0, 17)
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.PaleGreen
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.txtTotalSOA)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtAmtInWords)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtTotalAmtPHP)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.cboCurrency)
        Me.GroupBox2.Location = New System.Drawing.Point(705, 301)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(281, 264)
        Me.GroupBox2.TabIndex = 1193
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Computation"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.Location = New System.Drawing.Point(124, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(10, 13)
        Me.Label27.TabIndex = 1176
        Me.Label27.Text = ":"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.Location = New System.Drawing.Point(124, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 13)
        Me.Label20.TabIndex = 1174
        Me.Label20.Text = ":"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(124, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 13)
        Me.Label1.TabIndex = 1173
        Me.Label1.Text = ":"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.Location = New System.Drawing.Point(43, 19)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(62, 13)
        Me.Label34.TabIndex = 1172
        Me.Label34.Text = "Total SOA"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTotalSOA
        '
        Me.txtTotalSOA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotalSOA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSOA.Location = New System.Drawing.Point(137, 11)
        Me.txtTotalSOA.Name = "txtTotalSOA"
        Me.txtTotalSOA.ReadOnly = True
        Me.txtTotalSOA.Size = New System.Drawing.Size(138, 21)
        Me.txtTotalSOA.TabIndex = 1171
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.Location = New System.Drawing.Point(6, 106)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 13)
        Me.Label29.TabIndex = 1166
        Me.Label29.Text = "Amount In Words :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtAmtInWords
        '
        Me.txtAmtInWords.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAmtInWords.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmtInWords.Location = New System.Drawing.Point(9, 122)
        Me.txtAmtInWords.Multiline = True
        Me.txtAmtInWords.Name = "txtAmtInWords"
        Me.txtAmtInWords.ReadOnly = True
        Me.txtAmtInWords.Size = New System.Drawing.Size(266, 133)
        Me.txtAmtInWords.TabIndex = 1165
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.Location = New System.Drawing.Point(5, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(119, 13)
        Me.Label26.TabIndex = 1164
        Me.Label26.Text = "Total Amount (PHP)"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTotalAmtPHP
        '
        Me.txtTotalAmtPHP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotalAmtPHP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmtPHP.Location = New System.Drawing.Point(137, 74)
        Me.txtTotalAmtPHP.Name = "txtTotalAmtPHP"
        Me.txtTotalAmtPHP.ReadOnly = True
        Me.txtTotalAmtPHP.Size = New System.Drawing.Size(138, 21)
        Me.txtTotalAmtPHP.TabIndex = 1163
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.Location = New System.Drawing.Point(66, 57)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 13)
        Me.Label25.TabIndex = 1162
        Me.Label25.Text = "Currency"
        '
        'cboCurrency
        '
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Location = New System.Drawing.Point(137, 53)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(138, 21)
        Me.cboCurrency.TabIndex = 1161
        '
        'lblRefNo
        '
        Me.lblRefNo.BackColor = System.Drawing.SystemColors.Info
        Me.lblRefNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRefNo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefNo.ForeColor = System.Drawing.Color.Black
        Me.lblRefNo.Location = New System.Drawing.Point(705, 268)
        Me.lblRefNo.Name = "lblRefNo"
        Me.lblRefNo.Size = New System.Drawing.Size(275, 21)
        Me.lblRefNo.TabIndex = 1194
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.SystemColors.Info
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(705, 250)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(65, 18)
        Me.Label32.TabIndex = 1195
        Me.Label32.Text = "Ref No. :"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Location = New System.Drawing.Point(12, 233)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(691, 334)
        Me.TabControl1.TabIndex = 1192
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtgServiceCharge)
        Me.TabPage1.Controls.Add(Me.contCharges)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(683, 308)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Charges"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtgServiceCharge
        '
        Me.dtgServiceCharge.AllowUserToAddRows = False
        Me.dtgServiceCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgServiceCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSSelectCharge, Me.colSCharges, Me.colSTerms, Me.colORNbr, Me.colSBillAmt, Me.colSBillCurrency, Me.colSBillPHP, Me.colSBillingVAT, Me.colSBillingVATAmt, Me.colSRemarks, Me.colSDRAcctCode, Me.colSDRSub, Me.colSCRAcctCode, Me.colSCRSub, Me.Column1})
        Me.dtgServiceCharge.Location = New System.Drawing.Point(6, 36)
        Me.dtgServiceCharge.Name = "dtgServiceCharge"
        Me.dtgServiceCharge.Size = New System.Drawing.Size(671, 266)
        Me.dtgServiceCharge.TabIndex = 388
        '
        'colSSelectCharge
        '
        Me.colSSelectCharge.Frozen = True
        Me.colSSelectCharge.HeaderText = ""
        Me.colSSelectCharge.Name = "colSSelectCharge"
        Me.colSSelectCharge.Visible = False
        Me.colSSelectCharge.Width = 25
        '
        'colSCharges
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colSCharges.DefaultCellStyle = DataGridViewCellStyle1
        Me.colSCharges.Frozen = True
        Me.colSCharges.HeaderText = "Charges"
        Me.colSCharges.Name = "colSCharges"
        Me.colSCharges.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSCharges.Width = 175
        '
        'colSTerms
        '
        Me.colSTerms.HeaderText = "Terms"
        Me.colSTerms.Name = "colSTerms"
        Me.colSTerms.ReadOnly = True
        '
        'colORNbr
        '
        Me.colORNbr.HeaderText = "O.R No."
        Me.colORNbr.Name = "colORNbr"
        '
        'colSBillAmt
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.colSBillAmt.DefaultCellStyle = DataGridViewCellStyle2
        Me.colSBillAmt.HeaderText = "Amount"
        Me.colSBillAmt.Name = "colSBillAmt"
        Me.colSBillAmt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSBillAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colSBillCurrency
        '
        Me.colSBillCurrency.HeaderText = "Currency"
        Me.colSBillCurrency.Name = "colSBillCurrency"
        '
        'colSBillPHP
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0.00"
        Me.colSBillPHP.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSBillPHP.HeaderText = "(PHP)"
        Me.colSBillPHP.Name = "colSBillPHP"
        Me.colSBillPHP.ReadOnly = True
        '
        'colSBillingVAT
        '
        Me.colSBillingVAT.HeaderText = "VAT"
        Me.colSBillingVAT.Name = "colSBillingVAT"
        Me.colSBillingVAT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSBillingVAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSBillingVAT.Visible = False
        Me.colSBillingVAT.Width = 50
        '
        'colSBillingVATAmt
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0.00"
        Me.colSBillingVATAmt.DefaultCellStyle = DataGridViewCellStyle4
        Me.colSBillingVATAmt.HeaderText = "VAT Amt"
        Me.colSBillingVATAmt.Name = "colSBillingVATAmt"
        Me.colSBillingVATAmt.Visible = False
        '
        'colSRemarks
        '
        Me.colSRemarks.HeaderText = "Remarks"
        Me.colSRemarks.Name = "colSRemarks"
        Me.colSRemarks.Width = 200
        '
        'colSDRAcctCode
        '
        Me.colSDRAcctCode.HeaderText = "DRAcctCode"
        Me.colSDRAcctCode.Name = "colSDRAcctCode"
        Me.colSDRAcctCode.ReadOnly = True
        Me.colSDRAcctCode.Visible = False
        '
        'colSDRSub
        '
        Me.colSDRSub.HeaderText = "SubCode"
        Me.colSDRSub.Name = "colSDRSub"
        Me.colSDRSub.ReadOnly = True
        Me.colSDRSub.Visible = False
        '
        'colSCRAcctCode
        '
        Me.colSCRAcctCode.HeaderText = "CRAcctCode"
        Me.colSCRAcctCode.Name = "colSCRAcctCode"
        Me.colSCRAcctCode.ReadOnly = True
        Me.colSCRAcctCode.Visible = False
        '
        'colSCRSub
        '
        Me.colSCRSub.HeaderText = "SubCode"
        Me.colSCRSub.Name = "colSCRSub"
        Me.colSCRSub.ReadOnly = True
        Me.colSCRSub.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "CH Code"
        Me.Column1.Name = "Column1"
        '
        'contCharges
        '
        Me.contCharges.Controls.Add(Me.cmdClearSRows)
        Me.contCharges.Controls.Add(Me.cmdRemoveSRow)
        Me.contCharges.Controls.Add(Me.cmdAddSRow)
        Me.contCharges.Location = New System.Drawing.Point(577, 6)
        Me.contCharges.Name = "contCharges"
        Me.contCharges.Size = New System.Drawing.Size(101, 33)
        Me.contCharges.TabIndex = 1171
        '
        'cmdClearSRows
        '
        Me.cmdClearSRows.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdClearSRows.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdClearSRows.Image = CType(resources.GetObject("cmdClearSRows.Image"), System.Drawing.Image)
        Me.cmdClearSRows.Location = New System.Drawing.Point(67, 6)
        Me.cmdClearSRows.Name = "cmdClearSRows"
        Me.cmdClearSRows.Size = New System.Drawing.Size(32, 24)
        Me.cmdClearSRows.TabIndex = 391
        Me.cmdClearSRows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdClearSRows.UseVisualStyleBackColor = True
        '
        'cmdRemoveSRow
        '
        Me.cmdRemoveSRow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRemoveSRow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdRemoveSRow.Image = CType(resources.GetObject("cmdRemoveSRow.Image"), System.Drawing.Image)
        Me.cmdRemoveSRow.Location = New System.Drawing.Point(34, 6)
        Me.cmdRemoveSRow.Name = "cmdRemoveSRow"
        Me.cmdRemoveSRow.Size = New System.Drawing.Size(32, 24)
        Me.cmdRemoveSRow.TabIndex = 390
        Me.cmdRemoveSRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdRemoveSRow.UseVisualStyleBackColor = True
        '
        'cmdAddSRow
        '
        Me.cmdAddSRow.AccessibleDescription = ""
        Me.cmdAddSRow.AccessibleName = ""
        Me.cmdAddSRow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAddSRow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdAddSRow.Image = CType(resources.GetObject("cmdAddSRow.Image"), System.Drawing.Image)
        Me.cmdAddSRow.Location = New System.Drawing.Point(3, 6)
        Me.cmdAddSRow.Name = "cmdAddSRow"
        Me.cmdAddSRow.Size = New System.Drawing.Size(32, 24)
        Me.cmdAddSRow.TabIndex = 389
        Me.cmdAddSRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAddSRow.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label38)
        Me.TabPage3.Controls.Add(Me.txtCRTotal)
        Me.TabPage3.Controls.Add(Me.Label39)
        Me.TabPage3.Controls.Add(Me.txtDRTotal)
        Me.TabPage3.Controls.Add(Me.dtgAcctgTitle)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(683, 308)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Accounting Entry"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.Location = New System.Drawing.Point(427, 279)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(85, 13)
        Me.Label38.TabIndex = 251
        Me.Label38.Text = "Total Credit : "
        '
        'txtCRTotal
        '
        Me.txtCRTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCRTotal.Location = New System.Drawing.Point(518, 275)
        Me.txtCRTotal.Name = "txtCRTotal"
        Me.txtCRTotal.ReadOnly = True
        Me.txtCRTotal.Size = New System.Drawing.Size(159, 22)
        Me.txtCRTotal.TabIndex = 252
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.Location = New System.Drawing.Point(345, 252)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(82, 13)
        Me.Label39.TabIndex = 249
        Me.Label39.Text = "Total Debit : "
        '
        'txtDRTotal
        '
        Me.txtDRTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDRTotal.Location = New System.Drawing.Point(433, 248)
        Me.txtDRTotal.Name = "txtDRTotal"
        Me.txtDRTotal.ReadOnly = True
        Me.txtDRTotal.Size = New System.Drawing.Size(159, 22)
        Me.txtDRTotal.TabIndex = 250
        '
        'dtgAcctgTitle
        '
        Me.dtgAcctgTitle.AllowUserToAddRows = False
        Me.dtgAcctgTitle.AllowUserToDeleteRows = False
        Me.dtgAcctgTitle.AllowUserToResizeRows = False
        Me.dtgAcctgTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAcctgTitle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAcctCode, Me.colAcctTitle, Me.colSubAcctCode, Me.colSubAcctTitle, Me.colDept, Me.colDeptName, Me.colList, Me.colListItem, Me.colListItemName, Me.colDR, Me.colCR})
        Me.dtgAcctgTitle.Location = New System.Drawing.Point(6, 3)
        Me.dtgAcctgTitle.Name = "dtgAcctgTitle"
        Me.dtgAcctgTitle.ReadOnly = True
        Me.dtgAcctgTitle.Size = New System.Drawing.Size(671, 239)
        Me.dtgAcctgTitle.TabIndex = 248
        '
        'colAcctCode
        '
        Me.colAcctCode.HeaderText = "Account Code"
        Me.colAcctCode.Name = "colAcctCode"
        Me.colAcctCode.ReadOnly = True
        Me.colAcctCode.Width = 125
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.colDR.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDR.HeaderText = "Debit"
        Me.colDR.Name = "colDR"
        Me.colDR.ReadOnly = True
        '
        'colCR
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.colCR.DefaultCellStyle = DataGridViewCellStyle6
        Me.colCR.HeaderText = "Credit"
        Me.colCR.Name = "colCR"
        Me.colCR.ReadOnly = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label40)
        Me.TabPage5.Controls.Add(Me.dtgOR)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(683, 308)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Collection (AR)"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Firebrick
        Me.Label40.Location = New System.Drawing.Point(1, 2)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(165, 13)
        Me.Label40.TabIndex = 1147
        Me.Label40.Text = "ACKNOWLEDGMENT RECEIPT:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtgOR
        '
        Me.dtgOR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgOR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBillingRefNo, Me.DataGridViewTextBoxColumn6, Me.colCheckAmt, Me.colCheckNbr, Me.colCashAmt, Me.colCWT})
        Me.dtgOR.Location = New System.Drawing.Point(3, 18)
        Me.dtgOR.Name = "dtgOR"
        Me.dtgOR.Size = New System.Drawing.Size(674, 285)
        Me.dtgOR.TabIndex = 1146
        '
        'colBillingRefNo
        '
        Me.colBillingRefNo.HeaderText = "Billing Ref. No."
        Me.colBillingRefNo.Name = "colBillingRefNo"
        Me.colBillingRefNo.Width = 125
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "OR No."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 200
        '
        'colCheckAmt
        '
        Me.colCheckAmt.HeaderText = "Check Amount"
        Me.colCheckAmt.Name = "colCheckAmt"
        '
        'colCheckNbr
        '
        Me.colCheckNbr.HeaderText = "Check No."
        Me.colCheckNbr.Name = "colCheckNbr"
        '
        'colCashAmt
        '
        Me.colCashAmt.HeaderText = "Cash Amount"
        Me.colCashAmt.Name = "colCashAmt"
        '
        'colCWT
        '
        Me.colCWT.HeaderText = "CWT Amount"
        Me.colCWT.Name = "colCWT"
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.dgUnpostHistory)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(683, 308)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Unpost History"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'dgUnpostHistory
        '
        Me.dgUnpostHistory.AllowUserToAddRows = False
        Me.dgUnpostHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUnpostHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column2, Me.Column4, Me.Column5, Me.Column6})
        Me.dgUnpostHistory.Location = New System.Drawing.Point(18, 10)
        Me.dgUnpostHistory.Name = "dgUnpostHistory"
        Me.dgUnpostHistory.ReadOnly = True
        Me.dgUnpostHistory.Size = New System.Drawing.Size(646, 287)
        Me.dgUnpostHistory.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.HeaderText = "Tag"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Bill Ref. No."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Remarks"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 200
        '
        'Column5
        '
        Me.Column5.HeaderText = "Requested By"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Date Unposted"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 150
        '
        'tscmdSearch
        '
        Me.tscmdSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tscmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdSearch.Name = "tscmdSearch"
        Me.tscmdSearch.Size = New System.Drawing.Size(95, 22)
        Me.tscmdSearch.Text = "Advance Search"
        '
        'tstxtSearch
        '
        Me.tstxtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tstxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tstxtSearch.Name = "tstxtSearch"
        Me.tstxtSearch.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RToolStripMenuItem, Me.SOANoToolStripMenuItem, Me.CINoToolStripMenuItem})
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'RToolStripMenuItem
        '
        Me.RToolStripMenuItem.Name = "RToolStripMenuItem"
        Me.RToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RToolStripMenuItem.Text = "Ref. No."
        '
        'SOANoToolStripMenuItem
        '
        Me.SOANoToolStripMenuItem.Name = "SOANoToolStripMenuItem"
        Me.SOANoToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.SOANoToolStripMenuItem.Text = "S.O.A. No."
        '
        'CINoToolStripMenuItem
        '
        Me.CINoToolStripMenuItem.Name = "CINoToolStripMenuItem"
        Me.CINoToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CINoToolStripMenuItem.Text = "C.I. No."
        '
        'tslblSearch
        '
        Me.tslblSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tslblSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblSearch.Name = "tslblSearch"
        Me.tslblSearch.Size = New System.Drawing.Size(52, 22)
        Me.tslblSearch.Text = "Search :"
        '
        'tscmdPrint
        '
        Me.tscmdPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SOAToolStripMenuItem, Me.DraftSOAToolStripMenuItem, Me.SoftCopySOAToolStripMenuItem})
        Me.tscmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdPrint.Name = "tscmdPrint"
        Me.tscmdPrint.Size = New System.Drawing.Size(45, 22)
        Me.tscmdPrint.Text = "Print"
        '
        'SOAToolStripMenuItem
        '
        Me.SOAToolStripMenuItem.Name = "SOAToolStripMenuItem"
        Me.SOAToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SOAToolStripMenuItem.Text = "S.O.A."
        '
        'DraftSOAToolStripMenuItem
        '
        Me.DraftSOAToolStripMenuItem.Name = "DraftSOAToolStripMenuItem"
        Me.DraftSOAToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.DraftSOAToolStripMenuItem.Text = "Draft S.O.A"
        '
        'SoftCopySOAToolStripMenuItem
        '
        Me.SoftCopySOAToolStripMenuItem.Name = "SoftCopySOAToolStripMenuItem"
        Me.SoftCopySOAToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SoftCopySOAToolStripMenuItem.Text = "Soft Copy S.O.A"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tscmdClose
        '
        Me.tscmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdClose.Name = "tscmdClose"
        Me.tscmdClose.Size = New System.Drawing.Size(40, 22)
        Me.tscmdClose.Text = "Close"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PostBatchToolStripMenuItem, Me.BillingSummaryToolStripMenuItem, Me.UnbilledBookingToolStripMenuItem, Me.BiilingVsReceivablesToolStripMenuItem, Me.UnreceivedBillingSummaryToolStripMenuItem})
        Me.ToolStripDropDownButton2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripDropDownButton2.Text = "Reports"
        '
        'PostBatchToolStripMenuItem
        '
        Me.PostBatchToolStripMenuItem.Name = "PostBatchToolStripMenuItem"
        Me.PostBatchToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.PostBatchToolStripMenuItem.Text = "Post Batch"
        '
        'BillingSummaryToolStripMenuItem
        '
        Me.BillingSummaryToolStripMenuItem.Name = "BillingSummaryToolStripMenuItem"
        Me.BillingSummaryToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.BillingSummaryToolStripMenuItem.Text = "Billing Summary"
        '
        'UnbilledBookingToolStripMenuItem
        '
        Me.UnbilledBookingToolStripMenuItem.Name = "UnbilledBookingToolStripMenuItem"
        Me.UnbilledBookingToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.UnbilledBookingToolStripMenuItem.Text = "Unbilled Booking"
        '
        'BiilingVsReceivablesToolStripMenuItem
        '
        Me.BiilingVsReceivablesToolStripMenuItem.Name = "BiilingVsReceivablesToolStripMenuItem"
        Me.BiilingVsReceivablesToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.BiilingVsReceivablesToolStripMenuItem.Text = "Aging of Receivables - IMPORT"
        '
        'UnreceivedBillingSummaryToolStripMenuItem
        '
        Me.UnreceivedBillingSummaryToolStripMenuItem.Name = "UnreceivedBillingSummaryToolStripMenuItem"
        Me.UnreceivedBillingSummaryToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.UnreceivedBillingSummaryToolStripMenuItem.Text = "Unreceived Billing Summary"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscmdSearch, Me.tstxtSearch, Me.ToolStripDropDownButton1, Me.tslblSearch, Me.tscmdPrint, Me.ToolStripSeparator4, Me.tscmdClose, Me.ToolStripSeparator5, Me.ToolStripDropDownButton2, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1006, 25)
        Me.ToolStrip1.TabIndex = 1184
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frmSOA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 615)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblRefNo)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gpMain)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSOA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "S.O.A Billing - Import BT"
        Me.gpMain.ResumeLayout(False)
        Me.gpMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtgServiceCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contCharges.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dtgAcctgTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dtgOR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        CType(Me.dgUnpostHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gpMain As GroupBox
    Friend WithEvents txtDate As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents dtPrepDate As DateTimePicker
    Friend WithEvents dtReceived As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtRegNo As TextBox
    Friend WithEvents txtForwarder As TextBox
    Friend WithEvents txtWarehouse As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFreightTerms As TextBox
    Friend WithEvents txtBookingNo As TextBox
    Friend WithEvents txtCargoLoad As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents txtPier As TextBox
    Friend WithEvents txtShprAddr As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtETA As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lbl As Label
    Friend WithEvents cboTermsofPayment As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtVessel As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOriginDest As TextBox
    Friend WithEvents txtTransMode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtExrateDollar As TextBox
    Friend WithEvents txtConsignee As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtWgtMeas As TextBox
    Friend WithEvents txtDescOfGoods As TextBox
    Friend WithEvents txtShipper As TextBox
    Friend WithEvents lblTransType As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCISOANo As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslblCurrentUser As ToolStripStatusLabel
    Friend WithEvents tslblPrepBy As ToolStripStatusLabel
    Friend WithEvents tslblPrepDate As ToolStripStatusLabel
    Friend WithEvents tslblStatus1 As ToolStripStatusLabel
    Friend WithEvents tslblStatus2 As ToolStripStatusLabel
    Friend WithEvents tslblStatus3 As ToolStripStatusLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents txtTotalSOA As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtAmtInWords As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtTotalAmtPHP As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cboCurrency As ComboBox
    Friend WithEvents lblRefNo As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dtgServiceCharge As DataGridView
    Friend WithEvents colSSelectCharge As DataGridViewButtonColumn
    Friend WithEvents colSCharges As DataGridViewComboBoxColumn
    Friend WithEvents colSTerms As DataGridViewTextBoxColumn
    Friend WithEvents colORNbr As DataGridViewTextBoxColumn
    Friend WithEvents colSBillAmt As DataGridViewTextBoxColumn
    Friend WithEvents colSBillCurrency As DataGridViewComboBoxColumn
    Friend WithEvents colSBillPHP As DataGridViewTextBoxColumn
    Friend WithEvents colSBillingVAT As DataGridViewCheckBoxColumn
    Friend WithEvents colSBillingVATAmt As DataGridViewTextBoxColumn
    Friend WithEvents colSRemarks As DataGridViewTextBoxColumn
    Friend WithEvents colSDRAcctCode As DataGridViewTextBoxColumn
    Friend WithEvents colSDRSub As DataGridViewTextBoxColumn
    Friend WithEvents colSCRAcctCode As DataGridViewTextBoxColumn
    Friend WithEvents colSCRSub As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents contCharges As Panel
    Friend WithEvents cmdClearSRows As Button
    Friend WithEvents cmdRemoveSRow As Button
    Friend WithEvents cmdAddSRow As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label38 As Label
    Friend WithEvents txtCRTotal As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents txtDRTotal As TextBox
    Friend WithEvents dtgAcctgTitle As DataGridView
    Friend WithEvents colAcctCode As DataGridViewTextBoxColumn
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
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Label40 As Label
    Friend WithEvents dtgOR As DataGridView
    Friend WithEvents colBillingRefNo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents colCheckAmt As DataGridViewTextBoxColumn
    Friend WithEvents colCheckNbr As DataGridViewTextBoxColumn
    Friend WithEvents colCashAmt As DataGridViewTextBoxColumn
    Friend WithEvents colCWT As DataGridViewTextBoxColumn
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents dgUnpostHistory As DataGridView
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents tscmdSearch As ToolStripButton
    Friend WithEvents tstxtSearch As ToolStripTextBox
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents RToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SOANoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CINoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tslblSearch As ToolStripLabel
    Friend WithEvents tscmdPrint As ToolStripDropDownButton
    Friend WithEvents SOAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tscmdClose As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents PostBatchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BillingSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnbilledBookingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BiilingVsReceivablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnreceivedBillingSummaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents txtBilledTo As TextBox
    Friend WithEvents SoftCopySOAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DraftSOAToolStripMenuItem As ToolStripMenuItem
End Class
