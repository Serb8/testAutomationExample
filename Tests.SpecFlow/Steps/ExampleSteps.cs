using System;
using Allure.Commons;
using NUnit.Framework;
using Pages.Bing;
using Seleniq.Extensions;
using Seleniq.Extensions.Selenium;
using Seleniq.SpecFlow;
using TechTalk.SpecFlow;
using Unickq.SpecFlow.Selenium.Allure;

namespace Tests.SpecFlow.Steps
{
    [Binding]
    internal class ExampleSteps : SeleniqBaseSpecFlow
    {
        protected ExampleSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [Then(@"Search query should be equal to (.*)")]
        public void ThenSearchQueryShouldBeEqualTo(string query)
        {
            StringAssert.AreEqualIgnoringCase(query, Cache<SearchFormEl>(true).InputField.GetValue());
        }


        [Given(@"I have opened (.*)")]
        public void GivenIHaveOpened(string url)
        {
            if (!url.StartsWith("http"))
                url = string.Concat(BaseUrl, url);
            Console.WriteLine($"-> {url}");
            Driver.Navigate().GoToUrl(url);
        }

        [When(@"I search (.*)")]
        public void WhenISearch(string text)
        {
            Cache<SearchFormEl>().SetText(text).SubmitButton.JsHighlight().Click();
        }

        [Then(@"Browser title contains (.*)")]
        public void ThenBrowserTitleContains(string fraction)
        {
            AllureLifecycle.Instance.WrapInStep(
                () => { Driver.Wait().Until(ExpectedConditions.UrlContains(fraction)); },
                $"Validating that title contains {fraction}");
        }
    }
}