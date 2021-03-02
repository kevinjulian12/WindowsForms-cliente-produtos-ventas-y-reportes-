Public Class Menu
    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim FormCliente As Clientes = New Clientes
        FormCliente.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FormProductos As Productos = New Productos
        FormProductos.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim FormVentas As Venta = New Venta
        FormVentas.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FormReporte As ReportesDeVentas = New ReportesDeVentas
        FormReporte.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim FormReportProduct As ReporteProductos = New ReporteProductos
        FormReportProduct.ShowDialog()
    End Sub
End Class