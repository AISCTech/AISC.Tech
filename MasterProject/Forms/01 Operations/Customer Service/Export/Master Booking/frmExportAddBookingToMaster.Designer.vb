<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportAddBookingToMaster
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboConsignee = New System.Windows.Forms.ComboBox()
        Me.chkConsigneeAll = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboShipper = New System.Windows.Forms.ComboBox()
        Me.chkShipperAll = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboConsignor = New System.Windows.Forms.ComboBox()
        Me.chkConsignorAll = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkBookingNoAll = New System.Windows.Forms.CheckBox()
        Me.txtBookingNo = New System.Windows.Forms.TextBox()
        Me.dtgExportBooking = New System.Windows.Forms.DataGridView()
        Me.pnlHeader.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgExportBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.GroupBox1)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(898, 103)
        Me.pnlHeader.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(886, 94)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Options"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboConsignee)
        Me.GroupBox5.Controls.Add(Me.chkConsigneeAll)
        Me.GroupBox5.Location = New System.Drawing.Point(647, 19)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(228, 64)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Consignee"
        '
        'cboConsignee
        '
        Me.cboConsignee.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConsignee.FormattingEnabled = True
        Me.cboConsignee.IntegralHeight = False
        Me.cboConsignee.Location = New System.Drawing.Point(6, 36)
        Me.cboConsignee.Name = "cboConsignee"
        Me.cboConsignee.Size = New System.Drawing.Size(216, 23)
        Me.cboConsignee.TabIndex = 40
        '
        'chkConsigneeAll
        '
        Me.chkConsigneeAll.AutoSize = True
        Me.chkConsigneeAll.Location = New System.Drawing.Point(6, 19)
        Me.chkConsigneeAll.Name = "chkConsigneeAll"
        Me.chkConsigneeAll.Size = New System.Drawing.Size(37, 17)
        Me.chkConsigneeAll.TabIndex = 2
        Me.chkConsigneeAll.Text = "All"
        Me.chkConsigneeAll.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboShipper)
        Me.GroupBox4.Controls.Add(Me.chkShipperAll)
        Me.GroupBox4.Location = New System.Drawing.Point(413, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(228, 64)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Shipper"
        '
        'cboShipper
        '
        Me.cboShipper.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShipper.FormattingEnabled = True
        Me.cboShipper.IntegralHeight = False
        Me.cboShipper.Location = New System.Drawing.Point(6, 36)
        Me.cboShipper.Name = "cboShipper"
        Me.cboShipper.Size = New System.Drawing.Size(216, 23)
        Me.cboShipper.TabIndex = 40
        '
        'chkShipperAll
        '
        Me.chkShipperAll.AutoSize = True
        Me.chkShipperAll.Location = New System.Drawing.Point(6, 19)
        Me.chkShipperAll.Name = "chkShipperAll"
        Me.chkShipperAll.Size = New System.Drawing.Size(37, 17)
        Me.chkShipperAll.TabIndex = 2
        Me.chkShipperAll.Text = "All"
        Me.chkShipperAll.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboConsignor)
        Me.GroupBox3.Controls.Add(Me.chkConsignorAll)
        Me.GroupBox3.Location = New System.Drawing.Point(179, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(228, 64)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consignor/Debtor"
        '
        'cboConsignor
        '
        Me.cboConsignor.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConsignor.FormattingEnabled = True
        Me.cboConsignor.IntegralHeight = False
        Me.cboConsignor.Location = New System.Drawing.Point(6, 36)
        Me.cboConsignor.Name = "cboConsignor"
        Me.cboConsignor.Size = New System.Drawing.Size(216, 23)
        Me.cboConsignor.TabIndex = 40
        '
        'chkConsignorAll
        '
        Me.chkConsignorAll.AutoSize = True
        Me.chkConsignorAll.Location = New System.Drawing.Point(6, 19)
        Me.chkConsignorAll.Name = "chkConsignorAll"
        Me.chkConsignorAll.Size = New System.Drawing.Size(37, 17)
        Me.chkConsignorAll.TabIndex = 2
        Me.chkConsignorAll.Text = "All"
        Me.chkConsignorAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkBookingNoAll)
        Me.GroupBox2.Controls.Add(Me.txtBookingNo)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 64)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Booking No."
        '
        'chkBookingNoAll
        '
        Me.chkBookingNoAll.AutoSize = True
        Me.chkBookingNoAll.Location = New System.Drawing.Point(6, 19)
        Me.chkBookingNoAll.Name = "chkBookingNoAll"
        Me.chkBookingNoAll.Size = New System.Drawing.Size(37, 17)
        Me.chkBookingNoAll.TabIndex = 2
        Me.chkBookingNoAll.Text = "All"
        Me.chkBookingNoAll.UseVisualStyleBackColor = True
        '
        'txtBookingNo
        '
        Me.txtBookingNo.Location = New System.Drawing.Point(6, 36)
        Me.txtBookingNo.Name = "txtBookingNo"
        Me.txtBookingNo.Size = New System.Drawing.Size(155, 20)
        Me.txtBookingNo.TabIndex = 1
        '
        'dtgExportBooking
        '
        Me.dtgExportBooking.AllowUserToAddRows = False
        Me.dtgExportBooking.AllowUserToDeleteRows = False
        Me.dtgExportBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgExportBooking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgExportBooking.Location = New System.Drawing.Point(0, 103)
        Me.dtgExportBooking.Name = "dtgExportBooking"
        Me.dtgExportBooking.ReadOnly = True
        Me.dtgExportBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgExportBooking.Size = New System.Drawing.Size(898, 351)
        Me.dtgExportBooking.TabIndex = 2
        '
        'frmExportAddBookingToMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 454)
        Me.Controls.Add(Me.dtgExportBooking)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "frmExportAddBookingToMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Export Booking"
        Me.pnlHeader.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgExportBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboShipper As ComboBox
    Friend WithEvents chkShipperAll As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboConsignor As ComboBox
    Friend WithEvents chkConsignorAll As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkBookingNoAll As CheckBox
    Friend WithEvents txtBookingNo As TextBox
    Friend WithEvents dtgExportBooking As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cboConsignee As ComboBox
    Friend WithEvents chkConsigneeAll As CheckBox
End Class
