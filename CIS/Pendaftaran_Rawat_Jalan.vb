Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class Pendaftaran_Rawat_Jalan
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable
    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Sub formatdate()
        ' Contoh: di Form Load atau setelah inisialisasi
        dtTglDaftar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglDaftar.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"

        dtTglDaftar.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglDaftar.Properties.EditFormat.FormatString = "dd-MMM-yyyy HH:mm"

        dtTglDaftar.Properties.Mask.EditMask = "dd-MMM-yyyy HH:mm"
        dtTglDaftar.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub
    Private Sub Pendaftaran_Rawat_Jalan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTglDaftar.EditValue = Date.Now

        formatdate()

        combopasien()
        masterpoliklinik()
        masterdokter()
        mastercarabayar()
        masterkamar()
        data()
    End Sub

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

        Commandku.CommandText = "sp_Pendaftaran"

        Dim id = Trim(lblid.Text)
        Dim noreg = Trim(txtNodaftar.Text)
        Dim tgldaftar = dtTglDaftar.DateTime
        Dim jenislayanan = Trim(cmbJenisLayanan.Text)
        Dim pasienid = Trim(cmbPasienID.Text)
        Dim poliklinik = Trim(cmbPoliklinik.Text)
        Dim dokter = Trim(cmbDokter.Text)
        Dim carabayar = Trim(cmbCaraBayar.Text)
        Dim nojkn = Trim(txtNoJKN.Text)
        Dim keluhan = Trim(mmoKeluhan.Text)
        Dim diagnosa = Trim(mmoDiagnosa.Text)
        Dim kamarid = Trim(cmbKamar.Text)
        Dim caramasuk = Trim(cmbCaraMasuk.Text)
        Dim asalrujukan = Trim(txtAsalRujukan.Text)
        Dim statuskunjungan = Trim(txtStatusKunjungan.Text)
        Dim tglpulang = DBNull.Value

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@nopendaftaran", noreg)
        Commandku.Parameters.AddWithValue("@tgldaftar", tgldaftar)
        Commandku.Parameters.AddWithValue("@jenislayanan", jenislayanan)
        Commandku.Parameters.AddWithValue("@pasienid", pasienid)
        Commandku.Parameters.AddWithValue("@poliklinikid", poliklinik)
        Commandku.Parameters.AddWithValue("@dokterid", dokter)
        Commandku.Parameters.AddWithValue("@carabayar", carabayar)
        Commandku.Parameters.AddWithValue("@nokartujkn", nojkn)
        Commandku.Parameters.AddWithValue("@keluhan", keluhan)
        Commandku.Parameters.AddWithValue("@diagnosa", diagnosa)
        Commandku.Parameters.AddWithValue("@kamarid", kamarid)
        Commandku.Parameters.AddWithValue("@caramasuk", caramasuk)
        Commandku.Parameters.AddWithValue("@asalrujukan", asalrujukan)
        Commandku.Parameters.AddWithValue("@statuskunjungan", statuskunjungan)
        Commandku.Parameters.AddWithValue("@tglpulang", tglpulang)
        Commandku.Parameters.AddWithValue("@userid", userid)
        Commandku.Parameters.AddWithValue("@pc", shostname)
        Commandku.Parameters.AddWithValue("@aksi", aksi)

        Dim outMsg As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@message", SqlDbType.VarChar, 60)
        outMsg.Direction = ParameterDirection.Output

        Dim OutSTS As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@status", SqlDbType.VarChar, 150)
        OutSTS.Direction = ParameterDirection.Output

        Dim idOut As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@idOut", SqlDbType.VarChar, 150)
        idOut.Direction = ParameterDirection.Output

        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If Trim(OutSTS.Value.ToString) = "OK" Then
            Cursor.Current = Cursors.Default
            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            data()
            txtNodaftar.Text = idOut.Value.ToString
            'clear()

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
                                           ,[JenisLayanan]
                                          ,a.[PasienID] 
										  ,psn.NamaLengkap NamaPasien
                                          ,a.[PoliklinikID] 
										  ,pol.NamaPoliklinik
                                          ,a.[DokterID]
										  ,dr.Nama NamaDokter
                                          ,[CaraBayar]
                                          ,[NoKartuJKN]
                                          ,[Keluhan]
                                          ,[Diagnosa]
                                          ,a.[KamarID]
                                          ,kmr.KodeKamar
                                          ,kmr.NamaKamar
                                          ,[CaraMasuk]
                                          ,[AsalRujukan]
                                          ,[StatusKunjungan]
                                          ,a.[CreatedAt]
                                          ,a.[UserCreated]
                                          ,a.[PC]
                                      FROM [db_klinik].[dbo].[T_Pendaftaran] a
									  left join [dbo].[M_Pasien] psn
									  on psn.ID=a.PasienID
									  left join [dbo].[M_Poliklinik] pol
									  on pol.PoliklinikID=a.PoliklinikID
									  left join [dbo].[M_Dokter] dr
									  on dr.ID=a.DokterID
                                      left join [dbo].[M_Kamar] kmr
                                      on kmr.[KamarID]=a.[KamarID]
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
            Dim kamarid As GridColumn = gridView1.Columns("KamarID")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            tgl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            tgl.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            id.Visible = False
            pasien.Visible = False
            polid.Visible = False
            dokid.Visible = False
            kamarid.Visible = False

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
        dtTglDaftar.EditValue = Date.Now
        cmbJenisLayanan.SelectedIndex = -1
        cmbPasienID.Text = String.Empty
        txtPasien.Text = String.Empty
        cmbPoliklinik.Text = String.Empty
        txtPoliklinik.Text = String.Empty
        cmbDokter.Text = String.Empty
        txtDokter.Text = String.Empty
        cmbCaraBayar.Text = String.Empty
        txtNoJKN.Text = String.Empty
        mmoKeluhan.Text = String.Empty
        mmoDiagnosa.Text = String.Empty
        cmbKamar.EditValue = String.Empty
        cmbKamar.Text = String.Empty
        cmbCaraMasuk.Text = String.Empty
        txtAsalRujukan.Text = String.Empty
        txtStatusKunjungan.Text = "Terdaftar"

    End Sub

    Private Sub cmbPoliklinik_EditValueChanged(sender As Object, e As EventArgs) Handles cmbPoliklinik.EditValueChanged
        getnamapoliklinik()
    End Sub

    Sub combopasien()

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

    Private Sub cmbJenisLayanan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisLayanan.SelectedIndexChanged
        Dim jenlay = Trim(cmbJenisLayanan.Text)

        If jenlay = "Rawat Jalan" Then
            cmbKamar.Properties.ReadOnly = True
            cmbCaraMasuk.Properties.ReadOnly = True
            txtAsalRujukan.Properties.ReadOnly = True
        ElseIf jenlay = "Rawat Inap" Then
            cmbKamar.Properties.ReadOnly = False
            cmbCaraMasuk.Properties.ReadOnly = True
            txtAsalRujukan.Properties.ReadOnly = True
        Else
            cmbKamar.Properties.ReadOnly = True
            cmbCaraMasuk.Properties.ReadOnly = False
            txtAsalRujukan.Properties.ReadOnly = False
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnTambahPasien_Click(sender As Object, e As EventArgs) Handles btnTambahPasien.Click
        MasterPasien.Show()
        MasterPasien.BringToFront()
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

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Dim nodaftar = Trim(txtNodaftar.Text)
        nyieunbarcodeheula(nodaftar)
    End Sub

    Sub gridtotext()
        Try
            lblid.Text = GridViewData.GetFocusedRowCellValue("ID").ToString
            txtNodaftar.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString
            cmbJenisLayanan.Text = GridViewData.GetFocusedRowCellValue("JenisLayanan").ToString
            dtTglDaftar.Text = GridViewData.GetFocusedRowCellValue("TanggalDaftar").ToString
            cmbPasienID.Text = GridViewData.GetFocusedRowCellValue("PasienID").ToString
            txtPasien.Text = GridViewData.GetFocusedRowCellValue("NamaPasien").ToString
            cmbPoliklinik.Text = GridViewData.GetFocusedRowCellValue("PoliklinikID").ToString
            txtPoliklinik.Text = GridViewData.GetFocusedRowCellValue("NamaPoliklinik").ToString
            cmbDokter.Text = GridViewData.GetFocusedRowCellValue("DokterID").ToString
            txtDokter.Text = GridViewData.GetFocusedRowCellValue("NamaDokter").ToString
            cmbCaraBayar.Text = GridViewData.GetFocusedRowCellValue("CaraBayar").ToString
            txtNoJKN.Text = GridViewData.GetFocusedRowCellValue("NoKartuJKN").ToString
            mmoKeluhan.Text = GridViewData.GetFocusedRowCellValue("Keluhan").ToString
            mmoDiagnosa.Text = GridViewData.GetFocusedRowCellValue("Diagnosa").ToString
            cmbKamar.Text = GridViewData.GetFocusedRowCellValue("KodeKamar").ToString
            cmbCaraMasuk.Text = GridViewData.GetFocusedRowCellValue("CaraMasuk").ToString
            txtAsalRujukan.Text = GridViewData.GetFocusedRowCellValue("AsalRujukan").ToString
            txtStatusKunjungan.Text = GridViewData.GetFocusedRowCellValue("StatusKunjungan").ToString

        Catch ex As Exception

        End Try
    End Sub
    Sub ceknodaftar()
        If txtNodaftar.Text = "" Then
            btnCetak.Enabled = False
            btnHapus.Enabled = False
        Else
            btnCetak.Enabled = True
            btnHapus.Enabled = True
        End If
    End Sub
    Private Sub txtNodaftar_EditValueChanged(sender As Object, e As EventArgs) Handles txtNodaftar.EditValueChanged
        ceknodaftar()
    End Sub

    Sub masterkamar()

        tblKamar = Proses.ExecuteQuery("SELECT KodeKamar,NamaKamar,Ruang,Kelas  FROM [db_klinik].[dbo].[M_Kamar]")

        cmbKamar.Properties.DataSource = tblKamar
        cmbKamar.Properties.ValueMember = "KodeKamar"
        cmbKamar.Properties.DisplayMember = "KodeKamar"
        cmbKamar.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbKamar.Properties.AutoSearchColumnIndex = 1
        cmbKamar.Properties.SearchMode = SearchMode.AutoSearch
        cmbKamar.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbKamar.Properties.CaseSensitiveSearch = True
        cmbKamar.Properties.NullText = ""

    End Sub
    Sub nyieunbarcodeheula(nodaftar As String)
        Dim filepath = Application.StartupPath & "\Images\" & nodaftar & ".png"
        BarCodeControl1.AutoModule = True
        BarCodeControl1.Text = nodaftar

        If File.Exists(filepath) Then
            File.Delete(filepath)
        End If

        Using bmp As New Bitmap(BarCodeControl1.Width, BarCodeControl1.Height)
            BarCodeControl1.DrawToBitmap(bmp, New Rectangle(0, 0, BarCodeControl1.Width, BarCodeControl1.Height))
            bmp.Save(filepath, ImageFormat.Png)
        End Using

        exceltanpainterop(nodaftar)
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            If obj IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub
    Function InsertPicture(ByVal FName As String, ByVal Where As Microsoft.Office.Interop.Excel.Range,
  Optional ByVal LinkToFile As Boolean = False,
  Optional ByVal SaveWithDocument As Boolean = True,
  Optional ByVal LockAspectRatio As Boolean = True) As Microsoft.Office.Interop.Excel.Shape
        'Inserts the picture file FName as link or permanently into Where
        Dim S As Microsoft.Office.Interop.Excel.Shape
        'Dim SaveScreenUpdating, SaveCursor
        'SaveCursor = Application.Cursor
        'SaveScreenUpdating = Application.ScreenUpdating
        'Application.Cursor = xlWait
        'Application.ScreenUpdating = False
        With Where
            'Insert in original size
            S = Where.Parent.Shapes.AddPicture(
              FName, LinkToFile, SaveWithDocument, .Left, .Top, -1, -1)
            'Keep the proportions?
            S.LockAspectRatio = LockAspectRatio
            'Scale it to fit the cell
            S.Width = .Width
            If S.Height > .Height Or Not LockAspectRatio Then S.Height = .Height
        End With
        InsertPicture = S
        'Application.Cursor = SaveCursor
        'Application.ScreenUpdating = SaveScreenUpdating
    End Function
    Sub exceltanpainterop(nodaftar As String)
        Dim excelApp As Object = Nothing
        Dim workbook As Object = Nothing
        Dim worksheet As Object = Nothing
        Dim filepath = Application.StartupPath & "\Images\" & nodaftar & ".png"
        Try
            excelApp = CreateObject("Excel.Application")
            Dim templatepath As String = Application.StartupPath & "\Template\Tiket_Registrasi.xlt"
#Disable Warning BC42017
            workbook = excelApp.Workbooks.Open(templatepath)
            worksheet = workbook.Sheets(1)

            tblDokter = Proses.ExecuteQuery("SELECT [NoPendaftaran]
                                                  ,convert(date,[TanggalDaftar],113) Tgl
	                                              ,convert(time,[TanggalDaftar],113) Jam
                                                  ,[PasienID]
	                                              ,b.NamaLengkap Pasien
                                                  ,c.NamaPoliklinik
                                                  ,[DokterID]
                                                  ,d.Nama Dokter
                                                  ,convert(varchar(12),b.TanggalLahir,113) TTL
	                                              ,DATEDIFF(hour,TanggalLahir,GETDATE())/8766 Umur
                                              FROM [db_klinik].[dbo].[T_Pendaftaran] a
                                              left join [dbo].[M_Pasien] b
                                              on b.ID=a.PasienID
                                              left join [dbo].[M_Poliklinik] c
                                              on c.PoliklinikID=a.PoliklinikID
                                               left join [dbo].[M_Dokter] d
                                               on d.ID=a.DokterID
                                               where a.NoPendaftaran='" & nodaftar & "'")
            ' 2. Isi data ke template
            With worksheet

                If tblDokter.Rows.Count = 0 Then

                Else
                    ' Contoh isi data
                    .Range("A5").Value = Trim(tblDokter.Rows(0).Item("Tgl").ToString)
                    .Range("E5").Value = Trim(tblDokter.Rows(0).Item("Jam").ToString)
                    .Range("A6").Value = Trim(tblDokter.Rows(0).Item("Pasien").ToString) & " (" & Trim(tblDokter.Rows(0).Item("PasienID").ToString) & ")"
                    .Range("A7").Value = Trim(tblDokter.Rows(0).Item("TTL").ToString) & " / " & Trim(tblDokter.Rows(0).Item("Umur").ToString) & " tahun"
                    .Range("A13").Value = nodaftar
                    .Range("A15").Value = Trim(tblDokter.Rows(0).Item("NamaPoliklinik").ToString)
                    .Range("A16").Value = Trim(tblDokter.Rows(0).Item("Dokter").ToString)
                    ' ... isi data lainnya
                    If File.Exists(filepath) Then
                        InsertPicture(filepath, .Range("A" & CStr(8) & ":F" & CStr(12)))


                    End If
                End If

            End With


            ' 3. Setting printer dan langsung cetak
            'excelWorksheet.PrintOut(
            '    Copies:=1,
            '    Preview:=False,
            '    ActivePrinter:="Nama Printer Anda", ' Ganti dengan nama printer
            '    Collate:=True)
            worksheet.PrintOut(1, 1, 1, False) ' Print langsung

            excelApp.Visible = False
            excelApp.DisplayAlerts = False
            ' 4. Tutup tanpa menyimpan perubahan
            workbook.Close(SaveChanges:=False)
            excelApp.Quit()


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' 5. Bersihkan COM Object
            ReleaseObject(worksheet)
            ReleaseObject(workbook)
            ReleaseObject(excelApp)
        End Try
#Enable Warning BC42017
    End Sub
End Class