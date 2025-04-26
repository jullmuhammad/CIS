Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FarmasiKeluar
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar, tblObat As DataTable
    Private dtBarang As DataTable

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click

        CariResep.ShowDialog()
        CariResep.BringToFront()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtTransID.Text = "" Then
            aksi = "I"
            HeaderProc()
        Else
            aksi = "U"
            HeaderProc()
        End If
    End Sub

    Private Sub FarmasiKeluar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTglKeluar.EditValue = Date.Now
        combojeniskeluar()
    End Sub

    Public aksi As String

    Private Sub GridViewData_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridViewData.CustomUnboundColumnData
        'If e.Column.FieldName = "NamaBarang" AndAlso e.IsGetData Then
        '    Dim kodeBarang As String = GridViewData.GetRowCellValue(e.ListSourceRowIndex, "KodeBarang").ToString()

        '    Dim row() As DataRow = dtBarang.Select("KodeBarang = '" & kodeBarang.Replace("'", "''") & "'")
        '    If row.Length > 0 Then
        '        e.Value = row(0)("NamaBarang").ToString()
        '    End If
        'End If
    End Sub

    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub
    Sub clear()
        GridControlData.DataSource = Nothing
        GridViewData.Columns.Clear()
        txtTransID.Text = String.Empty
        txtNoPendaftaran.Text = String.Empty
        txtIDResep.Text = String.Empty
        dtTglKeluar.EditValue = Date.Now
        cmbJenisKeluar.SelectedIndex = -1
        txtTujuanKeluar.Text = String.Empty
        txtKeterangan.Text = String.Empty
    End Sub
    Sub HeaderProc()
        If cmbJenisKeluar.Text = "Resep" And txtIDResep.Text = "" Then MsgBox("Pilih dulu resep dari Poliklinik!") : Exit Sub

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

        Commandku.CommandText = "sp_Farmasi_Barang_Keluar_H"

        Dim transid = Trim(txtTransID.Text)
        Dim idresep = Trim(txtIDResep.Text)
        Dim nodaftar = Trim(txtNoPendaftaran.Text)
        Dim tglkeluar = dtTglKeluar.DateTime
        Dim jeniskeluar = Trim(cmbJenisKeluar.Text)
        Dim tujuankeluar = Trim(txtTujuanKeluar.Text)
        Dim ket = Trim(txtKeterangan.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@transid", transid)
        Commandku.Parameters.AddWithValue("@tglkeluar", tglkeluar)
        Commandku.Parameters.AddWithValue("@jeniskeluar", jeniskeluar)
        Commandku.Parameters.AddWithValue("@tujuankeluar", tujuankeluar)
        Commandku.Parameters.AddWithValue("@ket", ket)
        Commandku.Parameters.AddWithValue("@nodaftar", nodaftar)
        Commandku.Parameters.AddWithValue("@koderesep", idresep)
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
            'Data()
            'clear()
            If aksi = "I" Then
                dataobat()
                txtTransID.Text = Trim(OutId.Value.ToString)
            Else
                aksi = "I"
                DetailProc()
            End If

        Else
            Cursor.Current = Cursors.Default
            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()


    End Sub
    Sub dataobat()
        Dim resepid = Trim(txtIDResep.Text)
        Dim transid = Trim(txtTransID.Text)
        If resepid <> "" Then

            tblObat = Proses.ExecuteQuery("SELECT b.ID,[KodeObat] KodeBarang
                                          ,[NamaObat] NamaBarang
                                          ,[Jumlah]
                                          ,c.Stok
                                          ,a.[Satuan]
                                          ,[Dosis]
                                          ,[AturanPakai]
                                      FROM [db_klinik].[dbo].[T_ResepObat_Detail] a
                                      left join [Farmasi_Barang_Keluar_D] b
                                      on b.KodeBarang=a.KodeObat and a.IDResep='" & resepid & "'
                                      left join [M_Barang] c on c.KodeBarang=a.KodeObat
                                        ")
        Else
            tblObat = Proses.ExecuteQuery("SELECT ID
                                                ,a.[KodeBarang]
                                              ,a.[NamaBarang]
                                              ,[QtyKeluar] Jumlah
                                              ,c.Stok
                                          FROM [db_klinik].[dbo].[Farmasi_Barang_Keluar_D] a
                                          left join [M_Barang] c on c.KodeBarang=a.KodeBarang
                                          where TransID='" & transid & "'")
        End If

        Dim tblKosong As DataTable = Proses.ExecuteQuery("Select '' ID, '' KodeBarang, '' NamaBarang, 0 Jumlah, 0 Stok")

        If tblObat.Rows.Count = 0 Then
            GridControlData.DataSource = tblKosong
            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            Dim id As GridColumn = gridView1.Columns("ID")
            Dim namabarang As GridColumn = gridView1.Columns("NamaBarang")

            id.Visible = False
            namabarang.OptionsColumn.ReadOnly = True

            gridView1.Appearance.HeaderPanel.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            gridView1.Appearance.Row.Font = New Font("Segoe UI", 11, FontStyle.Regular)

            gridView1.OptionsView.ColumnAutoWidth = False
            gridView1.BestFitColumns()

            SetupRepositoryLookUpBarang()
            SetupUnboundNamaBarang()

            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom ' Atau Top kalau mau di atas
            'gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace ' Boleh juga pakai EditForm kalau mau popup
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        Else
            GridControlData.DataSource = tblObat

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim id As GridColumn = gridView1.Columns("ID")
            Dim namabarang As GridColumn = gridView1.Columns("NamaBarang")

            id.Visible = False
            namabarang.OptionsColumn.ReadOnly = True

            If resepid <> "" Then

                Dim satuan As GridColumn = gridView1.Columns("Satuan")
                Dim dosis As GridColumn = gridView1.Columns("Dosis")
                Dim aturan As GridColumn = gridView1.Columns("AturanPakai")

                satuan.Visible = False
                dosis.Visible = False
                aturan.Visible = False
            End If
            '' Make the grid read-only.
            'gridView1.OptionsBehavior.Editable = False
            '' Prevent the focused cell from being highlighted.
            'gridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            '' Draw a dotted focus rectangle around the entire row.
            'gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus

            gridView1.Appearance.HeaderPanel.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            gridView1.Appearance.Row.Font = New Font("Segoe UI", 11, FontStyle.Regular)

            gridView1.OptionsView.ColumnAutoWidth = False
            gridView1.BestFitColumns()

            SetupRepositoryLookUpBarang()
            SetupUnboundNamaBarang()

            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom ' Atau Top kalau mau di atas
            'gridView1.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace ' Boleh juga pakai EditForm kalau mau popup
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub
    Sub DetailProc()
        If txtTransID.Text = "" Then MsgBox("Buat dulu transaksi keluar!") : Exit Sub

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

            Commandku.CommandText = "sp_Farmasi_Barang_Keluar_D"

            Dim id = Trim(Convert.ToString(GridViewData.GetRowCellValue(x, "ID")))
            Dim transid = Trim(txtTransID.Text)
            Dim kodebarang = Trim(Convert.ToString(GridViewData.GetRowCellValue(x, "KodeBarang")))
            Dim namabrg = Trim(Convert.ToString(GridViewData.GetRowCellValue(x, "NamaBarang")))
            Dim jumlah = Val(Convert.ToDecimal(GridViewData.GetRowCellValue(x, "Jumlah")))

            Dim userid = Trim(FormMenu.txtUserID.Caption)

            Commandku.Parameters.AddWithValue("@id", id)
            Commandku.Parameters.AddWithValue("@transid", transid)
            Commandku.Parameters.AddWithValue("@kodebarang", kodebarang)
            Commandku.Parameters.AddWithValue("@namabrg", namabrg)
            Commandku.Parameters.AddWithValue("@qty", jumlah)
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
        dataobat()
    End Sub
    Private Function IsValidRow(view As GridView, rowHandle As Integer) As Boolean
        If view.IsNewItemRow(rowHandle) Then Return False

        Dim kodeBarang = Convert.ToString(view.GetRowCellValue(rowHandle, "KodeBarang"))
        Dim namaBarang = Convert.ToString(view.GetRowCellValue(rowHandle, "NamaBarang"))
        Dim jumlah = Val(view.GetRowCellValue(rowHandle, "Jumlah"))

        ' Validasi kolom-kolom penting
        Return Not String.IsNullOrWhiteSpace(kodeBarang) AndAlso
           Not String.IsNullOrWhiteSpace(namaBarang) AndAlso
           jumlah > 0
    End Function
    Sub combojeniskeluar()
        cmbJenisKeluar.Properties.Items.Clear()
        Call Proses.OpenConn()
        Dim str As String
        str = "SELECT [JenisKeluar] FROM [db_klinik].[dbo].[M_JenisKeluar]"
        Proses.Cmd = New OleDb.OleDbCommand(str, Proses.Cn)
        Proses.Rd = Proses.Cmd.ExecuteReader
        If Proses.Rd.HasRows Then
            Do While Proses.Rd.Read
                cmbJenisKeluar.Properties.Items.Add(Proses.Rd("JenisKeluar").ToString)

            Loop
        Else
        End If

    End Sub
    '--- Setup LookupEdit untuk kolom KodeBarang
    Private Sub SetupRepositoryLookUpBarang()
        ' Ambil data master barang
        dtBarang = Proses.ExecuteQuery("SELECT KodeBarang, NamaBarang,Stok FROM M_Barang")

        ' Buat repository
        Dim repoLookupBarang As New RepositoryItemLookUpEdit()
        With repoLookupBarang
            .DataSource = dtBarang
            .DisplayMember = "KodeBarang"
            .ValueMember = "KodeBarang"
            .NullText = ""
            .SearchMode = SearchMode.AutoSearch
            .BestFitMode = BestFitMode.BestFit
            .HeaderClickMode = HeaderClickMode.AutoSearch
            .CaseSensitiveSearch = True

            .Columns.Add(New LookUpColumnInfo("KodeBarang", "Kode"))
            .Columns.Add(New LookUpColumnInfo("NamaBarang", "Nama"))
            .Columns.Add(New LookUpColumnInfo("Stok", "Stok"))
        End With

        ' Tambah ke grid
        GridControlData.RepositoryItems.Add(repoLookupBarang)

        ' Assign ke kolom
        Dim colKodeBarang As GridColumn = GridViewData.Columns("KodeBarang")
        colKodeBarang.ColumnEdit = repoLookupBarang
    End Sub

    '--- Tambah kolom NamaBarang unbound (tidak dari data utama)
    Private Sub SetupUnboundNamaBarang()
        ' Cek apakah kolom sudah ada
        If GridViewData.Columns("NamaBarang") Is Nothing Then
            Dim colNamaBarang As New GridColumn()
            With colNamaBarang
                .FieldName = "NamaBarang"
                .Caption = "Nama Barang"
                .UnboundType = DevExpress.Data.UnboundColumnType.String
                .Visible = True
                .OptionsColumn.AllowEdit = False ' Biar tidak bisa diketik manual
            End With

            GridViewData.Columns.Add(colNamaBarang)
        End If

        If GridViewData.Columns("Stok") Is Nothing Then
            Dim colStok As New GridColumn()
            With colStok
                .FieldName = "Stok"
                .Caption = "Stok Barang"
                .UnboundType = DevExpress.Data.UnboundColumnType.String
                .Visible = True
                .OptionsColumn.AllowEdit = False ' Biar tidak bisa diketik manual
            End With

            GridViewData.Columns.Add(colStok)
        End If
    End Sub

    Private Sub GridViewData_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewData.CellValueChanged
        If e.Column.FieldName = "KodeBarang" Then
            Dim kodeBarang As String = e.Value.ToString()

            Try

                ' Cari NamaBarang dari dtBarang
                Dim found() As DataRow = dtBarang.Select("KodeBarang = '" & kodeBarang.Replace("'", "''") & "'")
                If found.Length > 0 Then
                    ' Update kolom NamaBarang pada baris yang sama
                    GridViewData.SetRowCellValue(e.RowHandle, "NamaBarang", found(0)("NamaBarang").ToString())
                    GridViewData.SetRowCellValue(e.RowHandle, "Stok", found(0)("Stok").ToString())
                Else
                    ' Kalau tidak ketemu, kosongkan
                    GridViewData.SetRowCellValue(e.RowHandle, "NamaBarang", "")
                    GridViewData.SetRowCellValue(e.RowHandle, "Stok", "")
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub
End Class