using System;
using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using Seleniq.Core;
using Seleniq.Extensions.Selenium;

namespace Pages
{
    public static class Extensions
    {
        public static SeleniqBaseElement ValidateExists(this SeleniqBaseElement element)
        {
            var text = $"Validating presence of {element.GetType().Name}";
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Console.WriteLine(text);
                Assert.IsNotNull(element);
            }, text);
            return element;
        }

        public static void ValidateExists(this IWebElement webElement, string name)
        {
            AllureLifecycle.Instance.WrapInStep(
                () =>
                {
                    Console.WriteLine(
                        $"-> Validating presence of {name} ({webElement.GetBy()}) on {webElement.ToDriver().Url}");
                    Assert.DoesNotThrow(() => webElement.JsHighlight("double", "red"));
                },
                $"Validating presence of {name}");
        }

        public static void WrapInStep(this SeleniqBase seleniq, Action action, string description = "")
        {
            Console.WriteLine(description);
            AllureLifecycle.Instance.WrapInStep(action, description);
        }
    }
}