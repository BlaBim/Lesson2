using Lesson2.DAL;
using Lesson2.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{

    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public IEnumerable<User> GetAllUsersWithOrders()
        {
            return _userRepository.GetAllUsersWithOrders();
        }
        public User? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }


        public void AddUsers(List<User> users)
        {
            _userRepository.AddUsers(users);
        }

        public void DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
        }

        public void RemoveUsersById(int id)
        {
            _userRepository.DeleteUser(GetUserById(id));
        }
        public void RemoveUsersByName(string name)
        {
            _userRepository.DeleteUserByName(name);
        }
        public void RemoveUserAll()
        {
            _userRepository.DeleteUser(GetAllUsers().First());
        }
        public IEnumerable<User> GetUsersWhoOrderedProduct(int productId)
        {
            return _userRepository.GetUsersWhoOrderedProduct(productId);
        }

        public IEnumerable<User> GetUsersWithMoreThanThreeOrders()
        {
            return _userRepository.GetUsersWithMoreThanThreeOrders();
        }

    }
}
