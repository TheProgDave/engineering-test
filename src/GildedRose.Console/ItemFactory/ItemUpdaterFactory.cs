using GildedRose.Console.ItemUpdaters;

namespace GildedRose.Console.ItemFactory
{
    public class ItemUpdaterFactory
    {
        public ItemUpdater GetItemUpdater(Item item) 
        {
            switch (item.Name) 
            {
                case "Aged Brie":
                    return new MaturingItemUpdater();
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new ConcertTicketItemUpdater();
                case "Conjured Mana Cake":
                    return new ConjuredItemUpdater();
                default:
                    return new StandardItemUpdater();
            }
        }
    }
}
