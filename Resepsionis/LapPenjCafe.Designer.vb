<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LapPenjCafe
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonProses = New System.Windows.Forms.Button()
        Me.ButtonKembali = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerUntil = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComboBoxKry = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelTtltrx = New System.Windows.Forms.Label()
        Me.Labelttlkas = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Buttoncetak = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxLokasi = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonProses
        '
        Me.ButtonProses.Location = New System.Drawing.Point(932, 12)
        Me.ButtonProses.Name = "ButtonProses"
        Me.ButtonProses.Size = New System.Drawing.Size(135, 42)
        Me.ButtonProses.TabIndex = 19
        Me.ButtonProses.Text = "Proses"
        Me.ButtonProses.UseVisualStyleBackColor = True
        '
        'ButtonKembali
        '
        Me.ButtonKembali.Location = New System.Drawing.Point(932, 60)
        Me.ButtonKembali.Name = "ButtonKembali"
        Me.ButtonKembali.Size = New System.Drawing.Size(135, 40)
        Me.ButtonKembali.TabIndex = 18
        Me.ButtonKembali.Text = "Kembali"
        Me.ButtonKembali.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(38, 78)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(628, 10)
        Me.ProgressBar1.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(347, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "sampai tgl"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Dari Tgl"
        '
        'DateTimePickerUntil
        '
        Me.DateTimePickerUntil.Location = New System.Drawing.Point(422, 32)
        Me.DateTimePickerUntil.Name = "DateTimePickerUntil"
        Me.DateTimePickerUntil.Size = New System.Drawing.Size(244, 22)
        Me.DateTimePickerUntil.TabIndex = 14
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(73, 32)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(252, 22)
        Me.DateTimePickerFrom.TabIndex = 13
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 106)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1077, 387)
        Me.DataGridView1.TabIndex = 22
        '
        'ComboBoxKry
        '
        Me.ComboBoxKry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxKry.FormattingEnabled = True
        Me.ComboBoxKry.Location = New System.Drawing.Point(772, 30)
        Me.ComboBoxKry.Name = "ComboBoxKry"
        Me.ComboBoxKry.Size = New System.Drawing.Size(142, 24)
        Me.ComboBoxKry.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(697, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Petugas"
        '
        'LabelTtltrx
        '
        Me.LabelTtltrx.AutoSize = True
        Me.LabelTtltrx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTtltrx.Location = New System.Drawing.Point(716, 556)
        Me.LabelTtltrx.Name = "LabelTtltrx"
        Me.LabelTtltrx.Size = New System.Drawing.Size(110, 18)
        Me.LabelTtltrx.TabIndex = 25
        Me.LabelTtltrx.Text = "Total Transaksi"
        '
        'Labelttlkas
        '
        Me.Labelttlkas.AutoSize = True
        Me.Labelttlkas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelttlkas.Location = New System.Drawing.Point(716, 596)
        Me.Labelttlkas.Name = "Labelttlkas"
        Me.Labelttlkas.Size = New System.Drawing.Size(0, 18)
        Me.Labelttlkas.TabIndex = 26
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 499)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(679, 205)
        Me.DataGridView2.TabIndex = 27
        '
        'Buttoncetak
        '
        Me.Buttoncetak.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttoncetak.Location = New System.Drawing.Point(719, 643)
        Me.Buttoncetak.Name = "Buttoncetak"
        Me.Buttoncetak.Size = New System.Drawing.Size(156, 37)
        Me.Buttoncetak.TabIndex = 28
        Me.Buttoncetak.Text = "Cetak"
        Me.Buttoncetak.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(697, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Lokasi"
        '
        'ComboBoxLokasi
        '
        Me.ComboBoxLokasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLokasi.FormattingEnabled = True
        Me.ComboBoxLokasi.Items.AddRange(New Object() {"CAFE", "GUDANG"})
        Me.ComboBoxLokasi.Location = New System.Drawing.Point(772, 69)
        Me.ComboBoxLokasi.Name = "ComboBoxLokasi"
        Me.ComboBoxLokasi.Size = New System.Drawing.Size(142, 24)
        Me.ComboBoxLokasi.TabIndex = 29
        '
        'LapPenjCafe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 715)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBoxLokasi)
        Me.Controls.Add(Me.Buttoncetak)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Labelttlkas)
        Me.Controls.Add(Me.LabelTtltrx)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBoxKry)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonProses)
        Me.Controls.Add(Me.ButtonKembali)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePickerUntil)
        Me.Controls.Add(Me.DateTimePickerFrom)
        Me.Name = "LapPenjCafe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Penjualan Cafe"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonProses As Button
    Friend WithEvents ButtonKembali As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePickerUntil As DateTimePicker
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBoxKry As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelTtltrx As Label
    Friend WithEvents Labelttlkas As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Buttoncetak As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxLokasi As ComboBox
End Class
