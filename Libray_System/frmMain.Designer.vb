<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.จดการขอมลToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการขอมลผใชToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการขอมลหนงสอToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการขอมลบรรณารกษToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.จดการขอมลสมาชกToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.รายการหนงสอToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.บนทกการยมToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportสมาชกทยงไมคนหนงสอToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.จดการขอมลToolStripMenuItem, Me.รายการหนงสอToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(987, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'จดการขอมลToolStripMenuItem
        '
        Me.จดการขอมลToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.จดการขอมลผใชToolStripMenuItem, Me.จดการขอมลหนงสอToolStripMenuItem, Me.จดการขอมลบรรณารกษToolStripMenuItem, Me.จดการขอมลสมาชกToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.จดการขอมลToolStripMenuItem.Name = "จดการขอมลToolStripMenuItem"
        Me.จดการขอมลToolStripMenuItem.Size = New System.Drawing.Size(95, 24)
        Me.จดการขอมลToolStripMenuItem.Text = "จัดการข้อมูล"
        '
        'จดการขอมลผใชToolStripMenuItem
        '
        Me.จดการขอมลผใชToolStripMenuItem.Name = "จดการขอมลผใชToolStripMenuItem"
        Me.จดการขอมลผใชToolStripMenuItem.Size = New System.Drawing.Size(268, 26)
        Me.จดการขอมลผใชToolStripMenuItem.Text = "จัดการข้อมูลผู้ใช้งาน  Ctrl+N"
        '
        'จดการขอมลหนงสอToolStripMenuItem
        '
        Me.จดการขอมลหนงสอToolStripMenuItem.Name = "จดการขอมลหนงสอToolStripMenuItem"
        Me.จดการขอมลหนงสอToolStripMenuItem.Size = New System.Drawing.Size(268, 26)
        Me.จดการขอมลหนงสอToolStripMenuItem.Text = "จัดการข้อมูลหนังสือ    Ctrl+O"
        '
        'จดการขอมลบรรณารกษToolStripMenuItem
        '
        Me.จดการขอมลบรรณารกษToolStripMenuItem.Name = "จดการขอมลบรรณารกษToolStripMenuItem"
        Me.จดการขอมลบรรณารกษToolStripMenuItem.Size = New System.Drawing.Size(268, 26)
        Me.จดการขอมลบรรณารกษToolStripMenuItem.Text = "จัดการข้อมูลบรรณารักษ์"
        Me.จดการขอมลบรรณารกษToolStripMenuItem.Visible = False
        '
        'จดการขอมลสมาชกToolStripMenuItem
        '
        Me.จดการขอมลสมาชกToolStripMenuItem.Name = "จดการขอมลสมาชกToolStripMenuItem"
        Me.จดการขอมลสมาชกToolStripMenuItem.Size = New System.Drawing.Size(268, 26)
        Me.จดการขอมลสมาชกToolStripMenuItem.Text = "จัดการข้อมูลสมาชิก    Ctrl+S"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(268, 26)
        Me.ExitToolStripMenuItem.Text = "Exit                           Ctrl+Q"
        '
        'รายการหนงสอToolStripMenuItem
        '
        Me.รายการหนงสอToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.บนทกการยมToolStripMenuItem, Me.ReportสมาชกทยงไมคนหนงสอToolStripMenuItem})
        Me.รายการหนงสอToolStripMenuItem.Name = "รายการหนงสอToolStripMenuItem"
        Me.รายการหนงสอToolStripMenuItem.Size = New System.Drawing.Size(52, 24)
        Me.รายการหนงสอToolStripMenuItem.Text = "ระบบ"
        '
        'บนทกการยมToolStripMenuItem
        '
        Me.บนทกการยมToolStripMenuItem.Name = "บนทกการยมToolStripMenuItem"
        Me.บนทกการยมToolStripMenuItem.Size = New System.Drawing.Size(275, 26)
        Me.บนทกการยมToolStripMenuItem.Text = "บันทึกการยืม-คืนหนังสือ"
        '
        'ReportสมาชกทยงไมคนหนงสอToolStripMenuItem
        '
        Me.ReportสมาชกทยงไมคนหนงสอToolStripMenuItem.Name = "ReportสมาชกทยงไมคนหนงสอToolStripMenuItem"
        Me.ReportสมาชกทยงไมคนหนงสอToolStripMenuItem.Size = New System.Drawing.Size(275, 26)
        Me.ReportสมาชกทยงไมคนหนงสอToolStripMenuItem.Text = "Report สมาชิกที่ยังไม่คืนหนังสือ"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        Me.HelpToolStripMenuItem.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 448)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(987, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Libray_System.My.Resources.Resources.images__3_1
        Me.ClientSize = New System.Drawing.Size(987, 470)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ระบบยืม-คืนหนังสือห้องสมุด"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents จดการขอมลToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents จดการขอมลผใชToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents จดการขอมลหนงสอToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents จดการขอมลสมาชกToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents รายการหนงสอToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents บนทกการยมToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents จดการขอมลบรรณารกษToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportสมาชกทยงไมคนหนงสอToolStripMenuItem As ToolStripMenuItem
End Class
