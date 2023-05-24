Public Class EntidadesVentasitems

    Private ID As Long
    Private IDVenta As Long
    Private IDProducto As Long
    Private PrecioUnitario As Double
    Private Cantidad As Integer
    Private PrecioTotal As Double

    Public Property ID1 As Long
        Get
            Return ID
        End Get
        Set(value As Long)
            ID = value
        End Set
    End Property

    Public Property IDVenta1 As Long
        Get
            Return IDVenta
        End Get
        Set(value As Long)
            IDVenta = value
        End Set
    End Property

    Public Property IDProducto1 As Long
        Get
            Return IDProducto
        End Get
        Set(value As Long)
            IDProducto = value
        End Set
    End Property

    Public Property PrecioUnitario1 As Double
        Get
            Return PrecioUnitario
        End Get
        Set(value As Double)
            PrecioUnitario = value
        End Set
    End Property

    Public Property Cantidad1 As Integer
        Get
            Return Cantidad
        End Get
        Set(value As Integer)
            Cantidad = value
        End Set
    End Property

    Public Property PrecioTotal1 As Double
        Get
            Return PrecioTotal
        End Get
        Set(value As Double)
            PrecioTotal = value
        End Set
    End Property
End Class
