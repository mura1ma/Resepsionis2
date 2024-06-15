Imports MySql.Data.MySqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Printing
Imports System.IO



Public Class Prive

    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer


    Private Sub PD_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, 250) 'fixed size
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
        line = "****************************************************************"

        'range from top
        'logo

        Dim logoImage As Image = My.Resources.ResourceManager.GetObject("FORREST_INN")
        'e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - 150) / 2), 5, 150, 35)
        'e.Graphics.DrawString(line, f8, Brushes.Black, 0, 40)

        Dim height As Integer 'DGV Position
        Dim i As Long

        height += 15
        e.Graphics.DrawString("-- Tanggal: " & DateTimePickerPrive.Value.ToString("dd MMMM yyyy") & " --", f10, Brushes.Black, 37, height)
        height += 15
        e.Graphics.DrawString("Prive Resepsionis       : Rp. " & CInt(TextBoxPrive.Text).ToString("#,###").Replace(",", "."), f10, Brushes.Black, 0, height)
        height += 15
        e.Graphics.DrawString("Prive Cafe                   : Rp. " & CInt(TextBoxCafe.Text).ToString("#,###").Replace(",", "."), f10, Brushes.Black, 0, height)
        height += 15
        e.Graphics.DrawString("Tambah Kas belanja  : Rp. " & CInt(TextBoxBelanja.Text).ToString("#,###").Replace(",", "."), f10, Brushes.Black, 0, height)
        height += 20
        e.Graphics.DrawString("***** SISA SALDO ***** ", f14, Brushes.Black, 0, height)
        height += 25
        e.Graphics.DrawString("Saldo Resepsionis : Rp. " & CInt(TextBoxSaldoResepsionis.Text).ToString("#,###").Replace(",", "."), f8, Brushes.Black, 0, height)
        height += 15
        e.Graphics.DrawString("Saldo Cafe               : Rp. " & CInt(TextBoxSaldoCafe.Text).ToString("#,###").Replace(",", "."), f8, Brushes.Black, 0, height)
        height += 15
        e.Graphics.DrawString("Saldo Kas belanja  : Rp. " & CInt(TextBoxSaldoBelanja.Text).ToString("#,###").Replace(",", "."), f8, Brushes.Black, 0, height)

        height += 35
        e.Graphics.DrawString(". ", f8, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), height)

    End Sub

    Private Sub ButtonProses_Click(sender As Object, e As EventArgs) Handles ButtonProses.Click
        tampilhistory()
    End Sub
    Sub tampilhistory()
        Dim dt As New DataTable
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        Dim BUKU As String = ""
        If ComboBox1.Text = "Resepsionis" Then
            BUKU = "kas"
        ElseIf ComboBox1.Text = "Cafe" Then
            BUKU = "cafe"
        ElseIf ComboBox1.Text = "Kas Belanja" Then
            BUKU = "kasbelanja"
        Else
            MsgBox("Masukkan buku")
        End If

        If BUKU <> "" Then
            Dim sqlstr As String = "SELECT * FROM " & BUKU & " WHERE TANGGAL >= '" & DateTimePickerAWAL.Value.Date.ToString("yyyy-MM-dd") & "' AND TANGGAL <= '" & DateTimePickerAKHIR.Value.Date.ToString("yyyy-MM-dd 23:59:59") & "' ORDER BY TANGGAL ASC"
            masuktabel(sqlstr, dt)
            DataGridView1.DataSource = dt
            DataGridView1.Columns(0).Visible = False
            If BUKU = "kas" Then
                DataGridView1.Columns(1).Visible = False
            End If

        End If
    End Sub


    Private Sub Buttonsimpan_Click(sender As Object, e As EventArgs) Handles Buttonsimpan.Click
        Dim dt As New DataTable
        DateTimePickerAWAL.Value = DateTimePickerPrive.Value

        ''MASUK BUKU KAS
        Dim SQLsaldo As String = "SELECT * FROM KAS WHERE TANGGAL <= '" & DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(SQLsaldo, dt)

        Dim SALDO As Integer = 0
        If dt.Rows.Count - 1 >= 0 Then
            SALDO = dt.Rows(0)("SALDO")
        End If
        SALDO = SALDO - CInt(TextBoxPrive.Text)

        dt = New DataTable
        Dim sqlstr As String = "INSERT INTO KAS (NORESEPSIONIS, TANGGAL, KETERANGAN, MASUK, KELUAR, SALDO)
                                VALUES ( '-1', '" & DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss") & "', 
                                '-PRIVE-', '0', '" & TextBoxPrive.Text & "', '" & SALDO & "') "
        'MsgBox(sqlstr)
        masuktabel(sqlstr, dt)
        TextBoxSaldoResepsionis.Text = SALDO

        ''''''MASUK BUKU CAFE
        dt = New DataTable
        SQLsaldo = "SELECT * FROM CAFE WHERE TANGGAL <= '" & DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(SQLsaldo, dt)

        SALDO = 0
        If dt.Rows.Count - 1 >= 0 Then
            SALDO = dt.Rows(0)("SALDO")
        End If
        SALDO = SALDO - CInt(TextBoxCafe.Text)

        dt = New DataTable
        sqlstr = "INSERT INTO CAFE (TANGGAL, KETERANGAN, MASUK, KELUAR, SALDO)
                                VALUES ( '" & DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss") & "', 
                                '-PRIVE-', '0', '" & TextBoxCafe.Text & "', '" & SALDO & "') "
        masuktabel(sqlstr, dt)
        TextBoxSaldoCafe.Text = SALDO


        '''''''MASUK BUKU KAS BELANJA
        dt = New DataTable
        SQLsaldo = "SELECT * FROM KASBELANJA WHERE TANGGAL <= '" & DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(SQLsaldo, dt)

        SALDO = 0
        If dt.Rows.Count - 1 >= 0 Then
            SALDO = dt.Rows(0)("SALDO")
        End If
        SALDO = SALDO + CInt(TextBoxBelanja.Text)

        dt = New DataTable
        sqlstr = "INSERT INTO KASBELANJA (TANGGAL, KETERANGAN, MASUK, KELUAR, SALDO)
                                VALUES ( '" & DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss") & "', 
                                '-TAMBAH-',  '" & TextBoxBelanja.Text & "', '0', '" & SALDO & "') "
        masuktabel(sqlstr, dt)
        TextBoxSaldoBelanja.Text = SALDO

        UPDATESALDOKAS(DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss"))
        UPDATESALDOLAIN(DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss"), "KASBELANJA")
        UPDATESALDOLAIN(DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss"), "CAFE")
        sqlstr = "SELECT * FROM KAS WHERE TANGGAL = '" + DateTimePickerPrive.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY TANGGAL DESC"
        dt = New DataTable
        masuktabel(sqlstr, dt)


        MsgBox("INPUT BERHASIL")
        ComboBox1.Text = "Resepsionis"
        tampilhistory()
        PPD.Document = PD
        PPD.ShowDialog()

        TextBoxPrive.Text = ""
        TextBoxCafe.Text = ""
        TextBoxBelanja.Text = ""
        DateTimePickerPrive.Value = DateAndTime.Now

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
        'MsgBox(SQLSTR)
        masuktabel(SQLSTR, DTTANGGAL)

        Dim DTSALDONEW As New DataTable
        If DTTANGGAL.Rows.Count - 1 > 0 Then
            ''DAPATKAN SALDO AKHIR SEBLUM DIUPDATE
            Dim SQLSTR2 As String = "SELECT * FROM KAS WHERE TANGGAL < '" & tglupdate & "' ORDER BY TANGGAL DESC LIMIT 1"
            'MsgBox(SQLSTR2)
            Dim DTTANGGAL2 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL2)
            SQLSTR2 = "SELECT * FROM KAS WHERE TANGGAL = '" & CDate(DTTANGGAL2.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL ASC"
            Dim DTTANGGAL3 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL3)
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
            '    updatesaldo = 0
            '    sqlstrupdatesaldo = "UPDATE KAS SET SALDO = '" & updatesaldo & "'"
            '    masuktabel(sqlstrupdatesaldo, DTSALDONEW)
        End If

    End Sub
    Sub UPDATESALDOLAIN(ByVal tglupdate As String, ByVal buku As String)
        Dim saldoawal As Integer = 0
        ' Dim urutawal As Integer = DTSALDO.Rows(0)("URUT")
        'Dim tglupdate As String = CDate(DTSALDO.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd")
        'MsgBox(tglupdate)

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

            'MsgBox(DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("TANGGAL") & "  " & DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("SALDO"))

            For A = 0 To DTTANGGAL.Rows.Count - 1
                updatesaldo = updatesaldo + CInt(DTTANGGAL.Rows(A)("MASUK")) - CInt(DTTANGGAL.Rows(A)("KELUAR"))
                'MsgBox(updatesaldo & "MASUK=" & DTTANGGAL.Rows(A)("MASUK") & " KELUAR = " & DTTANGGAL.Rows(A)("KELUAR"))
                sqlstrupdatesaldo = "UPDATE " & buku & " SET SALDO = '" & updatesaldo & "' WHERE URUT = '" & DTTANGGAL.Rows(A)("URUT") & "'"
                masuktabel(sqlstrupdatesaldo, DTSALDONEW)
                'urutawal = urutawal + 1
            Next
            'Else
            '    updatesaldo = 0
            '    sqlstrupdatesaldo = "UPDATE KAS SET SALDO = '" & updatesaldo & "'"
            '    masuktabel(sqlstrupdatesaldo, DTSALDONEW)
        End If

    End Sub
    Private Sub TextBoxPrive_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPrive.TextChanged
        If TextBoxPrive.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxPrive.Text)

            Catch
                MsgBox("Masukkan angka! ")
                TextBoxPrive.Text = TextBoxPrive.Text.Remove(TextBoxPrive.Text.Length - 1)
                TextBoxPrive.SelectionStart = TextBoxPrive.Text.Length
                TextBoxPrive.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxPrive.Text = "0"
        End If
    End Sub

    Private Sub TextBoxCafe_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCafe.TextChanged
        If TextBoxCafe.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxCafe.Text)

            Catch
                MsgBox("Masukkan angka! ")
                TextBoxCafe.Text = TextBoxCafe.Text.Remove(TextBoxCafe.Text.Length - 1)
                TextBoxCafe.SelectionStart = TextBoxCafe.Text.Length
                TextBoxCafe.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxCafe.Text = "0"
        End If
    End Sub

    Private Sub TextBoxBelanja_TextChanged(sender As Object, e As EventArgs) Handles TextBoxBelanja.TextChanged
        If TextBoxBelanja.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxBelanja.Text)

            Catch
                MsgBox("Masukkan angka! ")
                TextBoxBelanja.Text = TextBoxBelanja.Text.Remove(TextBoxBelanja.Text.Length - 1)
                TextBoxBelanja.SelectionStart = TextBoxBelanja.Text.Length
                TextBoxBelanja.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxBelanja.Text = "0"
        End If
    End Sub

    Private Sub DateTimePickerPrive_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerPrive.ValueChanged
        If DateTimePickerPrive.Value.Date <> Today.Date Then
            DateTimePickerPrive.Value = New DateTime(DateTimePickerPrive.Value.Year, DateTimePickerPrive.Value.Month, DateTimePickerPrive.Value.Day, 23, 59, 59)
        Else
            DateTimePickerPrive.Value = DateAndTime.Now
        End If
        'MsgBox(DateTimePickerPrive.Value)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Pendinglist.Visible = True
        Me.Close()
    End Sub

    Private Sub Prive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstr As String = "SELECT * FROM KAS ORDER BY TANGGAL DESC LIMIT 1"
        Dim DT As New DataTable
        masuktabel(sqlstr, DT)
        TextBoxSaldoResepsionis.Text = DT.Rows(0)("SALDO")
        DT = New DataTable
        sqlstr = "SELECT * FROM CAFE ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(sqlstr, DT)
        TextBoxSaldoCafe.Text = DT.Rows(0)("SALDO")
        DT = New DataTable
        sqlstr = "SELECT * FROM KASBELANJA ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(sqlstr, DT)
        TextBoxSaldoBelanja.Text = DT.Rows(0)("SALDO")
    End Sub
End Class