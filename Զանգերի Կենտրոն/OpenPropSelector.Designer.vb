<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenPropSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenPropSelector))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.rTotal = New System.Windows.Forms.RadioButton()
        Me.rDetails = New System.Windows.Forms.RadioButton()
        Me.btnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'rTotal
        '
        Me.rTotal.AutoSize = True
        Me.rTotal.Checked = True
        Me.rTotal.Location = New System.Drawing.Point(12, 15)
        Me.rTotal.Name = "rTotal"
        Me.rTotal.Size = New System.Drawing.Size(61, 17)
        Me.rTotal.TabIndex = 0
        Me.rTotal.TabStop = True
        Me.rTotal.Text = "Ամփոփ"
        Me.rTotal.UseVisualStyleBackColor = True
        '
        'rDetails
        '
        Me.rDetails.AutoSize = True
        Me.rDetails.Location = New System.Drawing.Point(12, 38)
        Me.rDetails.Name = "rDetails"
        Me.rDetails.Size = New System.Drawing.Size(73, 17)
        Me.rDetails.TabIndex = 1
        Me.rDetails.Text = "Բացվածք"
        Me.rDetails.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.Location = New System.Drawing.Point(84, 58)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(171, 29)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "Բեռնել"
        '
        'OpenPropSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 99)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.rDetails)
        Me.Controls.Add(Me.rTotal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OpenPropSelector"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Բաց Հայտեր"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents rTotal As System.Windows.Forms.RadioButton
    Friend WithEvents rDetails As System.Windows.Forms.RadioButton
    Friend WithEvents btnLoad As DevExpress.XtraEditors.SimpleButton
End Class
