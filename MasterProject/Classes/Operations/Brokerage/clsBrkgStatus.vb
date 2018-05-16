Public Class clsBrkgStatusType
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strDescription As String
    Property _Description As String
        Get
            Return strDescription
        End Get
        Set(value As String)
            strDescription = value
        End Set
    End Property
End Class

Public Class clsBrkgStatusList
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private clsStatusType As New clsBrkgStatusType
    Property _StatusTypeDetails As clsBrkgStatusType
        Get
            Return clsStatusType
        End Get
        Set(value As clsBrkgStatusType)
            clsStatusType = value
        End Set
    End Property

    Private intStatOrder As Integer
    Property _StatOrder As Integer
        Get
            Return intStatOrder
        End Get
        Set(value As Integer)
            intStatOrder = value
        End Set
    End Property

    Private strStatName As String
    Property _StatName As String
        Get
            Return strStatName
        End Get
        Set(value As String)
            strStatName = value
        End Set
    End Property
End Class
