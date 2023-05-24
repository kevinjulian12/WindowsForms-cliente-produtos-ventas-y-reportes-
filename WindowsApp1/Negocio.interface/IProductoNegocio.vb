Imports System.Data
Imports Negocio.Etidades

Public Interface IProductoNegocio
    Function Read(EtidadesProductos As EntidadesProductos) As List(Of EntidadesProductos)
    Function Update(EtidadesProductos As EntidadesProductos) As String
    Function Delete(Id As Integer) As String
    Function Insert(EtidadesProductos As EntidadesProductos) As String
End Interface