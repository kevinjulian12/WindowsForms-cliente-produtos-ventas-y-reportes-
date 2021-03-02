Imports System.Data.SqlClient

Public Class CDventas
    Inherits ConnectionToSql
    Public Function MostrarHistVent(IdCliente) As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select* from ventas where IDCliente=" + IdCliente + ";"
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

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

    Public Function Insertar(Idcliente As Object, fecha As DateTime, total As Object)
        Dim IdVenta As Integer

        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "insert into ventas values (" + Idcliente + ",'" + fecha.ToString("dd/MM/yyyy") +
                                      "'," + total.ToString() + "); SELECT SCOPE_IDENTITY();"
                command.CommandType = CommandType.Text
                IdVenta = command.ExecuteScalar()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
        Return IdVenta
    End Function

    Public Sub Editar(Id As Object, nombre As Object, precio As Object, categoria As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "update productos set Nombre='" + nombre + "',Precio='" + precio + "',Categoria='" + categoria + "' where ID='" + Id + "'"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub EliminarHist(Id As Object)
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

End Class