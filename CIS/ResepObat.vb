Imports DevExpress.XtraEditors

Public Class ResepObat
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(lbliddetail.Text) = "" Then
            aksi = "I"
            DetailProc()
        Else
            aksi = "U"
            DetailProc()
        End If
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
            DetailProc()
        End If
    End Sub

    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Sub HeaderProc()
        If Trim(Pelayanan_Poliklinik.txtIDPelayanan.Text) = "" Then MsgBox("Pilih pelayanan mana yang akan ditambahkan resep!") : Exit Sub

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

        Commandku.CommandText = "sp_Resep_Obat_H"

        Dim id = Trim(txtIDResep.Text)
        Dim idpel = Trim(txtIDPelayanan.Text)
        Dim tglresep = dtTglResep.DateTime
        Dim stts = Trim(cmbStatus.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@idresep", id)
        Commandku.Parameters.AddWithValue("@idpelayanan", idpel)
        Commandku.Parameters.AddWithValue("@tglresep", tglresep)
        Commandku.Parameters.AddWithValue("@stts", stts)
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

            txtIDResep.Text = Trim(OutId.Value.ToString)

        Else
            Cursor.Current = Cursors.Default
            XtraMessageBox.Show("" & outMsg.Value.ToString & "", "Proses gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()


    End Sub
    Sub DetailProc()
        If Trim(txtIDResep.Text) = "" Then MsgBox("Pilih resep mana yang akan ditambahkan obat!") : Exit Sub

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

        Commandku.CommandText = "sp_Resep_Obat_D"

        Dim iddtl = Trim(lbliddetail.Text)
        Dim idresep = Trim(txtIDResep.Text)
        Dim kdobat = Trim(cmbKodeObat.Text)
        Dim namaobat = Trim(txtNamaObat.Text)
        Dim dosis = Trim(txtDosis.Text)
        Dim jml = Val(txtJumlah.Text)
        Dim satuan = Trim(cmbSatuan.Text)
        Dim aturanpake = Trim(txtAturanPakai.Text)
        Dim ket = Trim(txtKet.Text)

        Dim userid = Trim(FormMenu.txtUserID.Caption)

        Commandku.Parameters.AddWithValue("@iddetail", iddtl)
        Commandku.Parameters.AddWithValue("@idresep", idresep)
        Commandku.Parameters.AddWithValue("@kodeobat", kdobat)
        Commandku.Parameters.AddWithValue("@namaobat", namaobat)
        Commandku.Parameters.AddWithValue("@dosis", dosis)
        Commandku.Parameters.AddWithValue("@jml", jml)
        Commandku.Parameters.AddWithValue("@satuan", satuan)
        Commandku.Parameters.AddWithValue("@aturanpake", aturanpake)
        Commandku.Parameters.AddWithValue("@ket", ket)
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
    Sub clear()

        Dim kdobat = Trim(cmbKodeObat.Text)
        Dim namaobat = Trim(txtNamaObat.Text)
        Dim dosis = Trim(txtDosis.Text)
        Dim jml = Val(txtJumlah.Text)
        Dim satuan = Trim(cmbSatuan.Text)
        Dim aturanpake = Trim(txtAturanPakai.Text)
        Dim ket = Trim(txtKet.Text)

        lbliddetail.Text = String.Empty
        kdobat = String.Empty
        namaobat = String.Empty
        dosis = String.Empty
        jml = 0
        satuan = String.Empty
        aturanpake = String.Empty
        ket = String.Empty
    End Sub
End Class