Imports System.Data.SqlClient
Imports Infraestructura.Data
Imports Infraestructura.[Interface]

Public Class RepositorioVentas
    Inherits ConnectionToSql
    Implements IVentasRepository

    Public Function MostrarReporte() As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select Cliente,Telefono,Correo,Nombre,Categoria,Precio,Cantidad,PrecioTotal 
                                       from ventasitems
                                       inner join ventas v on IDVenta = v.ID 
                                       inner join clientes c on IDCliente = c.ID
                                       inner join productos p on IDProducto = p.ID "
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Function Read(Id As Long, IdCliente As String, Fecha As DateTime, total As String) As DataTable Implements IVentasRepository.Read
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = My.Resources.BuscarVenta
                command.Parameters.AddWithValue("@id", Id.ToString)
                command.Parameters.AddWithValue("@idcliente", IdCliente.ToString)
                command.Parameters.AddWithValue("@fecha", Fecha.ToString("yyyy-MM-dd"))
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Sub Delete(Id As Long) Implements IVentasRepository.Delete
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "delete from ventas where ID=" + Id
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Function Insert(IdCliente As String, total As String) As Object Implements IVentasRepository.Insert
        Dim IdVenta As Integer
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"insert into ventas values ({IdCliente},getdate(),{total.ToString()}); SELECT SCOPE_IDENTITY();"
                command.CommandType = CommandType.Text
                IdVenta = command.ExecuteScalar()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
        Return IdVenta
    End Function
End Class