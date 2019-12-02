using SpecflowEx.SeleniumLib.Elements.Interfaces;
using CoreElementFactory = SpecflowEx.SeleniumLib.Elements.Interfaces.IElementFactory;
using CoreElementFinder = SpecflowEx.SeleniumLib.Elements.Interfaces.IElementFinder;
using CoreElementStateProvider = SpecflowEx.SeleniumLib.Elements.Interfaces.IElementStateProvider;

namespace SpecflowEx.SeleniumLib.Elements
{
    /// <summary>
    /// Defines base class for any UI element.
    /// </summary>
    public class Element :  IElement
    {
        public string ClassName { get; set; }
    public string CssSelector { get; set; }
    public string Id { get; set; }
    public string LinkText { get; set; }
        public string Name { get; set; }
        public string PartialLinkText { get; set; }
        public string TagName { get; set; }
        public string XPath { get; set; }
        public string State { get; set; }


        public Element()
        {
        }

        public override CoreElementStateProvider State => new ElementStateProvider(Locator, ConditionalWait, Finder);

        protected IBrowserProfile BrowserProfile => BrowserManager.GetRequiredService<IBrowserProfile>();

        public JsActions JsActions => new JsActions(this, ElementType, LocalizationLogger, BrowserProfile);

        public MouseActions MouseActions => new MouseActions(this, ElementType, LocalizationLogger, ActionRetrier);

        private Browser Browser => (Browser)Application;

        protected override IApplication Application => BrowserManager.Browser;

        protected override ElementActionRetrier ActionRetrier => BrowserManager.GetRequiredService<ElementActionRetrier>();

        protected override CoreElementFactory Factory => CustomFactory;

        protected virtual IElementFactory CustomFactory => BrowserManager.GetRequiredService<IElementFactory>();

        protected override CoreElementFinder Finder => BrowserManager.GetRequiredService<CoreElementFinder>();

        protected override LocalizationLogger LocalizationLogger => BrowserManager.GetRequiredService<LocalizationLogger>();

        protected LocalizationManager LocalizationManager => BrowserManager.GetRequiredService<LocalizationManager>();

        protected override ConditionalWait ConditionalWait => BrowserManager.GetRequiredService<ConditionalWait>();

        public void ClickAndWait()
        {
            Click();
            Browser.WaitForPageToLoad();
        }

        public void WaitAndClick()
        {
            State.WaitForClickable();
            Click();
        }

        public new void Click()
        {
            LogElementAction("loc.clicking");
            JsActions.HighlightElement();
            DoWithRetry(() => GetElement().Click());
        }

        public void Focus()
        {
            LogElementAction("loc.focusing");
            JsActions.SetFocus();
        }

        public string GetAttribute(string attr, HighlightState highlightState = HighlightState.Default)
        {
            LogElementAction("loc.el.getattr", attr);
            JsActions.HighlightElement(highlightState);
            return DoWithRetry(() => GetElement().GetAttribute(attr));
        }

        public string GetCssValue(string propertyName, HighlightState highlightState = HighlightState.Default)
        {
            LogElementAction("loc.el.cssvalue", propertyName);
            JsActions.HighlightElement(highlightState);
            return DoWithRetry(() => GetElement().GetCssValue(propertyName));
        }

        public string GetText(HighlightState highlightState = HighlightState.Default)
        {
            LogElementAction("loc.get.text");
            JsActions.HighlightElement(highlightState);
            return DoWithRetry(() => GetElement().Text);
        }

        public void SetInnerHtml(string value)
        {
            Click();
            LogElementAction("loc.send.text", value);
            Browser.ExecuteScript(JavaScript.SetInnerHTML, GetElement(), value);
        }
    }
}
