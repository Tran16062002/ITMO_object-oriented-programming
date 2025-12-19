using RPGInventory.State;

namespace RPGInventory.Models
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; } = 1;
        public int Value { get; protected set; }
        public IItemState State { get; private set; }

        protected Item(string name, int value)
        {
            Name = name;
            Value = value;
            State = new UnequippedState();
        }

        public void Equip() => State.Equip(this);
        public void Unequip() => State.Unequip(this);
        public string GetState() => State.GetState();

        public void SetState(IItemState state) => State = state;

        public void IncreaseLevel(int amount = 1)
        {
            Level += amount;
        }

        public abstract void Enhance(Strategy.IEnhancementStrategy strategy);
        public abstract void DisplayInfo();
    }
}
