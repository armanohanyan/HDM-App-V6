Public Class PurchaseInsert2


    Friend sDate As Date
    Friend sWareHouse As String
    Friend iWareHouseID As Short

    Private Sub loadEquipment()
        Try
            Dim dt2 As DataTable = iDB.GetEquipmentListFiltered()
            With cbEquipment
                .DataSource = dt2
                .DisplayMember = "Սարքավորում"
                .ValueMember = "ՀՀ"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub PurchaseInsert2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadEquipment()
        txtWareHouse.Text = sWareHouse
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrEmpty(txtQuantity.Text) Then Throw New Exception("Քանակը գրված չէ")
            If txtQuantity.Text <= 0 Then Throw New Exception("Քանակը պետք է 0-ից մեծ լինի")

            If String.IsNullOrEmpty(txtAmount.Text) Then Throw New Exception("Գումարը գրված չէ")
            If txtAmount.Text < 0 Then Throw New Exception("Գումարը պետք է 0-ից փոքր չլինի")

            Dim ismarket As Boolean
            If iWareHouseID = 5 Then ismarket = True Else ismarket = False

            iDB.InsertPurchaseWarehouse2(cbEquipment.SelectedValue, txtQuantity.Text, txtAmount.Text, sDate, txtComment.Text, iWareHouseID, ismarket)

            MsgBox("Տվյալը հաջողությամբ ավելացվեց բազա", MsgBoxStyle.Information, My.Application.Info.Title)

            txtQuantity.Text = String.Empty
            txtAmount.Text = String.Empty
            txtComment.Text = String.Empty

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class