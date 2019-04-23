<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditGeneralHayt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditGeneralHayt))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.eDate = New DevExpress.XtraEditors.DateEdit()
        Me.sDate = New DevExpress.XtraEditors.DateEdit()
        Me.ckInterval = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckInterval.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnShow
        '
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(36, 124)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(233, 32)
        Me.btnShow.TabIndex = 15
        Me.btnShow.Text = "Ցուցադրել"
        '
        'eDate
        '
        Me.eDate.EditValue = Nothing
        Me.eDate.Location = New System.Drawing.Point(159, 62)
        Me.eDate.Name = "eDate"
        Me.eDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.eDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.eDate.Size = New System.Drawing.Size(125, 20)
        Me.eDate.TabIndex = 14
        '
        'sDate
        '
        Me.sDate.EditValue = Nothing
        Me.sDate.Location = New System.Drawing.Point(19, 62)
        Me.sDate.Name = "sDate"
        Me.sDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.sDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.sDate.Size = New System.Drawing.Size(125, 20)
        Me.sDate.TabIndex = 13
        '
        'ckInterval
        '
        Me.ckInterval.EditValue = True
        Me.ckInterval.Location = New System.Drawing.Point(18, 25)
        Me.ckInterval.Name = "ckInterval"
        Me.ckInterval.Properties.Caption = "Ըստ Ամսաթվի"
        Me.ckInterval.Size = New System.Drawing.Size(102, 19)
        Me.ckInterval.TabIndex = 12
        '
        'EditGeneralHayt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 209)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.eDate)
        Me.Controls.Add(Me.sDate)
        Me.Controls.Add(Me.ckInterval)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditGeneralHayt"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ընդհանուր Հայտ"
        CType(Me.eDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckInterval.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents eDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ckInterval As DevExpress.XtraEditors.CheckEdit
End Class
