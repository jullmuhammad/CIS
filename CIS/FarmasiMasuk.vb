Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class FarmasiMasuk
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar, tblObat As DataTable

    Private Sub cmbSupplier_EditValueChanged(sender As Object, e As EventArgs) Handles cmbSupplier.EditValueChanged
        Dim kdsup = Trim(cmbSupplier.Text)
        tblUser = Proses.ExecuteQuery("SELECT [NamaSupplier],[Alamat] FROM [db_klinik].[dbo].[M_Supplier] where KodeSupplier='" & kdsup & "'")

        If tblUser.Rows.Count = 0 Then
            txtSupplier.Text = ""
            txtAlamat.Text = ""
        Else
            txtSupplier.Text = Trim(tblUser.Rows(0).Item("NamaSupplier").ToString)
            txtAlamat.Text = Trim(tblUser.Rows(0).Item("Alamat").ToString)
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
            btnPrint.Enabled = False
        Else
            btnBarangDetail.Enabled = True
            btnPrint.Enabled = True
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
        FarmasiMasukDetail.Show()
        FarmasiMasukDetail.BringToFront()
    End Sub

    Dim shostname As String = System.Net.Dns.GetHostName

    Private Sub GridViewData_RowClick(sender As Object, e As RowClickEventArgs) Handles GridViewData.RowClick
        gridtotext()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtTransID.Text = "" Then MsgBox("Buat dulu transaksi masuknya!") : Exit Sub

        PrintToExcelTemplate()
    End Sub

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
                                              ,convert(varchar(20),[TanggalMasuk],113) TanggalMasuk
                                              ,[NoFaktur]
                                              ,b.KodeSupplier
											  ,b.NamaSupplier
                                              ,[Keterangan]
                                              ,a.[CreatedAt]
                                              ,a.[UserCreated]
                                              ,a.[PC]
                                          FROM [db_klinik].[dbo].[Farmasi_Barang_Masuk_H] a
										  left join [dbo].[M_Supplier] b
										  on b.SupplierID=a.SupplierID
                                          order by TanggalMasuk asc
                                    ")

        If tblPasien.Rows.Count = 0 Then
            GridControlData.DataSource = Nothing
        Else
            GridControlData.DataSource = tblPasien

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
        txtTransID.Text = String.Empty
        txtNoFaktur.Text = String.Empty
        cmbSupplier.Text = String.Empty
        cmbSupplier.EditValue = String.Empty
        txtSupplier.Text = String.Empty
        txtKet.Text = String.Empty
    End Sub
    Sub gridtotext()
        Try
            txtTransID.Text = GridViewData.GetFocusedRowCellValue("TransID").ToString
            dtTglMasuk.Text = GridViewData.GetFocusedRowCellValue("TanggalMasuk").ToString
            txtNoFaktur.Text = GridViewData.GetFocusedRowCellValue("NoFaktur").ToString
            cmbSupplier.Text = GridViewData.GetFocusedRowCellValue("KodeSupplier").ToString
            cmbSupplier.EditValue = GridViewData.GetFocusedRowCellValue("KodeSupplier").ToString
            txtKet.EditValue = GridViewData.GetFocusedRowCellValue("Keterangan").ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Sub PrintToExcelTemplate()
        Dim transid = Trim(txtTransID.Text)

        Dim excelApp As Object = Nothing
        Dim workbook As Object = Nothing
        Dim worksheet As Object = Nothing
        'Dim filepath = Application.StartupPath & "\Images\" & nodaftar & ".png"
        Try
            ' 1. Buka template Excel
            excelApp = CreateObject("Excel.Application")
            Dim templatepath As String = Application.StartupPath & "\Template\Bukti_Penerimaan_Barang.xlt"
#Disable Warning BC42017 ' Late bound resolution
            workbook = excelApp.Workbooks.Open(templatepath)
            '#Enable Warning BC42017 ' Late bound resolution
            worksheet = workbook.Sheets(1)

            tblDokter = Proses.ExecuteQuery("SELECT [ID]
                                                  ,[TransID]
                                                  ,a.[KodeBarang]
                                                  ,a.[NamaBarang]
                                                  ,b.Satuan
                                                  ,[QtyMasuk]
                                              FROM [db_klinik].[dbo].[Farmasi_Barang_Masuk_D] a
                                              left join [dbo].[M_Barang] b
                                              on b.KodeBarang=a.KodeBarang
                                              where a.TransID='" & transid & "'")

            If tblDokter.Rows.Count = 0 Then MsgBox("Detail barang belum diinput!") : Exit Sub
            ' 2. Isi data ke template

            tblUser = Proses.ExecuteQuery("SELECT a.[CreatedAt]
                                                      ,b.Username
                                                  FROM [db_klinik].[dbo].[Farmasi_Barang_Masuk_H] a
                                                  left join [dbo].[M_User_Login] b
                                                  on b.UserID=a.UserCreated
                                                  where a.TransID='" & transid & "'")

            With worksheet

                If tblDokter.Rows.Count = 0 Then

                Else
                    ' Contoh isi data
                    .Range("H1").Value = txtSupplier.Text.Trim
                    .Range("H2").Value = txtAlamat.Text.Trim
                    .Range("H3").Value = dtTglMasuk.Text
                    .Range("H4").Value = txtTransID.Text.Trim & " | " & txtNoFaktur.Text.Trim

                    Dim nrow = 6
                    Dim no = 0
                    For x = 0 To tblDokter.Rows.Count - 1
                        no += 1
                        nrow += 1

                        .Range("A" & CStr(nrow)).Value = no
                        ' Merge kolom B dan C
                        .Range("B" & nrow & ":C" & nrow).Merge()
                        .Range("B" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("KodeBarang").ToString)
                        .Range("B" & nrow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("B" & nrow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        ' Merge kolom D sampai G
                        .Range("D" & nrow & ":G" & nrow).Merge()
                        .Range("D" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("NamaBarang").ToString)

                        .Range("H" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("Satuan").ToString)
                        .Range("H" & nrow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("H" & nrow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        .Range("I" & CStr(nrow)).Value = Trim(tblDokter.Rows(x).Item("QtyMasuk").ToString)
                        .Range("I" & nrow).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        .Range("I" & nrow).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

                        Dim cellRange = .Range("A" & nrow & ":I" & nrow)
                        With cellRange.Borders
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                    Next
                    .Range("H" & CStr(nrow + 1)).Value = "Total : "
                    .Range("H" & nrow + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("I" & CStr(nrow + 1)).Value = "=SUM(I7:I" & nrow & ")"
                    .Range("I" & nrow + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("B" & CStr(nrow + 2)).Value = "Diterima oleh : " & tblUser.Rows(0).Item("Username").ToString
                    .Range("B" & CStr(nrow + 3)).Value = "Tanggal : " & tblUser.Rows(0).Item("CreatedAt").ToString
                End If

            End With


            ' 3. Setting printer dan langsung cetak
            'excelWorksheet.PrintOut(
            '    Copies:=1,
            '    Preview:=False,
            '    ActivePrinter:="Nama Printer Anda", ' Ganti dengan nama printer
            '    Collate:=True)
            worksheet.PrintOut(1, 1, 1, False) ' Print langsung

            excelApp.Visible = False
            excelApp.DisplayAlerts = False
            ' 4. Tutup tanpa menyimpan perubahan
            workbook.Close(SaveChanges:=False)
            excelApp.Quit()


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' 5. Bersihkan COM Object
            ReleaseObject(worksheet)
            ReleaseObject(workbook)
            ReleaseObject(excelApp)
        End Try
#Enable Warning BC42017 ' Late bound resolution
    End Sub
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            If obj IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub
End Class