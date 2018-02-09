<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetrieveContainerDepositRequest
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.dtToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtFromDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.optPC = New System.Windows.Forms.RadioButton()
        Me.optMC = New System.Windows.Forms.RadioButton()
        Me.optCheck = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdPrintPrev = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btClose
        '
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.ForeColor = System.Drawing.Color.DarkBlue
        Me.btClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btClose.Location = New System.Drawing.Point(553, 584)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(82, 24)
        Me.btClose.TabIndex = 1232
        Me.btClose.Text = "Close"
        Me.btClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightCoral
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(116, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 12)
        Me.Label1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(126, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Not Liquidated/Posted"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Liquidated/Posted"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(12, 91)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(523, 20)
        Me.txtSearch.TabIndex = 1237
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 12)
        Me.Label3.TabIndex = 1230
        Me.Label3.Text = "Double Click to Select Transaction"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(527, 35)
        Me.GroupBox1.TabIndex = 1231
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Legend"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightGreen
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Location = New System.Drawing.Point(243, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 12)
        Me.Label6.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(256, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Already Billed"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 12)
        Me.Label2.TabIndex = 1
        '
        'cmdLoad
        '
        Me.cmdLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoad.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdLoad.Location = New System.Drawing.Point(545, 21)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(89, 48)
        Me.cmdLoad.TabIndex = 1235
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'dtToDate
        '
        Me.dtToDate.Location = New System.Drawing.Point(301, 19)
        Me.dtToDate.Name = "dtToDate"
        Me.dtToDate.Size = New System.Drawing.Size(200, 20)
        Me.dtToDate.TabIndex = 320
        Me.dtToDate.Value = New Date(2015, 6, 10, 9, 56, 7, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(272, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 319
        Me.Label9.Text = "To:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(381, 13)
        Me.Label10.TabIndex = 1236
        Me.Label10.Text = "Search by Booking No., Payee Name, Shipper/Consignee, Container No./HBL:"
        '
        'dtFromDate
        '
        Me.dtFromDate.Location = New System.Drawing.Point(55, 19)
        Me.dtFromDate.Name = "dtFromDate"
        Me.dtFromDate.Size = New System.Drawing.Size(200, 20)
        Me.dtFromDate.TabIndex = 318
        Me.dtFromDate.Value = New Date(2015, 6, 10, 9, 56, 0, 0)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtToDate)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.dtFromDate)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(527, 53)
        Me.GroupBox3.TabIndex = 1234
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 317
        Me.Label8.Text = "From:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DataGridView1.Location = New System.Drawing.Point(12, 170)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(622, 408)
        Me.DataGridView1.TabIndex = 1229
        '
        'optPC
        '
        Me.optPC.AutoSize = True
        Me.optPC.Location = New System.Drawing.Point(160, 24)
        Me.optPC.Name = "optPC"
        Me.optPC.Size = New System.Drawing.Size(76, 17)
        Me.optPC.TabIndex = 295
        Me.optPC.Text = "Petty Cash"
        Me.optPC.UseVisualStyleBackColor = True
        '
        'optMC
        '
        Me.optMC.AutoSize = True
        Me.optMC.Location = New System.Drawing.Point(96, 24)
        Me.optMC.Name = "optMC"
        Me.optMC.Size = New System.Drawing.Size(41, 17)
        Me.optMC.TabIndex = 295
        Me.optMC.Text = "MC"
        Me.optMC.UseVisualStyleBackColor = True
        '
        'optCheck
        '
        Me.optCheck.AutoSize = True
        Me.optCheck.Checked = True
        Me.optCheck.Location = New System.Drawing.Point(16, 24)
        Me.optCheck.Name = "optCheck"
        Me.optCheck.Size = New System.Drawing.Size(56, 17)
        Me.optCheck.TabIndex = 295
        Me.optCheck.TabStop = True
        Me.optCheck.Text = "Check"
        Me.optCheck.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optPC)
        Me.GroupBox2.Controls.Add(Me.optMC)
        Me.GroupBox2.Controls.Add(Me.optCheck)
        Me.GroupBox2.Location = New System.Drawing.Point(672, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 53)
        Me.GroupBox2.TabIndex = 1228
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Transaction"
        Me.GroupBox2.Visible = False
        '
        'cmdPrintPrev
        '
        Me.cmdPrintPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintPrev.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdPrintPrev.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdPrintPrev.Location = New System.Drawing.Point(12, 588)
        Me.cmdPrintPrev.Name = "cmdPrintPrev"
        Me.cmdPrintPrev.Size = New System.Drawing.Size(93, 20)
        Me.cmdPrintPrev.TabIndex = 1233
        Me.cmdPrintPrev.Text = "Print Preview"
        Me.cmdPrintPrev.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPrintPrev.UseVisualStyleBackColor = True
        '
        'frmRetrieveContainerDepositRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 615)
        Me.ControlBox = False
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdPrintPrev)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmRetrieveContainerDepositRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retrieve Container Deposit Request"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmdLoad As Button
    Friend WithEvents dtToDate As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dtFromDate As DateTimePicker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents optPC As RadioButton
    Friend WithEvents optMC As RadioButton
    Friend WithEvents optCheck As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdPrintPrev As Button
End Class
