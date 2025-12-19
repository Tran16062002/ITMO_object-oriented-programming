using RPGInventory.Models;

namespace RPGInventory.Strategy
{
    public class ArmorEnhancement : IEnhancementStrategy
    {
        private int increment;

        public ArmorEnhancement(int increment) => this.increment = increment;

        public void Enhance(Item item)
        {
            if (item is Armor armor)
            {
                armor.IncreaseDefense(increment);
                armor.IncreaseLevel();
            }
        }
    }
}
