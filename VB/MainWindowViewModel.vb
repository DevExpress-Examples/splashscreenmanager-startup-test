Imports System.Collections.ObjectModel
Imports System.Linq

Namespace SplashScreenStartupTest

    Public Class MainWindowViewModel

        Private _Items As ObservableCollection(Of SplashScreenStartupTest.Item)

        Public Property Items As ObservableCollection(Of Item)
            Get
                Return _Items
            End Get

            Private Set(ByVal value As ObservableCollection(Of Item))
                _Items = value
            End Set
        End Property

        Protected Sub New()
            Items = New ObservableCollection(Of Item)()
            Enumerable.ToList(Of Item)(Enumerable.Select(Of Integer, Global.SplashScreenStartupTest.Item)(Enumerable.Range(CInt(0), CInt(100)), CType(Function(x) CType(New Item() With {.Id = x, .Value = x.ToString()}, Item), System.Func(Of Integer, Item)))).ForEach(Sub(x) Items.Add(x))
        End Sub
    End Class

    Public Class Item

        Public Property Id As Integer

        Public Property Value As String
    End Class
End Namespace
