<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class changeTarifWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(changeTarifWindow))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.txtClient = New DevExpress.XtraEditors.TextEdit()
        Me.txtHVHH = New DevExpress.XtraEditors.TextEdit()
        Me.txtTarif = New DevExpress.XtraEditors.TextEdit()
        Me.cbTarif = New System.Windows.Forms.ComboBox()
        Me.btnChange = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCheck = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtClient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHVHH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtClient
        '
        Me.txtClient.Location = New System.Drawing.Point(12, 25)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Properties.ReadOnly = True
        Me.txtClient.Size = New System.Drawing.Size(266, 20)
        Me.txtClient.TabIndex = 0
        Me.txtClient.TabStop = False
        '
        'txtHVHH
        '
        Me.txtHVHH.Location = New System.Drawing.Point(284, 25)
        Me.txtHVHH.Name = "txtHVHH"
        Me.txtHVHH.Size = New System.Drawing.Size(115, 20)
        Me.txtHVHH.TabIndex = 0
        '
        'txtTarif
        '
        Me.txtTarif.Location = New System.Drawing.Point(12, 68)
        Me.txtTarif.Name = "txtTarif"
        Me.txtTarif.Properties.ReadOnly = True
        Me.txtTarif.Size = New System.Drawing.Size(266, 20)
        Me.txtTarif.TabIndex = 2
        Me.txtTarif.TabStop = False
        '
        'cbTarif
        '
        Me.cbTarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTarif.FormattingEnabled = True
        Me.cbTarif.Location = New System.Drawing.Point(12, 124)
        Me.cbTarif.Name = "cbTarif"
        Me.cbTarif.Size = New System.Drawing.Size(387, 21)
        Me.cbTarif.TabIndex = 2
        '
        'btnChange
        '
        Me.btnChange.Enabled = False
        Me.btnChange.Image = CType(resources.GetObject("btnChange.Image"), System.Drawing.Image)
        Me.btnChange.Location = New System.Drawing.Point(238, 165)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(161, 23)
        Me.btnChange.TabIndex = 3
        Me.btnChange.Text = "Փոխել"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Գործընկեր"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(281, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ՀՎՀՀ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Ընթացիկ Տարիֆ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Նոր Տարիֆ"
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(284, 66)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(115, 23)
        Me.btnCheck.TabIndex = 1
        Me.btnCheck.Text = "Ստուգել"
        '
        'changeTarifWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 210)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.cbTarif)
        Me.Controls.Add(Me.txtTarif)
        Me.Controls.Add(Me.txtHVHH)
        Me.Controls.Add(Me.txtClient)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "changeTarifWindow"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Փոխել Տարիֆը"
        CType(Me.txtClient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHVHH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents txtClient As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtHVHH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTarif As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbTarif As System.Windows.Forms.ComboBox
    Friend WithEvents btnChange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCheck As DevExpress.XtraEditors.SimpleButton
End Class
