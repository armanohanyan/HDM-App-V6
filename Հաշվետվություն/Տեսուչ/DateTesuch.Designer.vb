<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateTesuch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DateTesuch))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cYear = New System.Windows.Forms.ComboBox()
        Me.btnQuery = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cMonth = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cRegion = New System.Windows.Forms.ComboBox()
        Me.btnDoubleVisit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAllDB = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNotServed = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Տարի"
        '
        'cYear
        '
        Me.cYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cYear.FormattingEnabled = True
        Me.cYear.Location = New System.Drawing.Point(11, 30)
        Me.cYear.Name = "cYear"
        Me.cYear.Size = New System.Drawing.Size(94, 21)
        Me.cYear.TabIndex = 0
        '
        'btnQuery
        '
        Me.btnQuery.Image = CType(resources.GetObject("btnQuery.Image"), System.Drawing.Image)
        Me.btnQuery.Location = New System.Drawing.Point(12, 116)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(280, 23)
        Me.btnQuery.TabIndex = 3
        Me.btnQuery.Text = "Այցելություններ"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(185, 247)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Փակել"
        '
        'cMonth
        '
        Me.cMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cMonth.FormattingEnabled = True
        Me.cMonth.Location = New System.Drawing.Point(111, 30)
        Me.cMonth.Name = "cMonth"
        Me.cMonth.Size = New System.Drawing.Size(94, 21)
        Me.cMonth.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(111, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Ամիս"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 57)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "Տարածաշրջան"
        '
        'cRegion
        '
        Me.cRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cRegion.FormattingEnabled = True
        Me.cRegion.Items.AddRange(New Object() {"Երևան", "Մարզեր"})
        Me.cRegion.Location = New System.Drawing.Point(12, 76)
        Me.cRegion.Name = "cRegion"
        Me.cRegion.Size = New System.Drawing.Size(279, 21)
        Me.cRegion.TabIndex = 2
        '
        'btnDoubleVisit
        '
        Me.btnDoubleVisit.Image = CType(resources.GetObject("btnDoubleVisit.Image"), System.Drawing.Image)
        Me.btnDoubleVisit.Location = New System.Drawing.Point(12, 145)
        Me.btnDoubleVisit.Name = "btnDoubleVisit"
        Me.btnDoubleVisit.Size = New System.Drawing.Size(280, 23)
        Me.btnDoubleVisit.TabIndex = 4
        Me.btnDoubleVisit.Text = "Կրկնվող Այցեր"
        '
        'btnAllDB
        '
        Me.btnAllDB.Image = CType(resources.GetObject("btnAllDB.Image"), System.Drawing.Image)
        Me.btnAllDB.Location = New System.Drawing.Point(11, 174)
        Me.btnAllDB.Name = "btnAllDB"
        Me.btnAllDB.Size = New System.Drawing.Size(280, 23)
        Me.btnAllDB.TabIndex = 5
        Me.btnAllDB.Text = "Ամբողջ Բազան"
        '
        'btnNotServed
        '
        Me.btnNotServed.Image = CType(resources.GetObject("btnNotServed.Image"), System.Drawing.Image)
        Me.btnNotServed.Location = New System.Drawing.Point(11, 203)
        Me.btnNotServed.Name = "btnNotServed"
        Me.btnNotServed.Size = New System.Drawing.Size(280, 23)
        Me.btnNotServed.TabIndex = 6
        Me.btnNotServed.Text = "Չսպասարկված ՀԴՄ"
        '
        'DateTesuch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 284)
        Me.Controls.Add(Me.btnNotServed)
        Me.Controls.Add(Me.btnAllDB)
        Me.Controls.Add(Me.btnDoubleVisit)
        Me.Controls.Add(Me.cRegion)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cMonth)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.cYear)
        Me.Controls.Add(Me.LabelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DateTesuch"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրերի Ընտրություն"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnQuery As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cMonth As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cRegion As System.Windows.Forms.ComboBox
    Friend WithEvents btnDoubleVisit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAllDB As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNotServed As DevExpress.XtraEditors.SimpleButton
End Class
