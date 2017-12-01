<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddBookingContainer
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
        Me.dtPickup = New System.Windows.Forms.DateTimePicker()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtgContainer = New System.Windows.Forms.DataGridView()
        Me.colPK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContainerSizeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContainerSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPickup = New System.Windows.Forms.TextBox()
        Me.txtDelivery = New System.Windows.Forms.TextBox()
        Me.dtDelivery = New System.Windows.Forms.DateTimePicker()
        Me.chkPickupTBA = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkDeliveryTBA = New System.Windows.Forms.CheckBox()
        CType(Me.dtgContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtPickup
        '
        Me.dtPickup.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtPickup.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtPickup.Location = New System.Drawing.Point(213, 21)
        Me.dtPickup.Name = "dtPickup"
        Me.dtPickup.Size = New System.Drawing.Size(108, 20)
        Me.dtPickup.TabIndex = 33
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(122, 136)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(292, 20)
        Me.txtFilter.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Search"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(106, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = ":"
        '
        'dtgContainer
        '
        Me.dtgContainer.AllowUserToAddRows = False
        Me.dtgContainer.AllowUserToDeleteRows = False
        Me.dtgContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgContainer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPK, Me.colContainerNo, Me.colContainerSizeID, Me.colContainerSize})
        Me.dtgContainer.Location = New System.Drawing.Point(15, 162)
        Me.dtgContainer.Name = "dtgContainer"
        Me.dtgContainer.ReadOnly = True
        Me.dtgContainer.Size = New System.Drawing.Size(399, 213)
        Me.dtgContainer.TabIndex = 42
        '
        'colPK
        '
        Me.colPK.HeaderText = "PK"
        Me.colPK.Name = "colPK"
        Me.colPK.ReadOnly = True
        Me.colPK.Visible = False
        '
        'colContainerNo
        '
        Me.colContainerNo.HeaderText = "Container No."
        Me.colContainerNo.Name = "colContainerNo"
        Me.colContainerNo.ReadOnly = True
        Me.colContainerNo.Width = 200
        '
        'colContainerSizeID
        '
        Me.colContainerSizeID.HeaderText = "Size ID"
        Me.colContainerSizeID.Name = "colContainerSizeID"
        Me.colContainerSizeID.ReadOnly = True
        Me.colContainerSizeID.Visible = False
        '
        'colContainerSize
        '
        Me.colContainerSize.HeaderText = "Size"
        Me.colContainerSize.Name = "colContainerSize"
        Me.colContainerSize.ReadOnly = True
        '
        'txtPickup
        '
        Me.txtPickup.Location = New System.Drawing.Point(29, 21)
        Me.txtPickup.Name = "txtPickup"
        Me.txtPickup.ReadOnly = True
        Me.txtPickup.Size = New System.Drawing.Size(185, 20)
        Me.txtPickup.TabIndex = 43
        '
        'txtDelivery
        '
        Me.txtDelivery.Location = New System.Drawing.Point(29, 19)
        Me.txtDelivery.Name = "txtDelivery"
        Me.txtDelivery.ReadOnly = True
        Me.txtDelivery.Size = New System.Drawing.Size(185, 20)
        Me.txtDelivery.TabIndex = 45
        '
        'dtDelivery
        '
        Me.dtDelivery.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.dtDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtDelivery.Location = New System.Drawing.Point(213, 19)
        Me.dtDelivery.Name = "dtDelivery"
        Me.dtDelivery.Size = New System.Drawing.Size(108, 20)
        Me.dtDelivery.TabIndex = 44
        '
        'chkPickupTBA
        '
        Me.chkPickupTBA.AutoSize = True
        Me.chkPickupTBA.Location = New System.Drawing.Point(327, 23)
        Me.chkPickupTBA.Name = "chkPickupTBA"
        Me.chkPickupTBA.Size = New System.Drawing.Size(47, 17)
        Me.chkPickupTBA.TabIndex = 46
        Me.chkPickupTBA.Text = "TBA"
        Me.chkPickupTBA.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPickup)
        Me.GroupBox1.Controls.Add(Me.chkPickupTBA)
        Me.GroupBox1.Controls.Add(Me.dtPickup)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 56)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pickup Date"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDeliveryTBA)
        Me.GroupBox2.Controls.Add(Me.txtDelivery)
        Me.GroupBox2.Controls.Add(Me.dtDelivery)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(399, 56)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delivery Date"
        '
        'chkDeliveryTBA
        '
        Me.chkDeliveryTBA.AutoSize = True
        Me.chkDeliveryTBA.Location = New System.Drawing.Point(327, 21)
        Me.chkDeliveryTBA.Name = "chkDeliveryTBA"
        Me.chkDeliveryTBA.Size = New System.Drawing.Size(47, 17)
        Me.chkDeliveryTBA.TabIndex = 47
        Me.chkDeliveryTBA.Text = "TBA"
        Me.chkDeliveryTBA.UseVisualStyleBackColor = True
        '
        'frmAddBookingContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 385)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgContainer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddBookingContainer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Container"
        CType(Me.dtgContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtPickup As DateTimePicker
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtgContainer As DataGridView
    Friend WithEvents txtPickup As TextBox
    Friend WithEvents txtDelivery As TextBox
    Friend WithEvents dtDelivery As DateTimePicker
    Friend WithEvents colPK As DataGridViewTextBoxColumn
    Friend WithEvents colContainerNo As DataGridViewTextBoxColumn
    Friend WithEvents colContainerSizeID As DataGridViewTextBoxColumn
    Friend WithEvents colContainerSize As DataGridViewTextBoxColumn
    Friend WithEvents chkPickupTBA As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkDeliveryTBA As CheckBox
End Class
