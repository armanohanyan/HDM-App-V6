<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CallEcrForReplace
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClientEcr = New DevExpress.XtraEditors.TextEdit()
        Me.txtRegion = New DevExpress.XtraEditors.TextEdit()
        Me.txtTesuch = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbEcr = New System.Windows.Forms.ComboBox()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtClientEcr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTesuch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Տարածաշրջան"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Հաճախորդի ՀԴՄ"
        '
        'txtClientEcr
        '
        Me.txtClientEcr.Location = New System.Drawing.Point(111, 16)
        Me.txtClientEcr.Name = "txtClientEcr"
        Me.txtClientEcr.Properties.ReadOnly = True
        Me.txtClientEcr.Size = New System.Drawing.Size(298, 20)
        Me.txtClientEcr.TabIndex = 2
        Me.txtClientEcr.TabStop = False
        '
        'txtRegion
        '
        Me.txtRegion.Location = New System.Drawing.Point(111, 42)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Properties.ReadOnly = True
        Me.txtRegion.Size = New System.Drawing.Size(298, 20)
        Me.txtRegion.TabIndex = 3
        Me.txtRegion.TabStop = False
        '
        'txtTesuch
        '
        Me.txtTesuch.Location = New System.Drawing.Point(111, 68)
        Me.txtTesuch.Name = "txtTesuch"
        Me.txtTesuch.Properties.ReadOnly = True
        Me.txtTesuch.Size = New System.Drawing.Size(298, 20)
        Me.txtTesuch.TabIndex = 5
        Me.txtTesuch.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Տեսուչ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "ՀԴՄ"
        '
        'cbEcr
        '
        Me.cbEcr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEcr.FormattingEnabled = True
        Me.cbEcr.Location = New System.Drawing.Point(111, 94)
        Me.cbEcr.Name = "cbEcr"
        Me.cbEcr.Size = New System.Drawing.Size(298, 21)
        Me.cbEcr.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(243, 143)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(166, 29)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Տրամադրել"
        '
        'CallEcrForReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 192)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbEcr)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTesuch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRegion)
        Me.Controls.Add(Me.txtClientEcr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CallEcrForReplace"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տրամադրել Փոխարինող"
        CType(Me.txtClientEcr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTesuch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClientEcr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRegion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTesuch As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbEcr As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
End Class
