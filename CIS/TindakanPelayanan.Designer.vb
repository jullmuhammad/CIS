<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TindakanPelayanan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TindakanPelayanan))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtIDPelayanan = New DevExpress.XtraEditors.TextEdit()
        Me.txtNamaTindakan = New DevExpress.XtraEditors.TextEdit()
        Me.cmbKodeTindakan = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtTarif = New DevExpress.XtraEditors.TextEdit()
        Me.txtJumlah = New DevExpress.XtraEditors.TextEdit()
        Me.mmoKet = New DevExpress.XtraEditors.MemoEdit()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControlData = New DevExpress.XtraGrid.GridControl()
        Me.GridViewData = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.txtID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIDPelayanan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaTindakan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbKodeTindakan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlah.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mmoKet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnClear)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnExit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnHapus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.mmoKet)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtJumlah)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtTarif)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtNamaTindakan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmbKodeTindakan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtIDPelayanan)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl10)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtID)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControlData)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(904, 445)
        Me.SplitContainerControl1.SplitterPosition = 190
        Me.SplitContainerControl1.TabIndex = 0
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(51, 17)
        Me.LabelControl10.TabIndex = 27
        Me.LabelControl10.Text = "ID (Auto)"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(85, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.Properties.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(105, 24)
        Me.txtID.TabIndex = 26
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(198, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 17)
        Me.LabelControl1.TabIndex = 40
        Me.LabelControl1.Text = "ID Pelayanan"
        '
        'txtIDPelayanan
        '
        Me.txtIDPelayanan.Location = New System.Drawing.Point(278, 12)
        Me.txtIDPelayanan.Name = "txtIDPelayanan"
        Me.txtIDPelayanan.Properties.ReadOnly = True
        Me.txtIDPelayanan.Size = New System.Drawing.Size(206, 24)
        Me.txtIDPelayanan.TabIndex = 39
        '
        'txtNamaTindakan
        '
        Me.txtNamaTindakan.Location = New System.Drawing.Point(143, 42)
        Me.txtNamaTindakan.Name = "txtNamaTindakan"
        Me.txtNamaTindakan.Properties.ReadOnly = True
        Me.txtNamaTindakan.Size = New System.Drawing.Size(341, 24)
        Me.txtNamaTindakan.TabIndex = 42
        '
        'cmbKodeTindakan
        '
        Me.cmbKodeTindakan.Location = New System.Drawing.Point(85, 42)
        Me.cmbKodeTindakan.Name = "cmbKodeTindakan"
        Me.cmbKodeTindakan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbKodeTindakan.Properties.NullText = ""
        Me.cmbKodeTindakan.Size = New System.Drawing.Size(53, 24)
        Me.cmbKodeTindakan.TabIndex = 41
        '
        'txtTarif
        '
        Me.txtTarif.Location = New System.Drawing.Point(84, 72)
        Me.txtTarif.Name = "txtTarif"
        Me.txtTarif.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTarif.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTarif.Size = New System.Drawing.Size(162, 24)
        Me.txtTarif.TabIndex = 43
        '
        'txtJumlah
        '
        Me.txtJumlah.EditValue = "1"
        Me.txtJumlah.Location = New System.Drawing.Point(278, 72)
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtJumlah.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtJumlah.Size = New System.Drawing.Size(56, 24)
        Me.txtJumlah.TabIndex = 44
        '
        'mmoKet
        '
        Me.mmoKet.Location = New System.Drawing.Point(84, 102)
        Me.mmoKet.Name = "mmoKet"
        Me.mmoKet.Size = New System.Drawing.Size(400, 68)
        Me.mmoKet.TabIndex = 45
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ImageOptions.Image = CType(resources.GetObject("btnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(721, 115)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 33)
        Me.btnExit.TabIndex = 48
        Me.btnExit.Text = "Exit"
        '
        'btnHapus
        '
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.ImageOptions.Image = CType(resources.GetObject("btnHapus.ImageOptions.Image"), System.Drawing.Image)
        Me.btnHapus.Location = New System.Drawing.Point(613, 115)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(75, 33)
        Me.btnHapus.TabIndex = 47
        Me.btnHapus.Text = "Hapus"
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(501, 115)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 33)
        Me.btnSave.TabIndex = 46
        Me.btnSave.Text = "Simpan"
        '
        'btnClear
        '
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.ImageOptions.Image = CType(resources.GetObject("btnClear.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(493, 12)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(83, 24)
        Me.btnClear.TabIndex = 49
        Me.btnClear.Text = "Bersihkan"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(52, 17)
        Me.LabelControl2.TabIndex = 50
        Me.LabelControl2.Text = "Tindakan"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 75)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 17)
        Me.LabelControl3.TabIndex = 51
        Me.LabelControl3.Text = "Tarif"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(252, 75)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(20, 17)
        Me.LabelControl4.TabIndex = 52
        Me.LabelControl4.Text = "Qty"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(11, 103)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(67, 17)
        Me.LabelControl5.TabIndex = 53
        Me.LabelControl5.Text = "Keterangan"
        '
        'GridControlData
        '
        Me.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlData.MainView = Me.GridViewData
        Me.GridControlData.Name = "GridControlData"
        Me.GridControlData.Size = New System.Drawing.Size(904, 251)
        Me.GridControlData.TabIndex = 3
        Me.GridControlData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewData})
        '
        'GridViewData
        '
        Me.GridViewData.GridControl = Me.GridControlData
        Me.GridViewData.Name = "GridViewData"
        '
        'TindakanPelayanan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 445)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.Image = Global.CIS.My.Resources.Resources.stethoscope
        Me.Name = "TindakanPelayanan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tindakan Pelayanan"
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.txtID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIDPelayanan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaTindakan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbKodeTindakan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlah.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mmoKet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtIDPelayanan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNamaTindakan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbKodeTindakan As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtJumlah As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTarif As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mmoKet As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewData As DevExpress.XtraGrid.Views.Grid.GridView
End Class
