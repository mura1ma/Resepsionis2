Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Pendinglist
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Kedatangan.Visible = True
        Me.Visible = False
    End Sub

    Private Sub Pendinglist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UPDATELIST()
    End Sub

    Sub UPDATELIST()
        Dim DT As New DataTable
        Dim sqlstr As String = "SELECT BID, NAMA, NOHP, TGLIN, OTA, TIPEBYR, JMLKMR, JMLMLM, TOTALKMR, TOTALBYR, CF, POTLAIN, EXTRABED, TAMBAH, KETTAMBAH , PETUGASIN, URUT FROM RESEPSIONIS WHERE CINOUT = 'CI' ORDER BY TGLIN ASC"
        masuktabel(sqlstr, DT)
        DataGridView1.DataSource = DT
    End Sub


    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim URUT As String = DataGridView1.Rows(e.RowIndex).Cells("URUT").Value
        'MsgBox(DataGridView1.Rows(e.RowIndex).Cells("URUT").Value)
        Kedatangan.nourut = URUT
        ISITEXTBOXKEDATANGAN(URUT)
        Me.Visible = False
        Kedatangan.Visible = True
        ISITEXTBOXKEDATANGAN(URUT)
        Kedatangan.Simpanbtn.Text = "EDIT"
        Kedatangan.ButtonTambah.Visible = True
    End Sub

    Private Sub Pendinglist_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            UPDATELIST()
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
        Next

    End Sub

    Private Sub PetugasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetugasToolStripMenuItem.Click
        Me.Visible = False
        Petugas.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Visible = False
        SelesaiList.Visible = True
    End Sub

    Private Sub PencapaianToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PriveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriveToolStripMenuItem.Click
        Prive.Visible = True
    End Sub

    Private Sub MutasiKAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MutasiKAsToolStripMenuItem.Click
        Transaksi.Visible = True
    End Sub

    Private Sub KasResepsionisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KasResepsionisToolStripMenuItem.Click
        Laporankas.Visible = True
        Me.Visible = False
    End Sub

    Private Sub SelisihToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelisihToolStripMenuItem.Click
        'If InputBox("Password ", "Password", "") = "1" Then
        '    Me.Visible = False
        '    Rekap.Visible = True
        'End If
        Jumlahkmr.Visible = True
    End Sub

    Private Sub TesPrinterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TesPrinterToolStripMenuItem.Click
        PrintTry.Visible = True
    End Sub

    Private Sub PilihPrinterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PilihPrinterToolStripMenuItem.Click
        'PrintDialog1.Document = PrintDocument1
        Dim Namaprinter As String
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            'PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
            Namaprinter = PrintDialog1.PrinterSettings.PrinterName

            Dim filePath As String = "src\PRT.sys"
            If File.Exists(filePath) Then
                Dim objWriter As New System.IO.StreamWriter(filePath)
                objWriter.WriteLine(Namaprinter)
                objWriter.Close()
            Else
                Console.WriteLine("The file does not exist.")
            End If

            MsgBox("Printer kasir yang dipakai : " & Namaprinter)
        End If
    End Sub

    Private Sub SetPrintToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles SetPrintToolStripMenuItem.DropDownOpened
        Dim filePath As String = "src\PRT.sys"
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    'Console.WriteLine(line) ' Print the line to the console (you can process it differently)
                    PrinternToolStripMenuItem.Text = line
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If
        PrinternToolStripMenuItem.Enabled = False
    End Sub

    Private Sub Buttontrxcafe_Click(sender As Object, e As EventArgs) Handles Buttontrxcafe.Click
        Cafe.Visible = True
    End Sub

    Private Sub MasterBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterBarangToolStripMenuItem.Click
        Me.Visible = False
        FormBarang.Visible = True
    End Sub

    Private Sub TransaksiCafeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiCafeToolStripMenuItem.Click
        Cafe.Visible = True
    End Sub

    Private Sub HistoryCafeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryCafeToolStripMenuItem.Click
        Me.Visible = False
        Historycafe.Visible = True
    End Sub

    Private Sub StokCafeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StokCafeToolStripMenuItem.Click
        Me.Visible = False
        StokcafeAll.Visible = True
    End Sub

    Private Sub LaporanPenjualanCafeHarianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPenjualanCafeHarianToolStripMenuItem.Click
        Me.Visible = False
        LapPenjCafe.Visible = True
    End Sub

    Private Sub CafeBlmLunasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CafeBlmLunasToolStripMenuItem.Click
        Me.Visible = False
        Cafeblmlunaslist.Visible = True
    End Sub

    Private Sub PindahGudangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PindahGudangToolStripMenuItem.Click
        Me.Visible = False
        Pindahgudang.Visible = True
    End Sub

    Private Sub PenyesuaianSaldoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenyesuaianSaldoToolStripMenuItem.Click
        Me.Visible = False
        Penyesuaiansaldo.Visible = True
    End Sub

    Private Sub DatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.Click
        Databasechange.Visible = True
        Me.Visible = False
    End Sub
End Class