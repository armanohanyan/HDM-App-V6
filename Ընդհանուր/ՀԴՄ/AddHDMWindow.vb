Imports DevExpress.Utils

Public Class AddHDMWindow

    Dim dtRegoin As DataTable

    Dim dtObject As DataTable
    Dim dtAddress As DataTable
    Dim dtGPRS As DataTable
    Dim dtHvhh As DataTable

    Public Property NewEcr As String = String.Empty

    Private Sub LoadDT()
        On Error Resume Next

        dtObject = iDB.AutoCompleteObjectType()
        dtAddress = iDB.AutoCompleteIravAddress()
        dtGPRS = iDB.AutoCompleteGPRS()
        dtHvhh = iDB.AutoCompleteHvhh()

        txtObjType.AutoCompleteCustomSource.Clear()
        txtObjType.AutoCompleteCustomSource.AddRange((From row In dtObject.Rows.Cast(Of DataRow)() Select CStr(row("ObjectName"))).ToArray())

        txtGorcAddress.AutoCompleteCustomSource.Clear()
        txtGorcAddress.AutoCompleteCustomSource.AddRange((From row In dtAddress.Rows.Cast(Of DataRow)() Select CStr(row("Հասցե"))).ToArray())

        txtGprs.AutoCompleteCustomSource.Clear()
        txtGprs.AutoCompleteCustomSource.AddRange((From row In dtGPRS.Rows.Cast(Of DataRow)() Select CStr(row("gprs"))).ToArray())

        txtHvhh.AutoCompleteCustomSource.Clear()
        txtHvhh.AutoCompleteCustomSource.AddRange((From row In dtHvhh.Rows.Cast(Of DataRow)() Select CStr(row("ՀՎՀՀ"))).ToArray())

    End Sub
    Private Sub loadDefValues()
        Try
            Dim dt1 As DataTable = iDB.GetStatus
            With cbStatus
                .DataSource = dt1
                .DisplayMember = "Կարգավիճակ"
                .ValueMember = "statusID"
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

            Dim dt3 As DataTable = iDB.GetWorkingTesuchList
            With cbTesuch
                .DataSource = dt3
                .DisplayMember = "Տեսուչ"
                .ValueMember = "ՀՀ"
            End With

            dtRegoin = iDB.GetRegion2
            With cbRegion
                .DataSource = dtRegoin
                .DisplayMember = "Տարածաշրջան"
                .ValueMember = "ՀՀ"
            End With

            Dim j As Integer = cbRegion.SelectedValue
            For i As Integer = 0 To dtRegoin.Rows.Count - 1
                If dtRegoin.Rows(i)("ՀՀ") = j Then
                    If dtRegoin.Rows(i)("Տեսուչ") <> 0 Then cbTesuch.SelectedValue = dtRegoin.Rows(i)("Տեսուչ")
                End If
            Next

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ClearData()
        ckInvoice.Checked = False
        ckPosTerm.Checked = False
        ckNds.Checked = True
        txtTel.Text = String.Empty
        txtObjType.Text = String.Empty
        txtGprs.Text = String.Empty
        txtGorcAddress.Text = String.Empty
        txtMgh.Text = String.Empty
        txtHvhh.Text = String.Empty
        txtEcr.Text = String.Empty
        txtEcr.Focus()
    End Sub
    Private Sub AddHDMWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With dContractDate
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With

        Call loadDefValues()
    End Sub
    Private Sub btnNewClient_Click(sender As Object, e As EventArgs) Handles btnNewClient.Click
        Dim f As New AddHVHHWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim f As New AddressAddWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim f As New RegionAddWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim f As New TesuchAddWindow
        With f
            .ShowDialog()
            .Dispose()
        End With
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtEcr.Text.Trim = "" Then Throw New Exception("ՀԴՄ-ն գրված չէ")
            If txtHvhh.Text.Trim = "" Then Throw New Exception("ՀՎՀՀ-ն գրված չէ")
            If txtMgh.Text.Trim = "" Then Throw New Exception("ՄԳՀ-ն գրված չէ")
            If txtGorcAddress.Text.Trim = "" Then Throw New Exception("Գործունեության հասցեն գրված չէ")
            If txtGprs.Text.Trim = "" Then Throw New Exception("GPRS-ը գրված չէ")
            If txtObjType.Text.Trim = "" Then Throw New Exception("Օբյեկտի տեսակը գրված չէ")
            If txtTel.Text.Trim = "" Then Throw New Exception("Հեռախոսը-ն գրված չէ")

            If txtEcr.Text.Trim.Length <> 12 Then Throw New Exception("ՀԴՄ-ն պետք է ունենա 12 սիմվոլ երկարություն")
            'If txtHvhh.Text.Trim.Length <> 8 Then Throw New Exception("ՀՎՀՀ-ն պետք է ունենա 8 սիմվոլ երկարություն")
            If txtMgh.Text.Trim.Length <> 8 Then Throw New Exception("ՄԳՀ-ն պետք է ունենա 8 սիմվոլ երկարություն")

            If cbStatus.SelectedValue = 13 Then Throw New Exception("Շրջիկ կարգավիճակ կարելի է տալ միայն վերանորոգման միջոցով")

            Dim iEcr = New With {.Ecr = txtEcr.Text.Trim, .hvhh = txtHvhh.Text.Trim, .mgh = txtMgh.Text.Trim, .ContDate = dContractDate.DateTime, .gorcAddress = txtGorcAddress.Text.Trim,
                                 .gprs = txtGprs.Text.Trim, .status = cbStatus.SelectedValue, .regionID = cbRegion.SelectedValue, .objType = txtObjType.Text.Trim,
                                 .Tel = txtTel.Text.Trim, .IsNds = ckNds.Checked, .posTerm = ckPosTerm.Checked, .isInvoice = ckInvoice.Checked, .tesuch = cbTesuch.SelectedValue}

            iDB.InsertEcr(iEcr.Ecr, iEcr.hvhh, iEcr.mgh, iEcr.ContDate, iEcr.gorcAddress, iEcr.gprs, iEcr.status, iEcr.regionID, iEcr.objType,
                           iEcr.Tel, iEcr.tesuch, iEcr.IsNds, iEcr.posTerm, iEcr.isInvoice)

            'NewEcr = txtEcr.Text.Trim

            'Dim fG As New GPSForEcrRep With {.Ecr = NewEcr}
            'fG.ShowDialog()
            'fG.Dispose()

            MsgBox("Տվյալները ավելացվեցին", MsgBoxStyle.Information, My.Application.Info.Title)

            ClearData()
            LoadDT()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtEcr_TextChanged(sender As Object, e As EventArgs) Handles txtEcr.TextChanged
        On Error Resume Next
        If txtEcr.Text.Length = 1 Then
            If txtEcr.Text.StartsWith("V") Then
                txtEcr.Text = txtEcr.Text.Replace("V", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("v") Then
                txtEcr.Text = txtEcr.Text.Replace("v", "V90413") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("Q") Then
                txtEcr.Text = txtEcr.Text.Replace("Q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("q") Then
                txtEcr.Text = txtEcr.Text.Replace("q", "Q80414") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("S") Then
                txtEcr.Text = txtEcr.Text.Replace("S", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            ElseIf txtEcr.Text.StartsWith("s") Then
                txtEcr.Text = txtEcr.Text.Replace("s", "S900552") : txtEcr.SelectionStart = txtEcr.Text.Length
            End If
        End If
    End Sub
    Private Sub cbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegion.SelectedIndexChanged
        On Error Resume Next
        If TypeOf (cbRegion.SelectedValue) Is DataRowView Then Exit Sub

        Dim j As Integer = cbRegion.SelectedValue
        For i As Integer = 0 To dtRegoin.Rows.Count - 1
            If dtRegoin.Rows(i)("ՀՀ") = j Then
                If dtRegoin.Rows(i)("Տեսուչ") <> 0 Then cbTesuch.SelectedValue = dtRegoin.Rows(i)("Տեսուչ")
            End If
        Next
    End Sub
    Private Sub AddHDMWindow_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadDT()
    End Sub

End Class