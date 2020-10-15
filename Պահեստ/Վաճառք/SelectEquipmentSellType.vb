Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Public Class SelectEquipmentSellType

    Dim dt3 As DataTable
    Friend PropID As Integer

    Private Sub loadSupporter()
        Try
            Dim dt1 As DataTable = iDB.GetSupporter
            Dim dt2 As DataTable = iDB.GetSupporter

            dt3 = iDB.GetHVHHsForSell

            With cSeller
                .DataSource = dt1
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
            End With

            With cBuyer
                .DataSource = dt2
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
            End With

            With cbBvhhList
                .DataSource = dt3
                .DisplayMember = "ՀՎՀՀ"
                .ValueMember = "ՀՀ"
            End With

            If cSeller.Items.Count > 0 Then If iUser.DB <> 5 Then cSeller.SelectedValue = iUser.DB : cSeller.Enabled = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub SelectEquipmentSellType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadSupporter()
    End Sub
    Private Sub NextStep()

        If cSeller.SelectedValue = 5 Then MsgBox("Վաճառող կազմակերպությունը հստակ նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub

        Dim isLocal As Boolean = rSupporter.Checked

        Dim f As New SellWindow With {.IsLocalSell = isLocal, .ClientHVHH = txtHVHH.Text.Trim, .SupporterID = cSeller.SelectedValue, .ClientID = cBuyer.SelectedValue, .SellPropID = PropID}
        f.ShowDialog()
        f.Dispose()
        Me.Close()

    End Sub
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try

            If rSupporter.Checked Then
                If cSeller.SelectedValue = cBuyer.SelectedValue Then Throw New Exception("Վաճառողը և գնորդը չեն կարող նույնը լինել")
                If cSeller.SelectedValue = 5 OrElse cBuyer.SelectedValue = 5 Then Throw New Exception("Անորոշը չի կարող գնել կամ վաճառել")

                cSeller.Enabled = False
                rSupporter.Enabled = False
                cBuyer.Enabled = False
                rClient.Enabled = False
                txtHVHH.Enabled = False

                'OK
                Call NextStep()
            ElseIf rClient.Checked Then
                If txtHVHH.Text.Trim = "" Then Throw New Exception("Հաճախորդի ՀՎՀՀ-ն գրված չէ")

                'check if exists
                If iDB.IsClientSuported(txtHVHH.Text.Trim) = False Then Throw New Exception("ՀՎՀՀ-ն սխալ է կամ հաճախորդը չի սպասարկվում")

                Dim supporter As Byte = iDB.GetClientSupporter(txtHVHH.Text.Trim)

                If supporter = 5 Then Throw New Exception("Հաճախորդը չի սպասարկվում")

                If iUser.DB <> 5 AndAlso supporter <> iUser.DB Then Throw New Exception("Հաճախորդին դուք չեք սպասարկում")

                cSeller.SelectedValue = supporter

                cSeller.Enabled = False
                rSupporter.Enabled = False
                cBuyer.Enabled = False
                rClient.Enabled = False
                txtHVHH.Enabled = False

                If dt3.Rows.Count > 0 Then
                    For i = 0 To dt3.Rows.Count - 1
                        If txtHVHH.Text.Trim = dt3.Rows(i)("ՀՎՀՀ").ToString Then
                            'If txtHVHH.Text.Trim = cbHvhhList.Text.Trim Then
                            'Dim i As Integer = cbHvhhList.SelectedIndex
                            'cSeller.SelectedValue = dt3.Rows(i)("Սպասարկող")
                            PropID = dt3.Rows(i)("ՀՀ")
                        End If
                    Next
                End If

                'If txtHVHH.Text.Trim = cbBvhhList.Text.Trim Then
                '    If dt3.Rows.Count > 0 Then
                '        Dim i As Integer = cbBvhhList.SelectedIndex
                '        'cSeller.SelectedValue = dt3.Rows(i)("Սպասարկող")
                '        PropID = dt3.Rows(i)("ՀՀ")
                '    End If
                'End If

                'OK
                Call NextStep()
            End If

            btnCheck.Enabled = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

    Private Sub cbBvhhList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBvhhList.SelectedIndexChanged
        Dim hvhh As String = cbBvhhList.Text.ToString
        txtHVHH.Text = hvhh
    End Sub
End Class