Imports System.Drawing.Printing

Public Class SelectPrinter

    Private Sub _Printer_Load()
        On Error Resume Next
        PrinterList.Items.Clear()
        Dim pkInstalledPrinters As String
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            PrinterList.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters
        If PrinterList.Items.Count > 0 Then PrinterList.SelectedItem = strPrinter
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            If PrinterList.SelectedIndex = -1 Then MsgBox("Տպիչը նշված չէ", MsgBoxStyle.Exclamation, My.Application.Info.Title) : Exit Sub
            strPrinter = PrinterList.SelectedItem
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\ՀԴՄ APP", "Printer", strPrinter)
            Me.Close()
        Catch ex As ExceptionClass

        Catch ex As System.Data.SqlClient.SqlException
            Call SQLException(ex)
        Catch ex As Exception
            Call SoftException(ex)
        End Try
    End Sub
    Private Sub SelectPrinter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call _Printer_Load()
    End Sub

End Class