Imports Dominio
Public Class Form1
    Dim ObjectCN As CNventas = New CNventas
    Dim VentaItem As CNventasitems = New CNventasitems
    Public ID = ObjectCN.IdTex

    Private Sub MostrarHistorialV()
        dataGridView1.DataSource = ObjectCN.mostrarHistVent(ID)
        dataGridView1.Columns.Item(0).Visible = False
        dataGridView1.Columns.Item(1).Visible = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarHistorialV()
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Dim Detalles As DetallesVentas = New DetallesVentas
                DetallesVentas.ID = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                DetallesVentas.ShowDialog()
            Else
                MessageBox.Show("Por favor seleccione una fila...")
            End If
        Catch ex As Exception
            MessageBox.Show("No hay un registro seleccionado")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Dim idVenta = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                VentaItem.EliminarDetalleVenta(idVenta)
                ObjectCN.Eliminar(idVenta)
                MessageBox.Show("Eliminado correctamente")
                MostrarHistorialV()
            Else
                MessageBox.Show("seleccione una fila por favor")
            End If
        Catch ex As Exception
            MessageBox.Show("No hay un registro seleccionado")
        End Try
    End Sub

    Private Sub dataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dataGridView1.ColumnHeaderMouseClick
        NombreColumna = dataGridView1.Columns(e.ColumnIndex).DataPropertyName.Trim()
        txtBuscar.Enabled = True
        label6.Visible = False
    End Sub

    Private Sub FiltrarDatosDatagridview(DataGrid As DataGridView, nombre_columna As String, txt_buscar As TextBox)
        'Al texto recibido si contiene un asterisco (*) lo reemplazo de la cadena
        'para que no provoque una excepción.
        Dim cadena = txt_buscar.Text.Trim().Replace("*", "")
        Dim filtro = String.Format("convert([{0}], System.String) LIKE '{1}%'", nombre_columna, cadena)
        CType(DataGrid.DataSource, DataTable).DefaultView.RowFilter = filtro
    End Sub
    Dim NombreColumna As String = ""

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged, txtBuscar.TextChanged
        FiltrarDatosDatagridview(dataGridView1, NombreColumna, txtBuscar)
    End Sub
End Class