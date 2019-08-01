Imports System.Runtime.CompilerServices

''' <summary>
''' Contains methods that extend the <see cref="DataTable"/> class.
''' </summary>
Public Module DataTableExtensions

    ''' <summary>
    ''' Returns a delimited <see cref="String" /> containing the field values from the rows a <see cref="DataTable" />.
    ''' </summary>
    ''' <param name="source">
    ''' The input <see cref="DataTable" />.
    ''' </param>
    ''' <param name="includeHeaders">
    ''' <b>True</b> to include a row of column headers; otherwise, <b>False</b>
    ''' </param>
    ''' <param name="rowDelimiter">
    ''' The delimiter placed between rows. the default value is a line break comprising a carriage return and a line feed.
    ''' </param>
    ''' <param name="fieldDelimiter">
    ''' The delimiter placed between field values. the default value is a comma.
    ''' </param>
    ''' <returns>
    ''' A <see cref="String"/> containing the field values from the rows of the table separated by the specified delimiters.
    ''' </returns>
    <Extension>
    Public Function ToCsv(source As DataTable,
                          includeHeaders As Boolean,
                          Optional rowDelimiter As String = ControlChars.NewLine,
                          Optional fieldDelimiter As String = ",") As String
        Dim rows = source.Rows.
                          Cast(Of DataRow)().
                          Select(Function(row) row.ToCsv(fieldDelimiter))

        If includeHeaders Then
            Dim headers = String.Join(fieldDelimiter,
                                      source.Columns.
                                             Cast(Of DataColumn)().
                                             Select(Function(column) column.ColumnName))

            rows = {headers}.Concat(rows)
        End If

        Return String.Join(rowDelimiter, rows)
    End Function

    ''' <summary>
    ''' Returns a delimited <see cref="String" /> containing the field values from the rows a <see cref="DataTable" />.
    ''' </summary>
    ''' <param name="source">
    ''' The input <see cref="DataTable" />.
    ''' </param>
    ''' <param name="includeHeaders">
    ''' <b>True</b> to include a row of column headers; otherwise, <b>False</b>
    ''' </param>
    ''' <param name="quoteStrings">
    ''' <b>True</b> to wrap <see cref="String"/> values in double-quotes; otherwise, <b>False</b>.
    ''' If double-quotes are added, double-quotes within text are escaped with another double-quote.
    ''' </param>
    ''' <param name="rowDelimiter">
    ''' The delimiter placed between rows. the default value is a line break comprising a carriage return and a line feed.
    ''' </param>
    ''' <param name="fieldDelimiter">
    ''' The delimiter placed between field values. the default value is a comma.
    ''' </param>
    ''' <returns>
    ''' A <see cref="String"/> containing the field values from the rows of the table separated by the specified delimiters.
    ''' </returns>
    <Extension>
    Public Function ToCsv(source As DataTable,
                          includeHeaders As Boolean,
                          quoteStrings As Boolean,
                          Optional rowDelimiter As String = ControlChars.NewLine,
                          Optional fieldDelimiter As String = ",") As String
        Dim rows = source.Rows.
                          Cast(Of DataRow)().
                          Select(Function(row) row.ToCsv(quoteStrings, fieldDelimiter))

        If includeHeaders Then
            Dim headers = String.Join(fieldDelimiter,
                                      source.Columns.
                                             Cast(Of DataColumn)().
                                             Select(Function(column) If(quoteStrings,
                                                                        """" & CStr(column.ColumnName).Replace("""", """""") & """",
                                                                        column.ColumnName)))

            rows = {headers}.Concat(rows)
        End If

        Return String.Join(rowDelimiter, rows)
    End Function

End Module
