<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPersonalMessage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddPersonalMessage))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnSendMessage = New DevExpress.XtraEditors.SimpleButton()
        Me.cbMessageType = New System.Windows.Forms.ComboBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cbUser = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'btnSendMessage
        '
        Me.btnSendMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendMessage.Image = CType(resources.GetObject("btnSendMessage.Image"), System.Drawing.Image)
        Me.btnSendMessage.Location = New System.Drawing.Point(71, 199)
        Me.btnSendMessage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSendMessage.Name = "btnSendMessage"
        Me.btnSendMessage.Size = New System.Drawing.Size(208, 27)
        Me.btnSendMessage.TabIndex = 3
        Me.btnSendMessage.Text = "Ուղարկել"
        '
        'cbMessageType
        '
        Me.cbMessageType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMessageType.FormattingEnabled = True
        Me.cbMessageType.Items.AddRange(New Object() {"Ինֆորմատիվ", "Կարևոր"})
        Me.cbMessageType.Location = New System.Drawing.Point(79, 123)
        Me.cbMessageType.Name = "cbMessageType"
        Me.cbMessageType.Size = New System.Drawing.Size(259, 21)
        Me.cbMessageType.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 127)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl2.TabIndex = 16
        Me.LabelControl2.Text = "Հաղ. Տեսակ"
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.Location = New System.Drawing.Point(12, 29)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(326, 59)
        Me.txtMessage.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(192, 13)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "Հաղորդագրություն (MAX 1024 սիմվոլ)"
        '
        'cbUser
        '
        Me.cbUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUser.FormattingEnabled = True
        Me.cbUser.Location = New System.Drawing.Point(79, 159)
        Me.cbUser.Name = "cbUser"
        Me.cbUser.Size = New System.Drawing.Size(259, 21)
        Me.cbUser.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(13, 163)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl3.TabIndex = 19
        Me.LabelControl3.Text = "Հասցեատեր"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl4.Location = New System.Drawing.Point(12, 98)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(304, 13)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "Հաջորդ տող անցնելու համար սեղմել CTRL + Enter"
        '
        'AddPersonalMessage
        '
        Me.AcceptButton = Me.btnSendMessage
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 245)
        Me.Controls.Add(Me.cbUser)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.btnSendMessage)
        Me.Controls.Add(Me.cbMessageType)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddPersonalMessage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Անհատական Հաղորդագրություն"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnSendMessage As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbMessageType As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbUser As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
