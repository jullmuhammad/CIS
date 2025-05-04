Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Kasir
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim shostname As String = System.Net.Dns.GetHostName
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar, dtBarang As DataTable

    Private Sub GridViewData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewData.CellValueChanged
        If e.Column.FieldName = "Deskripsi" Then
            Dim kodeBarang As String = e.Value.ToString()

            Try

                ' Cari NamaBarang dari dtBarang
                Dim found() As DataRow = dtBarang.Select("Tindakan = '" & kodeBarang.Replace("'", "''") & "'")
                If found.Length > 0 Then
                    ' Update kolom NamaBarang pada baris yang sama
                    GridViewData.SetRowCellValue(e.RowHandle, "Harga", found(0)("Harga").ToString())
                    GridViewData.SetRowCellValue(e.RowHandle, "Jumlah", "1")
                Else
                    ' Kalau tidak ketemu, kosongkan
                    GridViewData.SetRowCellValue(e.RowHandle, "Harga", "0")
                    GridViewData.SetRowCellValue(e.RowHandle, "Jumlah", "0")
                    ' GridViewData.SetRowCellValue(e.RowHandle, "Stok", "")
                End If

            Catch ex As Exception

            End Try
        End If
        If e.Column.FieldName = "Jumlah" Then
            Dim jml As String = e.Value.ToString()
            Dim selectedharga As Integer = CInt(GridViewData.GetRowCellValue(e.RowHandle, "Harga"))
            If jml <> "" Then
                ' Update kolom NamaBarang pada baris yang sama
                GridViewData.SetRowCellValue(e.RowHandle, "Subtotal", (selectedharga * jml))
            Else
                ' Kalau tidak ketemu, kosongkan
                GridViewData.SetRowCellValue(e.RowHandle, "Subtotal", "0")
                ' GridViewData.SetRowCellValue(e.RowHandle, "Stok", "")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtBillingID.Text = "" Then
            aksi = "I"
            PROSESPROC()
        Else
            aksi = "U"
            PROSESPROC()
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click

        CariPendaftaranKasir.ShowDialog()
        CariPendaftaranKasir.BringToFront()
    End Sub

    Dim aksi As String
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Kasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTglBilling.EditValue = Date.Now

        ' Contoh: di Form Load atau setelah inisialisasi
        dtTglBilling.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglBilling.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy"

        dtTglBilling.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglBilling.Properties.EditFormat.FormatString = "dd-MMM-yyyy"

        dtTglBilling.Properties.Mask.EditMask = "dd-MMM-yyyy"
        dtTglBilling.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        aksi = "D"
        PROSESPROC()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintToExcelTemplate()
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

        Commandku.CommandText = "sp_Transaksi_Billing_H"

        Dim id = Trim(txtBillingID.Text)
        Dim noreg = Trim(txtNoPendaftaran.Text)
        Dim tglbill = dtTglBilling.DateTime
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@billid ", id)
        Commandku.Parameters.AddWithValue("@nopendaftaran ", noreg)
        Commandku.Parameters.AddWithValue("@tglbill ", tglbill)
        Commandku.Parameters.AddWithValue("@statuslunas ", stts)
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
        Commandku.Parameters.Add("@idout", SqlDbType.VarChar, 150)
        idOut.Direction = ParameterDirection.Output

        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If Trim(OutSTS.Value.ToString) = "OK" Then
            Cursor.Current = Cursors.Default
            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'data()
            'clear()
            If aksi = "I" Then
                txtBillingID.Text = idOut.Value.ToString
            End If

            aksi = "I"
            DetailProc()
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
        GridViewData.Columns.Clear()
        Dim nodaftar = Trim(txtNoPendaftaran.Text)
        Dim billid = Trim(txtBillingID.Text)
        tblPasien = Proses.ExecuteQuery("SELECT  b.DetailBillingID ID,a.[IDPelayanan]
                                                  ,a.[Kategori]
                                                  ,a.[Deskripsi]
                                                  ,[Jumlah]
                                                  ,a.[Harga]
                                                  ,Jumlah*a.Harga Subtotal
                                              FROM [db_klinik].[dbo].[V_Billing_Detail] a
                                              left join [dbo].[Transaksi_Billing_H] c
                                              on c.NoRegistrasi=a.NoPendaftaran
                                              left join [dbo].[Transaksi_Billing_D] b
                                              on b.IDPelayanan=a.IDPelayanan and b.BillingID=c.BillingID and b.Deskripsi=a.Deskripsi
											  where a.NoPendaftaran='" & nodaftar & "' and b.BillingID='" & billid & "'
                                              union all
                                              SELECT 
                                                    b.DetailBillingID AS ID,
                                                    b.[IDPelayanan],
                                                    b.Kategori,
                                                    b.[Deskripsi],
                                                    b.Qty,
                                                    b.[Harga],
                                                    b.Qty * b.Harga AS Subtotal
                                                FROM [dbo].[Transaksi_Billing_D] b
                                                LEFT JOIN [dbo].[Transaksi_Billing_H] c 
                                                    ON c.BillingID = b.BillingID
                                                LEFT JOIN [db_klinik].[dbo].[V_Billing_Detail] a 
                                                    ON a.IDPelayanan = b.IDPelayanan 
                                                    AND a.NoPendaftaran = c.NoRegistrasi 
                                                    AND a.Deskripsi = b.Deskripsi
                                                WHERE c.BillingID = '" & billid & "'
                                                    AND a.IDPelayanan IS NULL;")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else

            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            Dim id As GridColumn = gridView1.Columns("ID")
            Dim harga As GridColumn = gridView1.Columns("Harga")
            Dim subtotal As GridColumn = gridView1.Columns("Subtotal")

            id.Visible = False
            harga.OptionsColumn.ReadOnly = True
            subtotal.OptionsColumn.ReadOnly = True

            gridView1.Appearance.HeaderPanel.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            gridView1.Appearance.Row.Font = New Font("Segoe UI", 11, FontStyle.Regular)

            gridView1.OptionsView.ColumnAutoWidth = False
            gridView1.BestFitColumns()

            SetupRepositoryLookUpBarang()
            SetupUnboundNamaBarang()
            SetupRepositoryLookUpKategori()

            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom ' Atau Top kalau mau di atas
            'gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace ' Boleh juga pakai EditForm kalau mau popup
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True

            ' Aktifkan tampilan footer
            gridView1.OptionsView.ShowFooter = True

            ' Buat summary untuk kolom Subtotal
            Dim summaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem()
            summaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            summaryItem.DisplayFormat = "Total: {0:n0}"  ' Format ribuan tanpa desimal

            ' Set summary ke kolom Subtotal
            gridView1.Columns("Subtotal").Summary.Add(summaryItem)

            Dim colHarga As GridColumn = GridViewData.Columns("Harga")
            Dim colsubtot As GridColumn = GridViewData.Columns("Subtotal")
            colHarga.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colHarga.DisplayFormat.FormatString = "N0" ' Format angka (misal: 1.000)
            colsubtot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            colsubtot.DisplayFormat.FormatString = "N0" ' Format angka (misal: 1.000)

        End If
    End Sub
    Dim xrow As Integer = -1
    Private Sub GridControlData_MouseDown(sender As Object, e As MouseEventArgs) Handles GridControlData.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim view = TryCast(GridViewData, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo = view.CalcHitInfo(e.Location)

            If hitInfo.InRow Then
                xrow = hitInfo.RowHandle ' Simpan index row yang diklik kanan
                view.FocusedRowHandle = xrow
                ContextMenuStrip1.Show(GridControlData, e.Location)
            End If
        End If
    End Sub

    Private Sub SetupRepositoryLookUpBarang()
        ' Ambil data master barang
        dtBarang = Proses.ExecuteQuery("SELECT convert(varchar(20),[TindakanID]) + ' - ' + [NamaTindakan] Tindakan,Tarif Harga
                                        FROM [db_klinik].[dbo].[M_Tindakan]")

        ' Buat repository
        Dim repoLookupBarang As New RepositoryItemLookUpEdit()
        With repoLookupBarang
            .DataSource = dtBarang
            .DisplayMember = "Tindakan"
            .ValueMember = "Tindakan"
            .NullText = ""
            .SearchMode = SearchMode.AutoSearch
            .BestFitMode = BestFitMode.BestFit
            .HeaderClickMode = HeaderClickMode.AutoSearch
            .CaseSensitiveSearch = True

            .Columns.Add(New LookUpColumnInfo("Tindakan", "Deskripsi"))
            .Columns.Add(New LookUpColumnInfo("Harga", "Tarif"))
        End With

        ' Tambah ke grid
        GridControlData.RepositoryItems.Add(repoLookupBarang)

        ' Assign ke kolom
        Dim colKodeBarang As GridColumn = GridViewData.Columns("Deskripsi")
        colKodeBarang.ColumnEdit = repoLookupBarang
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(GridControlData.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
        If view IsNot Nothing AndAlso view.FocusedRowHandle >= 0 Then
            If xrow >= 0 Then
                aksi = "D" ' ← ini penting, agar stored procedure tahu ini penghapusan
                HapusDetailProc() ' Prosedur kamu tadi

                ' Hapus dari grid
                GridViewData.DeleteRow(xrow)
                xrow = -1 ' reset index
            End If
        End If
    End Sub

    '--- Tambah kolom NamaBarang unbound (tidak dari data utama)
    Private Sub SetupUnboundNamaBarang()
        ' Cek apakah kolom sudah ada
        If GridViewData.Columns("Harga") Is Nothing Then
            Dim colNamaBarang As New GridColumn()
            With colNamaBarang
                .FieldName = "Harga"
                .Caption = "Harga"
                .UnboundType = DevExpress.Data.UnboundColumnType.String
                .Visible = True
                .OptionsColumn.AllowEdit = False ' Biar tidak bisa diketik manual
            End With

            GridViewData.Columns.Add(colNamaBarang)
            End
        End If
    End Sub
    Private Sub SetupRepositoryLookUpKategori()
        ' Ambil data master barang
        tblRJ = Proses.ExecuteQuery("SELECT 'Tindakan' Kategori")

        ' Buat repository
        Dim repoLookupBarang As New RepositoryItemLookUpEdit()
        With repoLookupBarang
            .DataSource = tblRJ
            .DisplayMember = "Kategori"
            .ValueMember = "Kategori"
            .NullText = ""
            .SearchMode = SearchMode.AutoSearch
            .BestFitMode = BestFitMode.BestFit
            .HeaderClickMode = HeaderClickMode.AutoSearch
            .CaseSensitiveSearch = True

            .Columns.Add(New LookUpColumnInfo("Kategori", "Kategori"))
        End With

        ' Tambah ke grid
        GridControlData.RepositoryItems.Add(repoLookupBarang)

        ' Assign ke kolom
        Dim colKodeBarang As GridColumn = GridViewData.Columns("Kategori")
        colKodeBarang.ColumnEdit = repoLookupBarang
    End Sub
    Sub DetailProc()
        If txtBillingID.Text = "" Then MsgBox("Buat dulu transaksi kasirnya!") : Exit Sub

        Cursor.Current = Cursors.WaitCursor

        For x = 0 To GridViewData.RowCount - 1
            If Not IsValidRow(GridViewData, x) Then Continue For

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

            Commandku.CommandText = "sp_Transaksi_Billing_D"

            Dim id = Trim(Convert.ToString(GridViewData.GetRowCellValue(x, "ID")))
            Dim billid = Trim(txtBillingID.Text)
            Dim kategori = Trim(Convert.ToString(GridViewData.GetRowCellValue(x, "Kategori")))
            Dim deskripsi = Trim(Convert.ToString(GridViewData.GetRowCellValue(x, "Deskripsi")))
            Dim jumlah = Val(Convert.ToInt32(GridViewData.GetRowCellValue(x, "Jumlah")))
            Dim harga = Val(Convert.ToDecimal(GridViewData.GetRowCellValue(x, "Harga")))
            Dim pelayananid = Trim(Convert.ToString(GridViewData.GetRowCellValue(x, "IDPelayanan")))

            Dim userid = Trim(FormMenu.txtUserID.Caption)

            Commandku.Parameters.AddWithValue("@dtlid", id)
            Commandku.Parameters.AddWithValue("@billid", billid)
            Commandku.Parameters.AddWithValue("@kategori", kategori)
            Commandku.Parameters.AddWithValue("@deskripsi", deskripsi)
            Commandku.Parameters.AddWithValue("@qty", jumlah)
            Commandku.Parameters.AddWithValue("@harga", harga)
            Commandku.Parameters.AddWithValue("@idpelayanan", pelayananid)
            Commandku.Parameters.AddWithValue("@aksi", aksi)

            Dim outMsg As SqlClient.SqlParameter =
            Commandku.Parameters.Add("@message", SqlDbType.VarChar, 60)
            outMsg.Direction = ParameterDirection.Output

            Dim OutSTS As SqlClient.SqlParameter =
            Commandku.Parameters.Add("@status", SqlDbType.VarChar, 150)
            OutSTS.Direction = ParameterDirection.Output

            'Debug.Print("Insert Baris ke-" & x)
            'Debug.Print("ID: " & id)
            'Debug.Print("Kode: " & kodebarang)
            'Debug.Print("Nama: " & namabrg)
            'Debug.Print("Jumlah: " & jumlah)

            Commandku.CommandTimeout = 1000
            Commandku.ExecuteNonQuery()



            If Trim(OutSTS.Value.ToString) = "OK" Then
                Cursor.Current = Cursors.Default

                'XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Data()
                'clear()

            Else
                Cursor.Current = Cursors.Default
                'XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)


            End If
            ' ----- Bersih - bersih.
            Commandku = Nothing
            Database.Close()
            Database.Dispose()


        Next
        data()
    End Sub
    Sub HapusDetailProc()
        If txtBillingID.Text = "" Then MsgBox("Buat dulu transaksi kasirnya!") : Exit Sub
        Dim row = TryCast(GridViewData.GetRow(xrow), DataRowView)
        If row Is Nothing Then Exit Sub

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

        Commandku.CommandText = "sp_Transaksi_Billing_D"

        Dim id = Trim(row("ID").ToString())
        Dim billid = Trim(txtBillingID.Text)
        Dim kategori = Trim(row("Kategori").ToString())
        Dim deskripsi = Trim(row("Deskripsi").ToString())
        Dim jumlah = row("Jumlah")
        Dim harga = row("Harga")
        Dim pelayananid = Trim(row("IDPelayanan").ToString())

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@dtlid", id)
        Commandku.Parameters.AddWithValue("@billid", billid)
        Commandku.Parameters.AddWithValue("@kategori", kategori)
        Commandku.Parameters.AddWithValue("@deskripsi", deskripsi)
        Commandku.Parameters.AddWithValue("@qty", jumlah)
        Commandku.Parameters.AddWithValue("@harga", harga)
        Commandku.Parameters.AddWithValue("@idpelayanan", pelayananid)
        Commandku.Parameters.AddWithValue("@aksi", aksi)

        Dim outMsg As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@message", SqlDbType.VarChar, 60)
        outMsg.Direction = ParameterDirection.Output

        Dim OutSTS As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@status", SqlDbType.VarChar, 150)
        OutSTS.Direction = ParameterDirection.Output

        'Debug.Print("Insert Baris ke-" & x)
        'Debug.Print("ID: " & id)
        'Debug.Print("Kode: " & kodebarang)
        'Debug.Print("Nama: " & namabrg)
        'Debug.Print("Jumlah: " & jumlah)

        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If Trim(OutSTS.Value.ToString) = "OK" Then
            Cursor.Current = Cursors.Default

            'XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Data()
            'clear()

        Else
            Cursor.Current = Cursors.Default
            'XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()

    End Sub
    Private Function IsValidRow(view As GridView, rowHandle As Integer) As Boolean
        If view.IsNewItemRow(rowHandle) Then Return False

        Dim kategori = Convert.ToString(view.GetRowCellValue(rowHandle, "Kategori"))
        Dim deskripsi = Convert.ToString(view.GetRowCellValue(rowHandle, "Deskripsi"))
        Dim jumlah = Val(view.GetRowCellValue(rowHandle, "Jumlah"))
        Dim harga = Val(view.GetRowCellValue(rowHandle, "Harga"))

        ' Validasi kolom-kolom penting
        Return Not String.IsNullOrWhiteSpace(kategori) AndAlso
           Not String.IsNullOrWhiteSpace(deskripsi) AndAlso
           jumlah > 0 AndAlso
        harga > 0
    End Function
    Public Sub PrintToExcelTemplate()
        Dim billid = Trim(txtBillingID.Text)

        Dim excelApp As Object = Nothing
        Dim workbook As Object = Nothing
        Dim worksheet As Object = Nothing
        'Dim filepath = Application.StartupPath & "\Images\" & nodaftar & ".png"
        Try
            ' 1. Buka template Excel
            excelApp = CreateObject("Excel.Application")
            Dim templatepath As String = Application.StartupPath & "\Template\Invoice.xlt"
            workbook = excelApp.Workbooks.Open(templatepath)
            worksheet = workbook.Sheets(1)

            tblDokter = Proses.ExecuteQuery("SELECT a.[BillingID]
                                                  ,b.NamaLengkap Pasien
	                                              ,b.Alamat
                                                  ,[TanggalBilling]
                                                  ,[TotalTindakan]
                                                  ,[TotalObat]
                                                  ,[TotalBayar]
                                                  ,a.[UserCreated]
                                                  ,a.[CreatedAt]
                                                  ,c.Deskripsi
	                                              ,c.Qty
	                                              ,c.Harga
	                                              ,c.Subtotal
                                                  ,d.Username
                                              FROM [db_klinik].[dbo].[Transaksi_Billing_H] a
                                              left join [dbo].[M_Pasien] b
                                              on b.ID=a.PasienID
                                              left join [dbo].[Transaksi_Billing_D] c
                                              on c.BillingID=a.BillingID
                                              left join [dbo].[M_User_Login] d
                                              on d.UserID=a.UserCreated
                                              where a.BillingID='" & billid & "'")

            'If tblDokter.Rows.Count = 0 Then MsgBox("Detail barang belum diinput!") : Exit Sub
            ' 2. Isi data ke template
            With worksheet

                If tblDokter.Rows.Count = 0 Then

                Else
                    ' Contoh isi data
                    .Range("H2").Value = Trim(tblDokter.Rows(0).Item("BillingID").ToString)
                    .Range("H3").Value = Trim(tblDokter.Rows(0).Item("Pasien").ToString)
                    .Range("H4").Value = Trim(tblDokter.Rows(0).Item("Alamat").ToString)
                    .Range("H5").Value = Trim(tblDokter.Rows(0).Item("TanggalBilling").ToString)

                    Dim nrow = 6
                    Dim no = 0
                    For x = 0 To tblDokter.Rows.Count - 1
                        no += 1
                        nrow += 1

                        .Range("A" & CStr(nrow)).Value = no
                        ' Merge kolom B dan C
                        .Range("B" & nrow & ":F" & nrow).Merge()
                        .Range("B" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("Deskripsi").ToString)
                        .Range("B" & nrow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("B" & nrow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

                        .Range("G" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("Qty").ToString)
                        .Range("G" & nrow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("G" & nrow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        .Range("H" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("Harga").ToString)
                        .Range("H" & nrow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("H" & nrow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

                        .Range("I" & nrow & ":J" & nrow).Merge()
                        .Range("I" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("Subtotal").ToString)
                        .Range("I" & nrow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("I" & nrow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

                        Dim cellRange = .Range("A" & nrow & ":J" & nrow)
                        With cellRange.Borders
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                    Next
                    .Range("I" & nrow + 1 & ":J" & nrow + 1).Merge()
                    .Range("H" & CStr(nrow + 1)).Value = "Total : "
                    .Range("H" & nrow + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("I" & CStr(nrow + 1)).Value = "=SUM(I7:I" & nrow & ")"
                    .Range("I" & nrow + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("B" & CStr(nrow + 2)).Value = "Dibuat oleh : " & tblDokter.Rows(0).Item("Username").ToString
                    .Range("B" & CStr(nrow + 3)).Value = "Tanggal : " & tblDokter.Rows(0).Item("CreatedAt").ToString
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
End Class