<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AktRefuse
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPrintAkt = New System.Windows.Forms.Button()
        Me.btnSelectPrinter = New System.Windows.Forms.Button()
        Me.txtPrinterName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReason)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtPrintAkt)
        Me.GroupBox2.Controls.Add(Me.btnSelectPrinter)
        Me.GroupBox2.Controls.Add(Me.txtPrinterName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(523, 245)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Պրինտեր / Ակտ"
        '
        'txtPrintAkt
        '
        Me.txtPrintAkt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtPrintAkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtPrintAkt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txtPrintAkt.Location = New System.Drawing.Point(360, 191)
        Me.txtPrintAkt.Name = "txtPrintAkt"
        Me.txtPrintAkt.Size = New System.Drawing.Size(151, 29)
        Me.txtPrintAkt.TabIndex = 2
        Me.txtPrintAkt.Text = "Տպել Ակտ"
        Me.txtPrintAkt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.txtPrintAkt.UseVisualStyleBackColor = True
        '
        'btnSelectPrinter
        '
        Me.btnSelectPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSelectPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSelectPrinter.Location = New System.Drawing.Point(360, 24)
        Me.btnSelectPrinter.Name = "btnSelectPrinter"
        Me.btnSelectPrinter.Size = New System.Drawing.Size(157, 29)
        Me.btnSelectPrinter.TabIndex = 0
        Me.btnSelectPrinter.Text = "Փոխել Պրինտերը"
        Me.btnSelectPrinter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSelectPrinter.UseVisualStyleBackColor = True
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Location = New System.Drawing.Point(116, 27)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.ReadOnly = True
        Me.txtPrinterName.Size = New System.Drawing.Size(228, 21)
        Me.txtPrinterName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Պրինտերի Անուն"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Պատճառ"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(116, 72)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(395, 109)
        Me.txtReason.TabIndex = 1
        '
        'AktRefuse
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(523, 245)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AktRefuse"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Մերժման Ակտ"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrintAkt As System.Windows.Forms.Button
    Friend WithEvents btnSelectPrinter As System.Windows.Forms.Button
    Friend WithEvents txtPrinterName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
