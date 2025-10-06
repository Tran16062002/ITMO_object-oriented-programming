namespace VendingMachine.Models
{
    public class Product
    {
        public Product(string id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name} - {Price:C} (Осталось: {Quantity})";
        }
    }
}