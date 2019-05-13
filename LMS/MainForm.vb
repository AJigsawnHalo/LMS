Public Class MainForm

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        LoginForm.Show()
        'Me.Hide()
        LoginForm.UserNameTextBox2M.Focus()

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        AttendanceMainForm.Show()


        'Me.Hide()
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        SearchMainForm.Show()
        Me.Hide()
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class