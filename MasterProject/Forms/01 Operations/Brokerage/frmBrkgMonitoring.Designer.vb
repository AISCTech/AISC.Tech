<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrkgMonitoring
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblWithStatus = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCompleted = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblNoStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optShowAll = New System.Windows.Forms.RadioButton()
        Me.chkCompleted = New System.Windows.Forms.CheckBox()
        Me.chkWithStatus = New System.Windows.Forms.CheckBox()
        Me.chkNoStatus = New System.Windows.Forms.CheckBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.optDate = New System.Windows.Forms.RadioButton()
        Me.dtgBrkgMonitoring = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCancelled = New System.Windows.Forms.Label()
        Me.chkCancelled = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgBrkgMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 105)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblCancelled)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblWithStatus)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblCompleted)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblNoStatus)
        Me.GroupBox2.Location = New System.Drawing.Point(633, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(257, 79)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Color Legend"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(127, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "With Status (Incomplete)"
        '
        'lblWithStatus
        '
        Me.lblWithStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblWithStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWithStatus.Location = New System.Drawing.Point(108, 27)
        Me.lblWithStatus.Name = "lblWithStatus"
        Me.lblWithStatus.Size = New System.Drawing.Size(14, 14)
        Me.lblWithStatus.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Completed"
        '
        'lblCompleted
        '
        Me.lblCompleted.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCompleted.Location = New System.Drawing.Point(15, 47)
        Me.lblCompleted.Name = "lblCompleted"
        Me.lblCompleted.Size = New System.Drawing.Size(14, 14)
        Me.lblCompleted.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "No Status"
        '
        'lblNoStatus
        '
        Me.lblNoStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNoStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNoStatus.Location = New System.Drawing.Point(15, 27)
        Me.lblNoStatus.Name = "lblNoStatus"
        Me.lblNoStatus.Size = New System.Drawing.Size(14, 14)
        Me.lblNoStatus.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCancelled)
        Me.GroupBox1.Controls.Add(Me.optShowAll)
        Me.GroupBox1.Controls.Add(Me.chkCompleted)
        Me.GroupBox1.Controls.Add(Me.chkWithStatus)
        Me.GroupBox1.Controls.Add(Me.chkNoStatus)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.optDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(615, 79)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Options"
        '
        'optShowAll
        '
        Me.optShowAll.Location = New System.Drawing.Point(287, 19)
        Me.optShowAll.Name = "optShowAll"
        Me.optShowAll.Size = New System.Drawing.Size(72, 51)
        Me.optShowAll.TabIndex = 16
        Me.optShowAll.Text = "Show All"
        Me.optShowAll.UseVisualStyleBackColor = True
        '
        'chkCompleted
        '
        Me.chkCompleted.AutoSize = True
        Me.chkCompleted.Checked = True
        Me.chkCompleted.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompleted.Location = New System.Drawing.Point(386, 46)
        Me.chkCompleted.Name = "chkCompleted"
        Me.chkCompleted.Size = New System.Drawing.Size(76, 17)
        Me.chkCompleted.TabIndex = 15
        Me.chkCompleted.Text = "Completed"
        Me.chkCompleted.UseVisualStyleBackColor = True
        '
        'chkWithStatus
        '
        Me.chkWithStatus.AutoSize = True
        Me.chkWithStatus.Checked = True
        Me.chkWithStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWithStatus.Location = New System.Drawing.Point(465, 24)
        Me.chkWithStatus.Name = "chkWithStatus"
        Me.chkWithStatus.Size = New System.Drawing.Size(142, 17)
        Me.chkWithStatus.TabIndex = 14
        Me.chkWithStatus.Text = "With Status (Incomplete)"
        Me.chkWithStatus.UseVisualStyleBackColor = True
        '
        'chkNoStatus
        '
        Me.chkNoStatus.AutoSize = True
        Me.chkNoStatus.Checked = True
        Me.chkNoStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoStatus.Location = New System.Drawing.Point(386, 24)
        Me.chkNoStatus.Name = "chkNoStatus"
        Me.chkNoStatus.Size = New System.Drawing.Size(73, 17)
        Me.chkNoStatus.TabIndex = 2
        Me.chkNoStatus.Text = "No Status"
        Me.chkNoStatus.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Location = New System.Drawing.Point(73, 24)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From"
        '
        'dtpTo
        '
        Me.dtpTo.Enabled = False
        Me.dtpTo.Location = New System.Drawing.Point(73, 43)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpTo.TabIndex = 11
        '
        'optDate
        '
        Me.optDate.Checked = True
        Me.optDate.Location = New System.Drawing.Point(7, 19)
        Me.optDate.Name = "optDate"
        Me.optDate.Size = New System.Drawing.Size(49, 51)
        Me.optDate.TabIndex = 6
        Me.optDate.TabStop = True
        Me.optDate.UseVisualStyleBackColor = True
        '
        'dtgBrkgMonitoring
        '
        Me.dtgBrkgMonitoring.AllowUserToAddRows = False
        Me.dtgBrkgMonitoring.AllowUserToDeleteRows = False
        Me.dtgBrkgMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBrkgMonitoring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgBrkgMonitoring.Location = New System.Drawing.Point(0, 105)
        Me.dtgBrkgMonitoring.Name = "dtgBrkgMonitoring"
        Me.dtgBrkgMonitoring.ReadOnly = True
        Me.dtgBrkgMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgBrkgMonitoring.Size = New System.Drawing.Size(898, 368)
        Me.dtgBrkgMonitoring.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(127, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Cancelled"
        '
        'lblCancelled
        '
        Me.lblCancelled.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCancelled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCancelled.Location = New System.Drawing.Point(108, 47)
        Me.lblCancelled.Name = "lblCancelled"
        Me.lblCancelled.Size = New System.Drawing.Size(14, 14)
        Me.lblCancelled.TabIndex = 6
        '
        'chkCancelled
        '
        Me.chkCancelled.AutoSize = True
        Me.chkCancelled.Checked = True
        Me.chkCancelled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCancelled.Location = New System.Drawing.Point(465, 46)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.Size = New System.Drawing.Size(73, 17)
        Me.chkCancelled.TabIndex = 17
        Me.chkCancelled.Text = "Cancelled"
        Me.chkCancelled.UseVisualStyleBackColor = True
        '
        'frmBrkgMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 473)
        Me.Controls.Add(Me.dtgBrkgMonitoring)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmBrkgMonitoring"
        Me.Text = "Brokerage Monitoring"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgBrkgMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblWithStatus As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblCompleted As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblNoStatus As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents optShowAll As RadioButton
    Friend WithEvents chkCompleted As CheckBox
    Friend WithEvents chkWithStatus As CheckBox
    Friend WithEvents chkNoStatus As CheckBox
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents optDate As RadioButton
    Friend WithEvents dtgBrkgMonitoring As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCancelled As Label
    Friend WithEvents chkCancelled As CheckBox
End Class
