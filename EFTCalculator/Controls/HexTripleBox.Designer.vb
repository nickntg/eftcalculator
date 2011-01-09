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
        Me.txt1 = New EFTCalculator.HexTextBox()
        Me.txt2 = New EFTCalculator.HexTextBox()
        Me.txt3 = New EFTCalculator.HexTextBox()
        Me.erProv = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.erProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(3, 3)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(155, 21)
        Me.txt1.TabIndex = 0
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(164, 3)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(155, 21)
        Me.txt2.TabIndex = 1
        '
        'txt3
        '
        Me.txt3.Location = New System.Drawing.Point(325, 3)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(155, 21)
        Me.txt3.TabIndex = 2
        '
        'erProv
        '
        Me.erProv.ContainerControl = Me
        '
        'HexTripleBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt3)
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.txt1)
        Me.Name = "HexTripleBox"
        Me.Size = New System.Drawing.Size(512, 28)
        CType(Me.erProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt1 As EFTCalculator.HexTextBox
    Friend WithEvents txt2 As EFTCalculator.HexTextBox
    Friend WithEvents txt3 As EFTCalculator.HexTextBox
    Friend WithEvents erProv As System.Windows.Forms.ErrorProvider

End Class
