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
End Class