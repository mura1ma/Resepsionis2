Public Class Rekap
    Private Sub Rekap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePickerAWAL.Format = DateTimePickerFormat.Custom
        DateTimePickerAWAL.CustomFormat = "MMMM yyyy"

        DateTimePickerAKHIR.Format = DateTimePickerFormat.Custom
        DateTimePickerAKHIR.CustomFormat = "MMMM yyyy"
    End Sub

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        Pendinglist.Visible = True
        Me.Visible = False
    End Sub
End Class