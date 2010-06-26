Imports DexterLib
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.IO

Public Class MovieFrameExtractor

  Public Shared Function GetBitmap(ByVal position As Double, ByVal movieFileName As String, ByVal width As Integer, ByVal height As Integer) As Bitmap

    Dim det As New DexterLib.MediaDetClass()
    det.Filename = movieFileName
    det.CurrentStream = 0
    Dim len As Double = det.StreamLength
    If position > len Then
      Return Nothing
    End If

    Dim myTempFile As String = System.IO.Path.GetTempFileName
    det.WriteBitmapBits(position, width, height, myTempFile)
    Dim myBMP As Bitmap
    Using lStream As New FileStream(myTempFile, FileMode.Open, FileAccess.Read)
      myBMP = Image.FromStream(lStream)
    End Using
    System.IO.File.Delete(myTempFile)
    Return myBMP

  End Function

End Class
