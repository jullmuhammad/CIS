﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FarmasiKeluar
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FarmasiKeluar))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtIDResep = New DevExpress.XtraEditors.TextEdit()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtKeterangan = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTujuanKeluar = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbJenisKeluar = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.dtTglKeluar = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCari = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNoPendaftaran = New DevExpress.XtraEditors.TextEdit()
        Me.txtTransID = New DevExpress.XtraEditors.TextEdit()
        Me.GridControlData = New DevExpress.XtraGrid.GridControl()
        Me.GridViewData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HapusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.txtIDResep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTujuanKeluar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbJenisKeluar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTglKeluar.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTglKeluar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoPendaftaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtIDResep)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnClear)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnExit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnHapus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtKeterangan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtTujuanKeluar)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl6)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmbJenisKeluar)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtTglKeluar)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl10)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnCari)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtNoPendaftaran)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtTransID)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControlData)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1140, 494)
        Me.SplitContainerControl1.SplitterPosition = 166
        Me.SplitContainerControl1.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(653, 14)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(42, 21)
        Me.LabelControl3.TabIndex = 52
        Me.LabelControl3.Text = "Resep"
        '
        'txtIDResep
        '
        Me.txtIDResep.Location = New System.Drawing.Point(707, 9)
        Me.txtIDResep.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDResep.Name = "txtIDResep"
        Me.txtIDResep.Properties.ReadOnly = True
        Me.txtIDResep.Size = New System.Drawing.Size(240, 28)
        Me.txtIDResep.TabIndex = 51
        '
        'btnClear
        '
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.ImageOptions.Image = CType(resources.GetObject("btnClear.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(588, 83)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(107, 30)
        Me.btnClear.TabIndex = 50
        Me.btnClear.Text = "Bersihkan"
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ImageOptions.Image = CType(resources.GetObject("btnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(994, 105)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 41)
        Me.btnExit.TabIndex = 49
        Me.btnExit.Text = "Exit"
        '
        'btnHapus
        '
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.ImageOptions.Image = CType(resources.GetObject("btnHapus.ImageOptions.Image"), System.Drawing.Image)
        Me.btnHapus.Location = New System.Drawing.Point(867, 105)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(96, 41)
        Me.btnHapus.TabIndex = 48
        Me.btnHapus.Text = "Hapus"
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(733, 105)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 41)
        Me.btnSave.TabIndex = 47
        Me.btnSave.Text = "Simpan"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 125)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(79, 21)
        Me.LabelControl2.TabIndex = 46
        Me.LabelControl2.Text = "Keterangan"
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(139, 121)
        Me.txtKeterangan.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(555, 28)
        Me.txtKeterangan.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(15, 88)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(95, 21)
        Me.LabelControl5.TabIndex = 44
        Me.LabelControl5.Text = "Tujuan Keluar"
        '
        'txtTujuanKeluar
        '
        Me.txtTujuanKeluar.Location = New System.Drawing.Point(139, 84)
        Me.txtTujuanKeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTujuanKeluar.Name = "txtTujuanKeluar"
        Me.txtTujuanKeluar.Size = New System.Drawing.Size(441, 28)
        Me.txtTujuanKeluar.TabIndex = 3
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(360, 51)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(82, 21)
        Me.LabelControl6.TabIndex = 35
        Me.LabelControl6.Text = "Jenis Keluar"
        '
        'cmbJenisKeluar
        '
        Me.cmbJenisKeluar.Location = New System.Drawing.Point(456, 47)
        Me.cmbJenisKeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbJenisKeluar.Name = "cmbJenisKeluar"
        Me.cmbJenisKeluar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbJenisKeluar.Properties.Items.AddRange(New Object() {"Proses", "Selesai"})
        Me.cmbJenisKeluar.Size = New System.Drawing.Size(238, 28)
        Me.cmbJenisKeluar.TabIndex = 2
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(13, 51)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(103, 21)
        Me.LabelControl7.TabIndex = 33
        Me.LabelControl7.Text = "Tanggal Keluar"
        '
        'dtTglKeluar
        '
        Me.dtTglKeluar.EditValue = Nothing
        Me.dtTglKeluar.Location = New System.Drawing.Point(139, 47)
        Me.dtTglKeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.dtTglKeluar.Name = "dtTglKeluar"
        Me.dtTglKeluar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglKeluar.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglKeluar.Size = New System.Drawing.Size(207, 28)
        Me.dtTglKeluar.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(321, 14)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 21)
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "No Daftar"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(13, 12)
        Me.LabelControl10.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(62, 21)
        Me.LabelControl10.TabIndex = 30
        Me.LabelControl10.Text = "ID (Auto)"
        '
        'btnCari
        '
        Me.btnCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCari.ImageOptions.Image = CType(resources.GetObject("btnCari.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(955, 9)
        Me.btnCari.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(75, 30)
        Me.btnCari.TabIndex = 0
        Me.btnCari.Text = "Cari"
        '
        'txtNoPendaftaran
        '
        Me.txtNoPendaftaran.Location = New System.Drawing.Point(404, 9)
        Me.txtNoPendaftaran.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoPendaftaran.Name = "txtNoPendaftaran"
        Me.txtNoPendaftaran.Properties.ReadOnly = True
        Me.txtNoPendaftaran.Size = New System.Drawing.Size(240, 28)
        Me.txtNoPendaftaran.TabIndex = 28
        '
        'txtTransID
        '
        Me.txtTransID.Location = New System.Drawing.Point(86, 10)
        Me.txtTransID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTransID.Name = "txtTransID"
        Me.txtTransID.Properties.ReadOnly = True
        Me.txtTransID.Size = New System.Drawing.Size(228, 28)
        Me.txtTransID.TabIndex = 27
        '
        'GridControlData
        '
        Me.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlData.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControlData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlData.MainView = Me.GridViewData
        Me.GridControlData.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControlData.Name = "GridControlData"
        Me.GridControlData.Size = New System.Drawing.Size(1140, 323)
        Me.GridControlData.TabIndex = 3
        Me.GridControlData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewData})
        '
        'GridViewData
        '
        Me.GridViewData.DetailHeight = 432
        Me.GridViewData.GridControl = Me.GridControlData
        Me.GridViewData.Name = "GridViewData"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HapusToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(211, 56)
        '
        'HapusToolStripMenuItem
        '
        Me.HapusToolStripMenuItem.Name = "HapusToolStripMenuItem"
        Me.HapusToolStripMenuItem.Size = New System.Drawing.Size(210, 24)
        Me.HapusToolStripMenuItem.Text = "Hapus"
        '
        'FarmasiKeluar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 494)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.Image = Global.CIS.My.Resources.Resources.outbound
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FarmasiKeluar"
        Me.Text = "Farmasi Keluar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.txtIDResep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTujuanKeluar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbJenisKeluar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTglKeluar.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTglKeluar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoPendaftaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCari As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNoPendaftaran As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTransID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtTglKeluar As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbJenisKeluar As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTujuanKeluar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtKeterangan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtIDResep As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents HapusToolStripMenuItem As ToolStripMenuItem
End Class
