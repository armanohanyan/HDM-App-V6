Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class MnacordSelector

    Private Sub loadSupporter()
        Try
            Dim dt As DataTable

            If iUser.DB = 5 Then
                dt = iDB.GetWarehouseList()
            Else
                dt = iDB.GetSupporter2(iUser.DB)
            End If
            With cbSupporter
                .DataSource = dt
                .DisplayMember = "Կազմակերպություն"
                .ValueMember = "ՀՀ"
            End With

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub loadEquipments()
        Try
            Dim dt As DataTable
            If cNoNyut.Checked = True Then
                dt = iDB.GetEquipmentForFilter()
            Else
                dt = iDB.GetEquipmentForFilterNyut()
            End If
            With cEquipment
                .DataSource = dt
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
    Private Sub DateSelecterForSoldEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadSupporter()
        Call loadEquipments()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim formX As New Working
        Dim sTime As DateTime
        Dim eTime As DateTime

        Try
            formX.Show() : My.Application.DoEvents()
            sTime = Now

            Dim dt As DataTable

            Dim dbID As Byte = cbSupporter.SelectedValue

            If cNoNyut.Checked = True Then
                dt = iDB.ShtrikhMnacordBySarq(dbID, cEquipment.SelectedValue)
            Else
                dt = iDB.ShtrikhMnacordBySarq2(dbID, cEquipment.SelectedValue)
            End If

            Call CloseWindow("nIntermediateWarehouse")
            Dim f As New IntermediateWarehouseWin
            AddChildForm("nIntermediateWarehouse", f)

            f.GridControl1.BeginUpdate()
            f.GridView1.Columns.Clear()

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = Nothing
            f.GridView1.Columns.Clear()

            f.GridControl1.DataSource = dt

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            With f.GridView1
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = False
                .OptionsBehavior.ReadOnly = True
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = False
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .BestFitColumns(True)
            End With

            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            If f.GridView1.RowCount > 0 Then
                If f.GridView1.Columns("Սարքավորում").Summary.ActiveCount = 0 Then
                    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Սարքավորում", "{0}")
                    f.GridView1.Columns("Սարքավորում").Summary.Add(item)
                End If
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            eTime = Now
            Dim duration As TimeSpan = eTime - sTime
            Dim iduration = String.Format("Տևողություն {0}", duration.ToString())
            MainWindow.InfoTime.Caption = iduration
            formX.Close()
            formX = Nothing
            Me.Close()
        End Try
    End Sub
    Private Sub cNoNyut_CheckedChanged(sender As Object, e As EventArgs) Handles cNoNyut.CheckedChanged
        Call loadEquipments()
    End Sub
    Private Sub cNyut_CheckedChanged(sender As Object, e As EventArgs) Handles cNyut.CheckedChanged
        Call loadEquipments()
    End Sub

End Class