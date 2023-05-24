Imports Negocio.interface
Imports Negocio.Etidades
Imports Infraestructura.Repositorio

Public Class CoreCliente
    Implements IClientesNegocio

    Private data As New RepositorioClientes

    Public Function Update(EtidadesClientes As EntidadesClientes) As String Implements IClientesNegocio.Update
        Try
            data.Update(EtidadesClientes.CodCliente, EtidadesClientes.Cliente, EtidadesClientes.Telefono, EtidadesClientes.Correo)
            Return "Cliente actualizado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Delete(Id As Integer) As String Implements IClientesNegocio.Delete
        Try
            data.Delete(Id)
            Return "Cliente eliminado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Insert(EtidadesClientes As EntidadesClientes) As String Implements IClientesNegocio.Insert
        Try
            data.Insert(EtidadesClientes.Cliente, EtidadesClientes.Telefono, EtidadesClientes.Correo)
            Return "Nuevo cliente insertado"
        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function

    Public Function Reading(EntidadesClientes As EntidadesClientes) As List(Of EntidadesClientes) Implements IClientesNegocio.Reading
        Try
            Dim ListEntidadesClientes As List(Of EntidadesClientes) = New List(Of EntidadesClientes)
            Dim tabla As DataTable = data.Read(EntidadesClientes.CodCliente, EntidadesClientes.Cliente, EntidadesClientes.Telefono, EntidadesClientes.Correo)
            For Each row As DataRow In tabla.Rows
                Dim Entidades As EntidadesClientes = New EntidadesClientes
                Entidades.CodCliente = row(0)
                Entidades.Cliente = row(1)
                Entidades.Telefono = row(2)
                Entidades.Correo = row(3)
                ListEntidadesClientes.Add(Entidades)
            Next
            Return ListEntidadesClientes
        Catch ex As Exception

        End Try
    End Function
End Class
