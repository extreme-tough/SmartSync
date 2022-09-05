'===================================================================================================
'   File        :   modDriveInfo.vb (Module)
'   Purpose     :   Provides functionality to retrieve Drive related information
'                   e.g. Disk size, Free space etc.
'===================================================================================================
Option Explicit On
Option Strict On
Option Infer Off
Imports System.IO

Module modDiskUtil
    Private Declare Function GetDiskFreeSpaceEx Lib "kernel32" _
        Alias "GetDiskFreeSpaceExA" _
        (ByVal lpDirectoryName As String, _
        ByRef lpFreeBytesAvailableToCaller As Long, _
        ByRef lpTotalNumberOfBytes As Long, _
        ByRef lpTotalNumberOfFreeBytes As Long) As Long
    Public Function getDriveFreeSpace(ByVal sDrive As String) As Long
        ' Returns the free space in bytes for the specified Drive.
        Dim lBytesTotal, lFreeBytes, lFreeBytesAvailable As Long
        Dim iAns As Long = GetDiskFreeSpaceEx(sDrive, lFreeBytesAvailable, lBytesTotal, lFreeBytes)
        If iAns > 0 Then
            Return lFreeBytes
        Else
            'Throw New Exception("Invalid or unreadable drive")
        End If
    End Function
    Public Function getDriveTotalSpace(ByVal sDrive As String) As Long
        ' Returns the total space in bytes for the specified Drive.
        Dim lBytesTotal, lFreeBytes, lFreeBytesAvailable As Long
        Dim iAns As Long = GetDiskFreeSpaceEx(sDrive, lFreeBytesAvailable, lBytesTotal, lFreeBytes)
        If iAns > 0 Then
            Return lBytesTotal
        Else
            Throw New Exception("Invalid or unreadable drive")
        End If
    End Function
    Public Function convertBytesToMegaBytes(ByVal nBytes As Long) As Double
        ' Returns the conversion of bytes in megabytes as double.
        Return nBytes / 1024 / 1024
    End Function
    Public Function convertBytesToMegaBytesStr(ByVal nBytes As Long) As String
        ' Returns the conversion of bytes into megabytes after formatting.
        Return Format(convertBytesToMegaBytes(nBytes), "###,###,##0.00")
    End Function
    Public Function getFolderSize(ByVal sPath As String, ByVal bSubFolders As Boolean) As Long
        ' Returns the size in bytes of the contents of the specified folder
        Try
            Dim size As Long = 0
            Dim diBase As New DirectoryInfo(sPath)
            Dim files() As FileInfo
            If bSubFolders Then
                files = diBase.GetFiles("*.*", SearchOption.AllDirectories)
            Else
                files = diBase.GetFiles("*", SearchOption.TopDirectoryOnly)
            End If
            Dim ie As IEnumerator = files.GetEnumerator
            While ie.MoveNext
                size += DirectCast(ie.Current, FileInfo).Length
            End While
            Return size
        Catch NotAuthorized As UnauthorizedAccessException
            Dim sMsg As String = NotAuthorized.Message & vbCrLf & _
                    "Please ensure that this file is not locked by another application, or, the user may not " & _
                    "have sufficient priviledges to access this file."
            'MsgBox(sMsg, MsgBoxStyle.Critical, Application.ProductName)
            Exit Function
        Catch ex As Exception
            'MsgBox("Error: " & ex.Message)
            Return -1
        End Try
    End Function
    Public Function getIsPathWritable(ByVal sPath As String) As Boolean
        ' Returns whether the specified path (directory) is writable.
        ' The function creates a temporary file, and deletes it.
        ' If a temporary file cannot be created, the directory is not writable.
        getIsPathWritable = False
        Dim testFS As FileStream = Nothing
        Try
            Dim testFileName As String = Path.Combine(sPath, System.Guid.NewGuid().ToString + ".test")
            testFS = File.Create(testFileName)
            testFS.Close()
            File.Delete(testFileName)
            getIsPathWritable = True
        Catch ex As Exception
        Finally
            If testFS IsNot Nothing Then
                testFS.Close()
                testFS.Dispose()
            End If
        End Try
    End Function
End Module