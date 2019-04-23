Imports DevExpress.Utils

Public Class MapProp

    Private Sub LoadTesuch()
        Try
            Dim dt As DataTable = iDB.TesuchLoginRep()
            With cTesuch
                .DataSource = dt
                .DisplayMember = "Login"
                .ValueMember = "TesuchID"
            End With
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub MapProp_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With sDate
            .DateTime = Now
            .Properties.DisplayFormat.FormatType = FormatType.DateTime
            .Properties.DisplayFormat.FormatString = "dd.MM.yyyy"
            .Properties.ShowToday = True
            .Properties.ShowClear = False
        End With
        Call LoadTesuch()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Try
            Dim sDateX As Date = sDate.DateTime
            Dim eDateX As Date = DateAdd(DateInterval.Day, 1, sDateX)

            Dim tesuchID As Integer = cTesuch.SelectedValue

            Dim dt As DataTable = iDB.getMarkers(tesuchID, sDateX, eDateX)

            If dt.Rows.Count = 0 Then Throw New Exception("Հայտերի տվյալներ չկան")

            Dim sHeader As String = "<!DOCTYPE html><html><head><meta name=viewport content=initial-scale=1.0, user-scalable=no><meta charset=utf-8><title>Simple markers</title><style>html,body {height:100%;margin:0;padding:0;}#map {height:100%;}</style></head><body><div id=map></div><script>" & vbCrLf

            Dim sStartFN As String = "function initMap() {"
            Dim sLat As String = String.Empty
            Dim sObj As String = "var map = new google.maps.Map(document.getElementById('map'), {zoom: 12,center: LatLng});"
            Dim sMap As String = String.Empty
            Dim sEndFN As String = "}"

            If dt.Rows.Count = 1 Then
                Dim spl As String() = Split(dt.Rows(0)("EcrLocation"), ",")
                sLat = "var LatLng = {lat: " & spl(0) & ", lng: " & spl(1) & "};"
                sMap = "var marker = new google.maps.Marker({position: LatLng,map: map});"
            Else
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        Dim spl As String() = Split(dt.Rows(0)("EcrLocation"), ",")
                        sLat = "var LatLng = {lat: " & spl(0) & ", lng: " & spl(1) & "};"
                        sMap = "marker = new google.maps.Marker({position: LatLng,map: map});"
                    Else
                        Dim spl As String() = Split(dt.Rows(i)("EcrLocation"), ",")
                        sLat &= "var LatLng" & i & " = {lat: " & spl(0) & ", lng: " & spl(1) & "};"
                        sMap &= "marker = new google.maps.Marker({position: LatLng" & i & ",map: map});"
                    End If
                Next
            End If

            Dim sFN2 As String = String.Empty
            Dim sLoop As String = String.Empty
            Dim sObj2 As String = String.Empty

            'For Direction
            'Dim dt2 As DataTable = iDB.GpsLocationGet(tesuchID, sDateX, eDateX)
            'If dt2.Rows.Count > 1 Then
            '    sFN2 = " var directionsService = new google.maps.DirectionsService;var directionsDisplay = new google.maps.DirectionsRenderer({map: map});var stepDisplay = new google.maps.InfoWindow;"

            '    For i As Integer = 0 To dt2.Rows.Count - 2
            '        sLoop &= "calculateAndDisplayRoute(directionsDisplay, directionsService, stepDisplay, map,'" & dt2.Rows(i)("Latitude") & "," & dt2.Rows(i)("Longitude") & "','" & dt2.Rows(i + 1)("Latitude") & "," & dt2.Rows(i + 1)("Longitude") & "');"
            '    Next

            '    sFN2 &= sLoop
            '    sObj2 = "function calculateAndDisplayRoute(directionsDisplay, directionsService,stepDisplay, map, Lat, Lng){directionsService.route({origin: Lat ,destination: Lng ,travelMode: google.maps.TravelMode.WALKING}, function(response, status) {if (status === google.maps.DirectionsStatus.OK){directionsDisplay.setDirections(response);}});}"
            'End If


            'For Direction
            Dim iInterval As Byte = 0
            If RadioButton1.Checked = True Then
                iInterval = 1
            ElseIf RadioButton2.Checked = True Then
                iInterval = 2
            ElseIf RadioButton3.Checked = True Then
                iInterval = 3
            ElseIf RadioButton4.Checked = True Then
                iInterval = 4
            ElseIf RadioButton5.Checked = True Then
                iInterval = 5
            ElseIf RadioButton6.Checked = True Then
                iInterval = 6
            ElseIf RadioButton7.Checked = True Then
                iInterval = 7
            End If

            Dim dt2 As DataTable = iDB.GpsLocationGet(tesuchID, sDateX, iInterval)
            If dt2.Rows.Count > 1 Then
                sFN2 = "var directionsService = new google.maps.DirectionsService;var directionsDisplay = new google.maps.DirectionsRenderer({map: map});var stepDisplay = new google.maps.InfoWindow;"

                Dim iStart As String = dt2.Rows(0)("Latitude") & "," & dt2.Rows(0)("Longitude")
                Dim iFinish As String = dt2.Rows(dt2.Rows.Count - 1)("Latitude") & "," & dt2.Rows(dt2.Rows.Count - 1)("Longitude")

                For i As Integer = 1 To dt2.Rows.Count - 2
                    'sLoop &= "waypointsX[" & i - 1 & "]='" & dt2.Rows(i)("Latitude") & "," & dt2.Rows(i)("Longitude") & "';" & vbCrLf
                    'sLoop &= "waypts.push({location: '" & dt2.Rows(i)("Latitude") & "," & dt2.Rows(i)("Longitude") & "' , stopover: true });" & vbCrLf

                    sLoop &= "waypts.push({location: '" & dt2.Rows(i)("Latitude") & "," & dt2.Rows(i)("Longitude") & "' , stopover : true });" & vbCrLf
                Next

                sLoop &= "calculateAndDisplayRoute(directionsDisplay, directionsService, stepDisplay, map);"
                sFN2 &= sLoop
                sObj2 = "var waypts = []; function calculateAndDisplayRoute(directionsDisplay, directionsService,stepDisplay, map){directionsService.route({origin: '" & iStart & "' ,destination : '" & iFinish & "' ,waypoints : waypts,travelMode: google.maps.TravelMode.WALKING}, function(response, status) {if (status === google.maps.DirectionsStatus.OK){directionsDisplay.setDirections(response);}});}"
            End If

            Dim sFinish As String = "</script><script async defer src=" & Chr(34) & "https://maps.googleapis.com/maps/api/js?key=AIzaSyBISMrzj_X3BRM4wHZqFaOGFQUUcj4uh_g&callback=initMap" & Chr(34) & "></script></body></html>"

            WebBrowser1.Navigate("about:Tabs")
            WebBrowser1.Document.Write(sHeader & sStartFN & sLat & sObj & sMap & sFN2 & sEndFN & sObj2 & sFinish)
            WebBrowser1.Refresh()

            'Clipboard.SetText(sHeader & sStartFN & sLat & sObj & sMap & sFN2 & sEndFN & sObj2 & sFinish)

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Try
            Dim tesuchID As Integer = cTesuch.SelectedValue

            Dim dt As DataTable = iDB.GetTesuchLastMarkers(tesuchID)

            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չկան")

            Dim sHeader As String = "<!DOCTYPE html><html><head><meta name=viewport content=initial-scale=1.0, user-scalable=no><meta charset=utf-8><title>Simple markers</title><style>html,body {height:100%;margin:0;padding:0;}#map {height:100%;}</style></head><body><div id=map></div><script>" & vbCrLf

            Dim sStartFN As String = "function initMap() {"
            Dim sLat As String = String.Empty
            Dim sObj As String = "var map = new google.maps.Map(document.getElementById('map'), {zoom: 12,center: LatLng});"
            Dim sMap As String = String.Empty
            Dim sEndFN As String = "}"

            For i As Integer = 0 To dt.Rows.Count - 1
                If i = 0 Then
                    sLat = "var LatLng = {lat: " & dt.Rows(i)("Latitude") & ", lng: " & dt.Rows(i)("Longitude") & "};"
                    sMap = "marker = new google.maps.Marker({position: LatLng,map: map});"
                Else
                    sLat &= "var LatLng" & i & " = {lat: " & dt.Rows(i)("Latitude") & ", lng: " & dt.Rows(i)("Longitude") & "};"
                    sMap &= "marker = new google.maps.Marker({position: LatLng" & i & ",map: map});"
                End If
            Next

            Dim sFN2 As String = String.Empty
            Dim sLoop As String = String.Empty
            Dim sObj2 As String = String.Empty

            If dt.Rows.Count > 1 Then
                sFN2 = "var directionsService = new google.maps.DirectionsService;var directionsDisplay = new google.maps.DirectionsRenderer({map: map});var stepDisplay = new google.maps.InfoWindow;"

                Dim iStart As String = dt.Rows(0)("Latitude") & "," & dt.Rows(0)("Longitude")
                Dim iFinish As String = dt.Rows(dt.Rows.Count - 1)("Latitude") & "," & dt.Rows(dt.Rows.Count - 1)("Longitude")

                For i As Integer = 1 To dt.Rows.Count - 2
                    sLoop &= "waypts.push({location: '" & dt.Rows(i)("Latitude") & "," & dt.Rows(i)("Longitude") & "' , stopover : true });" & vbCrLf
                Next

                sLoop &= "calculateAndDisplayRoute(directionsDisplay, directionsService, stepDisplay, map);"
                sFN2 &= sLoop
                sObj2 = "var waypts = []; function calculateAndDisplayRoute(directionsDisplay, directionsService,stepDisplay, map){directionsService.route({origin: '" & iStart & "' ,destination : '" & iFinish & "' ,waypoints : waypts,travelMode: google.maps.TravelMode.WALKING}, function(response, status) {if (status === google.maps.DirectionsStatus.OK){directionsDisplay.setDirections(response);}});}"
            End If

            Dim sFinish As String = "</script><script async defer src=" & Chr(34) & "https://maps.googleapis.com/maps/api/js?key=AIzaSyBISMrzj_X3BRM4wHZqFaOGFQUUcj4uh_g&callback=initMap" & Chr(34) & "></script></body></html>"

            WebBrowser1.Navigate("about:Tabs")
            WebBrowser1.Document.Write(sHeader & sStartFN & sLat & sObj & sMap & sFN2 & sEndFN & sObj2 & sFinish)
            WebBrowser1.Refresh()

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub

End Class