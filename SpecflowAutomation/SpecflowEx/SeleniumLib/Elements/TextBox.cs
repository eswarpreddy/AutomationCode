using SpecflowEx.SeleniumLib.Elements.Interfaces;

namespace SpecflowEx.SeleniumLib.Elements
{
    /// <summary>
    /// Defines TextBox UI element.
    /// </summary>
    public class TextBox : Element, ITextBox
    {
        private const string SecretMask = "*********";

        protected internal TextBox() : base()
        {
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.text.field");

        public string Value => GetAttribute(Attributes.Value);

        public void Type(string value, bool secret = false)
        {
            LogElementAction("loc.text.typing", secret ? SecretMask : value);
            JsActions.HighlightElement();
            DoWithRetry(() => GetElement().SendKeys(value));
        }

        public void ClearAndType(string value, bool secret = false)
        {
            LogElementAction("loc.text.clearing");
            LogElementAction("loc.text.typing", secret ? SecretMask : value);
            JsActions.HighlightElement();
            DoWithRetry(() =>
            {
                GetElement().Clear();
                GetElement().SendKeys(value);
            });
        }

        public void Submit()
        {
            DoWithRetry(() => GetElement().Submit());
        }

        public new void Focus()
        {
            DoWithRetry(() => GetElement().SendKeys(string.Empty));
        }
    }
}
