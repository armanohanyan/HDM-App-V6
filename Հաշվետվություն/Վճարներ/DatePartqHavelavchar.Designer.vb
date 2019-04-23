<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatePartqHavelavchar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatePartqHavelavchar))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnQueryReRegister = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPartq = New DevExpress.XtraEditors.SimpleButton()
        Me.btnZroyakan = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHavelavchar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAll = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'btnQueryReRegister
        '
        Me.btnQueryReRegister.Image = CType(resources.GetObject("btnQueryReRegister.Image"), System.Drawing.Image)
        Me.btnQueryReRegister.Location = New System.Drawing.Point(12, 24)
        Me.btnQueryReRegister.Name = "btnQueryReRegister"
        Me.btnQueryReRegister.Size = New System.Drawing.Size(277, 23)
        Me.btnQueryReRegister.TabIndex = 6
        Me.btnQueryReRegister.Text = "Պարտքեր Վերագրանցումով"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(183, 182)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Փակել"
        '
        'btnPartq
        '
        Me.btnPartq.Image = CType(resources.GetObject("btnPartq.Image"), System.Drawing.Image)
        Me.btnPartq.Location = New System.Drawing.Point(12, 53)
        Me.btnPartq.Name = "btnPartq"
        Me.btnPartq.Size = New System.Drawing.Size(277, 23)
        Me.btnPartq.TabIndex = 8
        Me.btnPartq.Text = "Պարտքեր"
        '
        'btnZroyakan
        '
        Me.btnZroyakan.Image = CType(resources.GetObject("btnZroyakan.Image"), System.Drawing.Image)
        Me.btnZroyakan.Location = New System.Drawing.Point(12, 82)
        Me.btnZroyakan.Name = "btnZroyakan"
        Me.btnZroyakan.Size = New System.Drawing.Size(277, 23)
        Me.btnZroyakan.TabIndex = 9
        Me.btnZroyakan.Text = "Զրոյական"
        '
        'btnHavelavchar
        '
        Me.btnHavelavchar.Image = CType(resources.GetObject("btnHavelavchar.Image"), System.Drawing.Image)
        Me.btnHavelavchar.Location = New System.Drawing.Point(12, 111)
        Me.btnHavelavchar.Name = "btnHavelavchar"
        Me.btnHavelavchar.Size = New System.Drawing.Size(277, 23)
        Me.btnHavelavchar.TabIndex = 10
        Me.btnHavelavchar.Text = "Հավելավճարով"
        '
        'btnAll
        '
        Me.btnAll.Image = CType(resources.GetObject("btnAll.Image"), System.Drawing.Image)
        Me.btnAll.Location = New System.Drawing.Point(12, 140)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(277, 23)
        Me.btnAll.TabIndex = 11
        Me.btnAll.Text = "Բոլորը"
        '
        'DatePartqHavelavchar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 215)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.btnHavelavchar)
        Me.Controls.Add(Me.btnZroyakan)
        Me.Controls.Add(Me.btnPartq)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQueryReRegister)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DatePartqHavelavchar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրերի Ընտրություն"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnQueryReRegister As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPartq As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnZroyakan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHavelavchar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAll As DevExpress.XtraEditors.SimpleButton
End Class
