Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class ResepObat
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable
    Public aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(lbliddetail.Text) = "" Then
            aksi = "I"
            DetailProc()
        Else
            aksi = "U"
            DetailProc()
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
            DetailProc()
        End If
    End Sub

    Private Sub ResepObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboobat()
        combosatuan()
        data()
        dtTglResep.EditValue = Date.Now

        ' Contoh: di Form Load atau setelah inisialisasi
        dtTglResep.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglResep.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"

        dtTglResep.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglResep.Properties.EditFormat.FormatString = "dd-MMM-yyyy HH:mm"

        dtTglResep.Properties.Mask.EditMask = "dd-MMM-yyyy HH:mm"
        dtTglResep.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub

    Private Sub cmbKodeObat_EditValueChanged(sender As Object, e As EventArgs) Handles cmbKodeObat.EditValueChanged
        getnamaobat()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Sub HeaderProc()
        If Trim(Pelayanan_Poliklinik.txtIDPelayanan.Text) = "" Then MsgBox("Pilih pelayanan mana yang akan ditambahkan resep!") : Exit Sub
        'If Trim(txtIDResep.Text) = "" Then MsgBox("Silahkan Buat Resep terlebih dahulu!") : Exit Sub

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

        Commandku.CommandText = "sp_Resep_Obat_H"

        Dim id = Trim(txtIDResep.Text)
        Dim idpel = Trim(txtIDPelayanan.Text)
        Dim tglresep = dtTglResep.DateTime
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@idresep", id)
        Commandku.Parameters.AddWithValue("@idpelayanan", idpel)
        Commandku.Parameters.AddWithValue("@tglresep", tglresep)
        Commandku.Parameters.AddWithValue("@stts", stts)
        Commandku.Parameters.AddWithValue("@userid", userid)
        Commandku.Parameters.AddWithValue("@pc", shostname)
        Commandku.Parameters.AddWithValue("@aksi", aksi)

        Dim outMsg As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@message", SqlDbType.VarChar, 60)
        outMsg.Direction = ParameterDirection.Output

        Dim OutSTS As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@status", SqlDbType.VarChar, 150)
        OutSTS.Direction = ParameterDirection.Output

        Dim OutId As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@idout", SqlDbType.VarChar, 150)
        OutId.Direction = ParameterDirection.Output

        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If Trim(OutSTS.Value.ToString) = "OK" Then
            Cursor.Current = Cursors.Default

            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If aksi = "I" Then
                txtIDResep.Text = Trim(OutId.Value.ToString)

            End If
            'Data()
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

    Private Sub btnTambahResep_Click(sender As Object, e As EventArgs) Handles btnTambahResep.Click
        If txtIDResep.Text = "" Then

            aksi = "I"
            HeaderProc()
        Else
            aksi = "U"
            HeaderProc()
        End If
    End Sub

    Sub DetailProc()
        If Trim(txtIDResep.Text) = "" Then MsgBox("Pilih resep mana yang akan ditambahkan obat!") : Exit Sub

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

        Commandku.CommandText = "sp_Resep_Obat_D"

        Dim iddtl = Trim(lbliddetail.Text)
        Dim idresep = Trim(txtIDResep.Text)
        Dim kdobat = Trim(cmbKodeObat.Text)
        Dim namaobat = Trim(txtNamaObat.Text)
        Dim dosis = Trim(txtDosis.Text)
        Dim jml = Val(txtJumlah.Text)
        Dim satuan = Trim(cmbSatuan.Text)
        Dim aturanpake = Trim(txtAturanPakai.Text)
        Dim ket = Trim(txtKet.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@iddetail", iddtl)
        Commandku.Parameters.AddWithValue("@idresep", idresep)
        Commandku.Parameters.AddWithValue("@kodeobat", kdobat)
        Commandku.Parameters.AddWithValue("@namaobat", namaobat)
        Commandku.Parameters.AddWithValue("@dosis", dosis)
        Commandku.Parameters.AddWithValue("@jml", jml)
        Commandku.Parameters.AddWithValue("@satuan", satuan)
        Commandku.Parameters.AddWithValue("@aturanpake", aturanpake)
        Commandku.Parameters.AddWithValue("@ket", ket)
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
            'Data()
            'clear()
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

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Sub clear()

        lbliddetail.Text = String.Empty
        cmbKodeObat.Text = String.Empty
        cmbKodeObat.EditValue = String.Empty
        txtNamaObat.Text = String.Empty
        txtDosis.Text = String.Empty
        txtJumlah.Text = "0"
        cmbSatuan.SelectedIndex = -1
        txtAturanPakai.Text = String.Empty
        txtKet.Text = String.Empty
    End Sub
    Sub comboobat()

        tblPasien = Proses.ExecuteQuery("SELECT [KodeBarang] KodeObat,[NamaBarang] NamaObat  FROM [db_klinik].[dbo].[M_Barang] where Jenis='Obat' and Stok>0")

        cmbKodeObat.Properties.DataSource = tblPasien
        cmbKodeObat.Properties.ValueMember = "KodeObat"
        cmbKodeObat.Properties.DisplayMember = "KodeObat"
        cmbKodeObat.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbKodeObat.Properties.AutoSearchColumnIndex = 1
        cmbKodeObat.Properties.SearchMode = SearchMode.AutoSearch
        cmbKodeObat.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbKodeObat.Properties.CaseSensitiveSearch = True
        cmbKodeObat.Properties.NullText = ""

    End Sub
    Sub getnamaobat()
        Dim kodeobat = Trim(cmbKodeObat.Text)
        Dim tblobat As DataTable = Proses.ExecuteQuery("SELECT [KodeBarang] KodeObat,[NamaBarang] NamaObat, Satuan  FROM [db_klinik].[dbo].[M_Barang] where KodeBarang='" & kodeobat & "'")

        If tblobat.Rows.Count = 0 Then
            txtNamaObat.Text = ""
        Else
            txtNamaObat.Text = Trim(tblobat.Rows(0).Item("NamaObat").ToString)
            cmbSatuan.Text = Trim(tblobat.Rows(0).Item("Satuan").ToString)
        End If
    End Sub
    Sub combosatuan()
        cmbSatuan.Properties.Items.Clear()
        Call Proses.OpenConn()
        Dim str As String
        str = "SELECT  [KodeSatuan] + ' - ' + [Satuan] Satuan  FROM [db_klinik].[dbo].[M_Satuan]"
        Proses.Cmd = New OleDb.OleDbCommand(str, Proses.Cn)
        Proses.Rd = Proses.Cmd.ExecuteReader
        If Proses.Rd.HasRows Then
            Do While Proses.Rd.Read
                cmbSatuan.Properties.Items.Add(Proses.Rd("Satuan").ToString)

            Loop
        Else
        End If

    End Sub
    Sub data()
        Dim resepid = Trim(txtIDResep.Text)
        tblPasien = Proses.ExecuteQuery("SELECT [IDDetail]
                                          ,[IDResep]
                                          ,[KodeObat]
                                          ,[NamaObat]
                                          ,[Dosis]
                                          ,[Jumlah]
                                          ,[Satuan]
                                          ,[AturanPakai]
                                          ,[Keterangan]
                                          ,[CreatedAt]
                                          ,[PC]
                                      FROM [db_klinik].[dbo].[T_ResepObat_Detail]
                                      where IDResep='" & resepid & "'")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim id As GridColumn = gridView1.Columns("IDDetail")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")

            id.Visible = False
            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm:ss"
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
    Sub gridtotext()
        Try
            lbliddetail.Text = GridViewData.GetFocusedRowCellValue("IDDetail").ToString
            cmbKodeObat.Text = GridViewData.GetFocusedRowCellValue("KodeObat").ToString
            cmbKodeObat.EditValue = GridViewData.GetFocusedRowCellValue("KodeObat").ToString
            txtNamaObat.Text = GridViewData.GetFocusedRowCellValue("NamaObat").ToString
            txtDosis.Text = GridViewData.GetFocusedRowCellValue("Dosis").ToString
            txtJumlah.Text = GridViewData.GetFocusedRowCellValue("Jumlah").ToString
            cmbSatuan.Text = GridViewData.GetFocusedRowCellValue("Satuan").ToString
            txtAturanPakai.Text = GridViewData.GetFocusedRowCellValue("AturanPakai").ToString
            txtKet.Text = GridViewData.GetFocusedRowCellValue("Keterangan").ToString
        Catch ex As Exception

        End Try
    End Sub
End Class