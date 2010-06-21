<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportToAVI
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportToAVI))
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Button2 = New System.Windows.Forms.Button
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.TextBox2 = New System.Windows.Forms.TextBox
    Me.SuspendLayout()
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(13, 13)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(232, 20)
    Me.TextBox1.TabIndex = 0
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(251, 11)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Browse..."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 45)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(57, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Frame rate"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(147, 45)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(60, 13)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "per second"
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(251, 40)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(75, 23)
    Me.Button2.TabIndex = 5
    Me.Button2.Text = "Create AVI"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(13, 68)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(313, 23)
    Me.ProgressBar1.TabIndex = 7
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(74, 42)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(67, 20)
    Me.TextBox2.TabIndex = 8
    Me.TextBox2.Text = "10"
    '
    'ExportToAVI
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(333, 98)
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.ProgressBar1)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.TextBox1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "ExportToAVI"
    Me.Text = "ExportToAVI"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
