namespace GildedRose.Console.ItemUpdaters
{
    public class MaturingItemQualityUpdater : ItemQualityUpdater
    {
        public override void Update(Item item)
        {
            AdjustQuality(item, 1);            
        }
    }
}
