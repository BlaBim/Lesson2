using Lesson2.DAL.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.DAL
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;


        public ProductRepository()
        {
            _context = new AppDbContext();
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }


        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(u => u.Id == id);
        }


        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(u => u.Name == name);
        }
        public Product GetProductByPrice(decimal price)
        {
            return _context.Products.FirstOrDefault(p => p.Price == price);
        }
        public IEnumerable<Product> GetAllProductsWithOrders()
        {
            return _context.Products
                .Include(u => u.Orders)
                .ToList();
        }
        public Product GetProductByIdAndOrders(int id)
        {
            return _context.Products
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Id == id);
        }
        public Product GetProductByNameAndOrders(string name)
        {
            return _context.Products
                .Include(u => u.Orders)
                .FirstOrDefault(u => u.Name == name);
        }
        public Product GetProductByPriceAndOrders(decimal price)
        {
            return _context.Products
                .Include(p => p.Orders)
                .FirstOrDefault(p => p.Price == price);
        }


        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }


        public void AddProducts(List<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }


        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }


        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public IEnumerable<Product> GetAllProductsOrderedByUser(int userId)
        {
            return _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => o.Product)
                .Distinct()
                .ToList();
        }
        public bool IsProductActive(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;
            else
            {
                return true;
            }
        }
        //public void DeleteProductById(int id)
        //{
        //    var product = GetProductById(id);
        //    _context.Products.Remove(product);
        //    _context.SaveChanges();
        //}


        //public void DeleteProductByName(string name)
        //{
        //    var product = GetProductByName(name);
        //    _context.Products.Remove(product);
        //    _context.SaveChanges();
        //}
        //public void DeleteProductByPrice(decimal price)
        //{
        //    var product = GetProductByPrice(price);
        //    _context.Products.Remove(product);
        //    _context.SaveChanges();
        //}
    }
}

