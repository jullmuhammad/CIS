Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class Kasir
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim shostname As String = System.Net.Dns.GetHostName
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable
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

        Dim id = Val(txtIDPelayanan.Text)
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
            data()
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
    Sub data()

        tblPasien = Proses.ExecuteQuery("SELECT [IDPelayanan]
                                                  ,[NoPendaftaran]
                                                  ,[JenisDaftar]
                                                  ,[TanggalPeriksa]
                                                  ,[PoliID]
                                                  ,[DokterID]
                                                  ,[Keluhan]
                                                  ,[PemeriksaanFisik]
                                                  ,[Diagnosa]
                                                  ,[Tindakan]
                                                  ,[Saran]
                                                  ,[StatusSelesai]
                                                  ,a.[CreatedAt]
                                                  ,a.[UserCreated]
                                                  ,a.[PC]
                                                  ,a.[LastUpdated]
                                              FROM [db_klinik].[dbo].[T_PelayananPoli] a
                                       where StatusSelesai=0
									   and NoPendaftaran='" & Trim(txtNoPendaftaran.Text) & "'
                                        order by TanggalPeriksa desc
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            'Dim id As GridColumn = gridView1.Columns("ID")


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
End Class