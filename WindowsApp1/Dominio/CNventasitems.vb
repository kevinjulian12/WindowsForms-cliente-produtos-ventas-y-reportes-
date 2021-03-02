Imports Persistencia

Public Class CNventasitems

    Dim CDventasitems As CDventasitems = New CDventasitems

    Public Function mostrarDetVent(IdVenta As Object) As DataTable

        Return CDventasitems.MostrarDetVent(IdVenta)
    End Function

    Public Sub Eliminar(ID As Object)
        CDventasitems.EliminarDetalllesVenta(ID)
    End Sub

    Public Sub InsertarItems(idVenta As Integer, idproducto As Object, precioUnitario As Object, cantidad As Object, precioTotal As Object)
        CDventasitems.Insertar(idVenta, idproducto, precioUnitario, cantidad, precioTotal)
    End Sub

End Class
