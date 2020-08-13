Imports System.Linq
Imports DevExpress.Utils

Public Class AddHVHHWindow

    Dim dtContract As DataTable
    Dim dtAddress As DataTable

    Public Property NewHvhh As String = String.Empty

    Dim rTariff As Short = 0

    Private Sub LoadDT()
        On Error Resume Next
        dtContract = iDB.AutoCompleteContract()
        dtAddress = iDB.AutoCompleteIravAddress()

        txtContract.AutoCompleteCustomSource.Clear()
        txtContract.AutoCompleteCustomSource.AddRange((From row In dtContract.Rows.Cast(Of DataRow)() Select CStr(row("Պայմանագիր"))).ToArray())

        txtIravAddress.AutoCompleteCustomSource.Clear()
        txtIravAddress.AutoCompleteCustomSource.AddRange((From row In dtAddress.Rows.Cast(Of DataRow)() Select CStr(row("Հասցե"))).ToArray())

        txtAraqAddress.AutoCompleteCustomSource.Clear()
        txtAraqAddress.AutoCompleteCustomSource.AddRange((From row In dtAddress.Rows.Cast(Of DataRow)() Select CStr(row("Հասցե"))).ToArray())

        cbSupporter.SelectedValue = 6
    End Sub

    Private Sub clearBoxes()
        ckNDS.Checked = True
        ckNotSupported.Checked = False
        ckHraj.Checked = False
        ckZroNDS.Checked = False
        txtComments.Text = String.Empty
        txtTel.Text = String.Empty
        cbSupporter.SelectedIndex = 0
        cbRegion.SelectedIndex = 0
        cbTarif.SelectedIndex = 0
        cbTHT.SelectedIndex = 0
        txtAraqAddress.Text = String.Empty
        txtIravAddress.Text = String.Empty
        txtDirector.Text = String.Empty
        txtCompany.Text = String.Empty
        txtContract.Text = String.Empty
        txtHVHH.Text = String.Empty
        txtHVHH.Focus()
    End Sub
    Private Sub loadData()
        Try
            'Get THT
            Dim dt1 As DataTable = iDB.GetTHT()
            With cbTHT
                .DataSource = dt1
                .DisplayMember = "ՏՀՏ"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

            'Get Tarif
            Dim dt2 As DataTable = iDB.GetTarif
            With cbTarif
                .DataSource = dt2
                .DisplayMember = "Տարիֆ"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedValue = 1
            End With

            'Get Region
            Dim dt3 As DataTable = iDB.GetRegion
            With cbRegion
                .DataSource = dt3
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

            'Get Supporter
            Dim dt4 As DataTable = iDB.GetSupporter
            With cbSupporter
                .DataSource = dt4
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub btnAddContract_Click(sender As Object, e As EventArgs) Handles btnAddContract.Click
        Dim f As New ContractAddWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub btnAddIravAddress_Click(sender As Object, e As EventArgs) Handles btnAddIravAddress.Click
        Dim f As New AddressAddWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub btnAddTHT_Click(sender As Object, e As EventArgs) Handles btnAddTHT.Click
        Dim f As New ThtAddWin
        With f
            .ShowDialog()
            .Dispose()
        End With
        Try
            Dim dt1 As DataTable = iDB.GetTHT()
            With cbTHT
                .DataSource = dt1
                .DisplayMember = "ՏՀՏ"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnAddRegion_Click(sender As Object, e As EventArgs) Handles btnAddRegion.Click
        Dim f As New RegionAddWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
        Try
            Dim dt3 As DataTable = iDB.GetRegion
            With cbRegion
                .DataSource = dt3
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub AddHVHHWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadData()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtHVHH.Text.Trim = "" Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")
            If txtHVHH.Text.Trim.Length < 8 OrElse txtHVHH.Text.Trim.Length > 9 Then
                Throw New Exception("ՀՎՀՀ-ն պետք է ունենա 8 սիմվոլ երկարություն")
            ElseIf txtHVHH.Text.Trim.Length = 9 Then
                If txtHVHH.Text.Trim.Substring(8, 1) <> "S" Then Throw New Exception("Վերջին սիմվոլը սխալ է գրված")
            End If

            If txtContract.Text.Trim = "" Then Throw New Exception("Պայմանագիրը գրված չէ")
            If txtCompany.Text.Trim = "" Then Throw New Exception("Կազմակերպության անվանումը գրված չէ")
            If txtDirector.Text.Trim = "" Then Throw New Exception("Տնօրենի անունը գրված չէ")
            If txtIravAddress.Text.Trim = "" Then Throw New Exception("Իրավաբանական հասցեն գրված չէ")
            If txtAraqAddress.Text.Trim = "" Then Throw New Exception("Առաքման հասցեն գրված չէ")
            If txtTel.Text.Trim = "" Then Throw New Exception("Հեռախոսը գրված չէ")

            'S-ով գործընկեր ստեղծելիս ստուգել առանց S-ի գորընկերն ունի ՀԴՄ
            If iDB.IsInsertAllowedClientWithS(txtHVHH.Text.Trim) = 0 Then
                Throw New Exception("S-ով գորընկեր ստեղծելու անհրաժեշտությունն չկա, խնդրում եմ օգտագործել նշված ՀՎՀՀ-ի առանց S-ի տարբերակը")
            End If

            Dim iClient = New With {.hvhh = txtHVHH.Text.Trim, .contract = txtContract.Text.Trim, .company = txtCompany.Text.Trim, .director = txtDirector.Text.Trim,
                                    .iravAddress = txtIravAddress.Text.Trim, .araqAddress = txtAraqAddress.Text.Trim, .tht = cbTHT.SelectedValue, .tarif = cbTarif.SelectedValue,
                                    .region = cbRegion.SelectedValue, .supporter = cbSupporter.SelectedValue, .tel = txtTel.Text.Trim, .comment = txtComments.Text.Trim,
                                    .hraj = ckHraj.Checked, .notSupp = ckNotSupported.Checked, .nds = ckNDS.Checked, .ZroNDS = ckZroNDS.Checked}

            iDB.InsertClient(iClient.hvhh, iClient.contract, iClient.company, iClient.director, iClient.iravAddress, iClient.araqAddress, iClient.tht, iClient.tarif, iClient.region, iClient.supporter, iClient.tel, iClient.comment, iClient.hraj, iClient.notSupp, iClient.nds, iClient.ZroNDS)

            NewHvhh = txtHVHH.Text.Trim

            If rTariff < 1 Then
                iDB.AddMissedTarif(txtHVHH.Text.Trim)
            End If

            rTariff = 0

            Call clearBoxes()
            Call LoadDT()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtHVHH_LostFocus(sender As Object, e As EventArgs) Handles txtHVHH.LostFocus
        Try
            If Not String.IsNullOrEmpty(txtHVHH.Text) Then
                If iDB.IsClientHvhhExists(txtHVHH.Text.Trim) = True Then
                    Throw New Exception("Այդպիսի ՀՎՀՀ-ով կազմակերպություն արդեն գրանցված է")
                Else

                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub AddHVHHWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        cbTarif.Enabled = False

        Call LoadDT()

        If iUser.DB <> 5 Then
            cbSupporter.SelectedValue = iUser.DB
            cbSupporter.Enabled = False
        End If

    End Sub

    Private Sub txtHVHH_TextChanged(sender As Object, e As EventArgs) Handles txtHVHH.TextChanged
        If txtHVHH.Text.Trim.Length = 8 OrElse txtHVHH.Text.Trim.Length = 9 Then
            rTariff = iDB.GetPoakTariff(txtHVHH.Text.Trim)
            If rTariff > 0 Then
                cbTarif.SelectedValue = rTariff
            Else
                cbTarif.Enabled = True
            End If
        Else
            cbTarif.Enabled = False
        End If
    End Sub

End Class