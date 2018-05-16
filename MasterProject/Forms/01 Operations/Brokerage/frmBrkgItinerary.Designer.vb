<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBrkgItinerary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrkgItinerary))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tscmdAddRequest = New System.Windows.Forms.ToolStripButton()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDesignation = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPersonel = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPrepDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblModBy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblModDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tscmdAdd = New System.Windows.Forms.ToolStripButton()
        Me.tscmdRemove = New System.Windows.Forms.ToolStripButton()
        Me.dtgDetails = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colJOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtRemarks)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtLocation)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtDesignation)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboPersonel)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(825, 178)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListView1)
        Me.GroupBox1.Controls.Add(Me.ToolStrip2)
        Me.GroupBox1.Location = New System.Drawing.Point(427, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 158)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Request For Payment"
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Location = New System.Drawing.Point(3, 41)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(194, 114)
        Me.ListView1.TabIndex = 6
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscmdAddRequest})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(194, 25)
        Me.ToolStrip2.TabIndex = 5
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tscmdAddRequest
        '
        Me.tscmdAddRequest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscmdAddRequest.Image = CType(resources.GetObject("tscmdAddRequest.Image"), System.Drawing.Image)
        Me.tscmdAddRequest.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdAddRequest.Name = "tscmdAddRequest"
        Me.tscmdAddRequest.Size = New System.Drawing.Size(23, 22)
        Me.tscmdAddRequest.Text = "Add Container"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(97, 89)
        Me.txtRemarks.MaxLength = 500
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(307, 81)
        Me.txtRemarks.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(81, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Remarks"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(97, 70)
        Me.txtLocation.MaxLength = 250
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(307, 20)
        Me.txtLocation.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(81, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Location"
        '
        'txtDesignation
        '
        Me.txtDesignation.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDesignation.Location = New System.Drawing.Point(97, 51)
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.ReadOnly = True
        Me.txtDesignation.Size = New System.Drawing.Size(307, 20)
        Me.txtDesignation.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Designation"
        '
        'cboPersonel
        '
        Me.cboPersonel.FormattingEnabled = True
        Me.cboPersonel.IntegralHeight = False
        Me.cboPersonel.Location = New System.Drawing.Point(97, 31)
        Me.cboPersonel.Name = "cboPersonel"
        Me.cboPersonel.Size = New System.Drawing.Size(307, 21)
        Me.cboPersonel.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Personel"
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtID.Location = New System.Drawing.Point(97, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ref. No."
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslblPrepBy, Me.ToolStripStatusLabel3, Me.tslblPrepDate, Me.ToolStripStatusLabel2, Me.tslblModBy, Me.ToolStripStatusLabel5, Me.tslblModDate})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 371)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(825, 22)
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
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tscmdAdd, Me.tscmdRemove})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 178)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(825, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tscmdAdd
        '
        Me.tscmdAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscmdAdd.Image = CType(resources.GetObject("tscmdAdd.Image"), System.Drawing.Image)
        Me.tscmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdAdd.Name = "tscmdAdd"
        Me.tscmdAdd.Size = New System.Drawing.Size(23, 22)
        Me.tscmdAdd.Text = "Add Container"
        '
        'tscmdRemove
        '
        Me.tscmdRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tscmdRemove.Image = CType(resources.GetObject("tscmdRemove.Image"), System.Drawing.Image)
        Me.tscmdRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tscmdRemove.Name = "tscmdRemove"
        Me.tscmdRemove.Size = New System.Drawing.Size(23, 22)
        Me.tscmdRemove.Text = "Remove Container"
        '
        'dtgDetails
        '
        Me.dtgDetails.AllowUserToAddRows = False
        Me.dtgDetails.AllowUserToDeleteRows = False
        Me.dtgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colJOID, Me.colType, Me.colBookNo, Me.colStatusTypeID, Me.colStatusType, Me.colStatusID, Me.colStatusName, Me.colRemarks})
        Me.dtgDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgDetails.Location = New System.Drawing.Point(0, 203)
        Me.dtgDetails.Name = "dtgDetails"
        Me.dtgDetails.ReadOnly = True
        Me.dtgDetails.Size = New System.Drawing.Size(825, 168)
        Me.dtgDetails.TabIndex = 5
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'colJOID
        '
        Me.colJOID.HeaderText = "JOID"
        Me.colJOID.Name = "colJOID"
        Me.colJOID.ReadOnly = True
        Me.colJOID.Visible = False
        '
        'colType
        '
        Me.colType.HeaderText = "Type"
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        Me.colType.Width = 75
        '
        'colBookNo
        '
        Me.colBookNo.HeaderText = "Booking No."
        Me.colBookNo.Name = "colBookNo"
        Me.colBookNo.ReadOnly = True
        '
        'colStatusTypeID
        '
        Me.colStatusTypeID.HeaderText = "Status Type ID"
        Me.colStatusTypeID.Name = "colStatusTypeID"
        Me.colStatusTypeID.ReadOnly = True
        Me.colStatusTypeID.Visible = False
        '
        'colStatusType
        '
        Me.colStatusType.HeaderText = "Status Type"
        Me.colStatusType.Name = "colStatusType"
        Me.colStatusType.ReadOnly = True
        Me.colStatusType.Width = 200
        '
        'colStatusID
        '
        Me.colStatusID.HeaderText = "Status ID"
        Me.colStatusID.Name = "colStatusID"
        Me.colStatusID.ReadOnly = True
        Me.colStatusID.Visible = False
        '
        'colStatusName
        '
        Me.colStatusName.HeaderText = "Status"
        Me.colStatusName.Name = "colStatusName"
        Me.colStatusName.ReadOnly = True
        Me.colStatusName.Width = 200
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        Me.colRemarks.Width = 250
        '
        'frmBrkgItinerary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 393)
        Me.Controls.Add(Me.dtgDetails)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmBrkgItinerary"
        Me.Text = "Brokerage Itinerary"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDesignation As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboPersonel As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tslblPrepBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents tslblPrepDate As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tslblModBy As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents tslblModDate As ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tscmdAdd As ToolStripButton
    Friend WithEvents tscmdRemove As ToolStripButton
    Friend WithEvents dtgDetails As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colJOID As DataGridViewTextBoxColumn
    Friend WithEvents colType As DataGridViewTextBoxColumn
    Friend WithEvents colBookNo As DataGridViewTextBoxColumn
    Friend WithEvents colStatusTypeID As DataGridViewTextBoxColumn
    Friend WithEvents colStatusType As DataGridViewTextBoxColumn
    Friend WithEvents colStatusID As DataGridViewTextBoxColumn
    Friend WithEvents colStatusName As DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tscmdAddRequest As ToolStripButton
End Class
