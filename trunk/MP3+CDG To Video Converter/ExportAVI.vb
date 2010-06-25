Imports AviFile
Imports System.IO
Imports System.Text.RegularExpressions
Imports CDGNet

Public Class ExportAVI

  Public Sub CDGtoAVI(ByVal aviFileName As String, ByVal cdgFileName As String, ByVal mp3FileName As String, ByVal frameRate As Double, Optional ByVal backgroundAVIFileName As String = "")
    'Dim aviManagerBackground As AviManager
    'Dim backgroundVideoStream As AviFile.VideoStream
    'Dim backgroundBmp As Bitmap
    'Dim mergedBMP As Bitmap
    Dim aviStream As VideoStream
    Dim myCDGFile As New CDGFile(cdgFileName)
    myCDGFile.renderAtPosition(0)
    Dim bitmap__1 As Bitmap = DirectCast(myCDGFile.RGBImage, Bitmap)
    'If backgroundAVIFileName <> "" Then
    '  Try
    '    aviManagerBackground = New AviManager(backgroundAVIFileName, False)
    '    backgroundVideoStream = aviManagerBackground.GetVideoStream()
    '    backgroundBmp = GetFrameAtPosition(backgroundVideoStream, 0)
    '  Catch ex As Exception
    '  End Try
    'End If
    Dim aviManager As New AviManager(aviFileName, False)
    'If backgroundBmp IsNot Nothing Then
    '  mergedBMP = GraphicUtil.MergeImagesWithTransparency(backgroundBmp, bitmap__1)
    '  aviStream = aviManager.AddVideoStream(True, frameRate, mergedBMP)
    '  mergedBMP.Dispose()
    '  backgroundBmp.Dispose()
    'Else
    aviStream = aviManager.AddVideoStream(True, frameRate, bitmap__1)
    'End If

    Dim count As Integer = 0
    Dim frameInterval As Double = 1000 / frameRate
    Dim totalDuration As Long = myCDGFile.getTotalDuration
    Dim position As Double = 0
    While position <= totalDuration
      count += 1
      position = count * frameInterval
      myCDGFile.renderAtPosition(CLng(position))
      bitmap__1 = DirectCast(myCDGFile.RGBImage, Bitmap)
      'If backgroundVideoStream IsNot Nothing Then
      '  backgroundBmp = GetFrameAtPosition(backgroundVideoStream, CLng(position))
      '  mergedBMP = GraphicUtil.MergeImagesWithTransparency(backgroundBmp, bitmap__1)
      '  aviStream.AddFrame(mergedBMP)
      '  mergedBMP.Dispose()
      '  backgroundBmp.Dispose()
      'Else
      aviStream.AddFrame(bitmap__1)
      'End If
      bitmap__1.Dispose()
      Dim percentageDone As Integer = (position / totalDuration) * 100
      RaiseEvent Status(percentageDone.ToString)
      Application.DoEvents()
    End While
    myCDGFile.Dispose()
    aviManager.Close()
    'If backgroundAVIFileName <> "" Then
    '  aviManagerBackground.Close()
    'End If
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



  Public Shared Function GetFrameAtPosition(ByRef videoStream As AviFile.VideoStream, ByVal ms As Long)
    Dim myFrameIndex As Integer = If(ms = 0, 0, CInt(videoStream.FrameRate * (ms / 1000)))
    videoStream.GetFrameOpen()
    Dim myBitmap As Bitmap = videoStream.GetBitmap(myFrameIndex)
    videoStream.GetFrameClose()
    Return GraphicUtil.ResizeBitmap(myBitmap, CDGFile.CDG_FULL_WIDTH, CDGFile.CDG_FULL_HEIGHT)
  End Function

  Public Event Status(ByVal message As String)


End Class
