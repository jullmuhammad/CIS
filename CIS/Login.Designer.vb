<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.lblS = New DevExpress.XtraEditors.LabelControl()
        Me.lblDB = New DevExpress.XtraEditors.LabelControl()
        Me.lblP = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.ckLupa = New DevExpress.XtraEditors.CheckEdit()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtUserid = New DevExpress.XtraEditors.TextEdit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckLupa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblS)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblDB)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblP)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.PictureEdit1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.ckLupa)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnLogin)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.txtPassword)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.txtUserid)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(299, 308)
        Me.SplitContainerControl1.SplitterPosition = 105
        Me.SplitContainerControl1.TabIndex = 0
        '
        'lblS
        '
        Me.lblS.Location = New System.Drawing.Point(76, 44)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(0, 17)
        Me.lblS.TabIndex = 3
        Me.lblS.Visible = False
        '
        'lblDB
        '
        Me.lblDB.Location = New System.Drawing.Point(56, 44)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(0, 17)
        Me.lblDB.TabIndex = 2
        Me.lblDB.Visible = False
        '
        'lblP
        '
        Me.lblP.Location = New System.Drawing.Point(215, 59)
        Me.lblP.Name = "lblP"
        Me.lblP.Size = New System.Drawing.Size(0, 17)
        Me.lblP.TabIndex = 1
        Me.lblP.Visible = False
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.EditValue = Global.CIS.My.Resources.Resources.cislogo
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEdit1.Size = New System.Drawing.Size(299, 105)
        Me.PictureEdit1.TabIndex = 0
        '
        'ckLupa
        '
        Me.ckLupa.Location = New System.Drawing.Point(12, 92)
        Me.ckLupa.Name = "ckLupa"
        Me.ckLupa.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLupa.Properties.Appearance.Options.UseFont = True
        Me.ckLupa.Properties.Caption = "Lupa Password?"
        Me.ckLupa.Size = New System.Drawing.Size(118, 19)
        Me.ckLupa.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.BackColor = System.Drawing.Color.PeachPuff
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseBackColor = True
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Location = New System.Drawing.Point(12, 155)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(275, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Quit"
        '
        'btnLogin
        '
        Me.btnLogin.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnLogin.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Appearance.Options.UseBackColor = True
        Me.btnLogin.Appearance.Options.UseFont = True
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Location = New System.Drawing.Point(12, 117)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(275, 32)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(12, 52)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Properties.Appearance.Options.UseFont = True
        Me.txtPassword.Properties.ContextImageOptions.Image = CType(resources.GetObject("txtPassword.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.txtPassword.Properties.UseSystemPasswordChar = True
        Me.txtPassword.Size = New System.Drawing.Size(275, 32)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.ToolTip = "Masukkan Kata Sandi Anda"
        '
        'txtUserid
        '
        Me.txtUserid.Location = New System.Drawing.Point(12, 11)
        Me.txtUserid.Name = "txtUserid"
        Me.txtUserid.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserid.Properties.Appearance.Options.UseFont = True
        Me.txtUserid.Properties.ContextImageOptions.Image = CType(resources.GetObject("txtUserid.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.txtUserid.Size = New System.Drawing.Size(275, 32)
        Me.txtUserid.TabIndex = 0
        Me.txtUserid.ToolTip = "Masukkan UserID Anda"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 308)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.Image = Global.CIS.My.Resources.Resources.cislogo
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CIS v.1.0"
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckLupa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUserid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ckLupa As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDB As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblS As DevExpress.XtraEditors.LabelControl
End Class
