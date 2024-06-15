Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Diagnostics.Eventing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Threading

Public Class SelesaiList
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
    'Dim Tanggal As Date
    Dim rowindexdt As Integer
    Dim dtcoba As DataTable

    Private Sub PD_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, 350) 'fixed size
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
        Dim line3 As String
        line = "****************************************************************"
        line2 = "----------------------------------------------------------------------------------"
        line3 = "----- Dicetak ulang pada tanggal: " & Now.Date.ToString("dd MMM yyyy") & " ------"

        'range from top
        'logo
        Dim height As Integer 'DGV Position
        Dim i As Long
        Dim logoImage As Image = My.Resources.ResourceManager.GetObject("FORREST_INN")
        Dim lunas As Image = My.Resources.ResourceManager.GetObject("lunas")
        e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - 150) / 2), 5, 150, 35)
        height += 10
        e.Graphics.DrawString("Jl Raya Jong Biru 285 ", f6c, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 50, 35 + height)
        height += 10
        e.Graphics.DrawString("Tlp. 0895-1432-1888", f6c, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 48, 35 + height)
        height += 10
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 35 + height) '*******************************************
        height += 10
        e.Graphics.DrawString(line3, f8, Brushes.Black, 10, 35 + height)
        height += 15
        'MsgBox(DataGridView1.Rows(rowindexdt).Cells("TGLIN").Value.ToString)
        e.Graphics.DrawString("--- In : " & CDate(DataGridView1.Rows(rowindexdt).Cells("TGLIN").Value).ToString("dd MMMM yyyy") & " ---", f10, Brushes.Black, 37, 40 + height)
        height += 15
        e.Graphics.DrawString("--- Out: " & CDate(DataGridView1.Rows(rowindexdt).Cells("TGLOUT").Value).ToString("dd MMMM yyyy") & " ---", f10, Brushes.Black, 35, 40 + height)
        height += 25
        e.Graphics.DrawString("Nama ", f10, Brushes.Black, 5, 45 + height)
        e.Graphics.DrawString(": " & DataGridView1.Rows(rowindexdt).Cells("NAMA").Value, f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        height += 15
        e.Graphics.DrawString("Jumlah kamar ", f10, Brushes.Black, 5, 45 + height)
        e.Graphics.DrawString(": " & DataGridView1.Rows(rowindexdt).Cells("JMLKMR").Value & " x " & DataGridView1.Rows(rowindexdt).Cells("JMLMLM").Value & " malam", f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        height += 15
        Dim ttlbayar As Integer = CInt(DataGridView1.Rows(rowindexdt).Cells("TOTALBYR").Value) - CInt(DataGridView1.Rows(rowindexdt).Cells("POTLAIN").Value) + CInt(DataGridView1.Rows(rowindexdt).Cells("TAMBAH").Value) + CInt(DataGridView1.Rows(rowindexdt).Cells("EXTRABED").Value)
        e.Graphics.DrawString("Total ", f10, Brushes.Black, 5, 45 + height)
        e.Graphics.DrawString(": Rp. " & ttlbayar.ToString("#,###").Replace(",", "."), f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        height += 25
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 45 + height)
        If DataGridView1.Rows(rowindexdt).Cells("TRMOYO").Value <> 0 Then
            height += 10
            e.Graphics.DrawString("Pembayaran OYO ", f10b, Brushes.Black, 5, 45 + height)
            e.Graphics.DrawString(": Rp." & CInt(DataGridView1.Rows(rowindexdt).Cells("TRMOYO").Value).ToString("#,###").Replace(",", "."), f10b, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        End If
        If DataGridView1.Rows(rowindexdt).Cells("TRMTUNAI").Value <> 0 Then
            height += 10
            e.Graphics.DrawString("Pembayaran Tunai ", f10b, Brushes.Black, 5, 45 + height)
            e.Graphics.DrawString(": Rp." & CInt(DataGridView1.Rows(rowindexdt).Cells("TRMTUNAI").Value).ToString("#,###").Replace(",", "."), f10b, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        End If
        If DataGridView1.Rows(rowindexdt).Cells("TRMTRF").Value <> 0 Then
            height += 10
            e.Graphics.DrawString("Pembayaran Transfer ", f10b, Brushes.Black, 5, 45 + height)
            e.Graphics.DrawString(": Rp." & CInt(DataGridView1.Rows(rowindexdt).Cells("TRMTRF").Value).ToString("#,###").Replace(",", "."), f10b, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        End If
        height += 17
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 45 + height)
        height += 15
        e.Graphics.DrawString("Petugas", f8, Brushes.Black, 10, 45 + height)
        e.Graphics.DrawString("Pelanggan", f8, Brushes.Black, CInt((e.PageBounds.Width) / 2) + 50, 45 + height)
        e.Graphics.DrawImage(lunas, CInt((e.PageBounds.Width - 60) / 2), 45 + height, 60, 30)
        height += 75
        e.Graphics.DrawString("~Thank you for coming~", f6c, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)
        height += 20
        e.Graphics.DrawString(". ", f8, Brushes.Black, 0, 45 + height)
    End Sub

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Pendinglist.Visible = True
        Me.Close()
    End Sub

    Private Sub ButtonProses_Click(sender As Object, e As EventArgs) Handles ButtonProses.Click

        ProgressBar1.Value = 0
        ProgressBar1.Value = 10

        Dim dt As New DataTable
        Dim sqlstr As String = "SELECT * FROM RESEPSIONIS WHERE CINOUT = 'CO' AND TGLOUT >= '" + DateTimePickerFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00") + "' AND TGLOUT <= '" + DateTimePickerUntil.Value.Date.ToString("yyyy-MM-dd 23:59:59") + "' ORDER BY TGLIN ASC"
        ProgressBar1.Value = 30
        masuktabel(sqlstr, dt)
        ProgressBar1.Value = 50
        dt.Columns("TRMOYO").SetOrdinal(1)
        dt.Columns("TRMTRF").SetOrdinal(2)
        dt.Columns("TRMTUNAI").SetOrdinal(3)

        DataGridView1.DataSource = dt

        ProgressBar1.Value = 80
        DataGridView1.Columns(0).Visible = False

        Dim TOTALKAMAR As Integer = 0
        'Dim TRMTUNAI As Integer = 0
        For a = 0 To dt.Rows.Count - 1
            TOTALKAMAR = TOTALKAMAR + dt.Rows(a)("TOTALKMR")
            'TRMTUNAI = TRMTUNAI + dt.Rows(a)("TRMTUNAI")
        Next

        ProgressBar1.Value = 100

    End Sub

    Private Sub DateTimePickerFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerFrom.ValueChanged
        ProgressBar1.Value = 0
    End Sub

    Private Sub DateTimePickerUntil_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerUntil.ValueChanged
        ProgressBar1.Value = 0
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim nourut1 = DataGridView1.Rows(e.RowIndex).Cells("URUT").Value
        'Invoice.nourut = nourut1
        'Invoice.Visible = True
        rowindexdt = e.RowIndex
        'cetak''''''''
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If (Control.ModifierKeys = Keys.Control) Then
            Dim URUT As String = DataGridView1.Rows(e.RowIndex).Cells("URUT").Value
            Kedatangan.nourut = URUT
            ISITEXTBOXKEDATANGAN(URUT)
            Me.Visible = False
            Kedatangan.Visible = True
            ISITEXTBOXKEDATANGAN(URUT)
            Kedatangan.Simpanbtn.Visible = False
            Kedatangan.ButtonCheckout.Visible = False
            Kedatangan.ButtonEdit.Visible = True
            Kedatangan.ButtonEdit.Text = "Edit"
            Kedatangan.editan = True
        End If
    End Sub
    Sub ISITEXTBOXKEDATANGAN(ByVal urut As String)
        Dim DT As New DataTable
        Dim sqlstr As String = "SELECT * FROM RESEPSIONIS WHERE URUT = '" + urut + "'"
        masuktabel(sqlstr, DT)
        Kedatangan.TextBoxbid.Text = DT.Rows(0)("BID")
        Kedatangan.TextBoxName.Text = DT.Rows(0)("NAMA")
        Kedatangan.DateTimePicker1.Value = DT.Rows(0)("TGLIN")
        'MsgBox(Kedatangan.DateTimePicker1.Value)
        Kedatangan.ComboBoxOTA.Text = DT.Rows(0)("OTA")
        Kedatangan.ComboBoxTipebyr.Text = DT.Rows(0)("TIPEBYR")
        Kedatangan.TextBoxJMLKMR.Text = DT.Rows(0)("JMLKMR")
        Kedatangan.TextBoxJMLMLM.Text = DT.Rows(0)("JMLMLM")

        Kedatangan.ListBox1.Items.Clear()
        Dim delimiter As Char = ","c
        Dim substrings As String() = DT.Rows(0)("NOKMR").Split(delimiter)
        For Each substring As String In substrings
            'Console.WriteLine(substring)
            Kedatangan.ListBox1.Items.Add(substring)
        Next

        Kedatangan.TextBoxtotalbill.Text = DT.Rows(0)("TOTALBYR")
        Kedatangan.TextBoxCF.Text = DT.Rows(0)("CF")
        Kedatangan.TextBoxExtraBed.Text = DT.Rows(0)("EXTRABED")
        Kedatangan.TextBoxadminfee.Text = DT.Rows(0)("TAMBAH")
        Kedatangan.TextBoxkettambah.Text = DT.Rows(0)("KETTAMBAH")
        Kedatangan.TextBoxpotonganlain.Text = DT.Rows(0)("POTLAIN")
        Kedatangan.TextBoxketpotongan.Text = DT.Rows(0)("KETPOTLN")
        Kedatangan.TextBoxOYO.Text = DT.Rows(0)("TRMOYO")
        Kedatangan.TextBoxTunai.Text = DT.Rows(0)("TRMTUNAI")
        Kedatangan.TextBoxTrf.Text = DT.Rows(0)("TRMTRF")
        Kedatangan.TextBoxHP.Text = DT.Rows(0)("NOHP")
        Kedatangan.ComboBoxKry.Text = DT.Rows(0)("PETUGASIN")
        Kedatangan.TextBoxket.Text = DT.Rows(0)("KETERANGAN")
        Kedatangan.Simpanbtn.Text = "EDIT"
        Kedatangan.GroupBoxCheckout.Visible = True
        Kedatangan.allnotenabled()
        Kedatangan.nourut = urut
        Kedatangan.ComboBoxOUT.Text = DT.Rows(0)("PETUGASOUT")

        Kedatangan.TGLTUNAI = CDate(DT.Rows(0)("TGLOUT"))
        Kedatangan.DateTimePickerOut.Value = CDate(DT.Rows(0)("TGLOUT"))

        ''isi kas
        Dim dtkas As New DataTable
        Dim sqlstrkas As String = " SELECT * FROM KAS WHERE NoResepsionis = '" & urut & "'"
        Kedatangan.DataGridViewTunai.Rows.Clear()
        masuktabel(sqlstrkas, dtkas)
        For A = 0 To dtkas.Rows.Count - 1
            Kedatangan.DataGridViewTunai.Rows.Add()
            Kedatangan.DataGridViewTunai.Rows(Kedatangan.DataGridViewTunai.Rows.Count - 1).Cells("ColumnTgl").Value = CDate(dtkas.Rows(A)("Tanggal")).ToString("dd MMM yyyy HH:mm:ss")
            Kedatangan.DataGridViewTunai.Rows(Kedatangan.DataGridViewTunai.Rows.Count - 1).Cells("ColumnTunai").Value = dtkas.Rows(A)("Masuk")
            Kedatangan.DataGridViewTunai.Rows(Kedatangan.DataGridViewTunai.Rows.Count - 1).Cells("ColumnKeterangan").Value = dtkas.Rows(A)("Keterangan")
            Kedatangan.TGLOUT = CDate(dtkas.Rows(0)("Tanggal"))
        Next
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class