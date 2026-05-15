using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests;

public class ItemManagerTests : IClassFixture<ItemManagerFixture>
{
    private readonly ItemManagerFixture _fixture;

    public ItemManagerTests(ItemManagerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void AddItems_AddItemsToAvailibleInventory_ItemsAdded()
    {
        var itemManagement = _fixture.CreateItemManager();
        var testItem = _fixture.Sulfuras();
        itemManagement.AddItems(new List<Item> { testItem });

        var items = itemManagement.GetItems();
        Assert.Single(items);
        Assert.Contains(testItem, items);
    }

    [Fact]
    public void GetItems_RequestAllItems_ReturnsAllItems()
    {
        var itemManagement = _fixture.CreateItemManager();
        var testItem = _fixture.Sulfuras();
        var testItem2 = _fixture.AgedBrie();
        itemManagement.AddItems(new List<Item> { testItem, testItem2, testItem2 });

        var items = itemManagement.GetItems();
        Assert.NotEmpty(items);
        Assert.Equal(3, items.Count);
        Assert.Contains(testItem, items);
        Assert.Equal(2, items.FindAll(x => x == testItem2).Count);
    }

    [Fact]
    public void UpdateItems_NonPerishableItemSupplied_QualityRemainsUnchanged()
    {
        var itemManagement = _fixture.CreateItemManager();
        var testItem = _fixture.Sulfuras();
        itemManagement.AddItems(new List<Item> { testItem });
        itemManagement.UpdateItems();
        var items = itemManagement.GetItems();
        Assert.Contains(testItem, items);
    }

    [Fact]
    public void UpdateItems_MaturingItemSupplied_QuanityIncreasesUnlessAtLimit()
    {
        var itemManagement = _fixture.CreateItemManager();
        var initQuality = 0;
        var testItem = _fixture.AgedBrie(2, initQuality);
        itemManagement.AddItems(new List<Item> { testItem });
        itemManagement.UpdateItems();
        var items = itemManagement.GetItems();
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
    public void UpdateItems_BackStagePassItemSupplied_QualityChanges(int initSellIn, int initQuality, int expectedQuality)
    {
        var itemManagement = _fixture.CreateItemManager();
        var testItem = _fixture.BackstagePass(initSellIn, initQuality);
        itemManagement.AddItems(new List<Item> { testItem });
        itemManagement.UpdateItems();
        var items = itemManagement.GetItems();
        Assert.Contains(testItem, items);
        Assert.Equal(expectedQuality, items[0].Quality);
    }

    [Theory]
    [InlineData(10, 20, 19)]    // standard decrease applies.
    [InlineData(10, 0, 0)]      // minimum 0 limit applies.
    [InlineData(0, 0, 0)]       // minimum 0 limit applies.
    [InlineData(-1, 10, 8)]     // day-of decrease applies.
    public void UpdateItems_StandardItemSupplied_QuantityDecreasesUnlessAtLimit(int initSellIn, int initQuality, int expectedQuality)
    {
        var itemManagement = _fixture.CreateItemManager();
        var testItem = _fixture.StandardItem(initSellIn, initQuality);
        itemManagement.AddItems(new List<Item> { testItem });
        itemManagement.UpdateItems();
        var items = itemManagement.GetItems();
        Assert.Contains(testItem, items);
        Assert.Equal(expectedQuality, items[0].Quality);
    }

    [Theory]
    [InlineData(10, 12, 10)]    // doubled decay-rate applies.
    [InlineData(100, 1, 0)]     // minimum 0 limit nullifies doubled decay-rate.
    [InlineData(0, 0, 0)]       // minimum 0 limit applies.
    [InlineData(-1, 10, 6)]      // day-of doubled decay-rate applies.
    public void UpdateItems_ConjuredItemSupplied_QuantityDecreasesTwiceAsMuch(int initSellIn, int initQuality, int expectedQuality)
    {
        var itemManagement = _fixture.CreateItemManager();
        var testItem = _fixture.ConjuredItem(initSellIn, initQuality);
        itemManagement.AddItems(new List<Item> { testItem });
        itemManagement.UpdateItems();
        var items = itemManagement.GetItems();
        Assert.Contains(testItem, items);
        Assert.Equal(expectedQuality, items[0].Quality);
    }
}