using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Z10_BindingFromCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static DependencyProperty LabelDataProperty = DependencyProperty.Register(nameof(LabelData), typeof(string), typeof(MainWindow), new PropertyMetadata("Old Label Value"));
        public string LabelData
        {
            get { return (string)GetValue(LabelDataProperty); }
            set { SetValue(LabelDataProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();

            var binding = new Binding(nameof(LabelData)) { Source = this, Mode = BindingMode.OneWay };
            BindingOperations.SetBinding(UpdatedLabel, TextBlock.TextProperty, binding);

            UpdateLabelButton.Click += (s, a) => { LabelData = "New Label Value"; };
        }
    }
}
