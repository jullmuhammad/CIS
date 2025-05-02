Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Public Class MasterBarang
    Private dtBarang As DataTable
    Public aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar, tblObat As DataTable

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
            SimpanProc()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub MasterBarang_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim formIsopen As Boolean = Application.OpenForms().OfType(Of FarmasiMasukDetail)().Any()

        If formIsopen Then
            FarmasiMasukDetail.combobarang()
        Else

        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtKodeBarang.Text = "" Then
            aksi = "I"
            SimpanProc()
        Else
            aksi = "D"
            SimpanProc()
        End If
    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub MasterBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
        combosatuan()
        txtStok.Text = "0"

    End Sub

    Sub combosatuan()
        cmbSatuan.Properties.Items.Clear()
        Call Proses.OpenConn()
        Dim str As String
        str = "SELECT [KodeSatuan] + ' - ' + [Satuan] Satuan  FROM [db_klinik].[dbo].[M_Satuan]"
        Proses.Cmd = New OleDb.OleDbCommand(str, Proses.Cn)
        Proses.Rd = Proses.Cmd.ExecuteReader
        If Proses.Rd.HasRows Then
            Do While Proses.Rd.Read
                cmbSatuan.Properties.Items.Add(Proses.Rd("Satuan").ToString)

            Loop
        Else
        End If

    End Sub
    Sub SimpanProc()
        If txtNamaBarang.Text = "" Then MsgBox("Nama Barang harus diisi!") : Exit Sub

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

        Commandku.CommandText = "sp_Master_Barang"

        Dim kodebrg = Trim(txtKodeBarang.Text)
        Dim namabrg = Trim(txtNamaBarang.Text)
        Dim jenis = Trim(cmbJenis.Text)
        Dim satuan = Trim(cmbSatuan.Text)
        Dim hargasatuan = Val(txtHargaBeli.Text)
        Dim hargajual = Val(txtHargaJual.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@kodebarang", kodebrg)
        Commandku.Parameters.AddWithValue("@namabrg", namabrg)
        Commandku.Parameters.AddWithValue("@jenis", jenis)
        Commandku.Parameters.AddWithValue("@satuan", satuan)
        Commandku.Parameters.AddWithValue("@hargasatuan", hargasatuan)
        Commandku.Parameters.AddWithValue("@hargajual", hargajual)
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

        tblObat = Proses.ExecuteQuery("SELECT [KodeBarang]
                                          ,[NamaBarang]
                                          ,[Jenis]
                                          ,a.[Satuan] + ' - ' + b.Satuan Satuan
                                          ,[HargaSatuan]
                                          ,[Stok]
                                          ,[HargaJual]
                                          ,[CreatedAt]
                                          ,[UserCreated]
                                          ,[PC]
                                          ,[UpdatedAt]
                                      FROM [db_klinik].[dbo].[M_Barang] a
									  left join [dbo].[M_Satuan] b
									  on b.KodeSatuan=a.Satuan")

        If tblObat.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblObat

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            'Dim id As GridColumn = gridView1.Columns("ID")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm:ss"

            'id.Visible = False

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
        txtKodeBarang.Text = String.Empty
        txtNamaBarang.Text = String.Empty
        cmbJenis.SelectedIndex = -1
        cmbSatuan.SelectedIndex = -1
        txtStok.Text = "0"
        txtHargaBeli.Text = "0"
        txtHargaJual.Text = "0"
    End Sub
    Sub gridtotext()
        Try
            txtKodeBarang.Text = GridViewData.GetFocusedRowCellValue("KodeBarang").ToString
            txtNamaBarang.Text = GridViewData.GetFocusedRowCellValue("NamaBarang").ToString
            cmbJenis.Text = GridViewData.GetFocusedRowCellValue("Jenis").ToString
            cmbSatuan.Text = GridViewData.GetFocusedRowCellValue("Satuan").ToString
            txtHargaBeli.Text = GridViewData.GetFocusedRowCellValue("HargaSatuan").ToString
            txtStok.Text = GridViewData.GetFocusedRowCellValue("Stok").ToString
            txtHargaJual.Text = GridViewData.GetFocusedRowCellValue("HargaJual").ToString

        Catch ex As Exception

        End Try
    End Sub
End Class