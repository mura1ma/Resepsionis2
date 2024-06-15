Public Class Historycafe
    Private Sub Historycafe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DT As New DataTable
        Dim sqlstr As String = "SELECT * FROM ITEMCAFE ORDER BY ITEM ASC"
        masuktabel(sqlstr, DT)
        For A = 0 To DT.Rows.Count - 1
            ComboBox1.Items.Add(DT.Rows(A)("ITEM"))
        Next
        ''tambahkan item gudang untuk item2 yg ada gudang nya 
        For b = 0 To DT.Rows.Count - 1
            If IsDBNull(DT.Rows(b)("GUDANG")) = False Then
                If DT.Rows(b)("GUDANG") = "AKTIF" Then
                    ComboBox1.Items.Add(DT.Rows(b)("ITEM").trim() & " - GUDANG")
                End If
            End If
        Next
        ComboBox1.Sorted = True
        ComboBox1.Text = DT.Rows(0)("ITEM")
        ProgressBar1.Value = 0
    End Sub

    Private Sub ButtonProses_Click(sender As Object, e As EventArgs) Handles ButtonProses.Click
        ProgressBar1.Value = 0
        Dim DT As New DataTable
        Dim sqlstr As String = "SELECT TGL, QTTY, NAMA, ITEM, KETERANGAN, HRGSATUAN, TTLHARGA, HRGKRY, PETUGAS  FROM TRXCAFE WHERE TGL >= '" & DateTimePickerFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00") & "' AND TGL <= '" & DateTimePickerUntil.Value.Date.ToString("yyyy-MM-dd 23:59:59") & "' AND ITEM = '" & ComboBox1.Text & "' ORDER BY TGL ASC"
        masuktabel(sqlstr, DT)
        DT.Columns.Add("SALDO").SetOrdinal(2)
        DataGridView1.DataSource = DT
        ProgressBar1.Value = 30

        ''HITUNG SALDO AWAL
        Dim DTSALDOAWAL As New DataTable
        sqlstr = "SELECT * FROM TRXCAFE WHERE TGL < '" & DateTimePickerFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00") & "' AND ITEM = '" & ComboBox1.Text & "' ORDER BY TGL ASC"
        masuktabel(sqlstr, DTSALDOAWAL)
        ProgressBar1.Value = 60

        Dim SALDOAWAL As Integer = 0
        For A = 0 To DTSALDOAWAL.Rows.Count - 1
            SALDOAWAL = SALDOAWAL - DTSALDOAWAL.Rows(A)("QTTY")
        Next
        ProgressBar1.Value = 80

        '''''ISI DATA SALDO AWAL
        For a = 0 To DT.Rows.Count - 1
            DT.Rows(A)("SALDO") = SALDOAWAL - DT.Rows(A)("QTTY")
            SALDOAWAL = SALDOAWAL - DT.Rows(A)("QTTY")
        Next
        DataGridView1.Columns(1).HeaderText = "KELUAR"
        ProgressBar1.Value = 100

    End Sub

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Pendinglist.Visible = True
        Pendinglist.BringToFront()
        Me.Close()
    End Sub

    Private Sub Buttonexport_Click(sender As Object, e As EventArgs) Handles Buttonexport.Click
        ExportDgvToExcel(DataGridView1)
    End Sub
End Class