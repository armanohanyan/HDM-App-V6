<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReplaceEcrTesuchReturn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReplaceEcrTesuchReturn))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnRet = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEcr = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtEcr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRet
        '
        Me.btnRet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRet.Image = CType(resources.GetObject("btnRet.Image"), System.Drawing.Image)
        Me.btnRet.Location = New System.Drawing.Point(161, 59)
        Me.btnRet.Name = "btnRet"
        Me.btnRet.Size = New System.Drawing.Size(119, 27)
        Me.btnRet.TabIndex = 4
        Me.btnRet.Text = "Վերադարձնել"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(36, 22)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 21
        Me.LabelControl2.Text = "ՀԴՄ"
        '
        'txtEcr
        '
        Me.txtEcr.Location = New System.Drawing.Point(64, 19)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.Properties.ReadOnly = True
        Me.txtEcr.Size = New System.Drawing.Size(216, 20)
        Me.txtEcr.TabIndex = 22
        '
        'ReplaceEcrTesuchReturn
        '
        Me.AcceptButton = Me.btnRet
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 115)
        Me.Controls.Add(Me.txtEcr)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnRet)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReplaceEcrTesuchReturn"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ՀԴՄ Վերադարձ"
        CType(Me.txtEcr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnRet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEcr As DevExpress.XtraEditors.TextEdit
End Class
