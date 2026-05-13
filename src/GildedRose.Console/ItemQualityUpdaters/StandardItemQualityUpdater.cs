namespace GildedRose.Console.ItemUpdaters
{
    public class StandardItemQualityUpdater : ItemQualityUpdater
    {
        public override void Update(Item item)
        {
           AdjustQuality(item, -1);
        }
    }
}
