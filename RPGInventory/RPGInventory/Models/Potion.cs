using RPGInventory.Strategy;
using RPGInventory.State;
namespace RPGInventory.Models
{
    public class Potion : Item
    {
        public int HealAmount { get; private set; }

        public Potion(string name, int healAmount, int value) : base(name, value)
        {
            HealAmount = healAmount;
        }

        public override void Enhance(IEnhancementStrategy strategy)
        {

        }

        public override void DisplayInfo()
        {
            System.Console.WriteLine($"Potion: {Name}, Heal: {HealAmount}, State: {GetState()}");
        }
    }
}
