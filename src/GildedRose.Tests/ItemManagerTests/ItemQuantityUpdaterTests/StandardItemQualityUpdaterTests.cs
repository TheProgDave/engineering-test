using GildedRose.Console;
using GildedRose.Console.ItemUpdaters;
using Xunit;

namespace GildedRose.Tests;

public class StandardItemQualityUpdaterTests
{
    [Fact]
    public void Update_StandardItemWithPositiveSellIn_DecreasesQualityByOne()
    {
        var updater = new StandardItemQualityUpdater();
        var item = new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 10 };

        updater.Update(item);

        Assert.Equal(9, item.Quality);
    }

    [Fact]
    public void Update_StandardItemWithNegativeSellIn_DecreasesQualityByTwoOnceSellInIsNegative()
    {
        var updater = new StandardItemQualityUpdater();
        var item = new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 10 };

        updater.Update(item);

        Assert.Equal(8, item.Quality);
    }
}
