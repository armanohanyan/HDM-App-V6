<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendHVHHSMSWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SendHVHHSMSWindow))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeselect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFilter = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbTouch = New System.Windows.Forms.RadioButton()
        Me.rbMK = New System.Windows.Forms.RadioButton()
        Me.rbTama = New System.Windows.Forms.RadioButton()
        Me.rbShtrikh = New System.Windows.Forms.RadioButton()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSent = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rbTorp = New System.Windows.Forms.RadioButton()
        Me.rbSmart = New System.Windows.Forms.RadioButton()
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
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelect, Me.mnuSelectAll, Me.mnuDeselect, Me.ToolStripMenuItem1, Me.mnuExportToExcel})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(175, 98)
        '
        'mnuSelect
        '
        Me.mnuSelect.Image = CType(resources.GetObject("mnuSelect.Image"), System.Drawing.Image)
        Me.mnuSelect.Name = "mnuSelect"
        Me.mnuSelect.Size = New System.Drawing.Size(174, 22)
        Me.mnuSelect.Text = "Նշել Հատվածը"
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Image = CType(resources.GetObject("mnuSelectAll.Image"), System.Drawing.Image)
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(174, 22)
        Me.mnuSelectAll.Text = "Նշել Բոլորը"
        '
        'mnuDeselect
        '
        Me.mnuDeselect.Name = "mnuDeselect"
        Me.mnuDeselect.Size = New System.Drawing.Size(174, 22)
        Me.mnuDeselect.Text = "Հետնշել"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(171, 6)
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Image = CType(resources.GetObject("mnuExportToExcel.Image"), System.Drawing.Image)
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Size = New System.Drawing.Size(174, 22)
        Me.mnuExportToExcel.Text = "Արտահանել Excel"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnFilter)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtMessage)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnSent)
        Me.Panel1.Controls.Add(Me.btnLoad)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 521)
        Me.Panel1.TabIndex = 1
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.Location = New System.Drawing.Point(11, 219)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(182, 27)
        Me.btnFilter.TabIndex = 16
        Me.btnFilter.Text = "ՀՎՀՀ Ֆիլտր Excel-ից"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbTorp)
        Me.GroupBox1.Controls.Add(Me.rbSmart)
        Me.GroupBox1.Controls.Add(Me.rbTouch)
        Me.GroupBox1.Controls.Add(Me.rbMK)
        Me.GroupBox1.Controls.Add(Me.rbTama)
        Me.GroupBox1.Controls.Add(Me.rbShtrikh)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(198, 161)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Կազմակերպություններ"
        '
        'rbTouch
        '
        Me.rbTouch.AutoSize = True
        Me.rbTouch.Location = New System.Drawing.Point(6, 87)
        Me.rbTouch.Name = "rbTouch"
        Me.rbTouch.Size = New System.Drawing.Size(87, 17)
        Me.rbTouch.TabIndex = 3
        Me.rbTouch.Text = "Տոչ-մաստեր"
        Me.rbTouch.UseVisualStyleBackColor = True
        '
        'rbMK
        '
        Me.rbMK.AutoSize = True
        Me.rbMK.Location = New System.Drawing.Point(6, 64)
        Me.rbMK.Name = "rbMK"
        Me.rbMK.Size = New System.Drawing.Size(93, 17)
        Me.rbMK.TabIndex = 2
        Me.rbMK.Text = "ՄԵՐԻ-ՔՐԻՍՏ"
        Me.rbMK.UseVisualStyleBackColor = True
        '
        'rbTama
        '
        Me.rbTama.AutoSize = True
        Me.rbTama.Location = New System.Drawing.Point(6, 41)
        Me.rbTama.Name = "rbTama"
        Me.rbTama.Size = New System.Drawing.Size(106, 17)
        Me.rbTama.TabIndex = 1
        Me.rbTama.Text = "Տամա Էլեկտրոն"
        Me.rbTama.UseVisualStyleBackColor = True
        '
        'rbShtrikh
        '
        Me.rbShtrikh.AutoSize = True
        Me.rbShtrikh.Checked = True
        Me.rbShtrikh.Location = New System.Drawing.Point(6, 18)
        Me.rbShtrikh.Name = "rbShtrikh"
        Me.rbShtrikh.Size = New System.Drawing.Size(87, 17)
        Me.rbShtrikh.TabIndex = 0
        Me.rbShtrikh.TabStop = True
        Me.rbShtrikh.Text = "ՀԴՄ Շտրիխ"
        Me.rbShtrikh.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(9, 286)
        Me.txtMessage.MaxLength = 259
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(176, 172)
        Me.txtMessage.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 260)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Հաղորդագրություն"
        '
        'btnSent
        '
        Me.btnSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSent.Image = CType(resources.GetObject("btnSent.Image"), System.Drawing.Image)
        Me.btnSent.Location = New System.Drawing.Point(6, 476)
        Me.btnSent.Name = "btnSent"
        Me.btnSent.Size = New System.Drawing.Size(182, 27)
        Me.btnSent.TabIndex = 12
        Me.btnSent.Text = "Ուղարկել SMS"
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.Location = New System.Drawing.Point(11, 177)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(182, 27)
        Me.btnLoad.TabIndex = 11
        Me.btnLoad.Text = "Բեռնել Տվյալները"
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.mnuContext
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(200, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(597, 521)
        Me.GridControl1.TabIndex = 5
        Me.GridControl1.TabStop = False
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'rbTorp
        '
        Me.rbTorp.AutoSize = True
        Me.rbTorp.Location = New System.Drawing.Point(6, 133)
        Me.rbTorp.Name = "rbTorp"
        Me.rbTorp.Size = New System.Drawing.Size(72, 17)
        Me.rbTorp.TabIndex = 5
        Me.rbTorp.Text = "Թորփայս"
        Me.rbTorp.UseVisualStyleBackColor = True
        '
        'rbSmart
        '
        Me.rbSmart.AutoSize = True
        Me.rbSmart.Location = New System.Drawing.Point(6, 110)
        Me.rbSmart.Name = "rbSmart"
        Me.rbSmart.Size = New System.Drawing.Size(107, 17)
        Me.rbSmart.TabIndex = 4
        Me.rbSmart.Text = "Սմարթ Սոլուշնս"
        Me.rbSmart.UseVisualStyleBackColor = True
        '
        'SendHVHHSMSWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 521)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "SendHVHHSMSWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ուղարկել Անհատական SMS Գործընկերոջը"
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnSent As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeselect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTouch As System.Windows.Forms.RadioButton
    Friend WithEvents rbMK As System.Windows.Forms.RadioButton
    Friend WithEvents rbTama As System.Windows.Forms.RadioButton
    Friend WithEvents rbShtrikh As System.Windows.Forms.RadioButton
    Friend WithEvents btnFilter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents rbTorp As System.Windows.Forms.RadioButton
    Friend WithEvents rbSmart As System.Windows.Forms.RadioButton
End Class
