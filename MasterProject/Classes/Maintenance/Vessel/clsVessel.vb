Public Class clsVessel
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strVesselCode As String
    Property _VesselCode As String
        Get
            Return strVesselCode
        End Get
        Set(value As String)
            strVesselCode = value
        End Set
    End Property

    Private strVesselName As String
    Property _VesselName As String
        Get
            Return strVesselName
        End Get
        Set(value As String)
            strVesselName = value
        End Set
    End Property

    Private strCarrierCode As String
    Property _CarrierCode As String
        Get
            Return strCarrierCode
        End Get
        Set(value As String)
            strCarrierCode = value
        End Set
    End Property

    Private strNACCSUserCode As String
    Property _NACCSUserCode As String
        Get
            Return strNACCSUserCode
        End Get
        Set(value As String)
            strNACCSUserCode = value
        End Set
    End Property
End Class
