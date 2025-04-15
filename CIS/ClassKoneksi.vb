Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Public Class ClassKoneksi
    Public SQL As String
    Public Cn As OleDb.OleDbConnection
    Public Cmd As OleDb.OleDbCommand
    Public Da As OleDb.OleDbDataAdapter
    Public Rd As OleDb.OleDbDataReader
    Public Ds As DataSet
    Public Dt As DataTable
    Dim connString As String
    Dim connStringhasilencryp As String
    Dim P, S, DB As String
    Public Function OpenConn() As Boolean
        P = Trim(Login.lblP.Text)
        DB = Trim(Login.lblDB.Text)
        S = Trim(Login.lblS.Text)
        Cn = New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=" & S & ";Persist Security Info=True;Password=" & P & ";User ID=sa;Initial Catalog=" & DB & ";")

        Cn.Open()
        If Cn.State <> ConnectionState.Open Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub CloseConn()
        If Not IsNothing(Cn) Then
            Cn.Close()
            Cn = Nothing
        End If
    End Sub
    Public Function ExecuteQuery(ByVal Query As String) As DataTable
        If Not OpenConn() Then
            MsgBox("Connection Failed...!!", MsgBoxStyle.Critical, "Access Failed")
            Return Nothing
            Exit Function
        End If

        Cmd = New OleDb.OleDbCommand(Query, Cn)
        Cmd.CommandTimeout = 10000 ' number of seconds
        Da = New OleDb.OleDbDataAdapter
        Da.SelectCommand = Cmd

        Ds = New Data.DataSet
        Da.Fill(Ds)

        Dt = Ds.Tables(0)
        Return Dt
        Dt = Nothing
        Ds = Nothing
        Da = Nothing
        Cmd = Nothing
        CloseConn()
    End Function
    Public Sub ExecuteNonQuery(ByVal Query As String)
        If Not OpenConn() Then
            MsgBox("Koneksi Gagal..!!", MsgBoxStyle.Critical, "Access Failed..!!")
            Exit Sub
        End If

        Cmd = New OleDb.OleDbCommand
        Cmd.Connection = Cn
        Cmd.CommandTimeout = 10000
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Query

        Cmd.ExecuteNonQuery()
        Cmd = Nothing
        CloseConn()
    End Sub
End Class
