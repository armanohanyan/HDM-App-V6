<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddHVHHWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddHVHHWindow))
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
        Me.txtHVHH = New System.Windows.Forms.TextBox()
        Me.txtContract = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.txtIravAddress = New System.Windows.Forms.TextBox()
        Me.txtAraqAddress = New System.Windows.Forms.TextBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.ckHraj = New DevExpress.XtraEditors.CheckEdit()
        Me.ckNotSupported = New DevExpress.XtraEditors.CheckEdit()
        Me.ckNDS = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.cbTHT = New System.Windows.Forms.ComboBox()
        Me.btnAddContract = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddIravAddress = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddRegion = New DevExpress.XtraEditors.SimpleButton()
        Me.cbRegion = New System.Windows.Forms.ComboBox()
        Me.txtDirector = New System.Windows.Forms.TextBox()
        Me.cbSupporter = New System.Windows.Forms.ComboBox()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.cbTarif = New System.Windows.Forms.ComboBox()
        Me.btnAddTHT = New DevExpress.XtraEditors.SimpleButton()
        Me.ckZroNDS = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ckHraj.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckNotSupported.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckNDS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckZroNDS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(381, 218)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(241, 27)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Ավելացնել"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(75, 27)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "ՀՎՀՀ *"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(33, 52)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Պայմանագիր *"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 81)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(99, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Կազմակերպություն"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(70, 104)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl4.TabIndex = 2
        Me.LabelControl4.Text = "Տնօրեն"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(47, 132)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl5.TabIndex = 2
        Me.LabelControl5.Text = "Իրավ Հասցե"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(45, 159)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl6.TabIndex = 2
        Me.LabelControl6.Text = "Առաք Հասցե"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(86, 192)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl7.TabIndex = 2
        Me.LabelControl7.Text = "ՏՀՏ"
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
        Me.LabelControl9.Location = New System.Drawing.Point(381, 57)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl9.TabIndex = 2
        Me.LabelControl9.Text = "Սպասարկող"
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
        'txtHVHH
        '
        Me.txtHVHH.Location = New System.Drawing.Point(115, 27)
        Me.txtHVHH.MaxLength = 9
        Me.txtHVHH.Name = "txtHVHH"
        Me.txtHVHH.Size = New System.Drawing.Size(185, 21)
        Me.txtHVHH.TabIndex = 0
        '
        'txtContract
        '
        Me.txtContract.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtContract.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtContract.Location = New System.Drawing.Point(115, 52)
        Me.txtContract.Name = "txtContract"
        Me.txtContract.Size = New System.Drawing.Size(185, 21)
        Me.txtContract.TabIndex = 1
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(115, 79)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(185, 21)
        Me.txtCompany.TabIndex = 2
        '
        'txtIravAddress
        '
        Me.txtIravAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtIravAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtIravAddress.Location = New System.Drawing.Point(115, 132)
        Me.txtIravAddress.Name = "txtIravAddress"
        Me.txtIravAddress.Size = New System.Drawing.Size(185, 21)
        Me.txtIravAddress.TabIndex = 4
        '
        'txtAraqAddress
        '
        Me.txtAraqAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtAraqAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtAraqAddress.Location = New System.Drawing.Point(115, 159)
        Me.txtAraqAddress.Name = "txtAraqAddress"
        Me.txtAraqAddress.Size = New System.Drawing.Size(185, 21)
        Me.txtAraqAddress.TabIndex = 5
        '
        'txtTel
        '
        Me.txtTel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTel.Location = New System.Drawing.Point(448, 81)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(155, 21)
        Me.txtTel.TabIndex = 10
        '
        'ckHraj
        '
        Me.ckHraj.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckHraj.Enabled = False
        Me.ckHraj.Location = New System.Drawing.Point(394, 136)
        Me.ckHraj.Name = "ckHraj"
        Me.ckHraj.Properties.Caption = "Լուծարված"
        Me.ckHraj.Size = New System.Drawing.Size(84, 19)
        Me.ckHraj.TabIndex = 12
        '
        'ckNotSupported
        '
        Me.ckNotSupported.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckNotSupported.Enabled = False
        Me.ckNotSupported.Location = New System.Drawing.Point(394, 162)
        Me.ckNotSupported.Name = "ckNotSupported"
        Me.ckNotSupported.Properties.Caption = "Չսպասարկվող"
        Me.ckNotSupported.Size = New System.Drawing.Size(98, 19)
        Me.ckNotSupported.TabIndex = 13
        '
        'ckNDS
        '
        Me.ckNDS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckNDS.EditValue = True
        Me.ckNDS.Enabled = False
        Me.ckNDS.Location = New System.Drawing.Point(534, 136)
        Me.ckNDS.Name = "ckNDS"
        Me.ckNDS.Properties.Caption = "ԱԱՀ-ով Վճարող"
        Me.ckNDS.Size = New System.Drawing.Size(98, 19)
        Me.ckNDS.TabIndex = 14
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Location = New System.Drawing.Point(348, 112)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(94, 13)
        Me.LabelControl11.TabIndex = 2
        Me.LabelControl11.Text = "Մեկնաբանություն"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(448, 109)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(155, 21)
        Me.txtComments.TabIndex = 11
        '
        'cbTHT
        '
        Me.cbTHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTHT.FormattingEnabled = True
        Me.cbTHT.Location = New System.Drawing.Point(115, 188)
        Me.cbTHT.Name = "cbTHT"
        Me.cbTHT.Size = New System.Drawing.Size(185, 21)
        Me.cbTHT.TabIndex = 6
        '
        'btnAddContract
        '
        Me.btnAddContract.Image = CType(resources.GetObject("btnAddContract.Image"), System.Drawing.Image)
        Me.btnAddContract.Location = New System.Drawing.Point(306, 52)
        Me.btnAddContract.Name = "btnAddContract"
        Me.btnAddContract.Size = New System.Drawing.Size(23, 20)
        Me.btnAddContract.TabIndex = 15
        Me.btnAddContract.TabStop = False
        '
        'btnAddIravAddress
        '
        Me.btnAddIravAddress.Image = CType(resources.GetObject("btnAddIravAddress.Image"), System.Drawing.Image)
        Me.btnAddIravAddress.Location = New System.Drawing.Point(306, 132)
        Me.btnAddIravAddress.Name = "btnAddIravAddress"
        Me.btnAddIravAddress.Size = New System.Drawing.Size(23, 20)
        Me.btnAddIravAddress.TabIndex = 15
        Me.btnAddIravAddress.TabStop = False
        '
        'btnAddRegion
        '
        Me.btnAddRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddRegion.Image = CType(resources.GetObject("btnAddRegion.Image"), System.Drawing.Image)
        Me.btnAddRegion.Location = New System.Drawing.Point(609, 28)
        Me.btnAddRegion.Name = "btnAddRegion"
        Me.btnAddRegion.Size = New System.Drawing.Size(23, 20)
        Me.btnAddRegion.TabIndex = 15
        Me.btnAddRegion.TabStop = False
        '
        'cbRegion
        '
        Me.cbRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRegion.FormattingEnabled = True
        Me.cbRegion.Location = New System.Drawing.Point(448, 27)
        Me.cbRegion.Name = "cbRegion"
        Me.cbRegion.Size = New System.Drawing.Size(155, 21)
        Me.cbRegion.TabIndex = 8
        '
        'txtDirector
        '
        Me.txtDirector.Location = New System.Drawing.Point(115, 104)
        Me.txtDirector.Name = "txtDirector"
        Me.txtDirector.Size = New System.Drawing.Size(185, 21)
        Me.txtDirector.TabIndex = 3
        '
        'cbSupporter
        '
        Me.cbSupporter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSupporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSupporter.FormattingEnabled = True
        Me.cbSupporter.Location = New System.Drawing.Point(448, 54)
        Me.cbSupporter.Name = "cbSupporter"
        Me.cbSupporter.Size = New System.Drawing.Size(155, 21)
        Me.cbSupporter.TabIndex = 9
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(75, 218)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl12.TabIndex = 2
        Me.LabelControl12.Text = "Տարիֆ"
        '
        'cbTarif
        '
        Me.cbTarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTarif.FormattingEnabled = True
        Me.cbTarif.Location = New System.Drawing.Point(115, 215)
        Me.cbTarif.Name = "cbTarif"
        Me.cbTarif.Size = New System.Drawing.Size(185, 21)
        Me.cbTarif.TabIndex = 7
        '
        'btnAddTHT
        '
        Me.btnAddTHT.Image = CType(resources.GetObject("btnAddTHT.Image"), System.Drawing.Image)
        Me.btnAddTHT.Location = New System.Drawing.Point(306, 188)
        Me.btnAddTHT.Name = "btnAddTHT"
        Me.btnAddTHT.Size = New System.Drawing.Size(23, 20)
        Me.btnAddTHT.TabIndex = 16
        Me.btnAddTHT.TabStop = False
        '
        'ckZroNDS
        '
        Me.ckZroNDS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckZroNDS.Enabled = False
        Me.ckZroNDS.Location = New System.Drawing.Point(534, 162)
        Me.ckZroNDS.Name = "ckZroNDS"
        Me.ckZroNDS.Properties.Caption = "Զրոյական ԱԱՀ"
        Me.ckZroNDS.Size = New System.Drawing.Size(98, 19)
        Me.ckZroNDS.TabIndex = 18
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl13.Location = New System.Drawing.Point(12, 254)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(262, 13)
        Me.LabelControl13.TabIndex = 19
        Me.LabelControl13.Text = "* -ով նշված տվյալները բազայում չպետք է կրկնվեն"
        '
        'AddHVHHWindow
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 279)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.ckZroNDS)
        Me.Controls.Add(Me.btnAddTHT)
        Me.Controls.Add(Me.cbSupporter)
        Me.Controls.Add(Me.cbRegion)
        Me.Controls.Add(Me.btnAddRegion)
        Me.Controls.Add(Me.btnAddIravAddress)
        Me.Controls.Add(Me.btnAddContract)
        Me.Controls.Add(Me.cbTarif)
        Me.Controls.Add(Me.cbTHT)
        Me.Controls.Add(Me.ckNDS)
        Me.Controls.Add(Me.ckNotSupported)
        Me.Controls.Add(Me.ckHraj)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.txtAraqAddress)
        Me.Controls.Add(Me.txtDirector)
        Me.Controls.Add(Me.txtIravAddress)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.txtContract)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.txtHVHH)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl12)
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
        Me.Name = "AddHVHHWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Նոր Գործընկեր"
        CType(Me.ckHraj.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckNotSupported.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckNDS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckZroNDS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtHVHH As System.Windows.Forms.TextBox
    Friend WithEvents txtContract As System.Windows.Forms.TextBox
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents txtIravAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtAraqAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents ckHraj As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ckNotSupported As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ckNDS As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents cbTHT As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddContract As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddIravAddress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddRegion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents txtDirector As System.Windows.Forms.TextBox
    Friend WithEvents cbSupporter As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbTarif As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddTHT As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ckZroNDS As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
End Class
