Public Class LogBook

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        LibraryMainForm.Show()
        Me.Close()
    End Sub

    Sub readData2()
        ListView2.Clear()
        ListView2.Columns.Add("Name", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Address", 170, HorizontalAlignment.Center)
        ListView2.Columns.Add("Type", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Time", 70, HorizontalAlignment.Center)
        ListView2.Columns.Add("Action", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Date", 80, HorizontalAlignment.Center)
        ListView2.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT A_Name, A_Address, A_Type, A_Time, A_Action, A_Date FROM Attendance WHERE A_Date = DATE()", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview2(ListView2, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub

    Public Sub adddatatolistview2(ByVal lvw As ListView,
                                ByVal A_Name As String,
                                ByVal A_Address As String,
                                ByVal A_Type As String,
                                      ByVal A_Time As String,
                                ByVal A_Action As String,
                                ByVal A_Date As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = A_Name
        lv.SubItems.Add(A_Address)
        lv.SubItems.Add(A_Type)
        lv.SubItems.Add(A_Time)
        lv.SubItems.Add(A_Action)
        lv.SubItems.Add(A_Date)
    End Sub

    Private Sub LogBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call readData2()
        MetroDateTime1.MaxDate = DateTime.Today
    End Sub

    Private Sub MetroDateTime1_ValueChanged(sender As Object, e As EventArgs) Handles MetroDateTime1.ValueChanged
        ListView2.Clear()
        ListView2.Columns.Add("Name", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Address", 170, HorizontalAlignment.Center)
        ListView2.Columns.Add("Type", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Time", 70, HorizontalAlignment.Center)
        ListView2.Columns.Add("Action", 90, HorizontalAlignment.Center)
        ListView2.Columns.Add("Date", 80, HorizontalAlignment.Center)
        ListView2.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT A_Name, A_Address, A_Type, A_Time, A_Action, A_Date FROM Attendance WHERE A_Date = '" & MetroDateTime1.Text & "'", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview2(ListView2, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub
End Class