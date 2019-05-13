Public Class SearchMainForm

    Dim sel As Integer
    Private Sub metrocombobox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroComboBox1.SelectedIndexChanged


        If MetroComboBox1.Text = "Status" Then
            MetroComboBox2.Enabled = True
            MetroComboBox2.Visible = True
            MetroTextBox1.Visible = False

        Else
            MetroComboBox2.Enabled = False
            MetroComboBox2.Visible = False
            MetroTextBox1.Visible = True

        End If
        Call forselect()
    End Sub
    Sub forselect()
        If MetroComboBox1.Text = "Barcode" Then
            sel = 1
        ElseIf MetroComboBox1.Text = "Name" Then
            sel = 2
        ElseIf MetroComboBox1.Text = "Author" Then
            sel = 3
        ElseIf MetroComboBox1.Text = "Status" Then
            sel = 8
        ElseIf MetroComboBox1.Text = "Category" Then
            sel = 9
            'ElseIf MetroComboBox1.Text = "Publishing-Year" Then
            '   sel = 6

        End If
    End Sub

    Private Sub BookDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        metrocombobox2.Visible = False
        metrotextbox1.Visible = False

        Call readData()
        Call readData2()
    End Sub


    Sub readData2()
        MetroListView2.Clear()
        MetroListView2.Columns.Add("Book Barcode", 90)
        MetroListView2.Columns.Add("Category", 90)
        MetroListView2.Columns.Add("Book Name", 90)
        MetroListView2.Columns.Add("Publisher", 90)
        MetroListView2.Columns.Add("Author", 90)
        MetroListView2.Columns.Add("Publishing Year", 90)
        MetroListView2.Columns.Add("Edition", 90)
        MetroListView2.Columns.Add("Available Copies", 90)
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




    Sub readData()
        MetroListView2.Clear()
        MetroListView2.Columns.Add("Book Barcode", 90)
        MetroListView2.Columns.Add("Category", 90)
        MetroListView2.Columns.Add("Book Name", 90)
        MetroListView2.Columns.Add("Publisher", 90)
        MetroListView2.Columns.Add("Author", 90)
        MetroListView2.Columns.Add("Publishing Year", 90)
        MetroListView2.Columns.Add("Edition", 90)
        MetroListView2.Columns.Add("Available Copies", 90)


        MetroListView2.View = View.Details
        sel = 5
        'Call whenclick()
    End Sub
    Sub whenclick()
        Try

            While dr.Read()
                Call adddatatolistview(MetroListView2, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub
    Public Sub adddatatolistview(ByVal lvw As ListView, ByVal BookID As String, ByVal GroupID As String, ByVal BookName As String, ByVal publisher As String, ByVal author As String, ByVal pubyear As String, ByVal edi As String, ByVal qty As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = BookID
        lv.SubItems.Add(GroupID)
        lv.SubItems.Add(BookName)
        lv.SubItems.Add(publisher)
        lv.SubItems.Add(author)
        lv.SubItems.Add(pubyear)
        lv.SubItems.Add(edi)
        lv.SubItems.Add(qty)
    End Sub

    Private Sub metrobutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click


        Dim SearchFilter = MetroTextBox1.Text
        Dim SearchFilter2 = MetroComboBox2.Text


        If objcon.State = ConnectionState.Closed Then objcon.Open()

        Select Case (sel)
            Case 1
                com = New OleDb.OleDbCommand("select * from Books where BookID LIKE '%" & SearchFilter & "%' AND Quantity > 1", objcon)
                dr = com.ExecuteReader

              
                If dr.HasRows Then
                    Call readData()
                    Call whenclick()
                    Call forselect()
                    MetroTabControl2.Visible = True
                Else
                    MsgBox("No Data")
                    MetroTabControl2.Visible = False
                End If


         

            Case 2
                com = New OleDb.OleDbCommand("select * from Books where BookName LIKE '%" & SearchFilter & "%'  AND Quantity > 1", objcon)
                dr = com.ExecuteReader
     

                If dr.HasRows Then
                    Call readData()
                    Call whenclick()
                    Call forselect()
                    MetroTabControl2.Visible = True
                Else
                    MsgBox("No Data")
                    MetroTabControl2.Visible = False
                End If



            Case 3
                com = New OleDb.OleDbCommand("select * from Books where Author LIKE '%" & SearchFilter & "%' AND Quantity > 1", objcon)
                dr = com.ExecuteReader
                If dr.HasRows Then
                    Call readData()
                    Call whenclick()
                    Call forselect()
                    MetroTabControl2.Visible = True
                Else
                    MsgBox("No Data")
                    MetroTabControl2.Visible = False
                End If


            Case 8

                If MetroComboBox2.Text = "Available" Then
                    com = New OleDb.OleDbCommand("select * from Books where Quantity>1", objcon)
                    dr = com.ExecuteReader
                    If dr.HasRows Then
                        Call readData()
                        Call whenclick()
                        Call forselect()
                        MetroTabControl2.Visible = True
                    Else
                        MsgBox("No Data")
                        MetroTabControl2.Visible = False
                    End If


                ElseIf MetroComboBox2.Text = "Not Available" Then
                    com = New OleDb.OleDbCommand("select * from Books where Quantity =1", objcon)
                    dr = com.ExecuteReader
                    If dr.HasRows Then
                        Call readData()
                        Call whenclick()
                        Call forselect()
                        MetroTabControl2.Visible = True
                    Else
                        MsgBox("No Data")
                        MetroTabControl2.Visible = False
                    End If


                End If


            Case 9
                
                com = New OleDb.OleDbCommand("select * from Books where GroupID LIKE '%" & SearchFilter & "%' AND Quantity > 1", objcon)
                dr = com.ExecuteReader
                If dr.HasRows Then
                    Call readData()
                    Call whenclick()
                    Call forselect()
                    MetroTabControl2.Visible = True
                Else
                    MsgBox("No Data")
                    MetroTabControl2.Visible = False
                End If


            Case 6

                com = New OleDb.OleDbCommand("select * from Books where pubyear LIKE '%" & MetroTextBox1.Text & "%' AND Quantity > 1", objcon)
                dr = com.ExecuteReader
                If dr.HasRows Then
                    Call readData()
                    Call whenclick()
                    Call forselect()
                    MetroTabControl2.Visible = True
                Else
                    MsgBox("No Data")
                    MetroTabControl2.Visible = False
                End If


        End Select

        objcon.Close()









    End Sub

    Private Sub MetroListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim i As Integer
            For i = 0 To MetroListView2.Items.Count - 1
                If MetroListView2.Items(i).Selected = True Then
                    metrotextbox1.Text = MetroListView2.Items(i + 1).SubItems(0).Text
                    Exit For
                End If
            Next
            MetroListView2.Focus()
            MetroListView2.FullRowSelect = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim i As Integer
            For i = 0 To MetroListView2.Items.Count - 1
                If MetroListView2.Items(i).Selected = True Then
                    metrotextbox1.Text = MetroListView2.Items(i - 1).SubItems(0).Text
                    Exit For
                End If
            Next
            MetroListView2.Focus()
            MetroListView2.FullRowSelect = True
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        LibraryMainForm.Show()
        Me.Hide()
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        MainForm.Show()
        Me.Close()
    End Sub


End Class