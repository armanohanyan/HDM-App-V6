<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseInsert2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseInsert2))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.txtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.txtQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.cbEquipment = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtWareHouse = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWareHouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(25, 112)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl5.TabIndex = 25
        Me.LabelControl5.Text = "Մեկնաբան"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(44, 89)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl3.TabIndex = 24
        Me.LabelControl3.Text = "Գումար"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(45, 63)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 23
        Me.LabelControl2.Text = "Քանակ"
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(91, 115)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(267, 91)
        Me.txtComment.TabIndex = 3
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.EditValue = "0.00"
        Me.txtAmount.Location = New System.Drawing.Point(91, 89)
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
        Me.txtAmount.Properties.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(267, 20)
        Me.txtAmount.TabIndex = 2
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.EditValue = "0.00"
        Me.txtQuantity.Location = New System.Drawing.Point(91, 63)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Properties.Appearance.Options.UseTextOptions = True
        Me.txtQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtQuantity.Properties.DisplayFormat.FormatString = "MaskType = Numeric, EditMask = 'n2'"
        Me.txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtQuantity.Properties.EditFormat.FormatString = "MaskType = Numeric, EditMask = 'n2'"
        Me.txtQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtQuantity.Properties.Mask.EditMask = "n0"
        Me.txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtQuantity.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtQuantity.Size = New System.Drawing.Size(267, 20)
        Me.txtQuantity.TabIndex = 1
        '
        'cbEquipment
        '
        Me.cbEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEquipment.FormattingEnabled = True
        Me.cbEquipment.Location = New System.Drawing.Point(91, 36)
        Me.cbEquipment.Name = "cbEquipment"
        Me.cbEquipment.Size = New System.Drawing.Size(267, 21)
        Me.cbEquipment.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 36)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Սարքավորում"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(211, 229)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(147, 27)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Ավելացնել"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(39, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl4.TabIndex = 21
        Me.LabelControl4.Text = "Պահեստ"
        '
        'txtWareHouse
        '
        Me.txtWareHouse.Location = New System.Drawing.Point(91, 12)
        Me.txtWareHouse.Name = "txtWareHouse"
        Me.txtWareHouse.Properties.ReadOnly = True
        Me.txtWareHouse.Size = New System.Drawing.Size(267, 20)
        Me.txtWareHouse.TabIndex = 26
        Me.txtWareHouse.TabStop = False
        '
        'PurchaseInsert2
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 283)
        Me.Controls.Add(Me.txtWareHouse)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.cbEquipment)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PurchaseInsert2"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պահեստի Ներմուծում (Նյութ)"
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWareHouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbEquipment As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWareHouse As DevExpress.XtraEditors.TextEdit
End Class
