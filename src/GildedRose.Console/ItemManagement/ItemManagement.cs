using GildedRose.Console.ItemFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class ItemManagement
    {

        private IList<Item> _items = new List<Item>();
        public ItemUpdaterFactory _itemUpdaterFactory = new ItemUpdaterFactory();

        // TODO DG: write constructor

        public void AddItems(List<Item> items)
        {
            _items = items;
        }

        public List<Item> GetItems()
        {
            return _items.ToList();
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var itemQualityUpdater = _itemUpdaterFactory.GetItemQualityUpdater(item);
                itemQualityUpdater.Update(item);
            }
        }
    }
}
