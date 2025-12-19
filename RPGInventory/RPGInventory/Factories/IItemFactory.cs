using RPGInventory.Models;

namespace RPGInventory.Factories
{
    public interface IItemFactory
    {
        Item CreateItem(string name, int value);
    }
}
