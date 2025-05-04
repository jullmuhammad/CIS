Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class CariPendaftaranKasir
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable

    Private Sub GridControlData_DoubleClick(sender As Object, e As EventArgs) Handles GridControlData.DoubleClick
        Try
            If GridViewData.RowCount > 0 Then
                gridtotextkasir()
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        data()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        If RadioGroup1.SelectedIndex >= 0 Then

            data()
        End If
    End Sub

    Private Sub CariPendaftaranKasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateEdit1.EditValue = Date.Now
        RadioGroup1.SelectedIndex = 0
    End Sub
    Sub data()
        If RadioGroup1.SelectedIndex = -1 Then Exit Sub

        GridViewData.Columns.Clear()

        Dim radiogrup = RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description
        Dim yyyymm = Trim(DateEdit1.Text)

        If radiogrup = "Belum Proses" Then
            tblPasien = Proses.ExecuteQuery("SELECT a.[ID]
                                          ,[NoPendaftaran]
                                          ,[TanggalDaftar]
                                           ,[JenisLayanan]
                                          ,a.[PasienID] 
										  ,psn.NamaLengkap NamaPasien
                                          ,a.[PoliklinikID] 
										  ,pol.NamaPoliklinik
                                          ,a.[DokterID]
										  ,dr.Nama NamaDokter
                                          ,[CaraBayar]
                                          ,[NoKartuJKN]
                                          ,[Keluhan]
                                          ,[Diagnosa]
                                          ,a.[KamarID]
                                          ,kmr.KodeKamar
                                          ,kmr.NamaKamar
                                          ,[CaraMasuk]
                                          ,[AsalRujukan]
                                          ,[StatusKunjungan]
                                          ,a.[CreatedAt]
                                          ,a.[UserCreated]
                                          ,a.[PC]
                                          ,isnull(bill.BillingID,'') BillingID
                                          ,TanggalBilling
										  ,isnull(bill.StatusLunas,'') StatusLunas
                                      FROM [db_klinik].[dbo].[T_Pendaftaran] a
									  left join [dbo].[M_Pasien] psn
									  on psn.ID=a.PasienID
									  left join [dbo].[M_Poliklinik] pol
									  on pol.PoliklinikID=a.PoliklinikID
									  left join [dbo].[M_Dokter] dr
									  on dr.ID=a.DokterID
                                      left join [dbo].[M_Kamar] kmr
                                      on kmr.[KamarID]=a.[KamarID]
									  left join [dbo].[Transaksi_Billing_H] bill
									  on bill.NoRegistrasi=a.NoPendaftaran
                                       where StatusKunjungan in ('Dalam Pemeriksaan','Sedang di Farmasi')
									   and bill.NoRegistrasi is null
                                        order by TanggalDaftar desc
                                    ")
        Else
            tblPasien = Proses.ExecuteQuery("SELECT a.[ID]
                                          ,[NoPendaftaran]
                                          ,[TanggalDaftar]
                                           ,[JenisLayanan]
                                          ,a.[PasienID] 
										  ,psn.NamaLengkap NamaPasien
                                          ,a.[PoliklinikID] 
										  ,pol.NamaPoliklinik
                                          ,a.[DokterID]
										  ,dr.Nama NamaDokter
                                          ,[CaraBayar]
                                          ,[NoKartuJKN]
                                          ,[Keluhan]
                                          ,[Diagnosa]
                                          ,a.[KamarID]
                                          ,kmr.KodeKamar
                                          ,kmr.NamaKamar
                                          ,[CaraMasuk]
                                          ,[AsalRujukan]
                                          ,[StatusKunjungan]
                                          ,a.[CreatedAt]
                                          ,a.[UserCreated]
                                          ,a.[PC]
                                          ,isnull(bill.BillingID,'') BillingID
                                          ,TanggalBilling
										  ,isnull(bill.StatusLunas,'') StatusLunas
                                      FROM [db_klinik].[dbo].[T_Pendaftaran] a
									  left join [dbo].[M_Pasien] psn
									  on psn.ID=a.PasienID
									  left join [dbo].[M_Poliklinik] pol
									  on pol.PoliklinikID=a.PoliklinikID
									  left join [dbo].[M_Dokter] dr
									  on dr.ID=a.DokterID
                                      left join [dbo].[M_Kamar] kmr
                                      on kmr.[KamarID]=a.[KamarID]
									  left join [dbo].[Transaksi_Billing_H] bill
									  on bill.NoRegistrasi=a.NoPendaftaran
                                       where StatusKunjungan='Menunggu Pembayaran'
									   and bill.NoRegistrasi is not null
                                        order by TanggalDaftar desc
                                    ")
        End If


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
            Dim namapasien As GridColumn = gridView1.Columns("NamaPasien")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")
            Dim polid As GridColumn = gridView1.Columns("PoliklinikID")
            Dim dokid As GridColumn = gridView1.Columns("DokterID")
            Dim kamarid As GridColumn = gridView1.Columns("KamarID")
            Dim billid As GridColumn = gridView1.Columns("BillingID")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            tgl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            tgl.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            id.Visible = False
            pasien.Visible = False
            polid.Visible = False
            dokid.Visible = False
            kamarid.Visible = False
            'billid.Visible = False

            noreg.Fixed = FixedStyle.Left
            tgl.Fixed = FixedStyle.Left
            namapasien.Fixed = FixedStyle.Left

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
    Sub gridtotextkasir()
        Try
            With Kasir
                .txtNoPendaftaran.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString
                .txtBillingID.Text = GridViewData.GetFocusedRowCellValue("BillingID").ToString
                .dtTglBilling.Text = GridViewData.GetFocusedRowCellValue("TanggalBilling").ToString
                '.dtTglBilling.EditValue = GridViewData.GetFocusedRowCellValue("TanggalBilling").ToString
                .cmbStatus.Text = GridViewData.GetFocusedRowCellValue("StatusLunas").ToString
                'MsgBox(GridViewData.GetFocusedRowCellValue("TanggalBilling").ToString)
                .cmbStatus.SelectedIndex = 1
                .data()
            End With
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class