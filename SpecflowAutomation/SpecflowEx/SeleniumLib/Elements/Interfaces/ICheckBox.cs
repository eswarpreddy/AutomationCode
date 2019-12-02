namespace SpecflowEx.SeleniumLib.Elements.Interfaces
{
    public interface ICheckBox : IElement
    {
        /// <summary>
        /// Gets CheckBox specific JavaScript actions.
        /// </summary>
        /// <value>Instance of <see cref="CheckBoxJsActions"/></value>
        new CheckBoxJsActions JsActions { get; }

        /// <summary>
        /// Gets CheckBox state: True if checked and false otherwise.
        /// </summary>
        bool IsChecked { get; }

        /// <summary>
        /// Performs check action on the element.
        /// </summary>
        void Check();

        /// <summary>
        /// Performs uncheck action on the element.
        /// </summary>
        void Uncheck();

        /// <summary>
        /// Performs toggle action on the element.
        /// </summary>
        void Toggle();
    }
}
