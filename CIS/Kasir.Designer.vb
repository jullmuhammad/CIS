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
        Me.dtTglBilling = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCari = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNoPendaftaran = New DevExpress.XtraEditors.TextEdit()
        Me.txtBillingID = New DevExpress.XtraEditors.TextEdit()
        Me.GridControlData = New DevExpress.XtraGrid.GridControl()
        Me.GridViewData = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.dtTglBilling.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTglBilling.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoPendaftaran.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBillingID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.dtTglBilling)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl7)
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
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtBillingID)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControlData)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1124, 473)
        Me.SplitContainerControl1.SplitterPosition = 128
        Me.SplitContainerControl1.TabIndex = 0
        '
        'dtTglBilling
        '
        Me.dtTglBilling.EditValue = Nothing
        Me.dtTglBilling.Location = New System.Drawing.Point(149, 52)
        Me.dtTglBilling.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtTglBilling.Name = "dtTglBilling"
        Me.dtTglBilling.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglBilling.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTglBilling.Size = New System.Drawing.Size(238, 28)
        Me.dtTglBilling.TabIndex = 31
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(14, 56)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(55, 21)
        Me.LabelControl7.TabIndex = 39
        Me.LabelControl7.Text = "Tanggal"
        '
        'btnPrint
        '
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.ImageOptions.Image = CType(resources.GetObject("btnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrint.Location = New System.Drawing.Point(733, 79)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(136, 41)
        Me.btnPrint.TabIndex = 37
        Me.btnPrint.Text = "Cetak Invoice"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(15, 93)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(88, 21)
        Me.LabelControl6.TabIndex = 36
        Me.LabelControl6.Text = "Status Lunas"
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ImageOptions.Image = CType(resources.GetObject("btnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(917, 79)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 41)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        '
        'btnHapus
        '
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.ImageOptions.Image = CType(resources.GetObject("btnHapus.ImageOptions.Image"), System.Drawing.Image)
        Me.btnHapus.Location = New System.Drawing.Point(588, 79)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(96, 41)
        Me.btnHapus.TabIndex = 34
        Me.btnHapus.Text = "Hapus"
        '
        'cmbStatus
        '
        Me.cmbStatus.Location = New System.Drawing.Point(149, 89)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbStatus.Properties.Items.AddRange(New Object() {"1 - Lunas", "0 - Tidak"})
        Me.cmbStatus.Size = New System.Drawing.Size(238, 28)
        Me.cmbStatus.TabIndex = 32
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(440, 79)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 41)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Simpan"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(273, 19)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 21)
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "No Daftar"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(14, 17)
        Me.LabelControl10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(62, 21)
        Me.LabelControl10.TabIndex = 30
        Me.LabelControl10.Text = "ID (Auto)"
        '
        'btnCari
        '
        Me.btnCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCari.ImageOptions.Image = CType(resources.GetObject("btnCari.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(603, 15)
        Me.btnCari.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(75, 30)
        Me.btnCari.TabIndex = 29
        Me.btnCari.Text = "Cari"
        '
        'txtNoPendaftaran
        '
        Me.txtNoPendaftaran.Location = New System.Drawing.Point(355, 14)
        Me.txtNoPendaftaran.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNoPendaftaran.Name = "txtNoPendaftaran"
        Me.txtNoPendaftaran.Properties.ReadOnly = True
        Me.txtNoPendaftaran.Size = New System.Drawing.Size(240, 28)
        Me.txtNoPendaftaran.TabIndex = 28
        '
        'txtBillingID
        '
        Me.txtBillingID.Location = New System.Drawing.Point(87, 15)
        Me.txtBillingID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBillingID.Name = "txtBillingID"
        Me.txtBillingID.Properties.ReadOnly = True
        Me.txtBillingID.Size = New System.Drawing.Size(177, 28)
        Me.txtBillingID.TabIndex = 27
        '
        'GridControlData
        '
        Me.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlData.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridControlData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlData.MainView = Me.GridViewData
        Me.GridControlData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridControlData.Name = "GridControlData"
        Me.GridControlData.Size = New System.Drawing.Size(1124, 340)
        Me.GridControlData.TabIndex = 1
        Me.GridControlData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewData})
        '
        'GridViewData
        '
        Me.GridViewData.DetailHeight = 432
        Me.GridViewData.GridControl = Me.GridControlData
        Me.GridViewData.Name = "GridViewData"
        '
        'Kasir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 473)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("Kasir.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Kasir"
        Me.Text = "Kasir"
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.dtTglBilling.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTglBilling.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoPendaftaran.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBillingID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCari As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNoPendaftaran As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtBillingID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtTglBilling As DevExpress.XtraEditors.DateEdit
End Class
