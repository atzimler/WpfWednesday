using System.Windows.Media;
using PurpleButtonLib;

namespace WpfApplication
{
    public class AquaPurpleButton : PurpleButton
    {
        public AquaPurpleButton()
        {
            Background = Brushes.Aqua;
            BorderBrush = Brushes.DarkCyan;
        }
    }
}
