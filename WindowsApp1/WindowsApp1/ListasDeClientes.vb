Imports Dominio

Public Class ListasDeClientes

    Dim ObjectCN As CNclientes = New CNclientes()


    Private Sub MostrarClientes()
        dataGridView1.DataSource = ObjectCN.mostrarClientes()
    End Sub

    Private Sub ListasDeClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarClientes()
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If (dataGridView1.SelectedRows.Count > 0) Then
            Dim ventas As Venta = Application.OpenForms.OfType(Of Venta).SingleOrDefault
            ventas.txtidcliente.Text = dataGridView1.CurrentRow.Cells(0).Value.ToString()
            ventas.txtcliente.Text = dataGridView1.CurrentRow.Cells(1).Value.ToString()
            ventas.txtTelefono.Text = dataGridView1.CurrentRow.Cells(2).Value.ToString()
            ventas.txtcorreo.Text = dataGridView1.CurrentRow.Cells(3).Value.ToString()
            Close()
        Else
            MessageBox.Show("Por favor seleccione una fila...")
        End If
    End Sub

    Private Sub FiltrarDatosDatagridview(dataGrid As DataGridView, nombre_columna As String, txt_buscar As TextBox)
        'Al texto recibido si contiene un asterisco (*) lo reemplazo de la cadena

        Try 'para que no provoque una excepción.
            Dim cadena = txt_buscar.Text.Trim().Replace("*", "")
            Dim filtro = String.Format("convert([{0}], System.String) LIKE '{1}%'", nombre_columna, cadena)
            CType(dataGrid.DataSource, DataTable).DefaultView.RowFilter = filtro
        Catch ex As Exception
            MessageBox.Show("Seleccione una columna para buscar")
        End Try
    End Sub

    Dim NombreColumna As String = ""

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        FiltrarDatosDatagridview(dataGridView1, NombreColumna, txtBuscar)
    End Sub
End Class