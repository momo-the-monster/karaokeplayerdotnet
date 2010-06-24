Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Imports Un4seen.Bass

Public Class Form1

  Private mCDGFile As CDGFile
  Private mCDGStream As CdgFileIoStream
  Private mSemitones As Integer = 0
  Private mPaused As Boolean
  Private mFrameCount As Long = 0
  Private mStop As Boolean
  Private mCDGFileName As String
  Private mMP3FileName As String
  Private mTempDir As String
  Private mMP3Stream As Integer
  Private WithEvents mCDGWindow As New CDGWindow

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowse.Click
    OpenFileDialog1.Filter = "CDG or Zip Files (*.zip, *.cdg)|*.zip;*.cdg"
    OpenFileDialog1.ShowDialog()
    tbFileName.Text = OpenFileDialog1.FileName
  End Sub

  Private Sub PlayMP3Bass(ByVal mp3FileName As String)
    If Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Me.Handle) Then
      mMP3Stream = 0
      mMP3Stream = Bass.BASS_StreamCreateFile(mp3FileName, 0, 0, BASSFlag.BASS_STREAM_DECODE Or BASSFlag.BASS_SAMPLE_FLOAT Or BASSFlag.BASS_STREAM_PRESCAN)
      mMP3Stream = AddOn.Fx.BassFx.BASS_FX_TempoCreate(mMP3Stream, BASSFlag.BASS_FX_FREESOURCE Or BASSFlag.BASS_SAMPLE_FLOAT Or BASSFlag.BASS_SAMPLE_LOOP)
      If mMP3Stream <> 0 Then
        AdjustPitch()
        AdjustVolume()
        ShowCDGWindow()
        Bass.BASS_ChannelPlay(mMP3Stream, False)
      Else
        Throw New Exception(String.Format("Stream error: {0}", Bass.BASS_ErrorGetCode()))
      End If
    End If
  End Sub

  Private Sub StopPlaybackBass()
    Bass.BASS_Stop()
    Bass.BASS_StreamFree(mMP3Stream)
    Bass.BASS_Free()
    mMP3Stream = 0
  End Sub

  Private Sub StopPlayback()
    mStop = True
    'PictureBox1.Image = Nothing
    HideCDGWindow()
    StopPlaybackBass()
    mCDGFile.Dispose()
    CleanUp()
  End Sub

  Private Sub PausePlayback()
    Bass.BASS_Pause()
  End Sub

  Private Sub ResumePlayback()
    Bass.BASS_Pause()
  End Sub

  Private Sub ShowCDGWindow()
    mCDGWindow.Show()
  End Sub

  Private Sub HideCDGWindow()
    mCDGWindow.PictureBox1.Image = Nothing
    mCDGWindow.Hide()
  End Sub

  Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    StopPlayback()
  End Sub

  Private Sub tsbPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPlay.Click
    Try
      If mMP3Stream <> 0 AndAlso Bass.BASS_ChannelIsActive(mMP3Stream) = BASSActive.BASS_ACTIVE_PLAYING Then
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
      mCDGFile = New CDGFile(mCDGFileName)
      Dim cdgLength As Long = mCDGFile.getTotalDuration
      PlayMP3Bass(mMP3FileName)
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
        mCDGWindow.PictureBox1.Image = mCDGFile.RGBImage
        mCDGWindow.PictureBox1.Refresh()
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
    If mMP3Stream <> 0 Then
      If Bass.BASS_ChannelIsActive(mMP3Stream) <> BASSActive.BASS_ACTIVE_PLAYING Then
        Bass.BASS_ChannelPlay(mMP3Stream, False)
        tsbPause.Text = "Pause"
      Else
        Bass.BASS_ChannelPause(mMP3Stream)
        tsbPause.Text = "Resume"
      End If
    End If

  End Sub

  Private Sub OutputToWMA()
    Dim _encBuffer(65535) As Byte
    'create the encoder...
    Dim _encHandle As Integer = AddOn.Wma.BassWma.BASS_WMA_EncodeOpenFile(44100, 2, AddOn.Wma.BASSWMAEncode.BASS_WMA_ENCODE_DEFAULT, 192, mMP3FileName & ".wma")
    'create the stream
    Dim _stream As Integer = Bass.BASS_StreamCreateFile(mMP3FileName, 0, 0, BASSFlag.BASS_STREAM_DECODE)
    'encode the data
    While (Bass.BASS_ChannelIsActive(_stream) = BASSActive.BASS_ACTIVE_PLAYING)
      'get the decoded sample data
      Dim len As Integer = Bass.BASS_ChannelGetData(_stream, _encBuffer, 65536)
      'write the data to the encoder
      AddOn.Wma.BassWma.BASS_WMA_EncodeWrite(_encHandle, _encBuffer, len)
    End While
    'finish
    AddOn.Wma.BassWma.BASS_WMA_EncodeClose(_encHandle)
    Bass.BASS_StreamFree(_stream)
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
    mTempDir = ""
  End Sub

  Private Sub AdjustPitch()
    If mMP3Stream <> 0 Then
      Bass.BASS_ChannelSetAttribute(mMP3Stream, BASSAttribute.BASS_ATTRIB_TEMPO_PITCH, nudKey.Value)
    End If
  End Sub

  Private Sub AdjustVolume()
    If mMP3Stream <> 0 Then
      Bass.BASS_ChannelSetAttribute(mMP3Stream, BASSAttribute.BASS_ATTRIB_VOL, If(trbVolume.Value = 0, 0, (trbVolume.Value / 100)))
    End If
  End Sub

  Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbVolume.Scroll
    AdjustVolume()
  End Sub

  Private Sub nudKey_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudKey.ValueChanged
    AdjustPitch()
  End Sub

  Private Sub btAVI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAVI.Click
    Try
      StopPlayback()
    Catch ex As Exception
      'Do nothing for now
    End Try
    Try
      PreProcessFiles()
      If mCDGFileName = "" Or mMP3FileName = "" Then
        MsgBox("Cannot find a CDG and MP3 file to play together.")
        StopPlayback()
        Exit Sub
      End If
    Catch ex As Exception
      'Do nothing for now
    End Try
    Dim myExportAVI As New ExportToAVI(mCDGFileName, mMP3FileName)
    myExportAVI.ShowDialog()
    myExportAVI.Dispose()
    Try
      CleanUp()
    Catch ex As Exception
      'Do nothing for now
    End Try
  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Private Sub mCDGWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles mCDGWindow.FormClosing
    StopPlayback()
    mCDGWindow.Hide()
    e.Cancel = True
  End Sub

End Class
