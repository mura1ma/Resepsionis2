Imports DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing
Imports MySql.Data.MySqlClient
Imports System.Data.SqlTypes
Imports System.Diagnostics.Eventing.Reader
Imports System.Drawing.Printing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class Cafe
    Public rownb As Integer
    Public totaltrx As Integer
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
    Public nourutblmbyr As Integer
    Dim TRXLUNAS As Boolean = True

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
        Dim lunas As Image = My.Resources.ResourceManager.GetObject("lunas")
        ''JIKA BELUM LUNAS MAKA STRUK MUNCUL LAIN
        If TRXLUNAS = True Then
            If totaltrx > 0 Then  ''jika minus maka bon, belum lunas
                e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - 150) / 2), 5, 150, 35)
                height += 10
                e.Graphics.DrawString("Jl Raya Jong Biru 285 ", f6c, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 50, 35 + height)
                height += 10
                e.Graphics.DrawString("Tlp. 0895-1432-1888", f6c, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 48, 35 + height)
            Else
                height += 10
                e.Graphics.DrawString("-STRUK BON-", f14, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 50, 15 + height)
            End If
        Else
            height += 10
            e.Graphics.DrawString("-STRUK BON-", f14, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 50, 15 + height)

        End If

        height += 10
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 35 + height) '*******************************************
        height += 15
        e.Graphics.DrawString("Tanggal ", f8, Brushes.Black, 0, 35 + height)
        e.Graphics.DrawString(": " & DateTimePicker1.Value.ToString("dd-MMM-yyyy HH:mm:ss"), f8, Brushes.Black, 60, 35 + height)
        height += 15
        e.Graphics.DrawString("Nama ", f8, Brushes.Black, 0, 35 + height)
        e.Graphics.DrawString(": " & TextBoxpelanggan.Text, f8, Brushes.Black, 60, 35 + height)
        height += 15
        e.Graphics.DrawString("Keterangan ", f8, Brushes.Black, 0, 35 + height)
        e.Graphics.DrawString(": " & TextBoxketerangan.Text, f8, Brushes.Black, 60, 35 + height)
        height += 15
        e.Graphics.DrawString("Qty", f8b, Brushes.Black, 0, 35 + height)
        e.Graphics.DrawString("Item", f8b, Brushes.Black, 25, 35 + height)
        e.Graphics.DrawString("Price", f8b, Brushes.Black, 180, 35 + height, right)
        e.Graphics.DrawString("Total", f8b, Brushes.Black, rightmargin, 35 + height, right)
        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 35 + height)

        For row As Integer = 0 To DataGridView1.RowCount - 1
            'If DataGridView1.Rows(row).Cells("BLMLUNAS").Value = False Then
            height += 15
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells("KUANTITAS").Value.ToString, f8, Brushes.Black, 0, 35 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells("ITEM").Value.ToString, f8, Brushes.Black, 25, 35 + height)
            i = DataGridView1.Rows(row).Cells(2).Value
            'DataGridView1.Rows(row).Cells("HRG_SATUAN").Value = Format(i, "##,##0")
            e.Graphics.DrawString(CInt(DataGridView1.Rows(row).Cells("HRG_SATUAN").Value).ToString("Rp #,###").Replace(",", "."), f8, Brushes.Black, 180, 35 + height, right)

            'totalprice
            'Dim totalprice As Long
            'totalprice = Val(DataGridView1.Rows(row).Cells(1).Value * DataGridView1.Rows(row).Cells(2).Value)
            e.Graphics.DrawString(CInt(DataGridView1.Rows(row).Cells("TTLHARGA").Value).ToString("Rp #,###").Replace(",", "."), f8, Brushes.Black, rightmargin, 35 + height, right)
            '
            'End If
        Next
        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 35 + height)
        height += 10
        e.Graphics.DrawString("TOTAL: ", f10, Brushes.Black, 0, 35 + height)
        e.Graphics.DrawString(CInt(totaltrx).ToString("Rp #,###").Replace(",", "."), f10, Brushes.Black, rightmargin, 35 + height, right)
        height += 10
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 35 + height)
        If TRXLUNAS = True Then
            If totaltrx > 0 Then
                e.Graphics.DrawImage(lunas, CInt((e.PageBounds.Width - 60) / 2), 45 + height, 60, 30)   ''jika minus maka bon, belum lunas
            End If
        End If
        height += 15
        e.Graphics.DrawString("Petugas", f8, Brushes.Black, 10, 45 + height)
        e.Graphics.DrawString("Pelanggan", f8, Brushes.Black, CInt((e.PageBounds.Width) / 2) + 50, 45 + height)
        height += 70
        e.Graphics.DrawString("~Thank you for coming~", f6c, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)
        height += 20
        e.Graphics.DrawString(". ", f8, Brushes.Black, 0, 45 + height)

    End Sub

    Private Sub Cafe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sptgs As String = "Select * From PETUGAS WHERE STATUS = 'AKTIF'"
        Dim DTpts As New DataTable
        masuktabel(sptgs, DTpts)
        For a = 0 To DTpts.Rows.Count - 1
            ComboBoxkry.Items.Add(DTpts.Rows(a)("NAMA"))
        Next

    End Sub


    Private Sub Tambahbtn_Click(sender As Object, e As EventArgs) Handles Tambahbtn.Click
        DataGridView1.Rows.Add()
        Dim itemcafe As New DataGridViewComboBoxCell
        itemcafe = DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("ITEM")
        Dim dt As New DataTable
        Dim sqlstr As String = "SELECT * FROM ITEMCAFE WHERE STATUS = 'AKTIF' ORDER BY ITEM ASC"
        masuktabel(sqlstr, dt)
        For A = 0 To dt.Rows.Count - 1
            itemcafe.Items.Add(dt.Rows(A)("ITEM"))
        Next
        ''tambahkan item gudang untuk item2 yg ada gudang nya 
        For b = 0 To dt.Rows.Count - 1
            If IsDBNull(dt.Rows(b)("GUDANG")) = False Then
                If dt.Rows(b)("GUDANG") = "AKTIF" And ButtonPenjPemb.Text = "Pembelian" Then
                    itemcafe.Items.Add(dt.Rows(b)("ITEM") & " - GUDANG")
                End If
            End If
        Next
        itemcafe.Sorted = True
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Tambahbtn.Enabled = True Then
            DataGridView1.Rows.RemoveAt(e.RowIndex)
            Dim subtotal As Integer = 0
            For a = 0 To DataGridView1.RowCount - 1
                subtotal = subtotal + DataGridView1.Rows(a).Cells("ttlHarga").Value
            Next
            totaltrx = subtotal
            TextBoxsubtotal.Text = subtotal.ToString("#,###").Replace(",", ".")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Buttoncancel.Click
        Me.Close()
        Pendinglist.Visible = True
        Pendinglist.BringToFront()
    End Sub

    Private Sub Buttonsimpan_Click(sender As Object, e As EventArgs) Handles Buttonsimpan.Click
        Dim petujuklunas As String = ""
        If totaltrx > 0 Then
            petujuklunas = "LUNAS! "
        Else
            petujuklunas = "PERHATIAN, BARANG BELUM LUNAS! "
        End If
        If MessageBox.Show(petujuklunas & " Yakin simpan?", petujuklunas, MessageBoxButtons.YesNo) = DialogResult.Yes Then
            If ButtonPenjPemb.Text = "Penjualan" Then
                ''check jika data sudah ada isi
                If TextBoxpelanggan.Text = "" Then
                    MsgBox("Masukkan pelanggan")
                ElseIf ComboBoxkry.Text = "" Then
                    MsgBox("Masukkan petugas")
                Else

                    Dim coba As Integer = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("KUANTITAS").Value

                    If DataGridView1.Rows.Count - 1 >= 0 Then
                        Dim itemkosong As Boolean = IsDBNull(DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("ITEM").Value)
                        Dim kuantitaskosong As Boolean = IsDBNull(DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("KUANTITAS").Value)
                        Dim keteranganbon As String = ""
                        'MsgBox(coba)
                        If itemkosong = True Or kuantitaskosong = True Or coba = 0 Then
                            MsgBox("ITEM DAN KUANTITAS HARUS DIISI (Hapus / isi item terakhir)")
                        Else
                            Dim dtkas As New DataTable
                            Dim sqlstrsaldo = "SELECT * FROM CAFE ORDER BY TANGGAL DESC LIMIT 1"
                            Dim DTSALDO As New DataTable
                            masuktabel(sqlstrsaldo, DTSALDO)
                            If totaltrx < 0 Then
                                keteranganbon = "+BON+ "
                            End If

                            Dim sqlstrkas = "INSERT INTO CAFE (TANGGAL, KETERANGAN, MASUK, KELUAR, SALDO)
                                VALUES ('" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "', 
                                '" & keteranganbon & "TRXCAFE * " & TextBoxpelanggan.Text & " * " & TextBoxketerangan.Text & "',
                                '" & totaltrx & "', 
                                '0' , '" & CInt(DTSALDO.Rows(0)("SALDO")) + CInt(totaltrx) & "')"

                            masuktabel(sqlstrkas, dtkas)
                            UPDATESALDOLAIN(DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), "Cafe")

                            ''Save to tabel trxcafe
                            Dim dturutakhir As New DataTable
                            Dim strsqlurutakhir As String = "SELECT * FROM CAFE ORDER BY URUT DESC LIMIT 1"
                            masuktabel(strsqlurutakhir, dturutakhir)
                            Dim nourut As Integer = 0
                            If dturutakhir.Rows.Count > 0 Then
                                nourut = dturutakhir.Rows(0)("URUT")
                            End If

                            If Tambahbtn.Enabled = True Then
                                '''' jika pengisian normal
                                Dim sqlstrtrx = "SELECT * FROM TRXCAFE LIMIT 1"
                                Dim dttrx As New DataTable
                                INSERTCOLOM(dttrx)

                                For A = 0 To DataGridView1.Rows.Count - 1
                                    dttrx.Rows.Add()
                                    dttrx.Rows(A)("TGL") = DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                    dttrx.Rows(A)("NAMA") = TextBoxpelanggan.Text
                                    dttrx.Rows(A)("KETERANGAN") = TextBoxketerangan.Text
                                    dttrx.Rows(A)("URUT") = nourut
                                    dttrx.Rows(A)("ITEM") = DataGridView1.Rows(A).Cells("ITEM").Value
                                    dttrx.Rows(A)("QTTY") = DataGridView1.Rows(A).Cells("KUANTITAS").Value
                                    dttrx.Rows(A)("HRGSATUAN") = DataGridView1.Rows(A).Cells("HRG_SATUAN").Value
                                    dttrx.Rows(A)("TTLHARGA") = DataGridView1.Rows(A).Cells("TTLHARGA").Value
                                    If DataGridView1.Rows(A).Cells("HARGAKRY").Value = "True" Then
                                        dttrx.Rows(A)("HRGKRY") = "True"
                                    Else
                                        dttrx.Rows(A)("HRGKRY") = "False"
                                    End If
                                    dttrx.Rows(A)("PETUGAS") = ComboBoxkry.Text
                                    If DataGridView1.Rows(A).Cells("BLMLUNAS").Value = "True" Then
                                        dttrx.Rows(A)("BLMLUNAS") = "True"
                                    Else
                                        dttrx.Rows(A)("TGLBYR") = DateTime.Now().ToString("yyyy-MM-dd HH:mm:ss")
                                        dttrx.Rows(A)("BLMLUNAS") = "False"
                                    End If
                                Next
                                changedatafromtabel(sqlstrtrx, dttrx)

                            Else  '''''''jika pembayaran nota yang belum lunas'''''
                                Dim sqlstrlacak As String = "SELECT * FROM TRXCAFE WHERE URUT = '" & nourutblmbyr & "'"
                                Dim DTLACAK As New DataTable
                                masuktabel(sqlstrlacak, DTLACAK)
                                Dim sqlbayar As String
                                Dim DTUPDATE As New DataTable
                                For a = 0 To DTLACAK.Rows.Count - 1
                                    sqlbayar = "UPDATE TRXCAFE SET URUT = '" & nourutblmbyr + 1 & "', BLMLUNAS = 'False' , TGLBYR = '" & CStr(DateTime.Now().ToString("yyyy-MM-dd HH:mm:ss")) & "' WHERE ID = '" & DTLACAK.Rows(a)("ID") & "' AND BLMLUNAS = 'TRUE'"
                                    masuktabel(sqlbayar, DTUPDATE)
                                Next
                            End If
                            If TextBoxsubtotal.Text <> "" Then
                                'cetak''''''''
                                'MsgBox(TextBoxsubtotal.Text)
                                TRXLUNAS = True
                            Else
                                TRXLUNAS = False
                                MsgBox("Belum lunas")
                            End If
                            PPD.Document = PD
                            PPD.ShowDialog()

                            MsgBox("DATA BERHASIL DISIMPAN!")
                            Me.Close()
                            Pendinglist.Visible = True
                            Pendinglist.BringToFront()
                        End If
                    Else
                        MsgBox("Tambahkan data dahulu")
                    End If
                End If

            ElseIf ButtonPenjPemb.Text = "Pembelian" Then
                ''check jika data sudah ada isi
                If TextBoxpelanggan.Text = "" Then
                    MsgBox("Masukkan pelanggan")
                ElseIf ComboBoxkry.Text = "" Then
                    MsgBox("Masukkan petugas")
                Else
                    If DataGridView1.Rows.Count - 1 >= 0 Then
                        Dim itemkosong As Boolean = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("ITEM").Value = ""
                        Dim kuantitaskosong As Boolean = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("KUANTITAS").Value = ""

                        If itemkosong Or kuantitaskosong = True Then
                            MsgBox("ITEM DAN KUANTITAS HARUS DIISI (Hapus / isi item terakhir)")
                        Else
                            Dim dturutakhir As New DataTable
                            Dim strsqlurutakhir As String = "SELECT * FROM CAFE ORDER BY URUT DESC LIMIT 1"
                            masuktabel(strsqlurutakhir, dturutakhir)
                            Dim nourut As Integer = 0
                            If dturutakhir.Rows.Count > 0 Then
                                nourut = dturutakhir.Rows(0)("URUT")
                            End If
                            Dim sqlstrtrx = "SELECT * FROM TRXCAFE LIMIT 1"
                            Dim dttrx As New DataTable
                            INSERTCOLOM(dttrx)

                            For A = 0 To DataGridView1.Rows.Count - 1
                                dttrx.Rows.Add()
                                dttrx.Rows(A)("TGL") = DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")
                                dttrx.Rows(A)("NAMA") = TextBoxpelanggan.Text
                                dttrx.Rows(A)("KETERANGAN") = TextBoxketerangan.Text
                                dttrx.Rows(A)("URUT") = nourut
                                dttrx.Rows(A)("ITEM") = DataGridView1.Rows(A).Cells("ITEM").Value
                                dttrx.Rows(A)("QTTY") = -1 * DataGridView1.Rows(A).Cells("KUANTITAS").Value
                                dttrx.Rows(A)("HRGSATUAN") = DataGridView1.Rows(A).Cells("HRG_SATUAN").Value
                                dttrx.Rows(A)("TTLHARGA") = DataGridView1.Rows(A).Cells("TTLHARGA").Value
                                dttrx.Rows(A)("PETUGAS") = ComboBoxkry.Text
                            Next
                            changedatafromtabel(sqlstrtrx, dttrx)
                            MsgBox("DATA BERHASIL DISIMPAN!")
                            Me.Close()
                            Pendinglist.Visible = True
                            Pendinglist.BringToFront()
                        End If
                    Else
                        MsgBox("Tambahkan data dahulu")
                    End If
                End If
            End If
        End If

    End Sub
    Sub UPDATESALDOLAIN(ByVal tglupdate As String, ByVal buku As String)
        Dim saldoawal As Integer = 0

        Dim updatesaldo As Integer = 0
        Dim sqlstrupdatesaldo As String
        Dim DTTANGGAL As New DataTable
        Dim SQLSTR As String = "SELECT * FROM " & buku & " WHERE TANGGAL >= '" & tglupdate & "' ORDER BY TANGGAL ASC"
        'MsgBox(SQLSTR)
        masuktabel(SQLSTR, DTTANGGAL)

        Dim DTSALDONEW As New DataTable
        If DTTANGGAL.Rows.Count - 1 > 0 Then
            ''DAPATKAN SALDO AKHIR SEBLUM DIUPDATE
            Dim SQLSTR2 As String = "SELECT * FROM " & buku & " WHERE TANGGAL < '" & tglupdate & "' ORDER BY TANGGAL DESC LIMIT 1"
            'MsgBox(SQLSTR2)
            Dim DTTANGGAL2 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL2)
            SQLSTR2 = "SELECT * FROM " & buku & " WHERE TANGGAL = '" & CDate(DTTANGGAL2.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL ASC"
            Dim DTTANGGAL3 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL3)
            updatesaldo = DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("SALDO")

            'MsgBox(DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("TANGGAL") & "  " & DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("KETERANGAN"))

            For A = 0 To DTTANGGAL.Rows.Count - 1
                updatesaldo = updatesaldo + CInt(DTTANGGAL.Rows(A)("MASUK")) - CInt(DTTANGGAL.Rows(A)("KELUAR"))
                'MsgBox(updatesaldo & "MASUK=" & DTTANGGAL.Rows(A)("MASUK") & " KELUAR = " & DTTANGGAL.Rows(A)("KELUAR"))
                sqlstrupdatesaldo = "UPDATE " & buku & " SET SALDO = '" & updatesaldo & "' WHERE URUT = '" & DTTANGGAL.Rows(A)("URUT") & "'"
                masuktabel(sqlstrupdatesaldo, DTSALDONEW)
                'urutawal = urutawal + 1
            Next
        End If
    End Sub

    Private Sub TextBoxsubtotal_TextChanged(sender As Object, e As EventArgs) Handles TextBoxsubtotal.TextChanged
        DateTimePicker1.Value = Now()
        'MsgBox(DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"))
    End Sub

    Sub INSERTCOLOM(ByRef TBL As DataTable)
        TBL.Columns.Add("TGL")
        TBL.Columns.Add("NAMA")
        TBL.Columns.Add("KETERANGAN")
        TBL.Columns.Add("URUT")
        TBL.Columns.Add("ITEM")
        TBL.Columns.Add("QTTY")
        TBL.Columns.Add("HRGSATUAN")
        TBL.Columns.Add("TTLHARGA")
        TBL.Columns.Add("HRGKRY")
        TBL.Columns.Add("PETUGAS")
        TBL.Columns.Add("BLMLUNAS")
        TBL.Columns.Add("TGLBYR")
    End Sub

    Private Sub ButtonPenjPemb_Click(sender As Object, e As EventArgs) Handles ButtonPenjPemb.Click
        If ButtonPenjPemb.Text = "Penjualan" Then
            ButtonPenjPemb.Text = "Pembelian"
            Me.BackColor = Color.LightSkyBlue
            Label3.Text = "Supplier"
            DataGridView1.Columns.Remove("Hargakry")
            DataGridView1.Columns.Remove("Blmlunas")
            DataGridView1.Columns("Hrg_satuan").ReadOnly = False
            DateTimePicker1.Enabled = True
            ''hapus semua data saat diganti
            Dim row As Integer = DataGridView1.RowCount - 1
            While row >= 0
                DataGridView1.Rows.RemoveAt(row)
                row = row - 1
            End While
        ElseIf ButtonPenjPemb.Text = "Pembelian" Then
            ButtonPenjPemb.Text = "Penjualan"
            Me.BackColor = Color.Snow
            Label3.Text = "Pelanggan"

            Dim AddColumnkry As New DataGridViewCheckBoxColumn
            With AddColumnkry
                .HeaderText = "Harga Karyawan"
                .Name = "Hargakry"
            End With
            DataGridView1.Columns.Add(AddColumnkry)

            Dim AddColumnlunas As New DataGridViewCheckBoxColumn
            With AddColumnlunas
                .HeaderText = "Belum lunas"
                .Name = "Blmlunas"
            End With
            DataGridView1.Columns.Add(AddColumnlunas)

            DataGridView1.Columns("Hrg_satuan").ReadOnly = True
            DateTimePicker1.Enabled = False
            ''hapus semua data saat diganti
            Dim row As Integer = DataGridView1.RowCount - 1
            While row >= 0
                DataGridView1.Rows.RemoveAt(row)
                row = row - 1
            End While
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        'MsgBox(DataGridView1.Rows(0).Cells("KUANTITAS").Value)
        If ButtonPenjPemb.Text = "Penjualan" Then
            Try
                If DataGridView1.RowCount > 0 Then
                    'MsgBox(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                    If IsDBNull(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value) = False Then
                        Dim checker As Integer = DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value
                        If DataGridView1.Rows(e.RowIndex).Cells("ITEM").Value <> "" Then
                            Dim sqlstr As String = "SELECT * FROM ITEMCAFE WHERE ITEM = '" & DataGridView1.Rows(e.RowIndex).Cells("ITEM").Value & "' ORDER BY ITEM ASC"
                            Dim DT As New DataTable
                            masuktabel(sqlstr, DT)
                            Dim hargasatuan As Integer = 0
                            If DataGridView1.Rows(e.RowIndex).Cells("Hargakry").Value = "True" Then
                                hargasatuan = DT.Rows(0)("hargakry")
                                DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value = hargasatuan
                                DataGridView1.Rows(e.RowIndex).Cells("ttlHarga").Value = CInt(DT.Rows(0)("hargakry")) * CInt(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                            Else
                                hargasatuan = DT.Rows(0)("harga1")
                                DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value = hargasatuan
                                DataGridView1.Rows(e.RowIndex).Cells("ttlHarga").Value = CInt(DT.Rows(0)("harga1")) * CInt(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                            End If
                        End If
                        Dim subtotal As Integer = 0

                        For c = 0 To DataGridView1.RowCount - 1
                            'MsgBox(DataGridView1.Rows(c).Cells("Blmlunas").Value)
                            If IsDBNull(DataGridView1.Rows(c).Cells("Blmlunas").Value) Then
                                DataGridView1.Rows(c).Cells("Blmlunas").Value = False
                            End If
                            If DataGridView1.Rows(c).Cells("Blmlunas").Value = False Then
                                subtotal = subtotal + DataGridView1.Rows(c).Cells("ttlHarga").Value
                                If subtotal < 0 Then
                                    subtotal = subtotal * -1 '''balik jika mau bayar bon
                                End If
                            End If
                            If DataGridView1.Rows(c).Cells("Blmlunas").Value = True Then
                                If DataGridView1.Rows(c).Cells("ttlHarga").Value < 0 Then ''' jika bon (harga minus)
                                    subtotal = subtotal + DataGridView1.Rows(c).Cells("ttlHarga").Value
                                End If
                            End If
                        Next
                        totaltrx = subtotal
                        TextBoxsubtotal.Text = subtotal.ToString("#,###").Replace(",", ".")

                    Else
                        DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("ttlharga").Value = ""
                    End If
                End If
            Catch ex As Exception
                'MsgBox(ex.ToString)
                MsgBox("Masukkan angka")
                DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value = ""
            End Try
        ElseIf ButtonPenjPemb.Text = "Pembelian" Then
            If DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value <> "" And DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value Then
                DataGridView1.Rows(e.RowIndex).Cells("ttlHarga").Value = CInt(DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value) * CInt(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                Dim subtotal As Integer = 0

                For c = 0 To DataGridView1.RowCount - 1
                    subtotal = subtotal + DataGridView1.Rows(c).Cells("ttlHarga").Value
                Next
                totaltrx = subtotal
                TextBoxsubtotal.Text = subtotal.ToString("#,###").Replace(",", ".")
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        'MsgBox(DataGridView1.Rows(0).Cells("KUANTITAS").Value)
        If ButtonPenjPemb.Text = "Penjualan" Then
            Try
                If DataGridView1.RowCount > 0 Then
                    'MsgBox(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                    If IsDBNull(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value) = False Then
                        Dim checker As Integer = DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value
                        If DataGridView1.Rows(e.RowIndex).Cells("ITEM").Value <> "" Then
                            Dim sqlstr As String = "SELECT * FROM ITEMCAFE WHERE ITEM = '" & DataGridView1.Rows(e.RowIndex).Cells("ITEM").Value & "' ORDER BY ITEM ASC"
                            Dim DT As New DataTable
                            masuktabel(sqlstr, DT)
                            Dim hargasatuan As Integer = 0
                            If DataGridView1.Rows(e.RowIndex).Cells("Hargakry").Value = "True" Then
                                hargasatuan = DT.Rows(0)("hargakry")
                                DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value = hargasatuan
                                DataGridView1.Rows(e.RowIndex).Cells("ttlHarga").Value = CInt(DT.Rows(0)("hargakry")) * CInt(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                            Else
                                hargasatuan = DT.Rows(0)("harga1")
                                DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value = hargasatuan
                                DataGridView1.Rows(e.RowIndex).Cells("ttlHarga").Value = CInt(DT.Rows(0)("harga1")) * CInt(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                            End If
                        End If
                        Dim subtotal As Integer = 0

                        For c = 0 To DataGridView1.RowCount - 1
                            'MsgBox(DataGridView1.Rows(c).Cells("Blmlunas").Value)
                            If IsDBNull(DataGridView1.Rows(c).Cells("Blmlunas").Value) Then
                                DataGridView1.Rows(c).Cells("Blmlunas").Value = False
                            End If
                            If DataGridView1.Rows(c).Cells("Blmlunas").Value = False Then
                                subtotal = subtotal + DataGridView1.Rows(c).Cells("ttlHarga").Value
                                If subtotal < 0 Then
                                    subtotal = subtotal * -1 '''balik jika mau bayar bon
                                End If
                            End If
                            If DataGridView1.Rows(c).Cells("Blmlunas").Value = True Then
                                If DataGridView1.Rows(c).Cells("ttlHarga").Value < 0 Then ''' jika bon (harga minus)
                                    subtotal = subtotal + DataGridView1.Rows(c).Cells("ttlHarga").Value
                                End If
                            End If
                        Next
                        totaltrx = subtotal
                        TextBoxsubtotal.Text = subtotal.ToString("#,###").Replace(",", ".")

                    Else
                        DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value = ""
                        DataGridView1.Rows(e.RowIndex).Cells("ttlharga").Value = ""
                    End If
                End If
            Catch ex As Exception
                'MsgBox(ex.ToString)
                MsgBox("Masukkan angka")
                DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value = ""
            End Try
        ElseIf ButtonPenjPemb.Text = "Pembelian" Then
            If DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value <> "" And DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value Then
                DataGridView1.Rows(e.RowIndex).Cells("ttlHarga").Value = CInt(DataGridView1.Rows(e.RowIndex).Cells("Hrg_satuan").Value) * CInt(DataGridView1.Rows(e.RowIndex).Cells("Kuantitas").Value)
                Dim subtotal As Integer = 0

                For c = 0 To DataGridView1.RowCount - 1
                    subtotal = subtotal + DataGridView1.Rows(c).Cells("ttlHarga").Value
                Next
                totaltrx = subtotal
                TextBoxsubtotal.Text = subtotal.ToString("#,###").Replace(",", ".")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonBonus.Click
        If DataGridView1.RowCount > 0 Then
            Passwordcafe.Visible = True
        Else
            MsgBox("Isi data dahulu, harga bisa diisi sesukanya")
        End If
    End Sub
End Class