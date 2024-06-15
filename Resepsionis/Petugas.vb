Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Petugas
    Public nourut As Integer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Pendinglist.Visible = True
    End Sub

    Private Sub Petugas_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            Dim dt As New DataTable
            Dim sqlstr As String = "SELECT * FROM PETUGAS"
            masuktabel(sqlstr, dt)
            DataGridView1.DataSource = dt

            'If TextBoxNama.Text <> "" Then
            '    ButtonSimpan.Text = "Edit"
            'Else
            '    ButtonSimpan.Text = "Simpan"
            'End If
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        nourut = DataGridView1.Rows(e.RowIndex).Cells("NO").Value
        TextBoxNama.Text = DataGridView1.Rows(e.RowIndex).Cells("NAMA").Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells("MULAI").Value
        ComboBoxStatus.Text = DataGridView1.Rows(e.RowIndex).Cells("STATUS").Value
        ButtonSimpan.Text = "Edit"
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        TextBoxNama.Text = ""
        DateTimePicker1.Text = ""
        ComboBoxStatus.Text = ""
        nourut = -1
        ButtonSimpan.Text = "Simpan"
    End Sub

    Private Sub ButtonSimpan_Click(sender As Object, e As EventArgs) Handles ButtonSimpan.Click
        Dim dt As New DataTable
        Dim sqlstr As String = ""
        If ButtonSimpan.Text = "Simpan" Then
            sqlstr = "INSERT INTO PETUGAS (NAMA , MULAI, STATUS)
                        VALUES ( '" & TextBoxNama.Text.Trim() & "' 
                        , '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' 
                        , '" & ComboBoxStatus.Text & "')"
            'MsgBox(sqlstr)
            masuktabel(sqlstr, dt)
            MsgBox("DATA BERHASIL DITAMBAHKAN")
        ElseIf ButtonSimpan.Text = "Edit" Then
            sqlstr = "UPDATE PETUGAS 
                        SET NAMA = '" & TextBoxNama.Text.Trim() & "',
                        MULAI = ' " & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "',
                        STATUS = '" & ComboBoxStatus.Text & "' WHERE NO = '" & nourut & "'"
            masuktabel(sqlstr, dt)
            MsgBox("DATA BERHASIL DIUBAH")
        End If
        dt = New DataTable
        DataGridView1.DataSource = New DataTable
        sqlstr = "SELECT * FROM PETUGAS"
        masuktabel(sqlstr, dt)
        DataGridView1.DataSource = dt

        TextBoxNama.Text = ""
        DateTimePicker1.Text = ""
        ComboBoxStatus.Text = ""
        nourut = -1
        ButtonSimpan.Text = "Simpan"
    End Sub
End Class