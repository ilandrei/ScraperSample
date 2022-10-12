using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScraperSample.Helpers;

namespace ScraperSample.ScrapingTasks;

public static class SearchTasks
{
    public static ChromeDriver FillInput(this ChromeDriver driver,
        SelectorType selectorType,
        string selectorValue, string searchPhrase)
    {
        var inputElement = driver.GetFirst(selectorType, selectorValue);
        inputElement?.Clear();
        inputElement?.SendKeys(searchPhrase);
        
        return driver;
    }

    public static ChromeDriver SubmitInput(this ChromeDriver driver, SelectorType selectorType,
        string selectorValue)
    {

        var inputElement = driver.GetFirst(selectorType, selectorValue);
        inputElement?.Submit();
            
        return driver;
    }
}