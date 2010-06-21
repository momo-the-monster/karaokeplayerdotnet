Imports AviFile
Imports Un4seen.Bass
Imports System.IO
Imports System.Text.RegularExpressions

Public Class ExportAVI

  Public Sub CDGtoAVI(ByVal aviFileName As String, ByVal cdgFileName As String, ByVal mp3FileName As String, ByVal frameRate As Double)
    Dim myCDGFile As New CDGFile(cdgFileName)
    myCDGFile.renderAtPosition(0)
    Dim bitmap__1 As Bitmap = DirectCast(myCDGFile.RGBImage, Bitmap)
    Dim aviManager As New AviManager(aviFileName, False)
    Dim aviStream As VideoStream = aviManager.AddVideoStream(True, frameRate, bitmap__1)
    Dim count As Integer = 0
    Dim frameInterval As Double = 1000 / frameRate
    Dim totalDuration As Long = myCDGFile.getTotalDuration
    Dim position As Double = 0
    While position <= totalDuration
      count += 1
      position = count * frameInterval
      myCDGFile.renderAtPosition(CLng(position))
      bitmap__1 = DirectCast(myCDGFile.RGBImage, Bitmap)
      aviStream.AddFrame(bitmap__1)
      bitmap__1.Dispose()
      Dim percentageDone As Integer = (position / totalDuration) * 100
      RaiseEvent Status(percentageDone.ToString)
      Application.DoEvents()
    End While
    myCDGFile.Dispose()
    aviManager.Close()
    AddMP3toAVI(aviFileName, mp3FileName)
  End Sub

  Public Shared Sub AddMP3toAVI(ByVal aviFileName As String, ByVal mp3FileName As String)
    Dim newAVIFileName As String = Regex.Replace(aviFileName, "\.avi$", "MUX.avi", RegexOptions.IgnoreCase)
    Dim cmdLineArgs As String = "-ovc copy -oac copy -audiofile """ & mp3FileName & """ -o """ & newAVIFileName & """ """ & aviFileName & """"
    Using myProcess As New Process()
      Dim myCMD As String = """" & System.AppDomain.CurrentDomain.BaseDirectory() & "mencoder.exe """ & cmdLineArgs
      myProcess.StartInfo.FileName = """" & System.AppDomain.CurrentDomain.BaseDirectory() & "mencoder.exe"""
      myProcess.StartInfo.Arguments = cmdLineArgs
      myProcess.StartInfo.UseShellExecute = False
      myProcess.StartInfo.CreateNoWindow = True
      myProcess.Start()
      myProcess.PriorityClass = ProcessPriorityClass.Normal
      myProcess.WaitForExit()
    End Using
    If File.Exists(newAVIFileName) Then
      File.Delete(aviFileName)
      File.Move(newAVIFileName, aviFileName)
    End If
  End Sub

  Public Shared Function OutputToWave(ByVal mp3FileName As String) As String
    OutputToWave = ""
    Dim myWavFileName As String = ""
    myWavFileName = mp3FileName & ".wav"
    Try
      If Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Form1.Handle) Then
        Dim stream As Integer = Bass.BASS_StreamCreateFile(mp3FileName, 0, 0, BASSFlag.BASS_STREAM_DECODE)
        Dim ww As New Misc.WaveWriter(myWavFileName, stream, True)
        Dim data(65535) As Byte
        While Bass.BASS_ChannelIsActive(stream) = BASSActive.BASS_ACTIVE_PLAYING
          Dim length As Integer = Bass.BASS_ChannelGetData(stream, data, data.Length)
          If length > 0 Then
            ww.WriteNoConvert(data, length)
          End If
        End While
        Dim newWaveName As String = Regex.Replace(myWavFileName, "\.wav$", "PCM.wav", RegexOptions.IgnoreCase)
        File.Copy(myWavFileName, newWaveName)
        ww.Dispose()
        Bass.BASS_StreamFree(stream)
        OutputToWave = newWaveName
      End If
    Catch ex As Exception
    End Try
  End Function

  Public Event Status(ByVal message As String)


End Class
