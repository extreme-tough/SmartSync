<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblRegisterOnline = New System.Windows.Forms.Label
        Me.txtOnlineSKey = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnRegister = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.lblNotice = New System.Windows.Forms.Label
        Me.lblRegistrdTo = New System.Windows.Forms.Label
        Me.lblRegOwner = New System.Windows.Forms.Label
        Me.lblRegCompany = New System.Windows.Forms.Label
        Me.lblUnReg = New System.Windows.Forms.Label
        Me.pnlOnline = New System.Windows.Forms.Panel
        Me.lblActivationStatusOnline = New System.Windows.Forms.Label
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.pnlOffline = New System.Windows.Forms.Panel
        Me.lblActivationStatusOffline = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.BtnCheckKeyManual = New System.Windows.Forms.Button
        Me.btnMExit = New System.Windows.Forms.Button
        Me.txtmanualUnlockCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtOfflineSkey = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRegisterOffline = New System.Windows.Forms.Label
        Me.pnlOnline.SuspendLayout()
        Me.pnlOffline.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRegisterOnline
        '
        Me.lblRegisterOnline.AutoSize = True
        Me.lblRegisterOnline.BackColor = System.Drawing.Color.Transparent
        Me.lblRegisterOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRegisterOnline.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegisterOnline.Location = New System.Drawing.Point(14, 219)
        Me.lblRegisterOnline.Name = "lblRegisterOnline"
        Me.lblRegisterOnline.Size = New System.Drawing.Size(92, 15)
        Me.lblRegisterOnline.TabIndex = 0
        Me.lblRegisterOnline.Text = "Register Online"
        '
        'txtOnlineSKey
        '
        Me.txtOnlineSKey.Location = New System.Drawing.Point(102, 6)
        Me.txtOnlineSKey.Name = "txtOnlineSKey"
        Me.txtOnlineSKey.Size = New System.Drawing.Size(295, 20)
        Me.txtOnlineSKey.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Serial Key:"
        '
        'btnRegister
        '
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Location = New System.Drawing.Point(301, 30)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(96, 25)
        Me.btnRegister.TabIndex = 3
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(199, 30)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 25)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblNotice
        '
        Me.lblNotice.AutoSize = True
        Me.lblNotice.BackColor = System.Drawing.Color.Transparent
        Me.lblNotice.ForeColor = System.Drawing.Color.White
        Me.lblNotice.Location = New System.Drawing.Point(3, 195)
        Me.lblNotice.Name = "lblNotice"
        Me.lblNotice.Size = New System.Drawing.Size(242, 13)
        Me.lblNotice.TabIndex = 5
        Me.lblNotice.Text = "The purchased version doesn't display this notice."
        Me.lblNotice.Visible = False
        '
        'lblRegistrdTo
        '
        Me.lblRegistrdTo.AutoSize = True
        Me.lblRegistrdTo.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistrdTo.ForeColor = System.Drawing.Color.White
        Me.lblRegistrdTo.Location = New System.Drawing.Point(313, 144)
        Me.lblRegistrdTo.Name = "lblRegistrdTo"
        Me.lblRegistrdTo.Size = New System.Drawing.Size(59, 13)
        Me.lblRegistrdTo.TabIndex = 6
        Me.lblRegistrdTo.Text = "RegistrdTo"
        Me.lblRegistrdTo.Visible = False
        '
        'lblRegOwner
        '
        Me.lblRegOwner.AutoSize = True
        Me.lblRegOwner.BackColor = System.Drawing.Color.Transparent
        Me.lblRegOwner.ForeColor = System.Drawing.Color.White
        Me.lblRegOwner.Location = New System.Drawing.Point(390, 176)
        Me.lblRegOwner.Name = "lblRegOwner"
        Me.lblRegOwner.Size = New System.Drawing.Size(16, 13)
        Me.lblRegOwner.TabIndex = 7
        Me.lblRegOwner.Text = "..."
        Me.lblRegOwner.Visible = False
        '
        'lblRegCompany
        '
        Me.lblRegCompany.AutoSize = True
        Me.lblRegCompany.BackColor = System.Drawing.Color.Transparent
        Me.lblRegCompany.ForeColor = System.Drawing.Color.White
        Me.lblRegCompany.Location = New System.Drawing.Point(390, 189)
        Me.lblRegCompany.Name = "lblRegCompany"
        Me.lblRegCompany.Size = New System.Drawing.Size(16, 13)
        Me.lblRegCompany.TabIndex = 8
        Me.lblRegCompany.Text = "..."
        Me.lblRegCompany.Visible = False
        '
        'lblUnReg
        '
        Me.lblUnReg.AutoSize = True
        Me.lblUnReg.BackColor = System.Drawing.Color.Transparent
        Me.lblUnReg.ForeColor = System.Drawing.Color.White
        Me.lblUnReg.Location = New System.Drawing.Point(129, 176)
        Me.lblUnReg.Name = "lblUnReg"
        Me.lblUnReg.Size = New System.Drawing.Size(113, 13)
        Me.lblUnReg.TabIndex = 9
        Me.lblUnReg.Text = "UnRegistered Version."
        Me.lblUnReg.Visible = False
        '
        'pnlOnline
        '
        Me.pnlOnline.Controls.Add(Me.lblActivationStatusOnline)
        Me.pnlOnline.Controls.Add(Me.LinkLabel3)
        Me.pnlOnline.Controls.Add(Me.txtOnlineSKey)
        Me.pnlOnline.Controls.Add(Me.Label1)
        Me.pnlOnline.Controls.Add(Me.btnRegister)
        Me.pnlOnline.Controls.Add(Me.btnExit)
        Me.pnlOnline.Location = New System.Drawing.Point(2, 242)
        Me.pnlOnline.Name = "pnlOnline"
        Me.pnlOnline.Size = New System.Drawing.Size(418, 57)
        Me.pnlOnline.TabIndex = 11
        Me.pnlOnline.Visible = False
        '
        'lblActivationStatusOnline
        '
        Me.lblActivationStatusOnline.AutoSize = True
        Me.lblActivationStatusOnline.ForeColor = System.Drawing.Color.Red
        Me.lblActivationStatusOnline.Location = New System.Drawing.Point(41, 35)
        Me.lblActivationStatusOnline.Name = "lblActivationStatusOnline"
        Me.lblActivationStatusOnline.Size = New System.Drawing.Size(0, 13)
        Me.lblActivationStatusOnline.TabIndex = 21
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel3.Location = New System.Drawing.Point(8, 35)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(27, 13)
        Me.LinkLabel3.TabIndex = 20
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "help"
        '
        'pnlOffline
        '
        Me.pnlOffline.Controls.Add(Me.lblActivationStatusOffline)
        Me.pnlOffline.Controls.Add(Me.LinkLabel2)
        Me.pnlOffline.Controls.Add(Me.BtnCheckKeyManual)
        Me.pnlOffline.Controls.Add(Me.btnMExit)
        Me.pnlOffline.Controls.Add(Me.txtmanualUnlockCode)
        Me.pnlOffline.Controls.Add(Me.Label3)
        Me.pnlOffline.Controls.Add(Me.txtOfflineSkey)
        Me.pnlOffline.Controls.Add(Me.Label2)
        Me.pnlOffline.Location = New System.Drawing.Point(2, 242)
        Me.pnlOffline.Name = "pnlOffline"
        Me.pnlOffline.Size = New System.Drawing.Size(415, 87)
        Me.pnlOffline.TabIndex = 12
        Me.pnlOffline.Visible = False
        '
        'lblActivationStatusOffline
        '
        Me.lblActivationStatusOffline.AutoSize = True
        Me.lblActivationStatusOffline.ForeColor = System.Drawing.Color.Red
        Me.lblActivationStatusOffline.Location = New System.Drawing.Point(41, 64)
        Me.lblActivationStatusOffline.Name = "lblActivationStatusOffline"
        Me.lblActivationStatusOffline.Size = New System.Drawing.Size(0, 13)
        Me.lblActivationStatusOffline.TabIndex = 22
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel2.Location = New System.Drawing.Point(8, 64)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(27, 13)
        Me.LinkLabel2.TabIndex = 19
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "help"
        '
        'BtnCheckKeyManual
        '
        Me.BtnCheckKeyManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCheckKeyManual.Location = New System.Drawing.Point(301, 58)
        Me.BtnCheckKeyManual.Name = "BtnCheckKeyManual"
        Me.BtnCheckKeyManual.Size = New System.Drawing.Size(96, 25)
        Me.BtnCheckKeyManual.TabIndex = 17
        Me.BtnCheckKeyManual.Text = "Register"
        Me.BtnCheckKeyManual.UseVisualStyleBackColor = True
        '
        'btnMExit
        '
        Me.btnMExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMExit.Location = New System.Drawing.Point(199, 58)
        Me.btnMExit.Name = "btnMExit"
        Me.btnMExit.Size = New System.Drawing.Size(96, 25)
        Me.btnMExit.TabIndex = 18
        Me.btnMExit.Text = "Exit"
        Me.btnMExit.UseVisualStyleBackColor = True
        '
        'txtmanualUnlockCode
        '
        Me.txtmanualUnlockCode.Location = New System.Drawing.Point(102, 32)
        Me.txtmanualUnlockCode.Name = "txtmanualUnlockCode"
        Me.txtmanualUnlockCode.Size = New System.Drawing.Size(295, 20)
        Me.txtmanualUnlockCode.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Activation Code:"
        '
        'txtOfflineSkey
        '
        Me.txtOfflineSkey.Location = New System.Drawing.Point(102, 6)
        Me.txtOfflineSkey.Name = "txtOfflineSkey"
        Me.txtOfflineSkey.Size = New System.Drawing.Size(295, 20)
        Me.txtOfflineSkey.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Serial Key:"
        '
        'lblRegisterOffline
        '
        Me.lblRegisterOffline.AutoSize = True
        Me.lblRegisterOffline.BackColor = System.Drawing.Color.Transparent
        Me.lblRegisterOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRegisterOffline.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegisterOffline.Location = New System.Drawing.Point(314, 219)
        Me.lblRegisterOffline.Name = "lblRegisterOffline"
        Me.lblRegisterOffline.Size = New System.Drawing.Size(93, 15)
        Me.lblRegisterOffline.TabIndex = 13
        Me.lblRegisterOffline.Text = "Register Offline"
        '
        'frmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.UnLockMe.My.Resources.Resources.splash
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(418, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlOnline)
        Me.Controls.Add(Me.lblRegisterOffline)
        Me.Controls.Add(Me.lblUnReg)
        Me.Controls.Add(Me.lblRegCompany)
        Me.Controls.Add(Me.lblRegOwner)
        Me.Controls.Add(Me.lblRegistrdTo)
        Me.Controls.Add(Me.lblNotice)
        Me.Controls.Add(Me.lblRegisterOnline)
        Me.Controls.Add(Me.pnlOffline)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlOnline.ResumeLayout(False)
        Me.pnlOnline.PerformLayout()
        Me.pnlOffline.ResumeLayout(False)
        Me.pnlOffline.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRegisterOnline As System.Windows.Forms.Label
    Friend WithEvents txtOnlineSKey As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRegister As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblNotice As System.Windows.Forms.Label
    Friend WithEvents lblRegistrdTo As System.Windows.Forms.Label
    Friend WithEvents lblRegOwner As System.Windows.Forms.Label
    Friend WithEvents lblRegCompany As System.Windows.Forms.Label
    Friend WithEvents lblUnReg As System.Windows.Forms.Label
    Friend WithEvents pnlOnline As System.Windows.Forms.Panel
    Friend WithEvents pnlOffline As System.Windows.Forms.Panel
    Friend WithEvents txtmanualUnlockCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOfflineSkey As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnCheckKeyManual As System.Windows.Forms.Button
    Friend WithEvents btnMExit As System.Windows.Forms.Button
    Friend WithEvents lblRegisterOffline As System.Windows.Forms.Label
    Friend WithEvents lblActivationStatusOnline As System.Windows.Forms.Label
    Friend WithEvents lblActivationStatusOffline As System.Windows.Forms.Label

End Class
