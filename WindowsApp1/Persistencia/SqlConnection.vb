Imports System.Data.SqlClient
Imports System.Configuration

Public MustInherit Class ConnectionToSql
    Private ReadOnly connectionString As String

    Public Sub New()
        connectionString = ConfigurationManager.ConnectionStrings("WindowsApp1.My.MySettings.Conexion").ToString()
    End Sub

    Protected Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

End Class
