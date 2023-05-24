Public Class EntidadesProductos

    Private ID As Integer
    Private Nombre1 As String
    Private Precio1 As Double
    Private Categoria1 As String

    Public Property CodProducto As Integer
        Get
            Return ID
        End Get
        Set(value As Integer)
            ID = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return Nombre1
        End Get
        Set(value As String)
            Nombre1 = value
        End Set
    End Property

    Public Property Precio As Double
        Get
            Return Precio1
        End Get
        Set(value As Double)
            Precio1 = value
        End Set
    End Property

    Public Property Categoria As String
        Get
            Return Categoria1
        End Get
        Set(value As String)
            Categoria1 = value
        End Set
    End Property
End Class
