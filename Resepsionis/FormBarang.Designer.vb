<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBarang
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
        Me.ButtonTambah = New System.Windows.Forms.Button()
        Me.DataGridViewItem = New System.Windows.Forms.DataGridView()
        Me.ButtonEdit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxurutan = New System.Windows.Forms.TextBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.TextBoxketerangan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxHargakry = New System.Windows.Forms.TextBox()
        Me.TextBoxHarga1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxItem = New System.Windows.Forms.TextBox()
        Me.Buttonsimpan = New System.Windows.Forms.Button()
        Me.Buttonkembali = New System.Windows.Forms.Button()
        Me.Labeleditenabled = New System.Windows.Forms.Label()
        CType(Me.DataGridViewItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonTambah
        '
        Me.ButtonTambah.Location = New System.Drawing.Point(784, 48)
        Me.ButtonTambah.Name = "ButtonTambah"
        Me.ButtonTambah.Size = New System.Drawing.Size(88, 30)
        Me.ButtonTambah.TabIndex = 0
        Me.ButtonTambah.Text = "Tambah"
        Me.ButtonTambah.UseVisualStyleBackColor = True
        '
        'DataGridViewItem
        '
        Me.DataGridViewItem.AllowUserToAddRows = False
        Me.DataGridViewItem.AllowUserToDeleteRows = False
        Me.DataGridViewItem.AllowUserToResizeColumns = False
        Me.DataGridViewItem.AllowUserToResizeRows = False
        Me.DataGridViewItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewItem.Location = New System.Drawing.Point(12, 12)
        Me.DataGridViewItem.Name = "DataGridViewItem"
        Me.DataGridViewItem.ReadOnly = True
        Me.DataGridViewItem.RowHeadersVisible = False
        Me.DataGridViewItem.RowHeadersWidth = 51
        Me.DataGridViewItem.RowTemplate.Height = 24
        Me.DataGridViewItem.Size = New System.Drawing.Size(744, 570)
        Me.DataGridViewItem.TabIndex = 1
        '
        'ButtonEdit
        '
        Me.ButtonEdit.Location = New System.Drawing.Point(784, 84)
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(88, 30)
        Me.ButtonEdit.TabIndex = 2
        Me.ButtonEdit.Text = "Edit"
        Me.ButtonEdit.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TextBoxurutan)
        Me.Panel1.Controls.Add(Me.ButtonCancel)
        Me.Panel1.Controls.Add(Me.TextBoxketerangan)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBoxHargakry)
        Me.Panel1.Controls.Add(Me.TextBoxHarga1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextBoxItem)
        Me.Panel1.Controls.Add(Me.Buttonsimpan)
        Me.Panel1.Location = New System.Drawing.Point(762, 199)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(249, 251)
        Me.Panel1.TabIndex = 3
        Me.Panel1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Urutan list:"
        '
        'TextBoxurutan
        '
        Me.TextBoxurutan.Location = New System.Drawing.Point(89, 147)
        Me.TextBoxurutan.Name = "TextBoxurutan"
        Me.TextBoxurutan.Size = New System.Drawing.Size(141, 22)
        Me.TextBoxurutan.TabIndex = 10
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(142, 193)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(88, 30)
        Me.ButtonCancel.TabIndex = 4
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'TextBoxketerangan
        '
        Me.TextBoxketerangan.Location = New System.Drawing.Point(9, 119)
        Me.TextBoxketerangan.Name = "TextBoxketerangan"
        Me.TextBoxketerangan.Size = New System.Drawing.Size(221, 22)
        Me.TextBoxketerangan.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Keterangan:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "HargaKry:"
        '
        'TextBoxHargakry
        '
        Me.TextBoxHargakry.Location = New System.Drawing.Point(89, 72)
        Me.TextBoxHargakry.Name = "TextBoxHargakry"
        Me.TextBoxHargakry.Size = New System.Drawing.Size(141, 22)
        Me.TextBoxHargakry.TabIndex = 6
        '
        'TextBoxHarga1
        '
        Me.TextBoxHarga1.Location = New System.Drawing.Point(89, 44)
        Me.TextBoxHarga1.Name = "TextBoxHarga1"
        Me.TextBoxHarga1.Size = New System.Drawing.Size(141, 22)
        Me.TextBoxHarga1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Harga1:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Item:"
        '
        'TextBoxItem
        '
        Me.TextBoxItem.Location = New System.Drawing.Point(47, 16)
        Me.TextBoxItem.Name = "TextBoxItem"
        Me.TextBoxItem.Size = New System.Drawing.Size(183, 22)
        Me.TextBoxItem.TabIndex = 2
        '
        'Buttonsimpan
        '
        Me.Buttonsimpan.Location = New System.Drawing.Point(9, 193)
        Me.Buttonsimpan.Name = "Buttonsimpan"
        Me.Buttonsimpan.Size = New System.Drawing.Size(88, 30)
        Me.Buttonsimpan.TabIndex = 1
        Me.Buttonsimpan.Text = "Simpan"
        Me.Buttonsimpan.UseVisualStyleBackColor = True
        '
        'Buttonkembali
        '
        Me.Buttonkembali.Location = New System.Drawing.Point(784, 120)
        Me.Buttonkembali.Name = "Buttonkembali"
        Me.Buttonkembali.Size = New System.Drawing.Size(88, 30)
        Me.Buttonkembali.TabIndex = 4
        Me.Buttonkembali.Text = "Kembali"
        Me.Buttonkembali.UseVisualStyleBackColor = True
        '
        'Labeleditenabled
        '
        Me.Labeleditenabled.AutoSize = True
        Me.Labeleditenabled.Location = New System.Drawing.Point(889, 91)
        Me.Labeleditenabled.Name = "Labeleditenabled"
        Me.Labeleditenabled.Size = New System.Drawing.Size(84, 16)
        Me.Labeleditenabled.TabIndex = 5
        Me.Labeleditenabled.Text = "Edit Enabled"
        Me.Labeleditenabled.Visible = False
        '
        'FormBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 594)
        Me.ControlBox = False
        Me.Controls.Add(Me.Labeleditenabled)
        Me.Controls.Add(Me.Buttonkembali)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonEdit)
        Me.Controls.Add(Me.DataGridViewItem)
        Me.Controls.Add(Me.ButtonTambah)
        Me.Name = "FormBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Barang"
        CType(Me.DataGridViewItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonTambah As Button
    Friend WithEvents DataGridViewItem As DataGridView
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBoxketerangan As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxHargakry As TextBox
    Friend WithEvents TextBoxHarga1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxItem As TextBox
    Friend WithEvents Buttonsimpan As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents Buttonkembali As Button
    Friend WithEvents Labeleditenabled As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxurutan As TextBox
End Class
