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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDESParity = New System.Windows.Forms.Label()
        Me.lblDESKCV = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdAND = New System.Windows.Forms.Button()
        Me.cmdOR = New System.Windows.Forms.Button()
        Me.cmdXOR = New System.Windows.Forms.Button()
        Me.cmdDecrypt = New System.Windows.Forms.Button()
        Me.cmdEncrypt = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.DESResult = New EFTCalculator.HexTripleBox()
        Me.DESHexKey = New EFTCalculator.HexTripleBox()
        Me.DESHexData = New EFTCalculator.HexTripleBox()
        Me.cmdEvenParity = New System.Windows.Forms.Button()
        Me.cmdOddParity = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(630, 418)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdEvenParity)
        Me.TabPage1.Controls.Add(Me.cmdOddParity)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.lblDESParity)
        Me.TabPage1.Controls.Add(Me.lblDESKCV)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.DESResult)
        Me.TabPage1.Controls.Add(Me.cmdAND)
        Me.TabPage1.Controls.Add(Me.cmdOR)
        Me.TabPage1.Controls.Add(Me.cmdXOR)
        Me.TabPage1.Controls.Add(Me.cmdDecrypt)
        Me.TabPage1.Controls.Add(Me.cmdEncrypt)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.DESHexKey)
        Me.TabPage1.Controls.Add(Me.DESHexData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(622, 392)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DES/3DES"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(7, 134)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 10)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'lblDESParity
        '
        Me.lblDESParity.AutoSize = True
        Me.lblDESParity.Location = New System.Drawing.Point(489, 71)
        Me.lblDESParity.Name = "lblDESParity"
        Me.lblDESParity.Size = New System.Drawing.Size(67, 13)
        Me.lblDESParity.TabIndex = 13
        Me.lblDESParity.Text = "Parity: None"
        '
        'lblDESKCV
        '
        Me.lblDESKCV.Location = New System.Drawing.Point(301, 71)
        Me.lblDESKCV.Name = "lblDESKCV"
        Me.lblDESKCV.Size = New System.Drawing.Size(182, 13)
        Me.lblDESKCV.TabIndex = 12
        Me.lblDESKCV.Text = "Check Value: Not Calculated"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Result:"
        '
        'cmdAND
        '
        Me.cmdAND.Location = New System.Drawing.Point(463, 98)
        Me.cmdAND.Name = "cmdAND"
        Me.cmdAND.Size = New System.Drawing.Size(93, 30)
        Me.cmdAND.TabIndex = 9
        Me.cmdAND.Text = "AND"
        Me.cmdAND.UseVisualStyleBackColor = True
        '
        'cmdOR
        '
        Me.cmdOR.Location = New System.Drawing.Point(364, 98)
        Me.cmdOR.Name = "cmdOR"
        Me.cmdOR.Size = New System.Drawing.Size(93, 30)
        Me.cmdOR.TabIndex = 8
        Me.cmdOR.Text = "OR"
        Me.cmdOR.UseVisualStyleBackColor = True
        '
        'cmdXOR
        '
        Me.cmdXOR.Location = New System.Drawing.Point(265, 98)
        Me.cmdXOR.Name = "cmdXOR"
        Me.cmdXOR.Size = New System.Drawing.Size(93, 30)
        Me.cmdXOR.TabIndex = 7
        Me.cmdXOR.Text = "XOR"
        Me.cmdXOR.UseVisualStyleBackColor = True
        '
        'cmdDecrypt
        '
        Me.cmdDecrypt.Location = New System.Drawing.Point(166, 98)
        Me.cmdDecrypt.Name = "cmdDecrypt"
        Me.cmdDecrypt.Size = New System.Drawing.Size(93, 30)
        Me.cmdDecrypt.TabIndex = 6
        Me.cmdDecrypt.Text = "Decrypt"
        Me.cmdDecrypt.UseVisualStyleBackColor = True
        '
        'cmdEncrypt
        '
        Me.cmdEncrypt.Location = New System.Drawing.Point(67, 98)
        Me.cmdEncrypt.Name = "cmdEncrypt"
        Me.cmdEncrypt.Size = New System.Drawing.Size(93, 30)
        Me.cmdEncrypt.TabIndex = 5
        Me.cmdEncrypt.Text = "Encrypt"
        Me.cmdEncrypt.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Key:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Data:"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(683, 392)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PIN Block"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(683, 392)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "CVV"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(683, 392)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Visa PVV"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(683, 392)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Keys"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'DESResult
        '
        Me.DESResult.Location = New System.Drawing.Point(79, 150)
        Me.DESResult.Name = "DESResult"
        Me.DESResult.Size = New System.Drawing.Size(512, 28)
        Me.DESResult.TabIndex = 10
        '
        'DESHexKey
        '
        Me.DESHexKey.Location = New System.Drawing.Point(75, 40)
        Me.DESHexKey.Name = "DESHexKey"
        Me.DESHexKey.Size = New System.Drawing.Size(512, 28)
        Me.DESHexKey.TabIndex = 2
        '
        'DESHexData
        '
        Me.DESHexData.Location = New System.Drawing.Point(75, 6)
        Me.DESHexData.Name = "DESHexData"
        Me.DESHexData.Size = New System.Drawing.Size(512, 28)
        Me.DESHexData.TabIndex = 1
        '
        'cmdEvenParity
        '
        Me.cmdEvenParity.Location = New System.Drawing.Point(314, 184)
        Me.cmdEvenParity.Name = "cmdEvenParity"
        Me.cmdEvenParity.Size = New System.Drawing.Size(93, 30)
        Me.cmdEvenParity.TabIndex = 16
        Me.cmdEvenParity.Text = "Even Parity"
        Me.cmdEvenParity.UseVisualStyleBackColor = True
        '
        'cmdOddParity
        '
        Me.cmdOddParity.Location = New System.Drawing.Point(215, 184)
        Me.cmdOddParity.Name = "cmdOddParity"
        Me.cmdOddParity.Size = New System.Drawing.Size(93, 30)
        Me.cmdOddParity.TabIndex = 15
        Me.cmdOddParity.Text = "Odd Parity"
        Me.cmdOddParity.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 418)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EFT Calculator"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents DESHexData As EFTCalculator.HexTripleBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DESHexKey As EFTCalculator.HexTripleBox
    Friend WithEvents cmdEncrypt As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DESResult As EFTCalculator.HexTripleBox
    Friend WithEvents cmdAND As System.Windows.Forms.Button
    Friend WithEvents cmdOR As System.Windows.Forms.Button
    Friend WithEvents cmdXOR As System.Windows.Forms.Button
    Friend WithEvents cmdDecrypt As System.Windows.Forms.Button
    Friend WithEvents lblDESParity As System.Windows.Forms.Label
    Friend WithEvents lblDESKCV As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEvenParity As System.Windows.Forms.Button
    Friend WithEvents cmdOddParity As System.Windows.Forms.Button
End Class
