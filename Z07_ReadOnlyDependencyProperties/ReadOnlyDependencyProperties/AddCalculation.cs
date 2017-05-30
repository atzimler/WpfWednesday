using System.Windows;

namespace ReadOnlyDependencyProperties
{
    public class AddCalculation : DependencyObject
    {
        private static readonly DependencyPropertyKey ResultPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Result), typeof(int), typeof(AddCalculation), new PropertyMetadata(0));
        public static readonly DependencyProperty ResultProperty = ResultPropertyKey.DependencyProperty;
        public int Result
        {
            get { return (int)GetValue(ResultProperty); }
        }

        public static readonly DependencyProperty AProperty =
            DependencyProperty.Register(nameof(A), typeof(int), typeof(AddCalculation), new PropertyMetadata(0, AddNumbers));
        public int A
        {
            get { return (int)GetValue(AProperty); }
            set { SetValue(AProperty, value); }
        }

        public static readonly DependencyProperty BProperty =
            DependencyProperty.Register(nameof(B), typeof(int), typeof(AddCalculation), new PropertyMetadata(0, AddNumbers));
        public int B
        {
            get { return (int)GetValue(BProperty); }
            set { SetValue(BProperty, value); }
        }

        private static void AddNumbers(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ac = (AddCalculation)d;
            ac.SetValue(ResultPropertyKey, ac.A + ac.B);
        }

    }
}
