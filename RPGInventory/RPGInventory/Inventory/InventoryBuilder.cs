using RPGInventory.Models;
using System.Collections.Generic;

namespace RPGInventory.Inventory
{
    public class InventoryBuilder
    {
        private Inventory inventory = new Inventory();

        public InventoryBuilder AddItem(Item item)
        {
            inventory.AddItem(item);
            return this;
        }

        public Inventory Build() => inventory;
    }
}
