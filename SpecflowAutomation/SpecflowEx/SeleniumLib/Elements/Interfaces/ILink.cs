namespace SpecflowEx.SeleniumLib.Elements.Interfaces
{
    public interface ILink : IElement
    {
        /// <summary>
        /// Gets value of href attribute.
        /// </summary>
        /// <value>String representation of element's href.</value>
        string Href { get; }
    }
}
