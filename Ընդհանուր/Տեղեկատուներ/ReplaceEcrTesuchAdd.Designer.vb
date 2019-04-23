<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReplaceEcrTesuchAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReplaceEcrTesuchAdd))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cTesuch = New System.Windows.Forms.ComboBox()
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(161, 82)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(119, 27)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Տրամադրել"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(61, 46)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 21
        Me.LabelControl2.Text = "ՀԴՄ"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(43, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl1.TabIndex = 20
        Me.LabelControl1.Text = "Տեսուչի"
        '
        'cTesuch
        '
        Me.cTesuch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTesuch.FormattingEnabled = True
        Me.cTesuch.Location = New System.Drawing.Point(89, 16)
        Me.cTesuch.Name = "cTesuch"
        Me.cTesuch.Size = New System.Drawing.Size(191, 21)
        Me.cTesuch.TabIndex = 22
        '
        'txtEcr
        '
        Me.txtEcr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEcr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEcr.Location = New System.Drawing.Point(89, 46)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.Size = New System.Drawing.Size(191, 21)
        Me.txtEcr.TabIndex = 24
        '
        'ReplaceEcrTesuchAdd
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 137)
        Me.Controls.Add(Me.txtEcr)
        Me.Controls.Add(Me.cTesuch)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReplaceEcrTesuchAdd"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տեսուչ Նոր ՀԴՄ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cTesuch As System.Windows.Forms.ComboBox
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
End Class
