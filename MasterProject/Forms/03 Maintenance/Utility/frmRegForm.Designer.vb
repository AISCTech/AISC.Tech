<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegForm
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
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.colPrepBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrepDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlViewing = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSearchTo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSearchFrom = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.colRefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFormNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFormType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.colFormTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkSingleRecord = New System.Windows.Forms.CheckBox()
        Me.tscmdCancel = New System.Windows.Forms.ToolStripButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtSeriesTo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSeriesFrom = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFormType = New System.Windows.Forms.ComboBox()
        Me.tscmdReOpen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tscmdRelease = New System.Windows.Forms.ToolStripButton()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tscmdNew = New System.Windows.Forms.ToolStripButton()
        Me.cboModule = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tscmdReset = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tscmdSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.colSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dtgFormList = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlUserInput = New System.Windows.Forms.Panel()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlViewing.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgFormList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUserInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(395, 2)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 41
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'colPrepBy
        '
        Me.colPrepBy.HeaderText = "Prepared By"
        Me.colPrepBy.Name = "colPrepBy"
        Me.colPrepBy.ReadOnly = True
        Me.colPrepBy.Width = 125
        '
        'colPrepDate
        '
        Me.colPrepDate.HeaderText = "Prepared Date"
        Me.colPrepDate.Name = "colPrepDate"
        Me.colPrepDate.ReadOnly = True
        Me.colPrepDate.Width = 125
        '
        'pnlViewing
        '
        Me.pnlViewing.Controls.Add(Me.cmdSearch)
        Me.pnlViewing.Controls.Add(Me.Panel1)
        Me.pnlViewing.Controls.Add(Me.Label19)
        Me.pnlViewing.Controls.Add(Me.Label20)
        Me.pnlViewing.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlViewing.Location = New System.Drawing.Point(0, 101)
        Me.pnlViewing.Name = "pnlViewing"
        Me.pnlViewing.Size = New System.Drawing.Size(1060, 32)
        Me.pnlViewing.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtSearchTo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtSearchFrom)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(122, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 20)
        Me.Panel1.TabIndex = 19
        '
        'txtSearchTo
        '
        Me.txtSearchTo.Location = New System.Drawing.Point(166, -1)
        Me.txtSearchTo.Name = "txtSearchTo"
        Me.txtSearchTo.Size = New System.Drawing.Size(100, 20)
        Me.txtSearchTo.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(141, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "To:"
        '
        'txtSearchFrom
        '
        Me.txtSearchFrom.Location = New System.Drawing.Point(35, -1)
        Me.txtSearchFrom.Name = "txtSearchFrom"
        Me.txtSearchFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtSearchFrom.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "From:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Search By Form No."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(106, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 13)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = ":"
        '
        'colRefNo
        '
        Me.colRefNo.HeaderText = "Reference No."
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.ReadOnly = True
        Me.colRefNo.Width = 150
        '
        'colStatusDate
        '
        Me.colStatusDate.HeaderText = "Status Date"
        Me.colStatusDate.Name = "colStatusDate"
        Me.colStatusDate.ReadOnly = True
        Me.colStatusDate.Width = 125
        '
        'colStatusBy
        '
        Me.colStatusBy.HeaderText = "Status By"
        Me.colStatusBy.Name = "colStatusBy"
        Me.colStatusBy.ReadOnly = True
        Me.colStatusBy.Width = 125
        '
        'colFormNo
        '
        Me.colFormNo.HeaderText = "Form No."
        Me.colFormNo.Name = "colFormNo"
        Me.colFormNo.ReadOnly = True
        '
        'colModID
        '
        Me.colModID.HeaderText = "Module ID"
        Me.colModID.Name = "colModID"
        Me.colModID.ReadOnly = True
        Me.colModID.Visible = False
        '
        'colModName
        '
        Me.colModName.HeaderText = "Module"
        Me.colModName.Name = "colModName"
        Me.colModName.ReadOnly = True
        Me.colModName.Width = 200
        '
        'colStatusCode
        '
        Me.colStatusCode.HeaderText = ""
        Me.colStatusCode.Name = "colStatusCode"
        Me.colStatusCode.ReadOnly = True
        Me.colStatusCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colStatusCode.Visible = False
        '
        'colStatusName
        '
        Me.colStatusName.HeaderText = "Status"
        Me.colStatusName.Name = "colStatusName"
        Me.colStatusName.ReadOnly = True
        Me.colStatusName.Width = 125
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cancelled Date"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 125
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Cancelled Date"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 125
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = ""
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 125
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 125
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Status By"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 125
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cancelled By"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 125
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cancelled"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 75
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Prep. Date"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Form Type"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Form No."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Prep. By"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 125
        '
        'colFormType
        '
        Me.colFormType.HeaderText = "Form Type"
        Me.colFormType.Name = "colFormType"
        Me.colFormType.ReadOnly = True
        Me.colFormType.Width = 200
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(395, 43)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(75, 23)
        Me.cmdLoad.TabIndex = 40
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'colFormTypeID
        '
        Me.colFormTypeID.HeaderText = "Group ID"
        Me.colFormTypeID.Name = "colFormTypeID"
        Me.colFormTypeID.ReadOnly = True
        Me.colFormTypeID.Visible = False
        '
        'chkSingleRecord
        '
        Me.chkSingleRecord.AutoSize = True
        Me.chkSingleRecord.Location = New System.Drawing.Point(395, 28)
        Me.chkSingleRecord.Name = "chkSingleRecord"
        Me.chkSingleRecord.Size = New System.Drawing.Size(93, 17)
        Me.chkSingleRecord.TabIndex = 41
        Me.chkSingleRecord.Text = "Single Record"
        Me.chkSingleRecord.UseVisualStyleBackColor = True
        '
        'tscmdCancel
        '
        Me.tscmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdCancel.Name = "tscmdCancel"
        Me.tscmdCancel.Size = New System.Drawing.Size(42, 22)
        Me.tscmdCancel.Text = "Cancel"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtSeriesTo)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtSeriesFrom)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(122, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(267, 20)
        Me.Panel3.TabIndex = 18
        '
        'txtSeriesTo
        '
        Me.txtSeriesTo.Location = New System.Drawing.Point(166, -1)
        Me.txtSeriesTo.Name = "txtSeriesTo"
        Me.txtSeriesTo.Size = New System.Drawing.Size(100, 20)
        Me.txtSeriesTo.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(141, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "To:"
        '
        'txtSeriesFrom
        '
        Me.txtSeriesFrom.Location = New System.Drawing.Point(35, -1)
        Me.txtSeriesFrom.Name = "txtSeriesFrom"
        Me.txtSeriesFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtSeriesFrom.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "From:"
        '
        'cboFormType
        '
        Me.cboFormType.FormattingEnabled = True
        Me.cboFormType.IntegralHeight = False
        Me.cboFormType.Location = New System.Drawing.Point(122, 6)
        Me.cboFormType.Name = "cboFormType"
        Me.cboFormType.Size = New System.Drawing.Size(267, 21)
        Me.cboFormType.TabIndex = 4
        '
        'tscmdReOpen
        '
        Me.tscmdReOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdReOpen.Name = "tscmdReOpen"
        Me.tscmdReOpen.Size = New System.Drawing.Size(50, 22)
        Me.tscmdReOpen.Text = "Re Open"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = ":"
        '
        'tscmdRelease
        '
        Me.tscmdRelease.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdRelease.Name = "tscmdRelease"
        Me.tscmdRelease.Size = New System.Drawing.Size(46, 22)
        Me.tscmdRelease.Text = "Release"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 13)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "Module"
        '
        'tscmdNew
        '
        Me.tscmdNew.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscmdNew.ForeColor = System.Drawing.Color.Black
        Me.tscmdNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdNew.Name = "tscmdNew"
        Me.tscmdNew.Size = New System.Drawing.Size(34, 22)
        Me.tscmdNew.Text = "New"
        Me.tscmdNew.ToolTipText = "New Check Request"
        '
        'cboModule
        '
        Me.cboModule.FormattingEnabled = True
        Me.cboModule.IntegralHeight = False
        Me.cboModule.Location = New System.Drawing.Point(122, 45)
        Me.cboModule.Name = "cboModule"
        Me.cboModule.Size = New System.Drawing.Size(267, 21)
        Me.cboModule.TabIndex = 39
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscmdNew, Me.tscmdReset, Me.ToolStripSeparator2, Me.tscmdSave, Me.ToolStripSeparator1, Me.tscmdRelease, Me.tscmdCancel, Me.tscmdReOpen, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 76)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1060, 25)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tscmdReset
        '
        Me.tscmdReset.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscmdReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdReset.Name = "tscmdReset"
        Me.tscmdReset.Size = New System.Drawing.Size(39, 22)
        Me.tscmdReset.Text = "Reset"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tscmdSave
        '
        Me.tscmdSave.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscmdSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdSave.Name = "tscmdSave"
        Me.tscmdSave.Size = New System.Drawing.Size(37, 22)
        Me.tscmdSave.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(106, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(10, 13)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Form Type"
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 71)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1060, 5)
        Me.Splitter1.TabIndex = 20
        Me.Splitter1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(106, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = ":"
        '
        'colSelected
        '
        Me.colSelected.HeaderText = ""
        Me.colSelected.Name = "colSelected"
        Me.colSelected.Width = 25
        '
        'dtgFormList
        '
        Me.dtgFormList.AllowUserToAddRows = False
        Me.dtgFormList.AllowUserToDeleteRows = False
        Me.dtgFormList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgFormList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelected, Me.colFormTypeID, Me.colFormType, Me.colFormNo, Me.colModID, Me.colModName, Me.colStatusCode, Me.colStatusName, Me.colStatusBy, Me.colStatusDate, Me.colRefNo, Me.colPrepBy, Me.colPrepDate})
        Me.dtgFormList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgFormList.Location = New System.Drawing.Point(0, 71)
        Me.dtgFormList.Name = "dtgFormList"
        Me.dtgFormList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgFormList.Size = New System.Drawing.Size(1060, 458)
        Me.dtgFormList.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Series"
        '
        'pnlUserInput
        '
        Me.pnlUserInput.Controls.Add(Me.cmdLoad)
        Me.pnlUserInput.Controls.Add(Me.chkSingleRecord)
        Me.pnlUserInput.Controls.Add(Me.Panel3)
        Me.pnlUserInput.Controls.Add(Me.cboModule)
        Me.pnlUserInput.Controls.Add(Me.Label23)
        Me.pnlUserInput.Controls.Add(Me.Label24)
        Me.pnlUserInput.Controls.Add(Me.cboFormType)
        Me.pnlUserInput.Controls.Add(Me.Label1)
        Me.pnlUserInput.Controls.Add(Me.Label2)
        Me.pnlUserInput.Controls.Add(Me.Label4)
        Me.pnlUserInput.Controls.Add(Me.Label3)
        Me.pnlUserInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUserInput.Location = New System.Drawing.Point(0, 0)
        Me.pnlUserInput.Name = "pnlUserInput"
        Me.pnlUserInput.Size = New System.Drawing.Size(1060, 71)
        Me.pnlUserInput.TabIndex = 19
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Status Date"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 125
        '
        'frmRegForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 529)
        Me.Controls.Add(Me.pnlViewing)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.dtgFormList)
        Me.Controls.Add(Me.pnlUserInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmRegForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Registration Menu"
        Me.pnlViewing.ResumeLayout(False)
        Me.pnlViewing.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgFormList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUserInput.ResumeLayout(False)
        Me.pnlUserInput.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdSearch As Button
    Friend WithEvents colPrepBy As DataGridViewTextBoxColumn
    Friend WithEvents colPrepDate As DataGridViewTextBoxColumn
    Friend WithEvents pnlViewing As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSearchTo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSearchFrom As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents colRefNo As DataGridViewTextBoxColumn
    Friend WithEvents colStatusDate As DataGridViewTextBoxColumn
    Friend WithEvents colStatusBy As DataGridViewTextBoxColumn
    Friend WithEvents colFormNo As DataGridViewTextBoxColumn
    Friend WithEvents colModID As DataGridViewTextBoxColumn
    Friend WithEvents colModName As DataGridViewTextBoxColumn
    Friend WithEvents colStatusCode As DataGridViewTextBoxColumn
    Friend WithEvents colStatusName As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents colFormType As DataGridViewTextBoxColumn
    Friend WithEvents cmdLoad As Button
    Friend WithEvents colFormTypeID As DataGridViewTextBoxColumn
    Friend WithEvents chkSingleRecord As CheckBox
    Friend WithEvents tscmdCancel As ToolStripButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtSeriesTo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSeriesFrom As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboFormType As ComboBox
    Friend WithEvents tscmdReOpen As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Label2 As Label
    Friend WithEvents tscmdRelease As ToolStripButton
    Friend WithEvents Label23 As Label
    Friend WithEvents tscmdNew As ToolStripButton
    Friend WithEvents cboModule As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tscmdReset As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tscmdSave As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Label24 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Label3 As Label
    Friend WithEvents colSelected As DataGridViewCheckBoxColumn
    Friend WithEvents dtgFormList As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlUserInput As Panel
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
End Class
