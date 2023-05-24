Imports Negocio.interface
Imports Negocio.Etidades
Imports Infraestructura.Repositorio


Public Class CoreVentas
    Implements IVentasNegocio

    Public Function Delete(Id As Integer) Implements IVentasNegocio.Delete
        Try
            Dim data As New RepositorioVentas
            data.Delete(Id)
            Return "Venta eliminada"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Insert(EtidadesVentas As EntidadesVentas) Implements IVentasNegocio.Insert
        Try
            Dim data As New RepositorioVentas
            Return data.Insert(EtidadesVentas.IDCliente1, EtidadesVentas.Total1)
        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function

    Public Function Read(EtidadesVentas As EntidadesVentas) As DataTable Implements IVentasNegocio.Read
        Try
            Dim data As New RepositorioVentas
            Return data.Read(EtidadesVentas.ID1, EtidadesVentas.IDCliente1, EtidadesVentas.Fecha1, EtidadesVentas.Total1)
        Catch ex As Exception

        End Try
    End Function
End Class
