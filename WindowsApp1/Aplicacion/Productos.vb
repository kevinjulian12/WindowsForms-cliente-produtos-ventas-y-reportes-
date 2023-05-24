Imports Negocio.Centro
Imports Negocio.Etidades

Public Class Productos

    Dim negocio As CoreProducto = New CoreProducto()
    Public Editar As Boolean

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (txtnombre.TextLength < 3 And txtCategoria.TextLength < 3) Then
                MessageBox.Show("Complete los campos")
            Else
                Dim entidad As EntidadesProductos = New EntidadesProductos()
                entidad.Nombre = txtnombre.Text
                entidad.Precio = Convert.ToDouble(txtPrecio.Text)
                entidad.Categoria = txtCategoria.Text
                If (Editar = False) Then
                    MessageBox.Show(negocio.Insert(entidad))
                Else
                    entidad.CodProducto = txtid.Text
                    MessageBox.Show(negocio.Update(entidad))
                End If
                limpiarForm()
                txtBuscar.Enabled = False
                txtBuscar.Clear()
                label6.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show("no se pudo guardar los datos por: " & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub limpiarForm()
        btnEliminar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = False
        BtnGuardar.Enabled = False
        BtnNuevo.Enabled = True
        BtnBuscar.Enabled = True
        txtnombre.Clear()
        txtPrecio.Text = 0
        txtCategoria.Clear()
        txtid.Clear()
        txtid.Enabled = True
        dataGridView1.DataSource = Nothing
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Editar = True
                txtid.Text = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                txtnombre.Text = dataGridView1.CurrentRow.Cells(1).Value.ToString()
                txtPrecio.Text = dataGridView1.CurrentRow.Cells(2).Value.ToString()
                txtCategoria.Text = dataGridView1.CurrentRow.Cells(3).Value.ToString()
                dataGridView1.Enabled = False
                btnCancelar.Enabled = True
                BtnGuardar.Enabled = True
                BtnBuscar.Enabled = False
                BtnNuevo.Enabled = False
                btnEditar.Enabled = False
                btnEliminar.Enabled = False
                txtid.Enabled = False
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
                MessageBox.Show(negocio.Delete(idProductos))
                limpiarForm()
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
        txtBuscar.Clear()
        label6.Visible = True
    End Sub

    Dim NombreColumna As String = ""

    Private Sub dataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dataGridView1.ColumnHeaderMouseClick
        NombreColumna = dataGridView1.Columns(e.ColumnIndex).DataPropertyName.Trim()
        txtBuscar.Enabled = True
        label6.Visible = False
    End Sub

    Private Sub FiltrarDatosDatagridview(DataGrid As DataGridView, nombre_columna As String, txt_buscar As TextBox)
        Dim cadena = txt_buscar.Text.Trim().Replace("*", "")
        Dim filtro = String.Format("convert([{0}], System.String) LIKE '{1}%'", nombre_columna, cadena)
        CType(DataGrid.DataSource, DataTable).DefaultView.RowFilter = filtro
    End Sub

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        FiltrarDatosDatagridview(dataGridView1, NombreColumna, txtBuscar)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim entidad As EntidadesProductos = New EntidadesProductos()
        If txtid.Text <> "" Then
            entidad.CodProducto = Convert.ToInt64(txtid.Text)
        End If
        entidad.Nombre = txtnombre.Text
        entidad.Precio = Convert.ToDouble(txtPrecio.Text)
        entidad.Categoria = txtCategoria.Text
        dataGridView1.DataSource = negocio.Read(entidad)
        dataGridView1.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Editar = False
        txtid.Enabled = False
        BtnBuscar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        BtnNuevo.Enabled = False
        BtnGuardar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Private Sub txtid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtid.KeyPress
        If Not IsNumeric(e.KeyChar) And (e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Not IsNumeric(e.KeyChar) And (e.KeyChar <> vbBack) And (e.KeyChar <> ","c) Then
            e.Handled = True
        End If

        If ((e.KeyChar = ","c)) And (txtPrecio.Text = "" Or txtPrecio.Text.Contains(".") Or txtPrecio.Text.Contains(",")) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_Validated(sender As Object, e As EventArgs) Handles txtPrecio.Validated
        If IsNumeric(txtPrecio.Text) Then
            txtPrecio.Text = Convert.ToDouble(txtPrecio.Text)
        End If
    End Sub

    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtPrecio.Text = 0
    End Sub
End Class