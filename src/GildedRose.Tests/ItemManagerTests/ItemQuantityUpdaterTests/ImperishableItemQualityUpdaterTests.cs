using GildedRose.Console;
using GildedRose.Console.ItemUpdaters;
using Xunit;

namespace GildedRose.Tests;

public class ImperishableItemQualityUpdaterTests
{
    [Fact]
    public void Update_ImperishableItem_DoesNotChangeQuality()
    {
        var updater = new ImperishableItemQualityUpdater();
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

        updater.Update(item);

        Assert.Equal(80, item.Quality);
    }
}
