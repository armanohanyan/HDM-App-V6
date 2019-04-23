<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GPSforProp
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.txtLatitude = New DevExpress.XtraEditors.TextEdit()
        Me.txtLongitude = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Latitude"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Longitude"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(118, 91)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(150, 34)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Ավելացնել"
        '
        'txtLatitude
        '
        Me.txtLatitude.EditValue = "0"
        Me.txtLatitude.Location = New System.Drawing.Point(90, 28)
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Properties.Appearance.Options.UseTextOptions = True
        Me.txtLatitude.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtLatitude.Properties.Mask.EditMask = "n10"
        Me.txtLatitude.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtLatitude.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtLatitude.Size = New System.Drawing.Size(178, 20)
        Me.txtLatitude.TabIndex = 0
        '
        'txtLongitude
        '
        Me.txtLongitude.EditValue = "0"
        Me.txtLongitude.Location = New System.Drawing.Point(90, 54)
        Me.txtLongitude.Name = "txtLongitude"
        Me.txtLongitude.Properties.Appearance.Options.UseTextOptions = True
        Me.txtLongitude.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtLongitude.Properties.Mask.EditMask = "n10"
        Me.txtLongitude.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtLongitude.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtLongitude.Size = New System.Drawing.Size(178, 20)
        Me.txtLongitude.TabIndex = 1
        '
        'GPSforProp
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 137)
        Me.Controls.Add(Me.txtLongitude)
        Me.Controls.Add(Me.txtLatitude)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GPSforProp"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Հայտի Կոորդինատ"
        CType(Me.txtLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtLatitude As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLongitude As DevExpress.XtraEditors.TextEdit
End Class
