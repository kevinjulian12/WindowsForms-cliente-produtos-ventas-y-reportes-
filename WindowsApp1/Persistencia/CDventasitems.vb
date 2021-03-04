Imports System.Data.SqlClient
Public Class CDventasitems
    Inherits ConnectionToSql

    Public Function MostrarDetVent(IdVenta) As DataTable
        Dim Tabla = New DataTable()
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "select Nombre,Categoria,Precio,Cantidad,PrecioTotal from ventasitems join productos on IDProducto=productos.ID where IDVenta= " + IdVenta
                command.CommandType = CommandType.Text
                Tabla.Load(command.ExecuteReader)
                connection.Close()
            End Using
        End Using
        Return Tabla
    End Function

    Public Sub Insertar(IDVenta As Integer, IDProducto As Object, PrecioUnitario As Object, Cantidad As Object, PrecioTotal As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "insert into ventasitems values (" + IDVenta.ToString() + "," + IDProducto + "," + PrecioUnitario + "," + Cantidad + "," + PrecioTotal + ");"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub EliminarDetalllesVenta(Id As Object)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "delete from ventasitems where IDVenta=" + Id
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

End Class
