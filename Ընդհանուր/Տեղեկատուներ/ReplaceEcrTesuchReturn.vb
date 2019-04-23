Public Class ReplaceEcrTesuchReturn

    Friend Ecr As String
    Friend ID As Integer

    'print akt
    Private Function Akt() As Boolean
        Dim b As Boolean = False
        Try

            Dim dt As DataTable = iDB.IssueEcrToTesuch2(Ecr)
            If dt.Rows.Count = 0 Then Throw New Exception("Տվյալներ չեն ստացվել")

            Dim Support = New With {.Company = dt.Rows(0)("Company"), .Director = dt.Rows(0)("Director"), .ECR = dt.Rows(0)("ECR")}

            Dim strPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\HDM AKT"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)
            strPath &= "\Ecr"
            If IO.Directory.Exists(strPath) = False Then IO.Directory.CreateDirectory(strPath)

            Dim r As New Random
            Dim val As Integer

            val = r.Next(0, Integer.MaxValue)

            'Make file
            Dim f As String = strPath
            f = f & "\akt_" & val & ".xlsx"

            My.Computer.FileSystem.WriteAllBytes(f, My.Resources.Ecr_Rep_Akt_2, False)

            'Export
            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(f)
            Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)

            sheet.Range("F2").Value = Now.Date.ToShortDateString & " թ."
            sheet.Range("F20").Value = Now.Date.ToShortDateString & " թ."

            sheet.Range("A6").Value = "Մենք` ներքոստորագրյալներս, սույն ակտով հաստատում ենք, որ " & Support.Company & "-ի աշխատակից                   վերադարձնում է, իսկ " & Support.Company & "-ն՝ ի դեմս տնօրեն " & Support.Director & "ի, հետ է ընդունում հետևյալ հսկիչ դրամարկղային մեքենան, որը տրամադրվել էր ընկերության հաճախորդներին՝ փոխարինման տրամադրելու նպատակով:"
            sheet.Range("A24").Value = "Մենք` ներքոստորագրյալներս, սույն ակտով հաստատում ենք, որ " & Support.Company & "-ի աշխատակից                   վերադարձնում է, իսկ " & Support.Company & "-ն՝ ի դեմս տնօրեն " & Support.Director & "ի, հետ է ընդունում հետևյալ հսկիչ դրամարկղային մեքենան, որը տրամադրվել էր ընկերության հաճախորդներին՝ փոխարինման տրամադրելու նպատակով:"

            sheet.Range("B11").Value = "MF2351 մոդելի " & Support.ECR & " հսկիչ դրամարկղային մեքենա"
            sheet.Range("B29").Value = "MF2351 մոդելի " & Support.ECR & " հսկիչ դրամարկղային մեքենա"

            wbk.Close(SaveChanges:=True)
            xlApp.Quit()
            xlApp = Nothing

            Call Shell("explorer /select," & f, AppWinStyle.NormalFocus)

            b = True

            Return b

        Catch ex As ExceptionClass
            Return b
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
            Return b
        Catch ex As Exception
            Call SoftException(ex)
            Return b
        Finally
            GC.Collect()
        End Try
    End Function

    'Add Tesuch
    Private Sub btnRet_Click(sender As Object, e As EventArgs) Handles btnRet.Click
        Try
            'print akt
            If Akt() = True Then
                If MsgBox("Եթե ակտը տպվել է սեղմեք OK", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, My.Application.Info.Title) = MsgBoxResult.Ok Then

                    'save to db
                    iDB.ReturnTesuchEcr(ID)

                    MsgBox("Տվյալը հաջողությամբ փոփոխվեցին բազայում", MsgBoxStyle.Information, My.Application.Info.Title)

                    Me.Close()
                Else
                    MsgBox("Գործողությունը չեղարկվել է", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End If
            Else
                MsgBox("Ակտը չի տպվել", MsgBoxStyle.Critical, My.Application.Info.Title)
            End If

        Catch ex As ExceptionClass
        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub ReplaceEcrTesuchAdd_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtEcr.Text = Ecr
    End Sub

End Class