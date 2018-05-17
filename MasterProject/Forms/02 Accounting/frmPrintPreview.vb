Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPrintPreview
    Private Sub frmPrintPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub LoadAPV()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim strReqType As String = ""
        Dim dtcurrent As Date = GetServerDate()
        Dim strRefNo As String = ""

        Dim CR As New ReportDocument
        Dim amount As String

        amount = frmAPV.txtAmtInWords.Text

        'CR.Load(GetReportPath("rptAPVCAdmin.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptAPV.rpt")

        If frmAPV.optCheck.Checked = True Then
            strReqType = "(CHEQUE)"
        End If

        If frmAPV.optMC.Checked = True Then
            strReqType = "(MANAGER'S CHEQUE)"
        End If

        crParameterDiscreteValue.Value = amount
        crParameterFieldDefinitions =
            CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
    crParameterFieldDefinitions.Item("AmtInWords")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = dtcurrent
        crParameterFieldDefinitions =
            CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
    crParameterFieldDefinitions.Item("PrintDate")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = strReqType
        crParameterFieldDefinitions =
            CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
    crParameterFieldDefinitions.Item("strReqType")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = CR

        CrystalReportViewer1.SelectionFormula() = "{tbl_apv.APV_Nbr}='" & frmAPV.lblAPVNbr.Text & "'"
    End Sub


    Public Sub LoadRequestADM(ByVal str As String, ByVal strReqType As String)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim dtCurrent As Date = GetServerDate()
        Dim CR As New ReportDocument
        Dim strRequestType As String = ""
        Select Case strReqType
            Case "Check"
                strRequestType = "Check Request For Payment"
            Case "MC"
                strRequestType = "Manager's Check Request For Payment"
            Case "Petty Cash"
                strRequestType = "Petty Cash Request For Payment"
        End Select

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptRequestADM.rpt")

        crParameterDiscreteValue.Value = strRequestType
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strRequestType")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Format(dtCurrent, "yyyy-MM-dd hh:mm:ss")
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDatePrint")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = frmRequest.txtAmtInWords.Text
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strAmtInWords")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = CR

        CrystalReportViewer1.SelectionFormula() = "{tbl_request.REQ_Nbr} ='" & str & "'"

    End Sub

    Public Sub LoadRequestADMPO(ByVal str As String)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim dtCurrent As Date = GetServerDate()
        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptRequestADMPO.rpt")

        crParameterDiscreteValue.Value = frmPurchaseOrderDetails.txtDeliverTo.Text
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDeliveryTo")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Format(frmPurchaseOrderDetails.dtDeliver.Value, "yyyy-MM-dd")
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDeliveryOn")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = frmPurchaseOrderDetails.cboTerms.Text
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strTerms")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Format(dtCurrent, "yyyy-MM-dd")
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDate")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = frmPurchaseOrderDetails.txtRemarks.Text
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strRemarks")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


        crParameterDiscreteValue.Value = frmRequest.txtAmtInWords.Text
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strAmtInWords")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = frmPurchaseOrderDetails.txtRequestedBy.Text
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strRequestedBy")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = CR

        CrystalReportViewer1.SelectionFormula() = "{tbl_request.REQ_Nbr}='" & str & "'"
    End Sub

    Private Sub PrintExpCI()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument
        Dim amount As String
        amount = frmPCVCheckRequest.txtAmtInWords.Text

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        'CR.Load("D:\backup12102013\Systems and Codes\Current Systems\AISC\Implemented\2015-06.09 Container Deposit Summary\rptExpCI.rpt")

        With frmInvoiceExport
            crParameterDiscreteValue.Value = .txtBookingNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtShipper.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Shipper")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtBilledTo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BilledTo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtClient.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("Cnee")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtShprAddr.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CneeAddr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtOriginDest.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("OrigDest")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtWgtMeas.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("WtMeas")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDescOfGoods.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CgoDesc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            '    crParameterDiscreteValue.Value = .txtHBL.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("HBL")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtVessel.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("Carrier")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtETD.Text & " / " & .txtETA.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("ETAETD")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CurrentDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            'crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            If frmInvoiceExport.cboCurrency.Text = "USD" Then
                crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text / .txtExrateDollar.Text), "n2")
            Else
                crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            End If
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("VAT")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(CDbl(.txtExrateDollar.Text), "n2")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ExRate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'Dim dblAmt As Double = CDbl(.txtInvTotal.Text) + CDbl(.txtTotalVat.Text)

            'If .cboCurrency.Text = "Dollars" Then
            '    dblAmt = 0
            '    For introw = 0 To .dtgServiceCharge.Rows.Count - 1
            '        If .dtgServiceCharge.Rows(introw).Cells(.colSTerms.Name).Value = "Charge Invoice" Then
            '            dblAmt = dblAmt + .dtgServiceCharge.Rows(introw).Cells(.colSSellingRate.Name).Value
            '        End If
            '    Next
            'End If

            '    crParameterDiscreteValue.Value = English(CDec(Format$(dblAmt, "n2")), .cboCurrency.Text)
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("AmtInWords")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub
End Class