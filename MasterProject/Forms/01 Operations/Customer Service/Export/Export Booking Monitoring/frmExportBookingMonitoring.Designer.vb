<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportBookingMonitoring
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportBookingMonitoring))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Air")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sea")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LCL", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Air")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sea")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FCL", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7})
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Destination")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Coload")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Client")
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optStatusOpen = New System.Windows.Forms.RadioButton()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.optDate = New System.Windows.Forms.RadioButton()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.trvSelection = New System.Windows.Forms.TreeView()
        Me.lblTreeViewNote = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.dtgBooking = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtgBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 92)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optStatusOpen)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.optDate)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(382, 79)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Options"
        '
        'optStatusOpen
        '
        Me.optStatusOpen.Location = New System.Drawing.Point(6, 19)
        Me.optStatusOpen.Name = "optStatusOpen"
        Me.optStatusOpen.Size = New System.Drawing.Size(72, 51)
        Me.optStatusOpen.TabIndex = 0
        Me.optStatusOpen.TabStop = True
        Me.optStatusOpen.Text = "All open bookings"
        Me.optStatusOpen.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Location = New System.Drawing.Point(168, 24)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(121, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From"
        '
        'dtpTo
        '
        Me.dtpTo.Enabled = False
        Me.dtpTo.Location = New System.Drawing.Point(168, 43)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpTo.TabIndex = 11
        '
        'optDate
        '
        Me.optDate.Location = New System.Drawing.Point(102, 19)
        Me.optDate.Name = "optDate"
        Me.optDate.Size = New System.Drawing.Size(49, 51)
        Me.optDate.TabIndex = 6
        Me.optDate.TabStop = True
        Me.optDate.UseVisualStyleBackColor = True
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 92)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(915, 5)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "box_unchecked_over.ico")
        Me.ImageList1.Images.SetKeyName(1, "box_grayed_over.ico")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.trvSelection)
        Me.Panel2.Controls.Add(Me.lblTreeViewNote)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(258, 393)
        Me.Panel2.TabIndex = 3
        '
        'trvSelection
        '
        Me.trvSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvSelection.ImageIndex = 0
        Me.trvSelection.ImageList = Me.ImageList1
        Me.trvSelection.Location = New System.Drawing.Point(0, 13)
        Me.trvSelection.Name = "trvSelection"
        TreeNode1.Name = "ndeLCLAll"
        TreeNode1.Text = "All"
        TreeNode2.Name = "ndeLCLAir"
        TreeNode2.Text = "Air"
        TreeNode3.Name = "ndeLCLSea"
        TreeNode3.Text = "Sea"
        TreeNode4.Name = "ndeLCL"
        TreeNode4.Text = "LCL"
        TreeNode5.Name = "ndeFCLAll"
        TreeNode5.Text = "All"
        TreeNode6.Name = "ndeFCLAir"
        TreeNode6.Text = "Air"
        TreeNode7.Name = "ndeFCLSea"
        TreeNode7.Text = "Sea"
        TreeNode8.Name = "ndeFCL"
        TreeNode8.Text = "FCL"
        TreeNode9.Name = "ndeDestination"
        TreeNode9.Text = "Destination"
        TreeNode10.Name = "ndeCoload"
        TreeNode10.Text = "Coload"
        TreeNode11.Name = "ndeClient"
        TreeNode11.Text = "Client"
        Me.trvSelection.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Me.trvSelection.SelectedImageIndex = 0
        Me.trvSelection.ShowNodeToolTips = True
        Me.trvSelection.Size = New System.Drawing.Size(258, 380)
        Me.trvSelection.TabIndex = 4
        '
        'lblTreeViewNote
        '
        Me.lblTreeViewNote.AutoSize = True
        Me.lblTreeViewNote.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTreeViewNote.Location = New System.Drawing.Point(0, 0)
        Me.lblTreeViewNote.Name = "lblTreeViewNote"
        Me.lblTreeViewNote.Size = New System.Drawing.Size(39, 13)
        Me.lblTreeViewNote.TabIndex = 3
        Me.lblTreeViewNote.Text = "Label1"
        '
        'Splitter2
        '
        Me.Splitter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter2.Location = New System.Drawing.Point(258, 97)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(5, 393)
        Me.Splitter2.TabIndex = 4
        Me.Splitter2.TabStop = False
        '
        'dtgBooking
        '
        Me.dtgBooking.AllowUserToAddRows = False
        Me.dtgBooking.AllowUserToDeleteRows = False
        Me.dtgBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBooking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgBooking.Location = New System.Drawing.Point(263, 97)
        Me.dtgBooking.Name = "dtgBooking"
        Me.dtgBooking.ReadOnly = True
        Me.dtgBooking.Size = New System.Drawing.Size(652, 393)
        Me.dtgBooking.TabIndex = 5
        '
        'frmExportBookingMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 490)
        Me.Controls.Add(Me.dtgBooking)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmExportBookingMonitoring"
        Me.Text = "Export Booking Monitoring"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtgBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents trvSelection As TreeView
    Friend WithEvents lblTreeViewNote As Label
    Friend WithEvents Splitter2 As Splitter
    Friend WithEvents dtgBooking As DataGridView
    Friend WithEvents optStatusOpen As RadioButton
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents optDate As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label4 As Label
End Class
