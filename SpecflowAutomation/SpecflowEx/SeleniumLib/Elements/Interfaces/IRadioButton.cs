namespace SpecflowEx.SeleniumLib.Elements.Interfaces
{
    public interface IRadioButton : IElement
    {
        /// <summary>
        /// Gets RadioButton state.
        /// </summary>
        /// <value>True if checked and false otherwise.</value>
        bool IsChecked { get; }
    }
}
