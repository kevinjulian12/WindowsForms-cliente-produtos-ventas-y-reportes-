Imports Persistencia
Public Class CNventas
    Dim cdVentas As New CDventas()

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
