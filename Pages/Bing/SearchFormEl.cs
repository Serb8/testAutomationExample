using OpenQA.Selenium;
using Seleniq.Attributes;
using Seleniq.Core;
using Seleniq.Extensions.Selenium;

namespace Pages.Bing
{
    [ElementUrl("/")]
    public class SearchFormEl : SeleniqBaseElement
    {
        public SearchFormEl() : base(By.ClassName("b_searchboxForm"))
        {
        }

        public IWebElement InputField =>
            Root.GetElement(By.ClassName("b_searchbox"), message: "Input field is not found");

        public IWebElement SubmitButton =>
            Root.GetElement(By.ClassName("b_searchboxSubmit"), message: "Search icon is not found");

        public SearchFormEl SetText(string text)
        {
            this.WrapInStep(() =>
            {
                InputField.Clear();
                InputField.JsHighlight().SendKeys(text);
            });
            return this;
        }
    }
}