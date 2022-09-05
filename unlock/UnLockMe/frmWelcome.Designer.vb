<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWelcome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
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
        Me.lblRegCompany = New System.Windows.Forms.Label
        Me.lblRegOwner = New System.Windows.Forms.Label
        Me.lblRegistrdTo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblRegCompany
        '
        Me.lblRegCompany.AutoSize = True
        Me.lblRegCompany.BackColor = System.Drawing.Color.Transparent
        Me.lblRegCompany.ForeColor = System.Drawing.Color.Black
        Me.lblRegCompany.Location = New System.Drawing.Point(365, 207)
        Me.lblRegCompany.Name = "lblRegCompany"
        Me.lblRegCompany.Size = New System.Drawing.Size(16, 13)
        Me.lblRegCompany.TabIndex = 11
        Me.lblRegCompany.Text = "..."
        Me.lblRegCompany.Visible = False
        '
        'lblRegOwner
        '
        Me.lblRegOwner.AutoSize = True
        Me.lblRegOwner.BackColor = System.Drawing.Color.Transparent
        Me.lblRegOwner.ForeColor = System.Drawing.Color.Black
        Me.lblRegOwner.Location = New System.Drawing.Point(365, 194)
        Me.lblRegOwner.Name = "lblRegOwner"
        Me.lblRegOwner.Size = New System.Drawing.Size(16, 13)
        Me.lblRegOwner.TabIndex = 10
        Me.lblRegOwner.Text = "..."
        Me.lblRegOwner.Visible = False
        '
        'lblRegistrdTo
        '
        Me.lblRegistrdTo.AutoSize = True
        Me.lblRegistrdTo.BackColor = System.Drawing.Color.Transparent
        Me.lblRegistrdTo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrdTo.Location = New System.Drawing.Point(288, 162)
        Me.lblRegistrdTo.Name = "lblRegistrdTo"
        Me.lblRegistrdTo.Size = New System.Drawing.Size(59, 13)
        Me.lblRegistrdTo.TabIndex = 9
        Me.lblRegistrdTo.Text = "RegistrdTo"
        Me.lblRegistrdTo.Visible = False
        '
        'frmWelcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(414, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblRegCompany)
        Me.Controls.Add(Me.lblRegOwner)
        Me.Controls.Add(Me.lblRegistrdTo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWelcome"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRegCompany As System.Windows.Forms.Label
    Friend WithEvents lblRegOwner As System.Windows.Forms.Label
    Friend WithEvents lblRegistrdTo As System.Windows.Forms.Label

End Class
