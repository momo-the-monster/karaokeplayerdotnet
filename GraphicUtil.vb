Imports System.IO
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class GraphicUtil

  'copy a stream of pixels
  Public Shared Function BitmapToStream(ByVal filename As String) As Stream
    Dim oldBmp As Bitmap = DirectCast(Image.FromFile(filename), Bitmap)
    Dim width As Integer = oldBmp.Width, height As Integer = oldBmp.Width
    Dim oldData As BitmapData = oldBmp.LockBits(New Rectangle(0, 0, oldBmp.Width, oldBmp.Height), ImageLockMode.[WriteOnly], PixelFormat.Format24bppRgb)
    Dim length As Integer = oldData.Stride * oldBmp.Height
    Dim stream As Byte() = New Byte(length - 1) {}
    Marshal.Copy(oldData.Scan0, stream, 0, length)
    oldBmp.UnlockBits(oldData)
    oldBmp.Dispose()
    Return New MemoryStream(stream)
  End Function


  Public Shared Function StreamToBitmap(ByRef stream As Stream, ByVal width As Integer, ByVal height As Integer) As Bitmap
    'create a new bitmap
    Dim bmp As New Bitmap(width, height, PixelFormat.Format32bppArgb)
    Dim bmpData As BitmapData = bmp.LockBits(New Rectangle(0, 0, width, height), ImageLockMode.[WriteOnly], bmp.PixelFormat)
    stream.Seek(0, SeekOrigin.Begin)
    'copy the stream of pixel
    For n As Integer = 0 To stream.Length - 1
      Dim myByte(0) As Byte
      stream.Read(myByte, 0, 1)
      Marshal.WriteByte(bmpData.Scan0, n, myByte(0))
    Next
    bmp.UnlockBits(bmpData)
    Return bmp
  End Function




End Class
