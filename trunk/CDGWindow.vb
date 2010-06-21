Public Class CDGWindow

  Private Sub CDGWindow_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
    AutoSizeWindow()
  End Sub

  Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
    AutoSizeWindow()
  End Sub

  Private Sub AutoSizeWindow()
    If Me.WindowState = FormWindowState.Normal Then
      Me.WindowState = FormWindowState.Maximized
      Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
      Me.Refresh()
    Else
      Me.WindowState = FormWindowState.Normal
      Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
      Me.Refresh()
    End If
  End Sub

  Private Sub CDGWindow_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
    If Me.WindowState = FormWindowState.Maximized Then
      Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    Else
      Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
    End If
  End Sub
End Class