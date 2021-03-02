Imports Dominio

Public Class Venta
    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Dim obj As CNproductos = New CNproductos

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        Dim ListasClientes As ListasDeClientes = New ListasDeClientes
        ListasDeClientes.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim listasDeProductos As ListarProductos = New ListarProductos
        listasDeProductos.ShowDialog()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (txtCantidad.Text = "") Then
            MessageBox.Show("Complete todos los textos, por favor")
        Else
            dataGridView1.Rows.Add(New String() {txtidproductos.Text, txtPrecio.Text, txtCantidad.Text, txtPrecio.Text * txtCantidad.Text})
            LblTotal.Text = Sumar("PrecioTotal", dataGridView1)
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
        End If
        Dim ventas As CNventas = New CNventas
        Dim ventasItem As CNventasitems = New CNventasitems
        Dim hora As DateTime = DateTime.Today
        Dim total As Single = LblTotal.Text
        Dim idVenta = ventas.InsertarVenta(txtidcliente.Text, hora, total)
        For Each row As DataGridViewRow In dataGridView1.Rows
            If (row.Cells(0).Value <> Nothing) Then
                ventasItem.InsertarItems(idVenta,
                                     row.Cells(0).Value,
                                     row.Cells(1).Value,
                                     row.Cells(2).Value,
                                     row.Cells(3).Value)
            End If
        Next
        MessageBox.Show("se inserto correctamente")
    End Sub
End Class