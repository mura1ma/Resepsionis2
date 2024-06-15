<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pindahgudang
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxJumlah = New System.Windows.Forms.TextBox()
        Me.Buttonsimpan = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBoxtujuan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxpetugas = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Location = New System.Drawing.Point(138, 24)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(259, 22)
        Me.DateTimePicker1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(36, 94)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(223, 24)
        Me.ComboBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Barang asal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(320, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Barang Tujuan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Jumlah"
        '
        'TextBoxJumlah
        '
        Me.TextBoxJumlah.Location = New System.Drawing.Point(90, 138)
        Me.TextBoxJumlah.Name = "TextBoxJumlah"
        Me.TextBoxJumlah.Size = New System.Drawing.Size(136, 22)
        Me.TextBoxJumlah.TabIndex = 6
        '
        'Buttonsimpan
        '
        Me.Buttonsimpan.Location = New System.Drawing.Point(113, 204)
        Me.Buttonsimpan.Name = "Buttonsimpan"
        Me.Buttonsimpan.Size = New System.Drawing.Size(146, 31)
        Me.Buttonsimpan.TabIndex = 7
        Me.Buttonsimpan.Text = "Simpan"
        Me.Buttonsimpan.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(311, 204)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 31)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBoxtujuan
        '
        Me.TextBoxtujuan.Enabled = False
        Me.TextBoxtujuan.Location = New System.Drawing.Point(321, 96)
        Me.TextBoxtujuan.Name = "TextBoxtujuan"
        Me.TextBoxtujuan.Size = New System.Drawing.Size(220, 22)
        Me.TextBoxtujuan.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(318, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Petugas"
        '
        'ComboBoxpetugas
        '
        Me.ComboBoxpetugas.FormattingEnabled = True
        Me.ComboBoxpetugas.Location = New System.Drawing.Point(385, 136)
        Me.ComboBoxpetugas.Name = "ComboBoxpetugas"
        Me.ComboBoxpetugas.Size = New System.Drawing.Size(156, 24)
        Me.ComboBoxpetugas.TabIndex = 11
        '
        'Pindahgudang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.ComboBoxpetugas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxtujuan)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Buttonsimpan)
        Me.Controls.Add(Me.TextBoxJumlah)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "Pindahgudang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pindah Gudang"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxJumlah As TextBox
    Friend WithEvents Buttonsimpan As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBoxtujuan As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxpetugas As ComboBox
End Class
