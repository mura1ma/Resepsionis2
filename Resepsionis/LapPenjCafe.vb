Imports MySql.Data.MySqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.InteropServices.ComTypes

Public Class LapPenjCafe
    Public waktuawal As Date
    Public waktuakhir As Date

    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Pendinglist.Visible = True
        Me.Close()
    End Sub

    Private Sub ButtonProses_Click(sender As Object, e As EventArgs) Handles ButtonProses.Click
        ProgressBar1.Value = 0
        ProgressBar1.Value = 10
        Dim dt As New DataTable
        'MsgBox(DateTimePickerUntil.Value.ToString("yyyy-MM-dd HH:mm:ss"))
        Dim sqlstr As String
        If ComboBoxLokasi.Text = "CAFE" Then
            If ComboBoxKry.Text <> "Semua" Then
                sqlstr = "SELECT TGL, NAMA,  ITEM , QTTY, HRGSATUAN, TTLHARGA, HRGKRY, KETERANGAN, PETUGAS, BLMLUNAS FROM TRXCAFE WHERE TGL >= '" + DateTimePickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND TGL <= '" + DateTimePickerUntil.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PETUGAS = '" & ComboBoxKry.Text & "' AND URUT >'0'  ORDER BY TGL ASC"
            Else
                sqlstr = "SELECT TGL, NAMA,  ITEM , QTTY, HRGSATUAN, TTLHARGA, HRGKRY, KETERANGAN, PETUGAS, BLMLUNAS FROM TRXCAFE WHERE TGL >= '" + DateTimePickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND TGL <= '" + DateTimePickerUntil.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'  AND URUT >'0' ORDER BY TGL ASC"
            End If
        ElseIf ComboBoxLokasi.Text = "GUDANG" Then
            If ComboBoxKry.Text <> "Semua" Then
                sqlstr = "SELECT TGL, NAMA,  ITEM , QTTY, HRGSATUAN, TTLHARGA, HRGKRY, KETERANGAN, PETUGAS, BLMLUNAS FROM TRXCAFE WHERE TGL >= '" + DateTimePickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND TGL <= '" + DateTimePickerUntil.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PETUGAS = '" & ComboBoxKry.Text & "' AND URUT <'0' ORDER BY TGL ASC"
            Else
                sqlstr = "SELECT TGL, NAMA,  ITEM , QTTY, HRGSATUAN, TTLHARGA, HRGKRY, KETERANGAN, PETUGAS, BLMLUNAS FROM TRXCAFE WHERE TGL >= '" + DateTimePickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND TGL <= '" + DateTimePickerUntil.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND URUT <'0' ORDER BY TGL ASC"
            End If
        End If

        masuktabel(sqlstr, dt)
        If dt.Rows.Count - 1 < 0 Then
            MsgBox("Tidak ada data")
            DataGridView1.DataSource = New DataTable
            DataGridView2.DataSource = New DataTable
            ProgressBar1.Value = 100
        Else
            waktuawal = dt.Rows(0)("TGL")
            waktuakhir = dt.Rows(dt.Rows.Count - 1)("TGL")
            ProgressBar1.Value = 60
            DataGridView1.DataSource = dt
            SORTBARANGKELUAR()
            ProgressBar1.Value = 90

            LabelTtltrx.Text = "Jumlah Transasksi " & ComboBoxKry.Text & " = " & DataGridView1.RowCount & " Transaksi"
            'Labelttlkas.Text = "Jumlah Kas Masuk " & ComboBoxKry.Text & " = " & kasttl.ToString("Rp #,###").Replace(",", ".") & ",-"
            ProgressBar1.Value = 100
        End If

    End Sub
    Private Sub LapPenjCafe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePickerFrom.Format = DateTimePickerFormat.Custom
        DateTimePickerFrom.CustomFormat = "dd-MMM-yyyy HH:mm:ss"
        DateTimePickerUntil.Format = DateTimePickerFormat.Custom
        DateTimePickerUntil.CustomFormat = "dd-MMM-yyyy HH:mm:ss"

        DateTimePickerFrom.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)

        Dim sptgs As String = "Select * From PETUGAS WHERE STATUS = 'AKTIF'"
        Dim DT As New DataTable
        masuktabel(sptgs, DT)
        ComboBoxKry.Items.Add("Semua")
        For a = 0 To DT.Rows.Count - 1
            ComboBoxKry.Items.Add(DT.Rows(a)("NAMA"))
        Next
        ComboBoxKry.Text = "Semua"
        ComboBoxLokasi.Text = "CAFE"
    End Sub
    Sub SORTBARANGKELUAR()
        ''copy datagrid data to datatable to be sorted according to "Item" column
        Dim dtdatagrid As New DataTable
        For Each column As DataGridViewColumn In DataGridView1.Columns
            dtdatagrid.Columns.Add(DataGridView1.Columns(dtdatagrid.Columns.Count).Name)
        Next
        For Each row As DataGridViewRow In DataGridView1.Rows
            dtdatagrid.Rows.Add()
            For Each cell As DataGridViewCell In row.Cells
                dtdatagrid.Rows(dtdatagrid.Rows.Count - 1)(cell.ColumnIndex) = cell.Value.ToString()
            Next
        Next
        dtdatagrid.DefaultView.Sort = "Item"
        dtdatagrid = dtdatagrid.DefaultView.ToTable

        'DataGridView2.DataSource = dtdatagrid

        Dim DT As New DataTable
        DT.Columns.Add("ITEM")
        DT.Columns.Add("QTT KELUAR") '' QTT KELUAR keluar
        DT.Columns.Add("QTT MASUK") '' QTT KELUAR masuk
        'DT.Columns.Add("JUMLAH")


        Dim indicator As Integer = 0
        For a = 0 To DataGridView1.Rows.Count - 1
            'For b = 0 To DT.Rows.Count - 1
            If DT.Rows.Count = 0 Then
                DT.Rows.Add()
                DT.Rows(0)("ITEM") = dtdatagrid.Rows(0)("ITEM")
                DT.Rows(0)("QTT KELUAR") = 0
                DT.Rows(0)("QTT MASUK") = 0
                'DT.Rows(0)("JUMLAH") = 0
            End If
            If DT.Rows(DT.Rows.Count - 1)("ITEM") <> dtdatagrid.Rows(indicator)("ITEM") Then
                DT.Rows.Add()
                DT.Rows(DT.Rows.Count - 1)("ITEM") = dtdatagrid.Rows(indicator)("ITEM")
                If dtdatagrid.Rows(indicator)("QTTY") >= 0 Then
                    DT.Rows(DT.Rows.Count - 1)("QTT KELUAR") = CInt(dtdatagrid.Rows(indicator)("QTTY"))
                    DT.Rows(DT.Rows.Count - 1)("QTT MASUK") = 0
                Else
                    DT.Rows(DT.Rows.Count - 1)("QTT KELUAR") = 0
                    DT.Rows(DT.Rows.Count - 1)("QTT MASUK") = -1 * CInt(dtdatagrid.Rows(indicator)("QTTY"))
                End If

            ElseIf DT.Rows(DT.Rows.Count - 1)("ITEM") = dtdatagrid.Rows(indicator)("ITEM") Then
                If dtdatagrid.Rows(indicator)("QTTY") >= 0 Then
                    DT.Rows(DT.Rows.Count - 1)("QTT KELUAR") = DT.Rows(DT.Rows.Count - 1)("QTT KELUAR") + CInt(dtdatagrid.Rows(indicator)("QTTY"))
                    'DT.Rows(DT.Rows.Count - 1)("JUMLAH") = DT.Rows(DT.Rows.Count - 1)("JUMLAH") + CInt(dtdatagrid.Rows(indicator)("TTLHARGA"))
                Else
                    DT.Rows(DT.Rows.Count - 1)("QTT MASUK") = DT.Rows(DT.Rows.Count - 1)("QTT MASUK") + (-1 * CInt(dtdatagrid.Rows(indicator)("QTTY")))
                End If

            End If
            ' Next
            indicator = indicator + 1
        Next
        DataGridView2.DataSource = DT
    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, 550) 'fixed size
        'pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper)
        PD.DefaultPageSettings = pagesetup

        Dim filePath As String = "src\PRT.sys"
        Dim printernama As String
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    printernama = reader.ReadLine()
                    'Console.WriteLine(line) ' Print the line to the console (you can process it differently)
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If
        PD.PrinterSettings.PrinterName = printernama
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f6c As New Font("Courier", 6, FontStyle.Regular)
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f8b As New Font("Calibri", 8, FontStyle.Bold)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        'font alignment
        Dim right As New StringFormat
        Dim center As New StringFormat

        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        Dim line2 As String
        line = "****************************************************************"
        line2 = "----------------------------------------------------------------------------------"

        'range from top
        'logo
        Dim height As Integer 'DGV Position
        Dim i As Long
        'Dim logoImage As Image = My.Resources.ResourceManager.GetObject("FORREST_INN")
        'Dim lunas As Image = My.Resources.ResourceManager.GetObject("lunas")
        e.Graphics.DrawString("Laporan Cafe ", f14, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 60, 5 + height)
        height += 30
        e.Graphics.DrawString("Mulai: " & DateTimePickerFrom.Value, f8, Brushes.Black, 20, height)
        height += 15
        e.Graphics.DrawString("Sampai:" & DateTimePickerUntil.Value, f8, Brushes.Black, 20, height)
        height += 15
        e.Graphics.DrawString("Petugas:" & ComboBoxKry.Text, f8, Brushes.Black, 20, height)
        height += 15
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, height) '*******************************************
        'height += 15
        'e.Graphics.DrawString("Nama ", f8, Brushes.Black, 0, 35 + height)
        'e.Graphics.DrawString(": " & TextBoxpelanggan.Text, f8, Brushes.Black, 60, 35 + height)
        'height += 15
        'e.Graphics.DrawString("Keterangan ", f8, Brushes.Black, 0, 35 + height)
        'e.Graphics.DrawString(": " & TextBoxketerangan.Text, f8, Brushes.Black, 60, 35 + height)
        height += 15
        e.Graphics.DrawString("Qty", f8b, Brushes.Black, 0, height)
        e.Graphics.DrawString("Item", f8b, Brushes.Black, 25, height)
        e.Graphics.DrawString("Total Harga", f8b, Brushes.Black, 180, height, right)

        '
        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, height)

        For row As Integer = 0 To DataGridView2.RowCount - 1
            height += 15
            e.Graphics.DrawString(DataGridView2.Rows(row).Cells("QTT KELUAR").Value.ToString, f8, Brushes.Black, 0, height)
            e.Graphics.DrawString(DataGridView2.Rows(row).Cells("ITEM").Value.ToString, f8, Brushes.Black, 25, height)
            'e.Graphics.DrawString(CInt(DataGridView2.Rows(row).Cells("JUMLAH").Value).ToString("Rp #,###").Replace(",", "."), f8, Brushes.Black, 180, height, right)

        Next
        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, height)
        height += 15
        e.Graphics.DrawString(Labelttlkas.Text, f8b, Brushes.Black, 0, height)
        height += 15
        e.Graphics.DrawString(LabelTtltrx.Text, f8b, Brushes.Black, 0, height)
        'e.Graphics.DrawString(CInt(totaltrx).ToString("Rp #,###").Replace(",", "."), f10, Brushes.Black, rightmargin, 35 + height, right)
        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, height)

        'height += 15
        'e.Graphics.DrawString("Petugas", f8, Brushes.Black, 10, 45 + height)
        'e.Graphics.DrawString("Pelanggan", f8, Brushes.Black, CInt((e.PageBounds.Width) / 2) + 50, 45 + height)
        'e.Graphics.DrawImage(lunas, CInt((e.PageBounds.Width - 60) / 2), 45 + height, 60, 30)
        'height += 70
        'e.Graphics.DrawString("~Thank you for coming~", f6c, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)
        height += 30
        e.Graphics.DrawString(". ", f8, Brushes.Black, 0, height)

    End Sub

    Private Sub Buttoncetak_Click(sender As Object, e As EventArgs) Handles Buttoncetak.Click
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub
End Class