Imports System.IO

Public Class SelectDrive
    Public Valid As Boolean
    Public Drive As String
    Public DriveSync As String
    Public DriveFolder As String
    'Added to get free Space
    Public Declare Function GetDiskFreeSpaceEx _
    Lib "kernel32" _
    Alias "GetDiskFreeSpaceExA" _
    (ByVal lpDirectoryName As String, _
    ByRef lpFreeBytesAvailableToCaller As Long, _
    ByRef lpTotalNumberOfBytes As Long, _
    ByRef lpTotalNumberOfFreeBytes As Long) As Long
    Dim ScriptsFolder As String = (Application.StartupPath + "\scripts\")
    Dim ScriptsFolderFiles As New DirectoryInfo(Application.StartupPath + "\scripts")

    Public Sub AddDrivesToCombobox(ByRef Combo As ComboBox)
        Dim Drive As DriveInfo

        Combo.Items.Clear()
        Combo.Items.Add("")

        For Each Drive In My.Computer.FileSystem.Drives
            If Drive.DriveType = DriveType.Removable Then
                Combo.Items.Add(Drive.Name)
            End If
        Next

        If Combo.Items.Count > 0 Then
            Combo.SelectedIndex = 0
        Else
            MessageBox.Show("No removeable drives found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub SelectDrive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = USBSync.Icon

        Me.CbDrives.Items.Clear()
        Me.CbDrives.Enabled = True

        Me.AddDrivesToCombobox(Me.CbDrives)
        Me.Valid = False
        Me.Drive = ""

        LblSyncLocation.Text = USBSync.PassFolderOrScript
        If USBSync.PassDrive = Nothing Then
        Else
            CbDrives.Text = USBSync.PassDrive
            Me.Drive = USBSync.PassDrive
            CbDrives.Enabled = False
        End If

        For Each file As FileInfo In ScriptsFolderFiles.GetFiles("*.ini")
            CmbSelectScript.Items.Add(file.Name)
        Next

    End Sub

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        If Me.CbDrives.SelectedIndex >= 0 Then
            Me.Drive = CbDrives.SelectedItem.ToString
        End If

        If ChkAutoSync.Checked = True Then
            DriveSync = "Yes"
        Else
            DriveSync = "No"
        End If
        Me.Valid = True

        USBSync.PassFolderOrScript = LblSyncLocation.Text

        Me.CbDrives.Enabled = True

        Me.Hide()

    End Sub

    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Me.CbDrives.Enabled = True
        Me.Valid = False
        Me.Hide()
    End Sub
    Private Sub CbDrives_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDrives.SelectedValueChanged

        LblDriveLetter.Text = CbDrives.SelectedItem.ToString
        LblDriveLabel.Text = Microsoft.VisualBasic.Dir(CbDrives.SelectedItem.ToString, FileAttribute.Volume)
        LblDriveFreeSpace.Text = GetFreeSpace(CbDrives.SelectedItem.ToString) & " MB"
    End Sub
    'Free Space
    'Free Space
    Public Function GetFreeSpace(ByVal Drive As String) As Long
        'returns free space in MB, formatted to two decimal places
        'e.g., msgbox("Free Space on C: "& GetFreeSpace("C:\") & "MB")

        Dim lBytesTotal, lFreeBytes, lFreeBytesAvailable As Long

        Dim iAns As Long

        iAns = GetDiskFreeSpaceEx(Drive, lFreeBytesAvailable, _
             lBytesTotal, lFreeBytes)
        If ians > 0 Then

            Return BytesToMegabytes(lFreeBytes)
        Else
            Throw New Exception("Invalid or unreadable drive")
        End If


    End Function


    Public Function GetTotalSpace(ByVal Drive As String) As String
        'returns total space in MB, formatted to two decimal places
        'e.g., msgbox("Free Space on C: "& GetTotalSpace("C:\") & "MB")

        Dim lBytesTotal, lFreeBytes, lFreeBytesAvailable As Long

        Dim iAns As Long

        iAns = GetDiskFreeSpaceEx(Drive, lFreeBytesAvailable, _
             lBytesTotal, lFreeBytes)
        If iAns > 0 Then

            Return BytesToMegabytes(lBytesTotal)
        Else
            Throw New Exception("Invalid or unreadable drive")
        End If
    End Function

    Private Function BytesToMegabytes(ByVal Bytes As Long) _
    As Long
        Dim dblAns As Double
        dblAns = (Bytes / 1024) / 1024
        BytesToMegabytes = Format(dblAns, "###,###,##0.00")

    End Function

    Private Sub BtSyncLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSyncLocation.Click
        Dim SelectedFolder As String

        Me.DlgFolderSelector.Description = "Select Folder To SYNC"
        Dim dlgResult As DialogResult = DlgFolderSelector.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then

            If IsNothing(Me.DlgFolderSelector.SelectedPath) Then

                MsgBox("Please select a fodler to SYNC!", MsgBoxStyle.Critical, "Error")

            Else
                SelectedFolder = Me.DlgFolderSelector.SelectedPath
                Me.LblSyncLocation.Text = SelectedFolder
                'USBSync.PassFolderOrScript = SelectedFolder
                Me.DriveFolder = SelectedFolder
            End If
        Else
        End If


    End Sub

    Private Sub BtScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScript.Click
        Dim SelectedFolder As String = ""

        If Me.FOScript.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SelectedFolder = Me.FOScript.FileName
            Me.LblSyncLocation.Text = SelectedFolder
            USBSync.PassFolderOrScript = SelectedFolder
            Me.DriveFolder = SelectedFolder
        End If
        
    End Sub

    Private Sub CmbSelectScript_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSelectScript.SelectedIndexChanged
        If CmbSelectScript.Text = Nothing Then
        Else
            LblSyncLocation.Text = CmbSelectScript.Text
        End If

    End Sub
End Class