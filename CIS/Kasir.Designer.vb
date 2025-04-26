<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kasir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Kasir))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCari = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNoPendaftaran = New DevExpress.XtraEditors.TextEdit()
        Me.txtIDPelayanan = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlData = New DevExpress.XtraGrid.GridControl()
        Me.GridViewData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.dtTglPeriksa = New DevExpress.XtraEditors.DateEdit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.txtNoPendaftaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIDPelayanan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTglPeriksa.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTglPeriksa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtTglPeriksa)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnPrint)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl6)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnExit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnHapus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmbStatus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl10)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnCari)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtNoPendaftaran)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtIDPelayanan)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControlData)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(874, 383)
        Me.SplitContainerControl1.SplitterPosition = 104
        Me.SplitContainerControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(212, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 17)
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "No Daftar"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(51, 17)
        Me.LabelControl10.TabIndex = 30
        Me.LabelControl10.Text = "ID (Auto)"
        '
        'btnCari
        '
        Me.btnCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCari.ImageOptions.Image = CType(resources.GetObject("btnCari.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(469, 12)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(58, 24)
        Me.btnCari.TabIndex = 29
        Me.btnCari.Text = "Cari"
        '
        'txtNoPendaftaran
        '
        Me.txtNoPendaftaran.Location = New System.Drawing.Point(276, 11)
        Me.txtNoPendaftaran.Name = "txtNoPendaftaran"
        Me.txtNoPendaftaran.Properties.ReadOnly = True
        Me.txtNoPendaftaran.Size = New System.Drawing.Size(187, 24)
        Me.txtNoPendaftaran.TabIndex = 28
        '
        'txtIDPelayanan
        '
        Me.txtIDPelayanan.Location = New System.Drawing.Point(68, 12)
        Me.txtIDPelayanan.Name = "txtIDPelayanan"
        Me.txtIDPelayanan.Properties.ReadOnly = True
        Me.txtIDPelayanan.Size = New System.Drawing.Size(138, 24)
        Me.txtIDPelayanan.TabIndex = 27
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 75)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(72, 17)
        Me.LabelControl6.TabIndex = 36
        Me.LabelControl6.Text = "Status Lunas"
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ImageOptions.Image = CType(resources.GetObject("btnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(713, 64)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 33)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        '
        'btnHapus
        '
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.ImageOptions.Image = CType(resources.GetObject("btnHapus.ImageOptions.Image"), System.Drawing.Image)
        Me.btnHapus.Location = New System.Drawing.Point(457, 64)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(75, 33)
        Me.btnHapus.TabIndex = 34
        Me.btnHapus.Text = "Hapus"
        '
        'cmbStatus
        '
        Me.cmbStatus.Location = New System.Drawing.Point(116, 72)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbStatus.Properties.Items.AddRange(New Object() {"1 - Lunas", "2 - Tidak"})
        Me.cmbStatus.Size = New System.Drawing.Size(185, 24)
        Me.cmbStatus.TabIndex = 32
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(342, 64)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 33)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Simpan"
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(570, 64)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 33)
        Me.btnPrint.TabIndex = 37
        Me.btnPrint.Text = "Cetak Invoice"
        '
        'GridControlData
        '
        Me.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlData.MainView = Me.GridViewData
        Me.GridControlData.Name = "GridControlData"
        Me.GridControlData.Size = New System.Drawing.Size(874, 275)
        Me.GridControlData.TabIndex = 1
        Me.GridControlData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewData})
        '
        'GridViewData
        '
        Me.GridViewData.GridControl = Me.GridControlData
        Me.GridViewData.Name = "GridViewData"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(11, 45)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(47, 17)
        Me.LabelControl7.TabIndex = 39
        Me.LabelControl7.Text = "Tanggal"
        '
        'dtTglPeriksa
        '
        Me.dtTglPeriksa.EditValue = Nothing
        Me.dtTglPeriksa.Location = New System.Drawing.Point(116, 42)
        Me.dtTglPeriksa.Name = "dtTglPeriksa"
        Me.dtTglPeriksa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglPeriksa.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglPeriksa.Size = New System.Drawing.Size(185, 24)
        Me.dtTglPeriksa.TabIndex = 38
        '
        'Kasir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 383)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("Kasir.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "Kasir"
        Me.Text = "Kasir"
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.txtNoPendaftaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIDPelayanan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTglPeriksa.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTglPeriksa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCari As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNoPendaftaran As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtIDPelayanan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtTglPeriksa As DevExpress.XtraEditors.DateEdit
End Class
