Imports System.IO

Public Class Passwordcafe
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim passbetul As String
        Dim filePath As String = "src\misc.sys"
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    passbetul = reader.ReadLine()
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If

        ''jika password sesuai, maka set harga 0 semua

        If TextBox1.Text = passbetul Then
            Cafe.TextBoxketerangan.Text = "BONUS - " & CStr(Cafe.TextBoxketerangan.Text)
            Cafe.TextBoxketerangan.Enabled = False

            ''ubah harga menjadi 0
            For a = 0 To Cafe.DataGridView1.RowCount - 1
                Cafe.DataGridView1.Rows(a).Cells("hrg_satuan").Value = "0"
                Cafe.DataGridView1.Rows(a).Cells("ttlharga").Value = "0"
            Next
            Cafe.TextBoxsubtotal.Text = "0"
            Cafe.totaltrx = 0
            Cafe.DataGridView1.Enabled = False
            Cafe.BackColor = Color.LightGreen
        Else
            MsgBox("Password Salah, konfirmasi tidak valid")
        End If
        Me.Close()
    End Sub

    Private Sub Passwordcafe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()
    End Sub
End Class