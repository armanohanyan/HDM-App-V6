<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printNoPrintInvoiceSelect
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
        Me.cPrinted = New System.Windows.Forms.RadioButton()
        Me.cNoPrinted = New System.Windows.Forms.RadioButton()
        Me.cYear = New System.Windows.Forms.ComboBox()
        Me.cMonth = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ckAll = New DevExpress.XtraEditors.CheckEdit()
        Me.cNotRet = New System.Windows.Forms.RadioButton()
        Me.cRet = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ckAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cPrinted
        '
        Me.cPrinted.AutoSize = True
        Me.cPrinted.Checked = True
        Me.cPrinted.Location = New System.Drawing.Point(17, 172)
        Me.cPrinted.Name = "cPrinted"
        Me.cPrinted.Size = New System.Drawing.Size(81, 17)
        Me.cPrinted.TabIndex = 0
        Me.cPrinted.TabStop = True
        Me.cPrinted.Text = "Տպված Հ/Ա"
        Me.cPrinted.UseVisualStyleBackColor = True
        Me.cPrinted.Visible = False
        '
        'cNoPrinted
        '
        Me.cNoPrinted.AutoSize = True
        Me.cNoPrinted.Location = New System.Drawing.Point(144, 172)
        Me.cNoPrinted.Name = "cNoPrinted"
        Me.cNoPrinted.Size = New System.Drawing.Size(89, 17)
        Me.cNoPrinted.TabIndex = 1
        Me.cNoPrinted.Text = "Չտպված Հ/Ա"
        Me.cNoPrinted.UseVisualStyleBackColor = True
        Me.cNoPrinted.Visible = False
        '
        'cYear
        '
        Me.cYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cYear.FormattingEnabled = True
        Me.cYear.Location = New System.Drawing.Point(17, 37)
        Me.cYear.Name = "cYear"
        Me.cYear.Size = New System.Drawing.Size(121, 21)
        Me.cYear.TabIndex = 2
        '
        'cMonth
        '
        Me.cMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMonth.FormattingEnabled = True
        Me.cMonth.Location = New System.Drawing.Point(144, 37)
        Me.cMonth.Name = "cMonth"
        Me.cMonth.Size = New System.Drawing.Size(121, 21)
        Me.cMonth.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Տարի"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(141, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ամիս"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(96, 143)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(169, 23)
        Me.btnSelect.TabIndex = 4
        Me.btnSelect.Text = "Ցուցադրել"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckAll)
        Me.GroupBox1.Controls.Add(Me.cNotRet)
        Me.GroupBox1.Controls.Add(Me.cRet)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 73)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Պարամետր"
        '
        'ckAll
        '
        Me.ckAll.Location = New System.Drawing.Point(127, 42)
        Me.ckAll.Name = "ckAll"
        Me.ckAll.Properties.Caption = "Բոլորը"
        Me.ckAll.Size = New System.Drawing.Size(75, 19)
        Me.ckAll.TabIndex = 2
        '
        'cNotRet
        '
        Me.cNotRet.AutoSize = True
        Me.cNotRet.Location = New System.Drawing.Point(6, 43)
        Me.cNotRet.Name = "cNotRet"
        Me.cNotRet.Size = New System.Drawing.Size(103, 17)
        Me.cNotRet.TabIndex = 1
        Me.cNotRet.Text = "Չվերադարձված"
        Me.cNotRet.UseVisualStyleBackColor = True
        '
        'cRet
        '
        Me.cRet.AutoSize = True
        Me.cRet.Checked = True
        Me.cRet.Location = New System.Drawing.Point(6, 20)
        Me.cRet.Name = "cRet"
        Me.cRet.Size = New System.Drawing.Size(97, 17)
        Me.cRet.TabIndex = 0
        Me.cRet.TabStop = True
        Me.cRet.Text = "Վերադարձված"
        Me.cRet.UseVisualStyleBackColor = True
        '
        'printNoPrintInvoiceSelect
        '
        Me.AcceptButton = Me.btnSelect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 196)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.cMonth)
        Me.Controls.Add(Me.cYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cNoPrinted)
        Me.Controls.Add(Me.cPrinted)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "printNoPrintInvoiceSelect"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ընտրել Պարամետրը"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ckAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents cPrinted As System.Windows.Forms.RadioButton
    Friend WithEvents cNoPrinted As System.Windows.Forms.RadioButton
    Friend WithEvents cYear As System.Windows.Forms.ComboBox
    Friend WithEvents cMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cNotRet As System.Windows.Forms.RadioButton
    Friend WithEvents cRet As System.Windows.Forms.RadioButton
    Friend WithEvents ckAll As DevExpress.XtraEditors.CheckEdit
End Class
