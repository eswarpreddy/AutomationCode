using SpecflowEx.SeleniumLib.Elements.Interfaces;

namespace SpecflowEx.SeleniumLib.Elements
{
    /// <summary>
    /// Defines Label UI element.
    /// </summary>
    public class Label : Element, ILabel
    {
        protected internal Label() : base()
        {
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.label");
    }
}
