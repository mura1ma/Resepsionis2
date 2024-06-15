<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pendinglist
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PetugasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MutasiKAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenyesuaianSaldoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MutasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KasResepsionisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanPenjualanCafeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelisihToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CafeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CafeBlmLunasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiCafeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryCafeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StokCafeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PindahGudangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanPenjualanCafeHarianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenyesuaianCafeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PilihPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TesPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrinternToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Buttontrxcafe = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 122)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(871, 536)
        Me.DataGridView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(468, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "List Check In Pending"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 57)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Check In Baru"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(653, 42)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(220, 58)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "List Check Out"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(453, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "*Klik untuk check out / edit"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterToolStripMenuItem, Me.MenuToolStripMenuItem, Me.MutasiToolStripMenuItem, Me.CafeToolStripMenuItem, Me.SetPrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(895, 28)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterToolStripMenuItem
        '
        Me.MasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PetugasToolStripMenuItem, Me.MasterBarangToolStripMenuItem, Me.DatabaseToolStripMenuItem})
        Me.MasterToolStripMenuItem.Name = "MasterToolStripMenuItem"
        Me.MasterToolStripMenuItem.Size = New System.Drawing.Size(68, 24)
        Me.MasterToolStripMenuItem.Text = "Master"
        '
        'PetugasToolStripMenuItem
        '
        Me.PetugasToolStripMenuItem.Name = "PetugasToolStripMenuItem"
        Me.PetugasToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.PetugasToolStripMenuItem.Text = "Master Petugas"
        '
        'MasterBarangToolStripMenuItem
        '
        Me.MasterBarangToolStripMenuItem.Name = "MasterBarangToolStripMenuItem"
        Me.MasterBarangToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.MasterBarangToolStripMenuItem.Text = "Master Barang"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PriveToolStripMenuItem, Me.MutasiKAsToolStripMenuItem, Me.PenyesuaianSaldoToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(57, 24)
        Me.MenuToolStripMenuItem.Text = "Input"
        '
        'PriveToolStripMenuItem
        '
        Me.PriveToolStripMenuItem.Name = "PriveToolStripMenuItem"
        Me.PriveToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PriveToolStripMenuItem.Text = "Prive"
        '
        'MutasiKAsToolStripMenuItem
        '
        Me.MutasiKAsToolStripMenuItem.Name = "MutasiKAsToolStripMenuItem"
        Me.MutasiKAsToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.MutasiKAsToolStripMenuItem.Text = "Transaksi"
        '
        'PenyesuaianSaldoToolStripMenuItem
        '
        Me.PenyesuaianSaldoToolStripMenuItem.Name = "PenyesuaianSaldoToolStripMenuItem"
        Me.PenyesuaianSaldoToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PenyesuaianSaldoToolStripMenuItem.Text = "Penyesuaian saldo"
        '
        'MutasiToolStripMenuItem
        '
        Me.MutasiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KasResepsionisToolStripMenuItem, Me.LaporanPenjualanCafeToolStripMenuItem, Me.SelisihToolStripMenuItem})
        Me.MutasiToolStripMenuItem.Name = "MutasiToolStripMenuItem"
        Me.MutasiToolStripMenuItem.Size = New System.Drawing.Size(77, 24)
        Me.MutasiToolStripMenuItem.Text = "Laporan"
        '
        'KasResepsionisToolStripMenuItem
        '
        Me.KasResepsionisToolStripMenuItem.Name = "KasResepsionisToolStripMenuItem"
        Me.KasResepsionisToolStripMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.KasResepsionisToolStripMenuItem.Text = "Kas Resepsionis / Cafe / Belanja"
        '
        'LaporanPenjualanCafeToolStripMenuItem
        '
        Me.LaporanPenjualanCafeToolStripMenuItem.Name = "LaporanPenjualanCafeToolStripMenuItem"
        Me.LaporanPenjualanCafeToolStripMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.LaporanPenjualanCafeToolStripMenuItem.Text = "Laporan Penjualan Cafe"
        '
        'SelisihToolStripMenuItem
        '
        Me.SelisihToolStripMenuItem.Name = "SelisihToolStripMenuItem"
        Me.SelisihToolStripMenuItem.Size = New System.Drawing.Size(303, 26)
        Me.SelisihToolStripMenuItem.Text = "Jumlah Kamar"
        '
        'CafeToolStripMenuItem
        '
        Me.CafeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CafeBlmLunasToolStripMenuItem, Me.TransaksiCafeToolStripMenuItem, Me.HistoryCafeToolStripMenuItem, Me.StokCafeToolStripMenuItem, Me.PindahGudangToolStripMenuItem, Me.LaporanPenjualanCafeHarianToolStripMenuItem, Me.PenyesuaianCafeToolStripMenuItem})
        Me.CafeToolStripMenuItem.Name = "CafeToolStripMenuItem"
        Me.CafeToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.CafeToolStripMenuItem.Text = "Cafe"
        '
        'CafeBlmLunasToolStripMenuItem
        '
        Me.CafeBlmLunasToolStripMenuItem.Name = "CafeBlmLunasToolStripMenuItem"
        Me.CafeBlmLunasToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.CafeBlmLunasToolStripMenuItem.Text = "Cafe Blm lunas"
        '
        'TransaksiCafeToolStripMenuItem
        '
        Me.TransaksiCafeToolStripMenuItem.Name = "TransaksiCafeToolStripMenuItem"
        Me.TransaksiCafeToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.TransaksiCafeToolStripMenuItem.Text = "Transaksi Cafe"
        '
        'HistoryCafeToolStripMenuItem
        '
        Me.HistoryCafeToolStripMenuItem.Name = "HistoryCafeToolStripMenuItem"
        Me.HistoryCafeToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.HistoryCafeToolStripMenuItem.Text = "History Cafe"
        '
        'StokCafeToolStripMenuItem
        '
        Me.StokCafeToolStripMenuItem.Name = "StokCafeToolStripMenuItem"
        Me.StokCafeToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.StokCafeToolStripMenuItem.Text = "Stok Cafe"
        '
        'PindahGudangToolStripMenuItem
        '
        Me.PindahGudangToolStripMenuItem.Name = "PindahGudangToolStripMenuItem"
        Me.PindahGudangToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.PindahGudangToolStripMenuItem.Text = "Pindah Gudang"
        '
        'LaporanPenjualanCafeHarianToolStripMenuItem
        '
        Me.LaporanPenjualanCafeHarianToolStripMenuItem.Name = "LaporanPenjualanCafeHarianToolStripMenuItem"
        Me.LaporanPenjualanCafeHarianToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.LaporanPenjualanCafeHarianToolStripMenuItem.Text = "Laporan penjualan cafe harian"
        '
        'PenyesuaianCafeToolStripMenuItem
        '
        Me.PenyesuaianCafeToolStripMenuItem.Name = "PenyesuaianCafeToolStripMenuItem"
        Me.PenyesuaianCafeToolStripMenuItem.Size = New System.Drawing.Size(292, 26)
        Me.PenyesuaianCafeToolStripMenuItem.Text = "penyesuaian cafe"
        '
        'SetPrintToolStripMenuItem
        '
        Me.SetPrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PilihPrinterToolStripMenuItem, Me.TesPrinterToolStripMenuItem, Me.PrinternToolStripMenuItem})
        Me.SetPrintToolStripMenuItem.Name = "SetPrintToolStripMenuItem"
        Me.SetPrintToolStripMenuItem.Size = New System.Drawing.Size(118, 24)
        Me.SetPrintToolStripMenuItem.Text = "Setting printer"
        '
        'PilihPrinterToolStripMenuItem
        '
        Me.PilihPrinterToolStripMenuItem.Name = "PilihPrinterToolStripMenuItem"
        Me.PilihPrinterToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.PilihPrinterToolStripMenuItem.Text = "Pilih Printer"
        '
        'TesPrinterToolStripMenuItem
        '
        Me.TesPrinterToolStripMenuItem.Name = "TesPrinterToolStripMenuItem"
        Me.TesPrinterToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.TesPrinterToolStripMenuItem.Text = "Tes Printer"
        '
        'PrinternToolStripMenuItem
        '
        Me.PrinternToolStripMenuItem.Name = "PrinternToolStripMenuItem"
        Me.PrinternToolStripMenuItem.Size = New System.Drawing.Size(172, 26)
        Me.PrinternToolStripMenuItem.Text = "Printername"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Buttontrxcafe
        '
        Me.Buttontrxcafe.Location = New System.Drawing.Point(221, 43)
        Me.Buttontrxcafe.Name = "Buttontrxcafe"
        Me.Buttontrxcafe.Size = New System.Drawing.Size(180, 58)
        Me.Buttontrxcafe.TabIndex = 7
        Me.Buttontrxcafe.Text = "Transaksi Cafe"
        Me.Buttontrxcafe.UseVisualStyleBackColor = True
        '
        'Pendinglist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 670)
        Me.Controls.Add(Me.Buttontrxcafe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Pendinglist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " ver 24.05.17"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MasterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PetugasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MutasiKAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MutasiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KasResepsionisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PriveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelisihToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetPrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PilihPrinterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TesPrinterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrinternToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Buttontrxcafe As Button
    Friend WithEvents LaporanPenjualanCafeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MasterBarangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CafeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiCafeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HistoryCafeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StokCafeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CafeBlmLunasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PindahGudangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaporanPenjualanCafeHarianToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PenyesuaianCafeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PenyesuaianSaldoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As ToolStripMenuItem
End Class
