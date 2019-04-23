Option Explicit Off

Module ModuleInvoise

    Friend Function Tver(x As String, dram As Boolean)
        Dim a() As String
        Dim b As String
        Dim c As Integer

        ReDim a(1000000)

        a(0) = ""
        a(1) = " մեկ"
        a(2) = " երկու"
        a(3) = " երեք"
        a(4) = " չորս"
        a(5) = " հինգ"
        a(6) = " վեց"
        a(7) = " յոթ"
        a(8) = " ութ"
        a(9) = " ինը"
        a(10) = " տաս"
        a(11) = " տասնմեկ"
        a(12) = " տասներկու"
        a(13) = " տասներեք"
        a(14) = " տասնչորս"
        a(15) = " տասնհինգ"
        a(16) = " տասնվեց"
        a(17) = " տասնյոթ"
        a(18) = " տասնութ"
        a(19) = " տասնինը"
        a(20) = " քսան"
        a(21) = " քսանմեկ"
        a(22) = " քսաներկու"
        a(23) = " քսաներեք"
        a(24) = " քսանչորս"
        a(25) = " քսանհինգ"
        a(26) = " քսանվեց"
        a(27) = " քսանյոթ"
        a(28) = " քսանութ"
        a(29) = " քսանինը"
        a(30) = " երեսուն"
        a(31) = " երեսունմեկ"
        a(32) = " երեսուներկու"
        a(33) = " երեսուներեք"
        a(34) = " երեսունչորս"
        a(35) = " երեսունհինգ"
        a(36) = " երեսունվեց"
        a(37) = " երեսունյոթ"
        a(38) = " երեսունութ"
        a(39) = " երեսունինը"
        a(40) = " քառասուն"
        a(41) = " քառասունմեկ"
        a(42) = " քառասուներկու"
        a(43) = " քառասուներեք"
        a(44) = " քառասունչորս"
        a(45) = " քառասունհինգ"
        a(46) = " քառասունվեց"
        a(47) = " քառասունյոթ"
        a(48) = " քառասունութ"
        a(49) = " քառասունինը"
        a(50) = " հիսուն"
        a(51) = " հիսունմեկ"
        a(52) = " հիսուներկու"
        a(53) = " հիսուներեք"
        a(54) = " հիսունչորս"
        a(55) = " հիսունհինգ"
        a(56) = " հիսունվեց"
        a(57) = " հիսունյոթ"
        a(58) = " հիսունութ"
        a(59) = " հիսունինը"
        a(60) = " վաթսուն"
        a(61) = " վաթսունմեկ"
        a(62) = " վաթսուներկու"
        a(63) = " վաթսուներեք"
        a(64) = " վաթսունչորս"
        a(65) = " վաթսունհինգ"
        a(66) = " վաթսունվեց"
        a(67) = " վաթսունյոթ"
        a(68) = " վաթսունութ"
        a(69) = " վաթսունինը"
        a(70) = " յոթանասուն"
        a(71) = " յոթանասունմեկ"
        a(72) = " յոթանասուներկու"
        a(73) = " յոթանասուներեք"
        a(74) = " յոթանասունչորս"
        a(75) = " յոթանասունհինգ"
        a(76) = " յոթանասունվեց"
        a(77) = " յոթանասունյոթ"
        a(78) = " յոթանասունութ"
        a(79) = " յոթանասունինը"
        a(80) = " ութսուն"
        a(81) = " ութսունմեկ"
        a(82) = " ութսուներկու"
        a(83) = " ութսուներեք"
        a(84) = " ութսունչորս"
        a(85) = " ութսունհինգ"
        a(86) = " ութսունվեց"
        a(87) = " ութսունյոթ"
        a(88) = " ութսունութ"
        a(89) = " ութսունինը"
        a(90) = " իննիսուն"
        a(91) = " իննիսունմեկ"
        a(92) = " իննիսուներկու"
        a(93) = " իննիսուներեք"
        a(94) = " իննիսունչորս"
        a(95) = " իննիսունհինգ"
        a(96) = " իննիսունվեց"
        a(97) = " իննիսունյոթ"
        a(98) = " իննիսունութ"
        a(99) = " իննիսունինը"
        a(100) = " հարյուր"
        a(1000) = " հազար"
        a(1000000) = " միլիոն"

        x = Int(x)
        c = Len(x)

        Select Case c
            Case Is < 3
                If Int(x) = 0 Then
                    b = "զրո"
                Else
                    b = a(Int(x))
                End If
            Case 3
                b = a(Int(Mid(x, 1, 1))) + a(100) + a(Int(Mid(x, 2, 2)))
            Case 4
                If Int(Mid(x, 2, 1)) <> 0 Then
                    har = a(100)
                Else
                    har = ""
                End If
                b = a(Int(Mid(x, 1, 1))) + a(1000) + a(Int(Mid(x, 2, 1))) + har + a(Int(Mid(x, 3, 2)))
            Case 5
                If Int(Mid(x, 3, 1)) <> 0 Then
                    har = a(100)
                Else
                    har = ""
                End If
                b = a(Int(Mid(x, 1, 2))) + a(1000) + a(Int(Mid(x, 3, 1))) + har + a(Int(Mid(x, 4, 2)))
            Case 6
                If Int(Mid(x, 4, 1)) <> 0 Then
                    har = a(100)
                Else
                    har = ""
                End If
                b = a(Int(Mid(x, 1, 1))) + a(100) + a(Int(Mid(x, 2, 2))) + a(1000) + a(Int(Mid(x, 4, 1))) + har + a(Int(Mid(x, 5, 2)))
            Case 7
                If Int(Mid(x, 2, 1)) <> 0 Then
                    har = a(100)
                Else
                    har = ""
                End If

                If Int(Mid(x, 5, 1)) <> 0 Then
                    har2 = a(100)
                Else
                    har2 = ""
                End If
                If Int(Mid(x, 3, 2)) <> 0 Or Int(Mid(x, 2, 1)) <> 0 Then
                    haz = a(1000)
                Else
                    haz = ""
                End If
                b = a(Int(Mid(x, 1, 1))) + a(1000000) + a(Int(Mid(x, 2, 1))) + har + a(Int(Mid(x, 3, 2))) + haz + a(Int(Mid(x, 5, 1))) + har2 + a(Int(Mid(x, 6, 2)))
            Case 8
                If Int(Mid(x, 3, 1)) <> 0 Then
                    har = a(100)
                Else
                    har = ""
                End If
                If Int(Mid(x, 6, 1)) <> 0 Then
                    har2 = a(100)
                Else
                    har2 = ""
                End If
                If Int(Mid(x, 4, 2)) <> 0 Or Int(Mid(x, 3, 1)) <> 0 Then
                    haz = a(1000)
                Else
                    haz = ""
                End If
                b = a(Int(Mid(x, 1, 2))) + a(1000000) + a(Int(Mid(x, 3, 1))) + har + a(Int(Mid(x, 4, 2))) + haz + a(Int(Mid(x, 6, 1))) + har2 + a(Int(Mid(x, 7, 2)))
            Case 9
                If Int(Mid(x, 4, 1)) <> 0 Then
                    har = a(100)
                Else
                    har = ""
                End If
                If Int(Mid(x, 7, 1)) <> 0 Then
                    har2 = a(100)
                Else
                    har2 = ""
                End If
                If Int(Mid(x, 5, 2)) <> 0 Or Int(Mid(x, 4, 1)) <> 0 Then
                    haz = a(1000)
                Else
                    haz = ""
                End If
                b = a(Int(Mid(x, 1, 1))) + a(100) + a(Int(Mid(x, 2, 2))) + a(1000000) + a(Int(Mid(x, 4, 1))) + har + a(Int(Mid(x, 5, 2))) + haz + a(Int(Mid(x, 7, 1))) + har2 + a(Int(Mid(x, 8, 2)))
            Case Is > 9
                b = "Error:"
                dram = False
        End Select
        If dram = True Then
            Tver = b + " դրամ"
        Else
            Tver = b
        End If
    End Function

End Module