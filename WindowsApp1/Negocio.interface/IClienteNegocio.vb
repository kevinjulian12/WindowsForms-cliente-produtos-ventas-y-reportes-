Imports System.Data
Imports Negocio.Etidades

Public Interface IClientesNegocio
    Function Reading(EtidadesClientes As EntidadesClientes) As List(Of EntidadesClientes)
    Function Update(EtidadesClientes As EntidadesClientes) As String
    Function Delete(Id As Integer) As String
    Function Insert(EtidadesClientes As EntidadesClientes) As String
End Interface