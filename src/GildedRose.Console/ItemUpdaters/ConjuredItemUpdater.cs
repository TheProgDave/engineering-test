namespace GildedRose.Console.ItemUpdaters
{
    public class ConjuredItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            AdjustQuality(item, -2);
        }
    }
}
