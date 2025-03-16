using Order_management_system.Classes;
class Program
{
    static void Main()
    {
        CustomerManager.InitializeCustomers();
        ProductManager.InitializeProducts();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в Orderility!");
            Console.WriteLine("1. Войти");
            Console.WriteLine("2. Зарегистрироваться");
            Console.WriteLine("3. Выйти");

            Console.Write("Введите номер действия: ");
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    CustomerManager.Login();
                    Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                    ShowMainMenu();
                    break;

                case "2":
                    var newCustomer = CustomerManager.Registration();
                    Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                    if (newCustomer != null)
                    {
                        CustomerManager.currentCustomer = newCustomer;
                        ShowMainMenu();
                    }
                    break;

                case "3":
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Ошибка: выберите действие из списка!");
                    break;
            }
        }
    }

    static void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Привет, {CustomerManager.currentCustomer?.Nick}!");
            Console.WriteLine("1. Сделать заказ");
            Console.WriteLine("2. Посмотреть мои заказы");
            Console.WriteLine("3. Выйти из аккаунта");

            Console.Write("Введите номер действия: ");
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    OrderManager.MakeOrder(CustomerManager.currentCustomer);
                    Console.ReadKey();
                    break;

                case "2":
                    OrderManager.PrintAllOrders();
                    Console.ReadKey();
                    break;

                case "3":
                    CustomerManager.currentCustomer = null;
                    return;

                default:
                    Console.WriteLine("Ошибка: выберите действие из списка!");
                    break;
            }
        }
        
    }
}
