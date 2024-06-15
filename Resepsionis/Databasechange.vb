Imports System.IO

Public Class Databasechange
    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Dim passbetul As String = ""
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
        If passbetul = TextBoxpassword.Text Then
            Panel1.Visible = True
            Using reader As New StreamReader("src\conn.dt")
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    TextBoxserver.Text = reader.ReadLine()
                    TextBoxport.Text = reader.ReadLine()
                    TextBoxuser.Text = reader.ReadLine()
                    TextBoxpass.Text = reader.ReadLine()
                    TextBoxdb.Text = reader.ReadLine()
                End While
            End Using
        Else
            MsgBox("password tidak cocok!")
        End If

    End Sub

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Pendinglist.Visible = True
        Me.Close()
    End Sub

    Private Sub ButtonMasuk_Click(sender As Object, e As EventArgs) Handles ButtonMasuk.Click
        If MessageBox.Show("yakin untuk ganti database?", "Ganti database", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Using writer As New StreamWriter("src\conn.dt")
                ' Read and process each line in the file
                writer.WriteLine(TextBoxserver.Text)
                writer.WriteLine(TextBoxport.Text)
                writer.WriteLine(TextBoxuser.Text)
                writer.WriteLine(TextBoxpass.Text)
                writer.WriteLine(TextBoxdb.Text)
            End Using
        End If
    End Sub
End Class