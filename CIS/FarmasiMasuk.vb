Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class FarmasiMasuk
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar, tblObat As DataTable

    Private Sub cmbSupplier_EditValueChanged(sender As Object, e As EventArgs) Handles cmbSupplier.EditValueChanged
        Dim kdsup = Trim(cmbSupplier.Text)
        tblUser = Proses.ExecuteQuery("SELECT [NamaSupplier] FROM [db_klinik].[dbo].[M_Supplier] where KodeSupplier='" & kdsup & "'")

        If tblUser.Rows.Count = 0 Then
            txtSupplier.Text = ""
        Else
            txtSupplier.Text = Trim(tblUser.Rows(0).Item("NamaSupplier").ToString)
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private dtBarang As DataTable
    Public aksi As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtTransID.Text = "" Then
            aksi = "I"
            HeaderProc()
        Else
            aksi = "U"
            HeaderProc()
        End If
    End Sub

    Private Sub txtTransID_EditValueChanged(sender As Object, e As EventArgs) Handles txtTransID.EditValueChanged
        If txtTransID.Text = "" Then
            btnBarangDetail.Enabled = False
        Else
            btnBarangDetail.Enabled = True
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
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
            HeaderProc()
        End If
    End Sub

    Private Sub btnBarangDetail_Click(sender As Object, e As EventArgs) Handles btnBarangDetail.Click
        If txtTransID.Text = "" Then MsgBox("Buat dulu transaksi masuknya!") : Exit Sub

        FarmasiMasukDetail.txtTransID.Text = txtTransID.Text
        FarmasiMasukDetail.data()
        FarmasiMasukDetail.ShowDialog()
        FarmasiMasukDetail.BringToFront()
    End Sub

    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub FarmasiMasuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatdate()
        dtTglMasuk.EditValue = Date.Now
        combosupplier()
        data()
    End Sub
    Sub formatdate()
        dtTglMasuk.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglMasuk.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy"

        dtTglMasuk.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        dtTglMasuk.Properties.EditFormat.FormatString = "dd-MMM-yyyy"

        dtTglMasuk.Properties.Mask.EditMask = "dd-MMM-yyyy"
        dtTglMasuk.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub
    Sub combosupplier()

        tblPasien = Proses.ExecuteQuery("SELECT [KodeSupplier],[NamaSupplier],[Alamat]  FROM [db_klinik].[dbo].[M_Supplier] where StatusAktif=1")

        cmbSupplier.Properties.DataSource = tblPasien
        cmbSupplier.Properties.ValueMember = "KodeSupplier"
        cmbSupplier.Properties.DisplayMember = "KodeSupplier"
        cmbSupplier.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbSupplier.Properties.AutoSearchColumnIndex = 1
        cmbSupplier.Properties.SearchMode = SearchMode.AutoSearch
        cmbSupplier.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbSupplier.Properties.CaseSensitiveSearch = True
        cmbSupplier.Properties.NullText = ""

    End Sub
    Sub HeaderProc()
        'If cmb.Text = "" Then MsgBox("Pilih dulu resep dari Poliklinik!") : Exit Sub

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

        Commandku.CommandText = "sp_Farmasi_Barang_Masuk_H"

        Dim transid = Trim(txtTransID.Text)
        Dim tglmasuk = dtTglMasuk.Text
        Dim nofaktur = Trim(txtNoFaktur.Text)
        Dim suppid = Trim(cmbSupplier.Text)
        Dim ket = Trim(txtKet.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@transid", transid)
        Commandku.Parameters.AddWithValue("@tglmasuk", tglmasuk)
        Commandku.Parameters.AddWithValue("@nofaktur", nofaktur)
        Commandku.Parameters.AddWithValue("@suppid", suppid)
        Commandku.Parameters.AddWithValue("@ket", ket)
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
            data()
            'clear()
            If aksi = "I" Then
                'dataobat()
                txtTransID.Text = Trim(OutId.Value.ToString)
            Else
                'aksi = "I"
                'DetailProc()
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

    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT TOP(100)  [TransID]
                                              ,[TanggalMasuk]
                                              ,[NoFaktur]
                                              ,[SupplierID]
                                              ,[Keterangan]
                                              ,[CreatedAt]
                                              ,[UserCreated]
                                              ,[PC]
                                          FROM [db_klinik].[dbo].[Farmasi_Barang_Masuk_H]
                                          order by TanggalMasuk desc
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
        txtTransID.Text = String.Empty
        txtNoFaktur.Text = String.Empty
        cmbSupplier.Text = String.Empty
        cmbSupplier.EditValue = String.Empty
        txtSupplier.Text = String.Empty
        txtKet.Text = String.Empty
    End Sub
End Class