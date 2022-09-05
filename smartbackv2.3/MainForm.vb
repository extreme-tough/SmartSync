
Option Explicit On
Option Strict On
Option Infer Off

Imports System.IO
'Imports System.Net.Mail
Imports System.Runtime.InteropServices

Public Class MainForm
    Public Const APP_TITLE As String = "SmartBackUp"
    Dim timeOfBackup As DateTime
    Dim isBackingUp As Boolean
    Dim backupFinished As Boolean
    Dim WithEvents backupUtil As BackupUtil
    Dim hasError As Boolean
    Dim isAborted As Boolean
    Dim elapsedTimer As Timers.Timer
    Dim updateCopyingTextTimer As Timers.Timer
    Dim hideBalloonTip As Boolean
    Dim MyDirectoryInfo As String
    Dim Parameters As String
    Dim ScriptDir As New DirectoryInfo(Application.StartupPath + "\scripts\")


    Private Sub txtSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSource.TextChanged
        checkIfBackupCanOccur()
    End Sub
    Private Sub txtDestination_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestination.TextChanged
        checkIfBackupCanOccur()
    End Sub
    Private Sub checkIfBackupCanOccur()
        If txtSource.Text.Length > 0 And txtDestination.Text.Length > 0 Then
            btnBeginBackup.Enabled = True
        Else
            btnBeginBackup.Enabled = False
        End If
    End Sub
    Private Sub btnSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSource.Click
        Dim dlgBrowseSource As FolderBrowserDialog = New FolderBrowserDialog()
        If dlgBrowseSource.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSource.Text = dlgBrowseSource.SelectedPath
        End If
    End Sub
    Private Sub btnDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDestination.Click
        Dim dlgBrowseDestination As New FolderBrowserDialog
        If dlgBrowseDestination.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDestination.Text = dlgBrowseDestination.SelectedPath
        End If
    End Sub
    Private Sub btnBeginBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeginBackup.Click
        If isBackingUp Then
            backupUtil.PauseBackup()        ' We temporarily pause the backup till the user responds
            If MessageBox.Show("This will abort the backup process. Do you wish to continue", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
                    = Windows.Forms.DialogResult.No Then
                backupUtil.ResumeBackup()   ' We resume the backup
                Return
            End If
            Me.Cursor = Cursors.WaitCursor
            backupUtil.ResumeBackup()
            isAborted = True

            backupUtil.Abort()

            grpLogging.Enabled = True
            grpConfigurePaths.Enabled = True
            isBackingUp = False
            btnBeginBackup.Text = "&Aborting"
        Else
            Me.Cursor = Cursors.WaitCursor
            btnBeginBackup.Enabled = False
            ' We check to see whether the input parameters are correct.
            Dim bIsInputValid As Boolean

            If RadScript.Checked Then
                bIsInputValid = ValidateScriptInputs()
            Else
                bIsInputValid = validateInputs()
            End If

            LblFreeSpaceDest.Text = convertBytesToMegaBytes(getDriveFreeSpace(txtDestination.Text.Substring(0, 1))).ToString & " MB"

            Me.Cursor = Cursors.Default
            btnBeginBackup.Enabled = True
            If Not (bIsInputValid) Then Exit Sub

            hasError = False
            resetStats()
            grpLogging.Enabled = False
            GrType.Enabled = False
            grpConfigurePaths.Enabled = False
            btnResetStats.Enabled = False
            RestoreToolStripMenuItem.Enabled = False

            Dim elogType As ELogMode
            If radLogAll.Checked Then
                elogType = ELogMode.E_LogAll
            ElseIf radLogOnlyErrors.Checked Then
                elogType = ELogMode.E_LogErrors
            Else
                elogType = ELogMode.E_LogNone
            End If

            If RadScript.Checked Then
                backupUtil = New BackupUtil(ScriptDir.ToString & Me.txScript.Text, Me.txtDestination.Text, elogType)
            Else
                backupUtil = New BackupUtil(txtSource.Text, txtDestination.Text, txtDestination.Text, elogType)
            End If

            btnBeginBackup.Text = "&Abort Backup"
            isBackingUp = True
            isAborted = False


            elapsedTimer = New Timers.Timer(1000)
            AddHandler elapsedTimer.Elapsed, AddressOf elapsedTimerFired
            timeOfBackup = DateTime.Now

            updateCopyingTextTimer = New Timers.Timer(130)
            AddHandler updateCopyingTextTimer.Elapsed, AddressOf updateCopyingTextTimerFired

            elapsedTimer.Start()


            backupFinished = False
            backupUtil.Start()

            updateCopyingTextTimer.Start()

            While Not backupFinished

                If isAborted = True Then
                    backupUtil.Abort()
                End If
                Application.DoEvents()

            End While

            elapsedTimer.Stop()
            elapsedTimer.Dispose()

            updateCopyingTextTimer.Stop()
            updateCopyingTextTimer.Dispose()

            grpLogging.Enabled = True
            GrType.Enabled = True
            grpConfigurePaths.Enabled = True
            isBackingUp = False
            btnBeginBackup.Text = "&Begin Backup"
        End If

    End Sub
    Private Sub btnResetStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetStats.Click
        resetStats()
    End Sub
    Private Sub resetStats()
        ProgressBar1.Value = 0

        Dim statusLabels() As Label = New Label() {lblFileBeingCopied, lblFilesCopied, lblFilesRemaining, lbLFilesSkipped, lblTimeElapsed}
        Dim label As Label

        For Each label In statusLabels
            label.Text = ""
        Next

        btnResetStats.Enabled = False

    End Sub
    Private Sub updateCopyingTextTimerFired(ByVal sender As System.Object, ByVal e As Timers.ElapsedEventArgs)

        updateCopyingTextTimerFiredImpl()

    End Sub

    Delegate Sub updateCopyingTextTimerFiredDelegate()

    Private Sub updateCopyingTextTimerFiredImpl()
        If Me.InvokeRequired Then
            Me.Invoke(New updateCopyingTextTimerFiredDelegate(AddressOf updateCopyingTextTimerFiredImpl))
        Else
            If lblFileBeingCopied.Text.Contains("Copying") Then
                Dim startIndex As Int32 = lblFileBeingCopied.Text.IndexOf(" .")
                Dim length As Int32 = lblFileBeingCopied.Text.Length - lblFileBeingCopied.Text.IndexOf(" .")
                Dim ellipsis As String = lblFileBeingCopied.Text.Substring(startIndex, length)
                Dim three As String = " ..."
                Dim bytes As Char() = ellipsis.ToCharArray()
                Dim foo As Int32 = three.Length
                Dim bar As Int32 = ellipsis.Length

                If ellipsis = " ." Then

                    lblFileBeingCopied.Text = lblFileBeingCopied.Text.Replace(" .", " ..")
                ElseIf ellipsis = " .." Then

                    lblFileBeingCopied.Text = lblFileBeingCopied.Text.Replace(" ..", " ...")
                ElseIf ellipsis = three Then

                    lblFileBeingCopied.Text = lblFileBeingCopied.Text.Replace(" ...", " .")
                End If
            End If
        End If
    End Sub

    Private Sub elapsedTimerFired(ByVal sender As System.Object, ByVal e As Timers.ElapsedEventArgs)

        elapsedTimerFiredImpl()

    End Sub

    Delegate Sub elapsedTimerFiredDelegate()
    Private Sub elapsedTimerFiredImpl()
        If Me.InvokeRequired Then
            Me.Invoke(New elapsedTimerFiredDelegate(AddressOf elapsedTimerFiredImpl))
        Else
            Dim ts As TimeSpan = DateTime.Now.Subtract(timeOfBackup)
            lblTimeElapsed.Text = Format(ts.Hours, "###0") & ":" & Format(ts.Minutes, "00") & ":" & Format(ts.Seconds, "00")
        End If
    End Sub

    Delegate Sub backupStartedDelegate(ByVal filesToCopy As Int32)
    Public Sub backupStarted(ByVal filesToCopy As Int32) Handles backupUtil.BackupStarted
        backupStartedImpl(filesToCopy)
    End Sub
    Public Sub backupStartedImpl(ByVal filesToCopy As Int32)
        If Me.InvokeRequired Then
            Me.Invoke(New backupStartedDelegate(AddressOf backupStarted), filesToCopy)
        Else
            ProgressBar1.Maximum = filesToCopy
            ProgressBar1.Value = 1
        End If
    End Sub

    Public Sub backupCompleted(ByVal filesCopied As Int32, ByVal filesSkipped As Int32, ByVal logName As String) Handles backupUtil.BackupCompleted
        backupCompletedImpl(filesCopied, filesSkipped, logName)
    End Sub
    Delegate Sub backupCompletedDelegate(ByVal filesCopied As Int32, ByVal filesSkipped As Int32, ByVal logName As String)
    Public Sub backupCompletedImpl(ByVal filesCopied As Int32, ByVal filesSkipped As Int32, ByVal logName As String)
        If Me.InvokeRequired Then
            Me.Invoke(New backupCompletedDelegate(AddressOf backupCompletedImpl), filesCopied, filesSkipped, logName)
        Else
            Me.Cursor = Cursors.Default
            backupFinished = True
            If Not hasError And Not isAborted Then
                ProgressBar1.Value = ProgressBar1.Maximum
            End If
            elapsedTimer.Stop()
            lblFileBeingCopied.Text = ""
            btnResetStats.Enabled = True
            NotifyIcon1.Text = "Click to restore program."
            RestoreToolStripMenuItem.Enabled = True
            Dim finalMessage As String = ""

            If Me.WindowState = FormWindowState.Normal Then
                If Not isAborted Then
                    finalMessage = String.Format("Backup completed with {0} files copied and {1} files skipped.", filesCopied, filesSkipped)
                Else
                    finalMessage = String.Format("Backup aborted with {0} files copied and {1} files skipped.", filesCopied, filesSkipped)
                End If
            Else
                NotifyIcon1.BalloonTipText = "Backup complete!"
                NotifyIcon1.ShowBalloonTip(1000)
            End If

            If Me.ChkEmailLogFiles.Checked = True Then
                SendMail(logName)
            End If

            ' Now, if we have a HTML report file, prompt the user whether to view the Report.
            If (logName.Length > 0) Then finalMessage += vbCrLf & vbCrLf & "Do you wish to see the Report ?"
            If (logName.Length > 0) Then
                If (MessageBox.Show(finalMessage, "Backup Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
                    System.Diagnostics.Process.Start(logName)
                End If
            Else
                MessageBox.Show(finalMessage, "Backup Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            btnBeginBackup.Text = "&Begin Backup"
        End If
    End Sub

    Public Sub fileCopied(ByVal backupStatus As BackupStatus) Handles backupUtil.FileCopied
        fileCopiedImpl(backupStatus)

    End Sub

    Delegate Sub fileCopiedDelegate(ByVal backupStatus As BackupStatus)

    Public Sub fileCopiedImpl(ByVal backupStatus As BackupStatus)
        If Me.InvokeRequired Then
            Me.Invoke(New fileCopiedDelegate(AddressOf fileCopiedImpl), backupStatus)
        Else
            lblFilesRemaining.Text = backupStatus.numFilesRemaining.ToString
            lblFilesCopied.Text = backupStatus.numFilesCopied.ToString
            lbLFilesSkipped.Text = backupStatus.numFilesSkipped.ToString
            Dim copyText As String = String.Format("Copying {0} ...", backupStatus.fileBeingCopied)
            lblFileBeingCopied.Text = copyText
            'NotifyIcon1.Text = String.Format("{0} \r\n {1} files copied \r\n {2} files skipped \r\n {3} files remaining", copyText, backupStatus.numberFilesCopied, backupStatus.numberFilesSkipped, backupStatus.numberFilesRemaining)
            NotifyIcon1.BalloonTipText = String.Format("{0} " + Environment.NewLine + "{1} files copied" + Environment.NewLine + "{2} files skipped" + Environment.NewLine + "{3} files remaining", copyText, backupStatus.numFilesCopied, backupStatus.numFilesSkipped, backupStatus.numFilesRemaining)
            If Not hideBalloonTip Then
                NotifyIcon1.ShowBalloonTip(1000)
            End If

            If (backupStatus.numFilesCopied <= ProgressBar1.Maximum) Then
                ProgressBar1.Value = backupStatus.numFilesCopied
            End If
            Application.DoEvents()
        End If
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Activate()
        Me.Focus()
        Me.Invalidate()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Activate()
        Me.Focus()
        Me.Invalidate()
    End Sub
    Private Sub MainForm_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
            Me.Invalidate()
            Application.DoEvents()
        ElseIf Me.WindowState = FormWindowState.Normal Then
            NotifyIcon1.Visible = False
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            Me.Activate()
            Me.Focus()
            Me.Invalidate()
            Application.DoEvents()
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim args() As String
        Dim Msg As String = Nothing

        txScript.Items.Clear()

        Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")

        For Each file As FileInfo In dir.GetFiles("*.ini")
            txScript.Items.Add(file.Name)
        Next

        args = Environment.GetCommandLineArgs()
        Msg = "SmartBack - Syntax error." + Chr(13) + Chr(13)
        Msg += "Syntax: " + Chr(13)
        Msg += "     SmartBack.exe \n source destination" + Chr(13)
        Msg += "     SmartBack.exe \s script destination"
        If args.Length > 1 Then
            If args Is Nothing OrElse ((args.Length <> 4) Or ((args(1).ToUpper <> "\N") And (args(1).ToUpper <> "\S"))) Then
                MessageBox.Show(Msg, "Wrong parameters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If args(1).ToUpper = "\S" Then
                    Me.WindowState = FormWindowState.Minimized
                    RadScript.Checked = True
                    txScript.Text = args(2)
                    txtDestination.Text = args(3)
                    btnBeginBackup.PerformClick()
                End If

                If args(1).ToUpper = "\N" Then
                    Me.WindowState = FormWindowState.Minimized
                    txtSource.Text = args(2)
                    txtDestination.Text = args(3)
                    RadNormal.Checked = True
                    btnBeginBackup.PerformClick()
                End If
            End If

        End If
        hideBalloonTip = False
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.isBackingUp Then
            e.Cancel = True
            MessageBox.Show("SmartBackup cannot be closed during a backup. Please wait for the backup to finish or abort it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub AbortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isBackingUp Then
            btnBeginBackup.PerformClick()
        End If
    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If isBackingUp Then
                btnBeginBackup.PerformClick()
            End If
        End If
    End Sub

    Private Sub NotifyIcon1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseMove
        NotifyIcon1.ShowBalloonTip(1000)
        hideBalloonTip = False
    End Sub

    Private Sub NotifyIcon1_BalloonTipClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClosed
        hideBalloonTip = True
    End Sub
    Private Function ValidateScriptInputs() As Boolean
        ValidateScriptInputs = False

        Dim sDestPath As String = LCase(txtDestination.Text).Trim
        If (sDestPath.Length = 0) Then
            ' The Destination directory cannot be empty.
            MsgBox("Please enter the Destination directory.", MsgBoxStyle.Information, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If

        If (Directory.Exists(sDestPath) = False) Then
            MsgBox("The Destination directory " & txtDestination.Text & " does not exist.", MsgBoxStyle.Critical, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If

        If (Not getIsPathWritable(sDestPath)) Then
            MsgBox("The Destination directory is read-only, or, the application does not have " & _
                   "sufficient priviledges to write to the directory.", MsgBoxStyle.Information, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If

        If Not (File.Exists(ScriptDir.ToString & Me.txScript.Text)) Then
            MsgBox("The script file doesn't exists in the path provided", MsgBoxStyle.Information, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If

        ValidateScriptInputs = True
    End Function
    Private Function validateInputs() As Boolean
        validateInputs = False

        Dim sSourcePath As String = LCase(txtSource.Text).Trim
        Dim sDestPath As String = LCase(txtDestination.Text).Trim
        If (sSourcePath.Length = 0) Then
            ' The Source directory cannot be empty.
            MsgBox("Please enter the Source directory to backup.", MsgBoxStyle.Information, APP_TITLE)
            txtSource.Focus()
            Exit Function
        ElseIf (sDestPath.Length = 0) Then
            ' The Destination directory cannot be empty.
            MsgBox("Please enter the Destination directory.", MsgBoxStyle.Information, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If

        If (sSourcePath = sDestPath) Then
            ' The Destination directory cannot be same as the Source directory.
            MsgBox("The Destination directory cannot be same as the Source directory.", MsgBoxStyle.Information, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        ElseIf (InStr(sDestPath, sSourcePath, CompareMethod.Binary) > 0) Then
            ' The Destination directory cannot be a sub-directory of the Source directory.
            MsgBox("The Destination directory cannot be a sub-directory of the Source directory.", MsgBoxStyle.Information, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If
        If (Directory.Exists(sSourcePath) = False) Then
            MsgBox("The Source directory " & txtSource.Text & " does not exist.", MsgBoxStyle.Critical, APP_TITLE)
            txtSource.Focus()
            Exit Function
        ElseIf (Directory.Exists(sDestPath) = False) Then
            MsgBox("The Destination directory " & txtDestination.Text & " does not exist.", MsgBoxStyle.Critical, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If
        If (Not getIsPathWritable(sDestPath)) Then
            MsgBox("The Destination directory is read-only, or, the application does not have " & _
                   "sufficient priviledges to write to the directory.", MsgBoxStyle.Information, APP_TITLE)
            txtDestination.Focus()
            Exit Function
        End If
        Dim nDestSizeFree As Long = getDriveFreeSpace(sDestPath.Substring(0, 3))
        Dim nSourceSize As Long = getFolderSize(sSourcePath, True)
        If (nDestSizeFree <= nSourceSize) Then
            MsgBox("There is not enough space available on Drive " & UCase(sDestPath.Substring(0, 2)) & _
                   " to backup contents of the Source directory." & vbCrLf & _
                   "Space required by Source : " & convertBytesToMegaBytesStr(nSourceSize) & "MB" & vbCrLf & _
                   "Space available on Destination : " & convertBytesToMegaBytesStr(nDestSizeFree) & "MB", MsgBoxStyle.Critical, APP_TITLE)
            Exit Function
        End If
        validateInputs = True
    End Function
    Private Sub backupUtil_ErrorOccurred(ByVal ex As BackupUtilException, ByRef bContinue As Boolean) Handles backupUtil.ErrorOccurred
        If (bContinue = True) Then
            'If (MsgBox(ex.Message & vbCrLf & vbCrLf & "Do you want to continue ?", _
            '           CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, MsgBoxStyle), APP_TITLE) = MsgBoxResult.No) Then
            '    bContinue = False
            '    isAborted = True
            'End If
        Else
            MsgBox(ex.Message, MsgBoxStyle.Critical, APP_TITLE)
        End If
    End Sub
    Delegate Sub notifyDiskIoChangeDelegate(ByVal tInfo As TSpaceInfo)
    Private Sub notifyDiskIoChange(ByVal tInfo As TSpaceInfo) Handles backupUtil.notifyDiskIoChange
        Call notifyDiskIoChangeImpl(tInfo)
    End Sub

    Public Sub notifyDiskIoChangeImpl(ByVal tInfo As TSpaceInfo)
        If Me.InvokeRequired Then
            Me.Invoke(New notifyDiskIoChangeDelegate(AddressOf notifyDiskIoChange), tInfo)
        Else
            If (LblMbToCopy Is Nothing) Then LblMbToCopy = New Label
            LblMbToCopy.Text = convertBytesToMegaBytesStr(Math.Abs(tInfo.nTotalBytesToCopy - tInfo.nBytesCopied)) & " MB"
            If (tInfo.nTotalBytesToCopy = 0) Then
                Label5.Text = "Total Copied"
            Else
                Label5.Text = "Remaining to Copy"
            End If
            LblFreeSpaceDest.Text = convertBytesToMegaBytesStr(Math.Abs(tInfo.nFreeSpaceRemaining)) & " MB"
        End If
    End Sub


    Private Sub BtEditScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEditScript.Click
        Dim FormEdit As New ScriptEditor
        FormEdit.ShowDialog()

    End Sub

    Private Sub RadScript_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadScript.CheckedChanged
        EnableScriptButton(RadScript.Checked)
    End Sub

    Private Sub EnableScriptButton(ByVal Enable As Boolean)
        Me.BtLoadScript.Enabled = Enable
        Me.txScript.Enabled = Enable

        Me.txtDestination.Enabled = True
        Me.txtSource.Enabled = Not Enable
        Me.btnDestination.Enabled = True
        Me.btnSource.Enabled = Not Enable
    End Sub

    Private Sub BtLoadScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLoadScript.Click
        'If OpenScript.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    Me.txScript.Text = Me.OpenScript.FileName
        'End If

        Dim FormEdit As New ScriptEditor
        FormEdit.ShowDialog()

    End Sub

    Public Sub SendMail(ByVal MyEmailAttachment As String) '(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSend.Click

        Dim SendMessage As New Net.Mail.SmtpClient
        Dim SentInfo As New Object
        'Dim EmailMessage As New MailMessage

        '    With EmailMessage
        '.From = New MailAddress(TxSendersEmail.Text, TxSendersName.Text)

        If IsNothing(TxEmailTo.Text) Or TxEmailTo.Text = "" Then
        Else
            Dim StrRecipientsTo() As String
            StrRecipientsTo = Split(TxEmailTo.Text, ";")
            'adds each email address to the send email function
            For Each RecTo As String In StrRecipientsTo
                '       .To.Add(New MailAddress(RecTo))
            Next
            '.To.Add("tristan@smartlearn.com.au")
        End If

        If IsNothing(TxEmailCC.Text) Or TxEmailCC.Text = "" Then
        Else
            Dim StrRecipientsCC() As String
            StrRecipientsCC = Split(TxEmailCC.Text, ";")
            'adds each email address to the send email function
            For Each RecCC As String In StrRecipientsCC
                '      .To.Add(New MailAddress(RecCC))
                '.To.Add(New MailAddress(TxEmailCC.Text))
            Next

        End If
        'adds all the contacts to the BCC
        If IsNothing(TxEmailBCC.Text) Or TxEmailBCC.Text = "" Then
        Else
            Dim StrRecipientsBCC() As String
            StrRecipientsBCC = Split(TxEmailBCC.Text, ";")
            'adds each email address to the send email function
            For Each RecBCC As String In StrRecipientsBCC
                '     .To.Add(New MailAddress(RecBCC))
            Next
        End If

        'Next we add the attachment of the log file.
        'Dim NewAttachment As New System.Net.Mail.Attachment(LstAttachmentsFullPath.Items.Item(AttachCurrent).Text)
        If MyEmailAttachment.ToString = "" Then
        Else
            Dim NewAttachment As New System.Net.Mail.Attachment(MyEmailAttachment)
            '.Attachments.Add(NewAttachment)
        End If

        '        .ReplyTo = New MailAddress(TxReplyEmail.Text, TxReplyname.Text)


        '.To.Add(TxEmailTo.Text)
        '.CC.Add(TxEmailCC.Text)
        '.Bcc.Add(TxEmailBCC.Text)



        AddHandler SendMessage.SendCompleted, AddressOf SendMessage_SendCompleted

        With SendMessage
            .Host = TxSMTPServer.Text
            .Port = 25
            .UseDefaultCredentials = False

            If Me.ChkSMTPAuth.Checked = True Then
                .Credentials = New Net.NetworkCredential("username", "password")
            Else
                .Timeout = 60000
            End If

            .EnableSsl = False

        End With


    End Sub
    Private Sub SendMessage_SendCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

        Dim SentInfo As Object = e.UserState 'Pass an identifier of the state of the email sent. 

        If e.Cancelled Then 'Operation was cancelled  
            Debug.WriteLine("Email cancelled.")
        End If

        If e.Error IsNot Nothing Then 'An error occured  
            Debug.WriteLine("Error: {0}", e.Error.ToString)
            MsgBox("Error: " & e.Error.ToString, MsgBoxStyle.Critical, "Error")
        Else 'No error occured  
            Debug.WriteLine("Email sent!")
            'MsgBox("Email sent successfully!", MsgBoxStyle.Information, "Message Sent")
        End If
    End Sub
End Class
