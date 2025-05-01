Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class FarmasiMasukDetail
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
            DetailProc()
        End If
    End Sub

    Private Sub ckCekBarang_CheckedChanged(sender As Object, e As EventArgs) Handles ckCekBarang.CheckedChanged
        If ckCekBarang.Checked = True Then
            cmbKodeBarang.Properties.ReadOnly = True
            txtNamaBarang.Properties.ReadOnly = False
        Else
            cmbKodeBarang.Properties.ReadOnly = False
            txtNamaBarang.Properties.ReadOnly = True
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If lblid.Text = "" Then
            aksi = "I"
            DetailProc()
        Else
            aksi = "U"
            DetailProc()
        End If
    End Sub

    Private Sub FarmasiMasukDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combobarang()
    End Sub

    Private dtBarang As DataTable

    Private Sub cmbKodeBarang_EditValueChanged(sender As Object, e As EventArgs) Handles cmbKodeBarang.EditValueChanged
        getnamabarang()
    End Sub

    Public aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Sub DetailProc()
        If txtTransID.Text = "" Then MsgBox("Buat dulu transaksi masuk!") : Exit Sub

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

        Commandku.CommandText = "sp_Farmasi_Barang_Masuk_D"

        Dim id = Trim(lblid.Text)
        Dim transid = Trim(txtTransID.Text)
        Dim kodebarang = Trim(cmbKodeBarang.Text)
        Dim namabrg = Trim(txtNamaBarang.Text)
        Dim jumlah = Val(txtQty.Text)
        Dim harga = Val(txtHargaBeli.Text)
        Dim tglexp = Trim(dtTglMasuk.Text)
        Dim batchno = Trim(txtNoBatch.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@transid", transid)
        Commandku.Parameters.AddWithValue("@kodebarang", kodebarang)
        Commandku.Parameters.AddWithValue("@namabrg", namabrg)
        Commandku.Parameters.AddWithValue("@qtymasuk", jumlah)
        Commandku.Parameters.AddWithValue("@hargabeli", harga)
        Commandku.Parameters.AddWithValue("@tglexp", tglexp)
        Commandku.Parameters.AddWithValue("@batchno", batchno)
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
        Dim transid = Trim(txtTransID.Text)
        tblPasien = Proses.ExecuteQuery("SELECT [ID]
                                              ,[TransID]
                                              ,[KodeBarang]
                                              ,[NamaBarang]
                                              ,[QtyMasuk]
                                              ,[HargaBeli]
                                              ,[Subtotal]
                                              ,[TanggalExp]
                                              ,[BatchNo]
                                          FROM [db_klinik].[dbo].[Farmasi_Barang_Masuk_D]
                                          where TransID='" & transid & "'
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            'Dim id As GridColumn = gridView1.Columns("ID")


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
        lblid.Text = String.Empty
        ckCekBarang.Checked = False
        cmbKodeBarang.Text = String.Empty
        cmbKodeBarang.EditValue = String.Empty
        txtNamaBarang.Text = String.Empty
        txtQty.Text = String.Empty
        txtHargaBeli.Text = String.Empty
        txtNoBatch.Text = String.Empty
    End Sub
    Sub combobarang()

        tblObat = Proses.ExecuteQuery("SELECT [KodeBarang],[NamaBarang] FROM [db_klinik].[dbo].[M_Barang]")

        cmbKodeBarang.Properties.DataSource = tblObat
        cmbKodeBarang.Properties.ValueMember = "KodeBarang"
        cmbKodeBarang.Properties.DisplayMember = "KodeBarang"
        cmbKodeBarang.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbKodeBarang.Properties.AutoSearchColumnIndex = 1
        cmbKodeBarang.Properties.SearchMode = SearchMode.AutoSearch
        cmbKodeBarang.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbKodeBarang.Properties.CaseSensitiveSearch = True
        cmbKodeBarang.Properties.NullText = ""

    End Sub
    Sub getnamabarang()
        Dim kdbrg = Trim(cmbKodeBarang.Text)

        tblObat = Proses.ExecuteQuery("SELECT [KodeBarang],[NamaBarang] FROM [db_klinik].[dbo].[M_Barang] where KodeBarang='" & kdbrg & "'")

        If tblObat.Rows.Count = 0 Then
            txtNamaBarang.Text = ""
        Else
            txtNamaBarang.Text = Trim(tblObat.Rows(0).Item("NamaBarang").ToString)
        End If

    End Sub
End Class