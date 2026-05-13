namespace GildedRose.Console.ItemUpdaters
{
    public class ConcertTicketItemQualityUpdater : ItemQualityUpdater
    {
        public override void Update(Item item)
        {

            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn <= 5)
            {
                AdjustQuality(item, 3);
            }
            else if (item.SellIn <= 10)
            {
                AdjustQuality(item, 2);
            }
            else
            {
                AdjustQuality(item, 1);
            }
        }
    }
}
