<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportMasterBooking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportMasterBooking))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cboLoadType = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cboModeOfTransport = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cboAirLine = New System.Windows.Forms.ComboBox()
        Me.lblStatusDetails = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.dtATA = New System.Windows.Forms.DateTimePicker()
        Me.txtATA = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.dtETA = New System.Windows.Forms.DateTimePicker()
        Me.txtETA = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtLCT = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboVessel = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtChassisDepot = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEmptyPositioning = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSealNo = New System.Windows.Forms.TextBox()
        Me.dtATD = New System.Windows.Forms.DateTimePicker()
        Me.txtATD = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtETD = New System.Windows.Forms.DateTimePicker()
        Me.txtETD = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboWarehouse = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtContainerYard = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLoadedPullOut = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtOriginCountry = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cboOriginPort = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDestinationPort = New System.Windows.Forms.ComboBox()
        Me.cboDestinationCountry = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboCarrier = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblModBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblModDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tscmdAdd = New System.Windows.Forms.ToolStripButton()
        Me.tscmdRemove = New System.Windows.Forms.ToolStripButton()
        Me.dtgBookingDetails = New System.Windows.Forms.DataGridView()
        Me.pnlHeader.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgBookingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.AutoScroll = True
        Me.pnlHeader.Controls.Add(Me.Label41)
        Me.pnlHeader.Controls.Add(Me.Label42)
        Me.pnlHeader.Controls.Add(Me.cboLoadType)
        Me.pnlHeader.Controls.Add(Me.Label39)
        Me.pnlHeader.Controls.Add(Me.Label40)
        Me.pnlHeader.Controls.Add(Me.cboModeOfTransport)
        Me.pnlHeader.Controls.Add(Me.Label37)
        Me.pnlHeader.Controls.Add(Me.Label38)
        Me.pnlHeader.Controls.Add(Me.cboAirLine)
        Me.pnlHeader.Controls.Add(Me.lblStatusDetails)
        Me.pnlHeader.Controls.Add(Me.txtStatus)
        Me.pnlHeader.Controls.Add(Me.Label49)
        Me.pnlHeader.Controls.Add(Me.Label50)
        Me.pnlHeader.Controls.Add(Me.dtATA)
        Me.pnlHeader.Controls.Add(Me.txtATA)
        Me.pnlHeader.Controls.Add(Me.Label33)
        Me.pnlHeader.Controls.Add(Me.Label34)
        Me.pnlHeader.Controls.Add(Me.dtETA)
        Me.pnlHeader.Controls.Add(Me.txtETA)
        Me.pnlHeader.Controls.Add(Me.Label35)
        Me.pnlHeader.Controls.Add(Me.Label36)
        Me.pnlHeader.Controls.Add(Me.Label25)
        Me.pnlHeader.Controls.Add(Me.Label26)
        Me.pnlHeader.Controls.Add(Me.txtLCT)
        Me.pnlHeader.Controls.Add(Me.Label23)
        Me.pnlHeader.Controls.Add(Me.Label24)
        Me.pnlHeader.Controls.Add(Me.cboVessel)
        Me.pnlHeader.Controls.Add(Me.Label17)
        Me.pnlHeader.Controls.Add(Me.Label18)
        Me.pnlHeader.Controls.Add(Me.txtChassisDepot)
        Me.pnlHeader.Controls.Add(Me.Label15)
        Me.pnlHeader.Controls.Add(Me.Label16)
        Me.pnlHeader.Controls.Add(Me.txtEmptyPositioning)
        Me.pnlHeader.Controls.Add(Me.Label13)
        Me.pnlHeader.Controls.Add(Me.Label14)
        Me.pnlHeader.Controls.Add(Me.txtSealNo)
        Me.pnlHeader.Controls.Add(Me.dtATD)
        Me.pnlHeader.Controls.Add(Me.txtATD)
        Me.pnlHeader.Controls.Add(Me.Label11)
        Me.pnlHeader.Controls.Add(Me.Label12)
        Me.pnlHeader.Controls.Add(Me.dtETD)
        Me.pnlHeader.Controls.Add(Me.txtETD)
        Me.pnlHeader.Controls.Add(Me.Label22)
        Me.pnlHeader.Controls.Add(Me.Label21)
        Me.pnlHeader.Controls.Add(Me.Label9)
        Me.pnlHeader.Controls.Add(Me.Label10)
        Me.pnlHeader.Controls.Add(Me.cboWarehouse)
        Me.pnlHeader.Controls.Add(Me.Label5)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Controls.Add(Me.txtContainerYard)
        Me.pnlHeader.Controls.Add(Me.Label8)
        Me.pnlHeader.Controls.Add(Me.Label7)
        Me.pnlHeader.Controls.Add(Me.txtLoadedPullOut)
        Me.pnlHeader.Controls.Add(Me.GroupBox2)
        Me.pnlHeader.Controls.Add(Me.GroupBox1)
        Me.pnlHeader.Controls.Add(Me.Label19)
        Me.pnlHeader.Controls.Add(Me.Label20)
        Me.pnlHeader.Controls.Add(Me.cboCarrier)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.txtRefNo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1140, 206)
        Me.pnlHeader.TabIndex = 0
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(391, 38)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(67, 13)
        Me.Label41.TabIndex = 58
        Me.Label41.Text = "Load Type"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(509, 38)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(11, 13)
        Me.Label42.TabIndex = 59
        Me.Label42.Text = ":"
        '
        'cboLoadType
        '
        Me.cboLoadType.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoadType.FormattingEnabled = True
        Me.cboLoadType.IntegralHeight = False
        Me.cboLoadType.Location = New System.Drawing.Point(527, 34)
        Me.cboLoadType.Name = "cboLoadType"
        Me.cboLoadType.Size = New System.Drawing.Size(214, 23)
        Me.cboLoadType.TabIndex = 60
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(391, 16)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(113, 13)
        Me.Label39.TabIndex = 8
        Me.Label39.Text = "Mode Of Transport"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(509, 16)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 13)
        Me.Label40.TabIndex = 9
        Me.Label40.Text = ":"
        '
        'cboModeOfTransport
        '
        Me.cboModeOfTransport.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModeOfTransport.FormattingEnabled = True
        Me.cboModeOfTransport.IntegralHeight = False
        Me.cboModeOfTransport.Location = New System.Drawing.Point(527, 12)
        Me.cboModeOfTransport.Name = "cboModeOfTransport"
        Me.cboModeOfTransport.Size = New System.Drawing.Size(214, 23)
        Me.cboModeOfTransport.TabIndex = 10
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(857, 95)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(10, 13)
        Me.Label37.TabIndex = 49
        Me.Label37.Text = ":"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(764, 95)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(35, 13)
        Me.Label38.TabIndex = 48
        Me.Label38.Text = "Airline"
        '
        'cboAirLine
        '
        Me.cboAirLine.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAirLine.FormattingEnabled = True
        Me.cboAirLine.IntegralHeight = False
        Me.cboAirLine.Location = New System.Drawing.Point(874, 91)
        Me.cboAirLine.Name = "cboAirLine"
        Me.cboAirLine.Size = New System.Drawing.Size(214, 23)
        Me.cboAirLine.TabIndex = 50
        '
        'lblStatusDetails
        '
        Me.lblStatusDetails.AutoSize = True
        Me.lblStatusDetails.Location = New System.Drawing.Point(1069, 135)
        Me.lblStatusDetails.Name = "lblStatusDetails"
        Me.lblStatusDetails.Size = New System.Drawing.Size(16, 13)
        Me.lblStatusDetails.TabIndex = 57
        Me.lblStatusDetails.Text = "..."
        Me.lblStatusDetails.Visible = False
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(874, 132)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(214, 20)
        Me.txtStatus.TabIndex = 56
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(856, 136)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(10, 13)
        Me.Label49.TabIndex = 55
        Me.Label49.Text = ":"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(764, 136)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(37, 13)
        Me.Label50.TabIndex = 54
        Me.Label50.Text = "Status"
        '
        'dtATA
        '
        Me.dtATA.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtATA.Location = New System.Drawing.Point(723, 173)
        Me.dtATA.Name = "dtATA"
        Me.dtATA.Size = New System.Drawing.Size(18, 20)
        Me.dtATA.TabIndex = 35
        '
        'txtATA
        '
        Me.txtATA.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtATA.Location = New System.Drawing.Point(527, 173)
        Me.txtATA.Name = "txtATA"
        Me.txtATA.Size = New System.Drawing.Size(197, 20)
        Me.txtATA.TabIndex = 34
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(391, 177)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(28, 13)
        Me.Label33.TabIndex = 32
        Me.Label33.Text = "ATA"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(509, 177)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(10, 13)
        Me.Label34.TabIndex = 33
        Me.Label34.Text = ":"
        '
        'dtETA
        '
        Me.dtETA.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtETA.Location = New System.Drawing.Point(723, 154)
        Me.dtETA.Name = "dtETA"
        Me.dtETA.Size = New System.Drawing.Size(18, 20)
        Me.dtETA.TabIndex = 31
        '
        'txtETA
        '
        Me.txtETA.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtETA.Location = New System.Drawing.Point(527, 154)
        Me.txtETA.Name = "txtETA"
        Me.txtETA.Size = New System.Drawing.Size(197, 20)
        Me.txtETA.TabIndex = 30
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(391, 158)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(31, 13)
        Me.Label35.TabIndex = 28
        Me.Label35.Text = "ETA"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(509, 158)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 13)
        Me.Label36.TabIndex = 29
        Me.Label36.Text = ":"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(857, 116)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(10, 13)
        Me.Label25.TabIndex = 52
        Me.Label25.Text = ":"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(764, 116)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(27, 13)
        Me.Label26.TabIndex = 51
        Me.Label26.Text = "LCT"
        '
        'txtLCT
        '
        Me.txtLCT.Location = New System.Drawing.Point(874, 113)
        Me.txtLCT.Name = "txtLCT"
        Me.txtLCT.Size = New System.Drawing.Size(214, 20)
        Me.txtLCT.TabIndex = 53
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(857, 73)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 13)
        Me.Label23.TabIndex = 46
        Me.Label23.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(764, 73)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 13)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Vessel"
        '
        'cboVessel
        '
        Me.cboVessel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.IntegralHeight = False
        Me.cboVessel.Location = New System.Drawing.Point(874, 69)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(214, 23)
        Me.cboVessel.TabIndex = 47
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(857, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = ":"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(764, 53)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Chassis Depot"
        '
        'txtChassisDepot
        '
        Me.txtChassisDepot.Location = New System.Drawing.Point(874, 50)
        Me.txtChassisDepot.Name = "txtChassisDepot"
        Me.txtChassisDepot.Size = New System.Drawing.Size(214, 20)
        Me.txtChassisDepot.TabIndex = 44
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(857, 34)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(764, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Empty Positioning"
        '
        'txtEmptyPositioning
        '
        Me.txtEmptyPositioning.Location = New System.Drawing.Point(874, 31)
        Me.txtEmptyPositioning.Name = "txtEmptyPositioning"
        Me.txtEmptyPositioning.Size = New System.Drawing.Size(214, 20)
        Me.txtEmptyPositioning.TabIndex = 41
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(857, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(764, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Seal No."
        '
        'txtSealNo
        '
        Me.txtSealNo.Location = New System.Drawing.Point(874, 12)
        Me.txtSealNo.Name = "txtSealNo"
        Me.txtSealNo.Size = New System.Drawing.Size(214, 20)
        Me.txtSealNo.TabIndex = 38
        '
        'dtATD
        '
        Me.dtATD.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtATD.Location = New System.Drawing.Point(723, 135)
        Me.dtATD.Name = "dtATD"
        Me.dtATD.Size = New System.Drawing.Size(18, 20)
        Me.dtATD.TabIndex = 27
        '
        'txtATD
        '
        Me.txtATD.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtATD.Location = New System.Drawing.Point(527, 135)
        Me.txtATD.Name = "txtATD"
        Me.txtATD.Size = New System.Drawing.Size(197, 20)
        Me.txtATD.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(391, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "ATD"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(509, 139)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = ":"
        '
        'dtETD
        '
        Me.dtETD.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtETD.Location = New System.Drawing.Point(723, 116)
        Me.dtETD.Name = "dtETD"
        Me.dtETD.Size = New System.Drawing.Size(18, 20)
        Me.dtETD.TabIndex = 23
        '
        'txtETD
        '
        Me.txtETD.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtETD.Location = New System.Drawing.Point(527, 116)
        Me.txtETD.Name = "txtETD"
        Me.txtETD.Size = New System.Drawing.Size(197, 20)
        Me.txtETD.TabIndex = 22
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(391, 120)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 13)
        Me.Label22.TabIndex = 20
        Me.Label22.Text = "ETD"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(509, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(510, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(391, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Warehouse"
        '
        'cboWarehouse
        '
        Me.cboWarehouse.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.IntegralHeight = False
        Me.cboWarehouse.Location = New System.Drawing.Point(527, 94)
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(214, 23)
        Me.cboWarehouse.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(510, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(391, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Container Yard"
        '
        'txtContainerYard
        '
        Me.txtContainerYard.Location = New System.Drawing.Point(527, 75)
        Me.txtContainerYard.Name = "txtContainerYard"
        Me.txtContainerYard.Size = New System.Drawing.Size(214, 20)
        Me.txtContainerYard.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(510, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(391, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Loaded Pull Out"
        '
        'txtLoadedPullOut
        '
        Me.txtLoadedPullOut.Location = New System.Drawing.Point(527, 56)
        Me.txtLoadedPullOut.Name = "txtLoadedPullOut"
        Me.txtLoadedPullOut.Size = New System.Drawing.Size(214, 20)
        Me.txtLoadedPullOut.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtOriginCountry)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.cboOriginPort)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(350, 66)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Origin"
        '
        'txtOriginCountry
        '
        Me.txtOriginCountry.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtOriginCountry.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginCountry.Location = New System.Drawing.Point(136, 16)
        Me.txtOriginCountry.Name = "txtOriginCountry"
        Me.txtOriginCountry.ReadOnly = True
        Me.txtOriginCountry.Size = New System.Drawing.Size(208, 20)
        Me.txtOriginCountry.TabIndex = 2
        Me.txtOriginCountry.Text = "Philippines"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(119, 41)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 13)
        Me.Label29.TabIndex = 4
        Me.Label29.Text = ":"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(21, 41)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "Port"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(119, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 13)
        Me.Label31.TabIndex = 1
        Me.Label31.Text = ":"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(21, 19)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(50, 13)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Country"
        '
        'cboOriginPort
        '
        Me.cboOriginPort.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOriginPort.FormattingEnabled = True
        Me.cboOriginPort.IntegralHeight = False
        Me.cboOriginPort.Location = New System.Drawing.Point(136, 35)
        Me.cboOriginPort.Name = "cboOriginPort"
        Me.cboOriginPort.Size = New System.Drawing.Size(208, 23)
        Me.cboOriginPort.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboDestinationPort)
        Me.GroupBox1.Controls.Add(Me.cboDestinationCountry)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 66)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Destination"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(119, 43)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(21, 43)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(119, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Country"
        '
        'cboDestinationPort
        '
        Me.cboDestinationPort.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDestinationPort.FormattingEnabled = True
        Me.cboDestinationPort.IntegralHeight = False
        Me.cboDestinationPort.Location = New System.Drawing.Point(136, 37)
        Me.cboDestinationPort.Name = "cboDestinationPort"
        Me.cboDestinationPort.Size = New System.Drawing.Size(208, 23)
        Me.cboDestinationPort.TabIndex = 5
        '
        'cboDestinationCountry
        '
        Me.cboDestinationCountry.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDestinationCountry.FormattingEnabled = True
        Me.cboDestinationCountry.IntegralHeight = False
        Me.cboDestinationCountry.Location = New System.Drawing.Point(136, 15)
        Me.cboDestinationCountry.Name = "cboDestinationCountry"
        Me.cboDestinationCountry.Size = New System.Drawing.Size(208, 23)
        Me.cboDestinationCountry.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(134, 35)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Carrier"
        '
        'cboCarrier
        '
        Me.cboCarrier.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarrier.FormattingEnabled = True
        Me.cboCarrier.IntegralHeight = False
        Me.cboCarrier.Location = New System.Drawing.Point(152, 31)
        Me.cboCarrier.Name = "cboCarrier"
        Me.cboCarrier.Size = New System.Drawing.Size(214, 23)
        Me.cboCarrier.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reference No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        '
        'txtRefNo
        '
        Me.txtRefNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRefNo.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(152, 12)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.ReadOnly = True
        Me.txtRefNo.Size = New System.Drawing.Size(214, 20)
        Me.txtRefNo.TabIndex = 2
        Me.txtRefNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslblPrepBy, Me.ToolStripStatusLabel3, Me.tslblPrepDate, Me.ToolStripStatusLabel2, Me.tslblModBy, Me.ToolStripStatusLabel5, Me.tslblModDate})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(1140, 22)
        Me.StatusStrip2.TabIndex = 3
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
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 206)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1140, 5)
        Me.Splitter1.TabIndex = 4
        Me.Splitter1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscmdAdd, Me.tscmdRemove})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 211)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1140, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tscmdAdd
        '
        Me.tscmdAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscmdAdd.Image = CType(resources.GetObject("tscmdAdd.Image"), System.Drawing.Image)
        Me.tscmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdAdd.Name = "tscmdAdd"
        Me.tscmdAdd.Size = New System.Drawing.Size(23, 22)
        Me.tscmdAdd.Text = "Add Booking No."
        '
        'tscmdRemove
        '
        Me.tscmdRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscmdRemove.Image = CType(resources.GetObject("tscmdRemove.Image"), System.Drawing.Image)
        Me.tscmdRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdRemove.Name = "tscmdRemove"
        Me.tscmdRemove.Size = New System.Drawing.Size(23, 22)
        Me.tscmdRemove.Text = "Remove Selected Booking No."
        '
        'dtgBookingDetails
        '
        Me.dtgBookingDetails.AllowUserToAddRows = False
        Me.dtgBookingDetails.AllowUserToDeleteRows = False
        Me.dtgBookingDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBookingDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgBookingDetails.Location = New System.Drawing.Point(0, 236)
        Me.dtgBookingDetails.Name = "dtgBookingDetails"
        Me.dtgBookingDetails.ReadOnly = True
        Me.dtgBookingDetails.Size = New System.Drawing.Size(1140, 260)
        Me.dtgBookingDetails.TabIndex = 1
        '
        'frmExportMasterBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 518)
        Me.Controls.Add(Me.dtgBookingDetails)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmExportMasterBooking"
        Me.Text = "Export Master Booking"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgBookingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRefNo As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cboCarrier As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtOriginCountry As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents cboOriginPort As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboDestinationPort As ComboBox
    Friend WithEvents cboDestinationCountry As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtLoadedPullOut As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cboWarehouse As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtContainerYard As TextBox
    Friend WithEvents dtATA As DateTimePicker
    Friend WithEvents txtATA As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents dtETA As DateTimePicker
    Friend WithEvents txtETA As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtLCT As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents cboVessel As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtChassisDepot As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtEmptyPositioning As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtSealNo As TextBox
    Friend WithEvents dtATD As DateTimePicker
    Friend WithEvents txtATD As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents dtETD As DateTimePicker
    Friend WithEvents txtETD As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents cboAirLine As ComboBox
    Friend WithEvents lblStatusDetails As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tslblPrepBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents tslblPrepDate As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tslblModBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents tslblModDate As ToolStripStatusLabel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tscmdAdd As ToolStripButton
    Friend WithEvents tscmdRemove As ToolStripButton
    Friend WithEvents dtgBookingDetails As DataGridView
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents cboModeOfTransport As ComboBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents cboLoadType As ComboBox
End Class
