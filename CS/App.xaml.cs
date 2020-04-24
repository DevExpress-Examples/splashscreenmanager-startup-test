using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace SplashScreenStartupTest {
    public partial class App : Application {
        public static Stopwatch Timer;
        public App() {
            Timer = Stopwatch.StartNew();
            ApplicationThemeHelper.ApplicationThemeName = Theme.Office2019Colorful.Name;
            //Test_SplashScreenManager_DefaultFluentSplashScreen();
            //Test_SplashScreenManager_DefaultThemedSplashScreen();
            Test_SplashScreenManager_GeneratedInAppFluentSplashScreen();
            //Test_SplashScreenManager_GeneratedInAppThemedSplashScreen();
            //Test_LegacySplashScreen();
        }

        public static void Test_SplashScreenManager_DefaultFluentSplashScreen() {
            Test_SplashScreenManagerCore(() => new FluentSplashScreen());
        }
        public static void Test_SplashScreenManager_DefaultThemedSplashScreen() {
            Test_SplashScreenManagerCore(() => new ThemedSplashScreen());
        }
        public static void Test_SplashScreenManager_GeneratedInAppFluentSplashScreen() {
            Test_SplashScreenManagerCore(() => new CustomFluentSplashScreen());
        }
        public static void Test_SplashScreenManager_GeneratedInAppThemedSplashScreen() {
            Test_SplashScreenManagerCore(() => new CustomThemedSplashScreen());
        }
        public static void Test_SplashScreenManagerCore(Func<Window> splashScreenFactory) {
            SplashScreenManager.Create(() => {
                var w = splashScreenFactory();
                w.ContentRendered += (s, e) => {
                    Timer.Stop();
                    App.Current.Dispatcher.InvokeAsync(() => {
                        App.Current.MainWindow.Title = $"SplashScreen Startup Time: {Timer.ElapsedMilliseconds} ms";
                    });
                };
                return w;
            }, new DXSplashScreenViewModel() {
                Title = "SplashScreen Test",
                Subtitle = null,
            }).ShowOnStartup();
        }

        public static void Test_LegacySplashScreen() {
            var splashScreenViewModel = new SplashScreenViewModel() {
                IsIndeterminate = true,
            };
            DXSplashScreen.Show((x) => {
                var w = DXSplashScreen.DefaultSplashScreenWindowCreator.Invoke(null);
                w.Topmost = false;
                w.ContentRendered += (s, e) => {
                    Timer.Stop();
                    App.Current.Dispatcher.InvokeAsync(() => {
                        App.Current.MainWindow.Title = $"SplashScreen Startup Time: {Timer.ElapsedMilliseconds} ms";
                    });
                };
                return w;
            }, (x) => new LegacySplashScreenView() {
                DataContext = splashScreenViewModel
            }, null, null);

            App.Current.Dispatcher.InvokeAsync(() => {
                DXSplashScreen.Close();
            }, DispatcherPriority.Loaded);
        }
    }
}
