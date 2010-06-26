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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.tbFileName = New System.Windows.Forms.TextBox
    Me.btBrowseCDG = New System.Windows.Forms.Button
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.GroupBox3 = New System.Windows.Forms.GroupBox
    Me.tbAVIFile = New System.Windows.Forms.TextBox
    Me.btOutputAVI = New System.Windows.Forms.Button
    Me.tbFPS = New System.Windows.Forms.TextBox
    Me.lbFPS = New System.Windows.Forms.Label
    Me.btConvert = New System.Windows.Forms.Button
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.pbAVI = New System.Windows.Forms.ProgressBar
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
    Me.lbSaveAs = New System.Windows.Forms.Label
    Me.tbBackGroundAVI = New System.Windows.Forms.TextBox
    Me.btBackGroundBrowse = New System.Windows.Forms.Button
    Me.chkBackGround = New System.Windows.Forms.CheckBox
    Me.chkBackGraph = New System.Windows.Forms.CheckBox
    Me.tbBackGroundImg = New System.Windows.Forms.TextBox
    Me.btBrowseImg = New System.Windows.Forms.Button
    Me.Panel1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'tbFileName
    '
    Me.tbFileName.Location = New System.Drawing.Point(9, 13)
    Me.tbFileName.Name = "tbFileName"
    Me.tbFileName.ReadOnly = True
    Me.tbFileName.Size = New System.Drawing.Size(475, 20)
    Me.tbFileName.TabIndex = 0
    '
    'btBrowseCDG
    '
    Me.btBrowseCDG.Location = New System.Drawing.Point(490, 11)
    Me.btBrowseCDG.Name = "btBrowseCDG"
    Me.btBrowseCDG.Size = New System.Drawing.Size(68, 23)
    Me.btBrowseCDG.TabIndex = 1
    Me.btBrowseCDG.Text = "Browse..."
    Me.btBrowseCDG.UseVisualStyleBackColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.GroupBox3)
    Me.Panel1.Controls.Add(Me.GroupBox2)
    Me.Panel1.Controls.Add(Me.GroupBox1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(577, 255)
    Me.Panel1.TabIndex = 3
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.chkBackGraph)
    Me.GroupBox3.Controls.Add(Me.tbBackGroundImg)
    Me.GroupBox3.Controls.Add(Me.btBrowseImg)
    Me.GroupBox3.Controls.Add(Me.chkBackGround)
    Me.GroupBox3.Controls.Add(Me.tbBackGroundAVI)
    Me.GroupBox3.Controls.Add(Me.btBackGroundBrowse)
    Me.GroupBox3.Controls.Add(Me.lbSaveAs)
    Me.GroupBox3.Controls.Add(Me.tbAVIFile)
    Me.GroupBox3.Controls.Add(Me.btOutputAVI)
    Me.GroupBox3.Controls.Add(Me.tbFPS)
    Me.GroupBox3.Controls.Add(Me.lbFPS)
    Me.GroupBox3.Controls.Add(Me.btConvert)
    Me.GroupBox3.Location = New System.Drawing.Point(3, 53)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(571, 145)
    Me.GroupBox3.TabIndex = 18
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "AVI Settings"
    '
    'tbAVIFile
    '
    Me.tbAVIFile.Location = New System.Drawing.Point(128, 19)
    Me.tbAVIFile.Name = "tbAVIFile"
    Me.tbAVIFile.Size = New System.Drawing.Size(356, 20)
    Me.tbAVIFile.TabIndex = 9
    '
    'btOutputAVI
    '
    Me.btOutputAVI.Location = New System.Drawing.Point(490, 17)
    Me.btOutputAVI.Name = "btOutputAVI"
    Me.btOutputAVI.Size = New System.Drawing.Size(75, 23)
    Me.btOutputAVI.TabIndex = 10
    Me.btOutputAVI.Text = "Browse..."
    Me.btOutputAVI.UseVisualStyleBackColor = True
    '
    'tbFPS
    '
    Me.tbFPS.Location = New System.Drawing.Point(128, 108)
    Me.tbFPS.Name = "tbFPS"
    Me.tbFPS.Size = New System.Drawing.Size(67, 20)
    Me.tbFPS.TabIndex = 15
    Me.tbFPS.Text = "15"
    '
    'lbFPS
    '
    Me.lbFPS.AutoSize = True
    Me.lbFPS.Location = New System.Drawing.Point(201, 111)
    Me.lbFPS.Name = "lbFPS"
    Me.lbFPS.Size = New System.Drawing.Size(94, 13)
    Me.lbFPS.TabIndex = 12
    Me.lbFPS.Text = "frames per second"
    '
    'btConvert
    '
    Me.btConvert.Location = New System.Drawing.Point(490, 106)
    Me.btConvert.Name = "btConvert"
    Me.btConvert.Size = New System.Drawing.Size(75, 23)
    Me.btConvert.TabIndex = 13
    Me.btConvert.Text = "Create AVI"
    Me.btConvert.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.tbFileName)
    Me.GroupBox2.Controls.Add(Me.btBrowseCDG)
    Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(571, 40)
    Me.GroupBox2.TabIndex = 17
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "MP3 + CDG File"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.pbAVI)
    Me.GroupBox1.Location = New System.Drawing.Point(3, 204)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(571, 48)
    Me.GroupBox1.TabIndex = 16
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Progress"
    '
    'pbAVI
    '
    Me.pbAVI.Location = New System.Drawing.Point(7, 19)
    Me.pbAVI.Name = "pbAVI"
    Me.pbAVI.Size = New System.Drawing.Size(555, 23)
    Me.pbAVI.TabIndex = 14
    '
    'Panel2
    '
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(0, 255)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(577, 0)
    Me.Panel2.TabIndex = 4
    '
    'lbSaveAs
    '
    Me.lbSaveAs.AutoSize = True
    Me.lbSaveAs.Location = New System.Drawing.Point(76, 22)
    Me.lbSaveAs.Name = "lbSaveAs"
    Me.lbSaveAs.Size = New System.Drawing.Size(46, 13)
    Me.lbSaveAs.TabIndex = 16
    Me.lbSaveAs.Text = "Save as"
    '
    'tbBackGroundAVI
    '
    Me.tbBackGroundAVI.Enabled = False
    Me.tbBackGroundAVI.Location = New System.Drawing.Point(128, 49)
    Me.tbBackGroundAVI.Name = "tbBackGroundAVI"
    Me.tbBackGroundAVI.Size = New System.Drawing.Size(356, 20)
    Me.tbBackGroundAVI.TabIndex = 17
    '
    'btBackGroundBrowse
    '
    Me.btBackGroundBrowse.Enabled = False
    Me.btBackGroundBrowse.Location = New System.Drawing.Point(490, 47)
    Me.btBackGroundBrowse.Name = "btBackGroundBrowse"
    Me.btBackGroundBrowse.Size = New System.Drawing.Size(75, 23)
    Me.btBackGroundBrowse.TabIndex = 18
    Me.btBackGroundBrowse.Text = "Browse..."
    Me.btBackGroundBrowse.UseVisualStyleBackColor = True
    '
    'chkBackGround
    '
    Me.chkBackGround.AutoSize = True
    Me.chkBackGround.Location = New System.Drawing.Point(7, 51)
    Me.chkBackGround.Name = "chkBackGround"
    Me.chkBackGround.Size = New System.Drawing.Size(115, 17)
    Me.chkBackGround.TabIndex = 20
    Me.chkBackGround.Text = "Background movie"
    Me.chkBackGround.UseVisualStyleBackColor = True
    '
    'chkBackGraph
    '
    Me.chkBackGraph.AutoSize = True
    Me.chkBackGraph.Location = New System.Drawing.Point(7, 79)
    Me.chkBackGraph.Name = "chkBackGraph"
    Me.chkBackGraph.Size = New System.Drawing.Size(122, 17)
    Me.chkBackGraph.TabIndex = 23
    Me.chkBackGraph.Text = "Background graphic"
    Me.chkBackGraph.UseVisualStyleBackColor = True
    '
    'tbBackGroundImg
    '
    Me.tbBackGroundImg.Enabled = False
    Me.tbBackGroundImg.Location = New System.Drawing.Point(128, 77)
    Me.tbBackGroundImg.Name = "tbBackGroundImg"
    Me.tbBackGroundImg.Size = New System.Drawing.Size(356, 20)
    Me.tbBackGroundImg.TabIndex = 21
    '
    'btBrowseImg
    '
    Me.btBrowseImg.Enabled = False
    Me.btBrowseImg.Location = New System.Drawing.Point(490, 75)
    Me.btBrowseImg.Name = "btBrowseImg"
    Me.btBrowseImg.Size = New System.Drawing.Size(75, 23)
    Me.btBrowseImg.TabIndex = 22
    Me.btBrowseImg.Text = "Browse..."
    Me.btBrowseImg.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(577, 253)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "Form1"
    Me.Text = "MP3+CDG To Video Converter"
    Me.Panel1.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tbFileName As System.Windows.Forms.TextBox
  Friend WithEvents btBrowseCDG As System.Windows.Forms.Button
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents pbAVI As System.Windows.Forms.ProgressBar
  Friend WithEvents tbFPS As System.Windows.Forms.TextBox
  Friend WithEvents btConvert As System.Windows.Forms.Button
  Friend WithEvents lbFPS As System.Windows.Forms.Label
  Friend WithEvents btOutputAVI As System.Windows.Forms.Button
  Friend WithEvents tbAVIFile As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents tbBackGroundAVI As System.Windows.Forms.TextBox
  Friend WithEvents btBackGroundBrowse As System.Windows.Forms.Button
  Friend WithEvents lbSaveAs As System.Windows.Forms.Label
  Friend WithEvents chkBackGround As System.Windows.Forms.CheckBox
  Friend WithEvents chkBackGraph As System.Windows.Forms.CheckBox
  Friend WithEvents tbBackGroundImg As System.Windows.Forms.TextBox
  Friend WithEvents btBrowseImg As System.Windows.Forms.Button

End Class
