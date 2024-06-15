<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelesaiList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerUntil = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonKembali = New System.Windows.Forms.Button()
        Me.ButtonProses = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 111)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1175, 630)
        Me.DataGridView1.TabIndex = 0
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(132, 33)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(273, 22)
        Me.DateTimePickerFrom.TabIndex = 2
        '
        'DateTimePickerUntil
        '
        Me.DateTimePickerUntil.Location = New System.Drawing.Point(520, 33)
        Me.DateTimePickerUntil.Name = "DateTimePickerUntil"
        Me.DateTimePickerUntil.Size = New System.Drawing.Size(274, 22)
        Me.DateTimePickerUntil.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Check Out Tgl"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(432, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "sampai tgl"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(31, 64)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(523, 10)
        Me.ProgressBar1.TabIndex = 6
        '
        'ButtonKembali
        '
        Me.ButtonKembali.Location = New System.Drawing.Point(982, 29)
        Me.ButtonKembali.Name = "ButtonKembali"
        Me.ButtonKembali.Size = New System.Drawing.Size(149, 45)
        Me.ButtonKembali.TabIndex = 7
        Me.ButtonKembali.Text = "Kembali"
        Me.ButtonKembali.UseVisualStyleBackColor = True
        '
        'ButtonProses
        '
        Me.ButtonProses.Location = New System.Drawing.Point(823, 29)
        Me.ButtonProses.Name = "ButtonProses"
        Me.ButtonProses.Size = New System.Drawing.Size(135, 45)
        Me.ButtonProses.TabIndex = 8
        Me.ButtonProses.Text = "Proses"
        Me.ButtonProses.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(246, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "** Double click untuk cetak ulang invoice"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(331, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "** Ctrl + click untuk edit"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(562, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(563, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "**Hanya menghitung jumlah check out (utk perhitungan bulanan gunakan menu 'jumlah" &
    " kamar')"
        '
        'SelesaiList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1199, 753)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonProses)
        Me.Controls.Add(Me.ButtonKembali)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePickerUntil)
        Me.Controls.Add(Me.DateTimePickerFrom)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "SelesaiList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelesaiList"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents DateTimePickerUntil As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ButtonKembali As Button
    Friend WithEvents ButtonProses As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
