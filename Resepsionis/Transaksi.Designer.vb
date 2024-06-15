<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Transaksi
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
        Me.ComboBoxSumber = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ComboBoxKeluarmasuk = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Labeljumlah = New System.Windows.Forms.Label()
        Me.TextBoxJumlah = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButtonSimpan = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxSumber
        '
        Me.ComboBoxSumber.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxSumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSumber.FormattingEnabled = True
        Me.ComboBoxSumber.Items.AddRange(New Object() {"Resepsionis", "Cafe", "Kas Belanja"})
        Me.ComboBoxSumber.Location = New System.Drawing.Point(155, 12)
        Me.ComboBoxSumber.Name = "ComboBoxSumber"
        Me.ComboBoxSumber.Size = New System.Drawing.Size(150, 24)
        Me.ComboBoxSumber.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sumber Dana:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tanggal"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(142, 68)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(241, 22)
        Me.DateTimePicker1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Keterangan"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(143, 108)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(240, 105)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'ComboBoxKeluarmasuk
        '
        Me.ComboBoxKeluarmasuk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxKeluarmasuk.FormattingEnabled = True
        Me.ComboBoxKeluarmasuk.Items.AddRange(New Object() {"Masuk", "Keluar"})
        Me.ComboBoxKeluarmasuk.Location = New System.Drawing.Point(201, 12)
        Me.ComboBoxKeluarmasuk.Name = "ComboBoxKeluarmasuk"
        Me.ComboBoxKeluarmasuk.Size = New System.Drawing.Size(170, 24)
        Me.ComboBoxKeluarmasuk.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Dana Keluar / Masuk"
        '
        'Labeljumlah
        '
        Me.Labeljumlah.AutoSize = True
        Me.Labeljumlah.Location = New System.Drawing.Point(19, 54)
        Me.Labeljumlah.Name = "Labeljumlah"
        Me.Labeljumlah.Size = New System.Drawing.Size(50, 16)
        Me.Labeljumlah.TabIndex = 8
        Me.Labeljumlah.Text = "Jumlah"
        '
        'TextBoxJumlah
        '
        Me.TextBoxJumlah.Location = New System.Drawing.Point(201, 51)
        Me.TextBoxJumlah.Name = "TextBoxJumlah"
        Me.TextBoxJumlah.Size = New System.Drawing.Size(170, 22)
        Me.TextBoxJumlah.TabIndex = 9
        Me.TextBoxJumlah.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(167, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Rp."
        '
        'ButtonSimpan
        '
        Me.ButtonSimpan.Location = New System.Drawing.Point(127, 347)
        Me.ButtonSimpan.Name = "ButtonSimpan"
        Me.ButtonSimpan.Size = New System.Drawing.Size(192, 27)
        Me.ButtonSimpan.TabIndex = 11
        Me.ButtonSimpan.Text = "Simpan / Cetak"
        Me.ButtonSimpan.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ComboBoxSumber)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(28, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(355, 48)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ComboBoxKeluarmasuk)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TextBoxJumlah)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Labeljumlah)
        Me.Panel2.Location = New System.Drawing.Point(28, 235)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(387, 86)
        Me.Panel2.TabIndex = 13
        '
        'Transaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 409)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonSimpan)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Transaksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaksi"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBoxSumber As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents ComboBoxKeluarmasuk As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Labeljumlah As Label
    Friend WithEvents TextBoxJumlah As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ButtonSimpan As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
