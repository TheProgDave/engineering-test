namespace GildedRose.Console.ItemUpdaters
{
    public abstract class ItemUpdater
    {
        public abstract void Update(Item item);

        protected void AdjustQuality(Item item, int amount)
        {
            item.Quality = Math.Clamp(item.Quality + amount, 0, 50);
        }
    }
}
