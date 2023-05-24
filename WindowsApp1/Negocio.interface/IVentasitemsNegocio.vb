Imports System.Data
Imports Negocio.Etidades

Public Interface IVentasitemsNegocio
    Function Read(EtidadesVentasitems As EntidadesVentasitems) As DataTable
    Function Delete(Id As Integer)
    Function Insert(EtidadesVentasitems As EntidadesVentasitems)
End Interface