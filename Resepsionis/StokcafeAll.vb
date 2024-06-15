Imports System.Net.Mail
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Office.CustomUI
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel
Imports Microsoft.ReportingServices.ReportProcessing.ExprHostObjectModel

'Imports DocumentFormat.OpenXml.Spreadsheet

Public Class StokcafeAll
    Private Sub StokcafeAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd-MMM-yyyy HH:mm:ss"
        Dim sptgs As String = "Select * From PETUGAS WHERE STATUS = 'AKTIF'"
        Dim DT As New DataTable
        masuktabel(sptgs, DT)
        For a = 0 To DT.Rows.Count - 1
            ComboBox1.Items.Add(DT.Rows(a)("NAMA"))
        Next
    End Sub

    Private Sub ButtonProses_Click(sender As Object, e As EventArgs) Handles ButtonProses.Click
        'MsgBox(DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"))
        Dim DT As New DataTable
        Dim sqlstr As String = "SELECT * FROM TRXCAFE WHERE TGL <= '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TGL ASC"
        masuktabel(sqlstr, DT)
        Dim dtitems As New DataTable
        Dim items As New DataTable
        sqlstr = "SELECT * FROM ITEMCAFE WHERE STATUS = 'AKTIF' AND HARGA1 >= '0' ORDER BY URUTANLIST ASC"
        masuktabel(sqlstr, items)


        dtitems.Columns.Add("ITEM")
        dtitems.Columns.Add("CAFE", GetType(Integer))
        dtitems.Columns.Add("GUDANG", GetType(Integer))

        For A = 0 To items.Rows.Count - 1
            dtitems.Rows.Add()
            dtitems.Rows(A)("ITEM") = items.Rows(A)("ITEM")
            'MsgBox(dtitems.Rows(A)("ITEM"))
        Next

        For C = 0 To dtitems.Rows.Count - 1
            dtitems.Rows(C)("CAFE") = 0
            dtitems.Rows(C)("GUDANG") = 0
        Next

        '''''HITUNG STOK CAFE
        For A = 0 To dtitems.Rows.Count - 1
            'MsgBox(dtitems.Rows(A)("ITEM"))
            For b = 0 To DT.Rows.Count - 1
                If IsDBNull(DT.Rows(b)("ITEM")) = False Then
                    'If dtitems.Rows(A)("ITEM").TRIM() = "TEH" Then
                    '    MsgBox(DT.Rows(b)("TGL") & " " & DT.Rows(b)("URUT") & " " & DT.Rows(b)("QTTY"))
                    'End If
                    If dtitems.Rows(A)("ITEM").TRIM() = DT.Rows(b)("ITEM").TRIM() Then
                        dtitems.Rows(A)("CAFE") = dtitems.Rows(A)("CAFE") - DT.Rows(b)("QTTY")

                    ElseIf dtitems.Rows(A)("ITEM").TRIM() & " - GUDANG" = DT.Rows(b)("ITEM").TRIM() Then  ''''''HITUNG STOK GUDANG
                        dtitems.Rows(A)("GUDANG") = dtitems.Rows(A)("GUDANG") - DT.Rows(b)("QTTY")

                    End If
                End If
            Next
        Next
        DataGridView1.DataSource = dtitems

        ''Hitung saldo Resepsionis, cafe, Kas belanja
        Dim dtsaldoresepsionis As New DataTable
        Dim dtsaldocafe As New DataTable
        Dim dtsaldobelanja As New DataTable

        sqlstr = "SELECT * FROM KAS WHERE TANGGAL < '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(sqlstr, dtsaldoresepsionis)
        TextBoxresepsionis.Text = CInt(dtsaldoresepsionis.Rows(0)("Saldo")).ToString("#,###").Replace(",", ".")
        sqlstr = "SELECT * FROM CAFE WHERE TANGGAL < '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(sqlstr, dtsaldocafe)
        TextBoxcafe.Text = CInt(dtsaldocafe.Rows(0)("Saldo")).ToString("#,###").Replace(",", ".")
        sqlstr = "SELECT * FROM KASBELANJA WHERE TANGGAL < '" & DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL DESC LIMIT 1"
        masuktabel(sqlstr, dtsaldobelanja)
        TextBoxbelanja.Text = CInt(dtsaldobelanja.Rows(0)("Saldo")).ToString("#,###").Replace(",", ".")

        Dim DTLISTBON As New DataTable
        sqlstr = "SELECT * FROM TRXCAFE WHERE BLMLUNAS = 'TRUE'"
        masuktabel(sqlstr, DTLISTBON)
        Dim totalbon As Integer = 0
        Dim totalharga As Integer = 0
        For A = 0 To DTLISTBON.Rows.Count - 1
            'For B = 0 To DT.Rows.Count - 1
            'If IsDBNull(dt.Rows(B)("NAMA")) = False Then
            totalharga = DTLISTBON.Rows(A)("TTLHARGA")
            If totalharga < 0 Then
                totalharga = totalharga * -1
            End If
            'If DTLISTBON.Rows(A)("NAMA").TRIM() = DT.Rows(B)("NAMA").TRIM() Then
            'DTLISTBON.Rows(A)("TOTAL BON") = DTLISTBON.Rows(A)("TOTAL BON") + totalharga
            totalbon = totalbon + totalharga
            'End If
            'Next
        Next
        TextBoxttlbon.Text = totalbon
    End Sub

    Private Sub Exportbtn_Click(sender As Object, e As EventArgs) Handles Exportbtn.Click
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

        'ExportDgvToExcel(dtexport)
        ''set datatable to workbook
        Dim workbook1 As XLWorkbook = New XLWorkbook()

        workbook1.Worksheets.Add("CAFE")
        workbook1.Worksheets(0).Cell(1, 1).Value = "Stok Cafe Tgl: " & DateTimePicker1.Value.ToString("dd-MMM-yyyy HH:mm:ss")
        workbook1.Worksheets(0).Cell(1, 3).Value = "Shift: " & ComboBox1.Text
        For c = 0 To dtexport.Columns.Count - 1
            workbook1.Worksheets(0).Cell(3, c + 1).Value = CStr(dtexport.Columns(c).ColumnName)
            For a = 0 To dtexport.Rows.Count - 1
                workbook1.Worksheets(0).Cell(a + 4, c + 1).Value = CStr(dtexport.Rows(a)(c))
            Next
        Next

        'workbook1.Worksheets(0).Cell(3, dtexport.Columns.Count).Value = "CAFE"
        'workbook1.Worksheets(0).Cell(3, dtexport.Columns.Count + 1).Value = "FISIK"
        workbook1.Worksheets(0).Cell(3, dtexport.Columns.Count + 1).Value = "SELISIH"
        'workbook1.Worksheets(0).Cell(3, dtexport.Columns.Count + 3).Value = "KETERANGAN"

        workbook1.Worksheets(0).Column(1).Width = 30
        workbook1.Worksheets(0).Column(2).Width = 15
        workbook1.Worksheets(0).Column(3).Width = 15

        workbook1.Worksheets(0).Row(1).Style.Font.FontSize = 14
        workbook1.Worksheets(0).Row(3).Style.Font.FontSize = 14
        workbook1.Worksheets(0).Row(3).Style.Font.Bold = True

        ''border

        For a = 1 To dtexport.Columns.Count + 1
            For b = 0 To dtexport.Rows.Count
                workbook1.Worksheets(0).Cell(3 + b, a).Style.Border.BottomBorder = XLBorderStyleValues.Medium
                workbook1.Worksheets(0).Cell(3 + b, a).Style.Border.LeftBorder = XLBorderStyleValues.Medium
                workbook1.Worksheets(0).Cell(3 + b, a).Style.Border.RightBorder = XLBorderStyleValues.Medium
                workbook1.Worksheets(0).Cell(3 + b, a).Style.Border.TopBorder = XLBorderStyleValues.Medium
            Next
        Next

        ''tambahan untuk saldo resepsionis, cafe, kas belanja
        Dim nextline As Integer = dtexport.Rows.Count + 5
        workbook1.Worksheets(0).Cell(nextline, 1).Value = "Saldo Tgl: " & DateTimePicker1.Value.ToString("dd-MMM-yyyy HH:mm:ss")
        workbook1.Worksheets(0).Cell(nextline, 2).Value = "Saldo program"
        workbook1.Worksheets(0).Cell(nextline, 3).Value = "Saldo fisik"
        workbook1.Worksheets(0).Row(nextline).Style.Font.Bold = True
        nextline = nextline + 1
        workbook1.Worksheets(0).Cell(nextline, 1).Value = "Resepsionis: "
        workbook1.Worksheets(0).Cell(nextline, 2).Value = TextBoxresepsionis.Text
        nextline = nextline + 1
        workbook1.Worksheets(0).Cell(nextline, 1).Value = "Cafe: "
        workbook1.Worksheets(0).Cell(nextline, 2).Value = TextBoxcafe.Text
        nextline = nextline + 1
        workbook1.Worksheets(0).Cell(nextline, 1).Value = "Kas belanja: "
        workbook1.Worksheets(0).Cell(nextline, 2).Value = TextBoxbelanja.Text
        nextline = nextline + 2
        workbook1.Worksheets(0).Cell(nextline, 1).Value = "Total bon cafe: "
        workbook1.Worksheets(0).Cell(nextline, 2).Value = TextBoxttlbon.Text

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            MsgBox("Tersimpan di : " & SaveFileDialog1.FileName)
            workbook1.SaveAs(SaveFileDialog1.FileName & ".xlsx")
            '''open excel
            If MessageBox.Show("Buka file?", "Buka excel", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Process.Start(SaveFileDialog1.FileName & ".xlsx")
            End If
        End If
        'workbook1.SaveAs(SaveFileDialog1.FileName)

    End Sub

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Pendinglist.Visible = True
        Pendinglist.BringToFront()
        Me.Close()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text <> "" Then
            Buttoncocok.Enabled = True
            'Exportbtn.Enabled = True
        Else
            Buttoncocok.Enabled = False
            ' Exportbtn.Enabled = False
        End If
    End Sub

    Private Sub Buttoncocok_Click(sender As Object, e As EventArgs) Handles Buttoncocok.Click
        If Buttoncocok.Text = "Saldo cocok" Then
            Buttoncocok.Text = "Ubah"
            Label6.Text = "Saldo Cocok"
            Exportbtn.Enabled = True
            TextBoxresepsionis.Enabled = False
            TextBoxcafe.Enabled = False
            TextBoxbelanja.Enabled = False
            ButtonProses.Enabled = False
        Else
            Buttoncocok.Text = "Saldo cocok"
            Label6.Text = ""
            Exportbtn.Enabled = False
            TextBoxresepsionis.Enabled = True
            TextBoxcafe.Enabled = True
            TextBoxbelanja.Enabled = True
            ButtonProses.Enabled = True
        End If
    End Sub
End Class