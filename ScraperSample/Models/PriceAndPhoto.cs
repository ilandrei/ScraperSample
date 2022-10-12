namespace ScraperSample.Models;

public class PriceAndName
{
    public PriceAndName(string price, string name)
    {
        Price = price;
        Name = name;
    }

    public string Price { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Price:{Price} , Name: {Name}";
    }
}