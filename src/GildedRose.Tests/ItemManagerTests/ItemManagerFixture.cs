using GildedRose.Console;

namespace GildedRose.Tests;

public class ItemManagerFixture
{
    public ItemManager CreateItemManager() => new ItemManager();

    public Item Sulfuras() => new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

    public Item AgedBrie(int sellIn = 2, int quality = 0) => new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };

    public Item BackstagePass(int sellIn, int quality) => new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };

    public Item StandardItem(int sellIn, int quality) => new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };

    public Item ConjuredItem(int sellIn, int quality) => new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality };
}
