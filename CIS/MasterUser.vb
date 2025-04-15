Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class MasterUser
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien As DataTable
    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Sub PROSESPROC()
        If Trim(txtUserid.Text) = "" Then MsgBox("User ID harus diisi!") : Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim P, S, DB As String
        P = Trim(Login.lblP.Text)
        DB = Trim(Login.lblDB.Text)
        S = Trim(Login.lblS.Text)

        Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
        Dim Database As New SqlClient.SqlConnection(connectionString)
        Database.Open()
        ' ----- Membuat command dasar
        Dim Commandku As New SqlClient.SqlCommand()
        Commandku.CommandType = CommandType.StoredProcedure
        Commandku.Connection = Database

        Commandku.CommandText = "sp_RegistrasiUser"

        Dim id = Trim(txtUserid.Text)
        Dim nama = Trim(txtUsername.Text)
        Dim pwd = Encrypt(txtPassword.Text)
        Dim email = Trim(txtEmail.Text)
        Dim role = Trim(cmbRole.Text)
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@userid", id)
        Commandku.Parameters.AddWithValue("@username", nama)
        Commandku.Parameters.AddWithValue("@Password", pwd)
        Commandku.Parameters.AddWithValue("@email", email)
        Commandku.Parameters.AddWithValue("@role", role)
        Commandku.Parameters.AddWithValue("@statusaktif", stts)
        Commandku.Parameters.AddWithValue("@aksi", aksi)


        Dim outMsg As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@message", SqlDbType.VarChar, 60)
        outMsg.Direction = ParameterDirection.Output

        Dim OutSTS As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@status", SqlDbType.VarChar, 150)
        OutSTS.Direction = ParameterDirection.Output


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If Trim(OutSTS.Value.ToString) = "OK" Then
            Cursor.Current = Cursors.Default
            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            data()
            clear()

        Else
            Cursor.Current = Cursors.Default
            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()

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
    Sub gridtotxt()
        Try
            lblid.Text = Trim(GridViewData.GetFocusedRowCellValue("UserID").ToString)
            txtUserid.Text = Trim(GridViewData.GetFocusedRowCellValue("UserID").ToString)
            txtUsername.Text = GridViewData.GetFocusedRowCellValue("Username").ToString
            txtPassword.Text = Decrypt(GridViewData.GetFocusedRowCellValue("Password").ToString)
            txtEmail.Text = GridViewData.GetFocusedRowCellValue("Email").ToString
            cmbRole.Text = GridViewData.GetFocusedRowCellValue("Role").ToString
            cmbStatus.Text = GridViewData.GetFocusedRowCellValue("StatusAktif").ToString
        Catch ex As Exception

        End Try
    End Sub
    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT [UserID]
                                          ,[Username]
                                          ,[Password]
                                          ,[Email]
                                          ,[Role]
                                          ,[StatusAktif]
                                          ,[CreatedAt]
                                          ,[LastLogin]
                                          ,[Foto]
                                      FROM [db_klinik].[dbo].[M_User_Login]
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim coluserid As GridColumn = gridView1.Columns("UserID")
            Dim colnama As GridColumn = gridView1.Columns("Username")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")
            Dim lastlogin As GridColumn = gridView1.Columns("LastLogin")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            lastlogin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            lastlogin.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            coluserid.Fixed = FixedStyle.Left
            colnama.Fixed = FixedStyle.Left
            ' Make the grid read-only.
            gridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus

            gridView1.OptionsView.ColumnAutoWidth = False
            gridView1.BestFitColumns()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(lblid.Text) = "" Then
            aksi = "I"
            PROSESPROC()
        Else
            aksi = "U"
            PROSESPROC()
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        aksi = "D"
        PROSESPROC()
    End Sub

    Private Sub MasterUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotxt()
    End Sub

    Sub clear()
        lblid.Text = String.Empty
        txtUserid.Text = String.Empty
        txtUsername.Text = String.Empty
        txtPassword.Text = String.Empty
        txtEmail.Text = String.Empty
        cmbRole.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1
    End Sub
End Class