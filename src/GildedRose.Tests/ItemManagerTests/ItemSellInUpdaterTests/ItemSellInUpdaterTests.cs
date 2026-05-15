using GildedRose.Console;
using GildedRose.Console.ItemUpdaters;
using Xunit;

namespace GildedRose.Tests;

public class ItemSellInUpdaterTests
{
    [Fact]
    public void Update_DecreasesSellInByOne()
    {
        var updater = new ItemSellInUpdater();
        var item = new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 10 };

        updater.Update(item);

        Assert.Equal(4, item.SellIn);
    }
}
