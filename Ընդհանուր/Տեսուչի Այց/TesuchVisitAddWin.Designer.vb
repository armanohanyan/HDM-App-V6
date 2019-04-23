<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TesuchVisitAddWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TesuchVisitAddWin))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMGH = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cComment = New System.Windows.Forms.ComboBox()
        Me.cTesuch = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cDateEdit = New DevExpress.XtraEditors.DateEdit()
        CType(Me.cDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(199, 164)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(119, 27)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Ավելացնել"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(92, 26)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "ՄԳՀ"
        '
        'txtMGH
        '
        Me.txtMGH.Location = New System.Drawing.Point(119, 23)
        Me.txtMGH.Name = "txtMGH"
        Me.txtMGH.Size = New System.Drawing.Size(146, 21)
        Me.txtMGH.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Մեկնաբանություն"
        '
        'cComment
        '
        Me.cComment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cComment.FormattingEnabled = True
        Me.cComment.Items.AddRange(New Object() {"Ակտիվացում", "Բաժին Բացել", "Թարմեցում (Update)", "Ինվոյս", "Լիցքավորիչ", "Կասեցում", "Կասեցումից հանում", "Կարգավորում (Կալիբրովկա)", "ՊԵԿ", "Սովորեցնել", "Սպասարկում", "Վերագրանցում"})
        Me.cComment.Location = New System.Drawing.Point(119, 60)
        Me.cComment.Name = "cComment"
        Me.cComment.Size = New System.Drawing.Size(199, 21)
        Me.cComment.TabIndex = 1
        '
        'cTesuch
        '
        Me.cTesuch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTesuch.FormattingEnabled = True
        Me.cTesuch.Location = New System.Drawing.Point(119, 87)
        Me.cTesuch.Name = "cTesuch"
        Me.cTesuch.Size = New System.Drawing.Size(199, 21)
        Me.cTesuch.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Տեսուչ"
        '
        'cDateEdit
        '
        Me.cDateEdit.EditValue = Nothing
        Me.cDateEdit.Location = New System.Drawing.Point(119, 123)
        Me.cDateEdit.Name = "cDateEdit"
        Me.cDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm:ss"
        Me.cDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.cDateEdit.Size = New System.Drawing.Size(199, 20)
        Me.cDateEdit.TabIndex = 3
        '
        'TesuchVisitAddWin
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 204)
        Me.Controls.Add(Me.cDateEdit)
        Me.Controls.Add(Me.cTesuch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cComment)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMGH)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TesuchVisitAddWin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տեսուչի Նոր Այցելություն"
        CType(Me.cDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMGH As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cComment As System.Windows.Forms.ComboBox
    Friend WithEvents cTesuch As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cDateEdit As DevExpress.XtraEditors.DateEdit
End Class
