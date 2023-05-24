Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports Infraestructura.Data
Imports Infraestructura.Interface

Public Class RepositorioClientes
    Inherits ConnectionToSql
    Implements IClienteRepository

    Public Function Read(Id As Long, Optional Cliente As String = "", Optional telefono As String = "", Optional correo As String = "") As DataTable Implements IClienteRepository.Read
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = My.Resources.BuscarCliente()
                command.Parameters.AddWithValue("@id", Id.ToString)
                command.Parameters.AddWithValue("@Cliente", Cliente.ToString)
                command.Parameters.AddWithValue("@telefono", telefono.ToString)
                command.Parameters.AddWithValue("@correo", correo.ToString)
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Sub Insert(Cliente As String, telefono As String, correo As String) Implements IClienteRepository.Insert
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"insert into clientes values ('{Cliente}','{telefono}','{correo}')"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub Update(Id As Long, Cliente As String, telefono As String, correo As String) Implements IClienteRepository.Update
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"update clientes set Cliente='{Cliente}',Telefono='{telefono}',Correo='{correo}' where ID={Convert.ToString(Id)}"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub Delete(Id As Long) Implements IClienteRepository.Delete
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"delete from clientes where ID={Convert.ToString(Id)}"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

End Class