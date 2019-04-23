<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemakeClosedMessageViewer
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
        Me.txtSUser = New System.Windows.Forms.TextBox()
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProblem = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSDate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAUser = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRep = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRepDate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ուղարկող"
        '
        'txtSUser
        '
        Me.txtSUser.Location = New System.Drawing.Point(113, 26)
        Me.txtSUser.Name = "txtSUser"
        Me.txtSUser.ReadOnly = True
        Me.txtSUser.Size = New System.Drawing.Size(357, 21)
        Me.txtSUser.TabIndex = 1
        '
        'txtEcr
        '
        Me.txtEcr.Location = New System.Drawing.Point(113, 53)
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.ReadOnly = True
        Me.txtEcr.Size = New System.Drawing.Size(357, 21)
        Me.txtEcr.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ՀԴՄ"
        '
        'txtProblem
        '
        Me.txtProblem.Location = New System.Drawing.Point(113, 80)
        Me.txtProblem.Name = "txtProblem"
        Me.txtProblem.ReadOnly = True
        Me.txtProblem.Size = New System.Drawing.Size(357, 21)
        Me.txtProblem.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Խնդիր"
        '
        'txtSDate
        '
        Me.txtSDate.Location = New System.Drawing.Point(113, 107)
        Me.txtSDate.Name = "txtSDate"
        Me.txtSDate.ReadOnly = True
        Me.txtSDate.Size = New System.Drawing.Size(357, 21)
        Me.txtSDate.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ուղ. Ամսաթիվ"
        '
        'txtAUser
        '
        Me.txtAUser.Location = New System.Drawing.Point(113, 134)
        Me.txtAUser.Name = "txtAUser"
        Me.txtAUser.ReadOnly = True
        Me.txtAUser.Size = New System.Drawing.Size(357, 21)
        Me.txtAUser.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Պատասխանող"
        '
        'txtRep
        '
        Me.txtRep.Location = New System.Drawing.Point(113, 161)
        Me.txtRep.Name = "txtRep"
        Me.txtRep.ReadOnly = True
        Me.txtRep.Size = New System.Drawing.Size(357, 21)
        Me.txtRep.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Պատասխան"
        '
        'txtRepDate
        '
        Me.txtRepDate.Location = New System.Drawing.Point(113, 188)
        Me.txtRepDate.Name = "txtRepDate"
        Me.txtRepDate.ReadOnly = True
        Me.txtRepDate.Size = New System.Drawing.Size(357, 21)
        Me.txtRepDate.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Պատ. Ամսաթիվ"
        '
        'RemakeClosedMessageViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(502, 238)
        Me.Controls.Add(Me.txtRepDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtRep)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAUser)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtProblem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEcr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSUser)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RemakeClosedMessageViewer"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Դիտել Փակված Հաղորդագրությունը"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSUser As System.Windows.Forms.TextBox
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProblem As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSDate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAUser As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRep As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRepDate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
