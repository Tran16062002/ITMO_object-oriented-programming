using RPGInventory.Models;

namespace RPGInventory.Factories
{
    public class ArmorFactory : IItemFactory
    {
        private int defense;

        public ArmorFactory(int defense) => this.defense = defense;

        public Item CreateItem(string name, int value) => new Armor(name, defense, value);
    }
}
