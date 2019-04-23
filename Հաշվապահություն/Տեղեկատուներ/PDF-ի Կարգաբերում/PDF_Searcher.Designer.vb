<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDF_Searcher
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
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CKBXRegion = New System.Windows.Forms.CheckBox()
        Me.CRegion = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RToch = New System.Windows.Forms.RadioButton()
        Me.RMeryK = New System.Windows.Forms.RadioButton()
        Me.RTama = New System.Windows.Forms.RadioButton()
        Me.RShtrikh = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(643, 499)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtDetails)
        Me.Panel1.Controls.Add(Me.txtInfo)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnExecute)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 493)
        Me.Panel1.TabIndex = 0
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(9, 332)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.ReadOnly = True
        Me.txtDetails.Size = New System.Drawing.Size(220, 152)
        Me.txtDetails.TabIndex = 5
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(9, 306)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(220, 21)
        Me.txtInfo.TabIndex = 4
        Me.txtInfo.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(136, 252)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Չեղարկել"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(9, 252)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(99, 32)
        Me.btnExecute.TabIndex = 2
        Me.btnExecute.Text = "Կատարել"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CKBXRegion)
        Me.GroupBox2.Controls.Add(Me.CRegion)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 93)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Տարածաշրջան"
        '
        'CKBXRegion
        '
        Me.CKBXRegion.AutoSize = True
        Me.CKBXRegion.Checked = True
        Me.CKBXRegion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CKBXRegion.Location = New System.Drawing.Point(7, 70)
        Me.CKBXRegion.Name = "CKBXRegion"
        Me.CKBXRegion.Size = New System.Drawing.Size(157, 17)
        Me.CKBXRegion.TabIndex = 1
        Me.CKBXRegion.Text = "Բոլոր Տարածաշրջանները"
        Me.CKBXRegion.UseVisualStyleBackColor = True
        '
        'CRegion
        '
        Me.CRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CRegion.FormattingEnabled = True
        Me.CRegion.Location = New System.Drawing.Point(7, 31)
        Me.CRegion.Name = "CRegion"
        Me.CRegion.Size = New System.Drawing.Size(213, 21)
        Me.CRegion.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RToch)
        Me.GroupBox1.Controls.Add(Me.RMeryK)
        Me.GroupBox1.Controls.Add(Me.RTama)
        Me.GroupBox1.Controls.Add(Me.RShtrikh)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 121)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Սպասարկող"
        '
        'RToch
        '
        Me.RToch.AutoSize = True
        Me.RToch.Location = New System.Drawing.Point(7, 90)
        Me.RToch.Name = "RToch"
        Me.RToch.Size = New System.Drawing.Size(88, 17)
        Me.RToch.TabIndex = 3
        Me.RToch.TabStop = True
        Me.RToch.Text = "Տոչ Մաստեր"
        Me.RToch.UseVisualStyleBackColor = True
        '
        'RMeryK
        '
        Me.RMeryK.AutoSize = True
        Me.RMeryK.Location = New System.Drawing.Point(7, 67)
        Me.RMeryK.Name = "RMeryK"
        Me.RMeryK.Size = New System.Drawing.Size(87, 17)
        Me.RMeryK.TabIndex = 2
        Me.RMeryK.TabStop = True
        Me.RMeryK.Text = "Մերի Քրիստ"
        Me.RMeryK.UseVisualStyleBackColor = True
        '
        'RTama
        '
        Me.RTama.AutoSize = True
        Me.RTama.Location = New System.Drawing.Point(7, 43)
        Me.RTama.Name = "RTama"
        Me.RTama.Size = New System.Drawing.Size(106, 17)
        Me.RTama.TabIndex = 1
        Me.RTama.Text = "Տամա Էլեկտրոն"
        Me.RTama.UseVisualStyleBackColor = True
        '
        'RShtrikh
        '
        Me.RShtrikh.AutoSize = True
        Me.RShtrikh.Checked = True
        Me.RShtrikh.Location = New System.Drawing.Point(7, 20)
        Me.RShtrikh.Name = "RShtrikh"
        Me.RShtrikh.Size = New System.Drawing.Size(87, 17)
        Me.RShtrikh.TabIndex = 0
        Me.RShtrikh.TabStop = True
        Me.RShtrikh.Text = "ՀԴՄ Շտրիխ"
        Me.RShtrikh.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(253, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(387, 493)
        Me.DataGridView1.TabIndex = 1
        Me.DataGridView1.TabStop = False
        '
        'PDF_Searcher
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(643, 499)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(659, 338)
        Me.Name = "PDF_Searcher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ինվոյսների Տպում"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RToch As System.Windows.Forms.RadioButton
    Friend WithEvents RMeryK As System.Windows.Forms.RadioButton
    Friend WithEvents RTama As System.Windows.Forms.RadioButton
    Friend WithEvents RShtrikh As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CRegion As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents CKBXRegion As System.Windows.Forms.CheckBox
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant

End Class
