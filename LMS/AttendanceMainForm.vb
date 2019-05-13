

Imports System
Imports System.IO.Ports

Public Class AttendanceMainForm
     Dim receivedData As String = ""

    Function ReceiveSerialData() As String
        receivedData = ""
        Dim Reader As String
        Try

            Reader = SerialPort2.ReadExisting()
            If Reader Is Nothing Then
                Return "Nothing" & vbCrLf
            Else
                Return Reader
            End If
        Catch ex As TimeoutException
            Return "Error"
        End Try

    End Function
    Function ArduinoConnect() As String


        For Each sp As String In My.Computer.Ports.SerialPortNames
            SerialPort2.Close()
            SerialPort2.PortName = sp
            SerialPort2.BaudRate = 9600
            SerialPort2.DataBits = 8
            SerialPort2.Parity = Parity.None
            SerialPort2.StopBits = StopBits.One
            SerialPort2.Handshake = Handshake.None
            SerialPort2.Encoding = System.Text.Encoding.Default 'very important!
            SerialPort2.ReadTimeout = 10000
            SerialPort2.Open()
            Timer2.Enabled = True
        Next
    End Function

    Private Sub AttendanceMainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    
        LoginForm2.Show()
        LoginForm2.UserNameTextBox2M.Focus()



    End Sub



    Private Sub AttendanceMainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call readData1()

        MetroTextBox10.Focus()
        ArduinoConnect()
        Timer1.Enabled = True

    End Sub







    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        receivedData = ReceiveSerialData()
        MetroTextBox10.Text &= receivedData





    End Sub




    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click

        'MainForm.Show()
        'Me.Close()
        LoginForm2.Show()
        LoginForm2.UserNameTextBox2M.Focus()

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs)


        AttendanceMainForm2.Show()
        Me.Hide()
    End Sub

    Private Sub MetroButton1_Click_1(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If MetroTextBox10.Text = "" Then
            MsgBox("Please enter a Borrower ID", 0, "")
        ElseIf MetroTextBox2.Text = "" Or MetroTextBox7.Text = "" Or MetroTextBox2.Text = "" Then
            MsgBox("No Details", 0, "") ' Validation (Robert)



        Else
            Try
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("INSERT INTO Attendance values('','" & MetroTextBox1.Text & "','" & MetroTextBox7.Text & "','" & MetroTextBox2.Text & "','" & MetroDateTime1.Text & "','" & MetroTextBox3.Text & "','" & MetroDateTime2.Text & "')", objcon)
                If com.ExecuteNonQuery() Then MsgBox("Submitted!", 0, "")


                objcon.Close()

                MetroTextBox1.Clear()
                MetroTextBox7.Clear()
                MetroTextBox2.Clear()
                MetroTextBox10.Clear()
                MetroTextBox10.Focus()
                PictureBox4.Image = Nothing
            Catch ex As Exception
                MsgBox(ex.Message, 0, "")
            End Try
            PictureBox4.ResetText()
            'SerialPort2.Close()
            AttendanceMainForm2.Show()
            Me.Hide()
        End If
    End Sub








    Public Sub adddatatolistview1(ByVal lvw1 As ListView,
                            ByVal B_ID As String,
                            ByVal B_Name As String,
                            ByVal B_Addrress As String,
                            ByVal B_Type As String,
                            ByVal B_ContactNumber As String,
                            ByVal B_Img As String)

        Dim lv1 As New ListViewItem
        lvw1.Items.Add(lv1)
        lv1.Text = B_ID
        lv1.SubItems.Add(B_Name)
        lv1.SubItems.Add(B_Addrress)
        lv1.SubItems.Add(B_Type)
        lv1.SubItems.Add(B_ContactNumber)
        lv1.SubItems.Add(B_Img)



    End Sub



    Sub readData1()
        ListView1.Clear()
        ListView1.Columns.Add("", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 310, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 90, HorizontalAlignment.Center)
        ListView1.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Borrowers ", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview1(ListView1, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try


    End Sub





    Private Sub ListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

        Dim i As Integer
        For i = 0 To ListView1.Items.Count - 1
            If ListView1.Items(i).Selected = True Then

                Exit For
            End If
        Next
        ListView1.Focus()
        ListView1.FullRowSelect = True
    End Sub

    Private Sub MetroTextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox10.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Error")
            e.Handled = True
        End If
    End Sub


    Private Sub MetroTextBox10_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox10.TextChanged
        Dim i As Integer
        ListView1.SelectedItems.Clear()
        MetroTextBox10.Focus()

        Try



            If Me.MetroTextBox10.Text = "" Then
                ' Call CellRestart()
                MetroTextBox1.Text = ""
                MetroTextBox7.Text = ""
                MetroTextBox2.Text = ""
                PictureBox4.Image = Nothing
            Else


                For i = 0 To ListView1.Items.Count - 1
                    If MetroTextBox10.Text = ListView1.Items(i).SubItems(0).Text Then
                        MetroTextBox1.Text = ListView1.Items(i).SubItems(1).Text
                        MetroTextBox7.Text = ListView1.Items(i).SubItems(2).Text
                        MetroTextBox2.Text = ListView1.Items(i).SubItems(4).Text
                        PictureBox4.ImageLocation = ListView1.Items(i).SubItems(5).Text
                        MetroTextBox10.Focus()
                        'MetroLabel6.Hide()
                        Exit For


                    Else

                        'MetroLabel6.Show()
                    End If


                Next
            End If
            ' Call locateCell()

        Catch

        End Try

    End Sub







    Private Sub MetroTextBox2_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox2.TextChanged


        If MetroTextBox2.Text <> "" Then


            If objcon.State = ConnectionState.Closed Then objcon.Open()
            com2 = New OleDb.OleDbCommand("SELECT * FROM QAttendance WHERE A_Name='" & MetroTextBox1.Text & "' AND A_Date='" & MetroLabel7.Text & "'", objcon)
            dr = com2.ExecuteReader

            'If (dr("A_Action").ToString()) = "Login" Then
            '    MsgBox("Detected Login")
            'Else
            '    MsgBox("Detected Logout")
            'End If

            If (dr.HasRows) Then
                If objcon.State = ConnectionState.Closed Then objcon.Open()

                com4 = New OleDb.OleDbCommand("DELETE * FROM QAttendance WHERE A_Name='" & MetroTextBox1.Text & "'", objcon)
                com4.ExecuteNonQuery()
                '////////////////////////////////////////////
                Try
                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("INSERT INTO Attendance values('','" & MetroTextBox1.Text & "','" & MetroTextBox7.Text & "','" & MetroTextBox2.Text & "','" & MetroLabel6.Text & "','Logout','" & MetroLabel7.Text & "')", objcon)

                    If com.ExecuteNonQuery() Then
                        objcon.Close()
                        MetroTextBox1.Clear()
                        MetroTextBox7.Clear()
                        MetroTextBox2.Clear()

                        MetroTextBox10.Clear()
                        PictureBox4.Image = Nothing
                        'MsgBox("Logout")
                    End If


                Catch ex As Exception
                    MsgBox(ex.Message, 0, "adaw")
                End Try
                PictureBox4.ResetText()
                'SerialPort2.Close()
                'AttendanceMainForm2.Show()
                'Me.Hide()
                '////////////////////////////////////////////
            Else

                com3 = New OleDb.OleDbCommand("INSERT INTO QAttendance values('','" & MetroTextBox1.Text & "','" & MetroTextBox7.Text & "','" & MetroTextBox2.Text & "','" & MetroLabel6.Text & "','" & MetroTextBox3.Text & "','" & MetroLabel7.Text & "')", objcon)
                com3.ExecuteNonQuery()
                '////////////////////////////////////////////
                Try
                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("INSERT INTO Attendance values('','" & MetroTextBox1.Text & "','" & MetroTextBox7.Text & "','" & MetroTextBox2.Text & "','" & MetroLabel6.Text & "','Login','" & MetroLabel7.Text & "')", objcon)
                    If com.ExecuteNonQuery() Then
                        objcon.Close()
                        MetroTextBox1.Clear()
                        MetroTextBox7.Clear()
                        MetroTextBox2.Clear()

                        MetroTextBox10.Clear()
                        PictureBox4.Image = Nothing
                        ' MsgBox("login")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, 0, "adaw")
                End Try
                PictureBox4.ResetText()
                ' SerialPort2.Close()
                'AttendanceMainForm2.Show()
                'Me.Hide()
                '////////////////////////////////////////////
            End If







        End If
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try
            If objcon.State = ConnectionState.Closed Then objcon.Open()
            com = New OleDb.OleDbCommand("DELETE * FROM Attendance", objcon)
            If com.ExecuteNonQuery() Then MsgBox("Submitted!", 0, "")


            objcon.Close()

        Catch ex As Exception
            MsgBox(ex.Message, 0, "")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        MetroLabel6.Text = Date.Now.ToString("hh:mm:ss tt")
        MetroLabel7.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub
End Class