Public Class LibraryMainForm


    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        AddBooks.Show()

        Me.Hide()

    End Sub



    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        GroupID.Show()
        Me.Hide()
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        BookDetail.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        AddBorrower.Show()
        Me.Hide()
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        BorrowerDetail.Show()
        Me.Hide()
    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        ReturnBook.Show()
        Me.Hide()
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        IssueBook.Show()
        Me.Hide()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        Try
            If MessageBox.Show("Are you sure you want to Log out?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                If Windows.Forms.DialogResult.Yes Then

                    MessageBox.Show("Thank You!", "", MessageBoxButtons.OK)
                    MainForm.Show()
                    Me.Close()

                End If
            End If

        Catch

        End Try
    End Sub

    Private Sub MetroButton10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroButton8_Click(sender As Object, e As EventArgs)
        AllBorrowed.Show()
        Me.Hide()


    End Sub

    Private Sub MetroButton10_Click_1(sender As Object, e As EventArgs) Handles MetroButton10.Click
        Archive.Show()
        Me.Hide()

    End Sub

    Private Sub MetroButton8_Click_1(sender As Object, e As EventArgs) Handles MetroButton8.Click
        LogBook.Show()
        Me.Hide()

    End Sub
End Class
