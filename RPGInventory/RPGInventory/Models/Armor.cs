using RPGInventory.Strategy;

namespace RPGInventory.Models
{
    public class Armor : Item
    {
        public int Defense { get; private set; }

        public Armor(string name, int defense, int value) : base(name, value)
        {
            Defense = defense;
        }

        public override void Enhance(IEnhancementStrategy strategy)
        {
            strategy.Enhance(this);
        }

        public override void DisplayInfo()
        {
            System.Console.WriteLine($"Armor: {Name}, Defense: {Defense}, Level: {Level}, State: {GetState()}");
        }

        public void IncreaseDefense(int amount) => Defense += amount;
    }
}
