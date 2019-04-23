<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeInvoiceData
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
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEcrCount = New DevExpress.XtraEditors.TextEdit()
        Me.txtWorkDay = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxWorkDay = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPrice = New DevExpress.XtraEditors.TextEdit()
        Me.txtNDS = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnChangeData = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtEcrCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxWorkDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNDS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ՀԴՄ Քանակ"
        '
        'txtEcrCount
        '
        Me.txtEcrCount.Location = New System.Drawing.Point(118, 18)
        Me.txtEcrCount.Name = "txtEcrCount"
        Me.txtEcrCount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtEcrCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtEcrCount.Properties.Mask.EditMask = "n0"
        Me.txtEcrCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtEcrCount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtEcrCount.Size = New System.Drawing.Size(100, 20)
        Me.txtEcrCount.TabIndex = 1
        '
        'txtWorkDay
        '
        Me.txtWorkDay.Location = New System.Drawing.Point(118, 44)
        Me.txtWorkDay.Name = "txtWorkDay"
        Me.txtWorkDay.Properties.Appearance.Options.UseTextOptions = True
        Me.txtWorkDay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtWorkDay.Properties.Mask.EditMask = "n0"
        Me.txtWorkDay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtWorkDay.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtWorkDay.Size = New System.Drawing.Size(100, 20)
        Me.txtWorkDay.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Աշխատած Օրեր"
        '
        'txtMaxWorkDay
        '
        Me.txtMaxWorkDay.Location = New System.Drawing.Point(318, 18)
        Me.txtMaxWorkDay.Name = "txtMaxWorkDay"
        Me.txtMaxWorkDay.Properties.Appearance.Options.UseTextOptions = True
        Me.txtMaxWorkDay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtMaxWorkDay.Properties.ReadOnly = True
        Me.txtMaxWorkDay.Size = New System.Drawing.Size(142, 20)
        Me.txtMaxWorkDay.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "MAX Օրեր"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(268, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Գումար"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(318, 44)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtPrice.Properties.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(142, 20)
        Me.txtPrice.TabIndex = 7
        '
        'txtNDS
        '
        Me.txtNDS.Location = New System.Drawing.Point(318, 70)
        Me.txtNDS.Name = "txtNDS"
        Me.txtNDS.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNDS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtNDS.Properties.ReadOnly = True
        Me.txtNDS.Size = New System.Drawing.Size(142, 20)
        Me.txtNDS.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "ԱԱՀ"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(318, 96)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotal.Properties.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(142, 20)
        Me.txtTotal.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(248, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Ընդհանուր"
        '
        'btnChangeData
        '
        Me.btnChangeData.Location = New System.Drawing.Point(26, 142)
        Me.btnChangeData.Name = "btnChangeData"
        Me.btnChangeData.Size = New System.Drawing.Size(192, 33)
        Me.btnChangeData.TabIndex = 12
        Me.btnChangeData.Text = "Փոխել Տվյալները"
        '
        'ChangeInvoiceData
        '
        Me.AcceptButton = Me.btnChangeData
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 187)
        Me.Controls.Add(Me.btnChangeData)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNDS)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMaxWorkDay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtWorkDay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEcrCount)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangeInvoiceData"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Փոխել Ինվոյսի Տվյալները"
        CType(Me.txtEcrCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxWorkDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNDS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEcrCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtWorkDay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMaxWorkDay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNDS As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnChangeData As DevExpress.XtraEditors.SimpleButton
End Class
