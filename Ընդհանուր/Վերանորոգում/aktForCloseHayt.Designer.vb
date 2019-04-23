<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class aktForCloseHayt
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDamage = New System.Windows.Forms.TextBox()
        Me.cDamaged = New DevExpress.XtraEditors.CheckEdit()
        Me.NoBattary = New DevExpress.XtraEditors.CheckEdit()
        Me.NoStick = New DevExpress.XtraEditors.CheckEdit()
        Me.NoCharger = New DevExpress.XtraEditors.CheckEdit()
        Me.NoCase = New DevExpress.XtraEditors.CheckEdit()
        Me.OnlyBattary = New DevExpress.XtraEditors.CheckEdit()
        Me.btnPrintAkt = New System.Windows.Forms.Button()
        Me.btnChangePrinter = New System.Windows.Forms.Button()
        Me.txtPrinterName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cDamaged.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoBattary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoStick.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoCharger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoCase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnlyBattary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(551, 381)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 275)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDamage)
        Me.GroupBox2.Controls.Add(Me.cDamaged)
        Me.GroupBox2.Controls.Add(Me.NoBattary)
        Me.GroupBox2.Controls.Add(Me.NoStick)
        Me.GroupBox2.Controls.Add(Me.NoCharger)
        Me.GroupBox2.Controls.Add(Me.NoCase)
        Me.GroupBox2.Controls.Add(Me.OnlyBattary)
        Me.GroupBox2.Controls.Add(Me.btnPrintAkt)
        Me.GroupBox2.Controls.Add(Me.btnChangePrinter)
        Me.GroupBox2.Controls.Add(Me.txtPrinterName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(545, 275)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Պրինտեր / Ակտ"
        '
        'txtDamage
        '
        Me.txtDamage.Location = New System.Drawing.Point(17, 157)
        Me.txtDamage.Multiline = True
        Me.txtDamage.Name = "txtDamage"
        Me.txtDamage.ReadOnly = True
        Me.txtDamage.Size = New System.Drawing.Size(519, 41)
        Me.txtDamage.TabIndex = 12
        Me.txtDamage.TabStop = False
        '
        'cDamaged
        '
        Me.cDamaged.Enabled = False
        Me.cDamaged.Location = New System.Drawing.Point(17, 123)
        Me.cDamaged.Name = "cDamaged"
        Me.cDamaged.Properties.Caption = "Արտաքին Վնասվածքով"
        Me.cDamaged.Size = New System.Drawing.Size(152, 19)
        Me.cDamaged.TabIndex = 11
        Me.cDamaged.TabStop = False
        '
        'NoBattary
        '
        Me.NoBattary.Location = New System.Drawing.Point(395, 94)
        Me.NoBattary.Name = "NoBattary"
        Me.NoBattary.Properties.Caption = "Առանց Մարտկոցի"
        Me.NoBattary.Size = New System.Drawing.Size(116, 19)
        Me.NoBattary.TabIndex = 10
        Me.NoBattary.TabStop = False
        '
        'NoStick
        '
        Me.NoStick.Location = New System.Drawing.Point(251, 94)
        Me.NoStick.Name = "NoStick"
        Me.NoStick.Properties.Caption = "Առանց Մատիտի"
        Me.NoStick.Size = New System.Drawing.Size(101, 19)
        Me.NoStick.TabIndex = 9
        Me.NoStick.TabStop = False
        '
        'NoCharger
        '
        Me.NoCharger.Location = New System.Drawing.Point(395, 69)
        Me.NoCharger.Name = "NoCharger"
        Me.NoCharger.Properties.Caption = "Առանց Լիցքավորիչի"
        Me.NoCharger.Size = New System.Drawing.Size(130, 19)
        Me.NoCharger.TabIndex = 8
        Me.NoCharger.TabStop = False
        '
        'NoCase
        '
        Me.NoCase.Location = New System.Drawing.Point(250, 69)
        Me.NoCase.Name = "NoCase"
        Me.NoCase.Properties.Caption = "Առանց Տուփի"
        Me.NoCase.Size = New System.Drawing.Size(102, 19)
        Me.NoCase.TabIndex = 7
        Me.NoCase.TabStop = False
        '
        'OnlyBattary
        '
        Me.OnlyBattary.Enabled = False
        Me.OnlyBattary.Location = New System.Drawing.Point(17, 60)
        Me.OnlyBattary.Name = "OnlyBattary"
        Me.OnlyBattary.Properties.Caption = "Լիցքավորիչ"
        Me.OnlyBattary.Size = New System.Drawing.Size(88, 19)
        Me.OnlyBattary.TabIndex = 6
        Me.OnlyBattary.TabStop = False
        '
        'btnPrintAkt
        '
        Me.btnPrintAkt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPrintAkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintAkt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrintAkt.Location = New System.Drawing.Point(389, 225)
        Me.btnPrintAkt.Name = "btnPrintAkt"
        Me.btnPrintAkt.Size = New System.Drawing.Size(151, 29)
        Me.btnPrintAkt.TabIndex = 5
        Me.btnPrintAkt.Text = "Տպել Ակտ"
        Me.btnPrintAkt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintAkt.UseVisualStyleBackColor = True
        '
        'btnChangePrinter
        '
        Me.btnChangePrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnChangePrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangePrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnChangePrinter.Location = New System.Drawing.Point(17, 225)
        Me.btnChangePrinter.Name = "btnChangePrinter"
        Me.btnChangePrinter.Size = New System.Drawing.Size(305, 29)
        Me.btnChangePrinter.TabIndex = 4
        Me.btnChangePrinter.Text = "Փոխել Պրինտերը"
        Me.btnChangePrinter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnChangePrinter.UseVisualStyleBackColor = True
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Location = New System.Drawing.Point(116, 27)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.ReadOnly = True
        Me.txtPrinterName.Size = New System.Drawing.Size(420, 21)
        Me.txtPrinterName.TabIndex = 4
        Me.txtPrinterName.TabStop = False
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 284)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 94)
        Me.Panel2.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCheck)
        Me.GroupBox3.Controls.Add(Me.txtCode)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(545, 94)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Կոդի Ստուգում"
        '
        'btnCheck
        '
        Me.btnCheck.Enabled = False
        Me.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnCheck.Location = New System.Drawing.Point(385, 42)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(151, 29)
        Me.btnCheck.TabIndex = 7
        Me.btnCheck.Text = "Ստուգել"
        Me.btnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(163, 48)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(202, 21)
        Me.txtCode.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ակտի Գեներացման Կոդ"
        '
        'aktForCloseHayt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(551, 381)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "aktForCloseHayt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Փակման Հայտի Տպում"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cDamaged.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoBattary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoStick.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoCharger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoCase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnlyBattary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintAkt As System.Windows.Forms.Button
    Friend WithEvents btnChangePrinter As System.Windows.Forms.Button
    Friend WithEvents txtPrinterName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents OnlyBattary As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents NoBattary As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents NoStick As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents NoCharger As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents NoCase As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cDamaged As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtDamage As System.Windows.Forms.TextBox
End Class
