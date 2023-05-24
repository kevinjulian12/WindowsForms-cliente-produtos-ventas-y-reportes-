
Imports System.Data.SqlClient

Public Interface IClienteRepository
    Function Read(Id As Long, Optional Cliente As String = "", Optional telefono As String = "", Optional correo As String = "") As DataTable
    Sub Update(Id As Long, Cliente As String, telefono As String, correo As String)
    Sub Delete(Id As Long)
    Sub Insert(Cliente As String, telefono As String, correo As String)
End Interface