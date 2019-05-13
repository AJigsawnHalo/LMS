Public Class BookDetail
  
    Private Sub BookDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  
        ' MetroTabControl2.Visible = False

        Call readData()
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



    Sub readData()
        MetroListView2.Clear()
        MetroListView2.Columns.Add("Book Barcode", 160, HorizontalAlignment.Left)
        MetroListView2.Columns.Add("Group ID", 160, HorizontalAlignment.Center)
        MetroListView2.Columns.Add("Book Name", 210, HorizontalAlignment.Center)
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
        LibraryMainForm.Show()
        Me.Close()
    End Sub


End Class