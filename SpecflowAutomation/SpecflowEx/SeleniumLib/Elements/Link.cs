using SpecflowEx.SeleniumLib.Elements.Interfaces;

namespace SpecflowEx.SeleniumLib.Elements
{
    /// <summary>
    /// Defines Link UI element.
    /// </summary>
    public class Link : Element, ILink
    {
        protected internal Link() : base()
        {
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.link");

        public string Href => GetAttribute("href");
    }
}
