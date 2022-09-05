<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenScript = New System.Windows.Forms.OpenFileDialog
        Me.TabMain = New System.Windows.Forms.TabControl
        Me.TabBackup = New System.Windows.Forms.TabPage
        Me.grpBackupSetup = New System.Windows.Forms.GroupBox
        Me.GrType = New System.Windows.Forms.GroupBox
        Me.RadNormal = New System.Windows.Forms.RadioButton
        Me.RadScript = New System.Windows.Forms.RadioButton
        Me.BtEditScript = New System.Windows.Forms.Button
        Me.grpConfigurePaths = New System.Windows.Forms.GroupBox
        Me.txScript = New System.Windows.Forms.ComboBox
        Me.txScript1 = New System.Windows.Forms.TextBox
        Me.BtLoadScript = New System.Windows.Forms.Button
        Me.btnSource = New System.Windows.Forms.Button
        Me.txtDestination = New System.Windows.Forms.TextBox
        Me.btnDestination = New System.Windows.Forms.Button
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.grpLogging = New System.Windows.Forms.GroupBox
        Me.radLogAll = New System.Windows.Forms.RadioButton
        Me.radDoNotLog = New System.Windows.Forms.RadioButton
        Me.radLogOnlyErrors = New System.Windows.Forms.RadioButton
        Me.btnBeginBackup = New System.Windows.Forms.Button
        Me.grpBackupStatus = New System.Windows.Forms.GroupBox
        Me.LblFreeSpaceDest = New System.Windows.Forms.Label
        Me.LblFreeSpace = New System.Windows.Forms.Label
        Me.LblMbToCopy = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnResetStats = New System.Windows.Forms.Button
        Me.lblTimeElapsed = New System.Windows.Forms.Label
        Me.lblFilesRemaining = New System.Windows.Forms.Label
        Me.lbLFilesSkipped = New System.Windows.Forms.Label
        Me.lblFilesCopied = New System.Windows.Forms.Label
        Me.lblFileBeingCopied = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabOptions = New System.Windows.Forms.TabPage
        Me.ChkPromptReport = New System.Windows.Forms.CheckBox
        Me.ChkEmailLogFiles = New System.Windows.Forms.CheckBox
        Me.GrpAccount = New System.Windows.Forms.GroupBox
        Me.TabEmailDetail = New System.Windows.Forms.TabControl
        Me.TabEmailSendersDetails = New System.Windows.Forms.TabPage
        Me.LbReplyName = New System.Windows.Forms.Label
        Me.TxReplyEmail = New System.Windows.Forms.TextBox
        Me.LbEmailReply = New System.Windows.Forms.Label
        Me.TxReplyname = New System.Windows.Forms.TextBox
        Me.TxSendersEmail = New System.Windows.Forms.TextBox
        Me.LbSendersEmail = New System.Windows.Forms.Label
        Me.LbSendersName = New System.Windows.Forms.Label
        Me.TxSendersName = New System.Windows.Forms.TextBox
        Me.TabEmailSMTPSettings = New System.Windows.Forms.TabPage
        Me.TxSMTPPort = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbSMTPAuthentication = New System.Windows.Forms.Label
        Me.ChkSMTPAuth = New System.Windows.Forms.CheckBox
        Me.TxSMTPAccountName = New System.Windows.Forms.TextBox
        Me.TxSMTPServer = New System.Windows.Forms.TextBox
        Me.LbSMTPPassword = New System.Windows.Forms.Label
        Me.LbSMTP = New System.Windows.Forms.Label
        Me.LbSMTPUser = New System.Windows.Forms.Label
        Me.TxSMTPPassword = New System.Windows.Forms.TextBox
        Me.TabEmailMessage = New System.Windows.Forms.TabPage
        Me.TxEmailBody = New System.Windows.Forms.RichTextBox
        Me.LbSubject = New System.Windows.Forms.Label
        Me.TxEmailSubject = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxEmailBCC = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxEmailCC = New System.Windows.Forms.TextBox
        Me.LbEmailto = New System.Windows.Forms.Label
        Me.TxEmailTo = New System.Windows.Forms.TextBox
        Me.BtSaveInfo = New System.Windows.Forms.Button
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabBackup.SuspendLayout()
        Me.grpBackupSetup.SuspendLayout()
        Me.GrType.SuspendLayout()
        Me.grpConfigurePaths.SuspendLayout()
        Me.grpLogging.SuspendLayout()
        Me.grpBackupStatus.SuspendLayout()
        Me.TabOptions.SuspendLayout()
        Me.GrpAccount.SuspendLayout()
        Me.TabEmailDetail.SuspendLayout()
        Me.TabEmailSendersDetails.SuspendLayout()
        Me.TabEmailSMTPSettings.SuspendLayout()
        Me.TabEmailMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Click to restore program."
        Me.NotifyIcon1.BalloonTipTitle = "SmartBack"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Click to restore program."
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestoreToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(114, 26)
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RestoreToolStripMenuItem.Text = "R&estore"
        '
        'OpenScript
        '
        Me.OpenScript.DefaultExt = "INI"
        Me.OpenScript.Filter = "Script Files|*.ini"
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabBackup)
        Me.TabMain.Controls.Add(Me.TabOptions)
        Me.TabMain.Location = New System.Drawing.Point(12, 12)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(388, 499)
        Me.TabMain.TabIndex = 17
        '
        'TabBackup
        '
        Me.TabBackup.Controls.Add(Me.grpBackupSetup)
        Me.TabBackup.Controls.Add(Me.grpBackupStatus)
        Me.TabBackup.Location = New System.Drawing.Point(4, 22)
        Me.TabBackup.Name = "TabBackup"
        Me.TabBackup.Padding = New System.Windows.Forms.Padding(3)
        Me.TabBackup.Size = New System.Drawing.Size(380, 473)
        Me.TabBackup.TabIndex = 0
        Me.TabBackup.Text = "Backup"
        Me.TabBackup.UseVisualStyleBackColor = True
        '
        'grpBackupSetup
        '
        Me.grpBackupSetup.Controls.Add(Me.GrType)
        Me.grpBackupSetup.Controls.Add(Me.BtEditScript)
        Me.grpBackupSetup.Controls.Add(Me.grpConfigurePaths)
        Me.grpBackupSetup.Controls.Add(Me.grpLogging)
        Me.grpBackupSetup.Controls.Add(Me.btnBeginBackup)
        Me.grpBackupSetup.Location = New System.Drawing.Point(6, 6)
        Me.grpBackupSetup.Name = "grpBackupSetup"
        Me.grpBackupSetup.Size = New System.Drawing.Size(364, 265)
        Me.grpBackupSetup.TabIndex = 16
        Me.grpBackupSetup.TabStop = False
        Me.grpBackupSetup.Text = "Backup Setup"
        '
        'GrType
        '
        Me.GrType.Controls.Add(Me.RadNormal)
        Me.GrType.Controls.Add(Me.RadScript)
        Me.GrType.Location = New System.Drawing.Point(9, 71)
        Me.GrType.Name = "GrType"
        Me.GrType.Size = New System.Drawing.Size(349, 45)
        Me.GrType.TabIndex = 14
        Me.GrType.TabStop = False
        Me.GrType.Text = "Backup Type"
        '
        'RadNormal
        '
        Me.RadNormal.AutoSize = True
        Me.RadNormal.Checked = True
        Me.RadNormal.Location = New System.Drawing.Point(34, 16)
        Me.RadNormal.Name = "RadNormal"
        Me.RadNormal.Size = New System.Drawing.Size(114, 17)
        Me.RadNormal.TabIndex = 11
        Me.RadNormal.TabStop = True
        Me.RadNormal.Text = "Souce/Destination"
        Me.RadNormal.UseVisualStyleBackColor = True
        '
        'RadScript
        '
        Me.RadScript.AutoSize = True
        Me.RadScript.Location = New System.Drawing.Point(236, 16)
        Me.RadScript.Name = "RadScript"
        Me.RadScript.Size = New System.Drawing.Size(78, 17)
        Me.RadScript.TabIndex = 13
        Me.RadScript.Text = "From Script"
        Me.RadScript.UseVisualStyleBackColor = True
        '
        'BtEditScript
        '
        Me.BtEditScript.Location = New System.Drawing.Point(156, 236)
        Me.BtEditScript.Name = "BtEditScript"
        Me.BtEditScript.Size = New System.Drawing.Size(98, 23)
        Me.BtEditScript.TabIndex = 2
        Me.BtEditScript.Text = "&Script Editor"
        Me.BtEditScript.UseVisualStyleBackColor = True
        '
        'grpConfigurePaths
        '
        Me.grpConfigurePaths.Controls.Add(Me.txScript)
        Me.grpConfigurePaths.Controls.Add(Me.txScript1)
        Me.grpConfigurePaths.Controls.Add(Me.BtLoadScript)
        Me.grpConfigurePaths.Controls.Add(Me.btnSource)
        Me.grpConfigurePaths.Controls.Add(Me.txtDestination)
        Me.grpConfigurePaths.Controls.Add(Me.btnDestination)
        Me.grpConfigurePaths.Controls.Add(Me.txtSource)
        Me.grpConfigurePaths.Location = New System.Drawing.Point(9, 122)
        Me.grpConfigurePaths.Name = "grpConfigurePaths"
        Me.grpConfigurePaths.Size = New System.Drawing.Size(349, 108)
        Me.grpConfigurePaths.TabIndex = 1
        Me.grpConfigurePaths.TabStop = False
        Me.grpConfigurePaths.Text = "Configure Paths"
        '
        'txScript
        '
        Me.txScript.FormattingEnabled = True
        Me.txScript.Location = New System.Drawing.Point(115, 77)
        Me.txScript.Name = "txScript"
        Me.txScript.Size = New System.Drawing.Size(200, 21)
        Me.txScript.TabIndex = 22
        '
        'txScript1
        '
        Me.txScript1.Enabled = False
        Me.txScript1.Location = New System.Drawing.Point(115, 77)
        Me.txScript1.Name = "txScript1"
        Me.txScript1.Size = New System.Drawing.Size(200, 20)
        Me.txScript1.TabIndex = 8
        Me.txScript1.Text = "E:\test"
        '
        'BtLoadScript
        '
        Me.BtLoadScript.Enabled = False
        Me.BtLoadScript.Location = New System.Drawing.Point(34, 77)
        Me.BtLoadScript.Name = "BtLoadScript"
        Me.BtLoadScript.Size = New System.Drawing.Size(75, 23)
        Me.BtLoadScript.TabIndex = 7
        Me.BtLoadScript.Text = "&Script..."
        Me.BtLoadScript.UseVisualStyleBackColor = True
        '
        'btnSource
        '
        Me.btnSource.Location = New System.Drawing.Point(34, 19)
        Me.btnSource.Name = "btnSource"
        Me.btnSource.Size = New System.Drawing.Size(75, 23)
        Me.btnSource.TabIndex = 2
        Me.btnSource.Text = "&Source..."
        Me.btnSource.UseVisualStyleBackColor = True
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(115, 48)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(200, 20)
        Me.txtDestination.TabIndex = 6
        Me.txtDestination.Text = "E:\test"
        '
        'btnDestination
        '
        Me.btnDestination.Location = New System.Drawing.Point(34, 48)
        Me.btnDestination.Name = "btnDestination"
        Me.btnDestination.Size = New System.Drawing.Size(75, 23)
        Me.btnDestination.TabIndex = 3
        Me.btnDestination.Text = "&Destination..."
        Me.btnDestination.UseVisualStyleBackColor = True
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(115, 19)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(200, 20)
        Me.txtSource.TabIndex = 5
        Me.txtSource.Text = "C:\flash"
        '
        'grpLogging
        '
        Me.grpLogging.Controls.Add(Me.radLogAll)
        Me.grpLogging.Controls.Add(Me.radDoNotLog)
        Me.grpLogging.Controls.Add(Me.radLogOnlyErrors)
        Me.grpLogging.Location = New System.Drawing.Point(9, 19)
        Me.grpLogging.Name = "grpLogging"
        Me.grpLogging.Size = New System.Drawing.Size(349, 45)
        Me.grpLogging.TabIndex = 0
        Me.grpLogging.TabStop = False
        Me.grpLogging.Text = "Logging"
        '
        'radLogAll
        '
        Me.radLogAll.AutoSize = True
        Me.radLogAll.Location = New System.Drawing.Point(34, 16)
        Me.radLogAll.Name = "radLogAll"
        Me.radLogAll.Size = New System.Drawing.Size(93, 17)
        Me.radLogAll.TabIndex = 11
        Me.radLogAll.TabStop = True
        Me.radLogAll.Text = "Log All Events"
        Me.radLogAll.UseVisualStyleBackColor = True
        '
        'radDoNotLog
        '
        Me.radDoNotLog.AutoSize = True
        Me.radDoNotLog.Location = New System.Drawing.Point(236, 16)
        Me.radDoNotLog.Name = "radDoNotLog"
        Me.radDoNotLog.Size = New System.Drawing.Size(80, 17)
        Me.radDoNotLog.TabIndex = 13
        Me.radDoNotLog.TabStop = True
        Me.radDoNotLog.Text = "Do Not Log"
        Me.radDoNotLog.UseVisualStyleBackColor = True
        '
        'radLogOnlyErrors
        '
        Me.radLogOnlyErrors.AutoSize = True
        Me.radLogOnlyErrors.Checked = True
        Me.radLogOnlyErrors.Location = New System.Drawing.Point(133, 16)
        Me.radLogOnlyErrors.Name = "radLogOnlyErrors"
        Me.radLogOnlyErrors.Size = New System.Drawing.Size(97, 17)
        Me.radLogOnlyErrors.TabIndex = 12
        Me.radLogOnlyErrors.TabStop = True
        Me.radLogOnlyErrors.Text = "Log Only Errors"
        Me.radLogOnlyErrors.UseVisualStyleBackColor = True
        '
        'btnBeginBackup
        '
        Me.btnBeginBackup.Location = New System.Drawing.Point(260, 236)
        Me.btnBeginBackup.Name = "btnBeginBackup"
        Me.btnBeginBackup.Size = New System.Drawing.Size(98, 23)
        Me.btnBeginBackup.TabIndex = 1
        Me.btnBeginBackup.Text = "&Begin Backup"
        Me.btnBeginBackup.UseVisualStyleBackColor = True
        '
        'grpBackupStatus
        '
        Me.grpBackupStatus.Controls.Add(Me.LblFreeSpaceDest)
        Me.grpBackupStatus.Controls.Add(Me.LblFreeSpace)
        Me.grpBackupStatus.Controls.Add(Me.LblMbToCopy)
        Me.grpBackupStatus.Controls.Add(Me.Label5)
        Me.grpBackupStatus.Controls.Add(Me.btnResetStats)
        Me.grpBackupStatus.Controls.Add(Me.lblTimeElapsed)
        Me.grpBackupStatus.Controls.Add(Me.lblFilesRemaining)
        Me.grpBackupStatus.Controls.Add(Me.lbLFilesSkipped)
        Me.grpBackupStatus.Controls.Add(Me.lblFilesCopied)
        Me.grpBackupStatus.Controls.Add(Me.lblFileBeingCopied)
        Me.grpBackupStatus.Controls.Add(Me.ProgressBar1)
        Me.grpBackupStatus.Controls.Add(Me.Label2)
        Me.grpBackupStatus.Controls.Add(Me.Label4)
        Me.grpBackupStatus.Controls.Add(Me.Label1)
        Me.grpBackupStatus.Controls.Add(Me.Label3)
        Me.grpBackupStatus.Location = New System.Drawing.Point(6, 277)
        Me.grpBackupStatus.Name = "grpBackupStatus"
        Me.grpBackupStatus.Size = New System.Drawing.Size(364, 187)
        Me.grpBackupStatus.TabIndex = 17
        Me.grpBackupStatus.TabStop = False
        Me.grpBackupStatus.Text = "Backup Status"
        '
        'LblFreeSpaceDest
        '
        Me.LblFreeSpaceDest.Location = New System.Drawing.Point(144, 120)
        Me.LblFreeSpaceDest.Name = "LblFreeSpaceDest"
        Me.LblFreeSpaceDest.Size = New System.Drawing.Size(100, 13)
        Me.LblFreeSpaceDest.TabIndex = 22
        Me.LblFreeSpaceDest.Text = "                                              "
        Me.LblFreeSpaceDest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFreeSpace
        '
        Me.LblFreeSpace.AutoSize = True
        Me.LblFreeSpace.Location = New System.Drawing.Point(18, 120)
        Me.LblFreeSpace.Name = "LblFreeSpace"
        Me.LblFreeSpace.Size = New System.Drawing.Size(124, 13)
        Me.LblFreeSpace.TabIndex = 21
        Me.LblFreeSpace.Text = "Free Space (Remaining):"
        '
        'LblMbToCopy
        '
        Me.LblMbToCopy.Location = New System.Drawing.Point(144, 138)
        Me.LblMbToCopy.Name = "LblMbToCopy"
        Me.LblMbToCopy.Size = New System.Drawing.Size(100, 13)
        Me.LblMbToCopy.TabIndex = 20
        Me.LblMbToCopy.Text = "                                              "
        Me.LblMbToCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Remaining to Copy :"
        '
        'btnResetStats
        '
        Me.btnResetStats.Enabled = False
        Me.btnResetStats.Location = New System.Drawing.Point(258, 157)
        Me.btnResetStats.Name = "btnResetStats"
        Me.btnResetStats.Size = New System.Drawing.Size(98, 23)
        Me.btnResetStats.TabIndex = 18
        Me.btnResetStats.Text = "&Reset Stats"
        Me.btnResetStats.UseVisualStyleBackColor = True
        '
        'lblTimeElapsed
        '
        Me.lblTimeElapsed.AutoSize = True
        Me.lblTimeElapsed.Location = New System.Drawing.Point(36, 40)
        Me.lblTimeElapsed.Name = "lblTimeElapsed"
        Me.lblTimeElapsed.Size = New System.Drawing.Size(0, 13)
        Me.lblTimeElapsed.TabIndex = 17
        '
        'lblFilesRemaining
        '
        Me.lblFilesRemaining.AutoSize = True
        Me.lblFilesRemaining.Location = New System.Drawing.Point(276, 40)
        Me.lblFilesRemaining.Name = "lblFilesRemaining"
        Me.lblFilesRemaining.Size = New System.Drawing.Size(0, 13)
        Me.lblFilesRemaining.TabIndex = 17
        '
        'lbLFilesSkipped
        '
        Me.lbLFilesSkipped.AutoSize = True
        Me.lbLFilesSkipped.Location = New System.Drawing.Point(190, 40)
        Me.lbLFilesSkipped.Name = "lbLFilesSkipped"
        Me.lbLFilesSkipped.Size = New System.Drawing.Size(0, 13)
        Me.lbLFilesSkipped.TabIndex = 17
        '
        'lblFilesCopied
        '
        Me.lblFilesCopied.AutoSize = True
        Me.lblFilesCopied.Location = New System.Drawing.Point(118, 40)
        Me.lblFilesCopied.Name = "lblFilesCopied"
        Me.lblFilesCopied.Size = New System.Drawing.Size(0, 13)
        Me.lblFilesCopied.TabIndex = 16
        '
        'lblFileBeingCopied
        '
        Me.lblFileBeingCopied.AutoEllipsis = True
        Me.lblFileBeingCopied.Location = New System.Drawing.Point(20, 70)
        Me.lblFileBeingCopied.Name = "lblFileBeingCopied"
        Me.lblFileBeingCopied.Size = New System.Drawing.Size(326, 17)
        Me.lblFileBeingCopied.TabIndex = 16
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 88)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(326, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Time Elapsed:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Files Skipped:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(103, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Files Copied:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Files Remaining:"
        '
        'TabOptions
        '
        Me.TabOptions.Controls.Add(Me.ChkPromptReport)
        Me.TabOptions.Controls.Add(Me.ChkEmailLogFiles)
        Me.TabOptions.Controls.Add(Me.GrpAccount)
        Me.TabOptions.Controls.Add(Me.BtSaveInfo)
        Me.TabOptions.Location = New System.Drawing.Point(4, 22)
        Me.TabOptions.Name = "TabOptions"
        Me.TabOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabOptions.Size = New System.Drawing.Size(380, 473)
        Me.TabOptions.TabIndex = 1
        Me.TabOptions.Text = "Options"
        Me.TabOptions.UseVisualStyleBackColor = True
        '
        'ChkPromptReport
        '
        Me.ChkPromptReport.AutoSize = True
        Me.ChkPromptReport.Checked = True
        Me.ChkPromptReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPromptReport.Location = New System.Drawing.Point(17, 42)
        Me.ChkPromptReport.Name = "ChkPromptReport"
        Me.ChkPromptReport.Size = New System.Drawing.Size(193, 17)
        Me.ChkPromptReport.TabIndex = 48
        Me.ChkPromptReport.Text = "Prompt to load report after backup?"
        Me.ChkPromptReport.UseVisualStyleBackColor = True
        '
        'ChkEmailLogFiles
        '
        Me.ChkEmailLogFiles.AutoSize = True
        Me.ChkEmailLogFiles.Checked = True
        Me.ChkEmailLogFiles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEmailLogFiles.Location = New System.Drawing.Point(17, 19)
        Me.ChkEmailLogFiles.Name = "ChkEmailLogFiles"
        Me.ChkEmailLogFiles.Size = New System.Drawing.Size(96, 17)
        Me.ChkEmailLogFiles.TabIndex = 47
        Me.ChkEmailLogFiles.Text = "Email Log Files"
        Me.ChkEmailLogFiles.UseVisualStyleBackColor = True
        '
        'GrpAccount
        '
        Me.GrpAccount.Controls.Add(Me.TabEmailDetail)
        Me.GrpAccount.Controls.Add(Me.LbSubject)
        Me.GrpAccount.Controls.Add(Me.TxEmailSubject)
        Me.GrpAccount.Controls.Add(Me.Label9)
        Me.GrpAccount.Controls.Add(Me.TxEmailBCC)
        Me.GrpAccount.Controls.Add(Me.Label8)
        Me.GrpAccount.Controls.Add(Me.TxEmailCC)
        Me.GrpAccount.Controls.Add(Me.LbEmailto)
        Me.GrpAccount.Controls.Add(Me.TxEmailTo)
        Me.GrpAccount.Location = New System.Drawing.Point(6, 138)
        Me.GrpAccount.Name = "GrpAccount"
        Me.GrpAccount.Size = New System.Drawing.Size(352, 330)
        Me.GrpAccount.TabIndex = 46
        Me.GrpAccount.TabStop = False
        Me.GrpAccount.Text = "Email Settings"
        '
        'TabEmailDetail
        '
        Me.TabEmailDetail.Controls.Add(Me.TabEmailSendersDetails)
        Me.TabEmailDetail.Controls.Add(Me.TabEmailSMTPSettings)
        Me.TabEmailDetail.Controls.Add(Me.TabEmailMessage)
        Me.TabEmailDetail.Location = New System.Drawing.Point(6, 131)
        Me.TabEmailDetail.Name = "TabEmailDetail"
        Me.TabEmailDetail.SelectedIndex = 0
        Me.TabEmailDetail.Size = New System.Drawing.Size(335, 192)
        Me.TabEmailDetail.TabIndex = 18
        '
        'TabEmailSendersDetails
        '
        Me.TabEmailSendersDetails.Controls.Add(Me.LbReplyName)
        Me.TabEmailSendersDetails.Controls.Add(Me.TxReplyEmail)
        Me.TabEmailSendersDetails.Controls.Add(Me.LbEmailReply)
        Me.TabEmailSendersDetails.Controls.Add(Me.TxReplyname)
        Me.TabEmailSendersDetails.Controls.Add(Me.TxSendersEmail)
        Me.TabEmailSendersDetails.Controls.Add(Me.LbSendersEmail)
        Me.TabEmailSendersDetails.Controls.Add(Me.LbSendersName)
        Me.TabEmailSendersDetails.Controls.Add(Me.TxSendersName)
        Me.TabEmailSendersDetails.Location = New System.Drawing.Point(4, 22)
        Me.TabEmailSendersDetails.Name = "TabEmailSendersDetails"
        Me.TabEmailSendersDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEmailSendersDetails.Size = New System.Drawing.Size(327, 166)
        Me.TabEmailSendersDetails.TabIndex = 0
        Me.TabEmailSendersDetails.Text = "Senders Details"
        Me.TabEmailSendersDetails.UseVisualStyleBackColor = True
        '
        'LbReplyName
        '
        Me.LbReplyName.AutoSize = True
        Me.LbReplyName.Location = New System.Drawing.Point(17, 83)
        Me.LbReplyName.Name = "LbReplyName"
        Me.LbReplyName.Size = New System.Drawing.Size(68, 13)
        Me.LbReplyName.TabIndex = 51
        Me.LbReplyName.Text = "Reply Name:"
        '
        'TxReplyEmail
        '
        Me.TxReplyEmail.Location = New System.Drawing.Point(140, 111)
        Me.TxReplyEmail.Name = "TxReplyEmail"
        Me.TxReplyEmail.Size = New System.Drawing.Size(170, 20)
        Me.TxReplyEmail.TabIndex = 48
        Me.TxReplyEmail.Text = "tristan@smartlearn.com.au"
        '
        'LbEmailReply
        '
        Me.LbEmailReply.AutoSize = True
        Me.LbEmailReply.Location = New System.Drawing.Point(17, 114)
        Me.LbEmailReply.Name = "LbEmailReply"
        Me.LbEmailReply.Size = New System.Drawing.Size(65, 13)
        Me.LbEmailReply.TabIndex = 49
        Me.LbEmailReply.Text = "Reply Email:"
        '
        'TxReplyname
        '
        Me.TxReplyname.Location = New System.Drawing.Point(140, 80)
        Me.TxReplyname.Name = "TxReplyname"
        Me.TxReplyname.Size = New System.Drawing.Size(170, 20)
        Me.TxReplyname.TabIndex = 50
        Me.TxReplyname.Text = "Smart Studios"
        '
        'TxSendersEmail
        '
        Me.TxSendersEmail.Location = New System.Drawing.Point(140, 50)
        Me.TxSendersEmail.Name = "TxSendersEmail"
        Me.TxSendersEmail.Size = New System.Drawing.Size(170, 20)
        Me.TxSendersEmail.TabIndex = 44
        Me.TxSendersEmail.Text = "tristan@smartlearn.com.au"
        '
        'LbSendersEmail
        '
        Me.LbSendersEmail.AutoSize = True
        Me.LbSendersEmail.Location = New System.Drawing.Point(17, 53)
        Me.LbSendersEmail.Name = "LbSendersEmail"
        Me.LbSendersEmail.Size = New System.Drawing.Size(77, 13)
        Me.LbSendersEmail.TabIndex = 45
        Me.LbSendersEmail.Text = "Senders Email:"
        '
        'LbSendersName
        '
        Me.LbSendersName.AutoSize = True
        Me.LbSendersName.Location = New System.Drawing.Point(17, 24)
        Me.LbSendersName.Name = "LbSendersName"
        Me.LbSendersName.Size = New System.Drawing.Size(80, 13)
        Me.LbSendersName.TabIndex = 47
        Me.LbSendersName.Text = "Senders Name:"
        '
        'TxSendersName
        '
        Me.TxSendersName.Location = New System.Drawing.Point(140, 21)
        Me.TxSendersName.Name = "TxSendersName"
        Me.TxSendersName.Size = New System.Drawing.Size(170, 20)
        Me.TxSendersName.TabIndex = 46
        Me.TxSendersName.Text = "Smart Studios"
        '
        'TabEmailSMTPSettings
        '
        Me.TabEmailSMTPSettings.Controls.Add(Me.TxSMTPPort)
        Me.TabEmailSMTPSettings.Controls.Add(Me.Label6)
        Me.TabEmailSMTPSettings.Controls.Add(Me.lbSMTPAuthentication)
        Me.TabEmailSMTPSettings.Controls.Add(Me.ChkSMTPAuth)
        Me.TabEmailSMTPSettings.Controls.Add(Me.TxSMTPAccountName)
        Me.TabEmailSMTPSettings.Controls.Add(Me.TxSMTPServer)
        Me.TabEmailSMTPSettings.Controls.Add(Me.LbSMTPPassword)
        Me.TabEmailSMTPSettings.Controls.Add(Me.LbSMTP)
        Me.TabEmailSMTPSettings.Controls.Add(Me.LbSMTPUser)
        Me.TabEmailSMTPSettings.Controls.Add(Me.TxSMTPPassword)
        Me.TabEmailSMTPSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabEmailSMTPSettings.Name = "TabEmailSMTPSettings"
        Me.TabEmailSMTPSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEmailSMTPSettings.Size = New System.Drawing.Size(327, 166)
        Me.TabEmailSMTPSettings.TabIndex = 1
        Me.TabEmailSMTPSettings.Text = "SMTP Settings"
        Me.TabEmailSMTPSettings.UseVisualStyleBackColor = True
        '
        'TxSMTPPort
        '
        Me.TxSMTPPort.Location = New System.Drawing.Point(103, 50)
        Me.TxSMTPPort.Name = "TxSMTPPort"
        Me.TxSMTPPort.Size = New System.Drawing.Size(42, 20)
        Me.TxSMTPPort.TabIndex = 50
        Me.TxSMTPPort.Text = "25"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "SMTP Port:"
        '
        'lbSMTPAuthentication
        '
        Me.lbSMTPAuthentication.AutoSize = True
        Me.lbSMTPAuthentication.Location = New System.Drawing.Point(165, 53)
        Me.lbSMTPAuthentication.Name = "lbSMTPAuthentication"
        Me.lbSMTPAuthentication.Size = New System.Drawing.Size(123, 13)
        Me.lbSMTPAuthentication.TabIndex = 49
        Me.lbSMTPAuthentication.Text = "Requires Authentication:"
        '
        'ChkSMTPAuth
        '
        Me.ChkSMTPAuth.AutoSize = True
        Me.ChkSMTPAuth.Location = New System.Drawing.Point(294, 53)
        Me.ChkSMTPAuth.Name = "ChkSMTPAuth"
        Me.ChkSMTPAuth.Size = New System.Drawing.Size(15, 14)
        Me.ChkSMTPAuth.TabIndex = 48
        Me.ChkSMTPAuth.UseVisualStyleBackColor = True
        '
        'TxSMTPAccountName
        '
        Me.TxSMTPAccountName.Location = New System.Drawing.Point(103, 79)
        Me.TxSMTPAccountName.Name = "TxSMTPAccountName"
        Me.TxSMTPAccountName.Size = New System.Drawing.Size(207, 20)
        Me.TxSMTPAccountName.TabIndex = 44
        Me.TxSMTPAccountName.Text = "tristan@smartlearn.com.au"
        '
        'TxSMTPServer
        '
        Me.TxSMTPServer.Location = New System.Drawing.Point(103, 21)
        Me.TxSMTPServer.Name = "TxSMTPServer"
        Me.TxSMTPServer.Size = New System.Drawing.Size(207, 20)
        Me.TxSMTPServer.TabIndex = 42
        Me.TxSMTPServer.Text = "mail.bigpond.com"
        '
        'LbSMTPPassword
        '
        Me.LbSMTPPassword.AutoSize = True
        Me.LbSMTPPassword.Location = New System.Drawing.Point(17, 114)
        Me.LbSMTPPassword.Name = "LbSMTPPassword"
        Me.LbSMTPPassword.Size = New System.Drawing.Size(56, 13)
        Me.LbSMTPPassword.TabIndex = 47
        Me.LbSMTPPassword.Text = "Password:"
        '
        'LbSMTP
        '
        Me.LbSMTP.AutoSize = True
        Me.LbSMTP.Location = New System.Drawing.Point(17, 24)
        Me.LbSMTP.Name = "LbSMTP"
        Me.LbSMTP.Size = New System.Drawing.Size(74, 13)
        Me.LbSMTP.TabIndex = 43
        Me.LbSMTP.Text = "SMTP Server:"
        '
        'LbSMTPUser
        '
        Me.LbSMTPUser.AutoSize = True
        Me.LbSMTPUser.Location = New System.Drawing.Point(17, 82)
        Me.LbSMTPUser.Name = "LbSMTPUser"
        Me.LbSMTPUser.Size = New System.Drawing.Size(58, 13)
        Me.LbSMTPUser.TabIndex = 46
        Me.LbSMTPUser.Text = "Username:"
        '
        'TxSMTPPassword
        '
        Me.TxSMTPPassword.Location = New System.Drawing.Point(103, 111)
        Me.TxSMTPPassword.Name = "TxSMTPPassword"
        Me.TxSMTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxSMTPPassword.Size = New System.Drawing.Size(207, 20)
        Me.TxSMTPPassword.TabIndex = 45
        Me.TxSMTPPassword.Text = "susheima"
        '
        'TabEmailMessage
        '
        Me.TabEmailMessage.Controls.Add(Me.TxEmailBody)
        Me.TabEmailMessage.Location = New System.Drawing.Point(4, 22)
        Me.TabEmailMessage.Name = "TabEmailMessage"
        Me.TabEmailMessage.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEmailMessage.Size = New System.Drawing.Size(327, 166)
        Me.TabEmailMessage.TabIndex = 2
        Me.TabEmailMessage.Text = "Email Message"
        Me.TabEmailMessage.UseVisualStyleBackColor = True
        '
        'TxEmailBody
        '
        Me.TxEmailBody.Location = New System.Drawing.Point(5, 6)
        Me.TxEmailBody.Name = "TxEmailBody"
        Me.TxEmailBody.Size = New System.Drawing.Size(318, 155)
        Me.TxEmailBody.TabIndex = 0
        Me.TxEmailBody.Text = ""
        '
        'LbSubject
        '
        Me.LbSubject.AutoSize = True
        Me.LbSubject.Location = New System.Drawing.Point(38, 30)
        Me.LbSubject.Name = "LbSubject"
        Me.LbSubject.Size = New System.Drawing.Size(46, 13)
        Me.LbSubject.TabIndex = 52
        Me.LbSubject.Text = "Subject:"
        '
        'TxEmailSubject
        '
        Me.TxEmailSubject.Location = New System.Drawing.Point(161, 27)
        Me.TxEmailSubject.Name = "TxEmailSubject"
        Me.TxEmailSubject.Size = New System.Drawing.Size(170, 20)
        Me.TxEmailSubject.TabIndex = 51
        Me.TxEmailSubject.Text = "SmartBack"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(38, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Email BCC:"
        '
        'TxEmailBCC
        '
        Me.TxEmailBCC.Location = New System.Drawing.Point(161, 105)
        Me.TxEmailBCC.Name = "TxEmailBCC"
        Me.TxEmailBCC.Size = New System.Drawing.Size(170, 20)
        Me.TxEmailBCC.TabIndex = 49
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Email CC:"
        '
        'TxEmailCC
        '
        Me.TxEmailCC.Location = New System.Drawing.Point(161, 79)
        Me.TxEmailCC.Name = "TxEmailCC"
        Me.TxEmailCC.Size = New System.Drawing.Size(170, 20)
        Me.TxEmailCC.TabIndex = 47
        '
        'LbEmailto
        '
        Me.LbEmailto.AutoSize = True
        Me.LbEmailto.Location = New System.Drawing.Point(38, 56)
        Me.LbEmailto.Name = "LbEmailto"
        Me.LbEmailto.Size = New System.Drawing.Size(51, 13)
        Me.LbEmailto.TabIndex = 45
        Me.LbEmailto.Text = "Email To:"
        '
        'TxEmailTo
        '
        Me.TxEmailTo.Location = New System.Drawing.Point(161, 53)
        Me.TxEmailTo.Name = "TxEmailTo"
        Me.TxEmailTo.Size = New System.Drawing.Size(170, 20)
        Me.TxEmailTo.TabIndex = 44
        Me.TxEmailTo.Text = "tristan@smartlearn.com.au"
        '
        'BtSaveInfo
        '
        Me.BtSaveInfo.Location = New System.Drawing.Point(270, 6)
        Me.BtSaveInfo.Name = "BtSaveInfo"
        Me.BtSaveInfo.Size = New System.Drawing.Size(88, 30)
        Me.BtSaveInfo.TabIndex = 46
        Me.BtSaveInfo.Text = "Save"
        Me.BtSaveInfo.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 514)
        Me.Controls.Add(Me.TabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SmartBack"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabBackup.ResumeLayout(False)
        Me.grpBackupSetup.ResumeLayout(False)
        Me.GrType.ResumeLayout(False)
        Me.GrType.PerformLayout()
        Me.grpConfigurePaths.ResumeLayout(False)
        Me.grpConfigurePaths.PerformLayout()
        Me.grpLogging.ResumeLayout(False)
        Me.grpLogging.PerformLayout()
        Me.grpBackupStatus.ResumeLayout(False)
        Me.grpBackupStatus.PerformLayout()
        Me.TabOptions.ResumeLayout(False)
        Me.TabOptions.PerformLayout()
        Me.GrpAccount.ResumeLayout(False)
        Me.GrpAccount.PerformLayout()
        Me.TabEmailDetail.ResumeLayout(False)
        Me.TabEmailSendersDetails.ResumeLayout(False)
        Me.TabEmailSendersDetails.PerformLayout()
        Me.TabEmailSMTPSettings.ResumeLayout(False)
        Me.TabEmailSMTPSettings.PerformLayout()
        Me.TabEmailMessage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenScript As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabBackup As System.Windows.Forms.TabPage
    Friend WithEvents grpBackupSetup As System.Windows.Forms.GroupBox
    Friend WithEvents GrType As System.Windows.Forms.GroupBox
    Friend WithEvents RadNormal As System.Windows.Forms.RadioButton
    Friend WithEvents RadScript As System.Windows.Forms.RadioButton
    Friend WithEvents BtEditScript As System.Windows.Forms.Button
    Friend WithEvents grpConfigurePaths As System.Windows.Forms.GroupBox
    Friend WithEvents txScript1 As System.Windows.Forms.TextBox
    Friend WithEvents BtLoadScript As System.Windows.Forms.Button
    Friend WithEvents btnSource As System.Windows.Forms.Button
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents btnDestination As System.Windows.Forms.Button
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents grpLogging As System.Windows.Forms.GroupBox
    Friend WithEvents radLogAll As System.Windows.Forms.RadioButton
    Friend WithEvents radDoNotLog As System.Windows.Forms.RadioButton
    Friend WithEvents radLogOnlyErrors As System.Windows.Forms.RadioButton
    Friend WithEvents btnBeginBackup As System.Windows.Forms.Button
    Friend WithEvents grpBackupStatus As System.Windows.Forms.GroupBox
    Friend WithEvents LblFreeSpaceDest As System.Windows.Forms.Label
    Friend WithEvents LblFreeSpace As System.Windows.Forms.Label
    Friend WithEvents LblMbToCopy As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnResetStats As System.Windows.Forms.Button
    Public WithEvents lblTimeElapsed As System.Windows.Forms.Label
    Friend WithEvents lblFilesRemaining As System.Windows.Forms.Label
    Friend WithEvents lbLFilesSkipped As System.Windows.Forms.Label
    Friend WithEvents lblFilesCopied As System.Windows.Forms.Label
    Friend WithEvents lblFileBeingCopied As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabOptions As System.Windows.Forms.TabPage
    Friend WithEvents GrpAccount As System.Windows.Forms.GroupBox
    Friend WithEvents BtSaveInfo As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxEmailBCC As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxEmailCC As System.Windows.Forms.TextBox
    Friend WithEvents LbEmailto As System.Windows.Forms.Label
    Friend WithEvents TxEmailTo As System.Windows.Forms.TextBox
    Friend WithEvents LbSubject As System.Windows.Forms.Label
    Friend WithEvents TxEmailSubject As System.Windows.Forms.TextBox
    Friend WithEvents TabEmailDetail As System.Windows.Forms.TabControl
    Friend WithEvents TabEmailSendersDetails As System.Windows.Forms.TabPage
    Friend WithEvents LbReplyName As System.Windows.Forms.Label
    Friend WithEvents TxReplyEmail As System.Windows.Forms.TextBox
    Friend WithEvents LbEmailReply As System.Windows.Forms.Label
    Friend WithEvents TxReplyname As System.Windows.Forms.TextBox
    Friend WithEvents TxSendersEmail As System.Windows.Forms.TextBox
    Friend WithEvents LbSendersEmail As System.Windows.Forms.Label
    Friend WithEvents LbSendersName As System.Windows.Forms.Label
    Friend WithEvents TxSendersName As System.Windows.Forms.TextBox
    Friend WithEvents TabEmailSMTPSettings As System.Windows.Forms.TabPage
    Friend WithEvents TxSMTPPort As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbSMTPAuthentication As System.Windows.Forms.Label
    Friend WithEvents ChkSMTPAuth As System.Windows.Forms.CheckBox
    Friend WithEvents TxSMTPAccountName As System.Windows.Forms.TextBox
    Friend WithEvents TxSMTPServer As System.Windows.Forms.TextBox
    Friend WithEvents LbSMTPPassword As System.Windows.Forms.Label
    Friend WithEvents LbSMTP As System.Windows.Forms.Label
    Friend WithEvents LbSMTPUser As System.Windows.Forms.Label
    Friend WithEvents TxSMTPPassword As System.Windows.Forms.TextBox
    Friend WithEvents TabEmailMessage As System.Windows.Forms.TabPage
    Friend WithEvents TxEmailBody As System.Windows.Forms.RichTextBox
    Friend WithEvents ChkEmailLogFiles As System.Windows.Forms.CheckBox
    Friend WithEvents txScript As System.Windows.Forms.ComboBox
    Friend WithEvents ChkPromptReport As System.Windows.Forms.CheckBox
End Class
