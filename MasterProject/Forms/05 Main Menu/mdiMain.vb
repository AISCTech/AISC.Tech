Imports System.Windows.Forms

Public Class mdiMain

    Dim blIfNotLogout As Boolean = True

    Private Sub NewRecord(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            Try
                DirectCast(Me.ActiveMdiChild, ICommonFunction).NewRecord()
            Catch ex As Exception
                MsgBox("Error" & ex.Message & ex.ToString, vbInformation, "Error")
            End Try
        End If
    End Sub

    Private Sub EditRecord(ByVal sender As Object, ByVal e As EventArgs) Handles EditToolStripMenuItem.Click, EditToolStripButton.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).EditRecord()
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub mdiMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim clsDB As New clsDBTrans
        ListOfStatus = clsDB.PopulateListOfStatus

        Me.Text = strSystemName & " v. " & strSystemVersion & " " & CurrentUser._Company_Name
    End Sub

    Private Sub cmdOperations_Click(sender As Object, e As EventArgs) Handles cmdOperations.Click
        Me.lblMenuTitle.Text = "OPERATIONS"
        Dim MyNode() As TreeNode

        With trvMenu
            .Nodes.Clear()
            'Customer Service
            .Nodes.Add("1.1", "Customer Service")
            'Export CS
            MyNode = .Nodes.Find("1.1", True)
            MyNode(0).Nodes.Add("1.1.1", "Export Customer Service")
            MyNode = .Nodes.Find("1.1.1", True)
            MyNode(0).Nodes.Add("1.1.1.1", "Export Booking Menu")
            MyNode(0).Nodes.Add("1.1.1.2", "Export Master Booking Menu")
            MyNode(0).Nodes.Add("1.1.1.3", "Export Co-Load Sequence")
            MyNode(0).Nodes.Add("1.1.1.4", "Export Monitoring Sheet")
            MyNode(0).Nodes.Add("1.1.1.5", "Export Shipping/Flight Details")
            'Import CS
            MyNode = .Nodes.Find("1.1", True)
            MyNode(0).Nodes.Add("1.1.2", "Import Customer Service")
            MyNode = .Nodes.Find("1.1.2", True)
            MyNode(0).Nodes.Add("1.1.2.1", "Import Booking Menu")
            MyNode(0).Nodes.Add("1.1.2.2", "Import Booking Monitoring")
            'Domestic CS
            MyNode = .Nodes.Find("1.1", True)
            MyNode(0).Nodes.Add("1.1.3", "Domestic Customer Service")
            MyNode = .Nodes.Find("1.1.3", True)
            MyNode(0).Nodes.Add("1.1.3.1", "Domestic Booking Menu")

            'Documentation
            .Nodes.Add("1.2", "Documentation")
            'Export Docs
            MyNode = .Nodes.Find("1.2", True)
            MyNode(0).Nodes.Add("1.2.1", "Export Documentation")
            MyNode = .Nodes.Find("1.2.1", True)
            MyNode(0).Nodes.Add("1.2.1.1", "Export Air Waybill")
            MyNode(0).Nodes.Add("1.2.1.2", "Export Bill of Lading")
            MyNode(0).Nodes.Add("1.2.1.3", "Export Proof of Delivery")
            MyNode(0).Nodes.Add("1.2.1.4", "Export Trans Shipment")
            MyNode(0).Nodes.Add("1.2.1.5", "Export Proforma FCL")
            MyNode(0).Nodes.Add("1.2.1.6", "Export Proforma LCL")
            'Import Docs
            MyNode = .Nodes.Find("1.2", True)
            MyNode(0).Nodes.Add("1.2.2", "Import Documentation")
            MyNode = .Nodes.Find("1.2.2", True)
            MyNode(0).Nodes.Add("1.2.2.1", "Import Documentation Menu")

            'Brokerage
            .Nodes.Add("1.3", "Brokerage")
            MyNode = .Nodes.Find("1.3", True)
            MyNode(0).Nodes.Add("1.3.1", "Brokerage Status Update/Monitoring")
            MyNode(0).Nodes.Add("1.3.2", "Processor Monitoring")

            'Trucking
            .Nodes.Add("1.4", "Trucking")
            MyNode = .Nodes.Find("1.4", True)
            MyNode(0).Nodes.Add("1.4.1", "Trip Monitoring")
            MyNode(0).Nodes.Add("1.4.2", "Container Status Update/Monitoring")
            MyNode(0).Nodes.Add("1.4.3", "Chassis Status Update/Monitoring")
            MyNode(0).Nodes.Add("1.4.4", "Trucking Daily Report")
            MyNode(0).Nodes.Add("1.4.5", "Trip Ticket Summary")
            MyNode(0).Nodes.Add("1.4.6", "Truck Summary")
            MyNode(0).Nodes.Add("1.4.7", "Driver Summary")
            MyNode(0).Nodes.Add("1.4.8", "P.O. Summary")

            'Reports
            .Nodes.Add("1.5", "Reports")
            MyNode = .Nodes.Find("1.5", True)
            MyNode(0).Nodes.Add("1.5.1", "...")
            MyNode(0).Nodes.Add("1.5.2", "...")
            MyNode(0).Nodes.Add("1.5.3", "...")
        End With
    End Sub

    Private Sub cmdAccounting_Click(sender As Object, e As EventArgs) Handles cmdAccounting.Click
        Me.lblMenuTitle.Text = "ACCOUNTING"
        Dim MyNode() As TreeNode

        With trvMenu
            .Nodes.Clear()
            'Cash Disbursement
            .Nodes.Add("2.1", "Cash Disbursement")
            MyNode = .Nodes.Find("2.1", True)
            MyNode(0).Nodes.Add("2.1.1", "Request for Payment")
            MyNode(0).Nodes.Add("2.1.2", "Accounts Payables Voucher")
            MyNode(0).Nodes.Add("2.1.3", "Check/MC Voucher")
            MyNode(0).Nodes.Add("2.1.4", "Petty Cash Voucher")

            'Billing
            .Nodes.Add("2.2", "Billing")
            MyNode = .Nodes.Find("2.2", True)
            MyNode(0).Nodes.Add("2.2.1", "Invoice Billing")
            MyNode(0).Nodes.Add("2.2.1.1", "Import")
            MyNode(0).Nodes.Add("2.2.1.2", "Export")
            MyNode(0).Nodes.Add("2.2.2", "S.O.A Billing")
            MyNode(0).Nodes.Add("2.2.2.1", "Import")
            MyNode(0).Nodes.Add("2.2.2.2", "Export")

            MyNode(0).Nodes.Add("2.2.3", "...")

            'OR/AR
            .Nodes.Add("2.3", "Collection")
            MyNode = .Nodes.Find("2.3", True)
            MyNode(0).Nodes.Add("2.3.1", "Official Receipt")
            MyNode(0).Nodes.Add("2.3.2", "Acknowledgment Receipt")
            MyNode(0).Nodes.Add("2.3.3", "Container Refund")
            MyNode(0).Nodes.Add("2.3.4", "Acknowledgment Receipt - Container Refund")



            'Reports
            .Nodes.Add("2.4", "Reports")
            MyNode = .Nodes.Find("2.4", True)
            MyNode(0).Nodes.Add("2.4.1", "...")
            MyNode(0).Nodes.Add("2.4.2", "...")
            MyNode(0).Nodes.Add("2.4.3", "...")
        End With
    End Sub

    Private Sub cmdMaintenance_Click(sender As Object, e As EventArgs) Handles cmdMaintenance.Click
        Me.lblMenuTitle.Text = "MAINTENANCE"
        Dim MyNode() As TreeNode

        With trvMenu
            .Nodes.Clear()

            'User Accounts
            .Nodes.Add("3.1", "User Accounts")
            MyNode = .Nodes.Find("3.1", True)
            MyNode(0).Nodes.Add("3.1.1", "...")
            MyNode(0).Nodes.Add("3.1.2", "...")
            MyNode(0).Nodes.Add("3.1.3", "...")

            'Company
            .Nodes.Add("3.3", "Company")
            MyNode = .Nodes.Find("3.3", True)
            MyNode(0).Nodes.Add("3.3.1", "...")
            MyNode(0).Nodes.Add("3.3.2", "...")
            MyNode(0).Nodes.Add("3.3.3", "Manage Service Offered per Company")

            'Email Addresses
            .Nodes.Add("3.2", "Email Addresses")
            MyNode = .Nodes.Find("3.2", True)
            MyNode(0).Nodes.Add("3.2.1", "Manage Email Addresses")
            MyNode(0).Nodes.Add("3.2.2", "Assign Email Per Module")
            MyNode(0).Nodes.Add("3.2.3", "...")

            'Forms Registration
            .Nodes.Add("3.4", "Forms Registration Menu")
        End With
    End Sub

    Private Sub trvMenu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvMenu.AfterSelect

    End Sub

    Private Sub trvMenu_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles trvMenu.NodeMouseDoubleClick
        Dim ChildForm As New System.Windows.Forms.Form

        If trvMenu.SelectedNode IsNot Nothing Then
            Select Case _NotNull(trvMenu.SelectedNode.Name, "")
                Case "1.1.1.1"
                    ChildForm = frmExportBookingMenu
                Case "1.1.1.2"
                    ChildForm = frmExportMasterBooking
                Case "1.1.2.1"
                    ChildForm = frmImportBookingMenu
                Case "1.1.2.2"
                    ChildForm = frmImportBookingMonitoring
                Case "2.1.1"
                    ChildForm = frmRequest
                Case "2.1.2"
                    ChildForm = frmAPV
                Case "2.1.4"
                    ChildForm = frmPCV
                Case "2.2.1.1"
                    ChildForm = frmInvoice
                Case "2.2.1.2"
                    ChildForm = frmInvoiceExport
                Case "2.2.2.1"
                    ChildForm = frmSOA
                Case "2.2.2.2"
                    ChildForm = frmSOAExport
                Case "2.3.1"
                    ChildForm = frmOfficialReceipt
                Case "2.3.2"
                    ChildForm = frmAcknowledgementReceipt
                Case "2.3.3"
                    ChildForm = frmContainerRefund
                Case "2.3.4"
                    ChildForm = frmARContRef
                Case "3.2.1"
                    ChildForm = frmManageEmailAddresses
                Case "3.2.2"
                    ChildForm = frmModuleEmail
                Case "3.3.3"
                    ChildForm = frmCompanyServiceOffered
                Case "3.4"
                    ChildForm = frmRegForm
                Case Else
                    Exit Sub
            End Select
            ShowChildForm(ChildForm)
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click, SaveToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).SaveRecord()
        End If
    End Sub

    Private Sub ResetToolStripButton_Click(sender As Object, e As EventArgs) Handles ResetToolStripButton.Click, ResetToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).ResetRecord()
        End If
    End Sub

    Private Sub PrintPreviewToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripButton.Click, PrintPreviewToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).PrintPreview()
        End If
    End Sub

    Private Sub PostToolStripButton_Click(sender As Object, e As EventArgs) Handles PostToolStripButton.Click, PostToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).PostRecord()
        End If
    End Sub

    Private Sub CancelToolStripButton_Click(sender As Object, e As EventArgs) Handles CancelToolStripButton.Click, CancelToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).CancelRecord()
        End If
    End Sub

    Private Sub ReOpenToolStripButton_Click(sender As Object, e As EventArgs) Handles ReOpenToolStripButton.Click, ReOpenToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).ReOpenRecord()
        End If
    End Sub

    Private Sub SearchToolStripButton_Click(sender As Object, e As EventArgs) Handles SearchToolStripButton.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            DirectCast(Me.ActiveMdiChild, ICommonFunction).SearchRecord()
        End If
    End Sub

    Private Sub cmdLogout_Click(sender As Object, e As EventArgs) Handles cmdLogout.Click
        blIfNotLogout = False
        frmLogoutOptions.ShowDialog()
        blIfNotLogout = True
    End Sub

    Private Sub mdiMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If blIfNotLogout = True Then
            If MsgBox("Are you sure you want to close application?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Closing Application") = MsgBoxResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub HelpToolStripButton_Click(sender As Object, e As EventArgs) Handles HelpToolStripButton.Click

    End Sub
End Class
