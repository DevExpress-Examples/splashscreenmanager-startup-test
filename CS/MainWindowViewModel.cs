using System.Collections.ObjectModel;
using System.Linq;

namespace SplashScreenStartupTest {
    public class MainWindowViewModel {
        public ObservableCollection<Item> Items { get; private set; }
        protected MainWindowViewModel() {
            Items = new ObservableCollection<Item>();
            Enumerable.Range(0, 100)
                .Select(x => new Item() { Id = x, Value = x.ToString() })
                .ToList()
                .ForEach(x => Items.Add(x));
        }
    }
    public class Item {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}