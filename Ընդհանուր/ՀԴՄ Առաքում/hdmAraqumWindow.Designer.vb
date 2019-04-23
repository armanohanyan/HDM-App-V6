<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class hdmAraqumWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(hdmAraqumWindow))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClearData = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddRecord = New DevExpress.XtraEditors.SimpleButton()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.dTime = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cbPlace = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cbRegions = New System.Windows.Forms.ComboBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtHDM = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mnuContext.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dTime.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportToExcel, Me.ToolStripMenuItem2, Me.mnuDelete})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(175, 54)
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Image = CType(resources.GetObject("mnuExportToExcel.Image"), System.Drawing.Image)
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Size = New System.Drawing.Size(174, 22)
        Me.mnuExportToExcel.Text = "Արտահանել Excel"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(171, 6)
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(174, 22)
        Me.mnuDelete.Text = "Ջնջել"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClearData)
        Me.Panel1.Controls.Add(Me.btnAddRecord)
        Me.Panel1.Controls.Add(Me.txtNumber)
        Me.Panel1.Controls.Add(Me.LabelControl6)
        Me.Panel1.Controls.Add(Me.txtTel)
        Me.Panel1.Controls.Add(Me.LabelControl5)
        Me.Panel1.Controls.Add(Me.dTime)
        Me.Panel1.Controls.Add(Me.LabelControl4)
        Me.Panel1.Controls.Add(Me.cbPlace)
        Me.Panel1.Controls.Add(Me.LabelControl3)
        Me.Panel1.Controls.Add(Me.cbRegions)
        Me.Panel1.Controls.Add(Me.LabelControl2)
        Me.Panel1.Controls.Add(Me.txtHDM)
        Me.Panel1.Controls.Add(Me.LabelControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 478)
        Me.Panel1.TabIndex = 1
        '
        'btnClearData
        '
        Me.btnClearData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearData.Image = CType(resources.GetObject("btnClearData.Image"), System.Drawing.Image)
        Me.btnClearData.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnClearData.Location = New System.Drawing.Point(12, 423)
        Me.btnClearData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClearData.Name = "btnClearData"
        Me.btnClearData.Size = New System.Drawing.Size(198, 32)
        Me.btnClearData.TabIndex = 7
        Me.btnClearData.Text = "Մաքրել"
        '
        'btnAddRecord
        '
        Me.btnAddRecord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddRecord.Image = CType(resources.GetObject("btnAddRecord.Image"), System.Drawing.Image)
        Me.btnAddRecord.Location = New System.Drawing.Point(12, 368)
        Me.btnAddRecord.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddRecord.Name = "btnAddRecord"
        Me.btnAddRecord.Size = New System.Drawing.Size(198, 32)
        Me.btnAddRecord.TabIndex = 6
        Me.btnAddRecord.Text = "Ավելացնել"
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(12, 331)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(198, 21)
        Me.txtNumber.TabIndex = 5
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 312)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(89, 13)
        Me.LabelControl6.TabIndex = 10
        Me.LabelControl6.Text = "Մեքենայի Համար"
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(12, 287)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(198, 21)
        Me.txtTel.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 268)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(96, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Վարորդի Հեռախոս"
        '
        'dTime
        '
        Me.dTime.EditValue = New Date(CType(0, Long))
        Me.dTime.Location = New System.Drawing.Point(12, 233)
        Me.dTime.Name = "dTime"
        Me.dTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.dTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTime.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dTime.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.dTime.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.dTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dTime.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.dTime.Properties.Mask.EditMask = "g"
        Me.dTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dTime.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dTime.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.dTime.Size = New System.Drawing.Size(198, 20)
        Me.dTime.TabIndex = 3
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 214)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Ժամանելու Ժամ"
        '
        'cbPlace
        '
        Me.cbPlace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbPlace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cbPlace.FormattingEnabled = True
        Me.cbPlace.Items.AddRange(New Object() {"Առաջին Մաս", "ԶՈՐԱՎԱՐ ԱՆԴՐԱՆԻԿԻ ԿԱՅ․", "ԿԻԼԻԿԻԱ ԱՎՏՈԿԱՅԱՆ", "Ռայկոմ", "ՍԱՍՈՒՆՑԻ ԴԱՎԹԻ ԿԱՅ․", "ՕՖԻՍ"})
        Me.cbPlace.Location = New System.Drawing.Point(12, 123)
        Me.cbPlace.Name = "cbPlace"
        Me.cbPlace.Size = New System.Drawing.Size(198, 85)
        Me.cbPlace.Sorted = True
        Me.cbPlace.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 104)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Ժամանելու Վայր"
        '
        'cbRegions
        '
        Me.cbRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegions.FormattingEnabled = True
        Me.cbRegions.Location = New System.Drawing.Point(12, 77)
        Me.cbRegions.Name = "cbRegions"
        Me.cbRegions.Size = New System.Drawing.Size(198, 21)
        Me.cbRegions.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 58)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Տարածաշրջան"
        '
        'txtHDM
        '
        Me.txtHDM.Location = New System.Drawing.Point(12, 31)
        Me.txtHDM.Name = "txtHDM"
        Me.txtHDM.Size = New System.Drawing.Size(198, 21)
        Me.txtHDM.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "ՀԴՄ"
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.mnuContext
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(220, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(701, 478)
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
        'hdmAraqumWindow
        '
        Me.AcceptButton = Me.btnAddRecord
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 478)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "hdmAraqumWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ՀԴՄ Առաքում"
        Me.mnuContext.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dTime.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents mnuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtHDM As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbRegions As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbPlace As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dTime As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnClearData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddRecord As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
