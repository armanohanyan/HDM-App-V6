<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GprsFileSelecter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GprsFileSelecter))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rBeeline = New System.Windows.Forms.RadioButton()
        Me.rViva = New System.Windows.Forms.RadioButton()
        Me.rOrange = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.Location = New System.Drawing.Point(146, 152)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(183, 31)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "Ընտրել Ֆայլը ..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rBeeline)
        Me.GroupBox1.Controls.Add(Me.rViva)
        Me.GroupBox1.Controls.Add(Me.rOrange)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 129)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Օպերատոր"
        '
        'rBeeline
        '
        Me.rBeeline.AutoSize = True
        Me.rBeeline.Location = New System.Drawing.Point(15, 95)
        Me.rBeeline.Name = "rBeeline"
        Me.rBeeline.Size = New System.Drawing.Size(61, 17)
        Me.rBeeline.TabIndex = 2
        Me.rBeeline.Text = "Բիլայն"
        Me.rBeeline.UseVisualStyleBackColor = True
        '
        'rViva
        '
        Me.rViva.AutoSize = True
        Me.rViva.Location = New System.Drawing.Point(15, 61)
        Me.rViva.Name = "rViva"
        Me.rViva.Size = New System.Drawing.Size(68, 17)
        Me.rViva.TabIndex = 1
        Me.rViva.Text = "Վիվասել"
        Me.rViva.UseVisualStyleBackColor = True
        '
        'rOrange
        '
        Me.rOrange.AutoSize = True
        Me.rOrange.Checked = True
        Me.rOrange.Location = New System.Drawing.Point(15, 29)
        Me.rOrange.Name = "rOrange"
        Me.rOrange.Size = New System.Drawing.Size(60, 17)
        Me.rOrange.TabIndex = 0
        Me.rOrange.TabStop = True
        Me.rOrange.Text = "Օրանժ"
        Me.rOrange.UseVisualStyleBackColor = True
        '
        'GprsFileSelecter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 204)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOpen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GprsFileSelecter"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ընտրեք Exceli-ի Ֆայլը"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rBeeline As System.Windows.Forms.RadioButton
    Friend WithEvents rViva As System.Windows.Forms.RadioButton
    Friend WithEvents rOrange As System.Windows.Forms.RadioButton
End Class
