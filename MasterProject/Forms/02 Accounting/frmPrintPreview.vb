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

    Public Sub PrintExpCI()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptExpCI.rpt")

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtBookingNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETD.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("pETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintExpCI_S()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptExpCIS.rpt")

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtBookingNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETD.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("pETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CINo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ' CrystalReportViewer1.SelectionFormula() = "{bill_expinv_main.RefNo}= '" & .lblRefNo.Text & "'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintExpCI_D()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptExpCID.rpt")

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtBookingNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETD.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("pETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            ' CrystalReportViewer1.SelectionFormula() = "{bill_expinv_main.RefNo}= '" & .lblRefNo.Text & "'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintExpSOA()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptExpSOA.rpt")

        With frmSOAExport
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
            '    If frmInvoiceExport.cboCurrency.Text = "USD" Then
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text / .txtExrateDollar.Text), "n2")
            '    Else
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    End If
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("VAT")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtBookingNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("totalsoa")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETD.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("pETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintExpSOA_S()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptExpSOAS.rpt")

        With frmSOAExport
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


            '    'crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    If frmInvoiceExport.cboCurrency.Text = "USD" Then
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text / .txtExrateDollar.Text), "n2")
            '    Else
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    End If
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("VAT")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtBookingNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("totalsoa")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETD.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("pETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SOANo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ' CrystalReportViewer1.SelectionFormula() = "{bill_expinv_main.RefNo}= '" & .lblRefNo.Text & "'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintExpSOA_D()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptExpSOAD.rpt")

        With frmSOAExport
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


            '    'crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    If frmInvoiceExport.cboCurrency.Text = "USD" Then
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text / .txtExrateDollar.Text), "n2")
            '    Else
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    End If
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("VAT")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtBookingNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("totalsoa")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETD.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("pETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SOANo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ' CrystalReportViewer1.SelectionFormula() = "{bill_expinv_main.RefNo}= '" & .lblRefNo.Text & "'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpBCI()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpBCI.rpt")

        With frmInvoice
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

            crParameterDiscreteValue.Value = .txtConsignee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETA.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CINo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtWgtMeas.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Msrmnt")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpBCI_S()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpBCIS.rpt")

        With frmInvoice
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

            crParameterDiscreteValue.Value = .txtConsignee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETA.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CINo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtWgtMeas.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("Msrmnt")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpBCI_D()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpBCID.rpt")

        With frmInvoice
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

            crParameterDiscreteValue.Value = .txtConsignee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETA.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CINo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtWgtMeas.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("Msrmnt")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpBSOA()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpBSOA.rpt")

        With frmSOA
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

            crParameterDiscreteValue.Value = .txtConsignee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtShprAddr.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("CneeAddr")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETA.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            '    'crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    If frmInvoiceExport.cboCurrency.Text = "USD" Then
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text / .txtExrateDollar.Text), "n2")
            '    Else
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    End If
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("VAT")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = Format$(CDbl(.txtExrateDollar.Text), "n2")
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("ExRate")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SOANo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtWgtMeas.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("Msrmnt")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpBSOA_S()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpBSOAS.rpt")

        With frmSOA
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

            crParameterDiscreteValue.Value = .txtConsignee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtShprAddr.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("CneeAddr")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETA.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            '    'crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    If frmInvoiceExport.cboCurrency.Text = "USD" Then
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text / .txtExrateDollar.Text), "n2")
            '    Else
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    End If
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("VAT")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = Format$(CDbl(.txtExrateDollar.Text), "n2")
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("ExRate")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SOANo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtWgtMeas.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("Msrmnt")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpBSOA_D()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'ais
        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptExpCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpBSOAD.rpt")

        With frmSOA
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

            crParameterDiscreteValue.Value = .txtConsignee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtShprAddr.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("CneeAddr")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtETA.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            '    'crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    If frmInvoiceExport.cboCurrency.Text = "USD" Then
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text / .txtExrateDollar.Text), "n2")
            '    Else
            '        crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalVat.Text), "n2")
            '    End If
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("VAT")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = Format$(CDbl(.txtExrateDollar.Text), "n2")
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("ExRate")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

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


            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("AmtInWords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .lblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboTermsofPayment.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("TermsOfPayment")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.dtPrepDate.Value, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)




            crParameterDiscreteValue.Value = .txtTotalAmtPHP.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("GrandTotal")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strSellingRatePHP As String = ""
            Dim strRemarks As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgServiceCharge.Rows.Count - 1
                h = .dtgServiceCharge.Rows(i)

                If Len(h.Cells(1).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(1).Value
                    strSellingRatePHP = strSellingRatePHP & vbNewLine & h.Cells(6).Value
                    strRemarks = strRemarks & vbNewLine & h.Cells(9).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strRemarks
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Remarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strSellingRatePHP
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SellingRatePHP")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .txtCISOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SOANo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    crParameterDiscreteValue.Value = .txtWgtMeas.Text
            '    crParameterFieldDefinitions =
            '        CR.DataDefinition.ParameterFields
            '    crParameterFieldDefinition =
            'crParameterFieldDefinitions.Item("Msrmnt")
            '    crParameterValues = crParameterFieldDefinition.CurrentValues
            '    crParameterValues.Clear()
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_exp_main.RefNo}= '" & .lblRefNo.Text & "' AND {bill_exp_charges.Type} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpFCI()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptImpFCI.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpFCI.rpt")


        With frmInvoiceImpF
            crParameterDiscreteValue.Value = .txtBookNo.Text
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
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = GetStringValue("Select Addr1 From tbl_client where Description = '" & .txtBilledTo.Text & "'", "Addr1")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CneeAddr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtOrigin.Text & "/" & .txtPortofDischarge.Text
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

            If .optFCL.Checked = True Then
                crParameterDiscreteValue.Value = "FCL"
            ElseIf .optLCL.Checked = True Then
                crParameterDiscreteValue.Value = "LCL"
            Else
                crParameterDiscreteValue.Value = ""
            End If

            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CgoDesc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboMBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("MBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCarrier.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Voy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(.dtArrivalDate.Value, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CurrentDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            Dim VatAmt As Double = 0
            If .PrintCurrency = "PHP" Then
                VatAmt = CDbl(.txtVat.Text)
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format$(VatAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("VAT")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                VatAmt = CDbl(.txtVat.Text) / CDbl(.txtExRate.Text)
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format$(VatAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("VAT")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ExRate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            Dim strChargesDesc As String = ""
            Dim strChargesTotal As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgBilling.Rows.Count - 1
                h = .dtgBilling.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    If h.Cells(1).Value = "Charge Invoice" Then
                        strChargesDesc = strChargesDesc & h.Cells(0).Value & " " & h.Cells(6).Value & "" & vbNewLine & vbNewLine
                        If .PrintCurrency = "PHP" Then
                            strChargesTotal = strChargesTotal & "PHP " & h.Cells(4).Value & vbNewLine & vbNewLine
                        ElseIf .PrintCurrency = "USD" Then
                            'strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(4).Value) / CDbl(.txtExRate.Text), "n2") & vbNewLine & vbNewLine
                            strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(3).Value), "n2") & vbNewLine & vbNewLine
                        End If
                    End If
                End If

            Next


            crParameterDiscreteValue.Value = .tslblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesDesc
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesTotal
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Total")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            If .PrintCurrency = "PHP" Then
                Dim dblAmt As Double = CDbl(.txtInvTotal.Text) + CDbl(.txtVat.Text)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & .txtInvTotal.Text
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(dblAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("GrandTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                Dim dblAmt As Double = (CDbl(.txtInvTotal.Text) + CDbl(.txtVat.Text)) / CDbl(.txtExRate.Text)
                'MsgBox(CDbl(.txtSOA.Text / .txtExRate.Text))
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(CDbl(.txtInvTotal.Text) / CDbl(.txtExRate.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(dblAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("GrandTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            crParameterDiscreteValue.Value = .txtPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_impf_main.RefNo}= '" & .tslblRefNo.Text & "' AND {bill_impf_charges.Terms} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpFCI_S()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpFCIS.rpt")

        With frmInvoiceImpF
            crParameterDiscreteValue.Value = .txtBookNo.Text
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
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = GetStringValue("Select Addr1 From tbl_client where Description = '" & .txtBilledTo.Text & "'", "Addr1")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CneeAddr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtOrigin.Text & "/" & .txtPortofDischarge.Text
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

            If .optFCL.Checked = True Then
                crParameterDiscreteValue.Value = "FCL"
            ElseIf .optLCL.Checked = True Then
                crParameterDiscreteValue.Value = "LCL"
            Else
                crParameterDiscreteValue.Value = ""
            End If

            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CgoDesc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboMBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("MBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCarrier.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Voy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(.dtArrivalDate.Value, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CurrentDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim VatAmt As Double = 0
            If .PrintCurrency = "PHP" Then
                VatAmt = CDbl(.txtVat.Text)
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format$(VatAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("VAT")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                VatAmt = CDbl(.txtVat.Text) / CDbl(.txtExRate.Text)
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format$(VatAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("VAT")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ExRate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            Dim strChargesDesc As String = ""
            Dim strChargesTotal As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgBilling.Rows.Count - 1
                h = .dtgBilling.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    If h.Cells(1).Value = "Charge Invoice" Then
                        strChargesDesc = strChargesDesc & h.Cells(0).Value & " " & h.Cells(6).Value & "" & vbNewLine & vbNewLine
                        If .PrintCurrency = "PHP" Then
                            strChargesTotal = strChargesTotal & "PHP " & h.Cells(4).Value & vbNewLine & vbNewLine
                        ElseIf .PrintCurrency = "USD" Then
                            'strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(4).Value) / CDbl(.txtExRate.Text), "n2") & vbNewLine & vbNewLine
                            strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(3).Value), "n2") & vbNewLine & vbNewLine
                        End If
                    End If
                End If

            Next

            crParameterDiscreteValue.Value = .txtInvNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("InvoiceNum")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.DateSaved, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("DateSaved")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesDesc
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesTotal
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Total")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            If .PrintCurrency = "PHP" Then
                Dim dblAmt As Double = CDbl(.txtInvTotal.Text) + CDbl(.txtVat.Text)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(CDbl(.txtInvTotal.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(dblAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("GrandTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                Dim dblAmt As Double = (CDbl(.txtInvTotal.Text) + CDbl(.txtVat.Text)) / CDbl(.txtExRate.Text)
                'MsgBox(CDbl(.txtSOA.Text / .txtExRate.Text))
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(CDbl(.txtInvTotal.Text) / CDbl(.txtExRate.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(dblAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("GrandTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If
            'CrystalReportViewer2.SelectionFormula() = "{bill_impf_main.RefNo}= '" & .tslblRefNo.Text & "' AND {bill_impf_charges.Terms} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintIMPFCI_D()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpFCID.rpt")

        With frmInvoiceImpF
            crParameterDiscreteValue.Value = .txtBookNo.Text
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
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = GetStringValue("Select Addr1 From tbl_client where Description = '" & .txtBilledTo.Text & "'", "Addr1")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CneeAddr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtOrigin.Text & "/" & .txtPortofDischarge.Text
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

            If .optFCL.Checked = True Then
                crParameterDiscreteValue.Value = "FCL"
            ElseIf .optLCL.Checked = True Then
                crParameterDiscreteValue.Value = "LCL"
            Else
                crParameterDiscreteValue.Value = ""
            End If

            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CgoDesc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboMBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("MBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCarrier.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Voy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(.dtArrivalDate.Value, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CurrentDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim VatAmt As Double = 0
            If .PrintCurrency = "PHP" Then
                VatAmt = CDbl(.txtVat.Text)
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format$(VatAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("VAT")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                VatAmt = CDbl(.txtVat.Text) / CDbl(.txtExRate.Text)
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format$(VatAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("VAT")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ExRate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strChargesDesc As String = ""
            Dim strChargesTotal As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgBilling.Rows.Count - 1
                h = .dtgBilling.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    If h.Cells(1).Value = "Charge Invoice" Then
                        strChargesDesc = strChargesDesc & h.Cells(0).Value & " " & h.Cells(6).Value & "" & vbNewLine & vbNewLine
                        If .PrintCurrency = "PHP" Then
                            strChargesTotal = strChargesTotal & "PHP " & h.Cells(4).Value & vbNewLine & vbNewLine
                        ElseIf .PrintCurrency = "USD" Then
                            'strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(4).Value) / CDbl(.txtExRate.Text), "n2") & vbNewLine & vbNewLine
                            strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(3).Value), "n2") & vbNewLine & vbNewLine
                        End If
                    End If
                End If

            Next

            crParameterDiscreteValue.Value = .txtInvNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("InvoiceNum")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.DateSaved, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("DateSaved")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesDesc
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesTotal
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Total")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            If .PrintCurrency = "PHP" Then
                Dim dblAmt As Double = CDbl(.txtInvTotal.Text) + CDbl(.txtVat.Text)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(CDbl(.txtInvTotal.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(dblAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("GrandTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                Dim dblAmt As Double = (CDbl(.txtInvTotal.Text) + CDbl(.txtVat.Text)) / CDbl(.txtExRate.Text)
                'MsgBox(CDbl(.txtSOA.Text / .txtExRate.Text))
                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(CDbl(.txtInvTotal.Text) / CDbl(.txtExRate.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .PrintCurrency & " " & Format(dblAmt, "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("GrandTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If


            'CrystalReportViewer1.SelectionFormula() = "{bill_impf_main.RefNo}= '" & .tslblRefNo.Text & "' AND {bill_impf_charges.Terms} = 'Charge Invoice'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpFSOA()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpFSOA.rpt")

        With frmSOAImpF
            crParameterDiscreteValue.Value = .txtShipper.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Shipper")
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

            crParameterDiscreteValue.Value = .txtOrigin.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("OrigDest")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .dtArrivalDate.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtBilledTo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CgoDesc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDesc.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Desc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtBookNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CurrentDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboMBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("MBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = GetStringValue("Select Addr1 From tbl_client where Description = '" & .txtBilledTo.Text & "'", "Addr1")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Address")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strChargesDesc As String = ""
            Dim strChargesTotal As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgBilling.Rows.Count - 1
                h = .dtgBilling.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    If h.Cells(1).Value = "S.O.A." Then
                        strChargesDesc = strChargesDesc & h.Cells(0).Value & " " & h.Cells(6).Value & "" & vbNewLine & vbNewLine
                        If .PrintCurrency = "PHP" Then
                            strChargesTotal = strChargesTotal & "PHP " & h.Cells(4).Value & vbNewLine & vbNewLine
                        ElseIf .PrintCurrency = "USD" Then
                            'strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(4).Value) / CDbl(.txtExRate.Text), "n2") & vbNewLine & vbNewLine
                            strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(3).Value), "n2") & vbNewLine & vbNewLine
                        End If
                    End If
                End If

            Next


            crParameterDiscreteValue.Value = .tslblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesDesc
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesTotal
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Total")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            If .PrintCurrency = "PHP" Then
                crParameterDiscreteValue.Value = English(CDec(.txtSOA.Text), "Pesos")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("AmtInWords")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .txtSOA.Text
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                'MsgBox(CDbl(.txtSOA.Text / .txtExRate.Text))
                crParameterDiscreteValue.Value = English(Format(CDbl(.txtSOA.Text / .txtExRate.Text), "n2"), "USD")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("AmtInWords")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = Format(CDbl(.txtSOA.Text) / CDbl(.txtExRate.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            crParameterDiscreteValue.Value = .txtPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_impf_main.RefNo}= '" & .tslblRefNo.Text & "' AND {bill_impf_charges.Terms} = 'S.O.A.'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpFSOA_S()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpFSOAS.rpt")

        With frmSOAImpF
            crParameterDiscreteValue.Value = .txtShipper.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Shipper")
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

            crParameterDiscreteValue.Value = .txtOrigin.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("OrigDest")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .dtArrivalDate.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtBilledTo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CgoDesc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDesc.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Desc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtBookNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CurrentDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboMBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("MBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = GetStringValue("Select Addr1 From tbl_client where Description = '" & .txtBilledTo.Text & "'", "Addr1")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Address")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strChargesDesc As String = ""
            Dim strChargesTotal As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgBilling.Rows.Count - 1
                h = .dtgBilling.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    If h.Cells(1).Value = "S.O.A." Then
                        strChargesDesc = strChargesDesc & h.Cells(0).Value & " " & h.Cells(6).Value & "" & vbNewLine & vbNewLine
                        If .PrintCurrency = "PHP" Then
                            strChargesTotal = strChargesTotal & "PHP " & h.Cells(4).Value & vbNewLine & vbNewLine
                        ElseIf .PrintCurrency = "USD" Then
                            'strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(4).Value) / CDbl(.txtExRate.Text), "n2") & vbNewLine & vbNewLine
                            strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(3).Value), "n2") & vbNewLine & vbNewLine
                        End If
                    End If
                End If

            Next

            crParameterDiscreteValue.Value = .txtSOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SOANo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.DateSaved, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("DateSaved")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesDesc
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesTotal
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Total")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            If .PrintCurrency = "PHP" Then
                crParameterDiscreteValue.Value = English(CDec(.txtSOA.Text), "Pesos")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("AmtInWords")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .txtSOA.Text
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                'MsgBox(CDbl(.txtSOA.Text / .txtExRate.Text))
                crParameterDiscreteValue.Value = English(Format(CDbl(.txtSOA.Text / .txtExRate.Text), "n2"), "USD")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("AmtInWords")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = Format(CDbl(.txtSOA.Text) / CDbl(.txtExRate.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If


            crParameterDiscreteValue.Value = .txtPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer2.SelectionFormula() = "{bill_impf_main.RefNo}= '" & .tslblRefNo.Text & "' AND {bill_impf_charges.Terms} = 'S.O.A.'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintIMPFSOA_D()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImpFSOAD.rpt")

        With frmSOAImpF
            crParameterDiscreteValue.Value = .txtShipper.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Shipper")
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

            crParameterDiscreteValue.Value = .txtOrigin.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("OrigDest")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .dtArrivalDate.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("ETAETD")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtVessel.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Carrier")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtBilledTo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Cnee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = ""
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CgoDesc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDesc.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Desc")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtBookNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("BookNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("CurrentDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboMBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("MBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("HBL")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = GetStringValue("Select Addr1 From tbl_client where Description = '" & .txtBilledTo.Text & "'", "Addr1")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Address")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strChargesDesc As String = ""
            Dim strChargesTotal As String = ""
            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To .dtgBilling.Rows.Count - 1
                h = .dtgBilling.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    If h.Cells(1).Value = "S.O.A." Then
                        strChargesDesc = strChargesDesc & h.Cells(0).Value & " " & h.Cells(6).Value & "" & vbNewLine & vbNewLine
                        If .PrintCurrency = "PHP" Then
                            strChargesTotal = strChargesTotal & "PHP " & h.Cells(4).Value & vbNewLine & vbNewLine
                        ElseIf .PrintCurrency = "USD" Then
                            'strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(4).Value) / CDbl(.txtExRate.Text), "n2") & vbNewLine & vbNewLine
                            strChargesTotal = strChargesTotal & "USD " & Format(CDbl(h.Cells(3).Value), "n2") & vbNewLine & vbNewLine
                        End If
                    End If
                End If

            Next

            crParameterDiscreteValue.Value = .txtSOANo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("SOANo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format(.DateSaved, "yyyy-MM-dd")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("DateSaved")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .tslblRefNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("RefNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesDesc
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Charges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strChargesTotal
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("Total")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)



            If .PrintCurrency = "PHP" Then
                crParameterDiscreteValue.Value = English(CDec(.txtSOA.Text), "Pesos")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("AmtInWords")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = .txtSOA.Text
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            ElseIf .PrintCurrency = "USD" Then
                'MsgBox(CDbl(.txtSOA.Text / .txtExRate.Text))
                crParameterDiscreteValue.Value = English(Format(CDbl(.txtSOA.Text / .txtExRate.Text), "n2"), "USD")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("AmtInWords")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = Format(CDbl(.txtSOA.Text) / CDbl(.txtExRate.Text), "n2")
                crParameterFieldDefinitions =
                    CR.DataDefinition.ParameterFields
                crParameterFieldDefinition =
            crParameterFieldDefinitions.Item("ChargesTotal")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            crParameterDiscreteValue.Value = .txtPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("PrepBy")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'CrystalReportViewer1.SelectionFormula() = "{bill_impf_main.RefNo}= '" & .tslblRefNo.Text & "' AND {bill_impf_charges.Terms} = 'S.O.A.'"
            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub PrintImpFDCForm()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImportDCAF.rpt")

        With frmAgencyFeeBillingImpF
            crParameterDiscreteValue.Value = .txtHBLCnee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strConsignee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCneeAddr.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strConsigneeAddr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtContNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strContNbr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtWgtMeas.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strVol")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDCRemarks.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strRemarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDRTotal.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strTotalDR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCRTotal.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strTotalCR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = Format(CDbl(.txtDRTotal.Text - .txtCRTotal.Text), "n2")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strTotalDue")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strBLNbr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strDR As String = ""
            Dim strCR As String = ""

            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To frmAgencyFeeBillingImpF.dgDCBillingCharges.Rows.Count - 1
                h = frmAgencyFeeBillingImpF.dgDCBillingCharges.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(0).Value & " { " & h.Cells(8).Value & " }"
                    strDR = strDR & vbNewLine & h.Cells(4).Value
                    strCR = strCR & vbNewLine & h.Cells(7).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strCharges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strDR
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strCR
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strCR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub
    Public Sub PrintImpFDCForm_S()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument


        'CR.Load(GetReportPath("Acctg System Reports\Billing\rptImportDCAF_S.rpt"))

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\Billing\rptImportDCAFS.rpt")

        With frmAgencyFeeBillingImpF
            crParameterDiscreteValue.Value = .txtDRCRNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDRCRNo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtHBLCnee.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strConsignee")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCneeAddr.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strConsigneeAddr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtContNo.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strContNbr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtWgtMeas.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strVol")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = Format$(GetServerDate, "MM-dd-yyyy")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDCRemarks.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strRemarks")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtDRTotal.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strTotalDR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtCRTotal.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strTotalCR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


            crParameterDiscreteValue.Value = Format(CDbl(.txtDRTotal.Text - .txtCRTotal.Text), "n2")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strTotalDue")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .cboHBL.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strBLNbr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim strCharges As String = ""
            Dim strDR As String = ""
            Dim strCR As String = ""

            Dim i As Integer = 0
            Dim h As DataGridViewRow

            For i = 0 To frmAgencyFeeBillingImpF.dgDCBillingCharges.Rows.Count - 1
                h = frmAgencyFeeBillingImpF.dgDCBillingCharges.Rows(i)

                If Len(h.Cells(0).Value) <> 0 Then
                    strCharges = strCharges & vbNewLine & h.Cells(0).Value & " { " & h.Cells(8).Value & " }"
                    strDR = strDR & vbNewLine & h.Cells(4).Value
                    strCR = strCR & vbNewLine & h.Cells(7).Value
                End If

            Next

            crParameterDiscreteValue.Value = strCharges
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strCharges")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strDR
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strDR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strCR
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("strCR")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            CrystalReportViewer1.ReportSource = CR
        End With
    End Sub

    Public Sub loadCheckMCFundReport()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim CR As New ReportDocument


        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptCVFundSummary.rpt")

        CR.Refresh()

        'Check/MC Funding Summary Report

        crParameterDiscreteValue.Value = "Check/MC Funding Summary Report"
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("title")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Format$(frmFundSearch.txtDateFrom.Value, "Short Date")
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("datefrom")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Format$(frmFundSearch.txtDateTo.Value, "Short Date")
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("dateto")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = strCurrentUser
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("prepby")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = CR

        CrystalReportViewer1.SelectionFormula() = "{ap_cv.selected}='" & 1 & "'"
    End Sub

    Public Sub loadCheckMCFundPrintReport()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim CR As New ReportDocument

        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptCheckMCFundPrintSummary.rpt")

        CR.Refresh()

        'Check/MC Funding Summary Report

        crParameterDiscreteValue.Value = "Print Summary Report"
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("title")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Format$(frmChequeMCFund.txtDateFrom.Value, "Short Date")
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("datefrom")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = Format$(frmChequeMCFund.txtDateTo.Value, "Short Date")
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("dateto")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        crParameterDiscreteValue.Value = strCurrentUser
        crParameterFieldDefinitions =
        CR.DataDefinition.ParameterFields
        crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("prepby")
        crParameterValues = crParameterFieldDefinition.CurrentValues
        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = CR

        CrystalReportViewer1.SelectionFormula() = "{ap_cv.selected}='" & 1 & "'"
    End Sub

    Public Sub FundTransferOnline()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'CR.Load(GetReportPath("Acctg System Reports\Books of Account\Cash Disbursement\Fund Transfer\OLFT.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\OLFT.rpt")
        With frmFundTransfer
            crParameterDiscreteValue.Value = "ACESTAR INTERNATIONAL SERVICE CORP."
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("cname")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(.txtPrepDate.Text, "Short Date")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("transdate")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtRemarks.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("purpose")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtFromBankAcct.Text & vbNewLine & .txtFromAcct.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("fromBank")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtToBankAcct.Text & vbNewLine & .txtToAcct.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("toBank")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalAmt.Text), "n2")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("amt")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("amtwords")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = strCurrentUser
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("user")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .lblCVNbr.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("refno")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        End With

        CrystalReportViewer1.ReportSource = CR
    End Sub

    Public Sub FundTransferOffline()
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim CR As New ReportDocument

        'CR.Load(GetReportPath("Acctg System Reports\Books of Account\Cash Disbursement\Fund Transfer\rptFundTransfer.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptFundTransfer.rpt")
        With frmFundTransfer
            crParameterDiscreteValue.Value = .ToCCode.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("to")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .fromCCode.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("from")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtToAcct.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("toAcctNbr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtFromAcct.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("fromAcctNbr")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtToBankAcct.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("toAcctName")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtFromBankAcct.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("fromAcctName")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(CDbl(.txtTotalAmt.Text), "n2")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("amt")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtAmtInWords.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("amtfigures")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtRemarks.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("purpose")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = .txtPrepBy.Text
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("reqby")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterDiscreteValue.Value = Format$(CDate(.txtPrepDate.Text), "Short Date")
            crParameterFieldDefinitions =
                CR.DataDefinition.ParameterFields
            crParameterFieldDefinition =
        crParameterFieldDefinitions.Item("date")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        End With

        CrystalReportViewer1.ReportSource = CR
    End Sub
End Class