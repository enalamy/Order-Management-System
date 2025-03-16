using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management_system.Classes
{
    public class Order
    {

        public OrderStatus Status { get; set; } 
        private static int _lastId = 0;
        public int Id { get; }
        public string Customer {  get; set; }
        public string Product { get; set; }
        private static int _lastNum = 0; 
        public int Num { get; private set; }

        public Order(Customer customer, Product product, OrderStatus status = OrderStatus.Pending) 
        {
            Id = ++_lastId;
            Status = status; 
            Customer = customer.Nick;
            Product = product.Name;
        }
        public enum OrderStatus
        {
            InProcess,
            Cancelled,
            Pending,
        }
        public void PrintOrder()
        {
            Num = ++_lastNum;
            Console.WriteLine(Num + $".{Product}, статус - {Status}");
        }
    }
}
