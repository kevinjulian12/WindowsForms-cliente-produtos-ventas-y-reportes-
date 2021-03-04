Imports Persistencia
Public Class CNventas
    Dim cdVentas As New CDventas()

    Private idtext As String
    Public Property IdTex() As String
        Get
            Return idtext
        End Get
        Set(ByVal value As String)
            idtext = value
        End Set
    End Property

    Public Function mostrarHistVent(IdCliente As Object) As DataTable
        Return cdVentas.MostrarHistVent(IdCliente)
    End Function

    Public Function mostrarReporte() As DataTable
        Return cdVentas.MostrarReporte()
    End Function

    Public Function InsertarVenta(idcliente As Object, fecha As DateTime, total As Object)
        Return cdVentas.Insertar(idcliente, fecha, total)
    End Function

    Public Sub Eliminar(ID As Object)
        cdVentas.EliminarHist(ID)
    End Sub
End Class
