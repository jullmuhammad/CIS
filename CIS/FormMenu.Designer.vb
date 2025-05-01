Partial Public Class FormMenu
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMenu))
        Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnLogout = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExit = New DevExpress.XtraBars.BarButtonItem()
        Me.btnChangePwd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPasien = New DevExpress.XtraBars.BarButtonItem()
        Me.btnKamar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDokter = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUser = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRawatJalan = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRekamMedis = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTindakanRM = New DevExpress.XtraBars.BarButtonItem()
        Me.btnObatRM = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBarangMasuk = New DevExpress.XtraBars.BarButtonItem()
        Me.btnBarangKeluar = New DevExpress.XtraBars.BarButtonItem()
        Me.txtUsername = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.txtRole = New DevExpress.XtraBars.BarStaticItem()
        Me.txtUserID = New DevExpress.XtraBars.BarStaticItem()
        Me.btnKasir = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPelayananPoli = New DevExpress.XtraBars.BarButtonItem()
        Me.rpSystem = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgAction = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSystem = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpMaster = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgMasterData = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgFarmasi = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgUsers = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpTransaksi = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgPendaftaran = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPemeriksaan = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgRekamMedis = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgTransFarmasi = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgBilling = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.lblIP = New DevExpress.XtraEditors.LabelControl()
        Me.lblFolder = New DevExpress.XtraEditors.LabelControl()
        Me.lblemail = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl1
        '
        Me.ribbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(45, 48, 45, 48)
        Me.ribbonControl1.ExpandCollapseItem.Id = 0
        Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.btnLogout, Me.btnExit, Me.btnChangePwd, Me.btnPasien, Me.btnKamar, Me.btnDokter, Me.btnBarang, Me.btnUser, Me.btnRawatJalan, Me.btnRekamMedis, Me.btnTindakanRM, Me.btnObatRM, Me.btnBarangMasuk, Me.btnBarangKeluar, Me.txtUsername, Me.BarStaticItem1, Me.txtRole, Me.txtUserID, Me.btnKasir, Me.btnPelayananPoli})
        Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ribbonControl1.MaxItemId = 23
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.OptionsMenuMinWidth = 495
        Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpSystem, Me.rpMaster, Me.rpTransaksi})
        Me.ribbonControl1.Size = New System.Drawing.Size(1128, 197)
        Me.ribbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'btnLogout
        '
        Me.btnLogout.Caption = "Logout"
        Me.btnLogout.Id = 1
        Me.btnLogout.ImageOptions.Image = CType(resources.GetObject("btnLogout.ImageOptions.Image"), System.Drawing.Image)
        Me.btnLogout.ImageOptions.LargeImage = CType(resources.GetObject("btnLogout.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnLogout.Name = "btnLogout"
        '
        'btnExit
        '
        Me.btnExit.Caption = "Exit"
        Me.btnExit.Id = 2
        Me.btnExit.ImageOptions.Image = CType(resources.GetObject("btnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExit.ImageOptions.LargeImage = CType(resources.GetObject("btnExit.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExit.Name = "btnExit"
        '
        'btnChangePwd
        '
        Me.btnChangePwd.Caption = "Change Password"
        Me.btnChangePwd.Id = 3
        Me.btnChangePwd.ImageOptions.Image = CType(resources.GetObject("btnChangePwd.ImageOptions.Image"), System.Drawing.Image)
        Me.btnChangePwd.ImageOptions.LargeImage = CType(resources.GetObject("btnChangePwd.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnChangePwd.Name = "btnChangePwd"
        '
        'btnPasien
        '
        Me.btnPasien.Caption = "Pasien"
        Me.btnPasien.Id = 4
        Me.btnPasien.ImageOptions.Image = CType(resources.GetObject("btnPasien.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPasien.ImageOptions.LargeImage = CType(resources.GetObject("btnPasien.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnPasien.Name = "btnPasien"
        '
        'btnKamar
        '
        Me.btnKamar.Caption = "Kamar"
        Me.btnKamar.Id = 5
        Me.btnKamar.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.bed
        Me.btnKamar.Name = "btnKamar"
        '
        'btnDokter
        '
        Me.btnDokter.Caption = "Dokter"
        Me.btnDokter.Id = 6
        Me.btnDokter.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.medical_team
        Me.btnDokter.Name = "btnDokter"
        '
        'btnBarang
        '
        Me.btnBarang.Caption = "Obat/Alkes"
        Me.btnBarang.Id = 7
        Me.btnBarang.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.syringe
        Me.btnBarang.Name = "btnBarang"
        '
        'btnUser
        '
        Me.btnUser.Caption = "Users"
        Me.btnUser.Id = 8
        Me.btnUser.ImageOptions.Image = CType(resources.GetObject("btnUser.ImageOptions.Image"), System.Drawing.Image)
        Me.btnUser.ImageOptions.LargeImage = CType(resources.GetObject("btnUser.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnUser.Name = "btnUser"
        '
        'btnRawatJalan
        '
        Me.btnRawatJalan.Caption = "Pendaftaran"
        Me.btnRawatJalan.Id = 9
        Me.btnRawatJalan.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.doctor_patient
        Me.btnRawatJalan.Name = "btnRawatJalan"
        '
        'btnRekamMedis
        '
        Me.btnRekamMedis.Caption = "Rekam Medis"
        Me.btnRekamMedis.Id = 12
        Me.btnRekamMedis.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.health_report
        Me.btnRekamMedis.Name = "btnRekamMedis"
        '
        'btnTindakanRM
        '
        Me.btnTindakanRM.Caption = "Tindakan"
        Me.btnTindakanRM.Id = 13
        Me.btnTindakanRM.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.monitor
        Me.btnTindakanRM.Name = "btnTindakanRM"
        '
        'btnObatRM
        '
        Me.btnObatRM.Caption = "Obat/Alkes"
        Me.btnObatRM.Id = 14
        Me.btnObatRM.ImageOptions.Image = CType(resources.GetObject("btnObatRM.ImageOptions.Image"), System.Drawing.Image)
        Me.btnObatRM.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.medicine
        Me.btnObatRM.Name = "btnObatRM"
        '
        'btnBarangMasuk
        '
        Me.btnBarangMasuk.Caption = "Barang Masuk"
        Me.btnBarangMasuk.Id = 15
        Me.btnBarangMasuk.ImageOptions.Image = CType(resources.GetObject("btnBarangMasuk.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBarangMasuk.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.warehouse
        Me.btnBarangMasuk.Name = "btnBarangMasuk"
        '
        'btnBarangKeluar
        '
        Me.btnBarangKeluar.Caption = "Barang Keluar"
        Me.btnBarangKeluar.Id = 16
        Me.btnBarangKeluar.ImageOptions.Image = CType(resources.GetObject("btnBarangKeluar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBarangKeluar.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.outbound
        Me.btnBarangKeluar.Name = "btnBarangKeluar"
        '
        'txtUsername
        '
        Me.txtUsername.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.txtUsername.Id = 17
        Me.txtUsername.Name = "txtUsername"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.BarStaticItem1.Caption = "-"
        Me.BarStaticItem1.Id = 18
        Me.BarStaticItem1.Name = "BarStaticItem1"
        '
        'txtRole
        '
        Me.txtRole.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.txtRole.Id = 19
        Me.txtRole.Name = "txtRole"
        '
        'txtUserID
        '
        Me.txtUserID.Id = 20
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnKasir
        '
        Me.btnKasir.Caption = "Kasir"
        Me.btnKasir.Id = 21
        Me.btnKasir.ImageOptions.Image = CType(resources.GetObject("btnKasir.ImageOptions.Image"), System.Drawing.Image)
        Me.btnKasir.ImageOptions.LargeImage = CType(resources.GetObject("btnKasir.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnKasir.Name = "btnKasir"
        '
        'btnPelayananPoli
        '
        Me.btnPelayananPoli.Caption = "Poliklinik"
        Me.btnPelayananPoli.Id = 22
        Me.btnPelayananPoli.ImageOptions.Image = Global.CIS.My.Resources.Resources.clinic
        Me.btnPelayananPoli.ImageOptions.LargeImage = Global.CIS.My.Resources.Resources.clinic
        Me.btnPelayananPoli.Name = "btnPelayananPoli"
        '
        'rpSystem
        '
        Me.rpSystem.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgAction, Me.rpgSystem})
        Me.rpSystem.Name = "rpSystem"
        Me.rpSystem.Text = "System"
        '
        'rpgAction
        '
        Me.rpgAction.ItemLinks.Add(Me.btnLogout)
        Me.rpgAction.ItemLinks.Add(Me.btnExit)
        Me.rpgAction.Name = "rpgAction"
        '
        'rpgSystem
        '
        Me.rpgSystem.ItemLinks.Add(Me.btnChangePwd)
        Me.rpgSystem.Name = "rpgSystem"
        Me.rpgSystem.Text = "Action"
        '
        'rpMaster
        '
        Me.rpMaster.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgMasterData, Me.rpgFarmasi, Me.rpgUsers})
        Me.rpMaster.Name = "rpMaster"
        Me.rpMaster.Text = "Master"
        '
        'rpgMasterData
        '
        Me.rpgMasterData.ItemLinks.Add(Me.btnPasien)
        Me.rpgMasterData.ItemLinks.Add(Me.btnKamar)
        Me.rpgMasterData.ItemLinks.Add(Me.btnDokter)
        Me.rpgMasterData.Name = "rpgMasterData"
        Me.rpgMasterData.Text = "General"
        '
        'rpgFarmasi
        '
        Me.rpgFarmasi.ItemLinks.Add(Me.btnBarang)
        Me.rpgFarmasi.Name = "rpgFarmasi"
        Me.rpgFarmasi.Text = "Farmasi"
        '
        'rpgUsers
        '
        Me.rpgUsers.ItemLinks.Add(Me.btnUser)
        Me.rpgUsers.Name = "rpgUsers"
        Me.rpgUsers.Text = "Data"
        '
        'rpTransaksi
        '
        Me.rpTransaksi.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgPendaftaran, Me.rpgPemeriksaan, Me.rpgRekamMedis, Me.rpgTransFarmasi, Me.rpgBilling})
        Me.rpTransaksi.Name = "rpTransaksi"
        Me.rpTransaksi.Text = "Transaksi"
        '
        'rpgPendaftaran
        '
        Me.rpgPendaftaran.ItemLinks.Add(Me.btnRawatJalan)
        Me.rpgPendaftaran.Name = "rpgPendaftaran"
        Me.rpgPendaftaran.Text = "Pendaftaran"
        '
        'rpgPemeriksaan
        '
        Me.rpgPemeriksaan.ItemLinks.Add(Me.btnPelayananPoli)
        Me.rpgPemeriksaan.Name = "rpgPemeriksaan"
        Me.rpgPemeriksaan.Text = "Pemeriksaan"
        '
        'rpgRekamMedis
        '
        Me.rpgRekamMedis.ItemLinks.Add(Me.btnRekamMedis)
        Me.rpgRekamMedis.ItemLinks.Add(Me.btnTindakanRM)
        Me.rpgRekamMedis.ItemLinks.Add(Me.btnObatRM)
        Me.rpgRekamMedis.Name = "rpgRekamMedis"
        Me.rpgRekamMedis.Text = "Rekam Medis"
        '
        'rpgTransFarmasi
        '
        Me.rpgTransFarmasi.ItemLinks.Add(Me.btnBarangMasuk)
        Me.rpgTransFarmasi.ItemLinks.Add(Me.btnBarangKeluar)
        Me.rpgTransFarmasi.Name = "rpgTransFarmasi"
        Me.rpgTransFarmasi.Text = "Farmasi"
        '
        'rpgBilling
        '
        Me.rpgBilling.ItemLinks.Add(Me.btnKasir)
        Me.rpgBilling.Name = "rpgBilling"
        Me.rpgBilling.Text = "Billing"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.txtUsername)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.BarStaticItem1)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.txtRole)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.txtUserID)
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 642)
        Me.RibbonStatusBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.ribbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1128, 31)
        '
        'lblIP
        '
        Me.lblIP.Location = New System.Drawing.Point(728, 230)
        Me.lblIP.Margin = New System.Windows.Forms.Padding(4)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(0, 21)
        Me.lblIP.TabIndex = 2
        Me.lblIP.Visible = False
        '
        'lblFolder
        '
        Me.lblFolder.Location = New System.Drawing.Point(563, 326)
        Me.lblFolder.Margin = New System.Windows.Forms.Padding(4)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(0, 21)
        Me.lblFolder.TabIndex = 3
        Me.lblFolder.Visible = False
        '
        'lblemail
        '
        Me.lblemail.Location = New System.Drawing.Point(573, 336)
        Me.lblemail.Margin = New System.Windows.Forms.Padding(4)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(0, 21)
        Me.lblemail.TabIndex = 4
        Me.lblemail.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.AutoSize = True
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 197)
        Me.PanelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1128, 445)
        Me.PanelControl1.TabIndex = 7
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 673)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.lblemail)
        Me.Controls.Add(Me.lblFolder)
        Me.Controls.Add(Me.lblIP)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.ribbonControl1)
        Me.IconOptions.Image = Global.CIS.My.Resources.Resources.cislogo
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormMenu"
        Me.Ribbon = Me.ribbonControl1
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "CIS"
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Private WithEvents rpSystem As DevExpress.XtraBars.Ribbon.RibbonPage
    Private WithEvents rpgAction As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnLogout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnChangePwd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSystem As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpMaster As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgMasterData As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnPasien As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnKamar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDokter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgFarmasi As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgUsers As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpTransaksi As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgPendaftaran As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnRawatJalan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgRekamMedis As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgTransFarmasi As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnRekamMedis As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTindakanRM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnObatRM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBarangMasuk As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBarangKeluar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtUsername As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents txtRole As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents txtUserID As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lblIP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFolder As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblemail As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rpgBilling As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnKasir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rpgPemeriksaan As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnPelayananPoli As DevExpress.XtraBars.BarButtonItem
End Class
