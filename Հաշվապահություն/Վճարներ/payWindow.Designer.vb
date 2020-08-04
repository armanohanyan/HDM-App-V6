<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payWindow))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuChangeAmount = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccseptPayment = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteAmount = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.txtHts = New System.Windows.Forms.TextBox()
        Me.txtClient = New System.Windows.Forms.TextBox()
        Me.txtSupporter = New System.Windows.Forms.TextBox()
        Me.cbPayType = New System.Windows.Forms.ComboBox()
        Me.dePayDay = New DevExpress.XtraEditors.DateEdit()
        Me.txtHvhh = New System.Windows.Forms.TextBox()
        Me.cbSupporter = New System.Windows.Forms.ComboBox()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mnuContext.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dePayDay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dePayDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportToExcel, Me.ToolStripMenuItem1, Me.mnuChangeAmount, Me.mnuAccseptPayment, Me.ToolStripMenuItem2, Me.mnuDeleteAmount})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(205, 104)
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Image = CType(resources.GetObject("mnuExportToExcel.Image"), System.Drawing.Image)
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Size = New System.Drawing.Size(204, 22)
        Me.mnuExportToExcel.Text = "Արտահանել Excel"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(201, 6)
        '
        'mnuChangeAmount
        '
        Me.mnuChangeAmount.Image = CType(resources.GetObject("mnuChangeAmount.Image"), System.Drawing.Image)
        Me.mnuChangeAmount.Name = "mnuChangeAmount"
        Me.mnuChangeAmount.Size = New System.Drawing.Size(204, 22)
        Me.mnuChangeAmount.Text = "Փոխել Գումարի Չափը"
        '
        'mnuAccseptPayment
        '
        Me.mnuAccseptPayment.Image = CType(resources.GetObject("mnuAccseptPayment.Image"), System.Drawing.Image)
        Me.mnuAccseptPayment.Name = "mnuAccseptPayment"
        Me.mnuAccseptPayment.Size = New System.Drawing.Size(204, 22)
        Me.mnuAccseptPayment.Text = "Հաստատել Վճարը"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(201, 6)
        '
        'mnuDeleteAmount
        '
        Me.mnuDeleteAmount.Image = CType(resources.GetObject("mnuDeleteAmount.Image"), System.Drawing.Image)
        Me.mnuDeleteAmount.Name = "mnuDeleteAmount"
        Me.mnuDeleteAmount.Size = New System.Drawing.Size(204, 22)
        Me.mnuDeleteAmount.Text = "Ջնջել Մուծումը"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtAmount)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.txtHts)
        Me.Panel1.Controls.Add(Me.txtClient)
        Me.Panel1.Controls.Add(Me.txtSupporter)
        Me.Panel1.Controls.Add(Me.cbPayType)
        Me.Panel1.Controls.Add(Me.dePayDay)
        Me.Panel1.Controls.Add(Me.txtHvhh)
        Me.Panel1.Controls.Add(Me.cbSupporter)
        Me.Panel1.Controls.Add(Me.LabelControl8)
        Me.Panel1.Controls.Add(Me.LabelControl7)
        Me.Panel1.Controls.Add(Me.LabelControl6)
        Me.Panel1.Controls.Add(Me.LabelControl5)
        Me.Panel1.Controls.Add(Me.LabelControl4)
        Me.Panel1.Controls.Add(Me.LabelControl3)
        Me.Panel1.Controls.Add(Me.LabelControl2)
        Me.Panel1.Controls.Add(Me.LabelControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(230, 415)
        Me.Panel1.TabIndex = 1
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.EditValue = "0.00"
        Me.txtAmount.Location = New System.Drawing.Point(77, 122)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtAmount.Properties.DisplayFormat.FormatString = "MaskType = Numeric, EditMask = 'n2'"
        Me.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmount.Properties.EditFormat.FormatString = "MaskType = Numeric, EditMask = 'n2'"
        Me.txtAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmount.Properties.Mask.EditMask = "n2"
        Me.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtAmount.Size = New System.Drawing.Size(144, 20)
        Me.txtAmount.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(49, 147)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(172, 27)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Ավելացնել"
        '
        'txtHts
        '
        Me.txtHts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHts.Location = New System.Drawing.Point(80, 307)
        Me.txtHts.Name = "txtHts"
        Me.txtHts.ReadOnly = True
        Me.txtHts.Size = New System.Drawing.Size(144, 21)
        Me.txtHts.TabIndex = 10
        Me.txtHts.TabStop = False
        '
        'txtClient
        '
        Me.txtClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClient.Location = New System.Drawing.Point(80, 218)
        Me.txtClient.Multiline = True
        Me.txtClient.Name = "txtClient"
        Me.txtClient.ReadOnly = True
        Me.txtClient.Size = New System.Drawing.Size(144, 83)
        Me.txtClient.TabIndex = 9
        Me.txtClient.TabStop = False
        '
        'txtSupporter
        '
        Me.txtSupporter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupporter.BackColor = System.Drawing.Color.White
        Me.txtSupporter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtSupporter.Location = New System.Drawing.Point(80, 191)
        Me.txtSupporter.Name = "txtSupporter"
        Me.txtSupporter.ReadOnly = True
        Me.txtSupporter.Size = New System.Drawing.Size(144, 21)
        Me.txtSupporter.TabIndex = 8
        Me.txtSupporter.TabStop = False
        '
        'cbPayType
        '
        Me.cbPayType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbPayType.FormattingEnabled = True
        Me.cbPayType.Items.AddRange(New Object() {"Բանկ", "TelcCell", "EasyPay", "Idram", "Կանխիկ"})
        Me.cbPayType.Location = New System.Drawing.Point(77, 95)
        Me.cbPayType.Name = "cbPayType"
        Me.cbPayType.Size = New System.Drawing.Size(144, 21)
        Me.cbPayType.TabIndex = 5
        Me.cbPayType.TabStop = False
        '
        'dePayDay
        '
        Me.dePayDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dePayDay.EditValue = Nothing
        Me.dePayDay.Location = New System.Drawing.Point(77, 66)
        Me.dePayDay.Name = "dePayDay"
        Me.dePayDay.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.dePayDay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dePayDay.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dePayDay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dePayDay.Size = New System.Drawing.Size(144, 20)
        Me.dePayDay.TabIndex = 1
        '
        'txtHvhh
        '
        Me.txtHvhh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHvhh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtHvhh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtHvhh.Location = New System.Drawing.Point(77, 39)
        Me.txtHvhh.Name = "txtHvhh"
        Me.txtHvhh.Size = New System.Drawing.Size(144, 21)
        Me.txtHvhh.TabIndex = 0
        '
        'cbSupporter
        '
        Me.cbSupporter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSupporter.FormattingEnabled = True
        Me.cbSupporter.Location = New System.Drawing.Point(77, 12)
        Me.cbSupporter.Name = "cbSupporter"
        Me.cbSupporter.Size = New System.Drawing.Size(144, 21)
        Me.cbSupporter.TabIndex = 3
        Me.cbSupporter.TabStop = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(39, 310)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl8.TabIndex = 5
        Me.LabelControl8.Text = "ՀԾ Կոդ"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(47, 221)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl7.TabIndex = 4
        Me.LabelControl7.Text = "Կազմ"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(13, 194)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl6.TabIndex = 3
        Me.LabelControl6.Text = "Սպասարկող"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(34, 125)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 2
        Me.LabelControl5.Text = "Գումար"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(8, 98)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl4.TabIndex = 1
        Me.LabelControl4.Text = "Վճարման Ձև"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(7, 69)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl3.TabIndex = 0
        Me.LabelControl3.Text = "Վճարման Օր"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(46, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "ՀՎՀՀ"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Սպասարկող"
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.mnuContext
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(230, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(425, 415)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.TabStop = False
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AllowFindPanel = False
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'payWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 415)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "payWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Վճարների Մուտքագրում"
        Me.mnuContext.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dePayDay.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dePayDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents mnuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dePayDay As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtHvhh As System.Windows.Forms.TextBox
    Friend WithEvents cbSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents cbPayType As System.Windows.Forms.ComboBox
    Friend WithEvents txtHts As System.Windows.Forms.TextBox
    Friend WithEvents txtClient As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuChangeAmount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeleteAmount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccseptPayment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSupporter As System.Windows.Forms.TextBox
End Class
