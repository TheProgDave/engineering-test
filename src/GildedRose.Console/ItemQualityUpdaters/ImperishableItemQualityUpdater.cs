namespace GildedRose.Console.ItemUpdaters
{
    public class ImperishableItemQualityUpdater : ItemQualityUpdater
    {
        public override void Update(Item item)
        {
            // Imperishable items like "Sulfuras, Hand of Ragnaros" do not degrade.
            return;
        }
    }
}
