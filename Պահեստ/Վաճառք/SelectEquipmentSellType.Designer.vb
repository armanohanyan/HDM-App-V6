<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectEquipmentSellType
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
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.rSupporter = New System.Windows.Forms.RadioButton()
        Me.rClient = New System.Windows.Forms.RadioButton()
        Me.cSeller = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cBuyer = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHVHH = New System.Windows.Forms.TextBox()
        Me.btnCheck = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 436)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Nothing
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(646, 20)
        '
        'rSupporter
        '
        Me.rSupporter.AutoSize = True
        Me.rSupporter.Location = New System.Drawing.Point(14, 73)
        Me.rSupporter.Name = "rSupporter"
        Me.rSupporter.Size = New System.Drawing.Size(145, 17)
        Me.rSupporter.TabIndex = 1
        Me.rSupporter.Text = "Վաճառել Գործընկերոջը"
        Me.rSupporter.UseVisualStyleBackColor = True
        '
        'rClient
        '
        Me.rClient.AutoSize = True
        Me.rClient.Checked = True
        Me.rClient.Location = New System.Drawing.Point(6, 159)
        Me.rClient.Name = "rClient"
        Me.rClient.Size = New System.Drawing.Size(140, 17)
        Me.rClient.TabIndex = 2
        Me.rClient.TabStop = True
        Me.rClient.Text = "Վաճառել Հաճախորդին"
        Me.rClient.UseVisualStyleBackColor = True
        '
        'cSeller
        '
        Me.cSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cSeller.FormattingEnabled = True
        Me.cSeller.Location = New System.Drawing.Point(9, 30)
        Me.cSeller.Name = "cSeller"
        Me.cSeller.Size = New System.Drawing.Size(270, 21)
        Me.cSeller.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Վաճառող"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Գնորդ"
        '
        'cBuyer
        '
        Me.cBuyer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBuyer.FormattingEnabled = True
        Me.cBuyer.Location = New System.Drawing.Point(31, 122)
        Me.cBuyer.Name = "cBuyer"
        Me.cBuyer.Size = New System.Drawing.Size(248, 21)
        Me.cBuyer.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ՀՎՀՀ"
        '
        'txtHVHH
        '
        Me.txtHVHH.Location = New System.Drawing.Point(34, 192)
        Me.txtHVHH.Name = "txtHVHH"
        Me.txtHVHH.Size = New System.Drawing.Size(248, 21)
        Me.txtHVHH.TabIndex = 10
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(157, 229)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(125, 23)
        Me.btnCheck.TabIndex = 11
        Me.btnCheck.Text = "Ստուգել"
        '
        'SelectEquipmentSellType
        '
        Me.AcceptButton = Me.btnCheck
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 280)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.txtHVHH)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cBuyer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cSeller)
        Me.Controls.Add(Me.rClient)
        Me.Controls.Add(Me.rSupporter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectEquipmentSellType"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Վաճառքի Պարամետրեր"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents rSupporter As System.Windows.Forms.RadioButton
    Friend WithEvents rClient As System.Windows.Forms.RadioButton
    Friend WithEvents cSeller As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cBuyer As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHVHH As System.Windows.Forms.TextBox
    Friend WithEvents btnCheck As DevExpress.XtraEditors.SimpleButton
End Class
