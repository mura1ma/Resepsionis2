<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Jumlahkmr
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
        Me.ButtonProcess = New System.Windows.Forms.Button()
        Me.DateTimePickerDari = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerSampai = New System.Windows.Forms.DateTimePicker()
        Me.LabelTtlkamar = New System.Windows.Forms.Label()
        Me.TextBoxTtlkamar = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonProcess
        '
        Me.ButtonProcess.Location = New System.Drawing.Point(362, 21)
        Me.ButtonProcess.Name = "ButtonProcess"
        Me.ButtonProcess.Size = New System.Drawing.Size(100, 39)
        Me.ButtonProcess.TabIndex = 0
        Me.ButtonProcess.Text = "Proses"
        Me.ButtonProcess.UseVisualStyleBackColor = True
        '
        'DateTimePickerDari
        '
        Me.DateTimePickerDari.Location = New System.Drawing.Point(86, 21)
        Me.DateTimePickerDari.Name = "DateTimePickerDari"
        Me.DateTimePickerDari.Size = New System.Drawing.Size(247, 22)
        Me.DateTimePickerDari.TabIndex = 1
        '
        'DateTimePickerSampai
        '
        Me.DateTimePickerSampai.Location = New System.Drawing.Point(86, 49)
        Me.DateTimePickerSampai.Name = "DateTimePickerSampai"
        Me.DateTimePickerSampai.Size = New System.Drawing.Size(247, 22)
        Me.DateTimePickerSampai.TabIndex = 2
        '
        'LabelTtlkamar
        '
        Me.LabelTtlkamar.AutoSize = True
        Me.LabelTtlkamar.Location = New System.Drawing.Point(499, 32)
        Me.LabelTtlkamar.Name = "LabelTtlkamar"
        Me.LabelTtlkamar.Size = New System.Drawing.Size(80, 16)
        Me.LabelTtlkamar.TabIndex = 3
        Me.LabelTtlkamar.Text = "Total Kamar"
        '
        'TextBoxTtlkamar
        '
        Me.TextBoxTtlkamar.Location = New System.Drawing.Point(598, 29)
        Me.TextBoxTtlkamar.Name = "TextBoxTtlkamar"
        Me.TextBoxTtlkamar.Size = New System.Drawing.Size(155, 22)
        Me.TextBoxTtlkamar.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonExport)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.DateTimePickerDari)
        Me.GroupBox3.Controls.Add(Me.ButtonProcess)
        Me.GroupBox3.Controls.Add(Me.DateTimePickerSampai)
        Me.GroupBox3.Controls.Add(Me.TextBoxTtlkamar)
        Me.GroupBox3.Controls.Add(Me.LabelTtlkamar)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1114, 90)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pencapaian"
        '
        'ButtonExport
        '
        Me.ButtonExport.Location = New System.Drawing.Point(890, 29)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(135, 28)
        Me.ButtonExport.TabIndex = 16
        Me.ButtonExport.Text = "Export"
        Me.ButtonExport.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(359, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(434, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "**Dihitung jumlah check in saja tanpa peduli sudah check out atau belum"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Check In"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 119)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1114, 543)
        Me.DataGridView1.TabIndex = 29
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(72, 242)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(876, 212)
        Me.DataGridView2.TabIndex = 30
        Me.DataGridView2.Visible = False
        '
        'Jumlahkmr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 674)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Jumlahkmr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Total Kamar"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonProcess As Button
    Friend WithEvents DateTimePickerDari As DateTimePicker
    Friend WithEvents DateTimePickerSampai As DateTimePicker
    Friend WithEvents LabelTtlkamar As Label
    Friend WithEvents TextBoxTtlkamar As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents ButtonExport As Button
End Class
