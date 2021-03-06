﻿Imports MySql.Data.MySqlClient

Module dbproceduralstuff
    Private Const connstring As String = "Server={0};Database={1};Uid={2};Pwd={3};Allow User Variables=TRUE"
    Private conn As MySqlConnection
    Private cmd As New MySqlCommand
    Public rd As MySqlDataReader
	
    Public Sub setConn(host As String, database As String, userid As String, password As String, Optional ByRef MySqlConn As MySqlConnection = Nothing)
        conn = New MySqlConnection(String.Format(connstring, host, database, userid, password))
    End Sub

    Public Function getConn() As MySqlConnection
        Return conn
    End Function

    Public Sub op_con(Optional skipErrMsg As Boolean = False)
        If conn.State = ConnectionState.Closed Then
            For x = 0 To 2
                Try
                    consoleWriteLine("try " & x)
                    conn.Open()
                    If conn.State = ConnectionState.Open Then
                        Exit For
                    End If
                Catch ex As Exception
                    If x = 2 Then
                        If skipErrMsg = False Then
                            MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString, "Tidak dapat terhubung ke server"),
                                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        logError(ex, skipErrMsg)
                    End If
                End Try
            Next
        End If
    End Sub

    Public Sub cl_con()
        If conn.State = ConnectionState.Open Then
            Try
                conn.Close()
            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}", ex.Message))
                logError(ex)
            End Try
        End If
    End Sub

    Public Function startTrans(queryArr As List(Of String), Optional showErrMsg As Boolean = True) As Boolean
        Dim ctrans As New MySqlCommand
        Dim transact As MySqlTransaction = conn.BeginTransaction()
        Dim querycheck As Boolean = False
        Dim count As Integer = 0

        ctrans.Connection = conn
        ctrans.Transaction = transact
        For Each query As String In queryArr
            Try
                consoleWriteLine(query)
                ctrans.CommandText = query
                Dim i = ctrans.ExecuteNonQuery()
                consoleWriteLine(i)
                count += i
                querycheck = True
            Catch ex As Exception
                If showErrMsg = True Then
                    consoleWriteLine(String.Format("{0}:{1}", ex.GetType.ToString, ex.Message))
                    MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString, "Terjadi Kesalahan"),
                                                 Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                logError(ex)
                querycheck = False
                Exit For
            End Try
        Next

        If querycheck = True Then
            Try
                consoleWriteLine(count & "ROWS")
                transact.Commit()
            Catch ex As Exception
                If showErrMsg = True Then
                    consoleWriteLine(String.Format("{0}:{1}", ex.GetType.ToString, ex.Message))
                    MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString, "Terjadi Kesalahan"),
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                logError(ex)
                querycheck = False
            End Try
        End If

        If querycheck = False Then
            MessageBox.Show(String.Format("Error. {0}", "Terjadi Kesalahan, Transaksi tidak dapat disimpan"),
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                transact.Rollback()
            Catch ex As Exception
                If showErrMsg = True Then
                    consoleWriteLine(String.Format("{0}:{1}", ex.GetType.ToString, ex.Message))
                    MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString, "Terjadi Kesalahan"),
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                logError(ex)
                querycheck = False
            End Try
        End If

        Return querycheck
    End Function

    Public Function commnd(ByVal x As String) As Boolean
        Dim check As Boolean = False
        op_con()
        Try
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = x
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            check = True
        Catch ex As Exception
            consoleWriteLine(String.Format("Error: {0}", ex.Message))
            MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString & ex.Message, "Terjadi Kesalahan"),
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            logError(ex)
            check = False
        End Try
        Return check
    End Function

    Public Sub dbSelect(query As String, Optional skipErrMsg As Boolean = False)
        op_con()
        Try
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            rd = cmd.ExecuteReader
        Catch ex As Exception
            consoleWriteLine(String.Format("Error: {0}", ex.Message))
            If skipErrMsg = False Then
                MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString & ex.Message, "Terjadi Kesalahan"),
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            logError(ex, skipErrMsg)
        End Try
    End Sub

    Public Sub readcommd(query As String, Optional skipErrMsg As Boolean = False)
        Try
            dbSelect(query, skipErrMsg)
            If rd IsNot Nothing Then
                rd.Read()
            End If
        Catch ex As Exception
            consoleWriteLine(String.Format("Error: {0}", ex.Message))
            logError(ex, skipErrMsg)
            Try
                If rd.IsClosed = False Then
                    rd.Close()
                End If
            Catch ex2 As Exception
                logError(ex2, True)
            End Try
        End Try
    End Sub

    Public Function checkdata(table As String, param As String, paramCollumn As String) As Boolean
        Dim query As String = "select * from " & table & " where " & paramCollumn & "=" & param
        Dim x As Boolean = False
        consoleWriteLine(query)

        op_con()
        readcommd(query)
        If rd.HasRows Then
            x = True
        Else
            x = False
        End If
        If rd.IsClosed = False Then
            rd.Close()
        End If

        Return x
    End Function

    Public Function getDataTablefromDB(query As String, Optional ErrorMsg As Boolean = False) As DataTable
        op_con()
        consoleWriteLine(query)
        Dim _cmd As New MySqlCommand(query, conn)
        Dim data_adpt As New MySqlDataAdapter(_cmd)
        Dim dtable As New DataTable
        Try
            data_adpt.Fill(dtable)
            data_adpt.Dispose()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString & ex.Message, "Terjadi Kesalahan, data tidak dapat ditemukan"),
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            logError(ex, ErrorMsg)
        End Try
        Return dtable
    End Function

    'Private Function insertDataquerybuilt(table As String, data As Object(), dataCol As String()) As String
    '    Const querytemp As String = "insert into {0}({1}) values({2})"
    '    Dim key As String = String.Join(",", dataCol)
    '    Dim i As Integer = 0
    '    For Each x As Object In data
    '        If TypeOf (x) Is String Then
    '            data(i) = "'" & x & "'"
    '        End If
    '        Console.WriteLine(data(i))
    '        i += 1
    '    Next
    '    Dim val As String = String.Join(",", data)
    '    Dim querybuilt As String = String.Format(querytemp, table, key, val)
    '    'Console.WriteLine(key)
    '    'Console.WriteLine(val)
    '    'Console.WriteLine(querybuilt)
    '    Return querybuilt
    'End Function

    ''insert if all data is string
    'Public Function insertData(table As String, data As Object(), dataCol As String()) As Boolean
    '    Dim query As String = insertDataquerybuilt(table, data, dataCol)
    '    op_con()
    '    Return commnd(query)
    'End Function
End Module
