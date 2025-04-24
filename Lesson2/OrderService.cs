using Lesson2.DAL.Enteties;
using Lesson2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class OrderService
    {
        private OrderRepository _orderRepository;
        private readonly UserRepository _userRepository;
        private readonly ProductRepository _productRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _userRepository = new UserRepository();
            _productRepository = new ProductRepository();
        }


        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders().ToList();
        }


        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }
        public IEnumerable<Order> GetProductsByUser(int id)
        {
            return _orderRepository.GetOrdersByUser(id);
        }
        public IEnumerable<Order> GetUsersByProduct(int productId)
        {
            return _orderRepository.GetOrdersByProduct(productId);
        }

        //public Order? GetOrderByProductName(string productName)
        //{
        //    return _orderRepository.GetOrderByProductName(productName);
        //}


        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }
        public string CreateOrder(int userId, int productId)
        {
            if (_userRepository.GetUserById(userId) == null)
                return "User nor found";

            if (!_productRepository.IsProductActive(productId))
                return "Product isn`t active";

            if (_orderRepository.HasUserOrderedProduct(userId, productId))
                return "User had already ordered this product";

            var order = new Order
            {
                UserId = userId,
                ProductId = productId,
                CreationDate = DateTime.Now
            };

            _orderRepository.AddOrder(order);
            return "Order created";
        }

        public void AddOrders(List<Order> orders)
        {
            _orderRepository.AddOrders(orders);
        }


        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }

        //public void UpdateProductName(int id, string productName)
        //{
        //    var order = _orderRepository.GetAllOrders()
        //                              .FirstOrDefault(o => o.Id == id);
        //    order.ProductName = productName;
        //    _orderRepository.UpdateOrder(order);
        //}

        public void DeleteOrder(Order order)
        {
            _orderRepository.DeleteOrder(order);
        }

        public void DeleteOrderById(int id)
        {
            var order = _orderRepository.GetAllOrders()
                                      .FirstOrDefault(o => o.Id == id);
            _orderRepository.DeleteOrder(order);
        }

        public void DeleteOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                _orderRepository.DeleteOrder(order);
            }
        }
        public bool HasUserOrderedProduct(int userId, int productId)
        {
            var orders = _orderRepository.GetAllOrders();
            foreach (var order in orders)
            {
                if (order.UserId == userId && order.ProductId == productId)
                {
                    return true; 
                }
            }
            return false;
        }
    }
}
