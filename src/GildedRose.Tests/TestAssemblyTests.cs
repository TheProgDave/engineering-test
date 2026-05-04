using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests;

public class TestAssemblyTests
{

    [Fact]
    public void AddItems_AddItemsToAvailibleInventory_ItemsAdded()
    {
        // TODO: (DG) refactor into fixture.
        var app = new Program();
        var testItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        app.AddItems(new List<Item> { testItem });

        var items = app.GetItems();
        Assert.Single(items);
        Assert.Contains(testItem, items);
    }

    [Fact]
    public void GetItems_RequestAllItems_ReturnsAllItems()
    {
        // TODO: (DG) refactor into fixture.
        var app = new Program();
        var testItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var testItem2 = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
        app.AddItems(new List<Item> { testItem, testItem2, testItem2 });

        var items = app.GetItems();
        Assert.NotEmpty(items);
        Assert.Equal(3, items.Count);
        Assert.Contains(testItem, items);
        Assert.Equal(2, items.FindAll(x => x == testItem2).Count);
    }

    [Fact]
    public void UpdateQuality_NonPerishableItemSupplied_QualityRemainsUnchanged()
    {
        // TODO: (DG) refactor into fixture.
        var app = new Program();
        var testItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        app.AddItems(new List<Item> { testItem });
        app.UpdateQuality();
        var items = app.GetItems();
        Assert.Contains(testItem, items);
    }

    [Fact]
    public void UpdateQuality_MaturingItemSupplied_QuanityIncreasesUnlessAtLimit()
    {
        // TODO: (DG) refactor into fixture.
        var app = new Program();
        var initQuality = 0;
        var testItem = new Item { Name = "Aged Brie", SellIn = 2, Quality = initQuality };
        app.AddItems(new List<Item> { testItem });
        app.UpdateQuality();
        var items = app.GetItems();
        Assert.Contains(testItem, items);
        Assert.Equal(initQuality + 1, items[0].Quality);
    }

    [Theory]
    [InlineData(11, 14, 15)]    // standard increase applies.
    [InlineData(10, 13, 15)]    // upper boundary of +2 increase.
    [InlineData(6, 13, 15)]     // lower boundary of +2 increase.
    [InlineData(5, 12, 15)]     // upper boundary of +3 increase.
    [InlineData(1, 12, 15)]     // lower boundary of +3 increase.
    [InlineData(0, 50, 0)]      // day-of decrease applies.
    [InlineData(2, 49, 50)]     // maximum 50 limit applies.
    public void UpdateQuality_BackStagePassItemSupplied_Quality(int initSellIn, int initQuality, int expectedQuality)
    {
        // TODO: (DG) refactor into fixture.
        var app = new Program();
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = initSellIn, Quality = initQuality };
        app.AddItems(new List<Item> { testItem });
        app.UpdateQuality();
        var items = app.GetItems();
        Assert.Contains(testItem, items);
        Assert.Equal(expectedQuality, items[0].Quality);
    }

    [Theory]
    [InlineData(10, 20, 19)]    // standard decrease applies.
    [InlineData(10, 0, 0)]      // minimum 0 limit applies.
    [InlineData(0, 0, 0)]       // minimum 0 limit applies.
    public void UpdateQuality_StandardItemSupplied_QuantityDecreasesUnlessAtLimit(int initSellIn, int initQuality, int expectedQuality)
    {
        // TODO: (DG) refactor into fixture.
        var app = new Program();
        var testItem = new Item { Name = "+5 Dexterity Vest", SellIn = initSellIn, Quality = initQuality };
        app.AddItems(new List<Item> { testItem });
        app.UpdateQuality();
        var items = app.GetItems();
        Assert.Contains(testItem, items);
        Assert.Equal(expectedQuality, items[0].Quality);
    }

    [Theory]
    [InlineData(10, 12, 10)]    // doubled decay-rate applies.
    [InlineData(100, 1, 0)]     // minimum 0 limit nullifies doubled decay-rate.
    [InlineData(0, 0, 0)]       // minimum 0 limit applies.
    public void UpdateQuality_ConjuredItemSupplied_QuantityDecreasesTwiceAsMuch(int initSellIn, int initQuality, int expectedQuality)
    {
        // TODO: (DG) refactor into fixture.
        var app = new Program();
        var testItem = new Item { Name = "Conjured Mana Cake", SellIn = initSellIn, Quality = initQuality };
        app.AddItems(new List<Item> { testItem });
        app.UpdateQuality();
        var items = app.GetItems();
        Assert.Contains(testItem, items);
        Assert.Equal(expectedQuality, items[0].Quality);
    }
}