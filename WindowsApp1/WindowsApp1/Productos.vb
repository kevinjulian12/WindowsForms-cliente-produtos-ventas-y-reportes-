Imports Dominio

Public Class Productos
    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarProductos()
    End Sub

    Dim ObjectCN As CNproductos = New CNproductos()
    Public Editar As Boolean

    Private Sub MostrarProductos()
        dataGridView1.DataSource = ObjectCN.mostrarProductos()
        dataGridView1.Columns.Item(0).Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (Editar = False) Then
            Try
                If (txtnombre.TextLength < 3 And txtCategoria.TextLength < 3) Then
                    MessageBox.Show("Complete los campos")

                Else
                    If (txtprecio.Text <= 0) Then
                        MessageBox.Show("precio no puede contener valor negativos")
                    Else
                        ObjectCN.InsertarProductos(txtnombre.Text, txtprecio.Text, txtCategoria.Text)
                        MessageBox.Show("se inserto correctamente")
                        MostrarProductos()
                        limpiarForm()
                        txtBuscar.Enabled = False
                        txtBuscar.Clear()
                        label6.Visible = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("precio no contiene un valor numerico")
            End Try
        End If
        'EDITAR
        If (Editar = True) Then
            Try
                If (txtnombre.TextLength < 3 And txtCategoria.TextLength < 3) Then
                    MessageBox.Show("Complete los campos")

                Else
                    If (txtprecio.Text <= 0) Then
                        MessageBox.Show("precio no puede contener valor negativos")
                    Else
                        ObjectCN.EditarProductos(txtid.Text, txtnombre.Text, txtprecio.Text, txtCategoria.Text)
                        MessageBox.Show("se edito correctamente")
                        MostrarProductos()
                        limpiarForm()
                        Editar = False
                        btnCancelar.Enabled = False
                        dataGridView1.Enabled = True
                        txtBuscar.Enabled = False
                        txtBuscar.Clear()
                        label6.Visible = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("precio no contiene un valor numerico")
            End Try
        End If
    End Sub

    Private Sub limpiarForm()
        txtnombre.Clear()
        txtprecio.Clear()
        txtCategoria.Clear()
        txtid.Clear()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Editar = True
                txtid.Text = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                txtnombre.Text = dataGridView1.CurrentRow.Cells(1).Value.ToString()
                txtprecio.Text = dataGridView1.CurrentRow.Cells(2).Value.ToString()
                txtCategoria.Text = dataGridView1.CurrentRow.Cells(3).Value.ToString()
                btnEditar.Enabled = False
                btnEliminar.Enabled = False
                dataGridView1.Enabled = False
                btnCancelar.Enabled = True
            Else
                MessageBox.Show("seleccione una fila por favor")
            End If
        Catch ex As Exception
            MessageBox.Show("no hay un producto seleccionado")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Dim idProductos = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                ObjectCN.EliminarProductos(idProductos)
                MessageBox.Show("Eliminado correctamente")
                MostrarProductos()
                btnEliminar.Enabled = False
                btnEditar.Enabled = False
                btnCancelar.Enabled = False
                txtBuscar.Enabled = False
                txtBuscar.Clear()
                label6.Visible = True
            Else
                MessageBox.Show("seleccione una fila por favor")
            End If
        Catch ex As Exception
            MessageBox.Show("no hay un producto seleccionado")
        End Try
    End Sub


    Private Sub dataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        btnEliminar.Enabled = True
        btnEditar.Enabled = True
        btnCancelar.Enabled = False
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        btnEliminar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        dataGridView1.Enabled = True
        Editar = False
        limpiarForm()
        txtBuscar.Enabled = False
        txtBuscar.Clear()
        label6.Visible = True
        btnCancelar.Enabled = False
    End Sub

    Dim NombreColumna As String = ""

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

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        FiltrarDatosDatagridview(dataGridView1, NombreColumna, txtBuscar)
    End Sub

End Class