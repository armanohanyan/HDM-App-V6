Imports DevExpress.XtraGrid

Public Class XML_Dublicate_Checker

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim lForm As New Working

        Try
            'Folder Path
            Dim s As String = String.Empty
            Dim FB As FolderBrowserDialog = New FolderBrowserDialog
            With FB
                .ShowNewFolderButton = False
                .ShowDialog()
                s = .SelectedPath
                If String.IsNullOrEmpty(s) Then Exit Sub
                If IO.Directory.Exists(s) = False Then Exit Sub
            End With

            'Files List

            Dim di As New IO.DirectoryInfo(s)
            Dim FI As IO.FileInfo() = di.GetFiles("*.xml", IO.SearchOption.TopDirectoryOnly)

            If FI.Count = 0 Then Throw New Exception("Ֆայլերի ցանկը չի ստացվել")

            lForm.Show() : My.Application.DoEvents()

            'HVHH List
            Dim dt As DataTable = iDB.GetHvhhBySupporter()

            If dt.Rows.Count = 0 Then Throw New Exception("Բազայից տվյալները չեն ստացվել")

            GridControl1.BeginUpdate()
            GridView1.Columns.Clear()
            GridControl1.DataSource = dt
            GridView1.ClearSelection()

            With GridView1
                .Columns("ՀՎՀՀ").OptionsColumn.ReadOnly = True
                .Columns("Սպասարկող").OptionsColumn.ReadOnly = True
                .OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                .OptionsBehavior.Editable = True
                .OptionsBehavior.ReadOnly = False
                .OptionsView.AllowCellMerge = False
                .OptionsSelection.MultiSelect = True
                .OptionsSelection.EnableAppearanceFocusedCell = False
                .OptionsCustomization.AllowSort = True
            End With

            If GridView1.Columns("ՀՎՀՀ").Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀՎՀՀ", "{0}")
                GridView1.Columns("ՀՎՀՀ").Summary.Add(item)
            End If

            GridControl1.EndUpdate()

            Dim iCount As Integer = GridView1.RowCount

            Dim t1 As Long = System.Environment.TickCount

            Dim L As New List(Of String)

            'Check Count
            For Each CF As IO.FileInfo In FI
                Dim objReader As New System.IO.StreamReader(CF.FullName)

                Do While Not objReader.EndOfStream

                    Dim T As String = String.Empty
                    T = objReader.ReadLine()

                    If T.Contains("<TIN>") Then
                        L.Add(New String(T.Trim))
                    End If

                    My.Application.DoEvents()
                Loop
            Next

            For i As Integer = 0 To GridView1.RowCount - 1
                Dim t2 As Long = System.Environment.TickCount
                Dim sp As TimeSpan = TimeSpan.FromMilliseconds(t2 - t1)

                lForm.Text = i & " / " & iCount & "  |  " & Microsoft.VisualBasic.Right("00" & sp.Hours.ToString, 2) & ":" & Microsoft.VisualBasic.Right("00" & sp.Minutes.ToString, 2) & ":" & Microsoft.VisualBasic.Right("00" & sp.Seconds.ToString, 2)

                GridView1.MakeRowVisible(i)

                Dim hvhh As String = "<TIN>" & GridView1.GetRowCellValue(i, "ՀՎՀՀ") & "</TIN>"
                Dim CT As Integer = GridView1.GetRowCellValue(i, "Քանակ")

                For j As Integer = L.Count - 1 To 0 Step -1
                    If L.Item(j).ToString = hvhh Then
                        CT += 1
                        GridView1.SetRowCellValue(i, "Քանակ", CT)
                        L.RemoveAt(j)
                    End If

                    My.Application.DoEvents()
                Next
            Next

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            lForm.Close()
        End Try
    End Sub

End Class