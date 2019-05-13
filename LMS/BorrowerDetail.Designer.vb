<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BorrowerDetail
    'Inherits System.Windows.Forms.Form
    Inherits MetroFramework.Forms.MetroForm

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
        Me.components = New System.ComponentModel.Container()
        Me.TextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.Button1 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroListView1 = New MetroFramework.Controls.MetroListView()
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TextBox1
        '
        '
        '
        '
        Me.TextBox1.CustomButton.Image = Nothing
        Me.TextBox1.CustomButton.Location = New System.Drawing.Point(91, 1)
        Me.TextBox1.CustomButton.Name = ""
        Me.TextBox1.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.TextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.TextBox1.CustomButton.TabIndex = 1
        Me.TextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.TextBox1.CustomButton.UseSelectable = True
        Me.TextBox1.CustomButton.Visible = False
        Me.TextBox1.Lines = New String(-1) {}
        Me.TextBox1.Location = New System.Drawing.Point(609, 47)
        Me.TextBox1.MaxLength = 32767
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox1.SelectedText = ""
        Me.TextBox1.SelectionLength = 0
        Me.TextBox1.SelectionStart = 0
        Me.TextBox1.ShortcutsEnabled = True
        Me.TextBox1.Size = New System.Drawing.Size(113, 23)
        Me.TextBox1.Style = MetroFramework.MetroColorStyle.Black
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.TextBox1.UseSelectable = True
        Me.TextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TextBox1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Button1
        '
        Me.Button1.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.Button1.FontWeight = MetroFramework.MetroButtonWeight.Light
        Me.Button1.Location = New System.Drawing.Point(728, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.Style = MetroFramework.MetroColorStyle.Black
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Search"
        Me.Button1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.Button1.UseSelectable = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(562, 51)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(36, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroLabel1.TabIndex = 7
        Me.MetroLabel1.Text = "RFID"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroButton1
        '
        Me.MetroButton1.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.MetroButton1.FontWeight = MetroFramework.MetroButtonWeight.Light
        Me.MetroButton1.Location = New System.Drawing.Point(237, 24)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroButton1.TabIndex = 8
        Me.MetroButton1.Text = "Exit"
        Me.MetroButton1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton1.UseSelectable = True
        '
        'MetroListView1
        '
        Me.MetroListView1.AutoArrange = False
        Me.MetroListView1.BackColor = System.Drawing.SystemColors.MenuText
        Me.MetroListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MetroListView1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.MetroListView1.ForeColor = System.Drawing.SystemColors.InfoText
        Me.MetroListView1.FullRowSelect = True
        Me.MetroListView1.HideSelection = False
        Me.MetroListView1.LabelWrap = False
        Me.MetroListView1.Location = New System.Drawing.Point(73, 93)
        Me.MetroListView1.MaximumSize = New System.Drawing.Size(730, 352)
        Me.MetroListView1.MinimumSize = New System.Drawing.Size(730, 352)
        Me.MetroListView1.MultiSelect = False
        Me.MetroListView1.Name = "MetroListView1"
        Me.MetroListView1.OwnerDraw = True
        Me.MetroListView1.Size = New System.Drawing.Size(730, 352)
        Me.MetroListView1.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroListView1.TabIndex = 94
        Me.MetroListView1.UseCompatibleStateImageBehavior = False
        Me.MetroListView1.UseSelectable = True
        '
        'Timer2
        '
        '
        'BorrowerDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 484)
        Me.Controls.Add(Me.MetroListView1)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "BorrowerDetail"
        Me.ShowIcon = False
        Me.Style = MetroFramework.MetroColorStyle.Black
        Me.Text = "BORROWER DETAIL"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroListView1 As MetroFramework.Controls.MetroListView
    Friend WithEvents SerialPort2 As System.IO.Ports.SerialPort
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
