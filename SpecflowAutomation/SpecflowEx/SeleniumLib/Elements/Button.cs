using SpecflowEx.SeleniumLib.Elements.Interfaces;
using ElementState = SpecflowEx.SeleniumLib.Elements.ElementState;

namespace SpecflowEx.SeleniumLib.Elements
{
    /// <summary>
    /// Defines Button UI element.
    /// </summary>
    public class Button : Element, IButton
    {
        protected internal Button() : base()
        {
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.button");
    }
}