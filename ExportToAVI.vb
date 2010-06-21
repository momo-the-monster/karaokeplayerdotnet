Public Class ExportToAVI

  Private mCDGFileName As String
  Private mMP3FileName As String
  Private WithEvents mExportAVI As ExportAVI

  Public Sub New(ByVal cdgFileName As String, ByVal mp3FileName As String)

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    mCDGFileName = cdgFileName
    mMP3FileName = mp3FileName
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    SaveFileDialog1.Filter = "AVI Files (*.avi)|*.avi"
    SaveFileDialog1.ShowDialog()
    TextBox1.Text = SaveFileDialog1.FileName
  End Sub

  Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
    If (Asc(e.KeyChar) >= Keys.D0 And Asc(e.KeyChar) <= Keys.D9) _
    Or Asc(e.KeyChar) = Keys.Back Or e.KeyChar = "." Then
      e.Handled = False
    Else
      e.Handled = True
    End If
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    mExportAVI = New ExportAVI
    ProgressBar1.Value = 0
    mExportAVI.CDGtoAVI(TextBox1.Text, mCDGFileName, mMP3FileName, TextBox2.Text)
    Me.Close()
  End Sub

  Private Sub mExportAVI_Status(ByVal message As String) Handles mExportAVI.Status
    ProgressBar1.Value = (CInt(message))
  End Sub


End Class