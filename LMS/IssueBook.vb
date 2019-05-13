

Imports System
Imports System.IO.Ports

Public Class IssueBook

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

    '/////////////////////////////////////

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

    Private Sub IssueBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MetroTextBox8.Select()
        MetroDateTime1.MinDate = DateTime.Today
        MetroDateTime1.Enabled = False
        MetroDateTime2.MinDate = DateTime.Today
        Call readData()
        MetroDateTime2.Value = MetroDateTime2.Value.AddDays(3)
        ArduinoConnect()
    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        receivedData = ReceiveSerialData()
        MetroTextBox9.Text &= receivedData
    End Sub



    Private Sub metrobutton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        LibraryMainForm.Show()
    End Sub

    Private Sub MetroTextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        'condition for entering number only
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub




    Sub readData()
        MetroListView1.Clear()
        MetroListView1.Columns.Add("Book Barcode", 160, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Group ID", 60, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Book Name", 310, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Publisher", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Author", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Publishing Year", 190, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Edition", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Quantity", 90, HorizontalAlignment.Center)
        MetroListView1.View = View.Details

        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Books", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview(MetroListView1, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub
    Public Sub adddatatolistview(ByVal lvw As ListView, ByVal BookID As String, ByVal GroupID As String, ByVal BookName As String, ByVal Publisher As String, ByVal Author As String, ByVal PubYear As String, ByVal edi As String, ByVal qty As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = BookID
        lv.SubItems.Add(GroupID)
        lv.SubItems.Add(BookName)
        lv.SubItems.Add(Publisher)
        lv.SubItems.Add(Author)
        lv.SubItems.Add(PubYear)
        lv.SubItems.Add(edi)

        lv.SubItems.Add(qty)
    End Sub



    Private Sub MetroTextBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        MetroListView1.SelectedItems.Clear()

        Try
            If Me.MetroTextBox8.Text = "" Then
                MetroTextBox6.Text = ""
            Else
                For i = 0 To MetroListView1.Items.Count - 1
                    If MetroTextBox8.Text = MetroListView1.Items(i).SubItems(0).Text Then
                        MetroTextBox6.Text = MetroListView1.Items(i).SubItems(1).Text
                        MetroTextBox2.Text = MetroListView1.Items(i).SubItems(2).Text
                        MetroTextBox3.Text = MetroListView1.Items(i).SubItems(3).Text
                        MetroTextBox4.Text = MetroListView1.Items(i).SubItems(4).Text
                        MetroTextBox7.Text = MetroListView1.Items(i).SubItems(5).Text
                        MetroTextBox5.Text = MetroListView1.Items(i).SubItems(6).Text
                        MetroTextBox12.Text = MetroListView1.Items(i).SubItems(7).Text
                        MetroListView1.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch

        End Try
    End Sub

    Private Sub metrobutton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If MetroTextBox8.Text = "" Then
                MsgBox("Please mention the BookID", 0, "")
            Else
                If objcon.State = ConnectionState.Closed Then
                    com = New OleDb.OleDbCommand("delete from Issue where BookID='" & MetroTextBox8.Text & "'", objcon)
                    If MsgBox("Do you really want to delete?", MsgBoxStyle.YesNo, "Are you sure?") = Windows.Forms.DialogResult.Yes Then
                        com.ExecuteNonQuery()
                        Call readData()
                    End If
                    objcon.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroListView1.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To MetroListView1.Items.Count - 1
            If MetroListView1.Items(i).Selected = True Then
                MetroTextBox8.Text = MetroListView1.Items(i).SubItems(0).Text
                Exit For
            End If
        Next
        MetroListView1.Focus()
        MetroListView1.FullRowSelect = True
    End Sub



    Private Sub MetroTextBox8_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox8.TextChanged
        Dim i As Integer
        MetroListView1.SelectedItems.Clear()
        MetroTextBox8.Focus()
        Try
            If Me.MetroTextBox8.Text = "" Then
                MetroTextBox6.Text = ""
                MetroTextBox6.Text = ""
                MetroTextBox2.Text = ""
                MetroTextBox3.Text = ""
                MetroTextBox4.Text = ""
                MetroTextBox7.Text = ""
                MetroTextBox5.Text = ""

                MetroTextBox12.Text = ""
            Else
                For i = 0 To MetroListView1.Items.Count - 1
                    If MetroTextBox8.Text = MetroListView1.Items(i).SubItems(0).Text Then
                        MetroTextBox6.Text = MetroListView1.Items(i).SubItems(1).Text
                        MetroTextBox2.Text = MetroListView1.Items(i).SubItems(2).Text
                        MetroTextBox3.Text = MetroListView1.Items(i).SubItems(3).Text
                        MetroTextBox4.Text = MetroListView1.Items(i).SubItems(4).Text
                        MetroTextBox7.Text = MetroListView1.Items(i).SubItems(5).Text
                        MetroTextBox5.Text = MetroListView1.Items(i).SubItems(6).Text
                        MetroTextBox12.Text = MetroListView1.Items(i).SubItems(7).Text
                        MetroListView1.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch

        End Try
    End Sub

    Private Sub MetroTextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox9.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please use RFID Scanner")
            e.Handled = True
        End If
    End Sub



    Private Sub MetroTextBox9_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox9.TextChanged
        If MetroTextBox9.Text = "" Then
            MetroTextBox10.Text = ""
            MetroTextBox11.Text = ""

        Else

            Try
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("Select B_ID,B_Name,B_Type from Borrowers", objcon)
                dr = com.ExecuteReader
                While dr.Read
                    If dr.Item(0) = MetroTextBox9.Text Then
                        MetroTextBox10.Text = dr.Item(1)
                        MetroTextBox11.Text = dr.Item(2)
                    End If

                End While
                dr.Close()
                objcon.Close()
            Catch

            End Try

        End If
    End Sub



    Private Sub metrobutton4_Click_1(sender As Object, e As EventArgs) Handles MetroButton4.Click
        LibraryMainForm.Show()
        Me.Close()
        SerialPort2.Close()

    End Sub

    Private Sub metrobutton2_Click_1(sender As Object, e As EventArgs) Handles MetroButton2.Click

        If objcon.State = ConnectionState.Closed Then objcon.Open()

        com = New OleDb.OleDbCommand("SELECT * FROM Issue", objcon)
        com.Connection = objcon
        Dim maxid As Object
        Dim Strid As String
        Dim intID As Integer

        com.CommandText = "Select Max(Trans) as maxid from Issue"
        maxid = com.ExecuteScalar

        If maxid Is DBNull.Value Then
            intID = 1
        Else
            Strid = CType(maxid, String)
            intID = CType(Strid, String)
            intID = intID + 1


        End If

        MetroTextBox1.Text = intID
        objcon.Close()




        If MetroTextBox9.Text = "" Then
            MsgBox("Please enter the RFID Scanner!", 0, "")
        ElseIf MetroTextBox8.Text = "" Then
            MsgBox("Please enter the Barcode Book!", 0, "")
        ElseIf MetroTextBox12.Text = 1 Then
            MsgBox("You cannot borrow the last book", 0, "")
        ElseIf MetroTextBox9.Text <> "" And MetroTextBox10.Text = "" Then
            MsgBox("Unidentified Borrower", 0, "")
        Else

            Try


                '///////////////////////////////////////////////////

                If MetroTextBox8.Text = 2 Then
                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("UPDATE Books SET status='Borrowed' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                    com.ExecuteNonQuery()
                    objcon.Close()
                    Call readData()
                Else
                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("UPDATE Books SET status='Available' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                    com.ExecuteNonQuery()
                    objcon.Close()
                    Call readData()
                End If


                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("UPDATE Books SET Quantity='" & MetroTextBox12.Text - 1 & "' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                com.ExecuteNonQuery()
                objcon.Close()
                Call readData()
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("INSERT INTO Issue VALUES('" & MetroTextBox8.Text & "','" & MetroTextBox6.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox9.Text & "','" & MetroTextBox10.Text & "','" & MetroDateTime1.Text & "','" & MetroDateTime2.Text & "','" & MetroTextBox1.Text & "')", objcon)
                com.ExecuteNonQuery()
                MsgBox("Book has been Issued!", 0, "")
                Call readData()
                objcon.Close()
                '//////////////////////////////
                MetroTextBox9.Text = ""
                MetroTextBox10.Text = ""
                MetroTextBox11.Text = ""
                MetroTextBox8.Text = ""
                MetroTextBox6.Text = ""
                MetroTextBox2.Text = ""
                MetroTextBox3.Text = ""
                MetroTextBox4.Text = ""
                MetroTextBox7.Text = ""
                MetroTextBox5.Text = ""
                MetroTextBox12.Text = ""
                MetroDateTime2.MinDate = DateTime.Today
            Catch ex As Exception
                MsgBox(ex.Message, 0, "")
            End Try
        End If


    End Sub

    Private Sub metrobutton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""


        MetroTextBox8.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox12.Text = ""
        MetroDateTime2.MinDate = DateTime.Today
    End Sub




End Class