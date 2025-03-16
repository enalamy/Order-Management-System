using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Order_management_system.Classes
{
    public static class CustomerManager : ILogger
    {
        private static List<Customer> customers = new List<Customer>();

        public static void AddCustomer(Customer customer)
        {
            customers.Add(customer);

        }
        public static void AddCustomer(params Customer[] customer)
        {
            customers.AddRange(customer);
        }    

        public static void PrintAllCustomers()
        {
            foreach (var customer in customers)
            {
                customer.Print();
            }
        }
        public static void InitializeCustomers()
        {
            AddCustomer(
                new Customer("Алексей", "alex@mail.ru", "pass123"),
                new Customer("Мария", "maria@mail.ru", "securePass"),
                new Customer("Дмитрий", "dmitry@mail.ru", "qwerty123"),
                new Customer("Екатерина", "katya@mail.ru", "password321"),
                new Customer("Иван", "ivan@mail.ru", "ivanPass"),
                new Customer("1", "1", "1")
            ) ;
        }
        public static Customer? currentCustomer;
        public static bool Login()
        {
            Console.Write("Введите Email и Пароль через пробел: ");
            string input = Console.ReadLine()?.Trim() ?? ""; 

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Console.WriteLine("Ошибка! Нужно ввести Email и Пароль.");
                return false;
            }

            string email = parts[0].Trim();    
            string password = parts[1].Trim(); 

            // Проверяем, есть ли вообще клиенты в списке
            if (customers.Count == 0)
            {
                Console.WriteLine("Ошибка: база данных клиентов пуста.");
                return false;
            }

            
            currentCustomer = customers.FirstOrDefault(
                c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                  && c.Password == password // Пароль проверяем строго
            );

            if (currentCustomer != null)
            {
                Log($"Пользователь {currentCustomer.Nick} вошел в систему.");
                Console.WriteLine($"Добро пожаловать, {currentCustomer.Nick}!");
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка: неверный Email или пароль.");
                return false;
            }
        }

        public static Customer? Registration()
        {
            Console.Write("Приветствуем вас на регистрации! Введите Имя, Email и Пароль через пробел:");
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                Console.WriteLine("Ошибка! Нужно ввести Nick, Email и Пароль.");
                return null;
            }

            // Проверка email 
            if (!IsValidEmail(parts[1]))
            {
                Console.WriteLine("Ошибка! Введите корректный Email (например, user@example.com).");
                return null;
            }


            // Проверка пароля 
            if (parts[2].Length < 1)
            {
                Console.WriteLine("Ошибка! Пароль должен быть не менее 6 символов!");
                return null;
            }

            // Если всё ок — создаём пользователя
            Customer newCustomer = new Customer(parts[0], parts[1], parts[2]);
            CustomerManager.AddCustomer(newCustomer);

            Logger.Log($"Пользователь {newCustomer.Nick} успешно зарегестрировался!");
            Console.WriteLine("Регистрация успешна!");
            return newCustomer;
        }
        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

    }
}
