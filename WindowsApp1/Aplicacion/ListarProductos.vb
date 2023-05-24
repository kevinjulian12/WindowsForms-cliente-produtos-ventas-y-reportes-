Imports Negocio.Centro
Imports Negocio.Etidades

Public Class ListarProductos
    Dim Core As CoreProducto = New CoreProducto()
    Public entidad As EntidadesProductos = New EntidadesProductos

    Private Sub MostrarProductos()
        dataGridView1.DataSource = Core.Read(entidad)
    End Sub

    Private Sub ListarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarProductos()
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If (dataGridView1.SelectedRows.Count > 0) Then
            Dim ventas As Venta = Application.OpenForms.OfType(Of Venta).SingleOrDefault
            ventas.txtidproductos.Text = dataGridView1.CurrentRow.Cells(0).Value.ToString()
            ventas.txtNombre.Text = dataGridView1.CurrentRow.Cells(1).Value.ToString()
            ventas.txtPrecio.Text = dataGridView1.CurrentRow.Cells(2).Value.ToString()
            ventas.txtCategoria.Text = dataGridView1.CurrentRow.Cells(3).Value.ToString()
            ventas.txtidproductos.Enabled = False
            ventas.txtNombre.Enabled = False
            ventas.txtPrecio.Enabled = False
            ventas.txtCategoria.Enabled = False
            ventas.ProductoCargado = True
            Close()
        Else
            MessageBox.Show("Por favor seleccione una fila...")
        End If
    End Sub

    Private Sub FiltrarDatosDatagridview(dataGrid As DataGridView, nombre_columna As String, txt_buscar As TextBox)
        'Al texto recibido si contiene un asterisco (*) lo reemplazo de la cadena
        'para que no provoque una excepción.
        Try
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