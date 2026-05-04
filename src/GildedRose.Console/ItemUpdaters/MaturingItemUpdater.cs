namespace GildedRose.Console.ItemUpdaters
{
    public class MaturingItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            AdjustQuality(item, 1);            
        }
    }
}
