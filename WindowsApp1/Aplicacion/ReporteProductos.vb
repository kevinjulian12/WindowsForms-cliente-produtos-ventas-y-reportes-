

Public Class ReporteProductos
    ' Dim ObjectCN As CNproductos = New CNproductos

    Private Sub MostrarReporteProductos()
        Dim mes As String = 1
        If (ComboBox1.SelectedItem = "enero") Then
            mes = 1
        End If
        If (ComboBox1.SelectedItem = "febrero") Then
            mes = 2
        End If
        If (ComboBox1.SelectedItem = "marzo") Then
            mes = 3
        End If
        If (ComboBox1.SelectedItem = "abril") Then
            mes = 4
        End If
        If (ComboBox1.SelectedItem = "mayo") Then
            mes = 5
        End If
        If (ComboBox1.SelectedItem = "junio") Then
            mes = 6
        End If
        If (ComboBox1.SelectedItem = "julio") Then
            mes = 7
        End If
        If (ComboBox1.SelectedItem = "agosto") Then
            mes = 8
        End If
        If (ComboBox1.SelectedItem = "septiembre") Then
            mes = 9
        End If
        If (ComboBox1.SelectedItem = "octubre") Then
            mes = 10
        End If
        If (ComboBox1.SelectedItem = "noviembre") Then
            mes = 11
        End If
        If (ComboBox1.SelectedItem = "diciembre") Then
            mes = 12
        End If
        '    dataGridView1.DataSource = ObjectCN.mostrarReporte(mes)
    End Sub

    Private Sub ReporteProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load, ComboBox1.SelectedIndexChanged

        MostrarReporteProductos()
    End Sub

End Class