namespace GildedRose.Console.ItemUpdaters
{
    public class ConjuredItemQualityUpdater : ItemQualityUpdater
    {
        public override void Update(Item item)
        {
            AdjustQuality(item, -2);
        }
    }
}
