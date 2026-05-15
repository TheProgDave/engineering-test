using GildedRose.Console.ItemManagement.ItemSellInUpdaters;

namespace GildedRose.Console.ItemUpdaters
{
    public class ImperishableItemSellInUpdater : IItemSellInUpdater
    {
        public void Update(Item item)
        {
            // Imperishable items (like Sulfuras) don't change SellIn
        }
    }
}
