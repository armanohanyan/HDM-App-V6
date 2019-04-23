<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcountWarhExSel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcountWarhExSel))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.eDate = New DevExpress.XtraEditors.DateEdit()
        Me.sDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbSupporter = New System.Windows.Forms.ComboBox()
        Me.cEquipment = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cNoNyut = New System.Windows.Forms.RadioButton()
        Me.cNyut = New System.Windows.Forms.RadioButton()
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'eDate
        '
        Me.eDate.EditValue = Nothing
        Me.eDate.Location = New System.Drawing.Point(161, 28)
        Me.eDate.Name = "eDate"
        Me.eDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.eDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.eDate.Size = New System.Drawing.Size(125, 20)
        Me.eDate.TabIndex = 1
        '
        'sDate
        '
        Me.sDate.EditValue = Nothing
        Me.sDate.Location = New System.Drawing.Point(21, 28)
        Me.sDate.Name = "sDate"
        Me.sDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.sDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.sDate.Size = New System.Drawing.Size(125, 20)
        Me.sDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Պահեստ"
        '
        'cbSupporter
        '
        Me.cbSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSupporter.FormattingEnabled = True
        Me.cbSupporter.Location = New System.Drawing.Point(24, 68)
        Me.cbSupporter.Name = "cbSupporter"
        Me.cbSupporter.Size = New System.Drawing.Size(265, 21)
        Me.cbSupporter.TabIndex = 2
        '
        'cEquipment
        '
        Me.cEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cEquipment.FormattingEnabled = True
        Me.cEquipment.Location = New System.Drawing.Point(21, 161)
        Me.cEquipment.Name = "cEquipment"
        Me.cEquipment.Size = New System.Drawing.Size(265, 21)
        Me.cEquipment.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Սարքավորում"
        '
        'btnShow
        '
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(132, 202)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(154, 23)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "Ցուցադրել"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Ամսաթիվ"
        '
        'cNoNyut
        '
        Me.cNoNyut.AutoSize = True
        Me.cNoNyut.Checked = True
        Me.cNoNyut.Location = New System.Drawing.Point(21, 95)
        Me.cNoNyut.Name = "cNoNyut"
        Me.cNoNyut.Size = New System.Drawing.Size(95, 17)
        Me.cNoNyut.TabIndex = 19
        Me.cNoNyut.TabStop = True
        Me.cNoNyut.Text = "Սարքավորում"
        Me.cNoNyut.UseVisualStyleBackColor = True
        '
        'cNyut
        '
        Me.cNyut.AutoSize = True
        Me.cNyut.Location = New System.Drawing.Point(21, 118)
        Me.cNyut.Name = "cNyut"
        Me.cNyut.Size = New System.Drawing.Size(53, 17)
        Me.cNyut.TabIndex = 20
        Me.cNyut.Text = "Նյութ"
        Me.cNyut.UseVisualStyleBackColor = True
        '
        'AcountWarhExSel
        '
        Me.AcceptButton = Me.btnShow
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 250)
        Me.Controls.Add(Me.cNyut)
        Me.Controls.Add(Me.cNoNyut)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.cEquipment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbSupporter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.eDate)
        Me.Controls.Add(Me.sDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AcountWarhExSel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պահեստի Մնացորդ"
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents eDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents cEquipment As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cNoNyut As System.Windows.Forms.RadioButton
    Friend WithEvents cNyut As System.Windows.Forms.RadioButton
End Class
