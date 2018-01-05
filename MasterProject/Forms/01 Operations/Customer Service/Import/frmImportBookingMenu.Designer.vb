<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportBookingMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportBookingMenu))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBookingNo = New System.Windows.Forms.TextBox()
        Me.txtHouseBL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpShipper = New System.Windows.Forms.GroupBox()
        Me.txtShipper = New System.Windows.Forms.TextBox()
        Me.cmdSelectShipper = New System.Windows.Forms.Button()
        Me.txtShipperAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtConsignee = New System.Windows.Forms.TextBox()
        Me.cmdSelectConsignee = New System.Windows.Forms.Button()
        Me.txtConsigneeAddress = New System.Windows.Forms.TextBox()
        Me.cboShippingLine = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboModeOfTransport = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cboLoadType = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtRegistryNo = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtImportPermitNo = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtVoyage = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboVessel = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboDestination = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboOrigin = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboUnitOfMeasure = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNoOfPackage = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDescriptionOfGoods = New System.Windows.Forms.TextBox()
        Me.cboEntryType = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cboFreightType = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dtATA = New System.Windows.Forms.DateTimePicker()
        Me.dtETA = New System.Windows.Forms.DateTimePicker()
        Me.txtATA = New System.Windows.Forms.TextBox()
        Me.txtETA = New System.Windows.Forms.TextBox()
        Me.txtDestinationCountry = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtOriginCountry = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtgContainer = New System.Windows.Forms.DataGridView()
        Me.colCPK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCContainerID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCContainerSizeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCContainerSizeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCPickUpDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCDeliveryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslblContainerSizes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tscmdContainerAdd = New System.Windows.Forms.ToolStripButton()
        Me.tscmdContainerRemove = New System.Windows.Forms.ToolStripButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dtgDocuments = New System.Windows.Forms.DataGridView()
        Me.colDSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDDocName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDRequired = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtDocsCompletedDate = New System.Windows.Forms.TextBox()
        Me.chkDocsCompleted = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblStatusDetails = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBookingPrefix = New System.Windows.Forms.TextBox()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtForwarder = New System.Windows.Forms.TextBox()
        Me.cmdSelectForwader = New System.Windows.Forms.Button()
        Me.txtForwarderAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtConsignor = New System.Windows.Forms.TextBox()
        Me.cmdSelectConsignor = New System.Windows.Forms.Button()
        Me.txtConsignorAddress = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.dtgServices = New System.Windows.Forms.DataGridView()
        Me.colSSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSPK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSParam_Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSParam_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSPrefix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSParam_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtAccountHolder = New System.Windows.Forms.TextBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblModBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblModDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpShipper.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtgContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtgDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dtgServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Booking No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        '
        'txtBookingNo
        '
        Me.txtBookingNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBookingNo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBookingNo.Location = New System.Drawing.Point(198, 13)
        Me.txtBookingNo.Name = "txtBookingNo"
        Me.txtBookingNo.ReadOnly = True
        Me.txtBookingNo.Size = New System.Drawing.Size(170, 20)
        Me.txtBookingNo.TabIndex = 2
        Me.txtBookingNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHouseBL
        '
        Me.txtHouseBL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHouseBL.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHouseBL.Location = New System.Drawing.Point(120, 32)
        Me.txtHouseBL.Name = "txtHouseBL"
        Me.txtHouseBL.Size = New System.Drawing.Size(248, 20)
        Me.txtHouseBL.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(104, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "House BL"
        '
        'grpShipper
        '
        Me.grpShipper.Controls.Add(Me.txtShipper)
        Me.grpShipper.Controls.Add(Me.cmdSelectShipper)
        Me.grpShipper.Controls.Add(Me.txtShipperAddress)
        Me.grpShipper.Location = New System.Drawing.Point(13, 57)
        Me.grpShipper.Name = "grpShipper"
        Me.grpShipper.Size = New System.Drawing.Size(355, 103)
        Me.grpShipper.TabIndex = 6
        Me.grpShipper.TabStop = False
        Me.grpShipper.Text = "Shipper"
        '
        'txtShipper
        '
        Me.txtShipper.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtShipper.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipper.Location = New System.Drawing.Point(35, 19)
        Me.txtShipper.Name = "txtShipper"
        Me.txtShipper.ReadOnly = True
        Me.txtShipper.Size = New System.Drawing.Size(311, 20)
        Me.txtShipper.TabIndex = 1
        '
        'cmdSelectShipper
        '
        Me.cmdSelectShipper.Image = CType(resources.GetObject("cmdSelectShipper.Image"), System.Drawing.Image)
        Me.cmdSelectShipper.Location = New System.Drawing.Point(6, 19)
        Me.cmdSelectShipper.Name = "cmdSelectShipper"
        Me.cmdSelectShipper.Size = New System.Drawing.Size(27, 24)
        Me.cmdSelectShipper.TabIndex = 0
        Me.cmdSelectShipper.UseVisualStyleBackColor = True
        '
        'txtShipperAddress
        '
        Me.txtShipperAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtShipperAddress.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipperAddress.Location = New System.Drawing.Point(35, 38)
        Me.txtShipperAddress.Multiline = True
        Me.txtShipperAddress.Name = "txtShipperAddress"
        Me.txtShipperAddress.ReadOnly = True
        Me.txtShipperAddress.Size = New System.Drawing.Size(311, 59)
        Me.txtShipperAddress.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtConsignee)
        Me.GroupBox2.Controls.Add(Me.cmdSelectConsignee)
        Me.GroupBox2.Controls.Add(Me.txtConsigneeAddress)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 166)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(355, 103)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Consignee"
        '
        'txtConsignee
        '
        Me.txtConsignee.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtConsignee.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsignee.Location = New System.Drawing.Point(35, 19)
        Me.txtConsignee.Name = "txtConsignee"
        Me.txtConsignee.ReadOnly = True
        Me.txtConsignee.Size = New System.Drawing.Size(311, 20)
        Me.txtConsignee.TabIndex = 1
        '
        'cmdSelectConsignee
        '
        Me.cmdSelectConsignee.Image = CType(resources.GetObject("cmdSelectConsignee.Image"), System.Drawing.Image)
        Me.cmdSelectConsignee.Location = New System.Drawing.Point(6, 19)
        Me.cmdSelectConsignee.Name = "cmdSelectConsignee"
        Me.cmdSelectConsignee.Size = New System.Drawing.Size(27, 24)
        Me.cmdSelectConsignee.TabIndex = 0
        Me.cmdSelectConsignee.UseVisualStyleBackColor = True
        '
        'txtConsigneeAddress
        '
        Me.txtConsigneeAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtConsigneeAddress.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsigneeAddress.Location = New System.Drawing.Point(35, 38)
        Me.txtConsigneeAddress.Multiline = True
        Me.txtConsigneeAddress.Name = "txtConsigneeAddress"
        Me.txtConsigneeAddress.ReadOnly = True
        Me.txtConsigneeAddress.Size = New System.Drawing.Size(311, 59)
        Me.txtConsigneeAddress.TabIndex = 2
        '
        'cboShippingLine
        '
        Me.cboShippingLine.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShippingLine.FormattingEnabled = True
        Me.cboShippingLine.IntegralHeight = False
        Me.cboShippingLine.Location = New System.Drawing.Point(116, 13)
        Me.cboShippingLine.Name = "cboShippingLine"
        Me.cboShippingLine.Size = New System.Drawing.Size(208, 23)
        Me.cboShippingLine.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(100, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Shipping Line"
        '
        'cboModeOfTransport
        '
        Me.cboModeOfTransport.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModeOfTransport.FormattingEnabled = True
        Me.cboModeOfTransport.IntegralHeight = False
        Me.cboModeOfTransport.Location = New System.Drawing.Point(116, 35)
        Me.cboModeOfTransport.Name = "cboModeOfTransport"
        Me.cboModeOfTransport.Size = New System.Drawing.Size(208, 23)
        Me.cboModeOfTransport.TabIndex = 5
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(100, 38)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(10, 13)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = ":"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 38)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(96, 13)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Mode Of Transport"
        '
        'cboLoadType
        '
        Me.cboLoadType.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoadType.FormattingEnabled = True
        Me.cboLoadType.IntegralHeight = False
        Me.cboLoadType.Location = New System.Drawing.Point(116, 57)
        Me.cboLoadType.Name = "cboLoadType"
        Me.cboLoadType.Size = New System.Drawing.Size(208, 23)
        Me.cboLoadType.TabIndex = 8
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(100, 60)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(10, 13)
        Me.Label37.TabIndex = 7
        Me.Label37.Text = ":"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(6, 60)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(58, 13)
        Me.Label38.TabIndex = 6
        Me.Label38.Text = "Load Type"
        '
        'txtRegistryNo
        '
        Me.txtRegistryNo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegistryNo.Location = New System.Drawing.Point(116, 357)
        Me.txtRegistryNo.Name = "txtRegistryNo"
        Me.txtRegistryNo.Size = New System.Drawing.Size(208, 20)
        Me.txtRegistryNo.TabIndex = 55
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(100, 360)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(10, 13)
        Me.Label33.TabIndex = 54
        Me.Label33.Text = ":"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 360)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 13)
        Me.Label34.TabIndex = 53
        Me.Label34.Text = "Registry No."
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Location = New System.Drawing.Point(116, 338)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(208, 20)
        Me.txtInvoiceNo.TabIndex = 52
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(100, 341)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(10, 13)
        Me.Label31.TabIndex = 51
        Me.Label31.Text = ":"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 341)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(62, 13)
        Me.Label32.TabIndex = 50
        Me.Label32.Text = "Invoice No."
        '
        'txtImportPermitNo
        '
        Me.txtImportPermitNo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportPermitNo.Location = New System.Drawing.Point(116, 319)
        Me.txtImportPermitNo.Name = "txtImportPermitNo"
        Me.txtImportPermitNo.Size = New System.Drawing.Size(208, 20)
        Me.txtImportPermitNo.TabIndex = 49
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(100, 322)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(10, 13)
        Me.Label29.TabIndex = 48
        Me.Label29.Text = ":"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 322)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(88, 13)
        Me.Label30.TabIndex = 47
        Me.Label30.Text = "Import Permit No."
        '
        'txtVoyage
        '
        Me.txtVoyage.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoyage.Location = New System.Drawing.Point(116, 300)
        Me.txtVoyage.Name = "txtVoyage"
        Me.txtVoyage.Size = New System.Drawing.Size(208, 20)
        Me.txtVoyage.TabIndex = 46
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(100, 303)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(10, 13)
        Me.Label27.TabIndex = 45
        Me.Label27.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 303)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(43, 13)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "Voyage"
        '
        'cboVessel
        '
        Me.cboVessel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.IntegralHeight = False
        Me.cboVessel.Location = New System.Drawing.Point(116, 278)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(208, 23)
        Me.cboVessel.TabIndex = 43
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(100, 282)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(10, 13)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = ":"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 282)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 13)
        Me.Label26.TabIndex = 41
        Me.Label26.Text = "Vessel"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(100, 262)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 13)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 262)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = "ATA"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(100, 243)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 13)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 243)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(28, 13)
        Me.Label22.TabIndex = 33
        Me.Label22.Text = "ETA"
        '
        'cboDestination
        '
        Me.cboDestination.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDestination.FormattingEnabled = True
        Me.cboDestination.IntegralHeight = False
        Me.cboDestination.Location = New System.Drawing.Point(116, 199)
        Me.cboDestination.Name = "cboDestination"
        Me.cboDestination.Size = New System.Drawing.Size(208, 23)
        Me.cboDestination.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(100, 203)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 13)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 203)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 13)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Destination"
        '
        'cboOrigin
        '
        Me.cboOrigin.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrigin.FormattingEnabled = True
        Me.cboOrigin.IntegralHeight = False
        Me.cboOrigin.Location = New System.Drawing.Point(116, 158)
        Me.cboOrigin.Name = "cboOrigin"
        Me.cboOrigin.Size = New System.Drawing.Size(208, 23)
        Me.cboOrigin.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(100, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = ":"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 162)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Origin"
        '
        'cboUnitOfMeasure
        '
        Me.cboUnitOfMeasure.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnitOfMeasure.FormattingEnabled = True
        Me.cboUnitOfMeasure.IntegralHeight = False
        Me.cboUnitOfMeasure.Location = New System.Drawing.Point(116, 136)
        Me.cboUnitOfMeasure.Name = "cboUnitOfMeasure"
        Me.cboUnitOfMeasure.Size = New System.Drawing.Size(208, 23)
        Me.cboUnitOfMeasure.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(100, 139)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 139)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 13)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Unit Of Measure"
        '
        'txtNoOfPackage
        '
        Me.txtNoOfPackage.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfPackage.Location = New System.Drawing.Point(116, 117)
        Me.txtNoOfPackage.Name = "txtNoOfPackage"
        Me.txtNoOfPackage.Size = New System.Drawing.Size(208, 20)
        Me.txtNoOfPackage.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(100, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 121)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "No. Of Package"
        '
        'txtVolume
        '
        Me.txtVolume.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVolume.Location = New System.Drawing.Point(116, 98)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(208, 20)
        Me.txtVolume.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(100, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = ":"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Volume"
        '
        'txtWeight
        '
        Me.txtWeight.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(116, 79)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(208, 20)
        Me.txtWeight.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(100, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Weight"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDescriptionOfGoods)
        Me.GroupBox1.Location = New System.Drawing.Point(385, 237)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 96)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Description Of Goods"
        '
        'txtDescriptionOfGoods
        '
        Me.txtDescriptionOfGoods.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescriptionOfGoods.Location = New System.Drawing.Point(6, 19)
        Me.txtDescriptionOfGoods.Multiline = True
        Me.txtDescriptionOfGoods.Name = "txtDescriptionOfGoods"
        Me.txtDescriptionOfGoods.Size = New System.Drawing.Size(309, 71)
        Me.txtDescriptionOfGoods.TabIndex = 0
        '
        'cboEntryType
        '
        Me.cboEntryType.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntryType.FormattingEnabled = True
        Me.cboEntryType.IntegralHeight = False
        Me.cboEntryType.Location = New System.Drawing.Point(116, 376)
        Me.cboEntryType.Name = "cboEntryType"
        Me.cboEntryType.Size = New System.Drawing.Size(208, 23)
        Me.cboEntryType.TabIndex = 58
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(100, 380)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(10, 13)
        Me.Label39.TabIndex = 57
        Me.Label39.Text = ":"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(6, 380)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(58, 13)
        Me.Label40.TabIndex = 56
        Me.Label40.Text = "Entry Type"
        '
        'cboFreightType
        '
        Me.cboFreightType.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFreightType.FormattingEnabled = True
        Me.cboFreightType.IntegralHeight = False
        Me.cboFreightType.Location = New System.Drawing.Point(116, 398)
        Me.cboFreightType.Name = "cboFreightType"
        Me.cboFreightType.Size = New System.Drawing.Size(208, 23)
        Me.cboFreightType.TabIndex = 61
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(100, 402)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(10, 13)
        Me.Label41.TabIndex = 60
        Me.Label41.Text = ":"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 402)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(66, 13)
        Me.Label42.TabIndex = 59
        Me.Label42.Text = "Freight Type"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(728, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(340, 494)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.AutoScroll = True
        Me.TabPage3.Controls.Add(Me.cboShippingLine)
        Me.TabPage3.Controls.Add(Me.cboLoadType)
        Me.TabPage3.Controls.Add(Me.Label37)
        Me.TabPage3.Controls.Add(Me.Label38)
        Me.TabPage3.Controls.Add(Me.cboModeOfTransport)
        Me.TabPage3.Controls.Add(Me.Label35)
        Me.TabPage3.Controls.Add(Me.Label36)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.txtWeight)
        Me.TabPage3.Controls.Add(Me.txtVolume)
        Me.TabPage3.Controls.Add(Me.dtATA)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.dtETA)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.txtATA)
        Me.TabPage3.Controls.Add(Me.cboFreightType)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.txtETA)
        Me.TabPage3.Controls.Add(Me.Label41)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.txtDestinationCountry)
        Me.TabPage3.Controls.Add(Me.Label42)
        Me.TabPage3.Controls.Add(Me.txtNoOfPackage)
        Me.TabPage3.Controls.Add(Me.Label45)
        Me.TabPage3.Controls.Add(Me.cboEntryType)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Label46)
        Me.TabPage3.Controls.Add(Me.Label39)
        Me.TabPage3.Controls.Add(Me.cboOrigin)
        Me.TabPage3.Controls.Add(Me.txtOriginCountry)
        Me.TabPage3.Controls.Add(Me.Label40)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label43)
        Me.TabPage3.Controls.Add(Me.txtRegistryNo)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.Label44)
        Me.TabPage3.Controls.Add(Me.Label33)
        Me.TabPage3.Controls.Add(Me.cboUnitOfMeasure)
        Me.TabPage3.Controls.Add(Me.Label34)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.txtInvoiceNo)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label31)
        Me.TabPage3.Controls.Add(Me.cboDestination)
        Me.TabPage3.Controls.Add(Me.Label32)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.txtImportPermitNo)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label30)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.txtVoyage)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.Label28)
        Me.TabPage3.Controls.Add(Me.cboVessel)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(332, 468)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Shipping Details"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dtATA
        '
        Me.dtATA.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtATA.Location = New System.Drawing.Point(306, 259)
        Me.dtATA.Name = "dtATA"
        Me.dtATA.Size = New System.Drawing.Size(18, 20)
        Me.dtATA.TabIndex = 40
        '
        'dtETA
        '
        Me.dtETA.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtETA.Location = New System.Drawing.Point(306, 240)
        Me.dtETA.Name = "dtETA"
        Me.dtETA.Size = New System.Drawing.Size(18, 20)
        Me.dtETA.TabIndex = 36
        '
        'txtATA
        '
        Me.txtATA.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtATA.Location = New System.Drawing.Point(116, 259)
        Me.txtATA.Name = "txtATA"
        Me.txtATA.Size = New System.Drawing.Size(191, 20)
        Me.txtATA.TabIndex = 39
        '
        'txtETA
        '
        Me.txtETA.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtETA.Location = New System.Drawing.Point(116, 240)
        Me.txtETA.Name = "txtETA"
        Me.txtETA.Size = New System.Drawing.Size(191, 20)
        Me.txtETA.TabIndex = 35
        '
        'txtDestinationCountry
        '
        Me.txtDestinationCountry.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDestinationCountry.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestinationCountry.Location = New System.Drawing.Point(116, 221)
        Me.txtDestinationCountry.Name = "txtDestinationCountry"
        Me.txtDestinationCountry.ReadOnly = True
        Me.txtDestinationCountry.Size = New System.Drawing.Size(208, 20)
        Me.txtDestinationCountry.TabIndex = 32
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(100, 224)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(10, 13)
        Me.Label45.TabIndex = 31
        Me.Label45.Text = ":"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(6, 224)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(43, 13)
        Me.Label46.TabIndex = 30
        Me.Label46.Text = "Country"
        '
        'txtOriginCountry
        '
        Me.txtOriginCountry.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtOriginCountry.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginCountry.Location = New System.Drawing.Point(116, 180)
        Me.txtOriginCountry.Name = "txtOriginCountry"
        Me.txtOriginCountry.ReadOnly = True
        Me.txtOriginCountry.Size = New System.Drawing.Size(208, 20)
        Me.txtOriginCountry.TabIndex = 26
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(100, 183)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(10, 13)
        Me.Label43.TabIndex = 25
        Me.Label43.Text = ":"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(6, 183)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(43, 13)
        Me.Label44.TabIndex = 24
        Me.Label44.Text = "Country"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtgContainer)
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Controls.Add(Me.ToolStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(332, 468)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Containers"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtgContainer
        '
        Me.dtgContainer.AllowUserToAddRows = False
        Me.dtgContainer.AllowUserToDeleteRows = False
        Me.dtgContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgContainer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCPK, Me.colCContainerID, Me.colCContainerNo, Me.colCContainerSizeID, Me.colCContainerSizeName, Me.colCPickUpDate, Me.colCDeliveryDate})
        Me.dtgContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgContainer.Location = New System.Drawing.Point(3, 28)
        Me.dtgContainer.Name = "dtgContainer"
        Me.dtgContainer.ReadOnly = True
        Me.dtgContainer.Size = New System.Drawing.Size(326, 415)
        Me.dtgContainer.TabIndex = 1
        '
        'colCPK
        '
        Me.colCPK.HeaderText = "PK"
        Me.colCPK.Name = "colCPK"
        Me.colCPK.ReadOnly = True
        Me.colCPK.Visible = False
        '
        'colCContainerID
        '
        Me.colCContainerID.HeaderText = "Container ID"
        Me.colCContainerID.Name = "colCContainerID"
        Me.colCContainerID.ReadOnly = True
        Me.colCContainerID.Visible = False
        '
        'colCContainerNo
        '
        Me.colCContainerNo.HeaderText = "Container No"
        Me.colCContainerNo.Name = "colCContainerNo"
        Me.colCContainerNo.ReadOnly = True
        Me.colCContainerNo.Width = 150
        '
        'colCContainerSizeID
        '
        Me.colCContainerSizeID.HeaderText = "Container Size ID"
        Me.colCContainerSizeID.Name = "colCContainerSizeID"
        Me.colCContainerSizeID.ReadOnly = True
        Me.colCContainerSizeID.Visible = False
        '
        'colCContainerSizeName
        '
        Me.colCContainerSizeName.HeaderText = "Container Size"
        Me.colCContainerSizeName.Name = "colCContainerSizeName"
        Me.colCContainerSizeName.ReadOnly = True
        '
        'colCPickUpDate
        '
        Me.colCPickUpDate.HeaderText = "Pickup Date"
        Me.colCPickUpDate.Name = "colCPickUpDate"
        Me.colCPickUpDate.ReadOnly = True
        Me.colCPickUpDate.Width = 125
        '
        'colCDeliveryDate
        '
        Me.colCDeliveryDate.HeaderText = "Delivery Date"
        Me.colCDeliveryDate.Name = "colCDeliveryDate"
        Me.colCDeliveryDate.ReadOnly = True
        Me.colCDeliveryDate.Width = 125
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblContainerSizes})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 443)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(326, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslblContainerSizes
        '
        Me.tslblContainerSizes.Name = "tslblContainerSizes"
        Me.tslblContainerSizes.Size = New System.Drawing.Size(87, 17)
        Me.tslblContainerSizes.Text = "Container Sizes"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscmdContainerAdd, Me.tscmdContainerRemove})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(326, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tscmdContainerAdd
        '
        Me.tscmdContainerAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscmdContainerAdd.Image = CType(resources.GetObject("tscmdContainerAdd.Image"), System.Drawing.Image)
        Me.tscmdContainerAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdContainerAdd.Name = "tscmdContainerAdd"
        Me.tscmdContainerAdd.Size = New System.Drawing.Size(23, 22)
        Me.tscmdContainerAdd.Text = "Add Container"
        '
        'tscmdContainerRemove
        '
        Me.tscmdContainerRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscmdContainerRemove.Image = CType(resources.GetObject("tscmdContainerRemove.Image"), System.Drawing.Image)
        Me.tscmdContainerRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdContainerRemove.Name = "tscmdContainerRemove"
        Me.tscmdContainerRemove.Size = New System.Drawing.Size(23, 22)
        Me.tscmdContainerRemove.Text = "Remove Container"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtgDocuments)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(332, 468)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Documents"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtgDocuments
        '
        Me.dtgDocuments.AllowUserToAddRows = False
        Me.dtgDocuments.AllowUserToDeleteRows = False
        Me.dtgDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDocuments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDSelected, Me.colDDocID, Me.colDDocName, Me.colDRequired})
        Me.dtgDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgDocuments.Location = New System.Drawing.Point(3, 3)
        Me.dtgDocuments.Name = "dtgDocuments"
        Me.dtgDocuments.Size = New System.Drawing.Size(326, 388)
        Me.dtgDocuments.TabIndex = 2
        '
        'colDSelected
        '
        Me.colDSelected.HeaderText = ""
        Me.colDSelected.Name = "colDSelected"
        Me.colDSelected.Width = 25
        '
        'colDDocID
        '
        Me.colDDocID.HeaderText = "DocumentID"
        Me.colDDocID.Name = "colDDocID"
        Me.colDDocID.ReadOnly = True
        Me.colDDocID.Visible = False
        '
        'colDDocName
        '
        Me.colDDocName.HeaderText = "Document Name"
        Me.colDDocName.Name = "colDDocName"
        Me.colDDocName.ReadOnly = True
        Me.colDDocName.Width = 250
        '
        'colDRequired
        '
        Me.colDRequired.HeaderText = "Required"
        Me.colDRequired.Name = "colDRequired"
        Me.colDRequired.ReadOnly = True
        Me.colDRequired.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDRequired.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDRequired.Width = 75
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox6)
        Me.Panel2.Controls.Add(Me.chkDocsCompleted)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 391)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(326, 74)
        Me.Panel2.TabIndex = 3
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtDocsCompletedDate)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox6.Location = New System.Drawing.Point(0, 23)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(326, 51)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Docs Completed Date"
        '
        'txtDocsCompletedDate
        '
        Me.txtDocsCompletedDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDocsCompletedDate.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocsCompletedDate.Location = New System.Drawing.Point(6, 19)
        Me.txtDocsCompletedDate.Name = "txtDocsCompletedDate"
        Me.txtDocsCompletedDate.ReadOnly = True
        Me.txtDocsCompletedDate.Size = New System.Drawing.Size(314, 20)
        Me.txtDocsCompletedDate.TabIndex = 19
        '
        'chkDocsCompleted
        '
        Me.chkDocsCompleted.AutoCheck = False
        Me.chkDocsCompleted.AutoSize = True
        Me.chkDocsCompleted.Location = New System.Drawing.Point(6, 3)
        Me.chkDocsCompleted.Name = "chkDocsCompleted"
        Me.chkDocsCompleted.Size = New System.Drawing.Size(104, 17)
        Me.chkDocsCompleted.TabIndex = 0
        Me.chkDocsCompleted.Text = "Docs Completed"
        Me.chkDocsCompleted.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtRemarks)
        Me.GroupBox4.Location = New System.Drawing.Point(385, 339)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(321, 96)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(6, 19)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(309, 71)
        Me.txtRemarks.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.lblStatusDetails)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtBookingPrefix)
        Me.Panel1.Controls.Add(Me.txtSite)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Label51)
        Me.Panel1.Controls.Add(Me.Label52)
        Me.Panel1.Controls.Add(Me.dtgServices)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.Label49)
        Me.Panel1.Controls.Add(Me.Label50)
        Me.Panel1.Controls.Add(Me.Label47)
        Me.Panel1.Controls.Add(Me.Label48)
        Me.Panel1.Controls.Add(Me.txtAccountHolder)
        Me.Panel1.Controls.Add(Me.txtBookingNo)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtHouseBL)
        Me.Panel1.Controls.Add(Me.grpShipper)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(723, 494)
        Me.Panel1.TabIndex = 0
        '
        'lblStatusDetails
        '
        Me.lblStatusDetails.AutoSize = True
        Me.lblStatusDetails.Location = New System.Drawing.Point(686, 470)
        Me.lblStatusDetails.Name = "lblStatusDetails"
        Me.lblStatusDetails.Size = New System.Drawing.Size(16, 13)
        Me.lblStatusDetails.TabIndex = 25
        Me.lblStatusDetails.Text = "..."
        Me.ToolTip1.SetToolTip(Me.lblStatusDetails, "Status Details")
        Me.lblStatusDetails.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(185, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 16)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "-"
        '
        'txtBookingPrefix
        '
        Me.txtBookingPrefix.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBookingPrefix.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBookingPrefix.Location = New System.Drawing.Point(120, 13)
        Me.txtBookingPrefix.Name = "txtBookingPrefix"
        Me.txtBookingPrefix.ReadOnly = True
        Me.txtBookingPrefix.Size = New System.Drawing.Size(63, 20)
        Me.txtBookingPrefix.TabIndex = 23
        Me.txtBookingPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSite
        '
        Me.txtSite.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSite.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(492, 12)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(214, 20)
        Me.txtSite.TabIndex = 22
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtForwarder)
        Me.GroupBox5.Controls.Add(Me.cmdSelectForwader)
        Me.GroupBox5.Controls.Add(Me.txtForwarderAddress)
        Me.GroupBox5.Location = New System.Drawing.Point(13, 384)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(355, 103)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Forwarder"
        '
        'txtForwarder
        '
        Me.txtForwarder.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtForwarder.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForwarder.Location = New System.Drawing.Point(35, 19)
        Me.txtForwarder.Name = "txtForwarder"
        Me.txtForwarder.ReadOnly = True
        Me.txtForwarder.Size = New System.Drawing.Size(311, 20)
        Me.txtForwarder.TabIndex = 1
        '
        'cmdSelectForwader
        '
        Me.cmdSelectForwader.Image = CType(resources.GetObject("cmdSelectForwader.Image"), System.Drawing.Image)
        Me.cmdSelectForwader.Location = New System.Drawing.Point(6, 19)
        Me.cmdSelectForwader.Name = "cmdSelectForwader"
        Me.cmdSelectForwader.Size = New System.Drawing.Size(27, 24)
        Me.cmdSelectForwader.TabIndex = 0
        Me.cmdSelectForwader.UseVisualStyleBackColor = True
        '
        'txtForwarderAddress
        '
        Me.txtForwarderAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtForwarderAddress.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForwarderAddress.Location = New System.Drawing.Point(35, 38)
        Me.txtForwarderAddress.Multiline = True
        Me.txtForwarderAddress.Name = "txtForwarderAddress"
        Me.txtForwarderAddress.ReadOnly = True
        Me.txtForwarderAddress.Size = New System.Drawing.Size(311, 59)
        Me.txtForwarderAddress.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtConsignor)
        Me.GroupBox3.Controls.Add(Me.cmdSelectConsignor)
        Me.GroupBox3.Controls.Add(Me.txtConsignorAddress)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 275)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(355, 103)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consignor/Debtor"
        '
        'txtConsignor
        '
        Me.txtConsignor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtConsignor.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsignor.Location = New System.Drawing.Point(35, 19)
        Me.txtConsignor.Name = "txtConsignor"
        Me.txtConsignor.ReadOnly = True
        Me.txtConsignor.Size = New System.Drawing.Size(311, 20)
        Me.txtConsignor.TabIndex = 1
        '
        'cmdSelectConsignor
        '
        Me.cmdSelectConsignor.Image = CType(resources.GetObject("cmdSelectConsignor.Image"), System.Drawing.Image)
        Me.cmdSelectConsignor.Location = New System.Drawing.Point(6, 19)
        Me.cmdSelectConsignor.Name = "cmdSelectConsignor"
        Me.cmdSelectConsignor.Size = New System.Drawing.Size(27, 24)
        Me.cmdSelectConsignor.TabIndex = 0
        Me.cmdSelectConsignor.UseVisualStyleBackColor = True
        '
        'txtConsignorAddress
        '
        Me.txtConsignorAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtConsignorAddress.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsignorAddress.Location = New System.Drawing.Point(35, 38)
        Me.txtConsignorAddress.Multiline = True
        Me.txtConsignorAddress.Name = "txtConsignorAddress"
        Me.txtConsignorAddress.ReadOnly = True
        Me.txtConsignorAddress.Size = New System.Drawing.Size(311, 59)
        Me.txtConsignorAddress.TabIndex = 2
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(382, 16)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(25, 13)
        Me.Label51.TabIndex = 13
        Me.Label51.Text = "Site"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(476, 16)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(10, 13)
        Me.Label52.TabIndex = 14
        Me.Label52.Text = ":"
        '
        'dtgServices
        '
        Me.dtgServices.AllowUserToAddRows = False
        Me.dtgServices.AllowUserToDeleteRows = False
        Me.dtgServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSSelected, Me.colSPK, Me.colSParam_Type, Me.colSParam_Code, Me.colSPrefix, Me.colSParam_Desc})
        Me.dtgServices.Location = New System.Drawing.Point(385, 38)
        Me.dtgServices.Name = "dtgServices"
        Me.dtgServices.Size = New System.Drawing.Size(321, 193)
        Me.dtgServices.TabIndex = 10
        '
        'colSSelected
        '
        Me.colSSelected.HeaderText = ""
        Me.colSSelected.Name = "colSSelected"
        Me.colSSelected.Width = 25
        '
        'colSPK
        '
        Me.colSPK.HeaderText = "PK"
        Me.colSPK.Name = "colSPK"
        Me.colSPK.ReadOnly = True
        Me.colSPK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSPK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSPK.Visible = False
        '
        'colSParam_Type
        '
        Me.colSParam_Type.HeaderText = "Param_Type"
        Me.colSParam_Type.Name = "colSParam_Type"
        Me.colSParam_Type.ReadOnly = True
        Me.colSParam_Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSParam_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSParam_Type.Visible = False
        '
        'colSParam_Code
        '
        Me.colSParam_Code.HeaderText = "Param_Code"
        Me.colSParam_Code.Name = "colSParam_Code"
        Me.colSParam_Code.ReadOnly = True
        Me.colSParam_Code.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSParam_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSParam_Code.Visible = False
        '
        'colSPrefix
        '
        Me.colSPrefix.HeaderText = "Prefix"
        Me.colSPrefix.Name = "colSPrefix"
        Me.colSPrefix.ReadOnly = True
        Me.colSPrefix.Visible = False
        '
        'colSParam_Desc
        '
        Me.colSParam_Desc.HeaderText = "Services"
        Me.colSParam_Desc.Name = "colSParam_Desc"
        Me.colSParam_Desc.ReadOnly = True
        Me.colSParam_Desc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSParam_Desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSParam_Desc.Width = 225
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(492, 467)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(214, 20)
        Me.txtStatus.TabIndex = 21
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(476, 470)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(10, 13)
        Me.Label49.TabIndex = 20
        Me.Label49.Text = ":"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(382, 470)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(37, 13)
        Me.Label50.TabIndex = 19
        Me.Label50.Text = "Status"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(382, 444)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(81, 13)
        Me.Label47.TabIndex = 16
        Me.Label47.Text = "Account Holder"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(476, 444)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(10, 13)
        Me.Label48.TabIndex = 17
        Me.Label48.Text = ":"
        '
        'txtAccountHolder
        '
        Me.txtAccountHolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAccountHolder.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountHolder.Location = New System.Drawing.Point(492, 441)
        Me.txtAccountHolder.Name = "txtAccountHolder"
        Me.txtAccountHolder.ReadOnly = True
        Me.txtAccountHolder.Size = New System.Drawing.Size(214, 20)
        Me.txtAccountHolder.TabIndex = 18
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Location = New System.Drawing.Point(723, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(5, 494)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslblPrepBy, Me.ToolStripStatusLabel3, Me.tslblPrepDate, Me.ToolStripStatusLabel2, Me.tslblModBy, Me.ToolStripStatusLabel5, Me.tslblModDate})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 494)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(1068, 22)
        Me.StatusStrip2.TabIndex = 2
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(73, 17)
        Me.ToolStripStatusLabel1.Text = "Prepared By:"
        '
        'tslblPrepBy
        '
        Me.tslblPrepBy.AutoSize = False
        Me.tslblPrepBy.Name = "tslblPrepBy"
        Me.tslblPrepBy.Size = New System.Drawing.Size(120, 17)
        Me.tslblPrepBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(84, 17)
        Me.ToolStripStatusLabel3.Text = "Prepared Date:"
        '
        'tslblPrepDate
        '
        Me.tslblPrepDate.AutoSize = False
        Me.tslblPrepDate.Name = "tslblPrepDate"
        Me.tslblPrepDate.Size = New System.Drawing.Size(150, 17)
        Me.tslblPrepDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel2.Text = "Modified By:"
        '
        'tslblModBy
        '
        Me.tslblModBy.AutoSize = False
        Me.tslblModBy.Name = "tslblModBy"
        Me.tslblModBy.Size = New System.Drawing.Size(120, 17)
        Me.tslblModBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(85, 17)
        Me.ToolStripStatusLabel5.Text = "Modified Date:"
        '
        'tslblModDate
        '
        Me.tslblModDate.AutoSize = False
        Me.tslblModDate.Name = "tslblModDate"
        Me.tslblModDate.Size = New System.Drawing.Size(150, 17)
        Me.tslblModDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmImportBookingMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 516)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Name = "frmImportBookingMenu"
        Me.Text = "Import  Booking Menu"
        Me.grpShipper.ResumeLayout(False)
        Me.grpShipper.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dtgContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dtgDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dtgServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBookingNo As TextBox
    Friend WithEvents txtHouseBL As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents grpShipper As GroupBox
    Friend WithEvents txtShipperAddress As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtConsigneeAddress As TextBox
    Friend WithEvents cboShippingLine As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboModeOfTransport As ComboBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents cboLoadType As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents txtRegistryNo As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents txtImportPermitNo As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtVoyage As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents cboVessel As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents cboDestination As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cboOrigin As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents cboUnitOfMeasure As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtNoOfPackage As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtVolume As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtWeight As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDescriptionOfGoods As TextBox
    Friend WithEvents cboEntryType As ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents cboFreightType As ComboBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tscmdContainerAdd As ToolStripButton
    Friend WithEvents tscmdContainerRemove As ToolStripButton
    Friend WithEvents dtgContainer As DataGridView
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslblContainerSizes As ToolStripStatusLabel
    Friend WithEvents dtgDocuments As DataGridView
    Friend WithEvents txtDestinationCountry As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents txtOriginCountry As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents txtATA As TextBox
    Friend WithEvents txtETA As TextBox
    Friend WithEvents dtATA As DateTimePicker
    Friend WithEvents dtETA As DateTimePicker
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tslblPrepBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents tslblPrepDate As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tslblModBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents tslblModDate As ToolStripStatusLabel
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents txtAccountHolder As TextBox
    Friend WithEvents dtgServices As DataGridView
    Friend WithEvents colCPK As DataGridViewTextBoxColumn
    Friend WithEvents colCContainerID As DataGridViewTextBoxColumn
    Friend WithEvents colCContainerNo As DataGridViewTextBoxColumn
    Friend WithEvents colCContainerSizeID As DataGridViewTextBoxColumn
    Friend WithEvents colCContainerSizeName As DataGridViewTextBoxColumn
    Friend WithEvents colCPickUpDate As DataGridViewTextBoxColumn
    Friend WithEvents colCDeliveryDate As DataGridViewTextBoxColumn
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents cmdSelectShipper As Button
    Friend WithEvents txtShipper As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtConsignee As TextBox
    Friend WithEvents cmdSelectConsignee As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtConsignor As TextBox
    Friend WithEvents cmdSelectConsignor As Button
    Friend WithEvents txtConsignorAddress As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtForwarder As TextBox
    Friend WithEvents cmdSelectForwader As Button
    Friend WithEvents txtForwarderAddress As TextBox
    Friend WithEvents txtSite As TextBox
    Friend WithEvents colSSelected As DataGridViewCheckBoxColumn
    Friend WithEvents colSPK As DataGridViewTextBoxColumn
    Friend WithEvents colSParam_Type As DataGridViewTextBoxColumn
    Friend WithEvents colSParam_Code As DataGridViewTextBoxColumn
    Friend WithEvents colSPrefix As DataGridViewTextBoxColumn
    Friend WithEvents colSParam_Desc As DataGridViewTextBoxColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBookingPrefix As TextBox
    Friend WithEvents colDSelected As DataGridViewCheckBoxColumn
    Friend WithEvents colDDocID As DataGridViewTextBoxColumn
    Friend WithEvents colDDocName As DataGridViewTextBoxColumn
    Friend WithEvents colDRequired As DataGridViewCheckBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkDocsCompleted As CheckBox
    Friend WithEvents lblStatusDetails As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtDocsCompletedDate As TextBox
End Class
