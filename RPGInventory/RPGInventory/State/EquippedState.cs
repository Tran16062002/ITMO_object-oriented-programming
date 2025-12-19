using RPGInventory.Models;

namespace RPGInventory.State
{
    public class EquippedState : IItemState
    {
        public void Equip(Item item) { /* уже экипировано */ }
        public void Unequip(Item item) => item.SetState(new UnequippedState());
        public string GetState() => "Equipped";
    }
}
