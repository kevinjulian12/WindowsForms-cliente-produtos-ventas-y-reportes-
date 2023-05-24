Imports System.Data.SqlClient
Imports Infraestructura.Data
Imports Infraestructura.[Interface]

Public Class RepositorioVentasitems
    Inherits ConnectionToSql
    Implements IVentasitemsRepository

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

    Public Function Read(Id As Long, IDVenta As Long, IDProducto As Long, PrecioUnitario As Double, Cantidad As Integer, PrecioTotal As Double) As DataTable Implements IVentasitemsRepository.Read
        Throw New NotImplementedException()
    End Function

    Public Sub Delete(Id As Long) Implements IVentasitemsRepository.Delete
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"delete from ventasitems where IDVenta={Id.ToString}"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub

    Public Sub Insert(IDVenta As Long, IDProducto As Long, PrecioUnitario As Double, Cantidad As Integer, PrecioTotal As Double) Implements IVentasitemsRepository.Insert
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = $"insert into ventasitems values ({IDVenta.ToString()},{IDProducto.ToString},{PrecioUnitario.ToString},{Cantidad.ToString},{PrecioTotal.ToString});"
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
                command.Parameters.Clear()
                connection.Close()
            End Using
        End Using
    End Sub
End Class
