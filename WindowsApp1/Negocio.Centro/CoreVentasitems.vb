Imports Negocio.interface
Imports Negocio.Etidades
Imports Infraestructura.Repositorio


Public Class CoreVentasitems
    Implements IVentasitemsNegocio

    Public Function Delete(Id As Integer) Implements IVentasitemsNegocio.Delete
        Try
            Dim data As New RepositorioVentasitems
            data.Delete(Id)
            Return "Detalle de venta eliminado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Insert(EtidadesVentasitems As EntidadesVentasitems) Implements IVentasitemsNegocio.Insert
        Try
            Dim data As New RepositorioVentasitems
            data.Insert(EtidadesVentasitems.IDVenta1, EtidadesVentasitems.IDProducto1, EtidadesVentasitems.PrecioUnitario1, EtidadesVentasitems.Cantidad1, EtidadesVentasitems.PrecioTotal1)
            Return "Detalle de venta insertado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function

    Public Function Read(EtidadesVentasitems As EntidadesVentasitems) As DataTable Implements IVentasitemsNegocio.Read
        Try
            Dim data As New RepositorioVentasitems
            Return data.Read(EtidadesVentasitems.ID1, EtidadesVentasitems.IDVenta1, EtidadesVentasitems.IDProducto1, EtidadesVentasitems.PrecioUnitario1, EtidadesVentasitems.Cantidad1, EtidadesVentasitems.PrecioTotal1)
        Catch ex As Exception

        End Try
    End Function
End Class
