Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class clsTransparentPictureBox
    Inherits PictureBox

    Public Sub New()
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        If Me.Parent IsNot Nothing Then
            Dim state As GraphicsState = pevent.Graphics.Save()
            pevent.Graphics.TranslateTransform(-Me.Left, -Me.Top)
            Dim e As New PaintEventArgs(pevent.Graphics, Me.Parent.ClientRectangle)
            Me.InvokePaintBackground(Me.Parent, e)
            Me.InvokePaint(Me.Parent, e)
            pevent.Graphics.Restore(state)
        Else
            MyBase.OnPaintBackground(pevent)
        End If
    End Sub
End Class
