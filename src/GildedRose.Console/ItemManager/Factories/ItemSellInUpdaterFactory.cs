using GildedRose.Console.ItemUpdaters;
using GildedRose.Console.ItemManagement.ItemSellInUpdaters;

namespace GildedRose.Console.ItemFactory
{
    public class ItemSellInUpdaterFactory
    {
        private readonly IItemSellInUpdater _standardItemUpdater = new ItemSellInUpdater();
        private readonly IItemSellInUpdater _imperishableItemSellInUpdater = new ImperishableItemSellInUpdater();

        public IItemSellInUpdater GetItemSellInUpdater(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return _imperishableItemSellInUpdater;
                default:
                    return _standardItemUpdater;
            }
        }
    }
}
