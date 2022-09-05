<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptEditor))
        Me.BtnRemoveFolder = New System.Windows.Forms.Button
        Me.BtNAddFolder = New System.Windows.Forms.Button
        Me.BtnRemoveFile = New System.Windows.Forms.Button
        Me.BtnAddFile = New System.Windows.Forms.Button
        Me.BtScriptFilesRefresh = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbBackupScript = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LstCreatorFiles = New System.Windows.Forms.ListBox
        Me.LstCreatorFolders = New System.Windows.Forms.ListBox
        Me.BtScriptDelete = New System.Windows.Forms.Button
        Me.BtScriptLoad = New System.Windows.Forms.Button
        Me.BtNewScript = New System.Windows.Forms.Button
        Me.BtScriptSave = New System.Windows.Forms.Button
        Me.FOScriptCreator = New System.Windows.Forms.OpenFileDialog
        Me.FDScriptCreator = New System.Windows.Forms.FolderBrowserDialog
        Me.FDScriptNew = New System.Windows.Forms.SaveFileDialog
        Me.CmbFolders = New System.Windows.Forms.ComboBox
        Me.LbSpecialFolder = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'BtnRemoveFolder
        '
        Me.BtnRemoveFolder.Location = New System.Drawing.Point(436, 144)
        Me.BtnRemoveFolder.Name = "BtnRemoveFolder"
        Me.BtnRemoveFolder.Size = New System.Drawing.Size(80, 24)
        Me.BtnRemoveFolder.TabIndex = 27
        Me.BtnRemoveFolder.Text = "Remove Item"
        Me.BtnRemoveFolder.UseVisualStyleBackColor = True
        '
        'BtNAddFolder
        '
        Me.BtNAddFolder.Location = New System.Drawing.Point(339, 144)
        Me.BtNAddFolder.Name = "BtNAddFolder"
        Me.BtNAddFolder.Size = New System.Drawing.Size(80, 24)
        Me.BtNAddFolder.TabIndex = 26
        Me.BtNAddFolder.Text = "Add A Folder"
        Me.BtNAddFolder.UseVisualStyleBackColor = True
        '
        'BtnRemoveFile
        '
        Me.BtnRemoveFile.Location = New System.Drawing.Point(436, 314)
        Me.BtnRemoveFile.Name = "BtnRemoveFile"
        Me.BtnRemoveFile.Size = New System.Drawing.Size(80, 24)
        Me.BtnRemoveFile.TabIndex = 25
        Me.BtnRemoveFile.Text = "Remove Item"
        Me.BtnRemoveFile.UseVisualStyleBackColor = True
        '
        'BtnAddFile
        '
        Me.BtnAddFile.Location = New System.Drawing.Point(342, 314)
        Me.BtnAddFile.Name = "BtnAddFile"
        Me.BtnAddFile.Size = New System.Drawing.Size(80, 24)
        Me.BtnAddFile.TabIndex = 24
        Me.BtnAddFile.Text = "Add A File"
        Me.BtnAddFile.UseVisualStyleBackColor = True
        '
        'BtScriptFilesRefresh
        '
        Me.BtScriptFilesRefresh.Location = New System.Drawing.Point(418, 12)
        Me.BtScriptFilesRefresh.Name = "BtScriptFilesRefresh"
        Me.BtScriptFilesRefresh.Size = New System.Drawing.Size(98, 21)
        Me.BtScriptFilesRefresh.TabIndex = 23
        Me.BtScriptFilesRefresh.Text = "Refresh List"
        Me.BtScriptFilesRefresh.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(9, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Select a script to Edit:"
        '
        'CmbBackupScript
        '
        Me.CmbBackupScript.FormattingEnabled = True
        Me.CmbBackupScript.Location = New System.Drawing.Point(168, 12)
        Me.CmbBackupScript.Name = "CmbBackupScript"
        Me.CmbBackupScript.Size = New System.Drawing.Size(244, 21)
        Me.CmbBackupScript.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(24, 481)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(475, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Simply Click the add buttons to add folders and files you wish to include in the " & _
            "back list."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label4.Location = New System.Drawing.Point(11, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Folder List:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 323)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 18)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "File List:"
        '
        'LstCreatorFiles
        '
        Me.LstCreatorFiles.FormattingEnabled = True
        Me.LstCreatorFiles.Location = New System.Drawing.Point(12, 344)
        Me.LstCreatorFiles.Name = "LstCreatorFiles"
        Me.LstCreatorFiles.Size = New System.Drawing.Size(504, 134)
        Me.LstCreatorFiles.TabIndex = 17
        '
        'LstCreatorFolders
        '
        Me.LstCreatorFolders.FormattingEnabled = True
        Me.LstCreatorFolders.Location = New System.Drawing.Point(12, 174)
        Me.LstCreatorFolders.Name = "LstCreatorFolders"
        Me.LstCreatorFolders.Size = New System.Drawing.Size(504, 134)
        Me.LstCreatorFolders.TabIndex = 16
        '
        'BtScriptDelete
        '
        Me.BtScriptDelete.Image = Global.SmartBack.My.Resources.Resources.ScriptDelete
        Me.BtScriptDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtScriptDelete.Location = New System.Drawing.Point(342, 42)
        Me.BtScriptDelete.Name = "BtScriptDelete"
        Me.BtScriptDelete.Size = New System.Drawing.Size(105, 36)
        Me.BtScriptDelete.TabIndex = 31
        Me.BtScriptDelete.Text = "Delete Script"
        Me.BtScriptDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtScriptDelete.UseVisualStyleBackColor = True
        '
        'BtScriptLoad
        '
        Me.BtScriptLoad.Image = Global.SmartBack.My.Resources.Resources.ScriptLoad
        Me.BtScriptLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtScriptLoad.Location = New System.Drawing.Point(231, 42)
        Me.BtScriptLoad.Name = "BtScriptLoad"
        Me.BtScriptLoad.Size = New System.Drawing.Size(105, 36)
        Me.BtScriptLoad.TabIndex = 30
        Me.BtScriptLoad.Text = "Load Script"
        Me.BtScriptLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtScriptLoad.UseVisualStyleBackColor = True
        '
        'BtNewScript
        '
        Me.BtNewScript.Image = Global.SmartBack.My.Resources.Resources.ScriptAdd
        Me.BtNewScript.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtNewScript.Location = New System.Drawing.Point(12, 42)
        Me.BtNewScript.Name = "BtNewScript"
        Me.BtNewScript.Size = New System.Drawing.Size(103, 36)
        Me.BtNewScript.TabIndex = 29
        Me.BtNewScript.Text = "New Script"
        Me.BtNewScript.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtNewScript.UseVisualStyleBackColor = True
        '
        'BtScriptSave
        '
        Me.BtScriptSave.Image = Global.SmartBack.My.Resources.Resources.ScriptSave
        Me.BtScriptSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtScriptSave.Location = New System.Drawing.Point(121, 42)
        Me.BtScriptSave.Name = "BtScriptSave"
        Me.BtScriptSave.Size = New System.Drawing.Size(104, 36)
        Me.BtScriptSave.TabIndex = 28
        Me.BtScriptSave.Text = "Save Script"
        Me.BtScriptSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtScriptSave.UseVisualStyleBackColor = True
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
        'CmbFolders
        '
        Me.CmbFolders.FormattingEnabled = True
        Me.CmbFolders.Location = New System.Drawing.Point(184, 117)
        Me.CmbFolders.Name = "CmbFolders"
        Me.CmbFolders.Size = New System.Drawing.Size(332, 21)
        Me.CmbFolders.TabIndex = 32
        '
        'LbSpecialFolder
        '
        Me.LbSpecialFolder.AutoSize = True
        Me.LbSpecialFolder.Location = New System.Drawing.Point(12, 120)
        Me.LbSpecialFolder.Name = "LbSpecialFolder"
        Me.LbSpecialFolder.Size = New System.Drawing.Size(149, 13)
        Me.LbSpecialFolder.TabIndex = 33
        Me.LbSpecialFolder.Text = "Select a Special Folder to add"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(510, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "The drop down list below has some example folders you may wish to backup such as " & _
            "my docs, my pics etc."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(325, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Simply select an item in the list and it will be added to the folders list."
        '
        'ScriptEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 505)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LbSpecialFolder)
        Me.Controls.Add(Me.CmbFolders)
        Me.Controls.Add(Me.BtScriptDelete)
        Me.Controls.Add(Me.BtScriptLoad)
        Me.Controls.Add(Me.BtNewScript)
        Me.Controls.Add(Me.BtScriptSave)
        Me.Controls.Add(Me.BtnRemoveFolder)
        Me.Controls.Add(Me.BtNAddFolder)
        Me.Controls.Add(Me.BtnRemoveFile)
        Me.Controls.Add(Me.BtnAddFile)
        Me.Controls.Add(Me.BtScriptFilesRefresh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbBackupScript)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LstCreatorFiles)
        Me.Controls.Add(Me.LstCreatorFolders)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ScriptEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ScriptEditor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtScriptDelete As System.Windows.Forms.Button
    Friend WithEvents BtScriptLoad As System.Windows.Forms.Button
    Friend WithEvents BtNewScript As System.Windows.Forms.Button
    Friend WithEvents BtScriptSave As System.Windows.Forms.Button
    Friend WithEvents BtnRemoveFolder As System.Windows.Forms.Button
    Friend WithEvents BtNAddFolder As System.Windows.Forms.Button
    Friend WithEvents BtnRemoveFile As System.Windows.Forms.Button
    Friend WithEvents BtnAddFile As System.Windows.Forms.Button
    Friend WithEvents BtScriptFilesRefresh As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbBackupScript As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LstCreatorFiles As System.Windows.Forms.ListBox
    Friend WithEvents LstCreatorFolders As System.Windows.Forms.ListBox
    Friend WithEvents FOScriptCreator As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FDScriptCreator As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FDScriptNew As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CmbFolders As System.Windows.Forms.ComboBox
    Friend WithEvents LbSpecialFolder As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
