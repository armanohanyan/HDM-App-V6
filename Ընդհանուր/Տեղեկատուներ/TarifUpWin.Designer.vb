﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarifUpWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TarifUpWin))
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.d31 = New DevExpress.XtraEditors.TextEdit()
        Me.d30 = New DevExpress.XtraEditors.TextEdit()
        Me.d29 = New DevExpress.XtraEditors.TextEdit()
        Me.d28 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTarif = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.d31.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d30.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d29.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d28.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(134, 156)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(119, 27)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Փոփոխել"
        '
        'd31
        '
        Me.d31.EditValue = "0"
        Me.d31.Location = New System.Drawing.Point(62, 119)
        Me.d31.Name = "d31"
        Me.d31.Properties.Appearance.Options.UseTextOptions = True
        Me.d31.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.d31.Properties.Mask.EditMask = "n4"
        Me.d31.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.d31.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.d31.Size = New System.Drawing.Size(83, 20)
        Me.d31.TabIndex = 4
        '
        'd30
        '
        Me.d30.EditValue = "0"
        Me.d30.Location = New System.Drawing.Point(62, 93)
        Me.d30.Name = "d30"
        Me.d30.Properties.Appearance.Options.UseTextOptions = True
        Me.d30.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.d30.Properties.Mask.EditMask = "n4"
        Me.d30.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.d30.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.d30.Size = New System.Drawing.Size(83, 20)
        Me.d30.TabIndex = 3
        '
        'd29
        '
        Me.d29.EditValue = "0"
        Me.d29.Location = New System.Drawing.Point(62, 68)
        Me.d29.Name = "d29"
        Me.d29.Properties.Appearance.Options.UseTextOptions = True
        Me.d29.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.d29.Properties.Mask.EditMask = "n4"
        Me.d29.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.d29.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.d29.Size = New System.Drawing.Size(83, 20)
        Me.d29.TabIndex = 2
        '
        'd28
        '
        Me.d28.EditValue = "0"
        Me.d28.Location = New System.Drawing.Point(62, 42)
        Me.d28.Name = "d28"
        Me.d28.Properties.Appearance.Options.UseTextOptions = True
        Me.d28.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.d28.Properties.Mask.EditMask = "n4"
        Me.d28.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.d28.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.d28.Size = New System.Drawing.Size(83, 20)
        Me.d28.TabIndex = 1
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 122)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl5.TabIndex = 20
        Me.LabelControl5.Text = "31 Օր"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 96)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl4.TabIndex = 19
        Me.LabelControl4.Text = "30 Օր"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 71)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl3.TabIndex = 18
        Me.LabelControl3.Text = "29 Օր"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 17
        Me.LabelControl2.Text = "28 Օր"
        '
        'txtTarif
        '
        Me.txtTarif.Location = New System.Drawing.Point(62, 15)
        Me.txtTarif.Name = "txtTarif"
        Me.txtTarif.Size = New System.Drawing.Size(191, 21)
        Me.txtTarif.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 16
        Me.LabelControl1.Text = "Տարիֆ"
        '
        'TarifUpWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 198)
        Me.Controls.Add(Me.d31)
        Me.Controls.Add(Me.d30)
        Me.Controls.Add(Me.d29)
        Me.Controls.Add(Me.d28)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtTarif)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TarifUpWin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տարիֆ Փոփոխում"
        CType(Me.d31.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d30.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d29.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d28.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents d31 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents d30 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents d29 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents d28 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTarif As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
