<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/258539385/21.1.5%2B)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
To minimize the startup time, the Splash Screen Manager facilitates multiple performance enhancements. For example, it only partially loads the DevExpress Theme resources.

Our tests on different PC configurations have shown the following figures.

Without the [Ngen.exe](https://docs.devexpress.com/WPF/400286/common-concepts/performance-improvement/reducing-the-application-launch-time) optimization:

Themed Splash Screen: 290-450 ms

Fluent Splash Screen: 300-460 ms

Compiled with Ngen.exe:

Themed Splash Screen: 170-370 ms

Fluent Splash Screen: 180-370 ms

Use this example to test the startup time of various [splash screens](https://docs.devexpress.com/WPF/DevExpress.Xpf.Core.SplashScreenManager?v=20.1) on your machine.

To change the splash screen type, uncomment one of the lines in App.xaml.cs and keep the other lines commented out.

The window title shows the time it took to display the splash screen.
