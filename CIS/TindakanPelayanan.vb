Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class TindakanPelayanan
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtID.Text = "" Then
            aksi = "I"
            TindakanProc()
        Else
            aksi = "U"
            TindakanProc()
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        aksi = "D"
        TindakanProc()
    End Sub

    Private Sub TindakanPelayanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        combotindakan()
        data()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Public aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName

    Private Sub cmbKodeTindakan_EditValueChanged(sender As Object, e As EventArgs) Handles cmbKodeTindakan.EditValueChanged
        gettindakandetail()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Sub TindakanProc()
        If Trim(txtIDPelayanan.Text) = "" Then MsgBox("Pilih Pelayanan mana yang akan ditambahkan tindakan!") : Exit Sub

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

        Commandku.CommandText = "sp_Tindakan_Pelayanan"

        Dim id = Trim(txtID.Text)
        Dim idpelayanan = Trim(txtIDPelayanan.Text)
        Dim idtindak = Trim(cmbKodeTindakan.Text)
        Dim tarif = Val(txtTarif.Text)
        Dim jml = Val(txtJumlah.Text)
        Dim ket = Trim(mmoKet.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@idpelayanan", idpelayanan)
        Commandku.Parameters.AddWithValue("@idtindakan", idtindak)
        Commandku.Parameters.AddWithValue("@tarif", tarif)
        Commandku.Parameters.AddWithValue("@qty", jml)
        Commandku.Parameters.AddWithValue("@ket", ket)
        Commandku.Parameters.AddWithValue("@userid", userid)
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
        Dim idpelayanan = Trim(txtIDPelayanan.Text)
        tblPasien = Proses.ExecuteQuery("SELECT [ID]
                                          ,[IDPelayanan]
                                          ,[IDTindakan]
                                          ,b.NamaTindakan
                                          ,a.[Tarif]
                                          ,[Qty]
                                          ,[Subtotal]
                                          ,a.[Keterangan]
                                          ,a.[CreatedAt]
                                          ,a.[UserCreated]
                                      FROM [db_klinik].[dbo].[T_Tindakan_Pelayanan] a
									  left join [M_Tindakan] b
									  on b.TindakanID=a.IDTindakan
                                      where IDPelayanan='" & idpelayanan & "'")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim id As GridColumn = gridView1.Columns("ID")

            id.Visible = False
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
        txtID.Text = String.Empty
        cmbKodeTindakan.EditValue = String.Empty
        cmbKodeTindakan.Text = String.Empty
        txtNamaTindakan.Text = String.Empty
        txtTarif.Text = String.Empty
        txtJumlah.Text = "1"
        mmoKet.Text = ""
    End Sub
    Sub combotindakan()

        tblPasien = Proses.ExecuteQuery("SELECT [TindakanID],[NamaTindakan],[Kategori]  FROM [db_klinik].[dbo].[M_Tindakan] where StatusAktif=1")

        cmbKodeTindakan.Properties.DataSource = tblPasien
        cmbKodeTindakan.Properties.ValueMember = "TindakanID"
        cmbKodeTindakan.Properties.DisplayMember = "TindakanID"
        cmbKodeTindakan.Properties.BestFitMode = BestFitMode.BestFitResizePopup

        cmbKodeTindakan.Properties.AutoSearchColumnIndex = 1
        cmbKodeTindakan.Properties.SearchMode = SearchMode.AutoSearch
        cmbKodeTindakan.Properties.HeaderClickMode = HeaderClickMode.AutoSearch
        cmbKodeTindakan.Properties.CaseSensitiveSearch = True
        cmbKodeTindakan.Properties.NullText = ""

    End Sub
    Sub gettindakandetail()
        Dim kdtindakan = Trim(cmbKodeTindakan.Text)
        tblPoli = Proses.ExecuteQuery("SELECT [TindakanID]
                                              ,[KodeTindakan]
                                              ,[NamaTindakan]
                                              ,[Kategori]
                                              ,[Tarif]
                                              ,[Satuan]
                                              ,[Keterangan]
                                          FROM [db_klinik].[dbo].[M_Tindakan]
                                          where TindakanID='" & kdtindakan & "'")

        If tblPoli.Rows.Count = 0 Then
            txtNamaTindakan.Text = ""
            txtTarif.Text = String.Empty
            mmoKet.Text = ""
        Else
            txtNamaTindakan.Text = tblPoli.Rows(0).Item("NamaTindakan").ToString
            txtTarif.Text = tblPoli.Rows(0).Item("Tarif").ToString
            mmoKet.Text = tblPoli.Rows(0).Item("Keterangan").ToString
        End If
    End Sub
    Sub gridtotext()
        Try
            txtID.Text = GridViewData.GetFocusedRowCellValue("ID").ToString
            txtIDPelayanan.Text = GridViewData.GetFocusedRowCellValue("IDPelayanan").ToString
            cmbKodeTindakan.EditValue = GridViewData.GetFocusedRowCellValue("IDTindakan").ToString
            cmbKodeTindakan.Text = GridViewData.GetFocusedRowCellValue("IDTindakan").ToString
            txtNamaTindakan.Text = GridViewData.GetFocusedRowCellValue("NamaTindakan").ToString
            txtTarif.Text = GridViewData.GetFocusedRowCellValue("Tarif").ToString
            txtJumlah.Text = GridViewData.GetFocusedRowCellValue("Qty").ToString
            mmoKet.Text = GridViewData.GetFocusedRowCellValue("Keterangan").ToString


        Catch ex As Exception

        End Try
    End Sub
End Class