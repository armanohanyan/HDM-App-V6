<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MnacordSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MnacordSelector))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cbSupporter = New System.Windows.Forms.ComboBox()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cNoNyut = New System.Windows.Forms.RadioButton()
        Me.cNyut = New System.Windows.Forms.RadioButton()
        Me.cEquipment = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 22)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Պահեստ"
        '
        'cbSupporter
        '
        Me.cbSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSupporter.FormattingEnabled = True
        Me.cbSupporter.Location = New System.Drawing.Point(12, 41)
        Me.cbSupporter.Name = "cbSupporter"
        Me.cbSupporter.Size = New System.Drawing.Size(270, 21)
        Me.cbSupporter.TabIndex = 3
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(33, 181)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(106, 23)
        Me.btnQuery.TabIndex = 6
        Me.btnQuery.Text = "Հաստատել"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(157, 181)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Փակել"
        '
        'cNoNyut
        '
        Me.cNoNyut.AutoSize = True
        Me.cNoNyut.Checked = True
        Me.cNoNyut.Location = New System.Drawing.Point(12, 68)
        Me.cNoNyut.Name = "cNoNyut"
        Me.cNoNyut.Size = New System.Drawing.Size(95, 17)
        Me.cNoNyut.TabIndex = 8
        Me.cNoNyut.TabStop = True
        Me.cNoNyut.Text = "Սարքավորում"
        Me.cNoNyut.UseVisualStyleBackColor = True
        '
        'cNyut
        '
        Me.cNyut.AutoSize = True
        Me.cNyut.Location = New System.Drawing.Point(12, 91)
        Me.cNyut.Name = "cNyut"
        Me.cNyut.Size = New System.Drawing.Size(53, 17)
        Me.cNyut.TabIndex = 9
        Me.cNyut.Text = "Նյութ"
        Me.cNyut.UseVisualStyleBackColor = True
        '
        'cEquipment
        '
        Me.cEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cEquipment.FormattingEnabled = True
        Me.cEquipment.Location = New System.Drawing.Point(12, 138)
        Me.cEquipment.Name = "cEquipment"
        Me.cEquipment.Size = New System.Drawing.Size(270, 21)
        Me.cEquipment.TabIndex = 10
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 119)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "Սարքավորում"
        '
        'MnacordSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 250)
        Me.Controls.Add(Me.cEquipment)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cNyut)
        Me.Controls.Add(Me.cNoNyut)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cbSupporter)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MnacordSelector"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրերի Ընտրություն"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cNoNyut As System.Windows.Forms.RadioButton
    Friend WithEvents cNyut As System.Windows.Forms.RadioButton
    Friend WithEvents cEquipment As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
