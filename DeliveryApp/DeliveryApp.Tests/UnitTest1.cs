using DeliveryApp.Models;
using DeliveryApp.Pricing;
using DeliveryApp.State;
using System.Linq;

namespace DeliveryApp.Tests
{

    public class OrderTests
    {

        public void TestOrderTotalWithDiscount()
        {
            var dish = new Dish("Burger", 100);
            var order = new OrderBuilder()
                .AddDish(dish)
                .SetPricing(new DiscountPricing(10))
                .Build();

            Assert.Equal(90, order.GetTotal());
        }


        public void TestOrderStateTransition()
        {
            var order = new OrderBuilder().SetPricing(new StandardPricing()).Build();
            Assert.Equal("Подготовка", order.GetStatus());

            order.NextState();
            Assert.Equal("Доставка", order.GetStatus());

            order.NextState();
            Assert.Equal("Выполнен", order.GetStatus());
        }


        public void TestMultipleDishesTotal()
        {
            var order = new OrderBuilder()
                .AddDish(new Dish("Burger", 100))
                .AddDish(new Dish("Pizza", 200))
                .SetPricing(new StandardPricing())
                .Build();

            Assert.Equal(300, order.GetTotal());
        }
    }
}
