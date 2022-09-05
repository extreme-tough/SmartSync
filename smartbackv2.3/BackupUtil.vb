Option Explicit On
Option Strict On
Option Infer Off
Imports System.IO
Public Structure TSpaceInfo
    Dim nTotalBytesToCopy As Long
    Dim nBytesCopied As Long
    Dim nFreeSpaceRemaining As Long
End Structure
Public Enum ELogMode
    E_LogAll = 0
    E_LogErrors = 1
    E_LogNone = 2
End Enum
Public Class BackupUtil
    Public Structure BackupInfo

        Public Origin As String
        Public Destination As String
        Public SyncUSBDrive As String
        Public Script As String

    End Structure

    Private Structure RelativeFile
        Public FileName As String
        Public Path As String
        Public RelativePath As String
    End Structure

    Dim sourceDir As String
    Dim destinationDir As String
    Dim SyncUSBDrive As String
    Dim Script As String
    Dim ScriptFiles As New ArrayList

    Dim aborted As Boolean
    Dim alreadyRan As Boolean
    Dim m_sCopiedFiles As String
    Dim m_sSkippedFiles As String   ' The files that were skipped and not copied
    Dim m_sErrorFiles As String     ' The files that encountered errors while copying.
    Private m_copyInfo As TSpaceInfo
    Dim threadBackup As System.Threading.Thread
    Private m_bIsPaused As Boolean = False
    Private m_eLogMode As ELogMode = ELogMode.E_LogNone
    Private Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)
    Public Event FileCopied(ByVal backupStatus As BackupStatus)
    Public Event BackupCompleted(ByVal filesCopied As Int32, ByVal filesSkipped As Int32, ByVal logName As String)
    Public Event BackupFinished(ByVal Info As BackupInfo)
    Public Event BackupStarted(ByVal filesToCopy As Int32)
    Public Event ErrorOccurred(ByVal ex As BackupUtilException, ByRef bContinue As Boolean)
    Public Event notifyDiskIoChange(ByVal tInfo As TSpaceInfo)
    Private m_oBackupStatus As BackupStatus
    Public Sub New(ByVal sourceDir As String, ByVal destinationDir As String, ByVal SyncUSBDrive As String, ByVal eLogMode As ELogMode)
        m_oBackupStatus = New BackupStatus
        Me.sourceDir = sourceDir
        Me.destinationDir = destinationDir
        Me.SyncUSBDrive = SyncUSBDrive
        Me.Script = Nothing

        Me.m_eLogMode = eLogMode

        m_sCopiedFiles = "" : m_sErrorFiles = "" : m_sSkippedFiles = ""

        aborted = False
        alreadyRan = False
        m_bIsPaused = False
    End Sub

    Public Sub New(ByVal Script As String, ByVal DestinationDir As String, ByVal eLogMode As ELogMode)
        m_oBackupStatus = New BackupStatus
        Me.sourceDir = Nothing
        Me.destinationDir = DestinationDir
        Me.Script = Script

        Me.m_eLogMode = eLogMode

        m_sCopiedFiles = "" : m_sErrorFiles = "" : m_sSkippedFiles = ""

        aborted = False
        alreadyRan = False
        m_bIsPaused = False
    End Sub
    Public Sub Start()
        threadBackup = New System.Threading.Thread(AddressOf runBackup)
        threadBackup.IsBackground = True
        threadBackup.Start()
    End Sub
    Private Sub runBackup()
        'On Error GoTo Myerror
        Dim sourceDirInfo As DirectoryInfo
        Dim destinationDirInfo As DirectoryInfo

        Try
            If alreadyRan Then
                Dim errNewInstance As New BackupUtilException("A new instance of BackupUtil class must be created.")
                RaiseEvent ErrorOccurred(errNewInstance, False)
                aborted = True : Exit Sub
            End If

            If (m_oBackupStatus Is Nothing) Then
                m_oBackupStatus = New BackupStatus
            End If

            If Not (Directory.Exists(sourceDir)) And (File.Exists(Me.Script) = False) Then
                RaiseEvent ErrorOccurred(New BackupUtilException("The Source directory " & sourceDir & " does not exist."), False)
                aborted = True : Exit Sub
            ElseIf Not Directory.Exists(destinationDir) Then
                RaiseEvent ErrorOccurred(New BackupUtilException("The Destination directory " & destinationDir & " does not exist."), False)
                aborted = True : Exit Sub
            End If

            m_oBackupStatus.reset()
            m_copyInfo.nFreeSpaceRemaining = getDriveFreeSpace(destinationDir.Substring(0, 3))

            If File.Exists(Script) Then
                destinationDirInfo = New DirectoryInfo(destinationDir)
                Call waitIdleIfPaused()
                setNumFiles(Me.Script, destinationDirInfo)
                RaiseEvent notifyDiskIoChange(m_copyInfo)
                m_oBackupStatus.numFilesRemaining = m_oBackupStatus.numTotalFiles
                RaiseEvent BackupStarted(m_oBackupStatus.numFilesRemaining)
                If Not aborted Then
                    ' Just to send info about numFilesRemaining
                    m_oBackupStatus.fileBeingCopied = destinationDir
                    RaiseEvent FileCopied(m_oBackupStatus) ' New BackupStatus("", numFilesSkipped, numFilesCopied, numFilesRemaining))
                    copyAllFiles(Me.ScriptFiles, destinationDirInfo)
                End If
            Else
                m_copyInfo.nTotalBytesToCopy = getFolderSize(sourceDir, True)
                RaiseEvent notifyDiskIoChange(m_copyInfo)

                sourceDirInfo = New DirectoryInfo(sourceDir)
                destinationDirInfo = New DirectoryInfo(destinationDir)

                Call waitIdleIfPaused()
                setNumFiles(sourceDirInfo, destinationDirInfo, True)
                m_oBackupStatus.numFilesRemaining = m_oBackupStatus.numTotalFiles
                RaiseEvent BackupStarted(m_oBackupStatus.numFilesRemaining)
                If Not aborted Then
                    ' Just to send info about numFilesRemaining
                    m_oBackupStatus.fileBeingCopied = destinationDir
                    RaiseEvent FileCopied(m_oBackupStatus) ' New BackupStatus("", numFilesSkipped, numFilesCopied, numFilesRemaining))
                    copyAllFiles(sourceDirInfo, destinationDirInfo, True)
                End If
            End If
        Finally
            alreadyRan = True
            Dim sLogFileName As String = ""
            If (m_eLogMode <> ELogMode.E_LogNone) Then sLogFileName = generateReport()
            RaiseEvent BackupCompleted(m_oBackupStatus.numFilesCopied, m_oBackupStatus.numFilesSkipped, sLogFileName)

            Dim Info As BackupInfo
            Info.Destination = Me.destinationDir
            Info.Origin = Me.sourceDir
            Info.SyncUSBDrive = Me.SyncUSBDrive
            Info.Script = Me.Script

            RaiseEvent BackupFinished(Info)
        End Try
        Exit Sub
    End Sub
    Public Sub Abort()
        aborted = True
    End Sub
    Public Sub PauseBackup()
        m_bIsPaused = True
    End Sub
    Public Sub ResumeBackup()
        m_bIsPaused = False
    End Sub
    Private Sub waitIdleIfPaused()
        ' If the user has paused, then wait idly till the user resumes or aborts.
        While (aborted = False And m_bIsPaused)
            Application.DoEvents()
            Sleep(2000)
            Application.DoEvents()
        End While
    End Sub
    ' Recursive function to get the files of all directories and the total size.
    Private Function CountDirectory(ByVal target As String, ByVal root As String) As Long
        Dim Files() As String
        Dim temp As String
        Dim nSourceSize As Long
        Dim Dirs() As String
        Dim Dir As String
        Dim tempFile As RelativeFile

        Files = Directory.GetFiles(target)
        For Each temp In Files
            tempFile.FileName = temp
            tempFile.Path = New FileInfo(temp).DirectoryName
            If root.Length = tempFile.Path.Length Then
                temp = ""
            Else
                temp = tempFile.Path.Substring(root.Length + 1, tempFile.Path.Length - (root.Length + 1))
            End If
            tempFile.RelativePath = temp

            Me.ScriptFiles.Add(tempFile)
            nSourceSize += New FileInfo(tempFile.FileName).Length
            Me.m_oBackupStatus.numTotalFiles += 1
        Next

        Dirs = Directory.GetDirectories(target)
        For Each Dir In Dirs
            nSourceSize += CountDirectory(Dir, root)
        Next

        CountDirectory = nSourceSize
    End Function
    Private Overloads Sub setNumFiles(ByVal Script As String, ByVal target As DirectoryInfo)
        Dim F As StreamReader
        Dim LineA As String = Nothing
        Dim nDestSizeFree As Long = 0
        Dim nSourceSize As Long = 0
        Dim Files() As String = Nothing
        Dim temp As String = Nothing
        Dim TempFile As RelativeFile = Nothing

        If aborted Then Return
        If Not File.Exists(Script) Then Return

        nDestSizeFree = getDriveFreeSpace(target.FullName.Substring(0, 3))

        Call waitIdleIfPaused()

        Try
            Me.ScriptFiles.Clear()
            Me.m_oBackupStatus.numTotalFiles = 0
            F = New StreamReader(Script)
            LineA = F.ReadLine()
            Do Until LineA = "[Files]"
                LineA = F.ReadLine()
                If LineA = "[Files]" Then
                Else
                    nSourceSize += CountDirectory(LineA, LineA)
                End If
            Loop

            While Not (IsNothing(LineA))
                LineA = F.ReadLine
                If IsNothing(LineA) = False Then
                    TempFile.FileName = LineA
                    TempFile.Path = New FileInfo(TempFile.FileName).DirectoryName
                    TempFile.RelativePath = ""
                    Me.ScriptFiles.Add(TempFile)

                    nSourceSize += New FileInfo(TempFile.FileName).Length
                    Me.m_oBackupStatus.numTotalFiles += 1
                End If
            End While
            F.Close()

            If (nDestSizeFree <= nSourceSize) Then
                ' We do not have enough free space.
                Dim sMessage As String = "There is not enough space available on Drive " & UCase(target.FullName.Substring(0, 2)) & _
                                         " to backup contents of the Source directory." & vbCrLf & _
                                         "Space required by Source : " & convertBytesToMegaBytesStr(nSourceSize) & "MB" & vbCrLf & _
                                         "Space available on Destination : " & convertBytesToMegaBytesStr(nDestSizeFree) & "MB"
                RaiseEvent ErrorOccurred(New BackupUtilException(sMessage), False)
                aborted = True
                Exit Sub
            End If

            Me.m_copyInfo.nTotalBytesToCopy = nSourceSize
            Me.m_copyInfo.nBytesCopied = 0
            Me.m_copyInfo.nFreeSpaceRemaining = nDestSizeFree

        Catch errAuthExc As UnauthorizedAccessException
            m_sErrorFiles += errAuthExc.Message & "<BR>"
            Dim errNoAccess As New BackupUtilException("The Source directory " & LineA & " could not be accessed. " & _
                    "Please ensure that this file is not locked by another application, or, the user may not " & _
                    "have sufficient priviledges to access this file.")
            RaiseEvent ErrorOccurred(errNoAccess, True)
            aborted = False
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error loading script", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Overloads Sub setNumFiles(ByVal source As DirectoryInfo, ByVal target As DirectoryInfo, ByVal recursive As Boolean)
        If aborted Then Return
        If (source Is Nothing) Or (target Is Nothing) Then Return


        ' If the source doesn't exist, we have to throw an exception. 
        If Not source.Exists Then
            Dim bContinue As Boolean = True
            RaiseEvent ErrorOccurred(New BackupUtilException("The Source directory " & source.FullName & " does not exist."), bContinue)
            aborted = Not bContinue
            Exit Sub
        End If

        Call waitIdleIfPaused()
        'MainForm.LblMbToCopy.Text = (convertBytesToMegaBytesStr((getFolderSize(source.FullName, True))) & " MB")

        ' Determine whether we have enough free space.
        Dim nDestSizeFree As Long = getDriveFreeSpace(target.FullName.Substring(0, 3))
        Dim nSourceSize As Long = getFolderSize(source.FullName, True)

        'MainForm.LblFreeSpaceDest.Text = (getDriveFreeSpace(target.FullName.Substring(0, 3)) & " MB")

        If (nDestSizeFree <= nSourceSize) Then
            ' We do not have enough free space.
            Dim sMessage As String = "There is not enough space available on Drive " & UCase(target.FullName.Substring(0, 2)) & _
                                     " to backup contents of the Source directory." & vbCrLf & _
                                     "Space required by Source : " & convertBytesToMegaBytesStr(nSourceSize) & "MB" & vbCrLf & _
                                     "Space available on Destination : " & convertBytesToMegaBytesStr(nDestSizeFree) & "MB"
            RaiseEvent ErrorOccurred(New BackupUtilException(sMessage), False)
            aborted = True
            Exit Sub
        Else
            ' We have enough free space.
            Dim bContinue As Boolean = True
            Try
                m_oBackupStatus.numTotalFiles += source.GetFiles().Length
            Catch errAuthExc As UnauthorizedAccessException
                m_sErrorFiles += errAuthExc.Message & "<BR>"
                Dim errNoAccess As New BackupUtilException("The Source directory " & source.FullName & " could not be accessed. " & _
                        "Please ensure that this file is not locked by another application, or, the user may not " & _
                        "have sufficient priviledges to access this file.")
                RaiseEvent ErrorOccurred(errNoAccess, True)
                aborted = Not bContinue
                Exit Sub
            Catch ex As Exception
                m_sErrorFiles += ex.Message & "<BR>"
                Dim errGeneric As New BackupUtilException("An unknown error occurred while accessing contents of Source directory " & source.FullName & _
                                                          ex.Message)
                RaiseEvent ErrorOccurred(errGeneric, True)
                aborted = Not bContinue
                Exit Sub
            End Try
        End If

        ' Return if no recursive call is required. 
        If Not recursive Then Return
        ' Do the same for all sub directories. 
        For Each directory As DirectoryInfo In source.GetDirectories()
            If aborted Then Return
            waitIdleIfPaused()
            setNumFiles(directory, New DirectoryInfo(Path.Combine(target.FullName, directory.Name)), recursive)
        Next

    End Sub
    Private Overloads Sub copyAllFiles(ByVal files As ArrayList, ByVal target As DirectoryInfo)
        Dim Current As RelativeFile = Nothing
        Dim File As FileInfo = Nothing
        Dim bContinueOnError As Boolean = True
        Dim CurrentFile As RelativeFile = Nothing

        If aborted Then Return
        If target Is Nothing Then Return

        Call waitIdleIfPaused()
        ' If the target doesn't exist, we create it. 
        If Not target.Exists Then
            target.Create()
        End If

        Try
            For Each Current In Me.ScriptFiles
                Try
                    File = New FileInfo(Current.FileName)

                    bContinueOnError = True
                    If (aborted) Then Exit For
                    Call waitIdleIfPaused()

                    m_oBackupStatus.fileBeingCopied = File.FullName
                    RaiseEvent FileCopied(m_oBackupStatus)

                    Dim newPath As String = target.FullName

                    If target.FullName.Substring(target.FullName.Length - 1, 1) <> "\" Then
                        newPath += "\"
                    End If

                    newPath += Current.RelativePath
                    Dim newFile As String = Path.Combine(newPath, File.Name)
                    If Not Directory.Exists(New FileInfo(newFile).DirectoryName) Then
                        Directory.CreateDirectory(newPath)
                    End If
                    File.CopyTo(newFile, True)

                    m_oBackupStatus.numFilesCopied += 1
                    m_copyInfo.nBytesCopied += FileLen(File.FullName)
                    m_sCopiedFiles = m_sCopiedFiles & File.FullName & "<BR>" & vbCrLf
                Catch NotAuthorized As UnauthorizedAccessException
                    m_sErrorFiles += NotAuthorized.Message & "<BR>"
                    Dim errNoAccess As New BackupUtilException(NotAuthorized.Message & vbCrLf & _
                            "Please ensure that this file is not read-only, or locked by another application, or, the user may not " & _
                            "have sufficient priviledges to access this file.")
                    RaiseEvent ErrorOccurred(errNoAccess, True)
                    aborted = Not bContinueOnError
                    m_oBackupStatus.numFilesSkipped += 1
                    Exit Sub
                Catch NoFileFound As FileNotFoundException
                    m_sErrorFiles += NoFileFound.Message & "<BR>"
                    Dim errNotFound As New BackupUtilException("The file " & File.FullName & " was not found. " & _
                            "Please ensure that this file exists.")
                    RaiseEvent ErrorOccurred(errNotFound, True)
                    aborted = Not bContinueOnError
                    m_oBackupStatus.numFilesSkipped += 1
                    Exit Sub
                Catch NoMem As InsufficientMemoryException
                    m_sErrorFiles += NoMem.Message & "<BR>"
                    Dim errOutOfMemory As New BackupUtilException("There is insufficient memory to run this application.")
                    RaiseEvent ErrorOccurred(errOutOfMemory, False)
                    aborted = True
                    Exit Sub
                Catch ex As Exception
                    m_sErrorFiles += ex.Message & "<BR>"
                    Dim errGeneric As New BackupUtilException("An unknown error was encountered." & vbCrLf & ex.Message)
                    RaiseEvent ErrorOccurred(errGeneric, True)
                    aborted = Not bContinueOnError
                    m_oBackupStatus.numFilesSkipped += 1
                Finally
                    With m_oBackupStatus
                        .numFilesRemaining = .numTotalFiles - .numFilesCopied - .numFilesSkipped
                    End With
                    RaiseEvent FileCopied(m_oBackupStatus)
                    m_copyInfo.nFreeSpaceRemaining = getDriveFreeSpace(destinationDir.Substring(0, 3))
                    RaiseEvent notifyDiskIoChange(m_copyInfo)
                End Try
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Overloads Sub copyAllFiles(ByVal source As DirectoryInfo, ByVal target As DirectoryInfo, ByVal recursive As Boolean)
        If aborted Then Return
        If source Is Nothing Or target Is Nothing Then Return

        ' If the source doesn't exist, we have to throw an exception. 
        Dim bContinueOnError As Boolean = True
        If Not source.Exists Then
            Dim errDirNotFound As New BackupUtilException("The source directory " & source.FullName & " was not found.")
            RaiseEvent ErrorOccurred(errDirNotFound, bContinueOnError)
            aborted = Not bContinueOnError
            Exit Sub
        End If

        Call waitIdleIfPaused()

        ' If the target doesn't exist, we create it. 
        If Not target.Exists Then
            target.Create()
        End If

        ' Copy each file one at a time!
        ' Get all files and copy them over. 
        Try
            For Each file As FileInfo In source.GetFiles()
                Try
                    bContinueOnError = True
                    If (aborted) Then Exit For
                    Call waitIdleIfPaused()

                    m_oBackupStatus.fileBeingCopied = file.FullName
                    RaiseEvent FileCopied(m_oBackupStatus)

                    Dim newPath As String = Path.Combine(target.FullName, file.Name)
                    file.CopyTo(newPath, True)

                    m_oBackupStatus.numFilesCopied += 1
                    m_copyInfo.nBytesCopied += FileLen(file.FullName)
                    m_sCopiedFiles = m_sCopiedFiles & file.FullName & "<BR>" & vbCrLf
                Catch NotAuthorized As UnauthorizedAccessException
                    m_sErrorFiles += NotAuthorized.Message & "<BR>"
                    Dim errNoAccess As New BackupUtilException(NotAuthorized.Message & vbCrLf & _
                            "Please ensure that this file is not read-only, or locked by another application, or, the user may not " & _
                            "have sufficient priviledges to access this file.")
                    RaiseEvent ErrorOccurred(errNoAccess, True)
                    aborted = Not bContinueOnError
                    m_oBackupStatus.numFilesSkipped += 1
                    Exit Sub
                Catch NoFileFound As FileNotFoundException
                    m_sErrorFiles += NoFileFound.Message & "<BR>"
                    Dim errNotFound As New BackupUtilException("The file " & source.FullName & " was not found. " & _
                            "Please ensure that this file exists.")
                    RaiseEvent ErrorOccurred(errNotFound, True)
                    aborted = Not bContinueOnError
                    m_oBackupStatus.numFilesSkipped += 1
                    Exit Sub
                Catch NoMem As InsufficientMemoryException
                    m_sErrorFiles += NoMem.Message & "<BR>"
                    Dim errOutOfMemory As New BackupUtilException("There is insufficient memory to run this application.")
                    RaiseEvent ErrorOccurred(errOutOfMemory, False)
                    aborted = True
                    Exit Sub
                Catch ex As Exception
                    m_sErrorFiles += ex.Message & "<BR>"
                    Dim errGeneric As New BackupUtilException("An unknown error was encountered." & vbCrLf & ex.Message)
                    RaiseEvent ErrorOccurred(errGeneric, True)
                    aborted = Not bContinueOnError
                    m_oBackupStatus.numFilesSkipped += 1
                Finally
                    With m_oBackupStatus
                        .numFilesRemaining = .numTotalFiles - .numFilesCopied - .numFilesSkipped
                    End With
                    RaiseEvent FileCopied(m_oBackupStatus)
                    m_copyInfo.nFreeSpaceRemaining = getDriveFreeSpace(destinationDir.Substring(0, 3))
                    RaiseEvent notifyDiskIoChange(m_copyInfo)
                End Try
            Next
        Catch ex As Exception
            ' New exception - ignore and move on.
        End Try
        ' Return if no recursive call is required. 
        If Not recursive Then
            Return
        End If

        ' Do the same for all sub directories. 
        Try
            For Each directory As DirectoryInfo In source.GetDirectories()
                copyAllFiles(directory, New DirectoryInfo(Path.Combine(target.FullName, directory.Name)), recursive)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Function generateReport() As String
        ' Generate the HTML report.

        Dim logWriter As StreamWriter = Nothing

        If Not Directory.Exists(destinationDir + "\log") Then
            MkDir(destinationDir + "\log")
        End If
        Dim sLogFileName As String = Path.Combine(destinationDir, "log\backup_" + DateTime.Now.ToString("yy\-MM\-dd") + "_" + Format(DateTime.Now, "h-mm-ss tt") + ".html")
        Try
            logWriter = File.CreateText(sLogFileName)
            logWriter.WriteLine("<html>")
            logWriter.WriteLine("<head>")
            logWriter.WriteLine("<meta http-equiv=""content-type"" content=""text/html;charset=UTF-8""/>")
            logWriter.WriteLine("<title>SmartBackUp Report " & DateTime.Now.ToShortDateString & " - " & sourceDir & "</title>")
            logWriter.WriteLine("</head>")
            '<font color="#00CC33" size="7">
            logWriter.WriteLine("<body>")
            logWriter.WriteLine("<font color=Green><font face=arial><h1>Backup Report :</u></h1><br><hr>")
            logWriter.WriteLine("<font color=blue>Backup Date : " & DateTime.Now.ToShortDateString & "<br>")
            logWriter.WriteLine("<font color=blue>Backup Time : " & DateTime.Now.ToShortTimeString & "<br>")
            logWriter.WriteLine("<br>")
            logWriter.WriteLine("<font color=black>Computer Name: " & System.Net.Dns.GetHostName & "<br>")
            logWriter.WriteLine("IP Address: " & System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList(0).ToString() & "<br>")
            'logWriter.WriteLine("")
            logWriter.WriteLine("<br>")
            If File.Exists(Me.Script) Then
                logWriter.WriteLine("Script Launched : <B>" & Me.Script & "</B><br>")
            Else
                logWriter.WriteLine("Source Directory : <B>" & sourceDir & "</B><br>")
            End If
            logWriter.WriteLine("Backup Directory :  <B>" & destinationDir & " </B><br>")
            logWriter.WriteLine("<br>")
            logWriter.WriteLine("<font color=black>Logging : " + IIf(m_eLogMode = ELogMode.E_LogAll, "Log All", _
                                               IIf(m_eLogMode = ELogMode.E_LogErrors, "Log Errors", "None")).ToString + "<br><hr><br>")
            If (m_eLogMode = ELogMode.E_LogAll) Then
                logWriter.WriteLine("<font color=black><B>The following files were copied :</B><br>")
                logWriter.WriteLine(m_sCopiedFiles)
                logWriter.WriteLine("<font color=black><br><hr><br>")
            End If
            If (m_sErrorFiles.Length > 0) Then
                logWriter.WriteLine("<font color=red><B>The following files were not copied due to errors :</B><br>")
                logWriter.WriteLine(m_sErrorFiles)
                logWriter.WriteLine("<font color=black><br><hr><br>")
            End If

            If (m_eLogMode = ELogMode.E_LogAll And m_sSkippedFiles.Length > 0) Then
                logWriter.WriteLine("<font color=black><b>The following files were skipped :</b><br>")
                logWriter.WriteLine(m_sSkippedFiles)
                logWriter.WriteLine("<font color=black><br><hr><BR>")
            End If
            If (aborted) Then
                logWriter.WriteLine("<B><font color=red>Backup aborted by user at : " & DateTime.Now.ToString & ".</font></B>")
            Else
                logWriter.WriteLine("<B><font color=blue>Backup completed at : " & DateTime.Now.ToString & ".</font></B><BR><BR>")
            End If
            logWriter.WriteLine("<font color=blue><B>Statistics</B><BR><BR><BR>")
            logWriter.WriteLine("<font color=black><B>MB To Copy : </B>" & convertBytesToMegaBytesStr(m_copyInfo.nTotalBytesToCopy) & "<br>")
            logWriter.WriteLine("<B>MB Copied : </B>" & convertBytesToMegaBytesStr(m_copyInfo.nBytesCopied) & " MB<br>")
            logWriter.WriteLine("<B>Files Copied : </B>" & m_oBackupStatus.numFilesCopied.ToString & "<br>")
            logWriter.WriteLine("<B>Files Skipped : </B>" & m_oBackupStatus.numFilesSkipped.ToString & "<br>")
            'Dim TimeTaken As String

            'TimeTaken = MainForm.lblTimeElapsed.Text

            logWriter.WriteLine("<B>Total Time Taken : </B>" & m_oBackupStatus.elapsedTime & "<br>")
            logWriter.WriteLine("<font></body>")
            logWriter.WriteLine("</html>")
            logWriter.Close()
        Catch ex As Exception
            sLogFileName = ""
            MsgBox("An error occurred while trying to create the HTML report." & vbCrLf & ex.Message)
        Finally
            If (logWriter IsNot Nothing) Then logWriter.Close()
        End Try
        Return sLogFileName
    End Function
End Class
Public Class BackupStatus
    Public fileBeingCopied As String
    Public numFilesSkipped As Int32
    Public numFilesCopied As Int32
    Public numFilesRemaining As Int32
    Public numTotalFiles As Int32
    Public startTime As Date
    Public Sub New()

    End Sub


    Public Sub reset()
        Me.fileBeingCopied = ""
        Me.numFilesCopied = 0
        Me.numFilesRemaining = 0
        Me.numFilesSkipped = 0
        Me.numTotalFiles = 0
        Me.startTime = Now
    End Sub
    Public Function elapsedTime() As String
        Dim ts As TimeSpan = DateTime.Now.Subtract(startTime)
        Return Format(ts.Hours, "###0") & ":" & Format(ts.Minutes, "00") & ":" & Format(ts.Seconds, "00")
    End Function
End Class
Public Class BackupUtilException
    Inherits System.Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New("Details: " & message & vbNewLine & "Time: " & DateTime.Now.ToString & vbNewLine, innerException)
    End Sub
End Class