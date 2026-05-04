namespace GildedRose.Console.ItemUpdaters
{
    public class StandardItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            // "Sulfuras, Hand of Ragnaros" is unchanging and any item with Quality = 0 needs no adjustment.
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }
            AdjustQuality(item, -1);
        }
    }
}
