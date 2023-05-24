
Public Interface IVentasitemsRepository
    Function Read(Id As Long, IDVenta As Long, IDProducto As Long, PrecioUnitario As Double, Cantidad As Integer, PrecioTotal As Double) As DataTable
    Sub Delete(Id As Long)
    Sub Insert(IDVenta As Long, IDProducto As Long, PrecioUnitario As Double, Cantidad As Integer, PrecioTotal As Double)
End Interface