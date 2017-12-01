Imports MasterProject

Public Class frmImportBookingMonitoring
    Implements ICommonFunction

    Public Sub NewRecord() Implements ICommonFunction.NewRecord

    End Sub

    Public Sub EditRecord() Implements ICommonFunction.EditRecord

    End Sub

    Public Sub SaveRecord() Implements ICommonFunction.SaveRecord

    End Sub

    Public Sub ResetRecord() Implements ICommonFunction.ResetRecord

    End Sub

    Public Sub PrintPreview() Implements ICommonFunction.PrintPreview

    End Sub

    Public Sub SearchRecord() Implements ICommonFunction.SearchRecord

    End Sub

    Public Sub PostRecord() Implements ICommonFunction.PostRecord

    End Sub

    Public Sub CancelRecord() Implements ICommonFunction.CancelRecord

    End Sub

    Public Sub ReOpenRecord() Implements ICommonFunction.ReOpenRecord

    End Sub

    Private EnableButtons As New clsEnableToolstripObjects()
    Private Sub ChangeEnabledButtons(ByVal blNew As Boolean, ByVal blEdit As Boolean, ByVal blSave As Boolean, ByVal blReset As Boolean,
                                     ByVal blPrintPreview As Boolean, ByVal blPost As Boolean, ByVal blCancel As Boolean,
                                     ByVal blReOpen As Boolean, ByVal blUserInput As Boolean)
        With EnableButtons
            .NewEnabled = blNew
            .EditEnabled = blEdit
            .SaveEnabled = blSave
            .ResetEnabled = blReset
            .PrintPreviewEnabled = blPrintPreview
            .PostEnabled = blPost
            .CancelEnabled = blCancel

            .UpdateEnabledButtons()
        End With
    End Sub

    Private Sub frmImportBookingMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeEnabledButtons(False, False, False, True, False, False, False, False, False)
    End Sub

    Private Sub frmImportBookingMonitoring_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        EnableButtons.UpdateEnabledButtons()
    End Sub

    Private Sub frmImportBookingMonitoring_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ChangeEnabledButtons(False, False, False, False, False, False, False, False, False)
    End Sub
End Class