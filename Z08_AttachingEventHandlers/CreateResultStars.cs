using System.ComponentModel;

namespace Z08_AttachingEventHandlers
{
    public class CreateResultStars
    {
        private readonly MultiplyByTwo _multiplier;

        public string Stars { get; private set; }

        public CreateResultStars(MultiplyByTwo multiplier)
        {
            _multiplier = multiplier;

            var dpd = DependencyPropertyDescriptor.FromProperty(MultiplyByTwo.ResultProperty, typeof(MultiplyByTwo));
            dpd.AddValueChanged(_multiplier, (o, e) => RecalculateStars());

            RecalculateStars();
        }

        private void RecalculateStars()
        {
            Stars = new string('*', _multiplier.Result);
        }
    }
}
