
Public Class DetallesVentas

    '  Dim ObjectCN As CNventasitems = New CNventasitems
    '  Public ID = ObjectCN.IdVen

    Private Sub MostrarDetalles()
        '    dataGridView1.DataSource = ObjectCN.mostrarDetVent(ID)
    End Sub

    Private Sub DetallesVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarDetalles()
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