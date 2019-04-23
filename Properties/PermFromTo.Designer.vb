<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PermFromTo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PermFromTo))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.cbG1 = New System.Windows.Forms.ComboBox()
        Me.cbG2 = New System.Windows.Forms.ComboBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbG1
        '
        Me.cbG1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbG1.FormattingEnabled = True
        Me.cbG1.Location = New System.Drawing.Point(12, 25)
        Me.cbG1.Name = "cbG1"
        Me.cbG1.Size = New System.Drawing.Size(225, 21)
        Me.cbG1.TabIndex = 0
        '
        'cbG2
        '
        Me.cbG2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbG2.FormattingEnabled = True
        Me.cbG2.Location = New System.Drawing.Point(12, 70)
        Me.cbG2.Name = "cbG2"
        Me.cbG2.Size = New System.Drawing.Size(225, 21)
        Me.cbG2.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(78, 113)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(159, 29)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Կատարել"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Խմբից"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Խմբին"
        '
        'PermFromTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 166)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.cbG2)
        Me.Controls.Add(Me.cbG1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PermFromTo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Փոխանցել"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents cbG1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbG2 As System.Windows.Forms.ComboBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
