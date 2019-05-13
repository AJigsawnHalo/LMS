Imports System
Imports System.IO.Ports

Public Class ReturnBook





    Sub ClearThem()


        MetroTextBox8.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox5.Text = ""
        'metrotextbox9.text = ""
        MetroTextBox1.Text = ""
        ComboBox1.Items.Clear()
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroDateTime2.Text = ""
        MetroTextBox13.Text = ""
        MetroTextBox14.Text = ""

        MetroDateTime1.MinDate = DateTime.Today
    End Sub



    Sub BookID_Combo()
        Try
            If objcon.State = ConnectionState.Closed Then objcon.Open()
            com = New OleDb.OleDbCommand("Select BookID from Books", objcon)
            dr = com.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            objcon.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ReturnBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call BookID_Combo()
        Call readData()
        Call readData2()
        ' MetroDateTime1.MinDate = DateTime.Today
        MetroDateTime1.Enabled = False



    End Sub

    Sub readData2()
        ListView2.Clear()
        ListView2.Columns.Add("Book Barcode", 160, HorizontalAlignment.Center)
        ListView2.Columns.Add("Group ID", 60, HorizontalAlignment.Center)
        ListView2.Columns.Add("Book Name", 310, HorizontalAlignment.Center)
        ListView2.Columns.Add("Borrower ID", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Borrower Name", 190, HorizontalAlignment.Center)
        ListView2.Columns.Add("Issue Date", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Due Date", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Transaction", 130, HorizontalAlignment.Center)
        ListView2.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Issue", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview2(ListView2, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub

    Public Sub adddatatolistview2(ByVal lvw As ListView,
                                 ByVal BookID As String,
                                 ByVal GroupID As String,
                                 ByVal BookName As String,
                                 ByVal B_ID As String,
                                 ByVal B_Name As String,
                                 ByVal Issue_Date As String,
                                 ByVal Due_Date As String,
                                 ByVal Trans As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = BookID
        lv.SubItems.Add(GroupID)
        lv.SubItems.Add(BookName)
        lv.SubItems.Add(B_ID)
        lv.SubItems.Add(B_Name)
        lv.SubItems.Add(Issue_Date)
        lv.SubItems.Add(Due_Date)
        lv.SubItems.Add(Trans)
    End Sub



    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Me.MetroTextBox8.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox1.Text = ""
        'metrotextbox9.text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroDateTime2.Text = ""
        MetroTextBox13.Text = ""
    End Sub






    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged



        Dim i As Integer
        For i = 0 To ListView2.Items.Count - 1
            If ListView2.Items(i).Selected = True Then
                MetroTextBox8.Text = ListView2.Items(i).SubItems(0).Text
                ComboBox1.Text = ListView2.Items(i).SubItems(0).Text
                MetroTextBox11.Text = ListView2.Items(i).SubItems(3).Text
                MetroTextBox10.Text = ListView2.Items(i).SubItems(4).Text
                'metrotextbox9.text = ListView2.Items(i).SubItems(5).Text
                MetroLabel9.Text = ListView2.Items(i).SubItems(6).Text

                MetroTextBox14.Text = ListView2.Items(i).SubItems(7).Text

                Exit For
            End If
        Next
        ListView2.Focus()
        ListView2.FullRowSelect = True
        MetroTextBox12.Text = 0
        MetroTextBox15.Text = 0
    End Sub


    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Dim dt1 As DateTime = Convert.ToDateTime(MetroDateTime2.Text)
        Dim dt2 As DateTime = Convert.ToDateTime(MetroDateTime1.Text)
        Dim ts As TimeSpan = dt2.Subtract(dt1)

        Dim Total As Double = 0.0
        Dim Penalty As Integer = 15
        Dim Damage As Integer = 150
        If dt1 < dt2 Then
            Total = Penalty * ts.Days

            MetroTextBox12.Text = Total

        End If

        If ComboBox1.Text = "" Then
            MsgBox("Please mention the Book ID", 0, "")
        Else
            Try


                If MessageBox.Show("Damage book or not?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


                    MetroTextBox15.Text = 150
                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("INSERT INTO DamageBooks VALUES('" & MetroTextBox8.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox11.Text & "','" & MetroTextBox10.Text & "','" & MetroLabel9.Text & "','" & MetroDateTime2.Text & "','" & MetroDateTime1.Text & "','" & MetroTextBox15.Text & "')", objcon)
                    com.ExecuteNonQuery()
                    objcon.Close()
                    Call readData()




                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("DELETE FROM Issue WHERE Trans=" & MetroTextBox14.Text & "", objcon)
                    com.ExecuteNonQuery()
                    objcon.Close()
                    Call readData()
                    Call readData2()


                    If MetroTextBox8.Text = 2 Then
                        If objcon.State = ConnectionState.Closed Then objcon.Open()
                        com = New OleDb.OleDbCommand("UPDATE Books SET status='Available' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                        com.ExecuteNonQuery()
                        objcon.Close()
                        Call readData()
                        Call readData2()
                    Else
                        If objcon.State = ConnectionState.Closed Then objcon.Open()
                        com = New OleDb.OleDbCommand("UPDATE Books SET status='Borrowed' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                        com.ExecuteNonQuery()
                        objcon.Close()
                        Call readData()
                        Call readData2()
                    End If


                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("INSERT INTO Returns VALUES('" & MetroTextBox8.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox11.Text & "','" & MetroTextBox10.Text & "','" & MetroLabel9.Text & "','" & MetroDateTime2.Text & "','" & MetroDateTime1.Text & "','" & MetroTextBox12.Text & "')", objcon)
                    com.ExecuteNonQuery()
                    MsgBox("Book has been returned!", 0, "")
                    objcon.Close()
                    Call readData2()

                    Call ClearThem()
                    MsgBox(Damage, 0, "Damage Fine")
                    MsgBox(Total, 0, "Late Penalty")
                Else

                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("DELETE FROM Issue WHERE Trans=" & MetroTextBox14.Text & "", objcon)
                    com.ExecuteNonQuery()
                    objcon.Close()
                    Call readData()
                    Call readData2()

                    If MetroTextBox8.Text > 2 Then
                        If objcon.State = ConnectionState.Closed Then objcon.Open()
                        com = New OleDb.OleDbCommand("UPDATE Books SET status='Available' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                        com.ExecuteNonQuery()
                        objcon.Close()
                        Call readData()
                        Call readData2()
                    Else
                        If objcon.State = ConnectionState.Closed Then objcon.Open()
                        com = New OleDb.OleDbCommand("UPDATE Books SET status='Borrowed' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                        com.ExecuteNonQuery()
                        objcon.Close()
                        Call readData()
                        Call readData2()
                    End If


                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("UPDATE Books SET Quantity='" & MetroTextBox13.Text + 1 & "' WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
                    com.ExecuteNonQuery()
                    objcon.Close()
                    Call readData()
                    Call readData2()

                    If objcon.State = ConnectionState.Closed Then objcon.Open()
                    com = New OleDb.OleDbCommand("INSERT INTO Returns VALUES('" & MetroTextBox8.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox11.Text & "','" & MetroTextBox10.Text & "','" & MetroLabel9.Text & "','" & MetroDateTime2.Text & "','" & MetroDateTime1.Text & "','" & MetroTextBox12.Text & "')", objcon)
                    com.ExecuteNonQuery()
                    MsgBox("Book has been returned!", 0, "")
                    objcon.Close()
                    Call readData2()

                    Call ClearThem()


                    MsgBox(Total, 0, "Late Penalty")
                End If


                MetroTextBox15.Text = ""
                MetroTextBox12.Text = ""


            Catch ex As Exception
                MsgBox(ex.Message, 0, "")
            End Try


        End If
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        LibraryMainForm.Show()
        Me.Close()

    End Sub




    Sub IssueDetail() '
        Try
            If objcon.State = ConnectionState.Closed Then objcon.Open()
            com = New OleDb.OleDbCommand("Select IssueDate, Barcode_ID, Borrower_Name, DueDate from Issue WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
            dr = com.ExecuteReader
            While dr.Read
                MetroLabel9.Text = dr.Item(0)
                MetroTextBox11.Text = dr.Item(1)
                MetroTextBox10.Text = dr.Item(2)
                MetroDateTime2.Text = dr.Item(3)
                MetroTextBox14.Text = dr.Item(7)
            End While
            dr.Close()
            objcon.Close()
        Catch ex As Exception

        End Try
    End Sub



    'Private Sub MetroListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroListView2.SelectedIndexChanged
    '    Dim i As Integer
    '    For i = 0 To MetroListView2.Items.Count - 1
    '        If MetroListView2.Items(i).Selected = True Then
    '            MetroTextBox8.Text = MetroListView2.Items(i).SubItems(0).Text
    '            Exit For
    '        End If
    '    Next
    '    MetroListView2.Focus()
    '    MetroListView2.FullRowSelect = True
    'End Sub


    'Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim i As Integer
    '    MetroListView2.SelectedItems.Clear()
    '    MetroTextBox8.Focus()
    '    Try
    '        If Me.ComboBox1.Text = "" Then

    '        Else
    '            For i = 0 To MetroListView2.Items.Count - 1
    '                If MetroTextBox8.Text = MetroListView2.Items(i).SubItems(0).Text Then
    '                    MetroTextBox6.Text = MetroListView2.Items(i).SubItems(1).Text
    '                    MetroTextBox2.Text = MetroListView2.Items(i).SubItems(2).Text
    '                    MetroListView2.Items(i).Selected = True
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch

    '    End Try
    '    Call IssueDetail()
    'End Sub


    Private Sub MetroTextBox8_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox8.TextChanged


        Dim i As Integer
        MetroListView2.SelectedItems.Clear()
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
                MetroTextBox1.Text = ""

                MetroTextBox13.Text = ""
            Else
                For i = 0 To MetroListView2.Items.Count - 1
                    If MetroTextBox8.Text = MetroListView2.Items(i).SubItems(0).Text Then
                        ComboBox1.Text = MetroListView2.Items(i).SubItems(0).Text
                        MetroTextBox6.Text = MetroListView2.Items(i).SubItems(1).Text
                        MetroTextBox2.Text = MetroListView2.Items(i).SubItems(2).Text
                        MetroTextBox3.Text = MetroListView2.Items(i).SubItems(3).Text
                        MetroTextBox4.Text = MetroListView2.Items(i).SubItems(4).Text
                        MetroTextBox7.Text = MetroListView2.Items(i).SubItems(5).Text
                        MetroTextBox5.Text = MetroListView2.Items(i).SubItems(6).Text
                        MetroTextBox13.Text = MetroListView2.Items(i).SubItems(7).Text
                        MetroListView2.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch

        End Try
        Call IssueDetail()
    End Sub



    'Private Sub MetroButton3_Click(sender As Object, e As EventArgs)
    '    If ComboBox1.Text = "" Then
    '        MsgBox("Please mention a Book ID", 0, "")
    '    Else

    '        Try
    '            If objcon.State = ConnectionState.Closed Then objcon.Open()
    '            com = New OleDb.OleDbCommand("DELETE FROM Returns WHERE BookID='" & MetroTextBox8.Text & "'", objcon)
    '            com.ExecuteNonQuery()
    '            MsgBox("Deleted Success!", 0, "")
    '            Call ClearThem()
    '            objcon.Close()
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub





    Sub readData()
        MetroListView2.Clear()
        MetroListView2.Columns.Add("Book Barcode", 160, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Group ID", 60, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Book Name", 310, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Publisher", 90, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Author", 90, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Publishing Year", 190, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Edition", 90, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Quantity", 90, HorizontalAlignment.Center)
        MetroListView2.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Books", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview(MetroListView2, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7))
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




End Class