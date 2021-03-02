Imports Persistencia

Public Class CNclientes

    Dim cdClientes As New CDclientes()

    Public Function mostrarClientes() As DataTable
        Return cdClientes.MostrarClientes()
    End Function

    Public Sub InsertarCliente(cliente As Object, telefono As Object, correo As Object)
        cdClientes.Insertar(cliente, telefono, correo)
    End Sub

    Public Sub EditarCliente(Id As Object, cliente As Object, telefono As Object, correo As Object)
        cdClientes.Editar(Id, cliente, telefono, correo)
    End Sub

    Public Sub EliminarCliente(ID As Object)
        cdClientes.Eliminar(ID)
    End Sub

End Class
