using GildedRose.Console.ItemUpdaters;

namespace GildedRose.Console.ItemFactory
{
    public class ItemUpdaterFactory
    {

        private readonly IItemUpdater _maturingItemUpdater = new MaturingItemUpdater();
        private readonly IItemUpdater _concertTicketItemUpdater = new ConcertTicketItemUpdater();
        private readonly IItemUpdater _conjuredItemUpdater = new ConjuredItemUpdater();
        private readonly IItemUpdater _standardItemUpdater = new StandardItemUpdater();
           
        public IItemUpdater GetItemUpdater(Item item) 
        {
            switch (item.Name) 
            {
                case "Aged Brie":
                    return _maturingItemUpdater;
                case "Backstage passes to a TAFKAL80ETC concert":
                    return _concertTicketItemUpdater;
                case "Conjured Mana Cake":
                    return _conjuredItemUpdater;
                default:
                    return _standardItemUpdater;
            }
        }
    }
}
