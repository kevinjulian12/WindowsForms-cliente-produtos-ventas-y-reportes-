Public Class Menu
    Private Sub btnCliente_Click(sender As Object, e As EventArgs)
        Dim FormCliente As Clientes = New Clientes
        FormCliente.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim FormProductos As Productos = New Productos
        FormProductos.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim FormVentas As Venta = New Venta
        FormVentas.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim FormReporte As ReportesDeVentas = New ReportesDeVentas
        FormReporte.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim FormReportProduct As ReporteProductos = New ReporteProductos
        FormReportProduct.ShowDialog()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim FormCliente As Clientes = New Clientes
        FormCliente.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim FormProductos As Productos = New Productos
        FormProductos.ShowDialog()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        Dim FormVentas As Venta = New Venta
        FormVentas.ShowDialog()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        Dim FormReporte As ReportesDeVentas = New ReportesDeVentas
        FormReporte.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem1.Click
        Dim FormReportProduct As ReporteProductos = New ReporteProductos
        FormReportProduct.ShowDialog()
    End Sub
End Class