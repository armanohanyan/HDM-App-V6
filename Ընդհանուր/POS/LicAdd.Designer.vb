<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicAdd))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cBank = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLic = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(205, 113)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(119, 27)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Ավելացնել"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(38, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Բանկ"
        '
        'txtEcr
        '
        Me.txtEcr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtEcr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtEcr.Location = New System.Drawing.Point(73, 50)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.Size = New System.Drawing.Size(251, 21)
        Me.txtEcr.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ՀԴՄ"
        '
        'cBank
        '
        Me.cBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBank.FormattingEnabled = True
        Me.cBank.Location = New System.Drawing.Point(73, 18)
        Me.cBank.Name = "cBank"
        Me.cBank.Size = New System.Drawing.Size(251, 21)
        Me.cBank.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Լիցենզիա"
        '
        'txtLic
        '
        Me.txtLic.Location = New System.Drawing.Point(73, 77)
        Me.txtLic.Name = "txtLic"
        Me.txtLic.Size = New System.Drawing.Size(251, 21)
        Me.txtLic.TabIndex = 2
        '
        'LicAdd
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 152)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLic)
        Me.Controls.Add(Me.cBank)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEcr)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LicAdd"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Նոր Լիցենզիա"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLic As System.Windows.Forms.TextBox
End Class
