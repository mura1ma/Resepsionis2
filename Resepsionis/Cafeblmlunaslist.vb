Imports System.Data.SqlTypes
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.InteropServices.ComTypes
Imports DocumentFormat.OpenXml.Packaging

Public Class Cafeblmlunaslist
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
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
        Dim logoImage As Image = My.Resources.ResourceManager.GetObject("FORREST_INN")
        'Dim lunas As Image = My.Resources.ResourceManager.GetObject("lunas")
        ''JIKA BELUM LUNAS MAKA STRUK MUNCUL LAIN

        height += 10
        e.Graphics.DrawString("-TOTAL BON-", f14, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 50, 15 + height)

        height += 10
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 35 + height) '*******************************************
        height += 15
        e.Graphics.DrawString("Tanggal ", f8, Brushes.Black, 0, 35 + height)
        e.Graphics.DrawString(": " & DateTimePicker1.Value.ToString("dd-MMM-yyyy HH:mm:ss"), f8, Brushes.Black, 60, 35 + height)

        height += 15
        e.Graphics.DrawString("Nama", f8b, Brushes.Black, 10, 35 + height)
        e.Graphics.DrawString("Total bon", f8b, Brushes.Black, 150, 35 + height)

        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 35 + height)

        For row As Integer = 0 To DataGridView2.RowCount - 1
            'If DataGridView1.Rows(row).Cells("BLMLUNAS").Value = False Then
            height += 15
            e.Graphics.DrawString(DataGridView2.Rows(row).Cells("NAMA").Value.ToString, f8, Brushes.Black, 10, 35 + height)
            e.Graphics.DrawString(CInt(DataGridView2.Rows(row).Cells("TOTAL BON").Value).ToString("Rp #,###").Replace(",", "."), f8, Brushes.Black, 150, 35 + height)

        Next
        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 35 + height)
        height += 10
        e.Graphics.DrawString("TOTAL BON: ", f10, Brushes.Black, 0, 35 + height)
        e.Graphics.DrawString(TextBoxttlbon.Text, f10, Brushes.Black, 150, 35 + height)

        height += 50
        e.Graphics.DrawString(". ", f8, Brushes.Black, 0, 45 + height)

    End Sub

    Private Sub Buttonkembali_Click(sender As Object, e As EventArgs) Handles Buttonkembali.Click
        Me.Close()
        Pendinglist.Visible = True
        Pendinglist.BringToFront()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim NOURUT As Integer = DataGridView1.Rows(e.RowIndex).Cells("URUT").Value
        Cafe.nourutblmbyr = NOURUT
        Cafe.Visible = True
        Cafe.DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells("TGL").Value
        Cafe.TextBoxpelanggan.Text = DataGridView1.Rows(e.RowIndex).Cells("NAMA").Value
        Cafe.TextBoxketerangan.Text = DataGridView1.Rows(e.RowIndex).Cells("KETERANGAN").Value
        Cafe.ComboBoxkry.Text = DataGridView1.Rows(e.RowIndex).Cells("PETUGAS").Value
        For C = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(C).Cells("URUT").Value = NOURUT Then
                Cafe.DataGridView1.Rows.Add()
                Dim itemcafe As New DataGridViewComboBoxCell
                itemcafe = Cafe.DataGridView1.Rows(Cafe.DataGridView1.RowCount - 1).Cells("ITEM")
                Dim dt As New DataTable
                Dim sqlstr As String = "SELECT * FROM ITEMCAFE ORDER BY ITEM ASC"
                masuktabel(sqlstr, dt)
                For A = 0 To dt.Rows.Count - 1
                    itemcafe.Items.Add(dt.Rows(A)("ITEM"))
                Next
                'MsgBox(DataGridView1.Rows(C).Cells("ITEM").Value)
                Cafe.DataGridView1.Rows(Cafe.DataGridView1.Rows.Count - 1).Cells("ITEM").Value = DataGridView1.Rows(C).Cells("ITEM").Value
                Cafe.DataGridView1.Rows(Cafe.DataGridView1.Rows.Count - 1).Cells("KUANTITAS").Value = DataGridView1.Rows(C).Cells("QTTY").Value
                Cafe.DataGridView1.Rows(Cafe.DataGridView1.Rows.Count - 1).Cells("HRG_SATUAN").Value = DataGridView1.Rows(C).Cells("HRGSATUAN").Value
                Cafe.DataGridView1.Rows(Cafe.DataGridView1.Rows.Count - 1).Cells("TTLHARGA").Value = DataGridView1.Rows(C).Cells("TTLHARGA").Value
                Cafe.DataGridView1.Rows(Cafe.DataGridView1.Rows.Count - 1).Cells("HARGAKRY").Value = DataGridView1.Rows(C).Cells("HRGKRY").Value
                Cafe.DataGridView1.Rows(Cafe.DataGridView1.Rows.Count - 1).Cells("BLMLUNAS").Value = DataGridView1.Rows(C).Cells("BLMLUNAS").Value
            End If
        Next
        Cafe.TextBoxpelanggan.Enabled = False
        Cafe.TextBoxketerangan.Enabled = False
        Cafe.ComboBoxkry.Enabled = False
        Cafe.Tambahbtn.Enabled = False
        Cafe.ButtonPenjPemb.Enabled = False
        Cafe.DataGridView1.Columns("ITEM").ReadOnly = True
        Cafe.DataGridView1.Columns("KUANTITAS").ReadOnly = True
        Cafe.DataGridView1.Columns("HARGAKRY").ReadOnly = True

        Me.Close()
    End Sub

    Private Sub Cafeblmlunaslist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd-MMM-yyyy HH:mm:ss"
        Dim dt As New DataTable
        Dim sqlstr As String = "SELECT * FROM TRXCAFE WHERE BLMLUNAS = 'TRUE'"
        masuktabel(sqlstr, dt)
        DataGridView1.DataSource = dt

        ''KUMPULKAN BON JADI SATU
        Dim DTLISTBON As New DataTable
        sqlstr = "SELECT NAMA FROM TRXCAFE WHERE BLMLUNAS = 'TRUE' ORDER BY NAMA ASC"
        masuktabel(sqlstr, DTLISTBON)

        Dim CTR = DTLISTBON.Rows.Count - 1
        Dim LASTNAME As String = DTLISTBON.Rows(CTR)("NAMA").TRIM()
        While CTR > 0
            CTR = CTR - 1
            If DTLISTBON.Rows(CTR)("NAMA") = LASTNAME Then
                DTLISTBON.Rows.RemoveAt(CTR)
            Else
                LASTNAME = DTLISTBON.Rows(CTR)("NAMA")
            End If
        End While

        DTLISTBON.Columns.Add("TOTAL BON", GetType(Integer))

        Dim totalbon As Integer = 0
        Dim totalharga As Integer = 0
        For A = 0 To DTLISTBON.Rows.Count - 1
            DTLISTBON.Rows(A)("TOTAL BON") = 0
            For B = 0 To dt.Rows.Count - 1
                'If IsDBNull(dt.Rows(B)("NAMA")) = False Then
                totalharga = dt.Rows(B)("TTLHARGA")
                If totalharga < 0 Then
                    totalharga = totalharga * -1
                End If
                If DTLISTBON.Rows(A)("NAMA").TRIM() = dt.Rows(B)("NAMA").TRIM() Then
                    DTLISTBON.Rows(A)("TOTAL BON") = DTLISTBON.Rows(A)("TOTAL BON") + totalharga
                    totalbon = totalbon + totalharga
                End If

                'End If
            Next
        Next
        TextBoxttlbon.Text = totalbon.ToString("Rp #,###").Replace(",", ".")

        DataGridView2.DataSource = DTLISTBON


    End Sub

    Private Sub Buttoncetak_Click(sender As Object, e As EventArgs) Handles Buttoncetak.Click
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub
End Class