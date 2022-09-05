<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDrive
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
        Me.CbDrives = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtOk = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.LblDisDrive = New System.Windows.Forms.Label
        Me.LblDisDriveLabel = New System.Windows.Forms.Label
        Me.LblDisFreeSpace = New System.Windows.Forms.Label
        Me.LblDriveLetter = New System.Windows.Forms.Label
        Me.LblDriveLabel = New System.Windows.Forms.Label
        Me.LblDriveFreeSpace = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblSyncLocation = New System.Windows.Forms.Label
        Me.DlgFolderSelector = New System.Windows.Forms.FolderBrowserDialog
        Me.BtSyncLocation = New System.Windows.Forms.Button
        Me.LblOptAutoSync = New System.Windows.Forms.Label
        Me.ChkAutoSync = New System.Windows.Forms.CheckBox
        Me.BtScript = New System.Windows.Forms.Button
        Me.FOScript = New System.Windows.Forms.OpenFileDialog
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbSelectScript = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'CbDrives
        '
        Me.CbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDrives.FormattingEnabled = True
        Me.CbDrives.Location = New System.Drawing.Point(183, 4)
        Me.CbDrives.Name = "CbDrives"
        Me.CbDrives.Size = New System.Drawing.Size(63, 21)
        Me.CbDrives.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Removable Drive"
        '
        'BtOk
        '
        Me.BtOk.Location = New System.Drawing.Point(15, 254)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(75, 23)
        Me.BtOk.TabIndex = 2
        Me.BtOk.Text = "Ok"
        Me.BtOk.UseVisualStyleBackColor = True
        '
        'BtCancel
        '
        Me.BtCancel.Location = New System.Drawing.Point(171, 254)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 3
        Me.BtCancel.Text = "Cancel"
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'LblDisDrive
        '
        Me.LblDisDrive.AutoSize = True
        Me.LblDisDrive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisDrive.Location = New System.Drawing.Point(16, 41)
        Me.LblDisDrive.Name = "LblDisDrive"
        Me.LblDisDrive.Size = New System.Drawing.Size(43, 16)
        Me.LblDisDrive.TabIndex = 4
        Me.LblDisDrive.Text = "Drive:"
        '
        'LblDisDriveLabel
        '
        Me.LblDisDriveLabel.AutoSize = True
        Me.LblDisDriveLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisDriveLabel.Location = New System.Drawing.Point(16, 66)
        Me.LblDisDriveLabel.Name = "LblDisDriveLabel"
        Me.LblDisDriveLabel.Size = New System.Drawing.Size(80, 16)
        Me.LblDisDriveLabel.TabIndex = 5
        Me.LblDisDriveLabel.Text = "Drive Label:"
        '
        'LblDisFreeSpace
        '
        Me.LblDisFreeSpace.AutoSize = True
        Me.LblDisFreeSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisFreeSpace.Location = New System.Drawing.Point(16, 95)
        Me.LblDisFreeSpace.Name = "LblDisFreeSpace"
        Me.LblDisFreeSpace.Size = New System.Drawing.Size(82, 16)
        Me.LblDisFreeSpace.TabIndex = 6
        Me.LblDisFreeSpace.Text = "Free Space:"
        '
        'LblDriveLetter
        '
        Me.LblDriveLetter.AutoSize = True
        Me.LblDriveLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDriveLetter.Location = New System.Drawing.Point(180, 41)
        Me.LblDriveLetter.Name = "LblDriveLetter"
        Me.LblDriveLetter.Size = New System.Drawing.Size(14, 16)
        Me.LblDriveLetter.TabIndex = 7
        Me.LblDriveLetter.Text = "  "
        '
        'LblDriveLabel
        '
        Me.LblDriveLabel.AutoSize = True
        Me.LblDriveLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDriveLabel.Location = New System.Drawing.Point(180, 66)
        Me.LblDriveLabel.Name = "LblDriveLabel"
        Me.LblDriveLabel.Size = New System.Drawing.Size(14, 16)
        Me.LblDriveLabel.TabIndex = 8
        Me.LblDriveLabel.Text = "  "
        '
        'LblDriveFreeSpace
        '
        Me.LblDriveFreeSpace.AutoSize = True
        Me.LblDriveFreeSpace.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDriveFreeSpace.Location = New System.Drawing.Point(180, 95)
        Me.LblDriveFreeSpace.Name = "LblDriveFreeSpace"
        Me.LblDriveFreeSpace.Size = New System.Drawing.Size(14, 16)
        Me.LblDriveFreeSpace.TabIndex = 9
        Me.LblDriveFreeSpace.Text = "  "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sync Location:"
        '
        'LblSyncLocation
        '
        Me.LblSyncLocation.AutoSize = True
        Me.LblSyncLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.LblSyncLocation.Location = New System.Drawing.Point(16, 190)
        Me.LblSyncLocation.Name = "LblSyncLocation"
        Me.LblSyncLocation.Size = New System.Drawing.Size(13, 13)
        Me.LblSyncLocation.TabIndex = 11
        Me.LblSyncLocation.Text = "  "
        '
        'DlgFolderSelector
        '
        Me.DlgFolderSelector.Description = "Select a directory for the sync root"
        '
        'BtSyncLocation
        '
        Me.BtSyncLocation.Location = New System.Drawing.Point(117, 119)
        Me.BtSyncLocation.Name = "BtSyncLocation"
        Me.BtSyncLocation.Size = New System.Drawing.Size(92, 24)
        Me.BtSyncLocation.TabIndex = 12
        Me.BtSyncLocation.Text = "Select Folder"
        Me.BtSyncLocation.UseVisualStyleBackColor = True
        '
        'LblOptAutoSync
        '
        Me.LblOptAutoSync.AutoSize = True
        Me.LblOptAutoSync.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOptAutoSync.Location = New System.Drawing.Point(16, 219)
        Me.LblOptAutoSync.Name = "LblOptAutoSync"
        Me.LblOptAutoSync.Size = New System.Drawing.Size(66, 16)
        Me.LblOptAutoSync.TabIndex = 13
        Me.LblOptAutoSync.Text = "Autosync:"
        '
        'ChkAutoSync
        '
        Me.ChkAutoSync.AutoSize = True
        Me.ChkAutoSync.Location = New System.Drawing.Point(171, 221)
        Me.ChkAutoSync.Name = "ChkAutoSync"
        Me.ChkAutoSync.Size = New System.Drawing.Size(15, 14)
        Me.ChkAutoSync.TabIndex = 14
        Me.ChkAutoSync.UseVisualStyleBackColor = True
        '
        'BtScript
        '
        Me.BtScript.Location = New System.Drawing.Point(230, 119)
        Me.BtScript.Name = "BtScript"
        Me.BtScript.Size = New System.Drawing.Size(92, 24)
        Me.BtScript.TabIndex = 15
        Me.BtScript.Text = "Select Script"
        Me.BtScript.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "or Script:"
        '
        'CmbSelectScript
        '
        Me.CmbSelectScript.FormattingEnabled = True
        Me.CmbSelectScript.Location = New System.Drawing.Point(117, 155)
        Me.CmbSelectScript.Name = "CmbSelectScript"
        Me.CmbSelectScript.Size = New System.Drawing.Size(205, 21)
        Me.CmbSelectScript.TabIndex = 17
        '
        'SelectDrive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 298)
        Me.Controls.Add(Me.CmbSelectScript)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtScript)
        Me.Controls.Add(Me.ChkAutoSync)
        Me.Controls.Add(Me.LblOptAutoSync)
        Me.Controls.Add(Me.BtSyncLocation)
        Me.Controls.Add(Me.LblSyncLocation)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblDriveFreeSpace)
        Me.Controls.Add(Me.LblDriveLabel)
        Me.Controls.Add(Me.LblDriveLetter)
        Me.Controls.Add(Me.LblDisFreeSpace)
        Me.Controls.Add(Me.LblDisDriveLabel)
        Me.Controls.Add(Me.LblDisDrive)
        Me.Controls.Add(Me.BtCancel)
        Me.Controls.Add(Me.BtOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbDrives)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectDrive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Removeable Drive"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbDrives As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents LblDisDrive As System.Windows.Forms.Label
    Friend WithEvents LblDisDriveLabel As System.Windows.Forms.Label
    Friend WithEvents LblDisFreeSpace As System.Windows.Forms.Label
    Friend WithEvents LblDriveLetter As System.Windows.Forms.Label
    Friend WithEvents LblDriveLabel As System.Windows.Forms.Label
    Friend WithEvents LblDriveFreeSpace As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DlgFolderSelector As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtSyncLocation As System.Windows.Forms.Button
    Friend WithEvents LblOptAutoSync As System.Windows.Forms.Label
    Friend WithEvents ChkAutoSync As System.Windows.Forms.CheckBox
    Friend WithEvents BtScript As System.Windows.Forms.Button
    Friend WithEvents FOScript As System.Windows.Forms.OpenFileDialog
    Public WithEvents LblSyncLocation As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSelectScript As System.Windows.Forms.ComboBox
End Class
