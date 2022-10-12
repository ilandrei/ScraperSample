using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ScraperSample.Helpers;

public static class SelectorHelpers
{
    public static IWebElement? GetFirst(this ChromeDriver driver, SelectorType selectorType, string value)
    {
        try
        {
            return selectorType switch
            {
                (SelectorType.Id) => driver.FindElement(By.Id(value)),
                (SelectorType.XPath) => driver.FindElement(By.XPath(value)),
                (SelectorType.Class) => driver.FindElements(By.ClassName(value)).FirstOrDefault(),
                _ => null
            };
        }
        catch
        {
            return null;
        }
    }
}