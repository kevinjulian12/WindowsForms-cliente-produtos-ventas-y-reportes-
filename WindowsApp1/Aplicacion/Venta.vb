Imports Negocio.Centro
Imports Negocio.Etidades


Public Class Venta
    Dim core As CoreVentas = New CoreVentas
    Dim coreItems As CoreVentasitems = New CoreVentasitems
    Public ClienteCargado As Boolean
    Public ProductoCargado As Boolean

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Dim ListasClientes As ListasDeClientes = New ListasDeClientes
        ListasClientes.entidad.CodCliente = txtidcliente.Text
        ListasClientes.entidad.Cliente = txtcliente.Text
        ListasClientes.entidad.Telefono = txtTelefono.Text
        ListasClientes.entidad.Correo = txtcorreo.Text
        ListasClientes.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim listasDeProductos As ListarProductos = New ListarProductos
        listasDeProductos.entidad.CodProducto = txtidproductos.Text
        listasDeProductos.entidad.Nombre = txtNombre.Text
        listasDeProductos.entidad.Precio = txtPrecio.Text
        listasDeProductos.entidad.Categoria = txtCategoria.Text
        listasDeProductos.ShowDialog()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (txtCantidad.Text = "") Then
            MessageBox.Show("Complete todos los textos, por favor")
        Else
            dataGridView1.Rows.Add(New String() {txtidproductos.Text, txtNombre.Text, txtPrecio.Text, txtCantidad.Text, txtPrecio.Text * txtCantidad.Text})
            LblTotal.Text = Sumar("PrecioTotal", dataGridView1)
            btnAgregar.Enabled = False
        End If
    End Sub

    Private Function Sumar(
        ByVal nombre_Columna As String,
        ByVal Dgv As DataGridView) As Double
        Dim total As Single = 0
        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"  
        Try
            For i As Integer = 0 To Dgv.RowCount - 1
                total = total + CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        ' retornar el valor  
        Return total
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If (dataGridView1.SelectedRows.Count > 0) Then
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow)
            LblTotal.Text = Sumar("PrecioTotal", dataGridView1)
        Else
            MessageBox.Show("seleccione una fila por favor")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtidcliente.Text = "" Then
            MessageBox.Show("seleccionar un cliente")
        Else
            Dim entidad As EntidadesVentas = New EntidadesVentas
            entidad.IDCliente1 = txtidcliente.Text
            entidad.Total1 = LblTotal.Text
            Dim idVenta = core.Insert(entidad)
            For Each row As DataGridViewRow In dataGridView1.Rows
                If (row.Cells(0).Value <> Nothing) Then
                    Dim entidadItems As EntidadesVentasitems = New EntidadesVentasitems
                    entidadItems.IDVenta1 = idVenta
                    entidadItems.IDProducto1 = row.Cells(0).Value
                    entidadItems.PrecioUnitario1 = row.Cells(2).Value
                    entidadItems.Cantidad1 = row.Cells(3).Value
                    entidadItems.PrecioTotal1 = row.Cells(4).Value
                    coreItems.Insert(entidadItems)
                End If
            Next
            MessageBox.Show("se inserto correctamente")
            limpiarForm()
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not IsNumeric(e.KeyChar) And (e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Venta_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtidcliente.Text = 0
        txtidproductos.Text = 0
        txtPrecio.Text = 0
        ClienteCargado = False
        ProductoCargado = False
    End Sub

    Private Sub limpiarForm()
        txtidcliente.Text = 0
        txtidproductos.Text = 0
        txtPrecio.Text = 0
        txtcliente.Clear()
        txtTelefono.Clear()
        txtcorreo.Clear()
        txtNombre.Clear()
        txtCategoria.Clear()
        txtidcliente.Enabled = True
        txtcliente.Enabled = True
        txtTelefono.Enabled = True
        txtcorreo.Enabled = True
        txtidproductos.Enabled = True
        txtNombre.Enabled = True
        txtPrecio.Enabled = True
        txtCategoria.Enabled = True
        ClienteCargado = False
        ProductoCargado = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtidcliente.Enabled = True
        txtcliente.Enabled = True
        txtTelefono.Enabled = True
        txtcorreo.Enabled = True
        txtidcliente.Text = 0
        txtcliente.Clear()
        txtTelefono.Clear()
        txtcorreo.Clear()
        ClienteCargado = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtidproductos.Text = 0
        txtPrecio.Text = 0
        txtNombre.Clear()
        txtCategoria.Clear()
        txtidproductos.Enabled = True
        txtNombre.Enabled = True
        txtPrecio.Enabled = True
        txtCategoria.Enabled = True
        ProductoCargado = False
    End Sub

    Private Sub txtCantidad_Validated(sender As Object, e As EventArgs) Handles txtCantidad.Validated
        If ProductoCargado = True And (txtCantidad.Text <> "" Or txtCantidad.Text <> "0") Then
            btnAgregar.Enabled = True
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim entidad As EntidadesVentas = New EntidadesVentas
        entidad.ID1 = TextBox2.Text
        entidad.IDCliente1 = TextBox1.Text
        entidad.Fecha1 = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        DataGridView2.DataSource = core.Read(entidad)
    End Sub
End Class