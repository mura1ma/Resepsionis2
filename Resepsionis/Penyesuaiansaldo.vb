Public Class Penyesuaiansaldo
    Private Sub Buttonkembali_Click(sender As Object, e As EventArgs) Handles Buttonkembali.Click
        Pendinglist.Visible = True
        Me.Close()
    End Sub

    Private Sub Buttonpenyesuaian_Click(sender As Object, e As EventArgs) Handles Buttonpenyesuaian.Click
        UPDATESALDOKAS(DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"))
        UPDATESALDOLAIN(DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"), "Cafe")
        UPDATESALDOLAIN(DateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"), "Kasbelanja")
        MsgBox("Update selesai")
    End Sub
    Sub UPDATESALDOLAIN(ByVal tglupdate As String, ByVal buku As String)
        Dim saldoawal As Integer = 0

        Dim updatesaldo As Integer = 0
        Dim sqlstrupdatesaldo As String
        Dim DTTANGGAL As New DataTable
        Dim SQLSTR As String = "SELECT * FROM " & buku & " WHERE TANGGAL >= '" & tglupdate & "' ORDER BY TANGGAL ASC"
        'MsgBox(SQLSTR)
        masuktabel(SQLSTR, DTTANGGAL)

        Dim DTSALDONEW As New DataTable
        If DTTANGGAL.Rows.Count - 1 > 0 Then
            ''DAPATKAN SALDO AKHIR SEBLUM DIUPDATE
            Dim SQLSTR2 As String = "SELECT * FROM " & buku & " WHERE TANGGAL < '" & tglupdate & "' ORDER BY TANGGAL DESC LIMIT 1"
            'MsgBox(SQLSTR2)
            Dim DTTANGGAL2 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL2)
            SQLSTR2 = "SELECT * FROM " & buku & " WHERE TANGGAL = '" & CDate(DTTANGGAL2.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL ASC"
            Dim DTTANGGAL3 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL3)
            updatesaldo = DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("SALDO")

            'MsgBox(DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("TANGGAL") & "  " & DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("KETERANGAN"))

            For A = 0 To DTTANGGAL.Rows.Count - 1
                updatesaldo = updatesaldo + CInt(DTTANGGAL.Rows(A)("MASUK")) - CInt(DTTANGGAL.Rows(A)("KELUAR"))
                'MsgBox(updatesaldo & "MASUK=" & DTTANGGAL.Rows(A)("MASUK") & " KELUAR = " & DTTANGGAL.Rows(A)("KELUAR"))
                sqlstrupdatesaldo = "UPDATE " & buku & " SET SALDO = '" & updatesaldo & "' WHERE URUT = '" & DTTANGGAL.Rows(A)("URUT") & "'"
                masuktabel(sqlstrupdatesaldo, DTSALDONEW)
                'urutawal = urutawal + 1
            Next
        End If
    End Sub
    Sub UPDATESALDOKAS(ByVal tglupdate As String)
        Dim saldoawal As Integer = 0
        ' Dim urutawal As Integer = DTSALDO.Rows(0)("URUT")
        'Dim tglupdate As String = CDate(DTSALDO.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd")
        'MsgBox(tglupdate)

        Dim updatesaldo As Integer = 0
        Dim sqlstrupdatesaldo As String
        Dim DTTANGGAL As New DataTable
        Dim SQLSTR As String = "SELECT * FROM KAS WHERE TANGGAL >= '" & tglupdate & "' ORDER BY TANGGAL ASC"
        masuktabel(SQLSTR, DTTANGGAL)

        Dim DTSALDONEW As New DataTable
        If DTTANGGAL.Rows.Count - 1 > 0 Then
            ''DAPATKAN SALDO AKHIR SEBLUM DIUPDATE
            'MsgBox(tglupdate)
            Dim SQLSTR2 As String = "SELECT * FROM KAS WHERE TANGGAL < '" & tglupdate & "' ORDER BY TANGGAL DESC LIMIT 1"
            'MsgBox(SQLSTR2)
            Dim DTTANGGAL2 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL2)
            SQLSTR2 = "SELECT * FROM KAS WHERE TANGGAL = '" & CDate(DTTANGGAL2.Rows(0)("TANGGAL")).ToString("yyyy-MM-dd HH:mm:ss") & "' ORDER BY TANGGAL ASC"
            Dim DTTANGGAL3 As New DataTable
            masuktabel(SQLSTR2, DTTANGGAL3)
            'MsgBox(SQLSTR2)
            updatesaldo = DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("SALDO")

            'MsgBox(DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("TANGGAL") & "  " & DTTANGGAL3.Rows(DTTANGGAL3.Rows.Count - 1)("SALDO"))

            For A = 0 To DTTANGGAL.Rows.Count - 1
                updatesaldo = updatesaldo + CInt(DTTANGGAL.Rows(A)("MASUK")) - CInt(DTTANGGAL.Rows(A)("KELUAR"))
                'MsgBox(updatesaldo & "MASUK=" & DTTANGGAL.Rows(A)("MASUK") & " KELUAR = " & DTTANGGAL.Rows(A)("KELUAR"))
                sqlstrupdatesaldo = "UPDATE KAS SET SALDO = '" & updatesaldo & "' WHERE URUT = '" & DTTANGGAL.Rows(A)("URUT") & "'"
                masuktabel(sqlstrupdatesaldo, DTSALDONEW)
                'urutawal = urutawal + 1
            Next
            'Else
            '    'updatesaldo = 0
            '    'sqlstrupdatesaldo = "UPDATE KAS SET SALDO = '" & updatesaldo & "'"
            '    'masuktabel(sqlstrupdatesaldo, DTSALDONEW)
            '    MsgBox("masuk sini")
        End If

    End Sub
End Class