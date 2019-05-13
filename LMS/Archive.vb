Public Class Archive

    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        LibraryMainForm.Show()
        Me.Close()

    End Sub

    Private Sub Archive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call readData()
        Call Name_Group()
        'Call generateyear()

    End Sub

    Public Sub adddatatolistview(ByVal lvw As ListView,
                                 ByVal BookID As String,
                                 ByVal GroupID As String,
                                 ByVal BookName As String,
                                 ByVal Publisher As String,
                                 ByVal Author As String,
                                 ByVal PubYear As String,
                                 ByVal edi As String,
                             ByVal cpy As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = BookID
        lv.SubItems.Add(GroupID)
        lv.SubItems.Add(BookName)
        lv.SubItems.Add(Publisher)
        lv.SubItems.Add(Author)
        lv.SubItems.Add(PubYear)
        lv.SubItems.Add(edi)

        lv.SubItems.Add(cpy)
    End Sub

    Sub readData()
        MetroListView1.Clear()
        MetroListView1.Columns.Add("Book Barcode", 160, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Group ID", 80, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Book Name", 290, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Publisher", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Author", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Publishing Year", 190, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Edition", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Copy", 105, HorizontalAlignment.Center)
        MetroListView1.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM ArchivesBooks", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview(MetroListView1, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(9))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click

        Try
            If objcon.State = ConnectionState.Closed Then objcon.Open()

            If MessageBox.Show("Do you really want to delete?", "ARE YOU SURE", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                com3 = New OleDb.OleDbCommand("DELETE FROM ArchivesBooks WHERE Copy=@Copy AND BookID=@BID", objcon)

                com3.Parameters.AddWithValue("@Copy", MetroTextBox6.Text)
                com3.Parameters.AddWithValue("@BID", MetroTextBox1.Text)
                com3.ExecuteNonQuery()
                Call readData()

            End If

        Catch ex As Exception

        End Try


    End Sub

    Sub Name_Group()
        Try
            If objcon.State = ConnectionState.Closed Then objcon.Open()
            com = New OleDb.OleDbCommand("Select GroupName from GroupName", objcon)
            dr = com.ExecuteReader
            While dr.Read
                MetroComboBox1.Items.Add(dr.Item(0))
                MetroComboBox1.Items.Add(dr.Item(7))

            End While
            dr.Close()
            objcon.Close()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub MetroListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroListView1.SelectedIndexChanged




        Dim i As Integer
        For i = 0 To MetroListView1.Items.Count - 1
            If MetroListView1.Items(i).Selected = True Then

                MetroTextBox1.Text = MetroListView1.Items(i).SubItems(0).Text
                MetroComboBox1.Text = MetroListView1.Items(i).SubItems(1).Text
                MetroTextBox2.Text = MetroListView1.Items(i).SubItems(2).Text
                MetroTextBox3.Text = MetroListView1.Items(i).SubItems(3).Text
                MetroTextBox4.Text = MetroListView1.Items(i).SubItems(4).Text
                MetroTextBox9.Text = MetroListView1.Items(i).SubItems(5).Text
                MetroTextBox7.Text = MetroListView1.Items(i).SubItems(6).Text
                MetroTextBox6.Text = MetroListView1.Items(i).SubItems(7).Text

                Exit For
            End If
        Next
        MetroListView1.Focus()
        MetroListView1.FullRowSelect = True


    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        '//////////////////////////////////////////////////////
        If objcon.State = ConnectionState.Closed Then objcon.Open()

        com = New OleDb.OleDbCommand("SELECT * FROM Books", objcon)
        com.Connection = objcon
        Dim maxid As Object
        Dim Strid As String
        Dim intID As Integer

        com.CommandText = "Select Max(Quantity) as maxid from Books Where BookID='" & MetroTextBox1.Text & "'"
        maxid = com.ExecuteScalar

        If maxid Is DBNull.Value Then
            intID = 1
        Else
            Strid = CType(maxid, String)
            intID = CType(Strid, String)
            intID = intID + 1


        End If

        MetroTextBox10.Text = intID
        objcon.Close()


        Try
            If objcon.State = ConnectionState.Closed Then objcon.Open()

            If MessageBox.Show("Do you really want to restore?", "ARE YOU SURE", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                If intID = 1 Then
                    com = New OleDb.OleDbCommand("INSERT INTO Books VALUES('" & MetroTextBox1.Text & "','" & MetroComboBox1.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "','" & MetroTextBox9.Text & "','" & MetroTextBox7.Text & "', '" & MetroTextBox10.Text & "', '" & MetroTextBox5.Text & "')", objcon)

                    com3 = New OleDb.OleDbCommand("DELETE FROM ArchivesBooks WHERE Copy=@Copy AND BookID=@BID", objcon)

                    com3.Parameters.AddWithValue("@Copy", MetroTextBox6.Text)
                    com3.Parameters.AddWithValue("@BID", MetroTextBox1.Text)
                    com3.ExecuteNonQuery()
                    com.ExecuteNonQuery()
                    MsgBox("Restored successfully 1", 0, "SUCCESS")
                    Call readData()


                ElseIf intID > 1 Then
                    com2 = New OleDb.OleDbCommand("UPDATE Books SET Quantity='" & MetroTextBox10.Text & "' WHERE BookID='" & MetroTextBox1.Text & "'", objcon)

                    com3 = New OleDb.OleDbCommand("DELETE FROM ArchivesBooks WHERE Copy=@Copy AND BookID=@BID", objcon)

                    com3.Parameters.AddWithValue("@Copy", MetroTextBox6.Text)
                    com3.Parameters.AddWithValue("@BID", MetroTextBox1.Text)
                    com3.ExecuteNonQuery()

                    com2.ExecuteNonQuery()
                    MsgBox("Restored successfully 2", 0, "SUCCESS")
                    Call readData()



                End If





            End If




        Catch ex As Exception

        End Try


    End Sub



    Private Sub MetroTextBox6_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox6.TextChanged
        '//////////////////////////////////////////////////////
        If objcon.State = ConnectionState.Closed Then objcon.Open()

        com = New OleDb.OleDbCommand("SELECT * FROM Books", objcon)
        com.Connection = objcon
        Dim maxid As Object
        Dim Strid As String
        Dim intID As Integer

        com.CommandText = "Select Max(Quantity) as maxid from Books Where BookID='" & MetroTextBox1.Text & "'"
        maxid = com.ExecuteScalar

        If maxid Is DBNull.Value Then
            intID = 1
        Else
            Strid = CType(maxid, String)
            intID = CType(Strid, String)
            intID = intID + 1


        End If

        MetroTextBox10.Text = intID
        objcon.Close()

    End Sub
End Class