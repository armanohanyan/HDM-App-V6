<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TesuchRegion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TesuchRegion))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOldTesuch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbRegion = New System.Windows.Forms.ComboBox()
        Me.cbNewTesuch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ընթացիկ Տեսուչ"
        '
        'txtOldTesuch
        '
        Me.txtOldTesuch.Location = New System.Drawing.Point(109, 20)
        Me.txtOldTesuch.Name = "txtOldTesuch"
        Me.txtOldTesuch.ReadOnly = True
        Me.txtOldTesuch.Size = New System.Drawing.Size(241, 21)
        Me.txtOldTesuch.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Տարածաշրջան"
        '
        'cbRegion
        '
        Me.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegion.FormattingEnabled = True
        Me.cbRegion.Location = New System.Drawing.Point(109, 47)
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Size = New System.Drawing.Size(241, 21)
        Me.cbRegion.TabIndex = 2
        '
        'cbNewTesuch
        '
        Me.cbNewTesuch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNewTesuch.FormattingEnabled = True
        Me.cbNewTesuch.Location = New System.Drawing.Point(109, 114)
        Me.cbNewTesuch.Name = "cbNewTesuch"
        Me.cbNewTesuch.Size = New System.Drawing.Size(241, 21)
        Me.cbNewTesuch.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Նոր Տեսուչ"
        '
        'btnUpdate
        '
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.Location = New System.Drawing.Point(164, 158)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(186, 31)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Փոփոխել"
        '
        'TesuchRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 215)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.cbNewTesuch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbRegion)
        Me.Controls.Add(Me.txtOldTesuch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TesuchRegion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տարածաշրջանի Փոխում"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOldTesuch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents cbNewTesuch As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As DevExpress.XtraEditors.SimpleButton
End Class
