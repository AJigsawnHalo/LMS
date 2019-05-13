Public Class LoginForm2


    Private Sub BtnClearM_Click(sender As Object, e As EventArgs) Handles BtnClearM.Click

        UserNameTextBox2M.Text = ""
        PassWordTextBox2M.Text = ""
        UserNameTextBox2M.Focus()
        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub BtnLogin2M_Click(sender As Object, e As EventArgs) Handles BtnLogin2M.Click
        Dim PassWord2 As String

        Dim UserName2 As String

        Try


            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT  UserName, PassWord FROM Login WHERE (UserName = '" & UserNameTextBox2M.Text & "' ) AND (PassWord = '" & PassWordTextBox2M.Text & "')", objcon)
            dr = com.ExecuteReader
            If dr.HasRows Then
                While dr.Read()

                    'Do something here
                    PassWord2 = dr("PassWord").ToString()
                    UserName2 = dr("UserName").ToString()


                    If PassWord2 = PassWordTextBox2M.Text And UserName2 = UserNameTextBox2M.Text Then

                        MessageBox.Show("Logged out successfully as " & UserName2, "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        AttendanceMainForm.SerialPort2.Close()
                        AttendanceMainForm.Close()

                        PassWordTextBox2M.Text = ""
                        UserNameTextBox2M.Text = ""

                        'AttendanceMainForm.SerialPort2.Open()


                        MainForm.Show()
                        Me.Close()







                    Else


                    End If

                End While
            ElseIf PassWordTextBox2M.Text = "" And UserNameTextBox2M.Text = "" Then
                MessageBox.Show("Please input details", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            Else
                MessageBox.Show("Incorrect Username and Password", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                PassWordTextBox2M.Text = ""
                UserNameTextBox2M.Text = ""
            End If


        Catch ex As Exception
            'MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        Finally
            objcon.Close() 'Whether there is error or not. Close the connection.

        End Try


    End Sub











    Private Sub UserNameTextBox2M_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles UserNameTextBox2M.KeyPress

        'Dim startPos As Integer
        'Dim selectionLenght As Integer

        'startPos = UserNameTextBox2M.SelectionStart
        'selectionLenght = UserNameTextBox2M.SelectionLength



        'If UserNameTextBox2M.Text.Length > 1 Then

        '    UserNameTextBox2M.Text = UserNameTextBox2M.Text.Substring(0, 1).ToUpper + UserNameTextBox2M.Text.Substring(1).ToLower()
        'ElseIf UserNameTextBox2M.Text.Length Then

        '    UserNameTextBox2M.Text = UserNameTextBox2M.Text.ToUpper()

        'End If


        'UserNameTextBox2M.SelectionStart = startPos
        'UserNameTextBox2M.SelectionLength = selectionLenght




    End Sub


End Class

