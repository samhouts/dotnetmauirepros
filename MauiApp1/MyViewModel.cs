using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<CollectionViewItemModel> _CollectionViewItemSource = new();
        public ObservableCollection<CollectionViewItemModel> CollectionViewItemSource
        {
            get => _CollectionViewItemSource;
            set
            {
                if (_CollectionViewItemSource != value)
                {
                    _CollectionViewItemSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public MyViewModel()
        {
            foreach (var item in Enumerable.Range(1, 1000).Select(i => new CollectionViewItemModel( i % 2 == 0 ?"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.": "Lorem ipsum dolor sit amet.")))
            {
                _CollectionViewItemSource.Add(item);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public record CollectionViewItemModel(string LongText);
}
