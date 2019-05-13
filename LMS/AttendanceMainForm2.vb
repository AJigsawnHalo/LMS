Public Class AttendanceMainForm2

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        MainForm.Show()
        Me.Close()

    End Sub

    Dim CaptureAction As String
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        AttendanceMainForm.Show()
        Me.Hide()
        AttendanceMainForm.MetroTextBox3.Text = "Login"
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        AttendanceMainForm.Show()
        Me.Hide()
        AttendanceMainForm.MetroTextBox3.Text = "Logout"


    End Sub

    Private Sub AttendanceMainForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class