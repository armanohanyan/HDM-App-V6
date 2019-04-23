<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditPremiumClients
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditPremiumClients))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteBulk = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBulkDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.cb3000 = New System.Windows.Forms.CheckBox()
        Me.cb3600 = New System.Windows.Forms.CheckBox()
        Me.cb1200 = New System.Windows.Forms.CheckBox()
        Me.btnBulkInsert = New DevExpress.XtraEditors.SimpleButton()
        Me.btnInsert = New DevExpress.XtraEditors.SimpleButton()
        Me.txtHVHH = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mnuContext.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 436)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Nothing
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(646, 20)
        '
        'mnuContext
        '
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportToExcel, Me.ToolStripMenuItem1, Me.mnuDelete, Me.mnuDeleteBulk})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(200, 76)
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Image = CType(resources.GetObject("mnuExportToExcel.Image"), System.Drawing.Image)
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Size = New System.Drawing.Size(199, 22)
        Me.mnuExportToExcel.Text = "Արտահանել Excel"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(196, 6)
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(199, 22)
        Me.mnuDelete.Text = "Հեռացնել Ցանկից"
        '
        'mnuDeleteBulk
        '
        Me.mnuDeleteBulk.Image = CType(resources.GetObject("mnuDeleteBulk.Image"), System.Drawing.Image)
        Me.mnuDeleteBulk.Name = "mnuDeleteBulk"
        Me.mnuDeleteBulk.Size = New System.Drawing.Size(199, 22)
        Me.mnuDeleteBulk.Text = "Հեռացնել Նշվածները"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnInsert)
        Me.Panel1.Controls.Add(Me.txtHVHH)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(241, 383)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBulkDelete)
        Me.GroupBox1.Controls.Add(Me.cb3000)
        Me.GroupBox1.Controls.Add(Me.cb3600)
        Me.GroupBox1.Controls.Add(Me.cb1200)
        Me.GroupBox1.Controls.Add(Me.btnBulkInsert)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 199)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 181)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Խմբային գործողություններ"
        '
        'btnBulkDelete
        '
        Me.btnBulkDelete.Image = Global.ՀԴՄ_App.My.Resources.Resources.cancel_16x16
        Me.btnBulkDelete.Location = New System.Drawing.Point(12, 132)
        Me.btnBulkDelete.Name = "btnBulkDelete"
        Me.btnBulkDelete.Size = New System.Drawing.Size(198, 36)
        Me.btnBulkDelete.TabIndex = 10
        Me.btnBulkDelete.Text = "Հեռացնել խմբով ավելացվածները"
        '
        'cb3000
        '
        Me.cb3000.AutoSize = True
        Me.cb3000.Location = New System.Drawing.Point(12, 86)
        Me.cb3000.Name = "cb3000"
        Me.cb3000.Size = New System.Drawing.Size(84, 17)
        Me.cb3000.TabIndex = 8
        Me.cb3000.Text = "Տարիֆ3000"
        Me.cb3000.UseVisualStyleBackColor = True
        '
        'cb3600
        '
        Me.cb3600.AutoSize = True
        Me.cb3600.Location = New System.Drawing.Point(12, 109)
        Me.cb3600.Name = "cb3600"
        Me.cb3600.Size = New System.Drawing.Size(84, 17)
        Me.cb3600.TabIndex = 9
        Me.cb3600.Text = "Տարիֆ3600"
        Me.cb3600.UseVisualStyleBackColor = True
        '
        'cb1200
        '
        Me.cb1200.AutoSize = True
        Me.cb1200.Location = New System.Drawing.Point(12, 63)
        Me.cb1200.Name = "cb1200"
        Me.cb1200.Size = New System.Drawing.Size(165, 17)
        Me.cb1200.TabIndex = 7
        Me.cb1200.Text = "Տարիֆ1200 (1ից ավել ՀԴՄ)"
        Me.cb1200.UseVisualStyleBackColor = True
        '
        'btnBulkInsert
        '
        Me.btnBulkInsert.Image = CType(resources.GetObject("btnBulkInsert.Image"), System.Drawing.Image)
        Me.btnBulkInsert.Location = New System.Drawing.Point(12, 20)
        Me.btnBulkInsert.Name = "btnBulkInsert"
        Me.btnBulkInsert.Size = New System.Drawing.Size(198, 36)
        Me.btnBulkInsert.TabIndex = 6
        Me.btnBulkInsert.Text = "Ավելացնել խմբով"
        '
        'btnInsert
        '
        Me.btnInsert.Image = CType(resources.GetObject("btnInsert.Image"), System.Drawing.Image)
        Me.btnInsert.Location = New System.Drawing.Point(16, 70)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(189, 36)
        Me.btnInsert.TabIndex = 2
        Me.btnInsert.Text = "Ավելացնել"
        '
        'txtHVHH
        '
        Me.txtHVHH.Location = New System.Drawing.Point(16, 29)
        Me.txtHVHH.Name = "txtHVHH"
        Me.txtHVHH.Size = New System.Drawing.Size(189, 21)
        Me.txtHVHH.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ՀՎՀՀ"
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.mnuContext
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(241, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(462, 383)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'EditPremiumClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 383)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "EditPremiumClients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Խմբագրել Կասեցումից Ազատվածները"
        Me.mnuContext.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents mnuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnInsert As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtHVHH As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBulkDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cb3000 As System.Windows.Forms.CheckBox
    Friend WithEvents cb3600 As System.Windows.Forms.CheckBox
    Friend WithEvents cb1200 As System.Windows.Forms.CheckBox
    Friend WithEvents btnBulkInsert As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mnuDeleteBulk As System.Windows.Forms.ToolStripMenuItem
End Class
