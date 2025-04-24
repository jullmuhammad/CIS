Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class FarmasiKeluar
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable
    Public aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Sub HeaderProc()

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
            txtTransID.Text = Trim(OutId.Value.ToString)
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
    Sub dataobat()

        tblPoli = Proses.ExecuteQuery("")

        If tblPoli.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPoli

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