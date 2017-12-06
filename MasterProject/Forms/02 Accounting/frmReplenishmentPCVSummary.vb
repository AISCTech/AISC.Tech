
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmReplenishmentPCVSummarry
    Private Sub frmReplenishmentPCVSummarry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReport()
    End Sub

    Private Sub LoadReport()
        Dim dtCurrent As Date = GetServerDate()

        Dim CR As New ReportDocument

        'CR.Load(GetReportPath("rptPCRepPCRSummary.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptPCRepPCRSummaryNew.rpt")

        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldLocation As ParameterFieldDefinition
        Dim crParameterValues As ParameterValues

        crParameterFieldDefinitions = CR.DataDefinition.ParameterFields

        crParameterFieldLocation = crParameterFieldDefinitions.Item("PrintDate")
        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        crParameterDiscreteValue.Value = Format(dtCurrent, "MM/dd/yyyy")
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = CR

        CrystalReportViewer1.SelectionFormula() = "{tbl_request.REQ_PCVRepFundKey}='" & frmPettyCashReplenishment.txtName.Text & "'"

    End Sub
End Class