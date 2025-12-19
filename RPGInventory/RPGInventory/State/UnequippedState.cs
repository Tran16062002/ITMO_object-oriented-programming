using RPGInventory.Models;

namespace RPGInventory.State
{
    public class UnequippedState : IItemState
    {
        public void Equip(Item item) => item.SetState(new EquippedState());
        public void Unequip(Item item) { /* уже не экипировано */ }
        public string GetState() => "Unequipped";
    }
}
