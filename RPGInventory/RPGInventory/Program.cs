using RPGInventory.Models;
using RPGInventory.Inventory;
using RPGInventory.Strategy;
using RPGInventory.Factories;

namespace DeliveryApp;
class Program
{
    static void Main()
    {
        var weaponFactory = new WeaponFactory(50);
        var sword = weaponFactory.CreateItem("Sword", 100);

        var armorFactory = new ArmorFactory(20);
        var shield = armorFactory.CreateItem("Shield", 80);

        var inventory = new InventoryBuilder()
            .AddItem(sword)
            .AddItem(shield)
            .Build();

        inventory.DisplayAll();

        // Использование предметов и улучшение
        sword.Equip();
        var enhance = new WeaponEnhancement(10);
        sword.Enhance(enhance);

        inventory.DisplayAll();
    }
}
