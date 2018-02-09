<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchExportMasterBooking
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboModeOfTransport = New System.Windows.Forms.ComboBox()
        Me.chkModeOfTransportAll = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboDestination = New System.Windows.Forms.ComboBox()
        Me.chkDestinationAll = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRefNoAll = New System.Windows.Forms.CheckBox()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.dtgMasterBooking = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboLoadType = New System.Windows.Forms.ComboBox()
        Me.chkLoadTypeAll = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgMasterBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1018, 114)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(993, 94)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Options"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtTo)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.dtFrom)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(283, 64)
        Me.GroupBox5.TabIndex = 135
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Date Encoded"
        '
        'dtTo
        '
        Me.dtTo.Location = New System.Drawing.Point(69, 37)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(200, 20)
        Me.dtTo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(53, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = ":"
        '
        'dtFrom
        '
        Me.dtFrom.Location = New System.Drawing.Point(69, 18)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtFrom.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboModeOfTransport)
        Me.GroupBox4.Controls.Add(Me.chkModeOfTransportAll)
        Me.GroupBox4.Location = New System.Drawing.Point(641, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(167, 64)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mode Of Transport"
        '
        'cboModeOfTransport
        '
        Me.cboModeOfTransport.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModeOfTransport.FormattingEnabled = True
        Me.cboModeOfTransport.IntegralHeight = False
        Me.cboModeOfTransport.Location = New System.Drawing.Point(6, 36)
        Me.cboModeOfTransport.Name = "cboModeOfTransport"
        Me.cboModeOfTransport.Size = New System.Drawing.Size(155, 23)
        Me.cboModeOfTransport.TabIndex = 40
        '
        'chkModeOfTransportAll
        '
        Me.chkModeOfTransportAll.AutoSize = True
        Me.chkModeOfTransportAll.Location = New System.Drawing.Point(6, 19)
        Me.chkModeOfTransportAll.Name = "chkModeOfTransportAll"
        Me.chkModeOfTransportAll.Size = New System.Drawing.Size(37, 17)
        Me.chkModeOfTransportAll.TabIndex = 2
        Me.chkModeOfTransportAll.Text = "All"
        Me.chkModeOfTransportAll.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboDestination)
        Me.GroupBox3.Controls.Add(Me.chkDestinationAll)
        Me.GroupBox3.Location = New System.Drawing.Point(468, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(167, 64)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Destination"
        '
        'cboDestination
        '
        Me.cboDestination.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDestination.FormattingEnabled = True
        Me.cboDestination.IntegralHeight = False
        Me.cboDestination.Location = New System.Drawing.Point(6, 36)
        Me.cboDestination.Name = "cboDestination"
        Me.cboDestination.Size = New System.Drawing.Size(155, 23)
        Me.cboDestination.TabIndex = 40
        '
        'chkDestinationAll
        '
        Me.chkDestinationAll.AutoSize = True
        Me.chkDestinationAll.Location = New System.Drawing.Point(6, 19)
        Me.chkDestinationAll.Name = "chkDestinationAll"
        Me.chkDestinationAll.Size = New System.Drawing.Size(37, 17)
        Me.chkDestinationAll.TabIndex = 2
        Me.chkDestinationAll.Text = "All"
        Me.chkDestinationAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkRefNoAll)
        Me.GroupBox2.Controls.Add(Me.txtRefNo)
        Me.GroupBox2.Location = New System.Drawing.Point(295, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 64)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reference No."
        '
        'chkRefNoAll
        '
        Me.chkRefNoAll.AutoSize = True
        Me.chkRefNoAll.Location = New System.Drawing.Point(6, 19)
        Me.chkRefNoAll.Name = "chkRefNoAll"
        Me.chkRefNoAll.Size = New System.Drawing.Size(37, 17)
        Me.chkRefNoAll.TabIndex = 2
        Me.chkRefNoAll.Text = "All"
        Me.chkRefNoAll.UseVisualStyleBackColor = True
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(6, 36)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(155, 20)
        Me.txtRefNo.TabIndex = 1
        '
        'dtgMasterBooking
        '
        Me.dtgMasterBooking.AllowUserToAddRows = False
        Me.dtgMasterBooking.AllowUserToDeleteRows = False
        Me.dtgMasterBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgMasterBooking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgMasterBooking.Location = New System.Drawing.Point(0, 114)
        Me.dtgMasterBooking.Name = "dtgMasterBooking"
        Me.dtgMasterBooking.ReadOnly = True
        Me.dtgMasterBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgMasterBooking.Size = New System.Drawing.Size(1018, 357)
        Me.dtgMasterBooking.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboLoadType)
        Me.GroupBox6.Controls.Add(Me.chkLoadTypeAll)
        Me.GroupBox6.Location = New System.Drawing.Point(814, 19)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(167, 64)
        Me.GroupBox6.TabIndex = 136
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Load Type"
        '
        'cboLoadType
        '
        Me.cboLoadType.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoadType.FormattingEnabled = True
        Me.cboLoadType.IntegralHeight = False
        Me.cboLoadType.Location = New System.Drawing.Point(6, 36)
        Me.cboLoadType.Name = "cboLoadType"
        Me.cboLoadType.Size = New System.Drawing.Size(155, 23)
        Me.cboLoadType.TabIndex = 40
        '
        'chkLoadTypeAll
        '
        Me.chkLoadTypeAll.AutoSize = True
        Me.chkLoadTypeAll.Location = New System.Drawing.Point(6, 19)
        Me.chkLoadTypeAll.Name = "chkLoadTypeAll"
        Me.chkLoadTypeAll.Size = New System.Drawing.Size(37, 17)
        Me.chkLoadTypeAll.TabIndex = 2
        Me.chkLoadTypeAll.Text = "All"
        Me.chkLoadTypeAll.UseVisualStyleBackColor = True
        '
        'frmSearchExportMasterBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 471)
        Me.Controls.Add(Me.dtgMasterBooking)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSearchExportMasterBooking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Master Booking"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgMasterBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkDestinationAll As CheckBox
    Friend WithEvents chkRefNoAll As CheckBox
    Friend WithEvents txtRefNo As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboModeOfTransport As ComboBox
    Friend WithEvents chkModeOfTransportAll As CheckBox
    Friend WithEvents cboDestination As ComboBox
    Friend WithEvents dtgMasterBooking As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cboLoadType As ComboBox
    Friend WithEvents chkLoadTypeAll As CheckBox
End Class
