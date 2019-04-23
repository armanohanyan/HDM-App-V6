<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentUpWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentUpWin))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ckCanSell = New DevExpress.XtraEditors.CheckEdit()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.ckAllowSell = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.ckCanSell.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckAllowSell.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(202, 98)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(119, 27)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Փոփոխել"
        '
        'txtEquipment
        '
        Me.txtEquipment.Location = New System.Drawing.Point(88, 15)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Size = New System.Drawing.Size(194, 21)
        Me.txtEquipment.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Սարքավորում"
        '
        'ckCanSell
        '
        Me.ckCanSell.Location = New System.Drawing.Point(12, 42)
        Me.ckCanSell.Name = "ckCanSell"
        Me.ckCanSell.Properties.Caption = "Սարք / Նյութ"
        Me.ckCanSell.Size = New System.Drawing.Size(123, 19)
        Me.ckCanSell.TabIndex = 1
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(288, 15)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(36, 21)
        Me.txtCode.TabIndex = 8
        Me.txtCode.TabStop = False
        '
        'ckAllowSell
        '
        Me.ckAllowSell.Location = New System.Drawing.Point(12, 67)
        Me.ckAllowSell.Name = "ckAllowSell"
        Me.ckAllowSell.Properties.Caption = "Վաճառքի Հնարավորություն"
        Me.ckAllowSell.Size = New System.Drawing.Size(174, 19)
        Me.ckAllowSell.TabIndex = 9
        '
        'EquipmentUpWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 136)
        Me.Controls.Add(Me.ckAllowSell)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.ckCanSell)
        Me.Controls.Add(Me.txtEquipment)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EquipmentUpWin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Փոխել Սարքավորում"
        CType(Me.ckCanSell.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckAllowSell.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtEquipment As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ckCanSell As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents ckAllowSell As DevExpress.XtraEditors.CheckEdit
End Class
