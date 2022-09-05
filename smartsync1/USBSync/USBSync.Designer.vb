<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class USBSync
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(USBSync))
        Me.Folder = New System.Windows.Forms.FolderBrowserDialog
        Me.Tab = New System.Windows.Forms.TabControl
        Me.AutoSync = New System.Windows.Forms.TabPage
        Me.BtSync = New System.Windows.Forms.Button
        Me.TxtLog = New System.Windows.Forms.RichTextBox
        Me.View = New System.Windows.Forms.ListView
        Me.Drive = New System.Windows.Forms.ColumnHeader
        Me.Dir = New System.Windows.Forms.ColumnHeader
        Me.Status = New System.Windows.Forms.ColumnHeader
        Me.AuotSync = New System.Windows.Forms.ColumnHeader
        Me.MnuSyncList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuSyncNow = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.ReverseSyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
        Me.EditSyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAutoSync = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
        Me.ExploreDriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LbDrive = New System.Windows.Forms.Label
        Me.BtDelete = New System.Windows.Forms.Button
        Me.BtAdd = New System.Windows.Forms.Button
        Me.BtSave = New System.Windows.Forms.Button
        Me.USBScan = New System.Windows.Forms.TabPage
        Me.BtLoad = New System.Windows.Forms.Button
        Me.BtSaveScan = New System.Windows.Forms.Button
        Me.TxEdit = New System.Windows.Forms.TextBox
        Me.CbDrives = New System.Windows.Forms.ComboBox
        Me.BtRefresh = New System.Windows.Forms.Button
        Me.btScan = New System.Windows.Forms.Button
        Me.TabOptions = New System.Windows.Forms.TabPage
        Me.BtSaveCfg = New System.Windows.Forms.Button
        Me.ChkCopyMenu = New System.Windows.Forms.CheckBox
        Me.LblCopyMenu = New System.Windows.Forms.Label
        Me.ChkWindowsStartup = New System.Windows.Forms.CheckBox
        Me.ChkAutoSync = New System.Windows.Forms.CheckBox
        Me.LblAutoSync = New System.Windows.Forms.Label
        Me.LblwindowsStartup = New System.Windows.Forms.Label
        Me.LblloggingOptions = New System.Windows.Forms.Label
        Me.grpLogging = New System.Windows.Forms.GroupBox
        Me.radLogAll = New System.Windows.Forms.RadioButton
        Me.radDoNotLog = New System.Windows.Forms.RadioButton
        Me.radLogOnlyErrors = New System.Windows.Forms.RadioButton
        Me.TabSyncFileList = New System.Windows.Forms.TabPage
        Me.BtScriptDelete = New System.Windows.Forms.Button
        Me.BtScriptLoad = New System.Windows.Forms.Button
        Me.BtNewScript = New System.Windows.Forms.Button
        Me.BtScriptSave = New System.Windows.Forms.Button
        Me.BtnRemoveFolder = New System.Windows.Forms.Button
        Me.BtnAddFolder = New System.Windows.Forms.Button
        Me.BtnRemoveFile = New System.Windows.Forms.Button
        Me.BtnAddFile = New System.Windows.Forms.Button
        Me.BtScriptFilesRefresh = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbBackUpScript = New System.Windows.Forms.ComboBox
        Me.LblOptExplain = New System.Windows.Forms.Label
        Me.LblOptFolderList = New System.Windows.Forms.Label
        Me.LblOptFileList = New System.Windows.Forms.Label
        Me.LstCreatorFiles = New System.Windows.Forms.ListBox
        Me.LstCreatorFolders = New System.Windows.Forms.ListBox
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Save = New System.Windows.Forms.SaveFileDialog
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MnuUSBSync = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddDriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator
        Me.EjectDrivesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FDScriptCreator = New System.Windows.Forms.FolderBrowserDialog
        Me.FOScriptCreator = New System.Windows.Forms.OpenFileDialog
        Me.FDScriptNew = New System.Windows.Forms.SaveFileDialog
        Me.DriveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Tab.SuspendLayout()
        Me.AutoSync.SuspendLayout()
        Me.MnuSyncList.SuspendLayout()
        Me.USBScan.SuspendLayout()
        Me.TabOptions.SuspendLayout()
        Me.grpLogging.SuspendLayout()
        Me.TabSyncFileList.SuspendLayout()
        Me.MnuUSBSync.SuspendLayout()
        Me.SuspendLayout()
        '
        'Folder
        '
        Me.Folder.Description = "Select a directory for the sync root"
        Me.Folder.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Tab
        '
        Me.Tab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tab.Controls.Add(Me.AutoSync)
        Me.Tab.Controls.Add(Me.USBScan)
        Me.Tab.Controls.Add(Me.TabOptions)
        Me.Tab.Controls.Add(Me.TabSyncFileList)
        Me.Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab.HotTrack = True
        Me.Tab.Location = New System.Drawing.Point(0, 0)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(545, 485)
        Me.Tab.TabIndex = 0
        '
        'AutoSync
        '
        Me.AutoSync.Controls.Add(Me.BtSync)
        Me.AutoSync.Controls.Add(Me.TxtLog)
        Me.AutoSync.Controls.Add(Me.View)
        Me.AutoSync.Controls.Add(Me.LbDrive)
        Me.AutoSync.Controls.Add(Me.BtDelete)
        Me.AutoSync.Controls.Add(Me.BtAdd)
        Me.AutoSync.Controls.Add(Me.BtSave)
        Me.AutoSync.Location = New System.Drawing.Point(4, 25)
        Me.AutoSync.Name = "AutoSync"
        Me.AutoSync.Padding = New System.Windows.Forms.Padding(3)
        Me.AutoSync.Size = New System.Drawing.Size(537, 456)
        Me.AutoSync.TabIndex = 0
        Me.AutoSync.Text = "AutoSync"
        Me.AutoSync.UseVisualStyleBackColor = True
        '
        'BtSync
        '
        Me.BtSync.Image = Global.SmartSync.My.Resources.Resources.USBInProgress
        Me.BtSync.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSync.Location = New System.Drawing.Point(152, 8)
        Me.BtSync.Name = "BtSync"
        Me.BtSync.Size = New System.Drawing.Size(127, 36)
        Me.BtSync.TabIndex = 18
        Me.BtSync.Text = "Sync Selected"
        Me.BtSync.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtSync, "Start a Sync on the selected SYNC drive")
        Me.BtSync.UseVisualStyleBackColor = True
        '
        'TxtLog
        '
        Me.TxtLog.Location = New System.Drawing.Point(7, 228)
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.Size = New System.Drawing.Size(522, 226)
        Me.TxtLog.TabIndex = 17
        Me.TxtLog.Text = ""
        Me.ToolTip.SetToolTip(Me.TxtLog, "Log of the events that have happend")
        '
        'View
        '
        Me.View.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Drive, Me.Dir, Me.Status, Me.AuotSync})
        Me.View.ContextMenuStrip = Me.MnuSyncList
        Me.View.FullRowSelect = True
        Me.View.Location = New System.Drawing.Point(7, 50)
        Me.View.MultiSelect = False
        Me.View.Name = "View"
        Me.View.Size = New System.Drawing.Size(522, 154)
        Me.View.TabIndex = 16
        Me.View.UseCompatibleStateImageBehavior = False
        Me.View.View = System.Windows.Forms.View.Details
        '
        'Drive
        '
        Me.Drive.Text = "Drive Serial"
        Me.Drive.Width = 72
        '
        'Dir
        '
        Me.Dir.Text = "Directory / Script file"
        Me.Dir.Width = 266
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Status.Width = 96
        '
        'AuotSync
        '
        Me.AuotSync.Text = "AutoSync"
        Me.AuotSync.Width = 64
        '
        'MnuSyncList
        '
        Me.MnuSyncList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MnuSyncList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSyncNow, Me.ToolStripMenuItem3, Me.ReverseSyncToolStripMenuItem, Me.ToolStripMenuItem4, Me.EditSyncToolStripMenuItem, Me.MnuAutoSync, Me.ToolStripMenuItem5, Me.ExploreDriveToolStripMenuItem})
        Me.MnuSyncList.Name = "MnuSyncNow"
        Me.MnuSyncList.Size = New System.Drawing.Size(180, 132)
        Me.MnuSyncList.Text = "Sync Now"
        Me.ToolTip.SetToolTip(Me.MnuSyncList, "Start A sync now on the selected device.")
        '
        'MnuSyncNow
        '
        Me.MnuSyncNow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MnuSyncNow.Image = Global.SmartSync.My.Resources.Resources.USBInProgress
        Me.MnuSyncNow.Name = "MnuSyncNow"
        Me.MnuSyncNow.Size = New System.Drawing.Size(179, 22)
        Me.MnuSyncNow.Text = "Sync Now"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(176, 6)
        '
        'ReverseSyncToolStripMenuItem
        '
        Me.ReverseSyncToolStripMenuItem.Image = Global.SmartSync.My.Resources.Resources.USBInProgress
        Me.ReverseSyncToolStripMenuItem.Name = "ReverseSyncToolStripMenuItem"
        Me.ReverseSyncToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ReverseSyncToolStripMenuItem.Text = "Reverse Sync"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(176, 6)
        '
        'EditSyncToolStripMenuItem
        '
        Me.EditSyncToolStripMenuItem.Image = Global.SmartSync.My.Resources.Resources.USBInfo
        Me.EditSyncToolStripMenuItem.Name = "EditSyncToolStripMenuItem"
        Me.EditSyncToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.EditSyncToolStripMenuItem.Text = "Edit Sync"
        '
        'MnuAutoSync
        '
        Me.MnuAutoSync.Image = Global.SmartSync.My.Resources.Resources.USBSucessfull
        Me.MnuAutoSync.Name = "MnuAutoSync"
        Me.MnuAutoSync.Size = New System.Drawing.Size(179, 22)
        Me.MnuAutoSync.Text = "Auto Sync: Yes / No"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(176, 6)
        '
        'ExploreDriveToolStripMenuItem
        '
        Me.ExploreDriveToolStripMenuItem.Image = Global.SmartSync.My.Resources.Resources.Explore
        Me.ExploreDriveToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ExploreDriveToolStripMenuItem.Name = "ExploreDriveToolStripMenuItem"
        Me.ExploreDriveToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ExploreDriveToolStripMenuItem.Text = "Explore Drive"
        '
        'LbDrive
        '
        Me.LbDrive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbDrive.Location = New System.Drawing.Point(22, 207)
        Me.LbDrive.Name = "LbDrive"
        Me.LbDrive.Size = New System.Drawing.Size(466, 18)
        Me.LbDrive.TabIndex = 15
        Me.LbDrive.Text = "Waiting USB Signal"
        Me.LbDrive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtDelete
        '
        Me.BtDelete.Image = Global.SmartSync.My.Resources.Resources.USBClose
        Me.BtDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtDelete.Location = New System.Drawing.Point(410, 8)
        Me.BtDelete.Name = "BtDelete"
        Me.BtDelete.Size = New System.Drawing.Size(119, 36)
        Me.BtDelete.TabIndex = 13
        Me.BtDelete.Text = "Remove Sync"
        Me.BtDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtDelete, "Delete the selected SYNC.")
        Me.BtDelete.UseVisualStyleBackColor = True
        '
        'BtAdd
        '
        Me.BtAdd.Image = Global.SmartSync.My.Resources.Resources.USBAdd
        Me.BtAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtAdd.Location = New System.Drawing.Point(8, 8)
        Me.BtAdd.Name = "BtAdd"
        Me.BtAdd.Size = New System.Drawing.Size(138, 36)
        Me.BtAdd.TabIndex = 12
        Me.BtAdd.Text = "Add Drive To Sync"
        Me.BtAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtAdd, "Add a new SYNC to the list!")
        Me.BtAdd.UseVisualStyleBackColor = True
        '
        'BtSave
        '
        Me.BtSave.Image = Global.SmartSync.My.Resources.Resources.Save
        Me.BtSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSave.Location = New System.Drawing.Point(285, 8)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(119, 36)
        Me.BtSave.TabIndex = 11
        Me.BtSave.Text = "Save Config"
        Me.BtSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtSave, "Save the current configuration ")
        Me.BtSave.UseVisualStyleBackColor = True
        '
        'USBScan
        '
        Me.USBScan.Controls.Add(Me.BtLoad)
        Me.USBScan.Controls.Add(Me.BtSaveScan)
        Me.USBScan.Controls.Add(Me.TxEdit)
        Me.USBScan.Controls.Add(Me.CbDrives)
        Me.USBScan.Controls.Add(Me.BtRefresh)
        Me.USBScan.Controls.Add(Me.btScan)
        Me.USBScan.Location = New System.Drawing.Point(4, 25)
        Me.USBScan.Name = "USBScan"
        Me.USBScan.Padding = New System.Windows.Forms.Padding(3)
        Me.USBScan.Size = New System.Drawing.Size(537, 456)
        Me.USBScan.TabIndex = 1
        Me.USBScan.Text = "Usb Scan"
        Me.USBScan.UseVisualStyleBackColor = True
        '
        'BtLoad
        '
        Me.BtLoad.Image = Global.SmartSync.My.Resources.Resources.USBInfo
        Me.BtLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtLoad.Location = New System.Drawing.Point(373, 8)
        Me.BtLoad.Name = "BtLoad"
        Me.BtLoad.Size = New System.Drawing.Size(74, 32)
        Me.BtLoad.TabIndex = 10
        Me.BtLoad.Text = "Load"
        Me.BtLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtLoad, "Load an existing config file.")
        Me.BtLoad.UseVisualStyleBackColor = True
        '
        'BtSaveScan
        '
        Me.BtSaveScan.Image = Global.SmartSync.My.Resources.Resources.USBSave
        Me.BtSaveScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSaveScan.Location = New System.Drawing.Point(453, 8)
        Me.BtSaveScan.Name = "BtSaveScan"
        Me.BtSaveScan.Size = New System.Drawing.Size(74, 32)
        Me.BtSaveScan.TabIndex = 9
        Me.BtSaveScan.Text = "Save"
        Me.BtSaveScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtSaveScan, "Save config file.")
        Me.BtSaveScan.UseVisualStyleBackColor = True
        '
        'TxEdit
        '
        Me.TxEdit.Location = New System.Drawing.Point(8, 44)
        Me.TxEdit.Multiline = True
        Me.TxEdit.Name = "TxEdit"
        Me.TxEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxEdit.Size = New System.Drawing.Size(521, 404)
        Me.TxEdit.TabIndex = 8
        '
        'CbDrives
        '
        Me.CbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDrives.FormattingEnabled = True
        Me.CbDrives.Location = New System.Drawing.Point(8, 8)
        Me.CbDrives.Name = "CbDrives"
        Me.CbDrives.Size = New System.Drawing.Size(104, 21)
        Me.CbDrives.TabIndex = 5
        '
        'BtRefresh
        '
        Me.BtRefresh.Image = Global.SmartSync.My.Resources.Resources.USBSearch
        Me.BtRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtRefresh.Location = New System.Drawing.Point(133, 8)
        Me.BtRefresh.Name = "BtRefresh"
        Me.BtRefresh.Size = New System.Drawing.Size(121, 32)
        Me.BtRefresh.TabIndex = 7
        Me.BtRefresh.Text = "Refresh Drives"
        Me.BtRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtRefresh, "Refresh the drives list.")
        Me.BtRefresh.UseVisualStyleBackColor = True
        '
        'btScan
        '
        Me.btScan.Image = Global.SmartSync.My.Resources.Resources.USBMenu
        Me.btScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btScan.Location = New System.Drawing.Point(260, 8)
        Me.btScan.Name = "btScan"
        Me.btScan.Size = New System.Drawing.Size(107, 32)
        Me.btScan.TabIndex = 6
        Me.btScan.Text = "Create Menu"
        Me.btScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.btScan, "Create a new menu from the selected drive.")
        Me.btScan.UseVisualStyleBackColor = True
        '
        'TabOptions
        '
        Me.TabOptions.Controls.Add(Me.BtSaveCfg)
        Me.TabOptions.Controls.Add(Me.ChkCopyMenu)
        Me.TabOptions.Controls.Add(Me.LblCopyMenu)
        Me.TabOptions.Controls.Add(Me.ChkWindowsStartup)
        Me.TabOptions.Controls.Add(Me.ChkAutoSync)
        Me.TabOptions.Controls.Add(Me.LblAutoSync)
        Me.TabOptions.Controls.Add(Me.LblwindowsStartup)
        Me.TabOptions.Controls.Add(Me.LblloggingOptions)
        Me.TabOptions.Controls.Add(Me.grpLogging)
        Me.TabOptions.Location = New System.Drawing.Point(4, 25)
        Me.TabOptions.Name = "TabOptions"
        Me.TabOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabOptions.Size = New System.Drawing.Size(537, 456)
        Me.TabOptions.TabIndex = 2
        Me.TabOptions.Text = "Options"
        Me.TabOptions.UseVisualStyleBackColor = True
        '
        'BtSaveCfg
        '
        Me.BtSaveCfg.Image = Global.SmartSync.My.Resources.Resources.Save
        Me.BtSaveCfg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSaveCfg.Location = New System.Drawing.Point(410, 412)
        Me.BtSaveCfg.Name = "BtSaveCfg"
        Me.BtSaveCfg.Size = New System.Drawing.Size(119, 36)
        Me.BtSaveCfg.TabIndex = 12
        Me.BtSaveCfg.Text = "Save Config"
        Me.BtSaveCfg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip.SetToolTip(Me.BtSaveCfg, "Save the current config file.")
        Me.BtSaveCfg.UseVisualStyleBackColor = True
        '
        'ChkCopyMenu
        '
        Me.ChkCopyMenu.AutoSize = True
        Me.ChkCopyMenu.Location = New System.Drawing.Point(275, 219)
        Me.ChkCopyMenu.Name = "ChkCopyMenu"
        Me.ChkCopyMenu.Size = New System.Drawing.Size(15, 14)
        Me.ChkCopyMenu.TabIndex = 8
        Me.ChkCopyMenu.UseVisualStyleBackColor = True
        '
        'LblCopyMenu
        '
        Me.LblCopyMenu.AutoSize = True
        Me.LblCopyMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCopyMenu.Location = New System.Drawing.Point(14, 217)
        Me.LblCopyMenu.Name = "LblCopyMenu"
        Me.LblCopyMenu.Size = New System.Drawing.Size(255, 16)
        Me.LblCopyMenu.TabIndex = 7
        Me.LblCopyMenu.Text = "Copy Menu and autorun.inf at end of Sync:"
        '
        'ChkWindowsStartup
        '
        Me.ChkWindowsStartup.AutoSize = True
        Me.ChkWindowsStartup.Location = New System.Drawing.Point(275, 103)
        Me.ChkWindowsStartup.Name = "ChkWindowsStartup"
        Me.ChkWindowsStartup.Size = New System.Drawing.Size(15, 14)
        Me.ChkWindowsStartup.TabIndex = 6
        Me.ChkWindowsStartup.UseVisualStyleBackColor = True
        '
        'ChkAutoSync
        '
        Me.ChkAutoSync.AutoSize = True
        Me.ChkAutoSync.Location = New System.Drawing.Point(275, 158)
        Me.ChkAutoSync.Name = "ChkAutoSync"
        Me.ChkAutoSync.Size = New System.Drawing.Size(15, 14)
        Me.ChkAutoSync.TabIndex = 5
        Me.ChkAutoSync.UseVisualStyleBackColor = True
        '
        'LblAutoSync
        '
        Me.LblAutoSync.AutoSize = True
        Me.LblAutoSync.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAutoSync.Location = New System.Drawing.Point(14, 156)
        Me.LblAutoSync.Name = "LblAutoSync"
        Me.LblAutoSync.Size = New System.Drawing.Size(205, 16)
        Me.LblAutoSync.TabIndex = 4
        Me.LblAutoSync.Text = "AutoSync on USB Device Detect:"
        '
        'LblwindowsStartup
        '
        Me.LblwindowsStartup.AutoSize = True
        Me.LblwindowsStartup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblwindowsStartup.Location = New System.Drawing.Point(14, 101)
        Me.LblwindowsStartup.Name = "LblwindowsStartup"
        Me.LblwindowsStartup.Size = New System.Drawing.Size(171, 16)
        Me.LblwindowsStartup.TabIndex = 3
        Me.LblwindowsStartup.Text = "Launch on windows Startup:"
        '
        'LblloggingOptions
        '
        Me.LblloggingOptions.AutoSize = True
        Me.LblloggingOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblloggingOptions.Location = New System.Drawing.Point(14, 38)
        Me.LblloggingOptions.Name = "LblloggingOptions"
        Me.LblloggingOptions.Size = New System.Drawing.Size(163, 16)
        Me.LblloggingOptions.TabIndex = 2
        Me.LblloggingOptions.Text = "Select The Logging Type:"
        '
        'grpLogging
        '
        Me.grpLogging.Controls.Add(Me.radLogAll)
        Me.grpLogging.Controls.Add(Me.radDoNotLog)
        Me.grpLogging.Controls.Add(Me.radLogOnlyErrors)
        Me.grpLogging.Location = New System.Drawing.Point(180, 22)
        Me.grpLogging.Name = "grpLogging"
        Me.grpLogging.Size = New System.Drawing.Size(349, 45)
        Me.grpLogging.TabIndex = 1
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
        'TabSyncFileList
        '
        Me.TabSyncFileList.Controls.Add(Me.BtScriptDelete)
        Me.TabSyncFileList.Controls.Add(Me.BtScriptLoad)
        Me.TabSyncFileList.Controls.Add(Me.BtNewScript)
        Me.TabSyncFileList.Controls.Add(Me.BtScriptSave)
        Me.TabSyncFileList.Controls.Add(Me.BtnRemoveFolder)
        Me.TabSyncFileList.Controls.Add(Me.BtnAddFolder)
        Me.TabSyncFileList.Controls.Add(Me.BtnRemoveFile)
        Me.TabSyncFileList.Controls.Add(Me.BtnAddFile)
        Me.TabSyncFileList.Controls.Add(Me.BtScriptFilesRefresh)
        Me.TabSyncFileList.Controls.Add(Me.Label1)
        Me.TabSyncFileList.Controls.Add(Me.CmbBackUpScript)
        Me.TabSyncFileList.Controls.Add(Me.LblOptExplain)
        Me.TabSyncFileList.Controls.Add(Me.LblOptFolderList)
        Me.TabSyncFileList.Controls.Add(Me.LblOptFileList)
        Me.TabSyncFileList.Controls.Add(Me.LstCreatorFiles)
        Me.TabSyncFileList.Controls.Add(Me.LstCreatorFolders)
        Me.TabSyncFileList.Location = New System.Drawing.Point(4, 25)
        Me.TabSyncFileList.Name = "TabSyncFileList"
        Me.TabSyncFileList.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSyncFileList.Size = New System.Drawing.Size(537, 456)
        Me.TabSyncFileList.TabIndex = 3
        Me.TabSyncFileList.Text = "Backup Script Creator"
        Me.TabSyncFileList.UseVisualStyleBackColor = True
        '
        'BtScriptDelete
        '
        Me.BtScriptDelete.Image = Global.SmartSync.My.Resources.Resources.ScriptDelete
        Me.BtScriptDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtScriptDelete.Location = New System.Drawing.Point(339, 38)
        Me.BtScriptDelete.Name = "BtScriptDelete"
        Me.BtScriptDelete.Size = New System.Drawing.Size(105, 36)
        Me.BtScriptDelete.TabIndex = 15
        Me.BtScriptDelete.Text = "Delete Script"
        Me.BtScriptDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtScriptDelete.UseVisualStyleBackColor = True
        '
        'BtScriptLoad
        '
        Me.BtScriptLoad.Image = Global.SmartSync.My.Resources.Resources.ScriptLoad
        Me.BtScriptLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtScriptLoad.Location = New System.Drawing.Point(228, 38)
        Me.BtScriptLoad.Name = "BtScriptLoad"
        Me.BtScriptLoad.Size = New System.Drawing.Size(105, 36)
        Me.BtScriptLoad.TabIndex = 14
        Me.BtScriptLoad.Text = "Load Script"
        Me.BtScriptLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtScriptLoad.UseVisualStyleBackColor = True
        '
        'BtNewScript
        '
        Me.BtNewScript.Image = Global.SmartSync.My.Resources.Resources.ScriptAdd
        Me.BtNewScript.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtNewScript.Location = New System.Drawing.Point(9, 38)
        Me.BtNewScript.Name = "BtNewScript"
        Me.BtNewScript.Size = New System.Drawing.Size(103, 36)
        Me.BtNewScript.TabIndex = 13
        Me.BtNewScript.Text = "New Script"
        Me.BtNewScript.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtNewScript.UseVisualStyleBackColor = True
        '
        'BtScriptSave
        '
        Me.BtScriptSave.Image = Global.SmartSync.My.Resources.Resources.ScriptSave
        Me.BtScriptSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtScriptSave.Location = New System.Drawing.Point(118, 38)
        Me.BtScriptSave.Name = "BtScriptSave"
        Me.BtScriptSave.Size = New System.Drawing.Size(104, 36)
        Me.BtScriptSave.TabIndex = 12
        Me.BtScriptSave.Text = "Save Script"
        Me.BtScriptSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtScriptSave.UseVisualStyleBackColor = True
        '
        'BtnRemoveFolder
        '
        Me.BtnRemoveFolder.Location = New System.Drawing.Point(433, 86)
        Me.BtnRemoveFolder.Name = "BtnRemoveFolder"
        Me.BtnRemoveFolder.Size = New System.Drawing.Size(80, 24)
        Me.BtnRemoveFolder.TabIndex = 11
        Me.BtnRemoveFolder.Text = "Remove Item"
        Me.BtnRemoveFolder.UseVisualStyleBackColor = True
        '
        'BtnAddFolder
        '
        Me.BtnAddFolder.Location = New System.Drawing.Point(336, 86)
        Me.BtnAddFolder.Name = "BtnAddFolder"
        Me.BtnAddFolder.Size = New System.Drawing.Size(80, 24)
        Me.BtnAddFolder.TabIndex = 10
        Me.BtnAddFolder.Text = "Add A Folder"
        Me.BtnAddFolder.UseVisualStyleBackColor = True
        '
        'BtnRemoveFile
        '
        Me.BtnRemoveFile.Location = New System.Drawing.Point(433, 256)
        Me.BtnRemoveFile.Name = "BtnRemoveFile"
        Me.BtnRemoveFile.Size = New System.Drawing.Size(80, 24)
        Me.BtnRemoveFile.TabIndex = 9
        Me.BtnRemoveFile.Text = "Remove Item"
        Me.BtnRemoveFile.UseVisualStyleBackColor = True
        '
        'BtnAddFile
        '
        Me.BtnAddFile.Location = New System.Drawing.Point(339, 256)
        Me.BtnAddFile.Name = "BtnAddFile"
        Me.BtnAddFile.Size = New System.Drawing.Size(80, 24)
        Me.BtnAddFile.TabIndex = 8
        Me.BtnAddFile.Text = "Add A File"
        Me.BtnAddFile.UseVisualStyleBackColor = True
        '
        'BtScriptFilesRefresh
        '
        Me.BtScriptFilesRefresh.Location = New System.Drawing.Point(415, 8)
        Me.BtScriptFilesRefresh.Name = "BtScriptFilesRefresh"
        Me.BtScriptFilesRefresh.Size = New System.Drawing.Size(98, 21)
        Me.BtScriptFilesRefresh.TabIndex = 7
        Me.BtScriptFilesRefresh.Text = "Refresh List"
        Me.BtScriptFilesRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select a script to Edit:"
        '
        'CmbBackUpScript
        '
        Me.CmbBackUpScript.FormattingEnabled = True
        Me.CmbBackUpScript.Location = New System.Drawing.Point(165, 8)
        Me.CmbBackUpScript.Name = "CmbBackUpScript"
        Me.CmbBackUpScript.Size = New System.Drawing.Size(244, 21)
        Me.CmbBackUpScript.TabIndex = 5
        '
        'LblOptExplain
        '
        Me.LblOptExplain.AutoSize = True
        Me.LblOptExplain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LblOptExplain.Location = New System.Drawing.Point(22, 436)
        Me.LblOptExplain.Name = "LblOptExplain"
        Me.LblOptExplain.Size = New System.Drawing.Size(475, 15)
        Me.LblOptExplain.TabIndex = 4
        Me.LblOptExplain.Text = "Simply Click the add buttons to add folders and files you wish to include in the " & _
            "back list."
        '
        'LblOptFolderList
        '
        Me.LblOptFolderList.AutoSize = True
        Me.LblOptFolderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.LblOptFolderList.Location = New System.Drawing.Point(8, 92)
        Me.LblOptFolderList.Name = "LblOptFolderList"
        Me.LblOptFolderList.Size = New System.Drawing.Size(81, 18)
        Me.LblOptFolderList.TabIndex = 3
        Me.LblOptFolderList.Text = "Folder List:"
        '
        'LblOptFileList
        '
        Me.LblOptFileList.AutoSize = True
        Me.LblOptFileList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.LblOptFileList.Location = New System.Drawing.Point(9, 265)
        Me.LblOptFileList.Name = "LblOptFileList"
        Me.LblOptFileList.Size = New System.Drawing.Size(62, 18)
        Me.LblOptFileList.TabIndex = 2
        Me.LblOptFileList.Text = "File List:"
        '
        'LstCreatorFiles
        '
        Me.LstCreatorFiles.FormattingEnabled = True
        Me.LstCreatorFiles.Location = New System.Drawing.Point(9, 286)
        Me.LstCreatorFiles.Name = "LstCreatorFiles"
        Me.LstCreatorFiles.Size = New System.Drawing.Size(504, 147)
        Me.LstCreatorFiles.TabIndex = 1
        '
        'LstCreatorFolders
        '
        Me.LstCreatorFolders.FormattingEnabled = True
        Me.LstCreatorFolders.Location = New System.Drawing.Point(9, 116)
        Me.LstCreatorFolders.Name = "LstCreatorFolders"
        Me.LstCreatorFolders.Size = New System.Drawing.Size(504, 134)
        Me.LstCreatorFolders.TabIndex = 0
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 300
        '
        'Save
        '
        Me.Save.DefaultExt = "*.ini"
        Me.Save.Filter = "Config files|*.ini"
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.MnuUSBSync
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "Smart Sync"
        Me.NotifyIcon.Visible = True
        '
        'MnuUSBSync
        '
        Me.MnuUSBSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MnuUSBSync.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddDriveToolStripMenuItem, Me.ToolStripMenuItem1, Me.SaveConfigToolStripMenuItem, Me.LoadConfigToolStripMenuItem, Me.ToolStripMenuItem7, Me.EjectDrivesToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.MnuUSBSync.Name = "MnuUSBSync"
        Me.MnuUSBSync.Size = New System.Drawing.Size(197, 154)
        '
        'AddDriveToolStripMenuItem
        '
        Me.AddDriveToolStripMenuItem.Image = Global.SmartSync.My.Resources.Resources.USBAdd
        Me.AddDriveToolStripMenuItem.Name = "AddDriveToolStripMenuItem"
        Me.AddDriveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AddDriveToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.AddDriveToolStripMenuItem.Text = "Add Sync Drive"
        Me.AddDriveToolStripMenuItem.ToolTipText = "Select a new Sync Location and a drive to Sync to."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(193, 6)
        '
        'SaveConfigToolStripMenuItem
        '
        Me.SaveConfigToolStripMenuItem.Image = Global.SmartSync.My.Resources.Resources.Save
        Me.SaveConfigToolStripMenuItem.Name = "SaveConfigToolStripMenuItem"
        Me.SaveConfigToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveConfigToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.SaveConfigToolStripMenuItem.Text = "Save Config"
        '
        'LoadConfigToolStripMenuItem
        '
        Me.LoadConfigToolStripMenuItem.Image = Global.SmartSync.My.Resources.Resources.Load
        Me.LoadConfigToolStripMenuItem.Name = "LoadConfigToolStripMenuItem"
        Me.LoadConfigToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.LoadConfigToolStripMenuItem.Text = "Load Config"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(193, 6)
        '
        'EjectDrivesToolStripMenuItem
        '
        Me.EjectDrivesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DriveToolStripMenuItem})
        Me.EjectDrivesToolStripMenuItem.Name = "EjectDrivesToolStripMenuItem"
        Me.EjectDrivesToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.EjectDrivesToolStripMenuItem.Text = "Eject Drives"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(193, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.SmartSync.My.Resources.Resources._Exit
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'FDScriptCreator
        '
        Me.FDScriptCreator.Description = "Select a folder to add to the list."
        Me.FDScriptCreator.ShowNewFolderButton = False
        '
        'FDScriptNew
        '
        Me.FDScriptNew.Filter = "Script Files|*.ini"
        '
        'DriveToolStripMenuItem
        '
        Me.DriveToolStripMenuItem.Name = "DriveToolStripMenuItem"
        Me.DriveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DriveToolStripMenuItem.Text = "Drives"
        '
        'USBSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(545, 485)
        Me.ContextMenuStrip = Me.MnuUSBSync
        Me.Controls.Add(Me.Tab)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "USBSync"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SmartSync - USB Folder Syncer"
        Me.Tab.ResumeLayout(False)
        Me.AutoSync.ResumeLayout(False)
        Me.MnuSyncList.ResumeLayout(False)
        Me.USBScan.ResumeLayout(False)
        Me.USBScan.PerformLayout()
        Me.TabOptions.ResumeLayout(False)
        Me.TabOptions.PerformLayout()
        Me.grpLogging.ResumeLayout(False)
        Me.grpLogging.PerformLayout()
        Me.TabSyncFileList.ResumeLayout(False)
        Me.TabSyncFileList.PerformLayout()
        Me.MnuUSBSync.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Folder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents AutoSync As System.Windows.Forms.TabPage
    Friend WithEvents View As System.Windows.Forms.ListView
    Friend WithEvents Drive As System.Windows.Forms.ColumnHeader
    Friend WithEvents Dir As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents LbDrive As System.Windows.Forms.Label
    Friend WithEvents BtDelete As System.Windows.Forms.Button
    Friend WithEvents BtAdd As System.Windows.Forms.Button
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents USBScan As System.Windows.Forms.TabPage
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents BtSaveScan As System.Windows.Forms.Button
    Friend WithEvents TxEdit As System.Windows.Forms.TextBox
    Friend WithEvents BtRefresh As System.Windows.Forms.Button
    Friend WithEvents btScan As System.Windows.Forms.Button
    Friend WithEvents CbDrives As System.Windows.Forms.ComboBox
    Friend WithEvents Save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TxtLog As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents MnuSyncList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuSyncNow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUSBSync As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddDriveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtSync As System.Windows.Forms.Button
    Friend WithEvents BtLoad As System.Windows.Forms.Button
    Friend WithEvents TabOptions As System.Windows.Forms.TabPage
    Friend WithEvents LblAutoSync As System.Windows.Forms.Label
    Friend WithEvents LblwindowsStartup As System.Windows.Forms.Label
    Friend WithEvents LblloggingOptions As System.Windows.Forms.Label
    Friend WithEvents grpLogging As System.Windows.Forms.GroupBox
    Friend WithEvents radLogAll As System.Windows.Forms.RadioButton
    Friend WithEvents radDoNotLog As System.Windows.Forms.RadioButton
    Friend WithEvents radLogOnlyErrors As System.Windows.Forms.RadioButton
    Friend WithEvents ChkAutoSync As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWindowsStartup As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCopyMenu As System.Windows.Forms.CheckBox
    Friend WithEvents LblCopyMenu As System.Windows.Forms.Label
    Friend WithEvents BtSaveCfg As System.Windows.Forms.Button
    Friend WithEvents AuotSync As System.Windows.Forms.ColumnHeader
    Friend WithEvents ExploreDriveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAutoSync As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReverseSyncToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditSyncToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoadConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabSyncFileList As System.Windows.Forms.TabPage
    Friend WithEvents LblOptExplain As System.Windows.Forms.Label
    Friend WithEvents LblOptFolderList As System.Windows.Forms.Label
    Friend WithEvents LblOptFileList As System.Windows.Forms.Label
    Friend WithEvents LstCreatorFiles As System.Windows.Forms.ListBox
    Friend WithEvents LstCreatorFolders As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbBackUpScript As System.Windows.Forms.ComboBox
    Friend WithEvents BtScriptFilesRefresh As System.Windows.Forms.Button
    Friend WithEvents BtnAddFile As System.Windows.Forms.Button
    Friend WithEvents BtnRemoveFolder As System.Windows.Forms.Button
    Friend WithEvents BtnAddFolder As System.Windows.Forms.Button
    Friend WithEvents BtnRemoveFile As System.Windows.Forms.Button
    Friend WithEvents FDScriptCreator As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FOScriptCreator As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtNewScript As System.Windows.Forms.Button
    Friend WithEvents BtScriptSave As System.Windows.Forms.Button
    Friend WithEvents FDScriptNew As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BtScriptLoad As System.Windows.Forms.Button
    Friend WithEvents BtScriptDelete As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EjectDrivesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DriveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
