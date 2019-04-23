<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepRemakeTimeCounter
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
        Me.eDate = New DevExpress.XtraEditors.DateEdit()
        Me.sDate = New DevExpress.XtraEditors.DateEdit()
        Me.btnBranchWorkShowToCenter = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCenterToBranch = New DevExpress.XtraEditors.SimpleButton()
        Me.btnWorkToCenter = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnApprovedNotSend = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemakeDuration = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRemakeWorkshop = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'eDate
        '
        Me.eDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.eDate.EditValue = Nothing
        Me.eDate.Location = New System.Drawing.Point(198, 24)
        Me.eDate.Name = "eDate"
        Me.eDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.eDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.eDate.Size = New System.Drawing.Size(113, 20)
        Me.eDate.TabIndex = 1
        '
        'sDate
        '
        Me.sDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sDate.EditValue = Nothing
        Me.sDate.Location = New System.Drawing.Point(79, 23)
        Me.sDate.Name = "sDate"
        Me.sDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.sDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.sDate.Size = New System.Drawing.Size(113, 20)
        Me.sDate.TabIndex = 0
        '
        'btnBranchWorkShowToCenter
        '
        Me.btnBranchWorkShowToCenter.Appearance.Options.UseTextOptions = True
        Me.btnBranchWorkShowToCenter.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnBranchWorkShowToCenter.Location = New System.Drawing.Point(28, 282)
        Me.btnBranchWorkShowToCenter.Name = "btnBranchWorkShowToCenter"
        Me.btnBranchWorkShowToCenter.Size = New System.Drawing.Size(332, 31)
        Me.btnBranchWorkShowToCenter.TabIndex = 8
        Me.btnBranchWorkShowToCenter.Text = "Մասնաճյուղի Արհեստանոց - Կենտրոնի Սրահ"
        '
        'btnCenterToBranch
        '
        Me.btnCenterToBranch.Appearance.Options.UseTextOptions = True
        Me.btnCenterToBranch.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnCenterToBranch.Location = New System.Drawing.Point(28, 245)
        Me.btnCenterToBranch.Name = "btnCenterToBranch"
        Me.btnCenterToBranch.Size = New System.Drawing.Size(332, 31)
        Me.btnCenterToBranch.TabIndex = 7
        Me.btnCenterToBranch.Text = "Կենտրոնի Սրահից - Մասնաճյուղի Սրահ"
        '
        'btnWorkToCenter
        '
        Me.btnWorkToCenter.Appearance.Options.UseTextOptions = True
        Me.btnWorkToCenter.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnWorkToCenter.Location = New System.Drawing.Point(28, 208)
        Me.btnWorkToCenter.Name = "btnWorkToCenter"
        Me.btnWorkToCenter.Size = New System.Drawing.Size(332, 31)
        Me.btnWorkToCenter.TabIndex = 6
        Me.btnWorkToCenter.Text = "Արհեստանոցից - Սրահ"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Options.UseTextOptions = True
        Me.SimpleButton1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.SimpleButton1.Location = New System.Drawing.Point(28, 171)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(332, 31)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "Սրահից - Արհեստանոց"
        '
        'btnApprovedNotSend
        '
        Me.btnApprovedNotSend.Appearance.Options.UseTextOptions = True
        Me.btnApprovedNotSend.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnApprovedNotSend.Location = New System.Drawing.Point(28, 134)
        Me.btnApprovedNotSend.Name = "btnApprovedNotSend"
        Me.btnApprovedNotSend.Size = New System.Drawing.Size(332, 31)
        Me.btnApprovedNotSend.TabIndex = 4
        Me.btnApprovedNotSend.Text = "Հաստատված - Չտրամադրված"
        '
        'btnRemakeDuration
        '
        Me.btnRemakeDuration.Appearance.Options.UseTextOptions = True
        Me.btnRemakeDuration.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnRemakeDuration.Location = New System.Drawing.Point(28, 97)
        Me.btnRemakeDuration.Name = "btnRemakeDuration"
        Me.btnRemakeDuration.Size = New System.Drawing.Size(332, 31)
        Me.btnRemakeDuration.TabIndex = 3
        Me.btnRemakeDuration.Text = "Վերանորոգման Տևողություն (հայտի բացում - հաստատում)"
        '
        'btnRemakeWorkshop
        '
        Me.btnRemakeWorkshop.Appearance.Options.UseTextOptions = True
        Me.btnRemakeWorkshop.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnRemakeWorkshop.Location = New System.Drawing.Point(28, 60)
        Me.btnRemakeWorkshop.Name = "btnRemakeWorkshop"
        Me.btnRemakeWorkshop.Size = New System.Drawing.Size(332, 31)
        Me.btnRemakeWorkshop.TabIndex = 2
        Me.btnRemakeWorkshop.Text = "Վերանորոգման Տևողություն (Արհեստանոց)"
        '
        'RepRemakeTimeCounter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 331)
        Me.Controls.Add(Me.btnRemakeWorkshop)
        Me.Controls.Add(Me.btnRemakeDuration)
        Me.Controls.Add(Me.btnApprovedNotSend)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnWorkToCenter)
        Me.Controls.Add(Me.btnCenterToBranch)
        Me.Controls.Add(Me.btnBranchWorkShowToCenter)
        Me.Controls.Add(Me.eDate)
        Me.Controls.Add(Me.sDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RepRemakeTimeCounter"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տևողության Հաշվետվություն"
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents eDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnBranchWorkShowToCenter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCenterToBranch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnWorkToCenter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnApprovedNotSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemakeDuration As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemakeWorkshop As DevExpress.XtraEditors.SimpleButton
End Class
