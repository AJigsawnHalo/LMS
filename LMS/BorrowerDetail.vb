
Imports System
Imports System.IO.Ports

Public Class BorrowerDetail


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


    Private Sub CustomerDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call readDataW()
        ArduinoConnect()


    End Sub
    Sub readDataW()
        MetroListView1.Columns.Add("RFID", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Name", 140, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Address", 140, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Contact Number", 120, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("User type", 120, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Activation Date", 120, HorizontalAlignment.Center)

        MetroListView1.View = View.Details
    End Sub
    Sub readData()
        MetroListView1.Columns.Add("Barcode ID", 90, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Name", 140, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Address", 140, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Contact Number", 120, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("User type", 120, HorizontalAlignment.Center)
        MetroListView1.Columns.Add("Activation Date", 120, HorizontalAlignment.Center)

        MetroListView1.View = View.Details
        Try

            If (objcon.State = ConnectionState.Closed) Then objcon.Open()
            com = New OleDb.OleDbCommand("SELECT * FROM Borrowers", objcon)
            dr = com.ExecuteReader
            While dr.Read()
                Call adddatatolistview(MetroListView1, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
            End While
            dr.Close()
            objcon.Close()
        Catch
            'MsgBox("Please Refresh", MsgBoxStyle.Information, "")
        End Try
    End Sub
    Public Sub adddatatolistview(ByVal lvw As ListView,
                                 ByVal B_ID As String,
                                 ByVal B_Name As String,
                                 ByVal B_Address As String,
                                 ByVal B_ContactNumber As String,
                                 ByVal B_Type As String,
                                 ByVal B_ActiveDate As String)
        Dim lv As New ListViewItem
        lvw.Items.Add(lv)
        lv.Text = B_ID
        lv.SubItems.Add(B_Name)
        lv.SubItems.Add(B_Address)
        lv.SubItems.Add(B_ContactNumber)
        lv.SubItems.Add(B_Type)
        lv.SubItems.Add(B_ActiveDate)

    End Sub




    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        MetroListView1.SelectedItems.Clear()
        TextBox1.Focus()
        Try
            If Me.TextBox1.Text = "" Then

            Else
                For i = 0 To MetroListView1.Items.Count - 1
                    If TextBox1.Text = MetroListView1.Items(i).SubItems(0).Text Then
                        MetroListView1.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch

        End Try
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Call readData()
        Else
            MetroListView1.Clear()
            MetroListView1.Columns.Add("RFID", 90, HorizontalAlignment.Center)
            MetroListView1.Columns.Add("Name", 140, HorizontalAlignment.Center)
            MetroListView1.Columns.Add("Address", 140, HorizontalAlignment.Center)
            MetroListView1.Columns.Add("Contact Number", 120, HorizontalAlignment.Center)
            MetroListView1.Columns.Add("User type", 120, HorizontalAlignment.Center)
            MetroListView1.Columns.Add("Activation Date", 120, HorizontalAlignment.Center)

            MetroListView1.View = View.Details
            Try

                If (objcon.State = ConnectionState.Closed) Then objcon.Open()
                com = New OleDb.OleDbCommand("SELECT * FROM Borrowers WHERE B_ID='" & TextBox1.Text & "'", objcon)
                dr = com.ExecuteReader
                While dr.Read()
                    Call adddatatolistview(MetroListView1, dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                End While
                dr.Close()
                objcon.Close()
            Catch

            End Try
        End If
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        SerialPort2.Close()
        LibraryMainForm.Show()
        Me.Close()
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        'If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
        '    MessageBox.Show("Please use ")
        '    e.Handled = True
        'End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        receivedData = ReceiveSerialData()
        TextBox1.Text &= receivedData
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click

    End Sub
End Class