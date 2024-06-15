
Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient


Module Modulesubroutine
    
    Sub ExportDgvToExcel(ByVal dgv As DataGridView)
        Try
            If dgv Is Nothing OrElse dgv.RowCount <= 0 Then
                MsgBox("The Data is empty!!!")
                Exit Sub
            End If
            Dim sfdExcel As SaveFileDialog = New SaveFileDialog
            sfdExcel.Filter = "Excel File|*.xlsx"
            sfdExcel.Title = "Save an Excel File"
            sfdExcel.ShowDialog()
            If sfdExcel.FileName = "" Then
                MsgBox("Please Type File Name")
                Exit Sub
            End If
            Dim wb As XLWorkbook = New XLWorkbook
            wb.AddWorksheet(Format(Now, "dd MMM yy"))
            Dim ws = wb.Worksheet(Format(Now, "dd MMM yy"))
            For Each column As DataGridViewColumn In dgv.Columns
                ws.Cell(1, column.Index + 1).Value = column.HeaderText
                With ws.Cell(1, column.Index + 1).Style
                    .Font.Bold = True
                    .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Border.OutsideBorder = XLBorderStyleValues.Thin
                    .Fill.BackgroundColor = XLColor.LightGreen
                End With
                ws.RowHeight = dgv.ColumnHeadersHeight
            Next
            For Each row As DataGridViewRow In dgv.Rows
                For Each cell As DataGridViewCell In row.Cells
                    ws.Cell(cell.RowIndex + 2, cell.ColumnIndex + 1).Value = cell.Value.ToString
                Next
            Next
            wb.SaveAs(sfdExcel.FileName)
            If MsgBox("Do You Want To Open File", vbQuestion + vbYesNo, "Question?") = vbYes Then
                Process.Start(sfdExcel.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'WriteErrorLog("sub saveExcelFile Form7--> Error saat export data")
        End Try
    End Sub
    Sub masuktabel(ByVal sqlstr As String, ByRef dt As DataTable)
        Dim connstr(4) As String
        Dim counter As Integer = 0

        '' 0 = host
        '' 1 = port
        '' 2 = id
        '' 3 = password
        '' 4 = database

        Dim filePath As String = "src\conn.dt"
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Console.WriteLine(line) ' Print the line to the console (you can process it differently)
                    connstr(counter) = line
                    counter = counter + 1
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If

        Dim conn As MySqlConnection
        Dim command As MySqlCommand = New MySqlCommand
        Dim rd As MySqlDataReader
        Dim adapter As MySqlDataAdapter
        adapter = New MySqlDataAdapter
        conn = New MySqlConnection()
        conn.ConnectionString = "server= " + connstr(0) + ";port = " + connstr(1) + ";user id= " + connstr(2) + ";password= " + connstr(3) + ";database=" + connstr(4) + ";Allow User Variables=True"
        'conn.ConnectionString = "server= localhost:3306 ;user id= " + connstr(2) + ";password= " + connstr(3) + ";database=" + connstr(4) + ";Allow User Variables=True"

        conn.Open()


        command.Connection = conn
        command.CommandText = sqlstr
        adapter.SelectCommand = command
        rd = command.ExecuteReader
        dt.Load(rd)
        conn.Close()

    End Sub
    Sub changedatafromtabel(ByVal sqlstr As String, ByRef dt As DataTable)
        Dim connstr(4) As String
        Dim counter As Integer = 0

        '' 0 = host
        '' 1 = port
        '' 2 = id
        '' 3 = password
        '' 4 = database

        Dim filePath As String = "src\conn.dt"
        If File.Exists(filePath) Then
            ' Create a StreamReader to read the file
            Using reader As New StreamReader(filePath)
                ' Read and process each line in the file
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Console.WriteLine(line) ' Print the line to the console (you can process it differently)
                    connstr(counter) = line
                    counter = counter + 1
                End While
            End Using
        Else
            Console.WriteLine("The file does not exist.")
        End If


        Dim sqlConn As New MySqlConnection
        Dim sqlComm As New MySqlCommand
        sqlConn.ConnectionString = "server= " + connstr(0) + ";port = " + connstr(1) + ";user id= " + connstr(2) + ";password= " + connstr(3) + ";database=" + connstr(4) + ";Allow User Variables=True; Convert Zero Datetime=True"
        sqlComm.Connection = sqlConn
        sqlComm.CommandText = sqlstr
        sqlComm.CommandType = CommandType.Text

        Dim da As New MySqlDataAdapter(sqlComm)
        da.Fill(dt)

        Dim scb As New MySqlCommandBuilder(da)
        da.Update(dt)
        da.Dispose()

    End Sub



End Module
