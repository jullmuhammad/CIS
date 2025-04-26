Imports System.ComponentModel
Imports System.Text


Partial Public Class FormMenu
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FormMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me Then
                My.Application.OpenForms.Item(i).Close()

            End If
        Next i
        Login.Close()
    End Sub

    Private Sub btnPasien_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPasien.ItemClick
        MasterPasien.TopLevel = False
        PanelControl1.Controls.Add(MasterPasien)
        ' FormUsers.Dock = DockStyle.Fill
        MasterPasien.Show()
        MasterPasien.BringToFront()
    End Sub

    Private Sub ribbonControl1_Click(sender As Object, e As EventArgs) Handles ribbonControl1.Click

    End Sub

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ribbonControl1.Minimized = True
    End Sub

    Private Sub btnUser_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUser.ItemClick
        MasterUser.TopLevel = False
        PanelControl1.Controls.Add(MasterUser)
        ' FormUsers.Dock = DockStyle.Fill
        MasterUser.Show()
        MasterUser.BringToFront()
    End Sub

    Private Sub btnRawatJalan_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRawatJalan.ItemClick
        Pendaftaran_Rawat_Jalan.TopLevel = False
        PanelControl1.Controls.Add(Pendaftaran_Rawat_Jalan)
        ' FormUsers.Dock = DockStyle.Fill
        Pendaftaran_Rawat_Jalan.Show()
        Pendaftaran_Rawat_Jalan.BringToFront()
    End Sub

    Private Sub btnExit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExit.ItemClick
        Close()
    End Sub

    Private Sub btnPelayananPoli_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPelayananPoli.ItemClick
        Pelayanan_Poliklinik.TopLevel = False
        PanelControl1.Controls.Add(Pelayanan_Poliklinik)
        ' FormUsers.Dock = DockStyle.Fill
        Pelayanan_Poliklinik.Show()
        Pelayanan_Poliklinik.BringToFront()
    End Sub

    Private Sub btnBarangKeluar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBarangKeluar.ItemClick
        FarmasiKeluar.TopLevel = False
        PanelControl1.Controls.Add(FarmasiKeluar)
        ' FormUsers.Dock = DockStyle.Fill
        FarmasiKeluar.Show()
        FarmasiKeluar.BringToFront()
    End Sub
End Class
