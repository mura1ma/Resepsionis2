Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class Transaksi

    Public bukusumber As String
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
        Dim f6c As New Font("Courier", 6, FontStyle.Regular)

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

        Dim logoImage As Image = My.Resources.ResourceManager.GetObject("FORREST_INN")
        Dim lunas As Image = My.Resources.ResourceManager.GetObject("lunas")
        e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - 150) / 2), 5, 150, 35)
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 40)

        Dim height As Integer 'DGV Position
        height = 10
        Dim centerprt As Integer = centermargin - 25 - (ComboBoxSumber.Text.Length * 4)
        'MsgBox(ComboBoxSumber.Text.Length)
        e.Graphics.DrawString("-- " & ComboBoxSumber.Text & " --", f14, Brushes.Black, centerprt, 40 + height)
        height += 20
        e.Graphics.DrawString("-- Tanggal: " & DateTimePicker1.Value.ToString("dd MMMM yyyy") & " --", f10, Brushes.Black, 37, 40 + height)
        height += 15

        e.Graphics.DrawString("Keterangan ", f10, Brushes.Black, 5, 45 + height)
        e.Graphics.DrawString(": " & RichTextBox1.Text, f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 40, 45 + height)
        height += 15
        e.Graphics.DrawString("Jumlah ", f10, Brushes.Black, 5, 45 + height)
        If ComboBoxKeluarmasuk.Text = "Masuk" Then
            e.Graphics.DrawString(": Rp. " & CInt(TextBoxJumlah.Text).ToString("#,###").Replace(",", "."), f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 40, 45 + height)
        Else
            e.Graphics.DrawString(": -Rp. " & CInt(TextBoxJumlah.Text).ToString("#,###").Replace(",", "."), f10, Brushes.Black, CInt((e.PageBounds.Width) / 2) - 40, 45 + height)
        End If
        height += 17
        e.Graphics.DrawString(line2, f8, Brushes.Black, 0, 45 + height)
        height += 20
        e.Graphics.DrawString("Petugas", f8, Brushes.Black, 10, 45 + height)
        e.Graphics.DrawString("Pelanggan", f8, Brushes.Black, CInt((e.PageBounds.Width) / 2) + 50, 45 + height)
        e.Graphics.DrawImage(lunas, CInt((e.PageBounds.Width - 60) / 2), 45 + height, 60, 30)
        height += 75
        e.Graphics.DrawString("~Thank you for coming~", f6c, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)
        height += 35
        e.Graphics.DrawString(". ", f8, Brushes.Black, CInt((e.PageBounds.Width - 120) / 2), 45 + height)

    End Sub

    Private Sub ComboBoxSumber_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxSumber.TextChanged
        If ComboBoxSumber.Text = "Resepsionis" Then
            Panel1.BackColor = Color.CornflowerBlue
        ElseIf ComboBoxSumber.Text = "Cafe" Then
            Panel1.BackColor = Color.SandyBrown
        ElseIf ComboBoxsumber.Text = "Kas Belanja" Then
            Panel1.BackColor = Color.YellowGreen
        End If
    End Sub

    Private Sub ComboBoxKeluarmasuk_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxKeluarmasuk.TextChanged
        If ComboBoxKeluarmasuk.Text = "Keluar" Then
            Labeljumlah.Text = "Jumlah Keluar"
            Panel2.BackColor = Color.OrangeRed
        ElseIf ComboBoxKeluarmasuk.Text = "Masuk" Then
            Panel2.BackColor = Color.ForestGreen
            Labeljumlah.Text = "Jumlah Masuk"
        End If
    End Sub

    Sub clear()
        TextBoxJumlah.Text = "0"
        RichTextBox1.Text = ""
    End Sub


    Private Sub TextBoxJumlah_TextChanged(sender As Object, e As EventArgs) Handles TextBoxJumlah.TextChanged
        If TextBoxJumlah.Text <> "" Then
            Try
                Dim angka As Integer = CInt(TextBoxJumlah.Text)

            Catch
                MsgBox("Masukkan angka! ")
                TextBoxJumlah.Text = TextBoxJumlah.Text.Remove(TextBoxJumlah.Text.Length - 1)
                TextBoxJumlah.SelectionStart = TextBoxJumlah.Text.Length
                TextBoxJumlah.SelectionLength = 0 ' This ensures the cursor is not selecting any text
            End Try
        Else
            TextBoxJumlah.Text = "0"
        End If
    End Sub

    Private Sub ButtonSimpan_Click(sender As Object, e As EventArgs) Handles ButtonSimpan.Click
        SIMPANDATA()
        ''Cetak
        PPD.Document = PD
        PPD.ShowDialog()

        MsgBox("Data berhasil disimpan!")
        clear()
        Me.Close()
        Pendinglist.BringToFront()
    End Sub

    Sub SIMPANDATA()
        Dim DTAWAL As New DataTable
        Dim keluarmasuk As String = ""
        Dim sqlstr As String = ""
        Dim SQLsaldo As String
        Dim SALDO As Integer = 0
        Dim dt As New DataTable
        Dim SQLupdatesaldo As String = ""

        If ComboBoxSumber.Text = "Resepsionis" Then
            SQLsaldo = "SELECT * FROM KAS WHERE TANGGAL <= '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
            HITUNGSALDO(SQLsaldo, DTAWAL, SALDO, keluarmasuk)
            sqlstr = "INSERT INTO KAS (NORESEPSIONIS, TANGGAL, KETERANGAN, MASUK, KELUAR, SALDO)
                                VALUES ( '-2', '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "', 
                                '-TRX- " & RichTextBox1.Text.ToString & "'," & keluarmasuk
            SQLupdatesaldo = "SELECT * FROM KAS ORDER BY URUT DESC LIMIT 10"
            bukusumber = "KAS"
        ElseIf ComboBoxSumber.Text = "Cafe" Then
            SQLsaldo = "SELECT * FROM CAFE WHERE TANGGAL <= '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
            HITUNGSALDO(SQLsaldo, DTAWAL, SALDO, keluarmasuk)
            sqlstr = "INSERT INTO CAFE (TANGGAL, KETERANGAN, MASUK, KELUAR, SALDO)
                                VALUES ('" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "', 
                                '" & RichTextBox1.Text.ToString & "'," & keluarmasuk
            SQLupdatesaldo = "SELECT * FROM CAFE ORDER BY URUT DESC LIMIT 10"
            bukusumber = "CAFE"
        ElseIf ComboBoxSumber.Text = "Kas Belanja" Then
            SQLsaldo = "SELECT * FROM KASBELANJA WHERE TANGGAL <= '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
            HITUNGSALDO(SQLsaldo, DTAWAL, SALDO, keluarmasuk)
            sqlstr = "INSERT INTO KASBELANJA (TANGGAL, KETERANGAN, MASUK, KELUAR, SALDO)
                                VALUES ('" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "', 
                                '" & RichTextBox1.Text.ToString & "'," & keluarmasuk
            SQLupdatesaldo = "SELECT * FROM KASBELANJA ORDER BY URUT DESC LIMIT 10"
            bukusumber = "KASBELANJA"
        End If
        masuktabel(sqlstr, dt)

        Dim DTSALDO As New DataTable
        masuktabel(SQLupdatesaldo, DTSALDO)
        UPDATESALDOLAIN(CDate(DTSALDO.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd"), bukusumber)
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

            'MsgBox(DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("TANGGAL") & "  " & DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("KETERANGAN"))

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
    Sub HITUNGSALDO(ByVal SQLSALDO As String, ByVal DTAWAL As DataTable, ByRef SALDO As Integer, ByRef keluarmasuk As String)
        masuktabel(SQLSALDO, DTAWAL)

        If ComboBoxKeluarmasuk.Text = "Keluar" Then
            If DTAWAL.Rows.Count - 1 >= 0 Then
                SALDO = DTAWAL.Rows(0)("SALDO")
            End If
            SALDO = SALDO - CInt(TextBoxJumlah.Text)
            keluarmasuk = " '0', '" & TextBoxJumlah.Text & "', '" & SALDO & "') "
        ElseIf ComboBoxKeluarmasuk.Text = "Masuk" Then
            If DTAWAL.Rows.Count - 1 >= 0 Then
                SALDO = DTAWAL.Rows(0)("SALDO")
            End If
            SALDO = SALDO + CInt(TextBoxJumlah.Text)
            keluarmasuk = " '" & TextBoxJumlah.Text & "', '0', '" & SALDO & "') "
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value.Date <> Today.Date Then
            DateTimePicker1.Value = New DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTimePicker1.Value.Day, 23, 59, 59)
        Else
            DateTimePicker1.Value = DateAndTime.Now
        End If
    End Sub
End Class