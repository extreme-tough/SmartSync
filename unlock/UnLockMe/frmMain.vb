Public Class frmMain
    
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSerialKey As String = "Nothing!"
        Dim strUnlockCode As String = "Nothing!"
        Dim strUnlockCodeencryptd As String = ""
        Try
            strSerialKey = Trim(GetSettings("SerialKey"))
        Catch ex As Exception
            'Hmmmm, lost our reg key?
            strSerialKey = "Nothing!"
        End Try

        Try
            strUnlockCode = Trim(My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\Activation.dll"))
        Catch ex As Exception
            'Seems no activation.dll!
            strSerialKey = "Nothing!"
        End Try
        log2file("*********************************************************")
        log2file("Serial: " + strSerialKey + " UnlockCode(encryptd,from activation.dll): " + strUnlockCode)
        Me.Opacity = 0

        Try
            If strSerialKey = "Nothing!" Then
                log2file("No serial key found.Showing reg form.")
                frmRegister.Show()
                frmRegister.Activate()

            Else
                'Check if activated correctly.
                log2file("Checking activation keys:  " + strSerialKey + "  " + strUnlockCode)
                If GetSettings("mode") = "0" Then
                    If (CheckKey(strSerialKey, strUnlockCode)) Then
                        'show main form
                        Me.Opacity = 100
                        Me.ShowInTaskbar = True
                        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                        Me.Activate()
                        Me.BringToFront()
                    Else
                        Me.Opacity = 0
                        frmRegister.Show()
                        frmRegister.Activate()
                    End If
                Else
                    Dim AppUnlockCode As String
                    Dim AppKey As String
                    Dim AppKeyEncrypted As String

                    AppKey = strSerialKey
                    AppKeyEncrypted = Encryptme(AppKey + AppID + Format(DateTime.Now, "yyyy/MM/dd"))
                    strUnlockCodeencryptd = Encryptme(AppKeyEncrypted)
                    strUnlockCodeencryptd = Encryptme(strUnlockCodeencryptd + CPUid)
                    AppUnlockCode = strUnlockCode
                    If strUnlockCodeencryptd = AppUnlockCode Then
                        Me.Opacity = 100
                        Me.ShowInTaskbar = True
                        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                        Me.Activate()
                        Me.BringToFront()
                    Else
                        Me.Opacity = 0
                        frmRegister.Show()
                        frmRegister.Activate()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class