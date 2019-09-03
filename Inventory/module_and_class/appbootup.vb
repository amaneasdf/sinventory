Imports MadMilkman.Ini
Imports System.IO

Module appbootup
    'Public Structure ConfigKeyCollection
    '    Private keycoll As List(Of KeyValuePair(Of String, String))

    '    Public Function Count() As Integer
    '        Return keycoll.Count
    '    End Function


    'End Structure

    Public Function getSetting(SettingName As String, Optional ByRef Msg As String = Nothing) As IniSection
        If String.IsNullOrWhiteSpace(SettingName) Then
            Throw New ArgumentNullException("Setting name cannot be empty")
        End If

        Dim _retval As IniSection = Nothing
        Dim options As New IniOptions() With {.SectionNameCaseSensitive = True, .KeyNameCaseSensitive = True}
        Dim inifile As New IniFile(options)

        Try
            inifile.Load(getConfigFile)
            If Not inifile.Sections.Contains(SettingName) Then
                Throw New IndexOutOfRangeException("Config section named [" & SettingName & "] cannot be found")
            End If
            _retval = inifile.Sections(SettingName)
            Msg = "SUCCESS"

        Catch ex As Exception
            logError(ex, True)
            Msg = "ERROR : " & ex.Message
        End Try

        Return _retval
    End Function

    Public Function getConnectionSetting(Optional ByRef Msg As String = Nothing) As cnction
        Dim _retval As New cnction
        Dim _connSet As Integer = 0
        Dim _connNm As String = ""
        Dim _ConfSect As IniSection = getSetting("App", Msg)

        If Msg <> "SUCCESS" Then
            Throw New Exception(Msg)
        End If

        If Not _ConfSect.Keys.Contains("Conn") Then

        End If

        Dim _connCnf As IniKey = _ConfSect.Keys("Conn")

        If Integer.TryParse(_connCnf.Value, _connSet) And {0, 1, 2}.Contains(_connCnf.Value) Then
            Select Case _connSet
                Case 0
                    _connNm = "switch"
                Case 1
                    _connNm = "network"
                Case 2
                    _connNm = "local"
            End Select
        Else
            _connNm = _connCnf.Value
        End If

        If Not String.IsNullOrWhiteSpace(_connNm) Then
            _ConfSect = getSetting(_connNm, Msg)

            If Msg <> "SUCCESS" Then
                Throw New Exception(Msg)
            End If

        Else
            Msg = "Error : config value is empty"
            Throw New Exception("config value is empty")
        End If

        Return _retval
    End Function
End Module
