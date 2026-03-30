<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CompanyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Stock = New System.Windows.Forms.ToolStripMenuItem()
        Me.Clients = New System.Windows.Forms.ToolStripMenuItem()
        Me.Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompanyToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CompanyToolStripMenuItem
        '
        Me.CompanyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Stock, Me.Clients, Me.Settings})
        Me.CompanyToolStripMenuItem.Image = Global.SimpleStockApp.My.Resources.Resources.logo
        Me.CompanyToolStripMenuItem.Name = "CompanyToolStripMenuItem"
        Me.CompanyToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.CompanyToolStripMenuItem.Text = "Company"
        '
        'Stock
        '
        Me.Stock.Name = "Stock"
        Me.Stock.Size = New System.Drawing.Size(128, 22)
        Me.Stock.Text = "📦Stock"
        '
        'Clients
        '
        Me.Clients.Name = "Clients"
        Me.Clients.Size = New System.Drawing.Size(128, 22)
        Me.Clients.Text = "👤Clients"
        '
        'Settings
        '
        Me.Settings.Name = "Settings"
        Me.Settings.Size = New System.Drawing.Size(128, 22)
        Me.Settings.Text = "⚙️Settings"
        '
        'pnlContent
        '
        Me.pnlContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.Location = New System.Drawing.Point(12, 27)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(1160, 622)
        Me.pnlContent.TabIndex = 1
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 661)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CompanyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Stock As ToolStripMenuItem
    Friend WithEvents Clients As ToolStripMenuItem
    Friend WithEvents Settings As ToolStripMenuItem
    Friend WithEvents pnlContent As Panel
End Class
