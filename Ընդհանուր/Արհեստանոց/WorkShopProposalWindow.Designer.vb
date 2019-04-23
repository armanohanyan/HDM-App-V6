<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkShopProposalWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkShopProposalWindow))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.rNew = New System.Windows.Forms.RadioButton()
        Me.rReturned = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(26, 133)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(106, 23)
        Me.btnQuery.TabIndex = 1
        Me.btnQuery.Text = "Հաստատել"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(150, 133)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Փակել"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "ՀԴՄ"
        '
        'txtEcr
        '
        Me.txtEcr.Location = New System.Drawing.Point(67, 13)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.Size = New System.Drawing.Size(162, 21)
        Me.txtEcr.TabIndex = 0
        '
        'rNew
        '
        Me.rNew.AutoSize = True
        Me.rNew.Checked = True
        Me.rNew.Location = New System.Drawing.Point(67, 56)
        Me.rNew.Name = "rNew"
        Me.rNew.Size = New System.Drawing.Size(144, 17)
        Me.rNew.TabIndex = 9
        Me.rNew.TabStop = True
        Me.rNew.Text = "Աշխատանք ՀԴՄ-ի Հետ"
        Me.rNew.UseVisualStyleBackColor = True
        '
        'rReturned
        '
        Me.rReturned.AutoSize = True
        Me.rReturned.Location = New System.Drawing.Point(67, 91)
        Me.rReturned.Name = "rReturned"
        Me.rReturned.Size = New System.Drawing.Size(147, 17)
        Me.rReturned.TabIndex = 10
        Me.rReturned.Text = "Վերադարձ Արհեստանոց"
        Me.rReturned.UseVisualStyleBackColor = True
        '
        'WorkShopProposalWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 175)
        Me.Controls.Add(Me.rReturned)
        Me.Controls.Add(Me.rNew)
        Me.Controls.Add(Me.txtEcr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WorkShopProposalWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Արհեստանոցի Հայտ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
    Friend WithEvents rNew As System.Windows.Forms.RadioButton
    Friend WithEvents rReturned As System.Windows.Forms.RadioButton
End Class
