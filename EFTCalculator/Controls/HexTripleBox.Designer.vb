<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HexTripleBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HexTripleBox))
        Me.erProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdRandomKey = New System.Windows.Forms.Button()
        Me.btnMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SinglelengthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoublelengthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TriplelengthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdLoadKey = New System.Windows.Forms.Button()
        Me.keysMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.txt3 = New EFTCalculator.HexTextBox()
        Me.txt2 = New EFTCalculator.HexTextBox()
        Me.txt1 = New EFTCalculator.HexTextBox()
        CType(Me.erProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btnMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'erProv
        '
        Me.erProv.ContainerControl = Me
        '
        'cmdRandomKey
        '
        Me.cmdRandomKey.BackgroundImage = CType(resources.GetObject("cmdRandomKey.BackgroundImage"), System.Drawing.Image)
        Me.cmdRandomKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRandomKey.ContextMenuStrip = Me.btnMenu
        Me.cmdRandomKey.Location = New System.Drawing.Point(501, 1)
        Me.cmdRandomKey.Name = "cmdRandomKey"
        Me.cmdRandomKey.Size = New System.Drawing.Size(29, 23)
        Me.cmdRandomKey.TabIndex = 3
        Me.cmdRandomKey.UseVisualStyleBackColor = True
        '
        'btnMenu
        '
        Me.btnMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SinglelengthToolStripMenuItem, Me.DoublelengthToolStripMenuItem, Me.TriplelengthToolStripMenuItem})
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(142, 70)
        '
        'SinglelengthToolStripMenuItem
        '
        Me.SinglelengthToolStripMenuItem.Name = "SinglelengthToolStripMenuItem"
        Me.SinglelengthToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SinglelengthToolStripMenuItem.Text = "Single-length"
        '
        'DoublelengthToolStripMenuItem
        '
        Me.DoublelengthToolStripMenuItem.Name = "DoublelengthToolStripMenuItem"
        Me.DoublelengthToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DoublelengthToolStripMenuItem.Text = "Double-length"
        '
        'TriplelengthToolStripMenuItem
        '
        Me.TriplelengthToolStripMenuItem.Name = "TriplelengthToolStripMenuItem"
        Me.TriplelengthToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.TriplelengthToolStripMenuItem.Text = "Triple-length"
        '
        'cmdLoadKey
        '
        Me.cmdLoadKey.BackgroundImage = CType(resources.GetObject("cmdLoadKey.BackgroundImage"), System.Drawing.Image)
        Me.cmdLoadKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdLoadKey.ContextMenuStrip = Me.keysMenuStrip
        Me.cmdLoadKey.Location = New System.Drawing.Point(536, 1)
        Me.cmdLoadKey.Name = "cmdLoadKey"
        Me.cmdLoadKey.Size = New System.Drawing.Size(29, 23)
        Me.cmdLoadKey.TabIndex = 5
        Me.cmdLoadKey.UseVisualStyleBackColor = True
        '
        'keysMenuStrip
        '
        Me.keysMenuStrip.Name = "keysMenuStrip"
        Me.keysMenuStrip.Size = New System.Drawing.Size(61, 4)
        '
        'txt3
        '
        Me.txt3.AcceptHex = True
        Me.txt3.Location = New System.Drawing.Point(324, 3)
        Me.txt3.MaxLength = 16
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(155, 21)
        Me.txt3.TabIndex = 2
        Me.txt3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt2
        '
        Me.txt2.AcceptHex = True
        Me.txt2.Location = New System.Drawing.Point(163, 3)
        Me.txt2.MaxLength = 16
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(155, 21)
        Me.txt2.TabIndex = 1
        Me.txt2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt1
        '
        Me.txt1.AcceptHex = True
        Me.txt1.Location = New System.Drawing.Point(0, 3)
        Me.txt1.MaxLength = 16
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(155, 21)
        Me.txt1.TabIndex = 0
        Me.txt1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HexTripleBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt3)
        Me.Controls.Add(Me.cmdLoadKey)
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.cmdRandomKey)
        Me.Controls.Add(Me.txt1)
        Me.Name = "HexTripleBox"
        Me.Size = New System.Drawing.Size(571, 28)
        CType(Me.erProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btnMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt1 As EFTCalculator.HexTextBox
    Friend WithEvents txt2 As EFTCalculator.HexTextBox
    Friend WithEvents txt3 As EFTCalculator.HexTextBox
    Friend WithEvents erProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdRandomKey As System.Windows.Forms.Button
    Friend WithEvents btnMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SinglelengthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DoublelengthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TriplelengthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdLoadKey As System.Windows.Forms.Button
    Friend WithEvents keysMenuStrip As System.Windows.Forms.ContextMenuStrip

End Class
