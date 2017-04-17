using System.Windows;
using System.Windows.Controls;

namespace DependencyProperties
{
    public class HelloMessageButton : Button
    {
        public static DependencyProperty MessageProperty = DependencyProperty.Register(nameof(Message), typeof(string), typeof(HelloMessageButton), new PropertyMetadata(null));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public HelloMessageButton()
        {
            Click += (o, e) => MessageBox.Show(Message);
        }
    }
}
