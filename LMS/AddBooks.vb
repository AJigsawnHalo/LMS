Public Class AddBooks
    Public NameFrm, NameTo As String
    Private Sub Metrobutton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton9.Click

        LibraryMainForm.Show()
        Me.Close()
    End Sub

    Sub Firstload()
        MetroTextBox1.Focus()

    End Sub

    Private Sub AddBooks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call generateyear()
        Call disablethem()
        Call readData()
        Call Name_Group()
        MetroTextBox1.Select()
        Call fill_list()


       

    End Sub
    'Sub GroupID_Combo()
    '   Try
    '      If objcon.State = ConnectionState.Closed Then objcon.Open()
    '     com = New OleDb.OleDbCommand("Select GroupID from GroupD", objcon)
    '    dr = com.ExecuteReader
    '   While dr.Read
    '      MetroComboBox1.Items.Add(dr.Item(0))
    ' End While
    'dr.Close()
    'objcon.Close()
    'Catch ex As Exception

    '        End Try
    '    End Sub
    'Sub generateyear()
    '    Dim YearNow As Integer
    '    YearNow = Int(My.Computer.Clock.LocalTime.Year.ToString)
    '    Dim a, b, c As Integer
    '    a = YearNow - 100
    '    b = YearNow
    '    For c = a To b
    '        MetroTextBox8.Items.Add(c)
    '    Next
    'End Sub

    Private Sub MetroComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroComboBox1.LostFocus
        MetroComboBox1.Text = MetroComboBox1.Text.ToUpper()
    End Sub



    Private Sub Metrobutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click

        Call enablethem()
        MetroTextBox1.Select()
    End Sub

    Private Sub MetroTextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox2.LostFocus
        NameFrm = MetroTextBox2.Text
        Call Sentence()
        MetroTextBox2.Text = NameTo
    End Sub
    Sub disablethem()


        MetroTextBox2.Enabled = False
        MetroTextBox3.Enabled = False
        MetroComboBox1.Enabled = False
        MetroTextBox4.Enabled = False
        MetroTextBox5.Enabled = False
        MetroTextBox6.Enabled = False
        MetroTextBox8.Enabled = False


    End Sub
    Sub enablethem()

        MetroTextBox2.Enabled = True
        MetroTextBox3.Enabled = True
        MetroComboBox1.Enabled = True
        MetroTextBox4.Enabled = True
        MetroTextBox5.Enabled = True
        MetroTextBox6.Enabled = True
        MetroTextBox8.Enabled = True

        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox8.Text = ""
        MetroComboBox1.SelectedIndex = -1 'clearing combo box
        'MetroTextBox8.SelectedIndex = -1 'clearing combo box


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

    Private Sub MetroTextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox3.TextChanged

    End Sub

    Private Sub MetroTextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox4.LostFocus
        NameFrm = MetroTextBox4.Text
        Call Sentence()
        MetroTextBox4.Text = NameTo
    End Sub

    Private Sub MetroTextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox4.TextChanged

    End Sub

    Private Sub MetroTextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox5.LostFocus
        NameFrm = MetroTextBox5.Text
        Call Sentence()
        MetroTextBox5.Text = NameTo
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

    Private Sub Metrobutton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton8.Click
        If MetroTextBox9.Text = "" Then
            MessageBox.Show("Invalid Book Copy")


        Else


            Try



                If objcon.State = ConnectionState.Closed Then objcon.Open()

                If MessageBox.Show("Do you really want to delete?", "ARE YOU SURE", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    com = New OleDb.OleDbCommand("INSERT INTO ArchivesBooks VALUES('" & MetroTextBox1.Text & "','" & MetroComboBox1.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "','" & MetroTextBox8.Text & "','" & MetroTextBox5.Text & "', '" & MetroTextBox6.Text & "', '" & MetroTextBox7.Text & "', '" & MetroTextBox9.Text & "')", objcon)
                    com.ExecuteNonQuery()
                    com2 = New OleDb.OleDbCommand("UPDATE Books SET Quantity='" & MetroTextBox6.Text - 1 & "' WHERE BookID='" & MetroTextBox1.Text & "'", objcon)
                    com2.ExecuteNonQuery()

                    If MetroTextBox6.Text = 1 Then
                        com3 = New OleDb.OleDbCommand("DELETE FROM Books WHERE BookID='" & MetroTextBox1.Text & "'", objcon)
                        com3.ExecuteNonQuery()
                    End If



                    Call readData()
                    Call enablethem()
                    MsgBox("Deleted successfully", 0, "SUCCESS")

                    'If MetroTextBox6.Text > 1 Then
                    '    com3 = New OleDb.OleDbCommand("UPDATE Books SET Quantity='" & MetroTextBox6.Text - 1 & "' WHERE BookID='" & MetroTextBox1.Text & "'", objcon)

                    '    com2 = New OleDb.OleDbCommand("INSERT INTO ArchivesBooks VALUES('" & MetroTextBox1.Text & "','" & MetroComboBox1.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "','" & MetroTextBox8.Text & "','" & MetroTextBox5.Text & "', '" & MetroTextBox6.Text - 1 & "', '" & MetroTextBox7.Text & "')", objcon)

                    '    com2.ExecuteNonQuery()



                    '    com3.ExecuteNonQuery()
                    '    Call readData()
                    '    Call enablethem()
                    '    MsgBox("Deleted successfully", 0, "SUCCESS")
                    'Else
                    '    com3 = New OleDb.OleDbCommand("DELETE FROM Books WHERE BookID='" & MetroTextBox1.Text & "'", objcon)

                    '    com2 = New OleDb.OleDbCommand("UPDATE ArchivesBooks SET Quantity='" & MetroTextBox6.Text + 1 & "' WHERE BookID='" & MetroTextBox1.Text & "'", objcon)

                    '    com2.ExecuteNonQuery()
                    '    com3.ExecuteNonQuery()
                    '    Call readData()
                    '    Call enablethem()
                    '    MsgBox("This is the last copy")
                    'End If





                End If




            Catch ex As Exception

            End Try

        End If

    End Sub
    Sub fill_list()
        If objcon.State = ConnectionState.Closed Then objcon.Open()
        com = New OleDb.OleDbCommand("Select * from Books", objcon)
        Dim dr As OleDb.OleDbDataReader
        dr = com.ExecuteReader
        dr.Read()
        While (dr.NextResult)

        End While
    End Sub

    Private Sub MetroTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox1.KeyPress
        'condition for entering number only
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub MetroTextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox5.KeyPress
        'condition for entering number only
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub MetroTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox1.TextChanged
        Dim i As Integer
        ListView2.SelectedItems.Clear()
        MetroTextBox1.Focus()
        Try
            If Me.MetroTextBox1.Text = "" Then
                MetroTextBox2.Text = ""
            Else
                For i = 0 To ListView2.Items.Count - 1
                    If MetroTextBox1.Text = ListView2.Items(i).SubItems(0).Text Then
                        MetroComboBox1.Text = ListView2.Items(i).SubItems(1).Text
                        MetroTextBox2.Text = ListView2.Items(i).SubItems(2).Text
                        MetroTextBox3.Text = ListView2.Items(i).SubItems(3).Text
                        MetroTextBox4.Text = ListView2.Items(i).SubItems(4).Text
                        MetroTextBox8.Text = ListView2.Items(i).SubItems(5).Text
                        MetroTextBox5.Text = ListView2.Items(i).SubItems(6).Text
                        MetroTextBox6.Text = ListView2.Items(i).SubItems(7).Text
                        ListView2.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim i As Integer
            For i = 0 To ListView2.Items.Count - 1
                If ListView2.Items(i).Selected = True Then
                    MetroTextBox1.Text = ListView2.Items(i + 1).SubItems(0).Text
                    Exit For
                End If
            Next
            ListView2.Focus()
            ListView2.FullRowSelect = True
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
            End While
            dr.Close()
            objcon.Close()
        Catch ex As Exception

        End Try
    End Sub


    ' Private Sub MetroComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroComboBox1.SelectedIndexChanged
    '    Call Name_Group()
    'End Sub
    '
    '   Private Sub MetroComboBox1_TextUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroComboBox1.TextUpdate
    '      Call Name_Group()
    ' End Sub



    'Sub GroupNameCom()
    '   Try
    '      If objcon.State = ConnectionState.Closed Then objcon.Open()
    '     com = New OleDb.OleDbCommand("Select * from GroupD", objcon)
    '    dr = com.ExecuteReader
    '   While dr.Read
    '      If dr.Item(0) = MetroComboBox1.Text Then
    '         MetroTextBox7.Text = dr.Item(1)
    '    End If
    '
    '       End While
    '      dr.Close()
    '     objcon.Close()
    'Catch ex As Exception
    '
    '   End Try
    'End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim i As Integer
            For i = 0 To ListView2.Items.Count - 1
                If ListView2.Items(i).Selected = True Then
                    MetroTextBox1.Text = ListView2.Items(i - 1).SubItems(0).Text
                    Exit For
                End If
            Next
            ListView2.Focus()
            ListView2.FullRowSelect = True
        Catch ex As Exception

        End Try
    End Sub




    Private Sub ListView2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        '//////////////////////////////////////////////////////
        If objcon.State = ConnectionState.Closed Then objcon.Open()

        com = New OleDb.OleDbCommand("SELECT * FROM ArchivesBooks", objcon)
        com.Connection = objcon
        Dim maxid As Object
        Dim Strid As String
        Dim intID As Integer

        com.CommandText = "Select Max(Copy) as maxid from ArchivesBooks Where BookID='" & MetroTextBox1.Text & "'"
        maxid = com.ExecuteScalar

        If maxid Is DBNull.Value Then
            intID = 1
        Else
            Strid = CType(maxid, String)
            intID = CType(Strid, String)
            intID = intID + 1


        End If

        MetroTextBox9.Text = intID
        objcon.Close()


        '//////////////////////////////////////////////////////


        Dim i As Integer
        For i = 0 To ListView2.Items.Count - 1
            If ListView2.Items(i).Selected = True Then
                Call disablethem()
                MetroTextBox1.Text = ListView2.Items(i).SubItems(0).Text

                Exit For
            End If
        Next
        ListView2.Focus()
        ListView2.FullRowSelect = True
    End Sub


    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If MetroTextBox1.Text = "" Then
            MsgBox("Please enter the Book ID!", 0, "")
        ElseIf MetroComboBox1.SelectedIndex = -1 Then
            MsgBox("Please select group ID", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox2.Text = "" Then
            MsgBox("Please select Book Name", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox3.Text = "" Then
            MsgBox("Please select Publisher", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox4.Text = "" Then
            MsgBox("Please select Author", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox8.Text > 2018 Or MetroTextBox8.Text < 1950 Then
            MsgBox("Invalid Date, Must be less than 2018 and greater than 1950", 0, "") ' Validation (Robert)

        ElseIf MetroTextBox5.Text = "" Then
            MsgBox("Please select Edition", 0, "") ' Validation (Robert)
        ElseIf MetroTextBox6.Text = "" Then
            MsgBox("Please select Edition", 0, "") ' Validation (Robert)

        ElseIf MetroTextBox6.Text > 99 Then
            MsgBox("Maximum of 99 quantity", 0, "") ' Validation (Robert)

        Else
            Try
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("INSERT INTO Books VALUES('" & MetroTextBox1.Text & "','" & MetroComboBox1.Text & "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "','" & MetroTextBox8.Text & "','" & MetroTextBox5.Text & "', '" & MetroTextBox6.Text & "', '" & MetroTextBox7.Text & "')", objcon)
                com.ExecuteNonQuery()
                Call readData()
                Call enablethem()
                MsgBox("Saved successfully", 0, "SUCCESS")
                objcon.Close()
            Catch ex As Exception
                MsgBox(ex.Message, 0, "")
            End Try
        End If
    End Sub
    Sub readData()
        ListView2.Clear()
        ListView2.Columns.Add("Book Barcode", 160, HorizontalAlignment.Left)
        ListView2.Columns.Add("Group ID", 80, HorizontalAlignment.Center)
        ListView2.Columns.Add("Book Name", 290, HorizontalAlignment.Center)
        ListView2.Columns.Add("Publisher", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Author", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Publishing Year", 190, HorizontalAlignment.Center)
        ListView2.Columns.Add("Edition", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Quantity", 100, HorizontalAlignment.Center)
        ListView2.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Books", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview(ListView2, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub







    Private Sub MetroTextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox6.KeyPress
        'condition for entering number only
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub



    Private Sub MetroTextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MetroTextBox8.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub MetroTabPage1_Click(sender As Object, e As EventArgs) Handles MetroTabPage1.Click

    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.Click

    End Sub
End Class