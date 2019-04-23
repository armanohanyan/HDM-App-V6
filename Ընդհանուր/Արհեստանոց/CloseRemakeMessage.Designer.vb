<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CloseRemakeMessage
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
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.txtSender = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtM = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ՀԴՄ"
        '
        'txtEcr
        '
        Me.txtEcr.Location = New System.Drawing.Point(85, 41)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.ReadOnly = True
        Me.txtEcr.Size = New System.Drawing.Size(259, 21)
        Me.txtEcr.TabIndex = 1
        Me.txtEcr.TabStop = False
        '
        'txtSender
        '
        Me.txtSender.Location = New System.Drawing.Point(85, 12)
        Me.txtSender.Name = "txtSender"
        Me.txtSender.ReadOnly = True
        Me.txtSender.Size = New System.Drawing.Size(259, 21)
        Me.txtSender.TabIndex = 3
        Me.txtSender.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ուղարկող"
        '
        'txtM
        '
        Me.txtM.Location = New System.Drawing.Point(85, 68)
        Me.txtM.Multiline = True
        Me.txtM.Name = "txtM"
        Me.txtM.ReadOnly = True
        Me.txtM.Size = New System.Drawing.Size(351, 81)
        Me.txtM.TabIndex = 5
        Me.txtM.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Հաղորդ."
        '
        'txtSM
        '
        Me.txtSM.Location = New System.Drawing.Point(85, 155)
        Me.txtSM.Multiline = True
        Me.txtSM.Name = "txtSM"
        Me.txtSM.Size = New System.Drawing.Size(351, 81)
        Me.txtSM.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Պատասխան"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(254, 254)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(182, 39)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Պատասխանել և Փակել"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'CloseRemakeMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(448, 310)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtSM)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSender)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEcr)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CloseRemakeMessage"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պատասխանել Հաղորդագրությանը"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
    Friend WithEvents txtSender As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtM As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSM As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
