<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntriesMDI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EntriesMDI))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CANCELTICKETSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPORTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BOOKEDTICKETSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CANCELLEDTICKETSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 646)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1377, 25)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(49, 20)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'MenuStrip
        '
        Me.MenuStrip.AutoSize = False
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ViewMenu, Me.ToolsMenu, Me.HelpMenu, Me.CANCELTICKETSToolStripMenuItem, Me.REPORTToolStripMenuItem, Me.LogOutToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1377, 78)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(167, 74)
        Me.FileMenu.Text = "PLACE DETAILS"
        '
        'ViewMenu
        '
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(214, 74)
        Me.ViewMenu.Text = "CUSTOMER DETAILS"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(175, 74)
        Me.ToolsMenu.Text = "FLIGHT DETAILS"
        '
        'HelpMenu
        '
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(188, 74)
        Me.HelpMenu.Text = "TICKET BOOKING"
        '
        'CANCELTICKETSToolStripMenuItem
        '
        Me.CANCELTICKETSToolStripMenuItem.Name = "CANCELTICKETSToolStripMenuItem"
        Me.CANCELTICKETSToolStripMenuItem.Size = New System.Drawing.Size(182, 74)
        Me.CANCELTICKETSToolStripMenuItem.Text = "CANCEL TICKETS"
        '
        'REPORTToolStripMenuItem
        '
        Me.REPORTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BOOKEDTICKETSToolStripMenuItem, Me.CANCELLEDTICKETSToolStripMenuItem})
        Me.REPORTToolStripMenuItem.Name = "REPORTToolStripMenuItem"
        Me.REPORTToolStripMenuItem.Size = New System.Drawing.Size(100, 74)
        Me.REPORTToolStripMenuItem.Text = "REPORT"
        '
        'BOOKEDTICKETSToolStripMenuItem
        '
        Me.BOOKEDTICKETSToolStripMenuItem.Name = "BOOKEDTICKETSToolStripMenuItem"
        Me.BOOKEDTICKETSToolStripMenuItem.Size = New System.Drawing.Size(278, 32)
        Me.BOOKEDTICKETSToolStripMenuItem.Text = "BOOKED TICKETS"
        '
        'CANCELLEDTICKETSToolStripMenuItem
        '
        Me.CANCELLEDTICKETSToolStripMenuItem.Name = "CANCELLEDTICKETSToolStripMenuItem"
        Me.CANCELLEDTICKETSToolStripMenuItem.Size = New System.Drawing.Size(278, 32)
        Me.CANCELLEDTICKETSToolStripMenuItem.Text = "CANCELLED TICKETS"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(110, 74)
        Me.LogOutToolStripMenuItem.Text = "LOG OUT"
        '
        'EntriesMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1377, 671)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "EntriesMDI"
        Me.Text = "EntriesMDI"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CANCELTICKETSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents REPORTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BOOKEDTICKETSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CANCELLEDTICKETSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
