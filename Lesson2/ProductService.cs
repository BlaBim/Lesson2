using Lesson2.DAL.Enteties;
using Lesson2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public IEnumerable<Product> GetAllProductsWithOrders()
        {
            return _productRepository.GetAllProductsWithOrders();
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            return _productRepository.GetProductByName(name);
        }
        public IEnumerable<Product> GetProductsByUser(int userId)
        {
            return _productRepository.GetAllProductsOrderedByUser(userId);
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }


        public void AddUsers(List<Product> product)
        {
            _productRepository.AddProducts(product);
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
        }
        public void DeleteProductById(int id)
        {
            var res = _productRepository.GetAllProducts()
                                        .FirstOrDefault(p => p.Id == id);
            _productRepository.DeleteProduct(res);
        }
        public void DeleteProductByName(string name)
        {
            var res = _productRepository.GetAllProducts()
                                        .FirstOrDefault(p => p.Name == name);
            _productRepository.DeleteProduct(res);
        }
        public void DeleteProductByPrice(decimal price)
        {
            var res = _productRepository.GetAllProducts()
                                        .FirstOrDefault(p => p.Price == price);
            _productRepository.DeleteProduct(res);
        }
        public void UpdateProductName(int id, string name)
        {
            var res = _productRepository.GetAllProducts()
                                            .FirstOrDefault(p => p.Id == id);
            res.Name = name;
            _productRepository.UpdateProduct(res);
        }
        public void UpdateProductPrice(int id, decimal price)
        {
            var res = _productRepository.GetAllProducts()
                                            .FirstOrDefault(p => p.Id == id);
            res.Price = price;
            _productRepository.UpdateProduct(res);
        }
        public IEnumerable<Product> GetProductsOrderedByUser(int userId)
        {
            return _productRepository.GetAllProductsOrderedByUser(userId);
        }

        public bool IsProductActive(int id)
        {
            return _productRepository.IsProductActive(id);
        }
        //public void RemoveProductsById(int id)
        //{
        //    _productRepository.DeleteProduct(GetProductById(id));
        //}
        //public void RemoveProductByName(string name)
        //{
        //    _productRepository.DeleteProductByName(name);
        //}
    }
}
