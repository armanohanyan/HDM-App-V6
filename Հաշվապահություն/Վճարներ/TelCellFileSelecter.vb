Imports System.Data.OleDb

Public Class TelCellFileSelecter

    Dim MIN_DATE As String
    Dim MAX_DATE As String
    Dim MIN_DATE2 As Date
    Dim MAX_DATE2 As Date

    Dim Shtrikh_SUM As Decimal = 0
    Dim TAMA_SUM As Decimal = 0
    Dim MK_SUM As Decimal = 0
    Dim TOUCH_SUM As Decimal = 0

    'List Of CSV Variable
    Dim L As List(Of CSV)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Folder Path Variable
            Dim FolderPath As String = String.Empty

            'Dialog Variable
            Dim fDialog As New FolderBrowserDialog

            'Show Dialog Box
            With fDialog
                .ShowNewFolderButton = False
                .Description = "Նշեք Թղթապանակը"
                .ShowDialog()
                FolderPath = .SelectedPath
            End With

            'Check If NULL
            If (String.IsNullOrEmpty(FolderPath)) OrElse (IO.Directory.Exists(FolderPath) = False) Then Exit Sub

            'Get List Of FIle Names
            Dim files() As String = IO.Directory.GetFiles(FolderPath)

            'List Of CSV Variable
            L = New List(Of CSV)

            For Each f As String In files

                'Local Variables
                Dim ACCOUNT As String
                Dim AMOUNT As String
                Dim [DATE] As String
                Dim TERMINAL As String
                Dim RECEIPT As String
                Dim TELCELL_REF As String
                Dim PRV_REF As String

                'For ReadLine
                Dim s As String = String.Empty

                'Array For Split
                Dim s2() As String

                'StreamReader
                Dim r As IO.StreamReader = New IO.StreamReader(f)

                'For Ignoring First Row
                Dim i As Integer = 0

                'Reading Lines
                While Not r.EndOfStream

                    'Read Line
                    s = r.ReadLine


                    If i > 0 Then
                        'Spliting Line
                        s2 = s.Split(";")

                        'Setting Local Values
                        ACCOUNT = s2(0)
                        AMOUNT = s2(1)
                        [DATE] = s2(2)
                        TERMINAL = s2(3)
                        RECEIPT = s2(4)
                        TELCELL_REF = s2(5)
                        PRV_REF = s2(6)

                        'Checking Dublicates
                        If L.Exists(Function(x) x.TELCELL_REF = TELCELL_REF) = False Then
                            'Adding Item
                            L.Add(New CSV(ACCOUNT, AMOUNT, [DATE], TERMINAL, RECEIPT, TELCELL_REF, PRV_REF))
                        End If

                    End If

                    i += 1
                End While
                r.Close()
            Next

            'Setting DataSource
            Grid1.DataSource = L

            'Array For MIN & MAX Dates
            Dim d(L.Count - 1) As Date

            For i As Integer = 0 To L.Count - 1
                'Set Array Values
                d(i) = CDate(L.Item(i).DATE)

                'Calculating Amount
                If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 1 Then Shtrikh_SUM += L.Item(i).AMOUNT
                If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 2 Then TAMA_SUM += L.Item(i).AMOUNT
                If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 3 Then MK_SUM += L.Item(i).AMOUNT
                If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 4 Then TOUCH_SUM += L.Item(i).AMOUNT

            Next

            MIN_DATE = d.Min.ToString("dd.MM.yyyy")
            MIN_DATE2 = d.Min
            MAX_DATE = d.Max.ToString("dd.MM.yyyy")
            MAX_DATE2 = d.Max

            TextBox6.Text = "Միջակայք " & MIN_DATE & " - " & MAX_DATE

            TextBox1.Text = "Շտրիխ " & Shtrikh_SUM
            TextBox2.Text = "Տամա " & TAMA_SUM
            TextBox3.Text = "ՄՔ " & MK_SUM
            TextBox4.Text = "Տոչ " & TOUCH_SUM
            TextBox5.Text = "Ընդհանուր " & Shtrikh_SUM + TAMA_SUM + MK_SUM + TOUCH_SUM

            Button2.Enabled = True
            Button1.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim L_SUM As Decimal = 0
            Dim L2 As New List(Of CSV)

            For i As Integer = 0 To L.Count - 1
                If RadioButton1.Checked = True Then
                    If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 1 Then
                        L2.Add(New CSV(L.Item(i).ACCOUNT, L.Item(i).AMOUNT, L.Item(i).DATE, L.Item(i).TERMINAL, L.Item(i).RECEIPT, L.Item(i).TELCELL_REF, L.Item(i).PRV_REF))
                    End If
                ElseIf RadioButton2.Checked = True Then
                    If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 2 Then
                        L2.Add(New CSV(L.Item(i).ACCOUNT, L.Item(i).AMOUNT, L.Item(i).DATE, L.Item(i).TERMINAL, L.Item(i).RECEIPT, L.Item(i).TELCELL_REF, L.Item(i).PRV_REF))
                    End If
                ElseIf RadioButton3.Checked = True Then
                    If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 3 Then
                        L2.Add(New CSV(L.Item(i).ACCOUNT, L.Item(i).AMOUNT, L.Item(i).DATE, L.Item(i).TERMINAL, L.Item(i).RECEIPT, L.Item(i).TELCELL_REF, L.Item(i).PRV_REF))
                    End If
                ElseIf RadioButton4.Checked = True Then
                    If Microsoft.VisualBasic.Right(L.Item(i).ACCOUNT, 1) = 4 Then
                        L2.Add(New CSV(L.Item(i).ACCOUNT, L.Item(i).AMOUNT, L.Item(i).DATE, L.Item(i).TERMINAL, L.Item(i).RECEIPT, L.Item(i).TELCELL_REF, L.Item(i).PRV_REF))
                    End If
                End If
            Next

            Dim c As Byte

            If RadioButton1.Checked = True Then
                L_SUM = Shtrikh_SUM
                c = 1
            ElseIf RadioButton2.Checked = True Then
                L_SUM = TAMA_SUM
                c = 2
            ElseIf RadioButton3.Checked = True Then
                L_SUM = MK_SUM
                c = 3
            ElseIf RadioButton4.Checked = True Then
                L_SUM = TOUCH_SUM
                c = 4
            End If

            Dim d As Date = DateAdd(DateInterval.Day, 1, CDate(MAX_DATE2))

            Dim dt As DataTable = iDB.LoadTelCellData(MIN_DATE2, d, c)

            Dim Hastatvac_Vchar As Decimal = 0
            Dim CHastatvac_Vchar As Decimal = 0

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("AccseptedPayment") = 1 Then
                    Hastatvac_Vchar += dt.Rows(i)("amount")
                Else
                    CHastatvac_Vchar += dt.Rows(i)("amount")
                End If
            Next

            Dim f As New TelCellSetter
            With f
                .DataGridView1.DataSource = L2
                .DataGridView2.DataSource = dt
                .TextBox4.Text = "Հաստատված՝ " & Hastatvac_Vchar
                .TextBox3.Text = "Չաստատված՝ " & CHastatvac_Vchar
                '.TextBox1.Text = TextBox6.Text
                .TextBox2.Text = L_SUM
                .ShowDialog()
                .Dispose()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Class

Public Class CSV

    Public Sub New(ByVal _ACCOUNT As String, ByVal _AMOUNT As String, ByVal _DATE As String, ByVal _TERMINAL As String, ByVal _RECEIPT As String, ByVal _TELCELL_REF As String, ByVal _PRV_REF As String)
        ACCOUNT = _ACCOUNT
        AMOUNT = _AMOUNT
        [DATE] = _DATE
        TERMINAL = _TERMINAL
        RECEIPT = _RECEIPT
        TELCELL_REF = _TELCELL_REF
        PRV_REF = _PRV_REF
    End Sub

    Public Property ACCOUNT As String
    Public Property AMOUNT As String
    Public Property [DATE] As String
    Public Property TERMINAL As String
    Public Property RECEIPT As String
    Public Property TELCELL_REF As String
    Public Property PRV_REF As String

End Class