<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Penyesuaiansaldo
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
        Me.Buttonpenyesuaian = New System.Windows.Forms.Button()
        Me.Buttonkembali = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(223, 26)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(230, 22)
        Me.DateTimePicker1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Penyesuaian saldo dari tgl :"
        '
        'Buttonpenyesuaian
        '
        Me.Buttonpenyesuaian.Location = New System.Drawing.Point(95, 92)
        Me.Buttonpenyesuaian.Name = "Buttonpenyesuaian"
        Me.Buttonpenyesuaian.Size = New System.Drawing.Size(145, 30)
        Me.Buttonpenyesuaian.TabIndex = 2
        Me.Buttonpenyesuaian.Text = "Penyesuaian"
        Me.Buttonpenyesuaian.UseVisualStyleBackColor = True
        '
        'Buttonkembali
        '
        Me.Buttonkembali.Location = New System.Drawing.Point(326, 92)
        Me.Buttonkembali.Name = "Buttonkembali"
        Me.Buttonkembali.Size = New System.Drawing.Size(145, 30)
        Me.Buttonkembali.TabIndex = 3
        Me.Buttonkembali.Text = "Kembali"
        Me.Buttonkembali.UseVisualStyleBackColor = True
        '
        'Penyesuaiansaldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.Buttonkembali)
        Me.Controls.Add(Me.Buttonpenyesuaian)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "Penyesuaiansaldo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penyesuaian saldo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Buttonpenyesuaian As Button
    Friend WithEvents Buttonkembali As Button
End Class
