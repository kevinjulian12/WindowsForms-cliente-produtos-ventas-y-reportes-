Imports Negocio
Imports Negocio.Centro
Imports Negocio.Etidades

Public Class Clientes

    Dim negocio As CoreCliente = New CoreCliente()
    Public Editar As Boolean

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If (txtclientes.TextLength < 3 And txttelefono.TextLength < 5 And txtcorreo.TextLength < 5) Then
                MessageBox.Show("Complete los campos")
            Else
                Dim entidad As EntidadesClientes = New EntidadesClientes()
                entidad.Cliente = txtclientes.Text
                entidad.Correo = txtcorreo.Text
                entidad.Telefono = txttelefono.Text
                If (Editar = False) Then
                    MessageBox.Show(negocio.Insert(entidad))
                Else
                    entidad.CodCliente = txtid.Text
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
        btnHistorial.Enabled = False
        btnEliminar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = False
        btnGuardar.Enabled = False
        btnNuevo.Enabled = True
        btnBuscar.Enabled = True
        txtclientes.Clear()
        txttelefono.Clear()
        txtcorreo.Clear()
        txtid.Clear()
        txtid.Enabled = True
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Editar = True
                txtid.Text = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                txtclientes.Text = dataGridView1.CurrentRow.Cells(1).Value.ToString()
                txttelefono.Text = dataGridView1.CurrentRow.Cells(2).Value.ToString()
                txtcorreo.Text = dataGridView1.CurrentRow.Cells(3).Value.ToString()
                dataGridView1.Enabled = False
                btnCancelar.Enabled = True
                btnGuardar.Enabled = True
                btnBuscar.Enabled = False
                btnNuevo.Enabled = False
                btnEditar.Enabled = False
                btnEliminar.Enabled = False
                btnHistorial.Enabled = False
                txtid.Enabled = False
            Else
                MessageBox.Show("seleccione una fila por favor")
            End If
        Catch ex As Exception
            MessageBox.Show("No hay un clientes seleccionado")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Dim idCliente = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                MessageBox.Show(negocio.Delete(idCliente))
                limpiarForm()
            Else
                MessageBox.Show("seleccione una fila por favor")
            End If
        Catch ex As Exception
            MessageBox.Show("No hay un clientes seleccionado")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnHistorial.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                ' Dim historialF As Form1 = New Form1
                ' historialF.ID = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                ' historialF.ShowDialog()
            Else
                MessageBox.Show("Por favor seleccione una fila...")
            End If
        Catch ex As Exception
            MessageBox.Show("No hay un clientes seleccionado")
        End Try
    End Sub
    Private Sub dataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        btnEliminar.Enabled = True
        btnEditar.Enabled = True
        btnCancelar.Enabled = False
        btnHistorial.Enabled = True
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        btnEliminar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = False
        btnHistorial.Enabled = False
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

    Private Sub FiltrarDatosDatagridview(dataGrid As DataGridView, nombre_columna As String, txt_buscar As TextBox)
        Dim cadena = txt_buscar.Text.Trim().Replace("*", "")
        Dim filtro = String.Format("convert([{0}], System.String) LIKE '{1}%'", nombre_columna, cadena)
        CType(dataGrid.DataSource, DataTable).DefaultView.RowFilter = filtro
    End Sub

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        FiltrarDatosDatagridview(dataGridView1, NombreColumna, txtBuscar)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim entidad As EntidadesClientes = New EntidadesClientes()
        If txtid.Text <> "" Then
            entidad.CodCliente = Convert.ToInt64(txtid.Text)
        End If
        entidad.Cliente = txtclientes.Text
        entidad.Correo = txtcorreo.Text
        entidad.Telefono = txttelefono.Text
        dataGridView1.DataSource = negocio.Reading(entidad)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Editar = False
        txtid.Enabled = False
        btnBuscar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        btnHistorial.Enabled = False
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Private Sub txtid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtid.KeyPress
        If Not IsNumeric(e.KeyChar) And (e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub
End Class
