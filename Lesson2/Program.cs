using Lesson2.DAL.Enteties;
using Lesson2;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var prod = new ProductMenu();

            prod.Start();
        }
        //private ProductService _ProductService;
        //public Program()
        //{
        //    _ProductService = new ProductService();
        //}
        //static void Main(string[] args)
        //{
        //    bool cond = true;

        //    while (cond)
        //    {
        //        Console.WriteLine("1. Show all Products");
        //        Console.WriteLine("2. Add new Product");
        //        Console.WriteLine("3. Delete by id");
        //        Console.WriteLine("4. Delete by Name");
        //        Console.WriteLine("5. Delete by Price");
        //        Console.WriteLine("6. Update Name");
        //        Console.WriteLine("7. Update Price");
        //        Console.WriteLine("9. Exit");

        //        Console.Write("Enter your choise: ");
        //        string choice = Console.ReadLine();
        //        switch (choice)
        //        {
        //            case "1":
        //                var products = _ProductService.GetAllProducts();
        //                foreach (var student in products)
        //                {
        //                    Console.WriteLine($"ID: {student.Id} \t Name: {student.Name} \t Description: {student.Description}");
        //                }
        //                Console.Clear();
        //                break;
        //            case "2":
        //                string name = ConsoleEnter("Enter students name: ");
        //                string description = ConsoleEnter("Enter students description to delete: ");

        //                var newStudent = new Student
        //                {
        //                    Name = name,
        //                    Description = description
        //                };
        //                _StudentService.Add(newStudent);
        //                Console.WriteLine("Student added");
        //                break;
        //            case "3":
        //                int id = ConsoleEnterInt("Enter students id to Update");
        //                _StudentService.DeleteById(id);
        //                break;
        //            case "4":
        //                string nameDEL = ConsoleEnter("Enter students name to delete: ");
        //                _StudentService.DeleteByName(nameDEL);
        //                break;
        //            case "5":
        //                string desc = ConsoleEnter("Enter students description to delete: ");
        //                _StudentService.DeleteByDesc(desc);
        //                break;
        //            case "6":
        //                int idUPD = ConsoleEnterInt("Enter students id to Update");
        //                string nameUPD = ConsoleEnter("Enter new students name : ");
        //                _StudentService.UpdateName(idUPD, nameUPD);
        //                break;
        //            case "7":
        //                int idUPD2 = ConsoleEnterInt("Enter students id to Update");
        //                string descUPD2 = ConsoleEnter("Enter new students description : ");
        //                _StudentService.UpdateDesc(idUPD2, descUPD2);
        //                break;
        //            case "9":
        //                cond = false;
        //                break;
        //            default:
        //                Console.WriteLine("Eror choise");
        //                break;
        //        }
        //    }
        //}


        //var context = new AppDbContext();

        //var userAndOrder = context.Orders
        //    .Select(o => $"{o.User.Name} ordered {o.Product.Name} ({o.CreationDate})")
        //    .ToList();

        //foreach( var order in userAndOrder ) 
        //{
        //    Console.WriteLine(order);
        //}

        //var user = new User()
        //{
        //    Name = "Andrew"
        //};

        //var product = new Product()
        //{
        //    Name = "XBox",
        //    Price = 2000
        //};

        //var product2 = new Product()
        //{
        //    Name = "Samsung",
        //    Price = 2999
        //};

        //context.Users.Add(user);
        //context.Product.AddRange(product, product2);
        //context.SaveChanges();

        //var user1 = context.Users.FirstOrDefault();
        //var product1 = context.Product.FirstOrDefault();

        //var prod2 = context.Product.FirstOrDefault(p => p.Id == 2);

        //var order = new Order()
        //{
        //    UserId = user1.Id,
        //    ProductId = product.Id,
        //    CreationDate = DateTime.Now,
        //};

        //var order2 = new Order()
        //{
        //    UserId = user1.Id,
        //    ProductId = prod2.Id,
        //    CreationDate = DateTime.Now,
        //};

        //context.Orders.AddRange(order, order2);
        //context.SaveChanges();

        //----------------------------------------------------------------------
        ////ServiceMenu serviceMenu = new ServiceMenu();
        ////serviceMenu.Start();

        //var contex = new AppDbContext();

        //var user = new User()
        //{
        //    Name = "Andrew"
        //};

        //var order1 = new Order()
        //{
        //    ProductName = "SmartPhone",
        //    CreationDate = DateTime.Now,
        //};

        //var order2 = new Order()
        //{
        //    ProductName = "XBox",
        //    CreationDate = DateTime.Now,
        //};

        //user.Orders.Add(order1);
        //user.Orders.Add(order2);

        //contex.Users.Add(user);
        //contex.SaveChanges();
    }
    }
