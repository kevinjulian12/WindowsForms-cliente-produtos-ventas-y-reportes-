Imports System.Data
Imports Negocio.Etidades

Public Interface IVentasNegocio

    Function Read(EtidadesVentas As EntidadesVentas) As DataTable
    Function Delete(Id As Integer)
    Function Insert(EtidadesVentas As EntidadesVentas)
End Interface