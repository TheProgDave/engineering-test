using GildedRose.Console;
using GildedRose.Console.ItemUpdaters;
using Xunit;

namespace GildedRose.Tests;

public class ConjuredItemQualityUpdaterTests
{
    [Fact]
    public void Update_ConjuredItemWithPositiveSellIn_DecreasesQualityByTwo()
    {
        var updater = new ConjuredItemQualityUpdater();
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 10 };

        updater.Update(item);

        Assert.Equal(8, item.Quality);
    }

    [Fact]
    public void Update_ConjuredItemWithNegativeSellIn_DecreasesQualityByFourOnceSellInIsNegative()
    {
        var updater = new ConjuredItemQualityUpdater();
        var item = new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 10 };

        updater.Update(item);

        Assert.Equal(6, item.Quality);
    }
}
