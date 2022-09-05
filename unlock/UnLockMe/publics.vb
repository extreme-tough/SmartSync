Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.Security.Principal
Imports System.Management

Module Publics

    Public windowstate As Integer = 1
    Public CPUid As String = GetCPUId()
    Public OK As Boolean = False
    Public OSType As String = Nothing
    Public AppName As String = "SmartSync"
    Public AppID As String = "5"

    Public Declare Auto Function AutoBeep Lib "kernel32" Alias "Beep" _
        (ByVal dwFreq As Integer, ByVal dwDuration As Integer) As Integer

    Public Function ConnectionAvailable() As Boolean
        ' Returns True if connection is available 
        Dim objUrl As New System.Uri("http://www.smartlearn.com.au/")
        ' Setup WebRequest
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try
            ' Attempt to get response and return True
            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception
            ' Error, exit and return False
            objWebReq = Nothing
            Return False
        End Try
    End Function
    Public Sub log2file(ByVal strlog As String)
        'You can use the logging facility if you wants to diag what happnd in
        'customers premises.Tell them to upload the log file.
        'My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath + "\app.log", strlog + " : " + Date.Now.ToString + vbCrLf, True)
    End Sub

    Public Function GetCPUId() As String
        Dim cpuInfo As String = String.Empty
        Dim temp As String = String.Empty
        Try
            Dim mc As New ManagementClass("Win32_Processor")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            For Each mo As ManagementObject In moc
                If (cpuInfo = String.Empty) Then
                    'only return cpuInfo from first CPU
                    cpuInfo = mo.Properties("ProcessorId").Value.ToString()
                End If
            Next
        Catch ex As Exception
            MsgBox("Can't get the CPU ID." + vbCrLf + "May be because you are in Guest account or your Admin disabled access to the corresponding registry key " _
            + vbCrLf + ex.Message)
        End Try
        Return cpuInfo
    End Function

    Function GenerateHash(ByVal strSource As String) As String
        ' Create an Encoding object so that you can use the convenient GetBytes 
        ' method to obtain byte arrays.
        Dim uEncode As New System.Text.UnicodeEncoding()
        ' Create a byte array from the source text passed as an argument.
        Dim bytSource() As Byte = uEncode.GetBytes(strSource)
        Dim hash() As Byte = {1}
        Dim sha1 As New Security.Cryptography.SHA1CryptoServiceProvider()
        hash = sha1.ComputeHash(bytSource)
        ' Base64 is a method of encoding binary data as ASCII text.
        Return Convert.ToBase64String(hash)
    End Function

    Public Function GetGUID() As String
        Dim newGUID As Guid
        newGUID = Guid.NewGuid
        Return newGUID.ToString.ToUpper
    End Function

    Public Function Processor() As String
        ' This is to show how to use the SelectQuery object in the place of a SELECT 
        ' statement.
        Dim query As New SelectQuery("Win32_processor")
        Dim ret As String = Nothing

        'ManagementObjectSearcher retrieves a collection of WMI objects based on 
        ' the query.
        Dim search As New ManagementObjectSearcher(query)

        ' Display each entry for Win32_processor
        Dim info As ManagementObject
        For Each info In search.Get()
            ret = ret + "|" + "Processor: " + info("caption").ToString() + vbCrLf
        Next
        Return ret
    End Function

    Public Function SaveSettings(ByVal regstring As String, ByVal value As String) As Boolean
        Try
            Dim oKey As RegistryKey = Registry.LocalMachine
            oKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\SmartLearn\SmartSync\1.0", True)
            oKey.SetValue(regstring, value, RegistryValueKind.String)
            oKey.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetSettings(ByVal regstring As String) As String
        Dim value As String = "Nothing"
        Try
            Dim oKey As RegistryKey = Registry.LocalMachine
            oKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\smartlearn\SmartSync\1.0", False)
            value = oKey.GetValue(regstring, "Nothing")
            oKey.Close()
            Return value
        Catch ex As Exception
            Return "Nothing!"
        End Try
    End Function
    
    Public Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String
        Dim intPosition As Integer
        Dim strStringWithOutNulls As String
        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls
        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)
            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If
            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop
        Return strStringWithOutNulls
    End Function
    
    Function IsAdministrator() As Boolean
        AppDomain.CurrentDomain.SetPrincipalPolicy( _
            PrincipalPolicy.WindowsPrincipal)
        Dim prinWinPrincipal As WindowsPrincipal = CType(System.Threading.Thread.CurrentPrincipal, WindowsPrincipal)

        ' Check if the user account is an Administrator.
        If prinWinPrincipal.IsInRole(WindowsBuiltInRole.Administrator) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetOS()
        Dim b64 As Boolean = False
        Dim OS As String '= "Running in a "
        Dim MyOperatingSystem As String


        For Each ra As Reflection.Assembly In My.Application.Info.LoadedAssemblies
            If ra.Location.ToLower.Contains("framework64") Then b64 = True
            Exit For
        Next
        OSType = IIf(b64, "64 Bit", "32 Bit")

        MyOperatingSystem = GetOSVersion()
        OS = MyOperatingSystem
        OS += IIf(b64, " 64 Bit", " 32 Bit").ToString
        Return OS

    End Function

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
                                Return "Win 2000"
                            Case 1
                                Return "Win XP"
                            Case 2
                                Return "Win 2003"
                            Case Else
                                Return "Unknown"
                        End Select
                    Case 6
                        Return "Windows Vista"
                    Case 7
                        Return "Windows 7"
                    Case Else
                        Return "Unknown"
                End Select
            Case PlatformID.WinCE
                Return "Win CE"
            Case Else
                Return "Unknown"
        End Select
    End Function

    Public Function CheckKey(ByVal strKey As String, ByVal strUnlockCodeEncryptd As String) As Boolean

        Dim AppUnlockCode As String
        Dim AppKey As String
        Dim AppKeyEncrypted As String
        Dim ValidKey As Boolean

        AppKey = strKey
        AppUnlockCode = strUnlockCodeEncryptd
        ValidKey = False

        ValidKey = authKey(AppKey, AppName)

        If ValidKey = True Then                                                 'Checks if the authorization key is valid
            log2file("Serial key validated.")
        Else
            log2file("Serial key not valid.")
            SaveSettings("SerialKey", "Nothing!")
            Return False
        End If

        AppKeyEncrypted = Encryptme(AppKey + AppID)
        log2file("Appkey encrypted: " + AppKeyEncrypted)
        Dim appkey2 = Encryptme(AppKeyEncrypted)
        log2file("Appkey encrypted II: " + appkey2)
        Dim appkey3 = Encryptme(appkey2 + CPUid)
        log2file("Appkey encrypted III: " + appkey3)

        If appkey3 = AppUnlockCode Then        'Checks if the unlock code is valid
            log2file("Successfully Unlocked")
            Return True
        Else
            log2file("There seems to be a problem with your activation.")
            Return False
        End If

    End Function

    Public Function Encryptme(ByVal str As String) As String

        Dim md5 As MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim strOutput As String = Nothing
        Dim i As Integer

        ' Create New Crypto Service Provider Object
        md5 = New MD5CryptoServiceProvider

        ' Convert the original string to array of Bytes
        bytValue = System.Text.Encoding.UTF8.GetBytes(str)

        ' Compute the Hash, returns an array of Bytes
        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()

        For i = 0 To bytHash.Length - 1
            'don't lose the leading 0
            strOutput &= bytHash(i).ToString("x").PadLeft(2, "0")
        Next

        Return strOutput
    End Function

    Public Function authKey(ByVal key, ByVal appName) As Boolean
        authKey = False
        On Error GoTo err

        Dim splt() As String
        Dim appVal As Long
        Dim genVal As Long
        Dim tempVar As String
        Dim i As Integer
        key = UCase(key)

        For i = 1 To Len(appName) - 0
            appVal = appVal + Val(Asc(Mid$(appName, i, 1)))
        Next

        splt = Split(key, "-")                                      'Splits the key into an array
        splt(0) = ""                                                'Preps the key for genVal by removing app name
        splt(4) = ""                                                'Preps the key for genVal by removing appVal*genVal
        splt(5) = ""                                                'Preps the key for genVal by removing the key ID
        tempVar = Join(splt, "-")                                   'Brings the section of the key needed for genVal
        tempVar = tempVar.Remove(0, 1)                              'Removes the extra dash from the app name segment
        tempVar = tempVar.Remove(17, 1)                             'Removes the extra dash from the key ID segment

        For i = 1 To Len(tempVar) - 0
            If i < Len(appName) Then
                If getPlusMinus(Mid(appName, i, 1)) = False Then
                    genVal = genVal + Val(Asc(Mid$(tempVar, i, 1)))
                Else
                    genVal = genVal - Val(Asc(Mid$(tempVar, i, 1)))
                End If
            Else
                If Int(i / 2) = i / 2 Then
                    genVal = genVal - Val(Asc(Mid$(tempVar, i, 1)))
                Else
                    genVal = genVal + Val(Asc(Mid$(tempVar, i, 1)))
                End If
            End If
        Next
        If genVal < 0 Then genVal = 0 - genVal
        splt = Split(key, "-")
        If genVal = Val(splt(4)) / appVal Then
            authKey = True
        Else
            authKey = False
        End If

        Debug.Print(Mid((appVal * genVal) & "JSDEU", 1, 5))
        Debug.Print(splt(4))

        If Mid((appVal * genVal) & "JSDEU", 1, 5) = splt(4) Then
            authKey = True
        Else
            authKey = False
        End If

err:

    End Function

    Private Function getPlusMinus(ByVal chrr) As Boolean
        chrr = UCase(chrr)
        If Asc(chrr) - 65 < 12 Then
            getPlusMinus = True
        Else
            getPlusMinus = False
        End If
    End Function

End Module
