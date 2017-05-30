using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Z09_ObservableCollections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> ListItems { get; } = new List<int> { 1 };
        public ObservableCollection<int> ObservableCollectionItems { get; } = new ObservableCollection<int> { 1 };

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            ListButton.Click += (sender, args) => 
                ListItems.Add(ListItems[ListItems.Count - 1] + 1);
            ObservableCollectionButton.Click +=
                (sender, args) => ObservableCollectionItems.Add(
                    ObservableCollectionItems[ObservableCollectionItems.Count - 1] + 1);
        }
    }
}
