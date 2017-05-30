using System.Windows;
using System.Windows.Controls;

namespace Z11_AttachedProperties
{
    public class LeftRightLayoutControl : StackPanel
    {
        private Grid _grid;
        private StackPanel _left;
        private StackPanel _right;

        public enum Side
        {
            None,
            Left,
            Right
        }
        public static readonly DependencyProperty SideProperty = DependencyProperty.RegisterAttached(nameof(Side), typeof(Side), typeof(LeftRightLayoutControl), new PropertyMetadata(Side.None, UpdateSide));

        private static void UpdateSide(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (FrameworkElement)d;

            // Finding the LeftRightLayoutControl to which this object belongs to either directly or indirectly.
            var parent = LogicalTreeHelper.GetParent(obj);
            while (parent != null && parent.GetType() != typeof(LeftRightLayoutControl))
            {
                parent = LogicalTreeHelper.GetParent(parent);
            }
            var layoutControl = (LeftRightLayoutControl)parent;

            // Detaching the object from the current logical parent.
            ((StackPanel)obj.Parent).Children.Remove(obj);

            // Reattaching the object to the correct logical parent based on the new value.
            var value = (Side)e.NewValue;
            if (value == Side.Left)
            {
                layoutControl._left.Children.Add(obj);
            }
            else if (value == Side.Right)
            {
                layoutControl._right.Children.Add(obj);
            }
            else
            {
                layoutControl.Children.Add(obj);
            }
        }

        public static Side GetSide(UIElement target)
        {
            return (Side)target.GetValue(SideProperty);
        }

        public static void SetSide(UIElement target, Side value)
        {
            target.SetValue(SideProperty, value);
        }

        public LeftRightLayoutControl()
        {
            _grid = new Grid();
            _grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            _left = new StackPanel();
            Grid.SetRow(_left, 0);
            Grid.SetColumn(_left, 0);
            _grid.Children.Add(_left);

            _right = new StackPanel();
            Grid.SetRow(_right, 0);
            Grid.SetColumn(_right, 1);
            _grid.Children.Add(_right);

            Children.Add(_grid);
        }

    }
}
