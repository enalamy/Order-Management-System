using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_management_system.Classes
{
    public class Customer 
    {
        public int Id { get; private set; }
        public string Nick { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        private static int _lastId = 0;

        public Customer(string nick, string email, string password)
        {
            Id = ++_lastId;
            Nick = nick;
            Email = email;
            Password = password;
        }
        
        public void Print()
        {
            Console.WriteLine($"Покупатель: {Nick}, Email: {Email}");
        }
    }
}
