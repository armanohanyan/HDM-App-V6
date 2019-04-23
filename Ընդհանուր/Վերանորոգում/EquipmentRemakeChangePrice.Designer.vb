<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentRemakeChangePrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentRemakeChangePrice))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEquipment = New DevExpress.XtraEditors.TextEdit()
        Me.txtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnChange = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtEquipment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Սարքավորում"
        '
        'txtEquipment
        '
        Me.txtEquipment.Location = New System.Drawing.Point(15, 35)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Properties.ReadOnly = True
        Me.txtEquipment.Size = New System.Drawing.Size(331, 20)
        Me.txtEquipment.TabIndex = 1
        Me.txtEquipment.TabStop = False
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.EditValue = "0.00"
        Me.txtAmount.Location = New System.Drawing.Point(15, 83)
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
        Me.txtAmount.Size = New System.Drawing.Size(170, 20)
        Me.txtAmount.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Նոր Գումար"
        '
        'btnChange
        '
        Me.btnChange.Image = CType(resources.GetObject("btnChange.Image"), System.Drawing.Image)
        Me.btnChange.Location = New System.Drawing.Point(123, 122)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(224, 35)
        Me.btnChange.TabIndex = 1
        Me.btnChange.Text = "Փոխել"
        '
        'EquipmentRemakeChangePrice
        '
        Me.AcceptButton = Me.btnChange
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 169)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtEquipment)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EquipmentRemakeChangePrice"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Փոխել Սարքավորման Գումարը"
        CType(Me.txtEquipment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEquipment As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnChange As DevExpress.XtraEditors.SimpleButton
End Class
