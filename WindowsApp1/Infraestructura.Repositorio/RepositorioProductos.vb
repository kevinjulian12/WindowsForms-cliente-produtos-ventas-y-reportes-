Imports System.Data.SqlClient
Imports Infraestructura.Data
Imports Infraestructura.Interface

Public Class RepositorioProductos
    Inherits ConnectionToSql
    Implements IProductoRepository

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

    Public Function Read(Id As Long, Optional nombre As String = "", Optional precio As Double = 0, Optional categoria As String = "") As Object Implements IProductoRepository.Read
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = My.Resources.BuscarProducto()
                command.Parameters.AddWithValue("@id", Id.ToString)
                command.Parameters.AddWithValue("@nombre", nombre.ToString)
                command.Parameters.AddWithValue("@precio", precio.ToString)
                command.Parameters.AddWithValue("@categoria", categoria.ToString)
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Sub Update(Id As Long, nombre As String, precio As Double, categoria As String) Implements IProductoRepository.Update
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"update productos set Nombre='{nombre}',Precio='" + precio.ToString + "',Categoria='" + categoria + "' where ID='" + Id.ToString + "'"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub Delete(Id As Integer) Implements IProductoRepository.Delete
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "delete from productos where ID=" + Id.ToString
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub Insert(nombre As String, precio As Double, categoria As String) Implements IProductoRepository.Insert
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"insert into productos values ('{nombre}','{precio.ToString}','{categoria}')"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub
End Class