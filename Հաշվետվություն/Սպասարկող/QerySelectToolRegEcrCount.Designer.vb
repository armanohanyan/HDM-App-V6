<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QerySelectToolRegEcrCount
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
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cSupporter = New System.Windows.Forms.ComboBox()
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Սպասարկող"
        '
        'cSupporter
        '
        Me.cSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSupporter.FormattingEnabled = True
        Me.cSupporter.Location = New System.Drawing.Point(26, 50)
        Me.cSupporter.Name = "cSupporter"
        Me.cSupporter.Size = New System.Drawing.Size(231, 21)
        Me.cSupporter.TabIndex = 1
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(108, 101)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(149, 23)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Կատարել"
        '
        'QerySelectToolRegEcrCount
        '
        Me.AcceptButton = Me.btnSelect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 158)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.cSupporter)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "QerySelectToolRegEcrCount"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ընտրել Սպասարկողին"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
End Class
