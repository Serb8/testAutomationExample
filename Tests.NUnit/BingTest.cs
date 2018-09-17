using NUnit.Allure.Attributes;
using NUnit.Framework;
using Pages.Bing;
using Seleniq.Extensions.Selenium;

namespace Tests.NUnit
{
    [TestFixture(Author = "Nick", Category = "Example")]
    internal class BingTest : BaseTest<SearchFormEl>
    {
        [Test]
        [AllureTms("JIRA-123")]
        [AllureLink("https://confluence.e-loreal.com/pages/viewpage.action?pageId=257609828")]
        [TestCase("unickq")]
        [TestCase("google")]
        public void ValidateSearchFieldAfterSearch(string query)
        {
            Component.SetText(query).SubmitButton.JsHighlight().Click();
            StringAssert.AreEqualIgnoringCase(query, new SearchFormEl().InputField.GetValue());
        }

        [Test]
        [AllureTms("JIRA-123")]
        [AllureLink("https://confluence.e-loreal.com/pages/viewpage.action?pageId=257609828")]
        [TestCase("unickq")]
        [TestCase("google")]
        public void ValidateSearchTitle(string query)
        {
            Component.SetText(query).SubmitButton.JsHighlight().Click();
            ValidateTitleContains(query);
        }
    }
}