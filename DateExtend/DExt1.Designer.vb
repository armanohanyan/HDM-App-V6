<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DExt1
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
        Me.cDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChange = New DevExpress.XtraEditors.SimpleButton()
        Me.ckAdd = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.cDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cDateEdit
        '
        Me.cDateEdit.EditValue = Nothing
        Me.cDateEdit.Location = New System.Drawing.Point(51, 36)
        Me.cDateEdit.Name = "cDateEdit"
        Me.cDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm:ss"
        Me.cDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.cDateEdit.Size = New System.Drawing.Size(199, 20)
        Me.cDateEdit.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Վերջնաժամկետ"
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(108, 117)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(169, 26)
        Me.btnChange.TabIndex = 6
        Me.btnChange.Text = "Փոխել"
        '
        'ckAdd
        '
        Me.ckAdd.EditValue = True
        Me.ckAdd.Location = New System.Drawing.Point(38, 73)
        Me.ckAdd.Name = "ckAdd"
        Me.ckAdd.Properties.Caption = "Երկարացնել Ժամանակը / Ակտիվացնել"
        Me.ckAdd.Size = New System.Drawing.Size(226, 19)
        Me.ckAdd.TabIndex = 7
        '
        'DExt1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 155)
        Me.Controls.Add(Me.ckAdd)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cDateEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DExt1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Վերջնաժամկետ"
        CType(Me.cDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents cDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnChange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ckAdd As DevExpress.XtraEditors.CheckEdit
End Class
