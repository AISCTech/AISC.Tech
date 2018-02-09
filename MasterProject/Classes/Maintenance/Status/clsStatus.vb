Public Class clsStatus
    Private intStatus_ID As Integer
    Property _Status_ID As Integer
        Get
            Return intStatus_ID
        End Get
        Set(value As Integer)
            intStatus_ID = value
        End Set
    End Property

    Private strStatus_Name As String
    Property _Status_Name As String
        Get
            Return strStatus_Name
        End Get
        Set(value As String)
            strStatus_Name = value
        End Set
    End Property

    Private intStatus_ColorR As Integer
    Property _Status_ColorR As Integer
        Get
            Return intStatus_ColorR
        End Get
        Set(value As Integer)
            intStatus_ColorR = value
        End Set
    End Property

    Private intStatus_ColorG As Integer
    Property _Status_ColorG As Integer
        Get
            Return intStatus_ColorG
        End Get
        Set(value As Integer)
            intStatus_ColorG = value
        End Set
    End Property

    Private intStatus_ColorB As Integer
    Property _Status_ColorB As Integer
        Get
            Return intStatus_ColorB
        End Get
        Set(value As Integer)
            intStatus_ColorB = value
        End Set
    End Property
End Class
