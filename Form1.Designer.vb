<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        btnExit = New Button()
        btnAAuth = New Button()
        btnBAuth = New Button()
        staLabelA = New Label()
        staLabelB = New Label()
        lblTips1 = New Label()
        staLabelCurrentID = New Label()
        btnLaunch = New Button()
        Timer1 = New Timer(components)
        SuspendLayout()
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(664, 0)
        btnExit.Margin = New Padding(2)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(52, 35)
        btnExit.TabIndex = 0
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnAAuth
        ' 
        btnAAuth.Location = New Point(221, 196)
        btnAAuth.Margin = New Padding(2)
        btnAAuth.Name = "btnAAuth"
        btnAAuth.Size = New Size(114, 54)
        btnAAuth.TabIndex = 1
        btnAAuth.Text = "Auth A"
        btnAAuth.UseVisualStyleBackColor = True
        ' 
        ' btnBAuth
        ' 
        btnBAuth.Location = New Point(356, 196)
        btnBAuth.Margin = New Padding(2)
        btnBAuth.Name = "btnBAuth"
        btnBAuth.Size = New Size(114, 54)
        btnBAuth.TabIndex = 2
        btnBAuth.Text = "Auth B"
        btnBAuth.UseVisualStyleBackColor = True
        ' 
        ' staLabelA
        ' 
        staLabelA.AutoSize = True
        staLabelA.Location = New Point(252, 157)
        staLabelA.Margin = New Padding(2, 0, 2, 0)
        staLabelA.Name = "staLabelA"
        staLabelA.Size = New Size(60, 17)
        staLabelA.TabIndex = 3
        staLabelA.Text = "Not Pass"
        ' 
        ' staLabelB
        ' 
        staLabelB.AutoSize = True
        staLabelB.Location = New Point(388, 157)
        staLabelB.Margin = New Padding(2, 0, 2, 0)
        staLabelB.Name = "staLabelB"
        staLabelB.Size = New Size(60, 17)
        staLabelB.TabIndex = 4
        staLabelB.Text = "Not Pass"
        ' 
        ' lblTips1
        ' 
        lblTips1.AutoSize = True
        lblTips1.Location = New Point(11, 429)
        lblTips1.Margin = New Padding(2, 0, 2, 0)
        lblTips1.Name = "lblTips1"
        lblTips1.Size = New Size(71, 17)
        lblTips1.TabIndex = 5
        lblTips1.Text = "Current ID:"
        lblTips1.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' staLabelCurrentID
        ' 
        staLabelCurrentID.AutoSize = True
        staLabelCurrentID.Location = New Point(86, 429)
        staLabelCurrentID.Margin = New Padding(2, 0, 2, 0)
        staLabelCurrentID.Name = "staLabelCurrentID"
        staLabelCurrentID.Size = New Size(44, 17)
        staLabelCurrentID.TabIndex = 6
        staLabelCurrentID.Text = "Ready"
        ' 
        ' btnLaunch
        ' 
        btnLaunch.Enabled = False
        btnLaunch.Location = New Point(590, 390)
        btnLaunch.Margin = New Padding(2)
        btnLaunch.Name = "btnLaunch"
        btnLaunch.Size = New Size(114, 54)
        btnLaunch.TabIndex = 7
        btnLaunch.Text = "Launch"
        btnLaunch.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(715, 455)
        Controls.Add(btnLaunch)
        Controls.Add(staLabelCurrentID)
        Controls.Add(lblTips1)
        Controls.Add(staLabelB)
        Controls.Add(staLabelA)
        Controls.Add(btnBAuth)
        Controls.Add(btnAAuth)
        Controls.Add(btnExit)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        ImeMode = ImeMode.Disable
        Margin = New Padding(2)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Authencation Form"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnAAuth As Button
    Friend WithEvents btnBAuth As Button
    Friend WithEvents staLabelA As Label
    Friend WithEvents staLabelB As Label
    Friend WithEvents lblTips1 As Label
    Friend WithEvents staLabelCurrentID As Label
    Friend WithEvents btnLaunch As Button
    Friend WithEvents Timer1 As Timer

End Class
