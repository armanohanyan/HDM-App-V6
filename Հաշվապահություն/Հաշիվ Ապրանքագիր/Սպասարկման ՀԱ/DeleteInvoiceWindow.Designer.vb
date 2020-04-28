<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeleteInvoiceWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeleteInvoiceWindow))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.cSupporter = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.cYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cMonth = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHVHH = New DevExpress.XtraEditors.TextEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDeleteInvoice = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cReason = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.txtHVHH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cSupporter
        '
        Me.cSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSupporter.FormattingEnabled = True
        Me.cSupporter.Location = New System.Drawing.Point(12, 34)
        Me.cSupporter.Name = "cSupporter"
        Me.cSupporter.Size = New System.Drawing.Size(223, 21)
        Me.cSupporter.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Սպասարկող"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(15, 132)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(189, 23)
        Me.btnSelect.TabIndex = 5
        Me.btnSelect.Text = "Ցուցադրել"
        '
        'cYear
        '
        Me.cYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cYear.FormattingEnabled = True
        Me.cYear.Location = New System.Drawing.Point(281, 34)
        Me.cYear.Name = "cYear"
        Me.cYear.Size = New System.Drawing.Size(118, 21)
        Me.cYear.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(278, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Տարի"
        '
        'cMonth
        '
        Me.cMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMonth.FormattingEnabled = True
        Me.cMonth.Location = New System.Drawing.Point(405, 34)
        Me.cMonth.Name = "cMonth"
        Me.cMonth.Size = New System.Drawing.Size(85, 21)
        Me.cMonth.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(402, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Ամիս"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "ՀՎՀՀ"
        '
        'txtHVHH
        '
        Me.txtHVHH.Location = New System.Drawing.Point(53, 76)
        Me.txtHVHH.Name = "txtHVHH"
        Me.txtHVHH.Size = New System.Drawing.Size(166, 20)
        Me.txtHVHH.TabIndex = 3
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(0, 180)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(647, 223)
        Me.GridControl1.TabIndex = 38
        Me.GridControl1.TabStop = False
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDeleteInvoice})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(132, 26)
        '
        'mnuDeleteInvoice
        '
        Me.mnuDeleteInvoice.Image = CType(resources.GetObject("mnuDeleteInvoice.Image"), System.Drawing.Image)
        Me.mnuDeleteInvoice.Name = "mnuDeleteInvoice"
        Me.mnuDeleteInvoice.Size = New System.Drawing.Size(131, 22)
        Me.mnuDeleteInvoice.Text = "Ջնջել Հ/Ա"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always
        Me.GridView1.OptionsFind.ShowClearButton = False
        Me.GridView1.OptionsFind.ShowFindButton = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'cReason
        '
        Me.cReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cReason.FormattingEnabled = True
        Me.cReason.Items.AddRange(New Object() {"Լուծարված", "Հաշվառումից հանված", "Ժամանակավոր դադարեցված", "Սնանկ", "Լուծարված-միավորված", "Մահացած", "Ջնջված"})
        Me.cReason.Location = New System.Drawing.Point(281, 75)
        Me.cReason.Name = "cReason"
        Me.cReason.Size = New System.Drawing.Size(209, 21)
        Me.cReason.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(225, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Պատճառ"
        '
        'DeleteInvoiceWindow
        '
        Me.AcceptButton = Me.btnSelect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 403)
        Me.Controls.Add(Me.cReason)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.txtHVHH)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cMonth)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.cSupporter)
        Me.Controls.Add(Me.Label2)
        Me.MinimizeBox = False
        Me.Name = "DeleteInvoiceWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ջնջել Հ/Ա"
        CType(Me.txtHVHH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents cSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHVHH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDeleteInvoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cReason As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
