Imports Dominio

Public Class ReportesDeVentas
    Dim ObjectCN As CNventas = New CNventas()

    Private Sub MostrarReporteVentas()
        dataGridView1.DataSource = ObjectCN.mostrarReporte()
    End Sub

    Private Sub ReportesDeVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarReporteVentas()
    End Sub

    Private Sub FiltrarDatosDatagridview(DataGrid As DataGridView, nombre_columna As String, txt_buscar As TextBox)
        'Al texto recibido si contiene un asterisco (*) lo reemplazo de la cadena
        'para que no provoque una excepción.
        Try
            Dim cadena = txt_buscar.Text.Trim().Replace("*", "")
            Dim filtro = String.Format("convert([{0}], System.String) LIKE '{1}%'", nombre_columna, cadena)
            CType(DataGrid.DataSource, DataTable).DefaultView.RowFilter = filtro
        Catch ex As Exception
            MessageBox.Show("Seleccione una columna para buscar")
        End Try
    End Sub

    Dim NombreColumna As String = ""

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        FiltrarDatosDatagridview(dataGridView1, NombreColumna, txtBuscar)
    End Sub
End Class