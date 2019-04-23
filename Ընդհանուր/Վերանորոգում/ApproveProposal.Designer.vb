<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApproveProposal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApproveProposal))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.txtEzrakac = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnApprove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSMS = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTel = New DevExpress.XtraEditors.TextEdit()
        Me.lTesuch = New System.Windows.Forms.Label()
        CType(Me.txtTel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(120, 78)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(266, 60)
        Me.txtComment.TabIndex = 0
        '
        'txtEzrakac
        '
        Me.txtEzrakac.Location = New System.Drawing.Point(120, 14)
        Me.txtEzrakac.Multiline = True
        Me.txtEzrakac.Name = "txtEzrakac"
        Me.txtEzrakac.ReadOnly = True
        Me.txtEzrakac.Size = New System.Drawing.Size(266, 60)
        Me.txtEzrakac.TabIndex = 15
        Me.txtEzrakac.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Մեկնաբանություն"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Եզրակացություն"
        '
        'btnApprove
        '
        Me.btnApprove.Image = CType(resources.GetObject("btnApprove.Image"), System.Drawing.Image)
        Me.btnApprove.Location = New System.Drawing.Point(276, 209)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(110, 30)
        Me.btnApprove.TabIndex = 1
        Me.btnApprove.Text = "Հաստատել"
        '
        'btnSMS
        '
        Me.btnSMS.Enabled = False
        Me.btnSMS.Image = CType(resources.GetObject("btnSMS.Image"), System.Drawing.Image)
        Me.btnSMS.Location = New System.Drawing.Point(12, 209)
        Me.btnSMS.Name = "btnSMS"
        Me.btnSMS.Size = New System.Drawing.Size(110, 30)
        Me.btnSMS.TabIndex = 2
        Me.btnSMS.Text = "Ուղարկել SMS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Հեռախոս"
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(120, 155)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Properties.ReadOnly = True
        Me.txtTel.Size = New System.Drawing.Size(266, 20)
        Me.txtTel.TabIndex = 20
        Me.txtTel.TabStop = False
        '
        'lTesuch
        '
        Me.lTesuch.AutoSize = True
        Me.lTesuch.Location = New System.Drawing.Point(18, 254)
        Me.lTesuch.Name = "lTesuch"
        Me.lTesuch.Size = New System.Drawing.Size(47, 13)
        Me.lTesuch.TabIndex = 21
        Me.lTesuch.Text = "Տեսուչ՝ "
        '
        'ApproveProposal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 276)
        Me.Controls.Add(Me.lTesuch)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSMS)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtEzrakac)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ApproveProposal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Հաստատել Հայտ"
        CType(Me.txtTel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtEzrakac As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnApprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSMS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lTesuch As System.Windows.Forms.Label
End Class
