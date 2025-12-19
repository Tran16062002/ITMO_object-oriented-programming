using System.Collections.Generic;
using RPGInventory.Models;

namespace RPGInventory.Inventory
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item) => items.Add(item);
        public void RemoveItem(Item item) => items.Remove(item);
        public IEnumerable<Item> GetItems() => items.AsReadOnly();

        public void DisplayAll()
        {
            foreach (var item in items)
                item.DisplayInfo();
        }
    }
}
