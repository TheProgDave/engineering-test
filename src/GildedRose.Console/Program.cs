using GildedRose.Console.ItemFactory;

namespace GildedRose.Console;

public class Program
{
    private IList<Item> _items = new List<Item>();
    public ItemUpdaterFactory _itemUpdaterFactory = new ItemUpdaterFactory();

    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");
        var app = new Program();
        // (DG) ASSUMPTION: In an exercise, changing the item-list out for proper feels like it misses the point. However, in a real-world scenario, modifying that list would be essential.
        app.AddItems( new List<Item>
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
            var itemUpdater = _itemUpdaterFactory.GetItemUpdater(item);
            itemUpdater.Update(item);
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
    - Used Gemini to see if I could further refine the main-loop; use of Strategy and Factory patterns were suggested; Full disclamer - I'd seen plenty of examples of the Factory pattern prior (It usually helps that they are named as such) but I hadn't been aware of the Strategy pattern; this prompted some reseach into basic implementations. 
    - The unit tests written fairly early into my editing of this code-base proved invalueable when performing the various refactors; this was not proper TDD - but harnessed some of the power of the approach.
 */
