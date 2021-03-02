Imports System.Data.SqlClient

Public Class CDclientes
    Inherits ConnectionToSql
    Public Function MostrarClientes() As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select * from clientes"
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Sub Insertar(Cliente As Object, telefono As Object, correo As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "insert into clientes values ('" + Cliente + "','" + telefono + "','" + correo + "')"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub Editar(Id As Object, Cliente As Object, telefono As Object, correo As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "update clientes set Cliente='" + Cliente + "',Telefono='" + telefono + "',Correo='" + correo + "' where ID='" + Id + "'"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub Eliminar(Id As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "delete from clientes where ID=" + Id
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

End Class