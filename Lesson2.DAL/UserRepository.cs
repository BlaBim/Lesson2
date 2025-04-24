using Lesson2.DAL.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.DAL
{
    public class UserRepository
    {
        private readonly AppDbContext _context;


        public UserRepository()
        {
            _context = new AppDbContext();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }


        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }


        public User? GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }


        public IEnumerable<User> GetAllUsersWithOrders()
        {
            return _context.Users
                .Include(u => u.Orders)
                .ToList();
        }


        public User? GetUserByIdAndOrders(int id)
        {
            return _context.Users
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Id == id);
        }


        public User? GetUserByNameAndOrders(string name)
        {
            return _context.Users
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Name == name);
        }


        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void AddUsers(List<User> users)
        {
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }


        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }


        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


        public void DeleteUserById(int id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


        public void DeleteUserByName(string name)
        {
            var user = GetUserByName(name);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


        public void DeleteAllUsers()
        {
            var users = GetAllUsers();
            _context.Users.RemoveRange(users);
            _context.SaveChanges();
        }
        public IEnumerable<User> GetUsersWhoOrderedProduct(int productId)
        {
            return _context.Orders
                .Where(o => o.ProductId == productId)
                .Select(o => o.User)
                .Distinct()
                .ToList();
        }

        public IEnumerable<User> GetUsersWithMoreThanThreeOrders()
        {
            return _context.Orders
                .GroupBy(o => o.UserId)
                .Where(g => g.Count() > 3)
                .Select(g => g.First().User)
                .ToList();
        }
    }
}

