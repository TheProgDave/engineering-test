using GildedRose.Console;
using GildedRose.Console.ItemUpdaters;
using Xunit;

namespace GildedRose.Tests;

public class ConcertTicketItemQualityUpdaterTests
{
    [Fact]
    public void Update_ConcertTicketItemWithSellInFiveOrLess_IncreasesQualityByThreeWhenSellInIsFiveOrLess()
    {
        var updater = new ConcertTicketItemQualityUpdater();
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };

        updater.Update(item);

        Assert.Equal(13, item.Quality);
    }
}
