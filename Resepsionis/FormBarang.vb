Imports MySql.Data.MySqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Runtime.InteropServices.ComTypes

Public Class FormBarang
    Private Sub ButtonTambah_Click(sender As Object, e As EventArgs) Handles ButtonTambah.Click
        Panel1.Visible = True
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        clear()
        Panel1.Visible = False
    End Sub
    Sub clear()
        TextBoxItem.Text = ""
        TextBoxHarga1.Text = ""
        TextBoxHargakry.Text = ""
        TextBoxketerangan.Text = ""
        TextBoxurutan.Text = ""
    End Sub

    Private Sub Buttonsimpan_Click(sender As Object, e As EventArgs) Handles Buttonsimpan.Click
        Dim dt As New DataTable
        Dim sqlstr As String = "INSERT INTO ITEMCAFE (ITEM, HARGA1, HARGAKRY, KETERANGAN, URUTANLIST)
                                VALUES ('" & TextBoxItem.Text & "',
                                '" & TextBoxHarga1.Text & "',
                                '" & TextBoxHargakry.Text & "',
                                '" & TextBoxketerangan.Text & "',
                                '" & TextBoxurutan.Text & "')"
        masuktabel(sqlstr, dt)

        Dim dt2 As New DataTable
        Dim sqlstr2 As String = "SELECT * FROM ITEMCAFE ORDER BY URUTANLIST ASC"
        masuktabel(sqlstr2, dt2)
        DataGridViewItem.DataSource = New DataTable
        DataGridViewItem.DataSource = dt2
        MsgBox("DATA TERSIMPAN")
        clear()
        Panel1.Visible = False
    End Sub

    Private Sub FormBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim sqlstr As String = "SELECT * FROM ITEMCAFE ORDER BY URUTANLIST ASC"
        masuktabel(sqlstr, dt)
        'dt.Columns("URUTANLIST").SetOrdinal(0)
        DataGridViewItem.DataSource = dt
    End Sub



    Private Sub Buttonkembali_Click(sender As Object, e As EventArgs) Handles Buttonkembali.Click
        Pendinglist.Visible = True
        Me.Close()
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        If ButtonEdit.Text = "Edit" Then
            DataGridViewItem.Enabled = True
            DataGridViewItem.ReadOnly = False
            Labeleditenabled.Visible = True
            DataGridViewItem.DefaultCellStyle.ForeColor = Color.Red
            ButtonEdit.Text = "Selesai"
        Else
            ButtonEdit.Text = "Edit"
            saveedit()
            'DataGridViewItem.Enabled = False
            DataGridViewItem.ReadOnly = True
            Labeleditenabled.Visible = False
            DataGridViewItem.DefaultCellStyle.ForeColor = Color.Black
        End If

    End Sub
    Sub saveedit()
        Dim DTitem As New DataTable
        INSERTCOLOM(DTitem)
        For A = 0 To DataGridViewItem.Rows.Count - 1
            DTitem.Rows.Add()
            For B = 0 To DataGridViewItem.Columns.Count - 1
                DTitem.Rows(A)(B) = DataGridViewItem.Rows(A).Cells(B).Value
            Next
        Next

        Dim dt As New DataTable
        Dim sqlstr As String = "DELETE FROM ITEMCAFE"
        masuktabel(sqlstr, dt)

        sqlstr = "SELECT * FROM ITEMCAFE"
        changedatafromtabel(sqlstr, DTitem)

        Dim dt2 As New DataTable
        Dim sqlstr2 As String = "SELECT * FROM ITEMCAFE ORDER BY URUTANLIST ASC"
        masuktabel(sqlstr2, dt2)
        DataGridViewItem.DataSource = New DataTable
        DataGridViewItem.DataSource = dt2
        MsgBox("BERHASIL DIEDIT!")
    End Sub

    Sub INSERTCOLOM(ByRef TBL As DataTable)
        TBL.Columns.Add("ITEM")
        TBL.Columns.Add("HARGA1")
        TBL.Columns.Add("HARGAKRY")
        TBL.Columns.Add("URUTANLIST")
        TBL.Columns.Add("STATUS")
        TBL.Columns.Add("GUDANG")
        TBL.Columns.Add("KETERANGAN")
    End Sub

End Class