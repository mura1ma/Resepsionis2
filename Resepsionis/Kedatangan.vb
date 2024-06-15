Imports System.Buffers
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Printing
Imports System.IO
Imports System.Management
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Transactions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DocumentFormat.OpenXml.ExtendedProperties
Imports MySql.Data.MySqlClient

Public Class Kedatangan
    Public nourut As Integer
    Public tgledit As Date
    Public editan As Boolean = False
    Public TGLOUT As Date
    Public TGLTUNAI As Date
    Public passwordsuper As String
    Public jmlinputawal As Integer = 0

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

        If Simpanbtn.Text = "Check In" Then
            line = "################ PEMBAYARAN ####################"
        Else
            line = "****************************************************************"
        End If
        line2 = "----------------------------------------------------------------------------------"
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
        e.Graphics.DrawString("--- In : " & DateTimePicker1.Value.ToString("dd MMMM yyyy") & " ---", f10, Brushes.Black, 37, 40 + height)
        If Simpanbtn.Text <> "Check In" Then
            height += 15
            e.Graphics.DrawString("--- Out: " & DateTimePicker1.Value.ToString("dd MMMM yyyy") & " ---", f10, Brushes.Black, 35, 40 + height)
        End If
        height += 25
        e.Graphics.DrawString("Nama ", f10, Brushes.Black, 5, 45 + height)
        e.Graphics.DrawString(": " & TextBoxName.Text, f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        height += 15
        e.Graphics.DrawString("Jumlah kamar ", f10, Brushes.Black, 5, 45 + height)
        e.Graphics.DrawString(": " & TextBoxJMLKMR.Text & " x " & TextBoxJMLMLM.Text & " malam", f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        height += 15
        Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text)
        e.Graphics.DrawString("Total ", f10, Brushes.Black, 5, 45 + height)
        e.Graphics.DrawString(": Rp. " & ttlbayar.ToString("#,###").Replace(",", "."), f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        height += 25
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 45 + height)
        If TextBoxOYO.Text <> 0 Then
            height += 10
            e.Graphics.DrawString("Pembayaran OYO ", f10b, Brushes.Black, 5, 45 + height)
            e.Graphics.DrawString(": Rp." & CInt(TextBoxOYO.Text).ToString("#,###").Replace(",", "."), f10b, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        End If
        If TextBoxTunai.Text <> 0 Then
            height += 10
            e.Graphics.DrawString("Pembayaran Tunai ", f10b, Brushes.Black, 5, 45 + height)
            e.Graphics.DrawString(": Rp." & CInt(TextBoxTunai.Text).ToString("#,###").Replace(",", "."), f10b, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        End If
        If TextBoxTrf.Text <> 0 Then
            height += 10
            e.Graphics.DrawString("Pembayaran Transfer ", f10b, Brushes.Black, 5, 45 + height)
            e.Graphics.DrawString(": Rp." & CInt(TextBoxTrf.Text).ToString("#,###").Replace(",", "."), f10b, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 10, 45 + height)
        End If
        height += 17
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 45 + height)
        height += 15
        e.Graphics.DrawString("Petugas", f8, Brushes.Black, 10, 45 + height)
        e.Graphics.DrawString("Pelanggan", f8, Brushes.Black, CInt((e.PageBounds.Width) / 2) + 50, 45 + height)

        Dim angka As String = Labelttlbayar.Text.Substring(Labelttlbayar.Text.IndexOf(" "c) + 1)
        angka = angka.Substring(0, CInt(angka.Length) - 2)
        angka = angka.Replace(".", "")
        If angka = "" Then
            angka = 0
        End If

        If angka < 1000 And angka > -1000 Then
            e.Graphics.DrawImage(lunas, CInt((e.PageBounds.Width - 60) / 2), 45 + height, 60, 30)
        ElseIf angka > 1000 Then
            e.Graphics.DrawString("BELUM LUNAS", f14, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)
            height += 17
            e.Graphics.DrawString("Kekurangan = " & angka, f10, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)
        End If

        height += 70
        e.Graphics.DrawString("~Thank you for coming~", f6c, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)
        height += 20
        e.Graphics.DrawString(". ", f8, Brushes.Black, 0, 45 + height)

    End Sub

    Private Sub Kedatangan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' isi combobox
        'MsgBox(DateTimePicker1.Value)
        Dim filePath As String = "src\TBYR.sys"
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Console.WriteLine(line) ' Print the line to the console (you can process it differently)
                    ComboBoxTipebyr.Items.Add(line)
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If
        filePath = "src\OTA.sys"
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Console.WriteLine(line) ' Print the line to the console (you can process it differently)
                    ComboBoxOTA.Items.Add(line)
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If
        'Console.ReadLine()
        filePath = "src\NOKMR.sys"
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Console.WriteLine(line) ' Print the line to the console (you can process it differently)
                    ComboBoxKmr.Items.Add(line)
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If
        Dim sptgs As String = "Select * From PETUGAS WHERE STATUS = 'AKTIF'"
        Dim DT As New DataTable
        masuktabel(sptgs, DT)
        For a = 0 To DT.Rows.Count - 1
            ComboBoxKry.Items.Add(DT.Rows(a)("NAMA"))
            ComboBoxOUT.Items.Add(DT.Rows(a)("NAMA"))
        Next
        ComboBoxTipebyr.Text = ComboBoxTipebyr.Items(0)
        If Me.Visible = True Then
            Try
                'MsgBox(CInt(TextBoxExtraBed.Text))
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
                Labelttlbayar.Text = "Rp. " & CStr(ttlbayar)
            Catch ex As Exception
                Labelttlbayar.Text = "Rp. -"
            End Try
        End If
        jmlinputawal = DataGridViewTunai.RowCount '' tambah input dikosongkan dahulu
    End Sub

    Private Sub Simpanbtn_Click(sender As Object, e As EventArgs) Handles Simpanbtn.Click
        Dim blmlunas As Boolean = False
        Dim angka As String = Labelttlbayar.Text.Substring(Labelttlbayar.Text.IndexOf(" "c) + 1)
        angka = angka.Substring(0, CInt(angka.Length) - 2)
        angka = angka.Replace(".", "")
        If angka = "" Then
            angka = 0
        End If
        'MsgBox(angka)
        If angka > 1000 Then
            If MessageBox.Show("Belum lunas, tetap lanjut?", "Belum lunas", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                savedata()
            End If
        Else
            savedata()
        End If

    End Sub
    Sub savedata()
        If Simpanbtn.Text = "Check In" Then
            'MsgBox(Format(DateTimePicker1.Value), "yyyy-MM-dd HH:mm:ss")

            'ButtonCheckout.Visible = False
            'DateTimePickerOut.Visible = False
            GroupBoxCheckout.Visible = False

            ''cek kelengkapan isian textbox
            Dim lengkap As String = "YA"
            cekkosong(lengkap)

            If lengkap = "YA" Then
                ''if nourut sudah ada  - edit database saja (hapus dulu data lama)
                Dim strurut As String = "SELECT * FROM RESEPSIONIS WHERE URUT  = '" & nourut & "'"
                Dim dturut As New DataTable
                masuktabel(strurut, dturut)

                ''simpan tanggal 
                If editan = True Then
                    tgledit = dturut.Rows(0)("TGLIN")
                    'MsgBox(tgledit)
                End If

                If dturut.Rows.Count > 0 Then
                    strurut = "DELETE FROM RESEPSIONIS WHERE URUT = '" & nourut & "'"
                    masuktabel(strurut, dturut)
                End If

                Dim sqlstr = "SELECT * FROM RESEPSIONIS LIMIT 1"
                Dim dtinput As New DataTable
                INSERTCOLOM(dtinput)
                dtinput.Rows.Add()
                dtinput.Rows(0)("BID") = TextBoxbid.Text
                dtinput.Rows(0)("NAMA") = TextBoxName.Text
                If editan = False Then
                    dtinput.Rows(0)("TGLIN") = DateTimePicker1.Value
                Else
                    dtinput.Rows(0)("TGLIN") = tgledit
                End If
                dtinput.Rows(0)("OTA") = ComboBoxOTA.Text
                dtinput.Rows(0)("TIPEBYR") = ComboBoxTipebyr.Text
                dtinput.Rows(0)("JMLKMR") = TextBoxJMLKMR.Text
                dtinput.Rows(0)("JMLMLM") = TextBoxJMLMLM.Text
                dtinput.Rows(0)("TOTALKMR") = CInt(TextBoxJMLKMR.Text) * CInt(TextBoxJMLMLM.Text)
                Dim nokamar As String = ""
                If ListBox1.Items.Count > 0 Then
                    For Each listItem As Object In ListBox1.Items
                        If nokamar = "" Then
                            nokamar = listItem.ToString()
                        Else
                            nokamar = nokamar + "," + listItem.ToString()
                        End If
                    Next
                End If

                dtinput.Rows(0)("NOKMR") = nokamar
                dtinput.Rows(0)("TOTALBYR") = CInt(TextBoxtotalbill.Text)
                dtinput.Rows(0)("CF") = CInt(TextBoxCF.Text)
                If TextBoxExtraBed.Text <> "" Then
                    dtinput.Rows(0)("EXTRABED") = CInt(TextBoxExtraBed.Text)
                End If
                If TextBoxadminfee.Text <> "" Then
                    dtinput.Rows(0)("TAMBAH") = CInt(TextBoxadminfee.Text)
                End If
                dtinput.Rows(0)("KETTAMBAH") = TextBoxkettambah.Text
                If TextBoxpotonganlain.Text <> "" Then
                    dtinput.Rows(0)("POTLAIN") = CInt(TextBoxpotonganlain.Text)
                End If
                dtinput.Rows(0)("KETPOTLN") = TextBoxketpotongan.Text
                If TextBoxTunai.Text <> "" Then
                    dtinput.Rows(0)("TRMTUNAI") = TextBoxTunai.Text
                End If
                If TextBoxOYO.Text <> "" Then
                    dtinput.Rows(0)("TRMOYO") = TextBoxOYO.Text
                End If
                If TextBoxTrf.Text <> "" Then
                    dtinput.Rows(0)("TRMTRF") = TextBoxTrf.Text
                End If
                dtinput.Rows(0)("NOHP") = TextBoxHP.Text
                dtinput.Rows(0)("PETUGASIN") = ComboBoxKry.Text
                dtinput.Rows(0)("KETERANGAN") = TextBoxket.Text
                dtinput.Rows(0)("CINOUT") = "CI"  ''' CHECK IN
                changedatafromtabel(sqlstr, dtinput)
                UPDATEKAS()
                '''''''''''''''''''cetak invoice pembayaran''''''''''''''''''''
                'If ComboBoxTipebyr.Text = "CS (TUNAI)" Then
                PPD.Document = PD
                PPD.ShowDialog()
                'End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                clear()
                MsgBox("Check In Berhasil")
                Pendinglist.Visible = True

                Me.Close()
            Else
                MsgBox("Lengkapi dulu isian yg bertanda bintang (*) " & lengkap)
            End If
            editan = False
        ElseIf Simpanbtn.Text = "EDIT" Then
            Password.Visible = True
            Password.BringToFront()
        End If
    End Sub

    Sub cekkosong(ByRef lengkap As String)
        If TextBoxbid.Text = "" Then
            lengkap = "BID"
        ElseIf TextBoxName.Text = "" Then
            lengkap = "NAMA"
        ElseIf TextBoxHP.Text = "" Then
            lengkap = "NO HP"
        ElseIf ComboBoxOTA.Text = "" Then
            lengkap = "OTA"
        ElseIf ComboBoxTipebyr.Text = "" Then
            lengkap = "Tipe Byr"
        ElseIf ComboBoxKry.Text = "" Then
            lengkap = "Kasir In"
        ElseIf TextBoxJMLKMR.Text = "" Then
            lengkap = "Jumlah Kamar"
        ElseIf TextBoxJMLMLM.Text = "" Then
            lengkap = "Jumlah Malam"
        ElseIf ListBox1.Items.Count <= 0 Then
            lengkap = "Nomor Kamar"
        ElseIf TextBoxtotalbill.Text = "" Then
            lengkap = "Total bill"
        ElseIf TextBoxCF.Text = "" Then
            lengkap = "Convenience fee"
        ElseIf TextBoxtotalbill.Text = 0 Then
            lengkap = "Total bill tidak boleh 0. Masukkan harga kamar!"
        End If
    End Sub

    Private Sub Buttoninputkamar_Click(sender As Object, e As EventArgs) Handles Buttoninputkamar.Click
        Dim ada As Boolean = False

        For a = 0 To ListBox1.Items.Count - 1
            If ComboBoxKmr.Text = ListBox1.Items(a) Then
                ada = True
                Exit For
            End If
        Next

        If ada = True Then
            MsgBox("Kamar sudah diinput!")
            ada = False
        Else
            ListBox1.Items.Add(ComboBoxKmr.Text)
        End If

    End Sub

    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        Dim selectedIndex As Integer = ListBox1.SelectedIndex

        ' Check if an item was actually clicked (selectedIndex will be -1 if no item is clicked)
        If selectedIndex >= 0 Then
            ' Do something with selectedIndex
            If MessageBox.Show("Hapus kamar " & ListBox1.Items(selectedIndex) & " ?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                ListBox1.Items.RemoveAt(selectedIndex)
            End If
        End If
    End Sub

    Private Sub Simpanbtn_VisibleChanged(sender As Object, e As EventArgs) Handles Simpanbtn.VisibleChanged
        If TextBoxbid.Text = "" Then
            Simpanbtn.Text = "Check In"
            allenabled()
        Else
            Simpanbtn.Text = "Edit"
            allnotenabled()
        End If
    End Sub

    Sub INSERTCOLOM(ByRef TBL As DataTable)
        TBL.Columns.Add("BID")
        TBL.Columns.Add("NAMA")
        TBL.Columns.Add("TGLIN", GetType(DateTime))
        TBL.Columns.Add("OTA")
        TBL.Columns.Add("TIPEBYR")
        TBL.Columns.Add("JMLKMR")
        TBL.Columns.Add("JMLMLM")
        TBL.Columns.Add("TOTALKMR")
        TBL.Columns.Add("NOKMR")
        TBL.Columns.Add("TOTALBYR")
        TBL.Columns.Add("CF")
        TBL.Columns.Add("TAMBAH")
        TBL.Columns.Add("KETTAMBAH")
        TBL.Columns.Add("POTLAIN")
        TBL.Columns.Add("EXTRABED")
        TBL.Columns.Add("KETPOTLN")
        TBL.Columns.Add("TRMTUNAI")
        TBL.Columns.Add("TRMTRF")
        TBL.Columns.Add("TRMOYO")
        TBL.Columns.Add("NOHP")
        TBL.Columns.Add("PETUGASIN")
        TBL.Columns.Add("PETUGASOUT")
        TBL.Columns.Add("KETERANGAN")
        TBL.Columns.Add("SALDO")
        TBL.Columns.Add("CINOUT")
        TBL.Columns.Add("URUT")
    End Sub
    Sub clear()
        TextBoxbid.Text = ""
        TextBoxName.Text = ""
        TextBoxHP.Text = ""
        ComboBoxOTA.Text = ""
        TextBoxket.Text = ""
        ComboBoxKry.Text = ""
        TextBoxJMLKMR.Text = ""
        TextBoxJMLMLM.Text = ""
        ComboBoxKmr.Text = ""
        ListBox1.Items.Clear() ' Clear all items from the ListBox
        TextBoxtotalbill.Text = "0"
        TextBoxCF.Text = ""
        TextBoxpotonganlain.Text = "0"
        TextBoxketpotongan.Text = ""
        TextBoxExtraBed.Text = "0"
        TextBoxadminfee.Text = "0"
        TextBoxOYO.Text = "0"
        TextBoxTunai.Text = "0"
        TextBoxTrf.Text = "0"
        TextBoxkettambah.Text = ""
        ComboBoxOUT.Text = ""
        DataGridViewTunai.Rows.Clear()
        nourut = 0
        editan = False
        'DateTimePicker1.Value = DateTime.Now
        'DateTimePickerOut.Value = DateTime.Now
    End Sub
    Sub allenabled()
        DateTimePicker1.Enabled = True
        TextBoxbid.Enabled = True
        TextBoxName.Enabled = True
        TextBoxHP.Enabled = True
        ComboBoxOTA.Enabled = True
        ComboBoxTipebyr.Enabled = True
        TextBoxket.Enabled = True
        ComboBoxKry.Enabled = True
        TextBoxJMLKMR.Enabled = True
        TextBoxJMLMLM.Enabled = True
        ComboBoxKmr.Enabled = True
        ListBox1.Enabled = True
        TextBoxtotalbill.Enabled = True
        TextBoxCF.Enabled = True
        TextBoxpotonganlain.Enabled = True
        TextBoxketpotongan.Enabled = True
        TextBoxadminfee.Enabled = True
        TextBoxExtraBed.Enabled = True
        If ComboBoxTipebyr.Text = "XEN (OYO)" Then
            TextBoxOYO.Enabled = True
            TextBoxTrf.Enabled = False
            Buttoninputbayar.Enabled = False
            TextBoxInputTunai.Enabled = False
            RichTextBoxKetTunai.Enabled = False
        Else
            TextBoxOYO.Enabled = False
            TextBoxTrf.Enabled = True
            Buttoninputbayar.Enabled = True
            TextBoxInputTunai.Enabled = True
            RichTextBoxKetTunai.Enabled = True
        End If
        GroupBoxPembayaran.Enabled = True
        DataGridViewTunai.Enabled = True
        TextBoxkettambah.Enabled = True

        Try
            Dim angka As Integer = CInt(TextBoxadminfee.Text)
            Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
            Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
        Catch
            MsgBox("Masukkan angka! ")
            If TextBoxadminfee.Text.Length > 0 Then
                TextBoxadminfee.Text = TextBoxadminfee.Text.Remove(TextBoxadminfee.Text.Length - 1)
            Else
                TextBoxadminfee.Text = "0"
            End If
            TextBoxadminfee.SelectionStart = TextBoxadminfee.Text.Length
            TextBoxadminfee.SelectionLength = 0 ' This ensures the cursor is not selecting any text
        End Try

    End Sub
    Sub allnotenabled()
        DateTimePicker1.Enabled = False
        TextBoxbid.Enabled = False
        TextBoxName.Enabled = False
        TextBoxHP.Enabled = False
        ComboBoxOTA.Enabled = False
        ComboBoxTipebyr.Enabled = False
        TextBoxket.Enabled = False
        ComboBoxKry.Enabled = False
        TextBoxJMLKMR.Enabled = False
        TextBoxJMLMLM.Enabled = False
        ComboBoxKmr.Enabled = False
        ListBox1.Enabled = False
        TextBoxtotalbill.Enabled = False
        TextBoxCF.Enabled = False
        TextBoxpotonganlain.Enabled = False
        TextBoxketpotongan.Enabled = False
        'TextBoxadminfee.Enabled = False
        'TextBoxExtraBed.Enabled = False
        'GroupBoxPembayaran.Enabled = False
        TextBoxOYO.Enabled = False
        TextBoxTrf.Enabled = False
        DataGridViewTunai.Enabled = False
        'TextBoxkettambah.Enabled = False

    End Sub

    Private Sub ButtonCheckout_Click(sender As Object, e As EventArgs) Handles ButtonCheckout.Click
        ''saat check out. pembayaran harus sudah diisi (transfer / tunai)
        '
        Dim lengkap As String = "YA"
        cekkosong(lengkap)
        Dim gabung As Integer
        Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
        gabung = CInt(TextBoxOYO.Text) + CInt(TextBoxTunai.Text) + CInt(TextBoxTrf.Text) - (CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text))
        'MsgBox(gabung)
        'MsgBox(CInt(TextBoxtotalbill.Text) + CInt(TextBoxadminfee.Text))

        If ComboBoxOUT.Text = "" Then
            lengkap = "KASIR OUT BELUM DIISI"
        ElseIf gabung = 0 Then
            lengkap = "YA"
        ElseIf CInt(-5000) < gabung And gabung < CInt(5000) Then
            lengkap = "SELISIH PEMBAYARAN = " + ttlbayar.ToString("Rp #,###").Replace(",", ".") & vbNewLine & "Tetap simpan data?"
            If MessageBox.Show(lengkap, "Selisih", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                lengkap = "YA"
            End If
        Else
            lengkap = "Selisih antara pembayaran dan jumalh yg harus dibayar!"
        End If
        If lengkap = "YA" Then
            Dim NOKAMAR As String = ""
            If ListBox1.Items.Count > 0 Then
                For Each listItem As Object In ListBox1.Items
                    If NOKAMAR = "" Then
                        NOKAMAR = listItem.ToString()
                    Else
                        NOKAMAR = NOKAMAR + "," + listItem.ToString()
                    End If
                Next
            End If
            'MsgBox(CDate(DateTimePicker1.Value))
            Dim sqlstr = "UPDATE RESEPSIONIS
                            SET BID = '" & TextBoxbid.Text & "',
                            NAMA = '" & TextBoxName.Text & "' ,
                            TGLIN = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ,
                            TGLOUT = '" & DateTimePickerOut.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ,
                            OTA = '" & ComboBoxOTA.Text & "' ,
                            TIPEBYR = '" & ComboBoxTipebyr.Text & "',
                            JMLKMR = '" & TextBoxJMLKMR.Text & "',
                            JMLMLM = '" & TextBoxJMLMLM.Text & "',
                            TOTALKMR = '" & CInt(TextBoxJMLKMR.Text) * CInt(TextBoxJMLMLM.Text) & "',
                            NOKMR = '" & NOKAMAR & "',
                            TOTALBYR = '" & CInt(TextBoxtotalbill.Text) & "',
                            CF ='" & CInt(TextBoxCF.Text) & "',
                            EXTRABED ='" & TextBoxExtraBed.Text & "',
                            TAMBAH ='" & TextBoxadminfee.Text & "',
                            POTLAIN = '" & TextBoxpotonganlain.Text & "',
                            KETPOTLN = '" & TextBoxketpotongan.Text & "',
                            TRMTUNAI= '" & TextBoxTunai.Text & "',
                            TRMTRF= '" & TextBoxTrf.Text & "',
                            SELISIH= '" & ttlbayar & "',
                            TRMOYO= '" & TextBoxOYO.Text & "',
                            NOHP= '" & TextBoxHP.Text & "',
                            PETUGASIN= '" & ComboBoxKry.Text & "',
                            PETUGASOUT= '" & ComboBoxOUT.Text & "',
                            KETERANGAN= '" & TextBoxket.Text & "',
                            CINOUT = 'CO' 
                            WHERE URUT ='" & nourut & "'"

            Dim dt As New DataTable
            masuktabel(sqlstr, dt)
            MsgBox("CHECK OUT BERHASIL, DATA BERHASIL DISIMPAN")

            If MessageBox.Show("Cetak invoice", "Cetak invoice? ", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                'cetak''''''''
                PPD.Document = PD
                PPD.ShowDialog()
            End If

            clear()
            allenabled()
            GroupBoxCheckout.Visible = False
            'printinvoice()
            Pendinglist.Visible = True
            Me.Close()
        Else
            If lengkap.Contains("SELISIH PEMBAYARAN =") Then
            Else
                MsgBox(lengkap)
            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Pendinglist.Visible = True
        clear()
        SelesaiList.Close()
        Me.Close()
    End Sub

    Private Sub Simpanbtn_TextChanged(sender As Object, e As EventArgs) Handles Simpanbtn.TextChanged
        If Simpanbtn.Text = "Edit" Then
            GroupBoxCheckout.Visible = True
            'ButtonCheckout.Visible = True
            'DateTimePickerOut.Visible = True
        End If
    End Sub


    Private Sub TextBoxOYO_TextChanged(sender As Object, e As EventArgs) Handles TextBoxOYO.TextChanged
        If TextBoxOYO.Text <> "0" Then
            Try
                checknull()
                If TextBoxTunai.Text = "" Then
                    TextBoxTunai.Text = "0"
                End If
                Dim angka As Integer = CInt(TextBoxOYO.Text)
                'MsgBox("TTLBILL-" & TextBoxtotalbill.Text & "- ADMFEE-" & TextBoxadminfee.Text & "- EXBED-" & TextBoxExtraBed.Text & "- TUNAI-" & TextBoxTunai.Text & "- TRF-" & TextBoxTrf.Text & "- OYO-" & TextBoxOYO.Text)
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
                Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
            Catch
                MsgBox("Masukkan angka! ")
                If TextBoxOYO.Text.Length > 0 Then
                    TextBoxOYO.Text = TextBoxOYO.Text.Remove(TextBoxOYO.Text.Length - 1)
                Else
                    TextBoxOYO.Text = "0"
                End If
                TextBoxOYO.SelectionStart = TextBoxOYO.Text.Length
                TextBoxOYO.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxOYO.Text = "0"
        End If
    End Sub

    Private Sub TextBoxadminfee_TextChanged(sender As Object, e As EventArgs) Handles TextBoxadminfee.TextChanged
        If TextBoxadminfee.Text <> "0" And Me.Visible = True Then
            Try
                Dim angka As Integer = CInt(TextBoxadminfee.Text)
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
                Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
                If TextBoxExtraBed.Text + TextBoxadminfee.Text <> 0 Then
                    Buttoninputbayar.Enabled = True
                    TextBoxInputTunai.Enabled = True
                    RichTextBoxKetTunai.Enabled = True
                    TextBoxTrf.Enabled = True
                Else
                    TextBoxOYO.Enabled = True
                    TextBoxTrf.Enabled = False
                    Buttoninputbayar.Enabled = False
                    TextBoxInputTunai.Enabled = False
                    RichTextBoxKetTunai.Enabled = False
                    TextBoxTrf.Enabled = False
                End If
            Catch
                MsgBox("Masukkan angka! ")
                If TextBoxadminfee.Text.Length > 0 Then
                    TextBoxadminfee.Text = TextBoxadminfee.Text.Remove(TextBoxadminfee.Text.Length - 1)
                Else
                    TextBoxadminfee.Text = "0"
                End If
                TextBoxadminfee.SelectionStart = TextBoxadminfee.Text.Length
                TextBoxadminfee.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxadminfee.Text = "0"
        End If

    End Sub

    Private Sub TextBoxCF_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCF.TextChanged
        If TextBoxCF.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxCF.Text)
            Catch
                MsgBox("Masukkan angka! ")
                TextBoxCF.Text = TextBoxCF.Text.Remove(TextBoxCF.Text.Length - 1)
                TextBoxCF.SelectionStart = TextBoxCF.Text.Length
                TextBoxCF.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        End If
    End Sub

    Private Sub TextBoxJMLKMR_TextChanged(sender As Object, e As EventArgs) Handles TextBoxJMLKMR.TextChanged
        If TextBoxJMLKMR.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxJMLKMR.Text)
            Catch
                MsgBox("Masukkan angka! ")
                TextBoxJMLKMR.Text = TextBoxJMLKMR.Text.Remove(TextBoxJMLKMR.Text.Length - 1)
                TextBoxJMLKMR.SelectionStart = TextBoxJMLKMR.Text.Length
                TextBoxJMLKMR.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        End If
    End Sub

    Private Sub TextBoxJMLMLM_TextChanged(sender As Object, e As EventArgs) Handles TextBoxJMLMLM.TextChanged
        If TextBoxJMLMLM.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxJMLMLM.Text)
            Catch
                MsgBox("Masukkan angka! ")
                TextBoxJMLMLM.Text = TextBoxJMLMLM.Text.Remove(TextBoxJMLMLM.Text.Length - 1)
                TextBoxJMLMLM.SelectionStart = TextBoxJMLMLM.Text.Length
                TextBoxJMLMLM.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        End If
    End Sub

    Private Sub TextBoxpotonganlain_TextChanged(sender As Object, e As EventArgs) Handles TextBoxpotonganlain.TextChanged
        'If TextBoxpotonganlain.Text <> "" Then
        'Try
        '    Dim angka As Integer = CInt(TextBoxpotonganlain.Text)
        'Catch
        '    MsgBox("Masukkan angka! ")
        '    TextBoxpotonganlain.Text = TextBoxpotonganlain.Text.Remove(TextBoxpotonganlain.Text.Length - 1)
        '    TextBoxpotonganlain.SelectionStart = TextBoxpotonganlain.Text.Length
        '    TextBoxpotonganlain.SelectionLength = 0 ' This ensures the cursor is not selecting any text
        'End Try
        If TextBoxpotonganlain.Text <> "0" Then
            Try
                checknull()
                If TextBoxTunai.Text = "" Then
                    TextBoxTunai.Text = "0"
                End If
                Dim angka As Integer = CInt(TextBoxpotonganlain.Text)
                'MsgBox("TTLBILL-" & TextBoxtotalbill.Text & "- ADMFEE-" & TextBoxadminfee.Text & "- EXBED-" & TextBoxExtraBed.Text & "- TUNAI-" & TextBoxTunai.Text & "- TRF-" & TextBoxTrf.Text & "- OYO-" & textboxpotonganlain.Text)
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
                Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
            Catch
                MsgBox("Masukkan angka! ")
                If TextBoxpotonganlain.Text.Length > 0 Then
                    TextBoxpotonganlain.Text = TextBoxpotonganlain.Text.Remove(TextBoxpotonganlain.Text.Length - 1)
                Else
                    TextBoxpotonganlain.Text = "0"
                End If
                TextBoxpotonganlain.SelectionStart = TextBoxpotonganlain.Text.Length
                TextBoxpotonganlain.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxpotonganlain.Text = "0"
        End If
        'End If
    End Sub

    Private Sub TextBoxtotalbill_TextChanged(sender As Object, e As EventArgs) Handles TextBoxtotalbill.TextChanged
        If TextBoxtotalbill.Text <> "" And Me.Visible = True Then
            Try
                Dim angka As Integer = CInt(TextBoxtotalbill.Text)
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
                Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
            Catch
                MsgBox("Masukkan angka! ")
                TextBoxtotalbill.Text = TextBoxtotalbill.Text.Remove(TextBoxtotalbill.Text.Length - 1)
                TextBoxtotalbill.SelectionStart = TextBoxtotalbill.Text.Length
                TextBoxtotalbill.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxtotalbill.Text = "0"
        End If
    End Sub

    Private Sub TextBoxTrf_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTrf.TextChanged
        If TextBoxTrf.Text <> "0" Then
            Try
                Dim angka As Integer = CInt(TextBoxTrf.Text)
                checknull()
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
                Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
            Catch
                MsgBox("Masukkan angka! ")
                If TextBoxTrf.Text.Length > 0 Then
                    TextBoxTrf.Text = TextBoxTrf.Text.Remove(TextBoxTrf.Text.Length - 1)
                Else
                    TextBoxTrf.Text = "0"
                End If
                TextBoxTrf.SelectionStart = TextBoxTrf.Text.Length
                TextBoxTrf.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxTrf.Text = "0"
        End If
    End Sub

    Private Sub TextBoxTunai_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTunai.TextChanged
        If TextBoxTunai.Text <> "0" Then
            Try
                Dim angka As Integer = CInt(TextBoxTunai.Text)
                checknull()
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)

                Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
                'MsgBox(Labelttlbayar.Text & "  " & CStr(ttlbayar) & " " & CStr(TextBoxTunai.Text))
            Catch
                MsgBox("Masukkan angka! ")
                If TextBoxTunai.Text.Length > 0 Then
                    TextBoxTunai.Text = TextBoxTunai.Text.Remove(TextBoxTunai.Text.Length - 1)
                Else
                    TextBoxTunai.Text = "0"
                End If
                TextBoxTunai.SelectionStart = TextBoxTunai.Text.Length
                TextBoxTunai.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxTunai.Text = "0"
        End If
    End Sub

    Private Sub TextBoxExtraBed_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExtraBed.TextChanged
        If TextBoxExtraBed.Text <> "" And Me.Visible = True Then
            Try
                Dim angka As Integer = CInt(TextBoxExtraBed.Text)
                Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
                Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
                If TextBoxExtraBed.Text + TextBoxadminfee.Text <> 0 Then
                    Buttoninputbayar.Enabled = True
                    TextBoxInputTunai.Enabled = True
                    RichTextBoxKetTunai.Enabled = True
                    TextBoxTrf.Enabled = True
                Else
                    TextBoxOYO.Enabled = True
                    TextBoxTrf.Enabled = False
                    Buttoninputbayar.Enabled = False
                    TextBoxInputTunai.Enabled = False
                    RichTextBoxKetTunai.Enabled = False
                    TextBoxTrf.Enabled = False
                End If
            Catch
                MsgBox("Masukkan angka! ")
                TextBoxExtraBed.Text = TextBoxExtraBed.Text.Remove(TextBoxExtraBed.Text.Length - 1)
                TextBoxExtraBed.SelectionStart = TextBoxExtraBed.Text.Length
                TextBoxExtraBed.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxExtraBed.Text = "0"
        End If
    End Sub

    Private Sub TextBoxInputTunai_TextChanged(sender As Object, e As EventArgs) Handles TextBoxInputTunai.TextChanged
        If TextBoxInputTunai.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxInputTunai.Text)
            Catch
                MsgBox("Masukkan angka! ")
                TextBoxInputTunai.Text = TextBoxInputTunai.Text.Remove(TextBoxInputTunai.Text.Length - 1)
                TextBoxInputTunai.SelectionStart = TextBoxInputTunai.Text.Length
                TextBoxInputTunai.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxInputTunai.Text = "0"
        End If
    End Sub

    Sub UPDATEKAS()
        ''DAPATKAN SALDO DAHULU
        Dim dtsld As New DataTable
        Dim sqlsld As String = "SELECT * FROM KAS WHERE NoResepsionis = '" & nourut & "'"
        masuktabel(sqlsld, dtsld)
        If dtsld.Rows.Count - 1 > 0 Then
            'MsgBox((CDate(dtsld.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd")))
            UPDATESALDOKAS(CDate(dtsld.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd"))
        End If


        ''hapus data kas sesuai no urut
        Dim dtkas As New DataTable
        Dim sqlstrkas As String = "DELETE FROM KAS WHERE NoResepsionis = '" & nourut & "'"
        masuktabel(sqlstrkas, dtkas)


        Dim dt As New DataTable
        Dim SQLSTR As String = "SELECT * FROM RESEPSIONIS ORDER BY URUT DESC LIMIT 1"
        'If nourut = 0 Then
        masuktabel(SQLSTR, dt)
        nourut = dt.Rows(0)("URUT")
        ' End If

        Dim DTINPUT As New DataTable
        DTINPUT.Columns.Add("NoResepsionis")
        DTINPUT.Columns.Add("Tanggal")
        DTINPUT.Columns.Add("Keterangan")
        DTINPUT.Columns.Add("Masuk")
        For a = 0 To DataGridViewTunai.Rows.Count - 1
            DTINPUT.Rows.Add()
            DTINPUT.Rows(DTINPUT.Rows.Count - 1)("NoResepsionis") = nourut
            DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Tanggal") = CDate(DataGridViewTunai.Rows(a).Cells("ColumnTgl").Value).ToString("yyyy-MM-dd HH:mm:ss")
            DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keterangan") = DataGridViewTunai.Rows(a).Cells("ColumnKeterangan").Value
            DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Masuk") = DataGridViewTunai.Rows(a).Cells("ColumnTunai").Value
        Next

        Dim STRINGSQL As String = "SELECT * FROM KAS ORDER BY URUT DESC LIMIT 1"


        Dim DTSALDO As New DataTable
        masuktabel(STRINGSQL, DTSALDO)
        changedatafromtabel(STRINGSQL, DTINPUT)
        'UPDATESALDOKAS(CDate(DTSALDO.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd HH:mm:ss"))
        UPDATESALDOKAS(CDate(DTSALDO.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd 00:00:00"))
    End Sub

    Sub UPDATESALDOKAS(ByVal tglupdate As String)
        Dim saldoawal As Integer = 0
        ' Dim urutawal As Integer = DTSALDO.Rows(0)("URUT")
        'Dim tglupdate As String = CDate(DTSALDO.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd")
        'MsgBox(tglupdate)

        Dim updatesaldo As Integer = 0
        Dim sqlstrupdatesaldo As String
        Dim DTTANGGAL As New DataTable
        Dim SQLSTR As String = "SELECT * FROM KAS WHERE TANGGAL >= '" & tglupdate & "' ORDER BY TANGGAL ASC"
        masuktabel(SQLSTR, DTTANGGAL)

        Dim DTSALDONEW As New DataTable
        If DTTANGGAL.Rows.Count - 1 > 0 Then
            ''DAPATKAN SALDO AKHIR SEBLUM DIUPDATE
            'MsgBox(tglupdate)
            Dim SQLSTR2 As String = "SELECT * FROM KAS WHERE TANGGAL < '" & tglupdate & "' ORDER BY TANGGAL DESC LIMIT 1"
            'MsgBox(SQLSTR2)
            Dim DTTANGGAL2 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL2)
            SQLSTR2 = "SELECT * FROM KAS WHERE TANGGAL = '" & CDate(DTTANGGAL2.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL ASC"
            Dim DTTANGGAL3 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL3)
            'MsgBox(SQLSTR2)
            updatesaldo = DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("SALDO")

            'MsgBox(DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("TANGGAL") & "  " & DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("SALDO"))

            For A = 0 To DTTANGGAL.Rows.Count - 1
                updatesaldo = updatesaldo + CInt(DTTANGGAL.Rows(A)("MASUK")) - CInt(DTTANGGAL.Rows(A)("KELUAR"))
                'MsgBox(updatesaldo & "MASUK=" & DTTANGGAL.Rows(A)("MASUK") & " KELUAR = " & DTTANGGAL.Rows(A)("KELUAR"))
                sqlstrupdatesaldo = "UPDATE KAS SET SALDO = '" & updatesaldo & "' WHERE URUT = '" & DTTANGGAL.Rows(A)("URUT") & "'"
                masuktabel(sqlstrupdatesaldo, DTSALDONEW)
                'urutawal = urutawal + 1
            Next
            'Else
            '    'updatesaldo = 0
            '    'sqlstrupdatesaldo = "UPDATE KAS SET SALDO = '" & updatesaldo & "'"
            '    'masuktabel(sqlstrupdatesaldo, DTSALDONEW)
            '    MsgBox("masuk sini")
        End If

    End Sub

    Private Sub Buttoninputbayar_Click(sender As Object, e As EventArgs) Handles Buttoninputbayar.Click
        If TextBoxInputTunai.Text = 0 Then
            MsgBox("Masukkan angka")
            TextBoxInputTunai.Focus()
        Else
            DataGridViewTunai.Rows.Add()
            DataGridViewTunai.Rows(DataGridViewTunai.Rows.Count - 1).Cells("ColumnTgl").Value = DateTimePickertunai.Value.ToString("dd MMM yyyy HH:mm:ss")
            DataGridViewTunai.Rows(DataGridViewTunai.Rows.Count - 1).Cells("Columntunai").Value = TextBoxInputTunai.Text
            DataGridViewTunai.Rows(DataGridViewTunai.Rows.Count - 1).Cells("Columnketerangan").Value = RichTextBoxKetTunai.Text

            Dim totaltunai As Integer = 0
            For a = 0 To DataGridViewTunai.Rows.Count - 1
                totaltunai = totaltunai + DataGridViewTunai.Rows(a).Cells("Columntunai").Value
            Next
            TextBoxTunai.Text = totaltunai

            RichTextBoxKetTunai.Text = ""
            TextBoxInputTunai.Text = ""
        End If

        'End If
    End Sub
    Sub checknull()
        If TextBoxExtraBed.Text = "" Then
            TextBoxExtraBed.Text = "0"
        ElseIf TextBoxadminfee.Text = "" Then
            TextBoxadminfee.Text = "0"
        ElseIf TextBoxTunai.Text = "" Then
            TextBoxTunai.Text = "0"
        ElseIf TextBoxTrf.Text = "" Then
            TextBoxTrf.Text = "0"
        ElseIf TextBoxOYO.Text = "" Then
            TextBoxOYO.Text = "0"
        ElseIf TextBoxtotalbill.Text = "" Then
            TextBoxtotalbill.Text = "0"
        End If
    End Sub

    Private Sub DataGridViewTunai_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewTunai.CellDoubleClick
        'MsgBox(e.RowIndex)
        If MessageBox.Show("Yakin hapus data? ", "Hapus?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            'MsgBox(DataGridViewTunai.Rows.Count - 1)
            DataGridViewTunai.Rows.Remove(DataGridViewTunai.Rows(e.RowIndex))

            'MsgBox(DataGridViewTunai.Rows.Count - 1)
            Dim tunai As Integer = 0
            For A = 0 To DataGridViewTunai.Rows.Count - 1
                tunai = tunai + DataGridViewTunai.Rows(A).Cells("ColumnTunai").Value
            Next
            TextBoxTunai.Text = tunai
            Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
            Labelttlbayar.Text = ttlbayar.ToString("Rp #,###").Replace(",", ".") & ",-"
        End If
    End Sub

    Private Sub ComboBoxTipebyr_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxTipebyr.TextChanged
        If ComboBoxTipebyr.Text = "XEN (OYO)" Then
            If TextBoxExtraBed.Text + TextBoxadminfee.Text = 0 Then
                TextBoxOYO.Enabled = True
                TextBoxTrf.Enabled = False
                Buttoninputbayar.Enabled = False
                TextBoxInputTunai.Enabled = False
                RichTextBoxKetTunai.Enabled = False
            Else
                TextBoxOYO.Enabled = False
                TextBoxTrf.Enabled = True
                Buttoninputbayar.Enabled = True
                TextBoxInputTunai.Enabled = True
                RichTextBoxKetTunai.Enabled = True
            End If
        Else
            TextBoxOYO.Enabled = False
            TextBoxTrf.Enabled = True
            Buttoninputbayar.Enabled = True
            TextBoxInputTunai.Enabled = True
            RichTextBoxKetTunai.Enabled = True
        End If
    End Sub

    Private Sub Kedatangan_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            clear()
        End If
    End Sub

    Private Sub TextBoxInputTunai_EnabledChanged(sender As Object, e As EventArgs) Handles TextBoxInputTunai.EnabledChanged
        If TextBoxInputTunai.Enabled = True Then
            If editan = False Then
                DateTimePickertunai.Value = Now
            End If
        End If
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        'DateTimePickerOut.Value = TGLOUT
        'DateTimePickertunai.Value = TGLTUNAI

        If ButtonEdit.Text = "Edit" Then
            Password.Visible = True
        ElseIf ButtonEdit.Text = "Simpan" Then
            Dim lengkap As String = "YA"
            cekkosong(lengkap)
            Dim gabung As Integer
            Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
            gabung = CInt(TextBoxOYO.Text) + CInt(TextBoxTunai.Text) + CInt(TextBoxTrf.Text) - (CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text))
            'MsgBox(gabung)
            'MsgBox(CInt(TextBoxtotalbill.Text) + CInt(TextBoxadminfee.Text))

            If ComboBoxOUT.Text = "" Then
                lengkap = "KASIR OUT BELUM DIISI"
            ElseIf gabung = 0 Then
                lengkap = "YA"
            ElseIf CInt(-5000) < gabung And gabung < CInt(5000) Then
                lengkap = "SELISIH PEMBAYARAN = " + ttlbayar.ToString("Rp #,###").Replace(",", ".") & vbNewLine & "Tetap simpan data?"
                If MessageBox.Show(lengkap, "Selisih", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    lengkap = "YA"
                End If
            Else
                lengkap = "Selisih antara pembayaran dan jumalh yg harus dibayar!"
            End If
            If lengkap = "YA" Then
                'MsgBox(nourut)
                Dim NOKAMAR As String = ""
                If ListBox1.Items.Count > 0 Then
                    For Each listItem As Object In ListBox1.Items
                        If NOKAMAR = "" Then
                            NOKAMAR = listItem.ToString()
                        Else
                            NOKAMAR = NOKAMAR + "," + listItem.ToString()
                        End If
                    Next
                End If
                'MsgBox(CDate(DateTimePicker1.Value))
                Dim sqlstr = "UPDATE RESEPSIONIS
                            SET BID = '" & TextBoxbid.Text & "',
                            NAMA = '" & TextBoxName.Text & "' ,
                            TGLIN = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ,
                            TGLOUT = '" & DateTimePickerOut.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ,
                            OTA = '" & ComboBoxOTA.Text & "' ,
                            TIPEBYR = '" & ComboBoxTipebyr.Text & "',
                            JMLKMR = '" & TextBoxJMLKMR.Text & "',
                            JMLMLM = '" & TextBoxJMLMLM.Text & "',
                            TOTALKMR = '" & CInt(TextBoxJMLKMR.Text) * CInt(TextBoxJMLMLM.Text) & "',
                            NOKMR = '" & NOKAMAR & "',
                            TOTALBYR = '" & CInt(TextBoxtotalbill.Text) & "',
                            CF ='" & CInt(TextBoxCF.Text) & "',
                            EXTRABED ='" & TextBoxExtraBed.Text & "',
                            TAMBAH ='" & TextBoxadminfee.Text & "',
                            POTLAIN = '" & TextBoxpotonganlain.Text & "',
                            KETPOTLN = '" & TextBoxketpotongan.Text & "',
                            TRMTUNAI= '" & TextBoxTunai.Text & "',
                            TRMTRF= '" & TextBoxTrf.Text & "',
                            SELISIH= '" & ttlbayar & "',
                            TRMOYO= '" & TextBoxOYO.Text & "',
                            NOHP= '" & TextBoxHP.Text & "',
                            PETUGASIN= '" & ComboBoxKry.Text & "',
                            PETUGASOUT= '" & ComboBoxOUT.Text & "',
                            KETERANGAN= '" & TextBoxket.Text & "',
                            CINOUT = 'CO' 
                            WHERE URUT ='" & nourut & "'"

                Dim dt As New DataTable
                masuktabel(sqlstr, dt)

                ''UPDATE DATA KAS
                'case 1 : kas salah nominal
                'case 2 : salah transfer seharusnya kas
                'case 3 : salah kas seharusnya transfer


                UPDATEKASEDIT()


                MsgBox("EDIT DATA BERHASIL, DATA BERHASIL DISIMPAN")
                clear()
                allenabled()
                GroupBoxCheckout.Visible = False
                'printinvoice()
                Pendinglist.Visible = True
                Me.Close()
                SelesaiList.Close()
            End If

        End If
        'SelesaiList.Close()
        'Me.Close()
        'SelesaiList.Visible = True
    End Sub
    Sub UPDATEKASEDIT()
        '''DAPATKAN SALDO DAHULU
        Dim dtsld As New DataTable
        Dim sqlsld As String = "SELECT * FROM KAS WHERE NoResepsionis = '" & nourut & "'"
        masuktabel(sqlsld, dtsld)

        If dtsld.Rows.Count - 1 >= 0 Then  ''kalo no urut ada (berarti case 1 salah nominal kas)
            Dim DTINPUT As New DataTable
            DTINPUT.Columns.Add("NoResepsionis")
            DTINPUT.Columns.Add("Tanggal")
            DTINPUT.Columns.Add("Keterangan")
            DTINPUT.Columns.Add("Keluar")
            ''masukkan data minus utk membalik
            For a = 0 To dtsld.Rows.Count - 1
                DTINPUT.Rows.Add()
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("NoResepsionis") = -nourut
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Tanggal") = CDate(dtsld.Rows(a)("Tanggal")).ToString("yyyy-MM-dd HH:mm:ss")
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keterangan") = "#EDIT# " & Now.Date.ToString("yyyy-MM-dd HH:mm:ss")
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keluar") = dtsld.Rows(a)("MASUK")
            Next

            Dim STRINGSQL As String = "SELECT * FROM KAS ORDER BY URUT DESC LIMIT 1"
            changedatafromtabel(STRINGSQL, DTINPUT)
            ''masukkan data baru
            DTINPUT.Rows.Clear()
            For a = 0 To DataGridViewTunai.Rows.Count - 1
                DTINPUT.Rows.Add()
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("NoResepsionis") = nourut
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Tanggal") = CDate(DataGridViewTunai.Rows(a).Cells("ColumnTgl").Value).ToString("yyyy-MM-dd HH:mm:ss")
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keterangan") = "#PEMBETULAN# " & DataGridViewTunai.Rows(a).Cells("ColumnKeterangan").Value
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Masuk") = DataGridViewTunai.Rows(a).Cells("ColumnTunai").Value
            Next

            changedatafromtabel(STRINGSQL, DTINPUT)

            Dim DTSALDO As New DataTable
            masuktabel(STRINGSQL, DTSALDO)
            UPDATESALDOKAS(CDate(dtsld.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd HH:mm:ss"))

        Else   'kalo no urut tidak ada (berarti bukan case 1 salah nominal kas)

            Dim DTINPUT As New DataTable
            DTINPUT.Columns.Add("NoResepsionis")
            DTINPUT.Columns.Add("Tanggal")
            DTINPUT.Columns.Add("Keterangan")
            DTINPUT.Columns.Add("Keluar")
            DTINPUT.Columns.Add("Masuk")
            ''masukkan data baru
            DTINPUT.Rows.Clear()
            For a = 0 To DataGridViewTunai.Rows.Count - 1
                DTINPUT.Rows.Add()
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("NoResepsionis") = nourut
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Tanggal") = CDate(DataGridViewTunai.Rows(a).Cells("ColumnTgl").Value).ToString("yyyy-MM-dd HH:mm:ss")
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keterangan") = "#PEMBETULAN# " & DataGridViewTunai.Rows(a).Cells("ColumnKeterangan").Value
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Masuk") = DataGridViewTunai.Rows(a).Cells("ColumnTunai").Value
                DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keluar") = "0"
            Next
            Dim STRINGSQL As String = "SELECT * FROM KAS ORDER BY URUT DESC LIMIT 1"
            changedatafromtabel(STRINGSQL, DTINPUT)


            UPDATESALDOKAS(CDate(DataGridViewTunai.Rows(0).Cells("ColumnTgl").Value).ToString("yyyy-MM-dd HH:mm:ss"))



        End If
    End Sub

    Private Sub ButtonTambah_Click(sender As Object, e As EventArgs) Handles ButtonTambah.Click
        'If TextBoxInputTunai.Text = 0 Then
        '    MsgBox("Isi pembayaran dahulu!")
        'Else
        Dim gabung As Integer
            Dim ttlbayar As Integer = CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text) - CInt(TextBoxTunai.Text) - CInt(TextBoxTrf.Text) - CInt(TextBoxOYO.Text)
            gabung = CInt(TextBoxOYO.Text) + CInt(TextBoxTunai.Text) + CInt(TextBoxTrf.Text) - (CInt(TextBoxtotalbill.Text) - CInt(TextBoxpotonganlain.Text) + CInt(TextBoxadminfee.Text) + CInt(TextBoxExtraBed.Text))

            Dim sqlstr = "UPDATE RESEPSIONIS
                            SET 
                            TOTALBYR = '" & CInt(TextBoxtotalbill.Text) & "',
                            CF ='" & CInt(TextBoxCF.Text) & "',
                            EXTRABED ='" & TextBoxExtraBed.Text & "',
                            TAMBAH ='" & TextBoxadminfee.Text & "',
                            POTLAIN = '" & TextBoxpotonganlain.Text & "',
                            KETPOTLN = '" & TextBoxketpotongan.Text & "',
                            TRMTUNAI= '" & TextBoxTunai.Text & "',
                            TRMTRF= '" & TextBoxTrf.Text & "',
                            SELISIH= '" & ttlbayar & "',
                            TRMOYO= '" & TextBoxOYO.Text & "'                     
                            WHERE URUT ='" & nourut & "'"

            Dim dt As New DataTable
            masuktabel(sqlstr, dt)


        'UPDATEKASEDIT()
        Dim DTINPUT As New DataTable
        DTINPUT.Columns.Add("NoResepsionis")
        DTINPUT.Columns.Add("Tanggal")
        DTINPUT.Columns.Add("Keterangan")
        DTINPUT.Columns.Add("Keluar")
        DTINPUT.Columns.Add("Masuk")
        ''masukkan data baru
        DTINPUT.Rows.Clear()
        If DataGridViewTunai.RowCount > jmlinputawal Then
            If DataGridViewTunai.Rows.Count > 0 Then
                For a = jmlinputawal To DataGridViewTunai.Rows.Count - 1
                    DTINPUT.Rows.Add()
                    DTINPUT.Rows(DTINPUT.Rows.Count - 1)("NoResepsionis") = nourut
                    DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Tanggal") = CDate(DataGridViewTunai.Rows(a).Cells("ColumnTgl").Value).ToString("yyyy-MM-dd HH:mm:ss")
                    DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keterangan") = "+TAMBAH+ " & DataGridViewTunai.Rows(a).Cells("ColumnKeterangan").Value
                    DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Masuk") = DataGridViewTunai.Rows(a).Cells("ColumnTunai").Value
                    DTINPUT.Rows(DTINPUT.Rows.Count - 1)("Keluar") = "0"
                Next
                Dim STRINGSQL As String = "SELECT * FROM KAS ORDER BY URUT DESC LIMIT 1"
                changedatafromtabel(STRINGSQL, DTINPUT)
                UPDATESALDOKAS(CDate(DataGridViewTunai.Rows(0).Cells("ColumnTgl").Value).ToString("yyyy-MM-dd HH:mm:ss"))
            End If
            jmlinputawal = 0
        End If




        MsgBox("EDIT DATA BERHASIL, DATA BERHASIL DISIMPAN")
            clear()
            allenabled()
            GroupBoxCheckout.Visible = False
            'printinvoice()
            Pendinglist.Visible = True
            Me.Close()
            SelesaiList.Close()
        'End If
    End Sub
End Class