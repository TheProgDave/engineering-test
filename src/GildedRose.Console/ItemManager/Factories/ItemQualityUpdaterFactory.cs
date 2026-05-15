using GildedRose.Console.ItemUpdaters;

namespace GildedRose.Console.ItemFactory
{
    public class ItemUpdaterFactory
    {

        private readonly IItemQualityUpdater _maturingItemUpdater = new MaturingItemQualityUpdater();
        private readonly IItemQualityUpdater _concertTicketItemUpdater = new ConcertTicketItemQualityUpdater();
        private readonly IItemQualityUpdater _conjuredItemUpdater = new ConjuredItemQualityUpdater();
        private readonly IItemQualityUpdater _standardItemUpdater = new StandardItemQualityUpdater();

        private readonly IItemQualityUpdater _imperishableItemQualityUpdater = new ImperishableItemQualityUpdater();
           
        public IItemQualityUpdater GetItemQualityUpdater(Item item) 
        {
            switch (item.Name) 
            {
                case "Aged Brie":
                    return _maturingItemUpdater;
                case "Backstage passes to a TAFKAL80ETC concert":
                    return _concertTicketItemUpdater;
                case "Conjured Mana Cake":
                    return _conjuredItemUpdater;
                case "Sulfuras, Hand of Ragnaros":
                    return _imperishableItemQualityUpdater;
                default:
                    return _standardItemUpdater;
            }
        }
    }
}
