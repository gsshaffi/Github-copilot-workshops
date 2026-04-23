' Legacy VB.NET data export utility
' Exercise: Use Copilot to convert this to modern C#
' This is typical of legacy code found in estate agency systems

Imports System.Data.SqlClient
Imports System.IO

Module DataExport

    Private ConnectionString As String = "Server=localhost;Database=ConnellsDB;Trusted_Connection=True;"

    Sub Main()
        Console.WriteLine("Connells Property Data Export Utility")
        Console.WriteLine("=====================================")
        
        Dim exportType As String = ""
        Console.Write("Enter export type (properties/valuations/viewings): ")
        exportType = Console.ReadLine()
        
        Select Case exportType.ToLower()
            Case "properties"
                ExportProperties()
            Case "valuations"
                ExportValuations()
            Case "viewings"
                ExportViewings()
            Case Else
                Console.WriteLine("Unknown export type: " & exportType)
        End Select
    End Sub

    Sub ExportProperties()
        Dim conn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM Properties WHERE Status = 'Available' ORDER BY ListedDate DESC", conn)
        
        Try
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            
            Dim outputPath As String = "C:\Exports\properties_" & DateTime.Now.ToString("yyyyMMdd") & ".csv"
            Dim sw As New StreamWriter(outputPath)
            
            sw.WriteLine("Id,Address,Postcode,Town,Price,Bedrooms,Type,Status,ListedDate")
            
            While reader.Read()
                Dim line As String = ""
                line = line & reader("Id").ToString() & ","
                line = line & """" & reader("Address").ToString() & ""","
                line = line & reader("Postcode").ToString() & ","
                line = line & reader("Town").ToString() & ","
                line = line & reader("Price").ToString() & ","
                line = line & reader("Bedrooms").ToString() & ","
                line = line & reader("PropertyType").ToString() & ","
                line = line & reader("Status").ToString() & ","
                line = line & CDate(reader("ListedDate")).ToString("dd/MM/yyyy")
                sw.WriteLine(line)
            End While
            
            sw.Close()
            reader.Close()
            conn.Close()
            
            Console.WriteLine("Export complete: " & outputPath)
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    Sub ExportValuations()
        ' TODO: Implement valuation export
        Console.WriteLine("Valuation export not yet implemented")
    End Sub

    Sub ExportViewings()
        ' TODO: Implement viewings export
        Console.WriteLine("Viewings export not yet implemented")
    End Sub

End Module
