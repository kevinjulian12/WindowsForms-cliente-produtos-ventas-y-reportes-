Imports Persistencia

Public Class CNventasitems

    Dim CDventasitems As CDventasitems = New CDventasitems

    Private idvent As String
    Public Property IdVen() As String
        Get
            Return idvent
        End Get
        Set(ByVal value As String)
            idvent = value
        End Set
    End Property

    Public Function mostrarDetVent(IdVenta As Object) As DataTable
        Return CDventasitems.MostrarDetVent(IdVenta)
    End Function

    Public Sub EliminarDetalleVenta(ID As Object)
        CDventasitems.EliminarDetalllesVenta(ID)
    End Sub

    Public Sub InsertarItems(idVenta As Integer, idproducto As Object, precioUnitario As Object, cantidad As Object, precioTotal As Object)
        CDventasitems.Insertar(idVenta, idproducto, precioUnitario, cantidad, precioTotal)
    End Sub

End Class
