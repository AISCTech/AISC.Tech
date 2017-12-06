Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Public Class frmReportReplenish
    Dim ForReplenishment As String
    Dim ForEncashment As Double
    Dim Unliquidated As String
    Dim FundKey As String
    Dim RevolvingFund As Double
    Public TotalReleased As Double = 0, TotalPosted As Double = 0
    Private Sub frmReportReplenish_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If MsgBox("Print summary of PCV for this replenishment?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "System Message") = MsgBoxResult.Yes Then
            Application.DoEvents()
            frmReplenishmentPCVSummarry.ShowDialog()
        End If
    End Sub

    Private Sub frmReportReplenish_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Replenishment Report For " & frmPettyCashReplenishment.txtName.Text

        LoadReport()
    End Sub
    Public Sub ComputeForEncashment()
        Dim cmdSQL As New MySqlCommand
        Dim strSQL As String

        strSQL = "SELECT tbl_pcv_replenish.FundCode, SUM(tbl_pcv_replenish.Amount), tbl_pcv_replenish.Replenish " &
                 "FROM tbl_pcv_replenish " &
                 "WHERE tbl_pcv_replenish.Replenish = 0 and tbl_pcv_replenish.FundCode ='" & FundKey & "' " &
        "GROUP BY tbl_pcv_replenish.FundCode"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmd2 = New MySqlCommand(strSQL, cnnDBMaster)
        Dim reader2 As MySqlDataReader = cmd2.ExecuteReader()

        While reader2.Read
            ForEncashment = reader2.Item("SUM(tbl_pcv_replenish.Amount)")
        End While

        cmd2.Dispose()
        reader2.Close()
        cnnDBMaster.Close()
    End Sub
    Private Sub RetreiveRevolving()
        Dim strsql As String
        TotalPosted = 0
        TotalReleased = 0
        FundKey = frmPettyCashReplenishment.txtFundCode.Text
        ComputeForEncashment()

        strsql = "SELECT REQ_TotalAmt, REQ_LiquidatedAmount FROM tbl_request WHERE REQ_Liquidated = TRUE AND REQ_PCVRepSave = FALSE AND REQ_PCVRepFund = '" & FundKey & "' and REQ_ReqType = 1"

        If cnnDBMaster.State <> ConnectionState.Open Then cnnDBMaster.Open()

        Dim cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        Dim reader As MySqlDataReader = cmdsql.ExecuteReader

        While reader.Read
            If reader.Item("REQ_LiquidatedAmt") = 0 Then
                TotalPosted = TotalPosted + reader.Item("REQ_TotalAmt")
            Else
                TotalPosted = TotalPosted + reader.Item("REQ_LiquidatedAmt")
            End If
        End While

        reader.Close()

        'Retreive Released
        strsql = "SELECT REQ_TotalAmt FROM tbl_request WHERE REQ_Release = TRUE AND REQ_Liquidated = FALSE AND REQ_Cancel = FALSE AND REQ_PCVRepSave = FALSE AND REQ_PCVRepFund = '" & FundKey & "'"

        cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        reader = cmdsql.ExecuteReader

        While reader.Read
            If IsDBNull(reader.Item("REQ_TotalAmt")) = False Then TotalReleased = TotalReleased + reader.Item("REQ_TotalAmt")
        End While
        reader.Close()
        'Retreive Revolving Fund
        strsql = "SELECT * FROM lib_pcv_fund WHERE FundCode = '" & FundKey & "'"

        cmdsql = New MySqlCommand(strsql, cnnDBMaster)
        reader = cmdsql.ExecuteReader

        While reader.Read
            RevolvingFund = reader.Item("FundRevFund")
        End While

        reader.Close()
        cmdsql.Dispose()
        cnnDBMaster.Close()


    End Sub

    Private Sub LoadReport()
        RetreiveRevolving()
        Dim CR As New ReportDocument
        'CR.Load(GetReportPath("rptPCVReplenish.rpt"))
        CR.Load("D:\Backup\System Codes\MasterProject\MasterProject\reports\rptPCVReplenishNew.rpt")

        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldLocation As ParameterFieldDefinition
        Dim crParameterValues As ParameterValues

        crParameterFieldDefinitions = CR.DataDefinition.ParameterFields

        crParameterFieldLocation = crParameterFieldDefinitions.Item("Released")
        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        crParameterDiscreteValue.Value = TotalReleased
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

        crParameterFieldLocation = crParameterFieldDefinitions.Item("Posted")
        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        crParameterDiscreteValue.Value = TotalPosted
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

        crParameterFieldLocation = crParameterFieldDefinitions.Item("ForReplenishment")
        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        crParameterDiscreteValue.Value = 0
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

        crParameterFieldLocation = crParameterFieldDefinitions.Item("ForEncashment")
        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        crParameterDiscreteValue.Value = ForEncashment
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

        crParameterFieldLocation = crParameterFieldDefinitions.Item("RevolvingFund")
        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
        crParameterDiscreteValue.Value = RevolvingFund
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = CR

        CrystalReportViewer1.SelectionFormula() = "{tbl_request.REQ_PCVRepFundKey}='" & frmPettyCashReplenishment.txtName.Text & "'and {tbl_pcv_replenish.RepNumber}='" & frmPettyCashReplenishment.txtName.Text & "'"

    End Sub
End Class