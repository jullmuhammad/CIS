Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class Pendaftaran_Rawat_Jalan
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ As DataTable
    Dim aksi As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(lblid.Text) = "" Then
            aksi = "I"
            PROSESPROC()
        Else
            aksi = "U"
            PROSESPROC()
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        aksi = "D"
        PROSESPROC()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Pendaftaran_Rawat_Jalan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtJamDaftar.Text = Date.Now
    End Sub

    Dim shostname As String = System.Net.Dns.GetHostName
    Sub PROSESPROC()
        If Trim(cmbPasienID.Text) = "" Then MsgBox("Pilih pasien yang akan didaftarkan!") : Exit Sub

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

        Commandku.CommandText = "sp_Pendaftaran_RawatJalan"

        Dim id = Trim(lblid.Text)
        Dim noreg = Trim(txtNodaftar.Text)
        Dim pasienid = Trim(cmbPasienID.Text)
        Dim poliklinik = Trim(cmbPoliklinik.Text)
        Dim dokter = Trim(cmbDokter.Text)
        Dim carabayar = Trim(cmbCaraBayar.Text)
        Dim nojkn = Trim(txtNoJKN.Text)
        Dim keluhan = Trim(mmoKeluhan.Text)
        Dim statuskunjungan = Trim(txtStatusKunjungan.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@id", id)
        Commandku.Parameters.AddWithValue("@nopendaftaran", noreg)
        Commandku.Parameters.AddWithValue("@pasienid", pasienid)
        Commandku.Parameters.AddWithValue("@poliklinikid", poliklinik)
        Commandku.Parameters.AddWithValue("@dokterid", dokter)
        Commandku.Parameters.AddWithValue("@carabayar", carabayar)
        Commandku.Parameters.AddWithValue("@nokartujkn", nojkn)
        Commandku.Parameters.AddWithValue("@keluhan", keluhan)
        Commandku.Parameters.AddWithValue("@statuskunjungan", statuskunjungan)
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

        tblPasien = Proses.ExecuteQuery("SELECT [ID]
                                          ,[NoPendaftaran]
                                          ,[TanggalDaftar]
                                          ,[PasienID]
                                          ,[PoliklinikID]
                                          ,[DokterID]
                                          ,[CaraBayar]
                                          ,[NoKartuJKN]
                                          ,[Keluhan]
                                          ,[StatusKunjungan]
                                          ,[CreatedAt]
                                          ,[UserCreated]
                                          ,[PC]
                                      FROM [db_klinik].[dbo].[T_Pendaftaran_RawatJalan]
                                       where StatusKunjungan='Terdaftar'
                                        order by TanggalDaftar desc
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

            Dim gridView1 As GridView = TryCast(GridControlData.MainView, GridView)

            ' Obtain created columns.
            Dim id As GridColumn = gridView1.Columns("ID")
            Dim noreg As GridColumn = gridView1.Columns("NoPendaftaran")
            Dim tgl As GridColumn = gridView1.Columns("TanggalDaftar")
            Dim pasien As GridColumn = gridView1.Columns("PasienID")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            tgl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            tgl.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            id.Visible = False
            noreg.Fixed = FixedStyle.Left
            tgl.Fixed = FixedStyle.Left
            pasien.Fixed = FixedStyle.Left
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
        txtNodaftar.Text = String.Empty
        cmbPasienID.Text = String.Empty
        txtPasien.Text = String.Empty
        cmbPoliklinik.Text = String.Empty
        txtPoliklinik.Text = String.Empty
        cmbDokter.Text = String.Empty
        txtDokter.Text = String.Empty
        cmbCaraBayar.Text = String.Empty
        txtNoJKN.Text = String.Empty
        mmoKeluhan.Text = String.Empty
        txtStatusKunjungan.Text = "Terdaftar"
    End Sub
End Class