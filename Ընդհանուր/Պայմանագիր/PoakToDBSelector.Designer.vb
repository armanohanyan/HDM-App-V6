<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PoakToDBSelector
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
        Me.cbList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'cbList
        '
        Me.cbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbList.FormattingEnabled = True
        Me.cbList.Location = New System.Drawing.Point(12, 27)
        Me.cbList.Name = "cbList"
        Me.cbList.Size = New System.Drawing.Size(235, 21)
        Me.cbList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Կարգավիճակ"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(12, 68)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(235, 27)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Ընտրել"
        '
        'PoakToDBSelector
        '
        Me.AcceptButton = Me.btnSelect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 119)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PoakToDBSelector"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ընտրել Կարգավիճակը"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents cbList As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
End Class
