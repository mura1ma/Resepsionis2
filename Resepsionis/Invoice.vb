Imports MySql.Data.MySqlClient
Imports System.Data.Common
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Runtime.CompilerServices

Public Class Invoice
    Public nourut As Integer
    Private Sub Invoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportViewer1.Clear()
        Dim sReportDataSource As Microsoft.Reporting.WinForms.ReportDataSource
        sReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource

        sReportDataSource.Name = "DataSetReport_DataTableInvoice"
        sReportDataSource.Value = DataTableInvoiceBindingSource

        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Resepsionis.Invoice.rdlc"
        ReportViewer1.LocalReport.DataSources.Add(sReportDataSource)
        Me.ReportViewer1.RefreshReport()

        Dim dt As New DataTable
        Dim sqlstr As String = "SELECT * FROM RESEPSIONIS WHERE URUT = '" & nourut & "'"
        'MsgBox(sqlstr)
        masuktabel(sqlstr, dt)


        DataSet1.DataTableInvoice.Rows.Add()
        DataSet1.DataTableInvoice.Rows(0)("CheckIn") = CDate(dt.Rows(0)("TGLIN")).Date.ToString("dd-MMMM-yyyy")
        DataSet1.DataTableInvoice.Rows(0)("CheckOut") = CDate(dt.Rows(0)("TGLOUT")).Date.ToString("dd-MMMM-yyyy")
        DataSet1.DataTableInvoice.Rows(0)("NoKamar") = dt.Rows(0)("NOKMR")
        DataSet1.DataTableInvoice.Rows(0)("JumlahKamar") = dt.Rows(0)("JMLKMR") & " kamar"
        DataSet1.DataTableInvoice.Rows(0)("JumlahMalam") = dt.Rows(0)("JMLMLM") & " malam"
        DataSet1.DataTableInvoice.Rows(0)("TotalBayar") = (CInt(dt.Rows(0)("TOTALBYR")) + CInt(dt.Rows(0)("TAMBAH"))).ToString("Rp #,###").Replace(",", ".")

        Dim params(2) As Microsoft.Reporting.WinForms.ReportParameter
        params(0) = New Microsoft.Reporting.WinForms.ReportParameter("param_NAMA", CStr(dt.Rows(0)("NAMA")))
        params(1) = New Microsoft.Reporting.WinForms.ReportParameter("param_TANGGAL", Today.Date.ToString("dd-MMMM-yyyy"))
        params(2) = New Microsoft.Reporting.WinForms.ReportParameter("param_BAYAR", (CInt(dt.Rows(0)("TOTALBYR")) + CInt(dt.Rows(0)("TAMBAH"))).ToString("Rp #,###").Replace(",", ".") & ",-")
        ReportViewer1.LocalReport.SetParameters(params)

        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
    End Sub
End Class