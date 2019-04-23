<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewProblem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewProblem))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.txtProblem = New System.Windows.Forms.TextBox()
        Me.rbSoft = New System.Windows.Forms.RadioButton()
        Me.rbHard = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 21)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Խնդիր"
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(34, 101)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(106, 23)
        Me.btnQuery.TabIndex = 3
        Me.btnQuery.Text = "Հաստատել"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(158, 101)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Փակել"
        '
        'txtProblem
        '
        Me.txtProblem.Location = New System.Drawing.Point(58, 18)
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.Size = New System.Drawing.Size(206, 21)
        Me.txtProblem.TabIndex = 0
        '
        'rbSoft
        '
        Me.rbSoft.AutoSize = True
        Me.rbSoft.Checked = True
        Me.rbSoft.Location = New System.Drawing.Point(58, 45)
        Me.rbSoft.Name = "rbSoft"
        Me.rbSoft.Size = New System.Drawing.Size(83, 17)
        Me.rbSoft.TabIndex = 1
        Me.rbSoft.TabStop = True
        Me.rbSoft.Text = "Ծրագրային"
        Me.rbSoft.UseVisualStyleBackColor = True
        '
        'rbHard
        '
        Me.rbHard.AutoSize = True
        Me.rbHard.Location = New System.Drawing.Point(58, 68)
        Me.rbHard.Name = "rbHard"
        Me.rbHard.Size = New System.Drawing.Size(95, 17)
        Me.rbHard.TabIndex = 2
        Me.rbHard.Text = "Սարքավորում"
        Me.rbHard.UseVisualStyleBackColor = True
        '
        'NewProblem
        '
        Me.AcceptButton = Me.btnQuery
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 136)
        Me.Controls.Add(Me.rbHard)
        Me.Controls.Add(Me.rbSoft)
        Me.Controls.Add(Me.txtProblem)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewProblem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Նոր Խնդիր"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtProblem As System.Windows.Forms.TextBox
    Friend WithEvents rbSoft As System.Windows.Forms.RadioButton
    Friend WithEvents rbHard As System.Windows.Forms.RadioButton
End Class
