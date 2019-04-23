<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EcrFunctional
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
        Me.cInvoice = New DevExpress.XtraEditors.CheckEdit()
        Me.cPos = New DevExpress.XtraEditors.CheckEdit()
        Me.cVTQ = New DevExpress.XtraEditors.CheckEdit()
        Me.btnChange = New DevExpress.XtraEditors.SimpleButton()
        Me.cShrjik = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.cInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cPos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cVTQ.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cShrjik.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cInvoice
        '
        Me.cInvoice.Location = New System.Drawing.Point(12, 12)
        Me.cInvoice.Name = "cInvoice"
        Me.cInvoice.Properties.Caption = "Tax Free"
        Me.cInvoice.Size = New System.Drawing.Size(142, 19)
        Me.cInvoice.TabIndex = 0
        '
        'cPos
        '
        Me.cPos.Location = New System.Drawing.Point(12, 37)
        Me.cPos.Name = "cPos"
        Me.cPos.Properties.Caption = "POS"
        Me.cPos.Size = New System.Drawing.Size(142, 19)
        Me.cPos.TabIndex = 1
        '
        'cVTQ
        '
        Me.cVTQ.Location = New System.Drawing.Point(12, 62)
        Me.cVTQ.Name = "cVTQ"
        Me.cVTQ.Properties.Caption = "V-ից Q"
        Me.cVTQ.Size = New System.Drawing.Size(142, 19)
        Me.cVTQ.TabIndex = 2
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(127, 120)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(166, 23)
        Me.btnChange.TabIndex = 3
        Me.btnChange.Text = "Փոխել"
        '
        'cShrjik
        '
        Me.cShrjik.Location = New System.Drawing.Point(12, 87)
        Me.cShrjik.Name = "cShrjik"
        Me.cShrjik.Properties.Caption = "Շրջիկ"
        Me.cShrjik.Size = New System.Drawing.Size(142, 19)
        Me.cShrjik.TabIndex = 14
        Me.cShrjik.TabStop = False
        '
        'EcrFunctional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 155)
        Me.Controls.Add(Me.cShrjik)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.cVTQ)
        Me.Controls.Add(Me.cPos)
        Me.Controls.Add(Me.cInvoice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EcrFunctional"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ՀԴՄ Ֆունկցիոնալ"
        CType(Me.cInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cPos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cVTQ.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cShrjik.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents cInvoice As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cPos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cVTQ As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnChange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cShrjik As DevExpress.XtraEditors.CheckEdit
End Class
