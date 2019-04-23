<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EcrMessageWindow
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
        Me.cbProblem = New System.Windows.Forms.ComboBox()
        Me.btnAddNewProblem = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbEmployee = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.cbEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Խնդիր"
        '
        'cbProblem
        '
        Me.cbProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProblem.FormattingEnabled = True
        Me.cbProblem.Location = New System.Drawing.Point(119, 22)
        Me.cbProblem.Name = "cbProblem"
        Me.cbProblem.Size = New System.Drawing.Size(394, 21)
        Me.cbProblem.TabIndex = 0
        '
        'btnAddNewProblem
        '
        Me.btnAddNewProblem.Location = New System.Drawing.Point(519, 22)
        Me.btnAddNewProblem.Name = "btnAddNewProblem"
        Me.btnAddNewProblem.Size = New System.Drawing.Size(29, 23)
        Me.btnAddNewProblem.TabIndex = 1
        Me.btnAddNewProblem.Text = "+"
        Me.btnAddNewProblem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Աշխատակիցներ"
        '
        'cbEmployee
        '
        Me.cbEmployee.EditValue = ""
        Me.cbEmployee.Location = New System.Drawing.Point(119, 57)
        Me.cbEmployee.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbEmployee.Name = "cbEmployee"
        Me.cbEmployee.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.cbEmployee.Properties.Appearance.Options.UseBackColor = True
        Me.cbEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbEmployee.Size = New System.Drawing.Size(394, 20)
        Me.cbEmployee.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(394, 91)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(154, 38)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "Ավելացնել"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'EcrMessageWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(569, 153)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbEmployee)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnAddNewProblem)
        Me.Controls.Add(Me.cbProblem)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EcrMessageWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տեղեկացնել ՀԴՄ Մասին"
        CType(Me.cbEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbProblem As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddNewProblem As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbEmployee As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
