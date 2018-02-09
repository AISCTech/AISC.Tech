Public Class clsWarehouse
    Private lngID As Long
    Property _ID As Long
        Get
            Return lngID
        End Get
        Set(value As Long)
            lngID = value
        End Set
    End Property

    Private strWarehouseName As String
    Property _WarehouseName As String
        Get
            Return strWarehouseName
        End Get
        Set(value As String)
            strWarehouseName = value
        End Set
    End Property
End Class
