using System.Threading;
using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Seleniq.Attributes;
using Seleniq.Core;
using Seleniq.Extensions;
using Seleniq.Extensions.Selenium;

namespace Tests.NUnit
{
    [AllureNUnit]
    internal class BaseTest : SeleniqBase
    {
        [OneTimeSetUp]
        public void ClearAllure()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public virtual void StartBrowser()
        {
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            InitWebDriver(new ChromeDriver(service, chromeOptions));
        }

        [TearDown]
        public void KillBrowser()
        {
            AddScreenShot();
            KillWebDriver();
        }

        private void AddScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                var screenInBytes = ((ITakesScreenshot) Driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("ScreenShot", "image/png", screenInBytes, ".png");
            }
        }

        protected static void ValidateTitleContains(string fraction)
        {
            AllureLifecycle.Instance.WrapInStep(
                () => { Driver.Wait().Until(ExpectedConditions.UrlContains(fraction)); },
                $"Validating that title contains {fraction}");
        }
    }

    internal class BaseTest<T> : BaseTest where T : SeleniqBaseElement, new()
    {
        protected T Component { get; private set; }

        [SetUp]
        public override void StartBrowser()
        {
            base.StartBrowser();
            InitComponent();
        }

        private void InitComponent()
        {
            AllureLifecycle.Instance.UpdateTestCase(t =>
            {
                t.labels.Add(Label.Suite(typeof(T).Name));
                t.labels.Add(Label.Feature(typeof(T).Name));
            });
            AllureLifecycle.Instance.WrapInStep(() => { Component = InstanceOf<T>(NavigateBy.ElementUrl); },
                $"Opening {typeof(T).Name}");
        }
    }
}