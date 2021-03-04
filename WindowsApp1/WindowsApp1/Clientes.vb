Imports Dominio
Imports System.Text.RegularExpressions

Public Class Clientes

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarClientes()

    End Sub

    Dim ObjectCN As CNclientes = New CNclientes()

    Public Editar As Boolean

    Private Sub MostrarClientes()
        dataGridView1.DataSource = ObjectCN.mostrarClientes()
        dataGridView1.Columns.Item(0).Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (Editar = False) Then
            Try
                If (txtclientes.TextLength < 3 And txttelefono.TextLength < 5 And txtcorreo.TextLength < 5) Then
                    MessageBox.Show("Complete los campos")
                Else
                    ObjectCN.InsertarCliente(txtclientes.Text, txttelefono.Text, txtcorreo.Text)
                    MessageBox.Show("se inserto correctamente")
                    MostrarClientes()
                    limpiarForm()
                    txtBuscar.Enabled = False
                    txtBuscar.Clear()
                    label6.Visible = True
                End If
            Catch ex As Exception
                MessageBox.Show("no se pudo insertar los datos por: " & vbCrLf & ex.Message)
            End Try
        End If
        'EDITAR
        If (Editar = True) Then
            Try
                If (txtclientes.TextLength < 3 And txttelefono.TextLength < 5 And txtcorreo.TextLength < 5) Then
                    MessageBox.Show("Complete los campos")
                Else
                    ObjectCN.EditarCliente(txtid.Text, txtclientes.Text, txttelefono.Text, txtcorreo.Text)
                    MessageBox.Show("se edito correctamente")
                    MostrarClientes()
                    limpiarForm()
                    Editar = False
                    btnCancelar.Enabled = False
                    dataGridView1.Enabled = True
                    txtBuscar.Enabled = False
                    txtBuscar.Clear()
                    label6.Visible = True
                End If
            Catch ex As Exception
                MessageBox.Show("no se pudo insertar los datos por: " & vbCrLf & ex.Message)
            End Try
        End If
    End Sub

    Private Sub limpiarForm()
        txtclientes.Clear()
        txttelefono.Clear()
        txtcorreo.Clear()
        txtid.Clear()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Editar = True
                txtid.Text = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                txtclientes.Text = dataGridView1.CurrentRow.Cells(1).Value.ToString()
                txttelefono.Text = dataGridView1.CurrentRow.Cells(2).Value.ToString()
                txtcorreo.Text = dataGridView1.CurrentRow.Cells(3).Value.ToString()
                btnEditar.Enabled = False
                btnEliminar.Enabled = False
                dataGridView1.Enabled = False
                btnCancelar.Enabled = True
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
                ObjectCN.EliminarCliente(idCliente)
                MessageBox.Show("Eliminado correctamente")
                MostrarClientes()
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
            MessageBox.Show("No hay un clientes seleccionado")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If (dataGridView1.SelectedRows.Count > 0) Then
                Dim historialF As Form1 = New Form1
                historialF.ID = dataGridView1.CurrentRow.Cells(0).Value.ToString()
                historialF.ShowDialog()
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
        Button1.Enabled = True
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        btnEliminar.Enabled = False
        btnEditar.Enabled = False
        btnCancelar.Enabled = False
        Button1.Enabled = False
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

    Private Sub FiltrarDatosDatagridview(dataGrid As DataGridView, nombre_columna As String, txt_buscar As TextBox)
        'Al texto recibido si contiene un asterisco (*) lo reemplazo de la cadena
        'para que no provoque una excepción.
        Dim cadena = txt_buscar.Text.Trim().Replace("*", "")
        Dim filtro = String.Format("convert([{0}], System.String) LIKE '{1}%'", nombre_columna, cadena)
        CType(dataGrid.DataSource, DataTable).DefaultView.RowFilter = filtro
    End Sub

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        FiltrarDatosDatagridview(dataGridView1, NombreColumna, txtBuscar)
    End Sub
End Class
