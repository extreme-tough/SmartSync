Public Class SystemUtil
    Public Function GetOSVersion() As String
        Select Case Environment.OSVersion.Platform
            Case PlatformID.Win32S
                Return "Win 3.1"

            Case PlatformID.Win32Windows
                Select Case Environment.OSVersion.Version.Minor
                    Case 0
                        Return "Win95"
                    Case 10
                        Return "Win98"
                    Case 90
                        Return "WinME"
                    Case Else
                        Return "Unknown"
                End Select
            Case PlatformID.Win32NT
                Select Case Environment.OSVersion.Version.Major
                    Case 3
                        Return "NT 3.51"
                    Case 4
                        Return "NT 4.0"
                    Case 5
                        Select Case _
                            Environment.OSVersion.Version.Minor
                            Case 0
                                Return "Windows 2000"
                            Case 1
                                Return "Windows XP"
                            Case 2
                                Return "Windows 2003"
                            Case Else
                                Return "Unknown"
                        End Select
                    Case 6
                        Return "Windows Vista"
                    Case Else
                        Return "Unknown"
                End Select
            Case PlatformID.WinCE
                Return "Win CE"
            Case Else
                Return "Unknown"
        End Select
    End Function

End Class
