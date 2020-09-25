<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentAddWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentAddWin))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.ckCanSell = New DevExpress.XtraEditors.CheckEdit()
        Me.cbIsEcr = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.ckCanSell.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbIsEcr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(202, 57)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(119, 27)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Ավելացնել"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Սարքավորում"
        '
        'txtEquipment
        '
        Me.txtEquipment.Location = New System.Drawing.Point(88, 15)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Size = New System.Drawing.Size(234, 21)
        Me.txtEquipment.TabIndex = 0
        '
        'ckCanSell
        '
        Me.ckCanSell.Location = New System.Drawing.Point(12, 42)
        Me.ckCanSell.Name = "ckCanSell"
        Me.ckCanSell.Properties.Caption = "Սարք / Նյութ"
        Me.ckCanSell.Size = New System.Drawing.Size(123, 19)
        Me.ckCanSell.TabIndex = 1
        '
        'cbIsEcr
        '
        Me.cbIsEcr.Location = New System.Drawing.Point(12, 67)
        Me.cbIsEcr.Name = "cbIsEcr"
        Me.cbIsEcr.Properties.Caption = "ՀԴՄ"
        Me.cbIsEcr.Size = New System.Drawing.Size(123, 19)
        Me.cbIsEcr.TabIndex = 6
        '
        'EquipmentAddWin
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 95)
        Me.Controls.Add(Me.cbIsEcr)
        Me.Controls.Add(Me.ckCanSell)
        Me.Controls.Add(Me.txtEquipment)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EquipmentAddWin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Նոր Սարքավորում"
        CType(Me.ckCanSell.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbIsEcr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEquipment As System.Windows.Forms.TextBox
    Friend WithEvents ckCanSell As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cbIsEcr As DevExpress.XtraEditors.CheckEdit
End Class
