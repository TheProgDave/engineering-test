

using GildedRose.Console.ItemManagement.ItemSellInUpdaters;

namespace GildedRose.Console.ItemUpdaters
{
    public class ItemSellInUpdater : IItemSellInUpdater
    {
        public void Update(Item item)
        {
            item.SellIn -= 1;
        }
    }
}