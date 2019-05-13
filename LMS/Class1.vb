
Module Class1
    Public objcon As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\DataBase\LibraryData.mdb")
    Public com As OleDb.OleDbCommand
    Public com2 As OleDb.OleDbCommand
    Public com3 As OleDb.OleDbCommand
    Public com4 As OleDb.OleDbCommand

    Public com5 As OleDb.OleDbCommand
    Public com6 As OleDb.OleDbCommand
    Public com7 As OleDb.OleDbCommand
    Public dr As OleDb.OleDbDataReader
    Public dr2 As OleDb.OleDbDataReader
End Module
