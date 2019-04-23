<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TesuchAddWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TesuchAddWindow))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.txtTesuchName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ckActive = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.ckActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTesuchName
        '
        Me.txtTesuchName.Location = New System.Drawing.Point(105, 16)
        Me.txtTesuchName.Name = "txtTesuchName"
        Me.txtTesuchName.Size = New System.Drawing.Size(198, 21)
        Me.txtTesuchName.TabIndex = 0
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(105, 66)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(198, 21)
        Me.txtEmail.TabIndex = 2
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(105, 91)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(198, 21)
        Me.txtTel.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(184, 123)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(119, 27)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Ավելացնել"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(46, 94)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl4.TabIndex = 23
        Me.LabelControl4.Text = "Հեռախոս"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(53, 69)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl3.TabIndex = 22
        Me.LabelControl3.Text = "Էլ Փոստ"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(28, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl2.TabIndex = 21
        Me.LabelControl2.Text = "Կարգավիճակ"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl1.TabIndex = 20
        Me.LabelControl1.Text = "Տեսուչի Անուն"
        '
        'ckActive
        '
        Me.ckActive.Location = New System.Drawing.Point(105, 42)
        Me.ckActive.Name = "ckActive"
        Me.ckActive.Properties.Caption = "Ակտիվ"
        Me.ckActive.Size = New System.Drawing.Size(75, 19)
        Me.ckActive.TabIndex = 1
        '
        'TesuchAddWindow
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 161)
        Me.Controls.Add(Me.ckActive)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtTesuchName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TesuchAddWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Նոր Տեսուչ"
        CType(Me.ckActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents txtTesuchName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ckActive As DevExpress.XtraEditors.CheckEdit
End Class
