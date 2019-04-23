<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateRemakeInvoiceInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateRemakeInvoiceInfo))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTPDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtTotalPrice = New DevExpress.XtraEditors.TextEdit()
        Me.btnCreateInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtClient = New System.Windows.Forms.TextBox()
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.txtHVHH = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DTPDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(698, 368)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DTPDate)
        Me.Panel1.Controls.Add(Me.txtTotalPrice)
        Me.Panel1.Controls.Add(Me.btnCreateInvoice)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtClient)
        Me.Panel1.Controls.Add(Me.txtEcr)
        Me.Panel1.Controls.Add(Me.txtHVHH)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 362)
        Me.Panel1.TabIndex = 0
        '
        'DTPDate
        '
        Me.DTPDate.EditValue = Nothing
        Me.DTPDate.Location = New System.Drawing.Point(77, 146)
        Me.DTPDate.Name = "DTPDate"
        Me.DTPDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DTPDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTPDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.DTPDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DTPDate.Size = New System.Drawing.Size(157, 20)
        Me.DTPDate.TabIndex = 0
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.EditValue = "0"
        Me.txtTotalPrice.Location = New System.Drawing.Point(89, 85)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTotalPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalPrice.Properties.Mask.EditMask = "n4"
        Me.txtTotalPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtTotalPrice.Properties.ReadOnly = True
        Me.txtTotalPrice.Size = New System.Drawing.Size(145, 20)
        Me.txtTotalPrice.TabIndex = 17
        Me.txtTotalPrice.TabStop = False
        '
        'btnCreateInvoice
        '
        Me.btnCreateInvoice.Image = CType(resources.GetObject("btnCreateInvoice.Image"), System.Drawing.Image)
        Me.btnCreateInvoice.Location = New System.Drawing.Point(21, 201)
        Me.btnCreateInvoice.Name = "btnCreateInvoice"
        Me.btnCreateInvoice.Size = New System.Drawing.Size(213, 31)
        Me.btnCreateInvoice.TabIndex = 1
        Me.btnCreateInvoice.Text = "Ստեղծել Ինվոյս"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Մատակարարման Ամսաթիվ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Գումար"
        '
        'txtClient
        '
        Me.txtClient.Location = New System.Drawing.Point(89, 58)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.ReadOnly = True
        Me.txtClient.Size = New System.Drawing.Size(145, 21)
        Me.txtClient.TabIndex = 11
        Me.txtClient.TabStop = False
        Me.txtClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEcr
        '
        Me.txtEcr.Location = New System.Drawing.Point(89, 32)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.ReadOnly = True
        Me.txtEcr.Size = New System.Drawing.Size(145, 21)
        Me.txtEcr.TabIndex = 10
        Me.txtEcr.TabStop = False
        Me.txtEcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHVHH
        '
        Me.txtHVHH.Location = New System.Drawing.Point(89, 9)
        Me.txtHVHH.Name = "txtHVHH"
        Me.txtHVHH.ReadOnly = True
        Me.txtHVHH.Size = New System.Drawing.Size(145, 21)
        Me.txtHVHH.TabIndex = 9
        Me.txtHVHH.TabStop = False
        Me.txtHVHH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Գործընկեր"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "ՀԴՄ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ՀՎՀՀ"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridControl3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(253, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(442, 362)
        Me.Panel2.TabIndex = 1
        '
        'GridControl3
        '
        Me.GridControl3.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl3.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(442, 362)
        Me.GridControl3.TabIndex = 4
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.OptionsCustomization.AllowColumnMoving = False
        Me.GridView3.OptionsCustomization.AllowFilter = False
        Me.GridView3.OptionsCustomization.AllowGroup = False
        Me.GridView3.OptionsCustomization.AllowSort = False
        Me.GridView3.OptionsDetail.AllowZoomDetail = False
        Me.GridView3.OptionsFilter.AllowColumnMRUFilterList = False
        Me.GridView3.OptionsFilter.AllowFilterEditor = False
        Me.GridView3.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.GridView3.OptionsFilter.AllowMRUFilterList = False
        Me.GridView3.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.GridView3.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = False
        Me.GridView3.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = False
        Me.GridView3.OptionsFind.AllowFindPanel = False
        Me.GridView3.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView3.OptionsFind.ShowClearButton = False
        Me.GridView3.OptionsFind.ShowFindButton = False
        Me.GridView3.OptionsMenu.EnableColumnMenu = False
        Me.GridView3.OptionsMenu.EnableFooterMenu = False
        Me.GridView3.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'CreateRemakeInvoiceInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 368)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimizeBox = False
        Me.Name = "CreateRemakeInvoiceInfo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ստեղծել Վերանորոգման Ինվոյս"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DTPDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtClient As System.Windows.Forms.TextBox
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
    Friend WithEvents txtHVHH As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreateInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtTotalPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DTPDate As DevExpress.XtraEditors.DateEdit
End Class
