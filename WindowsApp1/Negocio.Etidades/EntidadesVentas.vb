Public Class EntidadesVentas

    Private ID As Long
    Private IDCliente As Long
    Private Fecha As DateTime
    Private Total As Double

    Public Property ID1 As Long
        Get
            Return ID
        End Get
        Set(value As Long)
            ID = value
        End Set
    End Property

    Public Property IDCliente1 As Long
        Get
            Return IDCliente
        End Get
        Set(value As Long)
            IDCliente = value
        End Set
    End Property

    Public Property Fecha1 As Date
        Get
            Return Fecha
        End Get
        Set(value As Date)
            Fecha = value
        End Set
    End Property

    Public Property Total1 As Double
        Get
            Return Total
        End Get
        Set(value As Double)
            Total = value
        End Set
    End Property
End Class
