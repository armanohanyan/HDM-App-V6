<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddHDMWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddHDMWindow))
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEcr = New System.Windows.Forms.TextBox()
        Me.txtHvhh = New System.Windows.Forms.TextBox()
        Me.txtMgh = New System.Windows.Forms.TextBox()
        Me.dContractDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtGorcAddress = New System.Windows.Forms.TextBox()
        Me.txtGprs = New System.Windows.Forms.TextBox()
        Me.txtObjType = New System.Windows.Forms.TextBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.ckNds = New DevExpress.XtraEditors.CheckEdit()
        Me.ckPosTerm = New DevExpress.XtraEditors.CheckEdit()
        Me.ckInvoice = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.btnNewClient = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.cbRegion = New System.Windows.Forms.ComboBox()
        Me.cbTesuch = New System.Windows.Forms.ComboBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.dContractDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dContractDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckNds.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckPosTerm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(362, 240)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(241, 27)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Ավելացնել"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(107, 27)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "ՀԴՄ *"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(104, 52)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "ՀՎՀՀ"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(108, 79)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "ՄԳՀ *"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 105)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(117, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Պայմանագրի Ամսաթիվ"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(10, 132)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(119, 13)
        Me.LabelControl5.TabIndex = 2
        Me.LabelControl5.Text = "Գործունեության Հասցե"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(103, 159)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl6.TabIndex = 2
        Me.LabelControl6.Text = "GPRS *"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(63, 189)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl7.TabIndex = 2
        Me.LabelControl7.Text = "Կարգավիճակ"
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Location = New System.Drawing.Point(368, 30)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl8.TabIndex = 2
        Me.LabelControl8.Text = "Տարածաշրջան"
        '
        'LabelControl9
        '
        Me.LabelControl9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl9.Location = New System.Drawing.Point(362, 60)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl9.TabIndex = 2
        Me.LabelControl9.Text = "Օբյեկտի Տեսակ"
        '
        'LabelControl10
        '
        Me.LabelControl10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl10.Location = New System.Drawing.Point(394, 84)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl10.TabIndex = 2
        Me.LabelControl10.Text = "Հեռախոս"
        '
        'txtEcr
        '
        Me.txtEcr.Location = New System.Drawing.Point(145, 27)
        Me.txtEcr.MaxLength = 12
        Me.txtEcr.Name = "txtEcr"
        Me.txtEcr.Size = New System.Drawing.Size(155, 21)
        Me.txtEcr.TabIndex = 0
        '
        'txtHvhh
        '
        Me.txtHvhh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtHvhh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtHvhh.Location = New System.Drawing.Point(145, 52)
        Me.txtHvhh.MaxLength = 9
        Me.txtHvhh.Name = "txtHvhh"
        Me.txtHvhh.Size = New System.Drawing.Size(155, 21)
        Me.txtHvhh.TabIndex = 1
        '
        'txtMgh
        '
        Me.txtMgh.Location = New System.Drawing.Point(145, 79)
        Me.txtMgh.MaxLength = 8
        Me.txtMgh.Name = "txtMgh"
        Me.txtMgh.Size = New System.Drawing.Size(155, 21)
        Me.txtMgh.TabIndex = 2
        '
        'dContractDate
        '
        Me.dContractDate.EditValue = Nothing
        Me.dContractDate.Location = New System.Drawing.Point(145, 106)
        Me.dContractDate.Name = "dContractDate"
        Me.dContractDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dContractDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dContractDate.Size = New System.Drawing.Size(155, 20)
        Me.dContractDate.TabIndex = 3
        '
        'txtGorcAddress
        '
        Me.txtGorcAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtGorcAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtGorcAddress.Location = New System.Drawing.Point(145, 132)
        Me.txtGorcAddress.Name = "txtGorcAddress"
        Me.txtGorcAddress.Size = New System.Drawing.Size(155, 21)
        Me.txtGorcAddress.TabIndex = 4
        '
        'txtGprs
        '
        Me.txtGprs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtGprs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtGprs.Location = New System.Drawing.Point(145, 159)
        Me.txtGprs.Name = "txtGprs"
        Me.txtGprs.Size = New System.Drawing.Size(155, 21)
        Me.txtGprs.TabIndex = 5
        '
        'txtObjType
        '
        Me.txtObjType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObjType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtObjType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtObjType.Location = New System.Drawing.Point(448, 54)
        Me.txtObjType.Name = "txtObjType"
        Me.txtObjType.Size = New System.Drawing.Size(155, 21)
        Me.txtObjType.TabIndex = 8
        '
        'txtTel
        '
        Me.txtTel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTel.Location = New System.Drawing.Point(448, 81)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(155, 21)
        Me.txtTel.TabIndex = 9
        '
        'ckNds
        '
        Me.ckNds.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckNds.EditValue = True
        Me.ckNds.Enabled = False
        Me.ckNds.Location = New System.Drawing.Point(448, 136)
        Me.ckNds.Name = "ckNds"
        Me.ckNds.Properties.Caption = "ԱԱՀ Գանձվող"
        Me.ckNds.Size = New System.Drawing.Size(113, 19)
        Me.ckNds.TabIndex = 11
        '
        'ckPosTerm
        '
        Me.ckPosTerm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckPosTerm.Enabled = False
        Me.ckPosTerm.Location = New System.Drawing.Point(448, 162)
        Me.ckPosTerm.Name = "ckPosTerm"
        Me.ckPosTerm.Properties.Caption = "PosTerminal"
        Me.ckPosTerm.Size = New System.Drawing.Size(98, 19)
        Me.ckPosTerm.TabIndex = 12
        Me.ckPosTerm.Visible = False
        '
        'ckInvoice
        '
        Me.ckInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckInvoice.Enabled = False
        Me.ckInvoice.Location = New System.Drawing.Point(448, 189)
        Me.ckInvoice.Name = "ckInvoice"
        Me.ckInvoice.Properties.Caption = "Tax Free"
        Me.ckInvoice.Size = New System.Drawing.Size(126, 19)
        Me.ckInvoice.TabIndex = 13
        Me.ckInvoice.Visible = False
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Location = New System.Drawing.Point(408, 112)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl11.TabIndex = 2
        Me.LabelControl11.Text = "Տեսուչ"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(145, 188)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(155, 21)
        Me.cbStatus.TabIndex = 6
        '
        'btnNewClient
        '
        Me.btnNewClient.Image = CType(resources.GetObject("btnNewClient.Image"), System.Drawing.Image)
        Me.btnNewClient.Location = New System.Drawing.Point(306, 52)
        Me.btnNewClient.Name = "btnNewClient"
        Me.btnNewClient.Size = New System.Drawing.Size(23, 20)
        Me.btnNewClient.TabIndex = 15
        Me.btnNewClient.TabStop = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(306, 132)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(23, 20)
        Me.SimpleButton2.TabIndex = 15
        Me.SimpleButton2.TabStop = False
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton4.Image = CType(resources.GetObject("SimpleButton4.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(609, 28)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(23, 20)
        Me.SimpleButton4.TabIndex = 15
        Me.SimpleButton4.TabStop = False
        '
        'cbRegion
        '
        Me.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegion.FormattingEnabled = True
        Me.cbRegion.Location = New System.Drawing.Point(448, 27)
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Size = New System.Drawing.Size(155, 21)
        Me.cbRegion.TabIndex = 7
        '
        'cbTesuch
        '
        Me.cbTesuch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTesuch.Enabled = False
        Me.cbTesuch.FormattingEnabled = True
        Me.cbTesuch.Location = New System.Drawing.Point(448, 108)
        Me.cbTesuch.Name = "cbTesuch"
        Me.cbTesuch.Size = New System.Drawing.Size(155, 21)
        Me.cbTesuch.TabIndex = 10
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Enabled = False
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(609, 109)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(23, 20)
        Me.SimpleButton1.TabIndex = 16
        Me.SimpleButton1.TabStop = False
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl12.Location = New System.Drawing.Point(12, 254)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(262, 13)
        Me.LabelControl12.TabIndex = 18
        Me.LabelControl12.Text = "* -ով նշված տվյալները բազայում չպետք է կրկնվեն"
        '
        'AddHDMWindow
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 279)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.cbTesuch)
        Me.Controls.Add(Me.cbRegion)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.btnNewClient)
        Me.Controls.Add(Me.cbStatus)
        Me.Controls.Add(Me.ckInvoice)
        Me.Controls.Add(Me.ckPosTerm)
        Me.Controls.Add(Me.ckNds)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.txtObjType)
        Me.Controls.Add(Me.txtGprs)
        Me.Controls.Add(Me.dContractDate)
        Me.Controls.Add(Me.txtGorcAddress)
        Me.Controls.Add(Me.txtMgh)
        Me.Controls.Add(Me.txtHvhh)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.txtEcr)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddHDMWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Նոր ՀԴՄ"
        CType(Me.dContractDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dContractDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckNds.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckPosTerm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEcr As System.Windows.Forms.TextBox
    Friend WithEvents txtHvhh As System.Windows.Forms.TextBox
    Friend WithEvents txtMgh As System.Windows.Forms.TextBox
    Friend WithEvents dContractDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtGorcAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtGprs As System.Windows.Forms.TextBox
    Friend WithEvents txtObjType As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents ckNds As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ckPosTerm As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ckInvoice As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnNewClient As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents cbTesuch As System.Windows.Forms.ComboBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
End Class
