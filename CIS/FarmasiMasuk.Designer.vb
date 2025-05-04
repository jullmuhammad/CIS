<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FarmasiMasuk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FarmasiMasuk))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.btnBarangDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtKet = New DevExpress.XtraEditors.TextEdit()
        Me.txtSupplier = New DevExpress.XtraEditors.TextEdit()
        Me.cmbSupplier = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtNoFaktur = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.dtTglMasuk = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTransID = New DevExpress.XtraEditors.TextEdit()
        Me.GridControlData = New DevExpress.XtraGrid.GridControl()
        Me.GridViewData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.txtAlamat = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.txtKet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSupplier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupplier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoFaktur.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTglMasuk.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTglMasuk.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlamat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainerControl1.Panel1.AutoScroll = True
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtAlamat)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnPrint)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnBarangDetail)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnClear)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnExit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnHapus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtKet)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtSupplier)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmbSupplier)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtNoFaktur)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtTglMasuk)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl10)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtTransID)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.AutoScroll = True
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControlData)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1329, 656)
        Me.SplitContainerControl1.SplitterPosition = 243
        Me.SplitContainerControl1.TabIndex = 0
        '
        'btnBarangDetail
        '
        Me.btnBarangDetail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBarangDetail.Enabled = False
        Me.btnBarangDetail.ImageOptions.Image = CType(resources.GetObject("btnBarangDetail.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBarangDetail.Location = New System.Drawing.Point(139, 193)
        Me.btnBarangDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBarangDetail.Name = "btnBarangDetail"
        Me.btnBarangDetail.Size = New System.Drawing.Size(126, 41)
        Me.btnBarangDetail.TabIndex = 54
        Me.btnBarangDetail.Text = "Detail Barang"
        '
        'btnClear
        '
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.ImageOptions.Image = CType(resources.GetObject("btnClear.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(375, 11)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(107, 30)
        Me.btnClear.TabIndex = 53
        Me.btnClear.Text = "Bersihkan"
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ImageOptions.Image = CType(resources.GetObject("btnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(1094, 149)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 41)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        '
        'btnHapus
        '
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.ImageOptions.Image = CType(resources.GetObject("btnHapus.ImageOptions.Image"), System.Drawing.Image)
        Me.btnHapus.Location = New System.Drawing.Point(941, 149)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(96, 41)
        Me.btnHapus.TabIndex = 5
        Me.btnHapus.Text = "Hapus"
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(787, 149)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 41)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Simpan"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 160)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(79, 21)
        Me.LabelControl3.TabIndex = 41
        Me.LabelControl3.Text = "Keterangan"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 88)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 21)
        Me.LabelControl2.TabIndex = 40
        Me.LabelControl2.Text = "Supplier"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(386, 52)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(72, 21)
        Me.LabelControl1.TabIndex = 39
        Me.LabelControl1.Text = "No. Faktur"
        '
        'txtKet
        '
        Me.txtKet.Location = New System.Drawing.Point(139, 157)
        Me.txtKet.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKet.Name = "txtKet"
        Me.txtKet.Size = New System.Drawing.Size(602, 28)
        Me.txtKet.TabIndex = 3
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(298, 85)
        Me.txtSupplier.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Properties.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(411, 28)
        Me.txtSupplier.TabIndex = 38
        '
        'cmbSupplier
        '
        Me.cmbSupplier.Location = New System.Drawing.Point(139, 85)
        Me.cmbSupplier.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbSupplier.Properties.NullText = ""
        Me.cmbSupplier.Size = New System.Drawing.Size(152, 28)
        Me.cmbSupplier.TabIndex = 2
        '
        'txtNoFaktur
        '
        Me.txtNoFaktur.Location = New System.Drawing.Point(466, 49)
        Me.txtNoFaktur.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoFaktur.Name = "txtNoFaktur"
        Me.txtNoFaktur.Size = New System.Drawing.Size(275, 28)
        Me.txtNoFaktur.TabIndex = 1
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 52)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(105, 21)
        Me.LabelControl7.TabIndex = 35
        Me.LabelControl7.Text = "Tanggal Masuk"
        '
        'dtTglMasuk
        '
        Me.dtTglMasuk.EditValue = Nothing
        Me.dtTglMasuk.Location = New System.Drawing.Point(139, 49)
        Me.dtTglMasuk.Margin = New System.Windows.Forms.Padding(4)
        Me.dtTglMasuk.Name = "dtTglMasuk"
        Me.dtTglMasuk.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglMasuk.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglMasuk.Size = New System.Drawing.Size(228, 28)
        Me.dtTglMasuk.TabIndex = 0
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl10.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(62, 21)
        Me.LabelControl10.TabIndex = 32
        Me.LabelControl10.Text = "ID (Auto)"
        '
        'txtTransID
        '
        Me.txtTransID.Location = New System.Drawing.Point(139, 13)
        Me.txtTransID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTransID.Name = "txtTransID"
        Me.txtTransID.Properties.ReadOnly = True
        Me.txtTransID.Size = New System.Drawing.Size(228, 28)
        Me.txtTransID.TabIndex = 31
        '
        'GridControlData
        '
        Me.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlData.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControlData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlData.MainView = Me.GridViewData
        Me.GridControlData.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControlData.Name = "GridControlData"
        Me.GridControlData.Size = New System.Drawing.Size(1329, 408)
        Me.GridControlData.TabIndex = 4
        Me.GridControlData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewData})
        '
        'GridViewData
        '
        Me.GridViewData.DetailHeight = 432
        Me.GridViewData.GridControl = Me.GridControlData
        Me.GridViewData.Name = "GridViewData"
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(298, 193)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(116, 41)
        Me.btnPrint.TabIndex = 55
        Me.btnPrint.Text = "Cetak Bukti"
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(139, 121)
        Me.txtAlamat.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Properties.ReadOnly = True
        Me.txtAlamat.Size = New System.Drawing.Size(570, 28)
        Me.txtAlamat.TabIndex = 56
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 124)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(49, 21)
        Me.LabelControl4.TabIndex = 57
        Me.LabelControl4.Text = "Alamat"
        '
        'FarmasiMasuk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1329, 656)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.Image = Global.CIS.My.Resources.Resources.warehouse
        Me.Name = "FarmasiMasuk"
        Me.Text = "Farmasi Masuk"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.txtKet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSupplier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupplier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoFaktur.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTglMasuk.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTglMasuk.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlamat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTransID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtTglMasuk As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtNoFaktur As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSupplier As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbSupplier As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtKet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnBarangDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtAlamat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
