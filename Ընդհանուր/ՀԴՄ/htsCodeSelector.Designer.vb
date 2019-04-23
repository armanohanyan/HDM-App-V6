<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class htsCodeSelector
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
        Me.rAll = New System.Windows.Forms.RadioButton()
        Me.rInterval = New System.Windows.Forms.RadioButton()
        Me.txtStart = New DevExpress.XtraEditors.TextEdit()
        Me.txtEnd = New DevExpress.XtraEditors.TextEdit()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rAll
        '
        Me.rAll.AutoSize = True
        Me.rAll.Checked = True
        Me.rAll.Location = New System.Drawing.Point(12, 17)
        Me.rAll.Name = "rAll"
        Me.rAll.Size = New System.Drawing.Size(68, 17)
        Me.rAll.TabIndex = 0
        Me.rAll.TabStop = True
        Me.rAll.Text = "Ամբողջը"
        Me.rAll.UseVisualStyleBackColor = True
        '
        'rInterval
        '
        Me.rInterval.AutoSize = True
        Me.rInterval.Location = New System.Drawing.Point(12, 41)
        Me.rInterval.Name = "rInterval"
        Me.rInterval.Size = New System.Drawing.Size(89, 17)
        Me.rInterval.TabIndex = 1
        Me.rInterval.Text = "Միջակայքով"
        Me.rInterval.UseVisualStyleBackColor = True
        '
        'txtStart
        '
        Me.txtStart.Enabled = False
        Me.txtStart.Location = New System.Drawing.Point(111, 42)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Properties.Appearance.Options.UseTextOptions = True
        Me.txtStart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtStart.Properties.Mask.EditMask = "n0"
        Me.txtStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtStart.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtStart.Size = New System.Drawing.Size(144, 20)
        Me.txtStart.TabIndex = 2
        '
        'txtEnd
        '
        Me.txtEnd.Enabled = False
        Me.txtEnd.Location = New System.Drawing.Point(111, 68)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Properties.Appearance.Options.UseTextOptions = True
        Me.txtEnd.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtEnd.Properties.Mask.EditMask = "n0"
        Me.txtEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtEnd.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtEnd.Size = New System.Drawing.Size(144, 20)
        Me.txtEnd.TabIndex = 3
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(52, 107)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(144, 29)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "Ցուցադրել"
        '
        'htsCodeSelector
        '
        Me.AcceptButton = Me.btnShow
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 153)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.rInterval)
        Me.Controls.Add(Me.rAll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "htsCodeSelector"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ՀԾ Կոդ"
        CType(Me.txtStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents rAll As System.Windows.Forms.RadioButton
    Friend WithEvents rInterval As System.Windows.Forms.RadioButton
    Friend WithEvents txtStart As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEnd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
End Class
