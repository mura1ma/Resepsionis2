<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Laporankas
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ButtonProses = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DateTimePickerAKHIR = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerAWAL = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ButtonKembali = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Buttonexport = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonProses
        '
        Me.ButtonProses.Location = New System.Drawing.Point(651, 18)
        Me.ButtonProses.Name = "ButtonProses"
        Me.ButtonProses.Size = New System.Drawing.Size(103, 50)
        Me.ButtonProses.TabIndex = 53
        Me.ButtonProses.Text = "Proses"
        Me.ButtonProses.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Resepsionis", "Cafe", "Kas Belanja"})
        Me.ComboBox1.Location = New System.Drawing.Point(360, 82)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(141, 24)
        Me.ComboBox1.TabIndex = 52
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(268, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Buku "
        '
        'DateTimePickerAKHIR
        '
        Me.DateTimePickerAKHIR.Location = New System.Drawing.Point(360, 51)
        Me.DateTimePickerAKHIR.Name = "DateTimePickerAKHIR"
        Me.DateTimePickerAKHIR.Size = New System.Drawing.Size(253, 22)
        Me.DateTimePickerAKHIR.TabIndex = 50
        '
        'DateTimePickerAWAL
        '
        Me.DateTimePickerAWAL.Location = New System.Drawing.Point(360, 21)
        Me.DateTimePickerAWAL.Name = "DateTimePickerAWAL"
        Me.DateTimePickerAWAL.Size = New System.Drawing.Size(253, 22)
        Me.DateTimePickerAWAL.TabIndex = 49
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(268, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Sampai Tgl"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(268, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 16)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Dari Tanggal"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 130)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(981, 565)
        Me.DataGridView1.TabIndex = 46
        '
        'ButtonKembali
        '
        Me.ButtonKembali.Location = New System.Drawing.Point(651, 74)
        Me.ButtonKembali.Name = "ButtonKembali"
        Me.ButtonKembali.Size = New System.Drawing.Size(103, 50)
        Me.ButtonKembali.TabIndex = 54
        Me.ButtonKembali.Text = "Kembali"
        Me.ButtonKembali.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(618, 130)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(375, 380)
        Me.DataGridView2.TabIndex = 55
        '
        'Buttonexport
        '
        Me.Buttonexport.Location = New System.Drawing.Point(855, 46)
        Me.Buttonexport.Name = "Buttonexport"
        Me.Buttonexport.Size = New System.Drawing.Size(103, 29)
        Me.Buttonexport.TabIndex = 56
        Me.Buttonexport.Text = "Export"
        Me.Buttonexport.UseVisualStyleBackColor = True
        '
        'Laporankas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 710)
        Me.ControlBox = False
        Me.Controls.Add(Me.Buttonexport)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.ButtonKembali)
        Me.Controls.Add(Me.ButtonProses)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DateTimePickerAKHIR)
        Me.Controls.Add(Me.DateTimePickerAWAL)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Laporankas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporankas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonProses As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents DateTimePickerAKHIR As DateTimePicker
    Friend WithEvents DateTimePickerAWAL As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ButtonKembali As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Buttonexport As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
