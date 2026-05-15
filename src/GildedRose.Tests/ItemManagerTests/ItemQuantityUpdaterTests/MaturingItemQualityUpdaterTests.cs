using GildedRose.Console;
using GildedRose.Console.ItemUpdaters;
using Xunit;

namespace GildedRose.Tests;

public class MaturingItemQualityUpdaterTests
{
    [Fact]
    public void Update_MaturingItem_IncreasesQualityByOne()
    {
        var updater = new MaturingItemQualityUpdater();
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };

        updater.Update(item);

        Assert.Equal(11, item.Quality);
    }
}
