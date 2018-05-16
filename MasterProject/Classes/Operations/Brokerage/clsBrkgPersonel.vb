Public Class clsBrkgPersonelType
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
    Property _Description As String '
        Get
            Return strDescription
        End Get
        Set(value As String)
            strDescription = value
        End Set
    End Property
End Class

Public Class clsBrkgPersonelList
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private clsType As New clsBrkgPersonelType
    Property _TypeDetails As clsBrkgPersonelType
        Get
            Return clsType
        End Get
        Set(value As clsBrkgPersonelType)
            clsType = value
        End Set
    End Property

    Private clsPersonel As New clsUserAccount
    Property _PersonelDetails As clsUserAccount
        Get
            Return clsPersonel
        End Get
        Set(value As clsUserAccount)
            clsPersonel = value
        End Set
    End Property

    Private blActive As Boolean
    Property _Active As Boolean
        Get
            Return blActive
        End Get
        Set(value As Boolean)
            blActive = value
        End Set
    End Property
End Class
