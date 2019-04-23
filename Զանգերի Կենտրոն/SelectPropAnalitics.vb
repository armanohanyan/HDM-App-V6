Imports DevExpress.XtraGrid

Public Class SelectPropAnalitics

#Region "Distance"

    Public Function distance(ByVal lat1 As Double, ByVal lon1 As Double, _
                         ByVal lat2 As Double, ByVal lon2 As Double, _
                         Optional ByVal unit As Char = "M"c) As Double
        Dim theta As Double = lon1 - lon2
        Dim dist As Double = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + _
                                Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * _
                                Math.Cos(deg2rad(theta))
        dist = Math.Acos(dist)
        dist = rad2deg(dist)
        dist = dist * 60 * 1.1515
        If unit = "K" Then
            dist = dist * 1.609344
        ElseIf unit = "N" Then
            dist = dist * 0.8684
        End If
        Return dist
    End Function
    Public Function Haversine(ByVal lat1 As Double, ByVal lon1 As Double, _
                         ByVal lat2 As Double, ByVal lon2 As Double, _
                         Optional ByVal unit As Char = "M"c) As Double
        Dim R As Double = 6371 'earth radius in km
        Dim dLat As Double
        Dim dLon As Double
        Dim a As Double
        Dim c As Double
        Dim d As Double
        dLat = deg2rad(lat2 - lat1)
        dLon = deg2rad((lon2 - lon1))
        a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(deg2rad(lat1)) * _
                Math.Cos(deg2rad(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        d = R * c
        Select Case unit.ToString.ToUpper
            Case "M"c
                d = d * 0.62137119
            Case "N"c
                d = d * 0.5399568
        End Select
        Return d
    End Function
    Private Function deg2rad(ByVal deg As Double) As Double
        Return (deg * Math.PI / 180.0)
    End Function
    Private Function rad2deg(ByVal rad As Double) As Double
        Return rad / Math.PI * 180.0
    End Function

#End Region

    Private Sub SelectPropAnalitics_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        sDate.DateTime = New Date(Now.Year, Now.Month, 1)
        eDate.DateTime = DateSerial(Now.Year, Now.Month + 1, 1 - 1)
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim frmX As New Working
        frmX.Show()
        My.Application.DoEvents()

        Try
            Dim sd As Date = sDate.DateTime
            Dim ed As Date = DateAdd(DateInterval.Day, 1, eDate.DateTime)

            Dim dt As DataTable = iDB.HaytAnalitics(sd, ed)

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows(i)("ՀայտիԿոորդինատ")) Then Continue For
                    If IsDBNull(dt.Rows(i)("Lat")) Then Continue For
                    If IsDBNull(dt.Rows(i)("Long")) Then Continue For

                    Dim s As String() = Split(dt.Rows(i)("ՀայտիԿոորդինատ"), ",")

                    If Not IsNumeric(s(0)) Then Continue For
                    If Not IsNumeric(s(1)) Then Continue For

                    If Not IsNumeric(dt.Rows(i)("Lat")) Then Continue For
                    If Not IsNumeric(dt.Rows(i)("Long")) Then Continue For

                    dt.Rows(i)("Հեռավորություն") = Math.Round(distance(s(0), s(1), dt.Rows(i)("Lat"), dt.Rows(i)("Long"), "K"), 3, MidpointRounding.AwayFromZero)

                Next
            End If

            Call CloseWindow("nPropAnalitics")
            Dim f As New PropAnalitics
            AddChildForm("nPropAnalitics", f)

            f.GridControl1.BeginUpdate()
            f.GridControl1.DataSource = dt
            With f.GridView1
                If .RowCount > 0 Then

                    .Columns("Lat").Visible = False
                    .Columns("Long").Visible = False
                    .Columns("ՀայտիԿոորդինատ").Visible = False

                    If .Columns("ՀԴՄ").Summary.ActiveCount = 0 Then
                        Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ՀԴՄ", "{0}")
                        .Columns("ՀԴՄ").Summary.Add(item)
                    End If
                End If
            End With
            f.GridView1.ClearSelection()
            f.GridControl1.EndUpdate()

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            frmX.Dispose()
        End Try
    End Sub

End Class