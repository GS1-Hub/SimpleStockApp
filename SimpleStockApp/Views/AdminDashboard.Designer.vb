<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminDashboard))
        Me.dtAdmin = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ForeverToggle1 = New ReaLTaiizor.Controls.ForeverToggle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDeleteUser = New System.Windows.Forms.Button()
        CType(Me.dtAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtAdmin
        '
        Me.dtAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtAdmin.Location = New System.Drawing.Point(12, 12)
        Me.dtAdmin.Name = "dtAdmin"
        Me.dtAdmin.Size = New System.Drawing.Size(542, 529)
        Me.dtAdmin.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.ForeverToggle1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnDeleteUser)
        Me.GroupBox1.Location = New System.Drawing.Point(560, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 122)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Settings"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(6, 87)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(215, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save User"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ForeverToggle1
        '
        Me.ForeverToggle1.BackColor = System.Drawing.Color.Transparent
        Me.ForeverToggle1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ForeverToggle1.BaseColorRed = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.ForeverToggle1.BGColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.ForeverToggle1.Checked = False
        Me.ForeverToggle1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ForeverToggle1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ForeverToggle1.Location = New System.Drawing.Point(51, 19)
        Me.ForeverToggle1.Name = "ForeverToggle1"
        Me.ForeverToggle1.Options = ReaLTaiizor.Controls.ForeverToggle._Options.Style1
        Me.ForeverToggle1.Size = New System.Drawing.Size(76, 33)
        Me.ForeverToggle1.TabIndex = 2
        Me.ForeverToggle1.Text = "ForeverToggle1"
        Me.ForeverToggle1.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.ForeverToggle1.ToggleColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Admin:"
        '
        'btnDeleteUser
        '
        Me.btnDeleteUser.Location = New System.Drawing.Point(6, 58)
        Me.btnDeleteUser.Name = "btnDeleteUser"
        Me.btnDeleteUser.Size = New System.Drawing.Size(215, 23)
        Me.btnDeleteUser.TabIndex = 1
        Me.btnDeleteUser.Text = "Delete User"
        Me.btnDeleteUser.UseVisualStyleBackColor = True
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 553)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtAdmin)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdminDashboard"
        Me.Text = "AdminDashboard"
        CType(Me.dtAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtAdmin As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnDeleteUser As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ForeverToggle1 As ReaLTaiizor.Controls.ForeverToggle
    Friend WithEvents btnSave As Button
End Class
