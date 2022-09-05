Imports System.IO

Public Class ScriptEditor

    Private Sub ScriptEditor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        MainForm.txScript.Items.Clear()

        Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")

        For Each file As FileInfo In dir.GetFiles("*.ini")
            MainForm.txScript.Items.Add(file.Name)
        Next

    End Sub
    Private Sub ScriptEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CmbBackupScript.Items.Clear()

        Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")

        For Each file As FileInfo In dir.GetFiles("*.ini")
            CmbBackupScript.Items.Add(file.Name)
        Next

        CmbFolders.Items.Clear()

        Dim MySystemUtils As New SystemUtil
        Dim MYOS As String
        MYOS = MySystemUtils.GetOSVersion()
        Dim UserProfile As String
        UserProfile = System.Environment.GetEnvironmentVariable("USERPROFILE")

        Select Case MYOS
            Case "Windows XP"
                CmbFolders.Items.Add("Application Data:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData))
                CmbFolders.Items.Add("My Documents:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments))
                CmbFolders.Items.Add("My Pictures:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures))
                CmbFolders.Items.Add("My Music:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic))
                CmbFolders.Items.Add("Desktop:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop))
                CmbFolders.Items.Add("Favourites:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.Favorites))
                CmbFolders.Items.Add("User Profile:   " & UserProfile)

            Case "Windows Vista"
                CmbFolders.Items.Add("Application Data:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData))
                CmbFolders.Items.Add("My Documents:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments))
                CmbFolders.Items.Add("My Pictures:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures))
                CmbFolders.Items.Add("My Music:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic))
                CmbFolders.Items.Add("Desktop:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop))
                CmbFolders.Items.Add("Favourites:   " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.Favorites))
                CmbFolders.Items.Add("User Profile:   " & UserProfile)
                CmbFolders.Items.Add("Windows Mail:   " & UserProfile & "\AppData\Local\Microsoft\Windows Mail")
                CmbFolders.Items.Add("Contacts:   " & UserProfile & "\Contacts")

            Case Else
                '"Unknown OS"
        End Select




    End Sub

    Private Sub BtScriptFilesRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScriptFilesRefresh.Click
        CmbBackupScript.Items.Clear()

        Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")

        For Each file As FileInfo In dir.GetFiles("*.ini")
            CmbBackupScript.Items.Add(file.Name)
        Next


    End Sub

    Private Sub BtNAddFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNAddFolder.Click
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
            CmbBackupScript.Items.Clear()
            Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")
            For Each file As FileInfo In dir.GetFiles("*.ini")
                CmbBackupScript.Items.Add(file.Name)
            Next
        End If


    End Sub

    Private Sub BtScriptSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScriptSave.Click
        Dim F As StreamWriter
        Dim FolderCount As Integer
        Dim FileCount As Integer

        Try
            F = New StreamWriter(Application.StartupPath + "\Scripts\" & CmbBackupScript.Text, False)

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

        MyFile = Application.StartupPath + "\scripts\" + CmbBackupScript.Text
        If System.IO.File.Exists(MyFile) = True Then
            Dim dlgResult As MsgBoxResult = MsgBox("Are you sure you want to delete this script?" & vbNewLine & "Any Syncs using this script will no longer function!", MsgBoxStyle.YesNo, "Confirm Delete")
            If dlgResult = Windows.Forms.DialogResult.Yes Then

                Kill(MyFile)

                'Refresh the Combo box which lists the script files.
                CmbBackupScript.Items.Clear()

                Dim dir As New DirectoryInfo(Application.StartupPath + "\scripts")
                For Each file As FileInfo In dir.GetFiles("*.ini")
                    CmbBackupScript.Items.Add(file.Name)
                Next
            End If
        End If

    End Sub

    Private Sub BtScriptLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScriptLoad.Click
        Dim F As StreamReader
        Dim LineA As String
        If CmbBackupScript.Text = "" Then
        Else

            Try
                LstCreatorFiles.Items.Clear()
                LstCreatorFolders.Items.Clear()

                F = New StreamReader(Application.StartupPath + "\scripts\" + CmbBackupScript.Text)
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

    Private Sub CmbFolders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFolders.SelectedIndexChanged

        Dim MyFolderPath As String = Nothing
        Dim strArr() As String = Nothing
        Dim count As Integer = Nothing
        strArr = Split(CmbFolders.Text, "   ")
        MyFolderPath = strArr(1)
        LstCreatorFolders.Items.Add(strArr(1))

    End Sub
End Class