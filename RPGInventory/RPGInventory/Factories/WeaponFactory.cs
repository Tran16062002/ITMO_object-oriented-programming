using RPGInventory.Models;

namespace RPGInventory.Factories
{
    public class WeaponFactory : IItemFactory
    {
        private int damage;

        public WeaponFactory(int damage) => this.damage = damage;

        public Item CreateItem(string name, int value) => new Weapon(name, damage, value);
    }
}
