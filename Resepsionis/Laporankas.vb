Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Spreadsheet
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Laporankas
    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Me.Visible = False
        Pendinglist.Visible = True
        Me.Close()
    End Sub
    Private Sub ButtonProses_Click(sender As Object, e As EventArgs) Handles ButtonProses.Click
        Dim dt As New DataTable
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        Dim BUKU As String = ""
        If ComboBox1.Text = "Resepsionis" Then
            BUKU = "KAS"
        ElseIf ComboBox1.Text = "Cafe" Then
            BUKU = "CAFE"
        ElseIf ComboBox1.Text = "Kas Belanja" Then
            BUKU = "KASBELANJA"
        Else
            MsgBox("Masukkan buku")
        End If

        If BUKU <> "" Then
            dt = New DataTable
            Dim sqlstr As String
            Dim DTresepsionis As New DataTable
            Dim sqlstrresepsionis As String
            sqlstr = "SELECT * FROM " & BUKU & " WHERE TANGGAL >= '" & DateTimePickerAWAL.Value.Date.ToString("yyyy-MM-dd") & "' AND TANGGAL <= '" & DateTimePickerAKHIR.Value.Date.ToString("yyyy-MM-dd 23:59:59") & "' ORDER BY TANGGAL ASC"
            masuktabel(sqlstr, dt)
            If BUKU = "KAS" Then
                sqlstrresepsionis = "SELECT * FROM KAS INNER JOIN RESEPSIONIS ON KAS.NoResepsionis= RESEPSIONIS.URUT WHERE TANGGAL >= '" & DateTimePickerAWAL.Value.Date.ToString("yyyy-MM-dd") & "' AND TANGGAL <= '" & DateTimePickerAKHIR.Value.Date.ToString("yyyy-MM-dd 23:59:59") & "' ORDER BY TANGGAL ASC"
                masuktabel(sqlstrresepsionis, DTresepsionis)
                dt.Columns.Add("NAMA", GetType(String))
                dt.Columns.Add("PETUGASIN", GetType(String))
                dt.Columns.Add("PETUGASOUT", GetType(String))
                For a = 0 To dt.Rows.Count - 1
                    For b = 0 To DTresepsionis.Rows.Count - 1
                        If dt.Rows(a)("NoResepsionis") = DTresepsionis.Rows(b)("NoResepsionis") Then
                            dt.Rows(a)("NAMA") = DTresepsionis.Rows(b)("NAMA")
                            dt.Rows(a)("PETUGASIN") = DTresepsionis.Rows(b)("PETUGASIN")
                            dt.Rows(a)("PETUGASOUT") = DTresepsionis.Rows(b)("PETUGASOUT")
                        End If
                    Next
                Next
                dt.Columns.Remove("NoResepsionis")
                dt.Columns("NAMA").SetOrdinal(2)
            End If

            DataGridView1.DataSource = dt
            DataGridView1.Columns("Tanggal").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
            DataGridView1.Columns("URUT").Visible = False
            DataGridView1.Columns("MASUK").DefaultCellStyle.Format = "N0"
            DataGridView1.Columns("MASUK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("KELUAR").DefaultCellStyle.Format = "N0"
            DataGridView1.Columns("KELUAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns("SALDO").DefaultCellStyle.Format = "N0"
            DataGridView1.Columns("SALDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End If
    End Sub


    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If (ComboBox1.Text = "Cafe") Then
            Dim sqlstr As String = "SELECT ITEM, QTTY, HRGSATUAN, TTLHARGA, PETUGAS FROM TRXCAFE WHERE URUT = '" & DataGridView1.Rows(e.RowIndex).Cells("URUT").Value & "'"
            Dim DT As New DataTable
            masuktabel(sqlstr, DT)
            DataGridView2.Visible = True
            DataGridView2.DataSource = DT
        End If
        'MsgBox(DataGridView1.Rows(e.RowIndex).Cells("URUT").Value)
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text = "Cafe" Then
            'MsgBox(DataGridView1.Width)
            DataGridView1.Width = 450
            DataGridView2.SendToBack()
        Else
            DataGridView1.Width = 736
            DataGridView2.SendToBack()
        End If
    End Sub

    Private Sub Laporankas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView2.SendToBack()
    End Sub

    Private Sub Buttonexport_Click(sender As Object, e As EventArgs) Handles Buttonexport.Click
        Dim dtexport As New DataTable

        For Each column As DataGridViewColumn In DataGridView1.Columns
            dtexport.Columns.Add(column.HeaderText, column.ValueType)
        Next
        'Adding the Rows.
        For Each row As DataGridViewRow In DataGridView1.Rows
            dtexport.Rows.Add()
            For Each cell As DataGridViewCell In row.Cells
                dtexport.Rows(dtexport.Rows.Count - 1)(cell.ColumnIndex) = cell.Value.ToString()
            Next
        Next
        Dim workbook1 As XLWorkbook = New XLWorkbook()

        workbook1.Worksheets.Add("CAFE")
        workbook1.Worksheets(0).Cell(1, 1).Value = "Laporan Buku  " & ComboBox1.Text
        workbook1.Worksheets(0).Cell(2, 1).Value = "Tanggal  " & DateTimePickerAWAL.Value.ToString("dd-MMM-yyyy HH:mm:ss") & " - " & DateTimePickerAKHIR.Value.ToString("dd-MMM-yyyy HH:mm:ss")

        For c = 0 To dtexport.Columns.Count - 1
            workbook1.Worksheets(0).Cell(4, c + 1).Value = CStr(dtexport.Columns(c).ColumnName)
            For a = 0 To dtexport.Rows.Count - 1
                workbook1.Worksheets(0).Cell(a + 5, c + 1).Value = CStr(dtexport.Rows(a)(c))
            Next
        Next
        workbook1.Worksheets(0).Column(2).Width = 20
        workbook1.Worksheets(0).Column(3).Width = 30

        workbook1.Worksheets(0).Row(1).Style.Font.FontSize = 14

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            MsgBox("Tersimpan di : " & SaveFileDialog1.FileName)
            workbook1.SaveAs(SaveFileDialog1.FileName & ".xlsx")
            '''open excel
            If MessageBox.Show("Buka file?", "Buka excel", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Process.Start(SaveFileDialog1.FileName & ".xlsx")
            End If
        End If
    End Sub
End Class