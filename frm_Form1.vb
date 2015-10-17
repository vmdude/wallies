Imports System.IO

Public Class frm_Form1
    Structure structWallies
        Dim imageLeft As Image
        Dim imageRight As Image
        Dim imageLeftPath As String
        Dim imageRightPath As String
    End Structure

    Private wallies As New structWallies()
    Private rootPathWallies As String = "D:\Images\Fonds d'écran\"
    Private imageMergedPath As String = "C:\Users\doudou\AppData\Local\_Ammesiah\wallies.jpg"

    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Private Const SPI_SETDESKWALLPAPER = 20
    Private Const SPIF_UPDATEINIFILE = &H1


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim myGraphic As System.Drawing.Graphics = Nothing
            Dim m As New Bitmap(3840, 1200)
            Dim destRectLeft As New Rectangle(0, 0, 1920, 1200)
            Dim destRectRight As New Rectangle(1920, 0, 1920, 1200)
            myGraphic = System.Drawing.Graphics.FromImage(m)
            myGraphic.DrawImage(wallies.imageLeft, destRectLeft)
            myGraphic.DrawImage(wallies.imageRight, destRectRight)
            myGraphic.Save()
            m.Save(imageMergedPath, System.Drawing.Imaging.ImageFormat.Jpeg)
            pbox_merge.Image = m
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageMergedPath, SPIF_UPDATEINIFILE)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button1.Enabled = False
        pbox_left.Image = Nothing
        pbox_right.Image = Nothing
    End Sub

    Private Sub pickWallies(ByVal path)
        Dim objFolder As DirectoryInfo = New DirectoryInfo(path)
        Dim r As New Random(System.DateTime.Now.Millisecond)
        Dim colWallies As New ArrayList
        Dim tmpLeft, tmpRight As String
        For Each wally As FileInfo In objFolder.GetFiles("*.jpg")
            colWallies.Add(wally.FullName)
        Next
        tmpLeft = colWallies.Item(r.Next(0, colWallies.Count))
        wallies.imageLeft = Image.FromFile(tmpLeft)
        wallies.imageLeftPath = tmpLeft
        tmpRight = colWallies.Item(r.Next(0, colWallies.Count))
        Do Until (tmpRight <> tmpLeft)
            tmpRight = colWallies.Item(r.Next(0, colWallies.Count))
        Loop
        wallies.imageRight = Image.FromFile(tmpRight)
        wallies.imageRightPath = tmpRight
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        writeLog("Load Random Begins ...")
        Button1.Enabled = True
        pickWallies(rootPathWallies)
        pbox_left.Image = wallies.imageLeft
        writeLog("ImageLeft path : " & wallies.imageLeftPath)
        writeLog("ImageLeft width : " & wallies.imageLeft.Width)
        writeLog("ImageLeft height : " & wallies.imageLeft.Height)
        pbox_right.Image = wallies.imageRight
        writeLog("ImageRight path : " & wallies.imageRightPath)
        writeLog("ImageRight width : " & wallies.imageRight.Width)
        writeLog("ImageRight height : " & wallies.imageRight.Height)
        writeLog("Load Random Ends ...")
    End Sub

    Private Sub writeLog(ByVal log As String)
        logWallies.Text = DateTime.Now & " - " & log & vbCrLf & logWallies.Text
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MessageBox.Show("ok")
    End Sub
End Class
