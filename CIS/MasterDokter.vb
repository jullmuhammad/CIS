Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class MasterDokter
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien As DataTable
    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub MasterDokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
        combospesialis()
    End Sub
    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT [ID]
                                              ,[KodeDokter]
                                              ,[Nama]
                                              ,[Spesialis]
                                              ,[Gender]
                                              ,[Alamat]
                                              ,[Phone]
                                              ,[SIP]
                                              ,[Status]
                                              ,[Foto]
                                              ,[CreatedAt]
                                              ,[UserCreated]
                                              ,[PC]
                                              ,[LastUpdated]
                                          FROM [db_klinik].[dbo].[M_Dokter]")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim coluserid As GridColumn = gridView1.Columns("ID")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")
            Dim updated As GridColumn = gridView1.Columns("LastUpdated")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            updated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            updated.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            coluserid.Visible = False
            'coluserid.Fixed = FixedStyle.Left
            'colnik.Fixed = FixedStyle.Left
            'colnama.Fixed = FixedStyle.Left
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
    Sub PROSESPROC()
        If Trim(txtNama.Text) = "" Then MsgBox("Nama harus diisi!") : Exit Sub

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

        Commandku.CommandText = "sp_Master_Dokter"

        Dim id = Trim(txtIDDokter.Text)
        Dim kodedokter = Trim(txtKodeDokter.Text)
        Dim nama = Trim(txtNama.Text)
        Dim spesialis = Trim(cmbSpesialis.Text)
        Dim gender = Trim(cmbGender.Text)
        Dim alamat = Trim(mmoAlamat.Text)
        Dim phone = Trim(txtPhone.Text)
        Dim sip = Trim(txtSIP.Text)
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@kodedokter", kodedokter)
        Commandku.Parameters.AddWithValue("@nama", nama)
        Commandku.Parameters.AddWithValue("@spesialis", spesialis)
        Commandku.Parameters.AddWithValue("@gender", gender)
        Commandku.Parameters.AddWithValue("@alamat", alamat)
        Commandku.Parameters.AddWithValue("@phone", phone)
        Commandku.Parameters.AddWithValue("@sip", sip)
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Sub clear()
        txtIDDokter.Text = String.Empty
        txtKodeDokter.Text = String.Empty
        txtNama.Text = String.Empty
        cmbSpesialis.SelectedIndex = -1
        cmbGender.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1
        mmoAlamat.Text = String.Empty
        txtPhone.Text = String.Empty
        txtSIP.Text = String.Empty
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtIDDokter.Text = "" Then
            aksi = "I"
            PROSESPROC()
        Else
            aksi = "U"
            PROSESPROC()
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        ' Tampilkan pesan konfirmasi
        Dim result As DialogResult = XtraMessageBox.Show("Apakah Anda yakin ingin menghapus data ini?",
                                                     "Konfirmasi Hapus",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)

        ' Cek hasil konfirmasi
        If result = DialogResult.Yes Then
            ' Lakukan proses penghapusan data
            aksi = "D"
            PROSESPROC()
        End If
    End Sub

    Sub combospesialis()
        cmbSpesialis.Properties.Items.Clear()
        Call Proses.OpenConn()
        Dim str As String
        str = "SELECT [Spesialis]  FROM [db_klinik].[dbo].[M_Spesialis]"
        Proses.Cmd = New OleDb.OleDbCommand(str, Proses.Cn)
        Proses.Rd = Proses.Cmd.ExecuteReader
        If Proses.Rd.HasRows Then
            Do While Proses.Rd.Read
                cmbSpesialis.Properties.Items.Add(Proses.Rd("Spesialis").ToString)

            Loop
        Else
        End If

    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Sub gridtotext()
        Try

            txtIDDokter.Text = GridViewData.GetFocusedRowCellValue("ID").ToString
            txtKodeDokter.Text = GridViewData.GetFocusedRowCellValue("KodeDokter").ToString
            txtNama.Text = GridViewData.GetFocusedRowCellValue("Nama").ToString
            cmbSpesialis.Text = GridViewData.GetFocusedRowCellValue("Spesialis").ToString
            cmbGender.Text = GridViewData.GetFocusedRowCellValue("Gender").ToString
            mmoAlamat.Text = GridViewData.GetFocusedRowCellValue("Alamat").ToString
            txtPhone.Text = GridViewData.GetFocusedRowCellValue("Phone").ToString
            txtSIP.Text = GridViewData.GetFocusedRowCellValue("SIP").ToString
            cmbStatus.Text = GridViewData.GetFocusedRowCellValue("Status").ToString
        Catch ex As Exception

        End Try
    End Sub
End Class