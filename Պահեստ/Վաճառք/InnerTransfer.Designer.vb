<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InnerTransfer
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
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtShtrikh = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbWarehousePrimary = New System.Windows.Forms.ComboBox()
        Me.cmbWarehouseSecondary = New System.Windows.Forms.ComboBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnTransfer = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrintDoc = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Առաջնային Պահեստ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Երկրորդական Պահեստ"
        '
        'txtShtrikh
        '
        Me.txtShtrikh.Location = New System.Drawing.Point(17, 93)
        Me.txtShtrikh.MaxLength = 7
        Me.txtShtrikh.Name = "txtShtrikh"
        Me.txtShtrikh.Size = New System.Drawing.Size(125, 21)
        Me.txtShtrikh.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Շտրիխ կոդ"
        '
        'cmbWarehousePrimary
        '
        Me.cmbWarehousePrimary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWarehousePrimary.FormattingEnabled = True
        Me.cmbWarehousePrimary.Location = New System.Drawing.Point(17, 42)
        Me.cmbWarehousePrimary.Name = "cmbWarehousePrimary"
        Me.cmbWarehousePrimary.Size = New System.Drawing.Size(182, 21)
        Me.cmbWarehousePrimary.TabIndex = 5
        '
        'cmbWarehouseSecondary
        '
        Me.cmbWarehouseSecondary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWarehouseSecondary.FormattingEnabled = True
        Me.cmbWarehouseSecondary.Location = New System.Drawing.Point(214, 42)
        Me.cmbWarehouseSecondary.Name = "cmbWarehouseSecondary"
        Me.cmbWarehouseSecondary.Size = New System.Drawing.Size(182, 21)
        Me.cmbWarehouseSecondary.TabIndex = 6
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(0, 130)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(508, 253)
        Me.GridControl1.TabIndex = 7
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(107, 22)
        Me.mnuDelete.Text = "Ջնջել"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsDetail.AllowZoomDetail = False
        Me.GridView1.OptionsFilter.AllowColumnMRUFilterList = False
        Me.GridView1.OptionsFilter.AllowFilterEditor = False
        Me.GridView1.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.GridView1.OptionsFilter.AllowMRUFilterList = False
        Me.GridView1.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.GridView1.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = False
        Me.GridView1.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = False
        Me.GridView1.OptionsFind.AllowFindPanel = False
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowCloseButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        Me.GridView1.OptionsMenu.EnableColumnMenu = False
        Me.GridView1.OptionsMenu.EnableFooterMenu = False
        Me.GridView1.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'btnTransfer
        '
        Me.btnTransfer.Location = New System.Drawing.Point(148, 91)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(150, 23)
        Me.btnTransfer.TabIndex = 8
        Me.btnTransfer.Text = "Կատարել Տեղափոխումը"
        '
        'btnPrintDoc
        '
        Me.btnPrintDoc.Enabled = False
        Me.btnPrintDoc.Location = New System.Drawing.Point(304, 91)
        Me.btnPrintDoc.Name = "btnPrintDoc"
        Me.btnPrintDoc.Size = New System.Drawing.Size(150, 23)
        Me.btnPrintDoc.TabIndex = 9
        Me.btnPrintDoc.Text = "Տպել Փաստաթուղթ"
        '
        'InnerTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 385)
        Me.Controls.Add(Me.btnPrintDoc)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.cmbWarehouseSecondary)
        Me.Controls.Add(Me.cmbWarehousePrimary)
        Me.Controls.Add(Me.txtShtrikh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MinimizeBox = False
        Me.Name = "InnerTransfer"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ներքին Տեղափոխություն"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtShtrikh As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbWarehousePrimary As System.Windows.Forms.ComboBox
    Friend WithEvents cmbWarehouseSecondary As System.Windows.Forms.ComboBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnTransfer As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrintDoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
End Class
