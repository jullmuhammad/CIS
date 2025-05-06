Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Public Class MasterTindakan
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien As DataTable
    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName

    Private Sub MasterTindakan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
    End Sub

    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT    [TindakanID]
                                                  ,[KodeTindakan]
                                                  ,[NamaTindakan]
                                                  ,[Kategori]
                                                  ,[Tarif]
                                                  ,[Satuan]
                                                  ,[Keterangan]
                                                  ,[StatusAktif]
                                                  ,[UserCreated]
                                                  ,[CreatedAt]
                                              FROM [db_klinik].[dbo].[M_Tindakan]")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim id As GridColumn = gridView1.Columns("TindakanID")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            id.Visible = False
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

        Commandku.CommandText = "sp_Master_Tindakan"

        Dim id = Trim(lblid.Text)
        Dim kodetdk = Trim(txtKodeTindakan.Text)
        Dim nama = Trim(txtNama.Text)
        Dim kategori = Trim(txtKategori.Text)
        Dim tarif = Val(txtTarif.Text)
        Dim satuan = Trim(txtSatuan.Text)
        Dim ket = Trim(mmoKet.Text)
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@kodetindakan", kodetdk)
        Commandku.Parameters.AddWithValue("@namatindakan", nama)
        Commandku.Parameters.AddWithValue("@kategori", kategori)
        Commandku.Parameters.AddWithValue("@tarif", tarif)
        Commandku.Parameters.AddWithValue("@satuan", satuan)
        Commandku.Parameters.AddWithValue("@ket", ket)
        Commandku.Parameters.AddWithValue("@sts", stts)
        Commandku.Parameters.AddWithValue("@userid", userid)
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If lblid.Text = "" Then
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

    Sub clear()
        lblid.Text = String.Empty
        txtKodeTindakan.Text = String.Empty
        txtNama.Text = String.Empty
        txtKategori.Text = String.Empty
        txtTarif.Text = String.Empty
        txtSatuan.Text = String.Empty
        mmoKet.Text = String.Empty
        cmbStatus.SelectedIndex = -1
    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Sub gridtotext()
        Try
            tblPasien = Proses.ExecuteQuery("SELECT    [TindakanID]
                                                  ,[KodeTindakan]
                                                  ,[NamaTindakan]
                                                  ,[Kategori]
                                                  ,[Tarif]
                                                  ,[Satuan]
                                                  ,[Keterangan]
                                                  ,[StatusAktif]
                                                  ,[UserCreated]
                                                  ,[CreatedAt]
                                              FROM [db_klinik].[dbo].[M_Tindakan]")

            lblid.Text = GridViewData.GetFocusedRowCellValue("TindakanID").ToString
            txtKodeTindakan.Text = GridViewData.GetFocusedRowCellValue("KodeTindakan").ToString
            txtNama.Text = GridViewData.GetFocusedRowCellValue("NamaTindakan").ToString
            txtKategori.Text = GridViewData.GetFocusedRowCellValue("Kategori").ToString
            txtTarif.Text = GridViewData.GetFocusedRowCellValue("Tarif").ToString
            txtSatuan.Text = GridViewData.GetFocusedRowCellValue("Satuan").ToString
            mmoKet.Text = GridViewData.GetFocusedRowCellValue("Keterangan").ToString
            If GridViewData.GetFocusedRowCellValue("StatusAktif").ToString = "1" Then
                cmbStatus.Text = "Aktif"
            Else
                cmbStatus.Text = "Nonaktif"
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class