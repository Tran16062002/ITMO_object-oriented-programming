using RPGInventory.Strategy;
namespace RPGInventory.Models
{
    public class QuestItem : Item
    {
        public string QuestName { get; private set; }

        public QuestItem(string name, string questName, int value) : base(name, value)
        {
            QuestName = questName;
        }

        public override void Enhance(IEnhancementStrategy strategy)
        {

        }

        public override void DisplayInfo()
        {
            System.Console.WriteLine($"QuestItem: {Name}, Quest: {QuestName}, State: {GetState()}");
        }
    }
}
