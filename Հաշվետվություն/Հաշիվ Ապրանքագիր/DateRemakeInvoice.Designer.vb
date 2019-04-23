<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateRemakeInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DateRemakeInvoice))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cYear = New System.Windows.Forms.ComboBox()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cMonth = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cSupporter = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 57)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Տարի"
        '
        'cYear
        '
        Me.cYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cYear.FormattingEnabled = True
        Me.cYear.Location = New System.Drawing.Point(16, 76)
        Me.cYear.Name = "cYear"
        Me.cYear.Size = New System.Drawing.Size(94, 21)
        Me.cYear.TabIndex = 3
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(38, 115)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(106, 23)
        Me.btnQuery.TabIndex = 5
        Me.btnQuery.Text = "Հաստատել"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(162, 115)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Փակել"
        '
        'cMonth
        '
        Me.cMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMonth.FormattingEnabled = True
        Me.cMonth.Location = New System.Drawing.Point(116, 76)
        Me.cMonth.Name = "cMonth"
        Me.cMonth.Size = New System.Drawing.Size(94, 21)
        Me.cMonth.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(116, 57)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Ամիս"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Սպասարկող"
        '
        'cSupporter
        '
        Me.cSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSupporter.FormattingEnabled = True
        Me.cSupporter.Location = New System.Drawing.Point(15, 25)
        Me.cSupporter.Name = "cSupporter"
        Me.cSupporter.Size = New System.Drawing.Size(266, 21)
        Me.cSupporter.TabIndex = 0
        '
        'DateRemakeInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 158)
        Me.Controls.Add(Me.cSupporter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cMonth)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cYear)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DateRemakeInvoice"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cSupporter As System.Windows.Forms.ComboBox
End Class
