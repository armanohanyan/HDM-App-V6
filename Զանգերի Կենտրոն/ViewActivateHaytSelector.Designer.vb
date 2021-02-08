<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewActivateHaytSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewActivateHaytSelector))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.ckOpen = New DevExpress.XtraEditors.CheckEdit()
        Me.eDate = New DevExpress.XtraEditors.DateEdit()
        Me.sDate = New DevExpress.XtraEditors.DateEdit()
        Me.ckInterval = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ckOpen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckInterval.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnShow)
        Me.GroupBox1.Controls.Add(Me.ckOpen)
        Me.GroupBox1.Controls.Add(Me.eDate)
        Me.GroupBox1.Controls.Add(Me.sDate)
        Me.GroupBox1.Controls.Add(Me.ckInterval)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 188)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Հայտեր"
        '
        'btnShow
        '
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(24, 129)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(233, 32)
        Me.btnShow.TabIndex = 11
        Me.btnShow.Text = "Ցուցադրել"
        '
        'ckOpen
        '
        Me.ckOpen.Location = New System.Drawing.Point(9, 80)
        Me.ckOpen.Name = "ckOpen"
        Me.ckOpen.Properties.Caption = "Ռեգիոն"
        Me.ckOpen.Size = New System.Drawing.Size(134, 19)
        Me.ckOpen.TabIndex = 10
        '
        'eDate
        '
        Me.eDate.EditValue = Nothing
        Me.eDate.Location = New System.Drawing.Point(149, 45)
        Me.eDate.Name = "eDate"
        Me.eDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.eDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.eDate.Size = New System.Drawing.Size(125, 20)
        Me.eDate.TabIndex = 9
        '
        'sDate
        '
        Me.sDate.EditValue = Nothing
        Me.sDate.Location = New System.Drawing.Point(9, 45)
        Me.sDate.Name = "sDate"
        Me.sDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.sDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.sDate.Size = New System.Drawing.Size(125, 20)
        Me.sDate.TabIndex = 8
        '
        'ckInterval
        '
        Me.ckInterval.EditValue = True
        Me.ckInterval.Location = New System.Drawing.Point(7, 20)
        Me.ckInterval.Name = "ckInterval"
        Me.ckInterval.Properties.Caption = "Ըստ Ամսաթվի"
        Me.ckInterval.Size = New System.Drawing.Size(102, 19)
        Me.ckInterval.TabIndex = 7
        '
        'ViewActivateHaytSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 209)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewActivateHaytSelector"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրեր"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ckOpen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckInterval.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ckOpen As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents eDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ckInterval As DevExpress.XtraEditors.CheckEdit
End Class
