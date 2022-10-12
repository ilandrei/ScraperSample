using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScraperSample.Helpers;
using ScraperSample.Models;

namespace ScraperSample.Workflows;

public static class ReadPricesAndNamesTillEndWorkflow
{
    private const string NextButtonClass = "js-next-page";
    private const string CardClass = "card-item";
    private const string PriceClass = "product-new-price";
    private const string FilterClass = "quick-filter";
    public static IEnumerable<PriceAndName> ReadPriceAndNamesTillEndRun(this ChromeDriver driver)
    {
        var returnList = new List<PriceAndName>();
        IWebElement? nextButton = null;
        
        driver.FindElements(By.ClassName(FilterClass))
            .FirstOrDefault(e => e.Text.Contains("128"))?.Click();
        Thread.Sleep(2000);
        do
        {
            var cardItems = driver.FindElements(By.ClassName(CardClass));
            if (cardItems != null)
            {
                returnList.AddRange(cardItems?.Select(cardItem =>
                        {
                            var price = cardItem.FindElements(By.ClassName(PriceClass)).FirstOrDefault()?.Text;
                            var name = cardItem.GetAttribute("data-name");
                            if (name != null && price != null)
                            {
                                return new PriceAndName(price, name);
                            }

                            return null;
                        })
                        .Where(item => item != null)!
                );
            }
           
            
            Thread.Sleep(2000);
            nextButton?.Click();
            Thread.Sleep(2000);
            nextButton = driver.GetFirst(SelectorType.Class,NextButtonClass);
        } while (nextButton != null);
        
        return returnList;
    }
}