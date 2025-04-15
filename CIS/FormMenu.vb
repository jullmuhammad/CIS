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
End Class
