using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Order_management_system.Classes
{
    public static class OrderManager 
    {
        public static List<Order> orders = new List<Order>();
        public static Order? currentOrder;
        public static void AddOrder(Order order)
        {
            orders.Add(order);

        }

        public static void MakeOrder(Customer currentCustomer)
        {
            Console.WriteLine($"Выберите товар:");
            foreach (var product in ProductManager.products)
            {
                Console.WriteLine($"{product.Id}. {product.Name} {product.Description} {product.Price} руб.");
            }

            int productId;
            if (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.WriteLine("Ошибка: введите корректный номер товара.");
                return;
            }

            Product selectedProduct = ProductManager.products.FirstOrDefault(p => p.Id == productId);

            if (selectedProduct == null)
            {
                Console.WriteLine("Ошибка: товар не найден.");
                return;
            }

            // Создаём новый заказ
            Order newOrder = new Order(currentCustomer, selectedProduct);

            // Добавляем заказ в список заказов
            orders.Add(newOrder);

            Console.WriteLine($"Заказ на {selectedProduct.Name} успешно оформлен!");
        }

        public static void PrintAllOrders()
        {
            int num = 1;
            foreach (var order in orders)
            {
                order.PrintOrder();
            }
        }
    }
}
