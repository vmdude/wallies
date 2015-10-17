Imports System.Diagnostics
Imports System.Text
Imports System.IO

Public Module modMain
    Public Structure structWallies
        Dim imageLeft As Image
        Dim imageRight As Image
        Dim imageLeftPath As String
        Dim imageRightPath As String
    End Structure

    Public notIcon As NotifyIcon
    Public WithEvents contMenu As ContextMenu
    Public WithEvents mobTimer As Timers.Timer
    Public intervalTimer As Integer = 600000 ' in ms
    Public wallies As New structWallies()
    Public rootPathWallies As String = My.Settings.rootPathWallies
    Public imageMergedPath As String = My.Settings.imageMergedPath

    Public Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Public Const SPI_SETDESKWALLPAPER = 20
    Public Const SPIF_UPDATEINIFILE = &H1

    Public Sub Main()
        Try
            ' Création de l'icone de systray
            notIcon = New NotifyIcon()
            notIcon.Visible = False
            contMenu = New ContextMenu()
            contMenu.MenuItems.Add(New MenuItem("Sync Now", New EventHandler(AddressOf SyncWallies)))
            contMenu.MenuItems.Add(New MenuItem("Change Interval", New EventHandler(AddressOf ChangeInterval)))
            contMenu.MenuItems.Add("-")
            contMenu.MenuItems.Add(New MenuItem("Exit", New EventHandler(AddressOf ExitWallies)))
            notIcon.ContextMenu = contMenu
            notIcon.Icon = New Icon("favicon.ico")
            contMenu.MenuItems(0).Enabled = True
            contMenu.MenuItems(1).Enabled = True
            contMenu.MenuItems(2).Enabled = True
            ' Initialisation du timer
            SetUpTimer(intervalTimer)
            notIcon.Visible = True
            ' Lancement de l'app
            Application.Run()
        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub SyncWallies()
        Try
            ' Récupération de 2 images en aléatoire
            pickWallies(rootPathWallies)
            ' Création de l'objet qui va recevoir l'assemblage des 2 images
            Dim myGraphic As System.Drawing.Graphics = Nothing
            Dim m As New Bitmap(3840, 1200)
            Dim destRectLeft As New Rectangle(0, 0, 1920, 1200)
            Dim destRectRight As New Rectangle(1920, 0, 1920, 1200)
            ' Construction de l'assemblage
            myGraphic = System.Drawing.Graphics.FromImage(m)
            myGraphic.DrawImage(wallies.imageLeft, destRectLeft)
            myGraphic.DrawImage(wallies.imageRight, destRectRight)
            myGraphic.Save()
            ' Sauvegarde en jpg pour que Windows puisse lire le fond d'écran
            m.Save(imageMergedPath, System.Drawing.Imaging.ImageFormat.Jpeg)
            ' Réinitialisation du fonc d'écran de Windows
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageMergedPath, SPIF_UPDATEINIFILE)
            ' Destruction des objets pour libération mémoire
            wallies.imageLeft.Dispose()
            wallies.imageLeftPath = Nothing
            wallies.imageRight.Dispose()
            wallies.imageRightPath = Nothing
            myGraphic.Dispose()
            m.Dispose()
            destRectLeft = Nothing
            destRectRight = Nothing
        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub ChangeInterval()
        ' Appel de la form de changement d'interval
        Try
            frm_IntervalTimer.Show()
        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub ExitWallies()
        ' Fermeture de l'application, suppression de l'icone de notification
        Try
            notIcon.Visible = False
            notIcon.Dispose()
            Application.Exit()
        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub pickWallies(ByVal path)
        Try
            Dim objFolder As DirectoryInfo = New DirectoryInfo(path)
            Dim r As New Random(System.DateTime.Now.Millisecond)
            Dim colWallies As New ArrayList
            Dim tmpLeft, tmpRight As String
            ' Parcours du dossier racine pour listing des fichiers
            For Each wally As FileInfo In objFolder.GetFiles("*.jpg")
                ' On remplit une liste avec les fichiers
                colWallies.Add(wally.FullName)
            Next
            ' Première génération alétoire
            tmpLeft = colWallies.Item(r.Next(0, colWallies.Count))
            wallies.imageLeft = Image.FromFile(tmpLeft)
            wallies.imageLeftPath = tmpLeft
            ' Deuxième générataion aléatoire
            tmpRight = colWallies.Item(r.Next(0, colWallies.Count))
            ' Vérification pour éviter 2 fois le même fond d'écran
            Do Until (tmpRight <> tmpLeft)
                tmpRight = colWallies.Item(r.Next(0, colWallies.Count))
            Loop
            wallies.imageRight = Image.FromFile(tmpRight)
            wallies.imageRightPath = tmpRight
            ' Destruction des objets
            objFolder = Nothing
            r = Nothing
            colWallies = Nothing
            tmpLeft = Nothing
            tmpRight = Nothing
        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub SetUpTimer(ByVal interval As Integer)
        ' Définition de l'objet timer qui permet de scheduler le changement de fond d'écran tous les x
        Try
            mobTimer = New Timers.Timer()
            With mobTimer
                .AutoReset = True
                .Interval = interval ' en millisecond
                .Start()
            End With
        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub

    Public Sub mobTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles mobTimer.Elapsed
        ' A la fin du temps imparti, on relance le changement de fond d'écrans
        Try
            SyncWallies()
        Catch obEx As Exception
            Throw obEx
        End Try
    End Sub
End Module
