using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management_system.Classes
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        private static int _lastId = 0;
        public string Description { get; private set; } 

        public Product(string name, int price, string description)
        {
            Id = ++_lastId;
            Name = name;
            Price = price;
            Description = description;
        }

        public void Print()
        {
            Console.WriteLine($"Товар: {Name}, Цена: {Price} руб.");
        }
    }
}


