<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StokcafeAll
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonProses = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ButtonKembali = New System.Windows.Forms.Button()
        Me.Exportbtn = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxresepsionis = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxcafe = New System.Windows.Forms.TextBox()
        Me.TextBoxbelanja = New System.Windows.Forms.TextBox()
        Me.Buttoncocok = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxttlbon = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(164, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(234, 22)
        Me.DateTimePicker1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(99, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tanggal:"
        '
        'ButtonProses
        '
        Me.ButtonProses.Location = New System.Drawing.Point(523, 70)
        Me.ButtonProses.Name = "ButtonProses"
        Me.ButtonProses.Size = New System.Drawing.Size(92, 36)
        Me.ButtonProses.TabIndex = 2
        Me.ButtonProses.Text = "Proses"
        Me.ButtonProses.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeight = 29
        Me.DataGridView1.Location = New System.Drawing.Point(13, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(489, 610)
        Me.DataGridView1.TabIndex = 3
        '
        'ButtonKembali
        '
        Me.ButtonKembali.Location = New System.Drawing.Point(657, 70)
        Me.ButtonKembali.Name = "ButtonKembali"
        Me.ButtonKembali.Size = New System.Drawing.Size(92, 36)
        Me.ButtonKembali.TabIndex = 4
        Me.ButtonKembali.Text = "Kembali"
        Me.ButtonKembali.UseVisualStyleBackColor = True
        '
        'Exportbtn
        '
        Me.Exportbtn.Enabled = False
        Me.Exportbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exportbtn.Location = New System.Drawing.Point(551, 399)
        Me.Exportbtn.Name = "Exportbtn"
        Me.Exportbtn.Size = New System.Drawing.Size(110, 26)
        Me.Exportbtn.TabIndex = 5
        Me.Exportbtn.Text = "Export"
        Me.Exportbtn.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(526, 302)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(135, 24)
        Me.ComboBox1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(526, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Shift:"
        '
        'TextBoxresepsionis
        '
        Me.TextBoxresepsionis.Location = New System.Drawing.Point(651, 127)
        Me.TextBoxresepsionis.Name = "TextBoxresepsionis"
        Me.TextBoxresepsionis.ReadOnly = True
        Me.TextBoxresepsionis.Size = New System.Drawing.Size(151, 22)
        Me.TextBoxresepsionis.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(523, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Saldo resepsionis:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(523, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Saldo cafe:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(523, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Saldo Kas belanja:"
        '
        'TextBoxcafe
        '
        Me.TextBoxcafe.Location = New System.Drawing.Point(651, 158)
        Me.TextBoxcafe.Name = "TextBoxcafe"
        Me.TextBoxcafe.ReadOnly = True
        Me.TextBoxcafe.Size = New System.Drawing.Size(151, 22)
        Me.TextBoxcafe.TabIndex = 12
        '
        'TextBoxbelanja
        '
        Me.TextBoxbelanja.Location = New System.Drawing.Point(651, 188)
        Me.TextBoxbelanja.Name = "TextBoxbelanja"
        Me.TextBoxbelanja.ReadOnly = True
        Me.TextBoxbelanja.Size = New System.Drawing.Size(151, 22)
        Me.TextBoxbelanja.TabIndex = 13
        '
        'Buttoncocok
        '
        Me.Buttoncocok.Enabled = False
        Me.Buttoncocok.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttoncocok.Location = New System.Drawing.Point(551, 356)
        Me.Buttoncocok.Name = "Buttoncocok"
        Me.Buttoncocok.Size = New System.Drawing.Size(110, 26)
        Me.Buttoncocok.TabIndex = 14
        Me.Buttoncocok.Text = "Saldo cocok"
        Me.Buttoncocok.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Viner Hand ITC", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Crimson
        Me.Label6.Location = New System.Drawing.Point(669, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 32)
        Me.Label6.TabIndex = 15
        '
        'TextBoxttlbon
        '
        Me.TextBoxttlbon.Location = New System.Drawing.Point(651, 235)
        Me.TextBoxttlbon.Name = "TextBoxttlbon"
        Me.TextBoxttlbon.ReadOnly = True
        Me.TextBoxttlbon.Size = New System.Drawing.Size(151, 22)
        Me.TextBoxttlbon.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(523, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Total Bon Cafe:"
        '
        'StokcafeAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 676)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBoxttlbon)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Buttoncocok)
        Me.Controls.Add(Me.TextBoxbelanja)
        Me.Controls.Add(Me.TextBoxcafe)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxresepsionis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Exportbtn)
        Me.Controls.Add(Me.ButtonKembali)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonProses)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "StokcafeAll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stok Cafe"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonProses As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ButtonKembali As Button
    Friend WithEvents Exportbtn As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxresepsionis As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxcafe As TextBox
    Friend WithEvents TextBoxbelanja As TextBox
    Friend WithEvents Buttoncocok As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxttlbon As TextBox
    Friend WithEvents Label7 As Label
End Class
