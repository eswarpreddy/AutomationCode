using System;

namespace SpecflowEx.SeleniumLib.Elements.Actions
{
    class JavaScriptWrapper
    {
        public String WaitTillPageLoad()
        {
            string  loadingState = "return document.readyState";
            // string loadingState = ExecuteJavaScript(loadingState).ToString();
            return loadingState;

        }



    }
}
