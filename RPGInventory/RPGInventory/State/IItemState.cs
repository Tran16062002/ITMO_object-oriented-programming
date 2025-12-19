using RPGInventory.Models;

namespace RPGInventory.State
{
    public interface IItemState
    {
        void Equip(Item item);
        void Unequip(Item item);
        string GetState();
    }
}
