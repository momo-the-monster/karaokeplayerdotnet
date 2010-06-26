Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Imports CDGNet

Public Class Form1

#Region "Private Declarations"

  Private mCDGFile As CDGFile
  Private mCDGStream As CdgFileIoStream
  Private mCDGFileName As String
  Private mMP3FileName As String
  Private mTempDir As String
  Private WithEvents mExportAVI As ExportAVI

#End Region

#Region "Control Events"

  Private Sub btOutputAVI_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOutputAVI.Click
    SelectOutputAVI()
  End Sub

  Private Sub btBackGroundBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBackGroundBrowse.Click
    SelectBackGroundAVI()
  End Sub

  Private Sub btConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConvert.Click
    ConvertAVI()
  End Sub

  Private Sub tbFPS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbFPS.KeyPress
    If (Asc(e.KeyChar) >= Keys.D0 And Asc(e.KeyChar) <= Keys.D9) _
    Or Asc(e.KeyChar) = Keys.Back Or e.KeyChar = "." Then
      e.Handled = False
    Else
      e.Handled = True
    End If
  End Sub

  Private Sub btBrowseCDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowseCDG.Click
    OpenFileDialog1.Filter = "CDG or Zip Files (*.zip, *.cdg)|*.zip;*.cdg"
    OpenFileDialog1.ShowDialog()
    tbFileName.Text = OpenFileDialog1.FileName
  End Sub

  Private Sub chkBackGraph_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackGraph.CheckedChanged
    If chkBackGround.Checked AndAlso chkBackGraph.Checked Then
      chkBackGround.Checked = False
    End If
    ToggleCheckBox()
  End Sub

  Private Sub chkBackGround_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackGround.CheckedChanged
    If chkBackGraph.Checked AndAlso chkBackGround.Checked Then
      chkBackGraph.Checked = False
    End If
    ToggleCheckBox()
  End Sub

  Private Sub btBrowseImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowseImg.Click
    SelectBackGroundGraphic()
  End Sub

#End Region

#Region "Events"

  Private Sub mExportAVI_Status(ByVal message As String) Handles mExportAVI.Status
    pbAVI.Value = (CInt(message))
  End Sub

#End Region

#Region "Private Methods"

  Private Sub SelectOutputAVI()
    SaveFileDialog1.Filter = "AVI Files (*.avi)|*.avi"
    SaveFileDialog1.ShowDialog()
    tbAVIFile.Text = SaveFileDialog1.FileName
  End Sub

  Private Sub SelectBackGroundAVI()
    OpenFileDialog1.Filter = "Movie Files (*.avi, *.mpg, *.wmv)|*.avi;*.mpg;*.wmv"
    OpenFileDialog1.ShowDialog()
    tbBackGroundAVI.Text = OpenFileDialog1.FileName
  End Sub

  Private Sub SelectBackGroundGraphic()
    OpenFileDialog1.Filter = "Graphic Files|*.jpg;*.bmp;*.png;*.tif;*.tiff;*.gif;*.wmf"
    OpenFileDialog1.ShowDialog()
    tbBackGroundImg.Text = OpenFileDialog1.FileName
  End Sub

  Private Sub ConvertAVI()
    Try
      PreProcessFiles()
      If mCDGFileName = "" Or mMP3FileName = "" Then
        MsgBox("Cannot find a CDG and MP3 file to convert together.")
        Exit Sub
      End If
    Catch ex As Exception
      'Do nothing for now
    End Try
    mExportAVI = New ExportAVI
    pbAVI.Value = 0
    Dim backGroundFilename As String = ""
    If chkBackGraph.Checked Then backGroundFilename = tbBackGroundImg.Text
    If chkBackGround.Checked Then backGroundFilename = tbBackGroundAVI.Text
    mExportAVI.CDGtoAVI(tbAVIFile.Text, mCDGFileName, mMP3FileName, tbFPS.Text, backGroundFilename)
    pbAVI.Value = 0
    Try
      CleanUp()
    Catch ex As Exception
      'Do nothing for now
    End Try
  End Sub

  Private Sub CleanUp()
    If mTempDir <> "" Then
      Try
        Directory.Delete(mTempDir, True)
      Catch ex As Exception
      End Try
    End If
    mTempDir = ""
  End Sub

  Private Sub PreProcessFiles()
    Dim myCDGFileName As String = ""
    If Regex.IsMatch(tbFileName.Text, "\.zip$") Then
      Dim myTempDir As String = Path.GetTempPath & Path.GetRandomFileName
      Directory.CreateDirectory(myTempDir)
      mTempDir = myTempDir
      myCDGFileName = Unzip.UnzipMP3GFiles(tbFileName.Text, myTempDir)
      GoTo PairUpFiles
    ElseIf Regex.IsMatch(tbFileName.Text, "\.cdg$") Then
      myCDGFileName = tbFileName.Text
PairUpFiles:
      Dim myMP3FileName As String = RegularExpressions.Regex.Replace(myCDGFileName, "\.cdg$", ".mp3")
      If File.Exists(myMP3FileName) Then
        mMP3FileName = myMP3FileName
        mCDGFileName = myCDGFileName
        mTempDir = ""
      End If
    End If
  End Sub


  Private Sub ToggleCheckBox()
    tbBackGroundAVI.Enabled = chkBackGround.Checked
    btBackGroundBrowse.Enabled = chkBackGround.Checked
    tbBackGroundImg.Enabled = chkBackGraph.Checked
    btBrowseImg.Enabled = chkBackGraph.Checked
  End Sub

#End Region

End Class
