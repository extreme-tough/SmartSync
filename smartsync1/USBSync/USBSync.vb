Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Threading
Imports SmartSync.BackupUtil
Imports System.Resources
Imports Microsoft.Win32


Public Class USBSync
    Public Shared PassFolderOrScript As String
    Public Shared PassDrive As String
    Dim ScriptsFolder As String = (Application.StartupPath + "\scripts\")
    Dim ScriptsFolderFiles As New DirectoryInfo(Application.StartupPath + "\scripts")

#Region "Constants"

    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004
    Private Const DBT_DEVTYP_VOLUME As Integer = &H2

#End Region

#Region "Structures"
    ' The different states of a log message
    Public Enum USBState
        None = 0
        Sucessfull = 1
        Add = 2
        Close = 3
        Info = 4
        InProgress = 5
        Save = 6
    End Enum
    ' Configuration data
    Public Structure TConfig
        Public LogType As Integer
        Public WinStartup As Boolean
        Public AutoSync As Boolean
        Public CopyMenu As Boolean
    End Structure
    ' All the info needed to redraw a single Richtexbox Line
    Public Structure LogLine
        Public Message As String
        Public Time As String
        Public Color As Color
        Public Icon As USBState
    End Structure

    Private Structure NodeInfo
        Public Serial As String
        Public State As String
        Public DriveAutoSync As String
        Public Message As String
        Public MessageColor As Color
        Public DrawMessage As Boolean
    End Structure
    Private Structure DEV_BROADCAST_HDR
        Public dbch_size As Int32
        Public dbch_devicetype As Int32
        Public dbch_reserved As Int32
    End Structure

    Private Structure DEV_BROADCAST_VOLUME
        Public dbcv_size As Int32
        Public dbcv_devicetype As Int32
        Public dbcv_reserved As Int32
        Public dbcv_unitmask As Int32
        Public dbcv_flags As Int32
    End Structure

#End Region

#Region "WndProc (HERE WE DETECT THE USB PLUG EVENT"
    ' Here we detect the plug of an usb drive
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Windows MESSAGE
        Dim Info As DriveInfo
        Dim Item As ListViewItem
        Dim Node As NodeInfo = Nothing

        If m.Msg = WM_DEVICECHANGE Then
            ' Check to see if device was plugged in
            If m.WParam.ToInt32() = DBT_DEVICEARRIVAL Then
                Dim hdr As DEV_BROADCAST_HDR = CType(Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_HDR)), DEV_BROADCAST_HDR)
                ' See if the device is a USB Flash Drive etc.
                If hdr.dbch_devicetype = DBT_DEVTYP_VOLUME Then
                    ' Declare volume as structure
                    Dim vol As DEV_BROADCAST_VOLUME = CType(Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_VOLUME)), DEV_BROADCAST_VOLUME)
                    ' Get volume number
                    Dim mask As Int32 = vol.dbcv_unitmask
                    ' Get the drive letter
                    Dim chDriveLetter As Char = GetDriveLetter(mask)
                    ' Display the drive letter
                    LbDrive.Text = String.Format("USB Flash Drive Plugged Into {0}:", chDriveLetter.ToString().ToUpper())

                    '
                    ' HERE WE CHECK IF AUTOSYNC IS TRUE TO WORK WITH IT.
                    '
                    ' If active, sync auto, else add a item to list in idle state.
                    '
                    If Config.AutoSync Then
                        ' If global autosync is ON then check if the item in the list is ON too.
                        Info = GetDriveInfo(chDriveLetter + ":\")
                        For Each Item In Me.View.Items
                            If Item.Text = Info.Serial Then
                                If Item.SubItems(3).Text = "Yes" Then
                                    Me.SyncFiles(chDriveLetter)
                                Else
                                    Item.SubItems(2).Text = "Idle"
                                    Node.State = "Idle"
                                    Node.DrawMessage = False
                                    Node.Serial = Item.Text
                                    Me.SerialList(Item.Index) = Node
                                End If
                            End If
                        Next
                    Else
                        Info = GetDriveInfo(chDriveLetter + ":\")
                        For Each Item In Me.View.Items
                            If Item.Text = Info.Serial Then
                                Item.SubItems(2).Text = "Idle"
                                Node.State = "Idle"
                                Node.DrawMessage = False
                                Node.Serial = Item.Text
                                Me.SerialList(Item.Index) = Node
                            End If
                        Next
                    End If
                End If
            ElseIf m.WParam.ToInt32() = DBT_DEVICEREMOVECOMPLETE Then
                ' Flash Drive Unplugged
                LbDrive.Text = "USB Flash Drive Removed"
                Me.RefreshDrives()
            End If
        End If
        MyBase.WndProc(m)
    End Sub

#End Region

#Region "API structures and calls"
    ' Structure to store information of a phisical drive.
    Private Structure DriveInfo
        Public Drive As String
        Public Volume As String
        Public Serial As String
    End Structure

    ' Api to get drive information
    Private Declare Function GetVolumeInformation Lib "kernel32" Alias "GetVolumeInformationA" _
        (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, _
        ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, _
        ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, _
        ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer

#End Region

#Region "Get Drive Letter (FUNCTION)"
    'Function to translate the drive letter to a readable char
    Private Function GetDriveLetter(ByVal Mask As Int32) As Char
        Dim twosPower As Int32 = 1
        Dim DriveName As Integer = 65

        While (twosPower < 2147483648)

            If (Mask And twosPower) Then
                Return Chr(DriveName)
            End If
            twosPower *= 2
            DriveName += 1
        End While
        Return "0"
    End Function

#End Region

#Region "Private variables"
    ' A list of serial numbers and states, for update the listview state column.
    Private SerialList As New ArrayList

    Private Icons As New ArrayList

    Private LogLines As New ArrayList

    ' Config filename for USBScan
    Private ConfigFile As String

    ' A form for selecting ONLY removeable devices.
    Private ChooseDrive As New SelectDrive

    Private Config As TConfig
    'A second variable is added so that I can pass this reference to the other class
#End Region

#Region "Auxiliary Functions"
    ' Function that fills a driveinfo structure with a drive letter information
    Private Function GetDriveInfo(ByVal drive As String) As DriveInfo
        Dim di As New DriveInfo
        Dim strVolName As New String(" ", 255)
        Dim lngVolSerialNumber As Integer
        Dim lngMaxComp As Integer
        Dim lngFSFlags As Integer
        Dim strFSName As New String(" ", 255)
        Dim lngDummy As Integer

        lngDummy = GetVolumeInformation(drive, strVolName, strVolName.Length, _
                                        lngVolSerialNumber, lngMaxComp, _
                                        lngFSFlags, strFSName, Len(strFSName))

        di.Drive = drive

        If strVolName.IndexOf(Chr(0)) <> -1 Then
            di.Volume = strVolName.Substring(0, strVolName.IndexOf(Chr(0)))
        Else
            di.Volume = ""
        End If

        Dim lWord As Integer = GetLowWord(lngVolSerialNumber)
        Dim hWord As Integer = GetHighWord(lngVolSerialNumber)
        di.Serial = Hex(hWord).PadLeft(4, "0") & "-" & Hex(lWord).PadLeft(4, "0")

        Return di
    End Function

    Public Function GetLowWord(ByRef pintValue As Integer) As Integer
        Return pintValue And &HFFFF
    End Function

    Public Function GetHighWord(ByRef pintValue As Integer) As Integer
        If (pintValue And &H80000000) = &H80000000 Then
            Return ((pintValue And &H7FFF0000) \ &H10000) Or &H8000&
        Else
            Return (pintValue And &HFFFF0000) \ &H10000
        End If
    End Function


    Private Sub LoadIcons(ByVal Icons As ArrayList)
        Icons.Add(Nothing)
        Icons.Add(Image.FromFile(Application.StartupPath + "\icons\USBsucessfull16.bmp"))
        Icons.Add(Image.FromFile(Application.StartupPath + "\icons\USBadd16.bmp"))
        Icons.Add(Image.FromFile(Application.StartupPath + "\icons\USBclose16.bmp"))
        Icons.Add(Image.FromFile(Application.StartupPath + "\icons\USBInfo16.bmp"))
        Icons.Add(Image.FromFile(Application.StartupPath + "\icons\USBInProgress16.bmp"))
        Icons.Add(Image.FromFile(Application.StartupPath + "\icons\USBSave16.bmp"))

    End Sub
    Private Sub LogMe(ByVal State As USBState, ByVal LogColor As Color, ByVal LogText As String)
        Dim icon As Bitmap = Nothing
        Dim Line As LogLine

        ' Saving the style data of the new line into a structure
        Line.Message = LogText
        Line.Color = LogColor
        Line.Icon = State
        Line.Time = Format(DateTime.Now, "yyyy/MM/dd") & " " & Format(DateTime.Now, "h:mm tt") & ">> "

        'Adding that info to the array of lines
        Me.LogLines.Add(Line)

        'And redraw the entire RichText
        Me.DrawRTF(Me.TxtLog, LogLines)
        Exit Sub

    End Sub
    ' We redraw all the lines of the RTFtext with the info of the previously saved array of lines.
    Private Sub DrawRTF(ByRef TxT As RichTextBox, ByVal Lines As ArrayList)
        Dim Aux As LogLine
        Dim Count As Integer
        Dim i As Integer
        Dim LineIcon As Bitmap

        Count = Lines.Count - 1
        TxtLog.Clear()
        TxtLog.Rtf = ""

        For i = Count To 0 Step -1
            Aux = CType(Lines(i), LogLine)
            If TxtLog.Text = Nothing Then
                TxtLog.Text = TxtLog.Text & vbNewLine
            Else
                TxtLog.SelectedText = vbNewLine
            End If

            If Aux.Icon > USBState.None Then
                If Icons.Count > 0 And Aux.Icon > USBState.None Then
                    LineIcon = CType(Icons(Aux.Icon), Image)
                    Clipboard.SetImage(LineIcon)

                    TxtLog.SelectionBackColor = Color.White
                    TxtLog.Paste()
                End If
                TxtLog.SelectionColor = Color.Black
                TxtLog.SelectedText = Aux.Time
                TxtLog.SelectionColor = Aux.Color
                TxtLog.SelectedText = Aux.Message

            End If
        Next

    End Sub

    ' Procedure to load previous saved configuration
    Private Sub LoadConfig()
        Dim F As StreamReader
        Dim Linea As String = ""
        Dim ViewItem As ListViewItem = Nothing
        Dim Node As NodeInfo = Nothing
        Dim info As DriveInfo = Nothing

        Me.View.Items.Clear()

        Try
            F = New StreamReader(Application.StartupPath + "\SyncConfig.ini")

            Config.LogType = Val(F.ReadLine)
            Config.WinStartup = Convert.ToBoolean(F.ReadLine)
            Config.AutoSync = Convert.ToBoolean(F.ReadLine)
            Config.CopyMenu = Convert.ToBoolean(F.ReadLine)

            If Config.LogType = 1 Then
                Me.radLogOnlyErrors.Checked = True
            ElseIf Config.LogType = 2 Then
                Me.radLogAll.Checked = True
            Else
                Me.radDoNotLog.Checked = True
            End If

            Me.ChkAutoSync.Checked = Config.AutoSync
            Me.ChkCopyMenu.Checked = Config.CopyMenu
            Me.ChkWindowsStartup.Checked = Config.WinStartup


            While Not (IsNothing(Linea))
                Linea = F.ReadLine()

                If Not (IsNothing(Linea)) Then
                    Dim i As String = Linea
                    Dim a() As String
                    a = i.Split("|")

                    ViewItem = Me.View.Items.Add(a(0))
                    Node.Serial = a(0)
                    info = GetDriveBySerial(a(0))

                    If IsNothing(info.Drive) Then
                        Node.State = "Waiting USB"
                    Else
                        Node.State = "Idle"
                    End If
                    Me.SerialList.Add(Node)
                    Node.DriveAutoSync = (a(2))

                    'If Not (IsNothing(a(0))) Then
                    ViewItem.SubItems.Add(a(1))
                    ViewItem.SubItems.Add(Node.State)
                    ViewItem.SubItems.Add(Node.DriveAutoSync)

                Else

                End If
            End While

            F.Close()
            LogMe(USBState.Info, Color.DarkGreen, "Config file loaded successfully!")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogMe(USBState.Info, Color.DarkRed, ex.Message)
        End Try

    End Sub
    ' This will refresh the status of the drives, needed at removal
    Private Sub RefreshDrives()
        Dim Item As ListViewItem
        Dim info As DriveInfo
        Dim Node As NodeInfo = Nothing

        For Each Item In Me.View.Items
            info = GetDriveBySerial(Item.Text)
            If IsNothing(info.Drive) Then
                Item.SubItems(2).Text = "Waiting USB"
                Node.Serial = Item.Text
                Node.State = Item.SubItems(2).Text
                Node.DrawMessage = False
                Me.SerialList(Item.Index) = Node
            End If
        Next
    End Sub
    'Procedure to save the current configuration
    Private Sub SaveConfig()
        Dim F As StreamWriter
        Dim Item As ListViewItem
        Dim regKey As RegistryKey

        Try
            F = New StreamWriter(Application.StartupPath + "\SyncConfig.ini", False)

            F.WriteLine(Config.LogType.ToString)
            F.WriteLine(Config.WinStartup.ToString)
            F.WriteLine(Config.AutoSync.ToString)
            F.WriteLine(Config.CopyMenu.ToString)

            If Config.WinStartup Then
                regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey.SetValue("SmartSync V1.0", Application.ExecutablePath)
                regKey.Close()
            Else
                regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey.DeleteValue("SmartSync V1.0", False)
                regKey.Close()
            End If

            For Each Item In View.Items
                F.WriteLine(Item.Text & "|" & Item.SubItems(1).Text & "|" & (Item.SubItems(3).Text))
            Next

            F.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LogMe(USBState.Save, Color.DarkGreen, "Config saved successfully!")

        MessageBox.Show("Configuration saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub ReverseSyncFiles(ByVal FromDrive As Char)
        Dim dest As String
        Dim Info As DriveInfo
        Dim Pos As Integer
        Dim From As String
        Dim Back As BackupUtil
        Dim node As NodeInfo
        Dim Log As ELogMode

        From = FromDrive + ":\"

        Info = GetDriveInfo(From)
        Pos = SerialPos(Info.Serial)

        If Pos >= 0 Then
            Select Case Config.LogType
                Case 0
                    Log = ELogMode.E_LogNone
                Case 1
                    Log = ELogMode.E_LogErrors
                Case 2
                    Log = ELogMode.E_LogAll
            End Select

            dest = Me.View.Items(Pos).SubItems(1).Text
            Back = New BackupUtil(From, dest, From, Log)
            AddHandler Back.BackupFinished, AddressOf BackupCompleted

            node = CType(Me.SerialList(Pos), NodeInfo)

            node.State = "In progress"

            Me.SerialList(Pos) = node

            Me.View.Items(Pos).SubItems(2).Text = "In progress"

            LogMe(USBState.InProgress, Color.Orange, "Reverse SYNC of drive " & From & " has been started")

            Back.Start()
        End If

    End Sub
    ' This sub will syncronize the files ONLY if the serial number of the destination is known
    Private Sub SyncFiles(ByVal Destination As Char)
        Dim dest As String
        Dim Info As DriveInfo
        Dim Pos As Integer
        Dim From As String
        Dim Back As BackupUtil
        Dim node As NodeInfo
        Dim Log As ELogMode

        dest = Destination + ":\"

        Info = GetDriveInfo(dest)
        Pos = SerialPos(Info.Serial)

        If Pos >= 0 Then
            Select Case Config.LogType
                Case 0
                    Log = ELogMode.E_LogNone
                Case 1
                    Log = ELogMode.E_LogErrors
                Case 2
                    Log = ELogMode.E_LogAll
            End Select


            From = Me.View.Items(Pos).SubItems(1).Text

            ' If item1 exists as file then its a script, else normal mode with directory
            Dim MyScript As String
            MyScript = ScriptsFolder & (From)
            If File.Exists(MyScript) Then
                Back = New BackupUtil(MyScript, dest, Log)
            Else
                Back = New BackupUtil(From, dest, dest, Log)
            End If

            AddHandler Back.BackupFinished, AddressOf BackupCompleted

            node = CType(Me.SerialList(Pos), NodeInfo)

            node.State = "In progress"

            Me.SerialList(Pos) = node

            Me.View.Items(Pos).SubItems(2).Text = "In progress"

            LogMe(USBState.InProgress, Color.Orange, dest & " SYNC has been started")

            Back.Start()
        End If

    End Sub
    Private Sub CopyMenuProgram(ByVal drive As String)
        If Config.CopyMenu Then
            Try
                File.Copy(Application.StartupPath + "\USBMenu.exe", drive + "USBMenu.exe", True)
                File.Copy(Application.StartupPath + "\Autorun.inf", drive + "Autorun.inf", True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error copying menu files.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub BackupCompleted(ByVal Info As BackupInfo)
        Dim State As USBSync.NodeInfo
        Dim Temp As NodeInfo
        Dim i As Integer

        Me.CopyMenuProgram(Info.Destination)

        'State.Serial = GetDriveInfo(Info.Destination).Serial
        State.Serial = GetDriveInfo(Info.SyncUSBDrive).Serial
        For i = 1 To SerialList.Count
            Temp = CType(SerialList(i - 1), NodeInfo)

            If Temp.Serial = State.Serial Then
                Temp.State = "Idle"
                Temp.Message = "Backup Completed! " & Info.Origin & " to " & Info.Destination
                Temp.MessageColor = Color.DarkGreen
                Temp.DrawMessage = True
                Me.SerialList(i - 1) = Temp
            End If
        Next
    End Sub

    Private Function SerialPos(ByVal Serial As String) As Integer
        Dim ret As Integer = False
        Dim i As Integer = -1
        Dim item As ListViewItem

        item = Me.View.FindItemWithText(Serial)
        If Not (IsNothing(item)) Then
            i = item.Index
        End If

        SerialPos = i
    End Function

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Dim Info As NodeInfo
        Dim i As Integer

        Try
            For i = 1 To SerialList.Count
                Info = CType(SerialList(i - 1), NodeInfo)
                Me.View.Items(i - 1).SubItems(2).Text = Info.State


                If Info.DrawMessage Then
                    LogMe(USBState.Sucessfull, Info.MessageColor, Info.Message)
                    Info.DrawMessage = False
                    SerialList(i - 1) = Info
                End If
            Next
        Catch ex As Exception
        Finally
            Me.Refresh()
        End Try
    End Sub

    '
    ' Code for USBScan
    '

    ' Scans all directories and files of the selected drive, saving the data to a filename
    Private Sub ScanConfigFile(ByVal Filename As String, ByVal Drive As String)
        Dim fs As New FileSearch()
        Dim FInfo As FileInfo = Nothing
        Dim DirInfo As DirectoryInfo = Nothing
        Dim Files() As FileInfo = {}
        Dim Config As StreamWriter

        Try
            fs.Search(Drive, "*.exe")
            Config = New StreamWriter(Filename)

            For Each DirInfo In fs.Directories
                Files = DirInfo.GetFiles("*.exe")
                Config.WriteLine("[" + DirInfo.Name + "]=" + DirInfo.FullName)

                For Each FInfo In Files
                    Config.WriteLine(FInfo.Name + "=" + FInfo.FullName)
                Next
                Config.WriteLine()
            Next

            Config.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        MessageBox.Show("Config file created.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' A routine to save the content of multiline textbox to a textfile
    Private Sub TextBoxToFile(ByVal Tx As TextBox, ByVal file As String)
        Dim F As StreamWriter = Nothing
        Dim i As Integer = 0

        F = New StreamWriter(file)
        For i = 1 To Tx.Lines.Count
            F.WriteLine(Tx.Lines(i - 1).ToString)
        Next
        F.Close()

    End Sub
    'With this we can get all the driveinfo needed, filtered by the serial number of the drive
    Private Function GetDriveBySerial(ByVal Serial As String) As DriveInfo
        Dim Info As DriveInfo = Nothing
        Dim Current As IO.DriveInfo = Nothing

        For Each Current In My.Computer.FileSystem.Drives
            If Current.DriveType = DriveType.Removable Then
                If GetDriveInfo(Current.Name).Serial = Serial Then
                    Info = GetDriveInfo(Current.Name)
                End If
            End If
        Next
        Return Info
    End Function


    ' A routine to load the content of a file to a multiline textbox
    Private Sub TextBoxFromFile(ByRef Tx As TextBox, ByVal file As String)
        Dim F As StreamReader = Nothing
        Dim i As Integer = 0
        Dim Linea As String = ""

        F = New StreamReader(file)

        While Not (IsNothing(Linea))
            i += 1
            Linea = F.ReadLine()
            If Not (IsNothing(Linea)) Then
                Tx.Text += Linea + Chr(13) + Chr(10)
            End If
        End While
        F.Close()

    End Sub
#End Region

#Region "Form event handlers"
    Private Sub Tab_TabIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab.TabIndexChanged
        Me.ChooseDrive.AddDrivesToCombobox(Me.CbDrives)
    End Sub

    Private Sub USBSync_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Load all the icons on the memory
        Me.ConfigFile = Application.StartupPath + ConfigFile

        LoadIcons(Me.Icons)

        ' When the form is loaded, we ensure that previous data is loaded into memory
        LoadConfig()

        'Populate the scripts list combo box!
        For Each file As FileInfo In ScriptsFolderFiles.GetFiles("*.ini")
            CmbBackUpScript.Items.Add(file.Name)
        Next

    End Sub

    Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub BtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSave.Click
        'Important to save all the serial number and directory data
        SaveConfig()
    End Sub


    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDelete.Click
        ' If there is an item selected on Drives list, then we remove both lines
        Dim DeletedString
        If Me.View.SelectedIndices.Count > 0 Then

            If MessageBox.Show("Are you sure you want to remove the Sync with serial " & Me.View.SelectedItems(0).Text & " ?", "Remove Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ' If Yes selected, then save and continue with the exit process
                'Try
                DeletedString = "Drive with serial " & Me.View.SelectedItems(0).Text & " has been removed from list!"
                Me.SerialList.RemoveAt(Me.View.SelectedIndices(0))
                Me.View.Items.RemoveAt(Me.View.SelectedIndices(0))
        
                LogMe(USBState.Close, Color.Red, DeletedString)

                'Catch ex As Exception
                'MsgBox(ex.Message)
                'End Try
            End If

        End If

    End Sub

    Private Sub BtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAdd.Click
        ' This will add a serial number from USB and the local source directory linked with it.
        Dim Drive As String
        Dim Info As DriveInfo
        Dim i As Integer
        Dim Already As Boolean = False
        'Dim Fold As String

        Dim Item As ListViewItem = Nothing
        Dim Node As NodeInfo = Nothing
        Dim DriveSync As String

        'Me.Folder.Description = "Select Folder To SYNC"
        'Me.Folder.ShowDialog()
        'Fold = Me.Folder.SelectedPath

        'If Fold = Nothing Then Exit Sub

        'PassFolderOrScript = Fold
        Me.ChooseDrive.ShowDialog()

        If Me.ChooseDrive.Valid Then
            Drive = ChooseDrive.Drive
            Info = Me.GetDriveInfo(Drive)
            DriveSync = ChooseDrive.DriveSync
            
            For i = 1 To Me.View.Items.Count
                If Me.View.Items(i - 1).ToString = Info.Serial Then
                    Already = True
                    Exit For
                End If
            Next


            If Not Already Then
                Item = Me.View.Items.Add(Info.Serial)
                Item.SubItems.Add(PassFolderOrScript)
                Item.SubItems.Add("Idle")
                Item.SubItems.Add(DriveSync)

                Node.Serial = Info.Serial
                Node.State = "Idle"
                Node.DriveAutoSync = "On"

                Me.SerialList.Add(Node)

                LogMe(USBState.Add, Color.DarkGreen, Drive & " with Label '" & Info.Volume & "' has been added successfully!")

            Else
                MessageBox.Show("The serial number is already in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If

        PassDrive = Nothing
        PassFolderOrScript = Nothing

    End Sub

    Private Sub btScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btScan.Click
        If IsNothing(Me.CbDrives.SelectedItem) Then
            MsgBox("You must choose a drive before.")
        Else
            Me.Save.FileName = "config.ini"
            Me.Save.ShowDialog()

            Me.ConfigFile = Me.Save.FileName
            Me.ScanConfigFile(Me.ConfigFile, Me.CbDrives.SelectedItem.ToString)
            Me.TextBoxFromFile(Me.TxEdit, Me.ConfigFile)

            MsgBox("Menu config file created successfully.", MsgBoxStyle.Information, "USB Sync")

        End If

    End Sub

    Private Sub BtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRefresh.Click

        Me.ChooseDrive.AddDrivesToCombobox(Me.CbDrives)

    End Sub

    Private Sub BtSaveScanClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSaveScan.Click
        Dim MyResult As String
        If File.Exists(CbDrives.Text & "config.ini") = True Then

            MyResult = MsgBox("Are you sure you want to overwrite the existing config file?", MsgBoxStyle.YesNo, "Overwrite file?")

            Select Case MyResult

                Case "6"
                    Try
                        Me.TextBoxToFile(Me.TxEdit, CbDrives.Text & "config.ini")
                        MsgBox("Menu config file saved successfully.", MsgBoxStyle.Information, "USB Sync")

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Case "7"

            End Select
        Else
            Try
                Me.TextBoxToFile(Me.TxEdit, CbDrives.Text & "config.ini")
                MsgBox("Menu config file saved successfully.", MsgBoxStyle.Information, "USB Sync")


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub MnuSyncNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuSyncNow.Click
        Dim dest As DriveInfo

        'If something is selected on the drive listview..
        If Me.View.SelectedItems.Count > 0 Then
            ' First get the drive information passing the serial
            dest = GetDriveBySerial(Me.View.SelectedItems(0).Text)

            If IsNothing(dest.Drive) Then
                MessageBox.Show("Cannot force sync on selected drive, because it can't be detected." + Chr(13) + "Please ensure that the drive is plugged in and ready for use.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ' And finally, we force to sync

                Me.SyncFiles(dest.Drive)
            End If
        End If
    End Sub
    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick

        If Me.WindowState = FormWindowState.Normal Then
            Me.Hide()
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub AddDriveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddDriveToolStripMenuItem.Click
        BtAdd_Click(MnuUSBSync, e)
    End Sub

    Private Sub DeleteDriveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BtDelete_Click(MnuUSBSync, e)
    End Sub

    Private Sub SaveConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveConfigToolStripMenuItem.Click
        SaveConfig()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtLoad.Click
        'declaring a FileStream to open the file named file.doc with access mode of reading
        Dim MyFile As String = (CbDrives.Text & "Config.ini")
        Dim fs As New FileStream(MyFile, FileMode.Open, FileAccess.Read)
        Dim d As New StreamReader(fs)

        TxEdit.Text = ""
       
        Try
            'creating a new StreamReader and passing the filestream object fs as argument
            d.BaseStream.Seek(0, SeekOrigin.Begin)

            'Seek method is used to move the cursor to different positions in a file, in this code, to 
            'the beginning
            While d.Peek() > -1
                'peek method of StreamReader object tells how much more data is left in the file
                TxEdit.Text &= d.ReadLine() & vbNewLine
                'displaying text from doc file in the RichTextBox
            End While
            d.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Config File", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub USBSync_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Make the question to user, and compare the result
        If MessageBox.Show("Do you want to save the config file?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ' If Yes selected, then save and continue with the exit process
            SaveConfig()
        Else
            ' otherwise, we cancel this event, so form will never close this time.
        End If

        'e.Cancel = True
    End Sub
    Private Sub ApplyChanges()
        If radLogAll.Checked Then
            Me.Config.LogType = 2
        ElseIf radLogOnlyErrors.Checked Then
            Me.Config.LogType = 1
        Else
            Me.Config.LogType = 0
        End If

        Me.Config.AutoSync = Me.ChkAutoSync.Checked
        Me.Config.WinStartup = Me.ChkWindowsStartup.Checked
        Me.Config.CopyMenu = Me.ChkCopyMenu.Checked

    End Sub

    Private Sub BtSaveCfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSaveCfg.Click
        Me.ApplyChanges()
        Me.SaveConfig()
    End Sub

    Private Sub BtSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSync.Click
        Dim dest As DriveInfo

        'If something is selected on the drive listview..
        If Me.View.SelectedItems.Count > 0 Then
            ' First get the drive information passing the serial
            dest = GetDriveBySerial(Me.View.SelectedItems(0).Text)

            ' And finally, we force to sync
            Me.SyncFiles(dest.Drive)
        End If
    End Sub
    Private Sub ExploreDriveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExploreDriveToolStripMenuItem.Click
        'This code opens up explorer on the selected drive as long as it is in IDLE STATE!
        Dim dest As DriveInfo
        If Me.View.SelectedIndices.Count > 0 Then

            If Me.View.SelectedItems(0).SubItems(2).Text = "Idle" Then

                dest = GetDriveBySerial(Me.View.SelectedItems(0).Text)

                System.Diagnostics.Process.Start("Explorer.exe", dest.Drive)

            End If
        End If
    End Sub

    Private Sub MnuAutoSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAutoSync.Click
        If Me.View.SelectedIndices.Count > 0 Then
            ' Change the state of the Device AutoSync option from yes to no.
            If Me.View.SelectedItems(0).SubItems(3).Text = "No" Then
                Me.View.SelectedItems(0).SubItems(3).Text = "Yes"
                'LogMe(USBState.Close, Color.Red, "Drive Changed AutoSync State Changed")
            Else
                Me.View.SelectedItems(0).SubItems(3).Text = "No"
            End If
        Else
        End If

    End Sub

    Private Sub USBSync_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Normal Then
            Me.Show()
        Else
            Me.Hide()
        End If
    End Sub

    Private Sub EditSyncToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSyncToolStripMenuItem.Click
        'This code is to first check wether or not a Sync Drive has been selected to be edited.
        'Then it checks to see wether the drive is in an IDLE STATE or Waiting USB device.
        'Dim dest As DriveInfo

        Dim DriveSerial As String
        Dim DriveFolder As String
        Dim DriveAutoSync As String
        Dim Info As NodeInfo = Nothing

        If Me.View.SelectedIndices.Count > 0 Then
            'First we check to see wether or not an item is selected in the list.
            If Me.View.SelectedItems(0).SubItems(2).Text = "Idle" Or Me.View.SelectedItems(0).SubItems(2).Text = "Waiting USB" Then
                'Get all Value ready to pass to the edit sync form.
                DriveSerial = Me.View.SelectedItems(0).Text
                DriveFolder = Me.View.SelectedItems(0).SubItems(1).Text
                DriveAutoSync = Me.View.SelectedItems(0).SubItems(3).Text
                Info = CType(SerialList(Me.View.SelectedIndices(0)), NodeInfo)

                Dim Edit As New SelectDrive

                If DriveAutoSync = "Yes" Then
                    Edit.ChkAutoSync.Checked = True
                Else
                    Edit.ChkAutoSync.Checked = False
                End If

                PassFolderOrScript = DriveFolder
                'Edit.DlgFolderSelector.SelectedPath = DriveFolder

                If Me.View.SelectedItems(0).SubItems(2).Text = "Idle" Then
                    Dim From As DriveInfo
                    From = GetDriveBySerial(Me.View.SelectedItems(0).Text)
                    PassDrive = From.Drive
                Else
                End If

                Edit.ShowDialog()

                If Edit.Valid Then
                    If (Edit.Drive.Length > 0) Then
                        DriveSerial = GetDriveInfo(Edit.Drive).Serial
                        Me.View.SelectedItems(0).Text = DriveSerial
                        Info.Serial = DriveSerial
                    End If
                    Dim SelectedScript As String

                    SelectedScript = (ScriptsFolder) & (PassFolderOrScript)

                    If Directory.Exists(PassFolderOrScript) Or File.Exists(SelectedScript) Then
                        Me.View.SelectedItems(0).SubItems(1).Text = PassFolderOrScript
                    End If

                    Me.View.SelectedItems(0).SubItems(3).Text = Edit.DriveSync
                    Info.DriveAutoSync = Edit.DriveSync

                    SerialList(Me.View.SelectedIndices(0)) = Info
                End If
                Edit.Close()
            End If
        End If



        PassDrive = Nothing
        PassFolderOrScript = Nothing

    End Sub

    Private Sub ReverseSyncToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReverseSyncToolStripMenuItem.Click
        'Prompt the user to confirm this is what they want to do.
        If MessageBox.Show("Are you sure you want to perform a REVERSE SYNC?" & vbNewLine & "Doing this may overwrite information on your hard drive!", "Confirm Reverse Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Perform a reverse SYNC
            Dim From As DriveInfo

            'If something is selected on the drive listview..
            If Me.View.SelectedItems.Count > 0 Then
                ' First get the drive information passing the serial
                From = GetDriveBySerial(Me.View.SelectedItems(0).Text)

                Dim FileSystemObject
                FileSystemObject = CreateObject("Scripting.FileSystemObject")

                If (FileSystemObject.FolderExists(Me.View.SelectedItems(0).SubItems(1).Text)) Then
                    ' And finally, we force to sync
                    Me.ReverseSyncFiles(From.Drive)

                Else
                    MsgBox("The Sync folder is no longer valid." & vbNewLine & "Please make sure the SYNC folder exists on the PC.", MsgBoxStyle.Critical, "Unable To Sync")
                End If
            End If
        Else
            ' Do nothing
        End If
    End Sub

    Private Sub LoadConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadConfigToolStripMenuItem.Click
        'First we need to empty the current lists.
        Me.SerialList.Clear()
        Me.View.Items.Clear()

        'Then we load the config again
        LoadConfig()
    End Sub
#End Region

#Region "Backup Script Creator"
    Private Sub BtScriptFilesRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScriptFilesRefresh.Click

        CmbBackUpScript.Items.Clear()

        Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")

        For Each file As FileInfo In dir.GetFiles("*.ini")
            CmbBackUpScript.Items.Add(file.Name)
        Next
    End Sub

    Private Sub CmbBackUpScript_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBackUpScript.SelectedIndexChanged
        'Load Files into there specific Lists.


    End Sub

    Private Sub BtnAddFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddFolder.Click
        'Open the folder dialogue box so we can select a folder.

        Dim dlgResult As DialogResult = FDScriptCreator.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            LstCreatorFolders.Items.Add(FDScriptCreator.SelectedPath)
        End If

    End Sub

    Private Sub BtnAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddFile.Click
        'Open the folder dialogue box so we can select a folder.
        FOScriptCreator.Multiselect = False


        Dim dlgResult As DialogResult = FOScriptCreator.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            LstCreatorFiles.Items.Add(FOScriptCreator.FileName())
        End If

    End Sub

    Private Sub BtnRemoveFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemoveFolder.Click

        If Me.LstCreatorFolders.SelectedIndices.Count > 0 Then
            Me.LstCreatorFolders.Items.RemoveAt(Me.LstCreatorFolders.SelectedIndices(0))
        End If

    End Sub

    Private Sub BtnRemoveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemoveFile.Click

        If Me.LstCreatorFiles.SelectedIndices.Count > 0 Then
            Me.LstCreatorFiles.Items.RemoveAt(Me.LstCreatorFiles.SelectedIndices(0))
        End If

    End Sub

    Private Sub BtNewScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNewScript.Click

        FDScriptNew.AddExtension = True
        FDScriptNew.InitialDirectory = (Application.StartupPath + "\scripts")
        FDScriptNew.ValidateNames = True

        Dim dlgResult As DialogResult = FDScriptNew.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Dim bAppendToFile As Boolean = False

            My.Computer.FileSystem.WriteAllText( _
                FDScriptNew.FileName, "", bAppendToFile)

            'Refresh the Combo box which lists the script files.
            CmbBackUpScript.Items.Clear()
            Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")
            For Each file As FileInfo In dir.GetFiles("*.ini")
                CmbBackUpScript.Items.Add(file.Name)
            Next
        End If


    End Sub
    Private Sub BtScriptSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScriptSave.Click
        Dim F As StreamWriter
        Dim FolderCount As Integer
        Dim FileCount As Integer

        Try
            F = New StreamWriter(Application.StartupPath + "\Scripts\" & CmbBackUpScript.Text, False)

            F.WriteLine("[Folders]")
            FolderCount = (0)
            Do While FolderCount < LstCreatorFolders.Items.Count()
                F.WriteLine(LstCreatorFolders.Items.Item(FolderCount))
                FolderCount = FolderCount + 1
            Loop

            F.WriteLine("[Files]")
            FileCount = (0)

            Do While FileCount < LstCreatorFiles.Items.Count()
                F.WriteLine(LstCreatorFiles.Items.Item(FileCount))
                FileCount = FileCount + 1
            Loop

            F.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtScriptDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScriptDelete.Click
        Dim MyFile As String

        MyFile = Application.StartupPath + "\scripts\" + CmbBackUpScript.Text
        If System.IO.File.Exists(MyFile) = True Then
            Dim dlgResult As DialogResult = MsgBox("Are you sure you want to delete this script?" & vbNewLine & "Any Syncs using this script will no longer function!", MsgBoxStyle.YesNo, "Confirm Delete")
            If dlgResult = Windows.Forms.DialogResult.Yes Then

                Kill(MyFile)

                'Refresh the Combo box which lists the script files.
                CmbBackUpScript.Items.Clear()

                Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")
                For Each file As FileInfo In dir.GetFiles("*.ini")
                    CmbBackUpScript.Items.Add(file.Name)
                Next
            End If
        End If
    End Sub

    Private Sub BtScriptLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScriptLoad.Click
        Dim F As StreamReader
        Dim LineA As String
        If CmbBackUpScript.Text = "" Then
        Else

            Try
                LstCreatorFiles.Items.Clear()
                LstCreatorFolders.Items.Clear()

                F = New StreamReader(Application.StartupPath + "\scripts\" + CmbBackUpScript.Text)
                LineA = F.ReadLine()
                Do Until LineA = "[Files]"
                    LineA = F.ReadLine()
                    If LineA = "[Files]" Then
                    Else
                        LstCreatorFolders.Items.Add(LineA)
                    End If
                Loop

                While Not (IsNothing(LineA))
                    LineA = F.ReadLine
                    If IsNothing(LineA) = False Then
                        LstCreatorFiles.Items.Add(LineA)
                    End If
                End While
                F.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
#End Region

End Class
