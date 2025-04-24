Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class CariResep
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable

    Private Sub GridControlData_DoubleClick(sender As Object, e As EventArgs) Handles GridControlData.DoubleClick
        Try
            If GridViewData.RowCount > 0 Then
                gridtotext()
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        data()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        data()
    End Sub

    Private Sub CariResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateEdit1.EditValue = Date.Now
        RadioGroup1.SelectedIndex = 0
    End Sub
    Sub data()
        Dim radiogrup = RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description
        Dim yyyymm = Trim(DateEdit1.Text)
        If radiogrup = "Belum Proses" Then

            tblPasien = Proses.ExecuteQuery("SELECT [IDResep]
                                              ,a.[IDPelayanan]
                                              ,b.NoPendaftaran
                                              ,[TanggalResep]
	                                          ,c.PasienID
	                                          ,d.NamaLengkap
                                              ,a.[Status]
                                          FROM [db_klinik].[dbo].[T_ResepObat] a
                                          left join [dbo].[T_PelayananPoli] b
                                          on b.IDPelayanan=a.IDPelayanan
                                          left join [dbo].[T_Pendaftaran] c
                                          on c.NoPendaftaran=b.NoPendaftaran
                                          left join M_Pasien d
                                          on d.ID=c.PasienID
                                          where substring(convert(varchar(20),a.CreatedAt,113),4,8)='" & yyyymm & "'")
        Else
            tblPasien = Proses.ExecuteQuery("SELECT [TransID]
		                                        ,[NoPendaftaran]
                                              ,[KodeResep]
                                              ,[TanggalKeluar]
                                              ,[JenisKeluar]
                                              ,[TujuanKeluar]
                                              ,[Keterangan]
      
                                          FROM [db_klinik].[dbo].[Farmasi_Barang_Keluar_H] a
                                          where substring(convert(varchar(20),a.CreatedAt,113),4,8)='" & yyyymm & "'")
        End If

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
    Sub gridtotext()
        Try
            Dim radiogrup = RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description

            If radiogrup = "Belum Proses" Then
                With FarmasiKeluar
                    .txtNoPendaftaran.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString
                    .txtIDResep.Text = GridViewData.GetFocusedRowCellValue("IDResep").ToString
                End With
            Else
                With FarmasiKeluar
                    .txtNoPendaftaran.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString
                    .txtIDResep.Text = GridViewData.GetFocusedRowCellValue("KodeResep").ToString
                    .txtTransID.Text = GridViewData.GetFocusedRowCellValue("TransID").ToString
                    .dtTglKeluar.Text = GridViewData.GetFocusedRowCellValue("TanggalKeluar").ToString
                    .cmbJenisKeluar.Text = GridViewData.GetFocusedRowCellValue("JenisKeluar").ToString
                    .txtTujuanKeluar.Text = GridViewData.GetFocusedRowCellValue("TujuanKeluar").ToString
                    .txtKeterangan.Text = GridViewData.GetFocusedRowCellValue("Keterangan").ToString
                End With
            End If
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class