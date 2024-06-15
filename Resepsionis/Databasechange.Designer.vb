<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Databasechange
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
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxpassword = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonMasuk = New System.Windows.Forms.Button()
        Me.TextBoxdb = New System.Windows.Forms.TextBox()
        Me.TextBoxpass = New System.Windows.Forms.TextBox()
        Me.TextBoxuser = New System.Windows.Forms.TextBox()
        Me.TextBoxport = New System.Windows.Forms.TextBox()
        Me.TextBoxserver = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonKembali = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOk
        '
        Me.ButtonOk.Location = New System.Drawing.Point(363, 26)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(112, 30)
        Me.ButtonOk.TabIndex = 0
        Me.ButtonOk.Text = "OK"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Password:"
        '
        'TextBoxpassword
        '
        Me.TextBoxpassword.Location = New System.Drawing.Point(112, 30)
        Me.TextBoxpassword.Name = "TextBoxpassword"
        Me.TextBoxpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxpassword.Size = New System.Drawing.Size(208, 22)
        Me.TextBoxpassword.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonMasuk)
        Me.Panel1.Controls.Add(Me.TextBoxdb)
        Me.Panel1.Controls.Add(Me.TextBoxpass)
        Me.Panel1.Controls.Add(Me.TextBoxuser)
        Me.Panel1.Controls.Add(Me.TextBoxport)
        Me.Panel1.Controls.Add(Me.TextBoxserver)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(12, 77)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(636, 118)
        Me.Panel1.TabIndex = 3
        Me.Panel1.Visible = False
        '
        'ButtonMasuk
        '
        Me.ButtonMasuk.Location = New System.Drawing.Point(379, 78)
        Me.ButtonMasuk.Name = "ButtonMasuk"
        Me.ButtonMasuk.Size = New System.Drawing.Size(153, 30)
        Me.ButtonMasuk.TabIndex = 10
        Me.ButtonMasuk.Text = "Ganti Database"
        Me.ButtonMasuk.UseVisualStyleBackColor = True
        '
        'TextBoxdb
        '
        Me.TextBoxdb.Location = New System.Drawing.Point(397, 44)
        Me.TextBoxdb.Name = "TextBoxdb"
        Me.TextBoxdb.Size = New System.Drawing.Size(185, 22)
        Me.TextBoxdb.TabIndex = 9
        '
        'TextBoxpass
        '
        Me.TextBoxpass.Location = New System.Drawing.Point(397, 16)
        Me.TextBoxpass.Name = "TextBoxpass"
        Me.TextBoxpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxpass.Size = New System.Drawing.Size(185, 22)
        Me.TextBoxpass.TabIndex = 8
        '
        'TextBoxuser
        '
        Me.TextBoxuser.Location = New System.Drawing.Point(75, 72)
        Me.TextBoxuser.Name = "TextBoxuser"
        Me.TextBoxuser.Size = New System.Drawing.Size(185, 22)
        Me.TextBoxuser.TabIndex = 7
        '
        'TextBoxport
        '
        Me.TextBoxport.Location = New System.Drawing.Point(75, 44)
        Me.TextBoxport.Name = "TextBoxport"
        Me.TextBoxport.Size = New System.Drawing.Size(185, 22)
        Me.TextBoxport.TabIndex = 6
        '
        'TextBoxserver
        '
        Me.TextBoxserver.Location = New System.Drawing.Point(75, 16)
        Me.TextBoxserver.Name = "TextBoxserver"
        Me.TextBoxserver.Size = New System.Drawing.Size(185, 22)
        Me.TextBoxserver.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(323, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Database:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(323, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "User:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Server: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Port:"
        '
        'ButtonKembali
        '
        Me.ButtonKembali.Location = New System.Drawing.Point(507, 26)
        Me.ButtonKembali.Name = "ButtonKembali"
        Me.ButtonKembali.Size = New System.Drawing.Size(112, 30)
        Me.ButtonKembali.TabIndex = 4
        Me.ButtonKembali.Text = "Kembali"
        Me.ButtonKembali.UseVisualStyleBackColor = True
        '
        'Databasechange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonKembali)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBoxpassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonOk)
        Me.Name = "Databasechange"
        Me.Text = "Change Database"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonOk As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxpassword As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonKembali As Button
    Friend WithEvents TextBoxdb As TextBox
    Friend WithEvents TextBoxpass As TextBox
    Friend WithEvents TextBoxuser As TextBox
    Friend WithEvents TextBoxport As TextBox
    Friend WithEvents TextBoxserver As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonMasuk As Button
End Class
