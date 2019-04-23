<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Change_Password
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Change_Password))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOldPass = New System.Windows.Forms.TextBox()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.btnResetPass = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChangePass = New DevExpress.XtraEditors.SimpleButton()
        Me.cbLogins = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Օգտանուն"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Հին Գաղտնաբառ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Նոր Գաղտնաբառ"
        '
        'txtOldPass
        '
        Me.txtOldPass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOldPass.Location = New System.Drawing.Point(159, 42)
        Me.txtOldPass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOldPass.Name = "txtOldPass"
        Me.txtOldPass.Size = New System.Drawing.Size(156, 21)
        Me.txtOldPass.TabIndex = 1
        Me.txtOldPass.UseSystemPasswordChar = True
        '
        'txtNewPass
        '
        Me.txtNewPass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewPass.Location = New System.Drawing.Point(159, 66)
        Me.txtNewPass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Size = New System.Drawing.Size(156, 21)
        Me.txtNewPass.TabIndex = 2
        Me.txtNewPass.UseSystemPasswordChar = True
        '
        'btnResetPass
        '
        Me.btnResetPass.Enabled = False
        Me.btnResetPass.Image = CType(resources.GetObject("btnResetPass.Image"), System.Drawing.Image)
        Me.btnResetPass.Location = New System.Drawing.Point(32, 100)
        Me.btnResetPass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnResetPass.Name = "btnResetPass"
        Me.btnResetPass.Size = New System.Drawing.Size(102, 33)
        Me.btnResetPass.TabIndex = 4
        Me.btnResetPass.Text = "Ջնջել (pass)"
        Me.btnResetPass.Visible = False
        '
        'btnChangePass
        '
        Me.btnChangePass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangePass.Image = CType(resources.GetObject("btnChangePass.Image"), System.Drawing.Image)
        Me.btnChangePass.Location = New System.Drawing.Point(159, 100)
        Me.btnChangePass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnChangePass.Name = "btnChangePass"
        Me.btnChangePass.Size = New System.Drawing.Size(155, 33)
        Me.btnChangePass.TabIndex = 3
        Me.btnChangePass.Text = "Փոխել Գաղտնաբառը"
        '
        'cbLogins
        '
        Me.cbLogins.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLogins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLogins.FormattingEnabled = True
        Me.cbLogins.Location = New System.Drawing.Point(159, 19)
        Me.cbLogins.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbLogins.Name = "cbLogins"
        Me.cbLogins.Size = New System.Drawing.Size(156, 21)
        Me.cbLogins.Sorted = True
        Me.cbLogins.TabIndex = 0
        '
        'Change_Password
        '
        Me.AcceptButton = Me.btnChangePass
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 159)
        Me.Controls.Add(Me.cbLogins)
        Me.Controls.Add(Me.btnChangePass)
        Me.Controls.Add(Me.btnResetPass)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.txtOldPass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Change_Password"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Փոխել Գաղտնաբառը"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOldPass As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents btnResetPass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChangePass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbLogins As System.Windows.Forms.ComboBox
End Class
