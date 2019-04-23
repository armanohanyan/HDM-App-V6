<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBankFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectBankFile))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tm = New System.Windows.Forms.RadioButton()
        Me.mk = New System.Windows.Forms.RadioButton()
        Me.te = New System.Windows.Forms.RadioButton()
        Me.hs = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(12, 28)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(168, 30)
        Me.btnQuery.TabIndex = 5
        Me.btnQuery.Text = "Նշել Ֆայլը"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(186, 28)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 30)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Փակել"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tm)
        Me.GroupBox1.Controls.Add(Me.mk)
        Me.GroupBox1.Controls.Add(Me.te)
        Me.GroupBox1.Controls.Add(Me.hs)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 122)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Սպասարկող Կազմակերպություն"
        '
        'tm
        '
        Me.tm.AutoSize = True
        Me.tm.Location = New System.Drawing.Point(6, 89)
        Me.tm.Name = "tm"
        Me.tm.Size = New System.Drawing.Size(88, 17)
        Me.tm.TabIndex = 3
        Me.tm.Text = "Տոչ Մաստեր"
        Me.tm.UseVisualStyleBackColor = True
        '
        'mk
        '
        Me.mk.AutoSize = True
        Me.mk.Location = New System.Drawing.Point(6, 66)
        Me.mk.Name = "mk"
        Me.mk.Size = New System.Drawing.Size(87, 17)
        Me.mk.TabIndex = 2
        Me.mk.Text = "Մերի Քրիստ"
        Me.mk.UseVisualStyleBackColor = True
        '
        'te
        '
        Me.te.AutoSize = True
        Me.te.Location = New System.Drawing.Point(6, 43)
        Me.te.Name = "te"
        Me.te.Size = New System.Drawing.Size(106, 17)
        Me.te.TabIndex = 1
        Me.te.Text = "Տամա Էլեկտրոն"
        Me.te.UseVisualStyleBackColor = True
        '
        'hs
        '
        Me.hs.AutoSize = True
        Me.hs.Checked = True
        Me.hs.Location = New System.Drawing.Point(6, 20)
        Me.hs.Name = "hs"
        Me.hs.Size = New System.Drawing.Size(87, 17)
        Me.hs.TabIndex = 0
        Me.hs.TabStop = True
        Me.hs.Text = "ՀԴՄ Շտրիխ"
        Me.hs.UseVisualStyleBackColor = True
        '
        'SelectBankFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 207)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectBankFile"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրերի Ընտրություն"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tm As System.Windows.Forms.RadioButton
    Friend WithEvents mk As System.Windows.Forms.RadioButton
    Friend WithEvents te As System.Windows.Forms.RadioButton
    Friend WithEvents hs As System.Windows.Forms.RadioButton
End Class
