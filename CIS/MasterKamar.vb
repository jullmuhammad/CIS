Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Public Class MasterKamar
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien As DataTable
    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub MasterKamar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
    End Sub

    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT [KamarID]
                                                  ,[KodeKamar]
                                                  ,[NamaKamar]
                                                  ,[Ruang]
                                                  ,[Kelas]
                                                  ,[TarifPerHari]
                                                  ,[Kapasitas]
                                                  ,[Terisi]
                                                  ,[StatusAktif]
                                                  ,[Keterangan]
                                                  ,[CreatedAt]
                                                  ,[UserCreated]
                                                  ,[PC]
                                              FROM [db_klinik].[dbo].[M_Kamar]")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim id As GridColumn = gridView1.Columns("KamarID")
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
        If Trim(txtNamaKamar.Text) = "" Then MsgBox("Nama harus diisi!") : Exit Sub

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

        Commandku.CommandText = "sp_Master_Kamar"

        Dim id = Trim(lblid.Text)
        Dim kodekamar = Trim(txtKodeKamar.Text)
        Dim nama = Trim(txtNamaKamar.Text)
        Dim ruang = Trim(txtRuang.Text)
        Dim kelas = Trim(cmbKelas.Text)
        Dim tarif = Val(txtTarif.Text)
        Dim kapasitas = Val(numKapasitas.Text)
        Dim terisi = Val(numTerisi.Text)
        Dim ket = Trim(mmoKet.Text)
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@kodekamar", kodekamar)
        Commandku.Parameters.AddWithValue("@namakamar", nama)
        Commandku.Parameters.AddWithValue("@ruang", ruang)
        Commandku.Parameters.AddWithValue("@kelas", kelas)
        Commandku.Parameters.AddWithValue("@tarif", tarif)
        Commandku.Parameters.AddWithValue("@kapasitas", tarif)
        Commandku.Parameters.AddWithValue("@terisi", terisi)
        Commandku.Parameters.AddWithValue("@sts", stts)
        Commandku.Parameters.AddWithValue("@ket", ket)
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
        txtKodeKamar.Text = String.Empty
        txtNamaKamar.Text = String.Empty
        txtRuang.Text = String.Empty
        txtTarif.Text = String.Empty
        numKapasitas.Text = 0
        numTerisi.Text = 0
        mmoKet.Text = String.Empty
        cmbKelas.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1
    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Sub gridtotext()
        Try
            tblPasien = Proses.ExecuteQuery("SELECT [KamarID]
                                                  ,[KodeKamar]
                                                  ,[NamaKamar]
                                                  ,[Ruang]
                                                  ,[Kelas]
                                                  ,[TarifPerHari]
                                                  ,[Kapasitas]
                                                  ,[Terisi]
                                                  ,[StatusAktif]
                                                  ,[Keterangan]
                                                  ,[CreatedAt]
                                                  ,[UserCreated]
                                                  ,[PC]
                                              FROM [db_klinik].[dbo].[M_Kamar]")

            lblid.Text = GridViewData.GetFocusedRowCellValue("KamarID").ToString
            txtKodeKamar.Text = GridViewData.GetFocusedRowCellValue("KodeKamar").ToString
            txtNamaKamar.Text = GridViewData.GetFocusedRowCellValue("NamaKamar").ToString
            txtRuang.Text = GridViewData.GetFocusedRowCellValue("Ruang").ToString
            cmbKelas.Text = GridViewData.GetFocusedRowCellValue("Kelas").ToString
            txtTarif.Text = GridViewData.GetFocusedRowCellValue("TarifPerHari").ToString
            numKapasitas.Text = GridViewData.GetFocusedRowCellValue("Kapasitas").ToString
            numTerisi.Text = GridViewData.GetFocusedRowCellValue("Terisi").ToString
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