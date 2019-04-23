<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListOfWorkShopItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListOfWorkShopItems))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTimer = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.txtEcrCurCount = New DevExpress.XtraEditors.TextEdit()
        Me.txtEcrOldCount = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAddEzrakac = New DevExpress.XtraEditors.SimpleButton()
        Me.txtEzrakac = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGarant = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cShrjik = New DevExpress.XtraEditors.CheckEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cVTQ = New DevExpress.XtraEditors.CheckEdit()
        Me.cPos = New DevExpress.XtraEditors.CheckEdit()
        Me.cInvoice = New DevExpress.XtraEditors.CheckEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtShtrikh = New System.Windows.Forms.TextBox()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.cbEquipment = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteShtrikhCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TmTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMessage = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtEcrCurCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEcrOldCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGarant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cShrjik.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cVTQ.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cPos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(669, 654)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtTimer)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnAddEzrakac)
        Me.Panel1.Controls.Add(Me.txtEzrakac)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtGarant)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cShrjik)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.cVTQ)
        Me.Panel1.Controls.Add(Me.cPos)
        Me.Panel1.Controls.Add(Me.cInvoice)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtShtrikh)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.cbEquipment)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtEcr)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 648)
        Me.Panel1.TabIndex = 0
        '
        'txtTimer
        '
        Me.txtTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTimer.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtTimer.ForeColor = System.Drawing.Color.Red
        Me.txtTimer.Location = New System.Drawing.Point(9, 6)
        Me.txtTimer.Name = "txtTimer"
        Me.txtTimer.Size = New System.Drawing.Size(229, 35)
        Me.txtTimer.TabIndex = 29
        Me.txtTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Blue
        Me.PictureBox2.Location = New System.Drawing.Point(3, 44)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(238, 2)
        Me.PictureBox2.TabIndex = 28
        Me.PictureBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.txtEcrCurCount)
        Me.GroupBox1.Controls.Add(Me.txtEcrOldCount)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 515)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 124)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Սրահում Առկա ՀԴՄ"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(108, 91)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(107, 23)
        Me.btnRefresh.TabIndex = 26
        Me.btnRefresh.Text = "Թարմեցնել"
        '
        'txtEcrCurCount
        '
        Me.txtEcrCurCount.Location = New System.Drawing.Point(108, 61)
        Me.txtEcrCurCount.Name = "txtEcrCurCount"
        Me.txtEcrCurCount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtEcrCurCount.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.txtEcrCurCount.Properties.Appearance.Options.UseFont = True
        Me.txtEcrCurCount.Properties.Appearance.Options.UseForeColor = True
        Me.txtEcrCurCount.Properties.ReadOnly = True
        Me.txtEcrCurCount.Size = New System.Drawing.Size(107, 22)
        Me.txtEcrCurCount.TabIndex = 25
        Me.txtEcrCurCount.TabStop = False
        '
        'txtEcrOldCount
        '
        Me.txtEcrOldCount.Location = New System.Drawing.Point(108, 34)
        Me.txtEcrOldCount.Name = "txtEcrOldCount"
        Me.txtEcrOldCount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtEcrOldCount.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.txtEcrOldCount.Properties.Appearance.Options.UseFont = True
        Me.txtEcrOldCount.Properties.Appearance.Options.UseForeColor = True
        Me.txtEcrOldCount.Properties.ReadOnly = True
        Me.txtEcrOldCount.Size = New System.Drawing.Size(107, 22)
        Me.txtEcrOldCount.TabIndex = 24
        Me.txtEcrOldCount.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Ընթացիկ Օրվա"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Նախորդից"
        '
        'btnAddEzrakac
        '
        Me.btnAddEzrakac.Location = New System.Drawing.Point(19, 381)
        Me.btnAddEzrakac.Name = "btnAddEzrakac"
        Me.btnAddEzrakac.Size = New System.Drawing.Size(211, 36)
        Me.btnAddEzrakac.TabIndex = 26
        Me.btnAddEzrakac.Text = "Ավելացնել/Փոխել Եզրակացությունը"
        '
        'txtEzrakac
        '
        Me.txtEzrakac.Location = New System.Drawing.Point(19, 270)
        Me.txtEzrakac.Multiline = True
        Me.txtEzrakac.Name = "txtEzrakac"
        Me.txtEzrakac.Size = New System.Drawing.Size(211, 105)
        Me.txtEzrakac.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Եզրակացություն"
        '
        'txtGarant
        '
        Me.txtGarant.Location = New System.Drawing.Point(66, 486)
        Me.txtGarant.Name = "txtGarant"
        Me.txtGarant.Properties.ReadOnly = True
        Me.txtGarant.Size = New System.Drawing.Size(143, 20)
        Me.txtGarant.TabIndex = 23
        Me.txtGarant.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 488)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Երաշխ"
        '
        'cShrjik
        '
        Me.cShrjik.Location = New System.Drawing.Point(140, 448)
        Me.cShrjik.Name = "cShrjik"
        Me.cShrjik.Properties.Caption = "Շրջիկ"
        Me.cShrjik.Properties.ReadOnly = True
        Me.cShrjik.Size = New System.Drawing.Size(90, 19)
        Me.cShrjik.TabIndex = 13
        Me.cShrjik.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Blue
        Me.PictureBox1.Location = New System.Drawing.Point(0, 142)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(238, 2)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'cVTQ
        '
        Me.cVTQ.Location = New System.Drawing.Point(9, 448)
        Me.cVTQ.Name = "cVTQ"
        Me.cVTQ.Properties.Caption = "V-ից Q"
        Me.cVTQ.Properties.ReadOnly = True
        Me.cVTQ.Size = New System.Drawing.Size(90, 19)
        Me.cVTQ.TabIndex = 11
        Me.cVTQ.TabStop = False
        '
        'cPos
        '
        Me.cPos.Location = New System.Drawing.Point(140, 423)
        Me.cPos.Name = "cPos"
        Me.cPos.Properties.Caption = "POS"
        Me.cPos.Properties.ReadOnly = True
        Me.cPos.Size = New System.Drawing.Size(90, 19)
        Me.cPos.TabIndex = 10
        Me.cPos.TabStop = False
        '
        'cInvoice
        '
        Me.cInvoice.Location = New System.Drawing.Point(9, 423)
        Me.cInvoice.Name = "cInvoice"
        Me.cInvoice.Properties.Caption = "Tax Free"
        Me.cInvoice.Properties.ReadOnly = True
        Me.cInvoice.Size = New System.Drawing.Size(90, 19)
        Me.cInvoice.TabIndex = 9
        Me.cInvoice.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Շտրիխ Կոդ"
        '
        'txtShtrikh
        '
        Me.txtShtrikh.Location = New System.Drawing.Point(52, 115)
        Me.txtShtrikh.Name = "txtShtrikh"
        Me.txtShtrikh.Size = New System.Drawing.Size(177, 21)
        Me.txtShtrikh.TabIndex = 7
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(66, 207)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(164, 34)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Ավելացնել Նյութ"
        '
        'cbEquipment
        '
        Me.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEquipment.DropDownWidth = 280
        Me.cbEquipment.FormattingEnabled = True
        Me.cbEquipment.Location = New System.Drawing.Point(18, 180)
        Me.cbEquipment.Name = "cbEquipment"
        Me.cbEquipment.Size = New System.Drawing.Size(211, 21)
        Me.cbEquipment.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Նյութ"
        '
        'txtEcr
        '
        Me.txtEcr.Location = New System.Drawing.Point(52, 61)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.ReadOnly = True
        Me.txtEcr.Size = New System.Drawing.Size(177, 21)
        Me.txtEcr.TabIndex = 1
        Me.txtEcr.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ՀԴՄ"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GridControl3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.GridControl2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.GridControl1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(253, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(413, 648)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'GridControl3
        '
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Location = New System.Drawing.Point(3, 434)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(407, 212)
        Me.GridControl3.TabIndex = 5
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.OptionsCustomization.AllowColumnMoving = False
        Me.GridView3.OptionsCustomization.AllowFilter = False
        Me.GridView3.OptionsCustomization.AllowGroup = False
        Me.GridView3.OptionsCustomization.AllowSort = False
        Me.GridView3.OptionsFilter.AllowFilterEditor = False
        Me.GridView3.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView3.OptionsFind.ShowClearButton = False
        Me.GridView3.OptionsFind.ShowFindButton = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridControl2
        '
        Me.GridControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl2.Location = New System.Drawing.Point(3, 218)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(407, 212)
        Me.GridControl2.TabIndex = 4
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsCustomization.AllowColumnMoving = False
        Me.GridView2.OptionsCustomization.AllowFilter = False
        Me.GridView2.OptionsCustomization.AllowGroup = False
        Me.GridView2.OptionsCustomization.AllowSort = False
        Me.GridView2.OptionsFilter.AllowFilterEditor = False
        Me.GridView2.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView2.OptionsFind.ShowClearButton = False
        Me.GridView2.OptionsFind.ShowFindButton = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(3, 2)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(407, 212)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDelete, Me.ToolStripMenuItem1, Me.mnuDeleteShtrikhCode, Me.ToolStripMenuItem2, Me.mnuMessage})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(228, 104)
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(227, 22)
        Me.mnuDelete.Text = "Ջնջել Գրանցումը"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(224, 6)
        '
        'mnuDeleteShtrikhCode
        '
        Me.mnuDeleteShtrikhCode.Image = CType(resources.GetObject("mnuDeleteShtrikhCode.Image"), System.Drawing.Image)
        Me.mnuDeleteShtrikhCode.Name = "mnuDeleteShtrikhCode"
        Me.mnuDeleteShtrikhCode.Size = New System.Drawing.Size(227, 22)
        Me.mnuDeleteShtrikhCode.Text = "Ջնջել Շտրիխ Կոդով"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsFilter.AllowFilterEditor = False
        Me.GridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'TmTimer
        '
        Me.TmTimer.Interval = 1000
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(224, 6)
        '
        'mnuMessage
        '
        Me.mnuMessage.Name = "mnuMessage"
        Me.mnuMessage.Size = New System.Drawing.Size(227, 22)
        Me.mnuMessage.Text = "Տեղեկացնել ՀԴՄ-ի Մասին"
        '
        'ListOfWorkShopItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 654)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ListOfWorkShopItems"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Արհեստանոցի Սարքավորումներ"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtEcrCurCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEcrOldCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGarant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cShrjik.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cVTQ.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cPos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbEquipment As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtShtrikh As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeleteShtrikhCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cVTQ As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cPos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cInvoice As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cShrjik As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtGarant As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAddEzrakac As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtEzrakac As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEcrCurCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEcrOldCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TmTimer As System.Windows.Forms.Timer
    Friend WithEvents txtTimer As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuMessage As System.Windows.Forms.ToolStripMenuItem
End Class
