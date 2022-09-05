Imports System
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Net.Sockets
Imports System.Web

Public Class frmRegister
    Dim OSType As String = Nothing
    Dim resetonline As Boolean = True
    Dim resetoffline As Boolean = True
    Dim strUkey As String
    Dim strSKey As String

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Me.btnRegister.Enabled = False
        Me.txtOnlineSKey.Enabled = False
        strUkey = ""
        lblActivationStatusOffline.Text = ""
        lblActivationStatusOnline.Text = ""
        Dim PcName As String
        Dim url As String
        Dim MyOS As String

        PcName = System.Environment.MachineName
        MyOS = GetOS()

        If Not ConnectionAvailable() Then
            Me.Close()
        Else
            log2file("Connection Available.")
        End If

        Dim local As Boolean = False

        url = "http://activate.smartchoicecomputers.com.au/activate.aspx?" & _
        "key=" & txtOnlineSKey.Text & _
        "&pid=5" & _
        "&pcname=" & PcName & _
        "&OS=" & MyOS

        log2file("Using URL: " + url)
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        ' Set some reasonable limits on resources used by this request
        request.MaximumAutomaticRedirections = 4
        request.MaximumResponseHeadersLength = 4
        request.Method = "POST"
        ' Set credentials to use for this request.
        request.Credentials = CredentialCache.DefaultCredentials
        Dim encoding As New ASCIIEncoding()
        Dim byte1 As Byte() = encoding.GetBytes(url)
        ' Set the content type of the data being posted.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the content length of the string being posted.
        request.ContentLength = byte1.Length
        Try
            Dim newStream As Stream = request.GetRequestStream()
            newStream.Write(byte1, 0, byte1.Length)
        Catch exweb As WebException
            MsgBox("Web related issue: " & exweb.ToString(), MsgBoxStyle.Information, "Website Read error")
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.ToString, MsgBoxStyle.Information, "Error")
        End Try
        Try
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            log2file("Content length is: " + response.ContentLength.ToString)
            log2file("Content type is: " + response.ContentType.ToString)
            log2file("Status code is: " + response.StatusCode.ToString)
            ' Get the stream associated with the response.
            Dim receiveStream As Stream = response.GetResponseStream()
            ' Pipes the stream to a higher level stream reader with the required encoding format. 
            Dim readStream As New StreamReader(receiveStream, System.Text.Encoding.UTF8)
            Dim ReceivedStream As String
            ReceivedStream = readStream.ReadToEnd()
            response.Close()
            readStream.Close()

            If ReceivedStream.ToLower.IndexOf("fail") = -1 Then
                strUkey = ReceivedStream.Trim
                log2file("Received unlock code. " + strUkey)
                activateapp(txtOnlineSKey.Text, strUkey, "0")
                MsgBox("Click OK and restart application.", MsgBoxStyle.Information, "Activated.")
                frmMain.Close()
                Me.Close()
            Else
                log2file("Activation failed." + vbCrLf + "Response received" + ReceivedStream.Trim)
                lblActivationStatusOnline.Text = "Activation failed."
                btnRegister.Enabled = True
                txtOnlineSKey.Enabled = True
            End If
        Catch exweb As WebException
            MsgBox("Web related issue: " & exweb.ToString(), MsgBoxStyle.Information, "Website Read error")
            btnRegister.Enabled = True
            txtOnlineSKey.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error")
            btnRegister.Enabled = True
            txtOnlineSKey.Enabled = True
        End Try
    End Sub
    Private Sub activateapp(ByVal strSKey As String, ByVal strUKey As String, ByVal mode As String)
        'Do registry activation information
        If GetSettings("SerialKey") = "Nothing!" Then
            My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\smartlearn\SmartSync\1.0", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath + "\activation.dll", Encryptme(Encryptme(strUKey) + CPUid), False)
        SaveSettings("SerialKey", Trim(strSKey))
        SaveSettings("Owner", "Crystal")
        SaveSettings("Company", "Aczire")
        SaveSettings("Mode", mode)
    End Sub
    ' Specify the URL to receive the request.
    Public Shared Sub Test(ByVal url As String)
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)

        ' Set some reasonable limits on resources used by this request
        request.MaximumAutomaticRedirections = 4
        request.MaximumResponseHeadersLength = 4
        request.Method = "POST"

        ' Set credentials to use for this request.
        request.Credentials = CredentialCache.DefaultCredentials

        Dim encoding As New ASCIIEncoding()
        Dim byte1 As Byte() = encoding.GetBytes(url)
        ' Set the content type of the data being posted.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the content length of the string being posted.
        request.ContentLength = byte1.Length

        Dim newStream As Stream = request.GetRequestStream()

        newStream.Write(byte1, 0, byte1.Length)

        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)


        Console.WriteLine("Content length is: ", response.ContentLength.ToString)
        Console.WriteLine("Content type is {0}", response.ContentType.ToString)

        ' Get the stream associated with the response.
        Dim receiveStream As Stream = response.GetResponseStream()

        ' Pipes the stream to a higher level stream reader with the required encoding format. 
        Dim readStream As New StreamReader(receiveStream, System.Text.Encoding.UTF8)

        Console.WriteLine("Response stream received.")
        MsgBox(readStream.ReadToEnd())

        response.Close()
        readStream.Close()

    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        frmMain.Close()
        Me.Close()
    End Sub

    Private Sub frmRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblNotice.Visible = True
        lblUnReg.Visible = True
        lblRegisterOnline.Visible = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start(CType(e.Link.LinkData, String))
    End Sub

    Private Sub lblRegisterOffline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRegisterOffline.Click
        If Me.Height > 240 Then
            Me.Height = 240
        Else
            Me.Height = 330
        End If

        pnlOnline.Visible = False
        pnlOffline.Visible = True

    End Sub

    Private Sub lblRegisterOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRegisterOnline.Click
        If Me.Height > 240 Then
            Me.Height = 240
        Else
            Me.Height = 300
        End If
        pnlOnline.Visible = True
        pnlOffline.Visible = False
    End Sub


    Private Sub BtnCheckKeyManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheckKeyManual.Click
        Dim AppUnlockCode As String
        Dim AppKey As String
        Dim AppKeyEncrypted As String
        lblActivationStatusOffline.Text = ""
        lblActivationStatusOnline.Text = ""
        AppKey = txtOfflineSkey.Text
        AppKeyEncrypted = Encryptme(AppKey + AppID + Format(DateTime.Now, "yyyy/MM/dd"))
        AppUnlockCode = txtmanualUnlockCode.Text
        If AppKeyEncrypted = AppUnlockCode Then
            activateapp(txtOfflineSkey.Text, txtmanualUnlockCode.Text, "1")
            frmMain.Opacity = 100
            frmMain.ShowInTaskbar = True
            frmMain.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            frmMain.Show()
            Me.Close()
        Else
            lblActivationStatusOffline.Text = "Activation failed."
        End If
    End Sub

    
    Private Sub btnMExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMExit.Click
        frmMain.Close()
        Me.Close()
    End Sub
End Class
