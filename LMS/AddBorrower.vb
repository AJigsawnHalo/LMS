

Imports System
Imports System.IO.Ports

Public Class AddBorrower
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
        Timer2.Enabled = False

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


    Private Sub AddCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MetroDateTime1.MinDate = DateTime.Today
        Call DisableThem()
        Call readData()
        MetroTextBox1.Focus()
        ArduinoConnect()
    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        receivedData = ReceiveSerialData()
        MetroTextBox1.Text &= receivedData
    End Sub

    Public NameFrm, NameTo As String

    Private Sub MetroTextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MetroTextBox4.KeyDown

    End Sub
    Private Sub MetroTextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox4.LostFocus
        MetroTextBox4.Text = MetroTextBox4.Text.Trim
    End Sub


    Private Sub MetroButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton9.Click
        SerialPort2.Close()
        LibraryMainForm.Show()
        Me.Close()
    End Sub

    Private Sub MetroTextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox2.LostFocus
        NameFrm = MetroTextBox2.Text
        Call Sentence()
        MetroTextBox2.Text = NameTo
    End Sub

    Private Sub MetroTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox2.TextChanged

    End Sub
    Sub Sentence()
        Dim a, b As Integer
        a = NameFrm.Length
        NameTo = ""
        For b = 0 To a - 1
            If b = 0 Then
                If Char.IsLower(NameFrm(0)) Then
                    NameTo = Char.ToUpper(NameFrm(0))
                Else
                    NameTo = NameFrm(0)
                End If
            Else
                If NameFrm(b - 1) = " " Then
                    NameTo = NameTo + Char.ToUpper(NameFrm(b))
                Else
                    NameTo = NameTo + NameFrm(b)
                End If
            End If
        Next
    End Sub

    Private Sub MetroTextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox3.LostFocus
        NameFrm = MetroTextBox3.Text
        Call Sentence()
        MetroTextBox3.Text = NameTo
    End Sub



    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        If MetroTextBox1.Text = "" Then
            MsgBox("Please enter Borrower's RFID", 0, "")
        ElseIf MetroComboBox1.SelectedIndex = -1 Then
            MsgBox("Please enter Borrower Type", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox2.Text = "" Then
            MsgBox("Please enter Borrower Name", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox3.Text = "" Then
            MsgBox("Please enter Borrower Address", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox4.Text = "" Then
            MsgBox("Please enter Contact #", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox4.Text.Length > 11 Then
            MsgBox("Minimun and Maximum of 11 digits", 0, "")

        ElseIf MetroTextBox4.Text.Length < 11 Then
            MsgBox("Minimun and Maximum of 11 digits", 0, "")
        Else
            Try
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("INSERT INTO Borrowers values('" & MetroTextBox1.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "','" & MetroComboBox1.Text & "','" & MetroTextBox7.Text & "')", objcon)
                If com.ExecuteNonQuery() Then MsgBox("Saved Success!", 0, "")
                ListView2.Clear()
                Call ClearField()
                Call readData()
                objcon.Close()
                Call DisableThem()
                MetroTextBox1.Focus()
                PictureBox4.Image = Nothing
            Catch ex As Exception
                MsgBox(ex.Message, 0, "")
            End Try
            PictureBox4.ResetText()
        End If
    End Sub

    Private Sub MetroTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox1.KeyPress
        'condition for entering number only
        ' If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
        'MessageBox.Show("Please enter numbers only")
        ' e.Handled = True
        ' End If
    End Sub

    Private Sub MetroTextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox4.KeyPress
        'condition for entering number only
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If

        If MetroTextBox4.Text.Length > 10 Then

            e.Handled = True
            MessageBox.Show("Maximum 11 digits, Please try again")
            MetroTextBox4.Text = ""
        End If


    End Sub

    'condition for letters only (the best!!)
    Private Sub MetroTextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox2.KeyPress

        If Not (Asc(e.KeyChar) = 8) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90 Or Asc(e.KeyChar) <= 32) And Asc(e.KeyChar) >= 31) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

    End Sub


    Private Sub MetroButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton8.Click
        If MetroTextBox1.Text = "" Then
            MsgBox("Please enter the ID to be deleted!", 0, "")
        Else
            Try
                objcon.Open()
                com = New OleDb.OleDbCommand("delete from Borrowers where B_ID='" & MetroTextBox1.Text & "'", objcon)
                If com.ExecuteNonQuery() Then
                    ListView2.Clear()
                    Call readData()
                    MsgBox("Deleted Success!", 0, "")
                    Call ClearField()
                    PictureBox4.Image = Nothing
                    MetroTextBox1.Focus()
                Else
                    MsgBox("ID Not Found!", 0, "")
                End If

                objcon.Close()
            Catch ex As Exception
                MsgBox(ex.Message, 0, "")
            End Try
        End If
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        PictureBox4.Image = Nothing
        Call EnableThem()
        Call ClearField()
        MetroTextBox1.Focus()
    End Sub
    Sub EnableThem()
        MetroTextBox1.Enabled = True
        MetroTextBox2.Enabled = True
        MetroTextBox3.Enabled = True
        MetroTextBox4.Enabled = True
        MetroComboBox1.Enabled = True
        MetroDateTime1.Visible = False

    End Sub
    Sub DisableThem()
        'MetroTextBox1.Enabled = False
        MetroTextBox2.Enabled = False
        MetroTextBox3.Enabled = False
        MetroTextBox4.Enabled = False
        MetroComboBox1.Enabled = False
        MetroDateTime1.Visible = False

    End Sub



    Sub readData()
        ListView2.Columns.Add("RFID", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Borrower Name", 210, HorizontalAlignment.Center)
        ListView2.Columns.Add("Borrower Address", 130, HorizontalAlignment.Center)
        ListView2.Columns.Add("Contact #", 150, HorizontalAlignment.Center)
        ListView2.Columns.Add("Borrower Type", 150, HorizontalAlignment.Center)


        ListView2.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Borrowers", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview(ListView2, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub

    Public Sub adddatatolistview(ByVal lvw As ListView, ByVal B_ID As String, ByVal B_Name As String, ByVal B_Address As String, ByVal B_Cont As String, ByVal B_Type As String, ByVal B_Img As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = B_ID
        lv.SubItems.Add(B_Name)
        lv.SubItems.Add(B_Address)
        lv.SubItems.Add(B_Cont)
        lv.SubItems.Add(B_Type)
        lv.SubItems.Add(B_Img)


    End Sub

    Sub ClearField()
        MetroTextBox1.Clear()
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""

        MetroComboBox1.SelectedIndex = -1 'clearing combo box
        MetroDateTime1.Value = DateTime.Now

    End Sub
    Sub LoadInto()

    End Sub
    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To ListView2.Items.Count - 1
            If ListView2.Items(i).Selected = True Then
                MetroTextBox1.Text = ListView2.Items(i).SubItems(0).Text
                MetroTextBox2.Text = ListView2.Items(i).SubItems(1).Text
                MetroTextBox3.Text = ListView2.Items(i).SubItems(2).Text
                MetroTextBox4.Text = ListView2.Items(i).SubItems(3).Text
                MetroComboBox1.Text = ListView2.Items(i).SubItems(4).Text
                PictureBox4.ImageLocation = ListView2.Items(i).SubItems(5).Text

                Exit For
            End If
        Next
        ListView2.Focus()
        ListView2.FullRowSelect = True
    End Sub





    Private Sub MetroTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox1.TextChanged
        Dim i As Integer
        ListView2.SelectedItems.Clear()
        MetroTextBox1.Focus()
        Try
            If Me.MetroTextBox1.Text = "" Then
                MetroTextBox2.Text = ""
                PictureBox4.Image = Nothing
            Else
                For i = 0 To ListView2.Items.Count - 1
                    If MetroTextBox1.Text = ListView2.Items(i).SubItems(0).Text Then
                        MetroTextBox2.Text = ListView2.Items(i).SubItems(1).Text
                        PictureBox4.ImageLocation = MetroTextBox7.Text
                        ListView2.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch

        End Try
    End Sub







    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try

            Dim OFD As FileDialog = New OpenFileDialog()

            OFD.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"

            If OFD.ShowDialog() = DialogResult.OK Then

                PictureBox4.ImageLocation = OFD.FileName
                MetroTextBox7.Text = OFD.FileName
            End If

            OFD = Nothing

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub


End Class
