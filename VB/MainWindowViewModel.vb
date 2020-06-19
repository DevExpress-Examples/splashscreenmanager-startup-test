Imports System.Collections.ObjectModel
Imports System.Linq

Namespace SplashScreenStartupTest
	Public Class MainWindowViewModel
		Private privateItems As ObservableCollection(Of Item)
		Public Property Items() As ObservableCollection(Of Item)
			Get
				Return privateItems
			End Get
			Private Set(ByVal value As ObservableCollection(Of Item))
				privateItems = value
			End Set
		End Property
		Protected Sub New()
			Items = New ObservableCollection(Of Item)()
			Enumerable.Range(0, 100).Select(Function(x) New Item() With {
				.Id = x,
				.Value = x.ToString()
			}).ToList().ForEach(Sub(x) Items.Add(x))
		End Sub
	End Class
	Public Class Item
		Public Property Id() As Integer
		Public Property Value() As String
	End Class
End Namespace