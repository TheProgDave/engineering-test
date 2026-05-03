using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests;

public class TestAssemblyTests
{

    [Fact]
    public void AddItems_AddItemsToAvailibleInventory_ItemsAdded()
    {
        // TODO: DG refactor into fixture.
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
        // TODO: DG refactor into fixture.
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
}