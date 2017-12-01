<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportBookingMonitoring
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShipperCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShipperName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsigneeCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsigneeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescriptionOfGoods = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModeOfTransportID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModeOfTransportName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoadTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoadTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrepDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(854, 91)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colBookingNo, Me.colCompanyCode, Me.colCompanyName, Me.colShipperCode, Me.colShipperName, Me.colConsigneeCode, Me.colConsigneeName, Me.colDescriptionOfGoods, Me.colModeOfTransportID, Me.colModeOfTransportName, Me.colLoadTypeID, Me.colLoadTypeName, Me.colPrepDate})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 91)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(854, 396)
        Me.DataGridView1.TabIndex = 1
        '
        'colID
        '
        Me.colID.Frozen = True
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'colBookingNo
        '
        Me.colBookingNo.Frozen = True
        Me.colBookingNo.HeaderText = "Booking No."
        Me.colBookingNo.Name = "colBookingNo"
        Me.colBookingNo.ReadOnly = True
        Me.colBookingNo.Width = 125
        '
        'colCompanyCode
        '
        Me.colCompanyCode.HeaderText = "Company Code"
        Me.colCompanyCode.Name = "colCompanyCode"
        Me.colCompanyCode.ReadOnly = True
        Me.colCompanyCode.Visible = False
        '
        'colCompanyName
        '
        Me.colCompanyName.HeaderText = "Company Name"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.ReadOnly = True
        Me.colCompanyName.Visible = False
        '
        'colShipperCode
        '
        Me.colShipperCode.HeaderText = "Shipper Code"
        Me.colShipperCode.Name = "colShipperCode"
        Me.colShipperCode.ReadOnly = True
        Me.colShipperCode.Visible = False
        '
        'colShipperName
        '
        Me.colShipperName.HeaderText = "Shipper"
        Me.colShipperName.Name = "colShipperName"
        Me.colShipperName.ReadOnly = True
        Me.colShipperName.Width = 200
        '
        'colConsigneeCode
        '
        Me.colConsigneeCode.HeaderText = "ConsigneeCode"
        Me.colConsigneeCode.Name = "colConsigneeCode"
        Me.colConsigneeCode.ReadOnly = True
        Me.colConsigneeCode.Visible = False
        '
        'colConsigneeName
        '
        Me.colConsigneeName.HeaderText = "Consignee"
        Me.colConsigneeName.Name = "colConsigneeName"
        Me.colConsigneeName.ReadOnly = True
        Me.colConsigneeName.Width = 200
        '
        'colDescriptionOfGoods
        '
        Me.colDescriptionOfGoods.HeaderText = "Description Of Goods"
        Me.colDescriptionOfGoods.Name = "colDescriptionOfGoods"
        Me.colDescriptionOfGoods.ReadOnly = True
        Me.colDescriptionOfGoods.Width = 250
        '
        'colModeOfTransportID
        '
        Me.colModeOfTransportID.HeaderText = "Mode Of Transport ID"
        Me.colModeOfTransportID.Name = "colModeOfTransportID"
        Me.colModeOfTransportID.ReadOnly = True
        Me.colModeOfTransportID.Visible = False
        '
        'colModeOfTransportName
        '
        Me.colModeOfTransportName.HeaderText = "Trans Mode"
        Me.colModeOfTransportName.Name = "colModeOfTransportName"
        Me.colModeOfTransportName.ReadOnly = True
        '
        'colLoadTypeID
        '
        Me.colLoadTypeID.HeaderText = "Load Type ID"
        Me.colLoadTypeID.Name = "colLoadTypeID"
        Me.colLoadTypeID.ReadOnly = True
        Me.colLoadTypeID.Visible = False
        '
        'colLoadTypeName
        '
        Me.colLoadTypeName.HeaderText = "Load Type"
        Me.colLoadTypeName.Name = "colLoadTypeName"
        Me.colLoadTypeName.ReadOnly = True
        '
        'colPrepDate
        '
        Me.colPrepDate.HeaderText = "Prepared Date"
        Me.colPrepDate.Name = "colPrepDate"
        Me.colPrepDate.ReadOnly = True
        Me.colPrepDate.Width = 125
        '
        'frmImportBookingMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 487)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmImportBookingMonitoring"
        Me.Text = "Import Booking Monitoring"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colBookingNo As DataGridViewTextBoxColumn
    Friend WithEvents colCompanyCode As DataGridViewTextBoxColumn
    Friend WithEvents colCompanyName As DataGridViewTextBoxColumn
    Friend WithEvents colShipperCode As DataGridViewTextBoxColumn
    Friend WithEvents colShipperName As DataGridViewTextBoxColumn
    Friend WithEvents colConsigneeCode As DataGridViewTextBoxColumn
    Friend WithEvents colConsigneeName As DataGridViewTextBoxColumn
    Friend WithEvents colDescriptionOfGoods As DataGridViewTextBoxColumn
    Friend WithEvents colModeOfTransportID As DataGridViewTextBoxColumn
    Friend WithEvents colModeOfTransportName As DataGridViewTextBoxColumn
    Friend WithEvents colLoadTypeID As DataGridViewTextBoxColumn
    Friend WithEvents colLoadTypeName As DataGridViewTextBoxColumn
    Friend WithEvents colPrepDate As DataGridViewTextBoxColumn
End Class
