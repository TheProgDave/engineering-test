namespace GildedRose.Console;

public class Program
{
    private IList<Item> Items = new List<Item>();

    static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program()
        {
            Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                // (DG) ASSUMPTION: An itemn is "Conjured" if the Name starts with "Conjured".
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            }

        };

        app.UpdateQuality();

        System.Console.ReadKey();
    }

    public void AddItems(List<Item> items)
    {
        Items = items;
    }

    public List<Item> GetItems()
    {
        return Items.ToList();
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            // "Sulfuras, Hand of Ragnaros" will always have a `Quailty = 80` and `SellIn = 0`.
            if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0)
                {
                    //if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    //{
                    Items[i].Quality = Items[i].Quality - 1;
                    //}
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            //if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            //{
            //    Items[i].SellIn = Items[i].SellIn - 1;
            //}

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            //if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            //{
                            Items[i].Quality = Items[i].Quality - 1;
                            //}
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
            }
        }
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
 */
