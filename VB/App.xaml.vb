Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Native
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Threading

Namespace SplashScreenStartupTest

    Public Partial Class App
        Inherits Application

        Public Shared Timer As Stopwatch

        Public Sub New()
            Timer = Stopwatch.StartNew()
            ApplicationThemeHelper.ApplicationThemeName = Theme.Office2019Colorful.Name
            'Test_SplashScreenManager_DefaultFluentSplashScreen();
            'Test_SplashScreenManager_DefaultThemedSplashScreen();
            Call Test_SplashScreenManager_GeneratedInAppFluentSplashScreen()
        'Test_SplashScreenManager_GeneratedInAppThemedSplashScreen();
        'Test_LegacySplashScreen();
        End Sub

        Public Shared Sub Test_SplashScreenManager_DefaultFluentSplashScreen()
            Call Test_SplashScreenManagerCore(Function() New FluentSplashScreen())
        End Sub

        Public Shared Sub Test_SplashScreenManager_DefaultThemedSplashScreen()
            Call Test_SplashScreenManagerCore(Function() New ThemedSplashScreen())
        End Sub

        Public Shared Sub Test_SplashScreenManager_GeneratedInAppFluentSplashScreen()
            Call Test_SplashScreenManagerCore(Function() New CustomFluentSplashScreen())
        End Sub

        Public Shared Sub Test_SplashScreenManager_GeneratedInAppThemedSplashScreen()
            Call Test_SplashScreenManagerCore(Function() New CustomThemedSplashScreen())
        End Sub

        Public Shared Sub Test_SplashScreenManagerCore(ByVal splashScreenFactory As Func(Of Window))
            Call SplashScreenManager.Create(Function()
                Dim w = splashScreenFactory()
                AddHandler w.ContentRendered, Sub(s, e)
                    Call Timer.Stop()
                    Current.Dispatcher.InvokeAsync(Sub() Current.MainWindow.Title = $"SplashScreen Startup Time: {Timer.ElapsedMilliseconds} ms")
                End Sub
                Return w
            End Function, New DXSplashScreenViewModel() With {.Title = "SplashScreen Test", .Subtitle = Nothing}).ShowOnStartup()
        End Sub

        Public Shared Sub Test_LegacySplashScreen()
            Dim splashScreenViewModel = New SplashScreenViewModel() With {.IsIndeterminate = True}
            Call DXSplashScreen.Show(Function(x)
                Dim w = DXSplashScreen.DefaultSplashScreenWindowCreator.Invoke(Nothing)
                w.Topmost = False
                AddHandler w.ContentRendered, Sub(s, e)
                    Call Timer.Stop()
                    Current.Dispatcher.InvokeAsync(Sub() Current.MainWindow.Title = $"SplashScreen Startup Time: {Timer.ElapsedMilliseconds} ms")
                End Sub
                Return w
            End Function, Function(x) New LegacySplashScreenView() With {.DataContext = splashScreenViewModel}, Nothing, Nothing)
            Current.Dispatcher.InvokeAsync(Sub() Call DXSplashScreen.Close(), DispatcherPriority.Loaded)
        End Sub
    End Class
End Namespace
