Imports MasterProject

Public Class frmSalesQuotation
    Implements ICommonFunction
    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blSearch As Boolean, ByVal blPost As Boolean,
                                     ByVal blCancel As Boolean, ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .SearchEnabled = blSearch
            .PostEnabled = blPost
            .CancelEnabled = blCancel
            .ReOpen = blReOpen


            .UpdateEnabledButtons()
        End With
    End Sub
    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub NewRecord() Implements ICommonFunction.NewRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord
        Throw New NotImplementedException()
    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord
        Throw New NotImplementedException()
    End Sub

    Private Sub frmSalesQuotation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmSalesQuotation_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub
End Class