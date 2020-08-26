<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendSMSWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SendSMSWindow))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeselect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnSendFromExcell = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLoadFromExcell = New DevExpress.XtraEditors.SimpleButton()
        Me.cbLoadFromExcell = New System.Windows.Forms.CheckBox()
        Me.cAllClients = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSMonth = New System.Windows.Forms.ComboBox()
        Me.cbSYear = New System.Windows.Forms.ComboBox()
        Me.TimeX = New DevExpress.XtraEditors.DateEdit()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.cbYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckByPeriod = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbForBlock = New System.Windows.Forms.RadioButton()
        Me.rbBlocked = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbTorp = New System.Windows.Forms.RadioButton()
        Me.rbSmart = New System.Windows.Forms.RadioButton()
        Me.rbTouch = New System.Windows.Forms.RadioButton()
        Me.rbMK = New System.Windows.Forms.RadioButton()
        Me.rbTama = New System.Windows.Forms.RadioButton()
        Me.rbShtrikh = New System.Windows.Forms.RadioButton()
        Me.btnSent = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rbForBlockExcel = New System.Windows.Forms.RadioButton()
        Me.rbBlockedExcel = New System.Windows.Forms.RadioButton()
        Me.mnuContext.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.cAllClients.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TimeX.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckByPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.cAllClients)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnSent)
        Me.Panel1.Controls.Add(Me.btnLoad)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 607)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbForBlockExcel)
        Me.GroupBox4.Controls.Add(Me.rbBlockedExcel)
        Me.GroupBox4.Controls.Add(Me.btnSendFromExcell)
        Me.GroupBox4.Controls.Add(Me.btnLoadFromExcell)
        Me.GroupBox4.Controls.Add(Me.cbLoadFromExcell)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Red
        Me.GroupBox4.Location = New System.Drawing.Point(6, 446)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(187, 151)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Կասեցվածներ Excell-ից"
        '
        'btnSendFromExcell
        '
        Me.btnSendFromExcell.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendFromExcell.Image = CType(resources.GetObject("btnSendFromExcell.Image"), System.Drawing.Image)
        Me.btnSendFromExcell.Location = New System.Drawing.Point(6, 115)
        Me.btnSendFromExcell.Name = "btnSendFromExcell"
        Me.btnSendFromExcell.Size = New System.Drawing.Size(109, 27)
        Me.btnSendFromExcell.TabIndex = 13
        Me.btnSendFromExcell.Text = "Ուղարկել SMS"
        '
        'btnLoadFromExcell
        '
        Me.btnLoadFromExcell.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadFromExcell.Image = CType(resources.GetObject("btnLoadFromExcell.Image"), System.Drawing.Image)
        Me.btnLoadFromExcell.Location = New System.Drawing.Point(5, 82)
        Me.btnLoadFromExcell.Name = "btnLoadFromExcell"
        Me.btnLoadFromExcell.Size = New System.Drawing.Size(111, 27)
        Me.btnLoadFromExcell.TabIndex = 12
        Me.btnLoadFromExcell.Text = "Բեռնել Excell-ից"
        '
        'cbLoadFromExcell
        '
        Me.cbLoadFromExcell.AutoSize = True
        Me.cbLoadFromExcell.ForeColor = System.Drawing.Color.Black
        Me.cbLoadFromExcell.Location = New System.Drawing.Point(6, 20)
        Me.cbLoadFromExcell.Name = "cbLoadFromExcell"
        Me.cbLoadFromExcell.Size = New System.Drawing.Size(108, 17)
        Me.cbLoadFromExcell.TabIndex = 0
        Me.cbLoadFromExcell.Text = "Բեռնել Excell-ից"
        Me.cbLoadFromExcell.UseVisualStyleBackColor = True
        '
        'cAllClients
        '
        Me.cAllClients.Location = New System.Drawing.Point(12, 327)
        Me.cAllClients.Name = "cAllClients"
        Me.cAllClients.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cAllClients.Properties.Appearance.ForeColor = System.Drawing.Color.RoyalBlue
        Me.cAllClients.Properties.Appearance.Options.UseFont = True
        Me.cAllClients.Properties.Appearance.Options.UseForeColor = True
        Me.cAllClients.Properties.Appearance.Options.UseTextOptions = True
        Me.cAllClients.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cAllClients.Properties.Caption = "Չսպասարկվողները և ՀԴՄ չունեցողները ներառյալ"
        Me.cAllClients.Size = New System.Drawing.Size(176, 43)
        Me.cAllClients.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cbSMonth)
        Me.GroupBox3.Controls.Add(Me.cbSYear)
        Me.GroupBox3.Controls.Add(Me.TimeX)
        Me.GroupBox3.Controls.Add(Me.cbMonth)
        Me.GroupBox3.Controls.Add(Me.cbYear)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.ckByPeriod)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 172)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(198, 130)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Պարամետրեր"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(167, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "- ը"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(167, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "- ից"
        '
        'cbSMonth
        '
        Me.cbSMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSMonth.FormattingEnabled = True
        Me.cbSMonth.Location = New System.Drawing.Point(102, 34)
        Me.cbSMonth.Name = "cbSMonth"
        Me.cbSMonth.Size = New System.Drawing.Size(57, 21)
        Me.cbSMonth.TabIndex = 16
        '
        'cbSYear
        '
        Me.cbSYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSYear.FormattingEnabled = True
        Me.cbSYear.Location = New System.Drawing.Point(14, 34)
        Me.cbSYear.Name = "cbSYear"
        Me.cbSYear.Size = New System.Drawing.Size(79, 21)
        Me.cbSYear.TabIndex = 15
        '
        'TimeX
        '
        Me.TimeX.EditValue = Nothing
        Me.TimeX.Location = New System.Drawing.Point(12, 102)
        Me.TimeX.Name = "TimeX"
        Me.TimeX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.TimeX.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeX.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TimeX.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.TimeX.Size = New System.Drawing.Size(176, 20)
        Me.TimeX.TabIndex = 10
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Location = New System.Drawing.Point(102, 60)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(57, 21)
        Me.cbMonth.TabIndex = 9
        '
        'cbYear
        '
        Me.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYear.FormattingEnabled = True
        Me.cbYear.Location = New System.Drawing.Point(14, 60)
        Me.cbYear.Name = "cbYear"
        Me.cbYear.Size = New System.Drawing.Size(79, 21)
        Me.cbYear.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Կասեցման Ամսաթիվ"
        '
        'ckByPeriod
        '
        Me.ckByPeriod.Enabled = False
        Me.ckByPeriod.Location = New System.Drawing.Point(12, 12)
        Me.ckByPeriod.Name = "ckByPeriod"
        Me.ckByPeriod.Properties.Caption = "Ըստ Միջակայքի"
        Me.ckByPeriod.Size = New System.Drawing.Size(108, 19)
        Me.ckByPeriod.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbForBlock)
        Me.GroupBox2.Controls.Add(Me.rbBlocked)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 120)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(198, 52)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Հաղորդագրության Տեսակ"
        '
        'rbForBlock
        '
        Me.rbForBlock.AutoSize = True
        Me.rbForBlock.Location = New System.Drawing.Point(6, 30)
        Me.rbForBlock.Name = "rbForBlock"
        Me.rbForBlock.Size = New System.Drawing.Size(144, 17)
        Me.rbForBlock.TabIndex = 5
        Me.rbForBlock.Text = "Կասեցման Ենթականեր"
        Me.rbForBlock.UseVisualStyleBackColor = True
        '
        'rbBlocked
        '
        Me.rbBlocked.AutoSize = True
        Me.rbBlocked.Checked = True
        Me.rbBlocked.Location = New System.Drawing.Point(6, 14)
        Me.rbBlocked.Name = "rbBlocked"
        Me.rbBlocked.Size = New System.Drawing.Size(97, 17)
        Me.rbBlocked.TabIndex = 4
        Me.rbBlocked.TabStop = True
        Me.rbBlocked.Text = "Կասեցվածներ"
        Me.rbBlocked.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Size = New System.Drawing.Size(198, 120)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Կազմակերպություններ"
        '
        'rbTorp
        '
        Me.rbTorp.AutoSize = True
        Me.rbTorp.Location = New System.Drawing.Point(6, 95)
        Me.rbTorp.Name = "rbTorp"
        Me.rbTorp.Size = New System.Drawing.Size(72, 17)
        Me.rbTorp.TabIndex = 7
        Me.rbTorp.Text = "Թորփայս"
        Me.rbTorp.UseVisualStyleBackColor = True
        '
        'rbSmart
        '
        Me.rbSmart.AutoSize = True
        Me.rbSmart.Location = New System.Drawing.Point(6, 79)
        Me.rbSmart.Name = "rbSmart"
        Me.rbSmart.Size = New System.Drawing.Size(107, 17)
        Me.rbSmart.TabIndex = 6
        Me.rbSmart.Text = "Սմարթ Սոլուշնս"
        Me.rbSmart.UseVisualStyleBackColor = True
        '
        'rbTouch
        '
        Me.rbTouch.AutoSize = True
        Me.rbTouch.Location = New System.Drawing.Point(6, 63)
        Me.rbTouch.Name = "rbTouch"
        Me.rbTouch.Size = New System.Drawing.Size(87, 17)
        Me.rbTouch.TabIndex = 3
        Me.rbTouch.Text = "Տոչ-մաստեր"
        Me.rbTouch.UseVisualStyleBackColor = True
        '
        'rbMK
        '
        Me.rbMK.AutoSize = True
        Me.rbMK.Location = New System.Drawing.Point(6, 47)
        Me.rbMK.Name = "rbMK"
        Me.rbMK.Size = New System.Drawing.Size(93, 17)
        Me.rbMK.TabIndex = 2
        Me.rbMK.Text = "ՄԵՐԻ-ՔՐԻՍՏ"
        Me.rbMK.UseVisualStyleBackColor = True
        '
        'rbTama
        '
        Me.rbTama.AutoSize = True
        Me.rbTama.Location = New System.Drawing.Point(6, 31)
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
        Me.rbShtrikh.Location = New System.Drawing.Point(6, 15)
        Me.rbShtrikh.Name = "rbShtrikh"
        Me.rbShtrikh.Size = New System.Drawing.Size(87, 17)
        Me.rbShtrikh.TabIndex = 0
        Me.rbShtrikh.TabStop = True
        Me.rbShtrikh.Text = "ՀԴՄ Շտրիխ"
        Me.rbShtrikh.UseVisualStyleBackColor = True
        '
        'btnSent
        '
        Me.btnSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSent.Image = CType(resources.GetObject("btnSent.Image"), System.Drawing.Image)
        Me.btnSent.Location = New System.Drawing.Point(6, 410)
        Me.btnSent.Name = "btnSent"
        Me.btnSent.Size = New System.Drawing.Size(182, 27)
        Me.btnSent.TabIndex = 12
        Me.btnSent.Text = "Ուղարկել SMS"
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.Location = New System.Drawing.Point(6, 375)
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
        Me.GridControl1.Size = New System.Drawing.Size(628, 607)
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
        'rbForBlockExcel
        '
        Me.rbForBlockExcel.AutoSize = True
        Me.rbForBlockExcel.Location = New System.Drawing.Point(7, 57)
        Me.rbForBlockExcel.Name = "rbForBlockExcel"
        Me.rbForBlockExcel.Size = New System.Drawing.Size(144, 17)
        Me.rbForBlockExcel.TabIndex = 15
        Me.rbForBlockExcel.Text = "Կասեցման Ենթականեր"
        Me.rbForBlockExcel.UseVisualStyleBackColor = True
        '
        'rbBlockedExcel
        '
        Me.rbBlockedExcel.AutoSize = True
        Me.rbBlockedExcel.Checked = True
        Me.rbBlockedExcel.Location = New System.Drawing.Point(7, 41)
        Me.rbBlockedExcel.Name = "rbBlockedExcel"
        Me.rbBlockedExcel.Size = New System.Drawing.Size(97, 17)
        Me.rbBlockedExcel.TabIndex = 14
        Me.rbBlockedExcel.TabStop = True
        Me.rbBlockedExcel.Text = "Կասեցվածներ"
        Me.rbBlockedExcel.UseVisualStyleBackColor = True
        '
        'SendSMSWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 607)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "SendSMSWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ուղարկել SMS Գործընկերներին"
        Me.mnuContext.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.cAllClients.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TimeX.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckByPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbForBlock As System.Windows.Forms.RadioButton
    Friend WithEvents rbBlocked As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTouch As System.Windows.Forms.RadioButton
    Friend WithEvents rbMK As System.Windows.Forms.RadioButton
    Friend WithEvents rbTama As System.Windows.Forms.RadioButton
    Friend WithEvents rbShtrikh As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TimeX As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckByPeriod As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cAllClients As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cbSYear As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSendFromExcell As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLoadFromExcell As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbLoadFromExcell As System.Windows.Forms.CheckBox
    Friend WithEvents rbTorp As System.Windows.Forms.RadioButton
    Friend WithEvents rbSmart As System.Windows.Forms.RadioButton
    Friend WithEvents rbForBlockExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rbBlockedExcel As System.Windows.Forms.RadioButton
End Class
