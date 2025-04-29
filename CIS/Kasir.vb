Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class Kasir
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim shostname As String = System.Net.Dns.GetHostName
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar, dtBarang As DataTable

    Private Sub GridViewData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewData.CellValueChanged
        If e.Column.FieldName = "Harga" Then
            Dim kodeBarang As String = e.Value.ToString()

            Try

                ' Cari NamaBarang dari dtBarang
                Dim found() As DataRow = dtBarang.Select("Tindakan = '" & kodeBarang.Replace("'", "''") & "'")
                If found.Length > 0 Then
                    ' Update kolom NamaBarang pada baris yang sama
                    GridViewData.SetRowCellValue(e.RowHandle, "Harga", found(0)("Harga").ToString())
                    'GridViewData.SetRowCellValue(e.RowHandle, "Stok", found(0)("Stok").ToString())
                Else
                    ' Kalau tidak ketemu, kosongkan
                    GridViewData.SetRowCellValue(e.RowHandle, "Harga", "0")
                    ' GridViewData.SetRowCellValue(e.RowHandle, "Stok", "")
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        aksi = "I"
        PROSESPROC()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        CariPendaftaran.tipe = "Kasir"
        CariPendaftaran.ShowDialog()
        CariPendaftaran.BringToFront()
    End Sub

    Dim aksi As String
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
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

        Dim id = Val(txtBillingID.Text)
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


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If Trim(OutSTS.Value.ToString) = "OK" Then
            Cursor.Current = Cursors.Default
            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'data()
            'clear()
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
        Dim nodaftar = Trim(txtNoPendaftaran.Text)
        tblPasien = Proses.ExecuteQuery("SELECT  b.DetailBillingID ID,a.[IDPelayanan]
                                                  ,a.[Kategori]
                                                  ,a.[Deskripsi]
                                                  ,[Jumlah]
                                                  ,a.[Harga]
                                                  ,Jumlah*a.Harga Subtotal
                                              FROM [db_klinik].[dbo].[V_Billing_Detail] a
                                              left join [dbo].[Transaksi_Billing_D] b
                                              on b.IDPelayanan=a.IDPelayanan 
                                              left join [dbo].[Transaksi_Billing_H] c
                                              on b.BillingID=c.BillingID and c.NoRegistrasi='" & nodaftar & "'")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            Dim id As GridColumn = gridView1.Columns("ID")
            id.Visible = False

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
            Dim jumlah = Val(Convert.ToDecimal(GridViewData.GetRowCellValue(x, "Jumlah")))
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
End Class