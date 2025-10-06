using VendingMachine.Models;

class Program
{
    
    static void Main(string[] args)
    {
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
        }
        catch
        {
            // Если не поддерживается UTF-8, используем стандартную кодировку
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.InputEncoding = System.Text.Encoding.Default;
        }
    
    var vendingMachine = new VendingMachineSystem();
    bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nВыберите режим:");
            Console.WriteLine("1 - Пользовательский режим");
            Console.WriteLine("2 - Администраторский режим");
            Console.WriteLine("3 - Статус автомата");
            Console.WriteLine("0 - Выход");
            
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    UserMode(vendingMachine);
                    break;
                case "2":
                    AdminMode(vendingMachine);
                    break;
                case "3":
                    vendingMachine.DisplayStatus();
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
    
    static void UserMode(VendingMachineSystem vm)
    {
        bool inUserMode = true;
        
        while (inUserMode)
        {
            Console.WriteLine("\n=== ПОЛЬЗОВАТЕЛЬСКИЙ РЕЖИМ ===");
            Console.WriteLine("1 - Показать товары");
            Console.WriteLine("2 - Внести монету");
            Console.WriteLine("3 - Купить товар");
            Console.WriteLine("4 - Отменить операцию");
            Console.WriteLine("0 - Назад");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    DisplayProducts(vm.GetAvailableProducts());
                    break;
                case "2":
                    InsertCoinDialog(vm);
                    break;
                case "3":
                    PurchaseProductDialog(vm);
                    break;
                case "4":
                    vm.CancelOperation();
                    break;
                case "0":
                    inUserMode = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
    
    static void AdminMode(VendingMachineSystem vm)
    {
        bool inAdminMode = true;
        
        while (inAdminMode)
        {
            Console.WriteLine("\n=== АДМИНИСТРАТОРСКИЙ РЕЖИМ ===");
            Console.WriteLine("1 - Пополнить ассортимент");
            Console.WriteLine("2 - Собрать деньги");
            Console.WriteLine("3 - Пополнить монеты");
            Console.WriteLine("4 - Показать статус");
            Console.WriteLine("0 - Назад");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    AddProductDialog(vm);
                    break;
                case "2":
                    vm.CollectMoney();
                    break;
                case "3":
                    RestockCoinsDialog(vm);
                    break;
                case "4":
                    vm.DisplayStatus();
                    break;
                case "0":
                    inAdminMode = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
    
    static void DisplayProducts(List<Product> products)
    {
        Console.WriteLine("\nДоступные товары:");
        if (products.Count == 0)
        {
            Console.WriteLine("Товары отсутствуют.");
            return;
        }
        
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i]}");
        }
    }
    
    static void InsertCoinDialog(VendingMachineSystem vm)
    {
        Console.WriteLine("Введите номинал монеты (1, 2, 5, 10):");
        if (decimal.TryParse(Console.ReadLine(), out decimal denomination))
        {
            vm.InsertCoin(denomination);
        }
        else
        {
            Console.WriteLine("Неверный формат номинала.");
        }
    }
    
    static void PurchaseProductDialog(VendingMachineSystem vm)
    {
        var products = vm.GetAvailableProducts();
        DisplayProducts(products);
        
        if (products.Count == 0) return;
        
        Console.WriteLine("Введите название товара:");
        string productName = Console.ReadLine();
        
        vm.PurchaseProduct(productName);
    }
    
    static void AddProductDialog(VendingMachineSystem vm)
    {
        Console.WriteLine("Введите название товара:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Введите цену:");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Неверный формат цены.");
            return;
        }
        
        Console.WriteLine("Введите количество:");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Неверный формат количества.");
            return;
        }
        
        vm.AddProduct(name, price, quantity);
    }
    
    static void RestockCoinsDialog(VendingMachineSystem vm)
    {
        Console.WriteLine("Введите номинал монеты:");
        if (!decimal.TryParse(Console.ReadLine(), out decimal denomination))
        {
            Console.WriteLine("Неверный формат номинала.");
            return;
        }
        
        Console.WriteLine("Введите количество:");
        if (!int.TryParse(Console.ReadLine(), out int count))
        {
            Console.WriteLine("Неверный формат количества.");
            return;
        }
        
        vm.RestockCoins(denomination, count);
    }
}