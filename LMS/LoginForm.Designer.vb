<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    'Inherits System.Windows.Forms.Form
    Inherits MetroFramework.Forms.MetroForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.BtnLogin2M = New MetroFramework.Controls.MetroButton()
        Me.BtnClearM = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.PassWordTextBox2M = New MetroFramework.Controls.MetroTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.UserNameTextBox2M = New MetroFramework.Controls.MetroTextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnLogin2M
        '
        Me.BtnLogin2M.Location = New System.Drawing.Point(318, 311)
        Me.BtnLogin2M.Name = "BtnLogin2M"
        Me.BtnLogin2M.Size = New System.Drawing.Size(114, 29)
        Me.BtnLogin2M.Style = MetroFramework.MetroColorStyle.Red
        Me.BtnLogin2M.TabIndex = 32
        Me.BtnLogin2M.TabStop = False
        Me.BtnLogin2M.Text = "Login"
        Me.BtnLogin2M.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.BtnLogin2M.UseSelectable = True
        '
        'BtnClearM
        '
        Me.BtnClearM.Location = New System.Drawing.Point(195, 311)
        Me.BtnClearM.Name = "BtnClearM"
        Me.BtnClearM.Size = New System.Drawing.Size(117, 29)
        Me.BtnClearM.Style = MetroFramework.MetroColorStyle.Blue
        Me.BtnClearM.TabIndex = 31
        Me.BtnClearM.TabStop = False
        Me.BtnClearM.Text = "Back"
        Me.BtnClearM.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.BtnClearM.UseSelectable = True
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(206, 123)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(67, 19)
        Me.MetroLabel4.TabIndex = 30
        Me.MetroLabel4.Text = "Password "
        Me.MetroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(201, 104)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(72, 19)
        Me.MetroLabel2.TabIndex = 29
        Me.MetroLabel2.Text = "Username "
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'PassWordTextBox2M
        '
        '
        '
        '
        Me.PassWordTextBox2M.CustomButton.Image = Nothing
        Me.PassWordTextBox2M.CustomButton.Location = New System.Drawing.Point(213, 1)
        Me.PassWordTextBox2M.CustomButton.Name = ""
        Me.PassWordTextBox2M.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.PassWordTextBox2M.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.PassWordTextBox2M.CustomButton.TabIndex = 1
        Me.PassWordTextBox2M.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.PassWordTextBox2M.CustomButton.UseSelectable = True
        Me.PassWordTextBox2M.CustomButton.Visible = False
        Me.PassWordTextBox2M.Lines = New String(-1) {}
        Me.PassWordTextBox2M.Location = New System.Drawing.Point(195, 271)
        Me.PassWordTextBox2M.MaxLength = 32767
        Me.PassWordTextBox2M.Name = "PassWordTextBox2M"
        Me.PassWordTextBox2M.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWordTextBox2M.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.PassWordTextBox2M.SelectedText = ""
        Me.PassWordTextBox2M.SelectionLength = 0
        Me.PassWordTextBox2M.SelectionStart = 0
        Me.PassWordTextBox2M.ShortcutsEnabled = True
        Me.PassWordTextBox2M.Size = New System.Drawing.Size(237, 25)
        Me.PassWordTextBox2M.Style = MetroFramework.MetroColorStyle.White
        Me.PassWordTextBox2M.TabIndex = 28
        Me.PassWordTextBox2M.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.PassWordTextBox2M.UseSelectable = True
        Me.PassWordTextBox2M.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.PassWordTextBox2M.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(138, 63)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(312, 127)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(154, 227)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(155, 269)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 29)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 35
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(0, 85)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(607, 385)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 36
        Me.PictureBox4.TabStop = False
        '
        'UserNameTextBox2M
        '
        '
        '
        '
        Me.UserNameTextBox2M.CustomButton.Image = Nothing
        Me.UserNameTextBox2M.CustomButton.Location = New System.Drawing.Point(213, 1)
        Me.UserNameTextBox2M.CustomButton.Name = ""
        Me.UserNameTextBox2M.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.UserNameTextBox2M.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.UserNameTextBox2M.CustomButton.TabIndex = 1
        Me.UserNameTextBox2M.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.UserNameTextBox2M.CustomButton.UseSelectable = True
        Me.UserNameTextBox2M.CustomButton.Visible = False
        Me.UserNameTextBox2M.Lines = New String(-1) {}
        Me.UserNameTextBox2M.Location = New System.Drawing.Point(195, 227)
        Me.UserNameTextBox2M.MaxLength = 32767
        Me.UserNameTextBox2M.Name = "UserNameTextBox2M"
        Me.UserNameTextBox2M.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.UserNameTextBox2M.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.UserNameTextBox2M.SelectedText = ""
        Me.UserNameTextBox2M.SelectionLength = 0
        Me.UserNameTextBox2M.SelectionStart = 0
        Me.UserNameTextBox2M.ShortcutsEnabled = True
        Me.UserNameTextBox2M.Size = New System.Drawing.Size(237, 25)
        Me.UserNameTextBox2M.Style = MetroFramework.MetroColorStyle.White
        Me.UserNameTextBox2M.TabIndex = 37
        Me.UserNameTextBox2M.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.UserNameTextBox2M.UseSelectable = True
        Me.UserNameTextBox2M.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.UserNameTextBox2M.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 400)
        Me.Controls.Add(Me.UserNameTextBox2M)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnLogin2M)
        Me.Controls.Add(Me.BtnClearM)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.PassWordTextBox2M)
        Me.Controls.Add(Me.PictureBox4)
        Me.Name = "LoginForm"
        Me.Style = MetroFramework.MetroColorStyle.Black
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnLogin2M As MetroFramework.Controls.MetroButton
    Friend WithEvents BtnClearM As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents PassWordTextBox2M As MetroFramework.Controls.MetroTextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents UserNameTextBox2M As MetroFramework.Controls.MetroTextBox
End Class
