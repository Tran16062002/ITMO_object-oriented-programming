using RPGInventory.Models;
using RPGInventory.Inventory;
using RPGInventory.Strategy;
using RPGInventory.Factories;

namespace RPGInventory.Tests
{
    public class InventoryTests
    {
        public void TestWeaponEnhancement()
        {
            var factory = new WeaponFactory(50);
            var sword = (Weapon)factory.CreateItem("Sword", 100);

            var strategy = new WeaponEnhancement(10);
            sword.Enhance(strategy);

            Assert.Equal(60, sword.Damage);
            Assert.Equal(2, sword.Level);
        }

        public void TestEquipAndUnequip()
        {
            var weapon = new Weapon("Axe", 40, 90);

            Assert.Equal("Unequipped", weapon.GetState());

            weapon.Equip();
            Assert.Equal("Equipped", weapon.GetState());

            weapon.Unequip();
            Assert.Equal("Unequipped", weapon.GetState());
        }

        public void TestInventoryBuilder()
        {
            var sword = new Weapon("Sword", 50, 100);
            var shield = new Armor("Shield", 20, 80);

            var inventory = new InventoryBuilder()
                .AddItem(sword)
                .AddItem(shield)
                .Build();

            Assert.Equal(2, inventory.GetItems().Count());
        }
    }
}
