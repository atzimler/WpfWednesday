using System.Windows;

namespace Z08_AttachingEventHandlers
{
    public class MultiplyByTwo : DependencyObject
    {
        private static readonly DependencyPropertyKey ResultPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(Result), typeof(int), typeof(MultiplyByTwo),
                new PropertyMetadata(0));

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register(nameof(Number), typeof(int), typeof(MultiplyByTwo),
                new PropertyMetadata(0, CalculateResult));

        public static readonly DependencyProperty ResultProperty = ResultPropertyKey.DependencyProperty;


        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public int Result
        {
            get { return (int)GetValue(ResultProperty); }
        }


        private static void CalculateResult(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(ResultPropertyKey, (int)e.NewValue * 2);
        }
    }
}