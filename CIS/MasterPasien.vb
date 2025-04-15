Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class MasterPasien
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien As DataTable
    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Sub PROSESPROC()
        If Trim(txtNIK.Text) = "" Then MsgBox("NIK harus diisi!") : Exit Sub

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

        Commandku.CommandText = "sp_Master_Pasien"

        Dim id = Trim(txtIDPasien.Text)
        Dim nik = Trim(txtNIK.Text)
        Dim nama = Trim(txtNamaLengkap.Text)
        Dim gender = Trim(cmbGender.Text)
        Dim tgllahir = Trim(dtTglLahir.Text)
        Dim tempat = Trim(txtTempatLahir.Text)
        Dim alamat = Trim(mmoAlamat.Text)
        Dim phone = Trim(txtPhone.Text)
        Dim goldarah = Trim(cmbGoldarah.Text)
        Dim pekerjaan = Trim(cmbPekerjaan.Text)
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@nik", nik)
        Commandku.Parameters.AddWithValue("@namalengkap", nama)
        Commandku.Parameters.AddWithValue("@gender", gender)
        Commandku.Parameters.AddWithValue("@tgllahir", tgllahir)
        Commandku.Parameters.AddWithValue("@tempatlahir", tempat)
        Commandku.Parameters.AddWithValue("@alamat", alamat)
        Commandku.Parameters.AddWithValue("@phone", phone)
        Commandku.Parameters.AddWithValue("@goldarah", goldarah)
        Commandku.Parameters.AddWithValue("@pekerjaan", pekerjaan)
        Commandku.Parameters.AddWithValue("@sts", stts)
        Commandku.Parameters.AddWithValue("@userid", userid)
        Commandku.Parameters.AddWithValue("@pc", shostname)
        Commandku.Parameters.AddWithValue("@aksi", aksi)



        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

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
    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT [ID]
                                          ,[NIK]
                                          ,[NamaLengkap]
                                          ,[Gender]
                                          ,convert(varchar(12),[TanggalLahir],113) TanggalLahir
                                          ,[Tempat]
                                          ,[Alamat]
                                          ,[Phone]
                                          ,[GolDarah]
                                          ,[Pekerjaan]
                                          ,[Status]
                                          ,[Foto]
                                          ,[CreatedAt]
                                          ,[UserCreated]
                                          ,[PC]
                                          ,[DateUpdated]
                                      FROM [db_klinik].[dbo].[M_Pasien]
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim coluserid As GridColumn = gridView1.Columns("ID")
            Dim colnik As GridColumn = gridView1.Columns("NIK")
            Dim colnama As GridColumn = gridView1.Columns("NamaLengkap")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")
            Dim updated As GridColumn = gridView1.Columns("DateUpdated")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            updated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            updated.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            coluserid.Fixed = FixedStyle.Left
            colnik.Fixed = FixedStyle.Left
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

    Private Sub MasterPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
        cmbStatus.SelectedIndex = 0
        combopekerjaan()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtIDPasien.Text) = "" Then
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

    Sub clear()
        txtIDPasien.Text = String.Empty
        txtNIK.Text = String.Empty
        txtNamaLengkap.Text = String.Empty
        cmbGender.SelectedIndex = -1
        txtTempatLahir.Text = String.Empty
        dtTglLahir.Text = ""
        mmoAlamat.Text = String.Empty
        txtPhone.Text = String.Empty
        cmbGoldarah.SelectedIndex = -1
        cmbPekerjaan.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1
    End Sub
    Sub combopekerjaan()
        cmbPekerjaan.Properties.Items.Clear()
        Call Proses.OpenConn()
        Dim str As String
        str = "SELECT [Pekerjaan]  FROM [db_klinik].[dbo].[M_Pekerjaan]"
        Proses.Cmd = New OleDb.OleDbCommand(str, Proses.Cn)
        Proses.Rd = Proses.Cmd.ExecuteReader
        If Proses.Rd.HasRows Then
            Do While Proses.Rd.Read
                cmbPekerjaan.Properties.Items.Add(Proses.Rd("Pekerjaan").ToString)

            Loop
        Else
        End If

    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotxt()
    End Sub

    Sub gridtotxt()
        Try
            txtIDPasien.Text = GridViewData.GetFocusedRowCellValue("ID").ToString
            txtNIK.Text = GridViewData.GetFocusedRowCellValue("NIK").ToString
            txtNamaLengkap.Text = GridViewData.GetFocusedRowCellValue("NamaLengkap").ToString
            cmbGender.Text = GridViewData.GetFocusedRowCellValue("Gender").ToString
            dtTglLahir.Text = GridViewData.GetFocusedRowCellValue("TanggalLahir").ToString
            txtTempatLahir.Text = GridViewData.GetFocusedRowCellValue("Tempat").ToString
            mmoAlamat.Text = GridViewData.GetFocusedRowCellValue("Alamat").ToString
            txtPhone.Text = GridViewData.GetFocusedRowCellValue("Phone").ToString
            cmbGoldarah.Text = GridViewData.GetFocusedRowCellValue("GolDarah").ToString
            cmbPekerjaan.Text = GridViewData.GetFocusedRowCellValue("Pekerjaan").ToString
            cmbStatus.Text = GridViewData.GetFocusedRowCellValue("Status").ToString
        Catch ex As Exception

        End Try
    End Sub
End Class