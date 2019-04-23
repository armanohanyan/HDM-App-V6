Imports System.Linq
Imports DevExpress.Utils

Public Class UpdateHVHHWindow

    Friend ClientID As Integer = 0

    Dim old_contract As String
    Dim lucvac As Boolean

    Dim oldSupporter As Byte

    Dim dtContract As DataTable
    Dim dtAddress As DataTable

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

    End Sub

#Region "Subs"

    Private Sub loadData()
        Try
            'Get THT
            Dim dt1 As DataTable = iDB.GetTHT()
            With cbTHT
                .DataSource = dt1
                .DisplayMember = "ՏՀՏ"
                .ValueMember = "ՀՀ"
            End With

            'Get Tarif
            Dim dt2 As DataTable = iDB.GetTarif
            With cbTarif
                .DataSource = dt2
                .DisplayMember = "Տարիֆ"
                .ValueMember = "ՀՀ"
            End With

            'Get Region
            Dim dt3 As DataTable = iDB.GetRegion
            With cbRegion
                .DataSource = dt3
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
            End With

            'Get Supporter
            Dim dt4 As DataTable = iDB.GetSupporter
            With cbSupporter
                .DataSource = dt4
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
            End With

            loadItems2()

        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadItems()
        Try
            Dim dt As DataTable = iDB.GetHVHHInfo(ClientID)
            If dt.Rows.Count = 1 Then
                txtHVHH.Text = dt.Rows(0)("ՀՎՀՀ")
                txtContract.Text = dt.Rows(0)("Պայմանագիր")
                txtCompany.Text = dt.Rows(0)("Կազմակերպություն")
                txtDirector.Text = dt.Rows(0)("Տնօրեն")
                txtIravAddress.Text = dt.Rows(0)("ԻրավաբանականՀասցե")
                txtAraqAddress.Text = dt.Rows(0)("ԱռաքմանՀասցե")
                cbTHT.Text = dt.Rows(0)("ՏՀՏ")
                cbTarif.Text = dt.Rows(0)("Տարիֆ")
                cbRegion.Text = dt.Rows(0)("Տարածաշրջան")
                cbSupporter.Text = dt.Rows(0)("Սպասարկող")
                If IsDBNull(dt.Rows(0)("Մեկնաբանություն")) Then txtComments.Text = "" Else txtComments.Text = dt.Rows(0)("Մեկնաբանություն")
                txtTel.Text = dt.Rows(0)("Հեռախոս")
                ckHraj.Checked = dt.Rows(0)("Հրաժարված")
                ckNotSupported.Checked = dt.Rows(0)("Չսպասարկվող")
                ckNDS.Checked = dt.Rows(0)("ԱԱՀ")
                ckZroNDS.Checked = dt.Rows(0)("Զրոյական")
                cbTarif.SelectedValue = dt.Rows(0)("Տարիֆ")
            End If
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadItems2()
        Try
            Dim dt As DataTable = iDB.GetHVHHInfo(ClientID)
            If dt.Rows.Count = 1 Then
                cbTHT.Text = dt.Rows(0)("ՏՀՏ")
                cbTarif.Text = dt.Rows(0)("Տարիֆ")
                cbRegion.Text = dt.Rows(0)("Տարածաշրջան")
                cbSupporter.Text = dt.Rows(0)("Սպասարկող")
                cbTarif.SelectedValue = dt.Rows(0)("Տարիֆ")
            End If
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Add"

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
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

#Region "Event"

    'Load
    Private Sub UpdateHVHHWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call loadData()
        Call loadItems()

        old_contract = txtContract.Text
        lucvac = ckHraj.Checked

        cbTarif.Enabled = False

        If iUser.UserID <> 10 Then
            ckNDS.Enabled = False
            ckZroNDS.Enabled = False
            ckNotSupported.Enabled = False
        Else
            ckNDS.Enabled = True
            ckZroNDS.Enabled = True
            ckNotSupported.Enabled = True
        End If

        If ckHraj.Checked = True Then ckHraj.Enabled = True Else ckHraj.Enabled = False

    End Sub

    'Update Client
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtContract.Text.Trim = "" Then Throw New Exception("Պայմանագիրը գրված չէ")
            If txtCompany.Text.Trim = "" Then Throw New Exception("Կազմակերպության անվանումը գրված չէ")
            If txtDirector.Text.Trim = "" Then Throw New Exception("Տնօրենի անունը գրված չէ")
            If txtIravAddress.Text.Trim = "" Then Throw New Exception("Իրավաբանական հասցեն գրված չէ")
            If txtAraqAddress.Text.Trim = "" Then Throw New Exception("Առաքման հասցեն գրված չէ")
            If txtTel.Text.Trim = "" Then Throw New Exception("Հեռախոսը գրված չէ")
            ''''''''''''''Arman
            If cbSupporter.SelectedValue <> 6 AndAlso lucvac = True AndAlso old_contract = txtContract.Text.Trim Then Throw New Exception("Ընթացիկ պայմանագիրը լուծարված է")

            If lucvac = True AndAlso old_contract <> txtContract.Text.Trim Then ckHraj.Checked = False

            Dim iClient = New With {.ClientID = ClientID, .hvhh = txtHVHH.Text.Trim, .contract = txtContract.Text.Trim, .company = txtCompany.Text.Trim, .director = txtDirector.Text.Trim,
                                    .iravAddress = txtIravAddress.Text.Trim, .araqAddress = txtAraqAddress.Text.Trim, .tht = cbTHT.SelectedValue, .tarif = cbTarif.SelectedValue,
                                    .region = cbRegion.SelectedValue, .supporter = cbSupporter.SelectedValue, .tel = txtTel.Text.Trim, .comment = txtComments.Text.Trim,
                                    .hraj = ckHraj.Checked, .notSupp = ckNotSupported.Checked, .nds = ckNDS.Checked, .ZroNDS = ckZroNDS.Checked}

            'Check for support
            If oldSupporter <> cbSupporter.SelectedValue Then
                iDB.CheckForUpdate(ClientID, oldSupporter)
            End If

            Dim checked As Boolean?
            If oldSupporter = 6 And cbSupporter.SelectedValue <> 6 Then checked = 1
            If oldSupporter <> 6 And cbSupporter.SelectedValue = 6 Then checked = 0


            iDB.UpdateClient(iClient.ClientID, iClient.hvhh, iClient.contract, iClient.company, iClient.director, iClient.iravAddress, iClient.araqAddress, iClient.tht, iClient.tarif, iClient.region, iClient.supporter, iClient.tel, iClient.comment, iClient.hraj, iClient.notSupp, iClient.nds, iClient.ZroNDS, checked)

            Me.Close()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

#End Region

    Private Sub UpdateHVHHWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadDT()

        On Error Resume Next

        If iUser.DB <> 5 Then
            cbSupporter.Enabled = False
        End If
        oldSupporter = cbSupporter.SelectedValue

    End Sub

End Class