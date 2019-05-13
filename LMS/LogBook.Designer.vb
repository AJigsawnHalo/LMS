<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogBook
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
        Me.MetroButton4 = New MetroFramework.Controls.MetroButton()
        Me.MetroTabControl1 = New MetroFramework.Controls.MetroTabControl()
        Me.MetroTabPage1 = New MetroFramework.Controls.MetroTabPage()
        Me.ListView2 = New MetroFramework.Controls.MetroListView()
        Me.MetroDateTime1 = New MetroFramework.Controls.MetroDateTime()
        Me.MetroTabControl1.SuspendLayout()
        Me.MetroTabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroButton4
        '
        Me.MetroButton4.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.MetroButton4.FontWeight = MetroFramework.MetroButtonWeight.Light
        Me.MetroButton4.Location = New System.Drawing.Point(130, 26)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(93, 23)
        Me.MetroButton4.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroButton4.TabIndex = 86
        Me.MetroButton4.Text = "Exit"
        Me.MetroButton4.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton4.UseSelectable = True
        '
        'MetroTabControl1
        '
        Me.MetroTabControl1.Controls.Add(Me.MetroTabPage1)
        Me.MetroTabControl1.Location = New System.Drawing.Point(60, 65)
        Me.MetroTabControl1.Name = "MetroTabControl1"
        Me.MetroTabControl1.SelectedIndex = 0
        Me.MetroTabControl1.Size = New System.Drawing.Size(655, 502)
        Me.MetroTabControl1.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroTabControl1.TabIndex = 90
        Me.MetroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTabControl1.UseSelectable = True
        '
        'MetroTabPage1
        '
        Me.MetroTabPage1.Controls.Add(Me.ListView2)
        Me.MetroTabPage1.HorizontalScrollbarBarColor = True
        Me.MetroTabPage1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroTabPage1.HorizontalScrollbarSize = 10
        Me.MetroTabPage1.Location = New System.Drawing.Point(4, 38)
        Me.MetroTabPage1.Name = "MetroTabPage1"
        Me.MetroTabPage1.Size = New System.Drawing.Size(647, 460)
        Me.MetroTabPage1.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroTabPage1.TabIndex = 0
        Me.MetroTabPage1.Text = "Records"
        Me.MetroTabPage1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTabPage1.VerticalScrollbarBarColor = True
        Me.MetroTabPage1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroTabPage1.VerticalScrollbarSize = 10
        '
        'ListView2
        '
        Me.ListView2.AutoArrange = False
        Me.ListView2.BackColor = System.Drawing.SystemColors.MenuText
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ListView2.ForeColor = System.Drawing.SystemColors.InfoText
        Me.ListView2.FullRowSelect = True
        Me.ListView2.HideSelection = False
        Me.ListView2.LabelWrap = False
        Me.ListView2.Location = New System.Drawing.Point(29, 12)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.OwnerDraw = True
        Me.ListView2.Size = New System.Drawing.Size(604, 407)
        Me.ListView2.Style = MetroFramework.MetroColorStyle.Black
        Me.ListView2.TabIndex = 92
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.UseSelectable = True
        '
        'MetroDateTime1
        '
        Me.MetroDateTime1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetroDateTime1.Location = New System.Drawing.Point(532, 30)
        Me.MetroDateTime1.MinimumSize = New System.Drawing.Size(0, 29)
        Me.MetroDateTime1.Name = "MetroDateTime1"
        Me.MetroDateTime1.Size = New System.Drawing.Size(179, 29)
        Me.MetroDateTime1.Style = MetroFramework.MetroColorStyle.Black
        Me.MetroDateTime1.TabIndex = 91
        Me.MetroDateTime1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'LogBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 615)
        Me.Controls.Add(Me.MetroDateTime1)
        Me.Controls.Add(Me.MetroTabControl1)
        Me.Controls.Add(Me.MetroButton4)
        Me.Name = "LogBook"
        Me.Style = MetroFramework.MetroColorStyle.Black
        Me.Text = "Log Book"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTabControl1.ResumeLayout(False)
        Me.MetroTabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MetroButton4 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroTabControl1 As MetroFramework.Controls.MetroTabControl
    Friend WithEvents MetroTabPage1 As MetroFramework.Controls.MetroTabPage
    Friend WithEvents ListView2 As MetroFramework.Controls.MetroListView
    Friend WithEvents MetroDateTime1 As MetroFramework.Controls.MetroDateTime
End Class
