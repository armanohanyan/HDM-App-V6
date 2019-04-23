<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepSelRemakeDayCounter
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
        Me.btnSrahNorog = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSrahNorNorog = New DevExpress.XtraEditors.SimpleButton()
        Me.btnWorkshopNorog = New DevExpress.XtraEditors.SimpleButton()
        Me.btnWorkshopExists = New DevExpress.XtraEditors.SimpleButton()
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
        Me.eDate.Location = New System.Drawing.Point(161, 23)
        Me.eDate.Name = "eDate"
        Me.eDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.eDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.eDate.Size = New System.Drawing.Size(113, 20)
        Me.eDate.TabIndex = 7
        '
        'sDate
        '
        Me.sDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sDate.EditValue = Nothing
        Me.sDate.Location = New System.Drawing.Point(42, 22)
        Me.sDate.Name = "sDate"
        Me.sDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.sDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.sDate.Size = New System.Drawing.Size(113, 20)
        Me.sDate.TabIndex = 6
        '
        'btnSrahNorog
        '
        Me.btnSrahNorog.Location = New System.Drawing.Point(42, 60)
        Me.btnSrahNorog.Name = "btnSrahNorog"
        Me.btnSrahNorog.Size = New System.Drawing.Size(232, 31)
        Me.btnSrahNorog.TabIndex = 8
        Me.btnSrahNorog.Text = "Սրահում Առկա Նորոգված"
        '
        'btnSrahNorNorog
        '
        Me.btnSrahNorNorog.Location = New System.Drawing.Point(42, 97)
        Me.btnSrahNorNorog.Name = "btnSrahNorNorog"
        Me.btnSrahNorNorog.Size = New System.Drawing.Size(232, 31)
        Me.btnSrahNorNorog.TabIndex = 9
        Me.btnSrahNorNorog.Text = "Սրահում Պատրաստ Չհաստատված"
        '
        'btnWorkshopNorog
        '
        Me.btnWorkshopNorog.Location = New System.Drawing.Point(42, 134)
        Me.btnWorkshopNorog.Name = "btnWorkshopNorog"
        Me.btnWorkshopNorog.Size = New System.Drawing.Size(232, 31)
        Me.btnWorkshopNorog.TabIndex = 10
        Me.btnWorkshopNorog.Text = "Արհեստանոցում Վերանորոգված"
        '
        'btnWorkshopExists
        '
        Me.btnWorkshopExists.Location = New System.Drawing.Point(42, 171)
        Me.btnWorkshopExists.Name = "btnWorkshopExists"
        Me.btnWorkshopExists.Size = New System.Drawing.Size(232, 31)
        Me.btnWorkshopExists.TabIndex = 11
        Me.btnWorkshopExists.Text = "Արհեստանոցում Առկա"
        '
        'RepSelRemakeDayCounter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 225)
        Me.Controls.Add(Me.btnWorkshopExists)
        Me.Controls.Add(Me.btnWorkshopNorog)
        Me.Controls.Add(Me.btnSrahNorNorog)
        Me.Controls.Add(Me.btnSrahNorog)
        Me.Controls.Add(Me.eDate)
        Me.Controls.Add(Me.sDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RepSelRemakeDayCounter"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Քանակային Հաշվետվություն"
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents eDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnSrahNorog As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSrahNorNorog As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnWorkshopNorog As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnWorkshopExists As DevExpress.XtraEditors.SimpleButton
End Class
