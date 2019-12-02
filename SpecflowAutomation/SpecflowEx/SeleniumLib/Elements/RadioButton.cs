using SpecflowEx.SeleniumLib.Elements.Interfaces;

namespace SpecflowEx.SeleniumLib.Elements
{
    /// <summary>
    /// Defines RadioButton UI element.
    /// </summary>
    public class RadioButton : Element, IRadioButton
    {
        protected internal RadioButton() : base()
        {
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.radio");

        public bool IsChecked => GetElement().Selected;
    }
}
