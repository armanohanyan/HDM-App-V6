<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAddPay
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cTarif = New System.Windows.Forms.ComboBox()
        Me.cEquip = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPrice = New DevExpress.XtraEditors.TextEdit()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.txtPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Տարիֆ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Սարքավորում"
        '
        'cTarif
        '
        Me.cTarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTarif.FormattingEnabled = True
        Me.cTarif.Location = New System.Drawing.Point(128, 24)
        Me.cTarif.Name = "cTarif"
        Me.cTarif.Size = New System.Drawing.Size(255, 21)
        Me.cTarif.TabIndex = 2
        '
        'cEquip
        '
        Me.cEquip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cEquip.FormattingEnabled = True
        Me.cEquip.Location = New System.Drawing.Point(128, 55)
        Me.cEquip.Name = "cEquip"
        Me.cEquip.Size = New System.Drawing.Size(255, 21)
        Me.cEquip.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Հավելագին"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(128, 82)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtPrice.Properties.Mask.EditMask = "n2"
        Me.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPrice.Size = New System.Drawing.Size(193, 20)
        Me.txtPrice.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(247, 123)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(136, 33)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "Ավելացնել"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'NewAddPay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(416, 168)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cEquip)
        Me.Controls.Add(Me.cTarif)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewAddPay"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Նոր Հավելագին"
        CType(Me.txtPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cTarif As System.Windows.Forms.ComboBox
    Friend WithEvents cEquip As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
