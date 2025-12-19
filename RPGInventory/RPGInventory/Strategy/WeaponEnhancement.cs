using RPGInventory.Models;

namespace RPGInventory.Strategy
{
    public class WeaponEnhancement : IEnhancementStrategy
    {
        private int increment;

        public WeaponEnhancement(int increment) => this.increment = increment;

        public void Enhance(Item item)
        {
            if (item is Weapon weapon)
            {
                weapon.IncreaseDamage(increment);
                weapon.IncreaseLevel();
            }
        }
    }
}
