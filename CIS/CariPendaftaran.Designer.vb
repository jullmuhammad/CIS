<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CariPendaftaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CariPendaftaran))
        Me.GridControlData = New DevExpress.XtraGrid.GridControl()
        Me.GridViewData = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControlData
        '
        Me.GridControlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlData.MainView = Me.GridViewData
        Me.GridControlData.Name = "GridControlData"
        Me.GridControlData.Size = New System.Drawing.Size(675, 340)
        Me.GridControlData.TabIndex = 2
        Me.GridControlData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewData})
        '
        'GridViewData
        '
        Me.GridViewData.GridControl = Me.GridControlData
        Me.GridViewData.Name = "GridViewData"
        '
        'CariPendaftaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 340)
        Me.Controls.Add(Me.GridControlData)
        Me.IconOptions.Image = CType(resources.GetObject("CariPendaftaran.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "CariPendaftaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cari Pendaftaran"
        CType(Me.GridControlData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControlData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewData As DevExpress.XtraGrid.Views.Grid.GridView
End Class
