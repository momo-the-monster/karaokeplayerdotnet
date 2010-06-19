Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO

Public Class Form1

  Private mCDGFile As CDGFile
  Private mCDGStream As CdgFileIoStream
  Private mSemitones As Integer = 0
  Private mPaused As Boolean
  Private mPlayer As New mPlayerControl
  Private mFrameCount As Long = 0
  Private mStop As Boolean
  Private mCDGFileName As String
  Private mMP3FileName As String
  Private mTempDir As String

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowse.Click
    OpenFileDialog1.Filter = "CDG or Zip Files (*.zip, *.cdg)|*.zip;*.cdg"
    OpenFileDialog1.ShowDialog()
    tbFileName.Text = OpenFileDialog1.FileName
  End Sub

  Private Sub PlayMP3(ByVal mp3FileName As String)
    mPlayer.Open(mp3FileName)
    mPlayer.Volume = trbVolume.Value
    mPlayer.Play()
  End Sub

  Private Sub StopPlayback()
    mStop = True
    PictureBox1.Image = Nothing
    mPlayer.Stop()
    mCDGFile.close()
    mCDGStream.close()
    CleanUp()
  End Sub

  Private Sub PausePlayback()
    mPlayer.Pause()
  End Sub

  Private Sub ResumePlayback()
    mPlayer.Resume()
  End Sub

  Private Sub AdjustPitch(ByVal semitones As Integer)
    'not implemeted yet
  End Sub

  Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    StopPlayback()
    mPlayer.Dispose()
    mCDGFile = Nothing
    mCDGStream = Nothing
  End Sub

  Private Sub tsbPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPlay.Click
    Try
      If mPlayer.Playing Then
        StopPlayback()
      End If
      PreProcessFiles()
      If mCDGFileName = "" Or mMP3FileName = "" Then
        MsgBox("Cannot find a CDG and MP3 file to play together.")
        StopPlayback()
        Exit Sub
      End If
      mPaused = False
      mStop = False
      mFrameCount = 0
      mCDGStream = New CdgFileIoStream
      mCDGStream.open(mCDGFileName)
      mCDGFile = New CDGFile
      Dim mySurface As New ISurface
      mCDGFile.open(mCDGStream, mySurface)
      Dim cdgLength As Long = mCDGFile.getTotalDuration
      PlayMP3(mMP3FileName)
      Dim startTime As DateTime = Now
      Dim endTime = startTime.AddMilliseconds(mCDGFile.getTotalDuration)
      Dim millisecondsRemaining As Long = cdgLength
      While millisecondsRemaining > 0
        If mStop Then
          Exit While
        End If
        millisecondsRemaining = endTime.Subtract(Now).TotalMilliseconds
        Dim pos As Long = cdgLength - millisecondsRemaining
        While mPaused
          endTime = Now.AddMilliseconds(millisecondsRemaining)
          Application.DoEvents()
        End While
        mCDGFile.renderAtPosition(pos)
        mFrameCount += 1
        PictureBox1.Image = mCDGFile.RGBImage
        PictureBox1.Refresh()
        Dim myFrameRate As Single = Math.Round(mFrameCount / (pos / 1000), 1)
        Application.DoEvents()
      End While
      StopPlayback()
    Catch ex As Exception
    End Try
  End Sub

  Private Sub tsbStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbStop.Click
    Try
      StopPlayback()
    Catch ex As Exception
      'Do nothing for now
    End Try
  End Sub

  Private Sub tsbPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPause.Click
    mPaused = Not mPaused
    If mPaused Then
      PausePlayback()
      tsbPause.Text = "Resume"
    Else
      ResumePlayback()
      tsbPause.Text = "Pause"
    End If
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

  Private Sub CleanUp()
    If mTempDir <> "" Then
      Try
        Directory.Delete(mTempDir, True)
      Catch ex As Exception
      End Try
    End If
  End Sub

  Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbVolume.Scroll
    mPlayer.Volume = trbVolume.Value
  End Sub
End Class
