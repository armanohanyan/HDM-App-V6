Imports System.Collections.Generic
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class PdfMerge
    Private m_baseFont As BaseFont
    Private m_enablePagination As Boolean = False
    Private ReadOnly m_documents As List(Of PdfReader)
    Private totalPages As Integer

    Public Property BaseFont() As BaseFont
        Get
            Return m_baseFont
        End Get
        Set(value As BaseFont)
            m_baseFont = value
        End Set
    End Property

    Public Property EnablePagination() As Boolean
        Get
            Return m_enablePagination
        End Get
        Set(value As Boolean)
            m_enablePagination = value
            If value AndAlso m_baseFont Is Nothing Then
                m_baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
            End If
        End Set
    End Property

    Public ReadOnly Property Documents() As List(Of PdfReader)
        Get
            Return m_documents
        End Get
    End Property

    Public Sub AddDocument(filename As String)
        m_documents.Add(New PdfReader(filename))
    End Sub
    Public Sub AddDocument(pdfStream As Stream)
        m_documents.Add(New PdfReader(pdfStream))
    End Sub
    Public Sub AddDocument(pdfContents As Byte())
        m_documents.Add(New PdfReader(pdfContents))
    End Sub
    Public Sub AddDocument(pdfDocument As PdfReader)
        m_documents.Add(pdfDocument)
    End Sub

    Public Sub Merge(outputFilename As String)
        Merge(New FileStream(outputFilename, FileMode.Create))
    End Sub
    Public Sub Merge(outputStream As Stream)
        If outputStream Is Nothing OrElse Not outputStream.CanWrite Then
            Throw New Exception("OutputStream es nulo o no se puede escribir en éste.")
        End If

        Dim newDocument As Document = Nothing
        Try
            newDocument = New Document()

            'newDocument.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())

            Dim pdfWriter__1 As PdfWriter = PdfWriter.GetInstance(newDocument, outputStream)

            newDocument.Open()
            Dim pdfContentByte__2 As PdfContentByte = pdfWriter__1.DirectContent

            If EnablePagination Then
                m_documents.ForEach(Sub(doc As PdfReader) totalPages += doc.NumberOfPages)
            End If

            Dim currentPage As Integer = 1
            For Each pdfReader As PdfReader In m_documents
                For page As Integer = 1 To pdfReader.NumberOfPages
                    newDocument.NewPage()
                    Dim importedPage As PdfImportedPage = pdfWriter__1.GetImportedPage(pdfReader, page)
                    pdfContentByte__2.AddTemplate(importedPage, 0, 0)

                    If EnablePagination Then
                        pdfContentByte__2.BeginText()
                        pdfContentByte__2.SetFontAndSize(m_baseFont, 9)
                        pdfContentByte__2.ShowTextAligned(PdfContentByte.ALIGN_CENTER, String.Format("{0} de {1}", System.Math.Max(System.Threading.Interlocked.Increment(currentPage), currentPage - 1), totalPages), 520, 5, 0)
                        pdfContentByte__2.EndText()
                    End If
                Next
            Next
        Finally
            outputStream.Flush()
            If newDocument IsNot Nothing Then
                newDocument.Close()
            End If
            outputStream.Close()
        End Try
    End Sub

    Public Sub New()
        m_documents = New List(Of PdfReader)()
    End Sub

End Class