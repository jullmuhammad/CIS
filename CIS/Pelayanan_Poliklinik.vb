Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class Pelayanan_Poliklinik
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable
    Dim aksi As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtIDPelayanan.Text) = "" Then
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        CariPendaftaran.ShowDialog()
        CariPendaftaran.BringToFront()
    End Sub

    Private Sub btnObat_Click(sender As Object, e As EventArgs) Handles btnObat.Click
        If txtIDPelayanan.Text = "" Then MsgBox("Pilih dulu pelayanannya, baru bisa resep obat!") : Exit Sub

        ResepObat.txtIDPelayanan.Text = txtIDPelayanan.Text

        Dim tblCekData As DataTable = Proses.ExecuteQuery("SELECT  [IDResep]
                                                          ,[IDPelayanan]
                                                          ,[TanggalResep]
                                                          ,[UserResep]
                                                          ,[Status]
                                                       FROM [db_klinik].[dbo].[T_ResepObat] 
                                                      where [IDPelayanan]='" & txtIDPelayanan.Text & "'")
        If tblCekData.Rows.Count = 0 Then
            ResepObat.txtIDResep.Text = ""
            ResepObat.dtTglResep.EditValue = Date.Now
            ResepObat.cmbStatus.Text = ""
        Else
            ResepObat.txtIDResep.Text = tblCekData.Rows(0).Item("IDResep").ToString
            ResepObat.dtTglResep.EditValue = tblCekData.Rows(0).Item("TanggalResep").ToString
            ResepObat.cmbStatus.Text = tblCekData.Rows(0).Item("Status").ToString
        End If
        'ResepObat.aksi = "I"
        'ResepObat.HeaderProc()
        ResepObat.ShowDialog()
        ResepObat.BringToFront()
    End Sub

    Dim shostname As String = System.Net.Dns.GetHostName

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Private Sub btnTindakan_Click(sender As Object, e As EventArgs) Handles btnTindakan.Click
        If txtIDPelayanan.Text = "" Then MsgBox("Pilih dulu pelayanannya, baru bisa tindakan!") : Exit Sub

        TindakanPelayanan.txtIDPelayanan.Text = txtIDPelayanan.Text
        TindakanPelayanan.ShowDialog()
        TindakanPelayanan.BringToFront()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Pelayanan_Poliklinik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTglPeriksa.EditValue = Date.Now

        ' Contoh: di Form Load atau setelah inisialisasi
        dtTglPeriksa.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglPeriksa.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"

        dtTglPeriksa.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglPeriksa.Properties.EditFormat.FormatString = "dd-MMM-yyyy HH:mm"

        dtTglPeriksa.Properties.Mask.EditMask = "dd-MMM-yyyy HH:mm"
        dtTglPeriksa.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub
    Sub PROSESPROC()
        If Trim(txtNoPendaftaran.Text) = "" Then MsgBox("Pilih No Pendaftaran yang dimaksud!") : Exit Sub

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

        Commandku.CommandText = "sp_PelayananPoli"

        Dim id = Trim(txtIDPelayanan.Text)
        Dim noreg = Trim(txtNoPendaftaran.Text)
        Dim tglperiksa = dtTglPeriksa.DateTime
        Dim jenislayanan = Trim(txtJenisDaftar.Text)
        Dim poliklinik = Trim(txtPoliklinikID.Text)
        Dim dokter = Trim(txtDokterID.Text)
        Dim keluhan = Trim(mmoKeluhan.Text)
        Dim pemriksaanfisik = Trim(mmoPemeriksaanFisik.Text)
        Dim diagnosa = Trim(mmoDiagnosa.Text)
        Dim tindakan = Trim(mmoTindakan.Text)
        Dim saran = Trim(mmoSaran.Text)
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id ", id)
        Commandku.Parameters.AddWithValue("@nopendaftaran ", noreg)
        Commandku.Parameters.AddWithValue("@jenisdaftar ", jenislayanan)
        Commandku.Parameters.AddWithValue("@tglperiksa", tglperiksa)
        Commandku.Parameters.AddWithValue("@poliklinikid ", poliklinik)
        Commandku.Parameters.AddWithValue("@dokterid ", dokter)
        Commandku.Parameters.AddWithValue("@keluhan ", keluhan)
        Commandku.Parameters.AddWithValue("@pemeriksaanfisik ", pemriksaanfisik)
        Commandku.Parameters.AddWithValue("@diagnosa ", diagnosa)
        Commandku.Parameters.AddWithValue("@tindakan ", tindakan)
        Commandku.Parameters.AddWithValue("@saran ", saran)
        Commandku.Parameters.AddWithValue("@statuskunjungan ", stts)
        Commandku.Parameters.AddWithValue("@userid", userid)
        Commandku.Parameters.AddWithValue("@pc", shostname)
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
    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT [IDPelayanan]
                                                  ,[NoPendaftaran]
                                                  ,[JenisDaftar]
                                                  ,[TanggalPeriksa]
                                                  ,[PoliID]
                                                  ,[DokterID]
                                                  ,[Keluhan]
                                                  ,[PemeriksaanFisik]
                                                  ,[Diagnosa]
                                                  ,[Tindakan]
                                                  ,[Saran]
                                                  ,[StatusSelesai]
                                                  ,a.[CreatedAt]
                                                  ,a.[UserCreated]
                                                  ,a.[PC]
                                                  ,a.[LastUpdated]
                                              FROM [db_klinik].[dbo].[T_PelayananPoli] a
                                       where StatusSelesai=0
									   and NoPendaftaran='" & Trim(txtNoPendaftaran.Text) & "'
                                        order by TanggalPeriksa desc
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            'Dim id As GridColumn = gridView1.Columns("ID")
            'Dim noreg As GridColumn = gridView1.Columns("NoPendaftaran")
            Dim tgl As GridColumn = gridView1.Columns("TanggalPeriksa")
            'Dim pasien As GridColumn = gridView1.Columns("PasienID")
            'Dim namapasien As GridColumn = gridView1.Columns("NamaPasien")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")
            'Dim polid As GridColumn = gridView1.Columns("PoliklinikID")
            'Dim dokid As GridColumn = gridView1.Columns("DokterID")
            'Dim kamarid As GridColumn = gridView1.Columns("KamarID")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            tgl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            tgl.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            'id.Visible = False
            'pasien.Visible = False
            'polid.Visible = False
            'dokid.Visible = False
            'kamarid.Visible = False

            'noreg.Fixed = FixedStyle.Left
            'tgl.Fixed = FixedStyle.Left
            'namapasien.Fixed = FixedStyle.Left

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
    Sub clear()
        txtIDPelayanan.Text = String.Empty
        txtNoPendaftaran.Text = String.Empty
        dtTglPeriksa.EditValue = Date.Now
        txtNoPendaftaran.Text = String.Empty
        txtPoliklinikID.Text = String.Empty
        txtDokterID.Text = String.Empty
        mmoKeluhan.Text = String.Empty
        mmoPemeriksaanFisik.Text = String.Empty
        mmoDiagnosa.Text = String.Empty
        mmoTindakan.Text = String.Empty
        mmoSaran.Text = String.Empty
        cmbStatus.Text = String.Empty

    End Sub
    Sub gridtotext()
        Try
            txtIDPelayanan.Text = GridViewData.GetFocusedRowCellValue("IDPelayanan").ToString
            txtNoPendaftaran.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString
            txtJenisDaftar.Text = GridViewData.GetFocusedRowCellValue("JenisDaftar").ToString
            dtTglPeriksa.Text = GridViewData.GetFocusedRowCellValue("TanggalPeriksa").ToString
            txtPoliklinikID.Text = GridViewData.GetFocusedRowCellValue("PoliID").ToString
            txtDokterID.Text = GridViewData.GetFocusedRowCellValue("DokterID").ToString
            mmoKeluhan.Text = GridViewData.GetFocusedRowCellValue("Keluhan").ToString
            mmoPemeriksaanFisik.Text = GridViewData.GetFocusedRowCellValue("PemeriksaanFisik").ToString
            mmoDiagnosa.Text = GridViewData.GetFocusedRowCellValue("Diagnosa").ToString
            mmoTindakan.Text = GridViewData.GetFocusedRowCellValue("Tindakan").ToString
            mmoSaran.Text = GridViewData.GetFocusedRowCellValue("Saran").ToString

            If GridViewData.GetFocusedRowCellValue("StatusSelesai").ToString = "False" Then
                cmbStatus.Text = "Proses"
            Else
                cmbStatus.Text = "Selesai"
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class