Imports System.Runtime.CompilerServices

''' <summary>
''' Contains methods that extend the <see cref="DataRow"/> class.
''' </summary>
Public Module DataRowExtensions

    ''' <summary>
    ''' Returns a delimited <see cref="String" /> containing the field values from a <see cref="DataRow" />.
    ''' </summary>
    ''' <param name="source">
    ''' The input <see cref="DataRow" />.
    ''' </param>
    ''' <param name="delimiter">
    ''' The delimiter placed between field values. the default value is a comma.
    ''' </param>
    ''' <returns>
    ''' A <see cref="String"/> containing the field values from the row separated by the specified delimiter.
    ''' </returns>
    <Extension>
    Public Function ToCsv(source As DataRow, Optional delimiter As String = ",") As String
        Return String.Join(delimiter, source.ItemArray)
    End Function

    ''' <summary>
    ''' Returns a delimited <see cref="String" /> containing the field values from a <see cref="DataRow" />.
    ''' </summary>
    ''' <param name="source">
    ''' The input <see cref="DataRow" />.S
    ''' </param>
    ''' <param name="quoteStrings">
    ''' <b>True</b> to wrap <see cref="String"/> values in double-quotes; otherwise, <b>False</b>.
    ''' If double-quotes are added, double-quotes within text are escaped with another double-quote.
    ''' </param>
    ''' <param name="delimiter">
    ''' The delimiter placed between field values. the default value is a comma.
    ''' </param>
    ''' <returns>
    ''' A <see cref="String"/> containing the field values from the row separated by the specified delimiter.
    ''' </returns>
    <Extension>
    Public Function ToCsv(source As DataRow, quoteStrings As Boolean, Optional delimiter As String = ",") As String
        Dim fieldValues = source.ItemArray

        If quoteStrings Then
            'Wrap any String values in double-quotes and also escape any double-quotes in the String with another double-quote.
            fieldValues = fieldValues.Select(Function(o) If(TypeOf o Is String, """" & CStr(o).Replace("""", """""") & """", o)).ToArray()
        End If

        Return String.Join(delimiter, fieldValues)
    End Function

End Module
