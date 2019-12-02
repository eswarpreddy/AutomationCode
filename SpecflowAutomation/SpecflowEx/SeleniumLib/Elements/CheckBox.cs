using SpecflowEx.SeleniumLib.Elements.Interfaces;

namespace SpecflowEx.SeleniumLib.Elements
{
    /// <summary>
    /// Defines CheckBox UI element.
    /// </summary>
    public class CheckBox : Element, ICheckBox
    {
        protected internal CheckBox() : base()
        {
        }

        protected override string ElementType => LocalizationManager.GetLocalizedMessage("loc.checkbox");

        public bool IsChecked
        {
            get
            {
                LogElementAction("loc.checkbox.get.state");
                return GetElement().Selected;
            }
        }

        public new CheckBoxJsActions JsActions => new CheckBoxJsActions(this, ElementType, LocalizationLogger, BrowserProfile);

        public void Check()
        {
            SetState(true);
        }

        public void Uncheck()
        {
            SetState(false);
        }

        public void Toggle()
        {
            SetState(!IsChecked);
        }

        private void SetState(bool state)
        {
            LogElementAction("loc.setting.value", state);
            if (state != IsChecked)
            {
                Click();
            }
        }
    }
}
