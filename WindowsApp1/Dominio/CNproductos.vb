Imports Persistencia

Public Class CNproductos
    Dim cdProductos As New CDproductos()

    Public Function mostrarProductos() As DataTable

        Return cdProductos.MostrarProd()
    End Function

    Public Function mostrarReporte(mes As Object) As DataTable
        Return cdProductos.MostrarReporteMes(mes)
    End Function

    Public Function ListarCategorias() As DataTable
        Return cdProductos.ListarCategoria()
    End Function

    Public Function ListarNombres(categoria As Object) As DataTable

        Return cdProductos.ListarNombre(categoria)
    End Function

    Public Sub InsertarProductos(nombre As Object, precio As Object, categoria As Object)
        cdProductos.Insertar(nombre, precio, categoria)
    End Sub

    Public Sub EditarProductos(Id As Object, nombre As Object, precio As Object, categoria As Object)
        cdProductos.Editar(Id, nombre, precio, categoria)
    End Sub

    Public Sub EliminarProductos(ID As Object)

        cdProductos.Eliminar(ID)
    End Sub
End Class
