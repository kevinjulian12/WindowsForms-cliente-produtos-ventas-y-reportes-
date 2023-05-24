Imports Negocio.interface
Imports Negocio.Etidades
Imports Infraestructura.Repositorio


Public Class CoreProducto
    Implements IProductoNegocio

    Private data As New RepositorioProductos

    Public Function Update(EtidadesProductos As EntidadesProductos) As String Implements IProductoNegocio.Update
        Try
            data.Update(EtidadesProductos.CodProducto, EtidadesProductos.Nombre, EtidadesProductos.Precio, EtidadesProductos.Categoria)
            Return "Producto actualizado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Delete(Id As Integer) As String Implements IProductoNegocio.Delete
        Try
            data.Delete(Id)
            Return "Producto eliminado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Insert(EtidadesProductos As EntidadesProductos) As String Implements IProductoNegocio.Insert
        Try
            data.Insert(EtidadesProductos.Nombre, EtidadesProductos.Precio, EtidadesProductos.Categoria)
            Return "Nuevo producto insertado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function

    Public Function Read(EtidadesProductos As EntidadesProductos) As List(Of EntidadesProductos) Implements IProductoNegocio.Read
        Try
            Dim ListEntidadesProductos As List(Of EntidadesProductos) = New List(Of EntidadesProductos)
            Dim tabla As DataTable = data.Read(EtidadesProductos.CodProducto, EtidadesProductos.Nombre, EtidadesProductos.Precio, EtidadesProductos.Categoria)
            For Each row As DataRow In tabla.Rows
                Dim Entidades As EntidadesProductos = New EntidadesProductos
                Entidades.CodProducto = row(0)
                Entidades.Nombre = row(1)
                Entidades.Precio = row(2)
                Entidades.Categoria = row(3)
                ListEntidadesProductos.Add(Entidades)
            Next
            Return ListEntidadesProductos
        Catch ex As Exception

        End Try
    End Function
End Class
