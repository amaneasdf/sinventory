Imports MySql.Data.MySqlClient

Public Class MySqlThing : Implements IDisposable
    Private Const connstring As String = "Server={0};Database={1};Uid={2};Pwd={3};Allow User Variables=TRUE"
    Private _host As String
    Private _db As String
    Private _Uid As String
    Private _pass As String
    Private conn As MySqlConnection
    Protected disposed As Boolean = False

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        If Not Me.disposed Then
            If disposing Then
                conn.Dispose()
            End If
            For Each x As String In {_host, _db, _Uid, _pass}
                x = String.Empty
            Next
            ' Insert code to free unmanaged resources.  
        End If
        Me.disposed = True
    End Sub

    Public Property ConnectionString As String
        Get
            Return conn.ConnectionString
        End Get
        Set(value As String)
            Dim x = New MySqlConnectionStringBuilder(value)
            _host = x.Server
            _db = x.Database
            _Uid = x.UserID
            _pass = x.Password

            If conn Is Nothing Then
                conn = New MySqlConnection(String.Format(value))
            Else
                conn.ConnectionString = value
            End If
        End Set
    End Property

    Public ReadOnly Property ConnectionState As ConnectionState
        Get
            Return conn.State
        End Get
    End Property


    Public Property Host As String
        Get
            Return _host
        End Get
        Set(value As String)
            _host = value
        End Set
    End Property

    Public Property Database As String
        Get
            Return _db
        End Get
        Set(value As String)
            _db = value
        End Set
    End Property

    Public WriteOnly Property UId As String
        Set(value As String)
            _Uid = value
        End Set
    End Property

    Public WriteOnly Property Password As String
        Set(value As String)
            _pass = value
        End Set
    End Property

    Public ReadOnly Property Connection As MySqlConnection
        Get
            Return conn
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(server As String, db As String, uid As String, pass As String)
        conn = New MySqlConnection(String.Format(connstring, server, db, uid, pass))
        _host = server : _db = db : _Uid = uid : _pass = pass
    End Sub

    Public Sub Open()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
    End Sub

    Public Function OpenAsync() As Task
        Dim x As New TaskCompletionSource(Of Object)
        If Not conn.State = ConnectionState.Open Then
            Try
                conn.Open()
                x.SetResult(Nothing)
            Catch ex As Exception
                x.SetException(ex)
            End Try
        Else
            x.SetResult("Already Open")
        End If
        Return x.Task
    End Function

    Public Function ExecCommand(query As String) As Integer
        Dim retVal As Integer = -1

        Me.Open()
        Dim cmd = New MySqlCommand(query, conn)
        retVal = cmd.ExecuteNonQuery

        Return retVal
    End Function

    Public Async Function ExecCommandAsync(query As String) As Task(Of Integer)
        Dim retVal As Integer = -1
        consoleWriteLine(query)
        Me.Open()
        Dim cmd = New MySqlCommand(query, conn)
        retVal = Await cmd.ExecuteNonQueryAsync

        Return retVal
    End Function

    Public Function ReadCommand(query As String, Optional behavior As System.Data.CommandBehavior = CommandBehavior.Default) As MySqlDataReader
        Dim retVal As MySqlDataReader = Nothing

        Me.Open()
        Dim x = New MySqlCommand(query, conn)
        retVal = x.ExecuteReader(behavior)

        Return retVal
    End Function

    Public Async Function ReadCommandAsync(query As String, Optional behavior As System.Data.CommandBehavior = CommandBehavior.Default) As Task(Of MySqlDataReader)
        Dim retVal As MySqlDataReader = Nothing

        Await Me.OpenAsync
        If conn.State = ConnectionState.Open Then
            Dim x = New MySqlCommand(query, conn)
            Dim _tsk As Task(Of Common.DbDataReader) = x.ExecuteReaderAsync(behavior)
            retVal = Await _tsk
            If _tsk.IsFaulted Then
                Throw _tsk.Exception
            End If
        End If

        Return retVal
    End Function

    Public Function TransactCommand(QueryList As List(Of String)) As Boolean
        If conn Is Nothing Then
            Throw New NullReferenceException("Connection is empty")
        End If

        Dim _ckSw As Boolean = False
        Open()
        If ConnectionState <> Data.ConnectionState.Open Then
            _ckSw = False
        Else
            Using x = conn.BeginTransaction()
                Using _cmd As New MySqlCommand
                    _cmd.Connection = conn : _cmd.Transaction = x
                    For Each q As String In QueryList
                        Try
                            _cmd.CommandText = q : _cmd.ExecuteNonQuery() : _ckSw = True
                        Catch ex As Exception
                            logError(ex, True) : _ckSw = False : Exit For
                        End Try
                    Next

                    If _ckSw Then : Try : x.Commit() : Catch ex As Exception : logError(ex, True) : _ckSw = False : End Try : End If

                    If Not _ckSw Then : Try : x.Rollback() : Catch ex As Exception : logError(ex, True) : _ckSw = False : End Try : End If
                End Using
            End Using
        End If

        Return _ckSw
    End Function

    Public Function GetDataTable(query As String) As DataTable
        If conn Is Nothing Then
            Throw New NullReferenceException("Connection is empty")
        End If
        Dim dtable As New DataTable
        Using _cmd As New MySqlCommand(query, conn)
            Me.Open()
            Using data_adpt As New MySqlDataAdapter(_cmd) : data_adpt.Fill(dtable) : End Using
        End Using
        Return dtable
    End Function

    Public Async Function GetDTAsync(query As String) As Task(Of DataTable)
        Dim _cmd As New MySqlCommand(query, conn)
        Dim dtable As New DataTable
        Try
            Await Me.OpenAsync()
            If Me.conn.State = ConnectionState.Open Then
                Using data_adpt As New MySqlDataAdapter(_cmd)
                    Dim r As Integer = Await data_adpt.FillAsync(dtable)
                End Using
            End If
        Catch ex As Exception
            logError(ex)
        End Try
        Return dtable
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
