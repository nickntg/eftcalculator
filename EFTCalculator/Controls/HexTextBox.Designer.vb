<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HexTextBox
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
        Me.txt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txt
        '
        Me.txt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txt.Location = New System.Drawing.Point(0, 0)
        Me.txt.MaxLength = 16
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(155, 22)
        Me.txt.TabIndex = 0
        Me.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HexTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt)
        Me.Name = "HexTextBox"
        Me.Size = New System.Drawing.Size(155, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt As System.Windows.Forms.TextBox

End Class
