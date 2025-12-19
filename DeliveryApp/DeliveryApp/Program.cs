using System;
using DeliveryApp.Models;
using DeliveryApp.Pricing;
using DeliveryApp.Factories;
using DeliveryApp.Managers;

namespace DeliveryApp
{
    class Program
    {
        static void Main()
        {
            var menu = new Menu();
            menu.AddDish(new Dish("Burger", 100));
            menu.AddDish(new Dish("Pizza", 200));

            // Стандартный заказ
            IOrderFactory standardFactory = new StandardOrderFactory();
            var order1 = standardFactory.CreateOrder();
            order1.Dishes.Add(menu.GetDishes()[0]);
            OrderManager.Instance.AddOrder(order1);
            Console.WriteLine($"Статус заказа 1: {order1.GetStatus()}, Сумма: {order1.GetTotal()}");

            // Быстрая доставка
            IOrderFactory fastFactory = new FastDeliveryOrderFactory();
            var order2 = fastFactory.CreateOrder();
            order2.Dishes.Add(menu.GetDishes()[1]);
            OrderManager.Instance.AddOrder(order2);
            Console.WriteLine($"Статус заказа 2: {order2.GetStatus()}, Сумма: {order2.GetTotal()}");

            // Продвинуть состояния заказов
            OrderManager.Instance.AdvanceOrder(order1);
            OrderManager.Instance.AdvanceOrder(order2);
        }
    }
}
