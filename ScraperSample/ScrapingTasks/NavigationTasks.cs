using OpenQA.Selenium.Chrome;
using ScraperSample.Helpers;

namespace ScraperSample.ScrapingTasks;

public static class NavigationTasks
{
    public static ChromeDriver NavigateToSite(this ChromeDriver driver,string url)
    {
        driver.Navigate().GoToUrl(url);
        return driver;
    }

    public static ChromeDriver ClickIfExists(this ChromeDriver driver,SelectorType selectorType, string selectorValue)
    {
        Thread.Sleep(1000);
        var buttonElement = driver.GetFirst(selectorType, selectorValue);
        buttonElement?.Click();
        
        return driver;
    }

    public static ChromeDriver Maximize(this ChromeDriver driver)
    {
        driver.Manage().Window.Maximize();
        return driver;
    }
}