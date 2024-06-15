Imports Irony.Parsing
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Jumlahkmr
    Private Sub ButtonProcess_Click(sender As Object, e As EventArgs) Handles ButtonProcess.Click
        Dim dt As New DataTable
        Dim sqlstr As String = "SELECT * FROM RESEPSIONIS WHERE TGLIN >= '" + DateTimePickerDari.Value.Date.ToString("yyyy-MM-dd") + "' AND TGLIN <= '" + DateTimePickerSampai.Value.Date.ToString("yyyy-MM-dd 23:59:59") + "' ORDER BY TGLIN ASC"
        masuktabel(sqlstr, dt)
        Dim TOTALKAMAR As Integer = 0
        'Dim TRMTUNAI As Integer = 0
        For a = 0 To dt.Rows.Count - 1
            TOTALKAMAR = TOTALKAMAR + dt.Rows(a)("TOTALKMR")
            'TRMTUNAI = TRMTUNAI + dt.Rows(a)("TRMTUNAI")
        Next
        TextBoxTtlkamar.Text = TOTALKAMAR

        DataGridView1.DataSource = dt
        DataGridView1.Columns("URUT").Visible = False
        DataGridView1.Columns("TIPEBYR").Visible = False
        For A = 10 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(A).Visible = False
        Next
        DataGridView1.Columns("NOKMR").Visible = True
        DataGridView1.Columns("TOTALBYR").Visible = True
    End Sub

    Private Sub ButtonExport_Click(sender As Object, e As EventArgs) Handles ButtonExport.Click
        Dim dtexcel As New DataTable
        Dim sqlstr As String = "SELECT BID,NAMA, TGLIN, OTA, TIPEBYR, JMLKMR, JMLMLM, TOTALKMR, NOKMR , TOTALBYR, CF, TRMOYO, TRMTUNAI, 
                                TAMBAH, TRMTRF, SELISIH, PETUGASIN, KETERANGAN, SALDO, NOHP  
                                FROM RESEPSIONIS WHERE TGLIN >= '" + DateTimePickerDari.Value.Date.ToString("yyyy-MM-dd") + "' AND TGLIN <= '" + DateTimePickerSampai.Value.Date.ToString("yyyy-MM-dd 23:59:59") + "' ORDER BY TGLIN ASC"
        masuktabel(sqlstr, dtexcel)

        dtexcel.Columns.Add("TGL", GetType(String))
        For A = 0 To dtexcel.Rows.Count - 1
            dtexcel.Rows(A)("TGL") = CDate(dtexcel.Rows(A)("TGLIN")).ToString("dd/MM/yyyy")
        Next
        dtexcel.Columns("TGL").SetOrdinal(3)
        dtexcel.Columns.Remove("TGLIN")
        'dtexcel.Columns("TGLIN").DataType = GetType(Date.ToString("yyyy-MM-dd"))
        DataGridView2.DataSource = dtexcel

        ExportDgvToExcel(DataGridView2)
    End Sub
End Class