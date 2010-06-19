Imports System.IO
Public Class Unzip

  Public Shared Function UnzipMP3GFiles(ByVal zipFilename As String, ByVal outputPath As String) As String
    UnzipMP3GFiles = ""
    Try
      Dim myZip As New ICSharpCode.SharpZipLib.Zip.FastZip
      myZip.ExtractZip(zipFilename, outputPath, "")
      Dim myDirInfo As New DirectoryInfo(outputPath)
      Dim myFileInfo() As FileInfo = myDirInfo.GetFiles("*.cdg", SearchOption.AllDirectories)
      If myFileInfo.Length > 0 Then
        UnzipMP3GFiles = myFileInfo(0).FullName
      End If
    Catch ex As Exception
    End Try
  End Function

End Class
