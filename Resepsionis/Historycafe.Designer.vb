<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Historycafe
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerUntil = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonKembali = New System.Windows.Forms.Button()
        Me.Buttonexport = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonProses
        '
        Me.ButtonProses.Location = New System.Drawing.Point(704, 20)
        Me.ButtonProses.Name = "ButtonProses"
        Me.ButtonProses.Size = New System.Drawing.Size(110, 45)
        Me.ButtonProses.TabIndex = 14
        Me.ButtonProses.Text = "Proses"
        Me.ButtonProses.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(25, 55)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(323, 10)
        Me.ProgressBar1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(360, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "sampai"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Mulai Tgl"
        '
        'DateTimePickerUntil
        '
        Me.DateTimePickerUntil.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerUntil.Location = New System.Drawing.Point(423, 24)
        Me.DateTimePickerUntil.Name = "DateTimePickerUntil"
        Me.DateTimePickerUntil.Size = New System.Drawing.Size(275, 22)
        Me.DateTimePickerUntil.TabIndex = 10
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(80, 24)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(268, 22)
        Me.DateTimePickerFrom.TabIndex = 9
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 85)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1032, 567)
        Me.DataGridView1.TabIndex = 15
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(485, 55)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(213, 24)
        Me.ComboBox1.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(387, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Item Barang"
        '
        'ButtonKembali
        '
        Me.ButtonKembali.Location = New System.Drawing.Point(820, 20)
        Me.ButtonKembali.Name = "ButtonKembali"
        Me.ButtonKembali.Size = New System.Drawing.Size(110, 45)
        Me.ButtonKembali.TabIndex = 18
        Me.ButtonKembali.Text = "Kembali"
        Me.ButtonKembali.UseVisualStyleBackColor = True
        '
        'Buttonexport
        '
        Me.Buttonexport.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonexport.Location = New System.Drawing.Point(969, 20)
        Me.Buttonexport.Name = "Buttonexport"
        Me.Buttonexport.Size = New System.Drawing.Size(75, 26)
        Me.Buttonexport.TabIndex = 19
        Me.Buttonexport.Text = "Export"
        Me.Buttonexport.UseVisualStyleBackColor = True
        '
        'Historycafe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 664)
        Me.ControlBox = False
        Me.Controls.Add(Me.Buttonexport)
        Me.Controls.Add(Me.ButtonKembali)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonProses)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePickerUntil)
        Me.Controls.Add(Me.DateTimePickerFrom)
        Me.Name = "Historycafe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History cafe"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonProses As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePickerUntil As DateTimePicker
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonKembali As Button
    Friend WithEvents Buttonexport As Button
End Class
