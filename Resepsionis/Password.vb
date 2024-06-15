Imports System.IO
Imports DocumentFormat.OpenXml.Drawing.Diagrams

Public Class Password
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Kedatangan.passwordsuper = TextBox1.Text

        '''''''''''''''''''''''''''''''''''''''''''''''''''
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
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        If TextBox1.Text = passbetul Then
            If Kedatangan.ButtonEdit.Visible = False Then
                Kedatangan.allenabled()
                Kedatangan.Simpanbtn.Text = "Check In"
                Kedatangan.GroupBoxCheckout.Visible = False
                Kedatangan.editan = True
            Else
                Kedatangan.allenabled()
                Kedatangan.ButtonEdit.Text = "Simpan"
            End If
        Else
            MsgBox("Password Salah")
            Me.BringToFront()
            'ButtonCheckout.Visible = False
            'DateTimePickerOut.Visible = False
        End If
        Me.Close()
    End Sub
End Class