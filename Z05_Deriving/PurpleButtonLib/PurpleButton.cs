using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PurpleButtonLib
{
    public class PurpleButton : Button
    {
        public PurpleButton()
        {
            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter)) { Name = "contentPresenter" };
            contentPresenter.SetValue(FocusableProperty, false);
            contentPresenter.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenter.SetValue(PaddingProperty, new Thickness(1));

            var border = new FrameworkElementFactory(typeof(Border)) { Name = "border" };
            border.SetValue(BorderBrushProperty, new SolidColorBrush(Color.FromArgb(0xFF, 0x70, 0x70, 0x70)));
            border.SetValue(BorderThicknessProperty, new Thickness(1));
            border.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromArgb(0xff, 0xdd, 0xdd, 0xdd)));
            border.SetValue(SnapsToDevicePixelsProperty, true);

            border.AppendChild(contentPresenter);

            var trigger = new Trigger {Property = IsMouseOverProperty, Value = true};
            trigger.Setters.Add(new Setter(BorderBrushProperty, new SolidColorBrush(Colors.Purple), "border"));
            trigger.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Colors.MediumPurple), "border"));

            var controlTemplate = new ControlTemplate(typeof(Button)) { VisualTree = border };
            controlTemplate.Triggers.Add(trigger);
            Template = controlTemplate;
        }
    }
}
