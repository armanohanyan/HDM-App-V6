<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GprsRealStatus
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGprs = New System.Windows.Forms.TextBox()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnCheck = New DevExpress.XtraEditors.SimpleButton()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GPRS"
        '
        'txtGprs
        '
        Me.txtGprs.Location = New System.Drawing.Point(55, 27)
        Me.txtGprs.Name = "txtGprs"
        Me.txtGprs.Size = New System.Drawing.Size(159, 21)
        Me.txtGprs.TabIndex = 1
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(220, 27)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(142, 23)
        Me.btnCheck.TabIndex = 2
        Me.btnCheck.Text = "Ստանալ"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(55, 74)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(307, 142)
        Me.txtResult.TabIndex = 3
        '
        'GprsRealStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 238)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.txtGprs)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GprsRealStatus"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GPRS Իրական Կարգավիճակ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGprs As System.Windows.Forms.TextBox
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnCheck As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
End Class
