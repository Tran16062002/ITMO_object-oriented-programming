using System;
using System.Collections.Generic;
using DeliveryApp.Models;

namespace DeliveryApp.Managers
{
    public class OrderManager
    {
        private static readonly Lazy<OrderManager> instance = new Lazy<OrderManager>(() => new OrderManager());
        public static OrderManager Instance => instance.Value;

        private List<Order> orders = new List<Order>();

        private OrderManager() { }

        public void AddOrder(Order order) => orders.Add(order);
        public IEnumerable<Order> GetOrders() => orders.AsReadOnly();

        public void AdvanceOrder(Order order)
        {
            order.NextState();
            Console.WriteLine($"Заказ обновлен: {order.GetStatus()}");
        }
    }
}
