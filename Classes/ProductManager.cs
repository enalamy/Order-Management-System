using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management_system.Classes
{
    public static class ProductManager
    {
        public static List<Product> products = new List<Product>();
        public static void AddProduct(Product product)
        {
            products.Add(product);
        }
        public static void AddProduct(params Product[] product)
        {
            products.AddRange(product);
        }

        public static void PrintAllProducts()
        {
            foreach (var product in products)
            {
                product.Print();
            }
        }
        public static void InitializeProducts()
        {
            Console.WriteLine("Запуск инициализации продуктов...");

            if (products == null)
            {
                Console.WriteLine("Ошибка: products == null, создаем новый список...");
                products = new List<Product>();
            }

            AddProduct(
                new Product("Телефон", 10000, "Айфон Эджимакс+"),
                new Product("Ноутбук", 50000, "MacBook Pro"),
                new Product("Планшет", 25000, "iPad Air"),
                new Product("Часы", 15000, "Apple Watch Series 7")
            );

            Console.WriteLine("Продукты успешно добавлены.");
        }
    }
}
