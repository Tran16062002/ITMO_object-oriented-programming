using VendingMachine.Models;


namespace VendingMachine.Tests
{
    public class VendingMachineSystemTests
    {
        [Fact]
        public void InsertCoin_ValidDenomination_ShouldIncreaseBalance()
        {
            // Arrange
            var vm = new VendingMachineSystem();
            decimal initialBalance = vm.GetCurrentBalance();
            decimal coinDenomination = 5;

            // Act
            vm.InsertCoin(coinDenomination);

            // Assert
            Assert.Equal(initialBalance + coinDenomination, vm.GetCurrentBalance());
        }

        [Fact]
        public void GetAvailableProducts_WhenCalled_ShouldReturnProductList()
        {
            // Arrange
            var vm = new VendingMachineSystem();

            // Act
            var products = vm.GetAvailableProducts();

            // Assert
            Assert.NotNull(products);
            Assert.IsType<List<Product>>(products);
        }

        [Fact]
        public void PurchaseProduct_WithSufficientBalance_ShouldReturnProduct()
        {
            // Arrange
            var vm = new VendingMachineSystem();
            string productName = "Cola";
            decimal productPrice = 10;
            
            vm.AddProduct(productName, productPrice, 1);
            vm.InsertCoin(10);

            // Act
            var result = vm.PurchaseProduct(productName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productName, result.Name);
            
            // Проверяем, что количество товара уменьшилось
            var productInInventory = vm.GetAllProducts().FirstOrDefault(p => p.Name == productName);
            Assert.NotNull(productInInventory);
            Assert.Equal(0, productInInventory.Quantity);
        }

        [Fact]
        public void PurchaseProduct_WithInsufficientBalance_ShouldReturnNull()
        {
            // Arrange
            var vm = new VendingMachineSystem();
            string productName = "Chips";
            decimal productPrice = 15;
            
            vm.AddProduct(productName, productPrice, 1);

            // Act
            var result = vm.PurchaseProduct(productName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CancelOperation_WhenCalled_ShouldResetBalance()
        {
            // Arrange
            var vm = new VendingMachineSystem();
            decimal insertedAmount = 10;
            vm.InsertCoin(insertedAmount);

            // Act
            var change = vm.CancelOperation();

            // Assert
            Assert.Equal(insertedAmount, change);
            Assert.Equal(0, vm.GetCurrentBalance());
        }

        [Fact]
        public void AddProduct_NewProduct_ShouldAddToInventory()
        {
            // Arrange
            var vm = new VendingMachineSystem();
            string productName = "Water";
            decimal price = 5;
            int quantity = 3;

            // Act
            vm.AddProduct(productName, price, quantity);

            // Assert
            var products = vm.GetAllProducts();
            var addedProduct = products.FirstOrDefault(p => p.Name == productName);
            Assert.NotNull(addedProduct);
            Assert.Equal(price, addedProduct.Price);
            Assert.Equal(quantity, addedProduct.Quantity);
        }

        [Fact]
        public void CollectMoney_WhenCalled_ShouldResetMoneyCollected()
        {
            // Arrange
            var vm = new VendingMachineSystem();
            
            // Симулируем сбор денег через покупку товара
            vm.AddProduct("Test", 50, 1);
            vm.InsertCoin(50);
            vm.PurchaseProduct("Test");

            // Act
            vm.CollectMoney();

            // Assert
            Assert.Equal(0, vm.GetCollectedMoney());
        }

        [Fact]
        public void RestockCoins_ValidDenomination_ShouldIncreaseCoinCount()
        {
            // Arrange
            var vm = new VendingMachineSystem();
            decimal denomination = 5;
            var initialCoins = vm.GetCoins();
            int initialCount = initialCoins[denomination];
            int coinsToAdd = 5;

            // Act
            vm.RestockCoins(denomination, coinsToAdd);

            // Assert
            var updatedCoins = vm.GetCoins();
            Assert.Equal(initialCount + coinsToAdd, updatedCoins[denomination]);
        }
    }

    public class ProductTests
    {
        [Fact]
        public void Product_Constructor_ShouldSetProperties()
        {
            // Arrange & Act
            var product = new Product("P001", "TestProduct", 10.5m, 5);

            // Assert
            // Assert.Equal("P001", product.Id); // Добавлена проверка Id
            Assert.Equal("TestProduct", product.Name);
            Assert.Equal(10.5m, product.Price);
            Assert.Equal(5, product.Quantity);
        }

        [Fact]
        public void Product_ToString_ShouldReturnFormattedString()
        {
            var product = new Product("P002", "Test", 15.0m, 3);

            var result = product.ToString();

            Assert.Contains("Test", result);
            Assert.Contains("15", result);
            Assert.Contains("3", result);
            Assert.Contains("Осталось", result);
        }   

}
}