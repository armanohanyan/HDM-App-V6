﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateBank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateBank))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(202, 57)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(119, 27)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Փոփոխել"
        '
        'txtBank
        '
        Me.txtBank.Location = New System.Drawing.Point(47, 15)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.Size = New System.Drawing.Size(275, 21)
        Me.txtBank.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Բանկ"
        '
        'UpdateBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 95)
        Me.Controls.Add(Me.txtBank)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateBank"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Բանկի Փոփոխում"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
