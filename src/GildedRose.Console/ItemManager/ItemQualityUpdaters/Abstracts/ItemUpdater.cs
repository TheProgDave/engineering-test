namespace GildedRose.Console.ItemUpdaters
{
    public abstract class ItemQualityUpdater : IItemQualityUpdater
    {
        
        private readonly int _minQuality = 0;

        private readonly int _maxQuality = 50;
        
        public abstract void Update(Item item);

        /* (DG) - This was what I wrote to control quality adjustment limit; but I fed it into Gemini thinking "There is probably a cleaner way to do this"; hence the much simpler actual implementation below using Math.Clamp() ~ cool!
        private int AdjustQuaility(int quality, int adjustment)
        {
            quality += adjustment;
            if (quality < 0)
            {
                quality = 0;
            }
            if (quality > 50)
            {
                quality = 50;
            }
            return quality;
        }
        */
        protected void AdjustQuality(Item item, int amount)
        {
            if (amount < 0 && item.SellIn < 0)
            {
                amount *= 2;
            }
            
            item.Quality = Math.Clamp(item.Quality + amount, _minQuality, _maxQuality);
        }
    }
}
