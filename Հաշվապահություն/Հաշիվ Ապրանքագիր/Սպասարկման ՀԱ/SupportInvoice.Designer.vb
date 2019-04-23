<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupportInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupportInvoice))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeselect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuXML = New System.Windows.Forms.ToolStripMenuItem()
        Me.ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtHVHH = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cManual = New System.Windows.Forms.RadioButton()
        Me.CAutomat = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBacvacq = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChangeNDS = New DevExpress.XtraEditors.SimpleButton()
        Me.cPrint = New DevExpress.XtraEditors.CheckEdit()
        Me.btnShowNoNDS = New DevExpress.XtraEditors.SimpleButton()
        Me.btnShowWithNDS = New DevExpress.XtraEditors.SimpleButton()
        Me.cWithPrint = New System.Windows.Forms.RadioButton()
        Me.cNoPrint = New System.Windows.Forms.RadioButton()
        Me.btnCheckDays = New DevExpress.XtraEditors.SimpleButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cMonth = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cYear = New System.Windows.Forms.ComboBox()
        Me.dDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMakeInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.cSupporter = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.mnuContext.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtHVHH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cPrint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
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
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelect, Me.mnuSelectAll, Me.mnuDeselect, Me.ToolStripMenuItem2, Me.mnuXML, Me.ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem, Me.mnuExcel, Me.ToolStripMenuItem1, Me.mnuExportToExcel})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(271, 170)
        '
        'mnuSelect
        '
        Me.mnuSelect.Name = "mnuSelect"
        Me.mnuSelect.Size = New System.Drawing.Size(270, 22)
        Me.mnuSelect.Text = "Նշել Հատվածը"
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(270, 22)
        Me.mnuSelectAll.Text = "Նշել Բոլորը"
        '
        'mnuDeselect
        '
        Me.mnuDeselect.Name = "mnuDeselect"
        Me.mnuDeselect.Size = New System.Drawing.Size(270, 22)
        Me.mnuDeselect.Text = "Հետնշել"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(267, 6)
        '
        'mnuXML
        '
        Me.mnuXML.Name = "mnuXML"
        Me.mnuXML.Size = New System.Drawing.Size(270, 22)
        Me.mnuXML.Text = "Գեներացնել XML (ԱԱՀ-ով)"
        '
        'ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem
        '
        Me.ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem.Name = "ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem"
        Me.ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem.Size = New System.Drawing.Size(270, 22)
        Me.ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem.Text = "Գեներացնել XML (Առանց ԱԱՀ-ով)"
        '
        'mnuExcel
        '
        Me.mnuExcel.Name = "mnuExcel"
        Me.mnuExcel.Size = New System.Drawing.Size(270, 22)
        Me.mnuExcel.Text = "Գեներացնել EXCEL (Առանց ԱԱՀ)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(267, 6)
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Image = CType(resources.GetObject("mnuExportToExcel.Image"), System.Drawing.Image)
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Size = New System.Drawing.Size(270, 22)
        Me.mnuExportToExcel.Text = "Արտահանել Excel"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(797, 594)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtHVHH)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cManual)
        Me.Panel1.Controls.Add(Me.CAutomat)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnCheckDays)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cMonth)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cYear)
        Me.Panel1.Controls.Add(Me.dDate)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.mDate)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnMakeInvoice)
        Me.Panel1.Controls.Add(Me.cSupporter)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 588)
        Me.Panel1.TabIndex = 0
        '
        'txtHVHH
        '
        Me.txtHVHH.Location = New System.Drawing.Point(50, 147)
        Me.txtHVHH.Name = "txtHVHH"
        Me.txtHVHH.Properties.ReadOnly = True
        Me.txtHVHH.Size = New System.Drawing.Size(185, 20)
        Me.txtHVHH.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "ՀՎՀՀ"
        '
        'cManual
        '
        Me.cManual.AutoSize = True
        Me.cManual.Location = New System.Drawing.Point(11, 121)
        Me.cManual.Name = "cManual"
        Me.cManual.Size = New System.Drawing.Size(91, 17)
        Me.cManual.TabIndex = 4
        Me.cManual.Text = "Անհատական"
        Me.cManual.UseVisualStyleBackColor = True
        '
        'CAutomat
        '
        Me.CAutomat.AutoSize = True
        Me.CAutomat.Checked = True
        Me.CAutomat.Location = New System.Drawing.Point(11, 98)
        Me.CAutomat.Name = "CAutomat"
        Me.CAutomat.Size = New System.Drawing.Size(75, 17)
        Me.CAutomat.TabIndex = 3
        Me.CAutomat.TabStop = True
        Me.CAutomat.Text = "Ավտոմատ"
        Me.CAutomat.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnBacvacq)
        Me.GroupBox1.Controls.Add(Me.btnChangeNDS)
        Me.GroupBox1.Controls.Add(Me.cPrint)
        Me.GroupBox1.Controls.Add(Me.btnShowNoNDS)
        Me.GroupBox1.Controls.Add(Me.btnShowWithNDS)
        Me.GroupBox1.Controls.Add(Me.cWithPrint)
        Me.GroupBox1.Controls.Add(Me.cNoPrint)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 302)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 277)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ստեղծված Հ/Ա"
        '
        'btnBacvacq
        '
        Me.btnBacvacq.Location = New System.Drawing.Point(5, 234)
        Me.btnBacvacq.Name = "btnBacvacq"
        Me.btnBacvacq.Size = New System.Drawing.Size(212, 37)
        Me.btnBacvacq.TabIndex = 56
        Me.btnBacvacq.Text = "Ինվոյսի բացվածք"
        '
        'btnChangeNDS
        '
        Me.btnChangeNDS.Location = New System.Drawing.Point(5, 191)
        Me.btnChangeNDS.Name = "btnChangeNDS"
        Me.btnChangeNDS.Size = New System.Drawing.Size(212, 37)
        Me.btnChangeNDS.TabIndex = 55
        Me.btnChangeNDS.Text = "ԱԱՀ-ն դարձնել առանց ԱԱՀ"
        '
        'cPrint
        '
        Me.cPrint.Location = New System.Drawing.Point(6, 66)
        Me.cPrint.Name = "cPrint"
        Me.cPrint.Properties.Caption = "Excel արտահանելուց տպել"
        Me.cPrint.Size = New System.Drawing.Size(182, 19)
        Me.cPrint.TabIndex = 54
        '
        'btnShowNoNDS
        '
        Me.btnShowNoNDS.Location = New System.Drawing.Point(2, 134)
        Me.btnShowNoNDS.Name = "btnShowNoNDS"
        Me.btnShowNoNDS.Size = New System.Drawing.Size(215, 37)
        Me.btnShowNoNDS.TabIndex = 2
        Me.btnShowNoNDS.Text = "Բեռնել (Առանց ԱԱՀ)"
        '
        'btnShowWithNDS
        '
        Me.btnShowWithNDS.Location = New System.Drawing.Point(2, 91)
        Me.btnShowWithNDS.Name = "btnShowWithNDS"
        Me.btnShowWithNDS.Size = New System.Drawing.Size(215, 37)
        Me.btnShowWithNDS.TabIndex = 2
        Me.btnShowWithNDS.Text = "Բեռնել (ԱԱՀ-ով)"
        '
        'cWithPrint
        '
        Me.cWithPrint.AutoSize = True
        Me.cWithPrint.Location = New System.Drawing.Point(6, 43)
        Me.cWithPrint.Name = "cWithPrint"
        Me.cWithPrint.Size = New System.Drawing.Size(60, 17)
        Me.cWithPrint.TabIndex = 1
        Me.cWithPrint.Text = "Բոլորը"
        Me.cWithPrint.UseVisualStyleBackColor = True
        '
        'cNoPrint
        '
        Me.cNoPrint.AutoSize = True
        Me.cNoPrint.Checked = True
        Me.cNoPrint.Location = New System.Drawing.Point(6, 20)
        Me.cNoPrint.Name = "cNoPrint"
        Me.cNoPrint.Size = New System.Drawing.Size(122, 17)
        Me.cNoPrint.TabIndex = 0
        Me.cNoPrint.TabStop = True
        Me.cNoPrint.Text = "Չգեներացվածները"
        Me.cNoPrint.UseVisualStyleBackColor = True
        '
        'btnCheckDays
        '
        Me.btnCheckDays.Location = New System.Drawing.Point(11, 220)
        Me.btnCheckDays.Name = "btnCheckDays"
        Me.btnCheckDays.Size = New System.Drawing.Size(224, 33)
        Me.btnCheckDays.TabIndex = 8
        Me.btnCheckDays.Text = "Ստուգել Օրերը"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Տարի"
        '
        'cMonth
        '
        Me.cMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMonth.FormattingEnabled = True
        Me.cMonth.Location = New System.Drawing.Point(97, 71)
        Me.cMonth.Name = "cMonth"
        Me.cMonth.Size = New System.Drawing.Size(82, 21)
        Me.cMonth.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Ամիս"
        '
        'cYear
        '
        Me.cYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cYear.FormattingEnabled = True
        Me.cYear.Location = New System.Drawing.Point(11, 71)
        Me.cYear.Name = "cYear"
        Me.cYear.Size = New System.Drawing.Size(82, 21)
        Me.cYear.TabIndex = 1
        '
        'dDate
        '
        Me.dDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dDate.EditValue = Nothing
        Me.dDate.Location = New System.Drawing.Point(129, 194)
        Me.dDate.Name = "dDate"
        Me.dDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.dDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.dDate.Size = New System.Drawing.Size(106, 20)
        Me.dDate.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(126, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Դուրսգրման Ամ"
        '
        'mDate
        '
        Me.mDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mDate.EditValue = Nothing
        Me.mDate.Location = New System.Drawing.Point(11, 194)
        Me.mDate.Name = "mDate"
        Me.mDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.mDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.mDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.mDate.Size = New System.Drawing.Size(111, 20)
        Me.mDate.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Մատակարարման Ամ"
        '
        'btnMakeInvoice
        '
        Me.btnMakeInvoice.Image = CType(resources.GetObject("btnMakeInvoice.Image"), System.Drawing.Image)
        Me.btnMakeInvoice.Location = New System.Drawing.Point(11, 259)
        Me.btnMakeInvoice.Name = "btnMakeInvoice"
        Me.btnMakeInvoice.Size = New System.Drawing.Size(224, 33)
        Me.btnMakeInvoice.TabIndex = 9
        Me.btnMakeInvoice.Text = "Ստեղծել Հ/Ա"
        '
        'cSupporter
        '
        Me.cSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSupporter.FormattingEnabled = True
        Me.cSupporter.Location = New System.Drawing.Point(9, 25)
        Me.cSupporter.Name = "cSupporter"
        Me.cSupporter.Size = New System.Drawing.Size(227, 21)
        Me.cSupporter.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Սպասարկող"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(253, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(541, 588)
        Me.Panel2.TabIndex = 1
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.mnuContext
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(541, 588)
        Me.GridControl1.TabIndex = 1
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
        'SupportInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 594)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "SupportInvoice"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Սպասարկման Հաշիվ Ապրանքագիր"
        Me.mnuContext.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtHVHH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cPrint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents mnuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMakeInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnCheckDays As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cWithPrint As System.Windows.Forms.RadioButton
    Friend WithEvents cNoPrint As System.Windows.Forms.RadioButton
    Friend WithEvents btnShowNoNDS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnShowWithNDS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtHVHH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cManual As System.Windows.Forms.RadioButton
    Friend WithEvents CAutomat As System.Windows.Forms.RadioButton
    Friend WithEvents mnuSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeselect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuXML As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cPrint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnChangeNDS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ԳեներացնելXMLԱռանցԱԱՀովToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBacvacq As DevExpress.XtraEditors.SimpleButton
End Class
