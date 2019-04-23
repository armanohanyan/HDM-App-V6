<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CorrectMiddleDB
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
        Me.btnPoakBazaForAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnpoakToDBGetReRegistering = New DevExpress.XtraEditors.SimpleButton()
        Me.btnpoakToDBMGHChanges = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChangePoakHVHH = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'btnPoakBazaForAdd
        '
        Me.btnPoakBazaForAdd.Location = New System.Drawing.Point(25, 21)
        Me.btnPoakBazaForAdd.Name = "btnPoakBazaForAdd"
        Me.btnPoakBazaForAdd.Size = New System.Drawing.Size(275, 35)
        Me.btnPoakBazaForAdd.TabIndex = 0
        Me.btnPoakBazaForAdd.Text = "ՊՈԱԿ Բազա (Ավելացման Ենթակա)"
        '
        'btnpoakToDBGetReRegistering
        '
        Me.btnpoakToDBGetReRegistering.Location = New System.Drawing.Point(25, 62)
        Me.btnpoakToDBGetReRegistering.Name = "btnpoakToDBGetReRegistering"
        Me.btnpoakToDBGetReRegistering.Size = New System.Drawing.Size(275, 35)
        Me.btnpoakToDBGetReRegistering.TabIndex = 1
        Me.btnpoakToDBGetReRegistering.Text = "ՊՈԱԿ Բազա (Վերագրանցման Ենթակա)"
        '
        'btnpoakToDBMGHChanges
        '
        Me.btnpoakToDBMGHChanges.Location = New System.Drawing.Point(25, 103)
        Me.btnpoakToDBMGHChanges.Name = "btnpoakToDBMGHChanges"
        Me.btnpoakToDBMGHChanges.Size = New System.Drawing.Size(275, 35)
        Me.btnpoakToDBMGHChanges.TabIndex = 2
        Me.btnpoakToDBMGHChanges.Text = "ՊՈԱԿ Բազա (ՄԳՀ Տարբերություն)"
        '
        'btnChangePoakHVHH
        '
        Me.btnChangePoakHVHH.Location = New System.Drawing.Point(25, 144)
        Me.btnChangePoakHVHH.Name = "btnChangePoakHVHH"
        Me.btnChangePoakHVHH.Size = New System.Drawing.Size(275, 35)
        Me.btnChangePoakHVHH.TabIndex = 3
        Me.btnChangePoakHVHH.Text = "ՊՈԱԿ Բազա (ՀՎՀՀ կարգաբերում)"
        '
        'CorrectMiddleDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 194)
        Me.Controls.Add(Me.btnChangePoakHVHH)
        Me.Controls.Add(Me.btnpoakToDBMGHChanges)
        Me.Controls.Add(Me.btnpoakToDBGetReRegistering)
        Me.Controls.Add(Me.btnPoakBazaForAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CorrectMiddleDB"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Կարգաբերել Միջանկյալ Բազան"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnPoakBazaForAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnpoakToDBGetReRegistering As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnpoakToDBMGHChanges As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChangePoakHVHH As DevExpress.XtraEditors.SimpleButton
End Class
