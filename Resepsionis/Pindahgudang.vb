Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports DocumentFormat.OpenXml.Bibliography

Public Class Pindahgudang
    Private Sub Pindahbarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim sqlstr As String = "SELECT * FROM ITEMCAFE WHERE STATUS = 'AKTIF' AND GUDANG = 'AKTIF' ORDER BY ITEM ASC"
        masuktabel(sqlstr, dt)
        For A = 0 To dt.Rows.Count - 1
            ComboBox1.Items.Add(dt.Rows(A)("ITEM"))
        Next
        ''TAMBAHKAN ITEM DGN GUDANG YG AKTIF
        For B = 0 To dt.Rows.Count - 1
            ComboBox1.Items.Add(dt.Rows(B)("ITEM").TRIM() & " - GUDANG")
        Next

        Dim sptgs As String = "Select * From PETUGAS WHERE STATUS = 'AKTIF'"
        Dim DTpts As New DataTable
        masuktabel(sptgs, DTpts)
        For a = 0 To DTpts.Rows.Count - 1
            ComboBoxpetugas.Items.Add(DTpts.Rows(a)("NAMA"))
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Pendinglist.Visible = True
        Me.Close()
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text.Contains("GUDANG") = True Then
            TextBoxtujuan.Text = ComboBox1.Text.Substring(0, ComboBox1.Text.IndexOf("- GUDANG"))
        Else
            Dim dt As New DataTable
            Dim sqlstr As String = "SELECT * FROM ITEMCAFE WHERE ITEM = '" & ComboBox1.Text & "'"
            masuktabel(sqlstr, dt)

            If IsDBNull(dt.Rows(0)("GUDANG")) = False Then
                If dt.Rows(0)("GUDANG") = "AKTIF" Then
                    TextBoxtujuan.Text = dt.Rows(0)("ITEM").TRIM() & " - GUDANG"
                Else
                    MsgBox("GUDANG TIDAK AKTIF")
                End If
            Else
                MsgBox("GUDANG TIDAK AKTIF")
            End If
        End If
    End Sub

    Private Sub Buttonsimpan_Click(sender As Object, e As EventArgs) Handles Buttonsimpan.Click
        Dim lengkap As Boolean = True
        checklengkap(lengkap)

        If lengkap = True Then
            If MessageBox.Show("Yakin untuk menyimpan", "Simpan", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Dim dt As New DataTable
                Dim sqlstr As String = "SELECT * FROM TRXCAFE LIMIT 1"
                INSERTCOLOM(dt)
                ''keluarkan barang dari gudang asal
                dt.Rows.Add()
                dt.Rows(0)("TGL") = DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")
                dt.Rows(0)("NAMA") = "PINDAH GUDANG"
                dt.Rows(0)("KETERANGAN") = "PINDAH " & ComboBox1.Text & " KE " & TextBoxtujuan.Text
                dt.Rows(0)("URUT") = "-2"  '' KODE URUT PINDAH GUDANG ASAL = -2 
                dt.Rows(0)("ITEM") = ComboBox1.Text
                dt.Rows(0)("QTTY") = TextBoxJumlah.Text
                dt.Rows(0)("HRGSATUAN") = "0"
                dt.Rows(0)("TTLHARGA") = "0"
                dt.Rows(0)("PETUGAS") = ComboBoxpetugas.Text

                ''masukkan barang ke gudang tujuan
                dt.Rows.Add()
                dt.Rows(1)("TGL") = DateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")
                dt.Rows(1)("NAMA") = "PINDAH GUDANG"
                dt.Rows(1)("KETERANGAN") = "PINDAH " & ComboBox1.Text & " KE " & TextBoxtujuan.Text
                dt.Rows(1)("URUT") = "-3"  '' KODE URUT PINDAH GUDANG TUJUAN = -3
                dt.Rows(1)("ITEM") = TextBoxtujuan.Text
                dt.Rows(1)("QTTY") = -1 * TextBoxJumlah.Text
                dt.Rows(1)("HRGSATUAN") = "0"
                dt.Rows(1)("TTLHARGA") = "0"
                dt.Rows(1)("PETUGAS") = ComboBoxpetugas.Text

                changedatafromtabel(sqlstr, dt)
                MsgBox("Data berhasil disimpan!")
                Me.Close()
                Pendinglist.Visible = True
            Else
                MsgBox("Lengkapi dahulu data yang belum diisi!")
            End If

        End If
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
    Sub checklengkap(ByRef lengkap As Boolean)
        If ComboBox1.Text = "" Then
            lengkap = False
        ElseIf TextBoxtujuan.Text = "" Then
            lengkap = False
        ElseIf TextBoxJumlah.Text = "" Then
            lengkap = False
        ElseIf ComboBoxpetugas.Text = "" Then
            lengkap = False
        Else
            lengkap = True
        End If
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
        End If
    End Sub
End Class