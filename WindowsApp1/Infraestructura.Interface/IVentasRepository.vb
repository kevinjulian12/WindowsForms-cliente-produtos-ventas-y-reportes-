
Public Interface IVentasRepository
    Function Read(Id As Long, IdCliente As String, Fecha As DateTime, total As String) As DataTable
    Sub Delete(Id As Long)
    Function Insert(IdCliente As String, total As String)
End Interface