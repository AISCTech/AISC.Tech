Public Class clsEnableToolstripObjects

    Private _blNew As Boolean
    Property NewEnabled As Boolean
        Get
            Return _blNew
        End Get
        Set(value As Boolean)
            _blNew = value
        End Set
    End Property

    Private _blEdit As Boolean
    Property EditEnabled As Boolean
        Get
            Return _blEdit
        End Get
        Set(value As Boolean)
            _blEdit = value
        End Set
    End Property

    Private _blSave As Boolean
    Property SaveEnabled As Boolean
        Get
            Return _blSave
        End Get
        Set(value As Boolean)
            _blSave = value
        End Set
    End Property

    Private _blReset As Boolean
    Property ResetEnabled As Boolean
        Get
            Return _blReset
        End Get
        Set(value As Boolean)
            _blReset = value
        End Set
    End Property

    Private _blPrintPreview As Boolean
    Property PrintPreviewEnabled As Boolean
        Get
            Return _blPrintPreview
        End Get
        Set(value As Boolean)
            _blPrintPreview = value
        End Set
    End Property

    Private _blSearch As Boolean
    Property SearchEnabled As Boolean
        Get
            Return _blSearch
        End Get
        Set(value As Boolean)
            _blSearch = value
        End Set
    End Property

    Private _blPost As Boolean
    Property PostEnabled As Boolean
        Get
            Return _blPost
        End Get
        Set(value As Boolean)
            _blPost = value
        End Set
    End Property

    Private _blCancel As Boolean
    Property CancelEnabled As Boolean
        Get
            Return _blCancel
        End Get
        Set(value As Boolean)
            _blCancel = value
        End Set
    End Property

    Private _blReOpen As Boolean
    Property ReOpen As Boolean
        Get
            Return _blReOpen
        End Get
        Set(value As Boolean)
            _blReOpen = value
        End Set
    End Property

    Public Sub UpdateEnabledButtons()
        With mdiMain
            .NewToolStripButton.Enabled = _blNew
            .NewToolStripMenuItem.Enabled = _blNew
            .EditToolStripButton.Enabled = _blEdit
            .EditToolStripMenuItem.Enabled = _blEdit
            .SaveToolStripButton.Enabled = _blSave
            .SaveToolStripMenuItem.Enabled = _blSave
            .ResetToolStripButton.Enabled = _blReset
            .ResetToolStripMenuItem.Enabled = _blReset
            .PrintPreviewToolStripButton.Enabled = _blPrintPreview
            .PrintPreviewToolStripMenuItem.Enabled = _blPrintPreview
            .SearchToolStripButton.Enabled = _blSearch
            .SearchToolStripMenuItem.Enabled = _blSearch
            .PostToolStripButton.Enabled = _blPost
            .PostToolStripMenuItem.Enabled = _blPost
            .CancelToolStripButton.Enabled = _blCancel
            .CancelToolStripMenuItem.Enabled = _blCancel
            .ReOpenToolStripButton.Enabled = _blReOpen
            .ReOpenToolStripMenuItem.Enabled = _blReOpen
        End With
    End Sub
End Class
