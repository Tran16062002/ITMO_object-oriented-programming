using RPGInventory.Strategy;
namespace RPGInventory.Models
{
    public class Weapon : Item
    {
        public int Damage { get; private set; }

        public Weapon(string name, int damage, int value) : base(name, value)
        {
            Damage = damage;
        }

        public override void Enhance(IEnhancementStrategy strategy)
        {
            strategy.Enhance(this);
        }

        public override void DisplayInfo()
        {
            System.Console.WriteLine($"Weapon: {Name}, Damage: {Damage}, Level: {Level}, State: {GetState()}");
        }

        public void IncreaseDamage(int amount) => Damage += amount;
    }
}
