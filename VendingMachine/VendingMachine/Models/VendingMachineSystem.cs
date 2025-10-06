namespace VendingMachine.Models
{
    public class VendingMachineSystem
    {
        private List<Product> _products;
        private Dictionary<decimal, int> _coins;
        private decimal _currentBalance;
        private decimal _collectedMoney;
        private int _productCounter;

        public VendingMachineSystem()
        {
            _products = new List<Product>();
            _coins = new Dictionary<decimal, int>
            {
                { 1, 10 },
                { 2, 10 },
                { 5, 10 },
                { 10, 10 }
            };
            _currentBalance = 0;
            _collectedMoney = 0;
            _productCounter = 1;
        }


        public void AddProduct(string name, decimal price, int quantity)
        {
            var existingProduct = _products.FirstOrDefault(p => 
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity;
            }
            else
            {
                string productId = $"P{_productCounter:000}";
                _productCounter++;
                _products.Add(new Product(productId, name, price, quantity));
            }

            Console.WriteLine($"Товар '{name}' добавлен/обновлен.");
        }

        public void InsertCoin(decimal denomination)
        {
            if (_coins.ContainsKey(denomination))
            {
                _coins[denomination]++;
                _currentBalance += denomination;
                Console.WriteLine($"Внесено: {denomination:C}");
            }
            else
            {
                Console.WriteLine("Неверный номинал монеты.");
            }
        }

        public List<Product> GetAvailableProducts()
        {
            return _products.Where(p => p.Quantity > 0).ToList();
        }

        public Product PurchaseProduct(string productName)
        {
            var product = _products.FirstOrDefault(p => 
                p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase) && p.Quantity > 0);

            if (product == null)
            {
                Console.WriteLine("Товар не найден.");
                return null;
            }

            if (_currentBalance < product.Price)
            {
                Console.WriteLine("Недостаточно средств.");
                return null;
            }

            product.Quantity--;
            _currentBalance -= product.Price;
            _collectedMoney += product.Price;
            Console.WriteLine($"Вы купили: {product.Name}");

            return product;
        }

        public decimal CancelOperation()
        {
            decimal change = _currentBalance;
            Console.WriteLine($"Операция отменена. Возвращено: {change:C}");
            _currentBalance = 0;
            return change;
        }

        public void RestockCoins(decimal denomination, int count)
        {
            if (_coins.ContainsKey(denomination))
            {
                _coins[denomination] += count;
                Console.WriteLine($"Монеты номиналом {denomination:C} пополнены на {count} шт.");
            }
            else
            {
                Console.WriteLine("Неверный номинал монеты.");
            }
        }

        public void CollectMoney()
        {
            Console.WriteLine($"Собрано денег: {_collectedMoney:C}");
            _collectedMoney = 0;
        }

        public void DisplayStatus()
        {
            Console.WriteLine("\n=== СТАТУС АВТОМАТА ===");
            Console.WriteLine($"Текущий баланс: {_currentBalance:C}");
            Console.WriteLine($"Собранные деньги: {_collectedMoney:C}");
            
            Console.WriteLine("\nТовары:");
            foreach (var product in _products)
            {
                Console.WriteLine($"  {product}");
            }
            
            Console.WriteLine("\nМонеты:");
            foreach (var coin in _coins)
            {
                Console.WriteLine($"  {coin.Key:C} - {coin.Value} шт.");
            }
        }

        public decimal GetCurrentBalance()
        {
            return _currentBalance;
        }

        public decimal GetCollectedMoney()
        {
            return _collectedMoney;
        }

        public Dictionary<decimal, int> GetCoins()
        {
            return new Dictionary<decimal, int>(_coins);
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(_products);
        }

        public void SetBalance(decimal balance)
        {
            _currentBalance = balance;
        }

        public void SetCollectedMoney(decimal amount)
        {
            _collectedMoney = amount;
        }
    }
}