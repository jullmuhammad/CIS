Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class CariPendaftaran
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblUser, tblPasien, tblPoli, tblCaraBayar, tblRJ, tblDokter, tblKamar As DataTable
    Public tipe As String
    Private Sub GridControlData_DoubleClick(sender As Object, e As EventArgs) Handles GridControlData.DoubleClick
        Try
            If GridViewData.RowCount > 0 Then
                If tipe = "Kasir" Then
                    gridtotextkasir()
                Else

                    gridtotext()
                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim aksi As String
    Dim shostname As String = System.Net.Dns.GetHostName
    Private Sub CariPendaftaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
    End Sub
    Sub data()

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
                                      FROM [db_klinik].[dbo].[T_Pendaftaran] a
									  left join [dbo].[M_Pasien] psn
									  on psn.ID=a.PasienID
									  left join [dbo].[M_Poliklinik] pol
									  on pol.PoliklinikID=a.PoliklinikID
									  left join [dbo].[M_Dokter] dr
									  on dr.ID=a.DokterID
                                      left join [dbo].[M_Kamar] kmr
                                      on kmr.[KamarID]=a.[KamarID]
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
            Dim namapasien As GridColumn = gridView1.Columns("NamaPasien")
            Dim created As GridColumn = gridView1.Columns("CreatedAt")
            Dim polid As GridColumn = gridView1.Columns("PoliklinikID")
            Dim dokid As GridColumn = gridView1.Columns("DokterID")
            Dim kamarid As GridColumn = gridView1.Columns("KamarID")

            created.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            created.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            tgl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            tgl.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            id.Visible = False
            pasien.Visible = False
            polid.Visible = False
            dokid.Visible = False
            kamarid.Visible = False

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
    Sub gridtotext()
        Try
            With Pelayanan_Poliklinik
                .txtNoPendaftaran.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString
                .txtJenisDaftar.Text = GridViewData.GetFocusedRowCellValue("JenisLayanan").ToString
                .txtPasien.Text = GridViewData.GetFocusedRowCellValue("PasienID").ToString & " - " & GridViewData.GetFocusedRowCellValue("NamaPasien").ToString
                .txtPoliklinikID.Text = GridViewData.GetFocusedRowCellValue("PoliklinikID").ToString & " - " & GridViewData.GetFocusedRowCellValue("NamaPoliklinik").ToString
                .txtDokterID.Text = GridViewData.GetFocusedRowCellValue("DokterID").ToString & " - " & GridViewData.GetFocusedRowCellValue("NamaDokter").ToString
                .mmoKeluhan.Text = GridViewData.GetFocusedRowCellValue("Keluhan").ToString

                .data()
            End With
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Sub gridtotextkasir()
        Try
            With Kasir
                .txtNoPendaftaran.Text = GridViewData.GetFocusedRowCellValue("NoPendaftaran").ToString

                .data()
            End With
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class