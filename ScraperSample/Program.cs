using OpenQA.Selenium.Chrome;
using ScraperSample.Helpers;
using ScraperSample.ScrapingTasks;
using ScraperSample.Workflows;

const string baseUrl = "https://www.emag.ro";

const string initialModalButtonXPath = "/html/body/div[7]/div/div/div[2]/a[2]";
const string searchBarId = "searchboxTrigger";
const string phraseToSearch = "samsung galaxy s22";
var pricesAndNames = new ChromeDriver()
    .Maximize()
    .NavigateToSite(baseUrl)
    .ClickIfExists(SelectorType.XPath,initialModalButtonXPath)
    .FillInput(SelectorType.Id,searchBarId,phraseToSearch)
    .SubmitInput(SelectorType.Id,searchBarId)
    .ClickIfExists(SelectorType.XPath,"/html/body/div[8]/div/div[2]/button[1]")
    .ClickIfExists(SelectorType.XPath,"/html/body/div[8]/div/button")
    .ReadPriceAndNamesTillEndRun();
foreach (var pricesAndName in pricesAndNames)
{
    Console.WriteLine(pricesAndName);
}
Thread.Sleep(5000);