<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class smsViewerWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(smsViewerWindow))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSMSCenter = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSMSByHayt = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSmsByHvhh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTesuch = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClient = New DevExpress.XtraEditors.SimpleButton()
        Me.eDate = New DevExpress.XtraEditors.DateEdit()
        Me.sDate = New DevExpress.XtraEditors.DateEdit()
        Me.ckByInterval = New DevExpress.XtraEditors.CheckEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnClosedSMS = New DevExpress.XtraEditors.SimpleButton()
        Me.mnuContext.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckByInterval.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportToExcel})
        Me.mnuContext.Name = "mnuContext"
        Me.mnuContext.Size = New System.Drawing.Size(175, 26)
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
        Me.Panel1.Controls.Add(Me.btnClosedSMS)
        Me.Panel1.Controls.Add(Me.btnSMSCenter)
        Me.Panel1.Controls.Add(Me.btnSMSByHayt)
        Me.Panel1.Controls.Add(Me.btnSmsByHvhh)
        Me.Panel1.Controls.Add(Me.btnTesuch)
        Me.Panel1.Controls.Add(Me.btnClient)
        Me.Panel1.Controls.Add(Me.eDate)
        Me.Panel1.Controls.Add(Me.sDate)
        Me.Panel1.Controls.Add(Me.ckByInterval)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 402)
        Me.Panel1.TabIndex = 1
        '
        'btnSMSCenter
        '
        Me.btnSMSCenter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSMSCenter.Image = CType(resources.GetObject("btnSMSCenter.Image"), System.Drawing.Image)
        Me.btnSMSCenter.Location = New System.Drawing.Point(11, 238)
        Me.btnSMSCenter.Name = "btnSMSCenter"
        Me.btnSMSCenter.Size = New System.Drawing.Size(169, 27)
        Me.btnSMSCenter.TabIndex = 7
        Me.btnSMSCenter.Text = "Բեռնել SMS Կենտրոն"
        '
        'btnSMSByHayt
        '
        Me.btnSMSByHayt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSMSByHayt.Image = CType(resources.GetObject("btnSMSByHayt.Image"), System.Drawing.Image)
        Me.btnSMSByHayt.Location = New System.Drawing.Point(12, 205)
        Me.btnSMSByHayt.Name = "btnSMSByHayt"
        Me.btnSMSByHayt.Size = New System.Drawing.Size(169, 27)
        Me.btnSMSByHayt.TabIndex = 6
        Me.btnSMSByHayt.Text = "Բեռնել SMS Հայտերի"
        '
        'btnSmsByHvhh
        '
        Me.btnSmsByHvhh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSmsByHvhh.Image = CType(resources.GetObject("btnSmsByHvhh.Image"), System.Drawing.Image)
        Me.btnSmsByHvhh.Location = New System.Drawing.Point(13, 172)
        Me.btnSmsByHvhh.Name = "btnSmsByHvhh"
        Me.btnSmsByHvhh.Size = New System.Drawing.Size(169, 27)
        Me.btnSmsByHvhh.TabIndex = 5
        Me.btnSmsByHvhh.Text = "Բեռնել SMS Հաճախորդին"
        '
        'btnTesuch
        '
        Me.btnTesuch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTesuch.Image = CType(resources.GetObject("btnTesuch.Image"), System.Drawing.Image)
        Me.btnTesuch.Location = New System.Drawing.Point(13, 139)
        Me.btnTesuch.Name = "btnTesuch"
        Me.btnTesuch.Size = New System.Drawing.Size(169, 27)
        Me.btnTesuch.TabIndex = 4
        Me.btnTesuch.Text = "Բեռնել SMS Տեսուչներին"
        '
        'btnClient
        '
        Me.btnClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClient.Image = CType(resources.GetObject("btnClient.Image"), System.Drawing.Image)
        Me.btnClient.Location = New System.Drawing.Point(12, 106)
        Me.btnClient.Name = "btnClient"
        Me.btnClient.Size = New System.Drawing.Size(169, 27)
        Me.btnClient.TabIndex = 3
        Me.btnClient.Text = "Բեռնել SMS Գործընկեր."
        '
        'eDate
        '
        Me.eDate.EditValue = Nothing
        Me.eDate.Location = New System.Drawing.Point(12, 64)
        Me.eDate.Name = "eDate"
        Me.eDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.eDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.eDate.Size = New System.Drawing.Size(168, 20)
        Me.eDate.TabIndex = 2
        '
        'sDate
        '
        Me.sDate.EditValue = Nothing
        Me.sDate.Location = New System.Drawing.Point(13, 38)
        Me.sDate.Name = "sDate"
        Me.sDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.sDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.sDate.Size = New System.Drawing.Size(168, 20)
        Me.sDate.TabIndex = 1
        '
        'ckByInterval
        '
        Me.ckByInterval.EditValue = True
        Me.ckByInterval.Location = New System.Drawing.Point(13, 13)
        Me.ckByInterval.Name = "ckByInterval"
        Me.ckByInterval.Properties.Caption = "Միջակայքով"
        Me.ckByInterval.Size = New System.Drawing.Size(97, 19)
        Me.ckByInterval.TabIndex = 0
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
        Me.GridControl1.Size = New System.Drawing.Size(517, 402)
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
        'btnClosedSMS
        '
        Me.btnClosedSMS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClosedSMS.Image = CType(resources.GetObject("btnClosedSMS.Image"), System.Drawing.Image)
        Me.btnClosedSMS.Location = New System.Drawing.Point(11, 271)
        Me.btnClosedSMS.Name = "btnClosedSMS"
        Me.btnClosedSMS.Size = New System.Drawing.Size(169, 27)
        Me.btnClosedSMS.TabIndex = 8
        Me.btnClosedSMS.Text = "Փակված Հայտեր"
        '
        'smsViewerWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 402)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "smsViewerWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ուղարկված SMS-ներ"
        Me.mnuContext.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckByInterval.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents eDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ckByInterval As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnTesuch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClient As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSmsByHvhh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSMSByHayt As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSMSCenter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClosedSMS As DevExpress.XtraEditors.SimpleButton
End Class
