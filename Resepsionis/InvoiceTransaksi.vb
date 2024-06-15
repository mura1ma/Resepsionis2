Imports MySql.Data.MySqlClient
Imports System.IO



Public Class InvoiceTransaksi
    Public tanggal As Date
    Public keterangan As String
    Public jumlah As Integer

    Private Sub InvoiceTransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportViewer1.Clear()
        ReportViewer1.LocalReport.ReportPath = "Resepsionis.InvoiceTransaksi.rdlc"
        'Dim sReportDataSource As Microsoft.Reporting.WinForms.ReportDataSource
        'sReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource

        'sReportDataSource.Name = "DataSetReport_DataTableInvoice"
        ''sReportDataSource.Value = DataTableInvoiceBindingSource

        'Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Resepsionis.InvoiceTransaksi.rdlc"
        'ReportViewer1.LocalReport.DataSources.Add(sReportDataSource)
        'Me.ReportViewer1.RefreshReport()

        'Dim dt As New DataTable
        'Dim sqlstr As String = "SELECT * FROM RESEPSIONIS WHERE URUT = '" & nourut & "'"
        ''MsgBox(sqlstr)
        'masuktabel(sqlstr, dt)

        Dim params(2) As Microsoft.Reporting.WinForms.ReportParameter
        params(0) = New Microsoft.Reporting.WinForms.ReportParameter("parameterTanggal", tanggal.ToString("dd MMMM yyyy"))
        params(1) = New Microsoft.Reporting.WinForms.ReportParameter("parameterKeterangan", keterangan)
        params(2) = New Microsoft.Reporting.WinForms.ReportParameter("parameterJumlah", jumlah)
        ReportViewer1.LocalReport.SetParameters(params)

        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class