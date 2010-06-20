<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.tbFileName = New System.Windows.Forms.TextBox
    Me.btBrowse = New System.Windows.Forms.Button
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Label2 = New System.Windows.Forms.Label
    Me.nudKey = New System.Windows.Forms.NumericUpDown
    Me.Label1 = New System.Windows.Forms.Label
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tsbPlay = New System.Windows.Forms.ToolStripButton
    Me.tsbStop = New System.Windows.Forms.ToolStripButton
    Me.tsbPause = New System.Windows.Forms.ToolStripButton
    Me.trbVolume = New System.Windows.Forms.TrackBar
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.Panel1.SuspendLayout()
    CType(Me.nudKey, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.trbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'tbFileName
    '
    Me.tbFileName.Location = New System.Drawing.Point(3, 5)
    Me.tbFileName.Name = "tbFileName"
    Me.tbFileName.ReadOnly = True
    Me.tbFileName.Size = New System.Drawing.Size(229, 20)
    Me.tbFileName.TabIndex = 0
    '
    'btBrowse
    '
    Me.btBrowse.Location = New System.Drawing.Point(247, 3)
    Me.btBrowse.Name = "btBrowse"
    Me.btBrowse.Size = New System.Drawing.Size(75, 23)
    Me.btBrowse.TabIndex = 1
    Me.btBrowse.Text = "Browse..."
    Me.btBrowse.UseVisualStyleBackColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'Timer1
    '
    Me.Timer1.Interval = 50
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.nudKey)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.ToolStrip1)
    Me.Panel1.Controls.Add(Me.tbFileName)
    Me.Panel1.Controls.Add(Me.btBrowse)
    Me.Panel1.Controls.Add(Me.trbVolume)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(331, 105)
    Me.Panel1.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(241, 37)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(25, 13)
    Me.Label2.TabIndex = 9
    Me.Label2.Text = "Key"
    '
    'nudKey
    '
    Me.nudKey.Location = New System.Drawing.Point(272, 35)
    Me.nudKey.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
    Me.nudKey.Minimum = New Decimal(New Integer() {12, 0, 0, -2147483648})
    Me.nudKey.Name = "nudKey"
    Me.nudKey.Size = New System.Drawing.Size(50, 20)
    Me.nudKey.TabIndex = 8
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(90, 35)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 13)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "Volume"
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbPlay, Me.tsbStop, Me.tsbPause})
    Me.ToolStrip1.Location = New System.Drawing.Point(3, 29)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(81, 25)
    Me.ToolStrip1.TabIndex = 2
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tsbPlay
    '
    Me.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsbPlay.Image = CType(resources.GetObject("tsbPlay.Image"), System.Drawing.Image)
    Me.tsbPlay.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsbPlay.Name = "tsbPlay"
    Me.tsbPlay.Size = New System.Drawing.Size(23, 22)
    Me.tsbPlay.Text = "Play"
    '
    'tsbStop
    '
    Me.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsbStop.Image = CType(resources.GetObject("tsbStop.Image"), System.Drawing.Image)
    Me.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsbStop.Name = "tsbStop"
    Me.tsbStop.Size = New System.Drawing.Size(23, 22)
    Me.tsbStop.Text = "Stop"
    '
    'tsbPause
    '
    Me.tsbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.tsbPause.Image = CType(resources.GetObject("tsbPause.Image"), System.Drawing.Image)
    Me.tsbPause.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsbPause.Name = "tsbPause"
    Me.tsbPause.Size = New System.Drawing.Size(23, 22)
    Me.tsbPause.Text = "Pause"
    '
    'trbVolume
    '
    Me.trbVolume.Location = New System.Drawing.Point(131, 34)
    Me.trbVolume.Maximum = 100
    Me.trbVolume.Name = "trbVolume"
    Me.trbVolume.Size = New System.Drawing.Size(101, 45)
    Me.trbVolume.TabIndex = 6
    Me.trbVolume.TickFrequency = 5
    Me.trbVolume.TickStyle = System.Windows.Forms.TickStyle.None
    Me.trbVolume.Value = 100
    '
    'Panel2
    '
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(0, 105)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(331, 0)
    Me.Panel2.TabIndex = 4
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(331, 61)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "Form1"
    Me.Text = "MP3+CDG Player"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.nudKey, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    CType(Me.trbVolume, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tbFileName As System.Windows.Forms.TextBox
  Friend WithEvents btBrowse As System.Windows.Forms.Button
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tsbPlay As System.Windows.Forms.ToolStripButton
  Friend WithEvents tsbStop As System.Windows.Forms.ToolStripButton
  Friend WithEvents tsbPause As System.Windows.Forms.ToolStripButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents trbVolume As System.Windows.Forms.TrackBar
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents nudKey As System.Windows.Forms.NumericUpDown

End Class
