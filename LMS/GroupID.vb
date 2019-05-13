Public Class GroupID
    Public NameFrm, NameTo As String
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        LibraryMainForm.Show()
        Me.Close()
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        MetroTextBox1.Clear()
        MetroTextBox2.Clear()
    End Sub
    Sub disablethem()
        'MetroTextBox1.Enabled = False
        MetroTextBox1.Enabled = False
        MetroTextBox2.Enabled = False

    End Sub
    Sub enablethem()
        'MetroTextBox1.Enabled = False
        MetroTextBox1.Enabled = True
        MetroTextBox2.Enabled = True

    End Sub


    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click

        If objcon.State = ConnectionState.Closed Then objcon.Open()

        com = New OleDb.OleDbCommand("SELECT * FROM GroupName", objcon)
        com.Connection = objcon
        Dim maxid As Object
        Dim Strid As String
        Dim intID As Integer

        com.CommandText = "Select Max(GroupID) as maxid from GroupName"
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


        If MetroTextBox2.Text = "" Then
            MsgBox("Please enter a Group Name!", 0, "")
        Else
            Try
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("INSERT INTO GroupName VALUES('" & MetroTextBox1.Text & "','" & MetroTextBox2.Text & "')", objcon)
                com.ExecuteNonQuery()
                MetroListView2.Clear()
                Call readData()
                MsgBox("Successfully Saved", 0, "")
                objcon.Close()
                MetroButton7.Show()
                MetroListView2.Enabled = True
                MetroButton6.Enabled = True

            Catch ex As Exception
                MsgBox(ex.Message, 0, "")
            End Try
        End If
    End Sub

    Private Sub GroupID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call readData()
    End Sub
    Sub readData()
        MetroListView2.Columns.Add("GROUP ID", 100, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("GROUP NAME", 300, HorizontalAlignment.Center)
        MetroListView2.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM GroupName", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call disablethem()
                Call adddatatolistview(MetroListView2, dr(0), dr(1))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub
    Public Sub adddatatolistview(ByVal lvw As ListView, ByVal GroupID As String, ByVal GroupName As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = GroupID
        lv.SubItems.Add(GroupName)
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

    Private Sub MetroTextbox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MetroTextBox2.LostFocus
        NameFrm = MetroTextbox2.Text
        Call Sentence()
        MetroTextbox2.Text = NameTo
    End Sub

    Private Sub MetroTextbox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox2.TextChanged

    End Sub

    Private Sub MetroTextbox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTextBox1.TextChanged
        Dim i As Integer
        MetroListView2.SelectedItems.Clear()
        MetroTextbox1.Focus()
        Try
            If Me.MetroTextbox1.Text = "" Then
                MetroTextbox2.Text = ""
            Else
                For i = 0 To MetroListView2.Items.Count - 1
                    If MetroTextbox1.Text = MetroListView2.Items(i).SubItems(0).Text Then
                        MetroTextbox2.Text = MetroListView2.Items(i).SubItems(1).Text
                        MetroListView2.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch

        End Try
    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        If MetroTextBox1.Text = "" Then
            MsgBox("Please enter Group ID!", 0, "")
        Else

            Try
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("DELETE FROM GroupName WHERE GroupID='" & MetroTextBox1.Text & "'", objcon)
                com.ExecuteNonQuery()
                MetroListView2.Clear()
                Call readData()
                MsgBox("Deleted", 0, "")
                objcon.Close()
            Catch ex As Exception
                MsgBox("Group ID number not found!", 0, "")
            End Try
        End If
    End Sub

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        If MetroTextBox1.Text = "" Then
            MsgBox("Please enter a Group ID!", 0, "")
        Else
            Try
                If objcon.State = ConnectionState.Closed Then objcon.Open()
                com = New OleDb.OleDbCommand("UPDATE GroupName SET GroupName='" & MetroTextBox2.Text & "' WHERE GroupID='" & MetroTextBox1.Text & "'", objcon)
                com.ExecuteNonQuery()
                MetroListView2.Clear()
                Call readData()
                MsgBox("Update successfully", 0, "")
                objcon.Close()
                MetroButton6.Show()
                MetroButton1.Enabled = True
                MetroButton7.Enabled = True


            Catch ex As Exception
                MsgBox("Cannot Update", 0, "")
            End Try
        End If
    End Sub


    Private Sub MetroButton3_Click_1(sender As Object, e As EventArgs)
        Me.Hide()
        LibraryMainForm.Show()
    End Sub

    Private Sub MetroListView2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles MetroListView2.SelectedIndexChanged
        Dim i As Integer
        For i = 0 To MetroListView2.Items.Count - 1
            If MetroListView2.Items(i).Selected = True Then
                MetroTextBox1.Text = MetroListView2.Items(i).SubItems(0).Text
                Exit For
            End If
        Next
        MetroListView2.Focus()
        MetroListView2.FullRowSelect = True
    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        MetroButton6.Hide()
        MetroButton5.Show()
        MetroButton1.Enabled = False
        MetroButton7.Enabled = False
        enablethem()

    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        MetroButton7.Hide()
        MetroButton5.Show()
        enablethem()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroListView2.Enabled = False
        MetroButton6.Enabled = False
    End Sub
End Class