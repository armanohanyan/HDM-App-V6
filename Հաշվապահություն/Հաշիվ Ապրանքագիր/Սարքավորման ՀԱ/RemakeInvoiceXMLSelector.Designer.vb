<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemakeInvoiceXMLSelector
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
        Me.cSupporter = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'cSupporter
        '
        Me.cSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSupporter.FormattingEnabled = True
        Me.cSupporter.Location = New System.Drawing.Point(12, 34)
        Me.cSupporter.Name = "cSupporter"
        Me.cSupporter.Size = New System.Drawing.Size(223, 21)
        Me.cSupporter.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Սպասարկող"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(115, 77)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(189, 23)
        Me.btnSelect.TabIndex = 3
        Me.btnSelect.Text = "Ցուցադրել"
        '
        'RemakeInvoiceXMLSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 119)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.cSupporter)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RemakeInvoiceXMLSelector"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Սպասարկող"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents cSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
End Class
