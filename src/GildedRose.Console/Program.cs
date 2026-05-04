namespace GildedRose.Console;

public class Program
{
    private IList<Item> _items = new List<Item>();

    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");
        var app = new Program();

        app.AddItems(new List<Item>
            {
                new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                // (DG) ASSUMPTION: An itemn is "Conjured" if the Name starts with "Conjured".
                new() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            });
        app.UpdateQuality();

        System.Console.ReadKey();
    }

    public void AddItems(List<Item> items)
    {
        _items = items;
    }

    public List<Item> GetItems()
    {
        return _items.ToList();
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {

            // "Sulfuras, Hand of Ragnaros" is unchanging and any item with Quality = 0 needs no adjustment.
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            var rate = 1;
            if (item.Name == "Aged Brie" && item.Quality != 50)
            {
                item.Quality = AdjustQuality(item.Quality, rate);
                continue;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                    continue;
                }
                if (item.SellIn <= 5)
                {
                    item.Quality = AdjustQuality(item.Quality, 3);
                    continue;
                }
                else if (item.SellIn <= 10)
                {
                    item.Quality = AdjustQuality(item.Quality, 2);
                    continue;
                }
                else
                {
                    item.Quality = AdjustQuality(item.Quality, rate);
                    continue;
                }

            }
            item.Quality = AdjustQuality(item.Quality, -rate);
        }
    }

    /* (DG) - This was what I wrote to control quality adjustment limit; but I fed it into Gemini thinking "There is probably a cleaner way to do this"; hence the much simpler actual implementation below using Math.Clamp() ~ cool!
    private int AdjustQuaility(int quality, int adjustment)
    {
        quality += adjustment;
        if (quality < 0)
        {
            quality = 0;
        }
        if (quality > 50)
        {
            quality = 50;
        }
        return quality;
    }
    */
    private int AdjustQuality(int quality, int adjustment)
    {
        return Math.Clamp(quality + adjustment, 0, 50);
    }
}

// Do not modify Item - Golbin will be mad.
public class Item
{
    public string Name { get; set; } = "";

    public int SellIn { get; set; }

    public int Quality { get; set; }
}

/* NOTES:
    - Adding members to 'Item' could have enabled the refactor of the main application logic to be cleaner, less reliant on hard-coded strings, and allowed easier input of new-items.
      i.e. Adding 'public bool NonPerishable {get; set; );', applying NonPerishable = true to "Sulfuras, Hand of Ragnaros", and altering 'UpdateQuality()' to check if true early; Would allow "Sulfuras, Hand of Ragnaros" skipped, with no explicit Name-checking or further handling required. 
    - Observation: "Sulfuras, Hand of Ragnaros" is being exempt from SellIn reductions; and loosely makes sense with its other qualities, but this stands as an ASSUMPTION rather than something confirmed in requirements. Would usually seek clarification here.
    - It would have been much-preferred to be able to move the 'Item' class to it's own file.
 */
