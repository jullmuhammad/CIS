Public Class MasterUser
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien As DataTable
    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class