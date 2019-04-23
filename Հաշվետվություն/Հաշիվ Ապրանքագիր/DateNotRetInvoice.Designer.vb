<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateNotRetInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DateNotRetInvoice))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cYear = New System.Windows.Forms.ComboBox()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cMonth = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ckAllTime = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(40, 34)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Տարի"
        '
        'cYear
        '
        Me.cYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cYear.FormattingEnabled = True
        Me.cYear.Location = New System.Drawing.Point(40, 53)
        Me.cYear.Name = "cYear"
        Me.cYear.Size = New System.Drawing.Size(94, 21)
        Me.cYear.TabIndex = 1
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(25, 93)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(106, 23)
        Me.btnQuery.TabIndex = 3
        Me.btnQuery.Text = "Հաստատել"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(149, 93)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Փակել"
        '
        'cMonth
        '
        Me.cMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMonth.FormattingEnabled = True
        Me.cMonth.Location = New System.Drawing.Point(140, 53)
        Me.cMonth.Name = "cMonth"
        Me.cMonth.Size = New System.Drawing.Size(94, 21)
        Me.cMonth.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(140, 34)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Ամիս"
        '
        'ckAllTime
        '
        Me.ckAllTime.AutoSize = True
        Me.ckAllTime.Location = New System.Drawing.Point(40, 11)
        Me.ckAllTime.Name = "ckAllTime"
        Me.ckAllTime.Size = New System.Drawing.Size(166, 17)
        Me.ckAllTime.TabIndex = 0
        Me.ckAllTime.Text = "Ամբողջ Ժամանակահատված"
        Me.ckAllTime.UseVisualStyleBackColor = True
        '
        'DateNotRetInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 128)
        Me.Controls.Add(Me.ckAllTime)
        Me.Controls.Add(Me.cMonth)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cYear)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DateNotRetInvoice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրերի Ընտրություն"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cMonth As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ckAllTime As System.Windows.Forms.CheckBox
End Class
