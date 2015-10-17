<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pbox_left = New System.Windows.Forms.PictureBox()
        Me.pbox_right = New System.Windows.Forms.PictureBox()
        Me.pbox_merge = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.logWallies = New System.Windows.Forms.TextBox()
        CType(Me.pbox_left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbox_right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbox_merge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(614, 504)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Merge"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pbox_left
        '
        Me.pbox_left.Location = New System.Drawing.Point(12, 12)
        Me.pbox_left.Name = "pbox_left"
        Me.pbox_left.Size = New System.Drawing.Size(384, 240)
        Me.pbox_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbox_left.TabIndex = 1
        Me.pbox_left.TabStop = False
        '
        'pbox_right
        '
        Me.pbox_right.Location = New System.Drawing.Point(402, 12)
        Me.pbox_right.Name = "pbox_right"
        Me.pbox_right.Size = New System.Drawing.Size(384, 240)
        Me.pbox_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbox_right.TabIndex = 2
        Me.pbox_right.TabStop = False
        '
        'pbox_merge
        '
        Me.pbox_merge.Location = New System.Drawing.Point(12, 258)
        Me.pbox_merge.Name = "pbox_merge"
        Me.pbox_merge.Size = New System.Drawing.Size(768, 240)
        Me.pbox_merge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbox_merge.TabIndex = 3
        Me.pbox_merge.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(533, 504)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Unload"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(695, 504)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(85, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Load Random"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'logWallies
        '
        Me.logWallies.Location = New System.Drawing.Point(793, 13)
        Me.logWallies.Multiline = True
        Me.logWallies.Name = "logWallies"
        Me.logWallies.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.logWallies.Size = New System.Drawing.Size(371, 485)
        Me.logWallies.TabIndex = 7
        Me.logWallies.WordWrap = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 535)
        Me.Controls.Add(Me.logWallies)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.pbox_merge)
        Me.Controls.Add(Me.pbox_right)
        Me.Controls.Add(Me.pbox_left)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pbox_left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbox_right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbox_merge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pbox_left As System.Windows.Forms.PictureBox
    Friend WithEvents pbox_right As System.Windows.Forms.PictureBox
    Friend WithEvents pbox_merge As System.Windows.Forms.PictureBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents logWallies As System.Windows.Forms.TextBox

End Class
