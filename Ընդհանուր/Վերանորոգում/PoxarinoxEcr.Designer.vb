<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PoxarinoxEcr
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPrintAkt = New System.Windows.Forms.Button()
        Me.btnSelectPrinter = New System.Windows.Forms.Button()
        Me.txtPrinterName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.cbEcrList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.NoBattary = New DevExpress.XtraEditors.CheckEdit()
        Me.NoStick = New DevExpress.XtraEditors.CheckEdit()
        Me.NoCharger = New DevExpress.XtraEditors.CheckEdit()
        Me.NoCase = New DevExpress.XtraEditors.CheckEdit()
        Me.OutDamaged = New DevExpress.XtraEditors.CheckEdit()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NoBattary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoStick.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoCharger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoCase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OutDamaged.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(541, 463)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCheck)
        Me.GroupBox3.Controls.Add(Me.txtCode)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 326)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(535, 134)
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
        Me.btnCheck.Size = New System.Drawing.Size(143, 29)
        Me.btnCheck.TabIndex = 24
        Me.btnCheck.Text = "Ստուգել"
        Me.btnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(163, 48)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(202, 21)
        Me.txtCode.TabIndex = 4
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPrintAkt)
        Me.GroupBox2.Controls.Add(Me.btnSelectPrinter)
        Me.GroupBox2.Controls.Add(Me.txtPrinterName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(535, 132)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Պրինտեր / Ակտ"
        '
        'btnPrintAkt
        '
        Me.btnPrintAkt.Enabled = False
        Me.btnPrintAkt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPrintAkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintAkt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnPrintAkt.Location = New System.Drawing.Point(385, 66)
        Me.btnPrintAkt.Name = "btnPrintAkt"
        Me.btnPrintAkt.Size = New System.Drawing.Size(143, 29)
        Me.btnPrintAkt.TabIndex = 25
        Me.btnPrintAkt.Text = "Տպել Ակտ"
        Me.btnPrintAkt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPrintAkt.UseVisualStyleBackColor = True
        '
        'btnSelectPrinter
        '
        Me.btnSelectPrinter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSelectPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSelectPrinter.Location = New System.Drawing.Point(13, 66)
        Me.btnSelectPrinter.Name = "btnSelectPrinter"
        Me.btnSelectPrinter.Size = New System.Drawing.Size(305, 29)
        Me.btnSelectPrinter.TabIndex = 24
        Me.btnSelectPrinter.Text = "Փոխել Պրինտերը"
        Me.btnSelectPrinter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSelectPrinter.UseVisualStyleBackColor = True
        '
        'txtPrinterName
        '
        Me.txtPrinterName.Location = New System.Drawing.Point(116, 27)
        Me.txtPrinterName.Name = "txtPrinterName"
        Me.txtPrinterName.ReadOnly = True
        Me.txtPrinterName.Size = New System.Drawing.Size(412, 21)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtComment)
        Me.GroupBox1.Controls.Add(Me.NoBattary)
        Me.GroupBox1.Controls.Add(Me.NoStick)
        Me.GroupBox1.Controls.Add(Me.NoCharger)
        Me.GroupBox1.Controls.Add(Me.NoCase)
        Me.GroupBox1.Controls.Add(Me.OutDamaged)
        Me.GroupBox1.Controls.Add(Me.btnSelect)
        Me.GroupBox1.Controls.Add(Me.cbEcrList)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(535, 179)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ՀԴՄ-ի Տվյալները"
        '
        'btnSelect
        '
        Me.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btnSelect.Location = New System.Drawing.Point(378, 36)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(151, 29)
        Me.btnSelect.TabIndex = 24
        Me.btnSelect.Text = "Ընտրել"
        Me.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'cbEcrList
        '
        Me.cbEcrList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbEcrList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEcrList.FormattingEnabled = True
        Me.cbEcrList.Location = New System.Drawing.Point(13, 36)
        Me.cbEcrList.Name = "cbEcrList"
        Me.cbEcrList.Size = New System.Drawing.Size(208, 21)
        Me.cbEcrList.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Առկա ՀԴՄ-ներ"
        '
        'NoBattary
        '
        Me.NoBattary.Location = New System.Drawing.Point(13, 138)
        Me.NoBattary.Name = "NoBattary"
        Me.NoBattary.Properties.Caption = "Առանց Մարտկոցի"
        Me.NoBattary.Size = New System.Drawing.Size(143, 19)
        Me.NoBattary.TabIndex = 29
        '
        'NoStick
        '
        Me.NoStick.Location = New System.Drawing.Point(13, 113)
        Me.NoStick.Name = "NoStick"
        Me.NoStick.Properties.Caption = "Առանց Մատիտի"
        Me.NoStick.Size = New System.Drawing.Size(143, 19)
        Me.NoStick.TabIndex = 28
        '
        'NoCharger
        '
        Me.NoCharger.Location = New System.Drawing.Point(13, 88)
        Me.NoCharger.Name = "NoCharger"
        Me.NoCharger.Properties.Caption = "Առանց Լիցքավորիչի"
        Me.NoCharger.Size = New System.Drawing.Size(143, 19)
        Me.NoCharger.TabIndex = 27
        '
        'NoCase
        '
        Me.NoCase.Location = New System.Drawing.Point(13, 63)
        Me.NoCase.Name = "NoCase"
        Me.NoCase.Properties.Caption = "Առանց Տուփի"
        Me.NoCase.Size = New System.Drawing.Size(143, 19)
        Me.NoCase.TabIndex = 26
        '
        'OutDamaged
        '
        Me.OutDamaged.Location = New System.Drawing.Point(180, 88)
        Me.OutDamaged.Name = "OutDamaged"
        Me.OutDamaged.Properties.Caption = "Արտաքին Վնասվածքով"
        Me.OutDamaged.Size = New System.Drawing.Size(157, 19)
        Me.OutDamaged.TabIndex = 25
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(180, 116)
        Me.txtComment.MaxLength = 25
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ReadOnly = True
        Me.txtComment.Size = New System.Drawing.Size(346, 57)
        Me.txtComment.TabIndex = 30
        '
        'PoxarinoxEcr
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(541, 463)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PoxarinoxEcr"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Տրամադրել Փոխարինող ՀԴՄ"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NoBattary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoStick.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoCharger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoCase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OutDamaged.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbEcrList As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrintAkt As System.Windows.Forms.Button
    Friend WithEvents btnSelectPrinter As System.Windows.Forms.Button
    Friend WithEvents txtPrinterName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents NoBattary As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents NoStick As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents NoCharger As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents NoCase As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents OutDamaged As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
End Class
