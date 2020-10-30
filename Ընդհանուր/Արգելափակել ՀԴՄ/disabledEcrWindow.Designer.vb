<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class disabledEcrWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(disabledEcrWindow))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelectRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectColored = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeselect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExportSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrepareEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ՀանելԱրգելքըToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOnlySelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAllItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnNotSupGprs = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cAllEcr = New System.Windows.Forms.RadioButton()
        Me.cBeeline = New System.Windows.Forms.RadioButton()
        Me.cViva = New System.Windows.Forms.RadioButton()
        Me.cOrange = New System.Windows.Forms.RadioButton()
        Me.btnInAction = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDeleteSim = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSelectSim = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLoadHVHH = New DevExpress.XtraEditors.SimpleButton()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
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
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectRow, Me.mnuSelectAll, Me.mnuSelectColored, Me.ToolStripMenuItem5, Me.mnuDeselect, Me.ToolStripMenuItem4, Me.mnuExportToExcel, Me.mnuExportSelected, Me.ToolStripMenuItem1, Me.mnuPrepareEmail, Me.ToolStripMenuItem2, Me.ՀանելԱրգելքըToolStripMenuItem})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(233, 204)
        '
        'mnuSelectRow
        '
        Me.mnuSelectRow.Image = CType(resources.GetObject("mnuSelectRow.Image"), System.Drawing.Image)
        Me.mnuSelectRow.Name = "mnuSelectRow"
        Me.mnuSelectRow.Size = New System.Drawing.Size(232, 22)
        Me.mnuSelectRow.Text = "Նշել"
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Image = CType(resources.GetObject("mnuSelectAll.Image"), System.Drawing.Image)
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(232, 22)
        Me.mnuSelectAll.Text = "Նշել Բոլոր Տողերը"
        '
        'mnuSelectColored
        '
        Me.mnuSelectColored.BackColor = System.Drawing.Color.GreenYellow
        Me.mnuSelectColored.ForeColor = System.Drawing.Color.Black
        Me.mnuSelectColored.Image = CType(resources.GetObject("mnuSelectColored.Image"), System.Drawing.Image)
        Me.mnuSelectColored.Name = "mnuSelectColored"
        Me.mnuSelectColored.Size = New System.Drawing.Size(232, 22)
        Me.mnuSelectColored.Text = "Նշել Երանգովները"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(229, 6)
        '
        'mnuDeselect
        '
        Me.mnuDeselect.Name = "mnuDeselect"
        Me.mnuDeselect.Size = New System.Drawing.Size(232, 22)
        Me.mnuDeselect.Text = "Հետնշել"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(229, 6)
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Image = CType(resources.GetObject("mnuExportToExcel.Image"), System.Drawing.Image)
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Size = New System.Drawing.Size(232, 22)
        Me.mnuExportToExcel.Text = "Արտահանել Excel"
        '
        'mnuExportSelected
        '
        Me.mnuExportSelected.Name = "mnuExportSelected"
        Me.mnuExportSelected.Size = New System.Drawing.Size(232, 22)
        Me.mnuExportSelected.Text = "Արտահանել Նշվածները"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(229, 6)
        '
        'mnuPrepareEmail
        '
        Me.mnuPrepareEmail.Image = CType(resources.GetObject("mnuPrepareEmail.Image"), System.Drawing.Image)
        Me.mnuPrepareEmail.Name = "mnuPrepareEmail"
        Me.mnuPrepareEmail.Size = New System.Drawing.Size(232, 22)
        Me.mnuPrepareEmail.Text = "Նախապատրաստել Նամակ"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(229, 6)
        '
        'ՀանելԱրգելքըToolStripMenuItem
        '
        Me.ՀանելԱրգելքըToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.mnuOnlySelected, Me.mnuAllItems})
        Me.ՀանելԱրգելքըToolStripMenuItem.Name = "ՀանելԱրգելքըToolStripMenuItem"
        Me.ՀանելԱրգելքըToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ՀանելԱրգելքըToolStripMenuItem.Text = "Հանել Արգելքը"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(181, 6)
        '
        'mnuOnlySelected
        '
        Me.mnuOnlySelected.Name = "mnuOnlySelected"
        Me.mnuOnlySelected.Size = New System.Drawing.Size(184, 22)
        Me.mnuOnlySelected.Text = "Նշվածների Համար"
        '
        'mnuAllItems
        '
        Me.mnuAllItems.Enabled = False
        Me.mnuAllItems.Name = "mnuAllItems"
        Me.mnuAllItems.Size = New System.Drawing.Size(184, 22)
        Me.mnuAllItems.Text = "Բոլորի Համար"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnNotSupGprs)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnInAction)
        Me.Panel1.Controls.Add(Me.btnDeleteSim)
        Me.Panel1.Controls.Add(Me.btnSelectSim)
        Me.Panel1.Controls.Add(Me.btnLoadHVHH)
        Me.Panel1.Controls.Add(Me.btnQuery)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 428)
        Me.Panel1.TabIndex = 1
        '
        'btnNotSupGprs
        '
        Me.btnNotSupGprs.Location = New System.Drawing.Point(12, 354)
        Me.btnNotSupGprs.Name = "btnNotSupGprs"
        Me.btnNotSupGprs.Size = New System.Drawing.Size(182, 27)
        Me.btnNotSupGprs.TabIndex = 7
        Me.btnNotSupGprs.Text = "Չպատկան GPRS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cAllEcr)
        Me.GroupBox1.Controls.Add(Me.cBeeline)
        Me.GroupBox1.Controls.Add(Me.cViva)
        Me.GroupBox1.Controls.Add(Me.cOrange)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(182, 108)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Օպերատոր"
        '
        'cAllEcr
        '
        Me.cAllEcr.AutoSize = True
        Me.cAllEcr.Checked = True
        Me.cAllEcr.Location = New System.Drawing.Point(6, 87)
        Me.cAllEcr.Name = "cAllEcr"
        Me.cAllEcr.Size = New System.Drawing.Size(60, 17)
        Me.cAllEcr.TabIndex = 4
        Me.cAllEcr.TabStop = True
        Me.cAllEcr.Text = "Բոլորը"
        Me.cAllEcr.UseVisualStyleBackColor = True
        '
        'cBeeline
        '
        Me.cBeeline.AutoSize = True
        Me.cBeeline.Location = New System.Drawing.Point(6, 66)
        Me.cBeeline.Name = "cBeeline"
        Me.cBeeline.Size = New System.Drawing.Size(59, 17)
        Me.cBeeline.TabIndex = 2
        Me.cBeeline.Text = "Beeline"
        Me.cBeeline.UseVisualStyleBackColor = True
        '
        'cViva
        '
        Me.cViva.AutoSize = True
        Me.cViva.Location = New System.Drawing.Point(6, 43)
        Me.cViva.Name = "cViva"
        Me.cViva.Size = New System.Drawing.Size(62, 17)
        Me.cViva.TabIndex = 1
        Me.cViva.Text = "VivaCell"
        Me.cViva.UseVisualStyleBackColor = True
        '
        'cOrange
        '
        Me.cOrange.AutoSize = True
        Me.cOrange.Location = New System.Drawing.Point(6, 20)
        Me.cOrange.Name = "cOrange"
        Me.cOrange.Size = New System.Drawing.Size(97, 17)
        Me.cOrange.TabIndex = 0
        Me.cOrange.Text = "Orange / Ucom"
        Me.cOrange.UseVisualStyleBackColor = True
        '
        'btnInAction
        '
        Me.btnInAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInAction.Image = CType(resources.GetObject("btnInAction.Image"), System.Drawing.Image)
        Me.btnInAction.Location = New System.Drawing.Point(12, 304)
        Me.btnInAction.Name = "btnInAction"
        Me.btnInAction.Size = New System.Drawing.Size(182, 27)
        Me.btnInAction.TabIndex = 5
        Me.btnInAction.Text = "Orange Ընթացիկներ"
        '
        'btnDeleteSim
        '
        Me.btnDeleteSim.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteSim.Enabled = False
        Me.btnDeleteSim.Image = CType(resources.GetObject("btnDeleteSim.Image"), System.Drawing.Image)
        Me.btnDeleteSim.Location = New System.Drawing.Point(12, 233)
        Me.btnDeleteSim.Name = "btnDeleteSim"
        Me.btnDeleteSim.Size = New System.Drawing.Size(182, 27)
        Me.btnDeleteSim.TabIndex = 3
        Me.btnDeleteSim.Text = "Ջնջել Ակտիվացման SIM-երը"
        '
        'btnSelectSim
        '
        Me.btnSelectSim.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectSim.Image = CType(resources.GetObject("btnSelectSim.Image"), System.Drawing.Image)
        Me.btnSelectSim.Location = New System.Drawing.Point(12, 200)
        Me.btnSelectSim.Name = "btnSelectSim"
        Me.btnSelectSim.Size = New System.Drawing.Size(182, 27)
        Me.btnSelectSim.TabIndex = 2
        Me.btnSelectSim.Text = "Նշել Ակտիվացման SIM-երը"
        '
        'btnLoadHVHH
        '
        Me.btnLoadHVHH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadHVHH.Image = CType(resources.GetObject("btnLoadHVHH.Image"), System.Drawing.Image)
        Me.btnLoadHVHH.Location = New System.Drawing.Point(12, 167)
        Me.btnLoadHVHH.Name = "btnLoadHVHH"
        Me.btnLoadHVHH.Size = New System.Drawing.Size(182, 27)
        Me.btnLoadHVHH.TabIndex = 1
        Me.btnLoadHVHH.Text = "Հետնշել ՀՎՀՀ-երը"
        '
        'btnQuery
        '
        Me.btnQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(12, 12)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(182, 27)
        Me.btnQuery.TabIndex = 0
        Me.btnQuery.Text = "Բեռնել"
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
        Me.GridControl1.Size = New System.Drawing.Size(594, 428)
        Me.GridControl1.TabIndex = 2
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
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'disabledEcrWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 428)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "disabledEcrWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Արգելափակված ՀԴՄ-ներ"
        Me.mnuContext.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mnuExportSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPrepareEmail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ՀանելԱրգելքըToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOnlySelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAllItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDeselect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnLoadHVHH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDeleteSim As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSelectSim As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents mnuSelectColored As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnInAction As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cBeeline As System.Windows.Forms.RadioButton
    Friend WithEvents cViva As System.Windows.Forms.RadioButton
    Friend WithEvents cOrange As System.Windows.Forms.RadioButton
    Friend WithEvents btnNotSupGprs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cAllEcr As System.Windows.Forms.RadioButton
End Class
