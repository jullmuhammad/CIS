<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterDokter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterDokter))
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtIDDokter = New DevExpress.XtraEditors.TextEdit()
        Me.txtKodeDokter = New DevExpress.XtraEditors.TextEdit()
        Me.txtNama = New DevExpress.XtraEditors.TextEdit()
        Me.cmbSpesialis = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cmbGender = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.mmoAlamat = New DevExpress.XtraEditors.MemoEdit()
        Me.txtSIP = New DevExpress.XtraEditors.TextEdit()
        Me.cmbStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHapus = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControlData = New DevExpress.XtraGrid.GridControl()
        Me.GridViewData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtIDDokter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKodeDokter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSpesialis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGender.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mmoAlamat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSIP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(1042, 283)
        Me.LabelControl10.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(113, 21)
        Me.LabelControl10.TabIndex = 25
        Me.LabelControl10.Text = "ID Dokter (Auto)"
        Me.LabelControl10.Visible = False
        '
        'txtIDDokter
        '
        Me.txtIDDokter.Location = New System.Drawing.Point(1168, 279)
        Me.txtIDDokter.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIDDokter.Name = "txtIDDokter"
        Me.txtIDDokter.Properties.ReadOnly = True
        Me.txtIDDokter.Size = New System.Drawing.Size(186, 28)
        Me.txtIDDokter.TabIndex = 0
        Me.txtIDDokter.TabStop = False
        Me.txtIDDokter.Visible = False
        '
        'txtKodeDokter
        '
        Me.txtKodeDokter.Location = New System.Drawing.Point(160, 14)
        Me.txtKodeDokter.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKodeDokter.Name = "txtKodeDokter"
        Me.txtKodeDokter.Properties.ReadOnly = True
        Me.txtKodeDokter.Size = New System.Drawing.Size(186, 28)
        Me.txtKodeDokter.TabIndex = 1
        Me.txtKodeDokter.TabStop = False
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(160, 51)
        Me.txtNama.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(517, 28)
        Me.txtNama.TabIndex = 2
        '
        'cmbSpesialis
        '
        Me.cmbSpesialis.Location = New System.Drawing.Point(160, 87)
        Me.cmbSpesialis.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSpesialis.Name = "cmbSpesialis"
        Me.cmbSpesialis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbSpesialis.Properties.Items.AddRange(New Object() {"P", "L"})
        Me.cmbSpesialis.Size = New System.Drawing.Size(306, 28)
        Me.cmbSpesialis.TabIndex = 3
        '
        'cmbGender
        '
        Me.cmbGender.Location = New System.Drawing.Point(160, 123)
        Me.cmbGender.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbGender.Properties.Items.AddRange(New Object() {"P", "L"})
        Me.cmbGender.Size = New System.Drawing.Size(68, 28)
        Me.cmbGender.TabIndex = 4
        '
        'mmoAlamat
        '
        Me.mmoAlamat.Location = New System.Drawing.Point(160, 159)
        Me.mmoAlamat.Margin = New System.Windows.Forms.Padding(4)
        Me.mmoAlamat.Name = "mmoAlamat"
        Me.mmoAlamat.Size = New System.Drawing.Size(517, 89)
        Me.mmoAlamat.TabIndex = 5
        '
        'txtSIP
        '
        Me.txtSIP.Location = New System.Drawing.Point(802, 14)
        Me.txtSIP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSIP.Name = "txtSIP"
        Me.txtSIP.Size = New System.Drawing.Size(306, 28)
        Me.txtSIP.TabIndex = 6
        '
        'cmbStatus
        '
        Me.cmbStatus.Location = New System.Drawing.Point(802, 86)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbStatus.Properties.Items.AddRange(New Object() {"Aktif", "Nonaktif"})
        Me.cmbStatus.Size = New System.Drawing.Size(186, 28)
        Me.cmbStatus.TabIndex = 8
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
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl8)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtPhone)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl7)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl6)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl5)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnClear)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnExit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnHapus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnSave)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl10)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmbStatus)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtIDDokter)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtSIP)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtKodeDokter)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.mmoAlamat)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.txtNama)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmbGender)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cmbSpesialis)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControlData)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1334, 610)
        Me.SplitContainerControl1.SplitterPosition = 261
        Me.SplitContainerControl1.TabIndex = 33
        '
        'btnClear
        '
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.ImageOptions.Image = CType(resources.GetObject("btnClear.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(363, 12)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 30)
        Me.btnClear.TabIndex = 29
        Me.btnClear.Text = "Bersihkan"
        '
        'btnExit
        '
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.ImageOptions.Image = CType(resources.GetObject("btnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(1023, 207)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 41)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        '
        'btnHapus
        '
        Me.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHapus.ImageOptions.Image = CType(resources.GetObject("btnHapus.ImageOptions.Image"), System.Drawing.Image)
        Me.btnHapus.Location = New System.Drawing.Point(877, 207)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(96, 41)
        Me.btnHapus.TabIndex = 10
        Me.btnHapus.Text = "Hapus"
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(726, 207)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 41)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Simpan"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 16)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(133, 21)
        Me.LabelControl1.TabIndex = 30
        Me.LabelControl1.Text = "Kode Dokter (Auto)"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 53)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 21)
        Me.LabelControl2.TabIndex = 31
        Me.LabelControl2.Text = "Nama"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 90)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(60, 21)
        Me.LabelControl3.TabIndex = 32
        Me.LabelControl3.Text = "Spesialis"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(19, 126)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(51, 21)
        Me.LabelControl4.TabIndex = 33
        Me.LabelControl4.Text = "Gender"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(19, 161)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(49, 21)
        Me.LabelControl5.TabIndex = 34
        Me.LabelControl5.Text = "Alamat"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(708, 17)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(50, 21)
        Me.LabelControl6.TabIndex = 35
        Me.LabelControl6.Text = "No. SIP"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(708, 89)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(43, 21)
        Me.LabelControl7.TabIndex = 36
        Me.LabelControl7.Text = "Status"
        '
        'GridControlData
        '
        Me.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlData.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControlData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlData.MainView = Me.GridViewData
        Me.GridControlData.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControlData.Name = "GridControlData"
        Me.GridControlData.Size = New System.Drawing.Size(1334, 344)
        Me.GridControlData.TabIndex = 1
        Me.GridControlData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewData})
        '
        'GridViewData
        '
        Me.GridViewData.DetailHeight = 432
        Me.GridViewData.GridControl = Me.GridControlData
        Me.GridViewData.Name = "GridViewData"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(802, 50)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(306, 28)
        Me.txtPhone.TabIndex = 7
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(708, 53)
        Me.LabelControl8.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(44, 21)
        Me.LabelControl8.TabIndex = 37
        Me.LabelControl8.Text = "Phone"
        '
        'MasterDokter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 610)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.Image = Global.CIS.My.Resources.Resources.medical_team
        Me.Name = "MasterDokter"
        Me.Text = "Dokter"
        CType(Me.txtIDDokter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKodeDokter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSpesialis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGender.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mmoAlamat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSIP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtIDDokter As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKodeDokter As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbSpesialis As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cmbGender As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents mmoAlamat As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtSIP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
End Class
