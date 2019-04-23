Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class PrepareMailSendWindow

    Friend iTempHdm As New List(Of tempHDM)
    Dim listofemails As New List(Of emailList)
    Dim newmail As New List(Of generateEmail)

    Friend iMailDirection As String = "Կասեցված"

    Private Sub GridView1_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        On Error Resume Next
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim PayStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("փոստ"))
            If PayStatus = "-" Then
                e.Appearance.BackColor = Color.Red        ' Color.Salmon
                e.Appearance.BackColor2 = Color.Green            ' Color.SeaShell
            End If
        End If
    End Sub
    Private Sub LoadData()
        Try
            Dim dt As DataTable

            If iMailDirection = "Կասեցված" Then
                Dim iDT As DataTable = ToDataTable(iTempHdm)

                dt = iDB.GetDisabledMailingInfo(iDT)

                GridControl1.BeginUpdate()
                GridControl1.DataSource = Nothing
                GridView1.Columns.Clear()

                GridControl1.DataSource = dt

                GridView1.ClearSelection()
                GridControl1.EndUpdate()

                With GridView1
                    .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.Editable = False
                    .OptionsBehavior.ReadOnly = True
                    .OptionsCustomization.AllowColumnMoving = False
                    .OptionsCustomization.AllowGroup = False
                    
                    .OptionsView.AllowCellMerge = False
                    .OptionsSelection.MultiSelect = True
                    .OptionsSelection.EnableAppearanceFocusedCell = False
                    .OptionsCustomization.AllowFilter = False
                    .OptionsCustomization.AllowSort = False
                    .Columns("Տեսուչ").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                End With
                If GridView1.RowCount > 0 Then
                    If GridView1.Columns("Տեսուչ").Summary.ActiveCount = 0 Then
                        Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Տեսուչ", "Քանակ {0}")
                        GridView1.Columns("Տեսուչ").Summary.Add(item)
                    End If
                End If

                Dim dt2 As DataTable = iDB.GetDisabledMailingInfo2(iDT)
                If Not IsNothing(dt2) AndAlso dt2.Rows.Count > 0 Then
                    For i As Integer = 0 To dt2.Rows.Count - 1
                        listofemails.Add(New emailList(dt2.Rows(i)("Տեսուչ"), dt2.Rows(i)("Կազմակերպություն"), dt2.Rows(i)("Տարածաշրջան"), dt2.Rows(i)("Հասցե"), dt2.Rows(i)("Payment")))
                    Next
                End If

            Else

                Dim iDT As DataTable = ToDataTable(iTempHdm)
                dt = iDB.GetMailingInfo(iDT)

                GridControl1.BeginUpdate()
                GridControl1.DataSource = Nothing
                GridView1.Columns.Clear()

                GridControl1.DataSource = dt

                GridView1.ClearSelection()
                GridControl1.EndUpdate()

                With GridView1
                    .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.Editable = False
                    .OptionsBehavior.ReadOnly = True
                    .OptionsCustomization.AllowColumnMoving = False
                    .OptionsCustomization.AllowGroup = False
                    
                    .OptionsView.AllowCellMerge = False
                    .OptionsSelection.MultiSelect = True
                    .OptionsSelection.EnableAppearanceFocusedCell = False
                    .OptionsCustomization.AllowFilter = False
                    .OptionsCustomization.AllowSort = False
                    .Columns("Տեսուչ").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                End With
                If GridView1.RowCount > 0 Then
                    If GridView1.Columns("Տեսուչ").Summary.ActiveCount = 0 Then
                        Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Տեսուչ", "Քանակ {0}")
                        GridView1.Columns("Տեսուչ").Summary.Add(item)
                    End If
                End If

                Dim dt2 As DataTable = iDB.GetMailingInfo2(iDT)
                If Not IsNothing(dt2) AndAlso dt2.Rows.Count > 0 Then
                    For i As Integer = 0 To dt2.Rows.Count - 1
                        listofemails.Add(New emailList(dt2.Rows(i)("Տեսուչ"), dt2.Rows(i)("Կազմակերպություն"), dt2.Rows(i)("Տարածաշրջան"), dt2.Rows(i)("Հասցե"), dt2.Rows(i)("Payment")))
                    Next
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub mnuExportToExcel_Click(sender As Object, e As EventArgs) Handles mnuExportToExcel.Click
        Try
            ExportTo(ExportType.Excel2013, Me)
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub PrepareMailSendWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LoadData()
    End Sub
    Private Sub mnuPrepEmail_Click(sender As Object, e As EventArgs) Handles mnuPrepEmail.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then Exit Sub
            Dim b As Boolean

            For i As Integer = 0 To GridView1.SelectedRowsCount - 1
                Dim strEmail As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("փոստ")
                If strEmail = "-" Then Continue For

                Dim strMessage As String = ""
                Dim sTesuch As String = GridView1.GetDataRow(GridView1.GetSelectedRows()(i)).Item("տեսուչ")

                If iMailDirection = "Կասեցված" Then
                    b = True
                    strMessage = "Հարգելի աշխատակից,<br />" & vbCrLf & "Կից աղյուսակում ներկայացված են մատուցվող ծառայությունների մասով կասեցված կազմակերպությունների ցանկը։<br /><br />" & vbCrLf & vbCrLf
                Else
                    b = False
                    strMessage = "Հարգելի աշխատակից,<br />" & vbCrLf & "Կից աղյուսակում ներկայացված են մատուցվող ծառայությունների մասով կասեցման ենթակա կազմակերպությունների ցանկը։<br /><br />" & vbCrLf & vbCrLf
                End If

                For j As Integer = 0 To listofemails.Count - 1
                    If sTesuch = listofemails(j).Տեսուչ Then strMessage &= listofemails(j).Տարածաշրջան & Space(10) & listofemails(j).Կազմակերպություն & Space(10) & listofemails(j).Հասցե & ":   Պարտքի չափ` & " & listofemails(j).Վճար & " <br />" & vbCrLf
                Next

                strMessage &= vbCrLf & "<br />Հարգանքով՝<br /><br />" & vbCrLf & "Սպասարկման սրահ"
                newmail.Add(New generateEmail(sTesuch, strEmail, strMessage, b))
            Next

            'Bulk Insert
            Dim dt As New System.Data.DataTable
            dt.Columns.Add("Tesuch")
            dt.Columns.Add("Email")
            dt.Columns.Add("TesuchMessage")
            dt.Columns.Add("IsBlocked")
            dt.Columns.Add("PrepDate")

            For i As Integer = 0 To newmail.Count - 1
                Dim R As DataRow = dt.NewRow
                R("Tesuch") = newmail(i).Տեսուչ
                R("Email") = newmail(i).փոստ
                R("TesuchMessage") = newmail(i).Հաղորդագրություն
                R("IsBlocked") = newmail(i).Կասեցված
                R("PrepDate") = DateTime.Now
                dt.Rows.Add(R)
            Next

            iDB.BulkInsert(dt, "Mailing.MailPreparing")

            MsgBox("Նամակների ուղարկումը պլանավորվեց", MsgBoxStyle.Information, My.Application.Info.Title)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            Me.Close()
        End Try
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As GridControl = sender
            Dim view As New GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

End Class

Public Class emailList

    Private tesuch As String
    Private company As String
    Private region As String
    Private address As String
    Private payment As Object

    Public Sub New(strtesuch As String, strcompany As String, strregion As String, straddress As String, ByVal Pay As Object)
        tesuch = strtesuch
        company = strcompany
        region = strregion
        address = straddress
        payment = Pay
    End Sub

    Public Property Տեսուչ As String
        Get
            Return tesuch
        End Get
        Set(value As String)
            tesuch = value
        End Set
    End Property
    Public Property Կազմակերպություն As String
        Get
            Return company
        End Get
        Set(value As String)
            company = value
        End Set
    End Property
    Public Property Տարածաշրջան As String
        Get
            Return region
        End Get
        Set(value As String)
            region = value
        End Set
    End Property
    Public Property Հասցե As String
        Get
            Return address
        End Get
        Set(value As String)
            address = value
        End Set
    End Property
    Public Property Վճար As Object
        Get
            Return payment
        End Get
        Set(value As Object)
            payment = value
        End Set
    End Property

End Class

Public Class generateEmail

    Private tesuch As String
    Private email As String
    Private message As String
    Private isDisabled As Boolean

    Public Sub New(strtesuch As String, stremail As String, strmessage As String, bdisabled As Boolean)
        tesuch = strtesuch
        email = stremail
        message = strmessage
        isDisabled = bdisabled
    End Sub

    Public Property Տեսուչ As String
        Get
            Return tesuch
        End Get
        Set(value As String)
            tesuch = value
        End Set
    End Property
    Public Property փոստ As String
        Get
            Return email
        End Get
        Set(value As String)
            email = value
        End Set
    End Property
    Public Property Հաղորդագրություն As String
        Get
            Return message
        End Get
        Set(value As String)
            message = value
        End Set
    End Property
    Public Property Կասեցված As Boolean
        Get
            Return isDisabled
        End Get
        Set(value As Boolean)
            isDisabled = value
        End Set
    End Property

End Class