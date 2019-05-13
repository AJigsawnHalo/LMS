Public Class AllBorrowed

    Private Sub ViewCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call readData()
    End Sub
    Sub readData()
        ListView1.Clear()
        ListView1.Columns.Add("", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 310, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 190, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 90, HorizontalAlignment.Center)
        ListView1.Columns.Add("", 100, HorizontalAlignment.Center)
        ListView1.GridLines = True
        ListView1.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Books WHERE status='Borrowed'", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview(ListView1, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub
    Public Sub adddatatolistview(ByVal lvw As ListView, ByVal BookID As String, ByVal GroupID As String, ByVal BookName As String, ByVal Publisher As String, ByVal Author As String, ByVal PubYear As String, ByVal edi As String, ByVal st As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = BookID
        lv.SubItems.Add(GroupID)
        lv.SubItems.Add(BookName)
        lv.SubItems.Add(Publisher)
        lv.SubItems.Add(Author)
        lv.SubItems.Add(PubYear)
        lv.SubItems.Add(edi)
        lv.SubItems.Add(st)
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        LibraryMainForm.Show()
        Me.Close()

    End Sub
End Class