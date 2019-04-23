<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CallSmsGeneral
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
        Me.txtTesuch = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTel = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.btnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProblem = New System.Windows.Forms.TextBox()
        CType(Me.txtTesuch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTesuch
        '
        Me.txtTesuch.Location = New System.Drawing.Point(122, 21)
        Me.txtTesuch.Name = "txtTesuch"
        Me.txtTesuch.Properties.ReadOnly = True
        Me.txtTesuch.Size = New System.Drawing.Size(228, 20)
        Me.txtTesuch.TabIndex = 42
        Me.txtTesuch.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Տեսուչ"
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(122, 47)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Properties.ReadOnly = True
        Me.txtTel.Size = New System.Drawing.Size(228, 20)
        Me.txtTel.TabIndex = 44
        Me.txtTel.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Հեռախոս"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Հաղորդագրություն"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(122, 212)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(325, 124)
        Me.txtMessage.TabIndex = 0
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(134, 356)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(146, 23)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "Ուղարկել"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(301, 356)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(146, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Փակել"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Խնդիր"
        '
        'txtProblem
        '
        Me.txtProblem.BackColor = System.Drawing.Color.White
        Me.txtProblem.Location = New System.Drawing.Point(122, 73)
        Me.txtProblem.Multiline = True
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.ReadOnly = True
        Me.txtProblem.Size = New System.Drawing.Size(325, 124)
        Me.txtProblem.TabIndex = 0
        Me.txtProblem.TabStop = False
        '
        'CallSmsGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 399)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtProblem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTesuch)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CallSmsGeneral"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ուղարկել SMS Տեսուչին (Ընդհանուր)"
        CType(Me.txtTesuch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents txtTesuch As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProblem As System.Windows.Forms.TextBox
End Class
