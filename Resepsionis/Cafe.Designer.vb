<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafe
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
        Me.Buttonsimpan = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Kuantitas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hrg_satuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttlHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hargakry = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Blmlunas = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Buttoncancel = New System.Windows.Forms.Button()
        Me.TextBoxsubtotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxpelanggan = New System.Windows.Forms.TextBox()
        Me.Tambahbtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxketerangan = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxkry = New System.Windows.Forms.ComboBox()
        Me.ButtonPenjPemb = New System.Windows.Forms.Button()
        Me.ButtonBonus = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Buttonsimpan
        '
        Me.Buttonsimpan.Location = New System.Drawing.Point(151, 572)
        Me.Buttonsimpan.Name = "Buttonsimpan"
        Me.Buttonsimpan.Size = New System.Drawing.Size(136, 47)
        Me.Buttonsimpan.TabIndex = 0
        Me.Buttonsimpan.Text = "Simpan + Cetak"
        Me.Buttonsimpan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tanggal:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Location = New System.Drawing.Point(152, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(257, 22)
        Me.DateTimePicker1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.Kuantitas, Me.Hrg_satuan, Me.ttlHarga, Me.Hargakry, Me.Blmlunas})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 149)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(861, 370)
        Me.DataGridView1.TabIndex = 3
        '
        'Item
        '
        Me.Item.HeaderText = "Item Barang"
        Me.Item.MinimumWidth = 6
        Me.Item.Name = "Item"
        Me.Item.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Item.Width = 200
        '
        'Kuantitas
        '
        Me.Kuantitas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Kuantitas.HeaderText = "Kuantitas"
        Me.Kuantitas.MinimumWidth = 6
        Me.Kuantitas.Name = "Kuantitas"
        Me.Kuantitas.Width = 90
        '
        'Hrg_satuan
        '
        Me.Hrg_satuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Hrg_satuan.HeaderText = "Harga / pcs"
        Me.Hrg_satuan.MinimumWidth = 6
        Me.Hrg_satuan.Name = "Hrg_satuan"
        Me.Hrg_satuan.ReadOnly = True
        Me.Hrg_satuan.Width = 78
        '
        'ttlHarga
        '
        Me.ttlHarga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ttlHarga.HeaderText = "Total Harga"
        Me.ttlHarga.MinimumWidth = 6
        Me.ttlHarga.Name = "ttlHarga"
        Me.ttlHarga.ReadOnly = True
        '
        'Hargakry
        '
        Me.Hargakry.HeaderText = "Harga Karyawan"
        Me.Hargakry.MinimumWidth = 6
        Me.Hargakry.Name = "Hargakry"
        Me.Hargakry.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Hargakry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Hargakry.Width = 75
        '
        'Blmlunas
        '
        Me.Blmlunas.HeaderText = "Belum lunas"
        Me.Blmlunas.MinimumWidth = 6
        Me.Blmlunas.Name = "Blmlunas"
        Me.Blmlunas.Width = 75
        '
        'Buttoncancel
        '
        Me.Buttoncancel.Location = New System.Drawing.Point(503, 572)
        Me.Buttoncancel.Name = "Buttoncancel"
        Me.Buttoncancel.Size = New System.Drawing.Size(136, 47)
        Me.Buttoncancel.TabIndex = 4
        Me.Buttoncancel.Text = "Cancel"
        Me.Buttoncancel.UseVisualStyleBackColor = True
        '
        'TextBoxsubtotal
        '
        Me.TextBoxsubtotal.Enabled = False
        Me.TextBoxsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxsubtotal.Location = New System.Drawing.Point(604, 525)
        Me.TextBoxsubtotal.Name = "TextBoxsubtotal"
        Me.TextBoxsubtotal.Size = New System.Drawing.Size(171, 30)
        Me.TextBoxsubtotal.TabIndex = 5
        Me.TextBoxsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(489, 528)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Total:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Pelanggan: "
        '
        'TextBoxpelanggan
        '
        Me.TextBoxpelanggan.Location = New System.Drawing.Point(152, 40)
        Me.TextBoxpelanggan.Name = "TextBoxpelanggan"
        Me.TextBoxpelanggan.Size = New System.Drawing.Size(420, 22)
        Me.TextBoxpelanggan.TabIndex = 8
        '
        'Tambahbtn
        '
        Me.Tambahbtn.Location = New System.Drawing.Point(664, 96)
        Me.Tambahbtn.Name = "Tambahbtn"
        Me.Tambahbtn.Size = New System.Drawing.Size(111, 31)
        Me.Tambahbtn.TabIndex = 9
        Me.Tambahbtn.Text = "Tambah Item"
        Me.Tambahbtn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 525)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "** Double click untuk menghapus row"
        '
        'TextBoxketerangan
        '
        Me.TextBoxketerangan.Location = New System.Drawing.Point(152, 68)
        Me.TextBoxketerangan.Name = "TextBoxketerangan"
        Me.TextBoxketerangan.Size = New System.Drawing.Size(420, 22)
        Me.TextBoxketerangan.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Keterangan: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(554, 528)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 25)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Rp."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Petugas: "
        '
        'ComboBoxkry
        '
        Me.ComboBoxkry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxkry.FormattingEnabled = True
        Me.ComboBoxkry.Location = New System.Drawing.Point(152, 100)
        Me.ComboBoxkry.Name = "ComboBoxkry"
        Me.ComboBoxkry.Size = New System.Drawing.Size(155, 24)
        Me.ComboBoxkry.TabIndex = 15
        '
        'ButtonPenjPemb
        '
        Me.ButtonPenjPemb.Font = New System.Drawing.Font("Swis721 Blk BT", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPenjPemb.Location = New System.Drawing.Point(581, 6)
        Me.ButtonPenjPemb.Name = "ButtonPenjPemb"
        Me.ButtonPenjPemb.Size = New System.Drawing.Size(207, 37)
        Me.ButtonPenjPemb.TabIndex = 16
        Me.ButtonPenjPemb.Text = "Penjualan"
        Me.ButtonPenjPemb.UseVisualStyleBackColor = True
        '
        'ButtonBonus
        '
        Me.ButtonBonus.BackColor = System.Drawing.Color.PaleGreen
        Me.ButtonBonus.Location = New System.Drawing.Point(813, 10)
        Me.ButtonBonus.Name = "ButtonBonus"
        Me.ButtonBonus.Size = New System.Drawing.Size(60, 31)
        Me.ButtonBonus.TabIndex = 17
        Me.ButtonBonus.Text = "Bonus"
        Me.ButtonBonus.UseVisualStyleBackColor = False
        '
        'Cafe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Snow
        Me.ClientSize = New System.Drawing.Size(886, 634)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonBonus)
        Me.Controls.Add(Me.ButtonPenjPemb)
        Me.Controls.Add(Me.ComboBoxkry)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxketerangan)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tambahbtn)
        Me.Controls.Add(Me.TextBoxpelanggan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxsubtotal)
        Me.Controls.Add(Me.Buttoncancel)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Buttonsimpan)
        Me.Name = "Cafe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaksi Cafe"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Buttonsimpan As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Buttoncancel As Button
    Friend WithEvents TextBoxsubtotal As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxpelanggan As TextBox
    Friend WithEvents Tambahbtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxketerangan As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBoxkry As ComboBox
    Friend WithEvents ButtonPenjPemb As Button
    Friend WithEvents Item As DataGridViewComboBoxColumn
    Friend WithEvents Kuantitas As DataGridViewTextBoxColumn
    Friend WithEvents Hrg_satuan As DataGridViewTextBoxColumn
    Friend WithEvents ttlHarga As DataGridViewTextBoxColumn
    Friend WithEvents Hargakry As DataGridViewCheckBoxColumn
    Friend WithEvents Blmlunas As DataGridViewCheckBoxColumn
    Friend WithEvents ButtonBonus As Button
End Class
