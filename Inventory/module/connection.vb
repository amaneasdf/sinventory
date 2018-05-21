'Imports System.Data.SqlClient
'Imports System.Data
Imports MySql.Data.MySqlClient

Module dbproceduralstuff
    'Public conn As New SqlConnection("server=(localdb)\MSSQLLocalDB;Integrated Security=true;database=Konveksitest;")
    'Public cmd As New SqlCommand
    'Public rd As SqlDataReader
	Private Const connstring As String = "Server={0};Database={1};Uid={2};Pwd={3};"
    Private conn As MySqlConnection
    Private cmd As New MySqlCommand
    Public rd As MySqlDataReader
	
	Public Sub setConn(host As String, database As String, userid As String, password as String)
        conn = New MySqlConnection(String.Format(connstring, host, database, userid, password))
	End Sub

    Public Function getConn() As MySqlConnection
        Return conn
    End Function

    Public Sub op_con()
        If conn.State = ConnectionState.Closed Then
            Try
                'For x = 0 To 2
                conn.Open()
                '    If conn.State = ConnectionState.Open Then
                '        Exit For
                '    End If
                '    x += 1
                'Next
            Catch ex As Exception
                MessageBox.Show(String.Format("Error {1}: {0}", ex.Message, ex.GetType.ToString))
            End Try
        End If
    End Sub

    Public Sub cl_con()
        If conn.State = ConnectionState.Open Then
            Try
                conn.Close()
            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}", ex.Message))
            End Try
        End If
    End Sub

    Public Function startTrans(queryArr As List(Of String)) As Boolean
        Dim ctrans As New MySqlCommand
        Dim transact As MySqlTransaction = conn.BeginTransaction
        Dim querycheck As Boolean = False

        ctrans.Connection = conn
        ctrans.Transaction = transact
        For Each query As String In queryArr
            Try
                Console.WriteLine(query)
                ctrans.CommandText = query
                ctrans.ExecuteNonQuery()
                querycheck = True
            Catch ex As Exception
                Console.WriteLine(String.Format("{0}:{1}", ex.GetType.ToString, ex.Message))
                querycheck = False
                Exit For
            End Try
        Next

        If querycheck = True Then
            Try
                transact.Commit()
            Catch ex As Exception
                Console.WriteLine(String.Format("{0}:{1}", ex.GetType.ToString, ex.Message))
                querycheck = False
            End Try
        End If

        If querycheck = False Then
            MessageBox.Show("transaksi tidak bisa disimpan")
            transact.Rollback()
        End If

        Return querycheck
    End Function

    Public Function commnd(ByVal x As String) As Boolean
        Console.WriteLine(x)
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
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
            check = False
        End Try
        Return check
    End Function

    Public Sub dbSelect(query As String)
        op_con()
        Try
            Console.WriteLine(query)
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            rd = cmd.ExecuteReader
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub readcommd(query As String)
        Try
            dbSelect(query)
            rd.Read()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            'MsgBox("Data tidak dapat ditemukan" & Environment.NewLine & ex.Message)
        End Try
    End Sub

    Public Function checkdata(table As String, param As String, paramCollumn As String) As Boolean
        Dim query As String = "select * from " & table & " where " & paramCollumn & "=" & param
        Dim x As Boolean = False
        Console.WriteLine(query)
        op_con()
        readcommd(query)
        If rd.HasRows Then
            x = True
        Else
            x = False
        End If
        rd.Close()
        Return x
    End Function

    Public Function getDataTablefromDB(query As String) As DataTable
        op_con()
        Dim data_adpt As New MySqlDataAdapter(query, conn)
        Dim dtable As New DataTable
        Try
            data_adpt.Fill(dtable)
            data_adpt.Dispose()
            conn.Close()
        Catch ex As Exception
            MsgBox("Data tidak dapat ditemukan" & Environment.NewLine & ex.Message)
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
