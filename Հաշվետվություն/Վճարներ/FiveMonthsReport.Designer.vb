<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiveMonthsReport
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiveMonthsReport))
        Me.cMonth = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.cYear = New System.Windows.Forms.ComboBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'cMonth
        '
        Me.cMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMonth.FormattingEnabled = True
        Me.cMonth.Location = New System.Drawing.Point(131, 35)
        Me.cMonth.Name = "cMonth"
        Me.cMonth.Size = New System.Drawing.Size(94, 21)
        Me.cMonth.TabIndex = 13
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(131, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "Ամիս"
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(131, 77)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(128, 23)
        Me.btnQuery.TabIndex = 12
        Me.btnQuery.Text = "Հաստատել"
        '
        'cYear
        '
        Me.cYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cYear.FormattingEnabled = True
        Me.cYear.Location = New System.Drawing.Point(31, 35)
        Me.cYear.Name = "cYear"
        Me.cYear.Size = New System.Drawing.Size(94, 21)
        Me.cYear.TabIndex = 10
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(31, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "Տարի"
        '
        'FiveMonthsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 123)
        Me.Controls.Add(Me.cMonth)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cYear)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FiveMonthsReport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ընտրեք Պարամետրը"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cMonth As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cYear As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
