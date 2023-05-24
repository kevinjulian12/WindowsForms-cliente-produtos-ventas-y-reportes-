
Public Interface IProductoRepository
    Function Read(Id As Long, Optional nombre As String = "", Optional precio As Double = 0, Optional categoria As String = "")
    Sub Update(Id As Long, nombre As String, precio As Double, categoria As String)
    Sub Delete(Id As Integer)
    Sub Insert(nombre As String, precio As Double, categoria As String)
End Interface