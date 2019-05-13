<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllBorrowed
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
        Me.ListView1 = New MetroFramework.Controls.MetroListView()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(23, 63)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.OwnerDraw = True
        Me.ListView1.Size = New System.Drawing.Size(1080, 443)
        Me.ListView1.Style = MetroFramework.MetroColorStyle.Black
        Me.ListView1.TabIndex = 0
        Me.ListView1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.UseSelectable = True
        '
        'MetroButton1
        '
        Me.MetroButton1.FontSize = MetroFramework.MetroButtonSize.Medium
        Me.MetroButton1.FontWeight = MetroFramework.MetroButtonWeight.Light
        Me.MetroButton1.Location = New System.Drawing.Point(291, 25)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.TabIndex = 9
        Me.MetroButton1.Text = "Exit"
        Me.MetroButton1.UseSelectable = True
        '
        'AllBorrowed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 529)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "AllBorrowed"
        Me.ShowIcon = False
        Me.Style = MetroFramework.MetroColorStyle.Black
        Me.Text = "ALL BORROWED BOOKS"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As MetroFramework.Controls.MetroListView
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
End Class
