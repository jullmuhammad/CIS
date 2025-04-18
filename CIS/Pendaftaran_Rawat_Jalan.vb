Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class Pendaftaran_Rawat_Jalan
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter As DataTable
    Dim aksi As String

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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Pendaftaran_Rawat_Jalan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtJamDaftar.Text = Date.Now
        masterpasien()
        masterpoliklinik()
        masterdokter()
        mastercarabayar()
        data()
    End Sub

    Dim shostname As String = System.Net.Dns.GetHostName
    Sub PROSESPROC()
        If Trim(cmbPasienID.Text) = "" Then MsgBox("Pilih pasien yang akan didaftarkan!") : Exit Sub

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

        Commandku.CommandText = "sp_Pendaftaran_RawatJalan"

        Dim id = Trim(lblid.Text)
        Dim noreg = Trim(txtNodaftar.Text)
        Dim pasienid = Trim(cmbPasienID.Text)
        Dim poliklinik = Trim(cmbPoliklinik.Text)
        Dim dokter = Trim(cmbDokter.Text)
        Dim carabayar = Trim(cmbCaraBayar.Text)
        Dim nojkn = Trim(txtNoJKN.Text)
        Dim keluhan = Trim(mmoKeluhan.Text)
        Dim statuskunjungan = Trim(txtStatusKunjungan.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@nopendaftaran", noreg)
        Commandku.Parameters.AddWithValue("@pasienid", pasienid)
        Commandku.Parameters.AddWithValue("@poliklinikid", poliklinik)
        Commandku.Parameters.AddWithValue("@dokterid", dokter)
        Commandku.Parameters.AddWithValue("@carabayar", carabayar)
        Commandku.Parameters.AddWithValue("@nokartujkn", nojkn)
        Commandku.Parameters.AddWithValue("@keluhan", keluhan)
        Commandku.Parameters.AddWithValue("@statuskunjungan", statuskunjungan)
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

    Private Sub cmbPasienID_EditValueChanged(sender As Object, e As EventArgs) Handles cmbPasienID.EditValueChanged
        getnamapasien()
    End Sub

    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT a.[ID]
                                          ,[NoPendaftaran]
                                          ,[TanggalDaftar]
                                          ,a.[PasienID] 
										  ,psn.NamaLengkap NamaPasien
                                          ,a.[PoliklinikID] 
										  ,pol.NamaPoliklinik
                                          ,a.[DokterID]
										  ,dr.Nama NamaDokter
                                          ,[CaraBayar]
                                          ,[NoKartuJKN]
                                          ,[Keluhan]
                                          ,[StatusKunjungan]
                                          ,a.[CreatedAt]
                                          ,a.[UserCreated]
                                          ,a.[PC]
                                      FROM [db_klinik].[dbo].[T_Pendaftaran_RawatJalan] a
									  left join [dbo].[M_Pasien] psn
									  on psn.ID=a.PasienID
									  left join [dbo].[M_Poliklinik] pol
									  on pol.PoliklinikID=a.PoliklinikID
									  left join [dbo].[M_Dokter] dr
									  on dr.ID=a.DokterID
                                       where StatusKunjungan='Terdaftar'
                                        order by TanggalDaftar desc
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim id As GridColumn = gridView1.Columns("ID")
            Dim noreg As GridColumn = gridView1.Columns("NoPendaftaran")
            Dim tgl As GridColumn = gridView1.Columns("TanggalDaftar")
            Dim pasien As GridColumn = gridView1.Columns("PasienID")
            Dim namapasien As GridColumn = gridView1.Columns("NamaPasien")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")
            Dim polid As GridColumn = gridView1.Columns("PoliklinikID")
            Dim dokid As GridColumn = gridView1.Columns("DokterID")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            tgl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            tgl.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            id.Visible = False
            pasien.Visible = False
            polid.Visible = False
            dokid.Visible = False

            noreg.Fixed = FixedStyle.Left
            tgl.Fixed = FixedStyle.Left
            namapasien.Fixed = FixedStyle.Left

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
        lblid.Text = String.Empty
        txtNodaftar.Text = String.Empty
        cmbPasienID.Text = String.Empty
        txtPasien.Text = String.Empty
        cmbPoliklinik.Text = String.Empty
        txtPoliklinik.Text = String.Empty
        cmbDokter.Text = String.Empty
        txtDokter.Text = String.Empty
        cmbCaraBayar.Text = String.Empty
        txtNoJKN.Text = String.Empty
        mmoKeluhan.Text = String.Empty
        txtStatusKunjungan.Text = "Terdaftar"
    End Sub

    Private Sub cmbPoliklinik_EditValueChanged(sender As Object, e As EventArgs) Handles cmbPoliklinik.EditValueChanged
        getnamapoliklinik()
    End Sub

    Sub masterpasien()

        tblPasien = Proses.ExecuteQuery("SELECT [ID],[NIK],[NamaLengkap],[TanggalLahir]  FROM [db_klinik].[dbo].[M_Pasien]  where Status='Aktif'")

        cmbPasienID.Properties.DataSource = tblPasien
        cmbPasienID.Properties.ValueMember = "ID"
        cmbPasienID.Properties.DisplayMember = "ID"
        cmbPasienID.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbPasienID.Properties.AutoSearchColumnIndex = 1
        cmbPasienID.Properties.SearchMode = SearchMode.AutoSearch
        cmbPasienID.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbPasienID.Properties.CaseSensitiveSearch = True
        cmbPasienID.Properties.NullText = ""

    End Sub

    Private Sub cmbDokter_EditValueChanged(sender As Object, e As EventArgs) Handles cmbDokter.EditValueChanged
        getnamadokter()
    End Sub

    Sub getnamapasien()
        Dim pasienid = Trim(cmbPasienID.Text)
        Dim tblDtlPasien As DataTable

        tblDtlPasien = Proses.ExecuteQuery("SELECT [NamaLengkap]  FROM [db_klinik].[dbo].[M_Pasien] where ID='" & pasienid & "'")

        If tblDtlPasien.Rows.Count = 0 Then
            txtPasien.Text = ""
        Else
            txtPasien.Text = tblDtlPasien.Rows(0).Item("NamaLengkap").ToString
        End If

    End Sub
    Sub masterpoliklinik()

        tblPoli = Proses.ExecuteQuery("SELECT [PoliklinikID],[KodePoli],[NamaPoliklinik]  
                                        FROM [db_klinik].[dbo].[M_Poliklinik]  where StatusAktif=1")

        cmbPoliklinik.Properties.DataSource = tblPoli
        cmbPoliklinik.Properties.ValueMember = "PoliklinikID"
        cmbPoliklinik.Properties.DisplayMember = "PoliklinikID"
        cmbPoliklinik.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbPoliklinik.Properties.AutoSearchColumnIndex = 1
        cmbPoliklinik.Properties.SearchMode = SearchMode.AutoSearch
        cmbPoliklinik.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbPoliklinik.Properties.CaseSensitiveSearch = True
        cmbPoliklinik.Properties.NullText = ""

    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Sub getnamapoliklinik()
        Dim poliid = Trim(cmbPoliklinik.Text)

        Dim tblDetailPoli As DataTable

        tblDetailPoli = Proses.ExecuteQuery("SELECT [PoliklinikID],[KodePoli],[NamaPoliklinik]  
                                        FROM [db_klinik].[dbo].[M_Poliklinik]
                                        where PoliklinikID='" & poliid & "'")

        If tblDetailPoli.Rows.Count = 0 Then
            txtPoliklinik.Text = ""
        Else
            txtPoliklinik.Text = tblDetailPoli.Rows(0).Item("NamaPoliklinik").ToString
        End If
    End Sub
    Sub masterdokter()

        tblDokter = Proses.ExecuteQuery("SELECT  [ID]
                                              ,[KodeDokter]
                                              ,[Nama]
                                              ,[Spesialis]
                                          FROM [db_klinik].[dbo].[M_Dokter]
                                          where Status='Aktif'")

        cmbDokter.Properties.DataSource = tblDokter
        cmbDokter.Properties.ValueMember = "ID"
        cmbDokter.Properties.DisplayMember = "ID"
        cmbDokter.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbDokter.Properties.AutoSearchColumnIndex = 1
        cmbDokter.Properties.SearchMode = SearchMode.AutoSearch
        cmbDokter.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbDokter.Properties.CaseSensitiveSearch = True
        cmbDokter.Properties.NullText = ""

    End Sub
    Sub getnamadokter()
        Dim dktrid = Trim(cmbDokter.Text)

        Dim tblDetailDr As DataTable

        tblDetailDr = Proses.ExecuteQuery("SELECT  [ID]
                                              ,[KodeDokter]
                                              ,[Nama]
                                              ,[Spesialis]
                                          FROM [db_klinik].[dbo].[M_Dokter]
                                          where Status='Aktif' and ID='" & dktrid & "'")

        If tblDetailDr.Rows.Count = 0 Then
            txtDokter.Text = ""
        Else
            txtDokter.Text = tblDetailDr.Rows(0).Item("Nama").ToString
        End If
    End Sub
    Sub mastercarabayar()

        tblCaraBayar = Proses.ExecuteQuery("SELECT [NamaBayar]
                                                  ,[Keterangan]
                                              FROM [db_klinik].[dbo].[M_CaraBayar]
                                              where Status=1")

        cmbCaraBayar.Properties.DataSource = tblCaraBayar
        cmbCaraBayar.Properties.ValueMember = "NamaBayar"
        cmbCaraBayar.Properties.DisplayMember = "NamaBayar"
        cmbCaraBayar.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbCaraBayar.Properties.AutoSearchColumnIndex = 1
        cmbCaraBayar.Properties.SearchMode = SearchMode.AutoSearch
        cmbCaraBayar.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbCaraBayar.Properties.CaseSensitiveSearch = True
        cmbCaraBayar.Properties.NullText = ""

    End Sub
    Sub gridtotext()
        Try
            lblid.Text = GridViewData.GetFocusedRowCellValue("ID").ToString
            txtNodaftar.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString
            txtJamDaftar.Text = GridViewData.GetFocusedRowCellValue("TanggalDaftar").ToString
            cmbPasienID.Text = GridViewData.GetFocusedRowCellValue("PasienID").ToString
            txtPasien.Text = GridViewData.GetFocusedRowCellValue("NamaPasien").ToString
            cmbPoliklinik.Text = GridViewData.GetFocusedRowCellValue("PoliklinikID").ToString
            txtPoliklinik.Text = GridViewData.GetFocusedRowCellValue("NamaPoliklinik").ToString
            cmbDokter.Text = GridViewData.GetFocusedRowCellValue("DokterID").ToString
            txtDokter.Text = GridViewData.GetFocusedRowCellValue("NamaDokter").ToString
            cmbCaraBayar.Text = GridViewData.GetFocusedRowCellValue("CaraBayar").ToString
            txtNoJKN.Text = GridViewData.GetFocusedRowCellValue("NoKartuJKN").ToString
            mmoKeluhan.Text = GridViewData.GetFocusedRowCellValue("Keluhan").ToString
            txtStatusKunjungan.Text = GridViewData.GetFocusedRowCellValue("StatusKunjungan").ToString

        Catch ex As Exception

        End Try
    End Sub
End Class