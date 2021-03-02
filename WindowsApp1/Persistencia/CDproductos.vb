Imports System.Data.SqlClient

Public Class CDproductos
    Inherits ConnectionToSql
    Public Function MostrarProd() As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select * from productos"
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Function MostrarReporteMes(Mes As Object) As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select Nombre, sum(Cantidad) as Cantidad
                                       from ventasitems
                                       inner join productos p on IDProducto = p.ID 
                                       inner join ventas v on IDVenta = v.ID 
                                       where month(v.Fecha) =" + Mes + "
                                       group by Nombre "
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Function ListarCategoria() As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select Categoria from productos "
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Function ListarNombre(categoria As Object) As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select Nombre from productos where Categoria='" + categoria + "'"
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Sub Insertar(nombre As Object, precio As Object, categoria As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "insert into productos values ('" + nombre + "','" + precio + "','" + categoria + "')"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

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

    Public Sub Eliminar(Id As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "delete from productos where ID=" + Id
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

End Class