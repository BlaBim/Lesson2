using Lesson2.DAL.Enteties;
using Lesson2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class ProductMenu
    {
        private ProductService _ProductService;
        private UserService _UserService;
        private OrderService _OrderService;

        public ProductMenu()
        {
            _ProductService = new ProductService();
            _UserService = new UserService();
            _OrderService = new OrderService();
        }

        public void Start()
        {
            bool cond = true;
            while (cond)
            {
                Console.WriteLine("1. Show all products");
                Console.WriteLine("2. Add new product");
                Console.WriteLine("3. Delete product by id");
                Console.WriteLine("4. Add new user");
                Console.WriteLine("5. Create new order");
                Console.WriteLine("6. Delete order");
                Console.WriteLine("7. Check if user ordered product");
                Console.WriteLine("8. Products ordered by user");
                Console.WriteLine("9. Users who ordered a product");
                Console.WriteLine("10. Show all orders ");
                Console.WriteLine("11. Users who ordered more than 3 products");
                Console.WriteLine("12. Order count per product");
                Console.WriteLine("13. Orders from last 7 days");
                Console.WriteLine("14. Users with no orders");
                Console.WriteLine("15. Order count per user");
                Console.WriteLine("16. Order with longest product name");
                Console.WriteLine("17. Delete orders older than 1 year");
                Console.WriteLine("18. Sort users by last order date");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        foreach (var product in _ProductService.GetAllProducts())
                            Console.WriteLine($"ID: {product.Id} Name: {product.Name} Price: {product.Price}");
                        break;

                    case "2":
                        Console.Clear();
                        var name = ConsoleEnter("Enter product name: ");
                        var price = ConsoleEnterDecimal("Enter product price: ");
                        _ProductService.AddProduct(new Product { Name = name, Price = price });
                        Console.WriteLine("Product added");
                        break;

                    case "3":
                        Console.Clear();
                        var idToDelete = ConsoleEnterInt("Enter product ID to delete: ");
                        _ProductService.DeleteProductById(idToDelete);
                        Console.WriteLine("Product deleted");
                        break;

                    case "4":
                        Console.Clear();
                        var userName = ConsoleEnter("Enter user name: ");
                        _UserService.AddUser(new User { Name = userName });
                        Console.WriteLine("User added");
                        break;

                    case "5":
                        Console.Clear();
                        int userId = ConsoleEnterInt("Enter user ID: ");
                        int productId = ConsoleEnterInt("Enter product ID: ");
                        var created = _OrderService.CreateOrder(userId, productId);
                        bool.TryParse(created, out bool result);
                        Console.WriteLine(result ? "Order created" : "Order not created (duplicate or invalid)");
                        break;

                    case "6":
                        Console.Clear();
                        int orderId = ConsoleEnterInt("Enter order ID to delete: ");
                        _OrderService.DeleteOrderById(orderId);
                        Console.WriteLine("Order deleted");
                        break;

                    case "7":
                        Console.Clear();
                        userId = ConsoleEnterInt("Enter user ID: ");
                        productId = ConsoleEnterInt("Enter product ID: ");
                        var hasOrdered = _OrderService.HasUserOrderedProduct(userId, productId);
                        Console.WriteLine(hasOrdered ? "Yes" : "No");
                        break;

                    case "8":
                        Console.Clear();
                        userId = ConsoleEnterInt("Enter user ID: ");
                        var orders = _OrderService.GetProductsByUser(userId);
                        foreach (var order in orders)
                        {
                            Console.WriteLine($"Product: {order.Product.Name}, Date: {order.CreationDate}");
                        }
                        break;

                    case "9":
                        Console.Clear();
                        productId = ConsoleEnterInt("Enter product ID: ");
                        var users = _OrderService.GetUsersByProduct(productId);
                        foreach (var order in users)
                        {
                            Console.WriteLine($"User: {order.User.Name}, Product: {order.Product.Name}, Date: {order.CreationDate}");
                        }
                        break;

                    case "10":
                        Console.Clear();
                        var orders2 = _OrderService.GetAllOrders();
                        foreach (var o in orders2)
                        {
                            Console.WriteLine($"Order ID: {o.Id}, Date: {o.CreationDate}, User Name: {o.User.Name}, Product Name: {o.Product.Name}");
                        }
                        break;
                    case "11":
                        Console.Clear();
                        var activeUsers = _UserService.GetUsersWithMoreThanThreeOrders();
                        foreach (var user in activeUsers)
                            Console.WriteLine(user.Name);
                        break;

                    case "12":
                        Console.Clear();
                        var orders3 = _OrderService.GetAllOrders(); 
                        var products = _ProductService.GetAllProducts(); 

                        foreach (var product in products)
                        {
                            int count = orders3.Count(order => order.Product.Id == product.Id);
                            Console.WriteLine($"{product.Name}: {count} orders");
                        }
                        break;
                    case "13":
                        Console.Clear();
                        var last7 = _OrderService.GetAllOrders()
                            .Where(o => o.CreationDate >= DateTime.Now.AddDays(-7));
                        foreach (var o in last7)
                            Console.WriteLine($"User name:{o.User.Name}, Product name: {o.Product.Name}, CreationDate: {o.CreationDate}");
                        break;
                    case "14":
                        Console.Clear();
                        var noOrders = _UserService.GetAllUsers()
                                                    .Where(u => !_OrderService.GetAllOrders().Any(o => o.UserId == u.Id));
                        foreach (var u in noOrders)
                            Console.WriteLine(u.Name);
                        break;
                    case "15":
                        Console.Clear();
                        var userOrders = _OrderService.GetAllOrders()
                            .GroupBy(o => o.User);
                        foreach (var group in userOrders)
                            Console.WriteLine($"{group.Key.Name} — {group.Count()} orders");
                        break;
                    case "16":
                        Console.Clear();
                        var longest = _OrderService.GetAllOrders()
                            .OrderByDescending(o => o.Product.Name.Length)
                            .FirstOrDefault();
                        if (longest != null)
                            Console.WriteLine($"{longest.User.Name} — {longest.Product.Name}");
                        break;
                    case "17":
                        Console.Clear();
                        var oldOrders = _OrderService.GetAllOrders()
                            .Where(o => o.CreationDate < DateTime.Now.AddYears(-1))
                            .ToList();
                        foreach (var order in oldOrders)
                            _OrderService.DeleteOrderById(order.Id);
                        Console.WriteLine("Old orders deleted");
                        break;
                    case "18":
                        Console.Clear();
                        var users2 = _UserService.GetAllUsers();
                        var sorted = users2.Select(u => new
                        {
                            User = u,
                            LastDate = _OrderService.GetAllOrders()
                                .Where(o => o.UserId == u.Id)
                                .OrderByDescending(o => o.CreationDate)
                                .Select(o => o.CreationDate)
                                .FirstOrDefault()
                        })
                        .OrderByDescending(x => x.LastDate);
                        foreach (var u in sorted)
                            Console.WriteLine($"{u.User.Name} — {u.LastDate}");
                        break;
                    case "0":
                        cond = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private string ConsoleEnter(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        private int ConsoleEnterInt(string text)
        {
            Console.Write(text);
            int.TryParse(Console.ReadLine(), out int value);
            return value;
        }

        private decimal ConsoleEnterDecimal(string text)
        {
            Console.Write(text);
            decimal.TryParse(Console.ReadLine(), out decimal value);
            return value;
        }
        private bool ConsoleEnterBool(string text)
        {
            Console.Write(text);
            bool.TryParse(Console.ReadLine(), out bool result);
            return result;
        }
    }
}