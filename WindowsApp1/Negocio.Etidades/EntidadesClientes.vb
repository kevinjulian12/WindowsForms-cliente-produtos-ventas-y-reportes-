Public Class EntidadesClientes

    Private ID As Integer
    Private Cliente1 As String
    Private Telefono1 As String
    Private Correo1 As String

    Public Property CodCliente As Integer
        Get
            Return ID
        End Get
        Set(value As Integer)
            ID = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return Cliente1
        End Get
        Set(value As String)
            Cliente1 = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return Telefono1
        End Get
        Set(value As String)
            Telefono1 = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return Correo1
        End Get
        Set(value As String)
            Correo1 = value
        End Set
    End Property
End Class
