Public Class changeGPRSCode

    Private Sub txtOldGPRS_TextChanged(sender As Object, e As EventArgs) Handles txtOldGPRS.TextChanged
        Try
            If cOrange.Checked AndAlso txtOldGPRS.Text.Trim.Length <> 13 Then
                txtIP.Text = String.Empty
                txtEcr.Text = String.Empty
                txtHVHH.Text = String.Empty
                txtClient.Text = String.Empty
                txtSupporter.Text = String.Empty
                Exit Sub
            ElseIf cViva.Checked AndAlso ((txtOldGPRS.Text.Trim.Length <> 19 And cF1.Checked = False) _
                                          OrElse (txtOldGPRS.Text.Trim.Length <> 20 And cF1.Checked = True)) Then
                txtIP.Text = String.Empty
                txtEcr.Text = String.Empty
                txtHVHH.Text = String.Empty
                txtClient.Text = String.Empty
                txtSupporter.Text = String.Empty
                Exit Sub
            ElseIf cBeeline.Checked AndAlso txtOldGPRS.Text.Trim.Length <> 19 Then
                txtIP.Text = String.Empty
                txtEcr.Text = String.Empty
                txtHVHH.Text = String.Empty
                txtClient.Text = String.Empty
                txtSupporter.Text = String.Empty
                Exit Sub
            End If

            Dim oGprs As String = String.Empty

            If cOrange.Checked = True Then
                oGprs = "8937410" & txtOldGPRS.Text.Trim
            ElseIf cViva.Checked = True Then
                oGprs = Microsoft.VisualBasic.Left(txtOldGPRS.Text.Trim, 18)
            ElseIf cBeeline.Checked = True Then
                oGprs = Microsoft.VisualBasic.Left(txtOldGPRS.Text.Trim, 18)
            End If

            Dim dt As DataTable = iDB.GetGprsClientInfoBySerial(oGprs)

            If dt.Rows.Count = 0 Then
                txtIP.Text = String.Empty
                txtEcr.Text = String.Empty
                txtHVHH.Text = String.Empty
                txtClient.Text = String.Empty
                txtOldGPRS.Text = String.Empty
                txtSupporter.Text = String.Empty
                Throw New Exception("Տվյալներ չեն ստացվել")
            End If

            txtNewGPRS.Enabled = True

            txtIP.Text = dt.Rows(0)("IP")
            txtEcr.Text = dt.Rows(0)("ECR")
            txtHVHH.Text = dt.Rows(0)("HVHH")
            txtClient.Text = dt.Rows(0)("CompanyName")
            txtSupporter.Text = dt.Rows(0)("Company")

            If txtEcr.Text <> txtHDM.Text Then txtNewGPRS.Enabled = False : Throw New Exception("ՀԴՄ-ի GPRS քարտը սխալ է")

            txtNewGPRS.Text = String.Empty
            txtNewGPRS.Focus()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub txtNewGPRS_TextChanged(sender As Object, e As EventArgs) Handles txtNewGPRS.TextChanged
        Try
            If cOrange2.Checked AndAlso txtNewGPRS.Text.Trim.Length <> 13 Then
                Exit Sub
            ElseIf cViva2.Checked AndAlso ((txtNewGPRS.Text.Trim.Length <> 19 AndAlso cF2.Checked = False) _
                                           OrElse (txtNewGPRS.Text.Trim.Length <> 20 AndAlso cF2.Checked = True)) Then
                Exit Sub
            ElseIf cBeeline2.Checked AndAlso txtNewGPRS.Text.Trim.Length <> 19 Then
                Exit Sub
            End If

            Dim oGP As String = String.Empty
            Dim nGP As String = String.Empty

            If cOrange.Checked Then
                If txtOldGPRS.Text.Trim.Length <> 13 Then Throw New Exception("Հին GPRS-ի կոդը լրիվ գրված չէ")
                oGP = "8937410" & txtOldGPRS.Text.Trim
            ElseIf cViva.Checked Then
                oGP = Microsoft.VisualBasic.Left(txtOldGPRS.Text.Trim, 18)
            Else
                oGP = Microsoft.VisualBasic.Left(txtOldGPRS.Text.Trim, 18)
            End If

            If cOrange2.Checked Then
                If txtNewGPRS.Text.Trim.Length <> 13 Then Throw New Exception("Նոր GPRS-ի կոդը լրիվ գրված չէ")
                nGP = "8937410" & txtNewGPRS.Text.Trim
            ElseIf cViva2.Checked Then
                nGP = Microsoft.VisualBasic.Left(txtNewGPRS.Text.Trim, 18)
            Else
                nGP = Microsoft.VisualBasic.Left(txtNewGPRS.Text.Trim, 18)
            End If

            If txtNewGPRS.Text.Trim = txtOldGPRS.Text.Trim Then Throw New Exception("Կոդերը կրկնվում են")

            iDB.ChangeEcrGprs(oGP, nGP, iUser.LoginName)

            MsgBox("Գործողությունը կատարվեց", MsgBoxStyle.Information, My.Application.Info.Title)

            btnClose.Enabled = True
            'btnPrint.Enabled = True

            txtHDM.Enabled = False
            txtOldGPRS.Enabled = False
            txtNewGPRS.Enabled = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub changeGPRSCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CheckPermission2("0662FC6C35F5455081F286DB04101486") = False Then txtOldGPRS.Enabled = False : txtNewGPRS.Enabled = False : txtHDM.Enabled = False
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            My.Application.DoEvents()

            Dim nGP As String = String.Empty
            If cOrange2.Checked Then
                If txtNewGPRS.Text.Trim.Length <> 13 Then Throw New Exception("Նոր GPRS-ի կոդը լրիվ գրված չէ")
                nGP = "8937410" & txtNewGPRS.Text.Trim
            ElseIf cViva2.Checked Then
                nGP = Microsoft.VisualBasic.Left(txtNewGPRS.Text.Trim, 18)
            Else
                nGP = Microsoft.VisualBasic.Left(txtNewGPRS.Text.Trim, 18)
            End If

            Me.Close()
        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            GC.Collect()
        End Try

    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            My.Application.DoEvents()

            Dim nGP As String = String.Empty
            If cOrange2.Checked Then
                If txtNewGPRS.Text.Trim.Length <> 13 Then Throw New Exception("Նոր GPRS-ի կոդը լրիվ գրված չէ")
                nGP = "8937410" & txtNewGPRS.Text.Trim
            ElseIf cViva2.Checked Then
                nGP = Microsoft.VisualBasic.Left(txtNewGPRS.Text.Trim, 18)
            Else
                nGP = Microsoft.VisualBasic.Left(txtNewGPRS.Text.Trim, 18)
            End If

            Dim dt As DataTable = iDB.GprsAkt(nGP)

            If dt.Rows.Count <> 1 Then Throw New Exception("Տվյալներ ստանալու սխալ")

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\GprsAkt"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\" & Now.Year & Now.Month & Now.Day
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            Dim rund As New Random
            Dim f As String = strPath & "\Akt_" & rund.Next(0, Integer.MaxValue) & ".xlsx"
            If IO.File.Exists(f) Then Throw New Exception("Նույն անունով ֆայլ է հայտնաբերվել")
            My.Computer.FileSystem.WriteAllBytes(f, My.Resources.gprsAkt, False)

            'Export To Excel
            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)
            'Dont Show Error Messages
            xlApp.DisplayAlerts = False

            With sheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""

                .PrintArea = ""
                'Set Paper Size To A4
                .PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4

                '.Zoom = 80

                'Change Options
                .CenterHorizontally = True
                .CenterVertically = False
                .ScaleWithDocHeaderFooter = True
                .AlignMarginsHeaderFooter = False

                'Set Margins
                '.LeftMargin = xlApp.InchesToPoints(0.28)
                '.TopMargin = xlApp.InchesToPoints(0.16)
                '.BottomMargin = xlApp.InchesToPoints(0.16)
                '.HeaderMargin = xlApp.InchesToPoints(0.16)
                '.RightMargin = xlApp.InchesToPoints(0.24)
                '.FooterMargin = xlApp.InchesToPoints(0.16)
            End With

            sheet.Range("H2").Value = Microsoft.VisualBasic.Right("00" & Now.Day, 2) & "." & Microsoft.VisualBasic.Right("00" & Now.Month, 2) & "." & Now.Year
            sheet.Range("A4").Value = "Տեղեկացնում ենք Ձեզ, որ " & dt.Rows(0)("AddressName") & " հասցեում գործող " & dt.Rows(0)("CompanyName") & "-ին պատկանող (ՀՎՀՀ " & dt.Rows(0)("HVHH") & ", ՄԳՀ " & dt.Rows(0)("MGH") & ") MF 2351 մոդելի հսկիչ դրամարկղային մեքենայի մեջ (գործարանային համար " & _
                        dt.Rows(0)("ECR") & ") կատարվել է համարի  և IP հասցեի փոփոխություն։ Խնդրում ենք Հարկատու 3 ծրագրում մուտքագրել նոր GPRS-ը և IP հասցեն:"
            sheet.Range("B15").Value = dt.Rows(0)("IP")
            sheet.Range("B17").Value = dt.Rows(0)("gprs")
            sheet.Range("A23").Value = dt.Rows(0)("Company")
            sheet.Range("F23").Value = dt.Rows(0)("Director")

            sheet.PrintOutEx(1, 1, 1, False, strPrinter, False, True, "", False)

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            btnClose.Enabled = True
            btnPrint.Enabled = False

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        Finally
            GC.Collect()
        End Try
    End Sub

End Class