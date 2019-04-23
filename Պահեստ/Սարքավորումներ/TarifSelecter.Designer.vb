<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarifSelecter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TarifSelecter))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cbTarif = New System.Windows.Forms.ComboBox()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 22)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Տարիֆ"
        '
        'cbTarif
        '
        Me.cbTarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTarif.FormattingEnabled = True
        Me.cbTarif.Location = New System.Drawing.Point(19, 41)
        Me.cbTarif.Name = "cbTarif"
        Me.cbTarif.Size = New System.Drawing.Size(270, 21)
        Me.cbTarif.TabIndex = 3
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(34, 88)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(106, 23)
        Me.btnQuery.TabIndex = 6
        Me.btnQuery.Text = "Հաստատել"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(158, 88)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Փակել"
        '
        'TarifSelecter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 139)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cbTarif)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TarifSelecter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրերի Ընտրություն"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbTarif As System.Windows.Forms.ComboBox
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
End Class
