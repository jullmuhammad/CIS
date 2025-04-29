Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports System.Reflection

Public Class Login
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser As DataTable
    Dim type As String
    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform
    Dim connStringP, connStringS, connStringDB As String
    Dim connStringhasilencryp As String
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Trim(txtUserid.Text) = "" Then MsgBox("Isi User ID") : Exit Sub


        If ckLupa.Checked Then
            'FormSendPwd.lblnik.Text = Trim(txtUserid.Text)
            'FormSendPwd.isi()
            'FormSendPwd.ShowDialog()

        Else
            If Trim(txtUserid.Text) = "" Then txtUserid.Focus() : Exit Sub
            If Trim(txtPassword.Text) = "" Then MsgBox("Isi Password") : Exit Sub
            LoginProg()
        End If
    End Sub
    Sub LoginProg()


        Cursor.Current = Cursors.WaitCursor


        Dim shostname, user As String
        shostname = System.Net.Dns.GetHostName
        user = SystemInformation.UserName



        Dim P, S, DB As String
        P = Trim(lblP.Text)
        DB = Trim(lblDB.Text)
        S = Trim(lblS.Text)

        Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
        Dim Database As New SqlClient.SqlConnection(connectionString)
        Database.Open()
        ' ----- Membuat command dasar
        Dim Commandku As New SqlClient.SqlCommand()
        Commandku.CommandType = CommandType.StoredProcedure
        Commandku.Connection = Database

        Commandku.CommandText = "sp_LoginUser"

        Commandku.Parameters.AddWithValue("@userid", Trim(txtUserid.Text))
        Commandku.Parameters.AddWithValue("@password", Encrypt(Trim(txtPassword.Text)))


        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@status", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output

        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()

        ' Eksekusi perintah dan ambil reader untuk result set
        Dim reader As SqlClient.SqlDataReader = Commandku.ExecuteReader()

        ' Variabel untuk menyimpan hasil user info
        Dim username As String = ""
        Dim email As String = ""
        Dim role As String = ""

        ' Kalau ada data user dikembalikan
        If reader.HasRows Then
            While reader.Read()
                username = reader("Username").ToString()
                email = reader("Email").ToString()
                role = reader("Role").ToString()
            End While
        End If
        reader.Close()
        If outParamSts.Value.ToString = "OK" Then
            Cursor.Current = Cursors.Default

            FormMenu.txtUserID.Caption = Trim(txtUserid.Text)
            FormMenu.txtUsername.Caption = Trim(username)
            FormMenu.txtRole.Caption = Trim(role)
            FormMenu.lblemail.Text = Trim(email)
            'FormMenu.lblip.Text = lblip.Text
            'FormMenu.lblfolder.Text = lblfolder.Text
            'FormMenu.menuaktif()
            'Me.Dispose()
            'FormMenu.menulist()
            FormMenu.Show()
            FormMenu.BringToFront()
            FormMenu.WindowState = FormWindowState.Maximized
            Me.Hide()

            Cursor.Current = Cursors.Default

        ElseIf outParamSts.Value.ToString = "NG" Then
            Cursor.Current = Cursors.Default

            If Trim(outParam.Value.ToString) = "Password salah" Then
                MessageBox.Show("" & Trim(outParam.Value.ToString) & "", "Login gagal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPassword.Focus()
                txtPassword.Properties.AppearanceFocused.BackColor = Color.MistyRose
            Else
                MessageBox.Show("" & Trim(outParam.Value.ToString) & "", "Login gagal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPassword.Properties.AppearanceFocused.BackColor = Color.Transparent
            End If

            'MessageBox.Show(Trim(outParam.Value.ToString), "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()


    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cekrun()

        Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        symmetricKey.Padding = PaddingMode.PKCS7

        Me.enc = New System.Text.UTF8Encoding
        Me.encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)
        Me.decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)
        'bege()
        callenc()
        getConnStringSer()
        getConnStringDB()
        txtPassword.Properties.AppearanceFocused.BackColor = Color.Transparent
        'TestEncryptDecrypt()
        Debug.Print(Encrypt("SurindoAdmin@"))

    End Sub
    Sub TestEncryptDecrypt()
        Dim plainText As String = "ammar49"

        ' Key dan IV sama seperti kamu
        Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111,
                             31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}

        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}

        Dim rijAlg As New RijndaelManaged()
        rijAlg.Mode = CipherMode.CBC
        rijAlg.Padding = PaddingMode.PKCS7

        Dim encryptor = rijAlg.CreateEncryptor(KEY_128, IV_128)
        Dim decryptor = rijAlg.CreateDecryptor(KEY_128, IV_128)

        ' ENKRIPSI
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(plainText)
        Dim ms As New MemoryStream()
        Dim cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
        cs.Write(bytes, 0, bytes.Length)
        cs.FlushFinalBlock()
        Dim cipherText = Convert.ToBase64String(ms.ToArray())

        Console.WriteLine("Encrypted: " & cipherText)

        ' DEKRIPSI
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Dim ms2 As New MemoryStream(cipherBytes)
        Dim cs2 As New CryptoStream(ms2, decryptor, CryptoStreamMode.Read)
        Dim decryptedBytes(255) As Byte
        Dim count = cs2.Read(decryptedBytes, 0, decryptedBytes.Length)
        Dim decryptedText = Encoding.UTF8.GetString(decryptedBytes, 0, count)

        Console.WriteLine("Decrypted: " & decryptedText)
    End Sub
    Sub callenc()
        getConnStringpASS()
        Dim cypherTextBytes As Byte() = Convert.FromBase64String(connStringP)
        Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, Me.decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes(cypherTextBytes.Length) As Byte
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        Me.lblP.Text = Me.enc.GetString(plainTextBytes, 0, decryptedByteCount)


    End Sub
    Sub getConnStringDB()
        Try
            Dim readFile As IO.TextReader = New StreamReader(Application.StartupPath & "\configDB.zip")
            connStringDB = readFile.ReadToEnd()
            readFile.Close()
            readFile = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' connStringhasilencryp = Decrypt(connString)
        lblDB.Text = connStringDB
    End Sub
    Sub getConnStringpASS()
        Try
            Dim readFile As IO.TextReader = New StreamReader(Application.StartupPath & "\configP.zip")
            connStringP = readFile.ReadToEnd()
            readFile.Close()
            readFile = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' connStringhasilencryp = Decrypt(connString)

    End Sub
    Sub getConnStringSer()
        Try
            Dim readFile As IO.TextReader = New StreamReader(Application.StartupPath & "\configS.zip")
            connStringS = readFile.ReadToEnd()
            readFile.Close()
            readFile = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' connStringhasilencryp = Decrypt(connString)
        lblS.Text = connStringS
    End Sub
    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Private Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Private Sub txtUserid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserid.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{tab}")
    End Sub

    Public Function checkInstance() As Process
        Dim cProcess As Process = Process.GetCurrentProcess()
        Dim aProcesses() As Process = Process.GetProcessesByName(cProcess.ProcessName)
        'loop through all the processes that are currently running on the
        'system that have the same name
        For Each process As Process In aProcesses
            'Ignore the currently running process
            If process.Id <> cProcess.Id Then
                'Check if the process is running using the same EXE as this one
                If Assembly.GetExecutingAssembly().Location = cProcess.MainModule.FileName Then
                    'if so return the process
                    Return process
                End If
            End If
        Next
        'if nothing was found then this is the only instance, so return null
        Return Nothing
    End Function
    Sub cekrun()
        If checkInstance() Is Nothing Then

        Else
            MessageBox.Show("Application is Running")
            Me.Dispose()
            Me.Close()
        End If
    End Sub
End Class