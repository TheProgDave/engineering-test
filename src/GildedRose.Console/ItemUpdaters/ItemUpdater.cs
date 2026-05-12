namespace GildedRose.Console.ItemUpdaters
{
    public abstract class ItemUpdater : IItemUpdater
    {
        
        private readonly int _minQuality = 0;

        private readonly int _maxQuality = 50;
        
        public abstract void Update(Item item);

        protected void AdjustQuality(Item item, int amount)
        {
            item.Quality = Math.Clamp(item.Quality + amount, _minQuality, _maxQuality);
        }
    }
}
